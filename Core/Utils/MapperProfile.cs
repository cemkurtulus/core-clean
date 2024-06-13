using AutoMapper;
using Infra.Dto;
using CreateCustomerApiModel = Core.Model.CreateCustomerApiModel;
using CustomerApiModel = Core.Model.CustomerApiModel;
using LoginRequestApiModel = Core.Model.LoginRequestApiModel;


namespace Core.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Infra To Core
            CreateMap<CustomerDto, CustomerApiModel>().ReverseMap();
            CreateMap<LoginRequestDto, LoginRequestApiModel>().ReverseMap();
            
            // Core To Infra
            CreateMap<CreateCustomerApiModel, CreateCustomerDto>().ReverseMap();
        }
    }
}
