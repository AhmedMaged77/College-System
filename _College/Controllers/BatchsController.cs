﻿using _College.DTOs;
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
    public class BatchsController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public BatchsController(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var Batchs = _dbContext.Batchs.Where(d => d.IsActive).Include(d => d.Students).ToList();
            var mappedBatchs = _mapper.Map<List<GetAllBatchsDto>>(Batchs);

            return Ok(new ApiResponse(200, mappedBatchs, "Batchs retrived successfully"));
        }
        [HttpGet("GetExams")]
        public IActionResult GetExams(int id)
        {
            var courses = _dbContext.Courses.Where(c => c.IsActive).Where(c => c.BatchId == id).Where(c => c.Exam_Date != null).ToList();
            if (courses.Count == 0) return NotFound(404);

            var mapped_courses = _mapper.Map<List<GetExamsDto>>(courses);
            return Ok(new ApiResponse(200, mapped_courses, "Exams retrived successfully"));
        }
        [HttpPost]
        public IActionResult CreateBatch(CreateBatchDto BatchDto)
        {
            var Batch = _mapper.Map<Batch>(BatchDto);
            _dbContext.Add(Batch);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(201));
        }
        [HttpDelete]
        public IActionResult DeleteBatch(int id)
        {
            var Batch = _dbContext.Batchs.Include(b => b.Students).FirstOrDefault(b => b.Id == id);

            if (Batch is null)
                return NotFound(new ApiResponse(404));

            Batch.IsActive = false;

            if (Batch.Students != null && Batch.Students.Any())
            {
                _dbContext.Students.RemoveRange(Batch.Students);
            }

            _dbContext.Update(Batch);
            _dbContext.SaveChanges();

            return Ok(new ApiResponse(200, message: "Batch removed successfully"));
        }
    }
}
