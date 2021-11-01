import { Router, RouterConfiguration } from 'aurelia-router';

export class App {

    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.map([
            { route: '', name: 'home', moduleId: 'webvantage' },
            { route: 'expense-reports', moduleId: 'modules/employee/expense-reports/index', nav: true, title: 'Expense Reports' },
            { route: 'AppSignIn', moduleId: 'modules/utilities/sign-in', nav: true, title: 'Sign In' }
        ]);
        config.fallbackRoute('AppSignIn');
        this.router = router;
    }

}
