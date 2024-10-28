﻿using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
   public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidatesProfiles();

        public CandidateProfile GetCandidateProfiles(string id);

        public bool AddCandidateProfile(CandidateProfile candidateprofile);

        public bool DeleteCandidateProfile(string candidateID);

        public bool UpdateCandidateProfile(CandidateProfile candidateprofile);
    }
}