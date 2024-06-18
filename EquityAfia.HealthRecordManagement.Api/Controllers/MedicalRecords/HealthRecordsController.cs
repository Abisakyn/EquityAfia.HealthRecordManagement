using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.HealthRecords;
using MediatR;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.PressureMap;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.PressureMapDTOs;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllHealthRecordsDTOs;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllMedicalRecords;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;


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

        [HttpGet("PressureMap")]
        public async Task<IActionResult> DisplayPressureMap([FromQuery]PressureMapDTO pressureMapDTO)
        {
            var query = new PressureMapQuery(pressureMapDTO);
            var records = await _mediator.Send(query);
            return Ok(records);
        }

        [HttpGet("ViewAllMedicalRecords")]

        public async Task<IActionResult> ViewAllMedicalRecords([FromQuery] ViewAllHealthRecordsDTO viewAllHealthRecordsDTO)
        {
            var query = new ViewAllHealthRecordsQuery(viewAllHealthRecordsDTO);
            var command = await _mediator.Send(query);
            return Ok(command);
        }
    }
}
