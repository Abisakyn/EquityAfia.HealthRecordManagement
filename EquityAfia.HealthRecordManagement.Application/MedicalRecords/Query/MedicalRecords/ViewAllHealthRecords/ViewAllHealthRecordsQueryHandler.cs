using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.ViewAllHealthRecordsDTOs;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.ViewAllMedicalRecords
{
    public class ViewAllHealthRecordsQueryHandler : IRequestHandler<ViewAllHealthRecordsQuery, List<ViewAllHealthRecordsResponse>>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;

        public ViewAllHealthRecordsQueryHandler(IHealthRecordsRepository healthRecordsRepository)
        {
            _healthRecordsRepository = healthRecordsRepository;
        }

        public async Task<List<ViewAllHealthRecordsResponse>> Handle(ViewAllHealthRecordsQuery viewAllHealthRecordsQuery, CancellationToken cancellationToken)
        {
            var idNumber = viewAllHealthRecordsQuery.ViewAllHealthRecords.IdNumber;
            var healthRecords = await _healthRecordsRepository.GetAllHealthRecordsAsync(idNumber);


            var response = healthRecords
                .OrderByDescending(r => r.Date)
                .Select(r => new ViewAllHealthRecordsResponse
                {
                    Systolic = r.Systolic,
                    Diastolic = r.Diastolic,
                    Height = r.Height,
                    Weight = r.Weight,
                })
                .ToList();

            return response;
        }
    }
}
