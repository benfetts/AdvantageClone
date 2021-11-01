import { ServiceBase } from 'services/base/service-base';
import { Application } from 'models/common/application';

export class ApplicationService extends ServiceBase {

    applicationInit() {
        return this.http.get('ApplicationInit').then(response => {
            let app: Application.App = Application.App.fromObject(response.content);
            return app;
        });
    }
    decryptDeepLink(link: string) {
        return this.http.get('DecryptDeepLink', { Link: link });
    }
    signOut() {
        return this.http.post("SignOut", null);
    }

    constructor() {
        super({ baseUrl: "Home" });
    }

}
