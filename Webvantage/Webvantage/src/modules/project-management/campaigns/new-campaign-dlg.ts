import { bindable, inject, customElement } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { HttpClient } from 'aurelia-http-client';

@inject(DialogController)
export class NewCampaignDlg {
    controller: DialogController;


    officeMultiSelect: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    divisionMultiSelect: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;
    productMultiSelect: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;
    salesClassMultiSelect: kendo.ui.MultiSelect;
    salesClassDataSource: kendo.data.DataSource;
    alertGroupMultiSelect: kendo.ui.MultiSelect;
    alertGroupDataSource: kendo.data.DataSource;

    officeCode = [];
    clientCode = [];
    divisionID = [];
    productID = [];
    alertGroupCode = [];

    virtualClient;
    virtualDivision;
    virtualProduct;

    campaignCode: string = "";
    campaignName: string = "";
    campaignType: number = 2;

    clientDivisionRequired: boolean = false;

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
        this.clientCode = [];
        this.clientDataSource.read();    
        this.divisionID = [];
        this.divisionDataSource.read();
        this.productID = [];
        this.productDataSource.read();
    }


    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_nc").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.clientCode = [];
            me.clientMultiSelect.trigger('change');
        });
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

                            Text = <string>me.clientMultiSelect.input.val();
                        }

                        if (Text == 'Client') {
                            Text = "";
                        }

                        if (Text == "" && me.clientMultiSelect) {
                            var dataItems = me.clientMultiSelect.dataItems();

                            if (dataItems && dataItems.length > 0) {
                                Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                            }
                        }

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
                        return {
                            OfficeCode: officeCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    clientMultiSelect_OnChange(e) {
        let me = this;

        //this.campaignID = [];

        if (!me.clientCode || me.clientCode.length == 0 || me.clientCode[0] == '') {
            this.divisionID = [];
            this.productID = [];

            this.productDataSource.read();
            this.divisionDataSource.read();
        }
        else {
            this.divisionDataSource.read().then(function () {

                me.divisionMultiSelect.trigger('change');
            });
        }

    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_nc").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.divisionID = [];
            me.divisionMultiSelect.trigger('change');
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
                            Text = <string>me.divisionMultiSelect.input.val();
                        }

                        if (Text == 'Division') {
                            Text = "";
                        }

                        if (Text == "" && me.divisionMultiSelect) {
                            var dataItems = me.divisionMultiSelect.dataItems();

                            if (dataItems && dataItems.length > 0) {
                                Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                            }
                        }

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    divisionMultiSelect_OnChange(e) {
        let me = this;
        //this.campaignID = [];

        if (!me.divisionID || me.divisionID.length == 0 || me.divisionID[0] == '') {
            console.log('division on change forcing a product read.')
            this.productID = [];
            this.productDataSource.read();
        }
        else {

            if (this.divisionID && this.divisionID.length > 0) {
                var codes = this.divisionID[0].split(',');

                if (!this.clientCode || this.clientCode[0] == '' || this.clientCode.length == 0 || this.clientCode[0] != codes[0]) {
                    this.clientCode = [];
                    this.clientCode[0] = codes[0];
                }
            }

            this.productDataSource.read().then(function () {
                if (me.productDataSource.total() == 1) {
                }
                else {
                    me.productMultiSelect.focus();
                }

            });
        }

    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_nc").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.productID = [];
            me.productMultiSelect.trigger('change');
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
                            Text = <string>me.productMultiSelect.input.val();
                        }

                        if (Text == 'Product') {
                            Text = "";
                        }

                        if (Text == "" && me.productMultiSelect) {
                            var dataItems = me.productMultiSelect.dataItems();

                            if (dataItems && dataItems.length > 0) {
                                Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                            }
                        }

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }
                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    productMultiSelect_OnChange(e) {
        let me = this;
        //this.campaignID = [];

        if (this.productID && this.productID.length > 0) {
            var codes = this.productID[0].split(',');

            if (!this.clientCode || this.clientCode[0] == '' || this.clientCode.length == 0 || this.clientCode[0] != codes[0]) {
                this.clientCode = [];
                this.clientCode[0] = codes[0];
            }

            if (!this.divisionID || this.divisionID[0] == '' || this.divisionID.length == 0 || this.divisionID[0] != codes[0] + ',' + codes[1]) {
                this.divisionDataSource.read().then(() => {
                    me.divisionID = [];
                    me.divisionID[0] = codes[0] + ',' + codes[1];
                });
            }

            this.alertGroupMultiSelect.focus();
        }
        else {
            console.log('product on change forcing a product read.')

            this.productDataSource.read();
        }

    }

    getRequireDivisionProduct() {
        let client = new HttpClient()
        let me = this;

        client.get("Campaign/RequireDivisionProduct").then(data => {
            if (data.statusCode == 200) {
                if (data.response == 'true') {
                    me.clientDivisionRequired = true;
                }
            }
        });
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
    }

    Create() {
        let client = new HttpClient()
            .configure(x => {
                x.withHeader('Accept', 'application/json');
            });

        let me = this;

        if (!this.clientCode || this.clientCode.length <= 0) {

            alert("Client is a required field!");

            return;
        }

        if ((!me.divisionID || me.divisionID.length <= 0) && me.clientDivisionRequired) {
            alert("Division is a required field!");

            return;
        }

        if ((!me.productID || me.productID.length <= 0) && me.clientDivisionRequired) {
            alert("Product is a required field!");

            return;
        }

        if (me.campaignCode == "" || me.campaignName == "") {

            alert("Campaign Code and Campaign Name are required fields!");

            return;
        }
        console.log(me.campaignType);
        let campaign = {
            OfficeCode: "",
            ClientCode: "",
            DivisionCode: "",
            ProductCode: "",
            CampaignCode: me.campaignCode,
            CampaignDescription: me.campaignName,
            AlertGroupCode: "",
            CampaignType: me.campaignType,
            CampaignId: -1
        }

        if (this.officeCode && this.officeCode.length > 0)
            campaign.OfficeCode = this.officeCode[0];

        if (this.clientCode && this.clientCode.length > 0)
            campaign.ClientCode = this.clientCode[0];

        if (this.divisionID && this.divisionID.length > 0)
            campaign.DivisionCode = this.divisionID[0].split(',')[1];

        if (this.productID && this.productID.length > 0)
            campaign.ProductCode = this.productID[0].split(',')[2];

        if (this.alertGroupCode && this.alertGroupCode.length > 0)
            campaign.AlertGroupCode = this.alertGroupCode[0];

        client.post('Campaign/Create', campaign)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);

                var results = JSON.parse(data.response);

                if (results.success == true) {
                    campaign.CampaignId = results.campaignId;
                    me.controller.ok(campaign);
                }
                else {
                    alert(results.message);
                }
            });
    }

    attached() {
        let me = this;

        let client = new HttpClient()
            .configure(x => {
                x.withHeader('Accept', 'application/json');
            });

        client.get('Campaign/GetDefaultCampaignID')
            .then(data => {
                var results = JSON.parse(data.response);

                this.campaignCode = results;
            });


    }

    clientMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            Text = "";

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
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
        });
    }

    divisionMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            Text = "";

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: options.value[0],
            SprintID: 0,
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
        });
    }

    productMapper(options) {
        let me = (<any>this).me;
        var officeCode = '',
            clientCode = '',
            Text = "",
            divisionCode = "";

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0].split(',')[1];
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
        }).fail(function () {
            alert("error");
        });
    }

    constructor(controller: DialogController ) {
        let me = this;
        this.controller = controller;
        this.controller.settings.lock = false;
        this.controller.settings.overlayDismiss = false;

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


        this.setOfficeDataSource();
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setAlertGroupDataSource();

        this.getRequireDivisionProduct();
    
    }

}

