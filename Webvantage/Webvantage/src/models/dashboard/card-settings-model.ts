import { ModelBase } from 'models/base/model-base';

export class CardSettingsDlgModel {

    ShowClientNameAlert: boolean;
    ShowJobNumberAlert: boolean;
    ShowJobComponentNumberAlert: boolean;
    ShowJobDescriptionAlert: boolean;
    ShowJobComponentDescriptionAlert: boolean;
    ShowTaskCommentAlert: boolean;
    ShowStateAlert: boolean;

    ShowClientNameAssignment: boolean;
    ShowJobNumberAssignment: boolean;
    ShowJobComponentNumberAssignment: boolean;
    ShowJobDescriptionAssignment: boolean;
    ShowJobComponentDescriptionAssignment: boolean;
    ShowTaskCommentAssignment: boolean;
    ShowStateAssignment: boolean;

    ShowClientNameReview: boolean;
    ShowJobNumberReview: boolean;
    ShowJobComponentNumberReview: boolean;
    ShowJobDescriptionReview: boolean;
    ShowJobComponentDescriptionReview: boolean;

    TaskStatus: string = "A";
    StartDateasofToday: boolean = false;
    TasksOnlyWithStartAndDueDates: boolean = false;

    PropertyCount: number = 22; // increment this number when adding more properties; used to make sure the refresh happens only when all settings are done saving.

    constructor() {
    }
}
