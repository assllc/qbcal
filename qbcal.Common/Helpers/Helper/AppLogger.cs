using Microsoft.Extensions.Logging;
using System.Text.Json;
using qbcal.Common.Helpers.Interfaces;

namespace qbcal.Common.Helpers.Helper
{
    public class AppLogger : IAppLogger
    {
        private readonly ILogger<AppLogger> _logger;
        public AppLogger(ILogger<AppLogger> logger)
        {
            _logger = logger;
        }

        public void Log<T>(LogLevel logLevel, string tag, T objectToLog)
        {
            if (objectToLog is not string)
            {
                _logger.Log(logLevel, "{tag} {objectToLog}", tag, JsonSerializer.Serialize(objectToLog));
            }
            else
            {
                _logger.Log(logLevel, "{tag} {objectToLog}", tag, objectToLog);
            }

        }
        public void LogError(string tag, Exception e)
        {
            _logger.Log(LogLevel.Error, "{tag} {exception}", tag, e.StackTrace);
        }
    }
}
