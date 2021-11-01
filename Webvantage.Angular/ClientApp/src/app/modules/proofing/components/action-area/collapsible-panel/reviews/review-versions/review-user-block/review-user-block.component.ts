import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

import { IReviewVersion } from '../../../../../../interfaces/review-versions';

const MAX_LENGTH = 17;
const USERNAME_LENGTH = 20;

@Component({
  selector: 'proof-review-user-block',
  templateUrl: './review-user-block.component.html',
  styleUrls: ['./review-user-block.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewUserBlockComponent implements OnInit {
  @Input() public review: IReviewVersion;

  public ngOnInit(): void {
    this.review.name = this.review.name.length > MAX_LENGTH
      ? `${this.review.name.slice(0, USERNAME_LENGTH)}...`
      : this.review.name;
  }
}
