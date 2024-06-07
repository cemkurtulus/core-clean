using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infra.Interfaces;

namespace Core.Service
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public CustomerModel GetCustomerById(Guid id)
        {
            var customer = customerRepository.GetCustomerById(id);
            return mapper.Map<CustomerModel>(customer);
        }
    }
}
