import { Component, Input, ViewEncapsulation } from '@angular/core';

import { IPage } from '../../../../interfaces/pages';
import { VIEW_VERSIONS_TYPES } from '../../../../constants/types/view-versions-types';

@Component({
  selector: 'proof-workspace-page-preview',
  templateUrl: './workspace-page-preview.component.html',
  styleUrls: ['./workspace-page-preview.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class WorkspacePagePreviewComponent {
  @Input() public pages: IPage[];
  @Input() public viewType: VIEW_VERSIONS_TYPES;

  public setClassOnBlock(): string {
    let classes: string;

    switch (this.viewType) {
      case VIEW_VERSIONS_TYPES.SPLIT_VERTICAL:
        classes = 'page-preview-vertical';
        break;
      case VIEW_VERSIONS_TYPES.SPLIT_HORIZONTAL:
        classes = 'page-preview-horizontal';
        break;
      default:
        classes = 'page-preview';
    }

    return classes;
  }
}
