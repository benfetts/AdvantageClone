export namespace SettingsAgency {
        
    export class SettingAgency {

        UseAgencyBranding: boolean;
        AllowUsersToSetTheirOwnColors: boolean;
        BackgroundColor: string;
        CustomTextColor: string;
        AgencyLogo: string;
        SimpleBackgroundColor: string;
        SimpleSideBarColor: string;

        constructor() {

        }

        static fromObject(data: any) {
            let settingagency = new SettingsAgency.SettingAgency();
            Object.assign(settingagency, data);
            return settingagency;
        }

    }

    

}
