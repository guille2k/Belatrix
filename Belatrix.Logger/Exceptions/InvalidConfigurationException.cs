using System;
using Belatrix.Logger.Properties;

namespace Belatrix.Logger.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException() 
            : base(Resources.InvalidConfiguration)
        {
        }
    }
}
