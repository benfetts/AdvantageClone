import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Observable } from 'rxjs';

import { ReviewTypeService } from '../../../../services/review-type.service';
import { REVIEW_TYPES } from '../../../../constants/types/review-types';

@Component({
  selector: 'proof-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewsComponent implements OnInit {
  public reviewType: Observable<string>;
  public reviewVersions = REVIEW_TYPES.VERSIONS;
  public reviewApproval = REVIEW_TYPES.APPROVAL;

  constructor(private reviewTypeService: ReviewTypeService) {
  }

  public ngOnInit(): void {
    this.reviewType = this.reviewTypeService.getReviewType();
  }
}
