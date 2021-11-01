import { ModelBase } from 'models/base/model-base';
import { AlertAssignmentModel } from 'models/desktop/alert-assignment-model';

export class AlertModel extends ModelBase {

    private _StartDate: Date;
    private _DueDate: Date;
    private _GeneratedDate: Date;
    private _OriginatedDate: Date;
    private _MyAlertDismissedDate: Date;
    private _CompletedDate: Date;

    ID: number;
    AlertLevel: string;
    AlertLevelDisplay: string;
    AlertTypeID: number;
    AlertTypeDescription: string;

    get GeneratedDate(): Date {
        return this._GeneratedDate;
    }
    set GeneratedDate(value: Date) {
        this._GeneratedDate = this.getDate(value);
    }
    get OriginatedDate(): Date {
        return this._OriginatedDate;
    }
    set OriginatedDate(value: Date) {
        this._OriginatedDate = this.getDate(value);
    }

    IsCPAlert: number;
    UserName: string;
    UserCode: string;
    GeneratedByEmployeeCode: string;
    GeneratedByEmployeeName: string;
    EmployeeCode: string;
    OfficeCode: string;
    OfficeName: string;
    ClientCode: string;
    ClientName: string;
    DivisionCode: string;
    DivisionName: string;
    ProductCode: string;
    ProductName: string;
    CampaignID: number;
    CampaignCode: string;
    CampaignName: string;
    JobNumber: number;
    JobDescription: string;
    JobComponentNumber: number;
    JobComponentDescription: string;
    TaskFunctionDescription: string;
    EstimateNumber: number;
    EstimateDescription: string;
    EstimateComponentNumber: number;
    EstimateComponentDescription: string;
    AlertCategoryID: number;
    AlertCategoryDescription: string;
    PriorityLevel: number;
    PriorityDescription: string;
    StartDateString: string;
    DueDateString: string;
    CompletedDateString: string;
    SelectedDocumentID: number = 0;
    Assignment: AlertAssignmentModel;

    get StartDate(): Date {
        return this._StartDate;
    }
    set StartDate(value: Date) {
        this._StartDate = this.getShortDate(value);
    }

    get DueDate(): Date {
        return this._DueDate;
    }
    set DueDate(value: Date) {
        this._DueDate = this.getShortDate(value);
    }

    get CompletedDate(): Date {
        return this._CompletedDate;
    }
    set CompletedDate(value: Date) {
        this._CompletedDate = this.getShortDate(value);
    }

    TimeDue: string;
    Subject: string;
    Body: string;
    EmailBody: string;
    AlertAssignmentTemplateID: number;
    AlertAssignmentTemplateName: string;
    AlertStateID: number;
    AlertStateName: string;
    AlertSequenceNumber: number;
    DisplayID: number;
    IsAlertAssignment: boolean;
    CommentCount: number;
    Version: string;
    VersionName: string;
    Build: string;
    BuildName: string;
    AttachmentCount: number;
    TaskCode: string;
    TaskSequenceNumber: number;
    AccountPayableID: number;
    AccountPayableSequenceNumber: number;
    IsCompleted: boolean;
    IsMyAlert: boolean;
    IsMyAlertOpen: boolean;
    IsMyAlertDismissed: boolean;
    IsTask: boolean;
    IsMyTask: boolean;
    IsMyTaskTempComplete: boolean;
    DueDateLocked: boolean;
    IsMultiRoute: boolean = false;
    IsRouted: boolean;

    get MyAlertDismissedDate(): Date {
        return this._MyAlertDismissedDate;
    }
    set MyAlertDismissedDate(value: Date) {
        this._MyAlertDismissedDate = this.getDate(value);
    }
    IsMyAssignment: boolean;
    IsMyAssignmentOpen: boolean;
    IsMyAssignmentCompleted: boolean;
    MediaATBRevisionID: number;
    MediaATBNumber: number;
    MediaATBDescription: string;
    WasMarkedRead: boolean;
    WvPermaLink: string;
    CpPermaLink: string;
    SprintID: number;
    SprintDescription: string;
    BoardID: number;
    BoardName: string;
    BoardHeaderID: number;
    BoardHeaderDescription: string;
    BoardStateID: number;
    BoardStateName: string;
    IsWorkItem: boolean;
    AssignedEmployeeCode: string;
    AssignedEmployeeName: string;
    HoursAllowed: number;
    HoursPosted: number;
    HoursAllocated: number;
    HoursAllocatedBalance: number;
    HoursBalance: number;
    SendAssignmentComment: string;
    UploadedFiles: Array<string>;
    Recipients: Array<string>;
    Assignees: Array<string>;
    HasSchedule: boolean;
    LinkedDocuments: Array<number>;
    Checklists: Array<any>;
    TaskFunctionComment: string;
    CSProjectID: number;
    CSReviewID: number;
    JobHours: number;
    IsAutoRoute: boolean = false;
    TaskStatusCode: string;
    TaskStatusDescription: string;
    //For reports:
    CallingPage: string;
    IncludeAttachments: boolean = true;

    constructor() {
        super();
        this.Assignment = new AlertAssignmentModel;
    }
    
}
