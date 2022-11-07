using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pantera.businessLogic.repository;
using pantera.services.contracts;
using pantera.services.util;
using pantera.customException;

namespace pantera.services
{
    public class SignInService : IServiceSignIn
    {
        private readonly ISignIn _signIn;
        private readonly IEmailValidator _validator;

        public SignInService(ISignIn signIn, IEmailValidator validator)
        {
            this._signIn = signIn;
            this._validator = validator;
        }

        public async Task<int?> accessTheAccount(string email, string password)
        {
            string passwordEncrypt = new MD5Encrypt().encrypt(password);
            int? existAccount = await this._signIn.login(email, passwordEncrypt);

            if (existAccount == null)
            {
                throw new HttpResponseException(404, new { message = "Wrong username or password" });
            }

            return existAccount;
        }
    }
}