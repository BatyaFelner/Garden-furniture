import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../class/product';
import { PurchaseDetails } from '../../class/PurchaseDetail';
import { ProductService } from './Product.service';
import { ClientService } from './client.service';
import Swal from 'sweetalert2';
import { Buy } from '../../class/Buy';


@Injectable({
  providedIn: 'root'
})
export class BuyService {
  private baseUrl = 'https://localhost:7092/api/Buy';
//servise לניהול קניות 
//יוצר קניה
  basket: Buy = new Buy(); 
  //מציב במערך של מוצר את המערך של המוצרים שנמצאים בקניה
  cart: Product[] = this.basket.purchaseDetails;

  constructor(
    public http: HttpClient, 
    public cf: HttpClient, 
    public ps: ProductService, 
    public cl: ClientService
  ) {}


//פונקציה להוספת קניה 
//מציב בקוד משתמש שבקניה את המשתמש הנוכחי
//ואת התאריך הנוכחי 
//ושולחח לשרת 
  addBuy(): Observable<Buy> {

    console.log(JSON.stringify(this.basket));
    this.basket.codeClient=this.cl.currentUser?.id
    this.basket.date= new Date()
    return this.http.post<Buy>('https://localhost:7092/api/buyControler', this.basket);
  }

 //פונקציה שמוחת את הקניה לאחר השמירה בשרת 
    removebuy() {
      debugger
      this.cart = [];  
    this.basket=new Buy(); 
    
    
    
  }
//פונקציה לשמירת הקניה לאחר אישור התשלום
//מחזירה Dictionary
//עם כל המוצרים שלא עודכנו במסד כי לא היה במאלי 
  saveBuy(id: number): Observable<{ [key: string]: number }> {
    return this.http.get<{ [key: string]: number }>(`https://localhost:7092/api/buyControler/${id}`);
}

//מוסיף מוצר לרישמת המוצרים 
//שיש אפשרות באמת להוסיף

  addtocart(p: Product) {
    if (p.amount > p.tempAmount) {
      let productIndex = this.cart.findIndex(p1 => p1.id === p.id);
      if (productIndex != -1) {
        this.cart[productIndex].tempAmount++;
      } else {
        p.tempAmount = 1;
        this.cart.push(p);
      }
      this.basket.purchaseDetails=this.cart

      this.basket.sumCount = (this.basket.sumCount || 0) + 1;
      this.basket.sumPrice = (this.basket.sumPrice || 0) + (p.price || 0);
    }
  }
//מוחקת מוצר מרשימת המוצרים
  removetocart(p: Product) {
    let productIndex = this.cart.findIndex(p1 => p1.id == p.id);
    if (productIndex != -1) {
      if (this.basket.sumCount != undefined) {
        this.basket.sumCount -= (this.cart[productIndex]?.tempAmount || 0);
      }
      
      if (this.basket.sumPrice != undefined) {
        this.basket.sumPrice -= (p.tempAmount ? p.tempAmount : 0) * (p.price ? p.price : 0);
      }
      this.cart.splice(productIndex, 1); 

  }
  }

}
