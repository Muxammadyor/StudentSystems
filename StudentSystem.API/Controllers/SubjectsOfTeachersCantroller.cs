using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO.SubjectsOfTeachers;
using StudentSystem.Application.DTO.Users;
using StudentSystem.Application.Service.SubjectOfTeachers;
using StudentSystem.Application.Service.Users;
using StudentSystem.Domain.Entities;

namespace StudentSystem.API.Controllers;

[Route("api/SsubjectsOfTeachers")]
[ApiController]
public class SubjectsOfTeachersCantroller : ControllerBase
{
    private readonly ISTService sTService;

    public SubjectsOfTeachersCantroller(ISTService sTService)
    {
        this.sTService = sTService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<UserDto>> PostUserAsync(
        STCreationDto sTForCreationDto)
    {
        var createdUser = await this.sTService
            .CreationAsync(sTForCreationDto);

        return Created("", createdUser);
    }

    [HttpGet("subjectid")]
    public IActionResult GetBySubjectId(Guid subjectId)
    {
        var storegST = this.sTService.RetriveBySubjectIdWhithDeteils(subjectId);

        return Ok(storegST);
    }

    [HttpGet("teacherid")]
    public IActionResult GetByTeacherId(Guid teacheId)
    {
        var storegST = this.sTService.RetriveByTeacherIdWhithDeteils(teacheId);

        return Ok(storegST);
    }
   



}
