import { Component, Input, ViewEncapsulation } from '@angular/core';

import { IVersion } from '../../../../../../interfaces/review-versions';

@Component({
  selector: 'proof-review-version-block',
  templateUrl: './review-version-block.component.html',
  styleUrls: ['./review-version-block.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewVersionBlockComponent {
  @Input() public version: IVersion;
}
