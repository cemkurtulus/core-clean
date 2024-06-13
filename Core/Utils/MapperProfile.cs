using AutoMapper;
using Dto.Dto;
using Dto.Model;


namespace Core.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Infra To Core
            CreateMap<CustomerDto, CustomerModel>().ReverseMap();
            
            // Core To Infra
            CreateMap<CreateCustomerModel, CreateCustomerDto>().ReverseMap();
        }
    }
}
