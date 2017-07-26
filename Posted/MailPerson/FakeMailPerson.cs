using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Posted
{
    public sealed class FakeMailPerson : MailPerson
    {
        public readonly List<MailMessage> DeliveredMail;

        public FakeMailPerson()
        {
            DeliveredMail = new List<MailMessage>();
        }

        public void Send(Envelope envelope)
        {
            DeliveredMail.Add(envelope.Unwrap());
        }

        public async Task SendAsync(Envelope envelope)
        {
            await Task.Run(() => DeliveredMail.Add(envelope.Unwrap()));
        }
    }
}
