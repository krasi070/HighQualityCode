namespace _01.Logger
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Enums;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IEnumerable<IAppender> Appenders { get; set; }

        public void Error(string message)
        {
            this.LogMessage(ReportLevel.Error, message);
        }

        public void Info(string message)
        {
            this.LogMessage(ReportLevel.Info, message);
        }

        public void Warn(string message)
        {
            this.LogMessage(ReportLevel.Warning, message);
        }

        public void Fatal(string message)
        {
            this.LogMessage(ReportLevel.Fatal, message);
        }

        public void Critical(string message)
        {
            this.LogMessage(ReportLevel.Critical, message);
        }

        private void LogMessage(ReportLevel reportLevel, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(DateTime.Now, reportLevel, message);
            }
        }
    }
}
