namespace Fanex.NAP.SPU.FS.BSNG.Core.Logging
{
    using Fanex.Logging;
    using Fanex.Logging.Extensions;
    using System;

    public static class CTSLogService
    {
        public static void LogError(this Exception ex)
        {
            var commonException = CommonInfoGetters.GetExceptionInfo(ex);

            var logMessage = new LogMessage(ex.Message)
                  .AddSection("Exception Info", commonException).ToString();

            LogService.Error(logMessage);
        }

        public static string GetLogMessage(this Exception ex)
        {
            return new LogMessage(ex.Message)
                        .AddSection("Exception Info", CommonInfoGetters.GetExceptionInfo(ex)).ToString();
        }
    }
}
