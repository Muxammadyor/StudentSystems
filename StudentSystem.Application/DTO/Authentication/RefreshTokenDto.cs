namespace StudentSystem.Application.DTO;

public record RefreshTokenDto(
    string accessToken,
    string refreshToken);