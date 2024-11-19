import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../Core/shop.service';
import { ActivatedRoute } from '@angular/router';
import { product } from '../../Shared/Model/Product';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { CurrencyPipe } from '@angular/common';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatDivider } from '@angular/material/divider';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [
    CurrencyPipe,
    MatButton,
    MatIcon,
    MatFormField,
    MatInput,
    MatLabel,
    MatDivider
  ],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {

  private shopService=inject(ShopService);
  private Activatedrouts=inject(ActivatedRoute);
  product?:product;

  ngOnInit(): void {
    this.loadProduct()
  }

  loadProduct(){
    const id=this.Activatedrouts.snapshot.paramMap.get('id');
    if(id){
      this.shopService.GetProduct((+id)).subscribe({
        next:product=> this.product=product,
        error:err=>console.log(err)
      })
    }
  }
}
