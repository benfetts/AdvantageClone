import { customElement, bindable, observable, BindingEngine } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';


@customElement('wv-cdpjc-drop-downs')
export class cdpjcDropDowns extends ModuleBase {

    officeMultiSelect: kendo.ui.ComboBox;
    officeDataSource: kendo.data.DataSource;
    clientMultiSelect: kendo.ui.ComboBox;
    clientDataSource: kendo.data.DataSource;
    divisionMultiSelect: kendo.ui.ComboBox;
    divisionDataSource: kendo.data.DataSource;

    productMultiSelect: kendo.ui.ComboBox;
    productDataSource: kendo.data.DataSource;

    jobMultiSelect: kendo.ui.ComboBox;
    jobDataSource: kendo.data.DataSource;
    componentMultiSelect: kendo.ui.ComboBox;
    componentDataSource: kendo.data.DataSource;

    virtualClient;
    virtualDivision;
    virtualProduct;
    virtualJob;
    virtualComponent;

    resetDivision: boolean = false;
    resetProduct: boolean = false;
    resetJob: boolean = false;
    resetComponent: boolean = false;

    // search parameters
    @bindable officeCode = '';
    @bindable clientCode = '';
    @bindable divisionId = '';
    @bindable divisionCode = '';
    @bindable productId = '';
    @bindable productCode = '';
    @bindable jobNumber : number = null;
    @bindable componentCode = '';

    @bindable jobName: string = "";
    @bindable componentId: number = 0;
    @bindable componentName: string = "";
    @bindable accountExecutiveCode: string = '';
    @bindable campaignId: number = 0;
    @bindable salesClassCode: string = '';
    @bindable jobTypeCode: string = '';
    @bindable showClosedJobs: boolean = false;
    @bindable SprintId: number = 0;

    constructor() {
        super();

        this.setOfficeDataSource();
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setJobDataSource();
        this.setComponentDataSource();

        this.virtualClient = {
            itemHeight: 26,
            me: this,
            valueMapper: this.clientMapper
        };

        this.virtualDivision = {
            itemHeight: 26,
            me: this,
            valueMapper: this.divisionMapper
        };

        this.virtualProduct = {
            itemHeight: 26,
            me: this,
            valueMapper: this.productMapper
        };

        this.virtualJob = {
            itemHeight: 26,
            me: this,
            valueMapper: this.jobMapper
        };

        this.virtualComponent = {
            itemHeight: 26,
            me: this,
            valueMapper: this.componentMapper
        };
    }

    setOfficeDataSource() {
        let me = this;
        this.officeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchOffices'
                }
            }
        });
        if (this.officeMultiSelect) {
            this.officeMultiSelect.setDataSource(this.officeDataSource);
        }
    }

    officeMultiSelect_OnChange(e) {

        if (this.officeMultiSelect.value() && this.officeMultiSelect.select() == -1) {
            this.officeMultiSelect.value('');
            this.officeMultiSelect.focus();
        }
        else {
            this.clientMultiSelect.focus();
        }

        this.clientCode = '';
        this.clientDataSource.read();
        this.divisionId = '';
        this.divisionDataSource.read();
        this.productId = '';
        this.productDataSource.read();
        this.SprintId = 0;
        this.jobNumber = null;
        this.jobDataSource.read();
        this.componentId = 0;
        this.componentCode = '';
        this.componentDataSource.read();

        if (this.officeCode && this.officeCode != '') {
            this.clientMultiSelect.focus();
        }

    }

    onOfficeReady(e) {

        var combobox = $('#officeComboBox').data('kendoComboBox');

        combobox.focus();
    }

    setClientDataSource() {
        let me = this;
        this.clientDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Clients",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '',
                            Text = "";

                        if (me.clientMultiSelect) {

                            Text = (<any>me.clientMultiSelect.input[0]).value;

                            if (Text == 'Client') {
                                Text = "";
                            }
                        }

                        if (me.officeCode) {
                            officeCode = me.officeCode;
                        }

                        var data = {
                            OfficeCode: officeCode,
                            //SprintId: me.SprintId,
                            Text: Text
                        }

                        console.log('client datasource');
                        console.log(data);

                        return data;
                    }
                }
            }
        });
    }

    clientMultiSelect_OnChange(e) {
        let me = this;
        this.SprintId = 0;

        if (this.clientMultiSelect.value() && this.clientMultiSelect.select() == -1) {
            this.clientMultiSelect.value('');
            this.clientMultiSelect.focus();
        }
        else {
            if (!this.clientCode || this.clientCode == '') {
                this.clientMultiSelect.focus();
            }
            else {
                this.divisionMultiSelect.focus();
            }
        }

        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        (<any>this.divisionMultiSelect.input[0]).value = '';
        this.divisionDataSource.read();
        this.divisionId = '';
        (<any>this.productMultiSelect.input[0]).value = '';
        this.productDataSource.read();
        this.productId = '';
        (<any>this.jobMultiSelect.input[0]).value = '';
        this.jobDataSource.read();
        this.jobNumber = null;
        (<any>this.componentMultiSelect.input[0]).value = '';
        this.componentDataSource.read();
        this.componentId = 0;
        this.componentCode = '';


    }

    clientMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            Text = "";

        if (me.clientMultiSelect) {

            Text = (<any>me.clientMultiSelect.input[0]).value;

            if (Text == 'Client') {
                Text = "";
            }
        }

        if (me.officeCode) {
            officeCode = me.officeCode;
        }

        var data = {
            OfficeCode: officeCode,
            Text: Text,
            ClientCode: options.value[0]
        }

        $.ajax({
            url: 'Utilities/SearchClientIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    setDivisionDataSource() {
        let me = this;
        this.divisionDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Divisions",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchDivisions',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            Text = "";

                        if (me.divisionMultiSelect) {

                            Text = (<any>me.divisionMultiSelect.input[0]).value;
                            if (Text == 'Division') {
                                Text = "";
                            }
                        }

                        if (me.officeCode) {
                            officeCode = me.officeCode;
                        }
                        if (me.clientCode) {
                            clientCode = me.clientCode;
                        }

                        var data = {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            //SprintId: me.SprintId,
                            Text: Text
                        }

                        console.log('division Datasource');
                        console.log(data);

                        return data;
                    }
                }
            }
        });
    }

    divisionMultiSelect_OnChange(e) {
        let me = this;
        this.SprintId = 0;

        if (this.divisionMultiSelect.value() && this.divisionMultiSelect.select() == -1) {
            this.divisionMultiSelect.value('');
            this.divisionMultiSelect.focus();
            me.divisionId = null;
        }
        else {
            if (!this.divisionCode || this.divisionCode == '') {
                this.divisionMultiSelect.focus();
            }
            else {
                this.productMultiSelect.focus();
            }
        }

        if (!me.divisionId || me.divisionId == '') {
            me.divisionCode = '';
        }
        else {

            if (this.divisionId) {
                var codes = this.divisionId.split(',');

                me.divisionCode = codes[1];

                if (!this.clientCode || this.clientCode == '' || this.clientCode != codes[0]) {
                    this.clientCode = codes[0];
                }
            }
        }

        (<any>this.productMultiSelect.input[0]).value = '';
        this.productDataSource.read();
        this.productId = '';
        (<any>this.jobMultiSelect.input[0]).value = '';
        this.jobDataSource.read();
        this.jobNumber = null;
        (<any>this.componentMultiSelect.input[0]).value = '';
        this.componentDataSource.read();
        this.componentCode = '';
        this.componentId = 0;
    }

    divisionMapper(options) {
        let me = (<any>this).me;

        if (!me.divisionId || me.divisionId == '') {
            options.success(-1);
        }

        var officeCode = '',
            clientCode = '',
            Text = "";

        if (me.divisionMultiSelect) {

            Text = (<any>me.divisionMultiSelect.input[0]).value;

            if (Text == 'Division') {
                Text = "";
            }
        }


        if (me.officeCode) {
            officeCode = me.officeCode;
        }

        if (me.clientCode) {
            clientCode = me.clientCode;
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: options.value[0],
            //SprintID: 0,
            Text: Text
        }

        $.ajax({
            url: 'Utilities/SearchDivisionIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    setProductDataSource() {
        let me = this;
        this.productDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Products",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchProducts',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            officeCode = '',
                            Text = "";

                        if (me.productMultiSelect) {
                            Text = (<any>me.productMultiSelect.input[0]).value;

                            if (Text == 'Product') {
                                Text = "";
                            }
                        }

                        if (me.officeCode) {
                            officeCode = me.officeCode;
                        }
                        if (me.clientCode) {
                            clientCode = me.clientCode;
                        }
                        if (me.divisionId) {
                            divisionCode = me.divisionId.split(',')[1];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            //SprintId: me.SprintId,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    productMultiSelect_OnChange(e) {
        let me = this;
        this.SprintId = 0;

        this.resetJob = true;
        this.resetComponent = true;

        if (this.productMultiSelect.value() && this.productMultiSelect.select() == -1) {
            this.productMultiSelect.value('');
            this.productId = null;
            this.productMultiSelect.focus();
        }
        else {
            if (!this.productCode || this.productCode == '') {
                this.productMultiSelect.focus();
            }
            else {
                this.jobMultiSelect.focus();
            }
        }

        if (this.productId) {
            var codes = this.productId.split(',');

            me.productCode = codes[2];

            if (!this.clientCode || this.clientCode == '' || this.clientCode != codes[0]) {
                this.clientCode = codes[0];
            }

            if (!this.divisionId || this.divisionId == '' || this.divisionId != codes[0] + ',' + codes[1]) {
                this.setDivisionDataSource();
                me.divisionCode = codes[1];
                me.divisionId = codes[0] + ',' + codes[1];
            }
        }
        else {
            me.productCode = '';
            this.setProductDataSource();
        }

        (<any>this.jobMultiSelect.input[0]).value = '';
        this.jobDataSource.read();
        this.jobNumber = null;
        (<any>this.componentMultiSelect.input[0]).value = '';
        this.componentDataSource.read();
        this.componentCode = '';
        this.componentId = 0;
    }

    productMapper(options) {
        let me = (<any>this).me;
        var officeCode = '',
            clientCode = '',
            Text = "",
            divisionCode = "";

        if (me.productMultiSelect) {

            Text = (<any>me.productMultiSelect.input[0]).value;

            if (Text == 'Product') {
                Text = "";
            }
        }

        if (me.officeCode) {
            officeCode = me.officeCode;
        }

        if (me.clientCode) {
            clientCode = me.clientCode;
        }

        if (me.divisionId) {
            divisionCode = me.divisionId.split(',')[1];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductID: options.value[0],
            Text: Text
        };

        $.ajax({
            url: 'Utilities/SearchProductIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Jobs",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchJob',
                    data: function () {

                        var clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            officeCode = '',
                            AccountExecutive = '',
                            CampaignID = 0,
                            SalesClass = '',
                            JobType = '',
                            Text = "";

                        if (me.jobMultiSelect) {
                            Text = (<any>me.jobMultiSelect.input[0]).value;

                            if (Text == 'Job') {
                                Text = "";
                            }
                        }

                        if (me.officeCode) {
                            officeCode = me.officeCode;
                        }
                        if (me.clientCode) {
                            clientCode = me.clientCode;
                        }
                        if (me.divisionId) {
                            divisionCode = me.divisionId.split(',')[1];
                        }
                        if (me.productId) {
                            productCode = me.productId.split(',')[2];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            AccountExecutive: AccountExecutive,
                            ShowClosedJobs: 0,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            //SprintId: me.SprintId,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    backFillCDP() {
        let me = this;
        if (!this.clientCode || this.clientCode == '' ||
            !this.divisionId || this.divisionId == '' ||
            !this.productId || this.productId == '') {
            $.ajax({
                url: 'Utilities/SearchCDPForJob',
                type: 'GET',
                dataType: 'json',
                data: {
                    JobNumber: me.jobNumber
                },
                success: (data) => {
                    me.clientCode = data.ClientCode;
                    me.setDivisionDataSource();
                    me.divisionId = data.ClientCode + ',' + data.DivisionCode;
                    me.divisionCode = data.DivisionCode;

                    me.setProductDataSource();
                    me.productId = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                    me.productCode = data.ProductCode;
                },
                error: function (jqXHR, exception) {
                    if (jqXHR.status === 0) {
                        alert('Not connect.\n Verify Network.');
                    } else if (jqXHR.status == 404) {
                        alert('Requested page not found. [404]');
                    } else if (jqXHR.status == 500) {
                        alert('Internal Server Error [500].');
                    } else if (exception === 'parsererror') {
                        alert('Requested JSON parse failed.');
                    } else if (exception === 'timeout') {
                        alert('Time out error.');
                    } else if (exception === 'abort') {
                        alert('Ajax request aborted.');
                    } else {
                        alert('Uncaught Error.\n' + jqXHR.responseText);
                    }
                }
            });
        }
    }

    jobMultiSelect_OnChange(e) {
        let me = this;

        var dataItems = me.jobMultiSelect.dataItem();
        this.SprintId = 0;

        this.resetComponent = true;

        if (this.jobMultiSelect.value() && this.jobMultiSelect.select() == -1) {
            this.jobMultiSelect.value('');
            this.jobMultiSelect.focus();
            this.jobNumber = null;
        }


        if (!this.jobNumber || this.jobNumber == 0) {
            this.componentId = 0;
            this.componentCode = '';
        }
        else {
            this.backFillCDP();

            this.componentDataSource.read().then(function () {
                if (me.componentDataSource.total() == 1) {
                    me.componentCode = me.componentDataSource.data()[0].ID;
                    if (me.componentCode && me.componentCode.indexOf(',') > -1) {
                        me.componentId = kendo.parseInt(me.componentCode.split(',')[1]);

                        me.componentMultiSelect.focus();
                    }
                }
            });
        }
    }

    jobMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            jobNumber = '',
            AccountExecutive = '',
            CampaignID = 0,
            SalesClass = '',
            JobType = '',
            Text = "";

        if (me.jobMultiSelect) {
            Text = (<any>me.jobMultiSelect.input[0]).value;

            if (Text == 'Job') {
                Text = '';
            }
        }

        if (me.officeCode) {
            officeCode = me.officeCode;
        }
        if (me.clientCode) {
            clientCode = me.clientCode;
        }
        if (me.divisionId) {
            divisionCode = me.divisionId.split(',')[1];
        }
        if (me.productId) {
            productCode = me.productId.split(',')[2];
        }
        if (me.jobNumber) {
            jobNumber = me.jobNumber;
        }

        if (options.value[0] && !(me.jobMultiSelect.value() && me.jobMultiSelect.select() == -1)) {
            var data = {
                OfficeCode: officeCode,
                ClientCode: clientCode,
                DivisionCode: divisionCode,
                ProductCode: productCode,
                JobCode: options.value[0],
                AccountExecutive: AccountExecutive,
                CampaignID: CampaignID,
                SalesClass: SalesClass,
                JobType: JobType,
                ShowClosedJobs: me.showClosed,
                //SprintId: me.SprintId,
                Text: Text
            }

            console.log('jobMapper');
            console.log(data);

            $.ajax({
                url: 'Utilities/SearchJobIndex',
                type: 'GET',
                dataType: 'json',
                data: data,
                success: (data) => {
                    options.success(data);
                }
            }).fail(function (xhr, status, error) {
                alert('SearchJobIndex : ' + error);
            });
        }
        else {
            options.success(-1);
        }
    }

    setComponentDataSource() {
        let me = this;

        this.componentDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 31,
            schema: {
                data: "JobComponents",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchComponent',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            jobNumber = '',
                            AccountExecutive = '',
                            CampaignID = 0,
                            SalesClass = '',
                            JobType = '',
                            Text = "";

                        if (me.componentMultiSelect) {
                            Text = (<any>me.componentMultiSelect.input[0]).value;

                            if (Text == 'Component') {
                                Text = '';
                            }
                        }

                        if (me.officeCode) {
                            officeCode = me.officeCode;
                        }
                        if (me.clientCode) {
                            clientCode = me.clientCode;
                        }
                        if (me.divisionId) {
                            divisionCode = me.divisionId.split(',')[1];
                        }

                        if (me.productId) {
                            productCode = me.productId.split(',')[2];
                        }
                        if (me.jobNumber) {
                            jobNumber = me.jobNumber.toString();
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            JobCode: jobNumber,
                            AccountExecutive: AccountExecutive,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            ShowClosedJobs: 0,
                            //SprintId: me.SprintId,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    componentMultiSelect_OnChange(e) {
        let me = this;

        this.SprintId = 0;

        var dataItems = me.componentMultiSelect.dataItem();

        if (dataItems) {
            me.componentName = dataItems.Description;
        }

        if (this.componentCode && this.componentCode != '' && !(me.componentMultiSelect.value() && me.componentMultiSelect.select() == -1)) {
            var codes = this.componentCode.split(',');

            this.jobNumber = +codes[0];

            this.componentId = +codes[1];

            if (!this.clientCode || this.clientCode == '' ||
                !this.divisionId || this.divisionId == '' ||
                !this.productId || this.productId == '') {
                $.ajax({
                    url: 'Utilities/SearchCDPForJob',
                    type: 'GET',
                    dataType: 'json',
                    data: {
                        JobNumber: codes[0]
                    },
                    success: (data) => {
                        me.clientCode = data.ClientCode;
                        me.divisionDataSource.read().then(() => {
                            me.divisionId = data.ClientCode + ',' + data.DivisionCode;
                            me.divisionCode = data.DivisionCode;

                            me.productDataSource.read().then(() => {
                                me.productId = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                                me.productCode = data.ProductCode;

                                me.jobDataSource.read().then(() => {
                                    //set job code last
                                    if (!me.jobNumber || me.jobNumber == 0 || me.jobNumber != +codes[0]) {
                                        me.jobNumber = +codes[0];
                                    }
                                });
                            });
                        });
                    }
                });
            }
        }
        else {
            me.componentMultiSelect.value('');
            me.componentMultiSelect.focus();
            me.componentCode = null;
            me.componentId = 0;
        }
    }

    componentMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            jobNumber = '',
            AccountExecutive = '',
            CampaignID = 0,
            SalesClass = '',
            JobType = '',
            Text = "",
            componentID = 0;

        if (me.componentMultiSelect) {
            Text = (<any>me.componentMultiSelect.input[0]).value;

            if (Text == 'Component') {
                Text = '';
            }
        }

        if (me.officeCode) {
            officeCode = me.officeCode;
        }
        if (me.clientCode) {
            clientCode = me.clientCode;
        }
        if (me.divisionId) {
            divisionCode = me.divisionId.split(',')[1];
        }
        if (me.productId) {
            productCode = me.productId.split(',')[2];
        }
        if (me.jobNumber) {
            jobNumber = me.jobNumber;
        }

        if (options.value[0] && options.value[0] != '' && options.value[0] != null) {
            componentID = options.value[0].split(',')[1];
        }

        var data = {
            OfficeCode: officeCode
            , ClientCode: clientCode
            , DivisionCode: divisionCode
            , ProductCode: productCode
            , jobNumber: jobNumber
            , ComponentID: componentID
            , AccountExecutive: AccountExecutive
            , CampaignID: CampaignID
            , SalesClass: SalesClass
            , JobType: JobType
            , ShowClosedJobs: 0
            //, SprintId: me.SprintId
            , Text: Text
        }

        $.ajax({
            url: 'Utilities/SearchComponentIndex',
            type: 'GET',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: (data) => {
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert('SearchComponentIndex : ' + error);
        });
    }

    contactsClick() {
        var divisionCode = "";
        var productCode = "";
        var jobNumber = "";
        var componentId = ""

        if (this.componentCode && this.componentCode != "") {

            if (this.divisionId && this.divisionId != "") {
                divisionCode = this.divisionId.split(',')[1]
            }

            if (this.productId && this.productId != "") {
                productCode = this.productId.split(',')[2]
            }

            if (this.jobNumber && this.jobNumber != 0) {
                jobNumber = this.jobNumber.toString();
            }

            componentId = this.componentCode.split(',')[1]

            this.openRadWindow('Contacts', 'popContacts.aspx?from=newalert&c=' + this.clientCode + '&d=' + divisionCode + '&j=' + jobNumber + '&jc=' + this.componentId + '&p=' + productCode + '', 1200, 400);
        }

    }
}
