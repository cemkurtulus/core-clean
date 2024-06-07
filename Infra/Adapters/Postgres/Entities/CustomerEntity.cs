using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Adapters.Postgres.Entities
{
    internal class CustomerEntity
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }
    }
}
