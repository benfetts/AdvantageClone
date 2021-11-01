import { customElement, children, bindable, bindingMode } from 'aurelia-framework';
import { Tab } from './tab';

@customElement('wv-tabs')
export class Tabset {

    @children('wv-tab') tabs: Array<Tab>;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) active = 0;
    
    constructor() {
        
    }
    
    selectTab(tab: Tab, force: boolean = false) {
        this.active = tab.index;
        this.emitTabChanged();
    }

    activeChanged(newValue) {
        if (!this.tabs || this.tabs.length == 0) {
            return;
        }
        if (newValue > this.tabs.length) {
            this.active = 0;
            return;
        }
        this.selectTab(this.tabs[this.active], true);
    }

    tabsChanged() {
        for (let i = 0; i < this.tabs.length; i++) {
            let tab = this.tabs[i];
            tab.index = i;
        }
        if (this.active >= this.tabs.length) {
            this.active = 0;
        }
        this.selectTab(this.tabs[this.active]);
    }

    emitTabChanged() {
        for (let tab of this.tabs) {
            tab.handleTabChanged(this.active);
        }
    }


}
