import * as moment from 'moment';
import { isDate } from 'moment';
import { HttpClient } from 'aurelia-http-client';

export class ModuleBase {

    //notification: kendo.ui.Notification;
    progress: boolean;
    model: any;
    canAdd: boolean = false;
    canUpdate: boolean = false;
    canPrint: boolean = false;
    canCustom1: boolean = false;
    canCustom2: boolean = false;
    isBlocked: boolean = false;

    CanAdd(url: string) {
        let client = new HttpClient();
        let me = this;

        client.get(url)
            .then(data => {
                me.canAdd = (data.response === 'true');
            });
    }

    CanUpdate(url: string) {
        let client = new HttpClient();
        let me = this;

        client.get(url)
            .then(data => {
                me.canUpdate = (data.response === 'true');
            });
    }

    CanPrint(url: string) {
        let client = new HttpClient();
        let me = this;

        client.get(url)
            .then(data => {
                me.canPrint = (data.response === 'true');
            });
    }

    IsBlocked(url: string) {
        let client = new HttpClient();
        let me = this;

        client.get(url)
            .then(data => {
                me.isBlocked = (data.response === 'true');
            });
    }

    uuidv4() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    formatCurrency(Budget) {
        if (Budget) {
            return kendo.format('{0:c}', Budget);
        }
        else {
            return '';
        }
    }
          
    // helpers
    kendo() {
        return kendo;
    }

    alert(message: string, title?: any): void {
        message = this.javaScriptCommentToHTML(message);
        title = this.checkForTitle(title);
        let dialog = $('<div></div>').appendTo(document.body);
        let kAlert: kendo.ui.Alert;
        let options: any = {
            buttonLayout: 'normal',
            title: title,
            content: message,
            close: function (e) {
                kAlert.wrapper.remove();
            }
        };        
        kAlert = dialog.kendoAlert(options).data('kendoAlert');
        kAlert.open();        
    }
    confirm(message: string, title?: any): JQueryPromise<any> {        
        message = this.javaScriptCommentToHTML(message);
        title = this.checkForTitle(title);
        let dialog = $('<div></div>').appendTo(document.body);
        let kConfirm: kendo.ui.Confirm;
        let options: any = {
            buttonLayout: 'normal',
            title: title,
            content: message,
            //actions: [
            //    {
            //        text: "Cancel",
            //        primary: false,
            //        cssClass: "k-button-cancel",
            //        action: function (e) {
            //            //  What goes here to trigger cancel action???
            //        }
            //    },
            //    {
            //        text: "OK",
            //        primary: true,
            //        cssClass: "k-button-ok",
            //        action: function (e) {
            //            //  What goes here to trigger OK action???
            //        }
            //    }
            //],
            close: function (e) {
                kConfirm.wrapper.remove();
            }
        };
        kConfirm = dialog.kendoConfirm(options).data('kendoConfirm');
        kConfirm.open();
        return kConfirm.result;
    }

    javaScriptCommentToHTML(str: string) {
        return str = str.replace("\n", "<br/>");
    }
    checkForTitle(str?: any) {
        if (!str || str == undefined || str == null || str.trim() == "") {
            str = false;
        } else {
            str = String(str);
        }
        return str;
    }

    copyToClipboard(text: string) {
        wvbridge.copyToClipboard(text);
    }
    kendoParseDate(value) {
        return kendo.parseDate(value);
    }
    formatDate(date: string, format?: moment.LongDateFormatKey) {
        if (date) {
            if (!format) {
                format = 'L';
            }
            return moment(date).format(moment.localeData().longDateFormat(format));
        }
        return;
    }
    formatShortDateLongTimeDisplay(date: string) {
        return this.parseShortDate(moment(date).toDate()).value + ' ' + moment(date).format(moment.localeData().longDateFormat('LTS'));
    }
    formatCustodyStartAndEnd(custodyStart: string, custodyEnd: string) {
        var displayString = "";
        try {
            var startAr = [];
            var endAr = [];
            var isSameDay = false;
            if (!custodyEnd || custodyEnd == "") {
                displayString = custodyStart;
            } else {                
                try {
                    startAr = custodyStart.split(" ");
                } catch (e) {
                }
                try {
                    endAr = custodyEnd.split(" ");
                } catch (e) {
                }
                try {
                    if (startAr && endAr && startAr.length > 0 && endAr.length > 0) {
                        if (startAr[0] == endAr[0]) {
                            isSameDay = true;
                        }
                    }
                } catch (e) {
                }
                if (isSameDay == false) {
                    displayString = custodyStart + " - " + custodyEnd;
                } else {
                    displayString = custodyStart + " - " + custodyEnd.replace(startAr[0], "");
                }
            }
        } catch (e) {
            displayString = custodyStart + " - " + custodyEnd;
        }
        displayString = displayString.toUpperCase();
        return displayString;
    }
    parseDate(formats, value) {
        var isValid = false;
        var parsedDate: any = kendo.parseDate(value);
        if (!parsedDate) {
            $.each(formats, function () {
                parsedDate = kendo.parseDate(value, this);
                if (parsedDate) {
                    return false;
                }
            });
        };
        if (parsedDate) {
            parsedDate = kendo.toString(parsedDate, 'd');
            isValid = true;
        }
        return {
            isValid: isValid,
            value: parsedDate
        }
    }
    parseShortDate(value) {
        var formats = ["MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy"];
        return this.parseDate(formats, value);
    }
    padJobNumber(jobNumber) {
        return this.pad(jobNumber, 6);
    }
    padJobComponentNumber(jobComponentNumber) {
        return this.pad(jobComponentNumber, 2);
    }
    pad(value, length) {
        return (value.toString().length < length) ? this.pad("0" + value, length) : value;
    }
    getModel() {
        return this.model;
    }
    openRadWindow(title: string, url: string, height?: number, width?: number, modal?: boolean) {
        wvbridge.OpenRadWindow(title, url, height, width, modal);
    }
    openRadWindowdc(title: string, url: string, height?: number, width?: number, modal?: boolean, dialogCallback?: any, param?: any) {
        wvbridge.OpenRadWindowdc(title, url, height, width, modal, dialogCallback, param);
    }
    openRadWindowUpdate(title: string, url: string, newurl: string) {
        wvbridge.OpenRadWindowUpdate(title, url, newurl);
    }
    getRadWindow() {
        return wvbridge.GetRadWindow();
    }
    refreshBookmarksDTO() {
        wvbridge.RefreshBookmarksDTO();
    }
    showNotification(data: any, type = "info") {
        wvbridge.showNotification(data, type);
    }
    showSuccessNotification(data: any) {
        this.showNotification(data, "success");
    }
    showInfoNotification(data: any) {
        this.showNotification(data, "info");
    }
    showWarningNotification(data: any) {
        this.showNotification(data, "warning");
    }
    showErrorNotification(data: any) {
        this.showNotification(data, "error");
    }
    showProgress(toggle: boolean): void {
        this.progress = toggle;
        if (toggle) {
            //window.setTimeout(() => {
                kendo.ui.progress($('body'), this.progress);
            //}, 500);
        } else {
            kendo.ui.progress($('body'), false);
        }
    }
    dueDateIsBeforeStartDate(startDate, dueDate) {
        var dueDateIsBefore = false;
        if (startDate && dueDate) {
            if (isDate(startDate) && isDate(dueDate)) {
                var s = new Date(startDate);
                var d = new Date(dueDate);
                if (s > d) {
                    dueDateIsBefore = true;
                }
            }
        }
        return dueDateIsBefore;
    }
    openStopwatchNotify() {
        wvbridge.OpenStopwatchNotify();
    }
    toggleFullScreenElement(element: HTMLElement) {
        wvbridge.toggleFullScreenElement(element);
        //$(element).toggleClass('full-screen');
        //if ($(element).hasClass('full-screen')) {
        //    $(document.body).css('overflow', 'hidden');
        //} else {
        //    $(document.body).css('overflow', 'auto');
        //}
    }
    defaultEditorTools: Array<kendo.ui.EditorTool> = [
        {
            name: 'bold'
        },
        {
            name: 'italic'
        },
        {
            name: 'underline'
        },
        {
            name: 'strikethrough'
        },
        {
            name: 'justifyLeft'
        },
        {
            name: 'justifyCenter'
        },
        {
            name: 'justifyRight'
        },
        {
            name: 'justifyFull'
        },
        {
            name: 'foreColor'
        },
        {
            name: 'backColor'
        },
        {
            name: 'fontName'
        },
        {
            name: 'fontSize'
        },
        {
            name: 'customundo',
            tooltip: 'Undo',
            exec: function (e) {
                var editor = $(this).data('kendoEditor');
                editor.exec('undo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-button k-tool k-group-start" unselectable="on" title="Undo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-undo" tabindex= "-1"></span><span class="k-tool-text" tabindex="-1">Undo Changes</span></a>'
        },
        {
            name: 'customredo',
            tooltip: 'Redo',
            exec: function (e) {
                var editor = $(this).data('kendoEditor');
                editor.exec('redo', null);
            },
            template: '<a tabindex="-1" role="button" class="k-button k-tool k-group-end" unselectable="on" title="Redo" aria-pressed="false" ><span unselectable="on" class="k-tool-icon k-icon k-i-redo" tabindex= "-1"></span><span class="k-tool-text" tabindex="-1">Redo Changes</span></a>'
        },
        {
            name: 'createLink'
        },
        //{
        //    name: 'unlink'
        //},
        {
            name: 'indent'
        },
        //{
        //    name: 'outdent'
        //},
        {
            name: 'insertUnorderedList'
        },
        {
            name: 'insertOrderedList'
        }
    ];

    //CheckWnd() {
    //    wvbridge.CheckWnd();
    //}
    // methods
    constructor() {

    }
}
