using System;
using System.IO;

namespace Mario.Logging
{
    public class SeanLogger
    {
        private static SeanLogger instance = new SeanLogger();
        private readonly string logFilePath; // Path to the log file
        private StreamWriter logFileWriter; // StreamWriter for writing logs


        public static SeanLogger Instance
        {
            get
            {
                return instance;
            }
        }

        private SeanLogger()
        {
            // Set the path to the log file (you can customize this)
            logFilePath = "sean_log.txt";

            // Initialize the StreamWriter to append to the log file
            logFileWriter = new StreamWriter(logFilePath, append: true);

            // Log that the log file was created
            logFileWriter.WriteLine("Log file created at " + DateTime.Now);
        }


        // Log an error to the file
        public void LogError(string message)
        {
            logFileWriter.WriteLine("ERROR: " + message);
        }

        // Log a warning to the file
        public void LogWarning(string message)
        {
            logFileWriter.WriteLine("WARNING: " + message);
        }

        // Log an info message to the file
        public void LogInfo(string message)
        {
            logFileWriter.WriteLine("INFO: " + message);
        }

        // Dispose method to close the StreamWriter
        public void Dispose()
        {
            logFileWriter.Dispose();
        }
    }
}
