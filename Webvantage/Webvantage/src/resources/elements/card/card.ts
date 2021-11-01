import { customElement, bindable, observable } from 'aurelia-framework';
import { CampaignDisplayTemplate } from '../display-templates/campaign/campaign-display-template';
import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject } from 'aurelia-framework';
import { DialogService } from 'aurelia-dialog';
import { NewWorkItemTimeDialog } from 'modules/project-management/agile/new-work-item-time-dialog';
import { Webvantage } from '../../../webvantage';
import { AlertService } from 'services/desktop/alert-service';
import { AlertModel } from 'models/desktop/alert-model';
import { Dashboard } from 'modules/dashboard/dashboard';
import { DashboardService } from 'services/dashboard/dashboard-service';
import { HttpClient } from 'aurelia-http-client';

//Load types:
// 0 = Alerts
// 1 = Assignment
// 3 = Reviews

@inject(DialogService, 'openModule', Webvantage, AlertService, Dashboard, DashboardService)
@customElement('wv-card')
export class Card extends ModuleBase {

    @bindable alertid: number;
    @bindable sprintid: number;
    @bindable title: string;
    @bindable details: Array<string>;
    @bindable priority: number;
    @bindable jobnumber: number;
    @bindable startdate: Date;
    @bindable duedate: Date;
    @bindable timedue: string;
    @bindable jobdescription: string;
    @bindable jobcomponentnumber: number;
    @bindable jobcomponentdescription: string;
    @bindable taskfunctiondescription: string;
    @bindable startdatestring: string;
    @bindable duedatestring: string;
    @bindable alerttype: string;
    @bindable alerttypeid: number;
    @bindable alerttypedescription: string;
    @bindable dueDateCssName: string = "";
    @bindable dueDateTitle: string = "";
    @bindable startDateCssName: string = "";
    @bindable startDateTitle: string = "";
    @bindable typeCSSName: string = "";
    @bindable alertcategory: string;
    @bindable alertcategoryid: number;
    @bindable alertcategorydescription: string;
    @bindable indicator: string;
    @bindable isalertassignment: string;
    @bindable tasksequencenumber: number;
    @bindable isworkitem: string;
    @bindable loadtype: number;
    @bindable projectid: number;
    @bindable reviewid: number;
    @bindable estimatenumber: number;
    @bindable estimatecomponentnumber: number;
    @bindable alerttemplateid: number;
    @bindable alertstateid: number;
    @bindable alertstatename: string;
    @bindable taskstatus: string;
    @bindable taskstatusdescription: string;
    @bindable clientname: string = "";

    @bindable AutoClose: boolean;
    @bindable showchecklistsoncards: string;
    @bindable showstate: string;
    @bindable DetailsExpanded: boolean;
    @bindable checklisttotal: number;
    @bindable checklistcomplete: number;
    @bindable tempcompletestring: string;
    @bindable ismytasktempcomplete: boolean;
    @bindable isProofingActive: boolean = false;
    @bindable isConceptShareActive: boolean = false;
    @bindable isProof: boolean = false;
    @bindable isConceptShareReview: boolean = false;
    @bindable isClientPortal: boolean;
    @bindable isread: boolean;
    @bindable canAddJob: boolean;
    @bindable hasAccessJob: boolean;
    @bindable reviewimage: string;
    @bindable isautoroute: boolean = false;
    @bindable isTimesheetActive: boolean = true;
    @bindable reviewItemText: string = "Proofs";
    @bindable reviewItemTextSingular: string = "proof";

    ShowCL: boolean = false;

    assignmentDialog: kendo.ui.Dialog;
    deleteDialog: kendo.ui.Dialog;
    chatDialog: kendo.ui.Dialog;
    stopwatchDialog: kendo.ui.Dialog;
    timeDialog: kendo.ui.Dialog;

    dialogService: DialogService;
    webvantage: Webvantage;
    service: AlertService
    dashboardservice: DashboardService;
    openModule;
    dashboard: Dashboard;
    styleObject: any;

    @observable Alert: AlertModel;

    deleteAssignmentClick(mark: number) {
        //console.log("value: " + this.details);
        let me = this;

        this.service.getAlertView(this.alertid, this.sprintid).then(response => {
            var alertModel = new AlertModel;
            Object.assign(alertModel, response.content.Alert);
            Object.assign(this, response.content);
            this.Alert = alertModel;
            //console.log("wtf", this.Alert)
            //console.log("canUpdate", this.canUpdate)
            //console.log("DueDateLocked", this.Alert.DueDateLocked)
            //console.log("card.ts:deleteAssignmentClick:me.loadtype:", me.loadtype);

            // Large bodies (with images) can cause action to fail
            // That text is not needed for this action anyway so null it out.
           if (this.Alert) {
                this.Alert.Body = null;
                this.Alert.EmailBody = null;
           }
            if (me.loadtype == 1) {
                if (this.Alert.AlertCategoryDescription == "Task") {
                    if (mark == 0) {
                        this.service.tempComplete(this.Alert).then(response => {
                            if (response.content) {
                                this.webvantage.refreshDashboardAssignments();
                                if (response.content.Success == true && response.content.ShowFullyCompletePrompt == true) {
                                    this.showInfoNotification("Task will be completed if you were the last employee to temp complete");
                                }
                            }                            
                        });
                    } else {
                        this.service.unTempComplete(this.Alert).then(() => {
                            this.webvantage.refreshDashboardAssignments();
                        });
                    }                    
                } else {
                    this.service.dismissAlertComplete(this.Alert).then(() => {
                        this.webvantage.refreshDashboardAssignments();
                    });
                }
            } else if (me.loadtype == 0) {
                this.service.dismissAlert(this.Alert).then(() => {
                    this.webvantage.refreshDashboardAlerts();
                });
            } else if (me.loadtype == 3) {
                this.service.syncReview(this.Alert).then(() => {
                    this.webvantage.refreshDashboardReviews();
                });
            }
        }).then(() => {
        });
    }
    refreshAlerts(me) {
        me.dashboard.refreshDashboard(1);
    }
    assignmentClick() {
        if (this.alertcategorydescription == "Task") {
            this.webvantage.OpenDialog("Employees", "TrafficSchedule_TaskEmployees.aspx?From=pb&j=" + this.jobnumber + "&jc=" + this.jobcomponentnumber + "&s=" + this.tasksequencenumber, 600, 700, this.refreshAlerts,this);
        } else {
            this.webvantage.OpenDialog("Assignment", "Desktop_Reassign?AlertID=" + this.alertid, 500, 500, this.refreshAlerts, this);
        }

    }
    commentsClick() {
        //this.webvantage.OpenDialog("Comments", "Alert_Comments.aspx?AlertId=" + this.alertid, 500, 700);
        this.webvantage.OpenDialog("Comments", "Desktop_CommentView?AlertID=" + this.alertid, 430, 700);
    }
    addTimeClick() {
        this.webvantage.OpenDialog("Add Time", "Employee/Timesheet/Entry?a=" + this.alertid + "&j=" + this.jobnumber + "&jc=" + this.jobcomponentnumber + "&s=" + this.tasksequencenumber, 575, 630);
    }
    stopwatchClick() {
        if (this.jobnumber > 0 && this.jobcomponentnumber > 0) {
            this.service.getAlertView(this.alertid, this.sprintid).then(response => {
                var alertModel = new AlertModel;
                Object.assign(alertModel, response.content.Alert);
                Object.assign(this, response.content);
                this.Alert = alertModel;
                this.service.hasStopwatch("").then(response => {
                    if (response.content) {
                        if (response.content.StopwatchIsRunning == true) {
                            if (confirm("There is a stopwatch already running.\nStop it and start a new stopwatch?") == true) {
                                this.startStopwatch();
                            } else {
                                return false;
                            }
                        } else {
                            this.startStopwatch();
                        }
                    }
                })

            });

        }
    }
    updatecardpriority(priority) {
        let client = new HttpClient();
        var data = {
            AlertID: this.alertid,
            Priority: priority
        }
        client.post("Dashboard/UpdateCardPriority", data).then(data => {            
            if (this.loadtype == 0) {
                this.webvantage.refreshDashboardAlerts();
            } else if (this.loadtype == 1) {
                this.webvantage.refreshDashboardAssignments();
            } else if (this.loadtype == 2) {
                this.webvantage.refreshDashboardAssignments();
            } else if (this.loadtype == 3) {
                this.webvantage.refreshDashboardReviews();
            } else if (this.loadtype == 4) {
                this.webvantage.refreshDashboardAppointments()
            } else if (this.loadtype == 5) {
                this.webvantage.refreshDashboardBookmarks();
            } else if (this.loadtype == 6) {
                this.webvantage.refreshDashboardTime();
            }
        });
    }
    startStopwatch() {
        this.service.startStopwatch(this.Alert).then(response => {
            if (response.content.Success === true) {
                //wvbridge.OpenStopwatchNotify();
                this.webvantage.OpenDialog("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 350, 520);
                this.webvantage.checkForStopwatch();
                this.webvantage.stopwatch == true;
            } else if (response.content.Message) {
                this.alert(response.content.Message);
            }
        });
    }
    getCssForAlertType(alertType) {
        var cssClass = "";
        //if (alertType) {
        //    if (alertType == "A") {
        //        cssClass = "standard-blue";
        //    }
        //}
        return cssClass;
    }
    getCssForDatePicker(theDate, startOrDue) {
        let me = this;
        var isOverdue: boolean;
        var cssClass = "";
        var dateText = "";
        isOverdue == false;
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                isOverdue == true;
                cssClass = 'task-due-overdue';
                dateText = "Overdue";
            }
            //else if (theDate.valueOf() === today.valueOf()) {
            //    cssClass = 'standard-orange';
            //    dateText = "Due today";
            //} else if (weekends.indexOf(theDate.getDay()) > -1) {
            //    cssClass = 'standard-light-grey';
            //    dateText = "Due on weekend";
            //} else if (theDate > today && theDate < weekOut) {
            //    cssClass = 'standard-yellow';
            //    dateText = "Due in a week"
            //}
        }
        if (startOrDue == 'due') {
            me.dueDateCssName = cssClass;
        } else {
            me.startDateCssName = cssClass;
        }
        return cssClass;
    }

    attached() {
        let me = this;
        if (me.duedate) {
            me.dueDateCssName = me.getCssForDatePicker(me.duedatestring, "due");
        }
        //if (me.alerttype) {
        //    me.typeCSSName = me.getCssForAlertType(me.alerttype);
        //}        
        //console.log("tempcompletestring??", this.tempcompletestring)
        if (this.tempcompletestring == undefined) {
            this.styleObject = {
                'display': 'inline-block'
            };
        } else {
            if (this.tempcompletestring != '') {
                this.styleObject = {
                    'display': 'inline-block',
                    'text-decoration': 'line-through'
                };
            } else {
                this.styleObject = {
                    'display': 'inline-block'
                };
            }
        }

        //this.getAlert(this.alertid, this.sprintid);
        //this.getAlertSettings();
        
        me.isProofingActive = me.dashboard.isProofingActive;
        me.isConceptShareActive = me.dashboard.isConceptShareActive;
        //console.log("card", me.isProofingActive, me.isConceptShareActive);
        me.isClientPortal = me.dashboard.isClientPortal;
        me.isTimesheetActive = me.dashboard.isTimesheetActive;
        me.canAddJob = me.dashboard.canAdd;
        me.hasAccessJob = me.dashboard.isBlocked;

        if (me.isProofingActive == false && me.isConceptShareActive == true) {

            me.reviewItemText = "Reviews";

        } else {

            me.reviewItemText = "Proofs";

        }
        if (me.alertcategoryid == 79) {

            me.reviewItemTextSingular = "proof";
            me.isProof = true;

        } else if (me.alertcategoryid = 67) {

            me.reviewItemTextSingular = "review";
            me.isConceptShareReview = true;

        }
        //console.log("type?", me.alerttypeid);
        //console.log("cat?", me.alertcategoryid);
        //console.log("indicator?", me.indicator);
        //console.log("text?", me.reviewItemText);
        //console.log("canAddcard " + me.canAddJob);
        //try {
        //    if (me.reviewid && me.reviewid > 0) {
        //        this.service.getReviewThumbnailString(this.alertid).then(response => {
        //            ////console.log("image:response", response.response);
        //            me.reviewimage = response.response.toString();
        //            ////me.reviewimage = 'data: image/png; base64,' + response.response;
        //            //if (!me.reviewimage || me.reviewimage == "") {
        //            //    me.reviewimage = "Images/Icons/Grey/256/document_empty.png";
        //            //} else {
        //            //    console.log("IMAGE!", me.reviewimage);
        //            //}
        //        }).then(() => {
        //        });
        //    }
        //} catch (e) {
        //}

    }

    openassignment() {
        //let me = this; 
        //console.log(this.isworkitem);
        //console.log("openassignment", this.alertcategoryid, this.loadtype);
        if (this.loadtype * 1 == 3 && this.alertcategoryid * 1 != 79) {
            this.openModule(this.title, "Alert_DigitalAssetReview.aspx?a=" + this.alertid);
        } else {
            if (!this.sprintid) {
                this.sprintid = 0;
            }
            //console.log("openassignment", this.isworkitem, this.isalertassignment);
            if (this.isworkitem == "true") {
                this.openModule(this.title, "Desktop_AlertView?AlertID=" + this.alertid + "&SprintID=" + this.sprintid + "&FromBoard=0");
            } else {
                //console.log("openassignment:alertcategorydescription", this.alertcategorydescription);
                if (this.alertcategorydescription.indexOf("PO Approval") > -1) {
                    this.openModule(this.title, "Alert_View.aspx?AlertID=" + this.alertid + "&openasassign=false");
                } else {
                    this.openModule(this.title, "Desktop_AlertView?AlertID=" + this.alertid + "&SprintID=" + this.sprintid + "&FromBoard=0");
                }
                //console.log("openassignment:alertcategoryid", this.alertcategoryid);
                //console.log("openassignment:alertcategorydescription", this.alertcategorydescription);
                //console.log("openassignment:alerttypedescription", this.alerttypedescription);
                //if (this.isalertassignment == "true") {
                //    this.openModule(this.title, "Desktop_AlertView?AlertID=" + this.alertid + "&SprintID=" + this.sprintid + "&FromBoard=0");
                //} else {
                //    this.openModule(this.title, "Alert_View.aspx?AlertID=" + this.alertid + "&openasassign=false");
                //}
            }
        }
    }

    openNew(Type: number) {
        this.service.getAlertView(this.alertid, this.sprintid).then(response => {
            var alertModel = new AlertModel;
            Object.assign(alertModel, response.content.Alert);
            Object.assign(this, response.content);
            this.Alert = alertModel;
            //console.log("wtf", this.Alert)    
            //console.log("openNew " + alertModel.JobComponentNumber);
            if (Type == 0) {
                this.webvantage.OpenDialog('Alert', 'Alert_New.aspx?caller=jobtemplate&f=1&jt=1&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber, 0, 1000);
            }
            if (Type == 1) {
                // half assed this.webvantage.OpenDialog('Assignment', 'Desktop_NewAssignment?caller=jobtemplate&f=1&jt=1&assn=1&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber, 0, 1250);
                var url = 'Desktop_NewAssignment?caller=jobtemplate&f=1&jt=1&assn=1';

                url += alertModel.ClientCode ? '&c=' + alertModel.ClientCode : '';
                url += alertModel.DivisionCode ? '&d=' + alertModel.DivisionCode : '';
                url += alertModel.ProductCode ? '&p=' + alertModel.ProductCode : '';
                url += alertModel.JobNumber ? '&j=' + alertModel.JobNumber : '';
                url += alertModel.JobComponentNumber ? '&jc=' + alertModel.JobComponentNumber : '';


                this.webvantage.OpenDialog('Assignment', url, 0, 1250);
            }
            if (Type == 2) {
                var url = 'Desktop_NewAssignment?caller=review&f=1&jt=1&assn=1';
                url += alertModel.ClientCode ? '&c=' + alertModel.ClientCode : '';
                url += alertModel.DivisionCode ? '&d=' + alertModel.DivisionCode : '';
                url += alertModel.ProductCode ? '&p=' + alertModel.ProductCode : '';
                url += alertModel.JobNumber ? '&j=' + alertModel.JobNumber : '';
                url += alertModel.JobComponentNumber ? '&jc=' + alertModel.JobComponentNumber : '';
                this.webvantage.OpenDialog('Proof', url, 0, 1250);
            }
            if (Type == 3) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.webvantage.OpenDialog('New Job', 'JobTemplate_New.aspx?j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber, 0, 1200);
                }
            }
            if (Type == 4) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('Job', 'Content.aspx?PageMode=Edit&NewComp=0&contaid=10&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber + '&f=2');
                }
            }
            if (Type == 5) {
                this.webvantage.OpenDialog('Add Time', 'Employee/Timesheet/Entry?j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber + '&s=' + alertModel.TaskSequenceNumber + '&a=' + alertModel.ID, 600, 600);
                //this.dialogService.open({ viewModel: NewWorkItemTimeDialog, model: { alertID: this.alertid } }).whenClosed(response => {
                //    if (!response.wasCancelled) {
                //        this.webvantage.refreshDashboardTime();
                //    }
                //});
            }
            if (Type == 6) {
                this.service.startStopwatch(this.Alert).then(response => {
                    if (response.content.Success === true) {
                        //wvbridge.OpenStopwatchNotify();
                        this.webvantage.OpenDialog("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 475, 500);
                        this.webvantage.stopwatch == true;
                    } else if (response.content.Message) {
                        this.alert(response.content.Message);
                    }
                });
            }
            if (Type == 7) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=1&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                } else {

                    var width = 780;
                    var height = 800;
                    var left = 150;
                    var top = 150;
                    var params = 'width=' + width + ', height=' + height;
                    params += ', top=' + top + ', left=' + left;
                    params += ', directories=no';
                    params += ', location=no';
                    params += ', menubar=no';
                    params += ', resizable=yes';
                    params += ', scrollbars=auto';
                    params += ', status=no';
                    params += ', toolbar=no';
                    let newwin = window.open('Alert_Html.aspx?a=' + this.alertid, 'PopLookup', params);

                    setTimeout(function () {
                        newwin.focus();
                    }, 1);                    
                }
            }
            if (Type == 8) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=2&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            if (Type == 9) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=5&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            if (Type == 10) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('Email', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=3&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            if (Type == 11) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=4&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Alerts
            if (Type == 12) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=1&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Documents
            if (Type == 13) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=3&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Creative Brief
            if (Type == 14) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=2&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Job Specs
            if (Type == 15) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=7&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Job Version
            if (Type == 16) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=11&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Estimate
            if (Type == 17) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {

                    if (this.estimatenumber > 0) {
                        this.openModule('', 'Content.aspx?contaid=4&JT=0&newEst=edit&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber + '&e=' + this.estimatenumber + '&ec=' + this.estimatecomponentnumber);
                    } else {
                        this.openModule('', 'Content.aspx?contaid=4&JT=0&newEst=job&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                    }

                    
                }
            }
            //Schedule
            if (Type == 18) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=15&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Boards
            if (Type == 19) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=25&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //QVA
            if (Type == 20) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=13&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Purchase Orders
            if (Type == 21) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=12&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Snapshot
            if (Type == 22) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'TrafficSchedule_ProjectSummary.aspx?j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
            //Reviews
            if (Type == 23) {
                if (alertModel.JobNumber > 0 && alertModel.JobComponentNumber > 0) {
                    this.openModule('', 'Content.aspx?contaid=24&j=' + alertModel.JobNumber + '&jc=' + alertModel.JobComponentNumber);
                }
            }
        }).then(() => {
            //this.getAlertRecipients();
            //this.getAlertAttachments();
            //this.getAlertChecklists();
            //this.getSoftwareVersions();
            //this.getSoftwareBuilds();
            //this.getAlertSettings();
            //this.checkDoesAlertHaveBoard();
            //this.getDefaultSubjectType();
        });



    }

    // getters
    getAlert(alertID: number, sprintID: number) {
        //console.log("getAlert", alertID, sprintID);
        if (!sprintID || sprintID == undefined || sprintID == null) {
            sprintID = 0;
        }
        sprintID = sprintID * 1;
        this.service.getAlertView(alertID, sprintID).then(response => {
            var alertModel = new AlertModel;
            Object.assign(alertModel, response.content.Alert);
            Object.assign(this, response.content);
            this.Alert = alertModel;
            //this.isRouted = this.Alert.AlertAssignmentTemplateID > 0 ? true : false;
            //this.hasBoard = response.content.HasBoard
            //this.assignmentChanged = false;
            //this.DueDateIsLocked = this.canUpdate;
            //if (this.Alert.IsTask == true && this.Alert.DueDateLocked == true) {
            //    this.DueDateIsLocked = true;
            //}
            //if (this.descriptionEditor) {
            //    this.descriptionEditor.value(this.Alert.EmailBody);
            //}
            //this.checkBuildEnabled();
            //this.getCssForDatePicker(this.Alert.StartDate, 'start');
            //this.getCssForDatePicker(this.Alert.DueDate, 'due');
            //this.setupDueDate();
            //if (this.alertTemplateStatesListBox) {
            //    this.alertTemplateStatesListBox.enable('.k-item', !this.Alert.IsCompleted);
            //}
            //if (this.Alert.AlertLevel == 'BRD') {
            //    this.isTaskAlert = true;
            //}
            //if ((this.Alert.JobNumber && this.Alert.JobNumber > 0) &&
            //    (this.Alert.JobComponentNumber && this.Alert.JobComponentNumber > 0)) {
            //    this.isJobComponentLevel = true;
            //} else {
            //    this.isJobComponentLevel = false;
            //}
            if (this.Alert.AssignedEmployeeCode && this.Alert.AssignedEmployeeCode.toLowerCase() == 'unassigned') {
                this.Alert.AssignedEmployeeCode = this.Alert.AssignedEmployeeCode.toUpperCase();
            }
            //console.log("wtf", this.Alert.Build)
            //console.log("canUpdate", this.canUpdate)
            //console.log("DueDateLocked", this.Alert.DueDateLocked)
            
        }).then(() => {
            //this.getAlertRecipients();
            //this.getAlertAttachments();
            //this.getAlertChecklists();
            //this.getSoftwareVersions();
            //this.getSoftwareBuilds();
            this.getAlertSettings();
            //this.checkDoesAlertHaveBoard();
            //this.getDefaultSubjectType();
        });
    }

    getAlertSettings() {
        //console.log("getAlertSettings")
        return this.service.getAlertSettings().then(response => {
            if (response.content) {
                //this.AutoClose = response.content.AutoClose;
                //this.ShowChecklistsOnCards = response.content.ShowChecklistsOnCards;
                //this.DetailsExpanded = response.content.DetailsExpanded;
                //this.WidgetLayout = new Array<string>();
                //Object.assign(this.WidgetLayout, response.content.WidgetLayout);
                //console.log(this.AutoClose)
                //console.log(this.ShowChecklistsOnCards)
                //console.log(this.DetailsExpanded)
                //console.log(this.WidgetLayout)
            }
        }).then(() => {
            //this.sortWidgets();
        });
    }

    feedbackSummary() {
        if (this.isConceptShareReview == true) {
            this.showProgress(true);
            this.service.feedbackSummaryLoad(this.projectid, this.reviewid).then(response => {
                this.showProgress(false);
                if (response.content.Success === true) {
                    this.showProgress(false);
                    console.log("feedbackSummary:response", response);
                    if (response.content.Success && response.content.Success) {
                        window.location.href = 'Desktop/Alert/DownloadFeedbackSummary?Key=' + response.content.Key;
                    }
                } else {
                    // there was a problem adding
                }
            }).then(() => {
                this.showProgress(false);
            });
        } else if (this.isProof == true) {
            let exists = false;
            let errorMessage = "";
            var data = {
                AlertID: this.alertid
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
        } else {
            this.alert("Feedback Summary is not available for this type of assignment.")
        }

        //var data = {.ProjectID = this.projectid, .ReviewID = this.reviewid};
        //let exists = false;
        //this.showProgress(true);
        //$.post({
        //    url: 'Desktop/Alert/FeedbackSummaryLoad',
        //    data: data
        //})
        //.then(response => {
        //    this.showProgress(false);
        //    if (response.Exists && response.Exists === true) {
        //        exists = true;
        //        window.location.href = 'Desktop/Alert/DownloadAttachment?Key=' + response.Key;
        //    }
        //})
        //.always(() => {
        //    this.showProgress(false);
        //    if (!exists) {
        //        this.alert('There was a problem downloading the attachment. Please contact software support.');
        //    }

        //});

    }

    constructor(dialogService: DialogService, openModule, webvantage: Webvantage, service: AlertService, dashboard: Dashboard, dashboardservice: DashboardService) {
        super();

        this.priority = 3;

        this.dialogService = dialogService;
        this.webvantage = webvantage;
        this.openModule = openModule;
        this.service = service;
        this.dashboardservice = dashboardservice;
        this.dashboard = dashboard;             

    }

}
