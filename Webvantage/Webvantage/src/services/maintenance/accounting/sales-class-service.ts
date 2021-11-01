import { ServiceBase } from '../../base/service-base';
import { SalesClassModel } from 'models/maintenance/sales-class-model';

export class SalesClassService extends ServiceBase {

    getSalesClasss() {
        return this.http.createRequest('GetSalesClasses').asGet().withReviver((key, value) => {
            if (key === '' || !value) {
                return value;
            }
            return typeof value === 'object' ? SalesClassModel.fromObject(value) : value;
        }).send();

        //return this.http.get('GetTasks');
    }
    getSalesClass(code: string) {
        return this.http.get('GetSalesClass', { Code: code });
    }
    insertSalesClasses(salesclasses: any) {
        return this.http.post('InsertSalesClasses', salesclasses);
    }
    updateSalesClass(salesclass: any) {
        return this.http.post('UpdateSalesClasses', { SalesClasses: [salesclass]});
    }
    updateSalesClasses(salesclasses: any) {
        return this.http.post('UpdateSalesClasses', salesclasses);
    }
    deleteSalesClasses(salesclasses: any) {
        return this.http.post('DeleteSalesClasses', salesclasses);
    }
    deleteSalesClass(salesclass: any) {
        return this.http.post('DeleteSalesClasses', { SalesClasses: [salesclass] });
    }
    getSalesClassTypes() {
       //console.log('GetSalesClassTypes')
        return this.http.get('GetSalesClassTypes');
    }
    
    initSalesClassMaintenance() {
        return this.http.get('InitSalesClassMaintenance');
    }

    constructor() {
        super({ baseUrl: "Maintenance/Accounting/SalesClass" });

    }

}
