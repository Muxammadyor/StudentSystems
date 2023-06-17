using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.DTO.Subject;
using StudentSystem.Application.Service.Subjects;

namespace StudentSystem.API.Controllers;

[Route("api/subject")]
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
