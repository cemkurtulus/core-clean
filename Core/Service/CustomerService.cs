using AutoMapper;
using Core.Interfaces;
using Infra.Dto;
using Infra.Interfaces;
using CreateCustomerApiModel = Core.Model.CreateCustomerApiModel;
using CustomerApiModel = Core.Model.CustomerApiModel;

namespace Core.Service
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public async Task<CustomerApiModel> GetCustomerById(Guid id)
        {
            var customer =  await customerRepository.GetCustomerById(id);
            return mapper.Map<CustomerApiModel>(customer);
        }

        public async Task<Guid> CreateCustomer(CreateCustomerApiModel apiModel)
        {
            var customerDto = mapper.Map<CreateCustomerDto>(apiModel);
            var customerId = await customerRepository.CreateCustomer(customerDto);
            return customerId;
        }
    }
}
