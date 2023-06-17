using StudentSystem.Application.DTO.Subject;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.Subjects
{
    public interface ISubjectFactory
    {
        Subject MapToSubject(SubjectForCreationDto subjectForCreationDto);

        SubjectDto MapToSubjectDto(Subject subject);

    }
}
