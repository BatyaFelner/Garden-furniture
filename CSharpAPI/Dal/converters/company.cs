using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converters
{
  public class company
    {
        public static Dto.Company ToDtoCategory(models.Company c)
        {
            Dto.Company cNew = new Dto.Company();
            cNew.Id = c.Id;
            cNew.CompanyName = c.CompanyName;
          

            return cNew;

        }

        public static List<Dto.Company> ToListCategoryDto(List<models.Company> lc)
        {
            List<Dto.Company> lnew = new List<Dto.Company>();
            foreach (models.Company c in lc)
            {
                lnew.Add(ToDtoCategory(c));
            }
            return lnew;
        }
    }
}

  