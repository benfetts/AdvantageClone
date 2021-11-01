import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class UpdateAlertGroupDlg {
    controller: DialogController;
    alertGroupCode = [];

    alertGroupMultiSelect: kendo.ui.MultiSelect;
    alertGroupDataSource: kendo.data.DataSource;

    alertGroup = { alertGroupName: '', IsDefault: false, UpdateSelected: 0 };

    updateAll = [
        { id: 0, name: "Update Current Page" },
        { id: 1, name: "Update Selected Job(s)" }
    ];

    constructor(controller: DialogController) {
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

        this.setAlertGroupDataSource()
    }

    setAlertGroupDataSource() {
        let me = this;
        this.alertGroupDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchAlertGroups'
                }
            }
        });
        if (this.alertGroupMultiSelect) {
            this.alertGroupMultiSelect.setDataSource(this.alertGroupDataSource);
        }
    }

    alertGroupMultiSelect_OnChange(e) {
        if (this.alertGroupCode && this.alertGroupCode.length > 0) {
            this.alertGroup.alertGroupName = this.alertGroupCode[0];
        }
        else {
            this.alertGroup.alertGroupName = "";
        }
    }

    activate() {
    }
}
