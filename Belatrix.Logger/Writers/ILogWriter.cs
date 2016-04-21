namespace Belatrix.Logger.Writers
{
    public interface ILogWriter
    {
        void Write(string message, MessageType messageType);
    }
}
