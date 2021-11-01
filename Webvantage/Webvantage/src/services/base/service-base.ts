import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';

@inject(HttpClient)
export class ServiceBase {

    http: HttpClient;
    baseUrl: string;

    constructor(options?: any) {
        var http = new HttpClient();      
        if (options.baseUrl) {
            this.baseUrl = options.baseUrl;
        }
        if (options) {
            http.configure(config => {
                if (options.baseUrl) {
                    config.withBaseUrl(options.baseUrl);
                }
            })
            
        }
        this.http = http;
    }

}
