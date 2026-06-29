using System;
using System.IO;

namespace DesignPatternsAssignment
{
    // Real-world scenario: Logging System for an application
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();
        private readonly string _logFilePath;

        // Private constructor ensures no external instantiation
        // Updated private constructor to target your explicit directory path
        private Logger()
        {
            // This forces the text file to generate exactly inside your design patterns folder
            _logFilePath = @"D:\Cognizant_Digital-Nurture-DeepSkilling\01-Engineering-Concepts\Module-01-Design-Patterns\app_log.txt";
        }

        // Thread-safe Singleton implementation using double-check locking
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            Console.WriteLine(logLine);
            try
            {
                File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            logger1.Log("Application initialized.");
            logger2.Log("Database connection established successfully.");

            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("\n[SUCCESS] Both loggers share the exact same instance memory address.");
            }
            else
            {
                Console.WriteLine("\n[FAILURE] Error: Multiple instances discovered.");
            }
        }
    }
}