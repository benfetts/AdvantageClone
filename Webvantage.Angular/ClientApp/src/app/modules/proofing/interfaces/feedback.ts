export interface IFeedback {
  alertId: number;
  alertStateId?: number;
  alrtNotifyHdrId?: number;
  assignedEmpCode: string;
  boardColId?: number;
  boardDtlId?: number;
  boardHdrId?: number;
  boardId?: number;
  comment: string;
  commentId: number;
  csCommentId?: number;
  csProjectId?: number;
  csReplyId?: number;
  csReviewId?: number;
  custodyEnd?: Date;
  custodyStart?: Date;
  documentId?: number;
  emailsent?: boolean;
  generatedDate?: Date;
  isDraft?: boolean;
  isSystem?: boolean;
  parentId?: number;
  userCode?: string;
  userCodeCp?: string;
  vcCode?: string;
  vrCode?: string;
  employeeFullName?: string;
  markupId?: number;
  markupSeqNumber?: number;
  proofingXReviwerId?: number;

  replies?: Array<IFeedback>;

  //name: string;
  //commentTime: string;
  //mentioned: string;
  //text: string;
  //addReplyBlock: boolean;
  //imageUrl: string;
  flagChecked: boolean;
  //mark: number;
  //draft?: boolean;
  //replies?: string;

  mentions: string[];
  active: boolean;
}

export interface IFeedbackExpanded extends IFeedback {
  expanded: boolean;
}
