import { bindable, customElement } from 'aurelia-framework';

@customElement('wv-drawer')
export class Drawer {

    @bindable position: string;
    @bindable closeTitle: string = 'Close';

    isOpen: boolean = false;
    positionCss: string;

    positionChanged(newValue, oldValue) {
        if (this.position.toUpperCase() === 'TOP') {
            this.positionCss = 'wv-drawer-top';
        } else if (this.position.toUpperCase() === 'BOTTOM') {
            this.positionCss = 'wv-drawer-bottom'
        } else if (this.position.toUpperCase() === 'RIGHT') {
            this.positionCss = 'wv-drawer-right';
        } else {
            this.positionCss = '';
        }
    }

    closeMenus() {
        //$(".wv-tree-nav li").removeClass("wv-nav-expanded");
    }

    close() {
        this.isOpen = false;
        this.closeMenus();
    }
    open() {
        this.isOpen = true;
    }

}
