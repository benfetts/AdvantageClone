export class SalesClassModel {

    Code: string;
    Description: string;
    SalesClassType: string;
    IsInactive: boolean;

    constructor() {

    }

    static fromObject(data: any) {
        let SalesClass = new SalesClassModel();
        Object.assign(SalesClass, data);
        return SalesClass;
    }
}
