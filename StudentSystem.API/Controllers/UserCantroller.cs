using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO;
using StudentSystem.Application.Service.Users;
using StudentSystem.Domain.Enums;
using System.Data;

namespace StudentSystem.API.Controllers;


[Route("api/users")]
[Authorize(Roles = "Admin")]
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

    [HttpGet("substringstudent")]
    public async ValueTask<ActionResult<UserDto>> GetUserBySubstringStudent(
        string substring)
    {

        var user = this.userService
            .RetriveUserBySubStringStudent(substring);

        return Ok(user);
    }

    [HttpGet("substringteacher")]
    public async ValueTask<ActionResult<UserDto>> GetUserBySubstringTeacher(
        string substring)
    {

        var user = this.userService
            .RetriveUserBySubStringTeacher(substring);

        return Ok(user);
    }
    
    [HttpGet("phoneteacher")]
    public async ValueTask<ActionResult<UserDto>> GetUserByPhoneNumberTeacher(
        string phoneNumber)
    {

        var user = this.userService
            .RetriveUserByPhoneNumberTeacher(phoneNumber);

        return Ok(user);
    }
    
    [HttpGet("phonestudent")]
    public async ValueTask<ActionResult<UserDto>> GetUserByPhoneNumberStudent(
        string phoneNumber)
    {

        var user = this.userService
            .RetriveUserByPhoneNumberStudent(phoneNumber);

        return Ok(user);
    }

    [HttpGet("agestudent")]
    public async ValueTask<ActionResult<UserDto>> GetUserByAgeStudent(
        int age)
    {

        var user = this.userService
            .RetriveUserByAgeStudent(age);

        return Ok(user);
    }
    
    [HttpGet("ageteacher")]
    public async ValueTask<ActionResult<UserDto>> GetUserByAgeTeacher(
        int age)
    {

        var user = this.userService
            .RetriveUserByAgeTeacher(age);

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


