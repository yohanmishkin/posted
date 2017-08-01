using Xunit;

namespace Posted.Tests
{
    public class SmtpWireTests
    {
        [Fact]
        public void Connects()
        {
            var wire = new SmtpWire();
            var transport = wire.Connect();
            Assert.NotNull(transport.Host);
        }
    }
}
