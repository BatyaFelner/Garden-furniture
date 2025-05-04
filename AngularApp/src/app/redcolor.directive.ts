import { Directive , ElementRef ,HostListener, input, Input} from '@angular/core';

@Directive({
  selector: '[appRedcolor]',
  standalone: true
})

export class RedcolorDirective {

  @Input() appRedcolor = '';
  @HostListener('click') onMouseEnter() {
    this.highlight('red');
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }
   constructor(private el: ElementRef) {
    // this.el.nativeElement.style.border = (color)+' red solid 2px';

}

}

