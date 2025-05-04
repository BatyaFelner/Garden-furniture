import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../class/product';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  //קומפוננטת להבאת מוצרים 
  private baseUrl = 'https://localhost:7092/api/Product'; 
  //  cart : Array<Product> =this.loadCart()
   
  //  count:number=0
  //  sumcount:number=0
  constructor(private http: HttpClient) {}
 //קבלת מוצרים לפי קוד קוד קטגוריה 
  getProduct(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/category/${categoryId}`);
  
  }
  //קבלת המוצרים הפופולרים  - 
  //5 המוצרים שקנו מהם הכי הרבה 
  getPopolaryroduct(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseUrl}/populate`);
  
  }
  //קבלת מוצר לפי קוד 
  //השתמשתי בשביל פרטים נוספים
  getProductId(pId: number): Observable<Product> {
    debugger
    console.log(`${this.baseUrl}/Product/${pId}`)
    return this.http.get<Product>(`${this.baseUrl}/${pId}`);
  
  }
//מביא את כל המוצרים
  getAllProduct(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl);
  }
  //מביא את כל המוצרים לפי סינון 
  filter(selectall:Array<number>):Observable<Product[]>{
    
    debugger
    console.log(`${this.baseUrl}/${selectall[0]}?${selectall[1]}/${selectall[2]}/${selectall[3]}`)

    return this.http.get<Product[]>(`${this.baseUrl}/filter?CodeCat=${selectall[0]}&minPrice=${selectall[1]}&maxPrice=${selectall[2]}&codeComp=${selectall[3]}`);

  }
    // loadCart(): Array<Product> {
  // debugger
  //   const cartString = sessionStorage.getItem('cart');
  //   return cartString ? JSON.parse(cartString) : [];
  // }
}
