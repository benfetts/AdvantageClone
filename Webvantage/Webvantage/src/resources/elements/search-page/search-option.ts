import { customElement, bindable } from 'aurelia-framework';

@customElement('wv-search-option')
export class SearchOption {

    @bindable label: string;
    @bindable hideLabel: boolean = false;

}
