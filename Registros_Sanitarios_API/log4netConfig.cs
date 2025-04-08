using log4net.Config;
using log4net;
using System.Reflection;

namespace Registros_Sanitarios_API
{
    public static class Log4NetConfig
    {
        public static void InitializeConfig()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
