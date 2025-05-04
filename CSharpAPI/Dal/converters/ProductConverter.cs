using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converters
{
    public static class productcoverter
    {

      
            public static Dto.Product ToDto(this Dal.models.Product product)
            {
                return new Dto.Product
                {
                    Id = product.Id,
                    NameP = product.NameP,
                    CodeCat = product.CodeCat,
                    CodeCom = product.CodeCom,
                    Descrip = product.Descrip,
                    Price = product.Price,
                    Pic = product.Pic,
                    Amount = product.Amount,
                    LastUpdate = product.LastUpdate,
                    codeCategoryName = product.CodeCatNavigation.CategoryName, 
                    CompenyName = product.CodeComNavigation.CompanyName
                };
            }
        
        public static List<Dto.Product> toListDtoProd(List<models.Product> products)
        {
            List<Dto.Product> newProds = new List<Dto.Product>();
            foreach (var prod in products)
            {
                newProds.Add(ToDto(prod));
            }
            return newProds;
        }
    }
}
