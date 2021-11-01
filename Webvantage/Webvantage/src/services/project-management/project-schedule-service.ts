import { ServiceBase } from 'services/base/service-base';

export class ProjectScheduleService extends ServiceBase {

    getJobs() {
        return this.http.get('GetJobs');
    }
    searchOffices() {
        return this.http.get('SearchOffices');
    }
    searchClients() {
        return this.http.get('SearchClients');
    }
    searchDivisions() {
        return this.http.get('SearchDivisions');
    }
    searchProducts() {
        return this.http.get('SearchProducts');
    }
    getSalesClasses() {
        return this.http.get('GetSalesClasses');
    }
    getCampaigns() {
        return this.http.get('GetCampaigns');
    }
    getComponents() {
        return this.http.get('GetComponents');
    }
    getAccountExecutives() {
        return this.http.get('GetAccountExecutives');
    }

    constructor() {
        super({ baseUrl: "ProjectManagement/ProjectSchedule" });
    }

}
