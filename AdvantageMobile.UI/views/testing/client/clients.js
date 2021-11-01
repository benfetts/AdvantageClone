AdvantageMobile_UI.Clients = function(params) {
    "use strict";

    var shouldReload = false,
        dataSource;

    function handleClientsModification() {
        shouldReload = true;
    }

    function handleViewShown() {
        if(shouldReload) {
            shouldReload = false;
            dataSource.pageIndex(0);
            dataSource.load();
        }
    }

    function handleViewDisposing() {
        AdvantageMobile_UI.db.Clients.modified.remove(handleClientsModification);
    }

    dataSource = new DevExpress.data.DataSource({
        store: AdvantageMobile_UI.db.Clients,
        map: function(item) {
            return new AdvantageMobile_UI.ClientViewModel(item);
        }
    });

    AdvantageMobile_UI.db.Clients.modified.add(handleClientsModification);

    return {
        dataSource: dataSource,
        viewShown: handleViewShown,
        viewDisposing: handleViewDisposing
    };   
};