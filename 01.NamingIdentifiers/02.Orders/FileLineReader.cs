namespace _02.Orders
{
    using System.Collections.Generic;
    using System.IO;

    public class FileLineReader
    {
        public List<string> ReadFileLines(string fileName, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
