using System.Net.Mail;

namespace Posted
{
    interface Wire
    {
        SmtpClient Connect();
    }
}