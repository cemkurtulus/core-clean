using Dto.Model;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerModel> GetCustomerById(Guid id);
        
        public Task<Guid> CreateCustomer(CreateCustomerModel model);
    }
}
