import { NewWorkItemTime } from './new-work-item-time';
import { inject, bindable } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class NewWorkItemTimeDialog {

    controller: DialogController;
    alertID: number;
    newWorkItemTime: NewWorkItemTime;
    canAdd: boolean = false;

    addClick() {
        if (this.newWorkItemTime.canAdd === false) {
            return false;
        }
        let result = this.newWorkItemTime.save();
        if (typeof result === 'boolean') {
            if (result) {
                this.controller.ok();
            }
        } else {
            result.then(response => {
                if (response.content.Success === true) {
                    this.controller.ok();
                }
            });
        }
    }
    activate(model: any) {
        this.alertID = model.alertID;
       //console.log(this.alertID)
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
