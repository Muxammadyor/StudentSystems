﻿using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO.Users;
using StudentSystem.Application.Service.Users;
using StudentSystem.Domain.Enums;

namespace StudentSystem.API.Controllers;


[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(
        IUserService userService)
    {
        this.userService = userService;
    }


    [HttpPost]
    public async ValueTask<ActionResult<UserDto>> PostUserAsync(
        UserForCreationDto userForCreationDto)
    {
        var createdUser = await this.userService
            .CreateUserAsync(userForCreationDto);

        return Created("", createdUser);
    }

    [HttpGet]
    public IActionResult GetAlUser(UserRole role)
    {
        
        var user = this.userService.RetrieveUserByRole(role);
        return Ok(user);
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
        Guid userId)
    {

        var user = await this.userService
            .RetrieveUserByIdAsync(userId);

        return Ok(user);
    }


    [HttpPut]
    public async ValueTask<ActionResult<UserDto>> PutUserAsync(
        UserForModificationDto userForModificationDto)
    {
        var modifiedUser = await this.userService
            .ModifyUserAsync(userForModificationDto);

        return Ok(modifiedUser);
    }

    [HttpDelete("{userId:guid}")]
    public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
        Guid userId)
    {
        var removed = await this.userService
            .RemoveUserAsync(userId);

        return Ok(removed);
    }
}

