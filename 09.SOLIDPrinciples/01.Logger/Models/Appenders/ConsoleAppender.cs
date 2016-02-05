namespace _01.Logger
{
    using System;
    using Interfaces;
    using Appenders;
    using Enums;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string format = this.Layout.ConvertToFormat(dateTime, reportLevel, message);
                Console.WriteLine(format);
            }
        }
    }
}
