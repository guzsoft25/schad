using Microsoft.Extensions.Logging;
using Ecommerce.Shared.Contracts;

namespace Ecommerce.Business.Custom
{
    public class CustomLogger : ICustomLogger
    {
        private readonly ILogger<CustomLogger> logger;

        public CustomLogger(ILogger<CustomLogger> logger)
        {
            this.logger = logger;
        }

        public void Debug(string message)
        {
            logger.LogDebug(message);
        }

        public void Error(string message)
        {
            logger.LogError(message);
        }

        public void Fatal(string message)
        {
            logger.LogCritical(message);
        }

        public void Info(string message)
        {
            logger.LogInformation(message);
        }

        public void Warn(string message)
        {
            logger.LogWarning(message);
        }
    }
}
