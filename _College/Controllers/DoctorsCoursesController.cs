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
    public class DoctorsCoursesController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public DoctorsCoursesController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetAssigns()
        {
            var doctorcourse = _dbContext.DoctorCourses.Include(s => s.Course).Include(s => s.Doctor).ToList();
            var mapped = _mapper.Map<List<GetDoctorCourseDto>>(doctorcourse);
            return Ok(new ApiResponse(200, mapped, "All Assigns retrived successfully"));
            
        }
        [HttpPost]
        public IActionResult AssignToCourse(DoctorCourseDto dto)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == dto.CourseId);
            if (course == null) return NotFound(new ApiResponse(404));

            var doctor = _dbContext.Doctors.FirstOrDefault(x => x.Id == dto.DoctorId);
            if (doctor == null) return NotFound(new ApiResponse(404));

            var doctorCourse = _mapper.Map<DoctorCourse>(dto);
            _dbContext.DoctorCourses.Add(doctorCourse);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(201,message: "Assignment success"));

        }
        [HttpDelete]
        public IActionResult Delete(DoctorCourseDto dto)
        {
            var doctorcourse = _dbContext.DoctorCourses.FirstOrDefault(dc => dc.DoctorId == dto.DoctorId && dc.CourseId == dto.CourseId);

            if (doctorcourse == null) return NotFound(new ApiResponse(404));

            _dbContext.DoctorCourses.Remove(doctorcourse);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(200, message: "Assignment deleted successfully"));
        }

    }
}
