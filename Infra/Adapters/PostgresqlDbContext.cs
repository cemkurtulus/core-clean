using Infra.Adapters.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Adapters
{
    public class PostgresqlDbContext(IConfiguration configuration) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
