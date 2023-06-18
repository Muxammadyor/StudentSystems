using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO;
using StudentSystem.Application.DTO.SubjectsOfStudents;
using StudentSystem.Application.Service;
using StudentSystem.Domain.Entities;
using System.Data;

namespace StudentSystem.API.Controllers;

[Route("api/subjectsofstudents")]
[Authorize]
[ApiController]
public class SubjectsOfStudentsCantroller : ControllerBase
{
    private readonly ISSService sSService;

    public SubjectsOfStudentsCantroller(ISSService sSService)
    {
        this.sSService = sSService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<SubjectsOfStudents>> PostSTAsync(SSCreationDto sSCreationDto)
    {
        var createdSS = await this.sSService
            .CreationSSAsync(sSCreationDto);

        return Created("", createdSS);

    }

    [HttpGet("studentid")]
    public IActionResult GetByStudentId(Guid studentId)
    {
        var storegSS = this.sSService.RetriveByStudentId(studentId);

        return Ok(storegSS);
    }

    [HttpGet("teacherid")]
    public IActionResult GetByTeacherId(Guid teacherId)
    {
        var storegSS = this.sSService.RetriveByTeacherId(teacherId);

        return Ok(storegSS);
    }

    [HttpGet("subjectId")]
    public IActionResult GetBySubjectId(Guid subjectId)
    {
        var storegSS = this.sSService.RetriveBySubjectId(subjectId);

        return Ok(storegSS);
    }

    [HttpGet("id")]
    public IActionResult GetById(Guid id)
    {
        var storegSS = this.sSService.RetriveBySTId(id);

        return Ok(storegSS);

    }

    [HttpGet("mark")]
    public IActionResult GetByMark(int mark)
    {
        var storegSS = this.sSService.RetriveByMark(mark);

        return Ok(storegSS);

    }



    [HttpPut]
    public async ValueTask<ActionResult<SubjectsOfStudents>> PutSSAsync(SSForModificationDto sSForModificationDto)
    {
        var modifitedSS = await this.sSService.ModifySSAsync(sSForModificationDto);

        return Ok(modifitedSS);
    }


    
}
