import { ServiceBase } from 'services/base/service-base';

export class SprintDashboardService extends ServiceBase {

    getDashboard(sprintID: number) {
        return this.http.get('GetDashboard', { SprintID: sprintID });
    }
    
    constructor() {
        super({ baseUrl: "ProjectManagement/Agile" });
    }

}
