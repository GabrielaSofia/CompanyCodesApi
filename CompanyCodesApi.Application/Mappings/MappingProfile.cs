using AutoMapper;
using CompanyCodesApi.Application.DTOs.Codes;
using CompanyCodesApi.Application.DTOs.Enterprises;
using CompanyCodesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyCodesApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Enterprise, EnterpriseResponseDto>();
            CreateMap<CreateEnterpriseDto, Enterprise>();
            CreateMap<UpdateEnterpriseDto, Enterprise>();

            CreateMap<Code, CodeResponseDto>();
            CreateMap<CreateCodeDto, Code>();
            CreateMap<UpdateCodeDto, Code>();

            CreateMap<Enterprise, EnterpriseResponseDto>()
                .ForMember(dest => dest.Codes, opt => opt.MapFrom(src => src.Codes));
        }
    }
}
