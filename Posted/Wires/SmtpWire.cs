using System.Net.Mail;

namespace Posted
{
    public sealed class SmtpWire : Wire
    {
        private readonly string _host;
        private readonly bool _useDefaultCredentials;

        public SmtpWire(string host, bool useDefaultCredentials)
        {
            _host = host;
            _useDefaultCredentials = useDefaultCredentials;
        }

        public SmtpWire(string host) : this(host, true)
        {
        }

        public SmtpWire() { }

        public SmtpClient Connect()
        {
            return new SmtpClient(_host)
            {
                UseDefaultCredentials = _useDefaultCredentials
            };
        }
    }
}