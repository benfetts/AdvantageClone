import { bindable, inject, customElement } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class CreateBudgetDialog {
    controller: DialogController;

    postPeriodDropDown: kendo.ui.DropDownList;
    postPeriodDataSource: kendo.data.DataSource;
    
    Periods = {
        MaxPeriods: 1,
        PostPeriodCode: ""
    }

    setPostPeriodDataSource() {
        let me = this;
        this.postPeriodDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchPostPeriod'
                }
            }
        });
    }


    constructor(controller: DialogController) {
        let me = this;
        this.controller = controller;
        this.controller.settings.lock = false;
        this.controller.settings.overlayDismiss = false;

        this.setPostPeriodDataSource();
    }
}
