import { ServiceBase } from '../../base/service-base';
import { AgencyTimesheetSettingsModel } from 'models/maintenance/agency-timesheet-settings-model';

export class AgencyTimesheetSettingService extends ServiceBase {

    getTimeSheetSettings() {
        return this.http.createRequest('GetTimeSheetSettings').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? AgencyTimesheetSettingsModel.fromObject(value) : value;
        }).send();

    }
    updateJobType(displaySettings: any) {
        return this.http.post('UpdateTimeSheetSettings', { DisplaySettings: displaySettings });
    }
    initTimeSheetSettingsMaintenance() {
        return this.http.get('InitTimeSheetSettingsMaintenance');
    }

    constructor() {
        super({ baseUrl: "Maintenance/Agency/TimesheetSettings" });

    }

}
