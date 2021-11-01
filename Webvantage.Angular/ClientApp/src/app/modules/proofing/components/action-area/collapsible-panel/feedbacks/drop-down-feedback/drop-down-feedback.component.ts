import { Component, ViewEncapsulation } from '@angular/core';

import { feedbackPopUpOptions } from '../constants/feedback-pop-up-options.constants';
import { IDropDown } from '../../../../../interfaces/drop-down';

@Component({
  selector: 'proof-drop-down-feedback',
  templateUrl: './drop-down-feedback.component.html',
  styleUrls: ['./drop-down-feedback.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DropDownFeedbackComponent {
  public popupSettings = {popupClass: 'drop-down-feedback', align: 'right'};
  public options: IDropDown[] = feedbackPopUpOptions;
}
