using System.Reflection;
using log4net;
using log4net.Config;

namespace RegistrosSanitarios.API.Log4Net
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
