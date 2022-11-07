using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pantera.businessLogic.valueObjects;

namespace pantera.businessLogic
{
    public class UserEntity
    {
        private string _email;
        private string _password;

        public UserEntity(string email, string password)
        {
            _email = (new EmailValueObject(email)).sanitate();
            _password = (new PasswordValueObject(password)).sanitate();
        }

        public string Email { get { return _email; } }
        public string Password { get { return _password; } }
    }
}