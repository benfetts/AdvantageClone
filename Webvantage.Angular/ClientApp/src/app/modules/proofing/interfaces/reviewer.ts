
export enum ProofingStatusID {
  Accept = 1,
  Reject,
  Defer
}


export interface IReviewer {
  id: number;
  employeeName: string;
  approveDate: Date;
  proofingStatusID: ProofingStatusID;
  proofingStatus: string;
  dl: string
}

export interface IReviewerGroup {
  alertStateId?: number;
  alertStateName?: string;
  isCurrentState: boolean;
  reviewers: IReviewer[];
}
