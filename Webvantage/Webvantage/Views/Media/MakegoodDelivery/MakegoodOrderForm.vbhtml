@ModelType AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel
@Code
    'ViewData("Title") = "Order/Makegood Form"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            @If Model.IsOriginalOrderMode Then
                @<h2>New/Revised Order From @Html.DisplayFor(Function(M) M.AgencyName)</h2>
            Else
                @<h2>Makegood Submissions To @Html.DisplayFor(Function(M) M.AgencyName)</h2>
            End If
        </div>
    </div>
End Section

@Styles.Render("~/CSS/wv-icons.css")
@Styles.Render("~/Content/ej/web/flat-azure/ej.web.all.min.css")
@*@Styles.Render("~/Content/ej/web/bootstrap-theme/ej.web.all.min.css")*@
@Styles.Render("~/Content/ej/web/ej.widgets.core.bootstrap.min.css")
@Styles.Render("~/Views/Media/MakegoodDelivery/Content/ej.theme.min.css")

<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.min.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>

@If Model.IsValid = False Then
    @<div class="alert alert-danger">
        <strong>Invalid order requested.</strong>
    </div>

Else

    If Model.InDifferentOrderState Then
        @<div class="alert alert-danger">
            <strong>The buyer has altered the schedule, please exit and await a revised order or contact the buyer for assistance.</strong>
        </div>
    Else
        Using Html.BeginForm("MakegoodOrderForm", "MakegoodDelivery", New With {.QueryString = Model.QueryString}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
            @Html.AntiForgeryToken()

            @Html.ValidationSummary(False, "", New With {.style = "color:red"})

            @Html.HiddenFor(Function(M) Model.IsValid)
            @Html.HiddenFor(Function(M) Model.InDifferentOrderState)
            @Html.HiddenFor(Function(M) Model.DatabaseName)
            @Html.HiddenFor(Function(M) Model.StationName)
            @Html.HiddenFor(Function(M) Model.ClientName)
            @Html.HiddenFor(Function(M) Model.ProductName)
            @Html.HiddenFor(Function(M) Model.SalesRep)
            @Html.HiddenFor(Function(M) Model.SalesRepEmail)
            @Html.HiddenFor(Function(M) Model.SalesRepPhone)
            @Html.HiddenFor(Function(M) Model.OrderNumber)
            @Html.HiddenFor(Function(M) Model.OrderPlaced)
            @Html.HiddenFor(Function(M) Model.OrderStatus)
            @Html.HiddenFor(Function(M) Model.AgencyName)
            @Html.HiddenFor(Function(M) Model.BuyerName)
            @Html.HiddenFor(Function(M) Model.BuyerEmail)
            @Html.HiddenFor(Function(M) Model.BuyerPhone)
            @Html.HiddenFor(Function(M) Model.MediaType)
            @Html.HiddenFor(Function(M) Model.IsOriginalOrderMode)
            @Html.HiddenFor(Function(M) Model.MediaBroadcastWorksheetMarketID)
            @Html.HiddenFor(Function(M) Model.SpotCount)
            @Html.HiddenFor(Function(M) Model.TermsOfAgreement)
            @Html.HiddenFor(Function(M) Model.VendorEditLocked)
            @Html.HiddenFor(Function(M) Model.WorksheetDateTypeName)
            @Html.HiddenFor(Function(M) Model.StartDates)
            @Html.HiddenFor(Function(M) Model.MinDate)

            @<table id="OrderHeader" class="table table-bordered table-condensed">
                <tbody>
                    <tr>
                        <td>Station</td>
                        <td>@Html.DisplayFor(Function(M) Model.StationName)</td>
                        <td>Order Number</td>
                        <td>@Html.DisplayFor(Function(M) Model.OrderNumber) @Html.DisplayFor(Function(M) Model.RevisedString)</td>
                        <td>Agency</td>
                        <td>@Html.DisplayFor(Function(M) Model.AgencyName)</td>
                    </tr>
                    <tr>
                        <td>Client</td>
                        <td>@Html.DisplayFor(Function(M) Model.ClientName)</td>
                        <td>Order Placed</td>
                        <td>@Html.DisplayFor(Function(M) Model.OrderPlaced)</td>
                        <td>Buyer</td>
                        <td>@Html.DisplayFor(Function(M) Model.BuyerName)</td>
                    </tr>
                    <tr>
                        <td>Product</td>
                        <td>@Html.DisplayFor(Function(M) Model.ProductName)</td>
                        <td>Order Status</td>
                        <td>@Html.DisplayFor(Function(M) Model.OrderStatus)</td>
                        <td>Phone</td>
                        <td>@Html.DisplayFor(Function(M) Model.BuyerPhone)</td>
                    </tr>
                    <tr>
                        <td>Sales Rep</td>
                        <td>@Html.DisplayFor(Function(M) Model.SalesRep)</td>
                        <td>Flight Dates</td>
                        <td>@Html.DisplayFor(Function(M) Model.FlightDates)</td>
                        <td>Email</td>
                        <td>@Html.DisplayFor(Function(M) Model.BuyerEmail)</td>
                    </tr>
                    <tr>
                        <td>Worksheet Name</td>
                        <td colspan="4">@Html.DisplayFor(Function(M) Model.WorksheetName)</td>
                        <td>@Html.DisplayFor(Function(M) Model.Copyright)</td>
                    </tr>
                    @*<tr id="rowStartDate" style="background-color:rgb(255,255,204)">
                            <td>Start Date</td>
                            <td>@Html.EJ().DropDownList("StartDate").Datasource(Model.StartDates).ClientSideEvents(Sub(eve)
                                                                                                                        eve.Change("changedropdown")
                                                                                                                    End Sub).DropDownListFields(Function(F)
                                                                                                                                                    Return F.Value("Code").Text("Description")
                                                                                                                                                End Function).Value(Model.MinDate).EnableFilterSearch(True).FilterType(SearchFilterType.Contains)</td>
                            <td colspan="4">Start Date determines the 12 weeks/days that are displayed on the grid.  Totals reflect entire order.</td>
                        </tr>*@
                </tbody>
            </table>
            @<div class="row">
                <input type="hidden" id="selectedRow" value="-1">
                <input type="hidden" id="ratesVisible" value="0">
                <ul class="pull-right list-inline" style="margin-right: 26px; ">
                    <li>
                        <div class="form-group" id="myDiv1" hidden="hidden">
                            <input type="checkbox" onchange="handleChange(this);" id="checkTerms" /> I agree to <a href="#TermsOfAgreementModal" data-toggle="modal">Terms Of Agreement</a>
                        </div>
                    </li>
                    <li>
                        @If Model.IsOriginalOrderMode Then
                            @<input type="button" class="btn btn-primary" name="command" disabled="disabled" id="accept" value="Accept" title="Accept Order" onclick="acceptOrder()" />
                            @<input type="button" class="btn btn-normal" name="command" value="Reject" title="Reject Order" onclick="rejectOrder()" />
                            @<input type="button" class="btn btn-normal" name="command" value="Cancel" title="Close page without Accepting or Rejecting" onclick="cancel()" />
                        ElseIf Not Model.VendorEditLocked Then
                            @<br />
                            @<input type="button" class="btn btn-primary" name="command" id="submit" value="Submit" onclick="submitMakegood()" />
                            @<input type="button" class="btn btn-normal" name="command" id="discard" value="Discard" title="Makegoods removed" onclick="location.href='@Url.Action("DiscardMakegood", "MakegoodDelivery", New With {.OrderNumber = Model.OrderNumber, .DatabaseName = Model.DatabaseName})'" />
                            @<input type="button" class="btn btn-normal" name="command" value="Cancel" title="Exit, makegoods remain unsent" onclick="cancel()" />
                        End If
                    </li>

                </ul>
                <ul class="list-inline pull-left menu-bar" style="margin-top: 14px; margin-left: 12px;">
                    <li>
                        <a href='@Url.Action("DownloadOrderDocument", "MakegoodDelivery", New With {.QueryString = Model.QueryString})' class="btn btn-primary" id="btnDownloadOrderDocument" style=" margin-left: 20px;">View Order</a>
                    </li>
                    <li>
                        <a href='@Url.Action("DownloadXMLDocument", "MakegoodDelivery", New With {.QueryString = Model.QueryString})' class="btn btn-primary" id="btnDownloadXMLDocument">Download</a>
                    </li>
                    <li>
                        <a href='@Url.Action("DownloadXMLDocumentAsNew", "MakegoodDelivery", New With {.QueryString = Model.QueryString})' class="btn btn-primary" id="btnDownloadXMLDocumentAsNew">Download as New</a>
                    </li>
                    <li>
                        <a href='@Url.Action("DownloadProposalXML", "MakegoodDelivery", New With {.QueryString = Model.QueryString})' class="btn btn-primary" id="btnDownloadProposalXML">Download Proposal</a>
                    </li>
                    <li>
                        <input type="button" id="btnToggleRates" class="btn btn-primary" value="Toggle Rates" style="" />
                    </li>
                    <li>
                        <input type="button" id="btnResponses" class="btn btn-primary" value="Responses" style="" />
                    </li>
                    <li>
                        <input type="button" id="btnNewComment" class="btn btn-primary" value="New Comment" style="" />
                    </li>
                    <li>
                        <a class="btn btn-default" href="#InformationModal" data-toggle="modal" style="padding: 3px 6px;line-height: 17px;" title="Instructions"><span style="font-size: 20px;" class="wvi wvi-information"></span></a>
                    </li>
                </ul>
            </div>

            @(Html.EJ().TreeGrid("TreeGridContainer").CssClass("e-table").
                ToolbarSettings(Sub(tool)
                                    tool.ShowToolbar(Not Model.IsOriginalOrderMode AndAlso Not Model.VendorEditLocked)
                                    tool.CustomToolbarItems(Sub(ctb)
                                                                ctb.TemplateID("#addMakegoodButtonTemplate").TooltipText("Add Makegood").Add()
                                                                ctb.TemplateID("#addReplacementButtonTemplate").TooltipText("Add Replacement").Add()
                                                                ctb.TemplateID("#updateMakegoodButtonTemplate").TooltipText("Update Makegood").Add()
                                                                ctb.TemplateID("#cancelButtonTemplate").TooltipText("Cancel").Add()
                                                                ctb.TemplateID("#deleteButtonTemplate").TooltipText("Delete Makegood").Add()
                                                                ctb.TemplateID("#viewButtonTemplate").TooltipText("View Makegood Details").Add()
                                                            End Sub)
                                End Sub) _
                .IdMapping("ID") _
                .ParentIdMapping("ParentID") _
                .HasChildMapping(True) _
                .AllowTextWrap(False) _
                .ShowGridCellTooltip(True) _
                .HeaderTextOverflow(TreeGridHeaderTextOverflow.Wrap) _
                .Datasource(Model.MakegoodDataTable) _
                .SelectionMode(TreeGridSelectionMode.Row) _
                .ShowTotalSummary(True) _
                .SizeSettings(Sub(ss)
                                  ss.Height("550px")
                              End Sub) _
                .EditSettings(Sub(edit)
                                  edit.AllowAdding(True)
                                  edit.AllowEditing(True)
                                  edit.EditMode(TreeGridEditMode.RowEditing)
                              End Sub) _
                .Columns(Sub(co)

                             Dim Dayparts As IEnumerable = Nothing
                             Dim CableNetworks As IEnumerable = Nothing
                             Dim EditorPropertiesZeroDecimals As New Syncfusion.JavaScript.Models.EditorProperties
                             Dim EditorPropertiesOneDecimal As New Syncfusion.JavaScript.Models.EditorProperties
                             Dim EditorPropertiesTwoDecimals As New Syncfusion.JavaScript.Models.EditorProperties

                             EditorPropertiesZeroDecimals.ShowSpinButton = False
                             EditorPropertiesOneDecimal.ShowSpinButton = False
                             EditorPropertiesTwoDecimals.ShowSpinButton = False

                             EditorPropertiesZeroDecimals.DecimalPlaces = 0
                             EditorPropertiesOneDecimal.DecimalPlaces = 1
                             EditorPropertiesTwoDecimals.DecimalPlaces = 2

                             Dayparts = DirectCast(ViewBag.Dayparts, IEnumerable(Of Object))

                             CableNetworks = DirectCast(ViewBag.CableNetworks, IEnumerable(Of Object))

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString).AllowEditing(False).HeaderText("Line").Width(140).IsFrozen(True).Add()

                             If Not Model.IsOriginalOrderMode AndAlso Not Model.VendorEditLocked Then

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsSubmitted.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Center).AllowEditing(False).EditType(TreeGridEditingType.Boolean).HeaderTooltip("Submitted to Buyer").HeaderText("Submitted").Width(95).IsFrozen(True).Add()

                             End If

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString).Visible(False).IsFrozen(True).Add()

                             If Model.MediaType = "T" AndAlso Model.VendorIsCableSystem Then

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString).HeaderText("Cable Network").EditTemplate(Sub(et)
                                                                                                                                                                                                et.Create("CreateCableNetwork").Read("ReadCableNetwork").Write("WriteCableNetwork")
                                                                                                                                                                                            End Sub).DropDownData(CableNetworks).IsFrozen(True).Add()

                             End If

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString).HeaderText("Days").Width(110).IsFrozen(True).Add()
                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString).HeaderText("Start").Width(100).IsFrozen(True).Add()
                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString).HeaderText("End").Width(100).IsFrozen(True).Add()

                             If Model.MediaType = "T" Then

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString).Width(180).IsFrozen(True).Add()

                             End If

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString).HeaderText("Daypart").EditTemplate(Sub(et)
                                                                                                                                                                                            et.Create("CreateDaypart").Read("ReadDaypart").Write("WriteDaypart")
                                                                                                                                                                                        End Sub).DropDownData(Dayparts).IsFrozen(True).Add()

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesZeroDecimals).Width(70).ValidationRules(Sub(v)
                                                                                                                                                                                                                                                                                                               v.AddRule("required", True)
                                                                                                                                                                                                                                                                                                               v.AddRule("validateLength", True)
                                                                                                                                                                                                                                                                                                           End Sub).IsFrozen(True).Add()
                             If Model.MediaType = "T" Then

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString).EditType(TreeGridEditingType.Boolean).HeaderText("BE").HeaderTooltip("Bookend - spot counts must be even").Width(40).Add()

                             End If

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString).EditType(TreeGridEditingType.Boolean).HeaderText("AV").HeaderTooltip("Added Value").Width(40).Add()
                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString).EditType(TreeGridEditingType.String).HeaderText("Comments").Add()
                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesTwoDecimals).HeaderText("Default Rate").Width(90).Format("{0:N2}").Tooltip("cellTooltipTemplateDefaultRate").Add()
                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString).Visible(False).Add()

                             For SpotColumnCounter As Integer = 0 To Model.SpotCount - 1

                                 Dim SpotDate As Date
                                 Dim DateString = Model.MakegoodDataTable.Columns("Spot" & SpotColumnCounter).Caption

                                 SpotDate = DateSerial(Mid(DateString, 1, 4), Mid(DateString, 5, 2), Mid(DateString, 7, 2))

                                 If Model.MakegoodDataTable.Columns("Spot" & SpotColumnCounter).ReadOnly Then

                                     co.Field("Spot" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText("<span style='color:red'>" & SpotDate.ToString("M/d") & "</span>").HeaderTooltip(SpotDate.ToString("M/d")).AllowEditing(False).Width(62).Add()
                                     co.Field("Rate" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText("Rate" & vbCrLf & SpotDate.ToString("M/d")).Width(0).AllowEditing(False).Visible(False).Add() 'keep Width(0) so it will never show!

                                 Else

                                     co.Field("Spot" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText(SpotDate.ToString("M/d")).ValidationRules(Sub(v)
                                                                                                                                                                                                                                                                           v.AddRule("validateSpot", True)
                                                                                                                                                                                                                                                                       End Sub).Width(62).Tooltip("cellTooltipTemplate").Add()

                                     co.Field("Rate" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesTwoDecimals).HeaderText("Rate" & vbCrLf & SpotDate.ToString("M/d")).Width(125).Visible(False).Format("{0:N2}").Add()

                                 End If

                             Next

                             co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("Total Spots").Width(90).AllowEditing(False).Format("{0:N0}").Add()

                             If Model.NetGross = 0 Then

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("Total Net").AllowEditing(False).Format("{0:N2}").Add()

                             Else

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("Total Gross").AllowEditing(False).Format("{0:N2}").Add()

                             End If

                             If Not String.IsNullOrWhiteSpace(Model.PrimaryDemographic) AndAlso Not Model.SuppressRatings Then

                                 If Model.MediaType = "T" Then

                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesTwoDecimals).Width(100).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("Rating").Format("{0:N2}").Add()

                                 Else

                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesOneDecimal).Width(100).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("AQH Rtg").Format("{0:N1}").Add()

                                 End If

                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).HeaderText("GRP").AllowEditing(False).Format("{0:N2}").Add()
                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).HeaderText("CPP").AllowEditing(False).Format("{0:N2}").Add()
                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).HeaderText(If(Model.MediaType = "T", "Imps (000)", "AQH (00)")).EditType(TreeGridEditingType.Numeric).NumericEditOptions(If(Model.MediaType = "T", EditorPropertiesOneDecimal, EditorPropertiesZeroDecimals)).Format(If(Model.MediaType = "T", "{0:N1}", "{0:N0}")).Add()
                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Width(120).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText(If(Model.MediaType = "T", "GIMP (000)", "GIMP (00)")).AllowEditing(False).Format(If(Model.MediaType = "T", "{0:N1}", "{0:N0}")).Add()
                                 co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString).Width(100).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("CPM").AllowEditing(False).Format("{0:N2}").Add()

                             End If
                         End Sub) _
                .ShowStackedHeader(True) _
                .StackedHeaderRows(Sub(row)
                                       row.StackedHeaderColumns(Sub(shc)
                                                                    shc.HeaderText("").Column(Sub(col)
                                                                                                  If Model.MediaType = "T" AndAlso Model.VendorIsCableSystem Then
                                                                                                      col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString)
                                                                                                  End If
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString)
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString)
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString)
                                                                                                  If Model.MediaType = "T" Then
                                                                                                      col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString)
                                                                                                  End If
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString)
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString)
                                                                                                  col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString)
                                                                                              End Sub).Add()

                                                                    Dim HeaderText As String = String.Empty
                                                                    Dim YearMonth As String = String.Empty
                                                                    For Each YearMonth In Model.YearMonths
                                                                        HeaderText = MonthName(YearMonth.Substring(4, 2), True) & " " & YearMonth.Substring(0, 4)
                                                                        shc.HeaderText(HeaderText).Column(Sub(col)
                                                                                                              For Each spot In Model.SpotDates
                                                                                                                  If Model.GetSpotYearMonth(spot.Value) = YearMonth Then
                                                                                                                      col.Add(spot.Key)
                                                                                                                      If Not Model.MakegoodDataTable.Columns(spot.Key).ReadOnly Then
                                                                                                                          col.Add(spot.Key.Replace("Spot", "Rate"))
                                                                                                                      End If
                                                                                                                  End If
                                                                                                              Next
                                                                                                          End Sub).Add()
                                                                    Next
                                                                    If Not String.IsNullOrWhiteSpace(Model.PrimaryDemographic) AndAlso Not Model.SuppressRatings Then
                                                                        shc.HeaderText(Model.PrimaryDemographic).Column(Sub(col)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)
                                                                                                                            col.Add(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString)
                                                                                                                        End Sub).Add()
                                                                    End If
                                                                End Sub).Add()
                                   End Sub) _
                .SummaryRows(Sub(SR)
                                 If Model.IsOriginalOrderMode Then
                                     SR.Title("Total").SummaryColumns(Sub(SC)
                                                                          For SpotColumnCounter As Integer = 0 To Model.SpotCount - 1
                                                                              SC.SummaryType(TreeGridSummaryType.Sum).DataMember("Spot" & SpotColumnCounter).DisplayColumn("Spot" & SpotColumnCounter).Add()
                                                                          Next
                                                                          SC.SummaryType(TreeGridSummaryType.Sum).DataMember("TotalSpots").DisplayColumn("TotalSpots").Add()
                                                                          SC.SummaryType(TreeGridSummaryType.Sum).DataMember("TotalGross").DisplayColumn("TotalGross").Format("{0:N2}").Add()
                                                                          SC.SummaryType(TreeGridSummaryType.Sum).DataMember("PrimaryGRP").DisplayColumn("PrimaryGRP").Format("{0:N2}").Add()
                                                                          SC.SummaryType(TreeGridSummaryType.Sum).DataMember("PrimaryGIMP").DisplayColumn("PrimaryGIMP").Format(If(Model.MediaType = "T", "{0:N1}", "{0:N0}")).Add()
                                                                          SC.SummaryType(TreeGridSummaryType.Custom).CustomSummaryValue("calcCPP").DisplayColumn("PrimaryCPP").Format("{0:N2}").Add()
                                                                          SC.SummaryType(TreeGridSummaryType.Custom).CustomSummaryValue("calcCPM").DisplayColumn("PrimaryCPM").Format("{0:N2}").Add()
                                                                      End Sub).Add()
                                 End If
                             End Sub) _
                .ClientSideEvents(Sub(eve)
                                      eve.EndEdit("endEdit")
                                      eve.BeginEdit("beginEdit")
                                      eve.RowDataBound("rowDataBound")
                                      eve.RowSelected("rowSelected")
                                      eve.QueryCellInfo("queryCellInfo")
                                      eve.ToolbarClick("toolbarClick")
                                      eve.Create("create")
                                  End Sub)
            )@(Html.EJ().ScriptManager())
            @<br />
            @<div id="InformationModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Instructions</h4>
                        </div>
                        <div class="modal-body">
                            <strong>EMAIL ORDER DELIVERY</strong>
                            <ul class="list-unstyled">
                                <li>
                                    - Order emails are sent to addresses in the agency database; please contact the agency buyer if you wish to add or alter email recipients.

                                </li>
                                <li>
                                    - Email attachments include both PDF and XML (SCX for cable) file types.

                                </li>
                                <li>
                                    - The email link <u>Click Here</u> opens the <strong>AGENCY ORDER DASHBOARD</strong> for order access.

                                </li>
                            </ul>


                            <strong>WEBSITE:</strong>
                            <strong>AGENCY ORDER DASHBOARD</strong>
                            <ul class="list-unstyled">
                                <li>
                                    - Station orders will stay active on the Agency Order Dashboard up to 60 days after the flight end date.

                                </li>
                                <li>
                                    - New and Revised orders are listed first.  Columns can be sorted by clicking on column headers and/or filtered by selecting the funnel.

                                </li>
                                <li>
                                    - Under the Link Header, click <u>View</u> to see an individual order.

                                    <ul>
                                        <li>
                                            If an order is new or revised, the <strong>NEW/REVISED ORDERS</strong> page will open.

                                        </li>
                                        <li>
                                            If an order has been accepted, the <strong>MAKEGOOD SUBMISSIONS</strong> page will open.

                                        </li>
                                    </ul>
                                </li>
                            </ul>


                            <strong>NEW/REVISED ORDERS</strong>
                            <ul class="list-unstyled">
                                <li>
                                    - In order to Accept (confirm) the order, select “I agree” to Terms of Agreement and then <strong>Accept</strong> (comment to the agency is optional).

                                </li>
                                <li>
                                    - If the order cannot be accepted, select <strong>Reject</strong> (comment to the agency is required).

                                </li>
                            </ul>


                            <strong>FUNCTION BUTTONS</strong>
                            <ul class="list-unstyled">
                                <li>
                                    - <strong>View Order</strong> downloads the order as a PDF document.

                                </li>
                                <li>
                                    - <strong>Download</strong> downloads the order as an XML (SCX for local cable) document suitable for import into the station's sales system.

                                </li>
                                <li>
                                    - <strong>Download as New</strong> downloads the order XML (SCX for local cable) as a new file suitable for import into the station’s sales system.

                                </li>
                                <li>
                                    - <strong>Download Proposal</strong> downloads the proposal XML for RADIO ONLY as a new file suitable for import into the station’s sales system.

                                </li>
                                <li>
                                    - <strong>Toggle Rates</strong> displays/hides the weekly/daily rate.
                                    <ul>
                                        <li>
                                            NOTE:  If the weekly rate varies for any week on a line, a red tic mark will appear in the Default Rate column.
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    - <strong>Responses</strong> displays the communication history with the agency for this order.

                                </li>
                                <li>
                                    - <strong>New Comment</strong> enter a new comment to communicate with the agency that will be sent via email.

                                </li>
                            </ul>


                            <strong>MAKEGOOD SUBMISSIONS</strong>
                            <ul class="list-unstyled">
                                <li>
                                    - To Add a Makegood, highlight the line with the preempted spot and select <strong>Add Makegood</strong>.  Enter the number of spots being preempted from each week and a new row will be created.

                                </li>
                                <li>
                                    - Highlight the new row and double click a cell to Edit the new row.  Update the following cells as needed for the makegood offer:
                                    <ul>
                                        <li>
                                            Days, Times, Daypart, Length, Bookend (BE), Added Value (AV), Comments, Default Rate, Spots by week/day, Cable Network, Rating and Impressions (000).  If a weekly rate needs to be updated, select <strong>Toggle Rates</strong> to update that week’s rate.
                                        </li>
                                        <li>Note: Weeks marked in <font color="red">red</font> are hiatus weeks and will not allow spot entry.</li>
                                    </ul>
                                </li>
                                <li>
                                    - Select Enter or Save to save the makegood entry.  Other makegood offers can then be added following the same process.

                                </li>
                                <li>
                                    - Select Cancel (red X) if a mistake is made on a makegood row to start over.

                                </li>
                                <li>
                                    - If multiple makegoods are being offered for a single missed spot or an added or replacement row needs to be added, select <strong>Add Replacement</strong> to add the extra row under the last makegood row and then update the details for that new row.

                                </li>
                                <li>
                                    - Click <strong>Submit</strong> to send the makegood offer to the buyer, <strong>Discard</strong> to erase all makegoods, or <strong>Cancel</strong> to undo edits on the current row and go back to the Order Dashboard.

                                </li>
                                <li>
                                    - Highlight an order row and select the Magnifying Glass or Details button to see the audit trail of all makegoods for that line.

                                </li>
                                <li>
                                    - Note:  Once a makegood offer is submitted, additional makegoods can be submitted for any line not marked Submitted.  If a mistake is made on a makegood offer, let the agency know to reject that offer so an update can be made in the dashboard and resubmitted.

                                    When the makegood acceptance is received from the buyer, updated PDF and XML (SCX for cable) files are then available for download in the Makegood Submissions window

                                </li>
                            </ul>
                        </div>
                        <div class="modal-footer no-padding">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>
            @<div id="TermsOfAgreementModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">@Html.DisplayNameFor(Function(M) M.TermsOfAgreement)</h4>
                        </div>
                        <div class="modal-body">
                            <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
                                @Model.TermsOfAgreement
                            </p>
                        </div>
                        <div class="modal-footer no-padding">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

            @<div id="MakeGoodModal" class="" title="Enter Number"></div>
            @<div id="AcceptRejectModal" class="" title="Order"></div>
            @<div id="ResponsesModal" class="" title="Responses"></div>
        End Using

    End If

End If

<script id="makegoodDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id='btnDialogOK' class="btn btn-primary">OK</button>
        <button id='btnDialogCancel' class="btn btn-normal">Cancel</button>
    </div>
</script>
<script id="makegoodDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        <table>
            <tr>
                <td><label>Days:</label></td>
                <td><label id="dialogDaypart">{{days}}</label></td>
                <td><label>&nbsp;&nbsp;&nbsp;</label></td>
                <td><label>Start:</label></td>
                <td><label id="dialogStart">{{start}}</label></td>
                <td><label>&nbsp;&nbsp;&nbsp;</label></td>
                <td><label>End:</label></td>
                <td><label id="dialogEnd">{{end}}</label></td>
                <td><label>&nbsp;&nbsp;&nbsp;</label></td>
                <td><label>Length:</label></td>
                <td><label id="dialogLength">{{length}}</label></td>
                <td><label>&nbsp;&nbsp;&nbsp;</label></td>
                <td><label>{{programlabel}}</label></td>
                <td><label id="dialogProgram">{{program}}</label></td>
            </tr>
        </table><br />
        @(Html.EJ().TreeGrid("TreeGridMakegood").CssClass("e-table").IdMapping("ID") _
                        .ParentIdMapping("ParentID") _
                        .HasChildMapping(True) _
                        .AllowTextWrap(True) _
                        .HeaderTextOverflow(TreeGridHeaderTextOverflow.Wrap) _
                        .SelectionMode(TreeGridSelectionMode.Row) _
                        .SizeSettings(Sub(ss)
                                          ss.Height("auto")
                                      End Sub) _
                        .EditSettings(Sub(edit)
                                          edit.AllowAdding(False)
                                          edit.AllowEditing(True)
                                          edit.AllowDeleting(False)
                                          edit.EditMode(TreeGridEditMode.RowEditing)
                                          edit.BeginEditAction(TreeGridBeginEditAction.DblClick)
                                          edit.BatchEditSettings(Sub(bedit)
                                                                     bedit.EditMode(TreeGridBatchEditMode.Cell)
                                                                 End Sub)
                                      End Sub) _
                        .Columns(Sub(co)

                                     Dim EditorPropertiesZeroDecimals As New Syncfusion.JavaScript.Models.EditorProperties
                                     Dim EditorPropertiesTwoDecimals As New Syncfusion.JavaScript.Models.EditorProperties

                                     EditorPropertiesZeroDecimals.ShowSpinButton = False
                                     EditorPropertiesTwoDecimals.ShowSpinButton = False

                                     EditorPropertiesZeroDecimals.DecimalPlaces = 0
                                     EditorPropertiesTwoDecimals.DecimalPlaces = 2

                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString).AllowEditing(False).HeaderText("Row Type").Width(110).Add()
                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString).AllowEditing(False).HeaderText("Line").Width(120).Add()
                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString).Visible(False).Add()

                                     If Model.MediaType = "T" Then

                                         co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString).AllowEditing(False).EditType(TreeGridEditingType.Boolean).HeaderText("BE").HeaderTooltip("Bookend - spot counts must be even").Width(40).Add()

                                     End If

                                     For SpotColumnCounter As Integer = 0 To Model.SpotCount - 1

                                         Dim SpotDate As Date
                                         Dim DateString = Model.MakegoodDataTable.Columns("Spot" & SpotColumnCounter).Caption

                                         SpotDate = DateSerial(Mid(DateString, 1, 4), Mid(DateString, 5, 2), Mid(DateString, 7, 2))

                                         If Model.MakegoodDataTable.Columns("Spot" & SpotColumnCounter).ReadOnly Then

                                             co.Field("Spot" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText("<span style='color:red'>" & SpotDate.ToString("M/d") & "</span>").HeaderTooltip(SpotDate.ToString("M/d")).AllowEditing(False).Width(62).Add()
                                             co.Field("Rate" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText("Rate" & vbCrLf & SpotDate.ToString("M/d")).Width(0).AllowEditing(False).Visible(False).Add() 'keep Width(0) so it will never show!

                                 Else

                                             co.Field("Spot" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesZeroDecimals).HeaderText(SpotDate.ToString("M/d")).ValidationRules(Sub(v)
                                                                                                                                                                                                                                                                                   v.AddRule("validateSpot", True)
                                                                                                                                                                                                                                                                               End Sub).Width(62).Tooltip("cellTooltipTemplate").Add()

                                             co.Field("Rate" & SpotColumnCounter).EditType(TreeGridEditingType.Numeric).TextAlign(Syncfusion.JavaScript.TextAlign.Right).NumericEditOptions(EditorPropertiesTwoDecimals).HeaderText("Rate" & vbCrLf & SpotDate.ToString("M/d")).Width(125).Visible(False).Format("{0:N2}").Add()

                                         End If

                                     Next

                                     co.Field(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString).TextAlign(Syncfusion.JavaScript.TextAlign.Right).HeaderText("Total Spots").Width(90).AllowEditing(False).Format("{0:N0}").Add()

                                 End Sub) _
                        .ClientSideEvents(Sub(eve)
                                              eve.BeginEdit("beginEditMakegood")
                                              eve.Load("createMakegood")
                                              eve.QueryCellInfo("queryCellInfoMakegood")
                                          End Sub)
        )@(Html.EJ().ScriptManager())
    </p>
</script>
<script id="acceptRejectDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        <label>Comment:</label>
        <textarea name="AcceptRejectComment" id="acceptRejectComment" cols="20" rows="5" style="margin: 0px; height: 92px; width: 361px;"></textarea>
    </p>
</script>
<script id="acceptRejectDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id='btnAcceptRejectDialogOK' class="btn btn-primary">OK</button>
        <button id='btnAcceptRejectDialogCancel' class="btn btn-normal">Cancel</button>
    </div>
</script>
<script id="responseDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        @(Html.Kendo.Grid(Of AdvantageFramework.DTO.Media.OrderAlertComment) _
                                                .Name("Grid") _
                                                .Editable(False) _
                                                .Sortable(Sub(s)
                                                              s.SortMode(GridSortMode.SingleColumn)
                                                              s.Enabled(True)
                                                          End Sub) _
                                                .Scrollable(Sub(s)
                                                                s.Enabled(True)
                                                                s.Height(500)
                                                            End Sub) _
                                                .Columns(Sub(col)
                                                             col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.VendorName.ToString).Column.Title = "Vendor Name"
                                                             col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.Name.ToString).Width(200).Column.Title = "By"
                                                             col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.CommentDateString.ToString).Width(200).Column.Title = "Date/Time"
                                                             col.Bound(AdvantageFramework.DTO.Media.OrderAlertComment.Properties.Comment.ToString)
                                                         End Sub) _
                                                .DataSource(Sub(d)
                                                                d.Ajax() _
                                                        .ServerOperation(False) _
                                                        .Read(Function(r) r.Action("GetResponses", "MakegoodDelivery").Data("getModelData"))
                                                            End Sub)
        )
    </p>
</script>
<script id="responseDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id='btnResponseDialogOK' class="btn btn-primary">OK</button>
    </div>
</script>
<script id="cancelButtonTemplate" type="text/x-jsrender">
    <button id="cancelButton" class="wv-icon-button k-button wv-cancel"
            onclick="cancelClick(); return false;">
        <span class="wvi wvi-sign-forbidden"></span>
    </button>
</script>
<script id="updateMakegoodButtonTemplate" type="text/x-jsrender">
    <button id="updateMakegoodButton" class="k-button wv-icon-button wv-save" onclick="return false;"><span class='wvi wvi-floppy-disk'></span></button>
</script>
<script id="addMakegoodButtonTemplate" type="text/x-jsrender">
    <button id="addMakegoodButton" class="k-button wv-text-button" onclick="return false;"><span>Add Makegood</span></button>
</script>
<script id="addReplacementButtonTemplate" type="text/x-jsrender">
    <button id="addReplacementButton" class="k-button wv-text-button" onclick="return false;"><span>Add Replacement</span></button>
</script>
<script id="viewButtonTemplate" type="text/x-jsrender">
    <button id="viewButton" class="k-button wv-icon-button" onclick="return false;"><span class='wvi wvi-magnifying-glass'></span></button>
</script>
<script id="deleteButtonTemplate" type="text/x-jsrender">
    <button id="deleteButton" class="k-button wv-icon-button wv-cancel" onclick="return false;"><span class='wvi wvi-delete'></span></button>
</script>

<script type="text/javascript">
    var isGridCreated = false;
     function handleChange(checkbox) {
         if (checkbox.checked == true) {
             document.getElementById("accept").removeAttribute("disabled");
         } else {
             document.getElementById("accept").setAttribute("disabled", "disabled");
         }
     }
    function cancelClick() {
        var treeObj = $("#TreeGridContainer").data("ejTreeGrid");
        if (treeObj) {
            treeObj.cancelRowEditCell();
        }
    }
    $(document).ready(function () {
        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var mediatype = @Html.Raw(Json.Encode(Model.MediaType));
        var isOriginalMode = @Html.Raw(Json.Encode(Model.IsOriginalOrderMode));
        var vendorEditLocked = @Html.Raw(Json.Encode(Model.VendorEditLocked));

        if (vendorEditLocked) {
            document.getElementById("btnDownloadOrderDocument").setAttribute("disabled", "disabled");
            document.getElementById("btnDownloadXMLDocument").setAttribute("disabled", "disabled");
            document.getElementById("btnDownloadXMLDocumentAsNew").setAttribute("disabled", "disabled");
            document.getElementById("btnDownloadProposalXML").setAttribute("disabled", "disabled");
        }

        enableDisableSubmit();

        if (mediatype != 'R') {
            document.getElementById("btnDownloadProposalXML").setAttribute("disabled", "disabled");
        }

        //if (mediatype == 'R') {
        //    document.getElementById("btnDownloadXMLDocument").setAttribute("disabled", "disabled");
        //    document.getElementById("btnDownloadXMLDocumentAsNew").setAttribute("disabled", "disabled");
        //}

        if (!isOriginalMode) {
            $('#myDiv1').hide();
        } else {
            $('#myDiv1').show();
        }

        $.validator.addMethod("validateLength", function (value, element, params) {
            return (value >= 0 && value <= 999);
        }, "Length must be 0-999");

        $.validator.addMethod("validateSpot", function (value, element, params) {
            var obj = $("#TreeGridContainer").ejTreeGrid("instance");
            return (value >= 0 && value <= 999);
        }, "Must be 0-999");

        $("#ResponsesModal").ejDialog({
            close: "onResponseDialogClose",
            closeOnEscape: true,
            enableModal: true,
            enableResize: false,
            showFooter: true,
            showOnInit: false,
            width: 800,
            maxWidth: 800,
            footerTemplateId: "responseDialogFooter"
        });

        $("#MakeGoodModal").ejDialog({
            close: "onDialogClose",
            closeOnEscape: true,
            enableModal: true,
            enableResize: false,
            showFooter: true,
            showOnInit: false,
            maxWidth: 1600,
            minWidth: 1600,
            maxHeight: 600,
            minHeight: 600,
            footerTemplateId: "makegoodDialogFooter",
        });

        $('#btnDialogOK').click(function () {
            var editable = $("#MakeGoodModal").data("editable");
            if (editable) {
                var treegridObj = $("#TreeGridMakegood").data("ejTreeGrid");
                try {
                    treegridObj.saveRow();
                }
                catch (err) {
                    //appears saveRow does not have to be called when row is closed for edit already
                }
                //treegridObj.saveCell(); 'Batchediting

                var obj = $("#TreeGridMakegood").ejTreeGrid("instance");
                if (obj.element.find('.e-field-validation-error').length === 0) {
                    MakegoodOK();
                } else {
                    showKendoAlert('Fix errors in grid first.');
                }
            } else {
                $("#MakeGoodModal").ejDialog("close");
            }
        });

        $('#btnDialogCancel').click(function () {
            $("#MakeGoodModal").ejDialog("close");
        });

        $("#AcceptRejectModal").ejDialog({
            closeOnEscape: true,
            enableModal: true,
            enableResize: false,
            showFooter: true,
            showOnInit: false,
            maxWidth: 500,
            footerTemplateId: "acceptRejectDialogFooter"
        });

        $('#btnResponseDialogOK').click(function () {
            $("#ResponsesModal").ejDialog("close");
        });

        $('#btnAcceptRejectDialogOK').click(function () {
            var mediaType = @Html.Raw(Json.Encode(Model.MediaType));
            var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));
            var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
            var salesRep = @Html.Raw(Json.Encode(Model.SalesRep));
            var salesRepEmail = @Html.Raw(Json.Encode(Model.SalesRepEmail));
            var alertID = @Html.Raw(Json.Encode(Model.AlertID));

            var commandID = $("#AcceptRejectModal").data("CommandID");
            var comment = $('#acceptRejectComment').val();

            if ((commandID == 2) && (!$.trim($("#acceptRejectComment").val()))) {
                showNotification("Comment is required when rejecting an order.", "warning")
            } else {
                $("#AcceptRejectModal").ejDialog("close");
                $('#acceptRejectComment').val("");
                if (commandID == 1 || commandID == 2) {
                    kendo.ui.progress($('body'), true);
                    $.ajax({
                        url: 'AcceptRejectOrder',
                        type: "Post",
                        data: { MediaType: mediaType, OrderNumber: orderNumber, DatabaseName: modeldbname, SalesRep: salesRep, SalesRepEmail: salesRepEmail, Command: commandID, Comment: comment, AlertID: alertID },
                        success: function (result) {
                            kendo.ui.progress($('body'), false);
                            window.location.href = result;
                        },
                        error: function (e) {
                            kendo.ui.progress($('body'), false);
                            showNotification("Failed to accept/reject", "error");
                        }
                    });
                } else if (commandID == 3) {
                    kendo.ui.progress($('body'), true);
                    $.ajax({
                        url: 'NewComment',
                        type: "Post",
                        data: { MediaType: mediaType, OrderNumber: orderNumber, DatabaseName: modeldbname, SalesRepEmail: salesRepEmail, Comment: comment },
                        success: function (result) {
                            kendo.ui.progress($('body'), false);
                        },
                        error: function (e) {
                            kendo.ui.progress($('body'), false);
                            showNotification("Failed to add new comment", "error");
                        }
                    });
                } else if (commandID == 4) {
                    kendo.ui.progress($('body'), true);
                    $.ajax({
                        url: 'SubmitMakegood',
                        type: "Post",
                        data: { MediaType: mediaType, OrderNumber: orderNumber, DatabaseName: modeldbname, SalesRep: salesRep, SalesRepEmail: salesRepEmail, Comment: comment },
                        success: function (result) {
                            kendo.ui.progress($('body'), false);
                            window.location.href = result;
                        },
                        error: function (e) {
                            kendo.ui.progress($('body'), false);
                            showNotification("Failed to add submit makegoods", "error");
                        }
                    });
                }
            }
        });

        $('#btnAcceptRejectDialogCancel').click(function () {
            $('#acceptRejectComment').val("");
            $("#AcceptRejectModal").ejDialog("close");
        });

        //if (isOriginalMode) {
        //    $("#rowStartDate").hide();
        //} else {
        //    setdropdownvalue(0);
        //}


    });
    function acceptOrder(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 1);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "Accept Order");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    function rejectOrder(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 2);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "Reject Order");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    function cancel(args) {
        $.ajax({
            url: 'CancelAcceptRejectOrder',
            type: "Post",
            data: { },
            success: function (result) {
                kendo.ui.progress($('body'), false);
                window.location.href = result;
            },
            error: function (e) {
                kendo.ui.progress($('body'), false);
                window.location.href = result;
            }
        });
    };

    function submitMakegood(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 4);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "Transmit Makegood Submission");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    function toolbarClick(args) {
        if (args.itemName == "Cancel") {
            if (!isButtonDisabled("cancelButton")) {
                disableButton("updateMakegoodButton");
                disableButton("cancelButton");
                document.getElementById("btnToggleRates").removeAttribute("disabled", "disabled");
                $('#submit').show();
                var grid = $("#TreeGridContainer").data("ejTreeGrid");
                var selected = grid.getSelectedRecords()[0];
                var args2 = {
                    data: selected
                };
                enableDisableToolbarButtons(args2);
            }
        }
        if (args.itemName == "Update Makegood") {
            if (!isButtonDisabled("updateMakegoodButton")) {
                var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
                var mediatype = @Html.Raw(Json.Encode(Model.MediaType));
                var form = $("#" + this._id + "EditForm"),
                    index = this.getIndexByRow(form.closest("tr")),
                    currentItem = args.model.currentViewData[index],
                    currentValue = ej.copyObject({}, currentItem.item),
                    columns = args.model.columns;

                for (var i = 0; i < args.model.columns.length; i++) {
                    var column = columns[i],
                        fieldName = column["field"],
                        editType = ej.isNullOrUndefined(column["editType"]) ? "stringedit" : column["editType"];
                    value = this.getCurrentEditCellDataForRowEdit(fieldName, editType, i);
                    currentValue[fieldName] = value;
                }

                $.ajax({
                    url: 'ValidateDaysAndTime',
                    type: "Post",
                    data: currentValue,
                    data: { DBName: modeldbname, MediaType: mediatype, MakegoodDeliveryDetailViewModel: currentValue },
                    success: function (result) {
                        if (result.IsValid) {
                            var grid = $("#TreeGridContainer").data("ejTreeGrid");
                            grid.saveRow();
                            document.getElementById("btnToggleRates").removeAttribute("disabled", "disabled");
                            var selected = grid.getSelectedRecords()[0];
                            var args2 = {
                                data: selected
                            };
                            enableDisableToolbarButtons(args2);
                            enableDisableSubmit();
                        } else {
                            showNotification(result.ErrorText, "error");
                        }
                    },
                    error: function (e) {
                        showNotification("Validation call failed", "error");
                    }
                });
            }
        }
        if (args.itemName == "Add Makegood" || args.itemName == "Add Replacement" || args.itemName == "View Makegood Details" || args.itemName == "Delete Makegood") {
            var obj = $("#TreeGridContainer").ejTreeGrid("instance");
            var selected = obj.getSelectedRecords()[0];
            var args2 = {
                data: selected
            };
        }
        if (args.itemName == "Add Makegood") {
            if (!isButtonDisabled("addMakegoodButton")) {
                customMenuMakegoodHandler(args2);
            }
        }
        if (args.itemName == "Add Replacement") {
            if (!isButtonDisabled("addReplacementButton")) {
                customMenuAddReplacementHandler(args2);
            }
        }
        if (args.itemName == "View Makegood Details") {
            if (!isButtonDisabled("viewButton")) {
                viewMakegood(args2);
            }
        }
        if (args.itemName == "Delete Makegood") {
            if (!isButtonDisabled("deleteButton")) {
                customMenuDeleteMakegoodHandler(args2);
            }
        }
     }

    $(function () {
        $(".e-treegridrows").click(function (e) {
            if ($("#TreeGridContainerEditForm").length > 0)
                e.stopImmediatePropagation();
        });
    });

    function create(args) {
        isGridCreated = true;

        disableButton("cancelButton");
        disableButton("updateMakegoodButton");
        disableButton("addMakegoodButton");
        disableButton("addReplacementButton");
        disableButton("viewButton");
        disableButton("deleteButton");

    }

    function CreateDaypart(args) {
        return $("<input>");
    }
    function WriteDaypart(args) {
        args.element.ejDropDownList({
            width: "100%",
            dataSource: args.column.dropdownData,
            fields: { text: "Description", value: "ID" },
            value: args.rowdata.DayPartID
        });
    }
    function ReadDaypart(args) {
        //return args.ejDropDownList("getSelectedValue");
        var DropDownListObj = args.ejDropDownList().data("ejDropDownList");
        return DropDownListObj.option("text"); //column is DaypartDescription, this will be updated and passed back to controller that will update the DaypartID
    }

    function CreateCableNetwork(args) {
        return $("<input>");
    }
    function WriteCableNetwork(args) {
        args.element.ejDropDownList({
            width: "100%",
            dataSource: args.column.dropdownData,
            fields: { text: "Description", value: "Code" },
            value: args.rowdata.CableNetwork
        });
    }
    function ReadCableNetwork(args) {
        return args.ejDropDownList("getSelectedValue");
        //var DropDownListObj = args.ejDropDownList().data("ejDropDownList");
        //return DropDownListObj.option("text"); //column is DaypartDescription, this will be updated and passed back to controller that will update the DaypartID
    }

    function endEdit(args) {
        var Record = args.currentValue;
        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var mediatype = @Html.Raw(Json.Encode(Model.MediaType));
        var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));

        if (args.requestType === "update") {
            kendo.ui.progress($('body'), true);
            $.ajax({
                type: "POST",
                url: "UpdateMakegoodDeliveryDetail",
                data: { MediaType: mediatype, DatabaseName: modeldbname, MakegoodDeliveryDetailViewModel: Record, OrderNumber: orderNumber },
                dataType: "json"
            }).done(function (data) {
                kendo.ui.progress($('body'), false);
                if (data == false) {
                    location.reload(true);
                } else {
                    var grid = $("#TreeGridContainer").data("ejTreeGrid");
                    grid.setModel({ dataSource: data });
                }
            });
        }
        $('#submit').show();
        document.getElementById("btnToggleRates").removeAttribute("disabled", "disabled");
        disableButton("cancelButton");
        disableButton("updateMakegoodButton");
    }

    function enableDisableSubmit() {
        var isOriginalOrderMode = @Html.Raw(Json.Encode(Model.IsOriginalOrderMode));
        var vendorEditLocked = @Html.Raw(Json.Encode(Model.VendorEditLocked));
        if (!isOriginalOrderMode && !vendorEditLocked) {
            var obj = $("#TreeGridContainer").ejTreeGrid("instance");
            var submitEnabled = false;
            var discardEnabled = false;
            for (i = 0; i < obj.model.dataSource.length; i++) {
                if (obj.model.dataSource[i].IsOriginal == false && obj.model.dataSource[i].ID > 0 && obj.model.dataSource[i].IsSubmitted == false) {
                    submitEnabled = true;
                    break;
                }
            }
            for (i = 0; i < obj.model.dataSource.length; i++) {
                if (obj.model.dataSource[i].IsOriginal == false && obj.model.dataSource[i].ID > 0 && obj.model.dataSource[i].IsSubmitted == false) {
                    discardEnabled = true;
                    break;
                }
            }
            if (!submitEnabled) {
                document.getElementById("submit").setAttribute("disabled", "disabled");
                document.getElementById("submit").title = "No makegoods entered, cannot submit";
            } else {
                document.getElementById("submit").removeAttribute("disabled", "disabled");
                document.getElementById("submit").title = "Submit Makegood Offer";
            }
            if (!discardEnabled) {
                document.getElementById("discard").setAttribute("disabled", "disabled");
            } else {
                document.getElementById("discard").removeAttribute("disabled", "disabled");
            }
        }

    }

    function beginEdit(args) {
        var vendorEditLocked = @Html.Raw(Json.Encode(Model.VendorEditLocked));
        if (args.data.IsOriginal || vendorEditLocked || args.data.IsSubmitted || args.data.ID < 0) {
            args.cancel = true;
        } else {
            for (i = 0; i < args.model.columns.length; i++) {
                if (args.model.columns[i].field.substring(0, 4) === "Spot") {
                    if (args.model.selectedItem[args.model.columns[i].field] == null) {
                        args.model.columns[i].allowEditing = false;
                    } else {
                        args.model.columns[i].allowEditing = true;
                    }
                }
            }
            enableButton("cancelButton");
            enableButton("updateMakegoodButton");
            document.getElementById("btnToggleRates").setAttribute("disabled", "disabled");
            disableToolbarForEdit(args);
            $('#submit').hide();
        }
    }

    function rowDataBound(args) {
        if (args.data.IsOriginal) { //hide edit button on parent rows
            args.rowElement.find(".e-button").hide();
        }
        if (!args.data.IsOriginal) {
            args.rowElement.addClass('editable');
        }
        if (args.data.ID == -1000) {
            args.rowElement.hide();
        }
        if (args.data.Line == "Grand Total:") {
            args.rowElement.addClass('grandtotal');
        }
    }

    //function contextMenuOpen(args) {
    //    var column = args.model.columns[args.columnIndex];
    //    var fieldName = column.field;
    //    var obj = $("#TreeGridContainer").ejTreeGrid("instance");
    //    var spots = obj.getSelectedRecords()[0][fieldName];

    //    args.contextMenuItems = [];

    //    if ((column.allowCellSelection) && (column.field.substring(0, 4) === "Spot") && (spots >= 0) && (args.item.ID > 0)) {
    //        args.contextMenuItems.push({
    //            headerText: "Makegood",
    //            menuId: spots + ',' + fieldName,  //this is the number of spots for the fieldname
    //            iconPath: "url(../../Images/Icons/Grey/256/add.png)",
    //            eventHandler: customMenuMakegoodHandler,
    //            disable: (args.item.IsOriginal == false || spots == null || args.item.IsSubmitted)
    //        });
    //        args.contextMenuItems.push({
    //            headerText: "Add Replacement",
    //            menuId: "AddReplacement",
    //            iconPath: "url(../../Images/Icons/Grey/256/add.png)",
    //            eventHandler: customMenuAddReplacementHandler,
    //            disable: (args.item.IsOriginal == false || spots == null || args.item.IsSubmitted)
    //        });
    //        args.contextMenuItems.push({
    //            headerText: "Delete",
    //            menuId: "DeleteMakegood",
    //            iconPath: "url(../../Images/Icons/Grey/256/delete.png)",
    //            eventHandler: customMenuDeleteMakegoodHandler,
    //            disable: (args.item.IsOriginal == true || args.item.IsSubmitted)
    //        });
    //    }
    //}

    function customMenuMakegoodHandler(args) {
        //$("#MakeGoodModal").data("MenuID", args.menuId);
        $("#MakeGoodModal").data("StagingDetailID", args.data.ID);
        $("#MakeGoodModal").data("Bookend", args.data.Bookend);
        //var menuId = $("#MakeGoodModal").data("MenuID");
        //var result = menuId.split(",", 2);
        //var spots = parseInt(result[0]);
        //var datatableColumnName = result[1];
        var stagingDetailID = $("#MakeGoodModal").data("StagingDetailID");
        //var bookEnd = $("#MakeGoodModal").data("Bookend");
        var title = "Enter number of preempted spots for each date";
        var mediaType = @Html.Raw(Json.Encode(Model.MediaType));

        //var strDate = String(spotDates[datatableColumnName]);

        var grid = $("#TreeGridContainer").data("ejTreeGrid");
        var dataManager = ej.DataManager(grid.model.dataSource);
        var dataSource = dataManager.executeLocal(ej.Query().where(ej.Predicate("ID", "equal", stagingDetailID, true).or("ID", "equal", -1000, true)));
        $("#MakeGoodModal").data("ds", dataSource);
        $("#MakeGoodModal").data("editable", true);

        var template = document.getElementById("makegoodDialogContent");
        var templateHTML = template.innerHTML;
        var outputHTML = "";
        outputHTML = templateHTML.replace(/{{days}}/g, args.data.Days).replace(/{{start}}/g, args.data.StartTime).replace(/{{end}}/g, args.data.EndTime).replace(/{{length}}/g, args.data.Length);

        if (mediaType = 'T') {
            outputHTML = outputHTML.replace(/{{programlabel}}/g, 'Program:').replace(/{{program}}/g, args.data.Program);
        } else {
            outputHTML = outputHTML.replace(/{{programlabel}}/g, '').replace(/{{program}}/g, '');
        }

        $("#MakeGoodModal").ejDialog("open", args);
        $("#MakeGoodModal").ejDialog("setTitle", title);
        $("#MakeGoodModal").ejDialog("setContent", outputHTML);
    }

    function customMenuDeleteMakegoodHandler(args) {
        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));
        var mediaType = @Html.Raw(Json.Encode(Model.MediaType));
        var stagingDetailID = args.data.ID;

        kendo.ui.progress($('body'), true);
        $.ajax({
            type: "POST",
            url: "DeleteMakegood",
            data: { DatabaseName: modeldbname, MediaBroadcastWorksheetMarketStagingDetailID: stagingDetailID, OrderNumber: orderNumber, MediaType: mediaType },
            dataType:  "json"
        }).done(function (data) {
            kendo.ui.progress($('body'), false);
            if (data.success) {
                var grid = $("#TreeGridContainer").data("ejTreeGrid");
                grid.setModel({ dataSource: JSON.parse(data.data) });
                enableDisableSubmit();

                var selected = grid.getSelectedRecords()[0];
                var args2 = {
                    data: selected
                };
                enableDisableToolbarButtons(args2);
            } else {
                window.location.href = data.data;
            }
        });
    }

    function customMenuAddReplacementHandler(args) {
        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));
        var mediaType = @Html.Raw(Json.Encode(Model.MediaType));
        var stagingDetailID = args.data.ID;

        kendo.ui.progress($('body'), true);
        $.ajax({
            type: "POST",
            url: "AddReplacement",
            data: { MediaType: mediaType, DatabaseName: modeldbname, MediaBroadcastWorksheetMarketStagingDetailID: stagingDetailID, OrderNumber: orderNumber },
            dataType: "json"
        }).done(function (data) {
            kendo.ui.progress($('body'), false);
            //console.log(data);
            if (data.success) {
                var grid = $("#TreeGridContainer").data("ejTreeGrid");
                grid.setModel({ dataSource: JSON.parse(data.data) });
                enableDisableSubmit();
            } else {
                window.location.href = data.data;
            }
        });
    }

    function disableToolbarForEdit(args) {
        disableButton("addMakegoodButton");
        disableButton("addReplacementButton");
        disableButton("viewButton");
        disableButton("deleteButton");
    }

    function enableDisableToolbarButtons(args) {
        if (args.data.ID < 0) {
            $("#TreeGridContainer_edit").addClass('e-disable');
            disableButton("addMakegoodButton");
            disableButton("addReplacementButton");
            disableButton("deleteButton");
            disableButton("viewButton");
        } else if (args.data.IsOriginal == true && args.data.IsSubmitted == true) {
            $("#TreeGridContainer_edit").addClass('e-disable');
            disableButton("addMakegoodButton");
            disableButton("addReplacementButton");
            disableButton("deleteButton");
            enableButton("viewButton");
        } else if (args.data.IsOriginal == false && args.data.IsSubmitted == true) {
            $("#TreeGridContainer_edit").addClass('e-disable');
            disableButton("addMakegoodButton");
            disableButton("addReplacementButton");
            disableButton("deleteButton");
            enableButton("viewButton");
        } else if (args.data.IsOriginal == true) {
            $("#TreeGridContainer_edit").addClass('e-disable');
            enableButton("addMakegoodButton");
            enableButton("addReplacementButton");
            disableButton("deleteButton");
            enableButton("viewButton");
        } else {
            $("#TreeGridContainer_edit").removeClass('e-disable');
            disableButton("addMakegoodButton");
            disableButton("addReplacementButton");
            enableButton("deleteButton");
            enableButton("viewButton");
        }
    }

    function viewMakegood(args) {
        var title = "Makegood Details";
        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));
        var mediaType = @Html.Raw(Json.Encode(Model.MediaType));
        var stagingDetailID = args.data.ID;
        $.ajax({
            type: "POST",
            url: "ViewMakegoodDetails",
            data: { MediaType: mediaType, DatabaseName: modeldbname, MediaBroadcastWorksheetMarketStagingDetailID: stagingDetailID, OrderNumber: orderNumber },
            dataType: "json"
        }).done(function (data) {
            if (data.success) {

                $("#MakeGoodModal").data("ds", JSON.parse(data.data));
                $("#MakeGoodModal").data("editable", false);

                var template = document.getElementById("makegoodDialogContent");
                var templateHTML = template.innerHTML;
                var outputHTML = "";
                outputHTML = templateHTML.replace(/{{days}}/g, args.data.Days).replace(/{{start}}/g, args.data.StartTime).replace(/{{end}}/g, args.data.EndTime).replace(/{{length}}/g, args.data.Length);

                if (mediaType = 'T') {
                    outputHTML = outputHTML.replace(/{{programlabel}}/g, 'Program:').replace(/{{program}}/g, args.data.Program);
                } else {
                    outputHTML = outputHTML.replace(/{{programlabel}}/g, '').replace(/{{program}}/g, '');
                }

                $("#MakeGoodModal").ejDialog("open", args);
                $("#MakeGoodModal").ejDialog("setTitle", title);
                $("#MakeGoodModal").ejDialog("setContent", outputHTML);
            }
        });
    }

    function rowSelected(args) {
        document.getElementById('selectedRow').value = args.recordIndex;
        enableDisableToolbarButtons(args);
    }

    function queryCellInfo(args) {
        //if ((args.column.field.startsWith("Spot")) && (args.data[args.column.field] != null)) {
        //    var rate = 'Rate' + args.column.field.substring(4);
        //    if (args.data.DefaultRate > args.data[rate]) {
        //        $(args.cellElement).addClass("red");
        //    } else if (args.data.DefaultRate < args.data[rate]) {
        //        $(args.cellElement).addClass("green");
        //    }
        //} else
        if (args.column.field == "DefaultRate") {
            if (args.data.RateDiffersFlag == true) {
                $(args.cellElement).addClass("red");
            }
        }
        else if (args.column.field == "PrimaryImpressions") {
            var mediatype = @Html.Raw(Json.Encode(Model.MediaType));
            var modifiedValue = 0.0;
            var actualValue = args.data.PrimaryImpressions;
            var n;

            //if (!isGridCreated) {
                if (mediatype == 'R') {
                    modifiedValue = Math.round(actualValue / 100);
                    //modifiedValue = ej.format(modifiedValue, "#,#");
                    //n = modifiedValue.toFixed(0);
                } else {
                    modifiedValue = Math.round(actualValue / 100);
                    modifiedValue = modifiedValue / 10;
                    //modifiedValue = ej.format(modifiedValue, "#.#");
                }
            if (actualValue == null) {
                args.cellElement.innerText = '';
            } else {
                args.cellElement.innerText = modifiedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }

            //} else {
            //    modifiedValue = typeof (actualValue) == "string" ? parseFloat(actualValue) : actualValue;
            //    //if (mediatype == 'R') {
            //    //    modifiedValue = ej.format(modifiedValue, "#,#");
            //    //} else {
            //    //    modifiedValue = ej.format(modifiedValue, "#.#");
            //    //}
            //    console.log(modifiedValue);
            //    args.cellElement.innerText = modifiedValue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");;
            //    isGridCreated = false;
            //}

        }
    }

    function MakegoodOK(args) {

        var modeldbname = @Html.Raw(Json.Encode(Model.DatabaseName));
        var spotDates = @Html.Raw(Json.Encode(Model.SpotDates));
        var orderNumber = @Html.Raw(Json.Encode(Model.OrderNumber));
        var mediaType = @Html.Raw(Json.Encode(Model.MediaType));

        //var menuId = $("#MakeGoodModal").data("MenuID");

        //var result = menuId.split(",", 2);
        //var spots = parseInt(result[0]);
        //var datatableColumnName = result[1];
        var stagingDetailID = $("#MakeGoodModal").data("StagingDetailID");
        //var bookEnd = $("#MakeGoodModal").data("Bookend");

        //var makegood = $('#makegoodNumber').val();

        var grid = $("#TreeGridMakegood").data("ejTreeGrid");
        //console.log(grid.model);

        //var dataManager = ej.DataManager(grid.model.dataSource);
        //var dataSource = dataManager.executeLocal(ej.Query().where("ID", "equal", -1000));
        //console.log(dataSource);

        var currentItem = grid.model.currentViewData[1];
        var currentValue;

        if (currentItem) {
            currentValue = ej.copyObject({}, currentItem.item);

            $("#MakeGoodModal").ejDialog("close");
            kendo.ui.progress($('body'), true);
            $.ajax({
                type: "POST",
                url: "Makegood2",
                data: { MediaType: mediaType, DatabaseName: modeldbname, MediaBroadcastWorksheetMarketStagingDetailID: stagingDetailID, MakegoodDeliveryDetailViewModel: currentValue, OrderNumber: orderNumber },
                dataType: "json"
            }).done(function (data) {
                kendo.ui.progress($('body'), false);
                //console.log(data);
                if (data.success) {
                    var grid = $("#TreeGridContainer").data("ejTreeGrid");
                    grid.setModel({ dataSource: JSON.parse(data.data) });
                    enableDisableSubmit();
                } else {
                    window.location.href = data.data;
                }
            });

        } else {
            console.log("NO currentItem!");
            console.log(grid);
            console.log(grid.model);
        }

    };

    function newComment(args) {
        var template = document.getElementById("acceptRejectDialogContent");
        $("#AcceptRejectModal").data("CommandID", 3);
        $("#AcceptRejectModal").ejDialog("open", args);
        $("#AcceptRejectModal").ejDialog("setTitle", "New Comment");
        $("#AcceptRejectModal").ejDialog("setContent", template.innerHTML);
    };

    function onDialogClose() {
        $("#MakeGoodModal").ejDialog("close");
    };

    function onResponseDialogClose() {
        $("#ResponsesModal").ejDialog("close");
    };

    function calcCPP(args, data) {
        if (ej.sum(data, "PrimaryGRP") == 0) {
            return 0;
        } else {
            return ej.sum(data, "TotalGross") / ej.sum(data, "PrimaryGRP");
        }
    };

    function calcCPM(args, data) {
        if (ej.sum(data, "PrimaryGIMP") == 0) {
            return 0;
        } else {
            var mediatype = @Html.Raw(Json.Encode(Model.MediaType));
            if (mediatype == "R") {
                return ej.sum(data, "TotalGross") / (ej.sum(data, "PrimaryGIMP") * 100) * 1000;
            } else {
                return ej.sum(data, "TotalGross") / (ej.sum(data, "PrimaryGIMP") * 1000) * 1000;
            }
        }
    };

    $('#btnToggleRates').click(function () {
        var spotCount = @Html.Raw(Json.Encode(Model.SpotCount));
        var obj = $("#TreeGridContainer").ejTreeGrid("instance");
        var column;
        var isVisible;
        var ratesVisible = document.getElementById('ratesVisible').value;
        var isSpotVisible;

        if (ratesVisible == '0') {
            isVisible = false;
        } else {
            isVisible = true;
        }

        column = obj.getColumnByField("DefaultRate");
        column.allowEditing = isVisible;

        var treeObject = $("#TreeGridContainer").data("ejTreeGrid");
        treeObject.clearSelection();

        var i;
        for (i = 0; i < spotCount; i++) {
            column = obj.getColumnByField("Spot" + i);
            isSpotVisible = column.visible;

            if (isSpotVisible) {
                column = obj.getColumnByField("Rate" + i);
                if (column.width > 0) {
                    column.visible = !isVisible;
                }
            }

        }
        obj.refresh(obj.model.dataSource);

        $("#TreeGridContainer").ejTreeGrid("option", "selectedRowIndex", document.getElementById('selectedRow').value);

        if (!isVisible) {
            var header = $("#TreeGridContainer").find(".e-columnheader");
            header.css({ height: '50px' });
        }
        if (ratesVisible == '0') {
            document.getElementById('ratesVisible').value = "1";
        } else {
            document.getElementById('ratesVisible').value = "0";
        }

    })

    @*function setdropdownvalue(itemId) {
        var spotCount = @Html.Raw(Json.Encode(Model.SpotCount));
        var obj = $("#TreeGridContainer").ejTreeGrid("instance");
        var column;
        var isVisible;
        var ratesVisible = document.getElementById('ratesVisible').value;

        if (ratesVisible == '0') {
            isVisible = false;
        } else {
            isVisible = true;
        }

        var treeObject = $("#TreeGridContainer").data("ejTreeGrid");
        treeObject.clearSelection();

        var i;
        for (i = 0; i < spotCount; i++) {
            if (i < itemId || i > (itemId + 11)) {
                column = obj.getColumnByField("Spot" + i);
                column.visible = false;

                column = obj.getColumnByField("Rate" + i);
                column.visible = false;
            } else {
                column = obj.getColumnByField("Spot" + i);
                column.visible = true;

                column = obj.getColumnByField("Rate" + i);
                column.visible = isVisible;
            }
        }
        obj.refresh(obj.model.dataSource);

        $("#TreeGridContainer").ejTreeGrid("option", "selectedRowIndex", document.getElementById('selectedRow').value);

        if (!isVisible) {
            var header = $("#TreeGridContainer").find(".e-columnheader");
            header.css({ height: '50px' });
        }
    }*@

    //function changedropdown(args) {
    //    var itemId = args.itemId;
    //    setdropdownvalue(itemId);
    //}

    var mgModel = {
        DatabaseName: @Html.Raw(Json.Encode(Model.DatabaseName)),
        AlertID: @Html.Raw(Json.Encode(Model.AlertID)),
        VendorTime: new Date().getTimezoneOffset(),
    };

    function getModelData() {
        return mgModel;
    };

    $('#btnResponses').click(function (args) {
        var template = document.getElementById("responseDialogContent");
        var templateHTML = template.innerHTML;

        $("#ResponsesModal").ejDialog("open", args);
        $("#ResponsesModal").ejDialog("setContent", templateHTML);
    })

    $('#btnNewComment').click(function () {
        newComment();
    })

    function createMakegood(args) {

        var grid = $("#TreeGridMakegood").data("ejTreeGrid");
        var ds = $("#MakeGoodModal").data("ds");

        grid.dataSource(ej.parseJSON(ds));
        grid.refreshContent(true);

        var editable = $("#MakeGoodModal").data("editable");
        var obj = $("#TreeGridMakegood").ejTreeGrid("instance");
        column = obj.getColumnByField("TotalSpots");
        column.visible = !editable;
    }

    function beginEditMakegood(args) {
        var editable = $("#MakeGoodModal").data("editable");
        if (editable == false) {
            args.cancel = true;
        } else if (args.data.IsOriginal) {
            args.cancel = true;
        } else {
            var column = args.model.columns[args.columnIndex];
            var fieldName = column.field;
            var grid = $("#TreeGridMakegood").ejTreeGrid("instance");
            var orderedSpotsRow = grid.model.currentViewData[0];
            var cancel = false;

            for (i = 0; i < args.model.columns.length; i++) {
                if (args.model.columns[i].field.substring(0, 4) === "Spot") {
                    if (orderedSpotsRow[args.model.columns[i].field] == null || orderedSpotsRow[args.model.columns[i].field] == 0) {
                        args.model.columns[i].allowEditing = false;
                        if (fieldName == args.model.columns[i].field) {
                            cancel = true;
                        }
                    }
                }
            }
            args.cancel = cancel;
        }
    }

    function queryCellInfoMakegood(args) {
        var editable = $("#MakeGoodModal").data("editable");
        if (editable == true) {
            var obj = $("#TreeGridMakegood").ejTreeGrid("instance");
            var rowIndex = args.data.index;
            if (rowIndex > 0) {
                var previousRecord = obj.getCurrentViewData()[rowIndex - 1];
                if (args.column.field.substring(0, 4) === "Spot") {
                    var previousRecordValue = previousRecord[args.column.field];
                    if (args.cellValue == null) {
                        args.cellValue = 0;
                        args.data[args.column.field] = 0;
                        args.data.item[args.column.field] = 0;
                        args.cellElement.innerHTML = 0;
                    } else if (previousRecordValue < args.cellValue) {
                        showKendoAlert('Invalid makegood.  Must be less than or equal to the number of spots for the ordered date.  Setting to ' + previousRecordValue + '.')
                        args.cellValue = previousRecordValue;
                        args.data[args.column.field] = previousRecordValue;
                        args.data.item[args.column.field] = previousRecordValue;
                        args.cellElement.innerHTML = previousRecordValue;
                    } else if (args.cellValue < 0) {
                        args.cellValue = 0;
                        args.data[args.column.field] = 0;
                        args.data.item[args.column.field] = 0;
                        args.cellElement.innerHTML = previousRecordValue;
                    }
                    if (previousRecord['Bookend'] == true) {
                        if (args.cellValue % 2 != 0) {
                            showKendoAlert('Invalid makegood.  Bookend must be an even number.  Setting to 0.');
                            args.cellValue = 0;
                            args.data[args.column.field] = 0;
                            args.data.item[args.column.field] = 0;
                            args.cellElement.innerHTML = 0;
                        }
                    }
                }
            }
        }
    }

</script>

<script type="text/x-jsrender" id="cellTooltipTemplate">
    <div style='padding:10px;font-weight: bold;'>
        {{if #data.column.field.substring(0,4) === "Spot" && #data['record']['Line'] < 9999999}}
        {{:'Rate: ' + #data['record']['Rate' + #data.column.field.substring(4)]}}
        {{else}}
        {{:#data['record'][#data.column.field]}}
        {{/if}}
    </div>
</script>
<script type="text/x-jsrender" id="cellTooltipTemplateDefaultRate">
    <div style='padding:10px;font-weight: bold;'>
        {{if #data['record']['RateDiffersFlag'] === true}}
        {{:'Rates Vary by Day/Week'}}
        {{/if}}
    </div>
</script>
@Functions

End Functions

<style type="text/css">
    label {
        font-weight: normal;
    }

    /*.e-treegrid .e-toolbaricons {
        color: #1a1a1a;
    }*/

    #TreeGridContainer_edit {
        border: 1px solid #767676;
    }

    strong {
        font-weight: bold;
        font-size: 22px;
    }

    textarea {
        Width: 1306px;
        Height: 86px;
    }

    label {
        vertical-align: top;
    }

    .e-treegrid .e-selectionbackground {
        background-color: lightskyblue;
        color: white !important;
        /*opacity: 1; #ffd800;*/
    }

    .e-selectionbackground .e-inner-treecolumn-container {
        color: white;
    }

    .e-treegrid.e-wrap .e-headercelldiv {
        text-align: center;
    }

    .modal-dialog {
        z-index: 9999;
    }

    .form-group .control-label, .form-group .form-control-static, p, span, .panel-body {
        font-family: Verdana !important;
        font-size: 10pt;
    }

    td font span {
        font-family: Verdana !important;
        font-size: 10pt;
        font-weight: normal;
    }

    .form-control-static tr td:first-child font span {
        font-weight: normal !important;
    }

    html, body, table, th, td {
        font-family: Verdana, Arial, sans-serif !important;
    }

    .e-dialog > .e-header .e-title {
        font-family: Verdana, Arial, sans-serif !important;
        font-size: 11pt;
        font-weight: normal;
    }

    #MakeGoodModal label {
        font-weight: normal;
    }

    h2 {
        font-size: 24px;
    }

    #OrderHeader tr td {
        padding: 6px 4px;
    }

    #myDiv2 label {
        font-weight: normal;
        line-height: 16px;
    }

    #myDiv1 {
        margin-top: 6px;
    }

    .e-treegrid .e-headercelldiv {
        color: #282827;
        font-family: Verdana;
        font-weight: normal;
    }

    .btn {
        border-radius: 4px;
        padding: 6px 12px;
    }

    .red {
        padding: 1em 3em;
        border: 1px solid grey;
        background-image: linear-gradient(225deg, red, red 10px, transparent 10px, transparent);
    }

    .green {
        padding: 1em 3em;
        border: 1px solid grey;
        background-image: linear-gradient(225deg, green, green 10px, transparent 10px, transparent);
    }

    /*.CustomUpdate:before {
        content: "\e620";
    }

    .table-bordered {
        margin: 10px auto;
        max-width: 1400px;
    }*/

    #TreeGridContainer {
        margin: 6px auto;
        padding: 0 20px;
        /*height: auto !important;*/
    }

    /*.e-toolbar {
        background: #e5e5e5;
        border-top: 0;
        border-left: transparent;
        border-radius: 0;
        margin: 6px 6px 0 6px;
        border: 1px solid #ccc;
        border-top-left-radius: 4px;
        border-top-right-radius: 4px;
    }*/

    /*.e-toolbar li {
            padding-left: 5px;
        }

    .e-treegrid .e-treegridtoolbar {
        background-color: #e5e5e5 !important;
        border-color: #c8c8c8 !important;
    }*/

    /*.e-toolbar li {
        border: #ccc 1px solid;
        background-color: white;
        height: 32px;
        line-height: 32px;
        width: 32px;
        text-align: center;
        padding: 0 5px;
        font-size: 20px !important;
        margin: 4px 6px;
    }*/

    /*.e-toolbar li {
        font-size: 16px !important;
    }

    .menu-bar li {
        padding: 0;
    }*/

    #TreeGridContainer_cancel {
        background: #d9534f;
        border-color: #d9534f;
        color: white;
    }

    /*#TreeGridContainer_cancel:hover {
            background: #d9534f !important;
            border-color: #d9534f;
            color: white;
        }

        #TreeGridContainer_cancel a {
            color: white;
        }*/

    /*.e-toolbar > .e-horizontal .e-disable, .e-toolbar > .e-vertical .e-disable {
        color: #a1a1a1;
        border: #ccc 1px solid;
        background-color: #fff;
        background-image: none;
    }*/

    /*.e-treegrid .e-treegridtoolbaritem {
        border: #ccc 1px solid;
    }*/

    #TreeGridContainer_CustomUpdate .e-icon {
        font-size: 16px;
    }

    #TreeGridContainer_CustomUpdate {
        color: #fff;
        background-color: #337ab7;
        border-color: #2e6da4;
    }

        #TreeGridContainer_CustomUpdate:hover {
            color: #fff;
            background-color: #337ab7;
            border-color: #2e6da4;
        }

    .e-menuitem .e-tgcontextmenu-image {
        background-position: center;
        background-size: contain;
    }


    /*#TreeGridContainere-gridcontent{
        height:100% !important;
    }*/

    #TreeGridContainer_CustomUpdate .e-icon {
        color: white;
    }

    /*.e-treegrid .e-treegridtoolbaritem {
        width: 28px;
    }*/

    .e-tgcontextmenu, .e-tginnerContextmenu {
        color: #262626;
        font-family: Verdana, Arial, sans-serif !important;
        font-size: 10pt;
        font-weight: normal;
        border-radius: 6px;
    }

    .e-tgcontextmenu-mouseover {
        background: #f5f5f5;
    }

    .e-menuitem .e-icon {
        width: 8px;
        height: 6px;
        margin-top: 4px;
    }

    #InformationModal h4, #TermsOfAgreementModal h4 {
        border-bottom: transparent;
    }

    #InformationModal strong {
        font-size: 12px;
    }

    #InformationModal ul li {
        padding: 8px 0;
    }

    #InformationModal .modal-dialog {
        width: 900px;
    }

    #InformationModal .modal-body {
        padding: 8px 14px;
    }
    /*Change the cancel icons*/
    /*.e-treegrid .e-treegrid-cancel:before {
        font-family: 'wv-icons';
        src: url('fonts/wv-icons.eot');
        content: "\e96d";
    }*/

    /*.e-dragintend {
        width: 10px !important;
    }*/

    .k-i-error {
        display: none !important;
    }

    .e-icon.e-arrow-sans-down:before {
        font-family: 'wv-icons';
        src: url('fonts/wv-icons.eot');
        content: "";
    }

    .e-chkbox-wrap .e-chk-image.e-checkmark:before {
        font-family: 'wv-icons';
        src: url('fonts/wv-icons.eot');
        content: "\e91e";
        width: 100%;
        height: 100%;
    }

    .editable {
        background-color: #dcefff !important;
    }
    .grandtotal {
        background-color: #a1d3ff !important;
    }
    /*  The below removes syncfusion CSS behind custom buttons */
    .e-tooltxt {
        background: none !important;
        border-color: transparent !important;
    }
        .e-tooltxt:active {
            background: none !important;
            border-color: transparent !important;
        }
        .e-tooltxt:hover {
            background: none !important;
            border-color: transparent !important;
        }
    /*  The above removes syncfusion CSS behind custom buttons */
</style>
