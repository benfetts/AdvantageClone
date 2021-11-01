import { DashboardService } from 'services/dashboard/dashboard-service';
import { inject } from 'aurelia-framework';
import { ModuleBase } from 'modules/base/module-base';
import { HttpClient } from 'aurelia-http-client';

@inject(DashboardService)
export class SampleDashboard extends ModuleBase {

    service: DashboardService;

    projectsDueByClient: Array<any> = [];
    projectsPendingByClient: Array<any> = [];
    jobStatisticByOffice: Array<any> = [];

    //projectsDueByClientDs: kendo.data.DataSource;
    //projectsPendingByClientDs: kendo.data.DataSource;
    //jobStatisticByOfficeDs: kendo.data.DataSource;

    //projectsDueByClientChart: kendo.dataviz.ui.Chart;
    //projectsPendingByClientChart: kendo.dataviz.ui.Chart;
    //jobStatisticByOfficeChart: kendo.dataviz.ui.Chart;

    

    jobStatisticByOfficeGrid: kendo.ui.Grid;
    frame: HTMLIFrameElement;

    //chart1 = {
    //    seriesDefaults: {
    //        labels: {
    //            visible: false,
    //            background: 'transparent',
    //            template: '#= category # \n #= value# '
    //        }
    //    },

    //    title: {
    //        position: 'top',
    //        text: 'Projects Pending by Client'
    //    },

    //    legend: {
    //        visible: true,
    //        labels: {
    //            template: '#= text # (#= value #)'
    //        }
    //    },

    //    series: [{
    //        type: 'pie',
    //        field: 'Value',
    //        categoryField: 'ClientName',
    //        startAngle: 150
    //    }],

    //    tooltip: {
    //        visible: true,
    //        template: '#= category # \n (#= value#)',
    //        format: '{0}'
    //    }

    //}

    //chart2 = {
    //    seriesDefaults: {
    //        labels: {
    //            visible: false,
    //            background: 'transparent',
    //            template: '#= category # \n #= value#'
    //        }
    //    },

    //    title: {
    //        position: 'top',
    //        text: 'Projects Due by Client'
    //    },

    //    legend: {
    //        visible: true,
    //        labels: {
    //            template: '#= text # (#= value #)'
    //        }
    //    },

    //    series: [{
    //        type: 'pie',
    //        field: 'Value',
    //        categoryField: 'ClientName',
    //        startAngle: 150
    //    }],

    //    tooltip: {
    //        visible: true,
    //        format: '{0}'
    //    }

    //}

    //chart3 = {
    //    seriesDefaults: {
    //        type: 'line',
    //        line: {
    //            line: {
    //                style: 'smooth'
    //            }
    //        }
    //    },

    //    series: [{
    //        name: 'India',
    //        data: [3.907, 7.943, 7.848, 9.284, 9.263, 9.801, 3.890, 8.238, 9.552, 6.855]
    //    }, {
    //        name: 'World',
    //        data: [1.988, 2.733, 3.994, 3.464, 4.001, 3.939, 1.333, -2.245, 4.339, 2.727]
    //    }, {
    //        name: 'Haiti',
    //        data: [-0.253, 0.362, -3.519, 1.799, 2.252, 3.343, 0.843, 2.877, -5.416, 5.590]
    //    }],

    //    valueAxis: {
    //        labels: {
    //            format: '{0}%'
    //        },
    //        line: {
    //            visible: false
    //        },
    //        axisCrossingValue: -10
    //    },

    //    categoryAxis: {
    //        categories: [2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011],
    //        majorGridLines: {
    //            visible: false
    //        },
    //        labels: {
    //            rotation: 'auto'
    //        }
    //    },

    //    tooltip: {
    //        visible: true,
    //        format: '{0}%',
    //        template: '${series.name} ${value}'
    //    }

    //}

    //chart4 = {

    //    series: [{ field: 'Created', name: 'Created' },
    //        { field: 'Completed', name: 'Completed' },
    //        { field: 'Due', name: 'Due' },
    //        { field: 'InProgress', name: 'In Progress' },
    //        { field: 'Cancelled', name: 'Cancelled' }],

    //    valueAxis: {
    //        labels: {
    //            format: 'N0'
    //        },
    //        majorUnit: 20
    //    },

    //    categoryAxis: {
    //        field: 'OfficeName',
    //        labels: {
    //            rotation: 0
    //        },
    //        crosshair: {
    //            visible: true
    //        }
    //    },

    //    tooltip: {
    //        visible: true,
    //        shared: true,
    //        format: 'N0'
    //    }

    //}

    //frameloaded(app: Application.ApplicationMenuItem, e) {
    //    let frame: HTMLIFrameElement = e.target;
    //    let me = this;

    //    me.frame = frame;
    //    app.Frame = frame;

    //    var foo = me.OpenSecurityModules.indexOf(app);
    //    me.OpenSecurityModules[foo].Frame = frame;

    //    if (frame) {
    //        $(frame).data("myAMI", app);

    //        app.DocumentTitle = frame.contentDocument.title;
    //        frame.contentDocument['GetRadWindow'] = function () {
    //            me.BrowserWindow.Parent = me;
    //            me.BrowserWindow.Frame = me.frame;
    //            me.BrowserWindow.webvantage = me;


    //            return {
    //                BrowserWindow: me.BrowserWindow
    //            };
    //        }
    //    }
    //}

    bookmark() {
        let client = new HttpClient();
        let me = this;     
        
        var data = {
            Dashboard: 'executive'
        };

        client.post('Dashboard/BookMarkPage', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }
    
    attached() {
        return this.service.getSampleChartData().then(response => {
            //this.projectsDueByClient = response.content.ProjectsDueByClient;
            //this.projectsPendingByClient = response.content.ProjectsPendingByClient;
            //this.jobStatisticByOffice = response.content.JobStatisticByOffice;
            //this.projectsPendingByClientDs = new kendo.data.DataSource({
            //    data: response.content.ProjectsPendingByClient
            //});
            //this.projectsDueByClientDs = new kendo.data.DataSource({
            //    data: response.content.ProjectsDueByClient
            //});
            //this.jobStatisticByOfficeDs = new kendo.data.DataSource({
            //    data: response.content.JobStatisticByOffice,
            //    filter: {
            //        field: 'OfficeCode',
            //        operator: 'neq',
            //        value: 'indy'
            //    }
            //});
            //this.projectsPendingByClientChart.setDataSource(this.projectsPendingByClientDs);
            //this.projectsDueByClientChart.setDataSource(this.projectsDueByClientDs);
            //this.jobStatisticByOfficeChart.setDataSource(this.jobStatisticByOfficeDs);
            //this.jobStatisticByOfficeGrid.setDataSource(this.jobStatisticByOfficeDs);
        });
    }

    constructor(service: DashboardService) {
        super();
        this.service = service;
        //this.projectsDueByClientDs = new kendo.data.DataSource();
        //this.projectsPendingByClientDs = new kendo.data.DataSource();
        //this.jobStatisticByOfficeDs = new kendo.data.DataSource();
    }

}
