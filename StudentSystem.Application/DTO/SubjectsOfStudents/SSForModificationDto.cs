namespace StudentSystem.Application.DTO.SubjectsOfStudents
{
    public record SSForModificationDto(
        Guid id,
        Guid studentId,
        Guid ssId,
        int mark);
}
