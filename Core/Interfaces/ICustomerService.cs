using CreateCustomerApiModel = Core.Model.CreateCustomerApiModel;
using CustomerApiModel = Core.Model.CustomerApiModel;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        public Task<CustomerApiModel> GetCustomerById(Guid id);
        
        public Task<Guid> CreateCustomer(CreateCustomerApiModel apiModel);
    }
}
