import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResizeHeightService {
  private rightPanelHeight: BehaviorSubject<number | null> = new BehaviorSubject<number | null>(null);

  public setHeight(value: number | null): void {
    this.rightPanelHeight.next(value);
  }

  public getHeight(): Observable<number | null> {
    return this.rightPanelHeight;
  }
}
