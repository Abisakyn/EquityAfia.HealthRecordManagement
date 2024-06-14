using AutoMapper;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
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
        private readonly IMapper _mapper;

        public LabResultsController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] LabResultsDTO LabResultsDTO)
        {
            var command = new LabResultsUploadCommand(LabResultsDTO);
            var labResultId = await _mediator.Send(command);
            //var mappedResult =_mapper.Map<LabResultsDTO>(labResultId);
            return Ok(labResultId);
        }
    }
}
