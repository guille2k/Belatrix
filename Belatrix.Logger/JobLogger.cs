using System.Collections.Generic;
using Belatrix.Logger.Exceptions;
using Belatrix.Logger.Writers;

namespace Belatrix.Logger
{
    public class JobLogger
    {
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool _initialized;

        private static readonly List<ILogWriter> Writers = new List<ILogWriter>();

        public static void Initialize(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
        {
            if (!logToConsole && !logToFile && !logToDatabase)
            {
                throw new InvalidConfigurationException();
            }

            if (!logError && !logMessage && !logWarning)
            {
                throw new MustSpecifyMessageTypeToLogException();
            }

            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;

            if (logToDatabase)
            {
                Writers.Add(new DatabaseWriter());
            }
            if (logToFile)
            {
                Writers.Add(new FileWriter());
            }
            if (logToConsole)
            {
                Writers.Add(new ConsoleWriter());
            }

            _initialized = true;
        }

        public static void LogMessage(string message, MessageType messageType)
        {
            if (!_initialized)
            {
                throw new MustInitialiceJobLoggerException();
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (messageType == MessageType.Undefined)
            {
                throw new MustSpecifyMessageTypeToLogException();
            }

            if (!ShouldLog(messageType))
            {
                return;
            }

            message = message.Trim();

            foreach (var w in Writers)
            {
                w.Write(message, messageType);
            }
        }

        protected static bool ShouldLog(MessageType messageType)
        {
            return messageType == MessageType.Message && _logMessage
                   || messageType == MessageType.Error && _logError
                   || messageType == MessageType.Warning && _logWarning;
        }
    }
}
