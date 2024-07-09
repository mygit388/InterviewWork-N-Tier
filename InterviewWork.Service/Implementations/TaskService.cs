using InterviewWork.Models;
using InterviewWork.Repository.Interfaces;
using InterviewWork.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        

        public TaskModel getTaskByID(int Id)
        {
            return _taskRepository.TaskByID(Id);
        }

        public List<TaskModel> GetTasks(int ProfileId)
        {
            return _taskRepository.GetTasks(ProfileId);
        }

        public bool TaskAdding(TaskModel model)
        {
            return _taskRepository.Insert(model);
        }

        public bool UpdatingTask(TaskModel model)
        {
            return _taskRepository.Update(model);
        }
        public void DeleteTask(int Id)
        {
             _taskRepository.Delete(Id);
        }

       
    }
}
