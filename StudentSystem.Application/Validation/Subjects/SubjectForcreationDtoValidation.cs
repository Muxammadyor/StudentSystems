using FluentValidation;
using StudentSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Application.Validation.Subjects
{
    internal class SubjectForCreationDtoValidation : AbstractValidator<SubjectForCreationDto>
    {
        public SubjectForCreationDtoValidation()
        {
            RuleFor(subject => subject)
                .NotNull();

            RuleFor(subject => subject.name)
                .MaximumLength(20)
                .NotNull();
        }
    }
}
