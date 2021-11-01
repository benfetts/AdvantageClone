import { bindable, inject, customElement, observable } from 'aurelia-framework';
import { ProjectScheduleService } from 'services/project-management/project-schedule-service';
import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { DialogService } from 'aurelia-dialog';
import { UpdateAccountExecutiveDlg } from 'modules/project-management/job-jacket/update-ae-dlg';
import { UserSettingService } from 'services/utilities/user-settings-service';
import { HttpClient } from 'aurelia-http-client';
import { Webvantage } from '../../../webvantage';
import { UpdateProjectScheduleDlg } from 'modules/project-management/project-schedule/update-ps-dlg';

@inject(Router, ProjectScheduleService, DialogService, UserSettingService, 'openModule', Webvantage)
export class EditView extends ModuleBase {
    categoryTemplate = '${Status}';

    usersettingservice: UserSettingService;
    pageSize: number = 15;
    totalpages: number;

    officeCode: string;
    clientCode: string;
    divisionCode: string;
    productCode: string;
    salesClassCode: string;
    //campaignId: number;
    jobNumber: number;
    componentNumber: number;
    accountExecutiveCode: string;
    jobTypeCode: string;
    statusCode: string;
    campaignID: number;
    projectManagerCode: string;
    phaseCode: string;
    employeeCode: string;
    taskCode: string;
    roleCode: string;
    cutoffDate: Date = null;
    istemplate: boolean = false;
    userCustom1: boolean = false;

    excludeCompletedSchedules: boolean = true;
    onlyScheduleTemplates: boolean = false;
    onlyPendingTasks: boolean = false;
    excludeProjectedTasks: boolean = false;
    includeCompletedTasks: boolean = false;

    processcomplete: boolean = false;
    service: ProjectScheduleService;
    router: Router;
    dialogService: DialogService;
    data: kendo.data.DataSource;
    statusDataSource: kendo.data.DataSource;
    grid: kendo.ui.Grid;

    webvantage: Webvantage;

    hasChanges: boolean = false;

    openModule;

    function: boolean = true;
    role: boolean = false;
    team: string = 'function';

    activate(params: any) {

        let me = this;

        me.officeCode = params.OfficeCode;
        me.clientCode = params.ClientCode;   
        me.divisionCode = params.DivisionCode;
        me.productCode = params.ProductCode;
        me.salesClassCode = params.SalesClassCode;
        me.campaignID = params.CampaignID;
        me.jobNumber = params.JobNumber;
        me.componentNumber = params.ComponentNumber;
        me.accountExecutiveCode = params.AccountExecutiveCode;
        me.jobTypeCode = params.JobTypeCode;
        me.statusCode = params.StatusCode;
        me.projectManagerCode = params.ProjectManagerCode;
        me.phaseCode = params.PhaseCode;
        me.employeeCode = params.EmployeeCode;
        me.taskCode = params.TaskCode;
        me.roleCode = params.RoleCode;
        me.excludeCompletedSchedules = params.ExcludeCompletedSchedules;
        me.onlyPendingTasks = params.OnlyPendingTasks;
        me.excludeProjectedTasks = params.ExcludeProjectedTasks;
        me.includeCompletedTasks = params.IncludeCompletedTasks;
        me.onlyScheduleTemplates = params.OnlyScheduleTemplates;
        if (params.CutoffDate) {
            me.cutoffDate = new Date(parseInt(params.CutoffDate.substr(6)));
        }
    }

    showDetailView(JobNumber, JobComponentNumber) {
        this.openRadWindow("", "Content.aspx?contaid=15&j=" + JobNumber + "&jc=" + JobComponentNumber);
    }

    refreshPage(me) {
        me.search();
    }

    RebindGrid() {
        this.search();
    }

    updateStatus() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        var jcs: string = '';
        var UserCustom1: number = 0;
        var IsTemplate: boolean = false;

        if (this.grid.dataSource.total() > 0) {

            this.dialogService.open({ viewModel: UpdateProjectScheduleDlg, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {

                    var i;
                    var sels = [];
                    var grid = this.grid;
                    var selectedRows = grid.select();
                    var maxRows;

                    if (response.output.UpdateSelected == 1) {
                        if (confirm("Are you sure you want to update the selected project schedules?")) {

                            if (selectedRows.length > 0) {

                                me.showProgress(true);

                                maxRows = selectedRows.length;

                                selectedRows.each(function (idx, el) {
                                    let dataItem = grid.dataItem(el);
                                });

                                var i;
                                var a1;
                                for (i = 0; i < maxRows; i++) {
                                    a1 = selectedRows[i];
                                    let dataItem = grid.dataItem(a1);
                                    //job = dataItem.get("JobNumber");
                                    //comp = dataItem.get("JobComponentNumber");
                                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                    UserCustom1 = dataItem.get("UserCustom1")
                                    IsTemplate = dataItem.get("IsTemplate")

                                    //var data = {                       
                                    //    JobNumber: job,
                                    //    JobComponentNumber: comp
                                    //};

                                    count += 1;
                                    //console.log(jcs);
                                }

                                var data = {
                                    Jcs: jcs
                                };

                                if (UserCustom1 == 1) {
                                    if (IsTemplate == false) {
                                        client.post('ProjectManagement/ProjectSchedule/UpdateStatusCodeMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }
                                } else {
                                    client.post('ProjectManagement/ProjectSchedule/UpdateStatusCodeMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }

                            } else {
                                this.alert("No rows selected.")
                            }
                        }
                        else {
                            return;
                        }
                    }
                    else {
                        if (confirm("Are you sure you want to update the project schedules on the current page?")) {
                            me.showProgress(true);

                            var ds = grid.dataSource.data();
                            var i;

                            for (i = 0; i < ds.length; i++) {
                                let dataItem = ds[i];
                                //job = dataItem.get("JobNumber");
                                //comp = dataItem.get("JobComponentNumber");
                                jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                UserCustom1 = dataItem.get("UserCustom1")
                                IsTemplate = dataItem.get("IsTemplate")

                                //var data = {
                                //    JobNumber: job,
                                //    JobComponentNumber: comp
                                //};
                                count += 1;
                                //console.log(dataItem.get("IsTemplate"));
                            }

                            var data = {
                                Jcs: jcs
                            };

                            if (UserCustom1 == 1) {
                                if (IsTemplate == false) {
                                    client.post('ProjectManagement/ProjectSchedule/UpdateStatusCodeMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }
                            } else {
                                client.post('ProjectManagement/ProjectSchedule/UpdateStatusCodeMV', data)
                                    .then(data => {
                                        me.processcomplete = true;
                                        me.showProgress(false);
                                        me.search();
                                    });
                            }
                        }
                        else {
                            return;
                        }
                    }


                }

            });

        }

    }

    calculate() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            this.dialogService.open({ viewModel: UpdateProjectScheduleDlg, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {

                    var i;
                    var sels = [];
                    var grid = this.grid;
                    var selectedRows = grid.select();
                    var maxRows;
                    var jcs: string = '';
                    var UserCustom1: number = 0;
                    var IsTemplate: boolean = false;

                    if (response.output.UpdateSelected == 1) {
                        if (confirm("Are you sure you want to update the selected project schedules?")) {
                            if (selectedRows.length > 0) {

                                me.showProgress(true);

                                maxRows = selectedRows.length;

                                selectedRows.each(function (idx, el) {
                                    let dataItem = grid.dataItem(el);
                                });

                                var i;
                                var a1;
                                for (i = 0; i < maxRows; i++) {
                                    a1 = selectedRows[i];
                                    let dataItem = grid.dataItem(a1);
                                    //job = dataItem.get("JobNumber");
                                    //comp = dataItem.get("JobComponentNumber");
                                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                    UserCustom1 = dataItem.get("UserCustom1")
                                    IsTemplate = dataItem.get("IsTemplate")

                                    //var data = {
                                    //    JobNumber: job,
                                    //    JobComponentNumber: comp
                                    //};


                                    count += 1;
                                    //console.log(jcs);
                                }

                                var data = {
                                    Jcs: jcs
                                };

                                if (UserCustom1 == 1) {
                                    if (IsTemplate == false) {
                                        client.post('ProjectManagement/ProjectSchedule/CalculateScheduleDatesMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }
                                } else {
                                    client.post('ProjectManagement/ProjectSchedule/CalculateScheduleDatesMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }


                            } else {
                                this.alert("No rows selected.")
                            }
                        }
                        else {
                            return;
                        }
                    }
                    else {
                        if (confirm("Are you sure you want to update the project schedules on the current page?")) {
                            me.showProgress(true);
                            var ds = grid.dataSource.data();
                            var i;

                            for (i = 0; i < ds.length; i++) {
                                let dataItem = ds[i];
                                //job = dataItem.get("JobNumber");
                                //comp = dataItem.get("JobComponentNumber");
                                jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                UserCustom1 = dataItem.get("UserCustom1")
                                IsTemplate = dataItem.get("IsTemplate")

                                //var data = {
                                //    JobNumber: job,
                                //    JobComponentNumber: comp
                                //};

                                count += 1;

                            }

                            //console.log("UCS " + UserCustom1)
                            //console.log("T " + IsTemplate)

                            var data = {
                                Jcs: jcs
                            };

                            if (UserCustom1 == 1) {
                                if (IsTemplate == false) {
                                    client.post('ProjectManagement/ProjectSchedule/CalculateScheduleDatesMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }
                            } else {
                                client.post('ProjectManagement/ProjectSchedule/CalculateScheduleDatesMV', data)
                                    .then(data => {
                                        me.processcomplete = true;
                                        me.showProgress(false);
                                        me.search();
                                    });
                            }
                        }
                        else {
                            return;
                        }
                    }


                }

            });
        }
    }

    applyteam() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        var jcs: string = '';
        var UserCustom1: number = 0;
        var IsTemplate: boolean = false;
        if (this.grid.dataSource.total() > 0) {

            this.dialogService.open({ viewModel: UpdateProjectScheduleDlg, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {

                    var i;
                    var sels = [];
                    var grid = this.grid;
                    var selectedRows = grid.select();
                    var maxRows;

                    if (response.output.UpdateSelected == 1) {
                        if (confirm("Are you sure you want to update the selected project schedules?")) {
                            if (selectedRows.length > 0) {

                                this.showProgress(true);
                                maxRows = selectedRows.length;

                                selectedRows.each(function (idx, el) {
                                    let dataItem = grid.dataItem(el);
                                });

                                var i;
                                var a1;
                                for (i = 0; i < maxRows; i++) {
                                    a1 = selectedRows[i];
                                    let dataItem = grid.dataItem(a1);
                                    //job = dataItem.get("JobNumber");
                                    //comp = dataItem.get("JobComponentNumber");
                                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                    UserCustom1 = dataItem.get("UserCustom1")
                                    IsTemplate = dataItem.get("IsTemplate")


                                    count += 1;
                                    //console.log(jcs);
                                }

                                if (this.team == 'function') {
                                    var data = {
                                        Jcs: jcs,
                                        ByFunction: true
                                    };

                                    if (UserCustom1 == 1) {
                                        if (IsTemplate == false) {
                                            client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                                .then(data => {
                                                    me.processcomplete = true;
                                                    me.showProgress(false);
                                                    me.search();
                                                });
                                        }
                                    } else {
                                        client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }


                                } else {
                                    var data = {
                                        Jcs: jcs,
                                        ByFunction: false
                                    };

                                    if (UserCustom1 == 1) {
                                        if (IsTemplate == false) {
                                            client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                                .then(data => {
                                                    me.processcomplete = true;
                                                    me.showProgress(false);
                                                    me.search();
                                                });
                                        }
                                    } else {
                                        client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }


                                }


                            } else {
                                this.alert("No rows selected.")
                            }
                        }
                        else {
                            return;
                        }
                    }
                    else {
                        if (confirm("Are you sure you want to update the project schedules on the current page?")) {
                            this.showProgress(true);
                            var ds = grid.dataSource.data();
                            var i;

                            for (i = 0; i < ds.length; i++) {
                                let dataItem = ds[i];
                                //job = dataItem.get("JobNumber");
                                //comp = dataItem.get("JobComponentNumber");
                                jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                UserCustom1 = dataItem.get("UserCustom1")
                                IsTemplate = dataItem.get("IsTemplate")

                                count += 1;
                                //console.log(dataItem.get("IsTemplate"));
                            }

                            if (this.team == 'function') {
                                var data = {
                                    Jcs: jcs,
                                    ByFunction: true
                                };

                                if (UserCustom1 == 1) {
                                    if (IsTemplate == false) {
                                        client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }
                                } else {
                                    client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }


                            } else {
                                var data = {
                                    Jcs: jcs,
                                    ByFunction: false
                                };

                                if (UserCustom1 == 1) {
                                    if (IsTemplate == false) {
                                        client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }
                                } else {
                                    client.post('ProjectManagement/ProjectSchedule/SetEmployeeTeamMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }


                            }
                        }
                        else {
                            return;
                        }
                    }


                }

            });
        }
    }

    tempcomplete() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        var jcs: string = '';
        var UserCustom1: number = 0;
        var IsTemplate: boolean = false;
        if (this.grid.dataSource.total() > 0) {

            this.dialogService.open({ viewModel: UpdateProjectScheduleDlg, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {

                    var i;
                    var sels = [];
                    var grid = this.grid;
                    var selectedRows = grid.select();
                    var maxRows;

                    if (response.output.UpdateSelected == 1) {
                        if (confirm("Are you sure you want to update the selected project schedules?")) {
                            if (selectedRows.length > 0) {

                                this.showProgress(true);
                                maxRows = selectedRows.length;

                                selectedRows.each(function (idx, el) {
                                    let dataItem = grid.dataItem(el);
                                });

                                var i;
                                var a1;
                                for (i = 0; i < maxRows; i++) {
                                    a1 = selectedRows[i];
                                    let dataItem = grid.dataItem(a1);
                                    //job = dataItem.get("JobNumber");
                                    //comp = dataItem.get("JobComponentNumber");
                                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                    UserCustom1 = dataItem.get("UserCustom1")
                                    IsTemplate = dataItem.get("IsTemplate")

                                    count += 1;
                                    //console.log(jcs);
                                }

                                var data = {
                                    Jcs: jcs
                                };

                                if (UserCustom1 == 1) {
                                    if (IsTemplate == false) {
                                        client.post('ProjectManagement/ProjectSchedule/MarkTempCompleteMV', data)
                                            .then(data => {
                                                me.processcomplete = true;
                                                me.showProgress(false);
                                                me.search();
                                            });
                                    }
                                } else {
                                    client.post('ProjectManagement/ProjectSchedule/MarkTempCompleteMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }


                            } else {
                                this.alert("No rows selected.")
                            }
                        }
                        else {
                            return;
                        }
                    }
                    else {
                        if (confirm("Are you sure you want to update the project schedules on the current page?")) {
                            this.showProgress(true);
                            var ds = grid.dataSource.data();
                            var i;

                            for (i = 0; i < ds.length; i++) {
                                let dataItem = ds[i];
                                //job = dataItem.get("JobNumber");
                                //comp = dataItem.get("JobComponentNumber");
                                jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                                UserCustom1 = dataItem.get("UserCustom1")
                                IsTemplate = dataItem.get("IsTemplate")

                                count += 1;
                                //console.log(dataItem.get("IsTemplate"));
                            }

                            var data = {
                                Jcs: jcs
                            };

                            if (UserCustom1 == 1) {
                                if (IsTemplate == false) {
                                    client.post('ProjectManagement/ProjectSchedule/MarkTempCompleteMV', data)
                                        .then(data => {
                                            me.processcomplete = true;
                                            me.showProgress(false);
                                            me.search();
                                        });
                                }
                            } else {
                                client.post('ProjectManagement/ProjectSchedule/MarkTempCompleteMV', data)
                                    .then(data => {
                                        me.processcomplete = true;
                                        me.showProgress(false);
                                        me.search();
                                    });
                            }
                        }
                        else {
                            return;
                        }
                    }


                }

            });
        }
    }

    replace() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        var completed;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    completed = dataItem.get("CompletedDate");
                    //console.log(completed);
                    if (dataItem.get("UserCustom1") == 1) {
                        if (dataItem.get("IsTemplate") == false) {
                            //job = dataItem.get("JobNumber"); if (completed == null)
                            //comp = dataItem.get("JobComponentNumber");
                            jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                        }
                    } else {
                        //job = dataItem.get("JobNumber");
                        //comp = dataItem.get("JobComponentNumber");
                        jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    }

                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    count += 1;
                    //console.log(jcs);
                }

                if (jcs == "") {
                    alert("Selected Jobs are not editable.");
                } else {

                    var data = {
                        Jcs: jcs
                    };

                    client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                        .then(data => {
                            this.openRadWindowdc("Find and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=ALL", 0, 0, false, me.refreshPage, me);
                        });
                }


            } else {
                var ds = grid.dataSource.data();
                var i;

                for (i = 0; i < ds.length; i++) {
                    let dataItem = ds[i];

                    if (dataItem.get("UserCustom1") == 1) {
                        if (dataItem.get("IsTemplate") == false) {
                            //job = dataItem.get("JobNumber");
                            //comp = dataItem.get("JobComponentNumber");
                            jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                        }
                    } else {
                        //job = dataItem.get("JobNumber");
                        //comp = dataItem.get("JobComponentNumber");
                        jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    }

                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    count += 1;

                }


                if (jcs == "") {
                    alert("Selected Jobs are not editable.");
                } else {
                    var data = {
                        Jcs: jcs
                    };

                    client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                        .then(data => {
                            this.openRadWindowdc("Find and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=ALL", 0, 0, false, me.refreshPage, me);
                        });



                }



            }


        }

    }

    gantt() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var jobnumber: number = 0;
        var compnumber: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    //client.get('Utilities/CheckJobTaskCount', data)
                    //    .then(data => {
                    //        count = data.content;
                    //        console.log(count);
                    //        if (count > 0) {
                    //            jobnumber = dataItem.get("JobNumber");
                    //            compnumber = dataItem.get("JobComponentNumber");
                    //            jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    //        }
                    //    });

                    count += 1;
                    //console.log(jcs);
                }


                //this.openRadWindow("", "angulargantt.aspx", 0, 0);
                if (count == 1) {
                    this.openRadWindow('', 'angulargantt.aspx?j=' + job + '&jc=' + comp);
                } else {
                    var data = {
                        Jcs: jcs
                    };

                    client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                        .then(data => {
                            this.openRadWindow('', 'angulargantt.aspx?from=pse&jcs=' + jcs);
                        });

                }


            } else {
                var ds = grid.dataSource.data();
                var i;

                for (i = 0; i < ds.length; i++) {
                    let dataItem = ds[i];
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //}; 

                    //client.get('ProjectManagement/ProjectSchedule/CheckJobTaskCount', data)
                    //    .then(data => {
                    //        count = data.content;
                    //        if (count > 0) {
                    //            jobnumber = dataItem.get("JobNumber");
                    //            compnumber = dataItem.get("JobComponentNumber");
                    //            jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';                            
                    //        }
                    //        console.log(jcs);
                    //    });

                    count += 1;
                    //console.log(dataItem.get("IsTemplate"));
                }



                //this.openRadWindow("", "angulargantt.aspx", 0, 0);
                if (count == 1) {
                    this.openRadWindow('Gantt', 'angulargantt.aspx?j=' + job + '&jc=' + comp);
                } else {
                    var data = {
                        Jcs: jcs
                    };

                    client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                        .then(data => {
                            this.openRadWindow('Gantt', 'angulargantt.aspx?from=pse');
                        });

                }

            }


        }

    }

    calendar() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + ',' + dataItem.get("ClientCode") + ',' + dataItem.get("DivisionCode") + ',' + dataItem.get("ProductCode") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};                    

                    count += 1;
                    //console.log(jcs);
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        this.openRadWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PSMV'");
                    });


            } else {
                var ds = grid.dataSource.data();
                var i;

                for (i = 0; i < ds.length; i++) {
                    let dataItem = ds[i];
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + ',' + dataItem.get("ClientCode") + ',' + dataItem.get("DivisionCode") + ',' + dataItem.get("ProductCode") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    count += 1;
                    //console.log(jcs);
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        this.openRadWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PSMV");
                    });



            }


        }

    }

    riskanalysis() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    count += 1;
                    //console.log(jcs);
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        this.openRadWindow("", "TrafficSchedule_Status_Summary.aspx", 0, 0);
                    });


            } else {
                var ds = grid.dataSource.data();
                var i;

                for (i = 0; i < ds.length; i++) {
                    let dataItem = ds[i];
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    //var data = {
                    //    JobNumber: job,
                    //    JobComponentNumber: comp
                    //};

                    count += 1;
                    //console.log(dataItem.get("IsTemplate"));
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        this.openRadWindow("", "TrafficSchedule_Status_Summary.aspx", 0, 0);
                    });



            }


        }

    }

    settingsOptions() {
        let client = new HttpClient();
        let me = this;
        //alert("Settings/Options");
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows = selectedRows.length;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    count += 1;
                    //console.log(jcs);
                }
                //console.log(jcs);

                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        if (count == 1) {
                            this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?pm=0&j=' + job + '&jc=' + comp);
                        } else {
                            this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?count=' + count + '&pm=1');
                        }
                    });

            } else {

                var ds = grid.dataSource.data();
                var i;

                for (i = 0; i < ds.length; i++) {
                    let dataItem = ds[i];
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';
                    count += 1;
                    //console.log(dataItem.get("IsTemplate"));
                }
                console.log(jcs);

                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        if (count == 1) {
                            this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?pm=0&j=' + job + '&jc=' + comp);
                        } else {
                            this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?count=' + count + '&pm=1');
                        }
                    });




            }




        }

    }

    categoryDropDownEditor(container, options) {
        $('<input required data-text-field="Status" data-value-field="Status" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: true,
                dataSource: {
                    transport: {
                        read: {
                            url: 'Utilities/SearchStatus'
                        }
                    }
                }
            });
    }

    onSelect(e) {

        console.log(e.index);

        if (e.index == 0) {
            this.team = 'function'
        } else {
            this.team = 'role'
        }


    }

    attached() {

        let me = this;

        window.setTimeout(function () {
            me.search();
        }, 150);
    }

    getPageSize(): number {

        var pageSizegrid: number;

        this.usersettingservice.getPageSize("ProjectScheduleEditGrid").then(response => {

            this.pageSize = response.content
            return response.content;
        });

        return pageSizegrid;
    }

    onDataBound(e) {
        var PageSize = this.grid.dataSource.pageSize();
        //this.totalpages = this.grid.pager.totalPages();
        //this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        //console.log("onDB1:" + this.totalpages);
        //console.log("onDB2:" + this.pageSize);
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        if (this.pageSize != PageSize) {
            this.usersettingservice.updatePageSize(PageSize, "ProjectScheduleEditGrid");
            this.pageSize = PageSize;
        }
    }

    search() {
        let me = this;

        //this.grid.pager.page(1);
        //this.grid.dataSource.pageSize(this.pageSize)
        //this.showProgress(true);
        this.grid.dataSource.read().then(function () {
            if (me.processcomplete == true) {
                me.alert("Process complete.");
                me.processcomplete = false;
            }
            //me.showProgress(false);
        });

        //this.grid.dataSource.query({ page: 1, pageSize: this.pageSize }).then(function () {

        //});

    }

    searchredirect() {
        this.openRadWindow("Project Schedule", "modules/project-management/project-schedule/project-schedule-search");
    }

    bookmark() {
        let client = new HttpClient();
        let me = this;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            salesClassCode = '',
            campaignID = 0,
            jobNumber = 0,
            componentNumber = 0,
            accountExecutiveCode = '',
            jobTypeCode = '',
            statusCode = '',
            projectManagerCode = '',
            phaseCode = '',
            employeeCode = '',
            taskCode = '',
            roleCode = '',
            excludeCompletedSchedules = false,
            onlyPendingTasks = false,
            excludeProjectedTasks = false,
            includeCompletedTasks = false,
            onlyScheduleTemplates = false,
            cutoffDate = null;


        var data = {
            Office: me.officeCode,
            Client: me.clientCode,
            Division: me.divisionCode,
            Product: me.productCode,
            SalesClass: me.salesClassCode,
            Campaign: me.campaignID,
            JobNumber: me.jobNumber > 0 ? me.jobNumber : null,
            ComponentNumber: me.componentNumber > 0 ? me.componentNumber : null,
            AccountExecutive: me.accountExecutiveCode,
            JobTypeCode: me.jobTypeCode,
            StatusCode: me.statusCode,
            ProjectManagerCode: me.projectManagerCode,
            PhaseCode: me.phaseCode,
            EmployeeCode: me.employeeCode,
            TaskCode: me.taskCode,
            RoleCode: me.roleCode,
            ExcludeCompletedSchedules: me.excludeCompletedSchedules,
            OnlyPendingTasks: me.onlyPendingTasks,
            ExcludeProjectedTasks: me.excludeProjectedTasks,
            IncludeCompletedTasks: me.includeCompletedTasks,
            OnlyScheduleTemplates: me.onlyScheduleTemplates,
            CutOffDate: me.cutoffDate
        };

        client.post('ProjectManagement/ProjectSchedule/BookMarkPagePSEdit', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }

    print() {

        let client = new HttpClient();
        let me = this;
        var jcs: string = '';
        var job: number = 0;
        var comp: number = 0;
        var count: number = 0;
        if (this.grid.dataSource.total() > 0) {

            var i;
            var sels = [];
            var grid = this.grid;
            var selectedRows = grid.select();
            var maxRows;

            if (selectedRows.length > 0) {
                maxRows = selectedRows.length;

                selectedRows.each(function (idx, el) {
                    let dataItem = grid.dataItem(el);
                });

                var i;
                var a1;
                for (i = 0; i < maxRows; i++) {
                    a1 = selectedRows[i];
                    let dataItem = grid.dataItem(a1);
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                    count += 1;

                    //var data = {
                    //    JobComps: jcs,
                    //    JobCompCount: count
                    //};

                    //console.log(jcs);
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        if (count == 1) {

                            var url = "popReportViewer.aspx?job=" + job + "&jobcomp=" + comp + "&ms=False&Type=1&Report=TrafficDetailByJob&completed=True"

                            window.open(url, '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no');

                        } else {

                            //this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?count=' + count + '&pm=1&mode=1&jcs=' + jcs);                

                            window.open('TrafficSchedule_Print.aspx?count=' + count + '&pm=1&mode=1', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no');

                            //client.post('ProjectManagement/ProjectSchedule/PrintProjectScheduleEdit', data)
                            //    .then(data => {
                            //        console.log(data.statusCode + ' - ' + data.statusText);
                            //    });
                        }
                    });

                //this.openRadWindow("", "angulargantt.aspx", 0, 0);PrintProjectScheduleEdit



            } else {
                var ds = grid.dataSource.data();
                var i;
                var currentpage = this.grid.pager.page();
                var start = (me.pageSize * (currentpage - 1));
                var end = (me.pageSize * currentpage);

                for (i = start; i < end; i++) {
                    let dataItem = ds[i];
                    job = dataItem.get("JobNumber");
                    comp = dataItem.get("JobComponentNumber");
                    jcs += dataItem.get("JobNumber") + ',' + dataItem.get("JobComponentNumber") + '|';

                    count += 1;

                    //var data = {
                    //    JobComps: jcs,
                    //    JobCompCount: count
                    //};
                    //console.log(dataItem.get("IsTemplate"));
                }
                var data = {
                    Jcs: jcs
                };

                client.post('ProjectManagement/ProjectSchedule/SetPSMultiviewSession', data)
                    .then(data => {
                        if (count == 1) {

                            var url = "popReportViewer.aspx?job=" + job + "&jobcomp=" + comp + "&ms=False&Type=1&Report=TrafficDetailByJobcompleted=True"

                            window.open(url, '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no');

                        } else {

                            //this.openRadWindow('Print Project Schedule', 'TrafficSchedule_Print.aspx?count=' + count + '&pm=1&mode=1&jcs=' + jcs);        

                            window.open('TrafficSchedule_Print.aspx?count=' + count + '&pm=1&mode=1', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no');

                            //client.post('ProjectManagement/ProjectSchedule/PrintProjectScheduleEdit', data)
                            //    .then(data => {
                            //        console.log(data.statusCode + ' - ' + data.statusText);
                            //    });
                        }
                    });

                //this.openRadWindow("", "angulargantt.aspx", 0, 0);


            }


        }


    }

    save() {

        let me = this;
        if (this.hasChanges) {
            this.grid.saveChanges();
        }

        //let client = new HttpClient();
        //let me = this;
        //var jcs: string = '';
        //var job: number = 0;
        //var comp: number = 0;
        //var count: number = 0;
        //if (this.grid.dataSource.total() > 0) {

        //    var i;
        //    var sels = [];
        //    var grid = this.grid;
        //    var selectedRows = grid.select();
        //    var maxRows;

        //    if (selectedRows.length > 0) {
                
        //            me.showProgress(true);

        //            maxRows = selectedRows.length;
        //            console.log(" maxRows " + maxRows);
        //            selectedRows.each(function (idx, el) {
        //                let dataItem = grid.dataItem(el);
        //            });

        //            var i;
        //            var a1;
        //            for (i = 0; i < maxRows; i++) {
        //                a1 = selectedRows[i];
        //                let dataItem = grid.dataItem(a1);
        //                job = dataItem.get("JobNumber");
        //                comp = dataItem.get("JobComponentNumber");
                       
        //                var data = {
        //                    JobNumber: job,
        //                    JobComponentNumber: comp,
        //                    StatusCode: dataItem.get("StatusCode"),
        //                    StartDate: dataItem.get("startdatepicker").value(),
        //                    DueDate: dataItem.get("duedatepicker").value(),
        //                    CompletedDate: dataItem.get("completeddatepicker").value(),
        //                    GutPercent: dataItem.get("GutPercent"),
        //                    Comments: dataItem.get("Comments")
        //                };

        //                client.post('ProjectManagement/ProjectSchedule/SaveSchedules', data)
        //                    .then(data => {
        //                        count += 1;
        //                        console.log(" count " + count);
        //                        if (count == maxRows) {
        //                            console.log(" count " + count + " total " + maxRows);
        //                            me.showProgress(false);
        //                            this.alert("Save completed.");
        //                        }
        //                    });

        //                //count += 1;
        //                //console.log(jcs);
        //            }
        //        //me.showProgress(false);
        //        //this.alert("Save complete.");


        //        //this.search();

        //    } else {
                
        //        me.showProgress(true);
        //        var total = this.grid.dataSource.total();
        //        var currentpage = this.grid.pager.page();
        //        var ds = grid.dataSource.data();
        //        var start = (me.pageSize * (currentpage - 1));
        //        var end = (me.pageSize * currentpage);

        //        if (end < total) {
        //            total = end;
        //        }

        //        //console.log("start " + start + " end " + end + " total " + total); 

        //        for (i = start; i < end; i++) {
        //            let dataItem = ds[i];
        //            if (typeof dataItem != 'undefined') {
        //                job = dataItem.get("JobNumber");
        //                comp = dataItem.get("JobComponentNumber");

        //                var data = {
        //                    JobNumber: job,
        //                    JobComponentNumber: comp,
        //                    StatusCode: dataItem.get("StatusCode"),
        //                    StartDate: dataItem.get("startdatepicker").value(),
        //                    DueDate: dataItem.get("duedatepicker").value(),
        //                    CompletedDate: dataItem.get("completeddatepicker").value(),
        //                    GutPercent: dataItem.get("GutPercent"),
        //                    Comments: dataItem.get("Comments")
        //                };

        //                client.post('ProjectManagement/ProjectSchedule/SaveSchedules', data)
        //                    .then(data => {
        //                        count += 1;
        //                        //console.log(" count " + count);
        //                        if (count == total) {
        //                            //console.log(" count " + count + " total " + total);
        //                            me.showProgress(false);
        //                            this.alert("Save completed.");
        //                        }
        //                    });

        //                //count += 1;
        //                //console.log("JC " + job + "  " + comp);
        //                //console.log("count " + count)
        //            }
                        
        //        }                
                
        //        //this.search();


        //    }


        //}

    }

    //save() {

    //    let client = new HttpClient();
    //    let me = this;
    //    var jcs: string = '';
    //    var job: number = 0;
    //    var comp: number = 0;
    //    var count: number = 0;
    //    if (this.grid.dataSource.total() > 0) {

    //        var i;
    //        var sels = [];
    //        var grid = this.grid;
    //        var selectedRows = grid.select();
    //        var maxRows;

    //        if (selectedRows.length > 0) {


    //            this.showProgress(true);

    //            maxRows = selectedRows.length;

    //            selectedRows.each(function (idx, el) {
    //                let dataItem = grid.dataItem(el);
    //            });

    //            var i;
    //            var a1;
    //            for (i = 0; i < maxRows; i++) {
    //                a1 = selectedRows[i];
    //                let dataItem = grid.dataItem(a1);
    //                job = dataItem.get("JobNumber");
    //                comp = dataItem.get("JobComponentNumber");

    //                var data = {
    //                    JobNumber: job,
    //                    JobComponentNumber: comp,
    //                    StatusCode: dataItem.get("StatusCode"),
    //                    StartDate: dataItem.get("startdatepicker").value(),
    //                    DueDate: dataItem.get("duedatepicker").value(),
    //                    CompletedDate: dataItem.get("completeddatepicker").value(),
    //                    GutPercent: dataItem.get("GutPercent"),
    //                    Comments: dataItem.get("Comments")
    //                };

    //                client.post('ProjectManagement/ProjectSchedule/SaveSchedules', data)
    //                    .then(data => {

    //                    });

    //                count += 1;
    //                //console.log(jcs);
    //            }
    //            this.showProgress(false);
    //            //this.search();

    //        } else {


    //            this.showProgress(true);
    //            var ds = grid.dataSource.data();
    //            var i;

    //            for (i = 0; i < ds.length; i++) {
    //                let dataItem = ds[i];
    //                job = dataItem.get("JobNumber");
    //                comp = dataItem.get("JobComponentNumber");

    //                var data = {
    //                    JobNumber: job,
    //                    JobComponentNumber: comp,
    //                    StatusCode: dataItem.get("StatusCode"),
    //                    StartDate: dataItem.get("startdatepicker").value(),
    //                    DueDate: dataItem.get("duedatepicker").value(),
    //                    CompletedDate: dataItem.get("completeddatepicker").value(),
    //                    GutPercent: dataItem.get("GutPercent"),
    //                    Comments: dataItem.get("Comments")
    //                };

    //                client.post('ProjectManagement/ProjectSchedule/SaveSchedules', data)
    //                    .then(data => {

    //                    });

    //                count += 1;
    //                //console.log(dataItem.get("IsTemplate"));
    //            }
    //            this.showProgress(false);
    //            //this.search();


    //        }


    //    }

    //}

    constructor(router: Router, service: ProjectScheduleService, dialogService: DialogService, usersettingservice: UserSettingService, openModule, webvantage: Webvantage) {
        super();
        let me = this;
        this.router = router;
        this.service = service;
        this.dialogService = dialogService;
        this.usersettingservice = usersettingservice;
        this.openModule = openModule;
        this.webvantage = webvantage;
        this.statusDataSource = new kendo.data.DataSource();

        this.getPageSize();

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/ProjectSchedule/Search',
                    data: function () {

                        var cutoffDate: string = null;

                        if (typeof (me.cutoffDate) != 'undefined' && me.cutoffDate != null) {
                            cutoffDate = me.cutoffDate.toDateString();
                        }

                        return {
                            OfficeCode: me.officeCode,
                            ClientCode: me.clientCode,
                            DivisionCode: me.divisionCode,
                            ProductCode: me.productCode,
                            SalesClassCode: me.salesClassCode,
                            CampaignID: me.campaignID,//me.campaignCode,
                            JobNumber: me.jobNumber,
                            ComponentNumber: me.componentNumber,
                            AccountExecutiveCode: me.accountExecutiveCode,
                            JobTypeCode: me.jobTypeCode,
                            StatusCode: me.statusCode,
                            ProjectManagerCode: me.projectManagerCode,
                            PhaseCode: me.phaseCode,
                            EmployeeCode: me.employeeCode,
                            TaskCode: me.taskCode,
                            RoleCode: me.roleCode,
                            ExcludeCompletedSchedules: me.excludeCompletedSchedules,
                            OnlyPendingTasks: me.onlyPendingTasks,
                            ExcludeProjectedTasks: me.excludeProjectedTasks,
                            IncludeCompletedTasks: me.includeCompletedTasks,
                            OnlyScheduleTemplates: me.onlyScheduleTemplates,
                            DateCutoff: cutoffDate
                            //,IsTemplate: me.istemplate,
                            //UserCustom1: me.userCustom1
                        }
                    }
                },
                update: {
                    url: 'ProjectManagement/ProjectSchedule/Update',
                    type: 'POST'
                }
            },
            pageSize: this.pageSize,
            serverPaging: true,
            schema: {
                data: 'data',
                total: 'total',
                model: {
                    id: 'JobNumber',
                    fields: {
                        JobNumber: { type: 'number', editable: false },
                        JobComponentNumber: { type: 'number' },
                        OfficeName: { type: 'string' },
                        OfficeCode: { type: 'string' },
                        ClientName: { type: 'string' },
                        ClientCode: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        DivisionName: { type: 'string' },
                        ProductCode: { type: 'string' },
                        ProductDescription: { type: 'string' },
                        StartDate: { type: 'date' },
                        DueDate: { type: 'date' },
                        CompletedDate: { type: 'date' },
                        JobDescription: { type: 'string' },
                        AccountExecutiveCode: { type: 'string' },
                        AccountExecutiveName: { type: 'string', editable: false  },
                        IsTemplate: { type: 'boolean' },
                        UserCustom1: { type: 'string' },
                        Status: { type: 'string' },
                        Comments: { type: 'string' }
                    }
                }
            },
            change: function (e) {

                if (e.action === 'add') {
                    me.hasChanges = true;
                }
                else if (e.action === 'itemchange') {
                    me.hasChanges = true;
                }
                else if (e.action === 'sync') {
                    me.hasChanges = false;
                }
            }
        });

        this.statusDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/ProjectSchedule/GetStatuses'
                }
            }
            //change: function () {
            //    var data = this.data(); // or this.view();
            //    if (data && data.length === 1 && me.Alert) {
            //        me.checkSingleDivision(data[0].ClientCode);
            //    }
            //}
        });
        //this.grid.setDataSource(this.data);
    }

    dateEditor(container, options) {
        let item;

        //<input disabled.bind = "UserCustom1 == 1 && IsTemplate"; k-widget.two-way: startdatepicker; name = "startdatepicker" />

        item = $('<input style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        item.kendoDatePicker({
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy'
        });
    }

    statusDropDownEditor(container, options) {
        var item;

        //k - enabled.bind="(UserCustom1 == 1 && !IsTemplate) || UserCustom1 == 0" >


        item = $('<input data-text-field="Description" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.statusDataSource,
            change: function (e) {
                Model.Status = e.sender.text();
                Model.StatusCode = e.sender.value();
            }
        });

        item.kendoDropDownList('open');
    }

    commentEditor(container, options) {
        var item;

        let Model = options.model;

        //disabled.bind = "UserCustom1 == 1 && IsTemplate"

        item = $('<textarea class="k-textbox" name="' + options.field + '" style="width:100%;height:100%;" />')
            .appendTo(container);
    }

    edit(e) {

    }

}
