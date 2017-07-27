using System.Net.Mail;

namespace Posted
{
    public sealed class FileWire : Wire
    {
        private readonly string _location;

        public FileWire(string location)
        {
            _location = location;
        }

        public SmtpClient Connect()
        {
            return new SmtpClient(_location)
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = _location
            };
        }
    }
}