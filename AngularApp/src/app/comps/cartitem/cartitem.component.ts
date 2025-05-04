import { Component ,Input, Output, EventEmitter, OnInit } from '@angular/core';
import { Product } from '../../class/product';
import { ProductService } from '../server/Product.service';
import { ButtonComponent } from "../../button/button.component";


@Component({
  selector: 'app-cartitem',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './cartitem.component.html',
  styleUrl: './cartitem.component.css'
})
export class CartitemComponent  implements OnInit{
  //קומפוננטה להבאת מוצר יחיד של סל
  //מקבל פונקציות ומפעיל אותם בהתאם לבקשה של האבא 
  //הסל יש בו רשימה של מוצרים הוא מקבל מוצר בטעינת הקומפוננטה
  @Input() item!: Product;
  @Input() line: boolean = false;
  @Output() add = new EventEmitter<void>();
  @Output() remove1 = new EventEmitter<void>();
  @Output() remove = new EventEmitter<void>();
  
  constructor( public product1:ProductService ){} 
 
 
   pics: Array<string> = new Array<string>;
   urlpic: string = '';
 
   
 
   ngOnInit(): void {
    //להבאת התמונה המתאימה של הפריט
     if (this.item) {
       this.pics = this.item.pic?.split(",") || new Array<string>
                 debugger
       this.urlpic = `${this.item.codeCategoryName}/${this.pics[0].replaceAll(/[\s]/g, '')}`;
 
     }
   
  }
}
