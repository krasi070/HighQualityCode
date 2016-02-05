namespace _01.Logger
{
    using Models.Layouts;
    using Enums;

    public class LoggerProgram
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            var fileAppender = new FileAppender(simpleLayout);
            fileAppender.File = "../../log.txt";
            fileAppender.ReportLevel = ReportLevel.Warning;
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender, fileAppender);

            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
