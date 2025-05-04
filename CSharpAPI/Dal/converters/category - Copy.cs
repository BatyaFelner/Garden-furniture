using System;
using System.Collections.Generic;

namespace Dal.converters
{
    public class ProductConverter
    {
    
        public static Dto.Product ToDtoProduct(models.Product p)
        {
            Dto.Product pNew = new Dto.Product();

            pNew.Id = p.Id;
            pNew.NameP = p.NameP;
            pNew.CodeCat = p.CodeCat;
            pNew.CodeCom = p.CodeCom;
            pNew.Descrip = p.Descrip;
            pNew.Price = p.Price;
            pNew.Pic = p.Pic;
            pNew.Amount = p.Amount;
            pNew.LastUpdate = p.LastUpdate;
            pNew.codeCategoryName = p.CodeCatNavigation?.CategoryName; 
            pNew.CompenyName = p.CodeComNavigation?.CompanyName;    
          

            return pNew;
        }

     
        public static List<Dto.Product> ToListProductDto(List<models.Product> lp)
        {
            List<Dto.Product> lnew = new List<Dto.Product>();
            foreach (models.Product p in lp)
            {
                lnew.Add(ToDtoProduct(p));
            }
            return lnew;
        }
    }
}
