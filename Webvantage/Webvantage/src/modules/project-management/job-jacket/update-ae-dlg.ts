import { bindable, inject, customElement } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class UpdateAccountExecutiveDlg  {
    controller: DialogController;
    AccountExec = [];

    AccountExecObj = { AccountExec: '', IsDefault: false, UpdateSelected: 0 };

    data: any;

    updateAll = [
        { id: 0, name: "Update Current Page"},
        { id: 1, name: "Update Selected Job(s)" }
    ];

    accountExecutiveMultiSelect: kendo.ui.MultiSelect;
    accountExecutiveDataSource: kendo.data.DataSource;

    constructor(controller: DialogController) {
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

        //this.setAccountExecutiveDataSource();
    }

    setAccountExecutiveDataSource() {
        let me = this;

        //var data = {
        //    OfficeCode: me.data.OfficeCode,
        //    ClientCode: "", // me.data.ClientCode,
        //    DivisionCode: "", // me.data.DivisionCode,
        //    ProductCode: "", // me.data.ProductCode
        //};

        this.accountExecutiveDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchEmployee'
                }
            }
        });
        if (this.accountExecutiveMultiSelect) {
            this.accountExecutiveMultiSelect.setDataSource(this.accountExecutiveDataSource);
        }
    }

    accountExecutiveMultiSelect_OnChange(e) {
        if (this.AccountExec && this.AccountExec.length > 0) {
            this.AccountExecObj.AccountExec = this.AccountExec[0];
        }
        else {
            this.AccountExecObj.AccountExec = '';
        }
    }

    activate(Data: any) {
        this.data = Data;

        this.setAccountExecutiveDataSource();
    }
}
