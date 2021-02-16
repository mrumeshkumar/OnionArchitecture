using System;

namespace OnionArchitectureDotNet.Infrastructure.Logging
{
    class LoggerService : ILoggerService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void HandleException(Exception ex, string message)
        {
            log.Error(message, ex);
        }
    }
}
