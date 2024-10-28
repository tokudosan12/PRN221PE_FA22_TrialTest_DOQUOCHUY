using Candidate_BussinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Respository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateprofile) 
            => CandidateDAO.Instance.AddCandidateProfile(candidateprofile);
      

        public bool DeleteCandidateProfile(string candidateID)
        => CandidateDAO.Instance.DeleteCandidateProfile(candidateID);

        public CandidateProfile GetCandidateProfiles(string id)
            => CandidateDAO.Instance.GetCandidateProfile(id);
        

        public List<CandidateProfile> GetCandidatesProfiles()
            => CandidateDAO.Instance.GetCandidateProfiles();
      
        public bool UpdateCandidateProfile(CandidateProfile candidateprofile)
       => CandidateDAO.Instance.UpdateCandidateProfile(candidateprofile);
    }
}
