using System.Net.Mail;

namespace Posted
{
    public sealed class SmtpWire : Wire
    {
        private readonly string _host;

        public SmtpWire(string host)
        {
            _host = host;
        }

        public SmtpClient Connect()
        {
            return new SmtpClient(_host);
        }
    }
}