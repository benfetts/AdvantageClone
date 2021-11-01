import { ModelBase } from 'models/base/model-base';

export class AlertRecipientModel extends ModelBase {

    //private _Processed: Date;

    AlertID: number;
    ClientContactID: number;
    EmployeeCode: string;
    Code: string;
    EmployeeEmail: string;
    EmployeeFullName: string;
    FullName: string;
    EmployeeImage: string;
    EmployeePicture: string;
    //ID: number;
    IsClientContact: boolean;
    IsCurrentNotify: boolean;
    IsCurrentRecipient: boolean;
    IsTaskEmployee: boolean;
    IsTaskTempComplete: boolean;
    CompletedDismissed: boolean;
    AlertTemplateID: number;
    AlertStateID: number;
    CurrentStateCompleted: boolean;
    IsCurrentAssignee: boolean;
    Name: string;
    //get Processed(): Date {
    //    return this._Processed;
    //}
    //set Processed(value: Date) {
    //    this._Processed = this.getDate(value);
    //}

    //PictureURL: string;
    
    constructor() {
        super();
    }

}
