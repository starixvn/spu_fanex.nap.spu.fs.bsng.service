namespace Fanex.NAP.SPU.FS.BSNG.JobService.Controllers
{
    using Fanex.Logging;
    using Fanex.NAP.SPU.FS.BSNG.JobService.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private readonly IBigStateNearGoalJobService bigStateNearGoalJobService;

        public JobController(IBigStateNearGoalJobService bigStateNearGoalJobService)
        {
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
