using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Cross.Logging
{
    public class LogLogger : ILogger
    {
        private Logger _logger;

        private const string _loggerName = "NLogLogger";

        public LogLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Debug(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
            {
                var logEvent = GetLogEvent(_loggerName, LogLevel.Debug, exception, format, args);
                _logger.Log(LogLevel.Debug, logEvent);
            });
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
           {
               var logEvent = GetLogEvent(_loggerName, LogLevel.Error, exception, format, args);
               _logger.Log(LogLevel.Error, logEvent);
           });
        }

        public void Fatal(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
           {
               var logEvent = GetLogEvent(_loggerName, LogLevel.Fatal, exception, format, args);
               _logger.Log(LogLevel.Fatal, logEvent);
           });
        }

        public void Info(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
           {
               var logEvent = GetLogEvent(_loggerName, LogLevel.Info, exception, format, args);
               _logger.Log(LogLevel.Info, logEvent);
           });
        }

        public void Trace(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
           {
               var logEvent = GetLogEvent(_loggerName, LogLevel.Trace, exception, format, args);
               _logger.Log(LogLevel.Trace, logEvent);
           });
        }

        public void Warn(Exception exception, string format, params object[] args)
        {
            Task.Factory.StartNew(() =>
           {
               var logEvent = GetLogEvent(_loggerName, LogLevel.Warn, exception, format, args);
               _logger.Log(LogLevel.Warn, logEvent);
           });
        }

        public void Debug(Exception exception)
        {
            this.Debug(exception, string.Empty);
        }

        public void Error(Exception exception)
        {
            this.Error(exception, string.Empty);
        }

        public void Fatal(Exception exception)
        {
            this.Fatal(exception, string.Empty);
        }

        public void Info(Exception exception)
        {
            this.Info(exception, string.Empty);
        }

        public void Trace(Exception exception)
        {
            this.Trace(exception, string.Empty);
        }

        public void Warn(Exception exception)
        {
            this.Warn(exception, string.Empty);
        }


        private LogEventInfo GetLogEvent(string loggerName, LogLevel level, Exception exception, string format, object[] args)
        {
            string assemblyProp = string.Empty;
            string classProp = string.Empty;
            string methodProp = string.Empty;
            string messageProp = string.Empty;
            string innerMessageProp = string.Empty;
            string stackTraceProp = string.Empty;
            string targetSiteProp = string.Empty;

            var logEvent = new LogEventInfo
                (level, loggerName, string.Format(format, args));

            if (exception != null)
            {
                assemblyProp = exception.Source;
                classProp = exception.TargetSite.DeclaringType.FullName;
                methodProp = exception.TargetSite.Name;
                messageProp = exception.Message;
                stackTraceProp = exception.StackTrace;
                targetSiteProp = exception.TargetSite.ToString();
                logEvent.Message = exception.Message;

                if (exception.InnerException != null)
                {
                    innerMessageProp = exception.InnerException.Message;
                    logEvent.Message = logEvent.Message + " - " + exception.InnerException.Message;
                }
            }

            logEvent.Properties["error-source"] = assemblyProp;
            logEvent.Properties["error-class"] = classProp;
            logEvent.Properties["error-method"] = methodProp;
            logEvent.Properties["error-message"] = messageProp;
            logEvent.Properties["inner-error-message"] = innerMessageProp;
            logEvent.Properties["inner-stack-trace"] = stackTraceProp;
            logEvent.Properties["inner-target-site"] = targetSiteProp;

            return logEvent;
        }


        public void Debug(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Error(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Info(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Trace(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }
    }
}