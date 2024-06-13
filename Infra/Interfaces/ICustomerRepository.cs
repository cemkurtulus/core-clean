using CreateCustomerDto = Infra.Dto.CreateCustomerDto;
using CustomerDto = Infra.Dto.CustomerDto;
using CustomerLoginDto = Infra.Dto.CustomerLoginDto;
using LoginRequestDto = Infra.Dto.LoginRequestDto;

namespace Infra.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<CustomerDto> GetCustomerById(Guid id);
        
        public Task<Guid> CreateCustomer(CreateCustomerDto model);
        
        public Task<CustomerLoginDto> Login(LoginRequestDto model);
    }
}
