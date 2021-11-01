<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ModalFilterDialog.aspx.vb" Inherits="Webvantage.ModalFilterDialog" MasterPageFile="~/ChildPage.Master" Title="Modal Filter Dialog" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/timeSheetLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/functionCategoryLookupModal.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupWindow.js"></script>

    <script type="text/javascript">

        var callingWindowScope;

        var initialSearchResults = function (searchCriteria, callingWindowScope) {
            var searchScope = angular.element($('#content')).scope();
            searchScope.searchCriteria = searchCriteria;
            searchScope.callingWindowScope = callingWindowScope;
            searchScope.$apply();
            searchScope.initialSearchResults();
        }

        function getSelectedGridDataItem() {
            var grid = $('#selectorGrid').data("kendoGrid");
            var selected = grid.select();
            if(selected.length === 1){
                return grid.dataItem(selected);
            }
        }

        function editVendorContact() {
            var dataItem = getSelectedGridDataItem();
            if (dataItem) {
                var scope = lookupScope().searchCriteria;
                OpenRadWindowLookup('VendorQuote_Contacts.aspx?fromNewLookup=1&from=popvc&type=Edit&VnCode=' + scope.Vendor.VendorCode + '&Contact=' + dataItem.VendorContactCode);
            } else {
                ShowMessage('Please select a contact to edit.');
            }
            return false;
        }

        function addVendorContact() {
            var scope = lookupScope().searchCriteria;
            OpenRadWindowLookup('VendorQuote_Contacts.aspx?fromNewLookup=1&from=popvc&type=New&VnCode=' + scope.Vendor.VendorCode);

            return false;
        }

       <%-- function VendorLimitbyDefaultFunction() {
            var scope = lookupScope().searchCriteria;
            scope.Vendor.LimitbyDefaultFunction = document.getElementById('<%= CheckboxClosedJobs.ClientID %>').checked;            
            return false;
        }

        function VendorIncludeMediaVendors() {
            var scope = lookupScope().searchCriteria;
            scope.Vendor.IncludeMediaVendors = document.getElementById('<%= CheckBoxMediaVendors.ClientID %>').checked;            
            return false;
        }--%>

        function lookupScope() {
            return angular.element($('#content')).scope();
        }

    </script>

    <div id="dialog"></div>

    <div ng-app="webvantageApp">
        <div id="DivAddEditOptions" runat="server">
            <asp:ImageButton ID="ImageButtonAdd" runat="server" Visible="false" SkinID="ImageButtonAdd" />&nbsp;
            <asp:ImageButton ID="ImageButtonEdit" runat="server" Visible="false" SkinID="ImageButtonEdit" />
        </div>
        <div id="content" ng-controller="kendoGridLookupWindowController">
            <ng-include src="'app/templates/kendoGridLookupWindow.html'"></ng-include>
        </div>
        <div>
            <asp:CheckBox ID="CheckboxClosedJobs" runat="server" AutoPostBack="True" Checked="False" Visible="false"
                EnableViewState="True" Text="Show closed/archived jobs?"/>
            <asp:CheckBox ID="CheckBoxMediaVendors" runat="server" AutoPostBack="True" Checked="False" Visible="false"
                EnableViewState="True" Text="Show Media Vendors" />
        </div>
    </div>
    <asp:HiddenField ID="initialWindowHeight" runat="server" ClientIDMode="Static" />
</asp:Content>
