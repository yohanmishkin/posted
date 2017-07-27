using System.Net.Mail;

namespace Posted.Stamps
{
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
}