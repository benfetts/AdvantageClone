import { DialogController } from 'aurelia-dialog';
import { bindable, inject, customElement } from 'aurelia-framework';

@inject(DialogController)
export class CardSettingsDialog {
    controller: DialogController;

    taskstatusDropDownList: kendo.ui.DropDownList;

    data: any;

    constructor(controller: DialogController) {
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

    }

    activate(Data: any) {
        this.data = Data;
    }

    okPressed(){
        var item = this.taskstatusDropDownList.dataItem(this.taskstatusDropDownList.select());
        this.data.TaskStatus = item.value;
        this.controller.ok(this.data);
    }
}
