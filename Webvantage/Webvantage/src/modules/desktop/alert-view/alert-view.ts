import { bindable, inject, child, observable } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { AlertService } from 'services/desktop/alert-service';
import { AlertModel } from 'models/desktop/alert-model';
import { CommentView } from './comment-view';
import { MentionItem } from './mention-item';
import { AlertRecipientModel } from 'models/desktop/alert-recipient-model';
import { AlertAttachmentModel } from 'models/desktop/alert-attachment-model';
import { DropDownList } from '../../../resources/elements/dropdownlist/dropdownlist';
import { NewWorkItemTimeDialog } from 'modules/project-management/agile/new-work-item-time-dialog';
import { DialogService } from 'aurelia-dialog';
import { AlertCommentDialog } from './alert-comment-dialog'
import { EventAggregator } from 'aurelia-event-aggregator';
import { HttpClient, responseTypeTransformer } from 'aurelia-http-client';
import { EmailGroupsDialog } from 'modules/desktop/alert-view/email-groups-dialog';
import { DashboardService } from 'services/dashboard/dashboard-service';
import { AlertStateModel } from '../../../models/desktop/alert-state-model';
import { AlertStateEmployeeModel } from '../../../models/desktop/alert-state-employee-model';
import { Webvantage } from '../../../webvantage';
@inject(AlertService, DashboardService, DialogService, EventAggregator, Webvantage)
export class AlertView extends ModuleBase {

    @bindable model: AlertModel;
    @observable Alert: AlertModel;
    dialogService: DialogService;
    dashboardService: DashboardService;
    service: AlertService;    
    webvantage: Webvantage;

    //RefreshWindow;

    @bindable proofIsComplete: boolean = false;
    sprintID: number;
    WidgetLayout: Array<string>;
    @bindable AutoClose: boolean;
    @bindable ShowChecklistsOnCards: boolean = false;
    @bindable DetailsExpanded: boolean;
    @bindable isJobComponentLevel: boolean = false;
    @bindable hasBoard: boolean = false;
    @bindable fromBoard: boolean = false;
    @bindable DueDateIsLocked: boolean = false;
    @bindable isClientPortal: boolean = false;
    @bindable isProofingActive: boolean = false;
    @bindable AllowProofHQ: boolean = false;
    @bindable hasCalculatedHours: boolean = false;
    @bindable hasWeeklyHours: boolean = false;
    @bindable openedFrom: number = 0; // 0 = board (default), 1 = Job Inbox
    @bindable isTimesheetActive: boolean = true;

    @bindable isUploadingFile: boolean = true;
    @bindable uploadingFilePrimary: string = "k-primary";
    @bindable uploadingLinkPrimary: string = "";
    @bindable urlTitle: string;
    @bindable urlLink: string;
    @bindable editorHeight: string = "460";
    @bindable editorHeightProofing: string = "346";

    focusLinkTitle: boolean = false;
    focusLinkURL: boolean = false;
    focusExternalReviewerName: boolean = false;
    focusExternalReviewerEmail: boolean = false;
    focusUploadFileButton: boolean = false;

    showingAllEmployees: boolean = false;
    AlertRecipients: Array<AlertRecipientModel>;
    showVersion: boolean;
    assignees: Array<string>;
    assigneesAsItems: Array<any>;
    @bindable proofersList: Array<any>;
    @bindable externalReviewersList: Array<any>;
    @bindable statesList: Array<any>;
    recipients: Array<string>;
    tempCompleteRcpts: Array<string>;
    priorityLevels: Array<any>;
    taskStatuses: Array<any>;
    attachments: Array<AlertAttachmentModel>;
    versionDataSource: kendo.data.DataSource;
    buildDataSource: kendo.data.DataSource;
    assignToNotRoutedAndTasksDataSource: kendo.data.DataSource;
    alertRecipientDataSource: kendo.data.DataSource;
    alertTemplateStatesDataSource: kendo.data.DataSource;
    alertTemplateStateEmployeesDataSource: kendo.data.DataSource;
    alertCategoriesDataSource: kendo.data.DataSource;
    boardStateDataSource: kendo.data.DataSource;
    autoApproveRuleDropDownList: kendo.ui.DropDownList;
    versionDropDownList: kendo.ui.DropDownList;
    buildDropDownList: kendo.ui.DropDownList;
    boardStateDropDownList: kendo.ui.DropDownList;
    alertCategoriesDropDownList: kendo.ui.DropDownList;
    alertTemplateStatesListBox: kendo.ui.ListBox;
    ccMultiSelect: kendo.ui.MultiSelect;
    commentsCollapsed: boolean = false;
    workflowCollapsed: boolean = false;
    descriptionEditor: kendo.ui.Editor;
    sendAssignmentComment: kendo.ui.Editor;
    commentView: CommentView;
    isRouted: boolean = false;
    //assignToDropDownList: DropDownList;
    assignToNotRoutedAndTasksMultiSelect: kendo.ui.MultiSelect;
    routedAssigneesMultiSelect: kendo.ui.MultiSelect;
    externalReviewerMultiSelect: kendo.ui.MultiSelect;
    externalReviewerDataSource: kendo.data.DataSource;

    toolBar: kendo.ui.ToolBar;

    reopenButton: kendo.ui.Button;
    completeButton: kendo.ui.Button;

    dismissButton: kendo.ui.Button;
    unDismissButton: kendo.ui.Button;

    tempCompleteButton: kendo.ui.Button;
    unTempCompleteButton: kendo.ui.Button;

    transferButton: kendo.ui.Button;
    addTimeButton: kendo.ui.Button;
    startStopwatchButton: kendo.ui.Button;
    contactsButton: kendo.ui.Button;
    weeklyHoursButton: kendo.ui.Button;
    employeeHoursButton: kendo.ui.Button;
    addChecklistButton: kendo.ui.Button;
    copyButton: kendo.ui.Button;
    copyTransferSeparator: kendo.ui.Button;
    calculateScheduleDatesButton: kendo.ui.Button;
    sendButton: kendo.ui.Button;
    bookmarkButton: kendo.ui.Button;
    hoursButton: kendo.ui.Button;
    refreshButton: kendo.ui.Button;
    openProofingToolButton: kendo.ui.Button;
    feedbackSummaryButton: kendo.ui.Button;

    @bindable isProof: boolean = false;
    @bindable autoApproveRule: string = "everyone";

    assignmentsGrid: kendo.ui.Grid;
    assignmentsGridDataSource: kendo.data.DataSource;

    weeklyHoursDialog: any; // syncfusion dialog
    buildEnabled: boolean;
    @bindable uploadToDocumentManager: boolean = false;
    uploadToProofHQ: boolean = false;
    sendAssignmentDialog: kendo.ui.Dialog;
    existingDocumentDialog: kendo.ui.Dialog;
    existingDocumentDialogActions: Array<any>;
    existingDocumentsDataSource: kendo.data.DataSource;
    attachmentUpload: kendo.ui.Upload;
    existingDocumentsGrid: kendo.ui.Grid;
    existingDocumentButton: HTMLElement;
    sortableWidgets: kendo.ui.Sortable;
    dueDateCssName: string = "";
    dueDateTitle: string = "";
    dueDatePicker: kendo.ui.DatePicker;
    startDateCssName: string = "";
    startDateTitle: string = "";
    startDatePicker: kendo.ui.DatePicker;
    completedDateCssName: string = "";
    completedDateTitle: string = "";
    completedDatePicker: kendo.ui.DatePicker;
    defaultSubjectType: string = "";
    isTaskAlert: boolean = false;
    @bindable copyTransferButtons: Array<any>;
    assignmentChanged: boolean = false;
    externalReviewersShowAllEmployees: boolean = false;
    doesJobHaveSchedule: boolean = false;
    completeclick: boolean = false;
    completeautoclose: boolean = false;
    loadVersion: boolean = false;
    assigneesChanged: boolean = false;
    isMultiRoute: boolean = false;
    routedAssigneesDataSource: kendo.data.DataSource;
    includeAlertGroup: boolean = false;
    includeTaskEmployees: boolean = false;
    includeContacts: boolean = false;
    jobHasSchedule: boolean = false;
    stateChanged: boolean = false;
    stateChangedFromLoadedState: boolean = false;
    canCompleteProof: boolean = false;
    canCompleteProofMessage: string;
    canCompleteProofMessages: Array<string>;
    canCompleteProofIsComplete: boolean = false;
    canCompleteProofOpenCount: number = 0;
    canCompleteProofRejectCount: number = 0;
    canCompleteProofDeferCount: number = 0;
    dateFormat: string = 'MM/dd/yyyy'
    dateInputFormat: string[] = ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'];
    addExternalReviewersDialog: kendo.ui.Dialog;
    addExternalReviewersDialogActions: Array<any>;
    externalReviewersText: string;
    dbTempCompleteRcpts: Array<string>;
    dbAlertAssignees: Array<string>;
    dbAssignees: Array<string>;
    dbAssigneesAsItems: Array<any>;
    dbAlertStateID: number;
    dbAlertStateName: string;
    dbItemsNotInList: Array<any>;
    currentAlertStateID: number;
    mentionItemSendAssignment: MentionItem;

    documentID: number = 0;

    toggleDetails() {
        this.DetailsExpanded = !this.DetailsExpanded;
        this.service.setDetailsExpanded(this.DetailsExpanded);
    }
    assigneeGridData: Array<AlertStateModel>;
    checkboxAssignmentsGridShowAllEmployeesClicked: boolean = false;

    // methods
    showAttachmentInfo(attachment: AlertAttachmentModel) {
        //console.log("wha", attachment);
        var s = "";
        var versionsOutsideOfProof: number = 0;
        try {
            if (attachment.TotalVersions && attachment.TotalVersionsForAlertID && attachment.TotalVersions > attachment.TotalVersionsForAlertID) {
                versionsOutsideOfProof = attachment.TotalVersions - attachment.TotalVersionsForAlertID;
            }
        } catch (e) {
            versionsOutsideOfProof = 0;
        }
        s += "<div style='border-bottom: 1px solid #CCCCCC; font-weight: bold; padding-bottom: 4px; margin-bottom: 2px;'>" + attachment.FileName + "</div>"
        s += "<b>Uploaded:</b> " + attachment.GeneratedString + " by " + attachment.EmployeeFullName + "<br/>";
        s += "<b>Size:</b> " + attachment.FileSizeDisplay + "<br/>";
        s += "<b>Version:</b> " + attachment.VersionNumber + " of " + attachment.TotalVersionsForAlertID + "<br/>";
        s += "<b>Total Markups:</b> " + attachment.TotalMarkups + "<br/>";
        if (attachment.LastMarkupDate) {
            s += "<b>Last markup:</b> " + attachment.LastMarkupFullName + " on " + attachment.LastMarkupDateString + "<br/>";
        }
        //if (versionsOutsideOfProof > 0) {
        //    s += "<b>Versions outside of this proof:</b> " + versionsOutsideOfProof + "<br/>";
        //}
        //s += "<b>Total Approves:</b> " + attachment.TotalApproved + "<br/>";
        //s += "<b>Total Rejects:</b> " + attachment.TotalRejected + "<br/>";
        //s += "<b>Total Defers:</b> " + attachment.TotalDeferred + "<br/>";
        //if (attachment.IsLatest == true) {
        //    s += "*  This is the lastest, active document."
        //} else {
        //    s += "*  This is not the lastest, active document."
        //}
        this.alert(s);
    }
    setUploadToLink() {
        this.isUploadingFile = false;
        this.focusUploadFileButton = false;
        this.focusLinkTitle = true;
        this.focusLinkURL = false;
        this.uploadingLinkPrimary = "k-primary";
        this.uploadingFilePrimary = "";
    }
    setUploadToFile() {
        this.isUploadingFile = true;
        this.focusUploadFileButton = true;
        this.focusLinkTitle = false;
        this.focusLinkURL = false;
        this.uploadingLinkPrimary = "";
        this.uploadingFilePrimary = "k-primary";
    }
    uploadLink() {
        this.showProgress(true);
        if (this.urlLink && this.urlLink.trim() != "") {
            this.service.uploadURL(this.Alert.ID, this.urlTitle, this.urlLink, this.uploadToDocumentManager).then(response => {
                this.focusLinkTitle = true;
                this.showProgress(false);
                var data = response.content;
                if (data) {
                    if (data.Success == true) {
                        this.getAlertAttachments();
                        this.urlTitle = null;
                        this.urlLink = null;
                    } else {
                        if (data.Message != "") {
                            this.alert(data.Message);
                        }
                    }
                }
            });
        } else {
            this.alert("A URL is required.");
            this.focusLinkURL = true;
            this.showProgress(false);
        }
    }    
    refreshClick() {
        this.getAlert(this.Alert.ID, this.Alert.SprintID, false, true);
        this.commentView.refreshList();
        this.refreshProofParts();
    }
    refreshProofParts() {
        let me = this;
        if (me.isProof == true) {
            me.commentView.getAlertComments();
            if (me.isRouted == true) {
                window.setTimeout(() => {
                    if (me.assignmentsGridDataSource) {
                        me.assignmentsGridDataSource.read().then(response => {
                            window.setTimeout(() => {
                                if (me.assignmentsGrid) {
                                    me.assignmentsGrid.refresh();
                                }
                            }, 0);
                        })
                    }
                }, 0);
            } else {
                window.setTimeout(() => {
                    me.assignToNotRoutedAndTasksDataSource.read();
                }, 0);
            }
            window.setTimeout(() => {
                me.externalReviewerDataSource.read();
            }, 0);
            window.setTimeout(() => {
                me.externalReviewerMultiSelect.refresh();
            }, 10);
            window.setTimeout(() => {
                try {
                    if (me.Alert && me.currentAlertStateID && me.currentAlertStateID > 0) {
                        me.service.checkForStateChange(me.Alert.ID, me.currentAlertStateID).then(response => {
                            if (response) {
                                if (response.content) {
                                    if (response.content.StateChanged == true) {
                                        me.currentAlertStateID = response.content.DbAlertStateID;
                                        me.Alert.AlertStateID = response.content.DbAlertStateID;
                                    } else {
                                    }
                                    window.setTimeout(() => {
                                        me.setSelectedStateOnGrid();
                                    }, 10);
                                }
                            }
                        }).then(() => {
                        });
                    }
                } catch (e) {}

            }, 0);
            window.setTimeout(() => {
                me.getAlertAttachments();
            }, 20);
            window.setTimeout(() => {
                me.canCompleteProofCheck();
            }, 30);
        }
    }
    hoursChanged() {
        //console.log("hoursChanged", this.Alert.HoursAllowed);
        this.service.updateRecipientHours(this.Alert.ID, this.Alert.HoursAllowed, this.Alert.JobHours).then(response => {
            if (response) {
                //console.log("hoursChanged response", response);
                this.getAlertHours();
            }
        }).then(() => {
        });
    }
    hoursChangedTask() {
        //console.log("hoursChanged", this.Alert.HoursAllowed);
        this.service.updateRecipientHours(this.Alert.ID, this.Alert.JobHours, this.Alert.JobHours).then(response => {
            if (response) {
                //console.log("hoursChanged response", response);
                this.getAlertHours();
            }
        }).then(() => {
        });
    }
    keyUpLinkTitle(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.focusLinkURL = true;
        }
    }
    keyUpLinkURL(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.uploadLink();
        }
    }

    openProofing(attachment: AlertAttachmentModel) {
    //    if (this.Alert.AlertCategoryID != 79) {
    //        this._downloadAttachment(attachment);
    //    } else {
            if (attachment.ProofingURL && attachment.ProofingURL != "") {
                this.openRadWindow(attachment.FileName, attachment.ProofingURL, 0, 0, false);
            //} else {
            //    this._downloadAttachment(attachment);
            }
    //    }
    }
    downloadAttachment(attachment: AlertAttachmentModel) {
        if (attachment.MIMEType == "URL" || attachment.FileType.indexOf("link") > -1) {
            var win = window.open(attachment.RepositoryFileName, '_blank');
            win.focus();
        } else {
            if (this.Alert.AlertCategoryID != 79) {
                this._downloadAttachment(attachment);
            } else {
                if (attachment.ProofingURL && attachment.ProofingURL != "") {
                    this.openRadWindow("Proofing", attachment.ProofingURL, 0, 0, false);
                } else {
                    this._downloadAttachment(attachment);
                }
            }
        }
    }
    _downloadAttachment(attachment: AlertAttachmentModel) {
        let exists = false;
        let errorMessage = "";
        var data = {
            AlertID: attachment.AlertID,
            DocumentID: attachment.DocumentID
        };
        this.showProgress(true);
        $.post({
            url: 'Desktop/Alert/TryDownloadAttachment',
            data: data
        })
            .then(response => {
                this.showProgress(false);
                if (response.Exists && response.Exists === true) {
                    exists = true;
                    window.location.href = 'Desktop/Alert/DownloadAttachment?Key=' + response.Key;
                } else {
                    if (response.ErrorMessage && response.ErrorMessage != "") {
                        errorMessage = response.ErrorMessage;
                    }
                }
            })
            .always(() => {
                this.showProgress(false);
                if (!exists) {
                    if (errorMessage && errorMessage != "") {
                        this.alert(errorMessage);
                    } else {
                        this.alert('There was a problem downloading the attachment. Please contact software support.');
                    }
                }

            });
    }
    deleteAttachment(attachment: AlertAttachmentModel) {
        let me = this;
        window.setTimeout(() => {
            if (me.isProof == true) {
                me.service.canDeleteDocument(me.Alert.ID, attachment.DocumentID).then(response => {
                    //console.log("canDeleteDocumentCheck response", response.content);
                    if (response.content) {
                        if (response.content.Success == false) {
                            if (response.content.Message != "") {
                                me.showErrorNotification(response.content.Message);
                            } else {
                                me.showErrorNotification("Cannot delete this asset.")
                            }
                        } else {
                            me._deleteAttachment(attachment);
                        }
                    }
                }).then(() => {
                });
            } else {
                me._deleteAttachment(attachment);
            }
        }, 10);
    }
    _deleteAttachment(attachment: AlertAttachmentModel) {
        let me = this;
        this.confirm("Are you sure you want to delete?").then(accept => {
            this.showProgress(true);
            this.service.deleteAttachment(attachment).then(response => {
                this.showProgress(false);
                if (me.isProof == false) {
                    me.showSuccessNotification("Attachment deleted.");
                } else {
                    me.showSuccessNotification("Asset deleted.");
                }
                this.getAlertAttachments();
            }).then(() => {
                this.showProgress(false);
            });
        }, deny => {
        });
    }
    viewAttachmentProofHQ(attachment: AlertAttachmentModel) {
        //console.log(attachment);
        if (attachment.ProofHQUrl && attachment.ProofHQUrl !== '') {
            window.open(attachment.ProofHQUrl, '_blank');
        } else {
            this.service.uploadAttachmentToProofHQ(attachment.ID).then(response => {
            });
        }
    }
    viewAttachmentComments(attachment: AlertAttachmentModel) {
        this.openRadWindow('', attachment.getViewAttachmentUrl(), 800, 1200, false);
    }
    linkItemClick(documentID: number) {
        //this.showSuccessNotification("Load link to proofing?!?!?!?!?!");
        this.changeSelectedDocument(documentID);
    }
    changeSelectedDocument(documentID: number) { 
        this.documentID = documentID;
        let me = this;
        me.selectDocumentThumbnail(documentID);    
        if (me.Alert) {
            me.Alert.SelectedDocumentID = documentID;
        }
        if (me.commentView) {
            me.commentView.documentId = documentID;
            me.commentView.getAlertComments();
        }
        window.setTimeout(() => {
            me.refreshProofParts();
        }, 100)
    }
    selectDocumentThumbnail(documentID: number) {
        try {
            let selector = "#assetContainer_" + documentID;
            let me = this;
            if ($(".asset-container")) {
                $(".asset-container").removeClass("selected-asset-container");
                //if ($(selector)[0]) {
                //    $(selector).addClass("selected-asset-container");
                //}
                $(selector).addClass("selected-asset-container");
                //console.log("class added");
            }
        } catch (e) {
            console.log("selectDocumentThumbnail:ERROR:", e);
        }
    //    try {
    //        if (this.attachments) {
    //            for (var j = 0; j < this.attachments.length; j++) {
    //                if (this.attachments[j].DocumentID == documentID) {
    //                    this.attachments[j].IsDefaultSelected = true;
    //                    this.attachments[j].SelectedCSS = "selected-asset-container";
    //                    if (this.commentView) {
    //                        this.commentView.documentId = documentID;
    //                    }
    //                    if (this.Alert) {
    //                        this.Alert.SelectedDocumentID = documentID;
    //                    }
    //                } else {
    //                    this.attachments[j].IsDefaultSelected = false;
    //                    this.attachments[j].SelectedCSS = "";
    //                }
    //            }
    //        }
    //    } catch (e) {}
    }

    viewAttachmentHistory(attachment: AlertAttachmentModel) {
        this.openRadWindow('', 'Documents_History.aspx?Level=AT&filename=' + attachment.FileName + '&doc=' + attachment.DocumentID + '&a=' + this.Alert.ID + '&FK=' + this.Alert.ID);
    }
    digitalSignAttachment(attachment: AlertAttachmentModel) {
        this.showProgress(true);
        this.service.signAttachment(attachment).then(response => {
            this.showProgress(false);
            if (response.content.Success === true) {
                this.commentView.getAlertComments();
            } else {
                this.alert('Failed signing document.');
            }
        }).then(() => {
            this.showProgress(false);
        });
    }
    toggleWorkflow() {
        this.workflowCollapsed = !this.workflowCollapsed;
    }
    toggleComments() {
        this.commentsCollapsed = !this.commentsCollapsed;
    }
    fullScreenAssignment() {
        this.dialogService.open({ viewModel: AlertCommentDialog, model: { Alert: this.Alert, Comment: this.sendAssignmentComment.value(), SaveLabel: 'Send Assignment', OkLabel: 'Save Assignment' } }).whenClosed(response => {
            if (!response.wasCancelled) {
                this.sendAssignmentComment.value(response.output.Comment);
                if (response.output.Send) {
                    this.sendAssignmentClicked();
                }
            }
        });
    }
    loadStatesForList() {
        let me = this;
        if (me.Alert.AlertAssignmentTemplateID) {
            this.service.getAlertTemplateStates(me.Alert.AlertAssignmentTemplateID).then(response => {
                if (response) {
                    me.statesList = response.content;
                }
            }).then(() => {
            });
        }
    }
    loadCurrentProofers() {
        let me = this;
        this.service.getCurrentProofersList(me.Alert.ID).then(response => {
            //console.log("loadCurrentProofers", response.content);
            if (response) {
                me.proofersList = response.content;
                //console.log("proofersList", me.proofersList);
            }
        }).then(() => {
        });
    }
    checkboxExternalReviewersShowAllEmployeesChanged() {
        this.externalReviewerDataSource.read();
    }
    loadExternalReviewers() {
        let me = this;
        this.externalReviewerDataSource.read();
        this.service.getExternalReviewersList(me.Alert.ID, 0).then(response => {
            if (response) {
                me.externalReviewersList = response.content;
                //console.log("loadExternalReviewers me.externalReviewersList", me.externalReviewersList);
            }
        }).then(() => {
        });
    }
    emailExternalReviewer(proofingExternalReviewerID) {
    //    console.log("emailExternalReviewer", this.Alert.ID, proofingExternalReviewerID);
    //    this.showSuccessNotification("Email sent!");
    }
    setupProofingButtons() {
        window.setTimeout(() => {
            if (this.toolBar) {
                if (this.isProof == true) {
                    if (this.openProofingToolButton) {
                        this.toolBar.show(this.openProofingToolButton.element);
                    }
                    if (this.feedbackSummaryButton) {
                        this.toolBar.show(this.feedbackSummaryButton.element);
                    }
                    if (this.dismissButton) {
                        this.toolBar.hide(this.dismissButton.element);
                    }
                    if (this.unDismissButton) {
                        this.toolBar.hide(this.unDismissButton.element);
                    }
                    if (this.tempCompleteButton) {
                        this.toolBar.hide(this.tempCompleteButton.element);
                    }
                    if (this.unTempCompleteButton) {
                        this.toolBar.hide(this.unTempCompleteButton.element);
                    }
                    if (this.isClientPortal == true) {
                        if (this.hoursButton) {
                            this.toolBar.hide(this.hoursButton.element);
                        }
                        if (this.openProofingToolButton) {
                            this.toolBar.hide(this.openProofingToolButton.element);
                        }
                        if (this.feedbackSummaryButton) {
                            this.toolBar.hide(this.feedbackSummaryButton.element);
                        }
                    }
                //    if (this.isProofingActive == false) {
                //        console.log(653, "isProofingActive");
                //        if (this.openProofingToolButton) {
                //            this.toolBar.hide(this.openProofingToolButton.element);
                //        }
                //        if (this.feedbackSummaryButton) {
                //            this.toolBar.hide(this.feedbackSummaryButton.element);
                //        }
                //    }
                } else {
                    if (this.openProofingToolButton) {
                        this.toolBar.hide(this.openProofingToolButton.element);
                    }
                    if (this.feedbackSummaryButton) {
                        this.toolBar.hide(this.feedbackSummaryButton.element);
                    }
                }
            }
        }, 0);

    }
    setupToolbar() {
        window.setTimeout(() => {
            if (this.toolBar) {
                var alertIsCompleted: boolean = false;
                if (this.isProof == false) {
                    if (this.Alert.IsCompleted == true || this.Alert.IsMyAssignmentCompleted == true) {
                        alertIsCompleted = true;
                    } else {
                        alertIsCompleted = false;
                    }
                } else {
                    alertIsCompleted = this.Alert.IsCompleted;
                }
                if (alertIsCompleted == true) {
                    if (this.reopenButton) {
                        this.toolBar.show(this.reopenButton.element);
                    }
                    if (this.completeButton) {
                        this.toolBar.hide(this.completeButton.element);
                    }
                } else {
                    if (this.reopenButton) {
                        this.toolBar.hide(this.reopenButton.element);
                    }
                    if (this.completeButton) {
                        if (this.Alert.IsMyAssignment == true) {
                            this.toolBar.show(this.completeButton.element);
                        } else {
                            this.toolBar.hide(this.completeButton.element);
                        }
                    }
                }
                if (this.fromBoard == true || this.openedFrom == 1) {

                } else {
                    if (this.Alert.IsMyAssignment == false) {
                        //if (this.reopenButton) {
                        //    this.toolBar.hide(this.reopenButton.element);
                        //}
                        if (this.completeButton) {
                            this.toolBar.hide(this.completeButton.element);
                        }
                    }
                }
                if (this.Alert.IsMyAlert == false) {
                    if (this.dismissButton) {
                        this.toolBar.hide(this.dismissButton.element);
                    }
                    if (this.unDismissButton) {
                        this.toolBar.hide(this.unDismissButton.element);
                    }
                } else {
                    if (this.Alert.IsMyAlertOpen == true) {
                        if (this.dismissButton) {
                            this.toolBar.show(this.dismissButton.element);
                        }
                        if (this.unDismissButton) {
                            this.toolBar.hide(this.unDismissButton.element);
                        }
                    } else {
                        if (this.dismissButton) {
                            this.toolBar.hide(this.dismissButton.element);
                        }
                        if (this.unDismissButton) {
                            this.toolBar.show(this.unDismissButton.element);
                        }
                    }
                }
                if (this.isTaskAlert === true) {
                    if (this.transferButton) {
                        this.toolBar.hide(this.transferButton.element);
                    }
                }
                if (this.isJobComponentLevel == false) {
                    if (!((this.Alert.OfficeCode && this.Alert.OfficeCode !== "")
                        && (!this.Alert.ClientCode || this.Alert.ClientCode === ""))) {
                        if (this.addTimeButton) {
                            this.toolBar.hide(this.addTimeButton.element);
                            //console.log("Hiding addTimeButton")
                        }
                    }
                    if (this.startStopwatchButton) {
                        this.toolBar.hide(this.startStopwatchButton.element);
                        //console.log("Hiding startStopwatchButton")
                    }
                    if (this.transferButton) {
                        this.toolBar.hide(this.transferButton.element);
                        //console.log("Hiding transferButton")
                    }
                    if (this.copyButton) {
                        this.toolBar.hide(this.copyButton.element);
                        //console.log("Hiding copyButton")
                    }
                    if (this.copyTransferSeparator) {
                        this.toolBar.hide(this.copyTransferSeparator.element);
                        //console.log("Hiding copyTransferSeparator")
                    }
                    if (this.hoursButton) {
                        if (!((this.Alert.OfficeCode && this.Alert.OfficeCode !== "")
                            && (!this.Alert.ClientCode || this.Alert.ClientCode === ""))) {
                            this.toolBar.hide(this.hoursButton.element);
                        }
                    }
                    this.showVersion = false;
                }
                if (this.Alert.IsMyTask == true) {
                    if (this.Alert.IsMyTaskTempComplete == true) {
                        if (this.unTempCompleteButton) {
                            this.toolBar.show(this.unTempCompleteButton.element);
                        }
                        if (this.tempCompleteButton) {
                            this.toolBar.hide(this.tempCompleteButton.element);
                        }
                    } else {
                        if (this.tempCompleteButton) {
                            this.toolBar.show(this.tempCompleteButton.element);
                        }
                        if (this.unTempCompleteButton) {
                            this.toolBar.hide(this.unTempCompleteButton.element);
                        }
                    }
                } else {
                    if (this.tempCompleteButton) {
                        this.toolBar.hide(this.tempCompleteButton.element);
                    }
                    if (this.unTempCompleteButton) {
                        this.toolBar.hide(this.unTempCompleteButton.element);
                    }
                    if (this.calculateScheduleDatesButton) {
                        this.toolBar.hide(this.calculateScheduleDatesButton.element);
                    }
                }
                if (this.Alert.IsWorkItem == false) {
                    if (this.transferButton) {
                        this.toolBar.hide(this.transferButton.element);
                        //console.log("Hiding transferButton")
                    }
                    if (this.Alert.AlertTypeID != 6 && this.Alert.AlertTypeID != 7) {
                        if (this.copyButton) {
                            this.toolBar.hide(this.copyButton.element);
                            //console.log("Hiding copyButton")
                        }
                        if (this.copyTransferSeparator) {
                            this.toolBar.hide(this.copyTransferSeparator.element);
                            //console.log("Hiding copyTransferSeparator")
                        }
                    }
                } else {
                    if (this.canUpdate == true && this.Alert.IsTask == true) {
                        if (this.calculateScheduleDatesButton) {
                            this.toolBar.show(this.calculateScheduleDatesButton.element);
                        }
                    } else {
                        if (this.calculateScheduleDatesButton) {
                            this.toolBar.hide(this.calculateScheduleDatesButton.element);
                        }
                    }
                }
                if (this.isClientPortal == true) {
                    this.toolBar.hide(this.addTimeButton.element);
                    this.toolBar.hide(this.startStopwatchButton.element);
                    this.toolBar.hide(this.copyButton.element);
                    this.toolBar.hide(this.transferButton.element);
                    this.toolBar.hide(this.bookmarkButton.element);
                    this.toolBar.hide(this.copyTransferSeparator.element);
                }
                if (this.isTimesheetActive == false) {
                    if (this.addTimeButton) {
                        this.toolBar.hide(this.addTimeButton.element);
                    }
                    if (this.startStopwatchButton) {
                        this.toolBar.hide(this.startStopwatchButton.element);
                    }
                }
                this.setupProofingButtons();
            }
        }, 10);
    }
    getAttachmentTooltip(attachment: AlertAttachmentModel) {
        var tooltip = '';
        if (attachment.FileType) {
            tooltip = attachment.FileType + ', ';
        }
        if (attachment.FileSizeKB > 0) {
            tooltip += 'Size: ' + attachment.FileSizeDisplay + ', ';
        }
        tooltip += 'Added: ' + this.Alert.getShortDateTimeDisplay(attachment.Generated);
        tooltip += 'by: ' + attachment.EmployeeFullName;
        if (attachment.PrivateFlag == 1) {
            tooltip += ', (PRIVATE)';
        }
        return tooltip;
    }
    sortWidgets() {
        if (this.WidgetLayout && this.WidgetLayout.length > 0) {
            for (var i = 0; i < this.WidgetLayout.length; i++) {
                var element = $('#' + this.WidgetLayout[i] + '-wrap');
                if (element) {
                    element.appendTo($('#sort-panel'));
                    this.refreshSortablePanel(element);
                }
            }
        }
    }
    refreshSortablePanel(item: JQuery<HTMLElement>) {
        let textareas = item.find('textarea');
        if (textareas.length > 0) {
            textareas.each(function () {
                let kEditor = $(this).data('kendoEditor');
                if (kEditor) {
                    kEditor.refresh();
                }
            });
        }
    }
    saveWidgets() {
        var widgets = [];
        $(this.sortableWidgets.items()).each(function () {
            widgets.push($(this).get(0).id.split("-")[0]);
        });
        this.service.saveWidgetLayout(widgets);
    }
    completedDateClick() {
        //console.log("completedDateClick");
        var val: any = this.completedDatePicker.value();
        if (val == null || val == undefined) {
            let me = this;
            var mydate = new Date();
            this.completedDatePicker.value(mydate);
            try {
                me.Alert.CompletedDate = mydate;
                //var todayDate: any = this.parseShortDate(mydate);
                //if (todayDate && todayDate.isValid) {
                //    window.setTimeout(function () {
                //        me.Alert.CompletedDate = todayDate.value;
                //    }, 0);
                //}
            } catch (e) {
            }
        }
    }
    completedDateChange() {
        //console.log("completedDateChange")
        var val2: any = this.completedDatePicker.value();
        let me = this;
        if (!val2) {
            if (this.completedDatePicker) {
                val2 = this.completedDatePicker.element.val();
                if (val2) {
                    var date: any = this.parseShortDate(val2);
                    if (date && date.isValid) {
                        window.setTimeout(() => {
                            me.Alert.CompletedDate = date.value;
                        }, 0);
                    }
                }
            }
        }
    }
    dueDateChange() {
        try {
            var val: any = this.dueDatePicker.value();
            if (!val) {
                if (this.dueDatePicker) {
                    val = this.dueDatePicker.element.val();
                    if (val) {
                        var date: any = this.parseShortDate(val);
                        if (date && date.isValid) {
                            //timeout gives bindings time to finish
                            let me = this;
                            window.setTimeout(() => {
                                me.Alert.DueDate = date.value;
                                me.setupDueDate();
                            }, 0);
                        }
                    }
                }
            }
            if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
                this.showErrorNotification("Due date before start date.")
            }
        } catch (e) {
            console.log("ERROR", e);
        }
        this.setupDueDate();
    }
    startDateChange() {
        try {
            var val: any = this.startDatePicker.value();
            if (!val) {
                if (this.startDatePicker) {
                    val = this.startDatePicker.element.val();
                    if (val) {
                        var date: any = this.parseShortDate(val);
                        if (date && date.isValid) {
                            //timeout gives bindings time to finish
                            let me = this;
                            window.setTimeout(() => {
                                me.Alert.StartDate = date.value;
                                me.setupStartDate();
                            }, 0);
                        }
                    }
                }
            }
            if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
                this.dueDatePicker.value(this.startDatePicker.value());
                this.Alert.DueDate = this.Alert.StartDate;
                //this.showErrorNotification("Due date before start date.")
            }
        } catch (e) {
            console.log("ERROR", e);
        }
        this.setupStartDate();
    }
    unTempCompleteClick() {
        let me = this;
        this.service.unTempComplete(this.Alert).then(() => {
            //Refresh handled by SignalR call from inside VB code
            me.refreshDashboardAssignments();
            if (!me.Alert.SprintID || me.Alert.SprintID == null || me.Alert.SprintID == undefined) {
                me.Alert.SprintID = 0;
            }
            me.commentView.getAlertComments();
            me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
            me.completeclick = true;
            me.completeautoclose = true;
        });
    }
    tempCompleteClick() {
        //this.service.tempComplete(this.Alert).then(() => {
        //    if (!this.Alert.SprintID || this.Alert.SprintID == null || this.Alert.SprintID == undefined) {
        //        this.Alert.SprintID = 0;
        //    }
        //    this.getAlert(this.Alert.ID, this.Alert.SprintID);
        //});
        let me = this;
        return this.service.tempComplete(this.Alert).then(response => {
            if (response.content) {
                me.refreshDashboardAssignments();
                if (response.content.Success == true && response.content.ShowFullyCompletePrompt == true) {
                    me.showWarningNotification("Task will be completed if you were the last employee to temp complete");
                }
            }
        }).then(() => {
            if (!me.Alert.SprintID || me.Alert.SprintID == null || me.Alert.SprintID == undefined) {
                me.Alert.SprintID = 0;
            }
            me.commentView.getAlertComments();
            me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
            me.completeclick = true;
            me.completeautoclose = true;
        });
    }
    setupDueDate() {
        try {
            var tooltip = this.getToolTipForDueDate(this.Alert.DueDate);
            this.getCssForDatePicker(this.Alert.DueDate, 'due');
            this.dueDateTitle = tooltip;
        } catch (e) {
            console.log("ERROR", e);
        }
    }
    setupStartDate() {
        try {
            var tooltip = this.getToolTipForDueDate(this.Alert.StartDate);
            this.getCssForDatePicker(this.Alert.StartDate, 'start');
            this.startDateTitle = tooltip;
        } catch (e) {
            console.log("ERROR", e);
        }
    }
    getToolTipForDueDate(theDate) {
        var tooltip = '';
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 6));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                tooltip = 'Overdue!';
            } else if (theDate.valueOf() === today.valueOf()) {
                tooltip = 'Due today!';
            } else if (weekends.indexOf(theDate.getDay()) > -1) {
                tooltip = 'Due date is on a weekend!';
            } else if (theDate > today && theDate < weekOut) {
                tooltip = 'Due in a week!';
            }
        }
        return tooltip;
    }
    getCssForDatePicker(theDate, startOrDue) {
        var cssClass = '';
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 6));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                cssClass = 'aam-standard-light-pink';
            } else if (theDate.valueOf() === today.valueOf()) {
                cssClass = 'aam-standard-light-orange';
            } else if (weekends.indexOf(theDate.getDay()) > -1) {
                cssClass = 'aam-standard-light-grey';
            } else if (theDate > today && theDate < weekOut) {
                cssClass = 'aam-projected';
            }
        }
        if (startOrDue == 'due') {
            this.dueDateCssName = cssClass;
        } else {
            this.startDateCssName = cssClass;
        }
        return cssClass;
    }
    datePickerOnReady(e) {
        $(e.wrapper).removeClass('standard-red').removeClass('standard-orange').removeClass('standard-light-grey').removeClass('standard-yellow');
    }
    
    // getters
    getAlert(alertID: number, sprintID: number, refreshAlerts: boolean = false, refreshDataSources: boolean = false) {
        //console.log("getAlert", alertID, sprintID);             
        let me = this;
        if (!alertID || alertID == undefined || alertID == null || alertID == 0) {
            alert("No alert ID!");
            me.close();
        }
        if (!sprintID || sprintID == undefined || sprintID == null) {
            sprintID = 0;
        }
        sprintID = sprintID * 1;
        me.showProgress(true);
        //console.log("1", this.Alert.IsCompleted);
        me.service.getAlertView(alertID, sprintID).then(response => {
            //console.log("2", this.Alert.IsCompleted);
            me.showProgress(false);
            if (refreshAlerts == true) {                
                wvbridge.refreshDashboardAlerts();
            }
            var alertModel = new AlertModel;
            Object.assign(alertModel, response.content.Alert);
            Object.assign(this, response.content);
            this.Alert = alertModel;
            //console.log("3", this.Alert.IsCompleted);
            try {
                me.Alert.CompletedDate = this.kendoParseDate(this.Alert.CompletedDateString);
            } catch (e) {
            }
            try {
                me.Alert.DueDate = this.kendoParseDate(this.Alert.DueDateString);
            } catch (e) {
            }
            try {
                me.Alert.StartDate = this.kendoParseDate(this.Alert.StartDateString);
            } catch (e) {
            }
            me.isRouted = me.Alert.AlertAssignmentTemplateID > 0 ? true : false;
            me.hasBoard = response.content.HasBoard;
            //me.isProof = me.Alert.AlertCategoryID === 79 ? true : false;
            me.checkIsProof();
            me.assignmentChanged = false;
            try {
                me.canUpdate = response.content.CanUpdate;
            } catch (e) {
            }
            try {
                me.canAdd = response.content.CanAdd;
            } catch (e) {
            }
            try {
                me.canPrint = response.content.CanPrint;
            } catch (e) {
            }
            try {
                me.canCustom1 = response.content.CanCustom1;
            } catch (e) {
            }
            try {
                me.canCustom2 = response.content.CanCustom2;
            } catch (e) {
            }
            me.DueDateIsLocked = me.canUpdate;
            if (me.Alert.IsTask == true && me.Alert.DueDateLocked == true) {
                me.DueDateIsLocked = true;
            }
            //if (this.descriptionEditor) {
            //    this.descriptionEditor.value(this.Alert.EmailBody);
            //}
            me.checkBuildEnabled();
            me.getCssForDatePicker(me.Alert.StartDate, 'start');
            me.getCssForDatePicker(me.Alert.DueDate, 'due');
            me.setupDueDate();
            if (me.alertTemplateStatesListBox) {
                me.alertTemplateStatesListBox.enable('.k-item', !me.Alert.IsCompleted);
            }
            if (me.Alert.AlertLevel == 'BRD') {
                me.isTaskAlert = true;
            }
            if ((me.Alert.JobNumber && me.Alert.JobNumber > 0) &&
                (me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0)) {
                me.isJobComponentLevel = true;
            } else {
                me.isJobComponentLevel = false;
            }
            //console.log("getAlert", this.isJobComponentLevel);
            if (me.Alert.AssignedEmployeeCode && me.Alert.AssignedEmployeeCode.toLowerCase() == 'unassigned') {
                me.Alert.AssignedEmployeeCode = me.Alert.AssignedEmployeeCode.toUpperCase();
            }
            //console.log("wtf", this.Alert.Build)
            //console.log("canUpdate", this.canUpdate)
            //console.log("DueDateLocked", this.Alert.DueDateLocked)
            //if (this.Alert.AlertStateID) {
            //    this.dbAlertStateID = this.Alert.AlertStateID;
            //}
            //console.log("TaskStatusCode", this.Alert.TaskStatusCode);
            //console.log("TaskStatusDescription", this.Alert.TaskStatusDescription);
            me.stateChangedFromLoadedState = false;
            if (me.isRouted == true) {
                me.currentAlertStateID = me.Alert.AlertStateID;
            }
            window.setTimeout(() => {
                if (me.isProof == true) {
                    me.editorHeight = me.editorHeightProofing;
                }
            }, 0);
            this.showProgress(false);
        }).then(() => {
            window.setTimeout(() => {
                me.setupToolbar();
            }, 10);
            me.getAlertBody();
            if (me.Alert.AlertCategoryID == 71) {
                me.getTaskDescription();
            }
            if (refreshDataSources == true) {
                me.alertTemplateStatesDataSource.read();
                me.assignToNotRoutedAndTasksDataSource.read();
                me.routedAssigneesDataSource.read();
            }
            me.getAlertRecipients(false, false);
            me.getAlertAttachments();
            me.getAlertChecklists();
            me.getSoftwareVersions();
            me.getSoftwareBuilds();
            me.getAlertSettings();
            me.getAlertHours();
            me.checkDoesAlertHaveBoard();
            me.getDefaultSubjectType();
            if (me.Alert.JobNumber && me.Alert.JobNumber > 0 && me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) {
                me.service.doesJobHaveSchedule(me.Alert.JobNumber, me.Alert.JobComponentNumber).then((data) => {
                    me.doesJobHaveSchedule = data.content;
                });
            }
            if (me.isProof == true) {
                //console.log("Hello?")
                if (me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) {
                    me.loadStatesForList();
                }
                me.loadCurrentProofers();
                //me.loadExternalReviewers();
                me.canCompleteProofCheck();
                me.getIsProofingActive();
                if (me.isRouted == true) {
                    me.Alert.IsAutoRoute = true;
                }
            }
            //this.refreshProofParts();
            window.setTimeout(() => {
                if (me.externalReviewerMultiSelect) {
                    if (me.Alert.IsCompleted == true) {
                        me.externalReviewerMultiSelect.enable(false);
                    } else {
                        me.externalReviewerMultiSelect.enable(true);
                    }
                    me.externalReviewerMultiSelect.refresh();
                }
            }, 50);
        });
    }
    canCompleteProofCheck() {
        let me = this;
        window.setTimeout(() => {
            me.service.canCompleteProof(me.Alert.ID).then(response => {
                if (response) {
                    if (response.content.Data) {
                        me.canCompleteProof = response.content.Data.CanComplete;
                        me.canCompleteProofMessage = response.content.Data.CompleteMessage;
                        me.canCompleteProofDeferCount = response.content.Data.DeferCount;
                        me.canCompleteProofIsComplete = response.content.Data.IsComplete;
                        me.canCompleteProofOpenCount = response.content.Data.OpenCount;
                        me.canCompleteProofRejectCount = response.content.Data.RejectCount;
                        me.canCompleteProofMessages = response.content.Data.CompleteMessages;
                    //    console.log("canCompleteProofCheck response", response.content);
                    }
                }
            }).then(() => {
            });
        }, 0);
    }
    setMultiSelect() {
    }
    getDefaultSubjectType() {
        let me = this;
        return this.service.getDefaultSubjectType().then(response => {
            if (response.content) {
                me.defaultSubjectType = response.content
            }
        }).then(() => {
        });
    }
    getAlertBody() {
        let me = this;
        this.showProgress(true);
        return this.service.getAlertBody(me.Alert.ID).then(response => {
            this.showProgress(false);
            if (response.content) {
                window.setTimeout(() => {
                    me.Alert.EmailBody = response.content;
                    if (me.descriptionEditor) {                        
                        me.descriptionEditor.value(me.Alert.EmailBody);
                    }
                }, 0);
            }
        }).then(() => {
            this.showProgress(false);
            try {
                if (me.descriptionEditor) {
                    let body: Element = me.descriptionEditor.body;
                    if (body) {
                        if ($(body)) {
                            $(body).find(".mention-name").prev(".k-br").remove();
                            me.descriptionEditor.update();
                        }
                    }
                }
            } catch (e) {
                //console.log("getAlertBody: " + e);
            }
            //window.setTimeout(() => { me.mentionItemSubject.addDeleteToMention(); }, 250);
        });
    }
    getAlertHours() {
        let me = this;
        this.showProgress(true);
        return this.service.getAlertHours(me.Alert.ID).then(response => {
            this.showProgress(false);
            if (response.content) {
                window.setTimeout(() => {
                    //console.log("getAlertHours", response.content)
                    me.Alert.HoursAllowed = response.content.HoursAllowed;
                    me.Alert.HoursPosted = response.content.HoursPosted;
                    me.Alert.HoursAllocated = response.content.HoursAllocated;
                    me.Alert.HoursBalance = response.content.HoursBalance;
                    me.Alert.HoursAllocatedBalance = response.content.HoursAllocatedBalance;
                    me.hasCalculatedHours = response.content.HasCalculatedHours;
                    me.hasWeeklyHours = response.content.HasWeeklyHours;
                }, 0);
            }
        }).then(() => {
            this.showProgress(false);
        });
    }

    getTaskDescription() {
        let me = this;
        return this.service.getTaskDescription(me.Alert.JobNumber, me.Alert.JobComponentNumber, me.Alert.TaskSequenceNumber).then(response => {
            if (response.content) {
                window.setTimeout(() => {
                    me.Alert.TaskFunctionComment = response.content;
                }, 0);
            }
        }).then(() => {
        });
    }

    getAlertRecipients(showMessage: boolean = false, updateTokens: boolean = false) {
        //console.log("getAlertRecipients", this.Alert.ID)
        let me = this;
        this.showProgress(true);
        return this.service.getAlertRecipients(this.Alert.ID).then(response => {
            this.showProgress(false);
            if (response.content) {
                this.AlertRecipients = new Array<AlertRecipientModel>();
                Object.assign(this.AlertRecipients, response.content)
            }
            //console.log("getAlertRecipients", this.AlertRecipients)
        }).then(() => {
            this.showProgress(false);
            this.setUpAlertRecipients(showMessage, updateTokens);
        });
    }
    setUpAlertRecipients(showMessage: boolean = false, updateTokens: boolean = false) {
        //console.log("setUpAlertRecipients");
        let me = this;
        this.assignees = new Array<string>();
        this.recipients = new Array<string>();
        this.Alert.Assignees = new Array<string>();
        this.tempCompleteRcpts = new Array<string>();
        this.assigneesAsItems = new Array<any>();
        if (this.AlertRecipients && this.AlertRecipients.length > 0) {
            for (var i = 0; i < this.AlertRecipients.length; i++) {
                var rcpt = new AlertRecipientModel;
                Object.assign(rcpt, this.AlertRecipients[i]);
                if (rcpt.IsCurrentNotify === true && rcpt.IsCurrentRecipient == false) {
                    //console.log("assignee" + i, rcpt);
                    if (this.isRouted == true) {
                        if (rcpt.CompletedDismissed == false && rcpt.IsCurrentAssignee == true) {
                            this.assignees.push(rcpt.Code);
                            this.Alert.Assignees.push(rcpt.Code);
                            this.assigneesAsItems.push(rcpt);
                        }
                        if (rcpt.CompletedDismissed == true && rcpt.CurrentStateCompleted == true) {
                            this.assignees.push(rcpt.Code);
                            this.Alert.Assignees.push(rcpt.Code);
                            this.assigneesAsItems.push(rcpt);
                            this.tempCompleteRcpts.push(rcpt.Code);
                        }
                    } else {
                        this.assignees.push(rcpt.Code);
                        this.Alert.Assignees.push(rcpt.Code);
                        this.assigneesAsItems.push(rcpt);
                        if (rcpt.CompletedDismissed == true) {
                            this.tempCompleteRcpts.push(rcpt.Code);
                        }
                    }
                } else if (rcpt.IsCurrentRecipient === true && rcpt.IsCurrentNotify === false) {
                    if (rcpt.Code != null) {
                        this.recipients.push(rcpt.Code);
                    } else {
                        if (isNaN(rcpt.ClientContactID) == false) {
                            this.recipients.push("CC|" + rcpt.ClientContactID);
                        }
                    }
                }
                if (rcpt.IsTaskTempComplete) {
                    this.tempCompleteRcpts.push(rcpt.Code);
                }
            }
            this.dbTempCompleteRcpts = this.tempCompleteRcpts;
            this.dbAlertAssignees = this.Alert.Assignees;
            this.dbAssigneesAsItems = this.assigneesAsItems;
            this.dbAssignees = this.assignees;
            this.dbAlertStateID = this.Alert.AlertStateID;
            this.dbAlertStateName = this.Alert.AlertStateName
        } else {
            //this.assignees.push('unassigned');
        }
        //console.log("tempCompleteRcpts", this.tempCompleteRcpts)
        //console.log("setUpAlertRecipients", this.Alert.Assignees);
        updateTokens = true;
        if (updateTokens && updateTokens == true) {
            //if (this.Alert && this.Alert.IsRouted == true) {
            if (this.Alert.IsWorkItem == true) {
                if (me.Alert.AlertLevel == "BRD" || me.isRouted == false) {
                    me.assignToNotRoutedAndTasksDataSource.read();
                    me.checkForTempCompleteAssignee(me.assignToNotRoutedAndTasksMultiSelect);
                } else {
                    me.checkForMultiRoutedCompleteAssignee(me.routedAssigneesMultiSelect);
                }
            }
            //}
        }
        if (showMessage && showMessage == true) {
            //console.log("ASSIGNESS AFTER CHANGE AND REFRESH!", me.Alert.Assignees, me.Alert.AssignedEmployeeName);
            if (me.Alert.AssignedEmployeeName && me.Alert.AssignedEmployeeName != null && me.Alert.AssignedEmployeeName != undefined) {
                if (me.Alert.AssignedEmployeeCode.toUpperCase() === 'UNASSIGNED') {
                    me.showSuccessNotification("Assignment unassigned");
                } else {
                    me.showSuccessNotification("Assignment sent to " + me.Alert.AssignedEmployeeName);
                }
            } else {
                if (me.Alert.Assignees) {
                    //console.log("me.Alert.Assignees.length:", me.Alert.Assignees.length);
                    if (me.Alert.Assignees.length == 1) {
                        me.showSuccessNotification("Assignment sent");
                    } else if (me.Alert.Assignees.length > 1) {
                        me.showSuccessNotification("Assignment sent to multiple employees");
                    }
                }
            }
        }
    }

    getAlertChecklists() {
        //console.log("getAlertChecklists")
        this.showProgress(true);
        return this.service.getAlertChecklists(this.Alert.ID).then(response => {
            this.showProgress(false);
            this.Alert.Checklists = new Array<any>();
            if (response.content) {
                Object.assign(this.Alert.Checklists, response.content);
            }
        });
    }
    initAttachments: boolean = false;
    getAlertAttachments() {
        this.showProgress(true);
        return this.service.getAlertAttachments(this.Alert.ID).then(response => {
            this.showProgress(false);
            this.attachments = new Array<AlertAttachmentModel>();
            for (var i = 0; i < response.content.length; i++) {
                var doc = new AlertAttachmentModel;                
                Object.assign(doc, response.content[i]);
                this.attachments.push(doc);
            }
            if (this.initAttachments == false) {
                for (var j = 0; j < this.attachments.length; j++) {
                    if (this.attachments[j].IsDefaultSelected == true) {
                        this.attachments[j].SelectedCSS = "selected-asset-container";
                        if (this.commentView) {
                            this.commentView.documentId = this.attachments[j].DocumentID;
                        }
                        if (this.Alert) {
                            this.Alert.SelectedDocumentID = this.attachments[j].DocumentID;
                        }
                        this.selectDocumentThumbnail(this.attachments[j].DocumentID);
                    }
                }
                this.initAttachments = true;
            }
        });
    }
    getAlertTemplateStateEmployees() {
        //console.log("getAlertTemplateStateEmployees")
        if (this.Alert.AlertStateID > 0) {
            this.getAlertTemplateStateEmployeesDataSourceMultiSelectRouted();
        } else {
            return this.alertTemplateStateEmployeesDataSource.read();
        }
    }
    getAlertTemplateStates() {
        //console.log("getAlertTemplateStates")
        return this.alertTemplateStatesDataSource.read();
    }
    getAlertCategories() {
        //console.log("getAlertCategories")
        return this.alertCategoriesDataSource.read();
    }
    getAlertTemplateStateEmployeesDataSourceMultiSelectRouted() {
        let me = this;
        //me.service.getAlertTemplateStateEmployeesCount(me.Alert.AlertAssignmentTemplateID, me.Alert.AlertStateID).then(response => {
        //    if (response.response == "0" || response.response == 0) {
        //        me.showingAllEmployees = true;
        //    }
        //    me.multiRouteInit = true;
        me.routedAssigneesDataSource.read();
        //})

    }
    getBoardStates() {
        //console.log("getBoardStates")
        return this.boardStateDataSource.read();
    }
    getSoftwareBuilds() {
        //console.log("getSoftwareBuilds")
        if (this.Alert.Version !== '') {
            let alertView = this;
            this.buildDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: 'Desktop/Alert/GetSoftwareBuildsByVersion',
                        data: function () {
                            return {
                                VersionID: alertView.Alert.Version && alertView.Alert.Version !== '' ? alertView.Alert.Version : 0
                            }
                        }
                    }
                }
            });
        } else {
            this.buildDataSource = new kendo.data.DataSource({
                data: []
            });
        }
        if (this.buildDropDownList) {
            this.buildDropDownList.setDataSource(this.buildDataSource);
        }
        //console.log("getSoftwareBuilds", this.Alert.Build);
        try {
            if (this.Alert.Build && this.buildDropDownList) {
                this.buildDropDownList.value(this.Alert.Build + "");
            }
        } catch (e) { }
    }
    getSoftwareVersions() {
        let me = this;
        me.loadVersion = true;
        me.versionDataSource.read();
    }
    getLinkableDocuments() {
        //console.log("getLinkableDocuments")
        this.existingDocumentsDataSource.data([]);
        this.service.getLinkableDocuments(this.Alert).then(response => {
            if (response.content && response.content !== '') {
                this.existingDocumentsDataSource.data(response.content);
            }
        }).then(() => {
            if (this.existingDocumentsDataSource.data().length > 0) {
                $(this.existingDocumentsGrid.element).show();
                $('#noLinkableDocs').hide();
            } else {
                $(this.existingDocumentsGrid.element).hide();
                $('#noLinkableDocs').show();
            }
            this.existingDocumentsGrid.setDataSource(this.existingDocumentsDataSource);
            this.existingDocumentDialog.open();
        });
    }
    getAlertSettings() {
        //console.log("getAlertSettings")
        return this.service.getAlertSettings().then(response => {
            if (response.content) {
                try {
                    this.AutoClose = response.content.AutoClose;
                } catch (e) { }
                try {
                    this.ShowChecklistsOnCards = response.content.ShowChecklistsOnCards;
                } catch (e) { }
                try {
                    this.DetailsExpanded = response.content.DetailsExpanded;
                } catch (e) { }
                try {
                    this.uploadToDocumentManager = response.content.UploadDocumentManager;
                } catch (e) { }
                try {
                    this.commentView.hideSystemComments = response.content.HideSystemComments;
                } catch (e) { }
                try {
                    this.WidgetLayout = new Array<string>();
                    Object.assign(this.WidgetLayout, response.content.WidgetLayout);
                } catch (e) { }
            }
        }).then(() => {
            this.sortWidgets();
        });
    }
    checkDoesAlertHaveBoard() {
        //console.log("checkDoesAlertHaveBoard", this.Alert.ID)
        let me = this;
        return this.service.doesAlertHaveBoard(this.Alert.ID).then(response => {
            if (response.content) {
                this.hasBoard = response.content;
            }
        }).then(() => {
            window.setTimeout(() => {
                me.setupToolbar();
            }, 0);
        });
    }
    getClientPortal() {
        try {
            this.service.isClientPortal().then(response => {
                if (response) {
                    this.isClientPortal = response.content;
                }
            });
        } catch (e) {
           //console.log("dashboard.ts:loadCounts:isClientPortal:error", e);
        }
    }
    getIsProofingActive() {
        try {
            this.service.isProofingActive().then(response => {
                if (response) {
                    this.isProofingActive = response.content;
                    if (this.isProofingActive == false) {
                        if (this.openProofingToolButton) {
                            this.toolBar.hide(this.openProofingToolButton.element);
                        }
                        if (this.feedbackSummaryButton) {
                            this.toolBar.hide(this.feedbackSummaryButton.element);
                        }
                    }
                }
            });
        } catch (e) {
            //console.log("dashboard.ts:loadCounts:getIsProofingActive:error", e);
        }
    }

    getAllowProofHQ() {

        try {
            this.service.AllowProofHQ().then(response => {
                if (response) {
                    this.AllowProofHQ = response.content;
                    //console.log("ALLOW " + this.AllowProofHQ);
                }
            });
        } catch (e) {
            //console.log("dashboard.ts:loadCounts:AllowProofHQ:error", e);
        }

    }
    selectedStateID: number = 0;
    // events
    alertTemplateStatesChange(e) {
        let me = this;
        let listBox: kendo.ui.ListBox = e.sender;
        if (me.Alert) {
            var item = listBox.select();
            var dataItem = <any>listBox.dataItem(item);
            if (dataItem) {
                me.selectedStateID = dataItem.ID;
                //console.log("alertTemplateStatesChange", dataItem.ID);
                if (me.Alert.AlertStateID !== dataItem.ID) {
                    me.stateChanged = true;
                    me.assigneesChanged = true;
                    me.Alert.AlertStateID = dataItem.ID;
                    if (me.Alert.AlertStateID != me.dbAlertStateID) {
                        me.stateChangedFromLoadedState = true;
                        this.getAlertTemplateStateEmployeesDataSourceMultiSelectRouted();
                    } else {
                        me.stateChangedFromLoadedState = false;
                        me.setDbAssignment(dataItem.ID, false);
                    }
                    me.setDefaultSubject(dataItem.Name);
                }
            } else {
                me.selectedStateID = 0;
            }
            //console.log("this.selectedStateID", this.selectedStateID, this.Alert.AlertAssignmentTemplateID);
        }
    }
    setDbAssignment(currentAlertStateID: number, resetStateListBox: boolean = false) {
        let me = this;
        if (currentAlertStateID == me.dbAlertStateID) {
            me.routedAssigneesDataSource.read().then(() => {
                if (me.dbItemsNotInList) {
                    for (var i = 0; i < me.dbItemsNotInList.length; i++) {
                        me.routedAssigneesDataSource.add(me.dbItemsNotInList[i]);
                    }
                }
                window.setTimeout(() => {
                    me.Alert.AlertStateID = me.dbAlertStateID;
                    me.tempCompleteRcpts = me.dbTempCompleteRcpts;
                    me.Alert.Assignees = me.dbAlertAssignees;
                    me.assigneesAsItems = me.dbAssigneesAsItems;
                    me.assignees = me.dbAssignees;
                    me.routedAssigneesMultiSelect.value(me.Alert.Assignees);
                    if (resetStateListBox == true) {
                        var item: any;
                        for (var i = 0; i < me.alertTemplateStatesListBox.items().length; i++) {
                            //console.log("item " + i, me.alertTemplateStatesListBox.items()[i]);
                            item = me.alertTemplateStatesListBox.items()[i];
                            if ($(item)[0].textContent.indexOf(me.dbAlertStateName) > -1) {
                                me.alertTemplateStatesListBox.select(item);
                                break;
                            }
                        }
                    }
                }, 0);
            });
        }
    }
    setDefaultSubject(newState) {
        if (this.Alert) {
            var defaultSubject = "";
            if (this.defaultSubjectType == "state") {
                defaultSubject = newState;
            } else if (this.defaultSubjectType === "template") {
                defaultSubject = this.Alert.AlertAssignmentTemplateName;
            } else if (this.defaultSubjectType === "templateandstate") {
                defaultSubject = this.Alert.AlertAssignmentTemplateName + " | " + newState;
            } else if (this.defaultSubjectType === "jjcts") {
                defaultSubject = "[";
                if (this.Alert.JobNumber && this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
                    defaultSubject += this.padJobNumber(this.Alert.JobNumber);
                    defaultSubject += "/";
                    defaultSubject += this.padJobComponentNumber(this.Alert.JobComponentNumber);
                    defaultSubject += " - ";
                    defaultSubject += this.Alert.JobComponentDescription;
                    defaultSubject += " | ";
                }
                defaultSubject += this.Alert.AlertAssignmentTemplateName + " | " + newState;
                defaultSubject += "]";
            }
            if (defaultSubject != "") {
                this.Alert.Subject = defaultSubject;
            }
        }
    }
    alertTemplateStatesDataBound(e) {
        window.setTimeout(() => {
            let listBox: kendo.ui.ListBox = e.sender;
            this.alertTemplateStatesListBox = listBox;
            //console.log("alertTemplateStatesDataBound", this.Alert)
            if (this.Alert) {
                listBox.select(null);
                for (var i = 0; i < listBox.items().length; i++) {
                    var item = listBox.items()[i];
                    var dataItem = <any>listBox.dataItem(item);
                    //console.log("AlertStateID, dataItemID", this.Alert.AlertStateID, dataItem.ID)
                    if (dataItem.ID === this.Alert.AlertStateID) {
                        listBox.select(item);
                        //console.log("selected:", item)
                    }
                }
                if (this.Alert.IsCompleted === true) {
                    this.alertTemplateStatesListBox.enable('.k-item', false);
                }
            }
        }, 10);
    }
    alertBoardStateChange() {
        if (this.Alert) {
            var item = this.boardStateDropDownList.select();
            var dataItem = <any>this.boardStateDropDownList.dataItem(item);
            if (dataItem) {
                if (this.Alert.BoardStateID !== dataItem.ID) {
                    this.service.changeBoardState(this.Alert, dataItem.ID).then(response => {
                        if (response) {
                        }
                    })
                    this.Alert.BoardStateID = dataItem.ID;
                }
            }
        }
    }
    alertCategoriesDataBound(e) {
    }
    alertCategoryChanged(e) {        
        //var item = this.alertCategoriesDropDownList.dataItem(this.alertCategoriesDropDownList.select());
        //var alertTypeID: number = null;
        //if (item) {
        //    alertTypeID = item.AlertTypeID;
        //}
        //this.Alert.AlertTypeID = alertTypeID;
    }
    contactsClick() {
        this.openRadWindow('Contacts', 'popContacts.aspx?from=newalert&c=' + this.Alert.ClientCode + '&d=' + this.Alert.DivisionCode + '&j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&p=' + this.Alert.ProductCode + '', 1200, 400);
    }
    refresh() {
        location.reload();
    }
    copyClick(e) {
        var type: string = "1";
        if (this.isRouted && this.isRouted == true) {
            type = "3";
        }
        this.openRadWindow("Copy", "Desktop_AlertView_CopyTransfer?Type=" + type + "&AlertID=" + this.Alert.ID + "&SprintID=" + this.sprintID + "&IsProof=" + this.isProof + "&IsRouted=" + this.isRouted, 575, 510, true);
    }
    transferClick(e) {
        this.openRadWindowdc('Move', 'Desktop_AlertView_CopyTransfer?Type=2&AlertID=' + this.Alert.ID + '&SprintID=' + this.sprintID + "&IsProof=" + this.isProof + "&IsRouted=" + this.isRouted, 400, 510, false, this.refresh);
    }
    copyTransferClick(e) {
        if (e.id === 'Transfer') {
            this.openRadWindow('Move', 'Desktop_AlertView_CopyTransfer?Type=2&AlertID=' + this.Alert.ID + '&SprintID=' + this.sprintID + "&IsProof=" + this.isProof + "&IsRouted=" + this.isRouted, 575, 510);
        } else {
            this.openRadWindow('Copy', 'Desktop_AlertView_CopyTransfer?Type=1&AlertID=' + this.Alert.ID + '&SprintID=' + this.sprintID + "&IsProof=" + this.isProof + "&IsRouted=" + this.isRouted, 400, 510);
        }
    }

    calculateScheduleDatesClick() {
        this.saveClick(false);
        this.service.calculateScheduleDates(this.Alert).then(response => {
            if (response) {
                if (response.content.Success == true) {
                    this.showSuccessNotification("Schedule dates recalculated.");
                } else {
                    this.showErrorNotification("Schedule dates not recalculated.")
                }
            }
        });
    }
    jobClick() {
        //this.openRadWindow('Job', 'JobTemplate_Search.aspx?f=2&l=2&j=' + this.Alert.JobNumber.toString());
        this.openRadWindow('Job Component', 'Content.aspx?j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&FromAlert=AlertView&PageMode=Edit&NewComp=0');
    }
    jobComponentClick() {
        this.service.doesJobHaveSchedule(this.Alert.JobNumber, this.Alert.JobComponentNumber).then(response => {
            if (response) {
                if (response.content == true) {
                    this.openRadWindow('Job Component', 'Content.aspx?contaid=15&j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&FromAlert=AlertView&PageMode=Edit&NewComp=0');
                } else {
                    this.openRadWindow('Job Component', 'Content.aspx?j=' + this.Alert.JobNumber + '&jc=' + this.Alert.JobComponentNumber + '&FromAlert=AlertView&PageMode=Edit&NewComp=0');
                }
            }
        });
    }
    printClick() {
        this.service.saveAssignment(this.Alert, false).then(() => {
            window.open('Alert_Html.aspx?a=' + this.Alert.ID, 'PopLookup', 'screenX=150,left=150,screenY=150,top=150,width=780,height=800,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes');
        }, () => {
            this.alert('There was a problem saving the alert.');
        });
    }

    // ASSIGNEES GRID MULTISELECTS
    @bindable assignmentsGridShowAllEmployees: boolean = false;
    setSelectedStateOnGrid() {
        let me = this;
        if (me.assignmentsGrid) {
            me.assignmentsGrid.clearSelection();
            var dataSource = me.assignmentsGrid.dataSource;
            if (dataSource) {
                try {
                    $.each(me.assignmentsGrid.items(), function (index, item) {
                        var uid = $(item).data("uid");
                        if (uid) {
                            var rowDataItem: any;
                            rowDataItem = dataSource.getByUid(uid);
                            if (rowDataItem) {
                                if (me.assignmentsGrid.table) {
                                    var row = me.assignmentsGrid.table.find("[data-uid=" + uid + "]");
                                    if (row) {
                                        if (rowDataItem.AlertStateID && rowDataItem.AlertStateID == me.Alert.AlertStateID) {
                                            me.assignmentsGrid.select(row);
                                        }
                                    }
                                }
                            }
                        }
                    });
                } catch (e) {
                }
            }
        } 
    }
    assignmentsGridDataBound(e) {
        let me = this;
        var grid = e.sender;
        window.setTimeout(() => {
            try {
                if (grid) {
                    grid.clearSelection();
                    var dataSource = grid.dataSource;
                    if (dataSource) {
                        $.each(grid.items(), function (index, item) {
                            var uid = $(item).data("uid");
                            if (uid) {
                                var rowDataItem = dataSource.getByUid(uid);
                                if (rowDataItem) {
                                    if (grid.table) {
                                        var row;
                                        row = grid.table.find("[data-uid=" + uid + "]");
                                        if (row) {
                                            if (rowDataItem.AlertStateID && rowDataItem.AlertStateID == me.Alert.AlertStateID) {
                                                grid.select(row);
                                            }
                                            var gridRowMultiSelect: kendo.ui.MultiSelect;
                                            gridRowMultiSelect = null;
                                            gridRowMultiSelect = row.find('[data-role="multiselect"]').data('kendoMultiSelect');
                                            if (gridRowMultiSelect != null) {
                                                //console.log("gridRowMultiSelect");
                                                if (rowDataItem.Employees) {
                                                    var emps = [];
                                                    for (var i = 0; i < rowDataItem.Employees.length; i++) {
                                                        if (rowDataItem.AlertStateID == rowDataItem.Employees[i].AlertStateID && rowDataItem.Employees[i].IsSelected == true) {
                                                            //console.log("???", rowDataItem.Employees[i]);
                                                            var emp = {
                                                                AlertStateID: rowDataItem.Employees[i].AlertStateID,
                                                                AlertTemplateID: rowDataItem.Employees[i].AlertTemplateID,
                                                                EmployeeCode: rowDataItem.Employees[i].EmployeeCode,
                                                                FullName: rowDataItem.Employees[i].FullName,
                                                                CanDelete: rowDataItem.Employees[i].CanDelete,
                                                                IsDefault: rowDataItem.Employees[i].IsDefault,
                                                                IsSelected: rowDataItem.Employees[i].IsSelected,
                                                                ProofingStatusID: rowDataItem.Employees[i].ProofingStatusID,
                                                                ProofingStatusText: rowDataItem.Employees[i].ProofingStatusText,
                                                                StatusDate: rowDataItem.Employees[i].StatusDate,
                                                                StatusDateText: rowDataItem.Employees[i].StatusDateText,
                                                                Status: i
                                                            }
                                                            emps.push(emp);
                                                        }
                                                    }
                                                    if (me.checkboxAssignmentsGridShowAllEmployeesClicked == true) {
                                                        me.checkboxAssignmentsGridShowAllEmployeesClicked = false;
                                                        gridRowMultiSelect.value(me.Alert.Assignees);
                                                    } else {
                                                        gridRowMultiSelect.value(emps);
                                                    }
                                                }
                                                if (gridRowMultiSelect.dataItems()) {
                                                    for (var i = 0; i < gridRowMultiSelect.dataItems().length; i++) {
                                                        var multiSelectDataItem = gridRowMultiSelect.dataItems()[i];
                                                        if (multiSelectDataItem) {
                                                            var hideDelete = false;
                                                            if (multiSelectDataItem.ProofingStatusID && multiSelectDataItem.ProofingStatusID == 1) {
                                                                multiSelectDataItem.StatusText = "A";
                                                                multiSelectDataItem.StatusTitle = "Approved";
                                                                multiSelectDataItem.StatusColor = "status-approved";
                                                            } else if (multiSelectDataItem.ProofingStatusID && multiSelectDataItem.ProofingStatusID == 2) {
                                                                multiSelectDataItem.StatusText = "R";
                                                                multiSelectDataItem.StatusTitle = "Rejected";
                                                                multiSelectDataItem.StatusColor = "status-rejected";
                                                            } else if (multiSelectDataItem.ProofingStatusID && multiSelectDataItem.ProofingStatusID == 3) {
                                                                multiSelectDataItem.StatusText = "D";
                                                                multiSelectDataItem.StatusTitle = "Deferred";
                                                                multiSelectDataItem.StatusColor = "status-deferred";
                                                            } else {
                                                                multiSelectDataItem.StatusText = "?";
                                                                multiSelectDataItem.StatusTitle = "Not set";
                                                                multiSelectDataItem.StyleColor = "status-none";
                                                            }
                                                            //console.log("multiSelectDataItem:", multiSelectDataItem.CanDelete);
                                                        }
                                                    }
                                                    window.setTimeout(() => {
                                                        if (gridRowMultiSelect) {
                                                            for (var i = 0; i < gridRowMultiSelect.tagList.find('.proofing-status-icon').length; i++) {
                                                                var li = $(gridRowMultiSelect.tagList.find('.proofing-status-icon')[i]).closest('li');
                                                                if (li) {
                                                                    $(li).find(".k-i-close").hide();
                                                                }
                                                            }
                                                        }
                                                    }, 0);
                                                    window.setTimeout(() => {
                                                        if (gridRowMultiSelect) {
                                                            for (var i = 0; i < gridRowMultiSelect.tagList.find('.delete-placeholder').length; i++) {
                                                                var li = $(gridRowMultiSelect.tagList.find('.delete-placeholder')[i]).closest('li');
                                                                if (li) {
                                                                    $(li).find(".k-i-close").hide();
                                                                }
                                                            }
                                                        }
                                                    }, 0);
                                                }
                                                try {
                                                    window.setTimeout(() => {
                                                    }, 10);
                                                        if (me.Alert.IsCompleted == true) {
                                                            window.setTimeout(() => {
                                                               gridRowMultiSelect.enable(false);
                                                                //console.log("complete! enable false");
                                                            }, 10);
                                                        } else {
                                                            if (rowDataItem.CanEdit == false) {
                                                                window.setTimeout(() => {
                                                                    gridRowMultiSelect.enable(false);
                                                                    //console.log("not complete enable false");
                                                                }, 10);
                                                            } else {
                                                                window.setTimeout(() => {
                                                                    gridRowMultiSelect.enable(true);
                                                                    //console.log("not complete enable true");
                                                                }, 10);
                                                            }
                                                        }
                                                } catch (e) {
                                                }
                                                gridRowMultiSelect.refresh();
                                            }
                                        }
                                    }
                                }
                            }
                        });
                   }
                }
            } catch (e) {
                //console.log("err", e);
            }
        }, 10);
    }
    gridRowMultiSelectOnDataBound(e) {
        //console.log("gridRowMultiSelectOnDataBound", e.sender);
    //    console.log("?AA?A??A", this.Alert.IsCompleted);
    }
    gridRowMultiSelectOnSelect(e) {
        //console.log("gridRowMultiSelectOnSelect", e.dataItem);
        let me = this;
        window.setTimeout(() => {
            if (e.dataItem) {
                if (e.dataItem.CanDelete == true) {
                    if (e.dataItem.AlertStateID == me.Alert.AlertStateID) { //  Current state
                        me.assigneesChanged = true;
                        me.assignees.push(e.dataItem.EmployeeCode);
                        me.Alert.Assignees.push(e.dataItem.EmployeeCode);
                        if (me.assigneesAsItems) {
                            try {
                                var rcpt = new AlertRecipientModel;
                                rcpt.AlertID = me.Alert.ID;
                                rcpt.AlertTemplateID = me.Alert.AlertAssignmentTemplateID;
                                rcpt.AlertStateID = me.Alert.AlertStateID;
                                rcpt.EmployeeCode = e.dataItem.EmployeeCode;
                                rcpt.Code = e.dataItem.EmployeeCode;
                                me.assigneesAsItems.push(rcpt);
                            } catch (e) {}
                        }
                    } else {
                        //// Not current state; add to "template"
                        me.addSelectedAssignee(me.Alert.ID, e.dataItem.AlertTemplateID, e.dataItem.AlertStateID, e.dataItem.EmployeeCode);
                    }
                } else {
                    e.preventDefault();
                    me.showErrorNotification("Cannot add assignee to this state.");
                }
            }
        }, 10);
    }
    gridRowMultiSelectOnDeselect(e) {
        let me = this;
        window.setTimeout(() => {
            if (e.dataItem) {
                if (e.dataItem.CanDelete == true) {
                    if (e.dataItem.AlertStateID != me.Alert.AlertStateID) {
                    //    this.service.stateHasAssignee(me.Alert.ID, e.dataItem.AlertTemplateID, e.dataItem.AlertStateID, e.dataItem.EmployeeCode).then(response => {
                    //        if (response.content.Data.HasAssignee == true) {
                                me.deleteSelectedAssignee(me.Alert.ID, e.dataItem.AlertTemplateID, e.dataItem.AlertStateID, e.dataItem.EmployeeCode);
                    //        } else {
                    //            e.preventDefault();
                    //            me.showErrorNotification("Cannot delete only assignee.");
                    //            me.assignmentsGridDataSource.read();
                    //        }
                    //    });
                    } else {
                        this.assigneesChanged = true;
                        me.assignees = $.grep(me.assignees, function (value) {
                            return value != e.dataItem.EmployeeCode;
                        });
                        me.Alert.Assignees = $.grep(me.Alert.Assignees, function (value) {
                            return value != e.dataItem.EmployeeCode;
                        });
                        me.assigneesAsItems = $.grep(me.assigneesAsItems, function (value) {
                            return value.EmployeeCode != e.dataItem.EmployeeCode;
                        });

                    //    this.service.stateHasAssignee(me.Alert.ID, e.dataItem.AlertTemplateID, e.dataItem.AlertStateID, e.dataItem.EmployeeCode).then(response => {
                    //        if (response.content.Data.HasAssignee == true) {
                    //            this.assigneesChanged = true;
                    //            me.assignees = $.grep(me.assignees, function (value) {
                    //                return value != e.dataItem.EmployeeCode;
                    //            });
                    //            me.Alert.Assignees = $.grep(me.Alert.Assignees, function (value) {
                    //                return value != e.dataItem.EmployeeCode;
                    //            });
                    //            me.assigneesAsItems = $.grep(me.assigneesAsItems, function (value) {
                    //                return value.EmployeeCode != e.dataItem.EmployeeCode;
                    //            });
                    //        } else {
                    //            e.preventDefault();
                    //            me.showErrorNotification("Cannot delete only assignee.");
                    //            me.assignmentsGridDataSource.read();
                    //        }
                    //    });
                    }
                } else {
                    e.preventDefault();
                    me.showErrorNotification("Cannot delete this assignee.");
                }
            }
        }, 10);
    }
    gridRowMultiSelectOnChange(e) {
        //console.log("gridRowMultiSelectOnChange", e);
        this.assigneesChanged = true;
    //    let me = this;
    //    if (e.dataItem.AlertStateID == me.Alert.AlertStateID) {
    //    } else {

    //    }
    }
    gridRowMultiSelectOnOpen(e) {
        if (e) {
        }
    }
    checkboxAssignmentsGridShowAllEmployeesChanged() {
        //console.log("checkboxAssignmentsGridShowAllEmployeesChanged", this.assignmentsGridShowAllEmployees);
        //this.assignmentsGridShowAllEmployees
        let me = this;
        me.checkboxAssignmentsGridShowAllEmployeesClicked = true;
        window.setTimeout(() => {
            me.assignmentsGridDataSource.read();
        }, 50);
    }
    addSelectedAssignee(alertID: number, alertTemplateID: number, alertStateID: number, employeeCode: string) {
        let me = this;
        //this.showProgress(true);
        window.setTimeout(() => {
            me.service.addAssigneeToTemplate(alertID, alertTemplateID, alertStateID, employeeCode).then(response => {
                if (response && response.content) {
                    if (response.content.Success == true) {
                        //this.showInfoNotification("Assignee added to assignment.")
                        //me.assignmentsGridDataSource.read();
                        window.setTimeout(() => {
                            me.canCompleteProofCheck();
                        }, 30);
                    } else {
                        if (response.content.Message.length > 0 && response.content.Message != "") {
                            me.showErrorNotification(response.content.Message);
                        }
                    }
                }
                //this.showProgress(false);
                //console.log("assignToNotRoutedAndTasksMultiSelectSelect response", response);
            });
        }, 0);
    } 
    deleteSelectedAssignee(alertID: number, alertTemplateID: number, alertStateID: number, employeeCode: string) {
        let me = this;
        window.setTimeout(() => {
            this.service.deleteAssigneeFromTemplate(alertID, alertTemplateID, alertStateID, employeeCode).then(response => {
                if (response && response.content) {
                    if (response.content.Success == true) {
                        //this.showInfoNotification("Assignee removed from assignment.")
                        window.setTimeout(() => {
                            me.canCompleteProofCheck();
                        }, 30);
                    } else {
                        if (response.content.Message.length > 0 && response.content.Message != "") {
                            this.showErrorNotification(response.content.Message);
                        }
                    }
                }
                //console.log("assignToNotRoutedAndTasksMultiSelectDeselect response", response);
            });
        }, 0);
    }

    // ROUTED MULTISELECT
    routedAssigneesMultiSelectDataBound(e) {
        //var dsData = e.sender.dataSource.data();
        //var emps = [];
        //if (dsData && dsData.length > 0) {
        //    for (var i = 0; i < dsData.length; i++) {
        //        var item = { EmployeeCode: dsData[i].EmployeeCode, FullName: dsData[i].FullName, IsDefault: dsData[i].IsDefault, Status: i }
        //        emps.push(item);
        //    }
        //    e.sender.value(emps);
        //}
        this.checkForMultiRoutedCompleteAssignee(e.sender)
    }
    routedAssigneesMultiSelectChange(e) {
        this.assigneesChanged = true;
        var items = this.routedAssigneesMultiSelect.value();
    }

    // NON-ROUTED MULTISELECT
    assignToNotRoutedAndTasksMultiSelectSelect(e) {
        console.log("assignToNotRoutedAndTasksMultiSelectSelect");
        this.assigneesChanged = true;
    //    if (e && e.dataItem && e.dataItem.Code) {
    //        //console.log("assignToNotRoutedAndTasksMultiSelectSelect", this.Alert.ID, this.Alert.AlertAssignmentTemplateID, this.selectedStateID, e.dataItem.Code);
    //        this.addSelectedAssignee(this.Alert.ID, this.Alert.AlertAssignmentTemplateID, this.selectedStateID, e.dataItem.Code);
    //    }
    }
    assignToNotRoutedAndTasksMultiSelectDeselect(e) {
        console.log("assignToNotRoutedAndTasksMultiSelectDeselect");
        this.assigneesChanged = true;
    //    if (e && e.dataItem && e.dataItem.Code) {
    //        //console.log("assignToNotRoutedAndTasksMultiSelectDeselect", this.Alert.ID, this.Alert.AlertAssignmentTemplateID, this.selectedStateID, e.dataItem.Code);
    //        this.deleteSelectedAssignee(this.Alert.ID, this.Alert.AlertAssignmentTemplateID, this.selectedStateID, e.dataItem.Code);
    //    } 
    }
    assignToNotRoutedAndTasksMultiSelectChange(e) {
        //console.log("assignToNotRoutedAndTasksMultiSelectChange");
        this.assigneesChanged = true;
        //this.checkForTempCompleteAssignee(e.sender);
        //this.refreshHours();
    }
    assignToNotRoutedAndTasksMultiSelectDataBound(e) {
        //console.log("assignToNotRoutedAndTasksMultiSelectDataBound");
        this.checkForTempCompleteAssignee(e.sender);
    }
    assignToNotRoutedAndTasksMultiSelectOnOpen(e) {
        //console.log("assignToNotRoutedAndTasksMultiSelectOnOpen");
    }
    assignToNotRoutedAndTasksMultiSelectOnClose(e) {
        //console.log("assignToNotRoutedAndTasksMultiSelectOnClose");
    }

    emailGroupsClick() {
        if (this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
            this.dialogService.open({ viewModel: EmailGroupsDialog, model: { Alert: this.Alert }, lock: false }).whenClosed(results => {
                if (!results.wasCancelled) {
                    //console.log("emailGroupsClick:response.output", results.output);
                    if (results.output.Employees) {
                        let selectedEmps: any;
                        selectedEmps = results.output.Employees;
                        for (let i = 0; i < selectedEmps.length; i++) {
                            if (!this.Alert.Recipients) {
                                this.Alert.Recipients = [];
                            }
                            if (!this.recipients) {
                                this.recipients = [];
                            }
                            if (selectedEmps[i].IsClientContact == false) {
                                if (this.Alert.Recipients.includes(selectedEmps[i].EmployeeCode) == false) {
                                    this.Alert.Recipients.push(selectedEmps[i].EmployeeCode);
                                    this.service.addRecipient(this.Alert, selectedEmps[i].EmployeeCode).then(response => {
                                    });
                                }
                                if (this.recipients.includes(selectedEmps[i].EmployeeCode) == false) {
                                    this.recipients.push(selectedEmps[i].EmployeeCode);
                                }
                            } else {
                                if (this.Alert.Recipients.includes("CC|" + selectedEmps[i].EmployeeCode) == false) {
                                    this.Alert.Recipients.push("CC|" + selectedEmps[i].EmployeeCode);
                                    this.service.addRecipient(this.Alert, "CC|" + selectedEmps[i].EmployeeCode).then(response => {
                                    });
                                }
                                if (this.recipients.includes("CC|" + selectedEmps[i].EmployeeCode) == false) {
                                    this.recipients.push("CC|" + selectedEmps[i].EmployeeCode);
                                }
                            }
                        }
                        //console.log("this.Alert.Recipients", this.Alert.Recipients);
                        if (this.Alert.Recipients) {
                            this.ccMultiSelect.value(this.Alert.Recipients);
                        }
                    }
                }
            });
        } else {
            this.showInfoNotification("Select a component first.")
        }
    }

    // EXTERNAL REVIEWERS
    @bindable addNewExternalReviewerName: string;
    @bindable addNewExternalReviewerEmailAddress: string;
    keyUpExternalReviewerName(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.focusExternalReviewerEmail = true;
        }
    }
    keyUpExternalReviewerEmailAddress(e) {
        if (e && e.keyCode && e.keyCode === 13) {
            this.addExternalReviewerslSaveClick();
        }
    }
    addExternalReviewerslCancelClick() {
        this.addNewExternalReviewerName = null;
        this.addNewExternalReviewerEmailAddress = null;
        this.addExternalReviewersDialog.close();
    }
    addExternalReviewerslSaveClick() {
        let me = this;
        this.service.saveExternalReviewer(this.Alert.ID, this.addNewExternalReviewerName, this.addNewExternalReviewerEmailAddress).then(response => {
            //console.log("response", response.content);
            if (response && response.content) {
                if (response.content.Success == true) {
                    me.externalReviewerDataSource.read();
                    me.showSuccessNotification("External reviewer added.")
                    me.addNewExternalReviewerName = null;
                    me.addNewExternalReviewerEmailAddress = null;
                    me.focusExternalReviewerName = true;
                    me.focusExternalReviewerEmail = false;
                } else {
                    if (response.content.Message && response.content.Message != "") {
                        me.alert(response.content.Message);
                    }
                }
            }
        });
   }
    addExternalReviewersClick() {
        this.addExternalReviewersDialog.open();
    }
    externalReviewerMultiSelectOnDataBound(e) {
        let me = this;
        var items = e.sender.value();
        var dataItems = e.sender.dataItems();
        var dsData = e.sender.dataSource.data();
        var emps = [];
        if (dsData && dsData.length > 0) {
            for (var i = 0; i < dsData.length; i++) {
                if (dsData[i].IsSelected == true) {
                    var item = {
                        CanDelete: dsData[i].CanDelete,
                        Email: dsData[i].Email,
                        IsSelected: dsData[i].IsSelected,
                        Name: dsData[i].Name,
                        ProofingExternalReviewerID: dsData[i].ProofingExternalReviewerID,
                        ProofingStatusID: dsData[i].ProofingStatusID,
                        ProofingStatusName: dsData[i].ProofingStatusName
                    }
                    emps.push(item);
                }
            }
            me.externalReviewersList = emps;
            e.sender.value(emps);
        }
        if (e.sender.dataItems()) {
            for (var i = 0; i < e.sender.dataItems().length; i++) {
                var dataItem = e.sender.dataItems()[i];
                if (dataItem) {
                    dataItem.FullName = dataItem.Name;
                    if (dataItem.ProofingStatusID && dataItem.ProofingStatusID == 1) {
                        dataItem.StatusText = "A";
                        dataItem.StatusTitle = "Approved";
                        dataItem.StatusColor = "status-approved";
                    } else if (dataItem.ProofingStatusID && dataItem.ProofingStatusID == 2) {
                        dataItem.StatusText = "R";
                        dataItem.StatusTitle = "Rejected";
                        dataItem.StatusColor = "status-rejected";
                    } else if (dataItem.ProofingStatusID && dataItem.ProofingStatusID == 3) {
                        dataItem.StatusText = "D";
                        dataItem.StatusTitle = "Deferred";
                        dataItem.StatusColor = "status-deferred";
                    } else {
                        dataItem.StatusText = "?";
                        dataItem.StatusTitle = "Not set";
                        dataItem.StyleColor = "status-none";
                    }
                }
            }
        }
        window.setTimeout(() => {
            for (var i = 0; i < e.sender.tagList.find('.proofing-status-icon').length; i++) {
                var li = $(e.sender.tagList.find('.proofing-status-icon')[i]).closest('li');
                if (li) {
                    $(li).find(".k-i-close").hide();
                }
            }
        }, 0);
        window.setTimeout(() => {
            for (var i = 0; i < e.sender.tagList.find('.delete-placeholder').length; i++) {
                var li = $(e.sender.tagList.find('.delete-placeholder')[i]).closest('li');
                if (li) {
                    $(li).find(".k-i-close").hide();
                }
            }
        }, 0);
    //    window.setTimeout(() => {
    //        e.sender.enable(me.Alert.IsCompleted = false);
    //    }, 0);
    }
    externalReviewerMultiSelectOnDeselect(e) {
        let me = this;
        if (e && e.dataItem) {
            //console.log("externalReviewerMultiSelectOnDeselect");
            this.service.canRemoveExternalReviewerFromAssignment(this.Alert.ID, e.dataItem.ProofingExternalReviewerID).then(response => {
                if (response.content) {
                    if (response.content.Success == false) {
                        if (response.content.Message && response.content.Message != "") {
                            me.showErrorNotification(response.content.Message);
                        } else {
                            me.showErrorNotification("Cannot remove this external reviewer!");
                        }
                        me.loadExternalReviewers();
                    } else {
                        this.service.removeExternalReviewerFromAssignment(this.Alert.ID, e.dataItem.ProofingExternalReviewerID).then(response => {
                            if (response.content == true) {
                                //me.loadExternalReviewers();
                            }
                        }).then(() => {
                            window.setTimeout(() => {
                                me.canCompleteProofCheck();
                            }, 30);
                        });
                    }
                } else {
                    me.loadExternalReviewers();
                }
                //console.log("canRemoveExternalReviewerFromAssignment", response.content);
            }).then(() => {
            });
        }
    }
    externalReviewerMultiSelectOnSelect(e) {
        console.log("externalReviewerMultiSelectOnSelect");
        let me = this;
        if (e && e.dataItem) {
            this.service.addExternalReviewerToAssignment(this.Alert.ID, e.dataItem.ProofingExternalReviewerID).then(response => {
                if (response.content == true) {
                    //me.loadExternalReviewers();
                }
            }).then(() => {
                window.setTimeout(() => {
                    me.canCompleteProofCheck();
                }, 30);
            });
        }
    }
    externalReviewerMultiSelectOnOpen(e) {
        let me = this;
        if (e) {
            //console.log("externalReviewerMultiSelectOnOpen", e);
        }
    }
    externalReviewerMultiSelectOnClose(e) {
        let me = this;
        if (e) {
            //console.log("externalReviewerMultiSelectOnClose", e);
        }
    }
    externalReviewerMultiSelectOnChange(e) {
        let me = this;
        if (e) {
        //    console.log("externalReviewerMultiSelectOnChange", e);
        }
    }

    checkIsProof() {
        let me = this;
        me.isProof = me.Alert.AlertCategoryID === 79 ? true : false;
        window.setTimeout(() => {
            me.setupProofingButtons();
        }, 0);
        //if (me.isProof == true) {
        //    me.isRouted = true;
        //}
        //if (me.isProof == true) {

        //} else {

        //}
        //console.log("proof?", me.isProof);
    }
    ccDeselected(e) {
        //console.log("ccDeselected", e.dataItem);
        if (this.Alert.Recipients) {
            var idx = this.Alert.Recipients.indexOf(e.dataItem.Code);
            if (idx > -1) {
                this.Alert.Recipients.splice(idx, 1);
            }
            //console.log("this.Alert.Recipients", this.Alert.Recipients);
        }
    }
    clearCCs() {
        if (this.Alert) {
            if (this.Alert.Recipients && this.Alert.Recipients.length > 0) {
                for (var i = 0; i < this.Alert.Recipients.length; i++) {
                    this.service.deleteRecipient(this.Alert, this.Alert.Recipients[i]).then(response => {
                    });
                }
            }
            this.Alert.Recipients = [];
        }
        if (this.recipients) {
            if (this.recipients && this.recipients.length > 0) {
                for (var i = 0; i < this.recipients.length; i++) {
                    this.service.deleteRecipient(this.Alert, this.recipients[i]).then(response => {
                    });
                }
            }
            this.recipients = [];
        }
        if (this.ccMultiSelect) {
            this.ccMultiSelect.value(null);
        }
    }
    addCCRecipientsFrom(type) {
        if (this.Alert && this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0) {
            let me = this;
            if (type == 0) {
                //if (this.includeAlertGroup == true) {
                this.service.getCCRecipientsAvailable(type, this.Alert.ClientCode, this.Alert.JobNumber, this.Alert.JobComponentNumber, this.Alert.TaskSequenceNumber).then(response => {
                    //console.log("response, response.content", response, response.content)
                    if (response && response.content && response.content.length > 0) {
                        //console.log("response, response.content", response, response.content);
                        for (var i = 0; i < response.content.length; i++) {
                            //console.log("item", response.content[i].Code);
                            this.service.addRecipient(this.Alert, response.content[i].Code).then(response => {
                            });
                        }
                        if (me.ccMultiSelect) {
                            me.ccMultiSelect.value(response.content);
                        }
                    } else {
                        this.showInfoNotification("No alert group.");
                    }
                }).then(() => {
                });
                //}
            }
            //if (type == 2) {
            //    if (this.includeContacts == true) {
            //        this.service.getCCRecipientsAvailable(type, this.Alert.ClientCode, this.Alert.JobNumber, this.Alert.JobComponentNumber, this.Alert.TaskSequenceNumber).then(response => {
            //            if (response && response.content) {
            //                if (me.ccMultiSelect) {
            //                    me.ccMultiSelect.value(response.content);
            //                } else {
            //                    //console.log("no multiselect?");
            //                }
            //            }
            //        }).then(() => {
            //        });
            //    }
            //}
        } else {
            this.showInfoNotification("Select a component first.")
        }
    }

    checkForTempCompleteAssignee(multiselect: kendo.ui.MultiSelect) {
        //console.log("checkForTempCompleteAssignee", multiselect, this.tempCompleteRcpts);
        let me = this;
        if (multiselect && multiselect.dataItems()) {
            //console.log("dataItems??", multiselect.dataItems())
            if (me.isProof == false) {
                for (var i = 0; i < multiselect.dataItems().length; i++) {
                    var item = multiselect.dataItems()[i];
                    if (item) {
                        item.IsProof = false;
                        if (this.tempCompleteRcpts.indexOf(item.Code) > -1) {
                            item.IsTempComplete = true;
                        } else {
                            item.IsTempComplete = false;
                        }
                    }
                }
                me.setassignToNotRoutedAndTasksMultiSelectIconAndDeleteStatus(multiselect);
            } else {
                me.service.getCurrentProofersList(me.Alert.ID).then(response => {
                    var proofers = [];
                    proofers = response.content.Proofers;
                    if (proofers && proofers.length > 0) {
                        //console.log("proofers", proofers);
                        for (var i = 0; i < multiselect.dataItems().length; i++) {
                            var item = multiselect.dataItems()[i];
                            var idx = null;
                            if (item) {
                                item.IsProof = true;
                                item.IsTempComplete = false;
                                item.FullName = item.Name;
                                item.Name = item.Name;
                                item.ProofingStatusID = 0;
                                idx = proofers.findIndex(x => x.EmployeeCode == item.Code);
                                if (idx > -1) {
                                    item.ProofingStatusID = proofers[idx].ProofingStatusID;
                                    item.StatusDateText = proofers[idx].DateString;
                                    item.CanDelete = proofers[idx].CanDelete;
                                    if (item.ProofingStatusID == 1) {
                                        item.StatusText = "A";
                                        item.StatusTitle = "Approved";
                                        item.StatusColor = "status-approved";
                                    } else if (item.ProofingStatusID == 2) {
                                        item.StatusText = "R";
                                        item.StatusTitle = "Rejected";
                                        item.StatusColor = "status-rejected";
                                    } else if (item.ProofingStatusID == 3) {
                                        item.StatusText = "D";
                                        item.StatusTitle = "Deferred";
                                        item.StatusColor = "status-deferred";
                                    } else {
                                        item.StatusText = "?";
                                        item.StatusTitle = "Not set";
                                        item.StyleColor = "status-none";
                                    }
                                }
                            }
                        }
                    } else {
                        for (var i = 0; i < multiselect.dataItems().length; i++) {
                            var item = multiselect.dataItems()[i];
                            if (item) {
                                item.IsProof = true;
                                item.IsTempComplete = false;
                                item.CanDelete = true;
                                item.FullName = "";
                                item.Name = "";
                                item.ProofingStatusID = 0;
                                item.StatusTitle = null;
                                item.StatusColor = null;
                                item.StatusText = null;
                                item.StatusDateText = null;
                            }
                        }
                    }
                }).then(() => {
                    me.setassignToNotRoutedAndTasksMultiSelectIconAndDeleteStatus(multiselect);
                });
            }
        }
    }
    setassignToNotRoutedAndTasksMultiSelectIconAndDeleteStatus(multiselect: kendo.ui.MultiSelect) {
        let me = this;
        if (multiselect) {
            window.setTimeout(() => {
                if (me.isProof == false) {
                    for (var i = 0; i < multiselect.tagList.find('.wv-assignee-complete').length; i++) {
                        var li = $(multiselect.tagList.find('.wv-assignee-complete')[i]).closest('li');
                        if (li) {
                            li.addClass('wv-assignee-complete');
                            $(li).find(".k-i-close").hide();
                        }
                    }
                } else {
                    for (var i = 0; i < multiselect.tagList.find('.proofing-status-icon').length; i++) {
                        var li = $(multiselect.tagList.find('.proofing-status-icon')[i]).closest('li');
                        if (li) {
                            $(li).find(".k-i-close").hide();
                        }
                    }
                }
            }, 0);
            window.setTimeout(() => {
                if (me.Alert.IsCompleted == true) {
                    multiselect.enable(false);
                } else {
                    multiselect.enable(true);
                }
            }, 0);
        }
    }
    checkForMultiRoutedCompleteAssignee(multiselect: kendo.ui.MultiSelect) {
        try {
            //console.log("checkForMultiRoutedCompleteAssignee", multiselect);
            if (multiselect && multiselect.dataItems()) {
                for (var i = 0; i < multiselect.dataItems().length; i++) {
                    var item = multiselect.dataItems()[i];
                    if (this.tempCompleteRcpts.indexOf(item.Code) > -1) {
                        item.IsTempComplete = true;
                    } else {
                        item.IsTempComplete = false;
                    }
                }
                window.setTimeout(() => {
                    for (var i = 0; i < multiselect.tagList.find('.wv-assignee-complete').length; i++) {
                        var li = $(multiselect.tagList.find('.wv-assignee-complete')[i]).closest('li');
                        if (li) {
                            li.addClass('wv-assignee-complete');
                            $(li).find(".k-i-close").hide();
                        }
                    }
                }, 50);
            }
        } catch (e) {
        }
    }

    sendingAssignment: boolean = false;
    sendAssignment(allowAutoClose, fromSendAssignmentButton) {
        let me = this;
        if ((this.Alert.IsWorkItem == true && this.assignmentChanged == true && this.sendingAssignment == false) || this.assigneesChanged == true || fromSendAssignmentButton == true) {
            let unassigned: boolean = false;
            let save: boolean = false;
            if (this.Alert.IsWorkItem == false) {
                save = true;
            } else {
                if (!this.Alert.Assignees || this.Alert.Assignees.length == 0) {
                    if (confirm("Save as unassigned?") == true) {
                        save = true;
                    } else {
                        save = false;
                        this.setDbAssignment(this.dbAlertStateID, true);
                    }
                } else {
                    save = true;
                }
            }
            if (save == true) {
                this.showProgress(true);
                this.sendingAssignment = true;
                try {
                    if (this.sendAssignmentComment) {

                        let comment = this.sendAssignmentComment.value();

                        if (this.mentionItemSendAssignment.mentions.length > 0) {
                            //remove the 'delete' mention span from comment
                            comment = this.mentionItemSendAssignment.cleanupMentionTag(comment);
                        }
                        this.Alert.SendAssignmentComment = comment;
                    }
                } catch (e) { }
                var s = "";
                var d = "";
                var c = "";
                if (this.Alert.StartDate) {
                    s = this.parseShortDate(this.Alert.StartDate).value;
                }
                if (this.Alert.DueDate) {
                    d = this.parseShortDate(this.Alert.DueDate).value;
                }
                if (this.Alert.CompletedDate) {
                    c = this.parseShortDate(this.Alert.CompletedDate).value;
                }
                if (this.mentionItemSendAssignment && this.mentionItemSendAssignment.mentions.length > 0) {
                    //send assignment comment contains mentions, add them to the db.                    
                    this.service.addMention(this.Alert.ID, this.mentionItemSendAssignment.mentions, 0);                    
                }                
                //if (this.mentionItemSubject && this.mentionItemSubject.mentions.length > 0) {                    
                //    //add new mentions to db
                //    this.service.addMention(this.Alert.ID, this.mentionItemSubject.mentions, 1);
                //    //the alert body needs some attention
                //    let bodyContents = this.descriptionEditor.value();                    
                //}
                //this.Alert.EmailBody = this.mentionItemSubject.removeMentionDeleteSpan(this.Alert.EmailBody);
                //this.Alert.Body = this.Alert.EmailBody;
                this.service.sendAssignmentWithDateWorkaround(this.Alert, s, d, c, fromSendAssignmentButton).then(response => {
                    me.showProgress(false);
                    me.assignmentChanged = false;
                    me.sendingAssignment = false;
                    me.assigneesChanged = false;
                    me.stateChanged = false;
                    me.stateChangedFromLoadedState = false;
                    me.refreshHours();
                    if (response.content.Sent == false && response.content.Message && response.content.Message != null) {
                        me.alert(response.content.Message);
                    } else {
                        if (allowAutoClose == true && me.AutoClose == true) {
                            //try {
                            //    if (fromSendAssignmentButton == true) {
                                    me.refreshDashboardAssignments();
                            //    }
                            //} catch (e) {
                            //}
                            me.close();
                        } else {
                            var empName: string = '';
                            me.commentView.getAlertComments();
                            //console.log("sendAssignment.response.content.Alert", response.content.Alert);
                            try {
                            //    if (fromSendAssignmentButton == true) {
                                me.refreshDashboardAssignments();
                                me.refreshAlertsAndAssignmentsManagerPMD();
                            //    }
                            } catch (e) {
                            }
                            try {
                                var alertModel = new AlertModel;
                                Object.assign(alertModel, response.content.Alert);
                                //me.Alert = alertModel;
                                //me.getAlertRecipients(true, false);
                                if (alertModel) {
                                    me.Alert.IsCompleted = alertModel.IsCompleted;
                                    me.Alert.IsMyAssignment = alertModel.IsMyAssignment;
                                    me.Alert.IsMyAssignmentOpen = alertModel.IsMyAssignmentOpen;
                                    me.Alert.IsMyAssignmentCompleted = alertModel.IsMyAssignmentCompleted;
                                    me.Alert.IsMyAlert = alertModel.IsMyAlert;
                                    me.Alert.IsMyAlertOpen = alertModel.IsMyAlertOpen;
                                    me.Alert.IsMyAlertDismissed = alertModel.IsMyAlertDismissed;
                                    me.Alert.AlertStateID = alertModel.AlertStateID;
                                }
                            } catch (e) {
                            }
                            if (me.isProof == true) {
                                window.setTimeout(() => {
                                    me.refreshProofParts();
                                }, 0)
                            }
                            try {
                                if (me.sendAssignmentComment) {
                                    me.sendAssignmentComment.value('');
                                }
                            } catch (e) { }
                            try {
                                if (response.content.StateChanged && response.content.StateChanged == true) {
                                    //refresh state box to select correct state
                                    this.Alert.AlertStateID = response.content.Alert.AlertStateID;
                                }
                            } catch (e) { }
                            //console.log("Assignees Changed?", response.content.AssigneesChanged)
                            try {
                                if (response.content.AssigneesChanged && response.content.AssigneesChanged == true) {
                                    this.getAlertRecipients(false, true);
                                }
                            } catch (e) { }
                            window.setTimeout(() => {
                                me.setupToolbar();
                            }, 250);
                           //try {
                            //    if (response.content.AssigneesChanged && response.content.AssigneesChanged == true) {
                            //        this.getAlertRecipients(false, true);
                            //    }
                            //} catch (e) { }
                        }
                    }
                    me.showProgress(false);
                });
            }
        } else {
            if (this.Alert.IsWorkItem == true) { //non-routed

            }
        }
    }
    saveClick(notify: boolean) {
        let bodyContents = this.descriptionEditor.value();
        var hasAssignees: boolean = false;
        var sendAssignmentRan: boolean = false;

        //this.Alert.EmailBody = bodyContents;

        if (this.Alert.Assignees) {
            hasAssignees = true;
        }
        if (!this.Alert.Subject || this.Alert.Subject == "") {
            this.showErrorNotification("Please enter a subject.");
        } else {
            if (this.dueDateIsBeforeStartDate(this.Alert.StartDate, this.Alert.DueDate) === true) {
                this.showErrorNotification("Due date before start date.")
            } else {
                this.showProgress(true);
                if (this.assigneesChanged == true) {
                    if (this.isRouted == true || hasAssignees == true) {
                        this.sendAssignment(false, notify);
                        sendAssignmentRan = true;
                    }
                }
                let me = this;
                if (sendAssignmentRan == false) {
                    var s = "";
                    var d = "";
                    var c = "";
                    if (this.Alert.StartDate) {
                        s = this.parseShortDate(this.Alert.StartDate).value;
                    }
                    if (this.Alert.DueDate) {
                        d = this.parseShortDate(this.Alert.DueDate).value;
                    }
                    if (this.Alert.CompletedDate) {
                        c = this.parseShortDate(this.Alert.CompletedDate).value;
                    }
                    this.service.saveAssignmentWithDateWorkaround(me.Alert, s, d, c, notify).then(response => {                        
                        //Refresh handled by SignalR call from inside VB code
                        this.showProgress(false);                        
                        if (me.Alert.IsWorkItem == false) {
                            me.refreshDashboardAlerts();
                        } else {
                            me.refreshDashboardAssignments();
                            //wvbridge.RefreshWindow("Content.aspx?contaid=15&j=" + me.Alert.JobNumber + "&jc=" + me.Alert.JobComponentNumber);
                        }
                        me.refreshAlertsAndAssignmentsManagerPMD();
                        if (notify == true && me.AutoClose == true) {
                            me.close();
                        } else {
                            var msg = '';
                            if (me.Alert.IsWorkItem === true) {
                                msg = 'Assignment ';
                            } else {
                                msg = 'Alert ';
                            }
                            if (notify) {
                                msg += 'Sent';
                            } else {
                                msg += 'Saved';
                            }
                            me.completeautoclose = true;
                            me.completeclick = true;
                            me.showSuccessNotification(msg);
                            me.commentView.getAlertComments();
                            me.getAlert(me.Alert.ID, me.Alert.SprintID, true, true);                                                        
                        }                        
                    }).then(() => {
                        if (me.isProof == true) {
                            me.refreshProofParts();
                        }
                        me.showProgress(false);
                    });
                } else {
                    me.showProgress(false);
                }
            }
        }
    }
    sendAssignmentClicked() {
        //console.log("sendAssignmentClicked");
        this.assignmentChanged = true;
        this.sendAssignment(true, true);
    }
    feedbackSummaryClick() {
        let exists = false;
        let errorMessage = "";
        var data = {
            AlertID: this.Alert.ID
        };
        this.showProgress(true);
        $.post({
            url: "Desktop/Alert/TryGetFeedbackSummary",
            data: data
        }).then(response => {
            this.showProgress(false);
            if (response.Success && response.Success == true) {
                exists = true;
                window.location.href = "Desktop/Alert/GetFeedbackSummary?Key=" + response.Key;
            } else {
                if (response.ErrorMessage && response.ErrorMessage != "") {
                    errorMessage = response.ErrorMessage;
                }
            }
        }).always(() => {
            this.showProgress(false);
            if (!exists) {
                if (errorMessage && errorMessage != "") {
                    this.alert(errorMessage);
                } else {
                    this.alert("There was a problem downloading the feedback summary. Please contact software support.");
                }
            }
        });
    }
    proofingToolClick() {
        if (this.attachments && this.attachments.length > 0) {
            var fileName = '';

            var docID = Math.max.apply(Math, this.attachments.map(function (o) { return o.DocumentID; }))
            fileName = this.attachments.find((e) => e.DocumentID == docID).FileName;

            this.service.getProofingURL(this.Alert.ID, docID).then(response => {
                if (response.content.url && response.content.url != "") {
                    this.openRadWindow(fileName, response.content.url, 0, 0, false);
                } else {
                    if (response.content.errorMessage && response.content.errorMessage != "") {
                        this.alert(response.content.errorMessage);
                    }
                }
            });
        } else {
            this.alert("Please upload something first.")
        }
    }
    showAllEmployeesChanged() {
        if (this.Alert.AlertAssignmentTemplateID && this.Alert.AlertAssignmentTemplateID > 0 && this.Alert.AlertStateID && this.Alert.AlertStateID > 0) {
            this.getAlertTemplateStateEmployeesDataSourceMultiSelectRouted();
        } else {
            this.alertTemplateStateEmployeesDataSource.read();
        }
    }
    toolbarClick(message: string) {
        this.alert(message);
    }
    uploadClick() {
        let me = this;
        this.openRadWindow('', 'Alert_AddAttachments.aspx?NoRefreshCaller=1&a=' + this.Alert.ID);
        window.setTimeout(() => {
            var wnd: any = this.getRadWindow();
            if (wnd) {
                var attachWnd = wnd.BrowserWindow.FindWindow('Alert_AddAttachments.aspx');
                if (attachWnd) {
                    attachWnd.add_close(function () {
                        me.showProgress(true);
                        me.getAlertAttachments().then(() => {
                            me.showProgress(false);
                        });
                        me.commentView.getAlertComments();
                    });
                }
            }
        }, 500)
    }
    addTimeClick() {
        //console.log(this.Alert.JobNumber, this.Alert.JobComponentNumber)
        let me = this;
        if (this.Alert.JobNumber && this.Alert.JobComponentNumber) {
            this.service.canAddTimeToJob(this.Alert.JobNumber, this.Alert.JobComponentNumber).then(response => {
                if (response && response.content) {
                    if (response.content.Success == false) {
                        if (response.content.Message && response.content.Message != '') {
                            this.alert(response.content.Message);
                        } else {
                            this.alert('Adding time is not allowed.');
                        }
                    } else {
                        //this.dialogService.open({ viewModel: NewWorkItemTimeDialog, model: { alertID: this.Alert.ID } }).whenClosed(response => {
                        //    if (!response.wasCancelled) {
                        //        this.refreshHours();
                        //    }
                        //});  
                        //this.webvantage.OpenDialog("Add Time", "Employee/Timesheet/Entry?a=" + this.alertid + "&j=" + this.jobnumber + "&jc=" + this.jobcomponentnumber, 600, 600);
                        this.openRadWindow("Add Time", "Employee/Timesheet/Entry?a=" + me.Alert.ID + "&j=" + me.Alert.JobNumber + "&jc=" + me.Alert.JobComponentNumber + "&s=" + me.Alert.TaskSequenceNumber, 500, 700, false);
                    }
                }
            })
        }
        else if ((this.Alert.OfficeCode && this.Alert.OfficeCode !== "") &&
            (!this.Alert.ClientCode || this.Alert.ClientCode === "")) {
            this.openRadWindow("Add Time", "Employee/Timesheet/Entry?a=" + me.Alert.ID, 500, 700, false);
        }

    }
    hoursClick() {
        var URL = "";
        var thisTitle = "Hours";
        URL = 'ProjectManagement/Agile/HoursByAlertID/' + (this.Alert.SprintID ? this.Alert.SprintID : 0) + '/' + this.Alert.ID;
        this.openRadWindow(thisTitle, URL, 700, 1000, true);
    }
    weeklyHoursClick() {
        //this.saveClick(false);
        //var URL = "";
        //var thisTitle = "Weekly Hours";
        //URL = 'ProjectManagement/Agile/HoursByAlertID/' + (this.Alert.SprintID ? this.Alert.SprintID : 0) + '/' + this.Alert.ID;
        //this.openRadWindow(thisTitle, URL, 700, 1000, true);
    }
    employeeHoursClick() {
        //this.saveClick(false);
        //var URL = "";
        //var thisTitle = "Employee Hours";
        //URL = 'ProjectManagement/Agile/HoursByAlertID/' + (this.Alert.SprintID ? this.Alert.SprintID : 0) + '/' + this.Alert.ID;
        //this.openRadWindow(thisTitle, URL, 700, 1000, true);
    }

    refreshHours() {
        this.getAlertHours();
    }
    recipientSelected(e) {
        try {
            this.showProgress(true);
            this.service.addRecipient(this.Alert, e.dataItem.Code).then(response => {
                this.showProgress(false);
            });
        } catch (e) {
            this.showProgress(false);
        }
    }
    recipientDeselected(e) {
        try {
            this.showProgress(true);
            this.service.deleteRecipient(this.Alert, e.dataItem.Code).then(response => {
                this.showProgress(false);
            });
        } catch (e) {
            this.showProgress(false);
        }
    }
    wvLinkClick(e) {
        if (e.id === 'CreateWVLink') {
            this.copyToClipboard(this.Alert.WvPermaLink);
        } else if (e.id === 'CreateCPLink') {
            this.copyToClipboard(this.Alert.CpPermaLink);
        }
    }
    versionChanged() {
        if (!this.Alert.Version || this.Alert.Version === '') {
            this.Alert.Build = '';
        }
        this.checkBuildEnabled();
        this.getSoftwareBuilds();
    }
    checkBuildEnabled() {
        this.buildEnabled = this.Alert.Version && this.Alert.Version !== '' ? true : false;
    }
    boardStateDataBound(e: any) {
        var dropDownList = <kendo.ui.DropDownList>e.sender;
        if (dropDownList) {
            if (!this.Alert.BoardStateID) {
                dropDownList.value('-1');
            }
        }
    }
    descriptionChanged(e) {             
        this.Alert.EmailBody = this.descriptionEditor.value();
    }
    bookmarkClick() {
        this.service.bookmark(this.Alert).then(response => {
            if (response.content.Success === true) {
                this.refreshBookmarksDTO();
            } else if (response.content.Message) {
                this.alert(response.content.Message);
            }
        });
    }
    startStopwatchClick() {
        this.service.startStopwatch(this.Alert).then(response => {
            if (response.content.Success === true) {
                wvbridge.checkForStopwatch();
            } else if (response.content.Message) {
                this.alert(response.content.Message);
            }
        });
    }

    dismissClick() {
        let me = this;
        this.clearBodyForAction();
        this.service.dismissAlert(this.Alert).then(() => {
            //Refresh handled by SignalR call from inside VB code
            me.refreshDashboardAlerts();
            if (me.AutoClose) {
                me.close();
            } else {
                if (!me.Alert.SprintID || me.Alert.SprintID == null || me.Alert.SprintID == undefined) {
                    me.Alert.SprintID = 0;
                }
                me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
                me.getAlertRecipients(false, true);
                me.completeclick = true;
                me.completeautoclose = true;
            }
        });
    }
    unDismissClick() {
        let me = this;
        this.service.unDismissAlert(this.Alert).then(() => {
            //Refresh handled by SignalR call from inside VB code
            me.refreshDashboardAlerts();
            if (!me.Alert.SprintID || me.Alert.SprintID == null || me.Alert.SprintID == undefined) {
                me.Alert.SprintID = 0;
            }
            me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
            me.getAlertRecipients(false, true);
            me.completeclick = true;
            me.completeautoclose = true;
        });
    }
    reopenClick() {
        let me = this;
        this.service.reopenAlert(this.Alert).then(() => {
            //Refresh handled by SignalR call from inside VB code
            me.refreshDashboardAssignments();
            if (!me.Alert.SprintID || me.Alert.SprintID == null || me.Alert.SprintID == undefined) {
                me.Alert.SprintID = 0;
            }
            me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
            me.commentView.getAlertComments();
            me.getAlertRecipients(false, true);
            me.completeclick = true;
            me.completeautoclose = true;
            //this.getAlertTemplateStates();
            window.setTimeout(() => {
                if (me.alertTemplateStatesListBox) {
                    me.alertTemplateStatesListBox.refresh();
                }
            }, 10);
            window.setTimeout(() => {
                me.refreshProofParts();
            }, 10);
        });
    }
    completeClick() {
        let me = this;
        this.clearBodyForAction();
        //console.log("before complete", me.Alert.AlertStateID)
        if (this.isProof == false) {
            this.service.completeAlert(this.Alert).then(response => {
                //Refresh handled by SignalR call from inside VB code
                me.refreshDashboardAssignments();
                if (me.AutoClose) {
                    me.close();
                } else {
                    me.commentView.getAlertComments();
                    me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
                    me.completeclick = true;
                    me.completeautoclose = true;
                    //console.log("response", response)
                    //console.log("response.content", response.content)
                    try {
                        if (response.content.Result.InitialAlertStateID != response.content.Result.FinalAlertStateID) {
                            me.Alert.AlertStateID = response.content.Result.FinalAlertStateID;
                        }
                    } catch (e) { }
                    try {
                        if (response.content.AssigneesChanged == true) {
                            me.getAlertRecipients(false, true);
                        }
                    } catch (e) { }
                    try {
                    } catch (e) { }
                    try {
                    } catch (e) { }
                    this.getAlertTemplateStates();
                    window.setTimeout(() => {
                        if (me.alertTemplateStatesListBox) {
                            me.alertTemplateStatesListBox.refresh();
                        }
                    }, 10);
                }
            });
        } else {
            var complete: boolean = false;
            var msg: string = "";
            var ul: string = "";
            if (me.canCompleteProofMessages && me.canCompleteProofMessages.length > 0) {
                if (me.canCompleteProofMessages.length == 1) {
                    me.canCompleteProofMessage = me.canCompleteProofMessages[0].toString() + "<br/>";
                } else {
                    ul = "<ul>";
                    for (var i = 0; i < me.canCompleteProofMessages.length; i++) {
                        ul += "<li>" + me.canCompleteProofMessages[i] + "</li>";
                    }
                    ul += "</ul>";
                    me.canCompleteProofMessage = ul;
                }
            }
            if (this.canCompleteProof == true) {
                if (me.canCompleteProofMessage && me.canCompleteProofMessage != "") {
                    this.confirm(me.canCompleteProofMessage + "Complete anyway?", "Complete Proof?").then(() => {
                        me.completeProof();
                    }, () => {
                    });
                } else {
                    me.completeProof();
                }
            } else {
                if (me.canCompleteProofMessage && me.canCompleteProofMessage != "") {
                    this.confirm(me.canCompleteProofMessage + "Complete anyway?", "Complete Proof?").then(() => {
                        me.completeProof();
                    }, () => {
                    });
                } else {
                    this.confirm("Proof has not been fully approved.<br />Complete anyway?", "Complete Proof?").then(() => {
                        me.completeProof();
                    }, () => {
                    });
                }
            }


        }
    }
    completeProof() {
        let me = this;
        this.service.completeProof(this.Alert).then(response => {
            //Refresh handled by SignalR call from inside VB code
            me.refreshDashboardAssignments();
            if (me.AutoClose) {
                me.close();
            } else {
                me.commentView.getAlertComments();
                me.getAlert(me.Alert.ID, me.Alert.SprintID, false, false);
                me.completeclick = true;
                me.completeautoclose = true;
                me.refreshProofParts();
                //console.log("response", response)
                //console.log("response.content", response.content)
                try {
                    if (response.content.Result.InitialAlertStateID != response.content.Result.FinalAlertStateID) {
                        me.Alert.AlertStateID = response.content.Result.FinalAlertStateID;
                    }
                } catch (e) { }
                //    try {
                //        if (response.content.AssigneesChanged == true) {
                //            me.getAlertRecipients(false, true);
                //        }
                //    } catch (e) { }
                //    try {
                //        this.getAlertTemplateStates();
                //    } catch (e) { }
                //    try {
                //        window.setTimeout(() => {
                //            if (me.alertTemplateStatesListBox) {
                //                me.alertTemplateStatesListBox.refresh();
                //            }
                //        }, 10);
                //    } catch (e) { }
            }
        });
    }
    clearBodyForAction() {
        // Large bodies (with images) can cause action to fail.
        // That text is not needed for this action anyway so null it out.
        if (this.Alert) {
            this.Alert.Body = null;
            this.Alert.EmailBody = null;
        }
    }
    saveAutoClose() {
        this.service.setAutoClose(this.AutoClose).then(response => {
            if (response) {
            }
        });
    }
    saveShowChecklistsOnCards() {
        this.service.setShowChecklistsOnCards(this.ShowChecklistsOnCards).then(response => {
            if (response) {
            }
        });
    }
    uploadDocumentManagerClick(e) {
        this.service.setUploadDocumentManager(this.uploadToDocumentManager).then(response => {
        });
    }
    postClick() {
        let me = this;
    }
    refreshDashboardReviews() {
        try {
            wvbridge.refreshDashboardReviews();
        } catch (e) {
        }
        //this.refreshAlertsAndAssignmentsManagerPMD();
    }
    refreshDashboardAssignments() {
        try {
            if (this.isProof == false) {
                wvbridge.refreshDashboardAssignments();
            } else {
                wvbridge.refreshDashboardReviews();
            }
        } catch (e) {
        }
        //this.refreshAlertsAndAssignmentsManagerPMD();
    }
    refreshDashboardAlerts() {
        try {
            wvbridge.refreshDashboardAlerts();
        } catch (e) {
        }
        //this.refreshAlertsAndAssignmentsManagerPMD();
    }
    refreshAlertsAndAssignmentsManagerPMD() {
        try {
            if (this.openedFrom != 25 || this.fromBoard == false) {
                wvbridge.refreshAlertsAndAssignmentsManagerPMD();
            }
        } catch (e) {
        }
    }
    assignToChanged(e) {
        //console.log("assignToChanged");
        this.assignmentChanged = true;
    }
    assignToSelected(e) {
        //if (e.dataItem.Code !== '' && e.dataItem.Code !== 'unassigned') {
        //    this.Alert.AssignedEmployeeCode = e.dataItem.Code;
        //    this.Alert.AssignedEmployeeName = e.dataItem.Name;
        //} else {
        //    this.Alert.AssignedEmployeeCode = '';
        //    this.Alert.AssignedEmployeeName = '';
        //}
        this.assignmentChanged = true;
        //console.log("assignmentChanged", this.assignmentChanged)
    }
    assignToDataBound(e) {
        if (this.Alert) {
        }
    }
    toolbarReady(e) {
        this.dismissButton = $('#dismissButton').data('button');
        this.unDismissButton = $('#unDismissButton').data('button');
        this.reopenButton = $('#reopenButton').data('button');
        this.completeButton = $('#completeButton').data('button');
        this.transferButton = $('#transferButton').data('button');
        this.addTimeButton = $('#addTimeButton').data('button');
        this.startStopwatchButton = $('#startStopwatchButton').data('button');
        this.contactsButton = $('#contactsButton').data('button');
        this.weeklyHoursButton = $('#weeklyHoursButton').data('button');
        this.employeeHoursButton = $('#employeeHoursButton').data('button');
        this.addChecklistButton = $('#addChecklistButton').data('button');
        this.copyButton = $('#copyButton').data('button');
        this.copyTransferSeparator = $('#copyTransferSeparator').data('separator');
        this.tempCompleteButton = $('#tempCompleteButton').data('button');
        this.unTempCompleteButton = $('#unTempCompleteButton').data('button');
        this.calculateScheduleDatesButton = $('#calculateScheduleDatesButton').data('button');
        this.sendButton = $('#sendButton').data('button');
        this.bookmarkButton = $('#bookmarkButton').data('button');
        this.copyTransferSeparator = $('#copyTransferSeparator').data('separator');
        this.hoursButton = $('#hoursButton').data('button');
        this.refreshButton = $('#refreshButton').data('button');
        this.openProofingToolButton = $('#openProofingToolButton').data('button');
        this.feedbackSummaryButton = $('#feedbackSummaryButton').data('button');
        //window.setTimeout(() => {
        //    this.setupToolbar();
        //}, 0);
    }
    descriptionReady(e) {
        var editor: kendo.ui.Editor = e;
        editor.wrapper.find("a,span, input").attr("tabindex", -1);
    }
    editExternalReviewers() {
        var title = "Edit External Reviewers";
        var url = "ProjectManagement/Proofing/ExternalReviewers?c=" + this.Alert.ClientCode;
        //this.openRadWindow(title, url);
        this.webvantage.OpenIFrameDialog(title, url, 585, 920, null, null);
    }
    onEditExternalReviewersDialogClose() {
        console.log("onEditExternalReviewersDialogClose");
    };
    emailExternalReviewers() {
        if (this.Alert.IsCompleted == false) {
            this.confirm("Send email to external reviewers?").then(yes => {
                this.service.emailExternalReviewers(this.Alert.ID, 0).then(response => {
                    if (response.content) {
                        //console.log("emailExternalReviewers", response.content);
                        if (response.content.Success == false) {
                            this.showWarningNotification(response.content.Data.Message[0]);
                        }
                    }
                });
            }, no => {
                // cancelled
            })
        } else {
            this.showWarningNotification("No emails sent.  Assignment is completed.")
        }
    }

    attachmentUploadSuccess(e) {
        //console.log('attachmentUploadSuccess', this.isProof, e.operation);
        if (e.operation == 'upload') {
            let me = this;
            me.getAlertAttachments();
            if (me.isProof == true) {
                window.setTimeout(() => {
                    me.refreshProofParts();
                }, 0);
                window.setTimeout(() => {
                    try {
                        me.Alert.SelectedDocumentID = 0;
                        for (var j = 0; j < me.attachments.length; j++) {
                            if (me.attachments[j].IsDefaultSelected == true) {
                                me.attachments[j].SelectedCSS = "selected-asset-container";
                                if (me.commentView) {
                                    me.commentView.documentId = me.attachments[j].DocumentID;
                                }
                                if (me.Alert) {
                                    me.Alert.SelectedDocumentID = me.attachments[j].DocumentID;
                                }
                            } else {
                                me.attachments[j].SelectedCSS = "";
                            }
                           // console.log("attachmentUploadSuccess attachments", me.attachments[j]);
                        }
                    } catch (e) {
                    }
                }, 250);
            }
        }
    }
    attachmentOnUpload(e) {
        //console.log('attachmentOnUpload', this.isProof, e.operation);
        e.data = {
            AlertID: this.Alert.ID,
            UploadToRepository: this.uploadToDocumentManager,
            UploadToProofHQ: this.uploadToProofHQ
        }
    }
    attachmentOnError(e) {
        if (e.operation == 'upload') {
            if (e.XMLHttpRequest.responseText) {
                this.alert(JSON.parse(e.XMLHttpRequest.responseText));
            }
        }
    }
    commentAdded() {
        if (this.commentView) {
            if (this.commentView.attachmentAdded == true) {
                if (this.isProof == true) {
                    this.initAttachments = false;
                    this.refreshProofParts();
                } else {
                    this.getAlertAttachments();
                }
            }
        }
    }
    linkExistingDocumentClick() {
        this.getLinkableDocuments();
    }
    linkExistingDocumentSaveClick() {
        var items = this.existingDocumentsGrid.select();
        if (items.length > 0) {
            var documents = [];
            for (var i = 0; i < items.length; i++) {
                var dataItem = <any>this.existingDocumentsGrid.dataItem(items[i]);
                documents.push(dataItem.ID);
            }
            if (documents.length > 0) {
                this.service.linkExistingDocuments(this.Alert, documents).then(() => {
                    this.getAlertAttachments();
                });
            }
        }
    }
    copyDetailsToClipboard() {
        var details = '';
        if (this.Alert.JobNumber > 0 && this.Alert.JobComponentNumber > 0) {
            details = this.Alert.JobNumber.toString() + '-' + this.Alert.JobComponentNumber.toString() + '-' + (this.Alert.AlertSequenceNumber && this.Alert.AlertSequenceNumber > 0 ? this.Alert.AlertSequenceNumber.toString() : this.Alert.ID.toString()) + ' - ' + this.Alert.Subject.replace("'", "\'");
            this.copyToClipboard(details);
        }
    }
    addChecklist() {
        //Add checklist function goes here
        //console.log('Adds Checklist');
        this.service.createChecklist(this.Alert.ID, { Description: 'Checklist' }).then(response => {
            if (!this.Alert.Checklists) {
                this.Alert.Checklists = [];
            }
            this.Alert.Checklists.push(response.content.Data);
        });
    }
    sortableHint(e) {
        return $(e).clone().addClass('sortable-panels-hint')
            .height($(e).height())
            .width($(e).width());
    }
    sortableEnd(e) {
        let item = $(e.item);
        let me = this;
        window.setTimeout(() => {
            me.refreshSortablePanel(item);
            me.saveWidgets();
        }, 0);
    }
    sortablePlaceholder(e) {
        return $(e).clone().addClass('sortable-panels-placeholder');
    }
    close() {

        var AMI = $(this).data("myAMI");

        try {
            wvbridge.CloseAlertView(this.Alert.ID);
        } catch (e) {
        }

        //try {
        //    var win = this.getRadWindow();
        //    if (win) {
        //        win.close();
        //    }
        //} catch (e) {
        //}
    }
    deleteChecklist(checklist) {
        //console.log('delete checklist', checklist);
        this.confirm('Are you sure you want to delete?').then(yes => {
            this.service.deleteChecklist(checklist).then(response => {
                if (response.content.Success === true) {
                    let index = this.Alert.Checklists.lastIndexOf(checklist);
                    this.Alert.Checklists.splice(index, 1);
                }
            });
        }, no => {
            // cancelled
        })
    }
    titleChangeChecklist(title) {
        //console.log('titleChangeChecklist', title);
    }
    showOnCardChecklist(checklist) {
        //console.log('showOnCardChecklist', checklist);
    }
    // SignalR
    refreshNewAlertView(alertId: number, sprintId: number, employeeName: string) {
        //console.log("alert-view.ts:refreshNewAlertView");
        window.setTimeout(() => {
            if (this.Alert.ID == alertId) {
                if (this.Alert.SprintID == sprintId || sprintId == 0) {
                    this.commentView.getAlertComments();
                    this.getAlert(alertId, sprintId, false, true);
                    if (this.isProof == true) {
                        this.refreshProofParts();
                    }
                    if (employeeName && employeeName != "") {
                        this.showNotification(employeeName + " updated the assignment.");
                    } else {
                        this.showNotification("Assignment updated.");
                    }
                }
            }
        }, 10);
    }
    pushAlertCommentsUpdate(alertId, employeeName) {
        //console.log("alert-view.ts:pushAlertCommentsUpdate");
        if (this.commentView) {
            if (employeeName && employeeName != "") {
                this.showNotification(employeeName + " added a comment.");
            } else {
                this.showNotification("Comment added.");
            }
            this.commentView.getAlertComments();
        }
    }
    pushAlertChecklistsUpdate(alertId, employeeName) {
        //console.log("alert-view.ts:pushAlertChecklistsUpdate");
        try {
            if (employeeName && employeeName != "") {
                this.showNotification("Checklist updated by " + employeeName);
            } else {
                this.showNotification("Checklist updated.");
            }
            this.getAlertChecklists();
        } catch (e) {
            //
        }
    }
    pushAlertAssigneesAndCCsUpdate(alertId, employeeName) {
        //console.log("alert-view.ts:pushAlertAssigneesAndCCsUpdate");
        try {
            if (employeeName && employeeName != "") {
                this.showNotification("Assignees/CC's updated by " + employeeName);
            } else {
                this.showNotification("Assigees/CC's updated.");
            }
            this.getAlertRecipients(false, false);
        } catch (e) {
            //
        }
    }
    pushAlertHoursUpdate(alertId, employeeName) {
        //console.log("alert-view.ts:pushAlertHoursUpdate");
        let me = this;
        me.getAlertHours();
    }
    // class methods
    activate(params: any) {
        wvbridge.CheckWnd();
        this.sprintID = params.SprintID;
        this.getAlert(params.AlertID, this.sprintID, true, false);
        if (params.FromBoard && params.FromBoard == 'true') {
            this.fromBoard = true;
        } else {
            this.fromBoard = false;
        }
        if (params.OpenedFrom && isNaN(params.OpenedFrom) == false) {
            this.openedFrom = params.OpenedFrom * 1;
        }
    }
    attached() {
        let me = this;
        // title change collapsible headers (checklists)
        this.ea.subscribe('title-input-changed', (value) => {
            //console.log(value);
            this.service.updateChecklistTitle(value.RecordID, value.Value).then(response => {
                if (response.content.Success === true) {
                    //console.log("Updated title!")
                }
            });
        });
        let client = new HttpClient();
        //console.log("gb " + this.searchbookmark);
        client.get('Utilities/GetDateFormat').then(data => {
            try {
                this.dateInputFormat = data.content.DateInputFormat;
                this.dateFormat = data.content.DateFormat;
                //console.log(this.dateInputFormat);
                if (this.isClientPortal == false) {
                    if (this.startDatePicker) {
                        this.startDatePicker.setOptions({
                            format: this.dateFormat,
                            parseFormats: this.dateInputFormat
                        });
                    }
                    if (this.dueDatePicker) {
                        this.dueDatePicker.setOptions({
                            format: this.dateFormat,
                            parseFormats: this.dateInputFormat
                        });
                    }
                }
            } catch (e) { }
        });
        this.dashboardService.hasAccessToTimesheet().then(response => {
            me.isTimesheetActive = response.content;
        });
        
        $(document).ready(function () {
            
            //me.attachmentUpload.wrapper.find('.k-dropzone .k-button').css('margin-right', '5px').after(me.existingDocumentButton);

            //if (me.startDatePicker && me.startDatePicker.element) {
            //    me.startDatePicker.element.change(function (e) {
            //        me.startDateChange();
            //    });
            //}
            //if (me.dueDatePicker && me.dueDatePicker.element) {
            //    me.dueDatePicker.element.change(function (e) {
            //        me.dueDateChange();
            //    });
            //}
            //if (me.completedDatePicker && me.completedDatePicker.element) {
            //    me.completedDatePicker.element.change(function (e) {
            //        me.completedDateChange();
            //    });
            //}
            me.sortWidgets();
        });
        // types: 1 = comments only, 2 = checklists only, 3 = assignees & CC's only, 4 = hours only, 0 or "else" = full refresh
        (<any>window).MvcRefreshNewAlertViewBridge = function (alertId, sprintId, employeeName, updateType) {
            //console.log("attached alert id, fn alertid", me.Alert.ID, alertId, sprintId, employeeName);
            if (updateType && updateType != undefined && updateType != null && isNaN(updateType) == false) {
                //console.log("MvcRefreshNewAlertViewBridge:updateType:", updateType);
                if (updateType == 0) {
                    return me.refreshNewAlertView(alertId, sprintId, employeeName);
                } else if (updateType == 1) {
                    return me.pushAlertCommentsUpdate(alertId, employeeName);
                } else if (updateType == 2) {
                    return me.pushAlertChecklistsUpdate(alertId, employeeName);
                } else if (updateType == 3) {
                    return me.pushAlertAssigneesAndCCsUpdate(alertId, employeeName);
                } else if (updateType == 4) {
                    return me.pushAlertHoursUpdate(alertId, employeeName);
                } else if (updateType == 5) {
                    //console.log("UPDATE PROOF");
                    me.refreshProofParts();
                    me.refreshDashboardAssignments();
                    me.refreshAlertsAndAssignmentsManagerPMD;
                } else {
                    return me.refreshNewAlertView(alertId, sprintId, employeeName);
                }
            } else {
                //console.log("MvcRefreshNewAlertViewBridge: no updateType!");
                return me.refreshNewAlertView(alertId, sprintId, employeeName);
            }
        }
    }

    constructor(service: AlertService, dashboardService: DashboardService, dialogService: DialogService, private ea: EventAggregator, webvantage: Webvantage) {

        super();

        let alertView = this;
        let me = this;

        this.dialogService = dialogService;
        this.Alert = new AlertModel;
        this.service = service;
        this.dashboardService = dashboardService;
        this.webvantage = webvantage;
        this.getClientPortal();
        this.getAllowProofHQ();

        this.priorityLevels = [
            { value: 1, text: 'Highest' },
            { value: 2, text: 'High' },
            { value: 3, text: 'Normal' },
            { value: 4, text: 'Low' },
            { value: 5, text: 'Lowest' }
        ];
        this.taskStatuses = [
            //{ value: "H", text: 'High' },
            //{ value: "L", text: 'Low' },
            { value: "A", text: 'Active' },
            { value: "P", text: 'Projected' }
        ];
        this.externalReviewerDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetExternalReviewersList',
                    data: function () {
                        var showAllType: number;
                        /*
                            @SHOW_ALL:
                            0/NULL = SHOW ACTUAL ON ASSIGNMENT
                            1 = By Client/Division/Product
                            2 = By Job
                            3 = "Truly all"
                            4 = By Client
                        */
                        if (me.externalReviewersShowAllEmployees == true) {
                            showAllType = 3;
                        } else {
                            showAllType = 4;
                        }
                        //console.log("showAlltype???", showAllType);
                        return {
                            AlertID: me.Alert.ID,
                            ShowAllType: showAllType
                        }
                    }
                }
            //    ,
            //    create: {
            //        url: 'Desktop/Alert/CreateExternalReviewer',
            //        data: function () {
            //            return {
            //                AlertID: me.Alert.ID
            //            }
            //        }
            //    }
            },
            requestStart: function (e) {
                //console.log("externalReviewerDataSource requestStart");
                if (e.type === "read") {
                    if (!me.Alert || me.isProof == false) {
                        e.preventDefault();
                        //console.log("GetExternalReviewersList cancelled!")
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                let me = this;
                items = e.response;
                if (items) {
                    //me.externalReviewersList = items;
                    //console.log("x reviewers?", items);
                    me.externalReviewersList = [];
                    for (var i = 0; i < items.length; i++) {
                        if (items[i].IsSelected == true) {
                            me.externalReviewersList.push(items[i]);
                        }
                    }
                    //console.log("externalReviewersList", me.externalReviewersList);
                }
            }
        });
        this.assignToNotRoutedAndTasksDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetEmployees'
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                let me = this;
                items = e.response;
                //console.log("items?", items);
                if (items) {
                }
            }
        });
        this.alertRecipientDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertRecipientsLookup',
                    data: function () {
                        return {
                            c: ((me.Alert.ClientCode && me.Alert.ClientCode != "") ? me.Alert.ClientCode : ""),
                            d: ((me.Alert.DivisionCode && me.Alert.DivisionCode != "") ? me.Alert.DivisionCode : ""),
                            p: ((me.Alert.ProductCode && me.Alert.ProductCode != "") ? me.Alert.ProductCode : ""),
                            j: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
                            jc: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
                            a: 0
                        }
                    }
                }
            }
        });
        this.versionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetSoftwareVersionsByJobComponent',
                    data: function () {
                        return {
                            JobNumber: ((alertView.Alert.JobNumber && alertView.Alert.JobNumber > 0) ? alertView.Alert.JobNumber : 0),
                            JobComponentNumber: ((alertView.Alert.JobComponentNumber && alertView.Alert.JobComponentNumber > 0) ? alertView.Alert.JobComponentNumber : 0),
                            VersionID: (alertView.Alert.Version && alertView.Alert.Version != "") ? alertView.Alert.Version : "0"
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    //if (me.loadVersion == true) {
                    if (!alertView.Alert.JobNumber || alertView.Alert.JobNumber == 0) {
                        e.preventDefault();
                    }
                    //} else {
                    //    e.preventDefault();
                    //}
                }
            },
            requestEnd: function (e) {
                if (e.type === "read") {
                    //console.log("versionDataSource", alertView.Alert.Version);
                    if (e.response) {
                        if (e.response.length > 0) {
                            alertView.showVersion = true;
                        } else {
                            alertView.showVersion = false;
                        }
                    }
                    me.loadVersion = false;
                }
            }
        });
        this.buildDataSource = new kendo.data.DataSource({
            data: []
        });

        this.alertTemplateStatesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertTemplateStates',
                    data: function () {
                        return {
                            AlertTemplateID: alertView.Alert.AlertAssignmentTemplateID && alertView.Alert.AlertAssignmentTemplateID > 0 ? alertView.Alert.AlertAssignmentTemplateID : 0
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!alertView.Alert.AlertAssignmentTemplateID || alertView.Alert.AlertAssignmentTemplateID == 0) {
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                let me = this;
                items = e.response;
                if (items) {
                    //console.log("alertTemplateStateEmployeesDataSource:items", items);
                    //console.log("alertTemplateStateEmployeesDataSource:assigneesAsItems", me.assigneesAsItems);
                    //console.log("alertTemplateStateEmployeesDataSource:assignees", me.assignees);
                }
            }
        });
        this.alertTemplateStateEmployeesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertTemplateStateEmployees',
                    data: function () {
                        return {
                            IncludeEmployeeCode: alertView.Alert.AssignedEmployeeCode,
                            AlertTemplateID: alertView.Alert.AlertAssignmentTemplateID,
                            AlertStateID: alertView.Alert.AlertStateID,
                            ShowAll: alertView.showingAllEmployees
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!alertView.Alert.AlertAssignmentTemplateID || !alertView.Alert.AlertStateID) {
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                if (items) {
                    //console.log("alertTemplateStateEmployeesDataSource:items", items);
                    //console.log("alertTemplateStateEmployeesDataSource:assigneesAsItems", me.assigneesAsItems);
                    //console.log("alertTemplateStateEmployeesDataSource:assignees", me.assignees);
                }
            }
        });
        this.alertCategoriesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetAlertCategories',
                    data: function () {
                        return {
                            IncludeTask: (me.jobHasSchedule && !me.isRouted)
                        }
                    }
                }
            }
        });
        this.boardStateDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Desktop/Alert/GetBoardStates',
                    data: function () {
                        return {
                            BoardHeaderID: alertView.Alert.BoardHeaderID && alertView.Alert.BoardHeaderID > 0 ? alertView.Alert.BoardHeaderID : 0
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!alertView.Alert.BoardHeaderID || alertView.Alert.BoardHeaderID == 0) {
                        e.preventDefault();
                    }
                }
            }
        });
        
        this.assignmentsGridDataSource = service.getAssignmentsGridDataSource({
            transport: {
                read: {
                    data: function () {
                        return {
                            AlertID: me.Alert.ID,
                            DocumentID: me.Alert.SelectedDocumentID,
                            AllEmployees: (me.assignmentsGridShowAllEmployees == undefined || me.assignmentsGridShowAllEmployees == null) ? false : me.assignmentsGridShowAllEmployees
                        }
                    }
                }
            },
            requestStart: function (e) {
                //console.log("assignmentsGridDataSource requestStart");
                if (e.type === "read") {
                    if (!me.Alert.ID || me.Alert.ID == 0 || me.isProof == false) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                //console.log("request End", items);
                if (items && items.length > 0) {
                    var dataModel = new Array<AlertStateModel>();
                    Object.assign(dataModel, items);
                    me.assigneeGridData = dataModel;
                }

            }
        });
        this.routedAssigneesDataSource = service.getAlertTemplateStateEmployeesDataSource({
            transport: {
                read: {
                    data: function () {
                        //var showAll: boolean = false;
                        //if (me.stateChanged == true) {
                        //    showAll = me.showingAllEmployees ? me.showingAllEmployees : false
                        //} else {
                        //    showAll = true;
                        //}
                        //console.log("showAll??", showAll, me.showingAllEmployees)
                        return {
                            AlertID: ((me.Alert.ID && me.Alert.ID > 0) ? me.Alert.ID : 0),
                            AlertTemplateID: ((me.Alert.AlertAssignmentTemplateID && me.Alert.AlertAssignmentTemplateID > 0) ? me.Alert.AlertAssignmentTemplateID : 0),
                            AlertStateID: ((me.Alert.AlertStateID && me.Alert.AlertStateID > 0) ? me.Alert.AlertStateID : 0),
                            ShowAll: me.showingAllEmployees
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    if (!me.Alert.AlertAssignmentTemplateID || me.Alert.AlertAssignmentTemplateID == 0 || !me.Alert.AlertStateID || me.Alert.AlertStateID == 0 || me.isRouted == false) {
                        e.sender.data([]);
                        e.preventDefault();
                    }
                    //console.log("routedAssigneesDataSource :: requestStart")
                }
                //console.log("rStart", me.Alert.Assignees);
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                //console.log("???", me.Alert.Assignees);
                if (me.stateChanged == true) {
                    //  On change, this replaces the Alert.Assignees with the selected state's default(s)
                    me.stateChanged = false;
                    if (items) {
                        try {
                            me.Alert.Assignees = new Array<string>();
                            me.dbItemsNotInList = new Array<any>();
                            if (me.Alert.AlertStateID == me.dbAlertStateID) {
                                for (var i = 0; i < me.dbAssigneesAsItems.length; i++) {
                                    let item: any = null;
                                    item = items.find(function (itm) { return itm.Code == me.dbAssigneesAsItems[i].EmployeeCode })
                                    if (item) {
                                        //console.log("found!", me.dbAssigneesAsItems[i])
                                    } else {
                                        var dsItem = { Code: me.dbAssigneesAsItems[i].EmployeeCode, Name: me.dbAssigneesAsItems[i].Name, IsDefault: false, IsSelected: true, IsCompleted: false }
                                        me.dbItemsNotInList.push(dsItem);
                                    }
                                }
                                me.Alert.Assignees = me.dbAlertAssignees;
                            } else {
                                for (var i = 0; i < items.length; i++) {
                                    if (items[i].IsDefault == true) {
                                        me.Alert.Assignees.push(items[i].Code);
                                    }
                                }
                            }
                        } catch (e) {
                        }
                    }
                } else {
                    if (items && me.showingAllEmployees == false) {
                        window.setTimeout(() => {
                            me.dbItemsNotInList = new Array<any>();
                            for (var i = 0; i < me.dbAssigneesAsItems.length; i++) {
                                let item: any = null;
                                item = items.find(function (itm) { return itm.Code == me.dbAssigneesAsItems[i].EmployeeCode })
                                if (item) {
                                    //console.log("found!", me.dbAssigneesAsItems[i])
                                } else {
                                    var dsItem = { Code: me.dbAssigneesAsItems[i].EmployeeCode, Name: me.dbAssigneesAsItems[i].Name, IsDefault: false, IsSelected: true, IsCompleted: false }
                                    if (dsItem) {
                                        me.dbItemsNotInList.push(dsItem);
                                    }
                                }
                            }
                            window.setTimeout(() => {
                                if (me.dbItemsNotInList && me.dbItemsNotInList.length > 0) {
                                    let itemAdded: boolean = false;
                                    for (var i = 0; i < me.dbItemsNotInList.length; i++) {
                                        me.routedAssigneesDataSource.add(me.dbItemsNotInList[i]);
                                        itemAdded = true;
                                        if (me.Alert.Assignees) {
                                            if (me.Alert.Assignees.indexOf(me.dbItemsNotInList[i]) == -1) {
                                                me.Alert.Assignees.push(me.dbItemsNotInList[i].Code);
                                            }
                                        }
                                    }
                                    if (itemAdded == true) {
                                        if (me.routedAssigneesMultiSelect) {
                                            me.routedAssigneesMultiSelect.value(me.Alert.Assignees);
                                        }
                                    }
                                }
                            }, 0);
                        }, 0);
                    }
                }
                if (me.isProof == true) {
                    me.getAlertRecipients(false, true);
                }
            }
        });
        this.existingDocumentsDataSource = new kendo.data.DataSource();
        this.existingDocumentDialogActions = [
            {
                text: 'Save',
                action: function () {
                    alertView.linkExistingDocumentSaveClick();
                },
                primary: true
            },
            {
                text: 'Cancel',
                action: function () {

                }
            }
        ];
    }
}

