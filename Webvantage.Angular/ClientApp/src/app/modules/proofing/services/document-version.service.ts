import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'any'
})
export class DocumentVersionService extends BaseService {

  dl: string;

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter((e: any) => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });
  }

  getVersion(DocumentID?: number): Observable<Object> {
    var url: string = (DocumentID ? 'api/DocumentVersion/' + DocumentID + '?dl=' : 'api/DocumentVersion?dl=') + this.dl;

    return this.http.get(url).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }
}
