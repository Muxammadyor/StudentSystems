using StudentSystem.Application.DTO;
using StudentSystem.Application.Validation.Subjects;
using StudentSystem.Domain.Entities;
using StudentSystem.Domain.Exceptions;
using System.Text.Json;

namespace StudentSystem.Application.Service.Subjects
{
    public partial class SubjectService
    {
        public void ValidateStorageSubject(Subject storageSubject, Guid subjectId)
        {
            if (storageSubject is null)
            {
                throw new NotFoundException($"Couldn't find user with given id: {subjectId}");
            }
        }

        public void ValidateSubjectForCreationDto(
            SubjectForCreationDto subjectForCreationDto)
        {
            var validationResult = new SubjectForCreationDtoValidation()
                .Validate(subjectForCreationDto);

            ThrowValidationExceptionIfValidationIsInvalid(validationResult);
        }


        private static void ThrowValidationExceptionIfValidationIsInvalid(FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return;
            }

            var errors = JsonSerializer
                    .Serialize(validationResult.Errors.Select(error => new
                    {
                        PropertyName = error.PropertyName,
                        ErrorMessage = error.ErrorMessage,
                        AttemptedValue = error.AttemptedValue
                    }));

            throw new Domain.Exceptions.ValidationException(errors);
        }
    }
}

