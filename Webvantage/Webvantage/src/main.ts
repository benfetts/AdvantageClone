import {Aurelia} from 'aurelia-framework'
import environment from './environment';
import { PLATFORM } from 'aurelia-pal';

export function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .feature('resources')
      .plugin('aurelia-dialog');


  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  if (environment.testing) {
    aurelia.use.plugin('aurelia-testing');
  }

    aurelia.use.plugin('aurelia-bootstrap');
    aurelia.use.plugin('aurelia-kendoui-bridge', config => config.notifyBindingBehavior());
    aurelia.use.plugin('aurelia-syncfusion-bridge');
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-dialog'));
    //aurelia.use.plugin('aurelia-syntax-highlighter');

  aurelia.use.globalResources('resources/elements/base-app/base-app');


 //aurelia.start().then(() => aurelia.setRoot());

  kendo.ui.Grid.fn.options.pageable = {
      pageSizes: ['all', 10, 20, 50, 100, 200],
      buttonCount: 10
  }

  let model: any;
  
  if(document['modelBinder'] && typeof document['modelBinder'] === 'function'){
    model = document['modelBinder']();
  }

  // clear it out!
  document['modelBinder'] = null;

  aurelia.start().then(() => aurelia.enhance(model, document.body));

}
