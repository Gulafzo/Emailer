﻿using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Email
{
    class Emailer
    {
        private string smtpServer;
        private int smtpPort;
        private string username;
        private string password;

        public Emailer(string smtpServer, int smtpPort, string username, string password)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.username = username;
            this.password = password;
        }

        public void SendEmail(string from, string to, string subject, string body, string[] attachments)
        {
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;

            foreach (string attachment in attachments)
            {
                if (File.Exists(attachment))
                {
                    Attachment fileAttachment = new Attachment(attachment);
                    message.Attachments.Add(fileAttachment);
                }
                else
                {
                    Console.WriteLine($"File {attachment} does not exist.");
                }
            }

            SmtpClient client = new SmtpClient(smtpServer, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(username, password);

            try
            {
                client.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
