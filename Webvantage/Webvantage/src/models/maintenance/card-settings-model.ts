import { ModelBase } from 'models/base/model-base';

export class CardSettingsModel extends ModelBase {

    DashboardType: number;
    ShowClientName: boolean;
    ShowJobNumber: boolean;
    ShowJobComponentNumber: boolean;
    ShowJobDescription: boolean;
    ShowJobComponentDescription: boolean;
    ShowTaskComment: boolean;

}
