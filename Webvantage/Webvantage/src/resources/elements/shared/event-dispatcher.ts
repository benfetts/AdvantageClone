export class EventDispatcher {

    element: HTMLElement;

    dispatch(name, detail) {
        if (this.element) {
            let customEvent: CustomEvent;
            if (window['CustomEvent']) {
                customEvent = new CustomEvent(name, { detail: detail, bubbles: true });
            } else {
                customEvent = document.createEvent('CustomEvent');
                customEvent.initCustomEvent(name, true, true, detail);
            }
            this.element.dispatchEvent(customEvent);
        }
    }  

    constructor(element: HTMLElement) {
        this.element = element;
    }

}
