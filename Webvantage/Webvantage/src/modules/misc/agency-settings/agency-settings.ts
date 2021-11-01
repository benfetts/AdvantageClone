import { ModuleBase } from 'modules/base/module-base';
import { inject, bindable } from 'aurelia-framework';
import { Webvantage } from '../../../webvantage';
import { HttpClient } from 'aurelia-http-client';
import { UserSettingService } from 'services/utilities/user-settings-service';
import { SettingsAgency } from 'models/utilities/settings-agency';

@inject(UserSettingService)
export class AgencySettings extends ModuleBase {

    // properties
    model: any;
    @bindable showAdvancedFilters: boolean = true;

    searchInputExpanded = false; 
    service: UserSettingService;
    uploadLogoDialog: kendo.ui.Dialog;
    collapsed = true;
    settings: SettingsAgency.SettingAgency;

    @bindable background: string = '';
    @bindable textColor: string = '';
    @bindable useagencybranding: boolean = false;
    @bindable allowusertosetcolors: boolean = false;
    @bindable agencylogo: string = '';

    //search editors
    officeMultiSelect: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    attachmentUploadAgency: kendo.ui.Upload;
    backgroundColorPicker: kendo.ui.ColorPicker;
    customColorPicker: kendo.ui.ColorPicker;

    hasChanges: boolean = false;

    officeCode = [];

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
        
    }
    expandSearch() {
        this.searchInputExpanded = true;
    }
    collapseSearch() {
        this.searchInputExpanded = false;
    }
   
    //primaryColor = [
    //    '#e68497', '#4d82b8', '#edc87e', '#808080',
    //    '#76a797', '#ed9a56', '#b89a7c', '#009688',
    //    '#f2f25a', '#efc1b4', '#2a579a', '#eeacb9',
    //    '#78a1ca', '#f2d9a8', '#aeaeae', '#99c3b8',
    //    '#f5c7a1', '#d3c0ad', '#4db6ac', '#ffffcc',
    //    '#4dd0e1', '#f1c8bd', '#f7d5db', '#b2c9e0',
    //    '#f6e3bc', '#f6ddd6', '#cae0da', '#f9dec7',
    //    '#e4d9ce', '#e0f2f1', '#fcfceb', '#e0f7fa',
    //    '#f6ddd6', '#d63251', '#3a6692', '#e2a62e',
    //    '#515151', '#4b7d70', '#c96615', '#826446',
    //    '#0c6666', '#d2d20f', '#0097a7', '#caa297',
    //    '#801a2d', '#203850', '#b07d18', '#2a2a2a',
    //    '#355950', '#aa5712', '#5c4732', '#004d40',
    //    '#a0a000', '#006064', '#a5877f'

    //];

    primaryColor = [
        '#F44336', '#2196F3', '#FFEB3B', '#4CAF50',
        '#808080', '#FF9800', '#795548', '#009688',
        '#00BCD4', '#f2f25a', '#EFC1B4', '#2a579a'

    ];

    //secondaryColor = [
    //    '#00bcd4', '#e68497', '#4d82b8', '#edc87e',
    //    '#808080', '#76a797', '#ed9a56', '#b89a7c',
    //    '#009688', '#f2f25a', '#efc1b4', '#2a579a'
    //];

    secondaryColor = [
        '#F44336', '#2196F3', '#FFEB3B', '#4CAF50',
        '#808080', '#FF9800', '#795548', '#009688',
        '#00BCD4', '#f2f25a', '#EFC1B4', '#2a579a'
    ];
   
    attached() {
        this.loadSettingsAgency();
    }
    uploadLogoClick() {
        this.uploadLogoDialog.open();
    }

    saveSettingsAgency() {
        let client = new HttpClient();
        let me = this;

        //console.log("settiungs:" + me.useagencybranding);
        //console.log("settiungs:" + me.background);
        //console.log("settiungs:" + me.textColor);
        //console.log("settiungs:" + me.timezone);
        //console.log("settings: " + me.attachmentUpload.getFiles());

        //me.Upload = me.attachmentUpload.getFiles();

        //console.log("settiungs:" + me.attachmentUpload.getFiles()[0].name);

        var data = {
            UseAgencyBranding: me.useagencybranding,
            AllowUsersToSetTheirOwnColors: me.allowusertosetcolors,
            BackGroundColor: me.background,
            CustomTextColor: me.textColor
        };

        //var data2 = {
        //    File: me.attachmentUpload.getFiles()[0]
        //};


        client.post('Utilities/Settings/SaveSettingsAgency', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });

        me.hasChanges = false;

        //client.post('Utilities/Settings/UploadProfilePicture', me.attachmentUpload.getFiles())
        //.then(data2 => {
        //    console.log(data2.statusCode + ' - ' + data2.statusText);
        //});

    }

    attachmentUpload_OnSelect(e) {
        let client = new HttpClient();
        let me = this;

        //me.Upload = e.files[0];
        //console.log("select:" + e.files[0].name);

        var data2 = {
            File: e.files[0].rawfile
        };

        client.post('Utilities/Settings/UploadAgencyLogo', data2)
            .then(data2 => {
                console.log(data2.statusCode + ' - ' + data2.statusText);
            });
    }

    loadSettingsAgency() {
        let me = this;
        return this.service.loadSettingsAgency().then(response => {

            this.settings = response.content;

            console.log("settiungs:" + this.settings.AgencyLogo);

            me.useagencybranding = this.settings.UseAgencyBranding;
            me.allowusertosetcolors = this.settings.AllowUsersToSetTheirOwnColors;
            me.agencylogo = this.settings.AgencyLogo;
            //if (this.settings.BackgroundPhoto) {
            //    me.background = this.settings.BackgroundPhoto;
            //} else {
            me.background = this.settings.BackgroundColor;
            //}

            me.textColor = this.settings.CustomTextColor;
            //me.timezone[0] = this.settings.TimeZone;
           
            if (me.background != '') {
                me.backgroundColorPicker.value(this.settings.BackgroundColor);
            } else {
                me.backgroundColorPicker.value('#ffffff');
            }
            if (me.textColor != '') {
                me.customColorPicker.value(this.settings.CustomTextColor);
            } else {
                me.customColorPicker.value('#ffffff');
            }
            

        });
    }

    cancelChange() {
        let client = new HttpClient();
        let me = this;
        me.hasChanges = false;
        return this.service.loadSettingsAgency().then(response => {

            this.settings = response.content;

            //console.log("settiungs:" + this.settings.Nickname);

            me.useagencybranding = this.settings.UseAgencyBranding;
            me.allowusertosetcolors = this.settings.AllowUsersToSetTheirOwnColors;
            me.background = this.settings.BackgroundColor;
            me.textColor = this.settings.CustomTextColor;

            if (me.background != '') {
                me.backgroundColorPicker.value(this.settings.BackgroundColor);
            } else {
                me.backgroundColorPicker.value('#ffffff');
            }
            if (me.textColor != '') {
                me.customColorPicker.value(this.settings.CustomTextColor);
            } else {
                me.customColorPicker.value('#ffffff');
            }

        });

    }

    checkForChanges() {

        this.hasChanges = true;

    }

    checkForChangesBG(color) {

        this.background = color
        this.backgroundColorPicker.value(color);
        this.hasChanges = true;

    }

    checkForChangesTC(color) {

        this.textColor = color
        this.customColorPicker.value(color);
        this.hasChanges = true;

    }

    itemCheckChanged(item) {
        this.hasChanges = true;
    }

    attachmentUploadSuccess(e) {
        if (e.operation == 'upload') {
           //console.log('attachmentUploadSuccess', e);
            this.agencylogo = e.files[0].name;

        }
    }

    removeLogo() {
        let client = new HttpClient();
        let me = this;

        client.post('Utilities/Settings/RemoveAgencyLogo', '')
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);

                me.agencylogo = '';

            });

    }

    constructor(service: UserSettingService) {
        super();
        this.service = service;
    }
}
