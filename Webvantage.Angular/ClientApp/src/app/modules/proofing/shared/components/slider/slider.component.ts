import { Component, OnInit, Output, ViewEncapsulation, EventEmitter, OnDestroy, Input } from '@angular/core';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

import { SliderToolService } from '../../../services/slider-tool.service';

@Component({
  selector: 'proof-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class SliderComponent implements OnInit, OnDestroy {
  @Output() public changeValue = new EventEmitter<number>();
  @Input() public isSidePanel = false;

  public showButtons = false;
  @Input() public value = 5;
  @Input() public min: number = 5;
  @Input() public max: number = 300;
  @Input() public smallStep = 1;
  @Input() public disabled: boolean = false;
  public tickPlacement = 'none';

  private destroy$: Subject<void> = new Subject();

  constructor(private sliderToolService: SliderToolService) {
  }

  public ngOnInit(): void {
    if (!this.isSidePanel) {
      this.sliderToolService.getSliderValue()
        .pipe(takeUntil(this.destroy$))
        .subscribe(value => {
          this.value = value;
          this.changeValue.emit(this.value);
        });
    }
  }

  public ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  public onValueChange(value: number): void {
    if (!this.isSidePanel) {
      this.sliderToolService.setSliderValue(value);
    }
    this.changeValue.emit(value);
  }

  public parseFloat(value): number{
    return parseFloat(value);
  }
}
