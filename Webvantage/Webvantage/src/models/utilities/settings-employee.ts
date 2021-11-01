export namespace SettingsEmployee {
        
    export class SettingEmployee {

        Code: string;
        Nickname: string;
        BackgroundColor: string;
        CustomTextColor: string;
        TimeZone: string;
        BackgroundPhoto;
        AgencySettings: boolean;
        ChangePassword: boolean;
        ShowDatabaseName: boolean;
        IsDarkMode: boolean;

        constructor() {

        }

        static fromObject(data: any) {
            let settingemployee = new SettingsEmployee.SettingEmployee();
            Object.assign(settingemployee, data);
            return settingemployee;
        }

    }

    

}
