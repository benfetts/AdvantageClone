import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BaseService } from "./base.service";
import { catchError, filter, retry } from "rxjs/operators";
import { BehaviorSubject, Observable } from "rxjs";
import { IAgency } from "../interfaces/agency";

@Injectable({
  providedIn: 'root'
})
export class AgencyService extends BaseService {
  dl: string;

  private Agency: BehaviorSubject<IAgency> = new BehaviorSubject<IAgency>(null);

  private WebvantageURL: BehaviorSubject<string> = new BehaviorSubject<string>(null);

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadWVURL();
    });
  }

  loadWVURL(): void {
    var url: string = 'api/ProofingRefresh?dl=' + this.dl;

    const options = { responseType: 'text' as 'text' };
    this.http.get(url, options).subscribe((res) => {
      this.WebvantageURL.next(res);
    });

  //    .pipe(
  //    retry(1),
  //    catchError(this.handleError))
  //    .subscribe((results: string) => {
  //      this.WebvantageURL.next(results);
  //  });
  }

  getWebvantageURL(): Observable<string> {
    return this.WebvantageURL.pipe();
  }
}
