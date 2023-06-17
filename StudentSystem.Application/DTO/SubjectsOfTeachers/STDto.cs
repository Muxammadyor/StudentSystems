using StudentSystem.Application.DTO.Subject;
using StudentSystem.Application.DTO.Users;

namespace StudentSystem.Application.DTO.SubjectsOfTeachers
{
    public record STDto(
        Guid id,
        Guid teacherId,
        Guid subjectId,
        UserDto teacher,
        SubjectDto subject);
}
