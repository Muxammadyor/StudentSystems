using StudentSystem.Application.DTO.SubjectsOfTeachers;
using StudentSystem.Application.DTO.Users;

namespace StudentSystem.Application.DTO.SubjectsOfStudents
{
    public record SSDto(
        Guid id,
        Guid studentId,
        Guid sTId,
        UserDto student,
        STDto st,
        int mark);
}
