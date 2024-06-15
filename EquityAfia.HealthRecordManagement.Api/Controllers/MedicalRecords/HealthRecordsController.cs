using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
using MediatR;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace EquityAfia.HealthRecordManagement.Api.Controllers.MedicalRecords
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class HealthRecordsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HealthRecordsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("AddMedicalRecord")]
        public async Task <IActionResult> AddMedicalRecord([FromBody]HealthRecordsDTO healthRecordsDTO)
        {
            var command = new HealthRecordsCommand(healthRecordsDTO);
            await _mediator.Send(command);
            return Ok(command);
        }
    }
}
