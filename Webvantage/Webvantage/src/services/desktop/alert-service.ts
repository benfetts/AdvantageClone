import { ServiceBase } from 'services/base/service-base';
import { AlertModel } from 'models/desktop/alert-model';
import { AlertAttachmentModel } from 'models/desktop/alert-attachment-model';
import { JobComponent } from 'models/common/job-component';

export class AlertService extends ServiceBase {

    priorityLevels: Array<any>;

    getFeedbackSummary(alertID: number) {
        return this.http.get("GetFeedbackSummary", { AlertID: alertID });
    }
    canDeleteDocument(alertID: number, documentID: number) {
        return this.http.get("CanDeleteDocument", { AlertID: alertID, DocumentID: documentID });
    }
    canCompleteProof(alertID: number) {
        return this.http.get("CanCompleteProof", { AlertID: alertID });
    }
    checkForStateChange(alertID: number, alertStateID: number) {
        return this.http.get("CheckForStateChange", { AlertID: alertID, AlertStateID: alertStateID });
    }
    getLatestDocumentID(alertID: number) {
        return this.http.get("GetLatestDocumentID", { AlertID: alertID });
    }
    emailExternalReviewers(alertID: number, proofingExternalReviewerID: number) {
        return this.http.post("EmailExternalReviewers", { AlertID: alertID, ProofingExternalReviewerID: proofingExternalReviewerID });
    }
    saveExternalReviewer(alertID: number, reviewerName: string, reviewerEmail: string) {
        return this.http.post("SaveExternalReviewer", {AlertID: alertID, Name: reviewerName, Email: reviewerEmail});
    }
    getAssignmentTemplate(alertTemplateID: number) {
        if (alertTemplateID) {
            return this.http.get("GetAssignmentTemplate", { AlertTemplateID: alertTemplateID });
        } else {
            return null;
        }
    }
    //canCompleteProof(alertID: number) {
    //    if (alertID) {
    //        return this.http.get("CanCompleteProof", { AlertID: alertID });
    //    } else {
    //        return null;
    //    }
    //}
    tempUploadURL(alertId: number, title: string, Url: string, uploadDocumentManager: boolean) {
        return this.http.post('tempUploadURL', { AlertID: alertId, Title: title, URL: Url, UploadDocumentManager: uploadDocumentManager });
    }
    uploadURL(alertId: number, title: string, Url: string, uploadDocumentManager: boolean) {
        return this.http.post('UploadURL', { AlertID: alertId, Title: title, URL: Url, UploadDocumentManager: uploadDocumentManager });
    }
    saveAssignmentWithDateWorkaround(alert: AlertModel, startDate: string, dueDate: string, completedDate: string, notify: boolean) {
        if (alert) {
            return this.http.post('SaveAssignmentWithDateWorkaround', { Alert: alert.toJSON(), StartDate: startDate, DueDate: dueDate, CompletedDate: completedDate, Notify: notify });
        }
    }
    saveAssignment(alert: AlertModel, notify: boolean) {
        if (alert) {
            return this.http.post('SaveAssignment', { Alert: alert.toJSON(), Notify: notify });
        }
    }
    sendAssignmentWithDateWorkaround(alert: AlertModel, startDate: string, dueDate: string, completedDate: string, addUpdatedComment: boolean) {
        if (alert) {
            return this.http.post('SendAssignmentWithDateWorkaround', { Alert: alert, StartDate: startDate, DueDate: dueDate, CompletedDate: completedDate, AddUpdatedComment: addUpdatedComment });
        }
    }
    sendAssignment(alert: AlertModel, addUpdatedComment: boolean) {
        if (alert) {
            return this.http.post('SendAssignment', { Alert: alert, AddUpdatedComment: addUpdatedComment });
        }
    }

    getDefaultEmailGroup(jobNumber: number, jobComponentNumber: number) {
        if ((jobNumber && jobNumber > 0) && (jobComponentNumber && jobComponentNumber > 0)) {
            return this.http.get('GetDefaultEmailGroup', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
        } else {
            return null;
        }
    }
    zeroOutEmployeeHours(alertID: number, employeeCode: string) {
        return this.http.post('ZeroOutEmployeeHours', { AlertID: alertID, EmployeeCode: employeeCode });
    }
    updateRecipientHours(alertID: number, hoursAllowed: number,jobHours: number) {
        return this.http.post('UpdateRecipientHours', {
            AlertID: alertID,
            HoursAllowed: hoursAllowed,
            JobHours: jobHours
        });
    }
    getEmailGroupByAlertID(alertID: number) {
        if (alertID) {
            return this.http.get('GetEmailGroupByAlertID', { AlertID: alertID });
        } else {
            return null;
        }
    }
    getNewAssignmentJobList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentJobList', options);
    }
    getNewAssignmentOfficeList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentOfficeList', options);
    }
    getNewAssignmentClientList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentClientList', options);
    }
    getNewAssignmentDivisionList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentDivisionList', options);
    }
    getNewAssignmentProductList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentProductList', options);
    }
    getNewAssignmentComponentList(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetNewAssignmentComponentList', options);
    }
    getNewAssignmentInfoFromJob(jobNumber: number) {
        return this.http.get('GetNewAssignmentInfoFromJob', { JobNumber: jobNumber });
    }
    getNewAssignmentInfoFromJobComponent(jobNumber: number, jobComponentNumber: number) {
        return this.http.get('GetNewAssignmentInfoFromJobComponent', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
    }
    getProofingURL(alertID: number, documentID: number) {
        if (alertID) {
            return this.http.get('GetProofingURL', { AlertID: alertID, DocumentID: documentID });
        } else {
            return null;
        }
    }
    getConceptShareProofingURL(alertID: number) {
        if (alertID) {
            return this.http.get('GetConceptShareProofingURL', { AlertID: alertID });
        } else {
            return null;
        }
    }
    getReviewThumbnailString(alertID: number) {
        //console.log("alert-service.ts:GetReviewThumbnailString", alertID);
        //if (alertID) {
        //    return this.http.get('GetReviewThumbnailString', { AlertID: alertID });
        //} else {
            return null;
        //}
    }
    getReviewThumbnail(alertID: number) {
        //console.log("alert-service.ts:getReviewThumbnail", alertID);
        if (alertID) {
            return this.http.get('GetReviewThumbnail', { AlertID: alertID });
        } else {
            return null;
        }
    }
    initNewAssignment(callingPage: string) {
        return this.http.get('InitNewAssignment', {CallingPage: callingPage}).then(response => {
            var newAssignmentSetup: any = {
                RepositoryLimitText: '',
                AllowUpload: true,
                DefaultSubject: '',
                DefaultAssignment: false,
                AllowProofHQ: false
            };
            try {
                if (response && response.content) {
                    newAssignmentSetup.RepositoryLimitText = response.content.RepositoryLimitText;
                    newAssignmentSetup.AllowUpload = response.content.AllowUpload;
                    newAssignmentSetup.DefaultSubject = response.content.DefaultSubject;
                    newAssignmentSetup.DefaultAssignment = response.content.DefaultAssignment;
                    newAssignmentSetup.AllowProofHQ = response.content.AllowProofHQ;
                }
            } catch (e) {
                //console.log("ERROR alert-service.ts initNewAssignment", e);
            }
            return newAssignmentSetup;
        });
    }
    getSprintSetup(sprintID: number) {
        if (sprintID) {
            return this.http.get('GetSprintSetup', { SprintID: sprintID }).then(response => {
                var sprintSetup: any = {
                    ExcludeTasks: false,
                    RepositoryLimitText: '',
                    AllowUpload: true,
                    DefaultAssignment: false  
                };
                sprintSetup.ExcludeTasks = response.content.ExcludeTasks;
                sprintSetup.RepositoryLimitText = response.content.RepositoryLimitText;
                sprintSetup.AllowUpload = response.content.AllowUpload;
                sprintSetup.DefaultAssignment = response.content.DefaultAssignment;
                return sprintSetup;
            });
        }
    }
    calculateScheduleDates(alert: AlertModel) {
        if (alert) {
            return this.http.post('CalculateScheduleDates', { Alert: alert.toJSON() });
        }
    }
    getScheduleTasks(jobNumber: number, jobComponentNumber: number) {
        if (jobNumber && jobComponentNumber) {
            return this.http.get('GetScheduleTasks', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
        }
    }
    getJobComponents() {
        return this.http.get('GetSprintJobComponents', { SprintID: 0 }).then(response => {
            var jobComponents: Array<JobComponent> = new Array<JobComponent>();
            var jobComponent: JobComponent;
            if (response.content.length > 0) {
                for (var i = 0; i < response.content.length; i++) {
                    jobComponent = new JobComponent;
                    Object.assign(jobComponent, response.content[i]);
                    jobComponents.push(jobComponent);
                }
            }
            return jobComponents;
        });
    }
    initKendoDataSource(readUrl: string, options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        if (!options) {
            options = {
                transport: {
                    read: {
                        url: ''
                    }
                }
            };
        }
        if (!options.transport.read['url'] || options.transport.read['url'] == '') {
            options.transport.read['url'] = this.baseUrl + '/' + readUrl;
        }
        return new kendo.data.DataSource(options);
    }
    getNotifications() {
        return this.http.get('GetNotifications');
    }
    getLimitedNotifications() {
        return this.http.get('GetLimitedNotifications');
    }
    alertNotificationMarkAllAsRead() {
        return this.http.get('AlertNotificationMarkAllAsRead');
    }
    alertNotificationDismissAllAlerts() {
        return this.http.get('AlertNotificationDismissAllAlerts');
    }
    getNotificationCount() {
        return this.http.get('GetNotificationCount');
    }
    getDefaultSubjectType() {
        return this.http.get('GetDefaultSubjectType');
    }
    getAlertView(alertID: number, sprintID: number) {
        if (alertID) {
            if (!sprintID || sprintID == undefined || sprintID == null) {
                sprintID = 0;
            } 
            return this.http.get('GetAlertView', { AlertID: alertID, SprintID: sprintID });
        }
    }
    getTaskDescription(jobNumber: number, jobComponentNumber: number, taskSequenceNumber: number) {
        if (jobNumber && jobComponentNumber && taskSequenceNumber >= 0) {
            return this.http.get('GetTaskDescription', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber, TaskSequenceNumber: taskSequenceNumber });
        }
    }
    isMyAssignment(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('IsMyAssignment', { AlertID: alertID });
        }
    }
    getAlertHours(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetAlertHours', { AlertID: alertID });
        }
    }
    getAlertBody(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetAlertBody', { AlertID: alertID });
        }
    }
    getAlertRecipients(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetAlertRecipients', { AlertID: alertID });
        }
    }
    getCurrentProofersList(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetCurrentProofersList', { AlertID: alertID });
        }
    }
    getExternalReviewersList(alertID: number, showAllType: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetExternalReviewersList', { AlertID: alertID, ShowAllType: showAllType });
        }
    }
    addExternalReviewerToAssignment(alertID: number, proofingExternalReviewerID: number) {
        return this.http.post('AddExternalReviewerToAssignment', { AlertID: alertID, ProofingExternalReviewerID: proofingExternalReviewerID });
    }
    canRemoveExternalReviewerFromAssignment(alertID: number, proofingExternalReviewerID: number) {
        return this.http.get('CanRemoveExternalReviewerFromAssignment', { AlertID: alertID, ProofingExternalReviewerID: proofingExternalReviewerID });
    }
    removeExternalReviewerFromAssignment(alertID: number, proofingExternalReviewerID: number) {
        return this.http.post('RemoveExternalReviewerFromAssignment', { AlertID: alertID, ProofingExternalReviewerID: proofingExternalReviewerID });
    }
    getAlertAttachments(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('GetAlertAttachments', { AlertID: alertID });
        }
    }
    getAlertCategoriesDataSource(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetAlertCategories', options);
    }
    getAlertTemplatesDataSource(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetAlertTemplates', options);
    }
    //getAlertTemplateDataSourceWithCurrentAssignee(assignedEmployeeCode: string, assignedEmployeeName: string, alertTemplateID: number, alertStateID: number, alertID: number) {
    //    return this.http.get('GetAlertTemplateStateEmployeesByAlertID', { AssignedEmployeeCode: assignedEmployeeCode, AssignedEmployeeName: assignedEmployeeName, AlertTemplateID: alertTemplateID, AlertStateID: alertStateID, AlertID: alertID})
    //}
    getAlertTemplateStatesDataSource(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        return this.initKendoDataSource('GetAlertTemplateStates', options);
    }
    getAlertTemplateStates(alertTemplateID: number) {
        if (alertTemplateID && alertTemplateID > 0) {
            return this.http.get("GetAlertTemplateStates", { AlertTemplateID: alertTemplateID });
        } 
    };
    getAssignmentsGridDataSource(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        //console.log("getAssignmentsGridDataSource::alert-service.ts::options::", options);
        return this.initKendoDataSource('GetAssignmentsGridDataSource', options);
    }
    getAlertTemplateStateEmployeesDataSource(options?: kendo.data.DataSourceOptions): kendo.data.DataSource {
        //console.log("getAlertTemplateStateEmployeesDataSource::alert-service.ts::options::",/ options);
        return this.initKendoDataSource('GetAlertTemplateStateEmployees', options);
    }
    getAlertComments(alertID: number, documentID: number, hideSystemComments: boolean = null) {
       //console.log("service.ts", hideSystemComments);
       if (alertID && alertID > 0) {
           return this.http.get("GetAlertComments", { AlertID: alertID, DocumentID: documentID, HideSystemComments: hideSystemComments });
       }
    }
    getAlertChecklists(alertID: number) {
        if (alertID && alertID > 0) {
           return this.http.get('GetAlertChecklists', { AlertID: alertID });
        }
    }
    getAlertStates() {
        return this.http.get('GetAlertStates');
    }
    getSoftwareVersionsByJobComponent(jobNumber: number, jobComponentNumber: number, versionID: string) {
        if (jobNumber && jobComponentNumber) {
            if (!versionID || versionID == "") {
                versionID = "0";
            }
            //console.log("alert-service.ts:getSoftwareVersionsByJobComponent", versionID);
            return this.http.get('GetSoftwareVersionsByJobComponent', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber, VersionID: versionID });
        }
    }
    getSoftwareBuildsByVersion(versionID: string) {
        return this.http.get('GetSoftwareBuildsByVersion', { VersionID: versionID });
    }
    getAlertSettings() {
        return this.http.get('GetAlertSettings');
    }
    doesAlertHaveBoard(alertID: number) {
        if (alertID && alertID > 0) {
            return this.http.get('DoesAlertHaveBoard', { AlertID: alertID });
        }
    }
    doesJobHaveSchedule(jobNumber: number, jobComponentNumber: number) {
        if (jobNumber && jobComponentNumber) {
            return this.http.get('DoesJobHaveSchedule', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
        }
    }
    canAddTimeToJob(jobNumber: number, jobComponentNumber: number) {
        if (jobNumber && jobComponentNumber) {
            return this.http.get('CanAddTimeToJob', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
        }
    }
    copyAlert(alert: AlertModel, copyComments: boolean, copyAttachments: boolean) {
        return this.http.post('CopyAlert', { Alert: alert.toJSON(), CopyComments: copyComments, CopyAttachments: copyAttachments });
    }
    transferAlert(alertID: number, jobNumber: number, jobComponentNumber: number, boardId: number, sprintId: number, stateId: number) {
        return this.http.post('TransferAlert', { AlertID: alertID, JobNumber: jobNumber, JobComponentNumber: jobComponentNumber, BoardID: boardId, SprintID: sprintId, StateID: stateId });
    }
    initCopyTransfer(alertID: number, sprintID: number) {
        return this.http.get('InitCopyTransfer', { AlertID: alertID, SprintID: sprintID });
    }
    checkForBoard(jobNumber: number, jobComponentNumber: number) {
        return this.http.get('CheckForBoard', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
    }
    isNoTaskBoard(alertID: number) {
        return this.http.get('IsNoTaskBoard', { AlertID: alertID });
    }
    jobIsNoTaskBoard(jobNumber: number, jobComponentNumber: number) {
        return this.http.get('JobIsNoTaskBoard', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
    }
   //getBoardsForJob(jobNumber: number, jobComponentNumber: number) {
    //    return this.http.get('GetBoardsForJob', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
    //}
    getBoardSprints(boardId: number) {
        if (!boardId) { boardId = 0; }
        return this.http.get('GetBoardSprints', { BoardID: boardId });
    }
    getBoardSprintStates(sprintId: number) {
        return this.http.get('GetBoardSprintStates', { SprintID: sprintId });
    }
    updateAlertCommentSimple(commentID: number, comment: string, mentions?: Array<string>) {
        if (commentID && commentID > 0) {
            var data = {
                CommentID: commentID,
                Comment: comment,
                Mentions: mentions
            };
            return this.http.post("UpdateAlertCommentSimple", data);
        }
    }
    updateAlertComment(commentID: number, comment: string,
        files: Array<string>, uploadToRepository: boolean, uploadToProofHQ: boolean, links: string,
        mentions?: Array<string>, documentID?: number) {
        if (commentID && commentID > 0) {
            var data = {
                CommentID: commentID,
                Comment: comment,
                Files: files,
                UploadToRepository: uploadToRepository,
                UploadToProofHQ: uploadToProofHQ,
                LinksString: links,
                Mentions: mentions,
                DocumentID: documentID
            };
            return this.http.post("UpdateAlertComment", data);
        }
    }
    addAlertComment(alertID: number, commentID: number, comment: string,
        files: Array<string>, uploadToRepository: boolean, uploadToProofHQ: boolean, links: string,
        mentions?: Array<string>, documentID?: number) {
        if (alertID && alertID > 0) {
            var data = {
                AlertID: alertID,
                CommentID: commentID,
                Comment: comment,
                Files: files,
                UploadToRepository: uploadToRepository,
                UploadToProofHQ: uploadToProofHQ,
                LinksString: links,
                Mentions: mentions,
                DocumentID: documentID
            };
            return this.http.post("AddAlertComment", data);
        }
    }
    addMention(alertID: number, mentions: Array<string>, descMention: number) {
        //descMention: are the mentions being added to the database coming from the  
        //main alert/assign. description body?
        try {
            if (alertID && alertID > 0) {            
                var data = {
                    AlertID: alertID,                
                    Mentions: mentions,
                    DescriptionMention: descMention
                };
                return this.http.post("AddMention", data);
            }
        } catch (e) {
            //console.log("mention err:", e);
        }
    }
    createAssignment(alert: AlertModel, notify: boolean, uploadToRepository: boolean, uploadToProofHQ: boolean) {
        if (alert) {
            return this.http.post('CreateAssignment', { Alert: alert, Notify: notify, UploadToRepository: uploadToRepository, UploadToProofHQ: uploadToProofHQ });
        }
    }
    createAssignmentWithDateWorkaround(alert: AlertModel, startDate: string, dueDate: string, notify: boolean, uploadToRepository: boolean, uploadToProofHQ: boolean,Report: string, linksString: string) {
        if (alert) {
            return this.http.post('CreateAssignmentWithDateWorkaround', { Alert: alert, StartDate: startDate, DueDate: dueDate, Notify: notify, UploadToRepository: uploadToRepository, UploadToProofHQ: uploadToProofHQ,Report:Report, LinksString: linksString });
        }
    }
    uploadAttachmentToProofHQ(attachmentID: number) {
        return this.http.post('UploadAttachmentToProofHQ', { AttachmentID: attachmentID });
    }
    addAssigneeToTemplate(alertId: number, alertTemplateId: number, alertStateId: number, employeeCode: string) {
        //console.log("addAssigneeToTemplate", alertId, alertTemplateId, alertStateId, employeeCode);
        return this.http.post('AddAssigneeToTemplate', { AlertID: alertId, AlertTemplateID: alertTemplateId, AlertStateID: alertStateId, EmployeeCode: employeeCode });
    }
    stateHasAssignee(alertId: number, alertTemplateId: number, alertStateId: number, employeeCode: string) {
        //console.log("deleteAssigneeFromTemplate", alertId, alertTemplateId, alertStateId, employeeCode);
        return this.http.post('StateHasAssignee', { AlertID: alertId, AlertTemplateID: alertTemplateId, AlertStateID: alertStateId, EmployeeCode: employeeCode });
    }
    deleteAssigneeFromTemplate(alertId: number, alertTemplateId: number, alertStateId: number, employeeCode: string) {
        //console.log("deleteAssigneeFromTemplate", alertId, alertTemplateId, alertStateId, employeeCode);
        return this.http.post('DeleteAssigneeFromTemplate', { AlertID: alertId, AlertTemplateID: alertTemplateId, AlertStateID: alertStateId, EmployeeCode: employeeCode });
    }
    deleteAssignee(alert: AlertModel, employeeCode: string) {
        if (alert) {
            return this.http.post('DeleteAssignee', { Alert: alert, EmployeeCode: employeeCode });
        }
    }
    addAssignee(alert: AlertModel, employeeCode: string) {
        if (alert) {
            return this.http.post('AddAssignee', { Alert: alert, EmployeeCode: employeeCode });
        }
    }
    deleteRecipient(alert: AlertModel, employeeCode: string) {
        if (alert) {
            return this.http.post('DeleteRecipient', { Alert: alert, EmployeeCode: employeeCode });
        }
    }
    addRecipient(alert: AlertModel, employeeCode: string) {
        if (alert) {
            return this.http.post('AddRecipient', { Alert: alert, EmployeeCode: employeeCode });
        }
    }
    addRecipients(alert: AlertModel, employeeCodes: any) {
        if (alert) {
            return this.http.post('AddRecipients', { Alert: alert, EmployeeCodes: employeeCodes });
        }
    }
    getCCRecipientsAvailable(type: number, clientCode: string, jobNumber: number, jobComponentNumber: number, taskSequenceNumber: number) {
        return this.http.post('GetCCRecipientsAvailable', { Type: type, ClientCode: clientCode, JobNumber: jobNumber, JobComponentNumber: jobComponentNumber, TaskSequenceNumber: taskSequenceNumber });
    }
    addCCRecipientsFrom(alertId: number, type: number) {
        return this.http.post('AddCCRecipientsFrom', { AlertID: alertId, Type: type });
    }
    bookmark(alert: AlertModel) {
        if (alert) {
            return this.http.post('BookmarkAlert', { Alert: alert });
        }
    }
    startStopwatch(alert: AlertModel) {
        if (alert) {
            return this.http.post('StartStopwatch', { Alert: alert });
        }
    }
    hasStopwatch(employeeCode: string) {
        return this.http.post('HasStopwatch', { Alert: alert });
    }
    stopStopwatch(employeeCode: string) {
        return this.http.post('StopStopwatch', { Alert: alert });
    }
    setupNewWorkItem(sprintID: number) {
        return this.http.get('SetupNewWorkItem', { SprintID: sprintID });
    }
    changeBoardState(alert: AlertModel, newStateID: number) {
        return this.http.post('ChangeBoardState', { Alert: alert, NewStateID: newStateID });
    }
    getSprintJobComponents(sprintID: number) {
        return this.http.get('GetSprintJobComponents', { SprintID: sprintID }).then(response => {
            var jobComponents: Array<JobComponent> = new Array<JobComponent>();
            var jobComponent: JobComponent;
            if (response.content.length > 0) {
                for (var i = 0; i < response.content.length; i++) {
                    jobComponent = new JobComponent;
                    Object.assign(jobComponent, response.content[i]);
                    jobComponents.push(jobComponent);
                }
            }
            return jobComponents;
        });
    }
    reassign(alert: AlertModel) {
        if (alert) {
            return this.http.post('Reassign', { Alert: alert });
        }
    }
    unTempComplete(alert: AlertModel) {
        if (alert) {
            return this.http.post('UnTempComplete', { Alert: alert });
        }
    }
    tempComplete(alert: AlertModel) {
        if (alert) {
            return this.http.post('TempComplete', { Alert: alert });
        }
    }
    reopenAlert(alert: AlertModel) {
        if (alert) {
            return this.http.post('ReopenAlert', { Alert: alert });
        }
    }
    completeProof(alert: AlertModel) {
        if (alert) {
            return this.http.post('CompleteProof', { Alert: alert });
        }
    }
    completeAlert(alert: AlertModel) {
        if (alert) {
            return this.http.post('CompleteAlert', { Alert: alert });
        }
    }
    dismissAlert(alert: AlertModel) {
        if (alert) {
            return this.http.post('DismissAlert', { Alert: alert });
        }
    }
    syncReview(alert: AlertModel) {
        if (alert) {
            return this.http.post('SyncReview', { Alert: alert });
        }
    }
    dismissAlertComplete(alert: AlertModel) {
        if (alert) {
            return this.http.post('DismissAlertComplete', { Alert: alert });
        }
    }
    unDismissAlert(alert: AlertModel) {
        if (alert) {
            return this.http.post('UnDismissAlert', { Alert: alert });
        }
    }
    deleteAttachment(attachment: AlertAttachmentModel) {
        return this.http.post('DeleteAttachment', { AlertID: attachment.AlertID, DocumentID: attachment.DocumentID, IsTaskDocument: attachment.IsTaskDocument });
    }
    saveNewWorkItemAttachments(attachments: any) {
        return this.http.post('SaveNewWorkItemAttachments', { Files: attachments });
    }
    getTaskFunctions() {
        return this.http.get('GetTaskFunctions');
    }
    signAttachment(attachment: AlertAttachmentModel) {
        return this.http.post('SignAttachment', { Attachment: attachment });
    }
    setShowHideSystemComments(hide: boolean) {
        return this.http.post('SetShowHideSystemComments', { Hide: hide });
    }
    setAutoClose(close: boolean) {
        return this.http.post('SetAutoClose', { AutoClose: close });
    }
    setShowChecklistsOnCards(showChecklistsOnCards: boolean) {
        return this.http.post('SetShowChecklistsOnCards', { ShowChecklistsOnCards: showChecklistsOnCards });
    }
    setUploadDocumentManager(upload: boolean) {
        return this.http.post('SetUploadDocumentManager', { Upload: upload });
    }
    setDetailsExpanded(expanded: boolean) {
        return this.http.post('SetDetailsExpanded', { Expanded: expanded });
    }
    getLinkableDocuments(alert: AlertModel) {
        if (alert) {
            return this.http.post('GetLinkableDocuments', { Alert: alert });
        }
    }
    linkExistingDocuments(alert: AlertModel, documents: Array<number>) {
        if (alert) {
           return this.http.post('LinkExistingDocuments', { Alert: alert, Documents: documents });
        }
    }
    saveWidgetLayout(widgetLayout: Array<string>) {
        return this.http.post('SaveWidgetLayout', { WidgetLayout: widgetLayout });
    }
    isAlertAssignmentTemplateMultiRoute(alertTemplateId: number) {
        return this.http.get('IsAlertAssignmentTemplateMultiRoute', { AlertTemplateID: alertTemplateId });
    }
    getDefaultWorkflowTemplate(jobNumber: number, jobComponentNumber: number) {
        if (jobNumber && jobComponentNumber) {
            return this.http.get('GetDefaultWorkflowTemplate', { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
        }
    }
    createChecklist(alertID: number, checklist: any) {
        return this.http.post('CreateChecklist', { AlertID: alertID, Checklist: checklist });
    }
    updateChecklistTitle(checklistID: number, title: string) {
        return this.http.post('UpdateChecklistTitle', {ChecklistID: checklistID, Title: title})
    }
    createChecklistItem(checklistID: number, checklistItem: any) {
        var checklist = {
            ID: checklistID
        };
        return this.http.post('CreateChecklistItem', { Checklist: checklist, ChecklistItem: checklistItem });
    }
    updateChecklistItem(checklistItem: any) {
        return this.http.post('UpdateChecklistItem', { ChecklistItem: checklistItem });
    }
    deleteChecklistItem(checklistItem: any) {
        return this.http.post('DeleteChecklistItem', { ChecklistItem: checklistItem });
    }
    deleteChecklist(checklist: any) {
        return this.http.post('DeleteChecklist', { ChecklistHeader: checklist });
    }
    extendSession() {
        return this.http.post('ExtendSession', {});
    }
    feedbackSummaryLoad(projectID: number, reviewID: number) {
        if (!projectID || projectID == undefined || projectID == null) {
            projectID = 0;
        } 
        if (!reviewID || reviewID == undefined || reviewID == null) {
            reviewID = 0;
        } 
        //console.log("feedbackSummaryLoad", projectID, reviewID);
        return this.http.get('FeedbackSummaryLoad', { ProjectID: projectID, ReviewID: reviewID });
    }

    isClientPortal() {
        return this.http.get('isClientPortal');
    }
    isProofingActive() {
        return this.http.get('IsProofingActive');
    }
    AllowProofHQ() {
        return this.http.get('AllowProofHQ');
    }

    GetJobVersionDefaults() {
        return this.http.get('GetJobVersionDefaults');
    }

    GetAlertGroupMembers(alertGroup : string) {
        if (!alertGroup) { alertGroup = ""; }
        return this.http.get('GetAlertGroupMembers', { AlertGroup: alertGroup });
    }

    constructor() {
        super({ baseUrl: "Desktop/Alert" });
        this.priorityLevels = [
            { value: 1, text: 'Highest' },
            { value: 2, text: 'High' },
            { value: 3, text: 'Normal' },
            { value: 4, text: 'Low' },
            { value: 5, text: 'Lowest' }
        ];
    }

}
