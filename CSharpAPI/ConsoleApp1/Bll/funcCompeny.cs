using Dto;
using IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class funcCompeny : CompanyIBll
    {
        public IDal.ICompanyDal delc;

        public funcCompeny(IDal.ICompanyDal c)
        {
            this.delc = c;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await delc.GetAllAsync();
        }



    }
}
