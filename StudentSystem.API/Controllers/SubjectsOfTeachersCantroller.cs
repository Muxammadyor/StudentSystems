using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO;
using StudentSystem.Application.Service.SubjectOfTeachers;
using StudentSystem.Domain.Entities;
using System.Data;

namespace StudentSystem.API.Controllers;

[Route("api/subjectsofteachers")]
[Authorize]
[ApiController]
public class SubjectsOfTeachersCantroller : ControllerBase
{
    private readonly ISTService sTService;

    public SubjectsOfTeachersCantroller(ISTService sTService)
    {
        this.sTService = sTService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<SubjectsOfTeachers>> PostSTAsync(
        STCreationDto sTForCreationDto)
    {
        var createdST = await this.sTService
            .CreationAsync(sTForCreationDto);

        return Created("", createdST);
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
