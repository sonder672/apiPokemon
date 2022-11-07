using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pantera.businessLogic.repository;
using pantera.businessLogic;
using pantera.services.contracts;
using pantera.services.util;
using pantera.customException;

namespace pantera.services
{
    public class SignUpService : IServiceSignUp
    {
        private readonly ISignUp _create;
        private readonly IEmailValidator _validator;

        public SignUpService(ISignUp create, IEmailValidator validator)
        {
            this._create = create;
            this._validator = validator;
        }

        public async Task newUser(string email, string password)
        {
            Boolean emailExists = await this._validator.existingEmail(email);
            if (emailExists)
            {
                throw new HttpResponseException(400, new { message = "Existing email" });
            }

            UserEntity user = new UserEntity(email, password);
            string passwordEncrypt = new MD5Encrypt().encrypt(user.Password);

            await this._create.newUser(user.Email, passwordEncrypt);
        }
    }
}