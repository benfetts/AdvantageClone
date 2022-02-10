import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { NgScrollbar } from 'ngx-scrollbar';

import { APPROVAL_REVIEW_BUTTONS_TYPES } from '../../../../../constants/approval-review-buttons.constants';
import { IApprovalReviewButtons } from '../../../../../interfaces/approval-review-buttons';
import { ResizeHeightService } from '../../../../../services/resize-height.service';
import { ApprovalService } from '../../../../../services/approval.service';
import { APPROVAL_TABLE_HEADER } from '../../../../../constants/approval-table-header.constants';
import { ProofingStatusID, IReviewerGroup } from '../../../../../interfaces/reviewer';
import { CanUpdateStatusService } from '../../../../../services/can-update-status.service';
import { ActiveFileService } from '../../../../../services/active-file.service';
import { CurrentVersionService } from '../../../../../services/current-version.service';
import { IDocument } from '../../../../../interfaces/document';
import { AnnotationService } from '../../../../../services/annotation.service';

const STATIC_CONTENT_HEIGHT = 132;

@Component({
  selector: 'proof-review-approval',
  templateUrl: './review-approval.component.html',
  styleUrls: ['./review-approval.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewApprovalComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(NgScrollbar, {static: false}) public scrollContainer: NgScrollbar;
  @ViewChild('elementsContainer') public elementsContainer: ElementRef;

  public approvalReviewButtons: IApprovalReviewButtons = JSON.parse(JSON.stringify(APPROVAL_REVIEW_BUTTONS_TYPES));
  public approvalTableHeader: string[] = APPROVAL_TABLE_HEADER;
  public reviewers: IReviewerGroup[];
  public heightScroll: string;
  public contentMoreThanHeight: boolean = true;
  public canUpdate: boolean = false;
  public disabled: boolean = true;
  public currentVersion: boolean = false;
  public opened: boolean = false;

  public accept: number = ProofingStatusID.Accept;
  public defer: number = ProofingStatusID.Defer;
  public reject: number = ProofingStatusID.Reject;
  public document: IDocument = null;

  public approvalStatus: ProofingStatusID;

  private destroy$: Subject<void> = new Subject();

  get elmContainer(): HTMLElement {
    return this.elementsContainer.nativeElement;
  }

  constructor(private resizeHeightService: ResizeHeightService,
    private approvalService: ApprovalService,
    private canUpdateStatusService: CanUpdateStatusService,
    private activeFileService: ActiveFileService,
    private currentVersionService: CurrentVersionService,
    private annotationService: AnnotationService,
    private cdr: ChangeDetectorRef) {
  }

  public ngOnInit(): void {
    this.resizeHeightService.getHeight()
      .pipe(takeUntil(this.destroy$))
      .subscribe(height => {
        this.heightScroll = `${height - STATIC_CONTENT_HEIGHT}px`;
        this.updateScrollContainer();
        this.cdr.detectChanges();
      });

    this.approvalService.getReviewers()
      .pipe(takeUntil(this.destroy$))
      .subscribe((reviewers: IReviewerGroup[]) => {
      this.reviewers = reviewers;
      this.cdr.detectChanges();
      });

    this.canUpdateStatusService.getCanUpdateStatus().subscribe((canUpdate: boolean) => {
      console.log(canUpdate);
      this.canUpdate = canUpdate;
      this.setDisabled();
    });

    this.activeFileService.getDocument()
      .pipe(takeUntil(this.destroy$))
      .subscribe((document: IDocument) => {
        this.document = document;
      });

    this.currentVersionService.getIsCurrentRevision().pipe().subscribe((current) => {
      this.currentVersion = current;
      this.setDisabled();
    });
  }

  public setDisabled() {
    if (this.currentVersion && this.canUpdate) {
      this.disabled = false;
    }
    else {
      this.disabled = true;
    }

    this.cdr.detectChanges();
  }

  public Approve(approvalStatus: ProofingStatusID) {
    this.approvalStatus = approvalStatus;
    if (this.annotationService.getDraftAnnotationCount() == 0) {
      this.approvalService.approve(approvalStatus, this.document?.documentId);
    }
    else {
      console.log('draft annotations exist');
      this.opened = true;
      this.cdr.detectChanges();
    }
  }

  public close(status) {
    console.log(`Dialog result: ${status}`);
    if (status == 'yes') {
      this.annotationService.deleteDraftAnnotations();

      this.approvalService.approve(this.approvalStatus, this.document?.documentId);

    }
    this.opened = false;
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public ngAfterViewInit(): void {
    this.updateContentHeight();
  }

  private updateScrollContainer(): void {
    setTimeout(() => {
      if (this.scrollContainer) {
        this.scrollContainer.update();
        this.updateContentHeight();
      }
    }, 200);
  }

  private updateContentHeight(): void {
    this.contentMoreThanHeight = parseInt(this.heightScroll, 10) >= this.elmContainer.offsetHeight;
  }
}
