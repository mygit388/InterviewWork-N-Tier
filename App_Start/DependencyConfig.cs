using InterviewWork.Repository.Implementations;
using InterviewWork.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace InterviewWork.UI.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IProfileRepository, ProfileRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}