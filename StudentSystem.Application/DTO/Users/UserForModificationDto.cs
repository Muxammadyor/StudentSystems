﻿using StudentSystem.Domain.Enums;

namespace StudentSystem.Application.DTO
{
    public record UserForModificationDto(
        Guid id,
        string? firstName,
        string? lastName,
        string? email,
        string? phoneNumber,
        DateTime? birthDate,
        UserRole? userRole);
}
