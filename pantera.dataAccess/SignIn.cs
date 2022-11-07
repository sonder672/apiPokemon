using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pantera.businessLogic.repository;
using Microsoft.EntityFrameworkCore;
using pantera.businessLogic;

namespace pantera.dataAccess
{
    public class SignIn : ISignIn
    {
        private readonly PanteraContext _context;

        public SignIn(PanteraContext context)
        {
            this._context = context;
        }

        public async Task<int?> login(string email, string password)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(user =>
            user.Email == email && user.Password == password
                );

            return user?.UserId;
        }
    }
}