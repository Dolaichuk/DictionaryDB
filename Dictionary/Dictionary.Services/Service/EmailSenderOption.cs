using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Services.Service
{
    public class EmailSenderOption
    {
        public string EmailSender { get; set; }
        public string EmailSenderName { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string SmtpAccount { get; set; }
        public string SmtpPassword { get; set; }
        public int SmtpTimeout { get; set; } 
    }
}
