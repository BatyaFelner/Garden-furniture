import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { RedcolorDirective } from './redcolor.directive';
import { LoginComponent } from './comps/login/login.component';
import { ClientService } from './comps/server/client.service';
import { Client } from './class/Client';
import { ProductService } from './comps/server/Product.service';
import { BuyService } from './comps/server/Buy.service';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RedcolorDirective , RouterLink,LoginComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  color = 'yellow';
  title = 'AngularProject';
  showLogin = false;
  //טוען את כמות המוצרים שבסל 
  counrcart?:number
constructor(public p :ProductService, public b:BuyService){}
ngOnInit(): void {
  this.counrcart= this.b.basket.sumCount
}
  toggleLogin() {
    this.showLogin = !this.showLogin;
  }
}
