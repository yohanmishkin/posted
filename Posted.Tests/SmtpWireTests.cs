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

        [Fact]
        public void UseDefaultCredentials()
        {
            var wire = new SmtpWire();
            var smtpClient = wire.Connect();
            Assert.False(smtpClient.UseDefaultCredentials);

            wire = new SmtpWire("hosthosthost");
            smtpClient = wire.Connect();
            Assert.True(smtpClient.UseDefaultCredentials);

            wire = new SmtpWire("hosthosthost", false);
            smtpClient = wire.Connect();
            Assert.False(smtpClient.UseDefaultCredentials);
        }
    }
}
