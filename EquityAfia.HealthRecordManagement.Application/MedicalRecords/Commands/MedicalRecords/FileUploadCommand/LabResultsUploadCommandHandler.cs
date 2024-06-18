using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.Common;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommandHandler : IRequestHandler<LabResultsUploadCommand, Response>
    {
        private readonly ILabResultsRepository _labResultsRepository;

        public LabResultsUploadCommandHandler(ILabResultsRepository labResultsRepository)
        {
            _labResultsRepository = labResultsRepository;
        }

        public async Task<Response> Handle(LabResultsUploadCommand request, CancellationToken cancellationToken)
        {
            var labResult = request.LabResults;
            var labResultId =Guid.NewGuid();

            byte[] testimage =await  ProcessFile(labResult.TestImage!);

            byte[] resultimage = await ProcessFile(labResult.ResultsImage!);


            var labResults = new LabResults
            {
                LabResultsId = labResultId,
                IdNumber =labResult.IdNumber!,
                Diagnosis = labResult.Diagnosis!,
                Test = labResult.Test!,
                Results = labResult.Results!,
                Prescriptions = labResult.Prescriptions!,
                TestImage = testimage,
                ResultsImage = resultimage
            };

            await _labResultsRepository.AddAsync(labResults);

            var response = new Response
            {
                LabResultsId = labResultId,
            };

            return response;
        }

        private async Task<byte[]> ProcessFile(IFormFile file)
        {

            byte[] testimage;

            using (var memorystream = new MemoryStream())
            {
                await file.CopyToAsync(memorystream);

                testimage = memorystream.ToArray();
            } 
            return testimage;
        }
    }
}
