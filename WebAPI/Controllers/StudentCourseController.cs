/*using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    public class StudentCourseController
    {
        [ApiController]
        [Route("[controller]")]
        public class SudentCourseController : ControllerBase
        {

            private readonly IRepository<StudentCourse> _studentCourseRepository;


            public SudentCourseController(IRepository<StudentCourse> studentCourseRepository)
            {
                _studentCourseRepository = studentCourseRepository;
            }


            [HttpGet("get")]
            public IEnumerable<StudentCourse> Get()
            {
                return _studentCourseRepository.GetAll();
            }

            [HttpPost("add")]
            public ObjectResult Add(StudentCourseDto studentCourseDto)
            {
                _studentCourseRepository.Add(new StudentCourse(studentCourseDto.Name, studentCourseDto.Student));
                _studentCourseRepository.SaveChanges();
                return Ok("Asigned student to course successfully!");
            }

            [HttpDelete("delete")]
            public ObjectResult Delete(string student, string name)
            {
                var studentCourseFromDb = _studentCourseRepository.GetCourseByStudentAndName(name,student);
                if (studentCourseFromDb == null)
                    return NotFound("No student asigned to this course");
                _studentCourseRepository.Remove(studentCourseFromDb);
                _studentCourseRepository.SaveChanges();
                return Ok("Aignment deleted");
            }
        }
    }

}*/
