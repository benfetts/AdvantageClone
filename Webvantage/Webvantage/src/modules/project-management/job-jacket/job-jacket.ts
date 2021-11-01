import { Router, RouterConfiguration } from 'aurelia-router'

export class JobJacket {

    router: Router;
    params: any;

    activate(params: any) {
        this.params = params;
    }
    attached() {
        
    }

    configureRouter(config: RouterConfiguration, router: Router) {
        this.router = router;
        config.title = 'Search';
        config.map([
            { route: '', name: 'search', moduleId: 'modules/project-management/job-jacket/job-jacket-search' }
        ]);
    }

}
