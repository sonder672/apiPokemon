using Microsoft.EntityFrameworkCore;
using pantera.businessLogic.repository;

namespace pantera.dataAccess
{
    public class VerifyEmail : IEmailValidator
    {
        private readonly PanteraContext _context;

        public VerifyEmail(PanteraContext context)
        {
            this._context = context;
        }

        public async Task<bool> existingEmail(string email)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(
                user => user.Email == email
                );

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}