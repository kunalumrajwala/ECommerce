import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { PagerHeaderComponent } from './Components/pager-header/pager-header.component';
import { PagerComponent } from './Components/pager/pager.component';

@NgModule({
  declarations: [PagerHeaderComponent, PagerComponent],
  imports: [CommonModule, PaginationModule.forRoot(), CarouselModule.forRoot()],
  exports: [
    PaginationModule,
    PagerHeaderComponent,
    PagerComponent,
    CarouselModule,
  ],
})
export class SharedModule {}
