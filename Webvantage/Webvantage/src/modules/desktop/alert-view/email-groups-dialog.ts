import { bindable, inject, child, observable, BindingEngine, Disposable } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { DialogController } from 'aurelia-dialog';
import { DialogService } from 'aurelia-dialog';
import { AlertModel } from 'models/desktop/alert-model';
import { AlertService } from 'services/desktop/alert-service';
import { AlertView } from './alert-view';
import { AlertRecipientModel } from 'models/desktop/alert-recipient-model';

@inject(DialogController, AlertService, DialogService, BindingEngine)

export class EmailGroupsDialog extends ModuleBase {

    controller: DialogController;
    Alert: AlertModel;
    dialogService: DialogService;
    service: AlertService;
    bindingEngine: BindingEngine;
    disposables: Array<Disposable>;
    emailGroupsTreeView: kendo.ui.TreeView;
    emailGroupsDataSource: kendo.data.HierarchicalDataSource;
    @bindable emailGroupCode: string = "";
    checkedNodes: Array<any>;

    emailGroupsTreeViewOnCheck() {
        let checkedNodes = [];
        this.getCheckedNodes(this.emailGroupsTreeView.dataSource.view(), checkedNodes);
    }
    getCheckedNodes(nodes, checkedNodes) {
        var show = false;
        for (let i = 0; i < nodes.length; i++) {
            if (nodes[i].checked === true && nodes[i].hasChildren === false) {
                let hasValue: boolean = false;
                for (let j = 0; j < checkedNodes.length; j++) {
                    if (checkedNodes[j].EmployeeCode === nodes[i].id) {
                        hasValue = true;
                        break;
                    }
                }
                if (hasValue == false) {
                    checkedNodes.push({ EmployeeCode: nodes[i].id, FullName: nodes[i].text, IsClientContact: nodes[i].isClientContact });
                }
            }
            if (nodes[i].hasChildren === true) {
                this.getCheckedNodes(nodes[i].children.view(), checkedNodes);
            }
        }
        this.checkedNodes = checkedNodes;
    }
    treeViewExpand(e) {
        //console.log("treeViewExpand", e);
    }
    saveClick() {
        this.returnOK(true);
    }
    cancelClick() {
        this.controller.cancel();
    }
    returnOK(success: boolean) {
        this.controller.ok({ Success: success, Employees: this.checkedNodes });
    }
    nodeCheckChanged() {

    }
    init() {
    }
    activate(model: any) {
        let me = this;
        this.Alert = model.Alert;
    }
    attached() {
        let me = this;
        $(document).ready(function () {
        });
    }
    collapseNotDefaultGroups() {
        let me = this;
        var allNodes;
        window.setTimeout(function () {
            if ((me.Alert.JobNumber && me.Alert.JobNumber > 0) && (me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0)) {
                me.service.getDefaultEmailGroup(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(data => {
                    if (data && data.response) {
                        me.emailGroupCode = data.response.toString();
                        if (me.emailGroupsTreeView && me.emailGroupCode && me.emailGroupCode !== "") {
                            allNodes = me.emailGroupsTreeView.dataSource.view();
                            if (allNodes && allNodes.length > 0) {
                                for (let i = 0; i < allNodes.length; i++) {
                                    if (allNodes[i].id.toString() !== me.emailGroupCode) {
                                        me.emailGroupsTreeView.collapse(me.emailGroupsTreeView.findByText(allNodes[i].id));
                                    }
                                }
                            }
                        }
                    } else {
                        //collapse all
                        allNodes = me.emailGroupsTreeView.dataSource.view();
                        if (allNodes && allNodes.length > 0) {
                            for (let i = 0; i < allNodes.length; i++) {
                                me.emailGroupsTreeView.collapse(me.emailGroupsTreeView.findByText(allNodes[i].id));
                            }
                        }
                    }
                })
            }
        }, 0);
    }
    getDefaultEmailGroup() {
        let me = this;
        //if ((me.Alert.JobNumber && me.Alert.JobNumber > 0) && (me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0)) {
        //   // me.emailGroupCode = 
        //    //this.service.getDefaultEmailGroup(this.Alert.JobNumber, this.Alert.JobComponentNumber).then((data) => {
        //    //    console.log("group????", data);
        //    //});
        //    me.service.getDefaultEmailGroup(me.Alert.JobNumber, me.Alert.JobComponentNumber).then(response => {
        //        console.log("group code??", response);
        //    })
        //}
    }
    constructor(dialogController: DialogController, service: AlertService, dialogService: DialogService, bindingEngine: BindingEngine) {
        super();
        this.controller = dialogController;
        this.bindingEngine = bindingEngine;
        this.service = service;
        this.dialogService = dialogService;
        let me = this;
        this.emailGroupsDataSource = new kendo.data.HierarchicalDataSource({
            schema: {
                model: {
                    children: "items"
                }
            },
            transport: {
                read: {
                    url: "Desktop/Alert/GetEmailGroupsTreeviewSimple",
                    data: function () {
                        return {
                            EmailGroupCode: "",
                            JobNumber: ((me.Alert.JobNumber && me.Alert.JobNumber > 0) ? me.Alert.JobNumber : 0),
                            JobComponentNumber: ((me.Alert.JobComponentNumber && me.Alert.JobComponentNumber > 0) ? me.Alert.JobComponentNumber : 0),
                            AutoGroup: false
                        }
                    }
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    //if (!me.Alert.AlertAssignmentTemplateID) {
                    //    e.sender.data([]);
                    //    e.preventDefault();
                    //}
                }
            },
            requestEnd: function (e) {
                //console.log("rcpt??", me.Alert.Recipients);
                var items = [];
                items = e.response;
                if (items) {
                    let checkedNodes = [];
                    for (var i = 0; i < items.length; i++) {
                        //console.log("items[" + i + "]", items[i]);
                        for (var k = 0; k < items[i].items.length; k++) {
                            //console.log("requestEnd:items:", items[i]);
                            var preChecked = false;
                            if (me.Alert.Recipients) {
                                if (me.Alert.Recipients.includes(items[i].items[k].id) == true) {
                                    preChecked = true;
                                    //console.log("found!", items[i].items[k].id);
                                }
                            }
                            if (items[i].checked == true || preChecked == true) {
                                if (items[i].items[k].checked == true || preChecked == true) {
                                    checkedNodes.push({ EmployeeCode: items[i].items[k].id, FullName: items[i].items[k].text, IsClientContact: items[i].items[k].isClientContact });
                                    //console.log("     PRE CHECKED items[" + i + "].items[" + k + "]", items[i].items[k]);
                                }
                            } else {
                                //console.log("     NOT PRE CHECKED items[" + i + "].items[" + k + "]", items[i].items[k]);
                            }
                        }
                    }
                    me.checkedNodes = checkedNodes;
                    me.collapseNotDefaultGroups();
                } else {
                    me.collapseNotDefaultGroups();
                }
            }
        });
   }

}
