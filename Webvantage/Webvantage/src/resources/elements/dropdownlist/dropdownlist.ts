import { bindable, customElement, inject } from 'aurelia-framework';
import { EventDispatcher } from '../shared/event-dispatcher';

@customElement('wv-drop-down-list')
@inject(Element)
export class DropDownList {

    @bindable widget: kendo.ui.DropDownList;
    @bindable value: any;
    @bindable valueField: string = 'Code';
    @bindable textField: string = 'Name';
    @bindable dataSource: kendo.data.DataSource;
    @bindable extraItems: Array<any>;
    @bindable optionLabel: string;
    @bindable enabled: boolean = true;
    eventDispatcher: EventDispatcher;

    changed(e) {
        this.eventDispatcher.dispatch('change', e);
    }
    selected(e) {
        this.eventDispatcher.dispatch('select', e);
    }
    dataBound(e) {
        this.eventDispatcher.dispatch('data-bound', e);
    }

    enabledChanged(newVal, oldVal) {
        if (this.widget) {
            this.widget.enable(this.enabled);
        }
    }

    dataSourceChanged() {
        if (this.dataSource) {
            this.dataSource.bind('requestEnd', e => {
                if (e.response) {
                    if (this.extraItems) {
                        for (var i = 0; i < this.extraItems.length; i++) {

                            var extraItem = <any>this.extraItems[i];
                            var itemToAdd = <any>{};

                            itemToAdd[this.valueField] = '';
                            itemToAdd[this.textField] = '';

                            if (extraItem.hasOwnProperty('Value')) {
                                itemToAdd[this.valueField] = extraItem.Value;
                            } else if (extraItem.hasOwnProperty(this.valueField)) {
                                itemToAdd[this.valueField] = extraItem[this.valueField];
                            }
                            if (extraItem.hasOwnProperty('Text')) {
                                itemToAdd[this.textField] = extraItem.Text;
                            } else if (extraItem.hasOwnProperty(this.textField)) {
                                itemToAdd[this.textField] = extraItem[this.textField];
                            }

                            e.response.splice(i, 0, itemToAdd);

                        }
                    }
                }
            });
        }
    }

    constructor(element: HTMLElement) {
        this.eventDispatcher = new EventDispatcher(element);
    }

}
