import { ModelBase } from 'models/base/model-base';

export class JobComponent extends ModelBase {

    ClientCode: string;
    ClientName: string;
    DivisionCode: string;
    DivisionName: string;
    ProductCode: string;
    ProductDescription: string;
    JobNumber: number;
    JobDescription: string;
    JobComponentNumber: number;
    JobComponentDescription: string;
    HasSchedule: boolean;

    constructor() {
        super();
    }


}
