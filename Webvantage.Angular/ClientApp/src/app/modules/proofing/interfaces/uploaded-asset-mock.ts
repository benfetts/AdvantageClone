import { FileInfo } from '@progress/kendo-angular-upload';

import { IButtonProperties } from './button-properties';

export interface IUploadedAssetMock extends IButtonProperties, FileInfo {
  uid?: string;
  name: string;
  src: string;
  extension?: string;
}
