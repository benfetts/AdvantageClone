import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SliderToolService {
  private sliderValue: BehaviorSubject<number> = new BehaviorSubject<number>(100);
  private fitMode: BehaviorSubject<string> = new BehaviorSubject<string>('actualSize');

  public setSliderValue(value: number): void {
    this.sliderValue.next(value);
  }

  public getSliderValue(): Observable<number> {
    return this.sliderValue;
  }

  public getFitMode(): Observable<string> {
    return this.fitMode;
  }

  public setFitMode(value: string): void {
    this.fitMode.next(value);
  }
}
