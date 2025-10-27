using EducationSys.Application.DTOs.Enrollment;
using FluentValidation;

namespace EducationSys.Application.Validators.Enrollment
{
   public class CreateEnrollmentDtoValidator : AbstractValidator<CreateEnrollmentDto>
    {
        public CreateEnrollmentDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0)
                .WithMessage("StudentId must be greater than 0");

            RuleFor(x => x.ClassId)
                .GreaterThan(0)
                .WithMessage("ClassId must be greater than 0");
        }
    }
}


