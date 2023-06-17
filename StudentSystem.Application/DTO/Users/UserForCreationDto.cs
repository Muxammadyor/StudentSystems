using StudentSystem.Domain.Enums;

namespace StudentSystem.Application.DTO;

public record UserForCreationDto(
    string firstName,
    string lastName,
    string email,
    string phoneNumber,
    DateTime birthDate,
    string password,
    UserRole userRole);
