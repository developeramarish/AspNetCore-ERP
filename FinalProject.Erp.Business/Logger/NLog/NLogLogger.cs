using FinalProject.Erp.Business.Logger.Base;
using NLog;

namespace FinalProject.Erp.Business.Logger.NLog
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("fileLogger");
            logger.Log(LogLevel.Error, message);
        }
    }
}