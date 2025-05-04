using Dto;
using IBll;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bll
{
    public class funcbuy : buyIBll
    {
        private readonly IDal.IbuyDal buyDal;
        private readonly IDal.IpurchaseDetailsDal purchaseDetailsDal;
        private readonly IDal.IClientDal clientDal;

        public funcbuy(IDal.IbuyDal buyDal, IDal.IpurchaseDetailsDal purchaseDetailsDal, IDal.IClientDal clientDal)
        {
            this.buyDal = buyDal;
            this.purchaseDetailsDal = purchaseDetailsDal;
            this.clientDal = clientDal;
        }

        public async Task<List<Dto.Buy>> GetAllAsync()
        {
            return await buyDal.GetAllAsync();
        }

        //מוסיף קניה 
        public async Task<Dto.Buy> addbuyAsync(Buy buy)
        {

           //מקבל קניה ומחפש את המשתמש לפי הקוד קניה בקניה שקבל
            var client = await clientDal.GetClientByIdAsync(buy.CodeClient);

            buy.SumPrice = 0;
            //עובר על כל הפרטי קניה שכרגע הם מסוג PRODUCT
            //ומציב במחיר שהוא צריך לשלם את הסכום הסופי שלו 
            foreach (var product in buy.PurchaseDetails)
            {
                buy.SumPrice += product.TempAmount * product.Price;
            }
            //בודק האם החודש זה החודש התאריך שלו
            //אם כן מעדכן את המחיר למחיר - 20 אחוז
            if (client.BearthDate?.Month == DateTime.Now.Month)
            {
                buy.SumPrice -= (int)(buy.SumPrice * 0.2);
            }
            //יוצר קניה חדשה ע"י כך שמפעיל את הIDAL 
            //ואז ייתקיים הזרקת תלויות לDAL

            var createdBuy = await buyDal.addbuyAsync(buy);
            //יוצר פרטי קניה ע"י שליחה לIDAL 
            //גם את רשימת המוצרים וכן את הקוד קניה 
            //בDAL יש שליחה להמרה ממוצרים לפרטי קניה 
          await purchaseDetailsDal.addPurchaseDetailsAsync(buy.PurchaseDetails, createdBuy.Id);
            //מחזיר את הקניה שיצרתי
            return createdBuy;
        }


        //שומר את הקניה ע"י הפעלת הפונקציה בIDAL
        public async Task<Dictionary <string, int>> SaveBUy(int id)
        {
             return await buyDal.SaveBUy(id);
        }

        public async Task<List<Dto.Buy>> GetByIdcleinAsync(string id)
        {
            return await buyDal.GetByIdcleinAsync(id);
        }
    }
}
