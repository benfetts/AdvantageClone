import { bindable, inject, customElement } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class NewPurchaseOrderDlg {
    controller: DialogController;

    constructor(controller: DialogController) {
        let me = this;
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

    }
}
