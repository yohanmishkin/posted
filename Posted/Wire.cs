using System.Net.Mail;
using System.Threading;

namespace Posted
{
    public interface Wire
    {
        SmtpClient Connect();
    }

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