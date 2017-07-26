using System.Net.Mail;

namespace Posted
{
    public interface Envelope
    {
        MailMessage Unwrap();
    }
}