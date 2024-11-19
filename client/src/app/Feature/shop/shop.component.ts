import { Component, inject, OnInit } from '@angular/core';
import { ShopService } from '../../Core/shop.service';
import { product } from '../../Shared/Model/Product';
import { MatCard } from '@angular/material/card';
import { ProductItemComponent } from "./product-item/product-item.component";
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatButton, MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { MatOption } from '@angular/material/core';
import { shopParams } from '../../Shared/Model/shopParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { pagination } from '../../Shared/Model/pagination';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-shop',
  standalone: true,
  imports: [
            ProductItemComponent,
            MatButton,
            MatIcon,
            //MatCard, 
            MatMenu,
            MatSelectionList,
            //MatOption,
            MatMenuTrigger,
            MatListOption,
            MatPaginator,
            FormsModule,
            MatIconButton
          ],

  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})

export class ShopComponent implements OnInit {


  private shopservice = inject(ShopService);
  private dialogeService=inject(MatDialog);
  shopparams=new shopParams();
  products?:pagination<product>;
  pageSizeOptions=[5,10,15,20,25]
  // selectedBrands:string[]=[];
  // selectedTypes:string[]=[];
  // selectedSort:string='name';
  sortOptions=[
      {name:'Alphabatical',value:'name'},
      {name:'Price: Low-High',value:'priceAsc'},
      {name:'Price: High-Low',value:'priceDesc'},
    
]
  constructor(){

  }

  ngOnInit(): void {
   this.InitializeShop();
  }

  InitializeShop(){
    this.shopservice.getBrand();
    this.shopservice.getTypes();
   
    this.GetProdList();
  }

  onSearchChange(){
    this.shopparams.pageNumber=1;
    this.GetProdList();
  }

  onSortChange(event: MatSelectionListChange) {
      const selectedOption=event.options[0];
      if (selectedOption){
        this.shopparams.sort=selectedOption.value;
        this.shopparams.pageNumber=1;
        this.GetProdList();
      }
      
    }

    handlePageEvents(event:PageEvent){
      this.shopparams.pageNumber=event.pageIndex+1;
      this.shopparams.pageSize=event.pageSize;
      this.GetProdList();


    }

  OpenFilterDialoge()
  {
    const dialogRef=this.dialogeService.open(FiltersDialogComponent,{
      minWidth:'400px',
      data:{
          selectedBrand:this.shopparams.brands,
          selectedType:this.shopparams.types
      }
    });

    dialogRef.afterClosed().subscribe({
      next:results=>{
        if(results)
        {
          this.shopparams.brands=results.selectedBrand;
          this.shopparams.types=results.selectedType;
          //apply the filters below
          this.shopparams.pageNumber=1;
          this.GetProdList();

        }
      }
    });

  }

  GetProdList()
  {
   // this.shopservice.getproducts().subscribe({
     // next:Response=> this.products=Response.data,
      //error:error=>console.log(error)
    //});

    this.shopservice.getproducts(this.shopparams).subscribe({
      next:response=>this.products=response,
      error:err=>console.log(err)
    });
  }

}
