import { Component, EventEmitter, input, Input, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})
export class ButtonComponent {
  @Input() iconName:string=""

  @Input() text:string=""
 
  @Output() myEvent=new EventEmitter()
  
  even()
  {
    this.myEvent.emit()
  }
  }
  

