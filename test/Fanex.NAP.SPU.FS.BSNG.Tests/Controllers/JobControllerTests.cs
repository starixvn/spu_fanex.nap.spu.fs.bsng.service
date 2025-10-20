namespace Fanex.NAP.SPU.FS.BSNG.Tests.Controllers
{
    using System.Threading.Tasks;
    using Fanex.NAP.SPU.FS.BSNG.JobService.Controllers;
    using Fanex.NAP.SPU.FS.BSNG.JobService.Services;
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class JobControllerTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task BigStateNearGoal_Returns_Execute_Result(bool executeResult)
        {
            var jobService = Substitute.For<IBigStateNearGoalJobService>();
            jobService.Execute().Returns(Task.FromResult(executeResult));

            var controller = new JobController(jobService);

            var result = await controller.BigStateNearGoal();

            result.Should().Be(executeResult);
            await jobService.Received(1).Execute();
        }

        [Fact]
        public async Task TestWriteLog_Returns_True()
        {
            var jobService = Substitute.For<IBigStateNearGoalJobService>();

            var controller = new JobController(jobService);

            var result = await controller.TestWriteLog();

            result.Should().BeTrue();
        }
    }
}


