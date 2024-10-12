import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../Core/shop.service';
import { product } from '../../Shared/Model/Product';
import { MatCard } from '@angular/material/card';
import { ProductItemComponent } from "./product-item/product-item.component";
@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [MatCard, ProductItemComponent],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {

  private shopservice = inject(ShopService);
  i:number=0;
  products:product[]=[];

  ngOnInit(): void {
   this.InitializeShop();
  }

  InitializeShop(){
    this.shopservice.getBrand();
    this.shopservice.getTypes();
    this.shopservice.getproducts().subscribe({
      next:Response=> this.products=Response.data,
      error:error=>console.log(error)
    });
  }

}
