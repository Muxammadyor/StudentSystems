namespace StudentSystem.Application.DTO;
public record AuthenticationDto(
        string email,
        string password);