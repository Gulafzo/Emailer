using Email;
using System;

class Program
{
    static void Main(string[] args)
    {
        string smtpServer = "smtp.example.com";
        int smtpPort = 587;
        string username = "your_username";
        string password = "your_password";

        Emailer emailer = new Emailer(smtpServer, smtpPort, username, password);

        Console.Write("From: ");
        string from = Console.ReadLine();

        Console.Write("To: ");
        string to = Console.ReadLine();

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Body: ");
        string body = Console.ReadLine();

        Console.Write("Attachments (comma separated): ");
        string attachmentsString = Console.ReadLine();
        string[] attachments = attachmentsString.Split(',');

        emailer.SendEmail(from, to, subject, body, attachments);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
