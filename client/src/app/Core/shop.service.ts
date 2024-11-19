import { Injectable,inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { product } from '../Shared/Model/Product';
import { pagination } from '../Shared/Model/pagination';
import { Brand } from '../Shared/Brand';
import { Types } from '../Shared/Model/Types';
import { shopParams } from '../Shared/Model/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5001/api/';
  private http=inject(HttpClient);
  types:string[]=[];
  brand:string[]=[];


  getproducts(shopparams:shopParams) { 
    let params=new HttpParams();
    if(shopparams.brands && shopparams.brands.length>0)
    {
      // for (let i = 0; i < shopparams.brands.length; i++) {
      //   params=params.append('brands',shopparams.brands[i]);       
      // }
      params=params.append('brands',shopparams.brands.join(','));
    }
    if(shopparams.types && shopparams.types.length>0)
     {
        params=params.append('types',shopparams.types.join(','));
    }
    if(shopparams.sort)
    {
      params=params.append('sort',shopparams.sort);
    }
    if(shopparams.search)
    {
      params=params.append('search',shopparams.search);
    }
      params=params.append('pageSize',shopparams.pageSize);
      params=params.append('pageIndex',shopparams.pageNumber);
      console.log(params);
    return this.http.get<pagination<product>>(this.baseUrl+'Products/Products',{params});
  }

  GetProduct(id:number){
    return this.http.get<product>(this.baseUrl+'Products/Product/'+id)
  }
  getBrand(){
    if (this.brand.length>0) return;
    return this.http.get<Brand[]>(this.baseUrl+'Products/Brands').subscribe(
      res=>
        {
          for (let i = 0; i < res.length; i++) {
           
            this.brand.push(res[i].name);
          }
         
        },
        err=>{
          console.log(err);
        });
  }

  getTypes(){
    if (this.types.length>0) return;
    return this.http.get<Types[]>(this.baseUrl+'Products/Types').subscribe(
      res=>
        {
          for (let i = 0; i < res.length; i++) {
           
            this.types.push(res[i].name);
          }
        },
        err=>{
          console.log(err);
        });
  }
}
