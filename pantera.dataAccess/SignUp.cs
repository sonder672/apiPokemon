using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pantera.businessLogic.repository;

namespace pantera.dataAccess
{
    public class SignUp : ISignUp
    {
        private readonly PanteraContext _context;

        public SignUp(PanteraContext context) {
            this._context = context;
        }

        public async Task newUser(string email, string password)
        {
            User userEF = new User();
            userEF.Email = email;
            userEF.Password = password;
            
            this._context.Add(userEF);
            await this._context.SaveChangesAsync();
        }
    }
}