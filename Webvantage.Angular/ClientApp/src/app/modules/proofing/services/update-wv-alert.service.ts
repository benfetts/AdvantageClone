import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BaseService } from "./base.service";
import { filter } from "rxjs/operators";
import { AgencyService } from "./agency.service";
import { IAgency } from "../interfaces/agency";

@Injectable({
  providedIn: 'root'
})
export class UpdateWVService extends BaseService {

  dl: string;
  agency: IAgency = null;
  WebvantageUrl: string;

  constructor(private agencyService: AgencyService,
    private http: HttpClient,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });

    this.agencyService.getWebvantageURL().subscribe((WvUrl: string) => {
      this.WebvantageUrl = WvUrl;
    });
  }

  updateWebvantageAlert(alertId: number): void {
    if (this.WebvantageUrl != null) {
      var url = this.WebvantageUrl + '/Desktop/Alert/RefreshProofingAssignment?AlertID=' + alertId; // <-- This needs to be our encrypted URL!
      this.http.get(url).subscribe((result) => {
        console.log(result);
      });
    }
  }
}
