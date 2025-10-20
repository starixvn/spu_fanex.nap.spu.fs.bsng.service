namespace Fanex.NAP.SPU.FS.BSNG.Tests
{
    using System;
    using System.Collections.Generic;
    using Fanex.NAP.SPU.FS.BSNG.JobService;
    using FluentAssertions;
    using Microsoft.Extensions.Configuration;
    using Xunit;

    public class AppSettingsTests
    {
        private static IConfiguration BuildConfiguration(Action<IConfigurationBuilder> configure)
        {
            var builder = new ConfigurationBuilder();
            configure(builder);
            return builder.Build();
        }

        [Theory]
        [InlineData("LOCAL", 1)]
        [InlineData("UAT", 2)]
        [InlineData("PROD", 3)]
        [InlineData("", 3)]
        [InlineData(null, 3)]
        public void Environment_Mapping_Works(string envValue, int expected)
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), envValue),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "SomeSP"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "dsn")
                }));

            var app = new AppSettings(config);

            app.Environment.Should().Be(expected);
        }

        [Fact]
        public void SPName_Should_Read_From_Config()
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), "LOCAL"),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "MyStoredProcedure"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "dsn")
                }));

            var app = new AppSettings(config);

            app.SPName.Should().Be("MyStoredProcedure");
        }

        [Fact]
        public void SentryDsn_Should_Read_From_Config()
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), "LOCAL"),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "SP"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "https://public@sentry.example/1")
                }));

            var app = new AppSettings(config);

            app.SentryDsn.Should().Be("https://public@sentry.example/1");
        }

        [Fact]
        public void GetValue_Should_Convert_To_Type()
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), "LOCAL"),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "SP"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "dsn"),
                    new KeyValuePair<string, string>("Some:Int", "123"),
                    new KeyValuePair<string, string>("Some:Bool", "true")
                }));

            var app = new AppSettings(config);

            app.GetValue<int>("Some:Int").Should().Be(123);
            app.GetValue<bool>("Some:Bool").Should().BeTrue();
        }

        [Fact]
        public void GetValue_Invalid_Conversion_Should_Throw_InvalidCastException()
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), "LOCAL"),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "SP"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "dsn"),
                    new KeyValuePair<string, string>("Some:Int", "abc")
                }));

            var app = new AppSettings(config);

            Action act = () => app.GetValue<int>("Some:Int");
            act.Should().Throw<InvalidCastException>()
                .WithMessage("*Key: Some:Int*");
        }

        private class SectionModel
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        [Fact]
        public void GetSection_Should_Bind_Model()
        {
            var config = BuildConfiguration(b =>
                b.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(nameof(IAppSettings.Environment), "LOCAL"),
                    new KeyValuePair<string, string>(nameof(IAppSettings.SPName), "SP"),
                    new KeyValuePair<string, string>("Sentry:Dsn", "dsn"),
                    new KeyValuePair<string, string>("Section:A", "5"),
                    new KeyValuePair<string, string>("Section:B", "text")
                }));

            var app = new AppSettings(config);

            var model = app.GetSection<SectionModel>("Section");

            model.Should().NotBeNull();
            model.A.Should().Be(5);
            model.B.Should().Be("text");
        }
    }
}


