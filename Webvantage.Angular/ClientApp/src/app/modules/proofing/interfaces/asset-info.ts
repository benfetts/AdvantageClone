
export interface IAssetInfo {
  documentId: number;
  fileName: string;
  description: string;
  version: number;
  uploadDate: Date
  userCode: string;
  userFullName: string;
  tags: Array<string>;
  mimeType: string;
  fileSize: number;
  versions: Array<IAssetInfo>;

  thumbnail: any;
  isLatestDocument: boolean;
  totalApproves: number;
  totalRejects: number;
  totalDefers: number;
  totalMarkups: number;
  totalVersions: number;
  totalVersionsForAlertID: number;
  latestMarkupFullName: string;
  latestMarkupDate: Date;
}
