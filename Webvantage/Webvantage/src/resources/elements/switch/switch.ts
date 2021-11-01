import { bindable, customElement, containerless, bindingMode } from 'aurelia-framework';
@containerless
@customElement('wv-switch')
export class Switch {
    @bindable label: string;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) checked: boolean = false;
    @bindable checkedLabel: string = 'On';
    @bindable uncheckedLabel: string = 'Off';
    @bindable visible: boolean = true;
}
