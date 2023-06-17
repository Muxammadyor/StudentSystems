﻿using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO.Authentication;
using StudentSystem.Application.Service.AuthenticationService;

namespace StudentSystem.API.Controllers;


[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IReportAuthenticationService authenticationService;

    public AuthController(
        IReportAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<TokenDto>> LoginAsync(
        AuthenticationDto authenticationDto)
    {
        var tokenDto = await this.authenticationService
            .LoginAsync(authenticationDto);

        return Ok(tokenDto);
    }

    [HttpPost("refresh-token")]
    public async ValueTask<ActionResult<TokenDto>> RefreshTokenAsync(
        RefreshTokenDto refreshTokenDto)
    {
        var tokenDto = await this.authenticationService
            .RefreshTokenAsync(refreshTokenDto);

        return Ok(tokenDto);
    }
}
