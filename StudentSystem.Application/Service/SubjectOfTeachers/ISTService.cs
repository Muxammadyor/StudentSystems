using StudentSystem.Application.DTO.SubjectsOfTeachers;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public interface ISTService
    {

        ValueTask<SubjectsOfTeachers> CreationAsync(STCreationDto sTCreationDto);
        IQueryable<SubjectsOfTeachers> RetriveBySubjectIdWhithDeteils(Guid subjectId);
        IQueryable<SubjectsOfTeachers> RetriveByTeacherIdWhithDeteils(Guid teacherId);

    }
}
