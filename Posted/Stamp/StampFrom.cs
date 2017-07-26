using System.Net.Mail;

namespace Posted
{
    public sealed class StampFrom : Stamp
    {
        private readonly string _sender;

        public StampFrom(string sender)
        {
            _sender = sender;
        }

        public void Attach(MailMessage message)
        {
            message.From = new MailAddress(_sender);
        }
    }
}