import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { filter, takeUntil } from 'rxjs/operators';
import { IDocument } from '../../../interfaces/document';
import { IToolbarBottomButtons } from '../../../interfaces/toolbar-bottom-buttons';
import { ActiveFileService } from '../../../services/active-file.service';
import { AlertDocumentService } from '../../../services/alert-document.service';
import { BottomPanelButtonsService } from '../../../services/bottom-panel-buttons.service';
import { CenterPanelButtonsService } from '../../../services/center-panel-buttons.service';

@Component({
  selector: 'proof-alert-documents',
  templateUrl: './alert-documents.component.html',
  styleUrls: ['./alert-documents.component.scss']
})
export class AlertDocumentsComponent implements OnInit, OnDestroy {
  public documents: IDocument[];
  private destroy$: Subject<void> = new Subject();
  private document: IDocument = null

  public bottomPanelButtons: Observable<IToolbarBottomButtons>;
  public amountOfCompasionedFiles: number;

  constructor(private alertDocumentService: AlertDocumentService,
    private bottomPanelButtonsService: BottomPanelButtonsService,
    private activeFileService: ActiveFileService,
    private centerPanelButtonService: CenterPanelButtonsService,
    private ref: ChangeDetectorRef) {
  }

  ngOnInit(): void {
    this.alertDocumentService.getDocuments().pipe(takeUntil(this.destroy$)).pipe(filter(d => d != null)).subscribe((documents: IDocument[]) => {
      this.documents = documents;

      this.documents.forEach((v, i, a) => {
        var filenameParts = v.filename.split('.');

        if (filenameParts.length > 1) {
          a[i].extension = filenameParts[filenameParts.length - 1].toLowerCase();
        }
      });
      this.ref.detectChanges();
    });

    this.bottomPanelButtons = this.bottomPanelButtonsService.getBottomPanelButtons();

    this.activeFileService.getDocument().subscribe((doc) => {
      this.document = doc;
      this.setSelected();
      this.ref.detectChanges();
    });
  }

  private setSelected(): void {
    if (this.documents) {
      this.documents.forEach((v, i, a) => {
        if (v.documentId == this.document.documentId) {
          a[i].selected = true;
        }
        else {
          a[i].selected = false;
        }

      });
    }
  }


  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
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
        classes = 'explorer-area-min';
    }
    return classes;
  }

  public trackAssets(index: number, item: IDocument): string {
    return `${item.documentId}`;
  }

  setSelectedDocument(index: number): void {
    if (!this.documents[index].selected) {
      this.documents.forEach(button => button.selected = false);
      this.documents[index] = { ...this.documents[index], selected: true };
    }

    this.centerPanelButtonService.setRevision(null);

    this.activeFileService.setDocument(this.documents[index]);
  }
}
