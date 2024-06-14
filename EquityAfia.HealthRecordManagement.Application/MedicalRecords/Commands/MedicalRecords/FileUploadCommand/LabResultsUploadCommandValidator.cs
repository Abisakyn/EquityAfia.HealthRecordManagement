using FluentValidation;

namespace EquityAfia.HealthRecordManagement.Application.MedicalRecords.Commands.MedicalRecords.FileUploadCommand
{
    public class LabResultsUploadCommandValidator : AbstractValidator<LabResultsUploadCommand>
    {
        public LabResultsUploadCommandValidator()
        {
            RuleFor(x => x.Diagnosis).NotEmpty();
            RuleFor(x => x.Test).NotEmpty();
            RuleFor(x => x.Results).NotEmpty();
            RuleFor(x => x.Prescriptions).NotEmpty();
            RuleFor(x => x.TestImage).NotNull().WithMessage("Test image is required.");
            RuleFor(x => x.ResultsImage).NotNull().WithMessage("Results image is required.");
        }
    }
}
