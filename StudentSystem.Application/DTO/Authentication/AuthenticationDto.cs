namespace StudentSystem.Application.DTO.Authentication;

public record AuthenticationDto(
        string email,
        string password);