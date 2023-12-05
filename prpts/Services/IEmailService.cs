using prpts.Models;

namespace prpts.Services
{
    public interface IEmailService
    {
        Task ReceiveEmailAsync();
        Task SendEmailAsync(string tenantId, string clientId, string clientSecret, Email email);
    }
}