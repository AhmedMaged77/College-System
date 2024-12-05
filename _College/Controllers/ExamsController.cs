//using _College.DTOs;
//using _College.Errors;
//using _College.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace _College.Controllers;
//[Route("api/[controller]")]
//[ApiController]
//public class ExamsController : ControllerBase
//{
//    private readonly AppDBContext _dbContext;

//    public ExamsController(AppDBContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    [HttpPost]
//    public IActionResult CreateExam(CreateExamDto examDto)
//    {
//        var dept = _dbContext.Departments.Find(examDto.DepartmentId);

//        if (dept is null)
//            return NotFound(new ApiResponse(404));

//        var course = _dbContext.Courses.Find(examDto.CourseId);

//        if (course is null)
//            return NotFound(new ApiResponse(404));

//        var students = _dbContext.Students.Where(s => s.DepartmentId == examDto.DepartmentId).ToList();

//        if (students.Count() == 0)
//            return NotFound(new ApiResponse(404));

//        foreach (var student in students)
//        {

//            var studenCourse = _dbContext.StudentsCourses
//                .Where(sc => sc.StudentId == student.Id && sc.CourseId == examDto.CourseId).FirstOrDefault();

//            if (studenCourse is not null)
//            {

//                studenCourse.Exam_Duration = examDto.Exam_Duration;
//                studenCourse.Exam_Date = examDto.Exam_Date;
//                _dbContext.Update(studenCourse);
//                _dbContext.SaveChanges();

//            }
//        }

//        return Ok(new ApiResponse(200, message: "Exam details successfully for all students in the department."));
//    }
//}
