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
    public class AdminsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public AdminsController(AppDBContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStudents(GetAdminDto dto)
        {
            var admin = _dbContext.Admins.FirstOrDefault(a => a.UserName == dto.UserName && a.Password == dto.Password);
            if (admin == null) return NotFound();
            return Ok(admin);

        }
    }
}
