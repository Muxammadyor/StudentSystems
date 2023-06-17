using StudentSystem.Application.DTO.SubjectsOfTeachers;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public interface ISTFactory
    {
        SubjectsOfTeachers MapToST(STCreationDto sTCreationDto);
    }
}
