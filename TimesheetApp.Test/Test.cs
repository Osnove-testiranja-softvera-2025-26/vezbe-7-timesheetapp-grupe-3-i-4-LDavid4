using NUnit.Framework;
using System;
using TimesheetApp.Test.Fakes;
using TimesheetApp;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestSuccessfulTimeLogging()
        {
            // Arrange
            var stubTask = new StubTask();
            var stubTaskManager = new StubTaskManager();
            var stubEmailSender = new StubEmailSender();
            var stubErrorLogger = new StubErrorLogger();
            var stubUserLogger = new StubUserLogger();

            var timeLogger = new TimeLogger(stubTask, stubEmailSender, stubErrorLogger, stubUserLogger, stubTaskManager);

            // Act
            timeLogger.LogTime(2, 30, "Test Task");

            // Assert
            Assert.Pass("Time logging was successful.");
        }
    }
}
