using System;
using Belatrix.Logger.Properties;

namespace Belatrix.Logger.Exceptions
{
    public class MustSpecifyMessageTypeToLogException : Exception
    {
        public MustSpecifyMessageTypeToLogException() 
            : base(Resources.MustSpecifyMessageTypeToLog)
        {
        }
    }
}
