namespace XmlParser.Logger
{
    public  class NLogger : ILogger
    {
        NLog.Logger logger;

        public NLogger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void LogWarn(string message)
        {
            logger.Log(NLog.LogLevel.Warn, message);
        }
    }
}
