import { customElement, bindable, containerless, observable, autoinject, inject } from 'aurelia-framework';
import { EventAggregator } from 'aurelia-event-aggregator';

@containerless
@customElement('wv-collapse-panel')
//@inject(EventAggregator)
@autoinject
export class CollapsiblePanel {

    @bindable recordId: number;
    @bindable title: string;
    @bindable icon: string;

    @bindable onDelete;
    @bindable onShowOnCardChange;
    @bindable onTitleChange;

    @bindable isCollapsed: boolean;
    @bindable isFullScreen: boolean;

    @bindable allowCollapse: boolean = true;
    @bindable allowFullScreen: boolean = true;
    @bindable allowEditTitle: boolean = false;
    @bindable allowShowOnCard: boolean = false;

    @observable oTitle: string;

    @bindable showDelete: boolean = false;
    @bindable showOnCard: boolean = false;
    @bindable showOnCardText: string = 'Show On Card';

    isEditingTitle: boolean = false;

    element: HTMLElement;
    titleInputEditor: HTMLInputElement;

    oTitleChanged(newValue, oldValue) {
        //console.log(newValue, oldValue)
    }
    cancelTitleChange() {
        this.isEditingTitle = false;
    }
    toggleEditTitle() {
        //console.log("collapsible-panel.ts toggleEditTitle()")
        let me = this;
        me.oTitle = me.title;
        if (this.allowEditTitle === true) {
            this.isEditingTitle = !this.isEditingTitle;
        }
        if (this.isEditingTitle == true) {
            window.setTimeout(function () {
                $(me.titleInputEditor).focus();
                $(me.titleInputEditor).select();
                $(window).one('click', function () {
                    if (me.isEditingTitle == true) {
                        me.toggleEditTitle();
                    } 
                });
                $(me.titleInputEditor).one('click', function (e) {
                    e.stopPropagation();
                });
                $(me.titleInputEditor).one('focusout', function () {
                    me.ea.publish('title-input-changed', { RecordID: me.recordId, Value: me.title });
                    me.toggleEditTitle();
                    //if (me.isEditingTitle == false) {
                    //    //console.log("focus out");
                    //    me.onTitleChange;
                    //}
                });
            });
        }
    }
    toggleCollapse() {
        //console.log("collapsible-panel.ts toggleCollapse()")
       if (!this.isFullScreen === true) {
            if (this.allowCollapse === true) {
                this.isCollapsed = !this.isCollapsed;
            } else if (this.isFullScreen !== true) {
                this.isCollapsed = false;
            }
        }       
    }
    toggleFullScreen() {
        //console.log("collapsible-panel.ts toggleFullScreen()")
        if (this.allowFullScreen === true) {
            this.isFullScreen = !this.isFullScreen;
            wvbridge.toggleFullScreenElement(this.element);
        } else {
            this.isFullScreen = false;
        }
    }

    constructor(private ea: EventAggregator) {

    }

}
