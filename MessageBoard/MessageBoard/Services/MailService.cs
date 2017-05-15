using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MessageBoard.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(String from, String to, String subject, String body)
            {
                try
                {
                    var msg = new MailMessage(from, to, subject, body);

                    var client = new SmtpClient();
                    client.Send(msg);
                }
                catch (Exception x)
                {
                    return false;
                }
                return true;
            }

        }

    }
