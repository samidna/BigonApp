namespace BigonApp.Helpers.Services
{
    public interface IEmailService
    {
        Task<bool> SendMailAsync(string to, string subject, string body);
    }
}
