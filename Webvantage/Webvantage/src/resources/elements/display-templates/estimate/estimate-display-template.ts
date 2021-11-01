import { containerless, customElement, bindable } from 'aurelia-framework';

@containerless
@customElement('wv-estimate-display-template')

export class EstimateDispalyTemplate {
    estimatePadding: number = 6;
    componentPadding: number = 3;

    @bindable estimateComponentNumber: number;
    @bindable estimateNumber: number;
    @bindable estimateDescription: string;
    @bindable estimateComponentDescription: string;
    @bindable divisionCode: string;
    @bindable divisionName: string;
    @bindable clientName: string;
    @bindable productCode: string;
    @bindable productName: string;
    @bindable clientCode: string;

    constructor() {

    }

}
