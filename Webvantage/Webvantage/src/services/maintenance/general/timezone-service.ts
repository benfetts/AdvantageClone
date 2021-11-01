import { ServiceBase } from '../../base/service-base';

export class TimezoneService extends ServiceBase {

    /*
    getDepartmentTeams() {
        return this.http.get('GetDepartmentTeams');
    }
    updateDepartmentTeams(departments: any) {
        return this.http.post('UpdateDepartmentTeams', departments);
    }
    getPurchaseOrderApprovalRules() {
       //console.log('GetPurchaseOrderApprovalRules')
        return this.http.get('GetPurchaseOrderApprovalRules');
    }
    getServiceFeeTypes() {
        return this.http.get('GetServiceFeeTypes');
    }
    */
    constructor() {
        super({ baseUrl: "Maintenance/General/Timezone" });
    }

}
