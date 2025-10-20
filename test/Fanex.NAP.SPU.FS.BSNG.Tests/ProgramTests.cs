namespace Fanex.NAP.SPU.FS.BSNG.Tests
{
    using Fanex.NAP.SPU.FS.BSNG.JobService;
    using FluentAssertions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.Hosting;
    using Xunit;

    public class ProgramTests
    {
        [Fact]
        public void CreateHostBuilder_Should_Build_Host()
        {
            var builder = Program.CreateHostBuilder(new string[0])
                .UseEnvironment("Development")
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseTestServer();
                });

            using var host = builder.Build();

            host.Should().NotBeNull();
        }
    }
}


