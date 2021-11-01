////AdvantageMobile_UI.time_template_edit = function (params, viewInfo) {

////    var viewModel = {
//////  Put the binding properties here
////    };

////    return viewModel;
////};

AdvantageMobile_UI.EmployeeTimeTemplateEdit = function (params, viewInfo) {
    "use strict";

    var id = params.id,
        isNew = (id === undefined),
        employeetimetemplate = new AdvantageMobile_UI.EmployeeTimeTemplateViewModel();

    function load() {
        AdvantageMobile_UI.db.EmployeeTimeTemplates.byKey(id).done(function (data) {
            employeetimetemplate.fromJS(data);
        });
    }

    function update() {
        AdvantageMobile_UI.db.EmployeeTimeTemplates.update(id, employeetimetemplate.toJS()).done(function () {
            AdvantageMobile_UI.app.navigate({ view: "time_template_detail", id: id }, { target: "back" });
        });
    }

    function insert() {
        AdvantageMobile_UI.db.EmployeeTimeTemplates.insert(employeetimetemplate.toJS()).done(function () {
            AdvantageMobile_UI.app.navigate("time_template_list", { target: "back" });
        });
    }

    function handleSave() {
        if (isNew)
            insert();
        else
            update();
    }

    function handleViewShown() {
        if (!isNew)
            load();
    }
    function viewShowing() {

    };

    return {
        employeetimetemplate: employeetimetemplate,
        handleSave: handleSave,
        viewShown: handleViewShown,
        viewShowing: viewShowing,
};
};