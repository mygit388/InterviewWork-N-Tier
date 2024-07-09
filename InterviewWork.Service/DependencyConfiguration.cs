using InterviewWork.Repository.Implementations;
using InterviewWork.Repository.Interfaces;
using InterviewWork.Service.Implementations;
using InterviewWork.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace InterviewWork.Service
{
    public class DependencyConfiguration
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<ITaskService, TaskService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
