import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.scss'],
})
export class PagerComponent implements OnInit {
  @Input() totalCount: number;
  @Input() pageSize: number;
  @Output() pageChange = new EventEmitter<number>();

  constructor() {}

  ngOnInit(): void {}

  pagerChangeEvent(event: any) {
    this.pageChange.emit(event.page);
  }
}
