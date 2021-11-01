export namespace Settings {

    export class Tab {

        SettingModuleID: number;
        ID: number;
        Description: string;
        Settings: Array<Setting>;

        constructor() {

        }

        static fromObject(data: any) {
            let settingTab = new Settings.Tab();
            Object.assign(settingTab, data);
            return settingTab;
        }
    }

    export class Setting {

        Code: string;
        ChildCode: string;
        Description: string;
        Value: any;
        DefaultValue: any;
        MinimumValue: number;
        MaximumValue: number;
        SettingModuleID: number;
        SettingModuleTabID: number;
        SettingModuleGroupID: number;
        OrderNumber: number;
        SettingDatabaseTypeID: number;
        SettingDatabaseType: SettingDatabaseType;

        constructor() {

        }

        static fromObject(data: any) {
            let setting = new Settings.Setting();
            Object.assign(setting, data);
            return setting;
        }
    }

    export class SettingDatabaseType {

        ID: number;
        DatabaseTypeID: number;
        Precision: number;
        Scale: number;
        Column: string;

        constructor() {

        }

        static fromObject(data: any) {
            let settingDatabaseType = new Settings.SettingDatabaseType();
            Object.assign(settingDatabaseType, data);
            return settingDatabaseType;
        }
    }

    export class SettingEmployee {

        Code: string;
        Nickname: string;
        BackgroundColor: string;
        CustomTextColor: string;
        TimeZone: string;

        constructor() {

        }

        static fromObject(data: any) {
            let settingemployee = new Settings.SettingEmployee();
            Object.assign(settingemployee, data);
            return settingemployee;
        }

    }

    

}
