using InterviewWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewWork.Repository.Interfaces
{
    public interface ITaskRepository
    {
        List<TaskModel> GetTasks(int ProfileId);
        bool Insert(TaskModel model);
        TaskModel TaskByID(int Id);
        bool Update(TaskModel model);
        void Delete(int Id);
    }
}
