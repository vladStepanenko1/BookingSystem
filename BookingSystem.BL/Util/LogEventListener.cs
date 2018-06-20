using System;
using System.IO;

namespace BookingSystem.BL.Util
{
    public class LogEventListener : IEventListener
    {
        private string filePath;

        public LogEventListener(string logFilePath)
        {
            if (string.IsNullOrEmpty(logFilePath))
            {
                throw new ArgumentNullException($"Path to log file is null");
            }
            filePath = logFilePath;
        }

        public void Update(string data)
        {
            using(var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(data);
            }
        }
    }
}
