using Microsoft.AspNetCore.Mvc;
using StudentSystem.Application.Service.SubjectOfTeachers;
using StudentSystem.Application.Service.Users;

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



}
