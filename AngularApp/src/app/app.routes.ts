import { Routes } from '@angular/router';
import { HomepageComponent } from './comps/homepage/homepage.component';
import { ShopeComponent } from './comps/shope/shope.component';
import { LoginComponent } from './comps/login/login.component';
import { ErrorComponent } from './comps/error/error.component';
import { ShoppingBasketComponent } from './comps/shopping-basket/shopping-basket.component';
import { ProductComponent } from './comps/product/product.component';
import { MoreDetailsComponent } from './comps/more-details/more-details.component';



 //קומפוננטת ניתובים 
export const routes: Routes = [
    { path: 'home page', component: HomepageComponent },
    { path: 'login', component: LoginComponent },
    { path: 'basket', component: ShoppingBasketComponent },
    { path: 'products/:categoryId', component: ProductComponent },
    { path: 'products', component: ProductComponent },
    { path: 'כל המוצרים', component: ShopeComponent, title: 'מתקני חצר' },
    { path: 'more/:pId' , component: MoreDetailsComponent, title: 'מתקני חצר' },
    { path: '', component: HomepageComponent },
    { path: '**', component: ErrorComponent },
  ];
    