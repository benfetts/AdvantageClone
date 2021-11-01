import { ModelBase } from 'models/base/model-base';

export class TimeSummaryModel extends ModelBase {

    private _DayDisplay: Date;
    get DayDisplay(): Date {
        return this._DayDisplay;
    }
    set DayDisplay(value: Date) {
        this._DayDisplay = this.getDate(value);
    }

    Hours: number;
    AgencyHours: number;
    NonBillableHours: number;
    ClientHours: number;
    IndirectHours: number;

    HasStopwatch: boolean;
    StopwatchEmployeeTimeID: number;
    StopwatchEmployeeTimeDetailID: number;
    Selected: boolean;

    HoursGoal: number;
    ShortDate: string;
    DayOfWeekString: string;
    ShortDayOfWeek: string;
    DayMonthDisplay: string;

    constructor() {

        super();

    }

}
