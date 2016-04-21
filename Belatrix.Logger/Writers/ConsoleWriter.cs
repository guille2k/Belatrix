using System;
using System.Configuration;

namespace Belatrix.Logger.Writers
{
    public class ConsoleWriter : ILogWriter
    {
        public void Write(string message, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine(ConfigurationManager.AppSettings["MessageFormat"], DateTime.Today, message);
        }
    }
}
