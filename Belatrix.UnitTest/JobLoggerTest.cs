using Belatrix.Logger;
using Belatrix.Logger.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.UnitTest
{
    [TestClass]
    public class JobLoggerTest : JobLogger
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidConfigurationException))]
        public void TestInitialize_InvalidConfiguration()
        {
            Initialize(false, false, false, true, true, true);
        }

        [TestMethod]
        [ExpectedException(typeof(MustSpecifyMessageTypeToLogException))]
        public void TestInitialize_MustSpecifyMessageTypeToLog()
        {
            Initialize(false, true, false, false, false, false);
        }

        [TestMethod]
        public void TestLogMessage_LogMessage()
        {
            Initialize(false, true, false, true, false, false);
            LogMessage("Log a Message", MessageType.Message);

        }

        [TestMethod]
        public void TestLogMessage_LogWarning()
        {
            Initialize(false, true, false, false, true, false);
            LogMessage("Log a Warning", MessageType.Warning);

        }

        [TestMethod]
        public void TestLogMessage_LogError()
        {
            Initialize(false, true, false, false, false, true);
            LogMessage("Log an Error", MessageType.Error);

        }

        [TestMethod]
        [ExpectedException(typeof(MustSpecifyMessageTypeToLogException))]
        public void TestLogMessage_Undefined()
        {
            Initialize(false, true, false, true, true, true);
            LogMessage("Message", MessageType.Undefined);
        }


        [TestMethod]
        public void TestShouldLog_Error()
        {
            Initialize(false, true, false, false, false, true);
            Assert.IsTrue(ShouldLog(MessageType.Error));
        }

        [TestMethod]
        public void TestNotShouldLog_Error()
        {
            Initialize(false, true, false, true, true, false);
            Assert.IsFalse(ShouldLog(MessageType.Error));
        }

        [TestMethod]
        public void TestShouldLog_Message()
        {
            Initialize(false, true, false, true, false, false);
            Assert.IsTrue(ShouldLog(MessageType.Message));
        }

        [TestMethod]
        public void TestNotShouldLog_Message()
        {
            Initialize(false, true, false, false, true, true);
            Assert.IsFalse(ShouldLog(MessageType.Message));
        }

        [TestMethod]
        public void TestShouldLog_Warning()
        {
            Initialize(false, true, false, false, true, false);
            Assert.IsTrue(ShouldLog(MessageType.Warning));
        }

        [TestMethod]
        public void TestNotShouldLog_Warning()
        {
            Initialize(false, true, false, true, false, true);
            Assert.IsFalse(ShouldLog(MessageType.Warning));
        }

    }
}
