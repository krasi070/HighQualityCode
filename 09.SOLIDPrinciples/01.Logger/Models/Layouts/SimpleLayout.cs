namespace _01.Logger
{
    using System;
    using Enums;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string ConvertToFormat(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string layout = string.Format("{0} - {1} - {2}", dateTime, reportLevel, message);

            return layout;
        }
    }
}
