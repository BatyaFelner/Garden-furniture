using Dal.models;
using IDal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class buy : IbuyDal
    {

        PatioFurnitureContext db;
        public buy(PatioFurnitureContext db)
        {
            this.db = db;
            var converter = new Dal.converters.buy();

        }

        public async Task<List<Dto.Buy>> GetAllAsync()
        {
            var converter = new Dal.converters.buy();

            var list = await db.Buys.Include(b => b.PurchaseDetails).ToListAsync();
            return converter.TolistDtobuy(list);
        }



        //הוספת קנייה
        public async Task<Dto.Buy> addbuyAsync(Dto.Buy buy)
        {

            var converter = new Dal.converters.buy();
            //ממיר את הקנייה מסוג DTO למייקורוסופט 
            var buyEntity = converter.ToModelbuy(buy);
            //מוסיף את הקניה למסד 
            await db.Buys.AddAsync(buyEntity);
            await db.SaveChangesAsync();

            //מציב בקנייה את ה IDשיצר 
            //מחזיר את הקניה
            buy.Id = buyEntity.Id;
            return buy;
        }





        //שומר את הקניה
        //ומלחזיר Dictionary עם פריטים שלא הצליח לעדכן מחוסר כמות
        public async Task<Dictionary<string, int>> SaveBUy(int idBuy)
        {
            Dictionary<string, int> finished = new Dictionary<string, int>();
            //מוצא את הקניה לפי קוד קניה 
            var buy = await db.Buys.FirstOrDefaultAsync(b => b.Id == idBuy);
            ////מוצא את כל הפרטי קניה המתאימים לקוד קניה
            var purchaseDetails = await db.PurchaseDetails.Where(c => c.CodeBuy == idBuy).ToListAsync();
            //עובר על הפרטי קניה 
            //ובכל שלב מוצא את המוצר 
            //ומעדכן לו את הכמות ואת התאריך קניה האחרון
            foreach (var p in purchaseDetails)
            {
                var prod = await db.Products.FirstOrDefaultAsync(pb => pb.Id == p.CodeProd);
                if (prod != null)
                {
                    if (prod.Amount - p.Amount >= 0)
                    {
                        prod.Amount -= p.Amount;
                    }
                    else
                    {
                        finished.Add(prod.NameP, (int)(p.Amount - prod.Amount));
                        prod.Amount = 0;
                    }
                }
                prod.LastUpdate = DateTime.Now;
            }

            buy.StatusBuy = true;

            await db.SaveChangesAsync();

            //מחזיר הרשימה שלא הצליח לעדכן
            return finished;
        }

        //מביא את חמשת הקניות האחרונות לפי קוד משתמש
        public async Task<List<Dto.Buy>> GetByIdcleinAsync(string id)
        {
            var converter = new Dal.converters.buy();

            var orders = await db.Buys.Include(x => x.PurchaseDetails)
                                      .ThenInclude(x => x.CodeProdNavigation)
                                      .ThenInclude(x => x.CodeCatNavigation)
                                      .Where(x => x.CodeClient == id)
                                      .OrderByDescending(x => x.Date)
                                      .Take(5)
                                      .ToListAsync();

            var dtoBuys = converter.TolistDtobuy(orders);

            return dtoBuys;
        }


    }
}
















