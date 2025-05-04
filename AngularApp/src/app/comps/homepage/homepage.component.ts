import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../class/product';
import { ProductService } from '../server/Product.service';
import { CardshopeComponent } from "../cardshope/cardshope.component";
import { Category } from '../../class/category';
import { CategoryService } from '../server/category.service copy';
import { CardcatComponent } from '../cardcat/cardcat.component';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [CardshopeComponent,CardcatComponent],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
//דף הבית
//שולפת את כל הקטגוריות 
//והצגת ע"י קריאה לקומפוננטת כרטיס קטגוריה 

export class HomepageComponent implements OnInit {
    allP: Array<Product> = new Array<Product>();
  constructor( public route:Router ,public ps: ProductService, public catS:CategoryService ,public ar:ActivatedRoute ){
    //שולף מהservise את חמשת המוצרים הפופולרים ביותר 
  this.getPopulates()

}
categories: Array<Category> = []

async ngOnInit() {
  debugger
  this.catS.getC().subscribe(x =>
    this.categories = x
  )
  this.ar.url.subscribe(urlSegments => {
    const fullPath = urlSegments.map(segment => segment.path);
    let element
    if (fullPath[fullPath.length - 1] == 'about')
      element = document.getElementById('about');
    if (element) {
      element.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }

  });

}
imgs: Array<string> = [ '543154.jpg','cddto-13-253-52-638120521722600283.webp', '543154.jpg']
population?: Array<Product>
// index:number=0;
getUrl(product: Product) {
  let arr = product.pic?.split(',')
  return product.codeCom + arr![0]
}
//מקבל את המוצרים הפופולים
getPopulates() {
  this.ps.getPopolaryroduct().subscribe(data => {
    this.population = data
  })
  // return prod.nameCat+"/"+prod.pic?.split(',')[0]
}
}

