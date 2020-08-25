import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from '../shop/shop.component';
import { ProductDetailComponent } from '../shop/product-detail/product-detail.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', component: ShopComponent },
  {
    path: ':id',
    component: ProductDetailComponent,
    data: { breadcrumb: { alias: 'productDetails' } },
  },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShopRoutingModule {}
