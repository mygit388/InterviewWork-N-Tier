using InterviewWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork.Service.Interfaces
{
    public interface IProfileService
    {
        List<Profile> GetAll();
        bool InsertProfile(Profile model);
        Profile getProfileByID(int ProfileId);
        bool UpdateProfile(Profile model);
        void DeleteProfile(int ProfileId);
    }
}
