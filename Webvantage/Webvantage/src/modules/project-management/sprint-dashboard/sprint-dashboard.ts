import { ModuleBase } from 'modules/base/module-base';
import { bindable, observable, inject } from 'aurelia-framework';
import { SprintDashboardService } from 'services/project-management/sprint-dashboard-service';

@inject(SprintDashboardService)
export class SprintDashboard extends ModuleBase {

    @observable sprintID: number;
    @observable isActive: boolean;
    service: SprintDashboardService;
    message: string = 'Hello World';
    seriesDefaults = {
        type: 'bar'
    };

    sprintIDChanged(newValue, oldValue) {
        this.getDashboard();
    }
    isActiveChanged(newValue, oldValue) {
        this.alert('is active changed to: ' + this.isActive);
    }
    toggleIsActive() {
        this.isActive = !this.isActive;
    }


    series = [{
        name: 'Total Visits',
        data: [56000, 63000, 74000, 91000, 117000, 138000]
    }, {
        name: 'Unique visitors',
        data: [52000, 34000, 23000, 48000, 67000, 83000]
    }];

    valueAxis = {
        max: 140000,
        line: {
            visible: false
        },
        minorGridLines: {
            visible: true
        },
        labels: {
            rotation: 'auto'
        }
    };

    categoryAxis = {
        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
        majorGridLines: {
            visible: false
        }
    };

    tooltip = {
        visible: true,
        template: '${series.name} ${value}'
    }

    getDashboard() {
        if (this.sprintID > 0) {
            this.service.getDashboard(this.sprintID).then(response => {
                this.message = response.content.DashboardName;
            });
        }
    }

    activate(params: any) {
        this.sprintID = params.SprintID;
    }

    constructor(service: SprintDashboardService) {
        super();
        this.service = service;
    }

}
