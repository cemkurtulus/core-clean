using Infra.Dto;
using Infra.Interfaces;
using System;

namespace Infra.Adapters.Postgres
{
    public class CustomerRepository(PostgresqlDbContext dbContext) : ICustomerRepository
    {
        public CustomerDto GetCustomerById(Guid id)
        {
            var customer = dbContext.Customers.Find(id);

            return customer == null
                ? throw new Exception("Customer not found")
                : new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            };
        }
    }
}
