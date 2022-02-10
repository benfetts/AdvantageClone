import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  Input,
  OnDestroy,
  OnInit,
  ViewEncapsulation,
  ViewChild
} from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { filter, map, takeUntil } from 'rxjs/operators';

import { FILE_NAME_TYPES } from '../../../../constants/types/file-name-types';
import { IPage } from '../../../../interfaces/pages';
import { ONE_HUNDRED_PERCENT, PAGE_VIEWER_BLOCK_WIDTH } from '../../../../constants/size-values.constants';
import { PAGES } from '../../../../constants/pages.constants';
import { SelectedFileTypeService } from '../../../../services/selected-file-type.service';
import { FILE_TYPES } from '../../../../constants/types/file-types';
import { TOOLTIPS } from '../../../../constants/tooltips.constants';
import { RightPanelButtonsService } from '../../../../services/right-panel-buttons.service';
import { CenterPanelButtonsService } from '../../../../services/center-panel-buttons.service';
import { ITooltip } from '../../../../interfaces/tooltip';
import { WebViewerComponent } from '../../../../webviewer/webviewer.component';
import { ActivatedRoute } from '@angular/router';
//import { DocumentHistoryService } from '../../../../services/document-history.service';
import { ActiveFileService } from '../../../../services/active-file.service';
import { WebViewerReadyService } from '../../../../services/web-viewer-ready.service';
import { IDocument } from '../../../../interfaces/document';
import { ComparisonService } from '../../../../services/comparison.service';
import { FeedbackService } from '../../../../services/feedback.service';
import { AssetInfoService } from '../../../../services/asset-info.serivice';

const IMAGE_WIDTH = 960;
const IMAGE_HEIGHT = 540;
const FILE_NAME_LENGTH = 5;
const TAG = 'img';
const FILE_NAME = 'File_na...';

@Component({
  selector: 'proof-workspace-view',
  templateUrl: './workspace-view.component.html',
  styleUrls: ['./workspace-view.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class WorkspaceViewComponent implements OnInit, OnDestroy {

  @Input() public onlyOneAsset: boolean;
  @Input() public sideSelected: boolean;
  @Input() public mainView: boolean = false;

  @ViewChild(WebViewerComponent)
  private webViewer: WebViewerComponent;

  public isRightPanelOpen: boolean;
  public showPageViewer = false;
  public kendoCardWidth = ONE_HUNDRED_PERCENT;
  public widthImg = IMAGE_WIDTH;
  public heigthImg = IMAGE_HEIGHT;
  public currentPage: IPage;
  public pages = PAGES;
  public componentType = FILE_NAME_TYPES.IMAGE_CONTAINER;
  public isDocument = FILE_TYPES.DOCUMENT;
  public isImage = FILE_TYPES.IMAGE;
  public selectedFileType: Observable<string>;
  public centralPanelButtons: Observable<any>;
  public fileName = FILE_NAME;
  public tooltips: ITooltip = TOOLTIPS;
  public fileNameLength = FILE_NAME_LENGTH;
  public dl: string = null;
  public overlay: boolean = false;
  public opened: boolean = false;

  private document: IDocument = null;
  private compareDocument: IDocument = null;

  private destroy$: Subject<void> = new Subject();

  constructor(private rightPanelButtonsService: RightPanelButtonsService,
    private selectedFileTypeService: SelectedFileTypeService,
    private centralPanelButtonsService: CenterPanelButtonsService,
    private comparisonService: ComparisonService,
    private feedbackService: FeedbackService,
    private assetInfoService: AssetInfoService,
    private activatedRouter: ActivatedRoute,
    private activeFileService: ActiveFileService,
    private webViewerReadyService: WebViewerReadyService,
    private ref: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    document.addEventListener('dragstart', function (event: any) {
      if (event.target.localName === TAG) {
        event.preventDefault();
      }
    }, false);

    this.rightPanelButtonsService.getRightPanelStatus()
      .pipe(takeUntil(this.destroy$))
      .subscribe(rightPanelStatus => {
        this.isRightPanelOpen = rightPanelStatus;
        this.ref.detectChanges();
      });

    this.centralPanelButtons = this.centralPanelButtonsService.getCentralPanelButtons()
      .pipe(takeUntil(this.destroy$))
      .pipe(map(buttons => {
        return {
          selection: buttons.selection.selected,
          shapes: buttons.shapes.selected,
          brush: buttons.brush.selected
        };
      }));
    this.selectedFileType = this.selectedFileTypeService.getFileType();
    this.setCurrentPage();
    this.ref.detectChanges();

    if (this.mainView == true) {
      this.webViewerReadyService.getWebViewerReady()
        .pipe(takeUntil(this.destroy$))
        .pipe(filter(r => r == true))
        .subscribe((ready) => {
          this.activeFileService.getDocument()
            .pipe(filter(d => d != null))
            .pipe(takeUntil(this.destroy$))
            .subscribe((document : IDocument) => {
            this.document = document;
              if (this.dl != null) {
                this.webViewer.loadDocument(this.dl, this.document);
              }
            });

          this.comparisonService.getComparisonFilesAmount().subscribe((amount: number) => {
            console.log(amount);
            if (amount < 2) {
              this.feedbackService.loadFeedback(this.document.documentId);
              this.assetInfoService.loadAssetInfo(this.document.documentId);
            }
          });

          this.activatedRouter.queryParams.pipe(filter(e => { return e.dl; })).subscribe(e => {
          this.dl = e.dl;
            this.webViewer.loadDocument(e.dl, this.document);
        });
      });
    }
    else {
      this.webViewerReadyService.getCompareWebViewerReady()
        .pipe(takeUntil(this.destroy$))
        .pipe(filter(r => r == true))
        .subscribe((ready) => {

          this.activeFileService.getDocument()
            .pipe(filter(d => d != null))
            .pipe(takeUntil(this.destroy$))
            .subscribe((document: IDocument) => {
              //in this case we need to know what document is loaded in the other viewer
              this.compareDocument = document;
            });

          this.activatedRouter.queryParams.
            pipe(filter(e => { return e.dl; }), takeUntil(this.destroy$)).
            subscribe(e => {
              this.dl = e.dl;

              if (this.document != null && this.dl != null && this.compareDocument != null && this.compareDocument.documentId != this.document.documentId) {
                if (!this.overlay || (this.compareDocument.mimeType.substr(0, this.compareDocument.mimeType.indexOf('/')).toLowerCase() == this.document.mimeType.substr(0, this.document.mimeType.indexOf('/')).toLowerCase())) {
                  this.webViewer.loadDocument(this.dl, this.document, this.compareDocument);
                }
                else {
                  this.opened = true;
                  this.ref.detectChanges();
                }
              }
            });

          this.centralPanelButtonsService.getCentralPanelButtons()
            .pipe(map(e => { return e.overlay; }), takeUntil(this.destroy$))
            .subscribe((button) => {
              this.overlay = button.selected;
              if (button.selected && this.document != null && this.compareDocument != null && this.compareDocument.documentId != this.document.documentId) {
                if (!this.overlay || (this.compareDocument.mimeType.substr(0, this.compareDocument.mimeType.indexOf('/')).toLowerCase() == this.document.mimeType.substr(0, this.document.mimeType.indexOf('/')).toLowerCase())) {
                  this.webViewer.loadDocument(this.dl, this.document, this.compareDocument);
                }
                else {
                  this.opened = true;
                  this.ref.detectChanges();
                }
              }
          });

          this.centralPanelButtonsService.getRevision()
            .pipe(takeUntil(this.destroy$), filter(d => d != null))
            .subscribe((document) => {
              this.document = document;

              if (this.dl != null && this.document != null && this.compareDocument != null && this.compareDocument.documentId != this.document.documentId) {
                if (!this.overlay ||(this.compareDocument.mimeType.substr(0, this.compareDocument.mimeType.indexOf('/')).toLowerCase() == this.document.mimeType.substr(0, this.document.mimeType.indexOf('/')).toLowerCase())) {
                  this.webViewer.loadDocument(this.dl, this.document, this.compareDocument);
                }
                else {
                  this.opened = true;
                  this.ref.detectChanges();
                }
              }
            });
        });
    }
  }

  public close(status) {
    this.opened = false;
    this.ref.detectChanges();
  }
  public ngOnDestroy(): void {
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

  public setCurrentPage(): void {
    this.currentPage = this.pages.find(page => page.selected);
  }

  public setSelectedStatus(currentPage: number): void {
    this.pages.forEach(page => {
      page.selected = currentPage === page.id;
    });

    this.setCurrentPage();
  }

  public togglePageViewer(): void {
    this.showPageViewer = !this.showPageViewer;
    this.kendoCardWidth = this.showPageViewer
      ? `calc(${ONE_HUNDRED_PERCENT}-${PAGE_VIEWER_BLOCK_WIDTH})`
      : ONE_HUNDRED_PERCENT;
  }

  public pageViewerStatus(documentType: string): boolean {
    if (documentType === this.isImage) {
      this.showPageViewer = false;
    }

    return documentType === this.isDocument && this.showPageViewer;
  }
}
