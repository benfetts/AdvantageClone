import { Component, Input } from '@angular/core';

@Component({
  selector: 'proof-file-icons',
  templateUrl: './file-icons.component.html',
  styleUrls: ['./file-icons.component.scss']
})
export class FileIconsComponent {
  @Input() reviewComponent = false;
}
