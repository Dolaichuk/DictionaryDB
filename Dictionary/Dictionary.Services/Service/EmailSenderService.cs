using Dictionary.Services.Interface;
using Dictionary.Services.Service;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Service
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly EmailSenderOption _emailSenderOptions;

        private SmtpClient SmtpClient
        {
            get
            {
                var client = new SmtpClient
                {
                    Host = _emailSenderOptions.SmtpServer,
                    Port = _emailSenderOptions.Port,
                    Timeout = _emailSenderOptions.SmtpTimeout,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailSenderOptions.SmtpAccount,
                        _emailSenderOptions.SmtpPassword),
                    EnableSsl = true
                };

                return client;
            }
        }

        public MailAddress DefaultFromAddress => new MailAddress(_emailSenderOptions.EmailSender, _emailSenderOptions.EmailSenderName);
        public EmailSenderService(IOptions<EmailSenderOption> emailSenderOptions)
        {
            _emailSenderOptions = emailSenderOptions.Value;
        }

        public async Task SendAsync(MailAddress from, MailAddress to, string subject, string body)
        {
            await SendAsync(from, new List<MailAddress> { to }, new List<MailAddress>(), subject, body, new List<Attachment>());
        }

        public async Task SendAsync(MailAddress to, string subject, string body)
        {
            await SendAsync(DefaultFromAddress, new List<MailAddress> { to }, new List<MailAddress>(), subject, body, new List<Attachment>());
        }

        public async Task SendAsync(MailMessage message)
        {
            try
            {
                using (SmtpClient)
                {
                    await SmtpClient.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendAsync(MailAddress from, List<MailAddress> to, List<MailAddress> cc, string subject, string body, List<Attachment> attachments)
        {
            var mail = new MailMessage
            {
                From = from,
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            foreach (var address in to)
            {
                mail.To.Add(address);
            }

            foreach (var address in cc)
            {
                mail.CC.Add(address);
            }

            foreach (var attachment in attachments)
            {
                mail.Attachments.Add(attachment);
            }

            try
            {
                using (SmtpClient)
                {
                    await SmtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

