import { ServiceBase } from 'services/base/service-base';
import { Settings } from 'models/utilities/settings';

export class UserSettingService extends ServiceBase {

    getPageSize(gridname: string) {
        return this.http.get('GetPageSize', { Gridname: gridname });
    }

    updatePageSize(pagesize: number, gridname: string) {
        return this.http.post('UpdatePageSize', { PageSize: pagesize, Gridname: gridname });
    }

    saveSettings(nickname: string, backgroundcolor: string, customtextcolor: string, timezone: string) {
        return this.http.get('SaveSettings', { Nickname: nickname, Backgroundcolor: backgroundcolor, Customtextcolor: customtextcolor, Timezone: timezone});
    }

    loadSettings() {
        return this.http.get('LoadSettings');
    }

    saveSettingsAgency(useagencybranding: boolean, allowuserstosettheirowncolors: boolean, backgroundcolor: string, customtextcolor: string) {
        return this.http.get('SaveAgencySettings', { UseAgencyBranding: useagencybranding, AllowUsersToSetTheirOwnColors: allowuserstosettheirowncolors, Backgroundcolor: backgroundcolor, Customtextcolor: customtextcolor });
    }

    loadSettingsAgency() {
        return this.http.get('LoadAgencySettings');
    }

    isClientPortal() {
        return this.http.get('isClientPortal');
    }
       
    getIsEmployeeVendor(employeeCode: string) {
        return this.http.get('GetIsEmployeeVendor', { EmployeeCode: employeeCode });
    }

    constructor() {
        super({ baseUrl: "Utilities/Settings" });
    }

}
