using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Respository
{
   public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
    }
}
