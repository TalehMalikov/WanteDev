using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSending
{
    public  class YahooEmailSender : BaseEmailSender
    {
        public YahooEmailSender(YahooClientInfo clientInfo) : base(clientInfo)
        {

        }
        public  override  EmailSendResult SendEmail(EmailMessage Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                if (Message.TO != null)
                {
                    foreach (string email in Message.TO)
                    {
                        mail.To.Add(email);
                    }
                }
                
                mail.From = new MailAddress(clientInfo.UserEmail);
                mail.Body = Message.Body;
                mail.Subject = Message.Subject;
                mail.IsBodyHtml = Message.IsBodyHtml;
                SmtpClient smtpClient = new SmtpClient(clientInfo.SMTPServerHost, clientInfo.STMPServerPort);
                smtpClient.Credentials = new NetworkCredential(clientInfo.UserEmail, clientInfo.UserPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                return new EmailSendResult() { Error = null, IsMessageDelivered = true };


            }
            catch (Exception e)
            {
                return new EmailSendResult() { Error = e,  IsMessageDelivered = false };

            }
        }

       
    }
}
