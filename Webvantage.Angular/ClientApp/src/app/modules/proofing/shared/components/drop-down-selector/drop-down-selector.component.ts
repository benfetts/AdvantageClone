import { Component, Input, ViewEncapsulation } from '@angular/core';

import { ASSETS_TYPES } from '../../../constants/types/assets-types.constants';
import { VersionsAssetFileService } from '../../../services/versions-asset-file.service';

@Component({
  selector: 'proof-drop-down-selector',
  templateUrl: './drop-down-selector.component.html',
  styleUrls: ['./drop-down-selector.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DropDownSelectorComponent {
  @Input() public listItems: string[];

  public itemsTypes = ASSETS_TYPES;

  constructor(private versionsAssetFileService: VersionsAssetFileService) {
  }

  public onValueChange(value: string): void {
    this.versionsAssetFileService.setAssetVersion(this.itemsTypes[value]);
  }
}
