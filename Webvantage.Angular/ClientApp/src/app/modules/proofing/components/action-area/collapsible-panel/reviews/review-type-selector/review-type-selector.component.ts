import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { LIST_OF_REVIEW_TYPES } from '../../../../../constants/types/review-types';
import { ReviewTypeService } from '../../../../../services/review-type.service';
import { reviewTypes } from '../../../../../constants/types/review-types.constants';

@Component({
  selector: 'proof-review-type-selector',
  templateUrl: './review-type-selector.component.html',
  styleUrls: ['./review-type-selector.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewTypeSelectorComponent implements OnInit {
  public listItems: string[] = LIST_OF_REVIEW_TYPES;
  public itemsTypes = reviewTypes;
  public reviewTypes;

  constructor(private reviewTypeService: ReviewTypeService) {
  }

  public ngOnInit(): void {
    this.reviewTypes = this.reviewTypeService.getReviewType();
  }

  public onValueChange(value: string): void {
    this.reviewTypeService.setReviewType(this.itemsTypes[value]);
  }
}
