import { BindingSignaler } from 'aurelia-templating-resources';
import { bindable, inject } from 'aurelia-framework';
import * as moment from 'moment';
import { DialogController } from 'aurelia-dialog';

@inject(DialogController, BindingSignaler)
export class SessionTimeoutDlg {

    dialogController: DialogController;
    signaler: BindingSignaler;

    @bindable message: string;
    @bindable timedOut: boolean = false;
    timedOutButton: HTMLButtonElement;


    countDown() {
        var i = 30;
        var x = setInterval(function () {
            i = i * 1 - 1;
            if (i <= 0) {
                this.message = 'You have timed out.'
                this.timedOut = true;
                this.dialogController.ok();
                
            } else {
                if (i == 1) {
                    this.message = 'You will time out in one second.'
                } else {
                    this.message = 'You will time out in ' + i + ' seconds.'
                }
            }
            this.signaler.signal('need-update');
        }.bind(this), 1000);
    }
    continueClick() {
    }

    okClick() {
    }

    activate() {
        this.countDown();
    }
    constructor(dialogController: DialogController, signaler: BindingSignaler) {
        this.dialogController = dialogController;
        this.signaler = signaler;
    }
}
