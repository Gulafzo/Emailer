using Email;
using System;

class Program
{
    static void Main(string[] args)
    {
        string smtpServer = "smtp.mail.ru";
        int smtpPort = 465;
        string username = "";
        string password = "";

        Emailer emailer = new Emailer(smtpServer, smtpPort, username, password);

        Console.Write("From: ");
        string from = Console.ReadLine();

        Console.Write("To: ");
        string to = Console.ReadLine();

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Body: ");
        string body = Console.ReadLine();

        emailer.SendEmail(from, to, subject, body);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
