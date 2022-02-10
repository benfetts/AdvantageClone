import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, filter, retry } from "rxjs/operators";
import { BaseService } from "./base.service";
import * as signalR from "@microsoft/signalr";
import { ActivatedRoute } from "@angular/router";


@Injectable({
  providedIn: 'root'
})
export class SignalrService extends BaseService {

  private hubConnection: signalR.HubConnection;
  private dl: string;

  constructor(private http: HttpClient,
    private activatedRouter: ActivatedRoute) {
    super();

    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
    });
  }

  public StartConnection() {
  //  this.hubConnection = new signalR.HubConnectionBuilder()
  //    .configureLogging(signalR.LogLevel.Debug)
  //    .withUrl('proofingRefreshHub')
  //    .build();


  //  this.hubConnection
  //    .start()
  //    .then(() => console.log('Connection started'))
  //    .catch(err => {
  //      console.log('Error while starting connection: ' + err)
  //    })
  }

  public addTransferChartDataListener(): void {
    this.hubConnection.on('notify', (data) => {
      //this.data = data;
      console.log(data);
    });
  }

  sendRefresh(): void {

    console.log('sendRefresh');

    this.http.get('api/ProofingRefresh?dl=' + this.dl, {
      responseType: 'text'
    }).pipe(
      retry(1),
      catchError(this.handleError)
    ).subscribe((results: string) => {
      console.log(results);
      if (results && results != '') {
        this.http.get(results).subscribe((newResults) => {
          console.log(newResults);
        });
      }
    });
  }
}
