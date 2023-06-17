using StudentSystem.Application.DTO;
using StudentSystem.Application.DTO.SubjectsOfStudents;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service
{
    public interface ISSService
    {
        ValueTask<SubjectsOfStudents> CreationSS(SSCreationDto sSCreationDto);

        IQueryable<SSDto> RetriveByStudentId(Guid studentId);
        IQueryable<SSDto> RetriveBySubjectId(Guid subjectId);
        IQueryable<SSDto> RetriveByTeacherId(Guid teacherId);
        IQueryable<SSDto> RetriveBySTId(Guid stId);

        ValueTask<SubjectsOfStudents> ModifySSAsync(SSForModificationDto sSForModificationDto);

    }
}
