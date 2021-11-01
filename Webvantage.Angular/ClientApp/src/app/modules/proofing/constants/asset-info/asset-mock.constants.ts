import { IAssetInfoAsset } from '../../interfaces/asset-info/asset';
import { ASSET } from '../types/asset-info-table/asset-table.constants';

export const assetMock: IAssetInfoAsset = {
  [ASSET.TITLE]: 'CoD.jpg',
  [ASSET.STATUS]: 'Under Review',
  [ASSET.STATUS]: 'Under Review',
  [ASSET.DESCRIPTION]: 'Bla bla bla bla bla bla bla',
  [ASSET.VERSION]: '3',
  [ASSET.CREATED_DATE]: '2020-05-18 2:51 AM',
  [ASSET.CREATED_BY]: 'Alan Able',
  [ASSET.LAST_MODIFIED]: '2020-05-19 9:40 AM',
  [ASSET.ASSET_URL]: 'https://tascml.gmail.com',
  [ASSET.TAGS]: ['tag1dfdfdfdfdfd', 'tag2', 'tag1', 'tag2', 'tag1', 'tag2', 'tag1', 'tag2']
};
