using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Dto;

namespace Infra.Interfaces
{
    public interface ICustomerRepository
    {
        public CustomerDto GetCustomerById(Guid id);
    }
}
