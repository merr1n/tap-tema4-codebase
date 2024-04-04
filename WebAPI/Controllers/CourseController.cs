using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly IRepository<Course> _courseRepository;


        public CourseController(IRepository<Course> CourseRepository)
        {
            _courseRepository = CourseRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        [HttpGet("GetAllCoursesInfo")]
        public IEnumerable<CourseDto> GetCoursesInfo()
        {
            return _courseRepository.GetAll().Select(course => new CourseDto(course.Name));
        }

        [HttpPost("add")]
        public ObjectResult Add(CourseDto courseDto)
        {
            _courseRepository.Add(new Course(courseDto.Name));
            _courseRepository.SaveChanges();
            return Ok("Course added successfully!");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid courseId, CourseDto course)
        {
            var courseFromDb = _courseRepository.GetById(courseId);
            if (courseFromDb == null)
                return NotFound("Course not found!");
            courseFromDb.Name = course.Name;
            _courseRepository.SaveChanges();
            return Ok("Course updated!");
        }



        [HttpDelete("delete")]
        public ObjectResult Delete(Guid courseId)
        {
            var courseFromDb = _courseRepository.GetById(courseId);
            if (courseFromDb == null)
                return NotFound("Course doesn't exist!");
            _courseRepository.Remove(courseFromDb);
            _courseRepository.SaveChanges();
            return Ok("Course deleted!");
        }
    }
}
