namespace Fanex.NAP.SPU.FS.BSNG.Tests.Services
{
    using Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase;
    using Fanex.NAP.SPU.FS.BSNG.JobService;
    using Fanex.NAP.SPU.FS.BSNG.JobService.Services;
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using NSubstitute;
    using Xunit;

    public class InitServiceTests
    {
        [Fact]
        public void RegisterService_Should_Register_All_Dependencies()
        {
            var services = new ServiceCollection();

            // Provide IAppSettings so BigStateNearGoalJobService can be constructed if resolved
            var appSettings = Substitute.For<IAppSettings>();
            services.AddSingleton(appSettings);

            services.RegisterService();

            var provider = services.BuildServiceProvider();

            provider.GetService<IFraudCaseDataAccess>().Should().NotBeNull();
            provider.GetService<IFraudCaseServices>().Should().NotBeNull();
            provider.GetService<IBigStateNearGoalDataAccess>().Should().NotBeNull();
            provider.GetService<BigStateNearGoalServices>().Should().NotBeNull();
            provider.GetService<IBigStateNearGoalJobService>().Should().NotBeNull();
        }

        [Fact]
        public void Registered_Services_Should_Resolve_And_Wire_Together()
        {
            var services = new ServiceCollection();

            var appSettings = Substitute.For<IAppSettings>();
            appSettings.Environment.Returns(1);
            services.AddSingleton(appSettings);

            services.RegisterService();

            var provider = services.BuildServiceProvider();

            var jobService = provider.GetRequiredService<IBigStateNearGoalJobService>();
            jobService.Should().NotBeNull();
        }
    }
}


