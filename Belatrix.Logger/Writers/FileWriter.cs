using System;
using System.Configuration;
using System.IO;

namespace Belatrix.Logger.Writers
{
    public class FileWriter : ILogWriter
    {
        public void Write(string message, MessageType messageType)
        {
            var path = Path.Combine(ConfigurationManager.AppSettings["LogFileDirectory"]
                , string.Format(ConfigurationManager.AppSettings["LogFileFormat"], DateTime.Today));

            File.AppendAllText(path, string.Format(ConfigurationManager.AppSettings["MessageFormat"], DateTime.Today, message));
        }
    }

}
