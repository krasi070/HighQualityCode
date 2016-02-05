namespace _01.Logger.Interfaces
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IEnumerable<IAppender> Appenders { get; }

        void Error(string message);

        void Info(string message);

        void Warn(string message);

        void Fatal(string message);

        void Critical(string message);
    }
}
