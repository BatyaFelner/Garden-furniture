import { Component, input } from '@angular/core';
import { CardcatComponent } from '../cardcat/cardcat.component';
import { Category } from '../../class/category';
import { CategoryService } from '../server/category.service copy';

@Component({
  selector: 'app-shope',
  standalone: true,
  imports: [CardcatComponent],
  templateUrl: './shope.component.html',
  styleUrl: './shope.component.css'
})
export class ShopeComponent {
  constructor(public cs: CategoryService) { }

ngOnInit(): void {
  this.get()
}
allC: Array<Category> = new Array<Category>()

get(){

    
  this.cs.getC().subscribe(
    d => {
   
      this.allC = d
    },
    err=>{console.log("error -צד שרת לא הביא את הדברים שבקשת" )}
  )

}
}
