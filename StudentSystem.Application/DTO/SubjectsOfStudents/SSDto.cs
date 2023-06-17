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
