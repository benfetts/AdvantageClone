export enum FileType {
  Image,
  PDF,
  DOC,
  XLS,
  PPT
}

export interface IDocument {
  documentId: number;
  filename: string;
  repositoryFilename: string;
  mimeType: string;
  description: string;
  keywords: string;
  userCode: string;
  fileSize: number;
  privateFlag?: number;
  documentTypeId: number;
  selected?: boolean;
  extension?: string;
}
