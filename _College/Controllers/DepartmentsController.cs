//using _College.DTOs;
//using _College.Errors;
//using _College.Models;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace _College.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DepartmentsController : ControllerBase
//    {
//        private readonly AppDBContext _dbContext;
//        private readonly IMapper _mapper;

//        public DepartmentsController(AppDBContext dbContext, IMapper mapper)
//        {
//            _dbContext = dbContext;
//            _mapper = mapper;
//        }

//        [HttpGet]//baseUrl/api/Departments
//        public IActionResult GetAll()
//        {
//            var departments = _dbContext.Departments.Where(d => d.IsActive).Include(d => d.Students).ToList();
//            var mappedDepartments = _mapper.Map<List<GetAllDepartmentDto>>(departments);

//            return Ok(new ApiResponse(200, mappedDepartments, "Departments retrived successfully"));
//        }

//        [HttpGet("{id}")]//baseUrl/api/Departments?Id=1
//        public IActionResult GetById(int id)
//        {
//            var dept = _dbContext.Departments.Find(id);

//            if (dept is null)
//            {
//                return NotFound(new ApiResponse(404));
//            }
//            var mappedDept = _mapper.Map<GetSingleDepartmentDto>(dept);

//            return Ok(new ApiResponse(200, mappedDept, "Department retrived successfully"));
//        }

//        [HttpPost]
//        public IActionResult CreateDepartment(CreateDepartmentDto departmentDto)
//        {
//            var department = _mapper.Map<Department>(departmentDto);
//            _dbContext.Add(department);
//            _dbContext.SaveChanges();

//            return Ok(new ApiResponse(201));
//        }

//        [HttpPut]
//        public IActionResult UpdateDepartment(UpdateDepartmentDto departmentDto)
//        {
//            var department = _mapper.Map<Department>(departmentDto);
//            _dbContext.Update(department);
//            _dbContext.SaveChanges();

//            return Ok(new ApiResponse(200, message: "Department updated successfully"));
//        }

//        [HttpDelete]
//        public IActionResult DeleteDepartment(int id)
//        {
//            var department = _dbContext.Departments.FirstOrDefault(d => d.Id == id);

//            if (department is null)
//                return NotFound(new ApiResponse(404));

//            department.IsActive = false;

//            _dbContext.Update(department);
//            _dbContext.SaveChanges();

//            return Ok(new ApiResponse(200, message: "Department removed successfully"));
//        }

//    }
//}
