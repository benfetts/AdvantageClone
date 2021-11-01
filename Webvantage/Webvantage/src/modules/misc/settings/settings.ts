import { ModuleBase } from 'modules/base/module-base';
import { inject, bindable } from 'aurelia-framework';
import { Webvantage } from '../../../webvantage';
import { HttpClient } from 'aurelia-http-client';
import { UserSettingService } from 'services/utilities/user-settings-service';
import { SettingsEmployee } from 'models/utilities/settings-employee';
import { ApplicationService } from 'services/application-service';
import { Application } from 'models/common/application';
import { Else } from 'aurelia-templating-resources';

@inject(UserSettingService, ApplicationService)
export class Settings extends ModuleBase {

    // properties
    //this.addModuleForTest('Agency Settings', 'modules/misc/agency-settings/agency-settings', true);
    model: any;
    @bindable showAdvancedFilters: boolean = true;

    searchInputExpanded = false;
    uploadPictureDialog: kendo.ui.Dialog;
    uploadBackgroundDialog: kendo.ui.Dialog;
    collapsed = true;
    service: UserSettingService;
    appservice: ApplicationService;
    settings: SettingsEmployee.SettingEmployee;
    employee: Application.EmployeeInfo;

    @bindable nickname: string = '';
    @bindable background: string = '';
    @bindable backgroundphoto;
    @bindable textColor: string = '';
    @bindable timezone = [];
    @bindable emppic;
    @bindable signature;
    @bindable showEmpPicRemove: boolean = false;
    @bindable showSignaturePicRemove: boolean = false;
    @bindable AgencySettings: boolean = false;
    @bindable ChangePassword: boolean = false;
    @bindable showdbname: boolean = false;
    @bindable isDarkMode: boolean = false;
    @bindable dbDarkMode: boolean = false;
    @bindable darkModeValueChanged: boolean = false;

    Upload = [];
    empnickname: string = '';
    previewbg: string = '';    

    //search editors
    officeMultiSelect: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    attachmentUpload: kendo.ui.Upload; 
    signatureUpload: kendo.ui.Upload; 
    backgroundColorPicker: kendo.ui.ColorPicker;
    customColorPicker: kendo.ui.ColorPicker;

    hasChanges: boolean = false;

    officeCode = [];

    setOfficeDataSource() {
        let me = this;
        this.officeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchTimeZones'
                }
            }
        });
        if (this.officeMultiSelect) {
            this.officeMultiSelect.setDataSource(this.officeDataSource);
        }
        //this.officeMultiSelect.value(me.timezone);
    }
    officeMultiSelect_OnChange(e) {
        this.hasChanges = true;
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
        '#00BCD4', '#3F51B5', '#EFC1B4', '#2a579a'

    ];

    //secondaryColor = [
    //    '#00bcd4', '#e68497', '#4d82b8', '#edc87e',
    //    '#808080', '#76a797', '#ed9a56', '#b89a7c',
    //    '#009688', '#f2f25a', '#efc1b4', '#2a579a'
    //];

    secondaryColor = [
        '#F44336', '#2196F3', '#FFEB3B', '#4CAF50',
        '#808080', '#FF9800', '#795548', '#009688',
        '#00BCD4', '#3F51B5', '#EFC1B4', '#2a579a'        
    ];
   
    attached() {
        this.loadSettings();
    }
    uploadBackgroundClick() {
        this.uploadBackgroundDialog.open();
    }
    uploadPictureClick() {
        this.uploadPictureDialog.open();
    }
    readURL(input) {
        if (input.files && input.files[0]) {
            var reader = <FileReader>event.target;

            reader.onload = function (event) {
                $('#nav-feature').css('background-image', "url(" + event.target + ")");
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    cancelChange() {
        let client = new HttpClient();
        let me = this;
        me.hasChanges = false;
        return this.service.loadSettings().then(response => {

            this.settings = response.content;

            //console.log("settiungs:" + this.settings.Nickname);

            me.nickname = this.settings.Nickname;
            me.background = this.settings.BackgroundColor;
            me.textColor = this.settings.CustomTextColor;
            this.officeMultiSelect.value(this.settings.TimeZone);

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

    attachmentUpload_OnSelect(e) {
        let client = new HttpClient();
        let me = this; 
        
        //me.Upload = e.files[0];
        //console.log("select:" + e.files[0].name);

        var data2 = {
            File: e.files[0].rawfile
        };

        client.post('Utilities/Settings/UploadProfilePicture', data2)
            .then(data2 => {
                console.log(data2.statusCode + ' - ' + data2.statusText);
            });
    }

    saveSettings() {
        let client = new HttpClient();
        let me = this;  

        //console.log("settiungs:" + me.nickname);
        //console.log("settiungs:" + me.background);
        //console.log("settiungs:" + me.textColor);
        //console.log("settiungs:" + me.timezone);
        //console.log("settings: " + me.attachmentUpload.getFiles());

        //me.Upload = me.attachmentUpload.getFiles();

        //console.log("settiungs:" + me.attachmentUpload.getFiles()[0].name);

        var data = {
            Nickname: me.nickname,
            BackGroundColor: me.background,
            CustomTextColor: me.textColor,
            TimeZone: me.timezone[0],
            ShowDBName: me.showdbname,
            IsDarkMode: me.isDarkMode
        };

        //var data2 = {
        //    File: me.attachmentUpload.getFiles()[0]
        //};


        client.post('Utilities/Settings/SaveSettings', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
                if (this.darkModeValueChanged == true) {
                    parent.location.reload();
                }
            });
        
        me.hasChanges = false;

        //client.post('Utilities/Settings/UploadProfilePicture', me.attachmentUpload.getFiles())
            //.then(data2 => {
            //    console.log(data2.statusCode + ' - ' + data2.statusText);
            //});

    }

    loadSettings() {
        let me = this;  
        return this.service.loadSettings().then(response => {

            this.settings = response.content;

            //console.log("settiungs:" + this.settings.Nickname);

            me.nickname = this.settings.Nickname;
            me.empnickname = this.settings.Nickname;
            me.AgencySettings = this.settings.AgencySettings;
            me.ChangePassword = this.settings.ChangePassword;
            me.showdbname = this.settings.ShowDatabaseName;
            me.isDarkMode = this.settings.IsDarkMode;
            me.dbDarkMode = this.settings.IsDarkMode;
            //if (this.settings.BackgroundPhoto) {
            //    me.background = this.settings.BackgroundPhoto;
            //} else {
                me.background = this.settings.BackgroundColor;
            //}
            
            me.textColor = this.settings.CustomTextColor;
            //me.timezone[0] = this.settings.TimeZone;
            me.officeMultiSelect.value(this.settings.TimeZone);
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
            
            me.emppic = 'data: image / png; base64,' + this.employee.Picture;            
            me.signature = 'data: image / png; base64,' + this.employee.Signature;

            if (this.employee.Picture != null) {
                me.showEmpPicRemove = true;
            }

            if (this.employee.Signature != null) {
                me.showSignaturePicRemove = true;
            }

            /*if (me.showEmpPicRemove) {
                $("#signature .k-dropzone").append("<img src.bind = 'signature' k-value.two-way='signature'><a href='#' click.delegate = 'removeSignature()'><span class='glyphicon glyphicon-remove' ></span></a >");
            }*/
        });
    }

    attachmentUploadSuccess(e) {
        if (e.operation == 'upload') {
            console.log('attachmentUploadSuccess', e);
            return this.appservice.applicationInit().then(app => {

                this.employee = app.Employee;
                this.emppic = 'data: image / png; base64,' + this.employee.Picture;                
                this.showEmpPicRemove = true;

                $("#profilePic .k-widget.k-upload.k-header").find("ul").remove();
            });
            
        }
    }

    attachmentUploadError(e) {
        if (e.operation == 'upload') {
            console.log('attachmentUploadError', e);

            if (e.XMLHttpRequest.responseText) {
                $('<span class="k-file-name" title="' + JSON.parse(e.XMLHttpRequest.responseText) + '">' + JSON.parse(e.XMLHttpRequest.responseText) + '</span>').insertAfter($('#profilePic .k-file-size').last());
            }

            return this.appservice.applicationInit().then(app => {

                this.employee = app.Employee;
                this.showEmpPicRemove = false;

            });

        }
    }

    removeProfilePicture() {
        let client = new HttpClient();

        client.post('Utilities/Settings/RemoveProfilePicture', null)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);

                if (data.statusCode == 200) {
                    this.showEmpPicRemove = false;
                    this.emppic = 'Images/Icons/White/256/user.png';
                    $("#profilePic .k-widget.k-upload.k-header").find("ul").remove();
                    $("#profilePic .k-dropzone").find("strong").remove();
                }
            });
    }

    signatureUploadSuccess(e) {
        if (e.operation == 'upload') {
            console.log('signatureUploadSuccess', e);
            return this.appservice.applicationInit().then(app => {

                this.employee = app.Employee;
                this.signature = 'data: image / png; base64,' + this.employee.Signature;
                this.showSignaturePicRemove = true;

                $("#signature .k-widget.k-upload.k-header").find("ul").remove();
            });
        }
    }

    signatureUploadError(e) {        
        if (e.operation == 'upload') {
            console.log('signatureUploadError', e);

            if (e.XMLHttpRequest.responseText) {                
                $('<span class="k-file-name" title="' + JSON.parse(e.XMLHttpRequest.responseText) + '">' + JSON.parse(e.XMLHttpRequest.responseText) + '</span>').insertAfter($('#signature .k-file-size').last());
            }

            return this.appservice.applicationInit().then(app => {

                this.employee = app.Employee;                
                this.showSignaturePicRemove = false;
                
            });

        }
    }    

    removeSignature() {
        let client = new HttpClient();        

        client.post('Utilities/Settings/RemoveSignature', null)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);                
                
                if (data.statusCode == 200) {                    
                    this.showSignaturePicRemove = false;
                    $("#signature .k-widget.k-upload.k-header").find("ul").remove();
                    $("#signature .k-dropzone").find("strong").remove();                                       
                }
            });             
    }    

    

    /*attachmentOnUpload(e) {
        //e.data = {
        //    AlertID: this.Alert.ID,
        //    UploadToRepository: this.uploadToDocumentManager,
        //    UploadToProofHQ: this.uploadToProofHQ
        //}
    } */ 

    getAlertAttachments() {
        //console.log("getAlertAttachments")
        //return this.service.getAlertAttachments(this.Alert.ID).then(response => {
        //    this.attachments = new Array<AlertAttachmentModel>();
        //    for (var i = 0; i < response.content.length; i++) {
        //        var doc = new AlertAttachmentModel;
        //        Object.assign(doc, response.content[i]);
        //        this.attachments.push(doc);
        //    }
        //    //console.log('attachments', this.attachments);
        //});
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

    nicknameChanged(name) {

        this.nickname = name;

        if (this.empnickname != name) {
            this.empnickname = '';
            this.hasChanges = true;
        }
        
    }

    itemCheckChanged(item) {
        this.hasChanges = true;
    }
    darkModeChanged(e) {
        if (this.isDarkMode == this.dbDarkMode) {
            this.darkModeValueChanged = false;
        } else {
            this.hasChanges = true;
            this.darkModeValueChanged = true;
        }
        //this.hasChanges = true;
    }

    closecustomColorPicker() {
        //console.log('close ' + this.textColor + '/' + this.customColorPicker.value());

        if (this.textColor != this.customColorPicker.value()) {
            this.textColor = this.customColorPicker.value();
        }

    }

    closebackgroundColorPicker() {
        //console.log('close ' + this.textColor + '/' + this.customColorPicker.value());

        if (this.background != this.backgroundColorPicker.value()) {
            this.background = this.backgroundColorPicker.value();
        }

    }

    activate() {

        return this.appservice.applicationInit().then(app => {    
                        
            this.employee = app.Employee;

        });

        
    }

    OpenFileInput() {
        $('#FileInput').trigger('click');
    }

    fileSelected(e) {
        console.log(e);

        let client = new HttpClient();
        let me = this;

        console.log(e.target.files[0].name);

        var data = {
            File: e.target.files[0].rawfile
        };

        client.post('Utilities/Settings/Upload', data)
            .then(data => {
                //refresh your image here
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }

    constructor(service: UserSettingService, appservice: ApplicationService) {
        super();
        this.service = service;
        this.appservice = appservice
        this.setOfficeDataSource();        

    }
}
