import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { catchError, filter, retry } from "rxjs/operators";
import { IAssetInfo } from "../interfaces/asset-info";
import { IDocument } from "../interfaces/document";
import { ActiveFileService } from "./active-file.service";
import { BaseService } from "./base.service";


@Injectable({
  providedIn: 'root'
})
export class AssetInfoService extends BaseService {

  dl: string = null;
  private $assetInfo: BehaviorSubject<IAssetInfo> = new BehaviorSubject<IAssetInfo>(null);


  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute,
    private activeFileService: ActiveFileService) {
    super();

    this.activatedRouter.queryParams.pipe(filter((e: any)=> {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.loadAssetInfo();
    });

    this.activeFileService.getDocument().pipe(filter((document) => document != null)).subscribe((document: IDocument) => {
      this.loadAssetInfo(document?.documentId);
    });
  }

  getAssetInfo(): Observable<IAssetInfo>{
    return this.$assetInfo.pipe();
  }

  loadAssetInfo(documentId? : number): void {
    var url: string = (documentId ? 'api/AssetInfo/' + documentId + '?dl=' : 'api/AssetInfo?dl=') + this.dl;

    this.http.get<IAssetInfo>(url)
      .pipe(
        retry(1),
        catchError(this.handleError)
      ).subscribe((assetInfo: IAssetInfo) => {
        console.log(assetInfo);
        assetInfo.uploadDate = new Date(assetInfo.uploadDate);

        if (assetInfo.versions) {
          assetInfo.versions.forEach((v, i, a) => {
            a[i].uploadDate = new Date(v.uploadDate);
          });
        }

        this.$assetInfo.next(assetInfo);
      });
  }
}
