import { containerless, bindable } from 'aurelia-framework';

@containerless
export class BaseApp {
  
    @bindable app: string;
    @bindable viewModel: string;

    attached() {

    }

}
