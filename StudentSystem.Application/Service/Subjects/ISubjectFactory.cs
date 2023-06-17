using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.Subjects
{
    public interface ISubjectFactory
    {
        Subject MapToSubject(SubjectForCreationDto subjectForCreationDto);

        SubjectDto MapToSubjectDto(Subject subject);

    }
}
