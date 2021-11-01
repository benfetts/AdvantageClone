import { ServiceBase } from '../../base/service-base';
import { DepartmentTeamModel } from 'models/maintenance/department-team-model';

export class DepartmentTeamService extends ServiceBase {

    getDepartmentTeams() {
        return this.http.createRequest('GetDepartmentTeams').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }             
            return typeof value === 'object' ? DepartmentTeamModel.fromObject(value) : value;
        }).send();
    }
    updateDepartmentTeams(departments: Array<DepartmentTeamModel>) {
        // advanced
        return this.http.createRequest('UpdateDepartmentTeams').asPost().withContent(departments).send();
        // basic
        //return this.http.post('UpdateDepartmentTeams', departments);
    }
    updateDepartmentTeam(department: DepartmentTeamModel) {
        return this.updateDepartmentTeams([department]);
    }
    getPurchaseOrderApprovalRules() {
        return this.http.get('GetPurchaseOrderApprovalRules');
    }
    getServiceFeeTypes() {
        return this.http.get('GetServiceFeeTypes');
    }

    constructor() {
        super({ baseUrl: "Maintenance/Accounting/DepartmentTeam" });
        
    }

}
