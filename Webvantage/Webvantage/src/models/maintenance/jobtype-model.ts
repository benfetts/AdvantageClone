export class JobTypeModel {

    Code: string;
    Description: string;
    IsInactive: boolean;
    SalesClassCode: string;

    constructor() {

    }

    static fromObject(data: any) {
        let JobType = new JobTypeModel();
        Object.assign(JobType, data);
        return JobType;
    }
}
