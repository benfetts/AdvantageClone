import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { REVIEW_TYPES } from '../constants/types/review-types';

@Injectable({
  providedIn: 'root'
})
export class ReviewTypeService {
  private reviewType: BehaviorSubject<string> = new BehaviorSubject<string>('Approval');

  public setReviewType(value: string): void {
    this.reviewType.next(value);
  }

  public getReviewType(): Observable<string> {
    return this.reviewType;
  }
}
