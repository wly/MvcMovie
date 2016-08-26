using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace MvcMovie.Services
{
    public class MailHelper
    {
        private static MimeMessage CreateMail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Leo Wang", "WangLaiYong@126.com"));
            emailMessage.To.Add(new MailboxAddress("mail", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = message };

            return emailMessage;
        }

        private static string s_sender = "WangLaiYong@126.com";

        private static string s_password = "Leo1024@126.com";

        private static string s_host = "smtp.126.com";

        public static void Send(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();
            //emailMessage.From.Add(new MailboxAddress("Leo Wang", "WangLaiYong@126.com"));
            //emailMessage.To.Add(new MailboxAddress("mail", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart("plain") { Text = message };

            var emailMessage = CreateMail(email, subject, message);

            using (var client = new SmtpClient())
            {
                client.Connect(s_host, 465, true);
                client.Authenticate(s_sender, s_password);

                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }

        public static async Task SendEmailAsync(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();

            //emailMessage.From.Add(new MailboxAddress("tianwei blogs", "mail@hantianwei.cn"));
            //emailMessage.To.Add(new MailboxAddress("mail", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart("plain") { Text = message };

            var emailMessage = CreateMail(email, subject, message);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(s_host, 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.AuthenticateAsync(s_sender, s_password);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
