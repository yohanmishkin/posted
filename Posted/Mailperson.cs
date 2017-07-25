using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Posted
{
    public interface MailPerson
    {
        void Send(Envelope envelope);
    }

    sealed class DefaultMailperson : MailPerson
    {
        public void Send(Envelope envelope)
        {
            var message = new DefaultEnvelope(envelope).Unwrap();
            var transport = _wire.Connect();
            try
            {
                final Address[] rcpts = message.getAllRecipients();
                transport.sendMessage(message, rcpts);
            }
            finally
            {
                Close(transport);
            }
        }
    }
}
