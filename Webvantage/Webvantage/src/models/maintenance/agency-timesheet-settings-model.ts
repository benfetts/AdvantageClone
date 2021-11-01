export class AgencyTimesheetSettingsModel {

    AgencyTimeEntryOptions: AgencyTimeEntryOptions;
    DisplaySettings: DisplaySettings;

    constructor() {

    }

    static fromObject(data: any) {
        let me = new AgencyTimesheetSettingsModel();
        Object.assign(me, data);
        return me;
    }
}

 export class DisplaySettings {

    DaysToDisplay: number;
    ShowCommentsUsing: string;
    StartTimesheetOnDayOfWeek: number;
    Labels: Labels;
    DisablePagingOnMainGrid: boolean;
    RepeatRowForAllDays: boolean;
    OnlyShowMyProgress: boolean;

    constructor() {

    }

    static fromObject(data: any) {
        let me = new DisplaySettings();
        Object.assign(me, data);
        return me;
    }
}

 export class Labels {

     Division: string;
     Product: string;
     ProdCat: string;
     Job: string;
     JobComponent: string;
     FuncCat: string;

     constructor() {

     }

     static fromObject(data: any) {
         let me = new Labels();
         Object.assign(me, data);
         return me;
     }
 }

export class AgencyTimeEntryOptions {

    StopwatchMinimumTime: number;
    StopwatchRoundToNextIncrement: number;
    AllTimeEntryMinimumTime: number;
    AllTimeEntryRoundToNextIncrement: number;
    CommentsRequiredWhenSubmittingForApproval: boolean;
    StartTimesheetOnDayOfWeek: number;
    RequireAssignment: boolean;

    constructor() {

    }

    static fromObject(data: any) {
        let me = new AgencyTimeEntryOptions();
        Object.assign(me, data);
        return me;
    }
}
