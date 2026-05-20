using System;
using TimesheetApp.Interfaces;

namespace TimesheetApp
{
    public class TimeLogger
    {
        ITask task;
        IEmailSender emailSender;
        IErrorLogger errorLogger;
        IUserLogger userLogger;
        ITaskManager taskManager;

        public TimeLogger()
        {
            task = new TaskLogger();
            emailSender = new EmailSender();
            errorLogger = new ErrorLogger();
            userLogger = new UserLogger();
            taskManager = new TaskManager();
        }

        public void LogTime(int hours, int minutes, string description)
        {
            try
            {
                // Retrieve logged user information
                string userName = userLogger.GetLoggedUserName();
                string userEmail = userLogger.GetLoggedUserEmail(userName);

                // Retrieve task information
                int taskId = taskManager.GetTaskId(userName, userEmail);

                // Log time and save to database
                task.TaskId = taskId;
                task.Hours = hours;
                task.Minutes = minutes;
                task.Description = description;
                bool saved = task.SaveToDB();

                if (saved)
                {
                    // Send notification email
                    emailSender.SendEmail(userEmail, 
                                         "Time logged successfully",
                                         hours + " hours and " + minutes + " minutes successfully logged to task with ID=" + taskId);
                }
                else
                {
                    throw new Exception("Failed to save data to database");
                }                                                
            }
            catch (Exception ex)
            {
                // Handle errors
                errorLogger.LogError(ex);
                throw;
            }
        }
    }
}
