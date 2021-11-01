import { ModelBase } from 'models/base/model-base';

export class AlertCommentModel extends ModelBase {

    private _GeneratedDate: Date;

    RowID: number;
    CommentID: number;

    get GeneratedDate(): Date {
        return this._GeneratedDate;
    }
    set GeneratedDate(value: Date) {
        this._GeneratedDate = this.getShortDate(value);
    }

    Comment: string;
    ShortComment: string;
    IsTruncated: number;
    IsClientPortalTruncated: boolean;
    UserName: string;
    UserCode: string;
    EmployeeCode: string;
    EmployeeFullName: string;
    EmployeeNickname: string;
    EmployeePicture: string;
    AssignedEmployeeCode: string;
    AssignedEmployeeFullName: string;
    AssignedEmployeeNickname: string;
    AssignedEmployeePicture: string;
    AlertTemplateID: number;
    AlertTemplateName: string;
    AlertStateID: number;
    AlertStateName: string;
    AssignmentChanged: boolean;
    IsUnassigned: boolean;
    DocumentList: string;
    ProofingExternalReviewerID: number;
    HasImage: boolean;
    Initials: string;

    constructor() {
        super();
    }

}
