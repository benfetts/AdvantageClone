import { ServiceBase } from '../../base/service-base';
import { StatusModel } from 'models/maintenance/status-model';

export class StatusService extends ServiceBase {

    getStatuses() {
        return this.http.createRequest('GetStatuses').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? StatusModel.fromObject(value) : value;
        }).send();

    }
    getStatus(code: string) {
        return this.http.get('GetStatus', { Code: code });
    }
    insertStatuses(statuses: any) {
        return this.http.post('InsertStatuses', statuses);
    }
    updateStatus(status: any) {
        return this.http.post('UpdateStatuses', { Statuses: [status]});
    }
    updateStatuses(statuses: any) {
        return this.http.post('UpdateStatuses', statuses);
    }
    deleteStatuses(statuses: any) {
        return this.http.post('DeleteStatuses', statuses);
    }
    deleteStatus(status: any) {
        return this.http.post('DeleteStatuses', { Statuses: [status] });
    }
    //initStatusMaintenance() {
    //    return this.http.get('InitStatusMaintenance');
    //}

    constructor() {
        super({ baseUrl: "Maintenance/ProjectSchedule/Status" });

    }

}
