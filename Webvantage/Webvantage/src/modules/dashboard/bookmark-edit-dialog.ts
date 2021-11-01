import { bindable, inject } from 'aurelia-framework';
import { DashboardService } from 'services/dashboard/dashboard-service';
import { ModuleBase } from 'modules/base/module-base';
import { BookmarkModel } from 'models/utilities/bookmark-model';
import { DialogController } from 'aurelia-dialog';

@inject(DashboardService, DialogController)
export class BookmarkEditDialog extends ModuleBase {

    @bindable bookmarkId: number;
    @bindable showPostPeriodWarning: boolean;
    @bindable showButtonsForOldPages: boolean;
    @bindable canAdd: boolean = true;
    @bindable model: BookmarkModel;
    
    service: DashboardService;
    controller: DialogController;

    name: string;
    description: string;
    bookmarks: Array<any>;    
    
    save() {
        if (!this.canAdd) {
            // no message needed... should be shown on the page
            return false;
        }
        //if (this.isCommentRequired === true && (!this.comment  || this.comment == undefined || this.comment == '')) {
        //    this.alert('Please enter a comment');
        //    return false;
        //}
        //if (!this.entryDate) {
        //    this.alert('Please select a date.');
        //    return false;
        //}
        console.log("save " + this.bookmarkId);
        console.log("save " + this.name);
        console.log("save " + this.description);
        return this.service.SaveBookmark(this.bookmarkId, this.name, this.description).then(response => {
            if (response.content.Success === false && response.content.Message) {
                this.alert(response.content.Message);
            } else {
                //Need to rework the refresh of the timesheet and objects when time is added.
                //wvbridge.RefreshTimesheetWindows();
            }
            return response;
        });
    }

    clear() {
       
    }
    addClick() {
        let result = this.save();
        if (typeof result === 'boolean') {
            if (result) {
                this.closeAndRefreshTimeWindows();
            }
        } else {
            result.then(response => {
                this.closeAndRefreshTimeWindows();
            });
        }
    }
    closeAndRefreshTimeWindows() {
        if (window.parent) {
            //try {
            //    wvbridge.RefreshTimesheetWindows();
            //} catch (ex) {
            //}
           // wvbridge.CloseWindow();
            this.controller.ok();
        }
    }
    cancelClick() {
        this.controller.cancel();
    }
    activate(params: any) {
        console.log("activate " + params);
        if (params.bookmarkID) {
            this.bookmarkId = params.bookmarkID;
            console.log("activate " + this.bookmarkId);
        }
    }
    attached() {
        let me = this;
        this.init();        
        $(document).ready(function () {
            //me.entryDateEditor.element.change(function () {
            //    me.entryDateEditorOnChange();
            //});
        });
        (<any>window).MvcSaveBridge = function() {
            return me.save();
        }
    }
    init() {
        //this.clear();
        this.name = null;
        this.description = null;
        console.log("initBMID " + this.bookmarkId);
        this.service.initBookmarkEdit(this.bookmarkId).then(response => {
            this.name = response.content.Name;
            this.description = response.content.Description;
            console.log("initBM " + this.name);
        });
    }
    
    constructor(service: DashboardService, dialogController: DialogController) {
        super();
        this.service = service;
        this.controller = dialogController;
        let me = this;
    }

}
