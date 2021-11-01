AdvantageMobile_UI.ClientEdit = function(params) {
    "use strict";

    var id = params.id,
        isNew = (id === undefined),
        client = new AdvantageMobile_UI.ClientViewModel();

    function load() {
        AdvantageMobile_UI.db.Clients.byKey(id).done(function(data) {
            client.fromJS(data);
        });
    }

    function update() {
        AdvantageMobile_UI.db.Clients.update(id, client.toJS()).done(function() {
            AdvantageMobile_UI.app.navigate({ view: "ClientDetails", id: id }, { target: "back" });
        });
    }

    function insert() {
        AdvantageMobile_UI.db.Clients.insert(client.toJS()).done(function() {
            AdvantageMobile_UI.app.navigate("Clients", { target: "back" });
        });
    }

    function handleSave() {
        if(isNew)
            insert();            
        else
            update();
    }

    function handleViewShown() {
        if(!isNew)
            load();
    }

    return {
        client: client,
        handleSave: handleSave,
        viewShown: handleViewShown
    };
};