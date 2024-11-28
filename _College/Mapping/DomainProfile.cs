using _College.DTOs;
using _College.Models;
using AutoMapper;

namespace _College.Mapping;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<Department, GetAllDepartmentDto>()
            .ForMember(dest => dest.NoOfStudents, opt => opt.MapFrom(src => src.Students.Count()));

        CreateMap<Department, GetSingleDepartmentDto>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();
    }
}
