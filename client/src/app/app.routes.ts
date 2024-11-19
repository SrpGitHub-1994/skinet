import { Routes } from '@angular/router';
import { HomeComponent } from './Feature/home/home.component';
import { ShopComponent } from './Feature/shop/shop.component';
import { ProductDetailsComponent } from './Feature/product-details/product-details.component';

export const routes: Routes = [
    {path:'', component:HomeComponent },
    {path:'shop', component:ShopComponent },
    {path:'shop/:id', component:ProductDetailsComponent },
    {path:'**', redirectTo : '', pathMatch:'full'},
];
