namespace StudentSystem.Application.DTO.SubjectsOfTeachers
{
    public record STCreationDto(
        Guid subjectId,
        Guid teacherId);
}
