AdvantageMobile_UI.rich_editor = function (params) {

    var richText = ko.observable("<strong>Hello</strong>");

    function viewShowing() {

    };

    function viewShown() {
    };

    var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
        richText: richText,
    };

    return viewModel;

};