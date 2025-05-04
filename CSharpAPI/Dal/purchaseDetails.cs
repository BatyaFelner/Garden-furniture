using Dal.models;
using Dto;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class purchaseDetails : IpurchaseDetailsDal
    {

        PatioFurnitureContext db;
        public purchaseDetails(PatioFurnitureContext db)
        {
            this.db = db;
        }



        public async Task<List<Dto.PurchaseDetail>> GetAllAsync()
        {
            var list = await db.PurchaseDetails.ToListAsync();
            return converters.PurchaseDetail.TolistDtoPurchaseDetail(list);
        }


        //יוצר פרטי קניה חדשים ע"י רשימת מוצרים שקבל 
        //וקוד קניה
        public async Task<List<Dto.Product>> addPurchaseDetailsAsync(List<Dto.Product> products, short buyId)
        {

            //יוצר רשימה חדשה
            var purchaseDetails = new List<models.PurchaseDetail>();
            //עובר על כל המוצרים שהתקבלו 
            foreach (var productDto in products)
            {

                //שולף את המוצר מהמסד
                var prod = await db.Products.FirstOrDefaultAsync(pb => pb.Id == productDto.Id);

                
                //יוצר פרטי קניה חדש

                    var newDetail = new models.PurchaseDetail
                    {
                        CodeProd = productDto.Id,
                        Amount = productDto.TempAmount,
                        CodeBuy = buyId
                    };
                    purchaseDetails.Add(newDetail);
                
            }
            //מוסיף אותו למסד

            await db.PurchaseDetails.AddRangeAsync(purchaseDetails);

            await db.SaveChangesAsync();
            //מחזיר את הפרטי קניה לאחר המרה לרשימת מוצרים בחזרה
            return converters.PurchaseDetail.ToDtoProductsFromPurchaseDetails(purchaseDetails);
        }


    }

}


