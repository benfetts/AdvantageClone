import { ModuleBase } from 'modules/base/module-base';
import { AgencyTimesheetSettingService } from 'services/maintenance/agency/timesheet-settings-service';
import { inject, bindable } from 'aurelia-framework';
import { AgencyTimesheetSettingsModel } from 'models/maintenance/agency-timesheet-settings-model';

@inject(AgencyTimesheetSettingService)
export class Status extends ModuleBase {

    // properties
    service: AgencyTimesheetSettingService;
    model: AgencyTimesheetSettingsModel;
    resizeTimeout: number;

    // methods

    save() {

    }

 
    onInputFocus(e) {

        //get the input
        var input = e.currentTarget;

        //select the value
        setTimeout(function () {
            input.select();
        }, 25);
       
    }

 

    activate(model: AgencyTimesheetSettingsModel) {

        this.model = model;

    }

    attached() {
        let me = this;

        $(document).ready(function () {
            $(window).resize(function () {
                if (me.resizeTimeout) {
                    window.clearTimeout(me.resizeTimeout);
                }
                me.resizeTimeout = window.setTimeout(function () {
                   
                }, 50);
            });


        });
        

        window.setTimeout(function () {
                
            }, 0);


    }

    constructor(Service: AgencyTimesheetSettingService) {
        super();
        this.service = Service;
        
        let me = this;

        

    }

}


