using _College.DTOs;
using _College.Errors;
using _College.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public StudentsController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            var students = _dbContext.Students.Where(s => s.IsActive).Include(s => s.Batch).ToList();
            var mapped_students = _mapper.Map<List<GetAllStudentsDto>>(students);
            return Ok(new ApiResponse(200, mapped_students, "Students retrived successfully"));

        }
        [HttpGet("{BatchId}")]
        public IActionResult GetStudentInBatch(int BatchId)
        {
            var students = _dbContext.Students.Where(s => s.IsActive).Where(s => s.BatchId== BatchId).Include(s => s.Batch).ToList();
            var mapped_students = _mapper.Map<List<GetAllStudentsDto>>(students);
            return Ok(new ApiResponse(200, mapped_students, "Students retrived successfully"));
        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);

            _dbContext.Add(student);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(201));

        }
        [HttpPut]
        public IActionResult EditStudent(UpdateStudentDto dto)
        {
            var student = _dbContext.Students.Where(s => s.IsActive).FirstOrDefault(x => x.Id == dto.BatchId);
            if (student == null)
            {
                return NotFound(new ApiResponse(404));
            }
            student = _mapper.Map(dto,student);
            _dbContext.Update(student);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Student updated successfully"));
        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = _dbContext.Students.Where(s => s.IsActive).FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound(new ApiResponse(404));
            }
            student.IsActive=false;
            _dbContext.Update(student);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Student removed successfully"));
        }

    }
}
