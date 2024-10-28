using Candidate_BussinessObjects;
using Candidate_Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo iHRAccountRepo;
        public HRAccountService()
        {
            iHRAccountRepo = new HRAccountRepo();
        }

        public Hraccount GetHraccount(string email)
        {
            throw new NotImplementedException();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
           return iHRAccountRepo.GetHraccount(email); 
        }

        public List<Hraccount> GetHraccounts()
        {
            return iHRAccountRepo.GetHRaccounts();
        }
    
        public List<Hraccount> GetHRaccounts()
        {
            throw new NotImplementedException();
        }
    }
}
