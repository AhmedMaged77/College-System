using _College.DTOs;
using _College.Models;
using AutoMapper;

namespace _College.Mapping;

public class DomainProfile : Profile
{
    public DomainProfile()
    {

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
        CreateMap<UpdateDoctorDto, Doctor>();
        CreateMap<Course,GetExamsDto>();
        CreateMap<DoctorCourseDto,DoctorCourse>();
        CreateMap<DoctorCourse, GetDoctorCourseDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name))
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Title));
       
            
    }
}
