export class StatusModel {

    Code: string;
    Description: string;
    IsInactive: boolean;

    constructor() {

    }

    static fromObject(data: any) {
        let Status = new StatusModel();
        Object.assign(Status, data);
        return Status;
    }
}
