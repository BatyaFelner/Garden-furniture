using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converters
{
    public class category
    {

        public static Dto.Category ToDtoCategory(models.Category c) {
            Dto.Category cNew = new Dto.Category();
            cNew.Id = c.Id;
            cNew.CategoryName = c.CategoryName;
            cNew.Img = c.Img;
            
            return cNew;
                
        }

        public static List<Dto.Category> ToListCategoryDto(List<models.Category> lc)
        {
            List<Dto.Category> lnew = new List<Dto.Category>();
            foreach (models.Category c in lc)
            {
                lnew.Add(ToDtoCategory(c));
            }
            return lnew;
        }
    }
}
