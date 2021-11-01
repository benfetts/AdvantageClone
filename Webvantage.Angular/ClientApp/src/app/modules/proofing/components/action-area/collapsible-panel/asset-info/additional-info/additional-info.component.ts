import { Component, Input } from '@angular/core';

import { HEADER_WIDTH } from '../constants/column-width';

const NONE = 'None';

@Component({
  selector: 'proof-additional-info',
  templateUrl: './additional-info.component.html',
  styleUrls: ['./additional-info.component.scss']
})
export class AdditionalInfoComponent {
  @Input() public additionalInfoMock: string;

  public oneBlock = [' '];
  public noneStr = NONE;
  public columnWidth = HEADER_WIDTH;
}
