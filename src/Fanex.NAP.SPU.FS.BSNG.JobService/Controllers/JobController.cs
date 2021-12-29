namespace Fanex.NAP.SPU.FS.BSNG.JobService.Controllers
{
    using Fanex.NAP.SPU.FS.BSNG.JobService.Services;
    using Microsoft.AspNetCore.Mvc;
    using Sentry;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
    }
}
