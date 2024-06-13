using Dto.Dto;
using Infra.Adapters.Postgres.Entities;
using Infra.Interfaces;

namespace Infra.Adapters.Postgres
{
    public class CustomerRepository(PostgresqlDbContext dbContext) : ICustomerRepository
    {
        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            return customer == null
                ? throw new Exception("Customer not found")
                : new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            };
        }

        public async Task<Guid> CreateCustomer(CreateCustomerDto model)
        {
            var customer = new CustomerEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
            };

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();

            return customer.Id;
        }
    }
}
