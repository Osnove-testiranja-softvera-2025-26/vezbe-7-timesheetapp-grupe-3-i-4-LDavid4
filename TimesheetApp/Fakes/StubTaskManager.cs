using TimesheetApp.Interfaces;

namespace TimesheetApp.Test.Fakes
{
    public class StubTaskManager : ITaskManager
    {
        public int GetTaskId(string loggedUserName, string loggedUserEmail)
        {
            return 1;
        }
    }
}