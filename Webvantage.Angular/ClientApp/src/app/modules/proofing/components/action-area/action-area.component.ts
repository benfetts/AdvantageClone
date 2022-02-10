import {
  AfterViewInit,
  ChangeDetectionStrategy,
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  ViewChild,
  ViewEncapsulation,
  ChangeDetectorRef
} from '@angular/core';
import { fromEvent, Observable, Subject } from 'rxjs';
import { debounceTime, takeUntil } from 'rxjs/operators';


import { WorkspaceContainerComponent } from '../central-container/workspace-container/workspace-container.component';
import { IRightPanelButtons } from '../../interfaces/right-panel-buttons';
import { RightPanelButtonsService } from '../../services/right-panel-buttons.service';
import { ResizeHeightService } from '../../services/resize-height.service';
import { ITooltip } from '../../interfaces/tooltip';
import { TOOLTIPS } from '../../constants/tooltips.constants';
import { TextSelectService } from '../../services/text-select.service';
import { RIGHT_PANEL_BUTTONS_TYPES } from '../../constants/types/right-panel-buttons-types.constants';

const DEBOUNCE_TIME = 100;

@Component({
  selector: 'proof-action-area',
  templateUrl: './action-area.component.html',
  styleUrls: ['./action-area.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class ActionAreaComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild('rightPanel') public rightPanel: ElementRef;

  public buttons: IRightPanelButtons;
  public tooltips: ITooltip = TOOLTIPS;

  private destroy$: Subject<void> = new Subject();

  @ViewChild(WorkspaceContainerComponent)
  private workspaceContainer: WorkspaceContainerComponent;

  get rightPanelElem(): HTMLElement {
    return this.rightPanel.nativeElement;
  }

  constructor(private rightPanelButtonsService: RightPanelButtonsService,
    private resizeHeightService: ResizeHeightService,
    private textSelectService: TextSelectService,
    private ref: ChangeDetectorRef) {
    fromEvent(window, 'resize')
      .pipe(
        debounceTime(DEBOUNCE_TIME),
        takeUntil(this.destroy$)
      )
      .subscribe(() => this.resizeHeightService.setHeight(this.rightPanelElem.offsetHeight));
  }

  public ngOnInit(): void {
    this.rightPanelButtonsService.getRightPanelButtons().pipe(
      takeUntil(this.destroy$)
    ).subscribe((buttons: IRightPanelButtons) => {
      this.buttons = buttons;
      this.ref.detectChanges();
    });

    this.textSelectService.getSelectedText()
      .subscribe((selectedText) => {
        if (selectedText.quads != null) {
          if (!this.rightPanelButtonsService.isExpanded()) {
            this.rightPanelButtonsService.setRightPanelButtons(RIGHT_PANEL_BUTTONS_TYPES.EXPANDED);
          }
        }
        this.ref.detectChanges();
      });
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public ngAfterViewInit(): void {
    this.resizeHeightService.setHeight(this.rightPanelElem.offsetHeight);
  }

  public selectedButton(propertyName: string): void {
    this.rightPanelButtonsService.setRightPanelButtons(propertyName);
  }

  isExpanded(): boolean {
    const expanded = RIGHT_PANEL_BUTTONS_TYPES.EXPANDED;
    const assetInfo = RIGHT_PANEL_BUTTONS_TYPES.ASSET_INFO;
    const review = RIGHT_PANEL_BUTTONS_TYPES.REVIEW;
    const feedback = RIGHT_PANEL_BUTTONS_TYPES.FEEDBACK;
    const search = RIGHT_PANEL_BUTTONS_TYPES.SEARCH;

    if (this.buttons) {
      return (this.buttons[expanded].selected || this.buttons[assetInfo].selected || this.buttons[review].selected || this.buttons[feedback].selected || this.buttons[search].selected);
    }

    return false;
  }
}
