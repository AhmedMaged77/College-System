using _College.DTOs;
using _College.Models;
using AutoMapper;

namespace _College.Mapping;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
      //  CreateMap<Department, GetAllDepartmentDto>()
       //     .ForMember(dest => dest.NoOfStudents, opt => opt.MapFrom(src => src.Students.Count()));

       // CreateMap<Department, GetSingleDepartmentDto>();
       // CreateMap<CreateDepartmentDto, Department>();
       // CreateMap<UpdateDepartmentDto, Department>();
        CreateMap<UpdateStudentDto,Student>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<Student, GetAllStudentsDto>()
            .ForMember(dest => dest.BatchName, opt => opt.MapFrom(src => src.Batch.Name))
            .ForMember(dest => dest.BatchYear, opt => opt.MapFrom(src => src.Batch.Year));
        CreateMap<Course, GetAllCoursesDto>()
            .ForMember(dest => dest.BatchName, opt => opt.MapFrom(src => src.Batch.Name));
        CreateMap<CreateCourseDto, Course>();
        CreateMap<Batch, GetAllBatchsDto>()
            .ForMember(dest => dest.NoOfStudents, opt => opt.MapFrom(src => src.Students.Count()));
        CreateMap<CreateBatchDto, Batch>();
        CreateMap<Doctor, GetAllDoctorsDto>();
        CreateMap<CreateDoctorDto,Doctor>();
        CreateMap<CreateExamDto,Course>();
    }
}
