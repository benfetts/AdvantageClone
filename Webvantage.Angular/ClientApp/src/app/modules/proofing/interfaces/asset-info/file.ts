import { FILE } from '../../constants/types/asset-info-table/file-table.constants';

export interface IAssetInfoFile {
  [FILE.FILE_NAME]: string;
  [FILE.DIMENSIONS]: string;
  [FILE.FILE_SIZE]: string;
  [FILE.TYPE]: string;
}
