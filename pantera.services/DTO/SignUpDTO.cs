using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pantera.services.DTO
{
    public class SignUpDTO
    {
        public string Email { get; }
        public string Password { get; }

        public SignUpDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}