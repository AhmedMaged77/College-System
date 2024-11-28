using _College.DTOs;
using _College.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _College.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDBContext dbContext;

        public DepartmentsController(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = dbContext.Departments.Include(d => d.Students).ToList();
            var mappedDepartments = new List<GetAllDepartmentDto>();
            foreach (var department in departments)
            {
                mappedDepartments.Add(new GetAllDepartmentDto
                {
                    Id = department.Id,
                    Name = department.Name,
                    NoOfStudents = department.Students.Count(),

                });
            }

            return Ok(mappedDepartments);
        }


    }
}
