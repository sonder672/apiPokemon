using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pantera.services.contracts
{
    public interface IServiceSignUp
    {
        public Task newUser(string email, string password);
    }
}