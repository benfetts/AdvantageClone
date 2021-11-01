import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { IToolbarBottomButtons } from '../../../interfaces/toolbar-bottom-buttons';
import { BottomPanelButtonsService } from '../../../services/bottom-panel-buttons.service';
import { VIEW_VERSIONS_TYPES } from '../../../constants/types/view-versions-types';
import { ComparisonService } from '../../../services/comparison.service';
import { MAX_AMOUNT_OF_COMPARISON_FILES } from '../../../constants/size-values.constants';
import { IToolbarCenterButtons } from '../../../interfaces/toolbar-center-buttons';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';
import { RightPanelButtonsService } from '../../../services/right-panel-buttons.service';
import { VIEW_CONTAINER } from './constants/view-container.constants';
import { WorkspaceViewComponent } from './workspace-view/workspace-view.component';

@Component({
  selector: 'proof-workspace-container',
  templateUrl: './workspace-container.component.html',
  styleUrls: ['./workspace-container.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WorkspaceContainerComponent implements OnInit, OnDestroy {
  public bottomPanelButtons: Observable<IToolbarBottomButtons>;
  public centralPanelButtons: Observable<IToolbarCenterButtons>;
  public splitView = VIEW_VERSIONS_TYPES.SPLIT_VIEW;
  public splitVertical = VIEW_VERSIONS_TYPES.SPLIT_VERTICAL;
  public splitHorizontal = VIEW_VERSIONS_TYPES.SPLIT_HORIZONTAL;
  public oneAsset = VIEW_VERSIONS_TYPES.ONE_ASSET;
  public isRightPanelOpen: boolean;
  public viewContainer = VIEW_CONTAINER;
  public maxAmountOfComparisonFiles = MAX_AMOUNT_OF_COMPARISON_FILES;

  private destroy$: Subject<void> = new Subject();

  @ViewChild(WorkspaceViewComponent)
  private workspaceView: WorkspaceViewComponent;

  constructor(private comparisonService: ComparisonService,
              private centerPanelButtonsService: CenterPanelButtonsService,
              private rightPanelButtonsService: RightPanelButtonsService,
              private bottomPanelButtonsService: BottomPanelButtonsService) {
  }

  get leftSide() {
    return this.viewContainer['first'];
  }

  get rightSide() {
    return this.viewContainer['second'];
  }

  public ngOnInit(): void {
    this.bottomPanelButtons = this.bottomPanelButtonsService.getBottomPanelButtons();
    this.centralPanelButtons = this.centerPanelButtonsService.getCentralPanelButtons();

    this.rightPanelButtonsService.getRightPanelStatus()
      .pipe(takeUntil(this.destroy$))
      .subscribe(rightPanelStatus => {
        this.isRightPanelOpen = rightPanelStatus;
      });
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public setClassOnBlock(fileManagerHidden: boolean, fileManagerMin: boolean): string {
    let classes: string;

    switch (fileManagerHidden) {
      case false:
        classes = 'workspace-area-large';
        break;
      case fileManagerMin:
        classes = 'workspace-area fileManagerMin';
        break;
      default:
        classes = 'workspace-area';
    }

    return classes;
  }

  public setClassOnEmptyCompare(className: string): string {
    return this.isRightPanelOpen ? `${className}-smaller` : className;
  }

  public isSplitViewForComparisonFiles(amountOfComparisonFiles): boolean {
    return true;
    //return amountOfComparisonFiles === this.maxAmountOfComparisonFiles;
  }

  public handleFocusOnSide(side: string): void {
    this.leftSide.selected = false;
    this.rightSide.selected = false;
    this.viewContainer[side].selected = true;
  }
}
