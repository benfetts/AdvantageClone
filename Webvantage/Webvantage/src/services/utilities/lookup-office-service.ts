import { ServiceBase } from 'services/base/service-base';

export class LookupOfficeService extends ServiceBase {

    constructor() {
        super({ baseUrl: "LookupQuick" });
    }

    LookupOffice() {
        return this.http.get('LookupOffice', {
        });
    }

}
