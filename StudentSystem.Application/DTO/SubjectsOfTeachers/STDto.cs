namespace StudentSystem.Application.DTO
{
    public record STDto(
        Guid id,
        Guid teacherId,
        Guid subjectId,
        UserDto teacher,
        SubjectDto subject);
}
