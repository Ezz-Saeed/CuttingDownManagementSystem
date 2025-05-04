using APIs.DTOs;
using APIs.Interfaces;
using APIs.Specifications;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController(IUnitOfWork unitOfWork, IIncidentGenerator incidentGenerator,
        IMapper mapper) : ControllerBase
    {

        private static readonly List<string> NetworkHierarchy = new()
            {
                "Governrate", "Sector", "Zone", "City", "Station", "Tower", "Cabin", "Cable", "Block", 
                "Building", "Flat", "Individual Subscription", "Corporate Subscription"
            };


        [HttpPost("generateIncidentsA")]
        public async Task<IActionResult> GenerateAndSaveIncidentsA([FromQuery] int count = 10, [FromQuery] int closedPercentage = 30)
        {
            var incidents = incidentGenerator.GenerateIncidentA(count, closedPercentage);
            await unitOfWork.CuttingDownAIncidents.AddRangeAsync(incidents.Result);
            await unitOfWork.SaveChangesAsync();
            return Ok(new { Message = $"{incidents.Result.Count} CuttingDownA incidents generated and saved." });
        }

        
        [HttpPost("generateIncidentsB")]
        public async Task<IActionResult> GenerateAndSaveIncidentsB([FromQuery] int count = 10, [FromQuery] int closedPercentage = 30)
        {
            var incidents = incidentGenerator.GenerateIncidentB(count, closedPercentage);
            await unitOfWork.CuttingDownBIncidents.AddRangeAsync(incidents.Result);
            await unitOfWork.SaveChangesAsync();
            return Ok(new { Message = $"{incidents.Result.Count} CuttingDownB incidents generated and saved." });
        }

        [HttpGet("ignoredIncidents")]
        public async Task<IActionResult> GetIgnoredIncidents()
        {
            var incidents = await unitOfWork.IgnoredIncidents.GetAllAsync(null);
            return Ok(incidents);
        }

        [HttpDelete("deleteIgnoredIncident/{id}")]
        public async Task<IActionResult> DeleteIgnoredIncident(int id)
        {
            var incident = await unitOfWork.IgnoredIncidents.GetEntityAsync(i => i.CuttingDownIgnoredKey == id);
            if(incident is null)
                return NotFound();
            unitOfWork.IgnoredIncidents.Delete(incident);
            await unitOfWork.SaveChangesAsync();
            return Ok(new { Message = "Ignored incident deleted." });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SpecificationParams searchParams)
        {
            var spec = new IncidentSpecifications(searchParams);
            var headers = await unitOfWork.Headers.GetAllAsync(spec);
            var headersDto = mapper.Map<List<GetHeaderDto>>(headers);
            return Ok(headersDto);
        }

        [HttpGet("channels")]
        public async Task<IActionResult> GetChannels()
        {
            var channels = await unitOfWork.Channels.GetAllAsync(null);
            return Ok(channels);
        }

        [HttpGet("problemTypes")]
        public async Task<IActionResult> GetProblemTypes()
        {
            var problemTypes = await unitOfWork.ProblemTypes.GetAllAsync(null);
            return Ok(problemTypes);
        }



        [HttpGet("getChildren")]
        public async Task<IActionResult> GetChildren([FromQuery] string name, [FromQuery] string type)
        {
            
            var element = await unitOfWork.NetworkElements.GetEntityAsync(e => e.NetworkElementName == name);
            if (element is null) return NotFound();

            var currentIndex = NetworkHierarchy.IndexOf(type);
            if (currentIndex == -1 || currentIndex == NetworkHierarchy.Count - 1)
                return Ok(new List<NetworkElementDto>());

            var nextLevelType = NetworkHierarchy[currentIndex + 1];

            var children = await unitOfWork.NetworkElements.GetAllAsyncWithExp(e =>
                e.ParentNetworkElementKey == element.NetworkElementKey &&
                e.NetworkElementType.NetworkElementTypeName == nextLevelType);

            var childrenDto = mapper.Map<List<NetworkElementDto>>(children);

            var result = new NetworkElementDto
            {
                NetworkElementKey = element.NetworkElementKey,
                NetworkElementName = element.NetworkElementName,
                NetworkElementType = element.NetworkElementType.NetworkElementTypeName,
                ParentKey = element.ParentNetworkElementKey,
                Children = childrenDto
            };

            return Ok(result);
        }

        [HttpGet("getHierarchy")]
        public IActionResult GetHierarchy()
        {
            return Ok(NetworkHierarchy);
        }

        [HttpGet("getIncidentDetails/{id}")]
        public async Task<IActionResult> GetIncidentDetails(int id)
        {
            var details = await unitOfWork.CuttingDownDetails.GetAllAsyncWithExp(i => i.NetworkElementKey == id);
            if (details == null || !details.Any()) return NotFound();

            var detailsDto = mapper.Map<List<DetailsDto>>(details);

            foreach (var item in detailsDto)
            {
                var element = await unitOfWork.NetworkElements.GetEntityAsync(e => e.NetworkElementKey == item.NetworkElementKey);
                item.NetworkElementName = element?.NetworkElementName;
            }

            return Ok(detailsDto);
        }



        //[HttpGet("searchByNetElement/{name}")]
        //public async Task<IActionResult> SearchByNetElement([FromQuery] string elementType, string name)
        //{
        //    var element = await unitOfWork.NetworkElements.GetEntityAsync(e=>e.NetworkElementName==name);
        //    if(element is null) return NotFound();

        //}


        //[HttpPut("closeIncident/{id}")]
        //public async Task<IActionResult> CloseIncident(int id)
        //{
        //    var incident = await unitOfWork.Headers.GetEntityAsync(i=>i.CuttingDownKey==id);
        //    if (incident is null) return NotFound();
        //    incident.ActualEndDate = DateTime.UtcNow;
        //}

    }
}
