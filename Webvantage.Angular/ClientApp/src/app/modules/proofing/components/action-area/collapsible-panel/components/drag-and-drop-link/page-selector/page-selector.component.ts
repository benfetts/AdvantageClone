import { Component, ViewEncapsulation } from '@angular/core';

import { LIST_OF_PAGES } from '../constants/pages.constants';

@Component({
  selector: 'proof-page-selector',
  templateUrl: './page-selector.component.html',
  styleUrls: ['./page-selector.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class PageSelectorComponent {
  public listItems = LIST_OF_PAGES;
  public currentPage = this.listItems[0];

  get selectedPage(): string {
    return `${this.currentPage} of ${this.listItems.length}`;
  }

  public onValueChange(value: string): void {
    this.currentPage = value;
  }
}
