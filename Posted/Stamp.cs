using System.Net.Mail;

namespace Posted
{
    public interface Stamp
    {
        void Attach(MailMessage message);
    }
}