@ModelType Object
@Code
    ' Do not put a title here! Let the OpenRadWindow function decide the title since this is used by multiple different reports
    'ViewData("Title") = "General Ledger Detail by Account Report" 
    ViewData("IsFullLayout") = True
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<style type="text/css">
    .k-checkbox-label {
        font-weight: normal;
    }

    #typeTable td, #statusTable td {
        padding-right: 5px;
        padding-top: 5px;
    }

    *, :before, :after {
        -webkit-box-sizing: content-box;
        -moz-box-sizing: content-box;
        box-sizing: content-box;
    }

    /* set a border-box model only to elements that need it */

    .form-control, /* if this class is applied to a Kendo UI widget, its layout may change */
    .container,
    .container-fluid,
    .row,
    .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1,
    .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2,
    .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3,
    .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4,
    .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5,
    .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6,
    .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7,
    .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8,
    .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9,
    .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10,
    .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11,
    .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
    }
    .adv-tab-content {
        padding-top: 10px !important;
    }
</style>

@helper OptionsContent()

    @<div class="form-horizontal col-sm-12 adv-tab-content"> 
        <div class="form-group" style="display: none;">
            <label class="control-label col-sm-2" for="ReportFormat">Report Format:</label>
            <div class="col-sm-10">
                @(Html.Kendo().DropDownList().Name("ReportFormat").Items(Sub(c)
                                                                             c.Add().Text("Detail by Account Code - Portrait").Value(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountPortrait).Code).Selected(True)
                                                                             c.Add().Text("Detail by Account Code - Landscape").Value(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.DetailByAccountLandscape).Code)
                                                                             c.Add().Text("Trial Balance").Value(AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.GeneralLedger.ReportWriter.StandardGeneralLedgerReports.TrialBalance).Code)
                                                                         End Sub).HtmlAttributes(New With {.style = "width: 350px"}))
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-3 col-md-3 col-lg-2" for="StartPostPeriod">

                @If Model.HideEndingPostPeriod = False Then

                    @Html.Raw("Starting Post Period:  ")

                Else

                    @Html.Raw("Ending Post Period:  ")

                End If
                     
            </label> 
            <div class="col-sm-6 col-md-5 col-lg-4">
                @(Html.Kendo().DropDownList().Name("StartPostPeriod").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                         ds.Read("DetailByAccountReport_PostPeriods", "GeneralLedgerReport").ServerFiltering(False)
                                                                                                                                                                                     End Sub).HtmlAttributes(New With {.style = "width: 350px"}).Events(Sub(e)
                                                                                                                                                                                                                                                            e.DataBound("setInitialPostPeriod")
                                                                                                                                                                                                                                                        End Sub))
            </div>
            @If Model.HideEndingPostPeriod = False Then

                @<div class="col-sm-3 col-md-3 col-lg-2">
                    <span>
                        @(Html.Kendo().Button().Content("YTD").Name("YTD").HtmlAttributes(New With {.style = "width: 60px;"}).Events(Sub(e) e.Click("postPeriodYTD")))
                    </span>
                    <span>
                        @(Html.Kendo().Button().Content("1 Year").Name("1Year").HtmlAttributes(New With {.style = "width: 80px;"}).Events(Sub(e) e.Click("postPeriod1Year")))
                    </span>
                </div>

            End If
            
        </div>

    @If Model.HideEndingPostPeriod = False Then

        @<div class="form-group">
            <label class="control-label col-sm-3 col-md-3 col-lg-2" for="EndPostPeriod">Ending Post Period:</label>
            <div class="col-sm-6 col-md-5 col-lg-4">
                @(Html.Kendo().DropDownList().Name("EndPostPeriod").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                       ds.Read("DetailByAccountReport_PostPeriods", "GeneralLedgerReport")
                                                                                                                                                                                   End Sub).HtmlAttributes(New With {.style = "width: 350px"}).Events(Sub(e)
                                                                                                                                                                                                                                                          e.DataBound("setInitialPostPeriod")
                                                                                                                                                                                                                                                      End Sub))
            </div>
            <div class="col-sm-3 col-md-3 col-lg-2">
                <span>
                    @(Html.Kendo().Button().Content("MTD").Name("MTD").HtmlAttributes(New With {.style = "width: 60px;"}).Events(Sub(e) e.Click("postPeriodMTD")))
                </span>
                <span>
                    @(Html.Kendo().Button().Content("2 Years").Name("2Years").HtmlAttributes(New With {.style = "width: 80px;"}).Events(Sub(e) e.Click("postPeriod2Years")))
                </span>
            </div>
        </div>

    End If
        
        <div class="form-group">
            <label class="control-label col-sm-3 col-md-3 col-lg-2">Record Source:</label>
            <div class="col-sm-6 col-md-5 col-lg-4">
                @(Html.Kendo().DropDownList().Name("RecordSourceID").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                        ds.Read("DetailByAccountReport_RecordSources", "GeneralLedgerReport")
                                                                                                                                                                                    End Sub).HtmlAttributes(New With {.style = "width: 350px"}))
            </div>
        </div>
    </div>

End Helper

@helper OfficesContent()

    @<div class="adv-tab-content">
        <div class="col-sm-5">
            @(Html.Kendo().Grid(Of Object)().Name("AvailableOfficesGrid").Columns(Sub(c)
                                                                                      c.Bound("Code").Width(100)
                                                                                      c.Bound("Description")
                                                                                      c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                                  End Sub).DataSource(Sub(d)
                                                                                                          d.Ajax() _
                                                                                                          .ServerOperation(False) _
                                                                                                          .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                          .Read(Function(r)
                                                                                                                    Return r.Action("DetailByAccountReport_LoadOffices", "GeneralLedgerReport")
                                                                                                                End Function) _
                                                                                                           .Model(Sub(m)
                                                                                                                      m.Id("Code")
                                                                                                                      m.Field("Description", GetType(String))
                                                                                                                      m.Field("IsInactive", GetType(Boolean))
                                                                                                                  End Sub)
                                                                                                      End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                                s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                            End Sub).Events(Sub(e)
                                                                                                                                                                                                                e.Change("checkOffices")
                                                                                                                                                                                                                e.DataBound("checkOffices")
                                                                                                                                                                                                            End Sub))
            <div style="margin-top: 5px;">
                @(Html.Kendo.CheckBox().Name("AvailableOfficesIncludeInactive").Label("Include Inactive").Checked(False))
            </div>
        </div>
        <div class="col-sm-2">
            @(Html.Kendo().Button().Name("AddOffice").Content(">").Events(Sub(e) e.Click("addOffice")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
            @(Html.Kendo().Button().Name("AddAllOffices").Content(">>").Events(Sub(e) e.Click("addAllOffices")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
            @(Html.Kendo().Button().Name("RemoveOffice").Content("<").Events(Sub(e) e.Click("removeOffice")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
            @(Html.Kendo().Button().Name("RemoveAllOffices").Content("<<").Events(Sub(e) e.Click("removeAllOffices")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        </div>
        <div class="col-sm-5">
            @(Html.Kendo().Grid(Of Object)().Name("SelectedOfficesGrid").Columns(Sub(c)
                                                                                     c.Bound("Code").Width(100)
                                                                                     c.Bound("Description")
                                                                                     c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                                 End Sub).DataSource(Sub(d)
                                                                                                         d.Ajax() _
                                                                                                          .ServerOperation(False) _
                                                                                                          .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                          .Model(Sub(m)
                                                                                                                     m.Id("Code")
                                                                                                                     m.Field("Description", GetType(String))
                                                                                                                     m.Field("IsInactive", GetType(Boolean))
                                                                                                                 End Sub)
                                                                                                     End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                               s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                           End Sub).Events(Sub(e)
                                                                                                                                                                                                               e.Change("checkOffices")
                                                                                                                                                                                                               e.DataBound("checkOffices")
                                                                                                                                                                                                           End Sub))

        </div>
    </div>

End Helper

@helper DepartmentsContent()

    @<div class="adv-tab-content">
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("AvailableDepartmentsGrid").Columns(Sub(c)
                                                                                      c.Bound("Code").Width(100)
                                                                                      c.Bound("Description")
                                                                                      c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                                  End Sub).DataSource(Sub(d)
                                                                                                          d.Ajax() _
                                                                                                          .ServerOperation(False) _
                                                                                                          .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                          .Read(Function(r)
                                                                                                                    Return r.Action("DetailByAccountReport_LoadDepartments", "GeneralLedgerReport")
                                                                                                                End Function) _
                                                                                                           .Model(Sub(m)
                                                                                                                      m.Id("Code")
                                                                                                                      m.Field("Description", GetType(String))
                                                                                                                      m.Field("IsInactive", GetType(Boolean))
                                                                                                                  End Sub)
                                                                                                      End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                                s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                            End Sub).Events(Sub(e)
                                                                                                                                                                                                                e.Change("checkDepartments")
                                                                                                                                                                                                                e.DataBound("checkDepartments")
                                                                                                                                                                                                            End Sub))
        <div style="margin-top: 5px;">
            @(Html.Kendo.CheckBox().Name("AvailableDepartmentsIncludeInactive").Label("Include Inactive").Checked(False))
        </div>
    </div>
    <div class="col-sm-2">
        @(Html.Kendo().Button().Name("AddDepartment").Content(">").Events(Sub(e) e.Click("addDepartment")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("AddAllDepartments").Content(">>").Events(Sub(e) e.Click("addAllDepartments")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveDepartment").Content("<").Events(Sub(e) e.Click("removeDepartment")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveAllDepartments").Content("<<").Events(Sub(e) e.Click("removeAllDepartments")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
    </div>
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("SelectedDepartmentsGrid").Columns(Sub(c)
                                                                                     c.Bound("Code").Width(100)
                                                                                     c.Bound("Description")
                                                                                     c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                                 End Sub).DataSource(Sub(d)
                                                                                                         d.Ajax() _
                                                                                                          .ServerOperation(False) _
                                                                                                          .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                          .Model(Sub(m)
                                                                                                                     m.Id("Code")
                                                                                                                     m.Field("Description", GetType(String))
                                                                                                                     m.Field("IsInactive", GetType(Boolean))
                                                                                                                 End Sub)
                                                                                                     End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                               s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                           End Sub).Events(Sub(e)
                                                                                                                                                                                                               e.Change("checkDepartments")
                                                                                                                                                                                                               e.DataBound("checkDepartments")
                                                                                                                                                                                                           End Sub))
    </div>
</div>

End Helper

@helper BaseContent()

    @<div class="adv-tab-content">
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("AvailableBasesGrid").Columns(Sub(c)
                                                                                c.Bound("Code").Width(100)
                                                                                c.Bound("Description")
                                                                                c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                            End Sub).DataSource(Sub(d)
                                                                                                    d.Ajax() _
                                                                                                    .ServerOperation(False) _
                                                                                                    .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                    .Read(Function(r)
                                                                                                              Return r.Action("DetailByAccountReport_LoadBases", "GeneralLedgerReport").Data("getReportData")
                                                                                                          End Function) _
                                                                                                     .Model(Sub(m)
                                                                                                                m.Id("Code")
                                                                                                                m.Field("Description", GetType(String))
                                                                                                                m.Field("IsInactive", GetType(Boolean))
                                                                                                            End Sub)
                                                                                                End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                          s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                      End Sub).Events(Sub(e)
                                                                                                                                                                                                          e.Change("checkBases")
                                                                                                                                                                                                          e.DataBound("checkBases")
                                                                                                                                                                                                      End Sub))
        <div style="margin-top: 5px;">
            @(Html.Kendo.CheckBox().Name("AvailableBasesIncludeInactive").Label("Include Inactive").Checked(False))
        </div>
    </div>
    <div class="col-sm-2">
        @(Html.Kendo().Button().Name("AddBase").Content(">").Events(Sub(e) e.Click("addBase")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("AddAllBases").Content(">>").Events(Sub(e) e.Click("addAllBases")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveBase").Content("<").Events(Sub(e) e.Click("removeBase")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveAllBases").Content("<<").Events(Sub(e) e.Click("removeAllBases")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
    </div>
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("SelectedBasesGrid").Columns(Sub(c)
                                                                               c.Bound("Code").Width(100)
                                                                               c.Bound("Description")
                                                                               c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                           End Sub).DataSource(Sub(d)
                                                                                                   d.Ajax() _
                                                                                                    .ServerOperation(False) _
                                                                                                    .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                    .Model(Sub(m)
                                                                                                               m.Id("Code")
                                                                                                               m.Field("Description", GetType(String))
                                                                                                               m.Field("IsInactive", GetType(Boolean))
                                                                                                           End Sub)
                                                                                               End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                         s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                     End Sub).Events(Sub(e)
                                                                                                                                                                                                         e.Change("checkBases")
                                                                                                                                                                                                         e.DataBound("checkBases")
                                                                                                                                                                                                     End Sub))
    </div>
</div>

End Helper

@helper OtherContent()

    @<div class="adv-tab-content">
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("AvailableOthersGrid").Columns(Sub(c)
                                                                                 c.Bound("Code").Width(100)
                                                                                 c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                             End Sub).DataSource(Sub(d)
                                                                                                     d.Ajax() _
                                                                                                     .ServerOperation(False) _
                                                                                                     .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                     .Read(Function(r)
                                                                                                               Return r.Action("DetailByAccountReport_LoadOthers", "GeneralLedgerReport").Data("getReportData")
                                                                                                           End Function) _
                                                                                                      .Model(Sub(m)
                                                                                                                 m.Id("Code")
                                                                                                                 m.Field("IsInactive", GetType(Boolean))
                                                                                                             End Sub)
                                                                                                 End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                           s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                       End Sub).Events(Sub(e)
                                                                                                                                                                                                           e.Change("checkOthers")
                                                                                                                                                                                                           e.DataBound("checkOthers")
                                                                                                                                                                                                       End Sub))
        <div style="margin-top: 5px;">
            @(Html.Kendo.CheckBox().Name("AvailableOthersIncludeInactive").Label("Include Inactive").Checked(False))
        </div>
    </div>
    <div class="col-sm-2">
        @(Html.Kendo().Button().Name("AddOther").Content(">").Events(Sub(e) e.Click("addOther")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("AddAllOthers").Content(">>").Events(Sub(e) e.Click("addAllOthers")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveOther").Content("<").Events(Sub(e) e.Click("removeOther")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveAllOthers").Content("<<").Events(Sub(e) e.Click("removeAllOthers")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
    </div>
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("SelectedOthersGrid").Columns(Sub(c)
                                                                                c.Bound("Code").Width(100)
                                                                                c.Bound("IsInactive").ClientTemplate("<input type='checkbox' #= IsInactive ? checked='checked' : '' # disabled='disabled' ></input>")
                                                                            End Sub).DataSource(Sub(d)
                                                                                                    d.Ajax() _
                                                                                                     .ServerOperation(False) _
                                                                                                     .Sort(Sub(s) s.Add("Code").Ascending()) _
                                                                                                     .Model(Sub(m)
                                                                                                                m.Id("Code")
                                                                                                                m.Field("IsInactive", GetType(Boolean))
                                                                                                            End Sub)
                                                                                                End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                          s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                      End Sub).Events(Sub(e)
                                                                                                                                                                                                          e.Change("checkOthers")
                                                                                                                                                                                                          e.DataBound("checkOthers")
                                                                                                                                                                                                      End Sub))
    </div>
</div>

End Helper

@helper AccountTypesContent()

    @<div class="adv-tab-content">
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("AvailableAccountTypesGrid").Columns(Sub(c)
                                                                                       c.Bound("Code").Width(100).Visible(False)
                                                                                       c.Bound("Description")
                                                                                   End Sub).DataSource(Sub(d)
                                                                                                           d.Ajax() _
                                                                                                           .ServerOperation(False) _
                                                                                                           .Read(Function(r)
                                                                                                                     Return r.Action("DetailByAccountReport_LoadAccountTypes", "GeneralLedgerReport")
                                                                                                                 End Function) _
                                                                                                            .Model(Sub(m)
                                                                                                                       m.Id("Code")
                                                                                                                       m.Field("Description", GetType(String))
                                                                                                                   End Sub)
                                                                                                       End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                                 s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                             End Sub).Events(Sub(e)
                                                                                                                                                                                                                 e.Change("checkAccountTypes")
                                                                                                                                                                                                                 e.DataBound("checkAccountTypes")
                                                                                                                                                                                                             End Sub))
    </div>
    <div class="col-sm-2">
        @(Html.Kendo().Button().Name("AddAccountType").Content(">").Events(Sub(e) e.Click("addAccountType")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("AddAllAccountTypes").Content(">>").Events(Sub(e) e.Click("addAllAccountTypes")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveAccountType").Content("<").Events(Sub(e) e.Click("removeAccountType")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
        @(Html.Kendo().Button().Name("RemoveAllAccountTypers").Content("<<").Events(Sub(e) e.Click("removeAllAccountTypes")).HtmlAttributes(New With {.style = "width: 100%; margin-bottom: 5px;"}))
    </div>
    <div class="col-sm-5">
        @(Html.Kendo().Grid(Of Object)().Name("SelectedAccountTypesGrid").Columns(Sub(c)
                                                                                      c.Bound("Code").Width(100).Visible(False)
                                                                                      c.Bound("Description")
                                                                                  End Sub).DataSource(Sub(d)
                                                                                                          d.Ajax() _
                                                                                                           .ServerOperation(False) _
                                                                                                           .Model(Sub(m)
                                                                                                                      m.Id("Code")
                                                                                                                      m.Field("Description", GetType(String))
                                                                                                                  End Sub)
                                                                                                      End Sub).HtmlAttributes(New With {.style = "height: 400px;"}).Scrollable().Selectable(Sub(s)
                                                                                                                                                                                                s.Mode(GridSelectionMode.Multiple)
                                                                                                                                                                                            End Sub).Events(Sub(e)
                                                                                                                                                                                                                e.Change("checkAccountTypes")
                                                                                                                                                                                                                e.DataBound("checkAccountTypes")
                                                                                                                                                                                                            End Sub))
    </div>
</div>

End Helper

<div style="margin-top: 10px;">

    <div>
        @(Html.Kendo().TabStrip().Name("TabStrip").Items(Sub(tabStrip)

                                                             tabStrip.Add().Text("Options").Content(OptionsContent().ToHtmlString()).Selected(True)

                                                             If Model.IncludeOffices = True Then

                                                                 tabStrip.Add().Text("Office").Content(OfficesContent().ToHtmlString()).HtmlAttributes(New With {.id = "OfficeTab"})

                                                             End If

                                                             If Model.IncludeDepartments = True Then

                                                                 tabStrip.Add().Text("Department / Teams").Content(DepartmentsContent().ToHtmlString()).HtmlAttributes(New With {.id = "DepartmentTab"})

                                                             End If

                                                             If Model.IncludeAccountTypes = True Then

                                                                 tabStrip.Add().Text("Types").Content(AccountTypesContent().ToHtmlString())

                                                             End If

                                                             If Model.IncludeOthers = True Then

                                                                 tabStrip.Add().Text("Other").Content(OtherContent().ToHtmlString()).HtmlAttributes(New With {.id = "OtherTab"})

                                                             End If

                                                             If Model.IncludeBases = True Then

                                                                 tabStrip.Add().Text("Base").Content(BaseContent().ToHtmlString()).HtmlAttributes(New With {.id = "BaseTab"})

                                                             End If

                                                         End Sub).Animation(False).Events(Sub(e)
                                                                                              e.Select("onTabSelect")
                                                                                              e.Show("onTabShow")
                                                                                          End Sub))
        <div class="pull-right" style="margin-top: 10px;">
            @(Html.Kendo().Button().Name("ViewReport").Content("OK").HtmlAttributes(New With {.style = "width: 100px"}).Events(Sub(e) e.Click("viewReport")))
            @(Html.Kendo().Button().Name("Cancel").Content("Cancel").HtmlAttributes(New With {.style = "width: 100px"}).Events(Sub(e) e.Click("closeWindow")))
        </div>
    </div>

</div>

<script>

    var AvailableOfficesGrid, 
        SelectedOfficesGrid,
        AvailableDepartmentsGrid,
        SelectedDepartmentsGrid,
        AvailableBasesGrid,
        SelectedBasesGrid,
        AvailableOthersGrid,
        SelectedOthersGrid,
        AccountTypesChanged,
        AvailableAccountTypesGrid,
        SelectedAccountTypesGrid;

    $(document).ready(function () {
        AvailableOfficesGrid = $('#AvailableOfficesGrid').data("kendoGrid");
        SelectedOfficesGrid = $('#SelectedOfficesGrid').data("kendoGrid");
        AvailableDepartmentsGrid = $('#AvailableDepartmentsGrid').data("kendoGrid");
        SelectedDepartmentsGrid = $('#SelectedDepartmentsGrid').data("kendoGrid");
        AvailableBasesGrid = $('#AvailableBasesGrid').data("kendoGrid");
        SelectedBasesGrid = $('#SelectedBasesGrid').data("kendoGrid");
        AvailableOthersGrid = $('#AvailableOthersGrid').data("kendoGrid");
        SelectedOthersGrid = $('#SelectedOthersGrid').data("kendoGrid");
        AvailableAccountTypesGrid = $('#AvailableAccountTypesGrid').data("kendoGrid");
        SelectedAccountTypesGrid = $('#SelectedAccountTypesGrid').data("kendoGrid");
        AccountTypesChanged = false;
        $('#AvailableOfficesIncludeInactive').change(function () {
            filterOffices();
        });
        $('#AvailableDepartmentsIncludeInactive').change(function () {
            filterDepartments();
        });
        $('#AvailableOthersIncludeInactive').change(function () {
            filterOthers();
        });
        $('#AvailableBasesIncludeInactive').change(function () {
            filterBases();
        });
    });

    function postPeriodYTD() {
        loadPostPeriodPresetOption(0);
    }
    function postPeriodMTD() {
        loadPostPeriodPresetOption(1);
    }
    function postPeriod1Year() {
        loadPostPeriodPresetOption(2);
    }
    function postPeriod2Years() {
        loadPostPeriodPresetOption(3);
    }
    function loadPostPeriodPresetOption(optionValue) {
        var data = { PresetOption: optionValue };
        $.get({
            url: window.appBase + '@Html.Raw(Webvantage.Controllers.GeneralLedger.Reports.GeneralLedgerReportController.BaseRoute)LoadPresetPostPeriod',
            data: data
        }).always(function (result) {
            if (result) {
                if (result.PostPeriodStart) {
                    $('#StartPostPeriod').data('kendoDropDownList').value(result.PostPeriodStart);
                }
                if (result.PostPeriodEnd) {
                    $('#EndPostPeriod').data('kendoDropDownList').value(result.PostPeriodEnd);
                }
            }
        });
    }

    function transferSelectedItem(sourceGrid, destinationGrid) {
        var selected = sourceGrid.select();
        var selectString = [];
        $.each(selected, function () {
            var item = sourceGrid.dataSource.getByUid($(this).attr('data-uid'));
            if (item) {
                selectString.push('tr[data-uid="' + item.uid + '"]');
                transferItem(sourceGrid, destinationGrid, item);
            }
        });
        if (sourceGrid.dataItems().length > 0) {
            sourceGrid.select($(sourceGrid.element).find('tr:eq(1)'));
        }
        destinationGrid.select(selectString.join(', '));
    }
    function transferAllItems(sourceGrid, destinationGrid) {
        var items = sourceGrid.dataItems();
        for(var i = 0; i < items.length; i++){
            transferItem(sourceGrid, destinationGrid, items[i]);
        }
        destinationGrid.select("tr[data-uid='" + destinationGrid.dataSource.at(0).uid + "']");
    }
    function transferItem(sourceGrid, destinationGrid, item) {
        sourceGrid.dataSource.remove(item);
        destinationGrid.dataSource.insert(destinationGrid.dataItems().length, item);
    }

    function addOffice() {
        transferSelectedItem(AvailableOfficesGrid, SelectedOfficesGrid);
        autoFitOffices();
    }
    function addAllOffices() {
        transferAllItems(AvailableOfficesGrid, SelectedOfficesGrid);
        autoFitOffices();
    }
    function removeOffice() {
        transferSelectedItem(SelectedOfficesGrid, AvailableOfficesGrid);
        autoFitOffices();
    }
    function removeAllOffices() {
        transferAllItems(SelectedOfficesGrid, AvailableOfficesGrid);
        autoFitOffices();
    }
    function filterOffices() {
        var uids = [];
        $.each($(AvailableOfficesGrid.element).find('tr.k-state-selected'), function () {
            uids.push($(this).attr('data-uid'));
        });
        AvailableOfficesGrid.dataSource.filter({ field: 'IsInactive', operator: 'neq', value: $('#AvailableOfficesIncludeInactive').is(":checked") ? null : true });
        if (uids.length > 0) {
            $.each(uids, function () {
                AvailableOfficesGrid.select("tr[data-uid='" + this + "']");
            });
        }
    }
    function autoFitOffices() {
        AvailableOfficesGrid.autoFitColumn(0);
        AvailableOfficesGrid.autoFitColumn(1);
        SelectedOfficesGrid.autoFitColumn(0);
        SelectedOfficesGrid.autoFitColumn(1);
    }
    function checkOffices() {

        var AddOffice = $('#AddOffice').data('kendoButton');
        var AddAllOffices = $('#AddAllOffices').data('kendoButton');
        var RemoveOffice = $('#RemoveOffice').data('kendoButton');
        var RemoveAllOffices = $('#RemoveAllOffices').data('kendoButton');
        var hasAvailable = $(AvailableOfficesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;
        var hasSelected = $(SelectedOfficesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;

        AddOffice.enable(hasAvailable);
        AddAllOffices.enable(AvailableOfficesGrid.dataItems().length > 0 ? true : false);
        RemoveOffice.enable(hasSelected);
        RemoveAllOffices.enable(SelectedOfficesGrid.dataItems().length > 0 ? true : false);
    }

    function addDepartment() {
        transferSelectedItem(AvailableDepartmentsGrid, SelectedDepartmentsGrid);
        autoFitDepartments();
    }
    function addAllDepartments() {
        transferAllItems(AvailableDepartmentsGrid, SelectedDepartmentsGrid);
        autoFitDepartments();
    }
    function removeDepartment() {
        transferSelectedItem(SelectedDepartmentsGrid, AvailableDepartmentsGrid);
        autoFitDepartments();
    }
    function removeAllDepartments() {
        transferAllItems(SelectedDepartmentsGrid, AvailableDepartmentsGrid);
        autoFitDepartments();
    }
    function filterDepartments() {
        var uids = [];
        $.each($(AvailableDepartmentsGrid.element).find('tr.k-state-selected'), function () {
            uids.push($(this).attr('data-uid'));
        });
        AvailableDepartmentsGrid.dataSource.filter({ field: 'IsInactive', operator: 'neq', value: $('#AvailableDepartmentsIncludeInactive').is(":checked") ? null : true });
        if (uids.length > 0) {
            $.each(uids, function () {
                AvailableDepartmentsGrid.select("tr[data-uid='" + this + "']");
            });
        }
    }
    function autoFitDepartments() {
        AvailableDepartmentsGrid.autoFitColumn(0);
        AvailableDepartmentsGrid.autoFitColumn(1);
        SelectedDepartmentsGrid.autoFitColumn(0);
        SelectedDepartmentsGrid.autoFitColumn(1);
    }
    function checkDepartments() {

        var AddDepartment = $('#AddDepartment').data('kendoButton');
        var AddAllDepartments = $('#AddAllDepartments').data('kendoButton');
        var RemoveDepartment = $('#RemoveDepartment').data('kendoButton');
        var RemoveAllDepartments = $('#RemoveAllDepartments').data('kendoButton');
        var hasAvailable = $(AvailableDepartmentsGrid.element).find('tr.k-state-selected').length > 0 ? true : false;
        var hasSelected = $(SelectedDepartmentsGrid.element).find('tr.k-state-selected').length > 0 ? true : false;

        AddDepartment.enable(hasAvailable);
        AddAllDepartments.enable(AvailableDepartmentsGrid.dataItems().length > 0 ? true : false);
        RemoveDepartment.enable(hasSelected);
        RemoveAllDepartments.enable(SelectedDepartmentsGrid.dataItems().length > 0 ? true : false);

    }

    function addBase() {
        transferSelectedItem(AvailableBasesGrid, SelectedBasesGrid);
    }
    function addAllBases() {
        transferAllItems(AvailableBasesGrid, SelectedBasesGrid);
    }
    function removeBase() {
        transferSelectedItem(SelectedBasesGrid, AvailableBasesGrid);
    }
    function removeAllBases() {
        transferAllItems(SelectedBasesGrid, AvailableBasesGrid);
    }
    function filterBases() {
        AvailableBasesGrid.dataSource.filter({ field: 'IsInactive', operator: 'neq', value: $('#AvailableBasesIncludeInactive').is(":checked") ? null : true });
    }
    function autoFitBases() {
        AvailableBasesGrid.autoFitColumn(0);
        AvailableBasesGrid.autoFitColumn(1);
        SelectedBasesGrid.autoFitColumn(0);
        SelectedBasesGrid.autoFitColumn(1);
    }
    function checkBases() {

        var AddBase = $('#AddBase').data('kendoButton');
        var AddAllBases = $('#AddAllBases').data('kendoButton');
        var RemoveBase = $('#RemoveBase').data('kendoButton');
        var RemoveAllBases = $('#RemoveAllBases').data('kendoButton');
        var hasAvailable = $(AvailableBasesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;
        var hasSelected = $(SelectedBasesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;

        AddBase.enable(hasAvailable);
        AddAllBases.enable(AvailableBasesGrid.dataItems().length > 0 ? true : false);
        RemoveBase.enable(hasSelected);
        RemoveAllBases.enable(SelectedBasesGrid.dataItems().length > 0 ? true : false);

    }

    function addOther() {
        transferSelectedItem(AvailableOthersGrid, SelectedOthersGrid);
    }
    function addAllOthers() {
        transferAllItems(AvailableOthersGrid, SelectedOthersGrid);
    }
    function removeOther() {
        transferSelectedItem(SelectedOthersGrid, AvailableOthersGrid);
    }
    function removeAllOthers() {
        transferAllItems(SelectedOthersGrid, AvailableOthersGrid);
    }
    function filterOthers() {
        AvailableOthersGrid.dataSource.filter({ field: 'IsInactive', operator: 'neq', value: $('#AvailableOthersIncludeInactive').is(":checked") ? null : true });
    }
    function autoFitOthers() {
        AvailableOthersGrid.autoFitColumn(0);
        SelectedOthersGrid.autoFitColumn(0);
    }
    function checkOthers() {

        var AddOther = $('#AddOther').data('kendoButton');
        var AddAllOthers = $('#AddAllOthers').data('kendoButton');
        var RemoveOther = $('#RemoveOther').data('kendoButton');
        var RemoveAllOthers = $('#RemoveAllOthers').data('kendoButton');
        var hasAvailable = $(AvailableOthersGrid.element).find('tr.k-state-selected').length > 0 ? true : false;
        var hasSelected = $(SelectedOthersGrid.element).find('tr.k-state-selected').length > 0 ? true : false;

        AddOther.enable(hasAvailable);
        AddAllOthers.enable(AvailableOthersGrid.dataItems().length > 0 ? true : false);
        RemoveOther.enable(hasSelected);
        RemoveAllOthers.enable(SelectedOthersGrid.dataItems().length > 0 ? true : false);

    }

    function addAccountType() {
        transferSelectedItem(AvailableAccountTypesGrid, SelectedAccountTypesGrid);
    }
    function addAllAccountTypes() {
        transferAllItems(AvailableAccountTypesGrid, SelectedAccountTypesGrid);
    }
    function removeAccountType() {
        transferSelectedItem(SelectedAccountTypesGrid, AvailableAccountTypesGrid);
    }
    function removeAllAccountTypes() {
        transferAllItems(SelectedAccountTypesGrid, AvailableAccountTypesGrid);
    }
    function checkAccountTypes() {

        var AddAccountType = $('#AddAccountType').data('kendoButton');
        var AddAllAccountTypes = $('#AddAllAccountTypes').data('kendoButton');
        var RemoveAccountType = $('#RemoveAccountType').data('kendoButton');
        var RemoveAllAccountTypes = $('#RemoveAllAccountTypes').data('kendoButton');
        var hasAvailable = $(AvailableAccountTypesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;
        var hasSelected = $(SelectedAccountTypesGrid.element).find('tr.k-state-selected').length > 0 ? true : false;

        AddAccountType.enable(hasAvailable);
        AddAllAccountTypes.enable(hasAvailable);
        RemoveAccountType.enable(hasSelected);
        RemoveAllAccountTypes.enable(hasSelected);

    }

    function typesChanged() {
        AccountTypesChanged = true;
        SelectedBasesGrid.dataSource.read();
    }

    function getReportData() {
        var recordSource = $('#RecordSourceID').val();
        if (recordSource !== '') {
            recordSource = Number(recordSource);
        } else {
            recordSource = 0;
        }
        var selectedOptions = {
            Report: JSON.parse($('#ReportFormat').val().toLowerCase()),
            StartPostPeriod: $('#StartPostPeriod').val(),
            EndPostPeriod: $('#EndPostPeriod').val(),
            EndPostPeriod: $('#@Html.Raw(If(Model.HideEndingPostPeriod = True, "StartPostPeriod", "EndPostPeriod"))').val(),
            RecordSourceID: recordSource,
            Offices: getSelectedGridItemsString(SelectedOfficesGrid),
            Departments: getSelectedGridItemsString(SelectedDepartmentsGrid),
            Others: getSelectedGridItemsString(SelectedOthersGrid),
            Bases: getSelectedGridItemsString(SelectedBasesGrid),
            AccountTypes: getSelectedGridItemsString(SelectedAccountTypesGrid)
        };
        
        return selectedOptions;
    }
    function getSelectedGridItemsString(grid) {
        var itemString = '';
        if (grid) {
            $.each(grid.dataItems(), function () {
                itemString += this.Code;
                if (grid.dataItems().indexOf(this) !== (grid.dataItems().length - 1)) {
                    itemString += ',';
                }
            });
        }
        return itemString;
    }
    function onTabShow(e) {
        if (e.item.id === 'OfficeTab') {
            autoFitOffices();
        }
        if (e.item.id === 'DepartmentTab') {
            autoFitDepartments();
        }
        if (e.item.id === 'BaseTab') {
            autoFitBases();
        }
        if (e.item.id === 'OtherTab') {
            autoFitOthers();
        }
    }
    function onTabSelect(e) {
        if (e.item.id === 'OfficeTab') {
            filterOffices();
            if (AvailableOfficesGrid.select().length === 0) {
                if (AvailableOfficesGrid.dataItems().length > 0) {
                    AvailableOfficesGrid.select($(AvailableOfficesGrid.element).find("tr:eq(1)"))
                }
            }
            if (SelectedOfficesGrid.select().length === 0) {
                if (SelectedOfficesGrid.dataItems().length > 0) {
                    SelectedOfficesGrid.select($(SelectedOfficesGrid.element).find("tr:eq(1)"))
                }
            }
        }
        if (e.item.id === 'DepartmentTab') {
            filterDepartments();
            if (AvailableDepartmentsGrid.select().length === 0) {
                if (AvailableDepartmentsGrid.dataItems().length > 0) {
                    AvailableDepartmentsGrid.select($(AvailableDepartmentsGrid.element).find("tr:eq(1)"))
                }
            }
            if (SelectedDepartmentsGrid.select().length === 0) {
                if (SelectedDepartmentsGrid.dataItems().length > 0) {
                    SelectedDepartmentsGrid.select($(SelectedDepartmentsGrid.element).find("tr:eq(1)"))
                }
            }
        }
        if (e.item.id === 'BaseTab') {
            if (AccountTypesChanged === true) {
                AccountTypesChanged = false;
                AvailableBasesGrid.dataSource.read().always(function(){
                    filterBases();
                });
            } else {
                filterBases();
            }
            
        }
        if (e.item.id === 'OtherTab') {
            if (AccountTypesChanged === true) {
                AccountTypesChanged = false;
                AvailableOthersGrid.dataSource.read().always(function () {
                    filterOthers();
                });
            } else {
                filterOthers();
            }
        }
    }
    function viewReport() {
        var data = getReportData();
        if (data.StartPostPeriod <= data.EndPostPeriod) {
            $.ajax({
                type: 'GET',
                url: '@Url.Action("ViewDetailByAccountReport", "GeneralLedgerReport")',
                data: data,
                dataType: 'json'
            }).done(function (result) {
                RefreshWindow(result.url, true, true);
                CloseThisWindow();
            }).fail(function (result) {
               //console.log(result);
                showKendoAlert('Something went terribly wrong!');
            });
        } else {
            showKendoAlert('Please select a starting post period that is before the ending post period.');
        }
    }

    function setInitialPostPeriod(e) {
        $.each(e.sender.dataItems(), function () {
            if (this.IsCurrent === true) {
                e.sender.value(this.Code);
            }
        });
    }

    

</script>
