import { ServiceBase } from '../../base/service-base';
import { PhaseModel } from 'models/maintenance/phase-model';

export class PhaseService extends ServiceBase {

    getPhases() {
        return this.http.createRequest('GetPhases').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? PhaseModel.fromObject(value) : value;
        }).send();

    }
    getPhase(id: number) {
        return this.http.get('GetPhase', { ID: id });
    }
    insertPhases(phases: any) {
        return this.http.post('InsertPhases', phases);
    }
    updatePhase(phase: any) {
        return this.http.post('UpdatePhases', { Phases: [phase]});
    }
    updatePhases(phases: any) {
        return this.http.post('UpdatePhases', phases);
    }
    deletePhases(phases: any) {
        return this.http.post('DeletePhases', phases);
    }
    deletePhase(phase: any) {
        return this.http.post('DeletePhases', { Phases: [phase] });
    }
    //initPhaseMaintenance() {
    //    return this.http.get('InitPhaseMaintenance');
    //}

    constructor() {
        super({ baseUrl: "Maintenance/ProjectSchedule/Phase" });

    }

}
