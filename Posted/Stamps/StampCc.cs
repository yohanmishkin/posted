using System.Collections.Generic;
using System.Net.Mail;

namespace Posted
{
    public sealed class StampCc : Stamp
    {
        private readonly List<string> _recipients;

        public StampCc(string recipient)
        {
            _recipients = new List<string> { recipient };
        }

        public StampCc(List<string> recipients)
        {
            _recipients = recipients;
        }

        public void Attach(MailMessage message)
        {
            _recipients.ForEach(recipient => message.CC.Add(recipient));
        }
    }
}