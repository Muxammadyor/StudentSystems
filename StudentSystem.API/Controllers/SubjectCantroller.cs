using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO;
using StudentSystem.Application.Service.Subjects;
using System.Data;

namespace StudentSystem.API.Controllers;

[Route("api/subject")]
[Authorize(Roles = "Admin")]
[ApiController]
public class SubjectCantroller : ControllerBase
{
    private readonly ISubjectService subjectService;

    public SubjectCantroller(ISubjectService subjectService)
    {
        this.subjectService = subjectService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<SubjectDto>> PostSubjectAsync(SubjectForCreationDto subjectForCreationDto)
    {
        var createdSubject = await this.subjectService.CreateSubjectAsync(subjectForCreationDto);

        return Created("", createdSubject);
    }

    [HttpGet]
    public IActionResult GetAllSubjects()
    {
        var subjects = this.subjectService.RetriveSubjects();

        return Ok(subjects);
    }
}
