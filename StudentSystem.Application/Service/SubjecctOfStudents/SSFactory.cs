using StudentSystem.Application.DTO;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service
{
    public class SSFactory : ISSFactory
    {
        public SubjectsOfStudents MapToSS(SSCreationDto sSCreationDto)
        {
            return new SubjectsOfStudents
            {
                StudentId = sSCreationDto.studentId,
                SubjectsOfTeachersId = sSCreationDto.sTId
            };
        }
    }
}
