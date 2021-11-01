import { ServiceBase } from 'services/base/service-base';

export class LookupService extends ServiceBase {

    constructor() {
        super({ baseUrl: "Lookup" });
    }

    initLookup(lookupType: number, lookupSource: number, includeClosed: boolean, clientCode: string, divisionCode: string, productCode: string, jobNumber: number) {
        return this.http.get('InitJobLookup', {
            LookupType: lookupType,
            LookupSource: lookupSource,
            IncludeClosed: includeClosed,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductCode: productCode,
            JobNumber: jobNumber
        });
    }

}
