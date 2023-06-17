namespace StudentSystem.Application.DTO.Authentication;

public record RefreshTokenDto(
    string accessToken,
    string refreshToken);