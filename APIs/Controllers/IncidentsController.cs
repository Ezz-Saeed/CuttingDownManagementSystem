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
            await unitOfWork.CuttingDownAIncidents.AddRangeAsync(incidents);
            await unitOfWork.SaveChangesAsync();
            return Ok(new { Message = $"{incidents.Count} CuttingDownA incidents generated and saved." });
        }

        
        [HttpPost("generateIncidentsB")]
        public async Task<IActionResult> GenerateAndSaveIncidentsB([FromQuery] int count = 10, [FromQuery] int closedPercentage = 30)
        {
            var incidents = incidentGenerator.GenerateIncidentB(count, closedPercentage);
            await unitOfWork.CuttingDownBIncidents.AddRangeAsync(incidents);
            await unitOfWork.SaveChangesAsync();
            return Ok(new { Message = $"{incidents.Count} CuttingDownB incidents generated and saved." });
        }
    }
}
