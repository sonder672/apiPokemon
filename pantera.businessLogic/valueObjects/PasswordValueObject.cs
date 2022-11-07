using pantera.customException;

namespace pantera.businessLogic.valueObjects
{
    public class PasswordValueObject
    {
        private string _password;
        public PasswordValueObject(string password)
        {
            this._password = password;
        }

        public string sanitate()
        {
            if (this._password.Length < 8)
            {
                throw new HttpResponseException(422, new { message = "Short password" });
            }
            return this._password;
        }
    }
}