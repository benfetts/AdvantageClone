import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { catchError, filter, retry } from "rxjs/operators";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: 'root'
})
export class LatestVersionService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getLatestVersion(dl: string) {

    return this.http.get<number>('api/LatestVersion?dl=' + dl).pipe(
      retry(1),
      catchError(this.handleError)
    );
  }
}
