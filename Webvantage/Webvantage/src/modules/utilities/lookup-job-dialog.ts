import { LookupJob } from './lookup-job';
import { inject, bindable } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController)
export class LookupJobDialog {

    controller: DialogController;
    lookupJob: LookupJob;

    selectClick() {

    }
    activate(model: any) {

    }
    cancelClick() {
        this.controller.cancel();
    }
    constructor(dialogController: DialogController) {
        this.controller = dialogController;
        this.controller.settings.centerHorizontalOnly = false;
        this.controller.settings.overlayDismiss = false;
    }

}
