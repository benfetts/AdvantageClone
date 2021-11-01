export interface IVersion {
  versionNum: string;
  fileName: string;
  fileDate: string;
}

export interface IReviewVersion {
  name: string;
  reviewDate: string;
  reply: boolean;
  imageUrl?: string;
  versions: IVersion[];
}
