using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleApplication_API.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet (Name ="Mystudents")]
        public IActionResult GetAllStudents()
        {
            string[] students = ["Mani", "Kalai", "lokesh", "Abdhul"];
            return Ok(students);
        }
    }
}
