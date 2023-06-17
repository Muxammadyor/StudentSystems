using System.IdentityModel.Tokens.Jwt;
using StudentSystem.Domain.Entities;

namespace StudentSystem.Infrastructure.Authentication;

public interface IJwtTokenHandler
{
    JwtSecurityToken GenerateAccessToken(User user);
    string GenerateRefreshToken();
}