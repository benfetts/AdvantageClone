import { ServiceBase } from '../../base/service-base';
import { JobTypeModel } from 'models/maintenance/jobtype-model';

export class JobTypeService extends ServiceBase {

    getJobTypes() {
        return this.http.createRequest('GetJobTypes').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? JobTypeModel.fromObject(value) : value;
        }).send();

    }
    getJobType(code: string) {
        return this.http.get('GetJobType', { Code: code });
    }
    insertJobTypes(jobTypes: any) {
        return this.http.post('InsertJobTypes', jobTypes);
    }
    updateJobType(jobType: any) {
        return this.http.post('UpdateJobTypes', { JobTypes: [jobType]});
    }
    updateJobTypes(jobTypes: any) {
        return this.http.post('UpdateJobTypes', jobTypes);
    }
    deleteJobTypes(jobTypes: any) {
        return this.http.post('DeleteJobTypes', jobTypes);
    }
    deleteJobType(jobType: any) {
        return this.http.post('DeleteJobTypes', { JobTypes: [jobType] });
    }
    initJobTypeMaintenance() {
        return this.http.get('InitJobTypeMaintenance');
    }

    constructor() {
        super({ baseUrl: "Maintenance/ProjectManagement/JobType" });

    }

}
