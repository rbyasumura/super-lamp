using Advance.Framework.Interfaces.Loggers;
using log4net;
using log4net.Config;

namespace Advance.Framework.Loggers.log4net
{
    public class Log4NetLogger : ILogger
    {
        private ILog logger;

        public Log4NetLogger()
        {
            XmlConfigurator.Configure();
            logger = LogManager.GetLogger(GetType());
        }

        public void Log(string message)
        {
            logger.Info(message);
        }

        public void Log(string format, params object[] args)
        {
            logger.InfoFormat(format, args);
        }
    }
}
