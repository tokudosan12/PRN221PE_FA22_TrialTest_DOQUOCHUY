using Candidate_BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Respository
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccount(string email);
        public List<Hraccount> GetHRaccounts();
    }
}
