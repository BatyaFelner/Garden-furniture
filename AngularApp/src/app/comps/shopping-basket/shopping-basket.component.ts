import { Component, OnInit } from '@angular/core';
import { CartitemComponent } from '../cartitem/cartitem.component';
import { ProductService } from '../server/Product.service';
import { Product } from '../../class/product';
import { ClientService } from '../server/client.service';
import { Router } from '@angular/router';
import { BuyService } from '../server/Buy.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shopping-basket',
  standalone: true,
  imports: [CartitemComponent],
  templateUrl: './shopping-basket.component.html',
  styleUrl: './shopping-basket.component.css'
})
export class ShoppingBasketComponent implements OnInit{
  //קומפוננטת הסל 
  stores: Array<Product>= [];

  
  totalAmount = 0;

  constructor(public cart1:ProductService, public client: ClientService ,    public route:Router, public pd:BuyService ,public p:ProductService) {
  }
  ngOnInit(): void {
    this.stores=this.pd.cart
    this.totalAmount=this.pd.basket.sumPrice?this.pd.basket.sumPrice:0;
  }


//מוסיף לרשימת המוצרים של הסל ע"י שליחה לservise 
  addToCart(item: Product) {
   this.pd.addtocart(item)
  }
//מוחק כמוצ מפריט ברשימה
 remove1(item: Product) {
  if(item.tempAmount==1)
    this.removeFromCart(item)
  else{
    debugger
    if (item.tempAmount && item.tempAmount > 0) {
      item.tempAmount -= 1;
      this.pd.basket.sumCount-=1;
      this.pd.basket.sumPrice-=item.price?item.price:0
    }
     
    }
  }
//מוחק מוצר מהרשימה
  removeFromCart(item: Product) {
   
   debugger
    this.pd.removetocart(item)
  }
  //לתשלום 
  //מביא את כל המוצרים שלא הצליחו להתעדכן 
  topay(){
if(!this.client.currentUser){

  this.route.navigate(['./login']) 
}
else{
  
    this.pd.addBuy().subscribe(x=>{
        Swal.fire({
          title: "הקניה שלך נשמרה, הסכום הסופי:"+x.sumPrice,
          showDenyButton: true,
          showCancelButton: true,
          confirmButtonText: "לאישור קניה",
          denyButtonText:" לביטול הקניה",
          cancelButtonText:"חזור"
        }).then((result) => {
          /* Read more about isConfirmed, isDenied below */
          if (result.isConfirmed) {
            this.pd.saveBuy(x.id || 0).subscribe(y => {
             
              let str = "";
              x.purchaseDetails?.forEach(element => {
                const prodName = element.nameP || ''; // שם המוצר
                const remainingAmount = y[prodName]; // כמות שנותרה מהמילון
                if (remainingAmount !== undefined) {
                  str += `המוצר ${prodName} חסר במלאי ${remainingAmount} יחידות.\n`;
                } else {
                  str += `המוצר ${prodName} נקלט בהצלחה!\n`;
                }
              });
              console.log(str); // הצגת ההודעה או טיפול נוסף

              this.stores = [];
              this.pd.removebuy();
              Swal.fire(str, "", "success");
            });
          
          } else if (result.isDenied) {
            Swal.fire({
              title: "האם אתה בטוח?",
              text: "לאחר מכן לא תוכל לחזור לסל שלך!",
              icon: "warning",
              showCancelButton: true,
              confirmButtonColor: "#3085d6",
              cancelButtonColor: "#d33",
              confirmButtonText: "כן, מחק את הסל!"
            }).then(async(result) => {
              if (result.isConfirmed) {

                this.stores=[]
                this.pd.removebuy()
                Swal.fire({
                  title: "הסל נמחק!",
                  text: "הסל נמחק בהצלחה.",
                  icon: "success"
                });
              }
            });          }
        });
      })
  
    }
  }

} 


