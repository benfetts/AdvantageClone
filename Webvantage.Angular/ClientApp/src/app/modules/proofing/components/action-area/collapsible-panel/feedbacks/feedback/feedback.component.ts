import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnDestroy,
  OnInit,
  ViewChild,
  ViewEncapsulation
} from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { NgScrollbar } from 'ngx-scrollbar';

import { IFeedback } from '../../../../../interfaces/feedback';
import { ResizeHeightService } from '../../../../../services/resize-height.service';

const REPLY_PLACEHOLDER = 'Reply';
const STATIC_CONTENT_HEIGHT = 90;

@Component({
  selector: 'proof-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class FeedbackComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(NgScrollbar, {static: false}) public scrollContainer: NgScrollbar;
  @ViewChild('elementsContainer') public elementsContainer: ElementRef;

  @Input() public feedbacks: IFeedback[];

  public replyPlaceholder = REPLY_PLACEHOLDER;
  public heightScroll: string;
  public contentMoreThanHeight: boolean;

  private destroy$: Subject<void> = new Subject();

  get elmContainer(): HTMLElement {
    return this.elementsContainer.nativeElement;
  }

  constructor(private resizeHeightService: ResizeHeightService,
              private cdr: ChangeDetectorRef) {
  }

  public onFlagClick(i: number): void {
    this.feedbacks[i].flagChecked = !this.feedbacks[i].flagChecked;
  }

  public ngOnInit(): void {
    this.resizeHeightService.getHeight()
      .pipe(takeUntil(this.destroy$))
      .subscribe(height => {
        this.heightScroll = `${height - STATIC_CONTENT_HEIGHT}px`;
        this.updateScrollContainer();
        this.cdr.detectChanges();
      });
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

  newComment(text): void {
    console.log(text);
    alert(text);
  }
}
