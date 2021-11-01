import { Component, Input } from '@angular/core';

@Component({
  selector: 'proof-tag',
  templateUrl: './tag.component.html',
  styleUrls: ['./tag.component.scss']
})
export class TagComponent {
  @Input() public text: string;
}
