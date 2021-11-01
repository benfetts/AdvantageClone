import { Component, OnInit } from '@angular/core';

import { linkTypes } from '../../../../../../constants/types/link-tool-types.constants';
import { LIST_OF_LINK_TYPES } from '../../../../../../constants/types/link-tool-types';
import { LinkToolService } from '../../../../../../services/link-tool.service';

@Component({
  selector: 'proof-link-type-selector',
  templateUrl: './link-type-selector.component.html',
  styleUrls: ['./link-type-selector.component.scss']
})
export class LinkTypeSelectorComponent implements OnInit {
  public listItems: string[] = LIST_OF_LINK_TYPES;
  public itemsTypes = linkTypes;
  public linkTypes;

  constructor(private linkToolService: LinkToolService) {
  }

  public ngOnInit(): void {
    this.linkTypes = this.linkToolService.getLinkToolType();
  }

  public onValueChange(value: string): void {
    this.linkToolService.setLinkToolType(this.itemsTypes[value]);
  }
}
