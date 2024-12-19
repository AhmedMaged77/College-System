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
    public class DoctorsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public DoctorsController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var Doctors = _dbContext.Doctors.Where(d => d.IsActive).ToList();
            var mapped_Doctors = _mapper.Map<List<GetAllDoctorsDto>>(Doctors);
            return Ok(new ApiResponse(200, mapped_Doctors, "Doctors retrived successfully"));

        }
        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorDto dto)
        {
            var Doctor = _mapper.Map<Doctor>(dto);

            _dbContext.Add(Doctor);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(201));

        }
        
        [HttpPut]
        public IActionResult UpdateDoctor(UpdateDoctorDto dto)
        {
            var doctor = _dbContext.Doctors.Where(d => d.IsActive).FirstOrDefault(x => x.Id == dto.Id);
            if (doctor == null) return NotFound(new ApiResponse(404));
            var mapped_doctor = _mapper.Map(dto, doctor);
            _dbContext.Update(mapped_doctor);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Doctor updated successfully"));

        }
        [HttpDelete]
        public IActionResult DeleteDoctor(int id)
        {
            var Doctor = _dbContext.Doctors.Where(d => d.IsActive).FirstOrDefault(x => x.Id == id);
            if (Doctor == null)
            {
                return NotFound(new ApiResponse(404));
            }
            Doctor.IsActive = false;
            _dbContext.Update(Doctor);
            _dbContext.SaveChanges();
            return Ok(new ApiResponse(200, message: "Doctor removed successfully"));
        }
        

    }
}
