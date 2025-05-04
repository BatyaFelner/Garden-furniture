import { Component, Input, input } from '@angular/core';
import { Category } from '../../class/category';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-cardcat',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './cardcat.component.html',
  styleUrl: './cardcat.component.css'
})
export class CardcatComponent {
    // @Input() cat!: Category
    @Input() nameCard?:string
    @Input() url?:string
    @Input() path?:string
//קומפוננטה להבאת הקטגוריה
    constructor(public router: Router) { }
    // toProd(){
    //   this.router.navigateByUrl(`/products/${this.cat.id}` )
    // }
    getImg(cat:Category){
      return cat.img;
    }
  }
