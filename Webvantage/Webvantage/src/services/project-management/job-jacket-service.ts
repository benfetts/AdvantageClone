import { ServiceBase } from 'services/base/service-base';

export class JobJacketService extends ServiceBase {

    lookupOffices() {
        return this.http.get('LookupOffices', {});
    }
    lookupClients(officeCode: string, includeInactive: boolean) {
        return this.http.get('LookupClients', {OfficeCode: officeCode, IncludeInactive: includeInactive});
    }
    lookupDivisions(clientCode: string, includeInactive: boolean) {
        return this.http.get('LookupDivisions', { ClientCode: clientCode, IncludeInactive: includeInactive });
    }
    getJobs() {
        return this.http.get('GetJobs');
    }
    getOffices() {
        return this.http.get('GetOffices');
    }
    getClients() {
        return this.http.get('GetClients');
    }
    getDivisions() {
        return this.http.get('GetDivisions');
    }
    getProducts() {
        return this.http.get('GetProducts');
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
        super({ baseUrl: "ProjectManagement/JobJacket" });
    }

}
