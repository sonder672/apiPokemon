namespace pantera.businessLogic.repository
{
    public interface IEmailValidator
    {
        public Task<Boolean> existingEmail (string email);
    }
}