import { Component, Input } from '@angular/core';

@Component({
  selector: 'proof-pasted-image',
  templateUrl: './pasted-image.component.html',
  styleUrls: ['./pasted-image.component.scss']
})
export class PastedImageComponent {
  @Input() public imageUrl: string;
}
