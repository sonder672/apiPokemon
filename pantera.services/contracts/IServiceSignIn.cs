using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pantera.services.contracts
{
    public interface IServiceSignIn
    {
        public Task<int?> accessTheAccount(string email, string password);
    }
}