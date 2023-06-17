using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public interface ISTService
    {

        ValueTask<SubjectsOfTeachers> CreationAsync(STCreationDto sTCreationDto);
        IQueryable<STDto> RetriveBySubjectIdWhithDeteils(Guid subjectId);
        IQueryable<STDto> RetriveByTeacherIdWhithDeteils(Guid teacherId);

    }
}
