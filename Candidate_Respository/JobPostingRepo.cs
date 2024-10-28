using Candidate_BussinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Respository
{
    public class JobPostingRepo:IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();
    }
}
