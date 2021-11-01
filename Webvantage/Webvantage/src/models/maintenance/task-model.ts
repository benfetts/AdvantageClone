export class TaskModel {

    Code: string;
    Description: string;
    ProcessOrderNumber: number;
    DaysToComplete: number;
    HoursAllowed: number;
    IsInactive: boolean;
    IsMilestone: boolean;
    FunctionCode: string;
    RoleCode: string;
    StatusCode: string;

    constructor() {

    }

    static fromObject(data: any) {
        let Task = new TaskModel();
        Object.assign(Task, data);
        return Task;
    }
}
