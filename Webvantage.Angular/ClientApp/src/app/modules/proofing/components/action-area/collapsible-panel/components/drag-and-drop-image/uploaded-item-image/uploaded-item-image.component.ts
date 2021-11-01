import { Component, EventEmitter, Input, Output } from '@angular/core';

import { FILE_NAME_TYPES } from '../../../../../../constants/types/file-name-types';

@Component({
  selector: 'proof-uploaded-item-image',
  templateUrl: './uploaded-item-image.component.html',
  styleUrls: ['./uploaded-item-image.component.scss']
})
export class UploadedItemImageComponent {
  @Output() public remove = new EventEmitter<string>();

  @Input() public thumbnail: boolean;
  @Input() public showVersions = false;
  @Input() public fileName: string;
  @Input() public textInIcon: string;
  @Input() public selected: boolean;
  @Input() public uid: string;

  public itemType = FILE_NAME_TYPES.VERSIONS;

  public onRemove(uid: string): void {
    this.remove.emit(uid);
  }
}
