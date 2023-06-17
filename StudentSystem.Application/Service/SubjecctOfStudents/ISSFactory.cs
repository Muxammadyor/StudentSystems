using StudentSystem.Application.DTO;
using StudentSystem.Application.DTO.SubjectsOfStudents;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service
{
    public interface ISSFactory
    {
        SubjectsOfStudents MapToSS(SSCreationDto sSCreationDto);

        SSDto MapToSSDto(SubjectsOfStudents subjectsOfStudents);

        void MaptoSS( SubjectsOfStudents subjectsOfStudents, SSForModificationDto sSForModificationDto);
    }
}
