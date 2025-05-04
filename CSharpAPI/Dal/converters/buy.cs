using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.converters
{
    public class buy
    {

        public  Dto.Buy ToDtobuy(models.Buy b)
        {


            Dto.Buy bNew = new Dto.Buy();
            bNew.Id = b.Id;
            var converter = new Dal.converters.PurchaseDetail(new PatioFurnitureContext());
           
                bNew.PurchaseDetails = Dal.converters.PurchaseDetail.ToDtoProductsFromPurchaseDetails(b.PurchaseDetails);
            
            bNew.CodeClient = b.CodeClient;
            bNew.Date = b.Date;
            bNew.SumPrice = b.SumPrice;
            bNew.Note = b.Note;

            return bNew;

        }
        //ממיר קניה מסוג מחלקת DTO ל מיקרוסופט
     public  models.Buy ToModelbuy(Dto.Buy b)
{
    models.Buy bNew = new models.Buy();
    bNew.Id = b.Id;
    bNew.CodeClient = b.CodeClient;
    bNew.SumPrice = (short?)b.SumPrice;
    bNew.Note = b.Note;

            return bNew;
}
        public  List<Dto.Buy> TolistDtobuy(List<models.Buy> lb)
        {


            List<Dto.Buy> lnew = new List<Dto.Buy>();
            foreach (models.Buy b in lb)
            {
                lnew.Add(ToDtobuy(b));
            }
            return lnew;
        }
    }
}
