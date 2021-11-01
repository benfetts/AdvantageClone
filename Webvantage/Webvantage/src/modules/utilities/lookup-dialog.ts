import { inject } from 'aurelia-framework';
import { DialogController } from 'aurelia-dialog';
import { lookupWindow} from '../../services/utilities/lookupWindow'

@inject(DialogController)
export class LookupDialog {
    controller: DialogController;

    frame: any;
    data: any;

    activate(data: any) {
        this.data = data;
    }

    attached() {
        let me = this;

        me.frame = $(document.getElementById('lookup-dialog-iframe'))[0];

        me.frame.ownerDocument['GetRadWindow'] = function () {
            let BrowserWindow = new lookupWindow();

            var $doc = me.frame.contentWindow.document;

            var foo: lookupWindow = Object.getPrototypeOf(BrowserWindow);

            foo.Parent = me;
            foo.Frame = me.frame;

            return {
                BrowserWindow: foo
            };
        }

    }

    constructor(controller) {
        this.controller = controller;
    }
}
