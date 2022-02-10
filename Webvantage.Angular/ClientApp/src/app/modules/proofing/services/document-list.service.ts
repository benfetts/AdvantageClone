import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, filter, map, retry } from "rxjs/operators";
import { ALERT_DOCUMENTS, VERSIONS } from "../constants/document-list.constants";
import { IDocument } from "../interfaces/document";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";
import { CenterPanelButtonsService } from "./center-panel-buttons.service";

@Injectable({
  providedIn: 'root'
})
export class DocumentListService extends BaseService {

  private Documents: BehaviorSubject<IDocument[]> = new BehaviorSubject<IDocument[]>(null);
  private dl: string = '';
  private document: IDocument = null;

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private activeFileService: ActiveFileService,
    private centerPanelButtonService: CenterPanelButtonsService  ) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadDocuments(ALERT_DOCUMENTS);
    });

    this.activeFileService.getDocument().pipe(filter(e => { return e != null })).subscribe((activeFile: IDocument) => {
      this.document = activeFile;
    });

    this.centerPanelButtonService.getCentralPanelButtons().pipe(map(e => {
      return e.version;
    })).subscribe((button) => {
      if (button.selected) {
        this.loadDocuments(VERSIONS, this.document?.documentId);
      }
      else {
        this.loadDocuments(ALERT_DOCUMENTS);
      }
    });
  }

  getDocuments(): Observable<IDocument[]> {
    return this.Documents;
  }

  loadDocuments(mode: string,documentId? : number) {
    if (mode == VERSIONS) {
      this.loadDocumentHistory(this.dl, documentId);
    }
    else {
      this.loadAlertDocuments(this.dl);
    }
  }

  private loadAlertDocuments(dl: string) {
    this.http.get<IDocument[]>('api/AlertDocuments?dl=' + dl).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((docHist: IDocument[]) => {
      this.Documents.next(docHist);
    });
  }

  private loadDocumentHistory(dl: string, documentId: number) {
    var url: string = 'api/DocumentHistory' + (documentId != null ? '/' + documentId + '?dl=' : '?dl=') + dl;

    this.http.get<IDocument[]>(url).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((docHist) => {
      if (docHist && docHist[0].documentId < docHist[docHist.length - 1].documentId) {
        docHist.reverse();
      }

      this.Documents.next(docHist);
    });
  }
}
