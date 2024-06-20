using AutoMapper;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.DownloadLabResults;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllLabResults;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.DownloadLabResultsDTOs;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllLabResultsDTOs;
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

        public LabResultsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] LabResultsDTO labResultsDTO)
        {
            var command = new LabResultsUploadCommand(labResultsDTO);
            var labResultId = await _mediator.Send(command);
            return Ok(labResultId);
        }

        [HttpGet("DownloadLabResult/{labResultsId}")]
        public async Task<IActionResult> DownloadLabResult([FromQuery] DownloadLabResultsDTO downloadLabResultsDTO)
        {
            var query = new DownloadLabResultsQuery(downloadLabResultsDTO);
            var result = await _mediator.Send(query);

            return new FileStreamResult(result.PdfFile.OpenReadStream(), "application/pdf")
            {
                FileDownloadName = $"LabResults_{downloadLabResultsDTO.LabResultsId}.pdf" 
            };
        }

        [HttpGet("ViewLabResults")]
        public async Task<IActionResult> ViewAllLabResults([FromQuery] ViewAllLabResultsDTO viewAllLabResultsDTO)
        {
            var query = new ViewAllLabResultsQuery(viewAllLabResultsDTO);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


    }
}
