import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { IDocument } from "../interfaces/document";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { catchError, filter, retry } from "rxjs/operators";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class DocumentHistoryService extends BaseService  {
  private Documents: BehaviorSubject<IDocument[]> = new BehaviorSubject<IDocument[]>(null);
  private dl: string = '';
  private documentToView: BehaviorSubject<IDocument> = new BehaviorSubject<IDocument>(null);
  private document: IDocument = null;

  constructor(private http: HttpClient,
    private activeFileService: ActiveFileService,
    private activatedRouter: ActivatedRoute) {
    super();
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadDocumentHistory(this.dl,this.document?.documentId);
    });

    this.activeFileService.getDocument().pipe(filter(x => x != null)).subscribe((document : IDocument) => {
      this.document = document;
      this.loadDocumentHistory(this.dl, this.document?.documentId);
    });
  }

  setDocumentToView(document: IDocument) {
    this.documentToView.next(document);
  }

  getDocumentToView(): Observable<IDocument> {
    return this.documentToView;
  }

  loadDocumentHistory(dl: string, documentId : number) {
    var url: string = 'api/DocumentHistory' + (documentId != null ? '/' + documentId + '?dl=' : '?dl=') + dl;

    this.http.get<IDocument[]>(url).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((docHist) => {
      this.Documents.next(docHist);
    });
  }

  getHistory(): Observable<IDocument[]> {
    return this.Documents;
  }
}
