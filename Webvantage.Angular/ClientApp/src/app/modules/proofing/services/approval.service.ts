import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { IDocument } from "../interfaces/document";
import { ProofingStatusID, IReviewer, IReviewerGroup } from "../interfaces/reviewer";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";
import { CanMarkupService } from "./can-markup.service";
import { CanUpdateStatusService } from "./can-update-status.service";
import { FeedbackService } from "./feedback.service";
import { SignalrService } from "./signalr.services";

@Injectable({
  providedIn: 'root'
})
export class ApprovalService extends BaseService {

  private Reviewers: BehaviorSubject<IReviewerGroup[]> = new BehaviorSubject<IReviewerGroup[]>(null);
  private dl: string;

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private activeFileService: ActiveFileService,
    private feedBackService: FeedbackService,
    private canUpdateStatusService: CanUpdateStatusService,
    private canMarkupService: CanMarkupService,
    private signalrService: SignalrService  ) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadReviewers();
    });

    this.activeFileService.getDocument()
      .subscribe((document: IDocument) => {
        this.loadReviewers(document?.documentId);
      })

  }

  getReviewers(): Observable<IReviewerGroup[]> {
    return this.Reviewers.pipe();
  }

  approve(approvalSatus: ProofingStatusID,DocumentId? : number) {
    console.log('Loading reviewers for ', DocumentId);

    var url: string = 'api/Approval?dl=' + this.dl;

    var data = {
      EmpCode: '',
      EmpFullName: '',
      UserCode: '',
      DateApproved: null,
      ApprovalStatus: approvalSatus,
      DocumentId: DocumentId
    }

    this.http.post<IReviewer>(url, data).subscribe((result) => {
      this.loadReviewers();
      this.feedBackService.loadFeedback(DocumentId);
      this.canUpdateStatusService.canUpdateStatus();
      this.canMarkupService.canMarkup();
      this.signalrService.sendRefresh();
    });
  }

  loadReviewers(documentId?: number) {
    var url: string = (documentId ? 'api/Approval/' + documentId + '?dl=' : 'api/Approval?dl=') + this.dl;

    this.http.get<IReviewerGroup []>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
    ).subscribe((reviewers: IReviewerGroup[]) => {
        console.log(reviewers);
        this.Reviewers.next(reviewers);
      });
  }
}
