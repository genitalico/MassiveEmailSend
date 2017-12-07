using System;
using System.Collections.Generic;
using System.Text;

namespace MassiveEmailSend
{
    public class JsonModel
    {
        public string From { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string SmtpServer { get; set; }

        public int Port { get; set; }

        public bool Ssl { get; set; }

        public string Subject { get; set; }
    }
}
