namespace _01.Logger.Models.Layouts
{
    using System;
    using Interfaces;
    using Enums;

    public class XmlLayout : ILayout
    {
        public string ConvertToFormat(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string layout = string.Format("<log>{0}{1}<date>{2}</date>{0}{1}<level>{3}</level>{0}{1}<message>{4}</message>{0}</log>",
                Environment.NewLine, new string(' ', 3), dateTime, reportLevel, message);

            return layout;
        }
    }
}
