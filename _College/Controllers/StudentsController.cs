using _College.DTOs;
using _College.Errors;
using _College.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDBContext dbContext;
        private readonly IMapper _mapper;

        public StudentsController(AppDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            var student = _mapper.Map<Student>(dto);

            dbContext.Add(student);
            dbContext.SaveChanges();

            return Ok(new ApiResponse(201));

        }

    }
}
