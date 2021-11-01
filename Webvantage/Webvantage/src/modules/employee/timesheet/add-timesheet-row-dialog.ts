import { AddTimesheetRow } from './add-timesheet-row';
import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class AddTimesheetRowDialog {

    controller: DialogController;
    employeeCode: string;
    addTimesheetRow: AddTimesheetRow;

    addClick() {
        //let result = this.addTimesheetRow.save();
        //if (typeof result === 'boolean') {
        //    if (result) {
        //        this.controller.ok();
        //    }
        //} else {
        //    result.then(response => {
        //        if (response.content.Success === true) {
        //            this.controller.ok();
        //        }
        //    });
        //}
    }

    activate(model: any) {
        this.employeeCode = model.employeeCode;
    }
    cancelClick() {
        this.controller.cancel();
    }
    constructor(dialogController: DialogController) {
        this.controller = dialogController;
        this.controller.settings.centerHorizontalOnly = false;
        this.controller.settings.overlayDismiss = false;
    }

}
