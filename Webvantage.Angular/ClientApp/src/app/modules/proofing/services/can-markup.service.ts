import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BaseService } from "./base.service";
import { catchError, filter, retry } from "rxjs/operators";
import { BehaviorSubject, Observable } from "rxjs";
import { ActiveFileService } from "./active-file.service";
import { IDocument } from "../interfaces/document";

@Injectable({
  providedIn: 'root'
})
export class CanMarkupService extends BaseService {
  dl: string;
  document: IDocument = null;
  private canMarkup$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);


  constructor(private http: HttpClient,
    private activeFileService: ActiveFileService,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });

    //if the document changes check to see if we can make changes
    this.activeFileService.getDocument().subscribe((document) => {
      this.document = document;
      this.canMarkup();
    });
  }

  public canMarkup(): void {
    var url: string = (this.document == null || this.document.documentId == null) ? 'api/CanMarkup?dl=' + this.dl : 'api/CanMarkup/' + this.document.documentId + '?dl=' + this.dl;
    this.http.get(url).pipe(retry(1),
      catchError(this.handleError))
      .subscribe((canMarkup: any) => {
        this.setCanMarkup(canMarkup);
      });
  }

  public setCanMarkup(canMarkup: boolean): void {
    this.canMarkup$.next(canMarkup);
  }

  public getCanMarkup(): Observable<Object> {
    return this.canMarkup$;
  };
}
