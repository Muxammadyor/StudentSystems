using StudentSystem.Application.DTO.Authentication;

namespace StudentSystem.Application.Service.AuthenticationService;

public interface IReportAuthenticationService
{
    Task<TokenDto> LoginAsync(AuthenticationDto authenticationDto);
    Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
