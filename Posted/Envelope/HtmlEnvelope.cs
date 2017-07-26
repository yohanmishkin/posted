using System.Collections.Generic;
using System.Net.Mail;

namespace Posted
{
    public sealed class HtmlEnvelope : Envelope
    {
        private readonly IEnumerable<Stamp> _stamps;
        private readonly string _content;

        public HtmlEnvelope(IEnumerable<Stamp> stamps, string content)
        {
            _stamps = stamps;
            _content = content;
        }

        public MailMessage Unwrap()
        {
            var message = new MailMessage
            {
                Body = _content,
                IsBodyHtml = true
            };

            foreach (var stamp in _stamps)
            {
                stamp.Attach(message);
            }

            return message;
        }
    }
}