import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'proof-dialog-window',
  templateUrl: './dialog-window.component.html',
  styleUrls: ['./dialog-window.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DialogWindowComponent {
  @Input() public isDialogOpened: boolean;
  @Input() public showOneButton = false;
  @Input() public dialogWindowText;
  @Input() public closeButtonText = 'Remove';
  @Output() public dialogWindowClosed = new EventEmitter<boolean>();

  public closeDialog(): void {
    this.dialogWindowClosed.emit(false);
    this.isDialogOpened = false;
  }
}
