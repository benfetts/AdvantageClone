import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewEncapsulation, ChangeDetectorRef } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { filter, map, takeUntil } from 'rxjs/operators';

import { ComparisonService } from '../../../services/comparison.service';
import { DocumentHistoryService } from '../../../services/document-history.service';
import { IDocument } from '../../../interfaces/document';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';
import { IToolbarCenterButtons } from '../../../interfaces/toolbar-center-buttons';
import { ActiveFileService } from '../../../services/active-file.service';

@Component({
  selector: 'proof-asset-explorer-item',
  templateUrl: './asset-explorer-item.component.html',
  styleUrls: ['./asset-explorer-item.component.scss'],
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AssetExplorerItemComponent implements OnInit, OnDestroy {
  public documents: IDocument[];
  public centerPanelButtons: Observable<IToolbarCenterButtons>;
  public amountOfCompasionedFiles: number;
  public compare: boolean = false;
  private document: IDocument = null

  private destroy$: Subject<void> = new Subject();

  constructor(private documentHistoryService: DocumentHistoryService,
    private comparisonService: ComparisonService,
    private activeFileService: ActiveFileService,
    private centerPanelButtonService: CenterPanelButtonsService,
    private ref: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    this.documentHistoryService.getHistory().pipe(takeUntil(this.destroy$))
      .pipe(filter((docHist) => { return docHist != null })).subscribe((docHist) => {
        this.documents = docHist;

        if (this.documents[0].documentId < this.documents[this.documents.length - 1].documentId) {
          this.documents.reverse();
        }

        this.setSelected();
        this.documents.forEach((v, i, a) => {
          var filenameParts = v.filename.split('.');
          if (filenameParts.length > 1) {
            a[i].extension = filenameParts[filenameParts.length - 1].toLowerCase();
          }
        });
        if (this.documents.length == 2) {
          if (this.compare) {
            this.centerPanelButtonService.setRevision(this.documents[1]);
          }
        }
        this.ref.detectChanges();
      });

    this.centerPanelButtons = this.centerPanelButtonService.getCentralPanelButtons();

    this.activeFileService.getDocument().subscribe((doc) => {
      console.log('document selected', doc);
      this.document = doc;
      this.setSelected();
      this.ref.detectChanges();
    });

    this.centerPanelButtons.pipe(map((buttons) => {
      return buttons.compare;
    })).subscribe((compare) => {
      this.compare = compare.selected;

      if (!compare) {
        this.activeFileService.setDocument(null);
      }
    });

    this.ref.detectChanges();

    this.comparisonService.getComparisonFilesAmount()
      .pipe(takeUntil(this.destroy$))
      .subscribe(amount => {
        this.amountOfCompasionedFiles = amount;
        this.ref.detectChanges();
      });
  }

  private setSelected(): void {
    this.documents.forEach((v, i, a) => {
      if (v.documentId == this.document?.documentId) {
        a[i].selected = true;
      }
      else {
        a[i].selected = false;
      }

    });
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public setSelectedPage(index: number, isCompareView: boolean): void {
    if (isCompareView) {
      this.comparisonService.setComparisonFilesAmount();
      this.documentHistoryService.setDocumentToView(this.documents[index]);
      this.centerPanelButtonService.setRevision(this.documents[index]);
    } else {
      if (!this.documents[index].selected) {
        this.documents.forEach(button => button.selected = false);
        this.documents[index] = { ...this.documents[index], selected: true };
      }
      this.activeFileService.setDocument(this.documents[index]);
    }
  }

  public setClassOnBlock(fileManagerMin: boolean, fileManagerMax: boolean): string {
    let classes: string;
    switch (fileManagerMax) {
      case true:
        classes = 'fileManagerMax';
        break;
      case fileManagerMin:
        classes = 'explorer-area';
        break;
      default:
        classes = 'explorer-area';
    }
    return classes;
  }

  public trackAssets(index: number, item: IDocument): string {
    return `${item.documentId}`;
  }
}
