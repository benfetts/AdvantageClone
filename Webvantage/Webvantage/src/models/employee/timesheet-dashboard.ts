import { ModelBase } from 'models/base/model-base';

export class TimesheetDashboard extends ModelBase {

    //  Today
    HoursToday: number = 0.00;
    GoalHoursToday: number = 0.00;
    RequiredHoursToday: number = 0.00;
    RequiredHoursWeek: number = 0.00;
    ////DirectHoursToGoalToday: number = 0.00;
    ////DirectHoursToGoalTodayPercent: number = 0.00;

    ////AgencyHoursToday: number = 0.00;
    ////NewBusinessHoursToday: number = 0.00;
    ////ClientHoursToday: number = 0.00;
    ////IndirectHoursToday: number = 0.00;

    //  This week
    HoursThisWeek: number = 0.00;
    GoalHoursThisWeek: number = 0.00;
    DirectHoursToGoalThisWeek: number = 0.00;
    DirectHoursToGoalThisWeekPercent: number = 0.00;

    AgencyHoursThisWeek: number = 0.00;
    NewBusinessHoursThisWeek: number = 0.00;
    ClientHoursThisWeek: number = 0.00;
    IndirectHoursThisWeek: number = 0.00;
    RequiredHoursThisWeek: number = 0.00;
    RequiredHoursThisWeekByType: number = 0.00;

    Color: string = "#808080";
    DarkColor: string = "#474747";

    constructor() {

        super();

    }

}
