import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { NgScrollbar } from 'ngx-scrollbar';
import { filter, takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

import { IAssetInfoAsset } from '../../../../interfaces/asset-info/asset';
import { IAssetInfoFile } from '../../../../interfaces/asset-info/file';
import { additionalInfoMock } from '../../../../constants/asset-info/additional-info-mock.constants';
import { ResizeHeightService } from '../../../../services/resize-height.service';
import { AssetInfoService } from '../../../../services/asset-info.serivice';
import { IAssetInfo } from '../../../../interfaces/asset-info';


const STATIC_CONTENT_HEIGHT = 31;

@Component({
  selector: 'proof-asset-info',
  templateUrl: './asset-info.component.html',
  styleUrls: ['./asset-info.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AssetInfoComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(NgScrollbar, {static: false}) public scrollContainer: NgScrollbar;
  @ViewChild('elementsContainer') public elementsContainer: ElementRef;

  public assetInfo: IAssetInfo = null;

  public additionalInfoMock: string = additionalInfoMock;
  public heightScroll: string;
  public contentMoreThanHeight: boolean;

  private destroy$: Subject<void> = new Subject();

  get elmContainer(): HTMLElement {
    return this.elementsContainer.nativeElement;
  }

  constructor(private resizeHeightService: ResizeHeightService,
    private cdr: ChangeDetectorRef,
    private assetInfoService: AssetInfoService) {
  }

  public ngOnInit(): void {
    this.resizeHeightService.getHeight()
      .pipe(takeUntil(this.destroy$))
      .subscribe(height => {
        this.heightScroll = `${height - STATIC_CONTENT_HEIGHT}px`;
        this.updateScrollContainer();
        this.cdr.detectChanges();
      });
    console.log('ngOnInit');
    this.assetInfoService.getAssetInfo()
      .pipe(filter((assetInfo: IAssetInfo) => {
        return assetInfo != null;
      }))
      .subscribe((assetInfo: IAssetInfo) => {
        console.log(assetInfo);
        this.assetInfo = assetInfo;
        this.cdr.detectChanges();
      })
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
