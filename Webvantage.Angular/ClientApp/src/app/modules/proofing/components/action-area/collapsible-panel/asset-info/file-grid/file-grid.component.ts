import { Component, Input } from '@angular/core';

import { File, IFileInfoColumn } from '../constants/file';
import { IAssetInfoFile } from '../../../../../interfaces/asset-info/file';
import { LEFT_COLUMN_WIDTH, RIGHT_COLUMN_WIDTH } from '../constants/column-width';
import { IAssetInfo } from '../../../../../interfaces/asset-info';
import { ASSET } from '../../../../../constants/types/asset-info-table/asset-table.constants';
import { FILE } from '../../../../../constants/types/asset-info-table/file-table.constants';

@Component({
  selector: 'proof-file-grid',
  templateUrl: './file-grid.component.html',
  styleUrls: ['./file-grid.component.scss']
})
export class FileGridComponent {
  @Input() public assetInfo: IAssetInfo;

  public columns = [FILE.FILE_NAME, FILE.FILE_SIZE];

  public columnsAsset: IFileInfoColumn[] = File;
  public leftColumnWidth = LEFT_COLUMN_WIDTH;
  public rightColumnWidth = RIGHT_COLUMN_WIDTH;

  public renderColumn(property: string): boolean {
    return this.columns.some(column => column === property);
  }
}
