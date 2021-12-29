namespace Fanex.NAP.SPU.FS.BSNG.JobService.Services
{
    using Fanex.NAP.SPU.FS.BSNG.Features.BigStateNearGoal;
    using Fanex.NAP.SPU.FS.BSNG.Features.FraudCase;
    using Microsoft.Extensions.DependencyInjection;

    public static class InitService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            RegisterBaseServices(services);
            RegisterBigStateNearGoalService(services);
        }

        private static void RegisterBaseServices(this IServiceCollection services)
        {
            services.AddSingleton<IFraudCaseDataAccess, FraudCaseDataAccess>();
            services.AddSingleton<IFraudCaseServices, FraudCaseServices>();
        }

        private static void RegisterBigStateNearGoalService(this IServiceCollection services)
        {
            services.AddSingleton<IBigStateNearGoalDataAccess, BigStateNearGoalDataAccess>();
            services.AddSingleton<BigStateNearGoalServices>();
            services.AddSingleton<IBigStateNearGoalJobService, BigStateNearGoalJobService>();
        }
    }
}
