using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassiveEmailSend
{
    public class SendEmail
    {
        #region PrivateVars
        private List<CsvModel> listEmail;
        private JsonModel dataEmail;
        private MimeMessage _Message;
        private string _Body;
        #endregion


        #region Ctor
        public SendEmail(List<CsvModel> listEmail,JsonModel dataEmail,string body)
        {
            this.listEmail = listEmail;
            this.dataEmail = dataEmail;
            this._Body = body;
        }
        #endregion

        #region PublicMethods
        public void SendListEmail()
        {


            foreach(var list in this.listEmail)
            {
                this._Message = new MimeMessage();

                this._Message.From.Add(new MailboxAddress(this.dataEmail.From, dataEmail.Email));


                this._Message.To.Add(new MailboxAddress(list.Name, list.Email));

                this._Message.Subject = dataEmail.Subject;


                string body = this._Body.Replace("##Name", list.Name);

                this._Message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(dataEmail.SmtpServer, dataEmail.Port, dataEmail.Ssl);

                    client.Authenticate(dataEmail.Email, dataEmail.Password);

                    client.Send(this._Message);
                    client.Disconnect(true);
                }
            }


            

        }
        #endregion
    }
}
