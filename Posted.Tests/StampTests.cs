using System.Collections.Generic;
using Xunit;

namespace Posted.Tests
{
    public class StampTests
    {
        [Fact]
        public void StampMultipleCc()
        {
            var stamp = new StampCc(
                new List<string> {
                    "address1@temp.com", "address1@temp.com"
                }
            );

            var message =
                new HtmlEnvelope(
                    new List<Stamp> { stamp },
                    string.Empty
                ).Unwrap();

            Assert.Equal(2, message.CC.Count);
        }
    }
}
