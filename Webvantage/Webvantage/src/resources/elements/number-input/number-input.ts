import { inject, bindable, bindingMode } from 'aurelia-framework';
import { EventDispatcher } from '../shared/event-dispatcher';


@inject(Element)
export class NumberInput {

    @bindable({ defaultBindingMode: bindingMode.twoWay }) value: any;
    @bindable({ defaultBindingMode: bindingMode.oneTime }) decimals: number = 0;
    @bindable({ defaultBindingMode: bindingMode.oneTime }) format: string = 'n';

    element: HTMLElement;
    input: HTMLInputElement;
    eventDispatcher: EventDispatcher;

    constructor(element: HTMLElement) {
        this.element = element;
    }

    created() {
        this.input = <HTMLInputElement>$(this.element).find('input').first()[0];
        this.eventDispatcher = new EventDispatcher(this.input);
    }

    valueChanged() {
        if (this.input) {
            const number = this.getNumber(this.value);
            if (isNaN(number)) {
                this.input.value = '';
            } else {
                var formatString = '';
                if (this.format !== '') {
                    formatString = this.format;
                    if (this.decimals > 0) {
                        formatString += this.decimals.toString();
                    }
                }
                if (formatString !== '') {
                    this.input.value = kendo.toString(number, formatString);
                } else {
                    this.input.value = number.toString(10);
                }
            }
            this.eventDispatcher.dispatch('change', null);
        }
    }

    keypress(event) {
        var carrot = this.input.selectionStart;
        var val = this.input.value;
        if (event.key === '.' && val.indexOf('.') > -1) { // already has decimal, advance character and/or block
            var preDecimal = val.substr(0, carrot);
            var postDecimal = val.substr(carrot);
            if (postDecimal.startsWith('.') === true){
                this.input.selectionStart += 1;
            }
            return false;
        }
        return true;
    }

    blur() {
        if (this.input.value === '') {
            this.value = null;
            return;
        }
        const number = this.getNumber(this.input.value);
        if (isNaN(number)) {
            this.valueChanged();
        } else {
            this.value = number;
        }
    }

    // utilities
    getNumber(value) {
        let number = parseFloat(value);
        return !isNaN(number) && isFinite(value) ? number : NaN;
    }

}
