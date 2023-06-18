using StudentSystem.Application.DTO;

namespace StudentSystem.Application.Service.AuthenticationService;

public interface IStudentSystemAuthenticationService
{
    Task<TokenDto> LoginAsync(AuthenticationDto authenticationDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
