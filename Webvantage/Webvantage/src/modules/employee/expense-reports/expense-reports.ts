import { Router, RouterConfiguration } from 'aurelia-router'

export class ExpenseReports {

    router: Router;
    params: any;

    activate(params: any) {
        this.params = params;
    }
    attached() {
        if (this.params) {
            this.router.navigateToRoute('searchAdvanced', this.params);
        }
    }

    configureRouter(config: RouterConfiguration, router: Router) {
        this.router = router;
        config.title = 'Search';
        config.map([
            { route: '', name: 'search', moduleId: 'modules/employee/expense-reports/expense-search' },
            { route: 'search/:EmployeeCode?', name: 'searchAdvanced', moduleId: 'modules/employee/expense-reports/expense-search' },
            { route: 'edit/:id:EmployeeCode?', name: 'edit', moduleId: 'modules/employee/expense-reports/expense-edit' }
        ]);
    }

}
