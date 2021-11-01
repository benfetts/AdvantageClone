import { ModelBase } from 'models/base/model-base';

export class CampaignModel extends ModelBase {
    ClientCode: string;
    DivisionCode: string;
    ProductCode: string;
    Code: string;
    StartDate?: Date;
    EndDate?: Date;
    Comment: string;
    Name: string;
    IsDirectResponse?: number;
    IsMagazine?: boolean;
    IsNewspaper?: number;
    IsOutOfHome?: number;
    IsPrint?: number;
    IsRadio?: number;
    IsTelevision?: number;
    IsOther?: number;
    OtherDescription: string;
    ID: number;
    IsClosed?: number;
    IsActive?: number;
    BillingBudgetAmount?: number;
    IncomeBudgetAmount?: number;
    CampaignType: number;
    OfficeCode: string;
    AlertGroupCode: string;
    IsInternetAds?: number;
    AdNumber: string;
    MarketCode: string;
    JobNumber?: number;
    JobComponentNumber?: number;
    ClientWebsiteID?: number;
    AdServerID?: number;
    AdServerCampaignID?: number;
    AdServerCreatedBy: string;

    constructor(data) {
        super();
        Object.assign(this, data);
    }
}
