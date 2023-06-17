using StudentSystem.Application.DTO;
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

        public STDto MapToSTDto(SubjectsOfTeachers subjectsOfTeachers)
        {
            UserDto? userDto = default;
            SubjectDto? subjectDto = default;

            if(subjectsOfTeachers.Teacher is not null)
            {
                userDto = new UserDto(
                    subjectsOfTeachers.Teacher.Id,
                    subjectsOfTeachers.Teacher.FirstName,
                    subjectsOfTeachers.Teacher.LastName,
                    subjectsOfTeachers.Teacher.Email,
                    subjectsOfTeachers.Teacher.PhoneNumber,
                    subjectsOfTeachers.Teacher.BirthDate,
                    subjectsOfTeachers.Teacher.Role
                    );
            }

            if(subjectsOfTeachers.Subject is not null)
            {
                subjectDto = new SubjectDto(
                    subjectsOfTeachers.Subject.Id,
                    subjectsOfTeachers.Subject.SubjectName);
            }

            return new STDto(
                subjectsOfTeachers.Id,
                subjectsOfTeachers.TeacherId,
                subjectsOfTeachers.SubjectId,
                userDto,
                subjectDto);
        }
    }
}
