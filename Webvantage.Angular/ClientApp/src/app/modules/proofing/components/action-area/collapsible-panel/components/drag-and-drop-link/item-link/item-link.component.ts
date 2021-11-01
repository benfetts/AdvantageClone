import { Component, EventEmitter, Input, Output } from '@angular/core';

import { FILE_NAME_TYPES } from '../../../../../../constants/types/file-name-types';

const PDF = 'PDF';
const FILE_NAME_LENGTH = 13;

@Component({
  selector: 'proof-uploaded-item-link',
  templateUrl: './item-link.component.html',
  styleUrls: ['./item-link.component.scss']
})
export class ItemLinkComponent {
  @Output() public remove = new EventEmitter<string>();

  @Input() public thumbnail: boolean;
  @Input() public showVersions = false;
  @Input() public fileName: string;
  @Input() public textInIcon: string;
  @Input() public selected: boolean;
  @Input() public uid: string;

  public itemType = FILE_NAME_TYPES.VERSIONS;
  public fileNameLength = FILE_NAME_LENGTH;

  get isDocument(): boolean {
      return this.textInIcon === PDF;
  }

  public onRemove(uid: string): void {
    this.remove.emit(uid);
  }
}
