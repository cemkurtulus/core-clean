using AutoMapper;
using Core.Interfaces;
using Dto.Dto;
using Dto.Model;
using Infra.Interfaces;

namespace Core.Service
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public async Task<CustomerModel> GetCustomerById(Guid id)
        {
            var customer =  await customerRepository.GetCustomerById(id);
            return mapper.Map<CustomerModel>(customer);
        }

        public async Task<Guid> CreateCustomer(CreateCustomerModel model)
        {
            var customerDto = mapper.Map<CreateCustomerDto>(model);
            var customerId = await customerRepository.CreateCustomer(customerDto);
            return customerId;
        }
    }
}
