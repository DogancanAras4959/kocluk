using kocluk.SERVICES.Dtos.StudentsData;
using kocluk.SERVICES.Interface;
using Microsoft.AspNetCore.Mvc;

namespace kocluk.WEBAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentsDto>>> GetStudents()
        {
            return await _studentService.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentsDto>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);
            return student == null ? NotFound() : student;
        }

        [HttpGet("getStudent")]
        public async Task<ActionResult<StudentsDto>> GetStudentsByStudentName([FromQuery] string studentName)
        {
            var student = await _studentService.GetStudentAsyncStudentName(studentName);
            return student == null ? NotFound() : student;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutStudent(int id, StudentsDto student)
        {
            if (id == student.Id)
                return BadRequest();

            await _studentService.UpdateAsync(student);
            return NoContent();
        }

        [HttpPost("PostStudent")]
        public async Task<ActionResult<StudentsDto>> PostStudent(StudentsDto student)
        {
            await _studentService.InsertAsync(student);
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentsDto>> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);
            if (student != null)
                _studentService.Delete(student.Id);
            return NoContent();
        }
    }
}
