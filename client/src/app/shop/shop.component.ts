import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IProduct } from '../shared/Model/IProduct';
import { ShopService } from './shop.service';
import { error } from 'protractor';
import { IBrands } from '../shared/Model/IBrands';
import { IProductTypes } from '../shared/Model/IProductTypes';
import { shopParams } from '../shared/Model/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrands[];
  productTypes: IProductTypes[];
  shopParams = new shopParams();
  sortOption = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  search = '';
  totalCount: number;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProduct();
    this.getBrands();
    this.getTyeps();
  }

  getProduct(): void {
    this.shopService.getProducts(this.shopParams).subscribe(
      (response) => {
        this.products = response.data;
        this.shopParams.pageNumber = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBrands(): void {
    this.shopService.getBrand().subscribe(
      (response) => {
        this.brands = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getTyeps(): void {
    this.shopService.getTypes().subscribe(
      (response) => {
        this.productTypes = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onBrandIdSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProduct();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProduct();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.shopParams.pageNumber = 1;
    this.getProduct();
  }

  onSearchChange(search: string) {
    this.search = search;
    this.getProduct();
  }

  onPageChange(event: any) {
    if (this.shopParams.pageNumber !== event) {
      this.shopParams.pageNumber = event;
      this.getProduct();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProduct();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new shopParams();
    this.getProduct();
  }
}
