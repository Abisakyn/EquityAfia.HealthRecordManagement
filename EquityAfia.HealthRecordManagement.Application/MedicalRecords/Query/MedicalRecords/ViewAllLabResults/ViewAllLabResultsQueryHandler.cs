//using AutoMapper;
//using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
//using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs;
//using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllLabResultsDTOs;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllLabResults
//{
//    public class ViewAllLabResultsQueryHandler : IRequestHandler<ViewAllLabResultsQuery, ViewAllLabResultsDTOResponse>
//    {
//        private readonly ILabResultsRepository _resultsRepository;
//        private readonly IMapper _mapper;

//        public ViewAllLabResultsQueryHandler(ILabResultsRepository resultsRepository, IMapper mapper)
//        {
//            _resultsRepository = resultsRepository;
//            _mapper = mapper;
//        }

//        public async Task<ViewAllLabResultsDTOResponse> Handle(ViewAllLabResultsQuery viewAllLabResultsQuery, CancellationToken cancellationToken)
//        {
//            var idNumber = viewAllLabResultsQuery.LabResults.IdNumber;
//            var labResults = await _resultsRepository.GetAllLabResultsAsync(idNumber);

//            //testImage = ProcessFile(labResults.Select(r => r.TestImage));
//            var respose = new ViewAllLabResultsDTOResponse
//            {
//                Results = labResults.Select(x => x.Results)


//            };
//        }

//        private IFormFile ProcessFile(byte[] fileBytes)
//        {
//            return FormFileHelper.CreateFormFile(fileBytes);
//        }


//    }
//}
