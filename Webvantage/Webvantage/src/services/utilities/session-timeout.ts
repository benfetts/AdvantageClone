import { observable, inject, Container, NewInstance } from 'aurelia-framework';
import { DialogService } from 'aurelia-dialog';
import { SessionTimeoutDlg } from 'modules/utilities/session-timeout';
import { HttpClient } from 'aurelia-http-client';
import { ApplicationService } from 'services/application-service';

@inject(DialogService, ApplicationService)
export class SessionTimeout {
    TimeOut = null;
    KeepAliveTimeOut = null;
    KeepAliveTime: number = 60000;
    SessionTime: number =  600000;
    dialogService: DialogService;
    service: ApplicationService;

    extendTimeout() {
        if (this.TimeOut)
            clearTimeout(this.TimeOut);

        this.TimeOut = setTimeout(this.SessionExpireEvent, this.SessionTime, this);

        let client = new HttpClient();
        return client.post('Utilities/ApplicationActions/ExtendSession', {});
    }

    SessionExpireEvent(me: SessionTimeout) {
        me.dialogService.open({ viewModel: SessionTimeoutDlg, lock: true }).whenClosed(response => {
            if (!response.wasCancelled) {
                me.service.signOut().then((response) => {
                    if (response && response.content) {
                        if (response.content.Success === false && response.content.Message !== "") {
                            alert(response.content.Message);
                        }
                        window.location.replace("SignIn.aspx");
                    }
                });
            } else {
                me.extendTimeout();
            }
        });
    }

    keepAlive(me: SessionTimeout) {
        //console.log("Sending keep alive.")

        let client = new HttpClient();
        client.post('Utilities/ApplicationActions/ExtendSession', {});

        me.KeepAliveTimeOut = setTimeout(me.keepAlive, me.KeepAliveTime, me);

    }

    constructor(dialogService: DialogService, service: ApplicationService) {
        let me = this;

        this.dialogService = dialogService;
        this.service = service;

        me.KeepAliveTimeOut = setTimeout(me.keepAlive, me.KeepAliveTime, me);

        let client = new HttpClient();
        client.get('Utilities/GetSessionTimeout').then(data => {
            var results = JSON.parse(data.response);
            me.SessionTime = results.TimeoutMilliseconds;
            //console.log("TimeoutMilliseconds = " + me.SessionTime)
            me.extendTimeout();
        });
    }
}
