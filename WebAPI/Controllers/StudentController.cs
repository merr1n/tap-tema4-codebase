using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IRepository<Student> _studentRepository;


        public StudentController(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAll();
        }

        [HttpGet("GetAllStudentdsPublicInfo")]
        public IEnumerable<StudentDto> GetStudentsInfo() {
            return _studentRepository.GetAll().Select(student => new StudentDto(student.Name, student.Surname, student.Email));
        }

        [HttpPost("add")]
        public ObjectResult Add(StudentDto studentDto)
        {
            _studentRepository.Add(new Student(studentDto.Name, studentDto.Surname, studentDto.Email));
            _studentRepository.SaveChanges();
            return Ok("Student added successfully!");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid studentId, StudentDto student)
        {
            var studentFromDb = _studentRepository.GetById(studentId);
            if (studentFromDb == null)
                return NotFound("Student not found!");
            studentFromDb.Name = student.Name;
            studentFromDb.Surname = student.Surname;
            studentFromDb.Email = student.Email;
            _studentRepository.SaveChanges();
            return Ok("Student updated!");
        }



        [HttpDelete("delete")]
        public ObjectResult Delete(Guid studentId)
        {
            var studentFromDb = _studentRepository.GetById(studentId);
            if (studentFromDb == null)
                return NotFound("Student doesn't exist!");
            _studentRepository.Remove(studentFromDb);
            _studentRepository.SaveChanges();
            return Ok("Student deleted!");
        }
    }
}
