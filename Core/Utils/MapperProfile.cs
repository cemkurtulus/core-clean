using AutoMapper;
using Core.Models;
using Infra.Dto;

namespace Core.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Infra To Core
            CreateMap<CustomerDto, CustomerModel>().ReverseMap();

        }
    }
}
