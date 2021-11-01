import { ModelBase } from 'models/base/model-base';

export namespace EmployeeTimesheet {

    export class Row extends ModelBase {

        RowID: number;
        ClientCode: string;
        ClientName: string;
        DivisionCode: string;
        DivisionName: string;
        ProductCode: string;
        ProductName: string;
        JobNumber: number;
        JobComponentNumber: number;
        FunctionCode: string;
        DepartmentTeamCode: string;
        Day1Date: Date;
        Day1ID: number;
        Day1DetailID: number;
        Day1SequenceNumber: number;
        Day1Hours: number;
        Day2Date: Date;
        Day2ID: number;
        Day2DetailID: number;
        Day2SequenceNumber: number;
        Day2Hours: number;
        Day3Date: Date;
        Day3ID: number;
        Day3DetailID: number;
        Day3SequenceNumber: number;
        Day3Hours: number;
        Day4Date: Date;
        Day4ID: number;
        Day4DetailID: number;
        Day4SequenceNumber: number;
        Day4Hours: number;
        Day5Date: Date;
        Day5ID: number;
        Day5DetailID: number;
        Day5SequenceNumber: number;
        Day5Hours: number;
        Day6Date: Date;
        Day6ID: number;
        Day6DetailID: number;
        Day6SequenceNumber: number;
        Day6Hours: number;
        Day7Date: Date;
        Day7ID: number;
        Day7DetailID: number;
        Day7SequenceNumber: number;
        Day7Hours: number;

        constructor() {
            super();
        }

    }

    export class Settings extends ModelBase {

        DaysToDisplay: number;
        StartTimesheetOnDayOfWeek: number;
        ShowCommentsUsing: string;
        DivisionLabel: string;
        ProductLabel: string;
        ProductCategoryLabel: string;
        JobLabel: string;
        JobComponentLabel: string;
        FunctionCategoryLabel: string;

        constructor() {
            super();
        }

    }
    export class Entry extends ModelBase {

        AlertSubject: number;
        EmployeeTimeID: number;
        EmployeeTimeDetailID: number;
        Hours: number;
        EntryDate: Date;
        Comments: string;
        EditFlag: number;
        TimeType: string;
        HasStopwatch: boolean;
        CannotEditDueToProcessingControl: boolean;
        CommentsRequired: boolean;
        CanDelete: boolean;
        AlertID: number;
        WebDataKey: string;
        LineID: string;

        constructor() {
            super();
        }

    }
    export class Line extends ModelBase {

        LineID: string;
        AlertSubject: string;
        AlertID: number;
        NonEditMessage: string;
        JobProcessControl: number;
        ClientName: string;
        DivisionName: string;
        ProductDescription: string;
        ClientCode: string;
        DivisionCode: string;
        ProductCode: string;
        JobNumber: number;
        JobDescription: string;
        JobComponentNumber: number;
        JobComponentDescription: string;
        FunctionCategory: string;
        FunctionCategoryDescription: string;
        DepartmentTeamCode: string;
        ProductCategory: string;
        TimeType: string;
        QuotedAmount: number;
        QuotedHours: number;
        ActualAmount: number;
        ActualHours: number;
        Threshold: number;
        IsOverThreshold: number;
        ProgressIsShowingTrafficHours: number;
        ProgressIsShowingOnlyEmployee: number;
        CannotEditDueToProcessingControl: number;
        ClientCommentRequired: number;
        TotalHours: number;

        Entries: Array<Entry>;

        constructor() {
            super();
        }

    }
    export class Day extends ModelBase {

        DayDate: Date;
        HasStopwatch: boolean;
        IsDenied: boolean;
        IsApproved: boolean;
        IsPendingApproval: boolean;
        PostPeriodIsClosed: boolean;
        CanEdit: boolean;
        DailyHours: number;
        PercentCompletedOfDailyHours: number;
        Status: number;
        TotalHours: number;
        StatusText: string;

        Entries: Array<Entry>;

        constructor() {
            super();
        }

    }

    export class Timesheet extends ModelBase {

        EmployeeCode: string;
        FullName: string;
        StartDate: Date;
        EndDate: Date;
        IsMissingComments: boolean;

        Lines: Array<Line>;
        Days: Array<Day>;

        UserSettings: Settings;

        constructor() {
            super();
        }

    }

}
