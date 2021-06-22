using System;
using System.IO;


namespace EAAutoFramework.Helpers
{
    public class LogHelpers
    {
        //global declaration of log file name
        private static string _logFileName = String.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamW = null;

        //create a file which can store the log information
        public static void CreateLogFile()
        {
            string dir = @"C:\Users\gaz30\Desktop\Logs\";
            if(Directory.Exists(dir))
            {
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamW = File.AppendText(dir + _logFileName + ".log");
            }
        }

        //write text in the log file
        public static void Write(string logMessage)
        {
            _streamW.Write("{0} {1}:", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamW.WriteLine(" {0}", logMessage);
            _streamW.Flush();
        }

    }
}
