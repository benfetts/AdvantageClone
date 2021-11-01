export class DepartmentTeamModel {

    Code: string;
    Description: string;
    IsInactive: boolean;
    DirectHoursPercentGoal: number;
    Category: string;
    PurchaseOrderApprovalRuleCode: string;
    ServiceFeeTypeCode: string;

    constructor() {
        
    }

    static fromObject(data: any) {
        let DepartmentTeam = new DepartmentTeamModel();
        Object.assign(DepartmentTeam, data);
        return DepartmentTeam;
    }


}
