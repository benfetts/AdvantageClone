import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgScrollbar } from 'ngx-scrollbar';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { ResizeHeightService } from '../../../../../services/resize-height.service';

const STATIC_CONTENT_HEIGHT = 86;

@Component({
  selector: 'proof-review-versions',
  templateUrl: './review-versions.component.html',
  styleUrls: ['./review-versions.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ReviewVersionsComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(NgScrollbar, {static: false}) public scrollContainer: NgScrollbar;
  @ViewChild('elementsContainer') public elementsContainer: ElementRef;

  public reviewVersions = null;
  public heightScroll: string;
  public contentMoreThanHeight: boolean;

  private destroy$: Subject<void> = new Subject();

  get elmContainer(): HTMLElement {
    return this.elementsContainer.nativeElement;
  }

  constructor(private resizeHeightService: ResizeHeightService,
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
