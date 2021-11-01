interface IDescriptionButtonsProperties {
  label: string;
}

export interface IApprovalReviewButtons {
  defer: IDescriptionButtonsProperties;
  approve: IDescriptionButtonsProperties;
  reject: IDescriptionButtonsProperties;
}
