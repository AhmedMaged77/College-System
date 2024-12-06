using _College.DTOs;
using _College.Errors;
using _College.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public CoursesController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var Courses = _dbContext.Courses.Where(c => c.IsActive).Include(c => c.Batch).ToList();
            var mapped_students = _mapper.Map<List<GetAllCoursesDto>>(Courses);
            return Ok(new ApiResponse(200, mapped_students, "Courses retrived successfully"));

        }
        [HttpPost]
        public IActionResult CreateCourse(CreateCourseDto dto)
        {
            var Course = _mapper.Map<Course>(dto);

            _dbContext.Add(Course);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(201));

        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var Cousrse = _dbContext.Courses.Where(s => s.IsActive).FirstOrDefault(x => x.Id == id);
            if (Cousrse == null)
            {
                return NotFound(new ApiResponse(404));
            }
            Cousrse.IsActive = false;
            _dbContext.Update(Cousrse);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Course removed successfully"));
        }
        [HttpPost("AddExam")]
        public IActionResult AddExam(CreateExamDto dto)
        {
            var course = _dbContext.Courses.FirstOrDefault(d => d.Id == dto.CourseId);
            if (course == null)
            {
                return NotFound();
            }
            course.Exam_Duration = dto.Exam_Duration;
            course.Exam_Date = dto.Exam_Date;
            _dbContext.Update(course);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Exam added"));

        }

    }
}
