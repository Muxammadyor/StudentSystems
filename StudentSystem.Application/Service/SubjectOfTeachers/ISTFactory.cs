using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public interface ISTFactory
    {
        SubjectsOfTeachers MapToST(STCreationDto sTCreationDto);

        STDto MapToSTDto(SubjectsOfTeachers subjectsOfTeachers);
    }
}
