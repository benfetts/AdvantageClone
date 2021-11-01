export class PhaseModel {

    ID: number;
    Description: string;
    OrderNumber: number;
    IsInactive: boolean;

    constructor() {

    }

    static fromObject(data: any) {
        let Phase = new PhaseModel();
        Object.assign(Phase, data);
        return Phase;
    }
}
