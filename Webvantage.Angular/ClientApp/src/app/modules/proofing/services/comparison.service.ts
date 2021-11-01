import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

const ZERO = 0;
const ONE = 1;
const TWO = 2;

@Injectable({
  providedIn: 'root'
})
export class ComparisonService {
  private comparison: BehaviorSubject<number> = new BehaviorSubject<number>(ONE);

  public setComparisonFilesAmount(): void {
    console.log('setComparisonFilesAmount', this.comparison.value);

    if (this.comparison.value + ONE > TWO) {
      this.comparison.next(ZERO);
    }
    this.comparison.next(this.comparison.value + ONE);
  }

  public resetComparisonFilesAmount(): void {
    console.log('reset comparison');
    this.comparison.next(ONE);
  }

  public getComparisonFilesAmount(): Observable<number> {
    return this.comparison;
  }
}
