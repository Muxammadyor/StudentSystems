using StudentSystem.Application.DTO;

namespace StudentSystem.Application.Service.Subjects
{
    public interface ISubjectService
    {
        ValueTask<SubjectDto> CreateSubjectAsync(SubjectForCreationDto subjectForCreationDto);
        ValueTask<SubjectDto> RetriveByIdAsync(Guid subjectId);
        IQueryable<SubjectDto> RetriveSubjects();
    }
}
