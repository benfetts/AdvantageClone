import { Component, Input } from '@angular/core';
import { IAssetInfo } from '../../../../../interfaces/asset-info';

import { IAssetInfoFile } from '../../../../../interfaces/asset-info/file';
import { LEFT_COLUMN_WIDTH, RIGHT_COLUMN_WIDTH } from '../constants/column-width';

@Component({
  selector: 'proof-versions',
  templateUrl: './versions-grid.component.html',
  styleUrls: ['./versions-grid.component.scss']
})
export class VersionsGridComponent {
  @Input() public assetInfo: IAssetInfo;

  public leftColumnWidth = LEFT_COLUMN_WIDTH;
  public rightColumnWidth = RIGHT_COLUMN_WIDTH;
}
