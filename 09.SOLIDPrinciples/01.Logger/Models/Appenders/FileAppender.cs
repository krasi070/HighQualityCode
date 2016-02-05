namespace _01.Logger
{
    using System;
    using Interfaces;
    using Appenders;
    using Enums;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
 
        }

        public string File { get; set; }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                string format = this.Layout.ConvertToFormat(dateTime, reportLevel, message);
                System.IO.File.AppendAllText(this.File, format + Environment.NewLine);
            }
        }
    }
}
