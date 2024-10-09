import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { product } from './Shared/Model/Product';
import { pagination } from './Shared/Model/pagination';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  i:number=0;
  title = 'client';
  baseUrl='https://localhost:5001/api/';
  private http=inject(HttpClient);
  products:product[]=[];

  ngOnInit(): void {
  var list=this.http.get<pagination<product>>(this.baseUrl+'Products/Products').subscribe({
    next:Response=> this.products=Response.data,
    error:error=>console.log(error),
    complete:()=>console.log('Complete')
  });
  }
}
