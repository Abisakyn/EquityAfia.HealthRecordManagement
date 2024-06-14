using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Api.Controllers.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabResultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LabResultsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] LabResultsUploadCommand command)
        {
            var labResultId = await _mediator.Send(command);
            return Ok(labResultId);
        }
    }
}
