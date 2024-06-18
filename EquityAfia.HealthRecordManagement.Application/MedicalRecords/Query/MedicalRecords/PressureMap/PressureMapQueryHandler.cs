using AutoMapper;
using EquityAfia.HealthRecordManagement.Application.MedicalRecords.Common.Interfaces;
using EquityAfia.HealthRecordManagement.Contracts.MedicalRecordsDTOs.PressureMapDTOs;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Query.MedicalRecords.PressureMap
{
    public class PressureMapQueryHandler : IRequestHandler<PressureMapQuery, PressureMapResponse>
    {
        private readonly IHealthRecordsRepository _healthRecordsRepository;
        private readonly IMapper _mapper;

        public PressureMapQueryHandler(IHealthRecordsRepository healthRecordsRepository, IMapper mapper)
        {
            _healthRecordsRepository = healthRecordsRepository;
            _mapper = mapper;
        }

        public async Task<PressureMapResponse> Handle(PressureMapQuery pressureMapQuery, CancellationToken cancellationToken)
        {
            var healthRecords = await _healthRecordsRepository.GetAllHealthRecordsAsync( pressureMapQuery.HealthRecords.IdNumber);

            var chartLabels = healthRecords.Select(r => r.Date.ToShortDateString()).ToArray();
            var systolicData = healthRecords.Select(r => r.Systolic).ToArray();
            var diastolicData = healthRecords.Select(r => r.Diastolic).ToArray();

            var response = new PressureMapResponse
            {
                ChartLabel = chartLabels,
                SystolicData = systolicData,
                DiastolicData = diastolicData

            };
            return response;
    }
    }

}
