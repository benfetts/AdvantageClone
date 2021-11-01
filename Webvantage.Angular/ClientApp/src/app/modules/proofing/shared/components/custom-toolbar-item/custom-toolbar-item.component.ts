import { Component, forwardRef, TemplateRef, ViewChild } from '@angular/core';
import { ToolBarToolComponent } from '@progress/kendo-angular-toolbar';

@Component({
  selector: 'proof-custom-toolbar-item',
  templateUrl: './custom-toolbar-item.component.html',
  providers: [{provide: ToolBarToolComponent, useExisting: forwardRef(() => CustomToolbarItemComponent)}],
})
export class CustomToolbarItemComponent extends ToolBarToolComponent {
  @ViewChild('toolbarTemplate', { static: true }) public toolbarTemplate: TemplateRef<any>;

  constructor() {
    super();
  }
}
