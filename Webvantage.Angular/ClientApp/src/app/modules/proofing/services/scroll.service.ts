import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { filter } from "rxjs/operators";
import { IScrollEvent } from "../interfaces/scroll-event";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class ScrollService extends BaseService {
  private ScrollEvent$: BehaviorSubject<IScrollEvent> = new BehaviorSubject<IScrollEvent>(null);
  private lockScroll: boolean = true;

  setLock(lock: boolean) {
    this.lockScroll = lock;
  }

  getLock(): boolean {
    return this.lockScroll;
  }

  setScrollEvent(scrollEvent: IScrollEvent) {
    this.ScrollEvent$.next(scrollEvent);
  }

  getScrollEvent(): Observable<IScrollEvent> {
    return this.ScrollEvent$.pipe(filter((e) => e != null))
  }
}
