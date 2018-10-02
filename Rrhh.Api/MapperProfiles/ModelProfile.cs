using AutoMapper;
using Rrhh.Api.DTOs;
using Rrhh.Model.Entities;

namespace Rrhh.Api.MapperProfiles
{
    public class ModelProfile: Profile
    {
        public ModelProfile()
        {
            CreateMap<EmployeeType, EmployeeTypeDTO>()
                //.IgnoreAllNonExisting()
                .ReverseMap()
                .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<IdentificationType, IdentificationTypeDTO>()
               .ReverseMap()
               .ForMember(s => s.Id, opt => opt.Ignore());

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(d => d.EmployeeTypeId, opt => opt.MapFrom(s => s.EmployeeType.Id))
                .ForMember(d => d.EmployeeTypeDesc, opt => opt.MapFrom(s => s.EmployeeType.Description))
                .ForMember(d => d.IdentificationTypeId, opt => opt.MapFrom(s => s.IdentificationType.Id))
                .ForMember(d => d.IdentificationTypeDesc, opt => opt.MapFrom(s => s.IdentificationType.Description))
                .ReverseMap()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.EmployeeType, opt => opt.Ignore())
                .ForMember(s => s.IdentificationType, opt => opt.Ignore());
        }        
    }

    
}
