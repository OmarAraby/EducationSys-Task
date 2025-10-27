using EducationSys.Application.DTOs.Class;
using FluentValidation;

namespace EducationSys.Application.Validators.Class
{
    public class UpdateClassDtoValidator : AbstractValidator<UpdateClassDto>
    {
        public UpdateClassDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Class name is required.")
                .MaximumLength(200).WithMessage("Class name cannot exceed 200 characters.");

            RuleFor(x => x.Teacher)
                .NotEmpty().WithMessage("Teacher name is required.")
                .MaximumLength(200).WithMessage("Teacher name cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters."); 
        }
    }
}
