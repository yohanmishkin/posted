using System.Net.Mail;

namespace Posted
{
    public interface Stamp
    {
        void Attach(MailMessage message);
    }

    public sealed class StampTo : Stamp
    {
        private readonly string _recipient;

        public StampTo(string recipient)
        {
            _recipient = recipient;
        }

        public void Attach(MailMessage message)
        {
            message.To.Add(_recipient);
        }
    }

    public sealed class StampCc : Stamp
    {
        private readonly string _recipient;

        public StampCc(string recipient)
        {
            _recipient = recipient;
        }

        public void Attach(MailMessage message)
        {
            message.CC.Add(_recipient);
        }
    }

    public sealed class StampBcc : Stamp
    {
        private readonly string _recipient;

        public StampBcc(string recipient)
        {
            _recipient = recipient;
        }

        public void Attach(MailMessage message)
        {
            message.Bcc.Add(_recipient);
        }
    }

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