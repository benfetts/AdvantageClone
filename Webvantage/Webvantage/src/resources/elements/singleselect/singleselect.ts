import { inject, bindable, customElement } from 'aurelia-framework';
import { EventDispatcher } from '../shared/event-dispatcher';

@customElement('wv-singleselect')
@inject(Element)
export class Singleselect {


    @bindable value: any;
    @bindable valueField: string = 'Value';
    @bindable textField: string = 'Text';
    @bindable dataSource: kendo.data.DataSource;
    @bindable enabled: boolean;
    @bindable placeholder: string = "";
    @bindable virtual: any;
    @bindable wvWidth: string = "100%";
    eventDispatcher: EventDispatcher;
    widget: kendo.ui.MultiSelect;

    internalValueChange: boolean = false;

    _values = [];

    changed(e) {
        console.log(this._values);

        this.internalValueChange = true;
        if (this._values && this._values.length > 0) {
            this.value = this._values[0];
        }
        else {
            this.value = '';
        }

        console.log(this.value);
        this.eventDispatcher.dispatch('change', e);
    }

    selected(e) {
        this.eventDispatcher.dispatch('select', e);
    }

    deselected(e) {
        let me = this;
        this.value = '';
        setTimeout(() => {
            me.eventDispatcher.dispatch('change', e);
        }, 50);

        //this.eventDispatcher.dispatch('deselect', e);
    }

    dataBound(e) {
        this.eventDispatcher.dispatch('data-bound', e);
    }

    attached() {

    }

    valueChanged(newValue, oldValue) {
        console.log(newValue);

        if (!this.internalValueChange) {
            this._values = [];
            this._values[0] = newValue;

            if (this.widget && (!newValue || newValue == '')) {
                this.widget.dataSource.read();
            }
        }

        this.internalValueChange = false;
    }

    dataItems() {
        if (this.widget) {
            return this.widget.dataItems();
        }

        return null;
    }

    val() {
        if (this.widget) {
            return this.widget.input.val();
        }

        return null;
    }

    setDataSource(dataSource: kendo.data.DataSource) {
        if (this.widget) {
            this.widget.setDataSource(dataSource);
        }
    }

    enable(enable: boolean) {
        if (this.widget) {
            this.widget.enable(enable);
        }
    }

    trigger(event: string, e: any) {
        this.eventDispatcher.dispatch(event, e);
    }

    constructor(element: HTMLElement) {
        this.eventDispatcher = new EventDispatcher(element);
    }

    focus() {
        this.widget.focus();
    }

    refresh() {
        this.widget.refresh();
    }

    widgetReady(e) {
        if (this.value) {
            console.log(this.value);
            this._values = [];
            this._values[0] = this.value;
        }
    }
}
