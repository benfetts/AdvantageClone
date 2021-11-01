import { ModelBase } from 'models/base/model-base';

export class AlertStateEmployeeModel extends ModelBase {

    AlertTemplateID: number;
    AlertStateID: number;
    EmployeeCode: string;
    FullName: string;
    IsDefault: boolean = false;
    IsSelected: boolean = false;
    CanDelete: boolean = false;
    ProofingStatusID: number;
    CssClass: string;

    constructor() {
        super();
    }

}
