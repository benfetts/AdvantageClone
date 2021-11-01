import { Component, OnInit, ViewEncapsulation, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IDropDown } from '../../../interfaces/drop-down';
import { sliderActionsConstants } from './constants/slider-actions.constants';
import { IToolbarCenterButtons } from '../../../interfaces/toolbar-center-buttons';
import { BottomPanelButtonsService } from '../../../services/bottom-panel-buttons.service';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';
import { CENTRAL_BUTTONS_TYPES } from '../../../constants/types/central-buttons-types.constants';
import { ITooltip } from '../../../interfaces/tooltip';
import { TOOLTIPS } from '../../../constants/tooltips.constants';
import { CanMarkupService } from '../../../services/can-markup.service';
import { RightPanelButtonsService } from '../../../services/right-panel-buttons.service';
import { RIGHT_PANEL_BUTTONS_TYPES } from '../../../constants/types/right-panel-buttons-types.constants';
import { ActiveFileService } from '../../../services/active-file.service';
import { IDocument } from '../../../interfaces/document';
import { SignalrService } from '../../../services/signalr.services';

const SIZE_PERCENTS = '5%';
const DIALOG_WINDOW_TEXT = 'Are you sure you want to remove all the comments?';

@Component({
  selector: 'proof-workspace-toolbar',
  templateUrl: './workspace-toolbar.component.html',
  styleUrls: ['./workspace-toolbar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class WorkspaceToolbarComponent implements OnInit {
  public sizePercents = SIZE_PERCENTS;
  public isDropDownOpen = false;
  public buttons: Observable<IToolbarCenterButtons>;
  public dialogWindowOpened = false;
  public dialogWindowText = DIALOG_WINDOW_TEXT;
  public sliderActions: IDropDown[] = sliderActionsConstants;
  public markerToolButton: Observable<any>;
  public tooltips: ITooltip = TOOLTIPS;
  public disableEdits = true;
  public document: IDocument = null;
  public compare: Boolean = false;
  @Output() public dropDownClick = new EventEmitter<IDropDown>();
  @Output() public zoomChange = new EventEmitter<Number>();

  constructor(private centerPanelButtonsService: CenterPanelButtonsService,
    private bottomPanelButtonsService: BottomPanelButtonsService,
    private canMarkupService: CanMarkupService,
    private rightPanelButtonsService: RightPanelButtonsService,
    private activeFileService: ActiveFileService,
    private cdr: ChangeDetectorRef
    ,private signalrService: SignalrService  ) {
  }

  public ngOnInit(): void {
    this.buttons = this.centerPanelButtonsService.getCentralPanelButtons();
    this.markerToolButton = this.bottomPanelButtonsService.getBottomPanelButtons()
      .pipe(map(buttons => buttons.markerTool));

    this.canMarkupService.getCanMarkup().subscribe((canMarkup: boolean) => {
      this.disableEdits = !canMarkup;
      this.cdr.detectChanges();
    });

    this.activeFileService.getDocument().subscribe((document: IDocument) => {
      this.document = document;
      this.cdr.detectChanges();
    });

    this.buttons.subscribe(buttons => {
      this.compare = buttons.compare.selected;
      this.cdr.detectChanges();
    });

    this.signalrService.StartConnection();
  }

  public setSizePercents(value: number): void {
    this.sizePercents = `${value}%`;
    this.zoomChange.emit(value);
 }

  public onDropDownToggle(dropDownStatus: boolean): void {
    this.isDropDownOpen = dropDownStatus;
  }

  public setSelectedButton(propertyName?: string, markerToolSelected?: boolean): void {
    if (propertyName === CENTRAL_BUTTONS_TYPES.GARBAGE_CAN) {
      this.dialogWindowOpened = !this.dialogWindowOpened;
    }
    else if (propertyName === CENTRAL_BUTTONS_TYPES.MAGNIFYING_GLASS) {

      this.rightPanelButtonsService.setRightPanelButtons(RIGHT_PANEL_BUTTONS_TYPES.SEARCH);
      return;
    }

    this.centerPanelButtonsService.setCentralPanelButtons(propertyName, markerToolSelected);
  }

  public canSearchText(): boolean {
    if (this.document && (this.document.mimeType.toLowerCase().includes('text')
      || this.document.mimeType.toLowerCase() == 'application/pdf'
      || this.document.mimeType.toLowerCase() == 'application/msword'
      || this.document.mimeType.toLowerCase() == 'application/vnd.openxmlformats-officedocument.wordprocessingm'
      || this.document.mimeType.toLowerCase() == 'application/vnd.ms-excel'
      || this.document.mimeType.toLowerCase() == 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
      || this.document.mimeType.toLowerCase() == 'application/vnd.ms-powerpoint'
      || this.document.mimeType.toLowerCase() == 'application/vnd.openxmlformats-officedocument.presentationml.presentation'
      || this.document.mimeType.toLowerCase() == 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' )) {
      return true;
    }

    return false;
  }

  public canCreateTextAnnotation(): boolean {
    if (!this.canSearchText() || this.disableEdits || this.compare) {
      return false;
    }

    return true;
  }
}
