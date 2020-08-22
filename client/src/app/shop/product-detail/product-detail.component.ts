import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { IProduct } from 'src/app/shared/Model/IProduct';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss'],
})
export class ProductDetailComponent implements OnInit {
  product: IProduct;
  constructor(
    private _shopService: ShopService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this._shopService
      .getProductById(+this.activatedRoute.snapshot.paramMap.get('id'))
      .subscribe(
        (product) => {
          this.product = product;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
