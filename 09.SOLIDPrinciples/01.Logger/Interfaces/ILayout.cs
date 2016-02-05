namespace _01.Logger.Interfaces
{
    using System;
    using Enums;

    public interface ILayout
    {
        string ConvertToFormat(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
