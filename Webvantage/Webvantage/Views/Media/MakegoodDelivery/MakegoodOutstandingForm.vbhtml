@ModelType AdvantageFramework.ViewModels.Media.MakegoodOutstandingViewModel
@Code     'ViewData("Title") = "Order Dashboard" - this is set in the controller!
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>@Html.DisplayFor(Function(M) M.AgencyName) Order Dashboard</h2>
        </div>
    </div>
End Section
<br />
<style>
    .form-control-static tr td:first-child font span {
        font-weight: normal !important;
    }

    html, body, table, th, td {
        font-family: Verdana, Arial, sans-serif !important;
    }

    h2, h3, h4 {
        font-family: Verdana !important;
    }

    h2 {
        font-size: 24px;
    }
    .e-scrollbar .e-hhandle {
        background-color: lightblue;
    }
    .e-scrollbar .e-hhandle:hover {
        background-color: lightblue;
    }
    .e-grid .e-alt_row {
        background: #d0deea;
    }
</style>
@If Model.IsValid = False Then
    @<div class="alert alert-danger">
        <strong>Invalid Outstanding Orders requested.</strong>
    </div>
Else

    @Html.HiddenFor(Function(M) Model.AgencyName)
    @Html.HiddenFor(Function(M) Model.VendorCode)
    @Html.HiddenFor(Function(M) Model.VendorRepCode)
    @Html.HiddenFor(Function(M) Model.DatabaseName)

    @(Html.EJ().Grid(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep)("Grid").CssClass("e-table").
                Columns(Sub(col)
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.Link.ToString).HeaderText("Link").Width(100).Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.ClientName.ToString).HeaderText("Client Name").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.ProductDescription.ToString).HeaderText("Product Description").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.WorksheetName.ToString).HeaderText("Worksheet Name").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.Station.ToString).HeaderText("Station").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.OrderNumber.ToString).HeaderText("Order Number").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.BuyerName.ToString).HeaderText("Buyer Name").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.Period.ToString).HeaderText("Period").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.Status.ToString).HeaderText("Status").Add()
                            col.Field(AdvantageFramework.Reporting.Database.Classes.BroadcastOrdersForVendorRep.Properties.StatusDate.ToString).HeaderText("Status Date").Format("{0:MM/dd/yyyy hh:mm tt}").Add()
                        End Sub) _
                .Datasource(Model.BroadcastOrdersForVendorRepList) _
                .AllowPaging() _
                .AllowSelection(False) _
                .AllowResizeToFit() _
                .AllowSorting(True) _
                .AllowScrolling(True) _
                .AllowFiltering(True) _
                .FilterSettings(Sub(filter)
                                    filter.FilterType(Syncfusion.JavaScript.FilterType.Excel)
                                End Sub) _
                .EnableAltRow(True) _
                .ScrollSettings(Sub(ss)
                                    ss.Height("auto")
                                End Sub) _
                .IsResponsive(True) _
                .EnableResponsiveRow(True) _
                .MinWidth(700)
    )@(Html.EJ().ScriptManager())

End If
