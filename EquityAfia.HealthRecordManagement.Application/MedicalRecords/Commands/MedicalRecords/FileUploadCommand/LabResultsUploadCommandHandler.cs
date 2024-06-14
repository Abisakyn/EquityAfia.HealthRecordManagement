using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using EquityAfia.HealthRecordManagement.Domain.MedicalRecordsAggregate.Entities;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommandHandler : IRequestHandler<LabResultsUploadCommand, Guid>
    {
        private readonly ILabResultsRepository _labResultsRepository;

        public LabResultsUploadCommandHandler(ILabResultsRepository labResultsRepository)
        {
            _labResultsRepository = labResultsRepository;
        }

        public async Task<Guid> Handle(LabResultsUploadCommand request, CancellationToken cancellationToken)
        {
            var labResultId = Guid.NewGuid();
            var uploadsRootFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsRootFolder);

            var testImagePath = Path.Combine(uploadsRootFolder, $"{labResultId}_test_{request.TestImage.FileName}");
            var resultsImagePath = Path.Combine(uploadsRootFolder, $"{labResultId}_results_{request.ResultsImage.FileName}");

            using (var testStream = new FileStream(testImagePath, FileMode.Create))
            {
                await request.TestImage.CopyToAsync(testStream);
            }

            using (var resultsStream = new FileStream(resultsImagePath, FileMode.Create))
            {
                await request.ResultsImage.CopyToAsync(resultsStream);
            }

            var labResults = new LabResults
            {
                Id = labResultId,
                Diagnosis = request.Diagnosis,
                Test = request.Test,
                Results = request.Results,
                Prescriptions = request.Prescriptions,
                TestImagePath = testImagePath,
                ResultsImagePath = resultsImagePath
            };

            await _labResultsRepository.AddAsync(labResults);

            return labResultId;
        }
    }
}
