using System.Net.Mail;
using System.Threading.Tasks;

namespace Posted.MailPeople
{
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

        public async Task SendAsync(Envelope envelope)
        {
            var message = envelope.Unwrap();
            var transport = _wire.Connect();
            try
            {
                await transport.SendMailAsync(message);
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
