using AutoMapper;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllLabResultsDTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllLabResults
{
    public class ViewAllLabResultsQueryHandler : IRequestHandler<ViewAllLabResultsQuery, List<ViewAllLabResultsDTOResponse>>
    {
        private readonly ILabResultsRepository _resultsRepository;
        private readonly IMapper _mapper;

        public ViewAllLabResultsQueryHandler(ILabResultsRepository resultsRepository, IMapper mapper)
        {
            _resultsRepository = resultsRepository;
            _mapper = mapper;
        }

        public async Task<List<ViewAllLabResultsDTOResponse>> Handle(ViewAllLabResultsQuery viewAllLabResultsQuery, CancellationToken cancellationToken)
        {
            var idNumber = viewAllLabResultsQuery.LabResults.IdNumber;
            var labResults = await _resultsRepository.GetAllLabResultsAsync(idNumber);

            var responses = labResults.Select(r => new ViewAllLabResultsDTOResponse
            {
                IdNumber = r.IdNumber,
                Diagnosis = r.Diagnosis,
                Test = r.Test,
                Results = r.Results,
                Prescriptions = r.Prescriptions,
                TestImage = ProcessFile(r.TestImage),
                ResultsImage = ProcessFile(r.ResultsImage)
            }).ToList();

            return responses;
        }

        private IFormFile ProcessFile(byte[] fileBytes)
        {
            return FormFileHelper.CreateFormFile(fileBytes);
        }
    }
}
