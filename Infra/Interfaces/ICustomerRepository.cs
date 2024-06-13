using Dto.Dto;

namespace Infra.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<CustomerDto> GetCustomerById(Guid id);
        
        public Task<Guid> CreateCustomer(CreateCustomerDto model);
    }
}
