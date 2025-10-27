using EducationSys.Application.DTOs.Mark;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSys.Application.Validators.Mark
{
    public class CreateMarkDtoValidator : AbstractValidator<CreateMarkDto>
    {
        public CreateMarkDtoValidator()
        {
            RuleFor(x => x.StudentId)
                .GreaterThan(0)
                .WithMessage("StudentId must be greater than 0.");

            RuleFor(x => x.ClassId)
                .GreaterThan(0)
                .WithMessage("ClassId must be greater than 0.");

            RuleFor(x => x.ExamMark)
                .InclusiveBetween(0, 100)
                .WithMessage("ExamMark must be between 0 and 100.");

            RuleFor(x => x.AssignmentMark)
                .InclusiveBetween(0, 100)
                .WithMessage("AssignmentMark must be between 0 and 100.");
        }
    }
}
