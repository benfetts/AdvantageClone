import { DROP_DOWN_TYPES } from '../components/bottom-container/asset-explorer-toolbar/constants/items-types.constants';

export interface IAssets {
  [DROP_DOWN_TYPES.VERSIONS]: string;
  [DROP_DOWN_TYPES.IN_THIS_REVIEW]: string;
  [DROP_DOWN_TYPES.RELATED_ASSETS]: string;
}
