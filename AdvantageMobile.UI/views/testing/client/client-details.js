AdvantageMobile_UI.ClientDetails = function (params, viewInfo) {
    "use strict";

    var id = params.settings,
        client = new AdvantageMobile_UI.ClientViewModel();

    function handleDelete() {
        DevExpress.ui.dialog.confirm("Are you sure you want to delete this item?", "Delete item").then(function(result) {
            if(result)
                handleConfirmDelete();
        });
    }

    function handleConfirmDelete() {        
        AdvantageMobile_UI.db.Clients.remove(id).done(function () {
            AdvantageMobile_UI.app.navigate("Clients", { target: "back" });
        });
    }

    function handleViewShown() {
        //alert(params.settings)
        AdvantageMobile_UI.db.Clients.byKey(id).done(function (data) {
            client.fromJS(data);
        });
    }

    return {
        id: id,
        client: client,
        handleDelete: handleDelete,        
        viewShown: handleViewShown
    };
};