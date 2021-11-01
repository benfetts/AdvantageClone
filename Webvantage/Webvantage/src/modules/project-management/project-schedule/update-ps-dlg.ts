import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class UpdateProjectScheduleDlg {
    controller: DialogController;
    alertGroupCode = [];

    alertGroupMultiSelect: kendo.ui.MultiSelect;
    alertGroupDataSource: kendo.data.DataSource;

    alertGroup = { alertGroupName: '', IsDefault: false, UpdateSelected: 0 };

    updateAll = [
        { id: 0, name: "Update Current Page" },
        { id: 1, name: "Update Selected Project Schedule(s)" }
    ];

    constructor(controller: DialogController) {
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;
        
    }    

    activate() {
    }
}
