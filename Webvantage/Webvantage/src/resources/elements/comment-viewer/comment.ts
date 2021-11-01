import { inject, bindable } from 'aurelia-framework';

export class Comment {

    @bindable message: string;
    @bindable employeeCode: string;
    @bindable employeeName: string;
    @bindable commentDate: string;


}
