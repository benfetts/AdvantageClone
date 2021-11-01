import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { IToolbarCenterButtons } from '../interfaces/toolbar-center-buttons';
import { BUTTON_CENTER_TYPES } from '../constants/toolbar-center-buttons.constants';
import { BottomPanelButtonsService } from './bottom-panel-buttons.service';
import { CENTRAL_BUTTONS_TYPES } from '../constants/types/central-buttons-types.constants';
import { shapesTypes, textTypes } from '../components/central-container/workspace-toolbar/constants/shapes.constants';
import { ComparisonService } from './comparison.service';
import { IDocument } from '../interfaces/document';

@Injectable({
  providedIn: 'root'
})
export class CenterPanelButtonsService {
  private buttons: IToolbarCenterButtons = JSON.parse(JSON.stringify(BUTTON_CENTER_TYPES));
  private buttons$: BehaviorSubject<IToolbarCenterButtons> = new BehaviorSubject<IToolbarCenterButtons>(this.buttons);
  private shapes: typeof shapesTypes = JSON.parse(JSON.stringify(shapesTypes));
  private text: typeof textTypes = JSON.parse(JSON.stringify(textTypes));
  private shapeButton$: BehaviorSubject<typeof shapesTypes> = new BehaviorSubject<typeof shapesTypes>(this.shapes);
  private textButton$: BehaviorSubject<typeof textTypes> = new BehaviorSubject<typeof textTypes>(this.text);
  private revision: BehaviorSubject<IDocument> = new BehaviorSubject<IDocument>(null);
  private lastTool = null;

  constructor(private bottomPanelButtonsService: BottomPanelButtonsService,
    private comparisonService: ComparisonService ) {
    this.buttons = JSON.parse(JSON.stringify(BUTTON_CENTER_TYPES));
  }

  public setCentralPanelButtons(propertyName: string, markerToolSelected: boolean): void {
    const prevSelectedButtonStatus = this.buttons[propertyName].selected;

    if (this.lastTool
      && this.lastTool != CENTRAL_BUTTONS_TYPES.TEXT_AREA
      && this.lastTool != CENTRAL_BUTTONS_TYPES.BOTTOM_NAVIGATION
      && this.lastTool != CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION
      && this.lastTool != CENTRAL_BUTTONS_TYPES.COMPARE
      && this.lastTool != CENTRAL_BUTTONS_TYPES.VERSION
      && this.lastTool != CENTRAL_BUTTONS_TYPES.MARKER_TOOL) {
      if (this.buttons[this.lastTool]) {
        this.buttons[this.lastTool].selected = false;
      }
    }
    this.lastTool = propertyName;

    this.buttons = {
      ...this.buttons,
      [CENTRAL_BUTTONS_TYPES.TEXT_AREA]: {
        ...this.buttons[CENTRAL_BUTTONS_TYPES.TEXT_AREA],
        selected: !prevSelectedButtonStatus ? false : true
      },
      [CENTRAL_BUTTONS_TYPES.BOTTOM_NAVIGATION]: {
        ...this.buttons[CENTRAL_BUTTONS_TYPES.BOTTOM_NAVIGATION],
      },
      [CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION]: {
        ...this.buttons[CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION],
      },
      [CENTRAL_BUTTONS_TYPES.COMPARE]: {
        ...this.buttons[CENTRAL_BUTTONS_TYPES.COMPARE],
      },
      [CENTRAL_BUTTONS_TYPES.VERSION]: {
        ...this.buttons[CENTRAL_BUTTONS_TYPES.VERSION]
      },
      [propertyName]: {
        ...this.buttons[propertyName],
        selected: !prevSelectedButtonStatus
      }
    };

    if (propertyName == CENTRAL_BUTTONS_TYPES.OVERLAY && this.buttons[CENTRAL_BUTTONS_TYPES.OVERLAY].selected) {
      this.buttons[CENTRAL_BUTTONS_TYPES.COMPARE].selected = true;
      this.buttons[CENTRAL_BUTTONS_TYPES.VERSION].selected = true;

      this.comparisonService.setComparisonFilesAmount();
      this.bottomPanelButtonsService.setViewVersion('split-view');
    }

    if (propertyName == CENTRAL_BUTTONS_TYPES.COMPARE && this.buttons[CENTRAL_BUTTONS_TYPES.COMPARE].selected == true) {
      this.buttons[CENTRAL_BUTTONS_TYPES.VERSION].selected = true;
      this.comparisonService.setComparisonFilesAmount();
      this.bottomPanelButtonsService.setViewVersion('split-view');
    }
    else if (propertyName == CENTRAL_BUTTONS_TYPES.COMPARE && this.buttons[CENTRAL_BUTTONS_TYPES.COMPARE].selected == false) {
      this.revision.next(null);
      this.comparisonService.resetComparisonFilesAmount();
      this.bottomPanelButtonsService.setViewVersion('one-asset');
    }

    if (propertyName == CENTRAL_BUTTONS_TYPES.VERSION && this.buttons[CENTRAL_BUTTONS_TYPES.VERSION].selected == false) {
      this.buttons[CENTRAL_BUTTONS_TYPES.COMPARE].selected = false;
      this.comparisonService.resetComparisonFilesAmount();
      this.bottomPanelButtonsService.setViewVersion('one-asset');
    }

    //if (markerToolSelected) {
    //  this.bottomPanelButtonsService.resetMarkerTool();
    //}

    this.buttons$.next(this.buttons);
  }

  public setShapesButtons(buttomName: string): void {

    if (this.lastTool
      && this.lastTool != CENTRAL_BUTTONS_TYPES.TEXT_AREA
      && this.lastTool != CENTRAL_BUTTONS_TYPES.BOTTOM_NAVIGATION
      && this.lastTool != CENTRAL_BUTTONS_TYPES.PAGE_NAVIGATION
      && this.lastTool != CENTRAL_BUTTONS_TYPES.COMPARE) {
      if (this.buttons[this.lastTool]) {
        this.buttons[this.lastTool].selected = false;
      }
    }

    this.shapes = JSON.parse(JSON.stringify(shapesTypes));

    this.shapes.forEach((v, i, a) => {
      if (v.name === buttomName) {
        a[i].selected = true;
      }
      else {
        a[i].selected = false;
      }
    });

    this.shapeButton$.next(this.shapes)
  }

  public setTextButtons(buttomName: string): void {
    this.text = JSON.parse(JSON.stringify(textTypes));

    this.text.forEach((v, i, a) => {
      if (v.name === buttomName) {
        a[i].selected = true;
      }
      else {
        a[i].selected = false;
      }
    });

    this.shapeButton$.next(this.text)
  }

  public getCentralPanelButtons(): Observable<IToolbarCenterButtons> {
    return this.buttons$;
  }

  public getShapeButton(): Observable<typeof shapesTypes> {
    return this.shapeButton$;
  }

  public getTextButton(): Observable<typeof textTypes> {
    return this.shapeButton$;
  }

  public setRevision(revision: IDocument): void {
    this.revision.next(revision);
  }

  public getRevision(): Observable<IDocument> {
    return this.revision;
  }

  public getButtonState(button: string) {
    return this.buttons[button].selected;
  }
}
