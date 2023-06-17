namespace StudentSystem.Application.DTO.Authentication;

public record TokenDto(
string accessToken,
string? refreshToken,
DateTime expireDate);
