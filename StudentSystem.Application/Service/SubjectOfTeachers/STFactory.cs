using StudentSystem.Application.DTO.SubjectsOfTeachers;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Application.Service.SubjectOfTeachers
{
    public class STFactory : ISTFactory
    {
        public SubjectsOfTeachers MapToST(STCreationDto sTCreationDto)
        {
            return new SubjectsOfTeachers {
                SubjectId = sTCreationDto.subjectId,
                TeacherId = sTCreationDto.teacherId
            };
        }
    }
}
