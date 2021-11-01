import { inject, bindable, customElement } from 'aurelia-framework';
import { EventDispatcher } from '../shared/event-dispatcher';

@customElement('wv-multiselect')
@inject(Element)
export class Multiselect {

    @bindable value: any;
    @bindable valueField: string = 'Value';
    @bindable textField: string = 'Text';
    @bindable dataSource: kendo.data.DataSource;
    @bindable enabled: boolean;
    @bindable clearButton: boolean;
    eventDispatcher: EventDispatcher;
    widget: kendo.ui.MultiSelect;

    changed(e) {
        this.eventDispatcher.dispatch('change', e);
    }  
    
    selected(e) {
        this.eventDispatcher.dispatch('select', e);
    }

    deselected(e) {        
        this.eventDispatcher.dispatch('deselect', e);
    }

    dataBound(e) {
        this.eventDispatcher.dispatch('data-bound', e);
    }

    attached() {
        
    }
    
    constructor(element: HTMLElement) {
        this.eventDispatcher = new EventDispatcher(element);
    }

}
