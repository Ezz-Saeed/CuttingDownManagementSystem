using APIs.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController(IUnitOfWork unitOfWork, IIncidentGenerator incidentGenerator) : ControllerBase
    {
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
    }
}
