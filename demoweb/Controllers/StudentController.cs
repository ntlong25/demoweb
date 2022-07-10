using System.Threading.Tasks;
using demoweb.Entities;
using demoweb.Services;
using Microsoft.AspNetCore.Mvc;

namespace demoweb.Controllers
{
    [ApiController]
    [Route("/users")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/get-all")]
        public async Task<ActionResult> GetAll()
        {
            var items = await _studentService.GetAll();
            return Ok(items);
        }

        [HttpGet("/get-student")]
        public async Task<ActionResult> GetById(int id)
        {
            var item = await _studentService.GetStudent(id);
            return Ok(item);
        }

        [HttpPost("/create-student")]
        public async Task<ActionResult> Create(Student student)
        {
            var item = await _studentService.AddStudent(student);
            return Ok(item);
        }

        [HttpPut("/update-student")]
        public async Task<ActionResult> Update(Student student)
        {
            var item = await _studentService.UpdateStudent(student);
            return Ok(item);
        }

        [HttpDelete("/delete-student")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _studentService.DeleteStudent(id);
            return Ok(item);
        }

    }
}
