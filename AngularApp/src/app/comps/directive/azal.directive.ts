import { ElementSchemaRegistry } from '@angular/compiler';
import {Directive, ElementRef, HostListener, input, Input} from '@angular/core';

@Directive({
  selector: '[appRedBorder]',
  standalone: true
})
export class AzalDirective {
 // Directive - מקבל ארוע של לחיצה ובהתאם בכל פעם מעלה את המספר ע"י:
 // this.er.nativeElement.innerText=this.appRedBorder
  constructor(public er:ElementRef) {
   }
  @HostListener('click') onClick() {
    this.er.nativeElement.innerText=this.appRedBorder
  }
  @Input() appRedBorder:number= 1;
  // @HostListener('mouseleave') onMouseLeave() {
  //   this.highlight('');
  // }

}
  

