using InterviewWork.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWork.Repository.Interfaces
{
    public interface IProfileRepository
    {
        List<Profile> GetAll();
        bool Insert(Profile model);
        Profile GetById(int ProfileId);
        bool Update(Profile model);
        void Delete(int ProfileId);

    }
}
