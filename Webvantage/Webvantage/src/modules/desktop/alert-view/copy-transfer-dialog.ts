import { inject, bindable } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { AlertModel } from 'models/desktop/alert-model';
import { CopyTransfer } from './copy-transfer';

@inject(DialogController)
export class AlertCommentDialog {
    controller: DialogController;
    Alert: AlertModel;
    copyTransfer: CopyTransfer;
    alertId: number;
    sprintId: number;
    isCopy: boolean = true;
    isProof: boolean = false;
    isRouted: boolean = false;
    saveClick() {
        this.copyTransfer.copy;
        this.copyTransfer.transfer;
        this.controller.ok();
    }
    cancelClick() {
        this.controller.cancel();
    }
    activate(model: any) {
        let me = this;
        this.Alert = model.Alert;
        this.alertId = model.alertID;
        this.sprintId = model.sprintID;
        this.isCopy = model.isCopy;
        this.isProof = model.isProof;
        this.isRouted = model.isRouted;
        console.log("model?", model);
    }
    attached() {
        let me = this;
        $(document).ready(function () {
        });
    }
    constructor(dialogController: DialogController) {
        this.controller = dialogController;
        //this.controller.settings.centerHorizontalOnly = false;
        //this.controller.settings.overlayDismiss = false;
    }
}
