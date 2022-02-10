import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { BUTTON_BOTTOM_TYPES } from '../constants/toolbar-bottom-buttons.constants';
import { VIEW_VERSIONS_TYPES } from '../constants/types/view-versions-types';
import { ComparisonService } from './comparison.service';
import { IToolbarBottomButtons } from '../interfaces/toolbar-bottom-buttons';
import { BOTTOM_BUTTONS_TYPES } from '../constants/types/bottom-buttons-types.constants';
import { IDocument } from '../interfaces/document';

@Injectable({
  providedIn: 'root'
})
export class BottomPanelButtonsService {
  private buttons: IToolbarBottomButtons = JSON.parse(JSON.stringify(BUTTON_BOTTOM_TYPES));
  private buttons$: BehaviorSubject<IToolbarBottomButtons> = new BehaviorSubject<IToolbarBottomButtons>(this.buttons);

  private revision: BehaviorSubject<IDocument> = new BehaviorSubject<IDocument>(null);

  constructor(private comparisonService: ComparisonService) {
  }

  public setBottomPanelButtons(value: string, status?: boolean): void {
    const {name: folderOpen} = this.buttons.folderOpen;
    const {name: fileManagerMin} = this.buttons.fileManagerMin;
    const {name: fileManagerMax} = this.buttons.fileManagerMax;
    const {name: compare} = this.buttons.compare;
    const {name: versions} = this.buttons.versions;
    const {name: markerTool} = this.buttons.markerTool;

    this.buttons[value] = {
      ...this.buttons[value],
      selected: status ? false : !this.buttons[value].selected
    };

    if (this.buttons[fileManagerMin].selected) {
      if (value !== folderOpen) {
        this.buttons[folderOpen].selected = this.buttons[fileManagerMin].selected === true;
      }
    }

    if (!this.buttons[folderOpen].selected) {
      this.buttons[fileManagerMin].selected = this.buttons[folderOpen].selected;

      if (value === fileManagerMax) {
        this.buttons[folderOpen].selected = true;
      }
    }

    console.log(value, compare);
    if (value === compare) {
      this.buttons[versions].selected = this.buttons[compare].selected;
      this.buttons[versions].selectedType = this.buttons[compare].selected
        ? this.buttons[versions].selectedType = VIEW_VERSIONS_TYPES.SPLIT_VIEW
        : this.buttons[versions].selectedType = VIEW_VERSIONS_TYPES.ONE_ASSET;

    //  if (BUTTON_BOTTOM_TYPES.compare.selected) {
    //    this.comparisonService.setComparisonFilesAmount();
    //  } else if (!BUTTON_BOTTOM_TYPES.compare.selected) {
    //    this.comparisonService.resetComparisonFilesAmount();
    //  }
    }

    //if (value === markerTool) {
    //  this.rightPanelButtonsService.setRightPanelButtons(RIGHT_PANEL_BUTTONS_TYPES.FEEDBACK);
    //  console.log('Marker tool?');
    //}

    this.buttons$.next({...this.buttons});
  }

  public setViewVersion(value: string): void {
    this.buttons = {
      ...this.buttons,
      versions: {
        ...this.buttons.versions,
        selectedType: value
      }
    };

    this.buttons$.next(this.buttons);
  }

  public getBottomPanelButtons(): Observable<IToolbarBottomButtons> {
    return this.buttons$;
  }

  public resetMarkerTool(): void {
    this.buttons = {
      ...this.buttons,
      [BOTTOM_BUTTONS_TYPES.MARKER_TOOL]: {
        ...this.buttons.markerTool,
        selected: false
      }
    };

    this.buttons$.next(this.buttons);
  }

  public setRevision(revision : IDocument) : void {
    this.revision.next(revision);
  }

  public getRevision(): Observable<IDocument> {
    return this.revision;
  }

}
