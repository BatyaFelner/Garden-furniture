import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../class/product';
import { ProductService } from '../server/Product.service';
import { Location } from '@angular/common';
import { BuyService } from '../server/Buy.service';


@Component({
  selector: 'app-more-details',
  standalone: true,
  imports: [],
  templateUrl: './more-details.component.html',
  styleUrl: './more-details.component.css'
})
export class MoreDetailsComponent {
  //קומפוננטה להצגת פרטים נוספים על כל מוצר
  //מקבלת מהניתוב id 
  //ושולפת מהפרמס על ID את הID 
  pId!: number;
  p!:Product
  index!:number
  x:number=0;
pics: Array<string> = new Array<string>;
urlpic: string = '';
  constructor(private route: ActivatedRoute ,  public pr :ProductService,public l: Location, public b:BuyService) { }
  ngOnInit(): void {
    //שליפה של  הID מהPARAMS
    this.route.params.subscribe((params) => {
      this.pId = params['pId'];
      this.get();
      if (this.p) {
      this.pics = this.p.pic?.split(",") || new Array<string>
      }
    })
  }
  get(){
    //מביאה את המוצר לפי קוד מוצר שקבלה
    this.pr.getProductId(this.pId).subscribe(
      (d)=>{
        this.p=d;
        this.pics = this.p.pic?.split(",") || new Array<string>
      })
    
  }
  back1(){
    //חזרה אחורה למקום הקודם שהיינו בו
    this.l.back()
  }
  getpic(i:number){
    debugger
    this.urlpic = `${this.p?.codeCategoryName}/${this.pics[i]}`;
    return this.urlpic
  }
  now(index:number){
this.x=index
  }

  addtocart(){
    //הוספה לסל ע"י הצבה בSERVISE 
    debugger
  this.b.addtocart(this.p);
  }

}




