import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { IFeedback } from "../interfaces/feedback";
import { HttpClient } from "@angular/common/http";
import { ActivatedRoute } from "@angular/router";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";
import { catchError, filter, retry } from "rxjs/operators";
import { IDocument } from "../interfaces/document";
import { IEmployeeMention } from "../interfaces/employee-mention";
import { SignalrService } from "./signalr.services";


@Injectable({
  providedIn: 'root'
})
export class FeedbackService extends BaseService{
  private Feedback$: BehaviorSubject<IFeedback[]> = new BehaviorSubject<IFeedback[]>(null);
  private dl: string;
  private document: IDocument = null;
  private mentions: string[] = null;

  constructor(private http: HttpClient,
    private activeFileService: ActiveFileService,
    private activatedRouter: ActivatedRoute,
    private signalrService: SignalrService  ) {
    super();
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadFeedback();
    });

    this.activeFileService.getDocument()
      .pipe(filter(x => x != null))
      .subscribe((document) => {
        this.document = document;
        this.loadFeedback(document?.documentId);
    });
  }

  //original
  loadEmployees() {
    var url: string = 'api/EmployeeMention?dl=' + this.dl;

    return this.http.get<any>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  loadEmployeesNew(): Observable<IEmployeeMention[]> {
    var url: string = 'api/EmployeeMention?dl=' + this.dl;
    return this.http.get<IEmployeeMention[]>(url)
  }

  loadFeedback(documentId?: number) {
    var url: string = (documentId ? 'api/Feedback/' + documentId + '?dl=' : 'api/Feedback?dl=') + this.dl;

    this.http.get<IFeedback[]>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe((feedback : IFeedback []) => {
        this.Feedback$.next(feedback);
      });
  }

  getFeedBack(): Observable<IFeedback[]> {
    return this.Feedback$;
  }

  createFeedback(feedBack: IFeedback): void{
    var stuff = {
      CommentId: -1,
      AlertId: 0,
      UserCode: '',
      Comment: feedBack.comment,
      ParentId: feedBack.parentId,
      DocumentId: this.document?.documentId,
      mentions: feedBack.mentions
    }

    this.http.post<IFeedback>('api/Feedback?dl=' + this.dl, stuff).pipe(
      catchError(this.handleError)
    ).subscribe((feedBack) => {
      this.loadFeedback(this.document?.documentId);
      //this.updateWVService.updateWebvantageAlert(feedBack.alertId);
      this.signalrService.sendRefresh();
    });
  }

  updateFeedback(feedBack: IFeedback): Observable<IFeedback> {
    var stuff = {
      CommentId: feedBack.commentId,
      AlertId: feedBack.alertId,
      UserCode: '',
      Comment: feedBack.comment,
      ParentId: feedBack.parentId,
      mentions: this.mentions

    }

    return this.http.put<IFeedback>('api/Feedback?dl=' + this.dl, stuff);
  }
}
