import { Injectable,inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { product } from '../Shared/Model/Product';
import { pagination } from '../Shared/Model/pagination';
import { Brand } from '../Shared/Brand';
import { Types } from '../Shared/Model/Types';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5001/api/';
  private http=inject(HttpClient);
  types:string[]=[];
  brand:string[]=[];


  getproducts(brands?:string[],types?:string[]) { 
    let params=new HttpParams();
    if(brands && brands.length>0)
    {
      params=params.append('brands',brands.join(','));
    }
    if(types && types.length>0)
      {
        params=params.append('types',types.join(','));
      }

      params=params.append('pageSize',20);
    return this.http.get<pagination<product>>(this.baseUrl+'Products/Products',{params});
  }

  getBrand(){
    if (this.brand.length>0) return;
    return this.http.get<Brand[]>(this.baseUrl+'Products/Brands').subscribe(
      res=>
        {
          for (let i = 0; i < res.length; i++) {
           
            this.brand.push(res[i].name);
          }
         
          console.log(this.brand);
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
          console.log(this.types);
        },
        err=>{
          console.log(err);
        });
  }
}
