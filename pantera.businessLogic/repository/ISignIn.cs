using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pantera.businessLogic.repository
{
    public interface ISignIn
    {
        public Task<int?> login(string email, string password);
    }
}