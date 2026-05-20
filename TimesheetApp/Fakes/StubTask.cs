using System;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Test.Fakes
{
    public class StubTask : ITask
    {
        public int TaskId { get; set; } = 0;
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public string Description { get; set; } = "Default Description";

        public bool SaveToDB()
        {
            Console.WriteLine("Task saved to database.");
            return true;
        }
    }
}