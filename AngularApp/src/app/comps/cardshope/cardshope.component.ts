import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../class/product';
import { CurrencyPipe, NgClass } from '@angular/common';
import { Router } from '@angular/router';
import { ProductService } from '../server/Product.service';
import { AzalDirective } from '../directive/azal.directive';
import { BuyService } from '../server/Buy.service';

@Component({
  selector: 'app-cardshope',
  standalone: true,
  imports: [NgClass,CurrencyPipe,AzalDirective],
  templateUrl: './cardshope.component.html',
  styleUrls: ['./cardshope.component.css'], 
})
export class CardshopeComponent implements OnInit {
 // קומפםננטה לשליפת מוצר יחיד
  //מקבל בinput את המוצר 

    constructor( public route:Router , public product1:ProductService ,public b:BuyService){} 
  @Input() p!: Product;
  @Input() num: number=1;
  pics: Array<string> = new Array<string>;
  urlpic: string = '';

  //שולף את כל התמונות ויוצר מערך ולוקח את התמונה במקום הראשון

  ngOnInit(): void {
    if (this.p) {
    
      this.pics = this.p.pic?.split(",") || new Array<string>
                debugger
      this.urlpic = `${this.p.codeCategoryName}/${this.pics[0].replaceAll(/[\s]/g, '')}`;

    }
  }

//פונקציה להבאת פרטים נוספים
  move(pId:number)
{
  debugger
  console.log(`./more/${pId}`)
  this.route.navigate([`./more/${pId}`]) 
}
//מוסיף לרשימה שבסל את המוצר
addtocart(){
  debugger
this.num++
this.b.addtocart(this.p);

}
}


