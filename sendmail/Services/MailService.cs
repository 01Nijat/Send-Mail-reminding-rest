using MailKit;
using MimeKit;
using SendGrid.Helpers.Mail;
using sendmail.Model;

namespace sendmail.Services
{
   
    public class MailService:IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(MailSettings mailSettings)
        {
            _mailSettings= mailSettings;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject=mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments !=null)
            {
                byte[] filebytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length >0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            filebytes= ms.ToArray();
                        }
                        builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
        }
    }
}
