import { IAssets } from '../../interfaces/assets';
import { FILE_NAME_TYPES } from './file-name-types';
import { DROP_DOWN_TYPES } from '../../components/bottom-container/asset-explorer-toolbar/constants/items-types.constants';

export const ASSETS_TYPES: IAssets = {
  [DROP_DOWN_TYPES.VERSIONS]: FILE_NAME_TYPES.VERSIONS,
  [DROP_DOWN_TYPES.IN_THIS_REVIEW]: FILE_NAME_TYPES.ONE_ASSET,
  [DROP_DOWN_TYPES.RELATED_ASSETS]: FILE_NAME_TYPES.RELATED_ASSETS
};
