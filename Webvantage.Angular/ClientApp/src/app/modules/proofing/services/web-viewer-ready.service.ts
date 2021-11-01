import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class WebViewerReadyService {
  private webViewerReady: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  private compareWebViewerReady: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  getWebViewerReady(): Observable<boolean> {
    return this.webViewerReady;
  }

  setWebViewerReady(ready: boolean): void {
    this.webViewerReady.next(ready);
  }

  getCompareWebViewerReady(): Observable<boolean> {
    return this.compareWebViewerReady;
  }

  setCompareWebViewerReady(ready: boolean): void {
    this.compareWebViewerReady.next(ready);
  }
}
