import { ServiceBase } from '../../base/service-base';
import { TaskModel } from 'models/maintenance/task-model';

export class TaskService extends ServiceBase {

    getTasks() {
        return this.http.createRequest('GetTasks').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? TaskModel.fromObject(value) : value;
        }).send();

        //return this.http.get('GetTasks');
    }
    getTask(code: string) {
        return this.http.get('GetTask', { Code: code });
    }
    insertTasks(tasks: any) {
        return this.http.post('InsertTasks', tasks);
    }
    updateTask(task: any) {
        return this.http.post('UpdateTasks', { Tasks: [task]});
    }
    updateTasks(tasks: any) {
        return this.http.post('UpdateTasks', tasks);
    }
    deleteTasks(tasks: any) {
        return this.http.post('DeleteTasks', tasks);
    }
    deleteTask(task: any) {
        return this.http.post('DeleteTasks', { Tasks: [task] });
    }
    getFunctionCodess() {
       //console.log('GetFunctionCodes')
        return this.http.get('GetFunctionCodes');
    }
    getRoles() {
        return this.http.get('GetRoles');
    }
    getStatusCodes() {
        return this.http.get('GetStatusCodes');
    }
    initTaskMaintenance() {
        return this.http.get('InitTaskMaintenance');
    }

    constructor() {
        super({ baseUrl: "Maintenance/ProjectSchedule/Task" });

    }

}
