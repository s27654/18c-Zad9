using Microsoft.AspNetCore.Mvc;

namespace EfCodeFirst.Controller;

[Route("/api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStudentsAsync()
    {
        throw new NotImplementedException();
    }
}