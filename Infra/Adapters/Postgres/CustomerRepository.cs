using System.Security.Cryptography;
using Infra.Adapters.Postgres.Entities;
using Infra.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using CreateCustomerDto = Infra.Dto.CreateCustomerDto;
using CustomerDto = Infra.Dto.CustomerDto;
using CustomerLoginDto = Infra.Dto.CustomerLoginDto;
using LoginRequestDto = Infra.Dto.LoginRequestDto;

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
            var salt = RandomNumberGenerator.GetBytes(128 / 8);
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: model.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            
            var customer = new CustomerEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                PasswordSalt = Convert.ToBase64String(salt),
                Password = hashed,
            };

            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<CustomerLoginDto> Login(LoginRequestDto model)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: model.Password,
                salt: Convert.FromBase64String(customer.PasswordSalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            
            if (hashed != customer.Password)
            {
                throw new Exception("Invalid login credentials");
            }
            
            return new CustomerLoginDto {
               Status = true,
               CustomerId = customer.Id
            };
        }
    }
}
