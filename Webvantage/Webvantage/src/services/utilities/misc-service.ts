import { ServiceBase } from 'services/base/service-base';

export class MiscService extends ServiceBase {

    constructor() {
        super({ baseUrl: "Misc" });
    }

    extendSession() {
        return this.http.post('ExtendSession', {});
    }

}
