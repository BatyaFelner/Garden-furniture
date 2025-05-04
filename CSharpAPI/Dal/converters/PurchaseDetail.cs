using Dal.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace Dal.converters
{
    public class PurchaseDetail
    {



        PatioFurnitureContext db;
        public PurchaseDetail(PatioFurnitureContext db)
        {
            this.db = db;
        }



        //מקבל רשימה של מוצרים וממיר אותם לפרטי קניה למסד
        public static List<models.PurchaseDetail> ToDtoPurchaseDetailsFromProducts(List<Dto.Product> products, short codBuy)
        {
            var purchaseDetails = new List<models.PurchaseDetail>();

            foreach (var p in products)
            {
                var purchaseDetail = ToDtoPurchaseDetailFromProduct(p, codBuy);
                purchaseDetails.Add(purchaseDetail);
            }

            return purchaseDetails;
        }

        //מקבלת מוצר בודדומחזירה  קניה בודדת מסוג המסד
        public static models.PurchaseDetail ToDtoPurchaseDetailFromProduct(Dto.Product p, short codBuy)
        {
            return new models.PurchaseDetail
            {
                CodeProd = p.Id,
                Amount = p.TempAmount,
                CodeBuy = codBuy
            };
        }
        //מקבל רשימה של פרטי קניה ומחזיר רשימה של מוצרים מסוג DTO
        public static List<Dto.Product> ToDtoProductsFromPurchaseDetails(List<models.PurchaseDetail> purchaseDetails)
        {
            var products = new List<Dto.Product>();
            var db = new Dal.models.PatioFurnitureContext();

            foreach (var pd in purchaseDetails)
            {
                var productEntity = db.Products
                    .Include(p => p.CodeCatNavigation) // טוען מידע מקטגוריה אם צריך
                    .Include(p => p.CodeComNavigation) // טוען מידע מחברה אם צריך
                    .FirstOrDefault(p => p.Id == pd.CodeProd); // שליפה לפי קוד מוצר

                if (productEntity != null)
                {
                    var product = new Dto.Product
                    {
                        Id = (short)productEntity.Id,
                        NameP = productEntity.NameP,
                        CodeCat = productEntity.CodeCat,
                        CodeCom = productEntity.CodeCom,
                        Descrip = productEntity.Descrip,
                        Price = productEntity.Price,
                        Pic = productEntity.Pic,
                        Amount = productEntity.Amount,
                        TempAmount = pd.Amount // הכמות שנרכשה
                    };

                    products.Add(product);
                }
            }

            return products;
        }


        //מקבל פרטי קניה וומיר אותם לרשימת מוצרים
        public static List<Dto.PurchaseDetail> TolistDtoPurchaseDetail(List<models.PurchaseDetail> lb)
        {
            var list = new List<Dto.PurchaseDetail>(); 
            foreach (var detail in lb)
            {
                list.Add(ToDtoPurchaseDetail(detail));
            }
            return list;
        }

        public static Dto.PurchaseDetail ToDtoPurchaseDetail(models.PurchaseDetail p)
        {
            Dto.PurchaseDetail pNew = new Dto.PurchaseDetail();
            pNew.Id = p.Id;
            pNew.CodeProd = p.CodeProd; 
            pNew.Amount = p.Amount;

            return pNew;
        }

    }
}



















/*   public static Dto.PurchaseDetail ToDtoPurchaseDetail(models.PurchaseDetail p)
    {
        return new Dto.PurchaseDetail
        {
            Id = p.Id,
            CodeProd = p.CodeProd,
            CodeBuy = p.CodeBuy,
            Amount = p.Amount
        };
    }*/

/*  public static Dto.PurchaseDetail ToDtoPurchaseDetail(models.Product p, short CoeBuy)
  {
      Dto.PurchaseDetail pNew = new Dto.PurchaseDetail();
      pNew.Id = p.Id;
      pNew.CodeProd = p.Id;
      pNew.CodeBuy = CoeBuy;

      pNew.Amount = p.Amount;


      return pNew;

  }

  /*  public static models.PurchaseDetail ToModelPurchaseDetail(Dto.PurchaseDetail p)
    {
        return new models.PurchaseDetail
        {
            Id = p.Id,
            CodeProd = p.CodeProd,
            CodeBuy = p.CodeBuy,
            Amount = p.Amount
        };
    }
  */
/*   
   }*/