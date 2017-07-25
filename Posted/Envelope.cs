using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Posted
{
    public interface Envelope
    {
        MailMessage Unwrap();
    }

    public sealed class DefaultEnvelope : Envelope
    {
        private readonly IEnumerable<Stamp> _stamps;
        private Envelope envelope;

        public DefaultEnvelope(IEnumerable<Stamp> stamps)
        {
            _stamps = stamps;
        }

        public MailMessage Unwrap()
        {
            var message = new MailMessage();
            try
            {
                foreach (var stamp in _stamps)
                {
                    stamp.Attach(message);
                }
            }
            catch (Exception exception)
            {
                
            }

            return message;
        }
    }
}