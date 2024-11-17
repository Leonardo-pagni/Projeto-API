using AutoMapper;
using PrimeiraApi.Domain.Model;
using PrimeiraApi.Domain.DTOs;

namespace PrimeiraApi.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.EmployeeName, m => m.MapFrom(orig => orig.Nome));
        }
    }
}
