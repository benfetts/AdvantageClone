import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { IDocument } from "../interfaces/document";
import { BaseService } from "./base.service";
import { LatestVersionService } from "./latest-version.service";

@Injectable({
  providedIn: 'root'
})
export class ActiveFileService extends BaseService  {

  private document: BehaviorSubject<IDocument> = new BehaviorSubject<IDocument>(null);

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private latestVersionService: LatestVersionService  ) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.latestVersionService.getLatestVersion(e.dl).subscribe(documentId => {
        this.loadDocument(e.dl, documentId);
      });
    });
  }

  getDocument(): Observable<IDocument> {
    return this.document;
  }

  setDocument(document: IDocument): void {
    this.document.next(document);
  }

  loadDocument(dl: string, docimentId?: number) {
    this.http.get<IDocument>((docimentId ? 'api/DocumentInfo/' + docimentId +'?dl=' : 'api/DocumentInfo?dl=') + dl).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((doc: IDocument) => {
      this.setDocument(doc);
    });
  }
}
