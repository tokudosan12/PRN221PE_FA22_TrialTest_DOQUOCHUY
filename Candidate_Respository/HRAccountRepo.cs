using Candidate_BussinessObjects;
using Candidate_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Respository
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccount(string email)=>HRAccountDAO.Instance.GetHRaccountByEmail(email);
        
    public List<Hraccount> GetHRaccounts() => HRAccountDAO.Instance.GetHRaccounts();
       
    }
}
