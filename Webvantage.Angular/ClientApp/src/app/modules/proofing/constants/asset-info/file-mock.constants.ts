import { IAssetInfoFile } from '../../interfaces/asset-info/file';
import { FILE } from '../types/asset-info-table/file-table.constants';

export const fileMock: IAssetInfoFile = {
  [FILE.FILE_NAME]: 'CoD.jpg',
  [FILE.TYPE]: 'Image',
  [FILE.DIMENSIONS]: 'w:284px h:177px',
  [FILE.FILE_SIZE]: '8.17 KB',
};
