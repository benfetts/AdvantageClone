import { bindable, inject, customElement } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class NewProjectScheduleDlg {
    controller: DialogController;

    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    divisionMultiSelect: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;
    productMultiSelect: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;
    jobMultiSelect: kendo.ui.MultiSelect;
    jobDataSource: kendo.data.DataSource;
    componentMultiSelect: kendo.ui.MultiSelect;
    componentDataSource: kendo.data.DataSource;
    statusMultiSelect: kendo.ui.MultiSelect;
    statusDataSource: kendo.data.DataSource;
    projectManagerMultiSelect: kendo.ui.MultiSelect;
    projectManagerDataSource: kendo.data.DataSource;

    clientMultiSelectCopy: kendo.ui.MultiSelect;
    clientDataSourceCopy: kendo.data.DataSource;
    divisionMultiSelectCopy: kendo.ui.MultiSelect;
    divisionDataSourceCopy: kendo.data.DataSource;
    productMultiSelectCopy: kendo.ui.MultiSelect;
    productDataSourceCopy: kendo.data.DataSource;

    clientCode = [];
    divisionCode = [];
    productCode = [];
    jobCode = [];
    componentCode = [];
    statusCode = [];
    projectManagerCode = [];

    clientCodeCopy = [];
    divisionCodeCopy = [];
    productCodeCopy = [];


    ShowClosed: boolean = false;
    IncludeStartDate: boolean = false;
    IncludeDueDate: boolean = false;
    IncludeTaskEmployee: boolean = false;
    IncludeTaskComment: boolean = false;
    IncludeDueDateComment: boolean = false;

    collapsed: boolean = true;

    setClientDataSource() {
        let me = this;
        this.clientDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '';
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        return {
                            OfficeCode: officeCode
                        }
                    }
                }
            }
        });
        if (this.clientMultiSelect) {
            this.clientMultiSelect.setDataSource(this.clientDataSource);
        }
    }

    clientMultiSelect_OnChange(e) {
        this.divisionCode = [];
        this.setDivisionDataSource();
        this.productCode = [];
        this.setProductDataSource();
    }


    setDivisionDataSource() {
        let me = this;
        this.divisionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchDivisions',
                    data: function () {
                        var officeCode = '',
                            clientCode = '';

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode
                        }
                    }
                }
            }
        });
        if (this.divisionMultiSelect) {
            this.divisionMultiSelect.setDataSource(this.divisionDataSource);
        }
    }

    divisionMultiSelect_OnChange(e) {
        let me = this;
        var item = null;

        if (me.divisionCode[0] && me.divisionCode[0].length > 0) {
            var data = this.divisionDataSource.data();
            for (var i = 0; i < data.length; i++) {
                if (data[i].Code == me.divisionCode[0]) {
                    item = data[i];
                    break;
                }
            };

            this.clientCode = [];
            this.clientCode[0] = item.ClientCode;
        }

        this.productCode = [];
        this.setProductDataSource();
    }

    setProductDataSource() {
        let me = this;
        this.productDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchProducts',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            officeCode = '';

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode
                        }
                    }
                }
            }
        });
        if (this.productMultiSelect) {
            this.productMultiSelect.setDataSource(this.productDataSource);
        }
    }

    productMultiSelect_OnChange(e) {
        let me = this;
        let item = null;

        if (me.productCode[0] && me.productCode[0].length > 0) {
            var data = this.productDataSource.data();
            for (var i = 0; i < data.length; i++) {
                if (data[i].Code == me.productCode[0]) {
                    item = data[i];
                    break;
                }
            };

            this.clientCode = [];
            this.clientCode[0] = item.ClientCode;

            this.setDivisionDataSource();
            me.divisionCode = [];
            me.divisionCode[0] = item.DivisionCode;
        }
    }

    setClientCopyDataSource() {
        let me = this;
        this.clientDataSourceCopy = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '';
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        return {
                            OfficeCode: officeCode
                        }
                    }
                }
            }
        });
        if (this.clientMultiSelectCopy) {
            this.clientMultiSelectCopy.setDataSource(this.clientDataSourceCopy);
        }
    }

    clientMultiSelectCopy_OnChange(e) {
        this.divisionCodeCopy = [];
        this.setDivisionCopyDataSource();
        this.productCodeCopy = [];
        this.setProductCopyDataSource();
    }


    setDivisionCopyDataSource() {
        let me = this;
        this.divisionDataSourceCopy = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchDivisions',
                    data: function () {
                        var officeCode = '',
                            clientCode = '';

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode
                        }
                    }
                }
            }
        });
        if (this.divisionMultiSelectCopy) {
            this.divisionMultiSelectCopy.setDataSource(this.divisionDataSourceCopy);
        }
    }

    divisionMultiSelectCopy_OnChange(e) {
        let me = this;
        var item = null;

        if (me.divisionCodeCopy[0] && me.divisionCodeCopy[0].length > 0) {
            var data = this.divisionDataSourceCopy.data();
            for (var i = 0; i < data.length; i++) {
                if (data[i].Code == me.divisionCodeCopy[0]) {
                    item = data[i];
                    break;
                }
            };

            this.clientCodeCopy = [];
            this.clientCodeCopy[0] = item.ClientCode;
        }

        this.productCode = [];
        this.setProductCopyDataSource();
    }

    setProductCopyDataSource() {
        let me = this;
        this.productDataSourceCopy = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchProducts',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            officeCode = '';

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode
                        }
                    }
                }
            }
        });
        if (this.productMultiSelectCopy) {
            this.productMultiSelectCopy.setDataSource(this.productDataSourceCopy);
        }
    }

    productMultiSelectCopy_OnChange(e) {
        let me = this;
        let item = null;

        if (me.productCodeCopy[0] && me.productCodeCopy[0].length > 0) {
            var data = this.productDataSourceCopy.data();
            for (var i = 0; i < data.length; i++) {
                if (data[i].Code == me.productCodeCopy[0]) {
                    item = data[i];
                    break;
                }
            };

            this.clientCodeCopy = [];
            this.clientCodeCopy[0] = item.ClientCode;

            this.setDivisionCopyDataSource();
            me.divisionCodeCopy = [];
            me.divisionCodeCopy[0] = item.DivisionCode;
        }
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchJob',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            officeCode = '',
                            AccountExecutive = '';

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        if (me.productCode && me.productCode.length > 0) {
                            productCode = me.productCode[0];
                        }
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        //if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
                        //    AccountExecutive = me.accountExecutiveCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            AccountExecutive: AccountExecutive
                        }
                    }
                }
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
    }

    jobMultiSelect_OnChange(e) {
        this.componentCode = [];
        this.setComponentDataSource();
    }

    setComponentDataSource() {
        let me = this;

        this.componentDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchComponent',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            jobCode = '',
                            AccountExecutive = '';

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        if (me.productCode && me.productCode.length > 0) {
                            productCode = me.productCode[0];
                        }
                        if (me.jobCode && me.jobCode.length > 0) {
                            jobCode = me.jobCode[0];
                        }
                        //if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
                        //    AccountExecutive = me.accountExecutiveCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            JobCode: jobCode,
                            AccountExecutive: AccountExecutive
                        }
                    }
                }
            }
        });
        if (this.componentMultiSelect) {
            this.componentMultiSelect.setDataSource(this.componentDataSource);
        }
    }

    componentMultiSelect_OnChange(e) {

    }

    setProjectManagerDataSource() {
        let me = this;
        this.projectManagerDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchProjectManager'
                }
            }
        });
        if (this.projectManagerMultiSelect) {
            this.projectManagerMultiSelect.setDataSource(this.projectManagerDataSource);
        }
    }

    setStatusDataSource() {
        let me = this;
        this.statusDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchStatus'
                }
            }
        });
        if (this.statusMultiSelect) {
            this.statusMultiSelect.setDataSource(this.statusDataSource);
        }
    }

    statusMultiSelect_OnChange(e) {

    }


    constructor(controller: DialogController) {
        let me = this;
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setJobDataSource();
        this.setComponentDataSource();
        this.setStatusDataSource();
        this.setProjectManagerDataSource();

        this.setClientCopyDataSource();
        this.setDivisionCopyDataSource();
        this.setProductCopyDataSource();

    }
}
