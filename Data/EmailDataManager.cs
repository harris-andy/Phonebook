using MimeKit;
using MailKit;
using MailKit.Net.Smtp;

namespace Phonebook.Data
{
    public class EmailDataManager
    {
        internal static void SendEmail(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("hobobrawler@gmail.com", "htba epwk tztt pydq");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}