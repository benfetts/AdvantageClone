import { customElement, bindable, inject } from 'aurelia-framework';
import { Tabset } from './tabset';

@customElement('wv-tab')
@inject(Tabset, Element)
export class Tab {

    @bindable title: string;
    @bindable selected: boolean;

    index: number;
    active: boolean = false;
    tabs: Tabset;
    element: Element;
    pane: HTMLElement;

    constructor(tabs: Tabset, element: Element) {
        this.tabs = tabs;
        this.element = element;
    }

    bind() {
        if (!this.title) {
            throw new Error('Please provide a title for the tab.');
        }
    }

    attached() {
        this.pane.style.display = this.active ? 'block' : 'none';
    }

    handleTabChanged(index) {
        let isSelected = index === this.index;
        if (isSelected === this.active) {
            return;
        }
        this.active = isSelected;
        if (isSelected) {
            this.pane.style.display = 'block';
        } else {
            this.pane.style.display = 'none';
        }
    }

}
