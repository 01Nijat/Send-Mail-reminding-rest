using sendmail.Model;

namespace sendmail.Interfaces
{
    public interface IMailSendService
    {
       public Task SendEmailAsync(MailRequest mailRequest);
    }
}
