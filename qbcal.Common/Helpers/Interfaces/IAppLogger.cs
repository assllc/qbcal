using Microsoft.Extensions.Logging;

namespace qbcal.Common.Helpers.Interfaces
{
    public interface IAppLogger
    {
        void Log<T>(LogLevel logLevel, string tag, T objectToLog);
        void LogError(string tag, Exception e);
    }
}
