using System.Collections.Generic;
using System.Net.Mail;

namespace Posted
{
    public interface MailPerson
    {
        void Send(IEnumerable<Stamp> stamps);
    }

    sealed class DefaultMailPerson : MailPerson
    {
        private readonly Wire _wire;

        public DefaultMailPerson(Wire wire)
        {
            _wire = wire;
        }

        public void Send(IEnumerable<Stamp> stamps)
        {
            var message = new DefaultEnvelope(stamps).Unwrap();
            SmtpClient transport = _wire.Connect();
            try
            {
                transport.Send(message);
            }
            finally
            {
                Close(transport);
            }
        }

        private void Close(SmtpClient transport)
        {
            transport.Dispose();
        }
    }
}
