namespace TastyTreats.Repositories
{
    public interface IEmailSenderRepository
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
