namespace StudentSystem.Application.DTO;

public record TokenDto(
string accessToken,
string? refreshToken,
DateTime expireDate);
