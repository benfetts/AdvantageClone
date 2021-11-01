import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ExpenseReportComponent } from './employee/expense-reports/expense-report/expense-report.component';

@NgModule({
  declarations: [
    AppComponent,
    ExpenseReportComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
