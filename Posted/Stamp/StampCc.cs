using System.Net.Mail;

namespace Posted
{
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
}