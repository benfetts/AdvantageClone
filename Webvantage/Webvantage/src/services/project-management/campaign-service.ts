import { HttpClient } from 'aurelia-http-client'; 
import {CampaignModel} from '../../models/project-managment/campaign-model'

export class CampaignService {
    http: HttpClient;

    getCampaign(CampaignID : number) {
        return this.http.get('Campaign/GetCampaign?id=' + CampaignID);
    }

    updateCampaign(Campaign: CampaignModel) {
        return this.http.post('Campaign/SaveCampaign', Campaign);
    }

    deleteCampaign(CampaignID: number) {
        return this.http.get('Campaign/DeleteCampaign?id=' + CampaignID);
    }

    constructor() {
        this.http = new HttpClient().configure(x => {
            x.withReviver((k, v) => {
                return typeof v === 'object' ? new CampaignModel(v) : v;
            });
        });
    }
}
