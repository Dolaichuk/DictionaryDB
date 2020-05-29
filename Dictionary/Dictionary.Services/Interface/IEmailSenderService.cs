using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Services.Interface
{
    public interface IEmailSenderService
    {
        Task SendAsync(MailAddress from, MailAddress to, string subject, string body);
        Task SendAsync(MailAddress to, string subject, string body);
        Task SendAsync(MailMessage message);

        Task SendAsync(MailAddress from, List<MailAddress> to, List<MailAddress> cc, string subject, string body,
            List<Attachment> attachments);

    }
}
