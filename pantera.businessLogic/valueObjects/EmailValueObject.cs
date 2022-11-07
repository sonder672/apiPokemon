using System.ComponentModel.DataAnnotations;
using pantera.customException;

namespace pantera.businessLogic.valueObjects
{
    public class EmailValueObject
    {
        private string _email;

        public EmailValueObject(string email)
        {
            _email = email;
        }

        public string sanitate()
        {
            if (!new EmailAddressAttribute().IsValid(this._email))
            {
                throw new HttpResponseException(422, new { message = "Wrong email" });
            }

            return this._email;
        }
    }
}