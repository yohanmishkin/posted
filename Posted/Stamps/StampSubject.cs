using System.Net.Mail;

namespace Posted
{
    public sealed class StampSubject : Stamp
    {
        private readonly string _subject;

        public StampSubject(string subject)
        {
            _subject = subject;
        }

        public void Attach(MailMessage message)
        {
            message.Subject = _subject;
        }
    }
}