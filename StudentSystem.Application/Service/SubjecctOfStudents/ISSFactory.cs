using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjecctOfStudents
{
    public interface ISSFactory
    {
        SubjectsOfStudents MapToSS(SSCreationDto sSCreationDto);
    }
}
