import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { IPagination } from '../shared/Model/IPagination';
import { IBrands } from '../shared/Model/IBrands';
import { IProductTypes } from '../shared/Model/IProductTypes';
import { map, delay } from 'rxjs/operators';
import { shopParams } from '../shared/Model/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: shopParams): Observable<IPagination> {
    let params = new HttpParams();
    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    params = params.append('Sort', shopParams.sort.toString());
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageIndex', shopParams.pageSize.toString());
    if (shopParams.search) {
      params = params.append('Search', shopParams.search.toString());
    }

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((res) => {
          return res.body;
        })
      );
  }

  getBrand(): Observable<IBrands[]> {
    return this.http.get<IBrands[]>(this.baseUrl + 'Products/brands');
  }

  getTypes(): Observable<IProductTypes[]> {
    return this.http.get<IBrands[]>(this.baseUrl + 'Products/types');
  }
}
