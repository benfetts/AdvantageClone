import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { GridModule } from '@progress/kendo-angular-grid';
import { ProofingModule } from './modules/proofing/proofing.module';
import { ProofingComponent } from './modules/proofing/components/proofing/proofing.component';
import { APP_BASE_HREF, PlatformLocation } from '@angular/common';
import { EditorModule } from '@progress/kendo-angular-editor';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ProofingModule,
    FormsModule,
    RouterModule.forRoot([
    { path: '', component: ProofingComponent, pathMatch: 'full' },
    { path: 'Proofing', component: ProofingComponent },
    { path: 'proofing', component: ProofingComponent },
], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule,
    GridModule,
    EditorModule
  ],
  providers: [
    {
      provide: APP_BASE_HREF,
      useFactory: (s: PlatformLocation) => s.getBaseHrefFromDOM(),
      deps: [PlatformLocation]
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
