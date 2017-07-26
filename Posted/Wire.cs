using System.Net.Mail;

namespace Posted
{
    public interface Wire
    {
        SmtpClient Connect();
    }
}