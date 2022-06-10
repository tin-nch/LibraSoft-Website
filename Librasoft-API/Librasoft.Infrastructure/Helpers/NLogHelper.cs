using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librasoft.Infrastructure.Helpers
{
    /// <summary>
    /// Logging helper class
    /// </summary>
    public class NLogHelper
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Info(string message)
        {
            logger.Info(message + "\n");
        }

        public static void Debug(string message)
        {
            logger.Debug(message + "\n");
        }

        public static void Debug(string message, Exception exception)
        {
            logger.Debug(exception, message + "\n");
        }

        public static void Error(string message)
        {
            logger.Error(message + "\n");
        }

        public static void Error(string message, Exception exception)
        {
            logger.Error(exception, message + "\n");
        }

        public static void Error(Exception exception)
        {
            logger.Error(exception + "\n");
        }
    }
}
