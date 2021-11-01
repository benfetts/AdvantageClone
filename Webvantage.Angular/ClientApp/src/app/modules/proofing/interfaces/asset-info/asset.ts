import { ASSET } from '../../constants/types/asset-info-table/asset-table.constants';

export interface IAssetInfoAsset {
  [ASSET.TITLE]: string;
  [ASSET.STATUS]: string;
  [ASSET.DESCRIPTION]: string;
  [ASSET.VERSION]: string;
  [ASSET.CREATED_DATE]: string;
  [ASSET.CREATED_BY]: string;
  [ASSET.LAST_MODIFIED]: string;
  [ASSET.ASSET_URL]: string;
  [ASSET.TAGS]: string[];
}
