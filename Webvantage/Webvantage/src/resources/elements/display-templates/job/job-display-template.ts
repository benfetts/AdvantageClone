import { containerless, customElement, bindable } from 'aurelia-framework';

@containerless
@customElement('wv-job-display-template')
export class JobDisplayTemplate {

    jobPadding: number = 6;
    componentPadding: number = 3;

    @bindable clientCode: string;
    @bindable clientName: string;
    @bindable divisionCode: string;
    @bindable divisionName: string;
    @bindable productCode: string;
    @bindable productName: string;
    @bindable jobNumber: number;
    @bindable jobDescription: string;
    @bindable jobComponentNumber: number;
    @bindable jobComponentDescription: string;
    @bindable jobAndComponent: string; // used for supporting existing data where job & component info is formatted on the server
    @bindable isValueTemplate: boolean = false; // used in drop down lists as the value template
    @bindable LookupOfficeService: string;
    @bindable SalesClass: string;
    @bindable JobType: string;

    
    constructor() {
        //console.log(this.jobDescription);
    }

}
