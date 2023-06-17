using StudentSystem.Application.DTO.Subject;

namespace StudentSystem.Application.Service.Subjects
{
    public interface ISubjectService
    {
        ValueTask<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subjectForCreationDto);
        ValueTask<SubjectDto> RetriveByIdAsync(Guid subjectId);
        IQueryable<SubjectDto> RetriveSubjects();
    }
}
