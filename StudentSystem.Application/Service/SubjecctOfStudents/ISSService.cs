using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service
{
    public interface ISSService
    {
        ValueTask<SubjectsOfStudents> CreationSS(SSCreationDto sSCreationDto);

    }
}
