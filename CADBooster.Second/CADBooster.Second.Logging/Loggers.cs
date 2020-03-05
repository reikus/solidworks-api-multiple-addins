using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace CADBooster.Second.Logging
{
    internal static class Loggers
    {
        #region Fields 

        public const int RollingFileMethodLength = 30;
        private static readonly Level DefaultLoggingLevel = Level.Debug;
        private const string PatternLayoutRollingFile = "%date %-5level %-27logger %message%newline";
        
        #endregion

        #region Methods

        /// <summary>
        /// Empty method so the static constructor initializes the root logger.
        /// </summary>
        public static void StartLogging(LogFilePath logFilePath)
        {
            var hierarchy = GetDefaultLoggerHierarchy();
            
            var patternLayoutRollingFile = GetPatternLayoutRollingFile();
            var rollingFileAppender = GetRollingFileAppender(patternLayoutRollingFile, logFilePath);
            hierarchy.Root.AddAppender(rollingFileAppender);

            hierarchy.Root.Level = DefaultLoggingLevel;
            hierarchy.Configured = true;
        }

        /// <summary>
        /// Close and flush all appenders.
        /// </summary>
        public static void ShutDown()
        {
            LogManager.Flush(2000);
            LogManager.Shutdown();
        }

        /// <summary>
        /// Get the default repository instance and its hierarchy
        /// </summary>
        /// <returns></returns>
        private static Hierarchy GetDefaultLoggerHierarchy()
        {
            return (Hierarchy) LogManager.GetRepository();
        }

        /// <summary>
        /// Activate a setting instance
        /// </summary>
        /// <param name="optionHandler"></param>
        private static void ActivateOptions(IOptionHandler optionHandler)
        {
            optionHandler.ActivateOptions();
        }

        #endregion

        #region Rolling file

        /// <summary>
        /// Get the activated pattern layout for writing to a local file.
        /// </summary>
        /// <returns></returns>
        private static PatternLayout GetPatternLayoutRollingFile()
        {
            var patternLayout = new PatternLayout { ConversionPattern = PatternLayoutRollingFile };
            ActivateOptions(patternLayout);
            return patternLayout;
        }

        /// <summary>
        /// Get the activated rolling file appender.
        /// </summary>
        /// <param name="patternLayout"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static RollingFileAppender GetRollingFileAppender(PatternLayout patternLayout, LogFilePath filePath)
        {
            var rollingFileAppender = new RollingFileAppender
            {
                AppendToFile = true,
                File = filePath.Path,
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "10MB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            ActivateOptions(rollingFileAppender);
            return rollingFileAppender;
        }

        #endregion
    }
}
