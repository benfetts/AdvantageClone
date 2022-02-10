import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { RIGHT_PANEL_BUTTONS_CONSTANTS } from '../constants/right-panel-buttons.constants';
import { IRightPanelButtons } from '../interfaces/right-panel-buttons';
import { RIGHT_PANEL_BUTTONS_TYPES } from '../constants/types/right-panel-buttons-types.constants';
import { SearchService } from './search.service';

@Injectable({
  providedIn: 'root'
})
export class RightPanelButtonsService {
  private buttons: IRightPanelButtons = JSON.parse(JSON.stringify(RIGHT_PANEL_BUTTONS_CONSTANTS));
  private buttons$: BehaviorSubject<IRightPanelButtons> = new BehaviorSubject<IRightPanelButtons>(this.buttons);


  constructor(private searchService: SearchService) {

  }

  public setRightPanelButtons(propertyName: string): void {
    const prevSelectedButtonStatus = this.buttons[propertyName].selected;
    const expanded = RIGHT_PANEL_BUTTONS_TYPES.EXPANDED;
    const assetInfo = RIGHT_PANEL_BUTTONS_TYPES.ASSET_INFO;
    const review = RIGHT_PANEL_BUTTONS_TYPES.REVIEW;
    const feedback = RIGHT_PANEL_BUTTONS_TYPES.FEEDBACK;
    const search = RIGHT_PANEL_BUTTONS_TYPES.SEARCH;

    if (prevSelectedButtonStatus) {
      this.buttons = {
        ...this.buttons,
        [propertyName]: {
          ...this.buttons[propertyName],
          selected: !prevSelectedButtonStatus
        }
      };
    }
    else {
      this.buttons = {
        ...this.buttons,
        [assetInfo]: {
          ...this.buttons[assetInfo],
          selected: false
        },
        [review]: {
          ...this.buttons[review],
          selected: false
        },
        [feedback]: {
          ...this.buttons[feedback],
          selected: false
        },
        [expanded]: {
          ...this.buttons[expanded],
          selected: false
        },
        [search]: {
          ...this.buttons[search],
          selected: false
        },
        [propertyName]: {
          ...this.buttons[propertyName],
          selected: !prevSelectedButtonStatus
        }
      };
    }

    if (this.buttons[search].selected == false) {
      this.searchService.clearSearch();
    }


    this.buttons$.next(this.buttons);
  }

  public getRightPanelButtons(): Observable<IRightPanelButtons> {
    return this.buttons$;
  }

  public getRightPanelStatus(): Observable<boolean> {
    return this.buttons$.pipe(map(buttons => buttons.expanded.selected));
  }

  public isOnlyExpanded({expanded, review, assetInfo, feedback} = this.buttons): boolean {
    return !feedback.selected && !review.selected && !assetInfo.selected && expanded.selected;
  }

  public isExpanded({ expanded } = this.buttons) {
    return expanded.selected;
  }
}
