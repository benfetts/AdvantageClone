import { bindable, customElement, containerless, bindingMode } from 'aurelia-framework';

@containerless
@customElement('wv-slider')

export class Slider {

    @bindable label: string;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) Max: number = 10;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) Min: number = 0;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) Value: number = 0;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) SmallStep: number = 1;
    @bindable({ defaultBindingMode: bindingMode.twoWay }) LargeStep: number = 2;
    @bindable IncreaseButtonTitle: string = "Increase";
    @bindable DecreaseButtonTitle: string = "Decrease";
    @bindable CssClass: string = "slider";

}
