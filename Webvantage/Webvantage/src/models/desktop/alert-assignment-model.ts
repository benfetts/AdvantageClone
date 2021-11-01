import { ModelBase } from 'models/base/model-base';
import { AlertStateModel } from 'models/desktop/alert-state-model';

export class AlertAssignmentModel extends ModelBase {
    AlertTemplateID: number;
    AlertTemplateName: string;
    States: Array<AlertStateModel>;
    constructor() {
        super();
        this.States = new Array();
    }
}
