import { ModuleBase } from 'modules/base/module-base';
import { inject } from 'aurelia-framework';
import { customElement } from 'aurelia-framework';
import { CampaignService } from 'services/project-management/campaign-service';
import { CampaignModel } from 'models/project-managment/campaign-model';
import { DialogService } from 'aurelia-dialog';
import { NewCampaignDlg } from 'modules/project-management/campaigns/new-campaign-dlg';
import { Webvantage } from '../../../webvantage';
import { Application } from 'models/common/application';

@inject(CampaignService, DialogService, 'openModule','closeModule')
export class New_Campaign {
    campaignModel: CampaignModel = null;
    campaignService: CampaignService;
    dialogService: DialogService;
    Dirty: Boolean = false;
    CampaignID: number = 68;
    openModule;
    closeModule;

    toolbar = { tools: ['transferTo', 'transferFrom'] };

    applicationMenuItem: Application.ApplicationMenuItem;

    officeDropDownList: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    clientDropDownList: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    divisionDropDownList: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;
    productDropDownList: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;
    campaignDropDownList: kendo.ui.MultiSelect;
    campaignDataSource: kendo.data.DataSource;
    alertGroupDropDownList: kendo.ui.MultiSelect;
    alertGroupDataSource: kendo.data.DataSource;
    AdNumberDropDownList: kendo.ui.MultiSelect;
    AdNumberDataSource: kendo.data.DataSource;
    MarketDropDownList: kendo.ui.MultiSelect;
    MarketDataSource: kendo.data.DataSource;
    ClientWebsiteMultiSelect: kendo.ui.MultiSelect;
    ClientWebsiteDataSource: kendo.data.DataSource;

    officeCode = [];
    clientCode = [];
    divisionCode = [];
    productCode = [];
    campaignCode = [];
    alertGroupCode = [];
    adNumber = [];
    marketCode = [];
    clientWebsiteID = [];

    datasource: kendo.data.DataSource;

    startDatePicker: kendo.ui.DatePicker;
    endDatePicker: kendo.ui.DatePicker;

    setDirty() {
        this.Dirty = true;
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
        if (this.officeDropDownList) {
            this.officeDropDownList.setDataSource(this.officeDataSource);
        }
    }

    officeDropDownList_OnChange(e) {
        this.campaignModel.ClientCode = '';
        this.campaignModel.DivisionCode = '';
        this.campaignModel.ProductCode = '';
        this.campaignModel.Code = '';
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();

        this.setDirty();
    }


    setClientDataSource() {
        let me = this;
        this.clientDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '';
                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
                        return {
                            OfficeCode: officeCode
                        }
                    }
                }
            }
        });
        if (this.clientDropDownList) {
            this.clientDropDownList.setDataSource(this.clientDataSource);
        }
    }

    clientDropDownList_OnChange(e) {
        let me = this;
        this.campaignModel.DivisionCode = '';
        this.campaignModel.ProductCode = '';
        this.campaignModel.Code = '';
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setCampaignDataSource();

        this.setDirty();
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

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
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
        if (this.divisionDropDownList) {
            this.divisionDropDownList.setDataSource(this.divisionDataSource);
        }
    }

    divisionDropDownList_OnChange(e) {
        let me = this;
        this.campaignModel.ProductCode = '';
        this.campaignModel.Code = '';
        this.setProductDataSource();
        this.setCampaignDataSource();

        this.setDirty();
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

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode
                        }
                    }
                }
            }
        });
        if (this.productDropDownList) {
            this.productDropDownList.setDataSource(this.productDataSource);
        }
    }

    productDropDownList_OnChange(e) {
        this.campaignModel.Code = '';
        this.setCampaignDataSource();

        this.setDirty();
    }

    setCampaignDataSource() {
        let me = this;

        this.campaignDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchCampaign',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = ''

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionCode && me.divisionCode.length > 0) {
                            divisionCode = me.divisionCode[0];
                        }
                        if (me.productCode && me.productCode.length > 0) {
                            productCode = me.productCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            InclClosed: 0
                        }

                    }
                }
            }
        });
        if (this.campaignDropDownList) {
            this.campaignDropDownList.setDataSource(this.campaignDataSource);
        }
    }

    campaignDropDownList_OnChange(e) {
        this.setDirty();
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
        if (this.alertGroupDropDownList) {
            this.alertGroupDropDownList.setDataSource(this.alertGroupDataSource);
        }
    }

    alertGroupDropDownList_OnChange(e) {
        this.setDirty();
    }

    setAdNumberDataSource() {
        let me = this;

        this.AdNumberDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchAdNumber',
                    data: function () {

                        return {
                            ClientCode: me.campaignModel.ClientCode
                        }
                    }
                }
            }
        });
        if (this.AdNumberDropDownList) {
            this.AdNumberDropDownList.setDataSource(this.AdNumberDataSource);
        }
    }

    adNumberDropDownList_OnChange(e) {
        this.setDirty();
    }

    setMarketDataSource() {
        let me = this;

        this.MarketDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchMarket'
                }
            }
        });
        if (this.MarketDropDownList) {
            this.MarketDropDownList.setDataSource(this.MarketDataSource);
        }
    }

    marketDropDownList_OnChange(e) {
        this.setDirty();
    }

    setClientWebsiteDataSource() {
        let me = this;

        this.ClientWebsiteDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchClientWebsite',
                    data: function () {

                        return {
                            ClientCode: me.campaignModel.ClientCode
                        }
                    }
                }
            }
        });
        if (this.ClientWebsiteMultiSelect) {
            this.ClientWebsiteMultiSelect.setDataSource(this.ClientWebsiteDataSource);
        }
    }

    clientWebsiteMultiSelect_OnChange(e) {
        this.setDirty();
    }

    newCampaign() {
        let me = this;
        this.dialogService.open({ viewModel: NewCampaignDlg, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                me.openModule('Campaign ' + response.output.CampaignId + ' - ' + response.output.CampaignDescription,
                    "modules/project-management/campaigns/new-campaign?cid=" + response.output.CampaignId + "&cmp=" + response.output.CampaignCode);
            }
        });
    }

    save() {

        let me = this;

        if (me.officeCode && me.officeCode.length > 0) {
            me.campaignModel.OfficeCode = me.officeCode[0];
        }
        else {
            me.campaignModel.OfficeCode = "";
        }
        if (me.clientCode && me.clientCode.length > 0) {
            me.campaignModel.ClientCode = me.clientCode[0];
        }
        else {
            me.campaignModel.ClientCode = "";
        }
        if (me.divisionCode && me.divisionCode.length > 0) {
            me.campaignModel.DivisionCode = me.divisionCode[0];
        }
        else {
            me.campaignModel.DivisionCode = "";
        }
        if (me.productCode && me.productCode.length > 0) {
            me.campaignModel.ProductCode = me.productCode[0];
        }
        else {
            me.campaignModel.ProductCode = "";
        }
        if (me.campaignCode && me.campaignCode.length > 0) {
            me.campaignModel.Code = me.campaignCode[0];
        }
        else {
            me.campaignModel.Code = "";
        }
        if (me.adNumber && me.adNumber.length > 0) {
            me.campaignModel.AdNumber = me.adNumber[0];
        }
        else {
            me.campaignModel.Code = "";
        }
        if (me.marketCode && me.marketCode.length > 0) {
            me.campaignModel.MarketCode = me.marketCode[0];
        }
        else {
            me.campaignModel.MarketCode = "";
        }

        if (me.alertGroupCode && me.alertGroupCode.length > 0) {
            me.campaignModel.AlertGroupCode = me.alertGroupCode[0];
        }
        else {
            me.campaignModel.AlertGroupCode = "";
        }


        this.campaignService.updateCampaign(this.campaignModel).then(data => {
            console.log(data);
            this.Dirty = false;
        });

    }

    load() {
        let me = this;
        this.campaignService.getCampaign(this.CampaignID).then(data => {

            for (var property in data.content) {
                if (data.content.hasOwnProperty(property)) {
                    if (typeof data.content[property] == 'object') {
                        data.content[property] = null;
                    }
                }
            }

            me.campaignModel = data.content;

            me.officeCode = [];
            me.officeCode[0] = me.campaignModel.OfficeCode;
            me.clientCode = [];
            me.clientCode[0] = me.campaignModel.ClientCode;
            me.divisionCode = [];
            me.divisionCode[0] = me.campaignModel.DivisionCode;
            me.productCode = [];
            me.productCode[0] = me.campaignModel.ProductCode;
            me.campaignCode = [];
            me.campaignCode[0] = me.campaignModel.Code;
            me.adNumber = [];
            me.adNumber[0] = me.campaignModel.AdNumber;
            me.marketCode = [];
            me.marketCode[0] = me.campaignModel.MarketCode;
            me.alertGroupCode = [];
            me.alertGroupCode[0] = me.campaignModel.AlertGroupCode;
        })

        this.setGridDatasource();
        this.Dirty = false;
    }

    alerts() {
        let me = this;

        me.openModule('', 'Alert_List.aspx?lstlvl=7&cid=' + this.CampaignID);
    }

    Upload() {
        let me = this;
        me.openModule("Upload a new document", "Documents_Upload.aspx??caller=&Level=CM&FK=" + me.CampaignID + "&Value=" + me.campaignModel.Code, 550, 575)
    }

    ViewDocuments() {
        let me = this;

        me.openModule("View documents", "Documents_List.aspx?DocPopupType=campaign&cmp=" + me.CampaignID);
    }

    NewAlert(assn) {
        let me = this;
        var Title: string = "Campaign Alert";

        if (assn == 1) {
            Title = "Campaign Assignment"
        }

        me.openModule(Title, "Alert_New.aspx?assn=" + assn +"&caller=campaign&f=5&cmp=" + me.CampaignID);
    }

    Delete() {

        if (confirm('Are you sure you want to delete?')) {

            this.campaignService.deleteCampaign(this.campaignModel.ID).then(data => {
                if (data.content.success == false) {
                    alert(data.content.message);
                }
                else {
                    this.closeModule(this.applicationMenuItem);
                }
            });
        }
    }

    SendEmail() {
        this.openModule("Send Email", "Alert_New.aspx?eml=1&send=1&cmp=" + this.CampaignID + "&pagetype=cmp&f=13");
    }

    setGridDatasource() {
        let me = this;
        this.datasource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Campaign/GetAllAttachedMedia',
                    data: function () {

                        return {
                            CmpID: me.CampaignID
                        }
                    }
                }
            },
            schema: {
                model: {
                    fields: {
                        SORT: { type: "number" },
                        TYPE: { type: "string" },
                        ORDER_NBR: { type: "string" },
                        ORDER_DESC: { type: "string" },
                        VN_CODE: { type: "string" },
                        VN_NAME: { type: "string" },
                        SC_CODE: { type: "string" },
                        SC_DESCRIPTION: { type: "string" },
                        ORDER_DATE: { type: "date" },
                        GROUP_DESC: { type: "string" },
                        SORT_ORDER: { type: "number" },
                    }
                }
            },
            pageSize: 10,
            group: [{
                field: "GROUP_DESC"
            }]
        });
    }

    constructor(campaignService: CampaignService, dialogService: DialogService, openModule, closeModule) {
        this.campaignService = campaignService;
        this.dialogService = dialogService;
        this.openModule = openModule;
        this.closeModule = closeModule;

        this.setOfficeDataSource();
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setCampaignDataSource();
        this.setAlertGroupDataSource();
        this.setAdNumberDataSource();
        this.setMarketDataSource();
        this.setClientWebsiteDataSource();
    }

    activate(argument: Application.ApplicationMenuItem) {

        this.applicationMenuItem = argument;

        this.CampaignID = this.applicationMenuItem.Parameters['cid'];
        console.log(argument);

        this.load()
    }

    attached() {
    }

}
