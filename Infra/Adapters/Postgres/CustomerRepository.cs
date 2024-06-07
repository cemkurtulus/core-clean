using Infra.Dto;
using Infra.Interfaces;

namespace Infra.Adapters.Postgres
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerDto GetCustomerById(Guid id)
        {
            return new CustomerDto
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "john@email.com",
            };
        }
    }
}
