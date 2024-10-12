import { Injectable,inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { product } from '../Shared/Model/Product';
import { pagination } from '../Shared/Model/pagination';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl='https://localhost:5001/api/';
  private http=inject(HttpClient);
  types:string[]=[];
  brand:string[]=[];


  getproducts() { 
    return this.http.get<pagination<product>>(this.baseUrl+'Products/Products?pageSize=20');
  }

  getBrand(){
    if(this.brand.length>0) return;
    return this.http.get<string[]>(this.baseUrl+'Products/Brands').subscribe({
      next:response=>this.brand=response
    });
  }

  getTypes(){
    if(this.types.length>0) return;
    return this.http.get<string[]>(this.baseUrl+'Products/Types').subscribe({
      next:response=>this.types=response
    });
  }
}
