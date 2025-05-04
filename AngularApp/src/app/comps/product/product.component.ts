import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../server/Product.service';
import { Product } from '../../class/product';
import { CardshopeComponent } from '../cardshope/cardshope.component';
import { Location } from '@angular/common';
import { CategoryService } from '../server/category.service copy';
import { Category } from '../../class/category';
import { CompenyService } from '../server/Compeny.service';
import { Company } from '../../class/company';
import { FormsModule, NgModel } from '@angular/forms';
import { ButtonComponent } from "../../button/button.component";

@Component({
  //קומפוננטה להצגת כל המוצרים
  selector: 'app-product',
  standalone: true,
  imports: [CardshopeComponent, FormsModule, ButtonComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
})
export class ProductComponent implements OnInit {
  //מקבלת את הקוד קטגוריה אם שלחו לפי קוד קטגוריה
  //מה  params

  categoryId?: number;
  allP: Array<Product> = new Array<Product>();
  allC: Array<Category> = new Array<Category>()
  allCm: Array<Company> = new Array<Company>()
  selectall: Array<number> =[0,0,0,0]
  constructor(private route: ActivatedRoute, public ps: ProductService, public l: Location, public cs: CategoryService, public cm: CompenyService) { }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.categoryId = params['categoryId'];
      this.get();
    })
  }

  get() {
    //הבאת כל המוצרים
    //ומסנן
    //מבי אאת כל הקטגוריות
    this.cs.getC().subscribe(
      d => {

        this.allC = d
      },
      err => { console.log("error -צד שרת לא הביא את הדברים שבקשת") }
    )


       //מביא את כל החברות
    this.cm.getAllCompany().subscribe(
      d => {

        this.allCm = d
      },
      err => { console.log("error -צד שרת לא הביא את הדברים שבקשת") }
    )

  //בודק אם הגיע דרך בחירת קטגוריה מסוימת
    if (this.categoryId != undefined) {
      this.ps.getProduct(this.categoryId).subscribe(
        (d) => {
          //מציב במה שמוצג את המוצרים לפי קוד קטגוריה
          this.allP = d;
          console.log('הצליח להביא מוצרים לפי קטגוריה');
          console.log(this.allP);
        },
        (err) => {
          console.error('שגיאה בצד שרת בעת הבאת מוצרים לפי קטגוריה');
        }
      );
    } else {
      this.ps.getAllProduct().subscribe(
        (d) => {
          this.allP = d;
          console.log('הצליח להביא את כל המוצרים');
        },
        (err) => {
          console.error('שגיאה בצד שרת בעת הבאת כל המוצרים');
        }
      );
    }
  }



  back() {
    this.l.back()
  }

  //סינון ע"י הצבה
filter(){
  debugger
  if(this.categoryId!=undefined)
    //בודק אם יש קוד קטגוריה  אם כן מציב במערך שנמצא בservuse 
  //את הקוד שלו 
    this.selectall[0]=this.categoryId
    //הולך לservise של המוצרים 
  //ומציב בו את המערך שהצבנו  בhtml 
  //לפי הבחירה של המשתמש
  this.ps.filter(this.selectall).subscribe(d=>
  {
    console.log(d)
    debugger
    this.allP = d;
    
    // this.selectall=[0,0,0,0]
  }
  )
}

//פונקציה למיון 
//מקבלת map כלשהו 
//ומוצר ומפעיל עליו מיון לפי מה שקבל או מינימום או מקסיממום 
sort1(func:(x:Product,y:Product)=>number){
  this.allP.sort(func)
}

   min(x:Product,y:Product){
   return ((x.price?x.price:0)-(y.price?y.price:0))
  }
    
  max(x:Product,y:Product){
    return ((y.price?y.price:0)-(x.price?x.price:0))
   }
}

