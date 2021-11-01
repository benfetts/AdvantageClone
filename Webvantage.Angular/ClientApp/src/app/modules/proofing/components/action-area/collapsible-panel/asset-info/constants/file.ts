import { FILE } from '../../../../../constants/types/asset-info-table/file-table.constants';

export interface IFileInfoColumn {
  name: string;
  title: string;
}

export const File: IFileInfoColumn[] = [
  {
    name: 'fileName', title: FILE.FILE_NAME
  },
  {
    name: 'mimeType', title: FILE.TYPE
  },
  //{
  //  name: 'fileName', title: FILE.DIMENSIONS
  //},
  {
    name: 'fileSize', title: FILE.FILE_SIZE
  },
];
