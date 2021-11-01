import { ModuleBase } from 'modules/base/module-base';
import { SettingsService } from 'services/utilities/settings-service';
import { bindable } from 'aurelia-framework';
import { Settings } from 'models/utilities/settings';

export class SettingsPage extends ModuleBase {

    // properties
    settingModuleID: number;
    service: SettingsService;
    settings: Array<Settings.Tab>;
    settingParent: any;
    alertAssignmentStates: kendo.data.DataSource;
    employees: kendo.data.DataSource;

    quickbooksURL: string;

    // methods
    getSettings() {
        //console.log("settings-page: getSettings", this.settingModuleID);
        return this.service.getSettings().then(response => {
            this.settings = response;
        });
    }

    getEmployees(code) {
        this.service.getEmployees().then(response => {
            this.settingParent = response;
        });
    }

    getSettingDataSource(code) {
        var dataSource = new kendo.data.DataSource();
        this.service.getSettingByCode(code).then(response => {
            dataSource.add(response);
            return dataSource;
        });
    }

    saveSetting(setting) {
        this.service.updateSetting(setting);
       //console.log("Code:" + setting.Code + "Value: " + setting.Value);
    }

    saveSettingsFilterData(setting) {
        this.service.updateSetting(setting);
        var filter = { field: 'ParentID', operator: 'eq', value: setting.Value };
        $('#' + setting.ChildCode).data('kendoDropDownList').value(null);
        $('#' + setting.ChildCode).data("kendoDropDownList").dataSource.filter(filter);
    }

    loadDefaults() {
        this.confirm('Are you sure you want to load defaults?  If you do, all current values will be discarded.').then(() => {
            this.service.loadDefaults(this.settingModuleID);
            this.getSettings()
        }, () => {            
            //this.alert('Delete cancelled');
        });       
       //console.log("Code:" + this.settingModuleID);
    }

    getQuickbooksURL() {
        //this.quickbooksURL = this.service.getQuickbooksURL();
        this.service.getQuickbooksURL().then(response => {
            this.quickbooksURL = response.content;
        });
    }

    checkedChanged(setting) {
        //save the setting
        if (setting.SettingModuleID == 7 && setting.Code == 'QB_ENABLED') {

            //do not save
            
        } else {

            this.saveSetting(setting);

        }
        
        if (setting.SettingModuleID == 7 && setting.Code == 'DC_ENABLED') {
            if (setting.Value == true) {
                this.openRadWindow("", "Google_Authentication.aspx?ServiceType=DoubleClick&ServiceLevel=Agency");
            } else {
                $.post({
                    url: 'Settings/DeauthorizeDoubleClick'
                })
            }
        } else if (setting.SettingModuleID == 7 && setting.Code == 'QB_ENABLED') {
            if (setting.Value == true) {
                window.open(this.quickbooksURL);
            } else {
                $.post({
                    url: 'Settings/DeauthorizeQuickbooks'
                })
            }
        }
    }

    activate(params: any) {
        this.settingModuleID = Number(params.SettingModule);
        this.service = new SettingsService(this.settingModuleID);
        //console.log("settings?", this.settingModuleID);
        this.getSettings().then(() => {
            for (var i = 0; i < this.settings.length; i++) {
                for (var ii = 0; ii < this.settings[i].Settings.length; ii++) {
                    if (this.settings[i].Settings[ii].ChildCode) {
                        var setting = this.settings[i].Settings[ii];
                        var filter = { field: 'ParentID', operator: 'eq', value: setting.Value };
                        $('#' + setting.ChildCode).data("kendoDropDownList").dataSource.filter(filter);
                    }
                }
            }
        });
        this.getQuickbooksURL();
    } 

    attached() {
        let me = this;
    }
    constructor() {
        super();
    }
}
