import { Component, Input, ViewEncapsulation } from '@angular/core';

import { ASSET } from '../../../../../constants/types/asset-info-table/asset-table.constants';
import { Asset, IAssetInfoColumn } from '../constants/asset';
import { IAssetInfoAsset } from '../../../../../interfaces/asset-info/asset';
import { LEFT_COLUMN_WIDTH, RIGHT_COLUMN_WIDTH } from '../constants/column-width';
import { IAssetInfo } from '../../../../../interfaces/asset-info';

const MAX_LENGTH_DESCRIPTION = 20;
const DESCRIPTION_LENGTH = 18;
const MAX_LENGTH_URL = 18;
const URL_LENGTH = 16;

@Component({
  selector: 'proof-asset-grid',
  templateUrl: './asset-grid.component.html',
  styleUrls: ['./asset-grid.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AssetGridComponent {
  @Input() public assetInfo: IAssetInfo;

  public description: string = ASSET.DESCRIPTION;
  public assetUrl: string = ASSET.ASSET_URL;
  public tags: string = ASSET.TAGS;
  public columnsAsset: IAssetInfoColumn[] = Asset;
  public leftColumnWidth = LEFT_COLUMN_WIDTH;
  public rightColumnWidth = RIGHT_COLUMN_WIDTH;
  //ASSET.DESCRIPTION,ASSET.TAGS,
  public columns = [ ASSET.ASSET_URL,  ASSET.CREATED_DATE, ASSET.LATEST_MARKUP_DATE];


  get truncatedDescription(): string {
    if (this.assetInfo[ASSET.DESCRIPTION]) {
      return this.assetInfo[ASSET.DESCRIPTION].length > MAX_LENGTH_DESCRIPTION
        ? `${this.assetInfo[ASSET.DESCRIPTION].slice(0, DESCRIPTION_LENGTH)}...`
        : this.assetInfo[ASSET.DESCRIPTION];
    } else {
      return '';
    }
  }

  get truncatedLink(): string {
    return this.assetInfo[ASSET.ASSET_URL].length > MAX_LENGTH_URL
      ? `${this.assetInfo[ASSET.ASSET_URL].slice(0, URL_LENGTH)}...`
      : this.assetInfo[ASSET.ASSET_URL];
  }

  public renderColumn(property: string): boolean {
    return this.columns.some(column => column === property);
  }
}
