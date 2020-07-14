import { Component, OnInit } from '@angular/core';
import {  HttpClient } from '@angular/common/http';
import {IProduct } from './Model/IProduct';
import {IPagination } from './Model/Pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'Ecommerce';
  products: IProduct[];

  constructor(private _httpClient: HttpClient){

  }

  ngOnInit(): void {
    this._httpClient.get('https://localhost:5001/api/products').subscribe((response: IPagination) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
  }
}
