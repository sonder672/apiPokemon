using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pantera.businessLogic.repository
{
    public interface ISignUp
    {
        public Task newUser(string email, string password);
    }
}