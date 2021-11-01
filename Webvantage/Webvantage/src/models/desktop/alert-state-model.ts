import { ModelBase } from 'models/base/model-base';
import { AlertStateEmployeeModel } from 'models/desktop/alert-state-employee-model';

export class AlertStateModel extends ModelBase {
    AlertStateID: number;
    AlertStateName: string;
    Selected: boolean = false;
    SelectedForSave: boolean = false; 
    Employees: Array<AlertStateEmployeeModel>;
    constructor() {
        super();
        this.Employees = new Array();
    }
}
