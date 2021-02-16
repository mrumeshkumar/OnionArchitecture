using System;

namespace OnionArchitectureDotNet.Infrastructure.Logging
{
    interface ILoggerService
    {
        void HandleException(Exception ex, string message);
    }
}
