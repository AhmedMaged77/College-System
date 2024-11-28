using _College.DTOs;
using _College.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDBContext dbContext;

        public StudentsController(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                PhoneNum = dto.PhoneNum,
                Year = dto.Year,
                GPA = dto. GPA,
                DepartmentId = dto.DepartmentId,
            };
            dbContext.Add(student);
            dbContext.SaveChanges();
            return Ok(student);

        }
    }
}
