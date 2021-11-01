import { ServiceBase } from 'services/base/service-base';
import { CardSettingsModel } from 'models/maintenance/card-settings-model';

export class DashboardService extends ServiceBase {

    switchDashboard(dashboardType: number) {
        return this.http.post('SwitchDashboard', { DashboardType: dashboardType });
    }
    loadCards(dashboardType: number, groupBy: string, search: string, pageSize: number, pageNumber: number) {
        return this.http.post('GetCards', { DashboardType: dashboardType, GroupBy: groupBy, Search: search, PageSize: pageSize, PageNumber: pageNumber });
    }
    initDashboard() {
        return this.http.get('InitDashboard');
    }
    getHoursCount() {
        return this.http.get('GetHoursCount');
    }
    showProofingIcon() {
        return this.http.get('ShowProofingIcon');
    }
    isProofingActive() {
        return this.http.get('IsProofingActive');
    }
    isConceptShareActive() {
        return this.http.get('IsConceptShareActive');
    }
    hasAccessToTimesheet() {
        return this.http.get('HasAccessToTimesheet');
    }
    isClientPortal() {
        return this.http.get('isClientPortal');
    }
    saveDashboardDefaultGroupBy(dashboardType: number, groupBy: string) {
        return this.http.post('SaveDashboardDefaultGroupBy', { DashboardType: dashboardType, GroupBy: groupBy });
    }
    getSampleChartData() {
        return this.http.get('GetSampleChartData');
    }
    getCardSettings(dashboardType: number) {
        return this.http.get('DashboardsCardSettingsMaintenance', { DashboardType: dashboardType });
    }
    saveCardSettings(dashboardType: number, cardsetting: String, value: string) {
        return this.http.post('SaveDashboardCardSettings', { DashboardType: dashboardType, Cardsetting: cardsetting, Value: value });
    }
    getTaskCardSettings(dashboardType: number, settingtype: string) {
        return this.http.get('GetTaskDashboardsCardSettings', { DashboardType: dashboardType, Settingtype: settingtype });
    }
    DeleteBookmark(bookmarkID: number) {
        return this.http.get('DeleteBookmark', { BookMarkID: bookmarkID });
    }
    SaveBookmark(bookmarkID: number,name: string, description: string) {
        return this.http.post('UpdateBookmark', { BookmarkID: bookmarkID, Name: name, Description: description });
    }
    initBookmarkEdit(bookmarkID: number) {
        return this.http.get("InitBookmarkEdit", {BookmarkID: bookmarkID });
    }

    constructor() {
        super({ baseUrl: "Dashboard" });
    }
    
}
