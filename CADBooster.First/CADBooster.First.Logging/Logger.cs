using System;
using log4net;

namespace CADBooster.First.Logging
{
    internal class Logger
    {
        #region Ctor

        /// <summary>
        /// A new logger that logs to all current end points.
        /// </summary>
        /// <param name="nameOfType"></param>
        public Logger(string nameOfType)
        {
            Log4NetLogger = LogManager.GetLogger(nameOfType);
        }

        #endregion

        #region Properties

        private ILog Log4NetLogger { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Get a logger with the name of the calling class
        /// </summary>
        /// <returns></returns>
        public static Logger GetLogger(string nameOfType)
        {
            return new Logger(nameOfType);
        }

        /// <summary>
        /// Send a debug entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        public void Debug(string message, string methodName)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Debug(rollingFileMessage);
        }

        /// <summary>
        /// Send a critical entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        public void Critical(string message, string methodName)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Fatal(rollingFileMessage);
        }

        /// <summary>
        /// Send a error entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        public void Error(string message, string methodName)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Error(rollingFileMessage);
        }

        /// <summary>
        /// Send a error entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="methodName"></param>
        public void Error(string message, string methodName, Exception exception)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Error(rollingFileMessage, exception);
        }

        /// <summary>
        /// Send an info entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        public void Info(string message, string methodName)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Info(rollingFileMessage);
        }

        /// <summary>
        /// Send a warning entry.
        /// Returns severity for testing.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        public void Warn(string message, string methodName)
        {
            string rollingFileMessage = GetRollingFileMessage(message, methodName);
            Log4NetLogger.Warn(rollingFileMessage);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get the message that combines the method name and the actual message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private static string GetRollingFileMessage(string message, string methodName)
        {
            string fixedLengthMethodName = GetFixedLengthMethodName(methodName);
            return fixedLengthMethodName + "     " + message;
        }

        /// <summary>
        /// Get a string that is padded or truncated to a fixed length.
        /// </summary>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private static string GetFixedLengthMethodName(string methodName)
        {
            const int length = Loggers.RollingFileMethodLength;
            return string.IsNullOrEmpty(methodName)
                ? new string(' ', length)
                : methodName.PadRight(length).Substring(0, length);
        }

        #endregion
    }
}
