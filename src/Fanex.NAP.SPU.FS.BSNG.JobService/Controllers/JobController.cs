namespace Fanex.NAP.SPU.FS.BSNG.JobService.Controllers
{
    using Fanex.Logging;
    using Fanex.NAP.SPU.FS.BSNG.JobService.Services;
    using Microsoft.AspNetCore.Mvc;
    using Sentry;   
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly ISentryClient sentryClient;
        private readonly IBigStateNearGoalJobService bigStateNearGoalJobService;

        public JobController(ISentryClient sentryClient, IBigStateNearGoalJobService bigStateNearGoalJobService)
        {
            this.sentryClient = sentryClient;
            this.bigStateNearGoalJobService = bigStateNearGoalJobService;
        }

        [HttpPost("bigstateneargoal")]
        public async Task<bool> BigStateNearGoal()
        {
            return await this.bigStateNearGoalJobService.Execute();
        }

        [HttpPost("testwritelog")]
        public async Task<bool> TestWriteLog()
        {
            LogService.Info($"TestWriteLog OK");

            return await Task.FromResult(true);
        }
    }
}
