import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class CurrentVersionService extends BaseService {

  private currentRevision: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private dl: string;

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private activeFileService : ActiveFileService  ) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadIsCurrentRevision();
    });

    this.activeFileService.getDocument().subscribe((document) => {
      this.loadIsCurrentRevision(document?.documentId);
    });
  }

  loadIsCurrentRevision(documentId?: number): void {
    var url: string = (documentId ? 'api/CurrentVersion/' + documentId + '?dl=' : 'api/CurrentVersion?dl=') + this.dl;

    this.http.get<boolean>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
    ).subscribe((current: boolean) => {
      console.log('is current revision', current)
      this.setIsCurrentRevision(current);
      });
  }

  getIsCurrentRevision(): Observable<boolean> {
    return this.currentRevision.pipe();
  }

  setIsCurrentRevision(current: boolean): void {
    this.currentRevision.next(current);
  }
}
