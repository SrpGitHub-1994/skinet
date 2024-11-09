import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../Core/shop.service';
import { product } from '../../Shared/Model/Product';
import { MatCard } from '@angular/material/card';
import { ProductItemComponent } from "./product-item/product-item.component";
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [MatCard, 
            ProductItemComponent,
            MatButton,
            MatIcon],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})
export class ShopComponent implements OnInit {

  private shopservice = inject(ShopService);
  private dialogeService=inject(MatDialog);
  products:product[]=[];
  selectedBrands:string[]=[];
  selectedTypes:string[]=[];

  constructor(){

  }

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

  OpenFilterDialoge()
  {
    const dialogRef=this.dialogeService.open(FiltersDialogComponent,{
      minWidth:'400px',
      data:{
          selectedBrand:this.selectedBrands,
          selectedType:this.selectedTypes
      }
    });

    dialogRef.afterClosed().subscribe({
      next:results=>{
        if(results)
        {
          this.selectedBrands=results.selectedBrand
          this.selectedTypes=results.selectedType
          //apply the filters below
          this.shopservice.getproducts(this.selectedBrands,this.selectedTypes).subscribe({
            next:response=>this.products=response.data,
            error:err=>console.log(err)
          });
        }
      }
    });
  }

}
