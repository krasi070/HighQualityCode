namespace _01.Logger.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public ILayout Layout { get; set; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
