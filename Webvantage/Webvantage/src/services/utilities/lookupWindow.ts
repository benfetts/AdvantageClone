export class lookupWindow {
    parameters: any;
    Frame: any;
    Parent: any;

    Close(controlsToSet: string) {
        var dlgDiv = $("#LookUpDlgDiv");
        var dlgParentFrame = dlgDiv.data('parentFrame');
        var doc = dlgParentFrame.contentDocument ? dlgParentFrame.contentDocument : dlgParentFrame.contentWindow.document;
        var CallingWindowContent = dlgParentFrame.contentWindow;

        controlsToSet = controlsToSet.split('CallingWindowContent.document').join('doc');
        try {
            eval(controlsToSet);
        }
        catch (e) {
            var frame = doc.getElementById('ctl00_ContentPlaceHolderMain_IFrameContent');

            doc = (<HTMLIFrameElement>frame).contentDocument ? (<HTMLIFrameElement>frame).contentDocument : (<HTMLIFrameElement>frame).contentWindow.document;

            eval(controlsToSet);
        }

        this.Parent.Close();
    }

    Cancel() {
        this.Parent.Close();
    }

    ClientSetAutoCompleteEntries(emps) {
        //var dlgDiv = $("#LookUpDlgDiv");
        //var dlgParentFrame = dlgDiv.data('parentFrame');
        //var CallingWindowContent = dlgParentFrame.contentWindow;

        //CallingWindowContent.ClientSetAutoCompleteEntries(emps);

        //this.Parent.Close();
    }

    ShowMessage(message: string) {
        let dialog = $('<div></div>').appendTo(document.body);
        let kAlert: kendo.ui.Alert;
        let options: any = {
            buttonLayout: 'normal',
            title: false,
            content: message,
            close: function (e) {
                kAlert.wrapper.remove();
            }
        };
        kAlert = dialog.kendoAlert(options).data('kendoAlert');
        kAlert.open();
    }
}
