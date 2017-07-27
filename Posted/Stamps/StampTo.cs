using System.Net.Mail;

namespace Posted
{
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
}