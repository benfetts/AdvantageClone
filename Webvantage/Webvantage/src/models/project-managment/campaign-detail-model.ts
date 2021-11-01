import { ModelBase } from 'models/base/model-base';

export class CampaignDetailModel extends ModelBase {
    CampaignIdentifier: number;
    CampaignCode: string;
    CampaignName: string;
    Client: {
            Name: string;
            Code: string;
    };
    Division: {
            Name: string;
            Code: string;
    };
    Product: {
            Name: string;
            Code: string;
    };
    BillingBudgetAmount: number;
    BillingCombinedBudgetAmount: number;
    BillingMediaBudgetAmount: number;
    BillingProductionBudgetAmount: number;
    BillingTotalAllocatedAmount: number;
    IncomeBudgetAmount: number;
    IncomeCombinedBudgetAmount: number;
    IncomeMediaBudgetAmount: number;
    IncomeProductionBudgetAmount: number;
    IncomeTotalAllocatedAmount: number;
}
