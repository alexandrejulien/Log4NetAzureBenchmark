using System.IO;
using System.Reflection;
using System.Xml;
using log4net;

namespace Peppermint.Log4Net.Azure.Benchmark.Core
{
    /// <summary>
    /// Logger main class.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Log4Net configuration file Xml.
        /// </summary>
        private static readonly string LOG_CONFIG_FILE = @"log4net.config";
        
        /// <summary>
        /// Current instance of logger.
        /// </summary>
        public static ILog Current => LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// Log4Net Configuration.
        /// </summary>
        public static void SetLog4NetConfiguration()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));
 
            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
 
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }
    }
}