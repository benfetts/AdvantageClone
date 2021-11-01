import { APP_BASE_HREF } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
import { TooltipSettings } from '@progress/kendo-angular-tooltip';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'proof-core',
  templateUrl: './proofing.component.html',
  styleUrls: ['./proofing.component.scss'],
  providers: [{
    provide: TooltipSettings,
    useFactory: (): TooltipSettings => ({
      closeTitle: '',
      position: 'bottom'
    })
  }]
})
export class ProofingComponent implements OnInit  {

  baseHref: string = "";
  private dl: string = '';

  constructor(private http: HttpClient,
    private titleService: Title,
    private activatedRouter: ActivatedRoute,
    @Inject(APP_BASE_HREF) baseHref: string  ) {
    this.baseHref = baseHref;
  }

  ngOnInit(): void {
    this.activatedRouter.queryParams.pipe(filter(e => {
      return e.dl;
    })).subscribe(e => {
      this.dl = e.dl;
      this.setTitle();
    });
  }

  setTitle() {
    this.http.get(this.baseHref + 'api/ProofingDocumentName?dl=' + this.dl, { responseType: 'text' })
      .subscribe((filename: string) => {
        this.titleService.setTitle(filename);
      });
  }
}
