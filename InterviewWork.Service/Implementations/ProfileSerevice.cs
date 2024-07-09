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
    public class ProfileService : IProfileService
    {
        private  IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public void DeleteProfile(int ProfileId)
        {
            _profileRepository.Delete(ProfileId);
        }

        public List<Profile> GetAll()
        {
            return _profileRepository.GetAll();
        }

        public Profile getProfileByID(int ProfileId)
        {
            return _profileRepository.GetById(ProfileId);
        }

        public bool InsertProfile(Profile model)
        {
            return _profileRepository.Insert(model);
        }

        public bool UpdateProfile(Profile model)
        {
            return _profileRepository.Update(model);
        }
    }
}
