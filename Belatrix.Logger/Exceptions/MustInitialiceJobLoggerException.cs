using System;
using Belatrix.Logger.Properties;

namespace Belatrix.Logger.Exceptions
{
    public class MustInitialiceJobLoggerException : Exception
    {
        public MustInitialiceJobLoggerException()
            : base(Resources.MustInitialiceJobLogger)
        {
        }
    }
}
