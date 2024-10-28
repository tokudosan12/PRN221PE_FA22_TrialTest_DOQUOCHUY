using Candidate_BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateDAO:CandidateProfile
    {
        private CandidateManagementContext context;
        private static CandidateDAO? instance = null;
        public CandidateDAO() {
            context = new CandidateManagementContext();
        }

        public static CandidateDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateDAO();
                }
                return instance;
            }
        }
        // Get all Candidates
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.Include("Posting").ToList();
        }
        // Get Candidate by ID
        public CandidateProfile? GetCandidateProfile(string id)
        {
            return context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate == null)
            {
                // Add and save to DB if not duplicate
                context.CandidateProfiles.Add(candidateProfile);
                context.SaveChanges();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }
        // Delete Candidate
        public bool DeleteCandidateProfile(string candidateID)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = GetCandidateProfile(candidateID);
            if (candidate != null)
            {
                // Remove and save to DB
                context.CandidateProfiles.Remove(candidate);
                context.SaveChanges();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }
        // Update Candidate
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            // check if already exist in DB
            CandidateProfile? candidate = GetCandidateProfile(candidateProfile.CandidateId);
            if (candidate != null)
            {
                // Auto update and save to DB
                candidate.Fullname = candidateProfile.Fullname;
                candidate.Birthday = candidateProfile.Birthday;
                candidate.ProfileShortDescription = candidateProfile.ProfileShortDescription;
                candidate.ProfileUrl = candidateProfile.ProfileUrl;
                candidate.PostingId = candidateProfile.PostingId;
                //dbContext.Entry<CandidateProfile>(candidateProfile).State 
                //    = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.CandidateProfiles.Update(candidate);
                context.SaveChanges();
                isSuccess = true;
            }
            // return flag
            return isSuccess;
        }
    }
}
