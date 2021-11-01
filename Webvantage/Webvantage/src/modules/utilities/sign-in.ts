import { ModuleBase } from 'modules/base/module-base';
import { bindable, inject } from 'aurelia-framework';
import * as moment from 'moment';
import { ApplicationService } from 'services/application-service';
import { DialogService } from 'aurelia-dialog';

@inject(ApplicationService, DialogService)
export class SignIn extends ModuleBase {

    service: ApplicationService;

    attached() {
    }
    activate(params: any) {
        window.location.href = "SignIn.aspx";
    }
    constructor(service: ApplicationService, dialogService: DialogService) {
        super();

    }

}
