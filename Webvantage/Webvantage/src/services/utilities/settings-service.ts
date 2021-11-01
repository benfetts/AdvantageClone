import { ServiceBase } from 'services/base/service-base';
import { Settings } from 'models/utilities/settings';

export class SettingsService extends ServiceBase {

    getSettings() {
        return this.http.get('GetSettings')
            .then(response => {
                var settings: Array<Settings.Tab> = new Array<Settings.Tab>();
                var settingTab: Settings.Tab;

                if (response.content.length > 0) {

                    for (var i = 0; i < response.content.length; i++) {

                        settingTab = new Settings.Tab;

                        Object.assign(settingTab, response.content[i]);
                        settings.push(settingTab);

                    }
                }

                return settings;
            });
    }
    getSettingByCode(code: string) {
        return this.http.get('GetSettingByCode', { Code: code });
    }
    getSettingValueListByCode(code: string) {
        return this.http.get('GetSettingValueListByCode', { Code: code });
    }
    getEmployees() {
        return this.http.get('GetEmployees');
    }
    updateSetting(setting: any) {
        return this.http.post('UpdateSetting', { Setting: setting });
    }
    loadDefaults(settingModuleID: number) {
        return this.http.post('loadDefaults', { SettingModuleID: settingModuleID });
    }
    getQuickbooksURL() {
        return this.http.get('GetQuickbooksURL');
    }
    constructor(settingModuleID: number) {

        var base = 'Utilities/Settings';

        switch (settingModuleID) {
            case 0:
                base = 'Maintenance/ProjectSchedule/Setting';
                break;
            case 2:
                base = 'Maintenance/ProjectManagement/ProductionSettings';
                break;
            case 7:
                base = 'Maintenance/General/IntegrationSetting';
                break;
            case 10:
                base = 'Maintenance/General/PasswordSettings';
                break;
        }

        super({ baseUrl: base });

    }
}
