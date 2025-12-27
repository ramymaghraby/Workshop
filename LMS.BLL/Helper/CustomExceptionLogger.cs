using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Helper
{
    public static class CustomExceptionLogger
    {
        public static async Task LogException(Exception ex)
        {
            string directory = Directory.GetCurrentDirectory();
            string logDirectory = Path.Combine(directory, "wwwroot", "Logs");
            string fileName = $"Log_{DateTime.Now.ToShortDateString()}.txt";
            string path = Path.Combine(logDirectory, fileName);
            Directory.CreateDirectory(logDirectory); // Ensure the directory exists

            using (var writer = new StreamWriter(path, true))
            {
                writer.WriteLine("********** " + DateTime.Now.ToString() + " **********");
                while (ex != null)
                {
                    await writer.WriteLineAsync("Message: " + ex.Message);
                    await writer.WriteLineAsync("StackTrace: " + ex.StackTrace);
                    await writer.WriteLineAsync("InnerException: " + ex.InnerException);
                }
                writer.WriteLine();
            }
        }
    }
}
