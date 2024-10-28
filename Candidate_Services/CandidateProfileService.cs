using Candidate_BussinessObjects;
using Candidate_Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo profileRepo;
        public CandidateProfileService() 
        {
            profileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateprofile)
        {
           return profileRepo.AddCandidateProfile(candidateprofile);
        }

        public bool DeleteCandidateProfile(string candidateID)
        {
            return profileRepo.DeleteCandidateProfile(candidateID);
        }

        public CandidateProfile GetCandidateProfiles(string id)
        {
            return profileRepo.GetCandidateProfiles(id);
        }

        public List<CandidateProfile> GetCandidatesProfiles()
        {
         return profileRepo.GetCandidatesProfiles().ToList();
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateprofile)
        {
            return profileRepo.UpdateCandidateProfile(candidateprofile);
        }
    }
}
