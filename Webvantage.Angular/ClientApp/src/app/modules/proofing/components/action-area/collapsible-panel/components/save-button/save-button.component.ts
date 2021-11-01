import { Component, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'proof-save-button',
  templateUrl: './save-button.component.html',
  styleUrls: ['./save-button.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SaveButtonComponent {
  @Input() public disabled: boolean = true;
}
