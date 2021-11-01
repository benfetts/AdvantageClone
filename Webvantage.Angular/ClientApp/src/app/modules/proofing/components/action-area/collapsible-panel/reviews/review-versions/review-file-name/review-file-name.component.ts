import { Component, Input } from '@angular/core';

@Component({
  selector: 'proof-review-file-name',
  templateUrl: './review-file-name.component.html',
  styleUrls: ['./review-file-name.component.scss']
})
export class ReviewFileNameComponent {
  @Input() public imageUrl: string;
  @Input() public fileName: string;
  @Input() public fileDate: string;
}
