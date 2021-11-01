//////AdvantageMobile_UI.time_template_detail = function (params, viewInfo) {

//////    var viewModel = {
////////  Put the binding properties here
//////    };

//////    return viewModel;
//////};

AdvantageMobile_UI.time_template_detail = function (params, viewInfo) {
    "use strict";

    var id = params.id,
        employeetimetemplate = new AdvantageMobile_UI.EmployeeTimeTemplateViewModel();

    function handleDelete() {
        DevExpress.ui.dialog.confirm("Are you sure you want to delete this item?", "Delete item").then(function (result) {
            if (result)
                handleConfirmDelete();
        });
    }

    function handleConfirmDelete() {
        AdvantageMobile_UI.db.EmployeeTimeTemplates.remove(id).done(function () {
            AdvantageMobile_UI.app.navigate("time_template_list", { target: "back" });
        });
    }

    function handleViewShown() {
        AdvantageMobile_UI.db.EmployeeTimeTemplates.byKey(id).done(function (data) {
            employeetimetemplate.fromJS(data);
        });
    }
    function viewShowing() {

    };

    return {
        id: id,
        employeetimetemplate: employeetimetemplate,
        handleDelete: handleDelete,
        viewShown: handleViewShown,
        viewShowing: viewShowing,
    };
};