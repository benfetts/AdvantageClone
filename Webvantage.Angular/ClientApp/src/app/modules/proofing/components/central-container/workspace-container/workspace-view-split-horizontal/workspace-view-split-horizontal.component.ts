import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Input, OnDestroy, OnInit, QueryList, ViewChildren } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { NgScrollbar } from 'ngx-scrollbar';

import { RightPanelButtonsService } from '../../../../services/right-panel-buttons.service';
import { FILE_NAME_TYPES } from '../../../../constants/types/file-name-types';
import { IPage } from '../../../../interfaces/pages';
import { FIFTY_PERCENT, ONE_HUNDRED_PERCENT, PAGE_VIEWER_BLOCK_WIDTH } from '../../../../constants/size-values.constants';
import { SelectedFileTypeService } from '../../../../services/selected-file-type.service';
import { VIEW_VERSIONS_TYPES } from '../../../../constants/types/view-versions-types';
import { VIEW_CONTAINER } from '../constants/view-container.constants';
import { FILE_TYPES } from '../../../../constants/types/file-types';

const IMAGE_WIDTH = 960;
const IMAGE_HEIGHT = 540;

@Component({
  selector: 'proof-workspace-view-split-horizontal',
  templateUrl: './workspace-view-split-horizontal.component.html',
  styleUrls: ['./workspace-view-split-horizontal.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WorkspaceViewSplitHorizontalComponent implements OnInit, OnDestroy {
  @ViewChildren(NgScrollbar) public scrollContainer: QueryList<NgScrollbar>;

  @Input() public onlyOneAsset: boolean;

  public isRightPanelOpen: boolean;
  public showPageViewer = false;
  public kendoCardWidth = ONE_HUNDRED_PERCENT;
  public widthImg = IMAGE_WIDTH;
  public heigthImg = IMAGE_HEIGHT;
  public currentPage: IPage;
  public componentType = FILE_NAME_TYPES.IMAGE_CONTAINER;
  public isDocument = FILE_TYPES.DOCUMENT;
  public isImage = FILE_TYPES.IMAGE;
  public viewType = VIEW_VERSIONS_TYPES.SPLIT_HORIZONTAL;
  public viewContainer = VIEW_CONTAINER;
  public selectedFileType: Observable<string>;

  private destroy$: Subject<void> = new Subject();

  constructor(private rightPanelButtonsService: RightPanelButtonsService,
              private selectedFileTypeService: SelectedFileTypeService,
              private ref: ChangeDetectorRef) {
  }

  get leftSide() {
    return this.viewContainer['first'];
  }

  get rightSide() {
    return this.viewContainer['second'];
  }

  public ngOnInit(): void {
    this.rightPanelButtonsService.getRightPanelStatus()
      .pipe(takeUntil(this.destroy$))
      .subscribe(rightPanelStatus => {
        this.isRightPanelOpen = rightPanelStatus;
        this.ref.detectChanges();
      });

    this.selectedFileType = this.selectedFileTypeService.getFileType();
    this.ref.detectChanges();
  }

  public ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public setClassOnBlock(className: string): string {
    let classes: string;

    switch (this.isRightPanelOpen) {
      case this.onlyOneAsset && false:
        classes = `only-one-asset ${className}`;
        break;
      case this.onlyOneAsset:
        classes = `only-one-asset ${className}-smaller`;
        break;
      case true:
        classes = `${className}-smaller`;
        break;
      case false:
        classes = className;
        break;
      default:
        classes = 'explorer-area-min';
    }
    return classes;
  }

  public setCurrentPage(side: string): void {
    this.viewContainer[side].currentPage = this.viewContainer[side].pages.find(page => page.selected);
  }

  public setSelectedStatus(currentPage: number, side: string): void {
    this.viewContainer[side].pages.forEach(page => {
      page.selected = currentPage === page.id;
    });

    this.setCurrentPage(side);
  }

  public togglePageViewer(side: string): void {
    this.viewContainer[side].showPageViewer = !this.viewContainer[side].showPageViewer;
    this.viewContainer[side].kendoCardWidth = this.viewContainer[side].showPageViewer
      ? `calc(${ONE_HUNDRED_PERCENT}-${PAGE_VIEWER_BLOCK_WIDTH})`
      : ONE_HUNDRED_PERCENT;
    this.viewContainer[side].containerWidth = this.viewContainer[side].showPageViewer
      ? `calc(${FIFTY_PERCENT}-${PAGE_VIEWER_BLOCK_WIDTH})`
      : FIFTY_PERCENT;
    this.ref.detectChanges();
  }

  public pageViewerStatus(documentType: string, side: string) {
    if (documentType === this.isImage) {
      this.showPageViewer = false;
    }

    return documentType === this.isDocument && this.viewContainer[side].showPageViewer;
  }

  public handleFocusOnSide(side: string): void {
    this.leftSide.selected = false;
    this.rightSide.selected = false;
    this.viewContainer[side].selected = true;
  }

  private updateScrollContainer(): void {
    setTimeout(() => {
      if (this.scrollContainer) {
        this.scrollContainer.forEach(scrollBar => scrollBar.update());
      }
    }, 200);
  }
}
