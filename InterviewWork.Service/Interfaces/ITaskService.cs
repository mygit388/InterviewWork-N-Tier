using InterviewWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewWork.Service.Interfaces
{
    public interface ITaskService
    {
        List<TaskModel> GetTasks(int ProfileId);
        bool TaskAdding(TaskModel model);
        TaskModel getTaskByID(int Id);
        bool UpdatingTask(TaskModel model);
        void DeleteTask(int Id);
        
    }
}
