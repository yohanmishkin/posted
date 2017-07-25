using System.Net.Mail;

namespace Posted
{
    public interface MailPerson
    {
        void Send(Envelope envelope);
    }

    public sealed class DefaultMailPerson : MailPerson
    {
        private readonly Wire _wire;

        public DefaultMailPerson(Wire wire)
        {
            _wire = wire;
        }

        public void Send(Envelope envelope)
        {
            var message = envelope.Unwrap();
            var transport = _wire.Connect();
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
