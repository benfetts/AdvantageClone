import { ServiceBase } from 'services/base/service-base';

export class AgileService extends ServiceBase {

    constructor() {
        super({ baseUrl: "ProjectManagement/Agile" });
    }

    initNewWorkItemTime(alertID: number) {
        return this.http.get('InitNewWorkItemTime?AlertID=' + alertID);
    }

    saveHoursToAlert(alertID: number, entryDate: Date, functionCode: string, hours: number, comment: string) {
        //console.log("saveHoursToAlert", entryDate.toISOString())
        var data = {
            AlertID: alertID,
            EntryDate: entryDate,
            FunctionCode: functionCode,
            Hours: hours * 1,
            Comment: comment
        };
        return this.http.post('SaveHoursToAlert', data);
    }
    addJobToBoard(boardID: number, jobNumber: number, jobComponentNumber: number) {
        var data = {
            BoardID: boardID,
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber
        };
        return this.http.post('AddJobToBoard', data);
    }
    addJobsToBoard(boardID: number, jobs: Array<any>) {
        var data = {
            BoardID: boardID,
            Jobs: jobs
        };
        return this.http.post('AddJobsToBoard', data);
    }
    checkIfPostPeriodIsAvailable(entryDate: Date) {
        //console.log("checkIfPostPeriodIsAvailable", entryDate.toISOString())
        var data = {
            EntryDate: entryDate.toISOString()
        };
        return this.http.get('CheckIfPostPeriodIsAvailable', data);
    }
    initSelectBoardJobs(boardId: number, excludeJobsOnBoard: boolean) {
        return this.http.get('InitSelectBoardJobs', { BoardID: boardId, ExcludeJobsOnBoard: excludeJobsOnBoard } );
    }

}
