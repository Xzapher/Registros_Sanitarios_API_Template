using log4net.Config;
using log4net;
using System.Reflection;

namespace Registros_Sanitarios_API
{
    public static class Log4NetConfig
    {

        //private static readonly ILog log = LogManager.GetLogger(typeof(  -->[CLASSNAME]<--  ));

        public static void InitializeConfig()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
