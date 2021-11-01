import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable, throwError } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { IDocument } from "../interfaces/document";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class AlertDocumentService extends BaseService {

  private Documents: BehaviorSubject<IDocument[]> = new BehaviorSubject<IDocument[]>(null);
  private dl: string = '';

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadDocuments(this.dl);
    });
  }

  loadDocuments(dl: string) {
    this.http.get<IDocument[]>('api/AlertDocuments?dl=' + dl).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((docHist: IDocument[]) => {
      this.Documents.next(docHist);
    });
  }

  getDocuments(): Observable<IDocument[]> {
    return this.Documents;
  }
}
