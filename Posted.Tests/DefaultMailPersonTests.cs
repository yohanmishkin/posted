using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Pop3;
using SmtpServer;
using Xunit;

namespace Posted.Tests
{
    public class DefaultMailPersonTests
    {
        private readonly SmtpServer.SmtpServer _server;

        public DefaultMailPersonTests()
        {
            var options = new OptionsBuilder()
                .ServerName("localhost")
                .Port(25, 587)
                .Build();

            _server = new SmtpServer.SmtpServer(options);
            Task.Run(() => _server.StartAsync(CancellationToken.None));
        }

        [Fact]
        public async Task SendsSmtp()
        {
            var mailperson = 
                new DefaultMailPerson(
                    new SmtpWire()
                );

            await mailperson.SendAsync(
                new HtmlEnvelope(
                    new List<Stamp>
                    {
                        new StampTo("to@test.com"),
                        new StampFrom("from@test.com")
                    },
                    String.Empty
                )
            );

            using (var client = new Pop3Client())
            {
                client.Connect("127.0.0.1", "user", "password", 25, false);
                Assert.NotEmpty(client.List());
            }
        }
    }
}
