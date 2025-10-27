using EducationSys.Application.DTOs.Student;
using FluentValidation;

namespace EducationSys.Application.Validators.Student
{
    public  class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
    {
        public CreateStudentDtoValidator() {


            RuleFor(x => x.FirstName)
                   .NotEmpty().WithMessage("First name is required.")
                   .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

            
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");

            RuleFor(x => x.Age)
                .InclusiveBetween(18, 60).WithMessage("Age must be between 18 and 60.");

        }
    }
}
