Imports System
Imports System.Text
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Webvantage.MiscFN
Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure
Imports System.Collections.Generic

Partial Public Class DesktopMyGrossIncomeGraph
    Inherits Webvantage.BaseDesktopObject

    Dim agy_setting As Int16
    Dim oSQL As SqlHelper
    Dim SQL_STRING As String
    Dim dr As SqlDataReader
    Dim client As String
    Dim manualinvoices As Integer = 0
    Dim glentries As Integer = 0

    Private _SalesClassesList As Generic.IEnumerable(Of Object) = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Me.RadioButtonClient.Checked = True
            Me.RadGridGrossIncomeCDP.Visible = False
            'Me.TableFilterGrossIncome.Visible = False
            LoadDropDowns()
            GetCurrentPP()
        End If
        LoadChart()

    End Sub

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDO.GetAgencySetting("CLI_INC_ALERT_PCT")
        Return AgySetting
    End Function

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddPPBegin
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddPPEnd
            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()
        End With

        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With
        Session("OFFICE_AGLSG") = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            _SalesClassesList = (From SalesClass In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                 Select SalesClass.Code,
                                        SalesClass.Description).ToList

        End Using

        RadComboBoxSalesClass.DataSource = _SalesClassesList
        RadComboBoxSalesClass.DataValueField = "Code"
        RadComboBoxSalesClass.DataTextField = "Description"
        RadComboBoxSalesClass.DataBind()
        RadComboBoxSalesClass.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))


    End Sub

    Private Function GetCurrentPP() As String
        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_AGLSG") = firstPeriod
        Session("PPEND_AGLSG") = currentPeriod

    End Function

    Private DtGraphData As New DataTable
    Private Sub LoadChart()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        Dim startPP, endPP, Office, SalesClass As String
        Dim descr As String
        Dim amt, total_amt As Double
        Dim goal_pct As Decimal

        startPP = Me.ddPPBegin.SelectedValue
        endPP = Me.ddPPEnd.SelectedValue
        Office = Me.ddOffice.SelectedValue
        SalesClass = Me.RadComboBoxSalesClass.SelectedValue

        If startPP > endPP Then
            Me.ShowMessage("Please enter valid Periods.")
            Me.ddPPBegin.SelectedValue = CStr(Session("PPBEGIN_AGLSG"))
            Me.ddPPEnd.SelectedValue = CStr(Session("PPEND_AGLSG"))
            Exit Sub
        End If

        Session("PPBEGIN_AGLSG") = startPP
        Session("PPEND_AGLSG") = endPP
        Session("OFFICE_AGLSG") = Office

        If Office = "All" Then
            Office = ""
        End If
        If SalesClass = "All" Then
            SalesClass = ""
        End If

        If Me.RadioButtonClient.Checked = True Then
            client = "c"
        End If
        If Me.RadioButtonCDP.Checked = True Then
            client = "cdp"
        End If

        Try
            DtGraphData = oDO.GetGrossIncome(startPP, endPP, Office, SalesClass, 0, Session("UserCode"), client, 2, Me.CheckboxIncludeManualInvoices.Checked, Me.CheckboxIncludeGLEntries.Checked)
        Catch
            Err.Raise(Err.Number, "Class:dt_agencygoals_graph Routine:LoadChart", Err.Description)
        End Try

        CreateChart(DtGraphData, "")

    End Sub

    Private Sub CreateChart(ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "")

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataSourceList As IEnumerable = Nothing
        Dim NamePosition As Integer = 0
        Dim ValuePosition As Integer = 0
        Dim ExplodedPosition As Integer = 0
        Dim AgencySetting As Short = 0
        Dim ClientPosition As Integer = 0
        Dim DivisionPosition As Integer = 0
        Dim ProductPosition As Integer = 0

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChartGrossIncomeGraph.PlotArea.Series.Clear()
            RadHtmlChartGrossIncomeGraph.DataSource = ""

            PieSeries = New Telerik.Web.UI.PieSeries
            PieSeries.Name = "Gross Income"
            PieSeries.TooltipsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:N2}\', value)#"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.NameField = "Name"
            PieSeries.DataFieldY = "Value"
            PieSeries.ExplodeField = "Exploded"
            PieSeries.ColorField = "Color"

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.InitializePieChart(RadHtmlChartGrossIncomeGraph, Caption)

            If Me.RadioButtonClient.Checked = True Then

                client = "c"

            End If

            If Me.RadioButtonCDP.Checked = True Then

                client = "cdp"

            End If

            If Me.CheckboxIncludeManualInvoices.Checked = True Then

                manualinvoices = 1

            End If

            If Me.CheckboxIncludeGLEntries.Checked = True Then

                glentries = 1

            End If

            AgencySetting = getAgencySetting()

            If RadioButtonClient.Checked Then

                NamePosition = 1
                ValuePosition = 2
                ExplodedPosition = 3
                ClientPosition = 0

            ElseIf RadioButtonCDP.Checked Then

                NamePosition = 5
                ValuePosition = 6
                ExplodedPosition = 7
                ClientPosition = 0
                DivisionPosition = 2
                ProductPosition = 4

            End If

            DataSourceList = DataTable.AsEnumerable _
                                .Where(Function(DataRow) DataRow.Item(ValuePosition) <> "0.00") _
                                .Select(Function(DataRow) New With {.Name = DataRow.Item(NamePosition),
                                                                    .Value = DataRow.Item(ValuePosition),
                                                                    .Exploded = If(CDec(DataRow.Item(ExplodedPosition)) > AgencySetting, True, False),
                                                                    .Client = DataRow.Item(ClientPosition),
                                                                    .Division = If(DivisionPosition > 0, DataRow.Item(DivisionPosition), ""),
                                                                    .Product = If(ProductPosition > 0, DataRow.Item(ProductPosition), ""),
                                                                    .SeriesClickURL = "GrossIncomeDetail.aspx?o=" & ddOffice.SelectedValue & "&s=" & RadComboBoxSalesClass.SelectedValue & "&c=" & .Client & "&d=" & .Division & "&p=" & .Product & "&start=" & Me.ddPPBegin.SelectedValue & "&end=" & Me.ddPPEnd.SelectedValue & "&group=" & client & "&manual=" & manualinvoices & "&gl=" & glentries,
                                                                    .Color = StandardColors(DataTable.Rows.IndexOf(DataRow) Mod StandardColors.Count)}).ToList

            RadHtmlChartGrossIncomeGraph.PlotArea.Series.Add(PieSeries)

            RadHtmlChartGrossIncomeGraph.DataSource = DataSourceList
            RadHtmlChartGrossIncomeGraph.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub RadGridGrossIncomeClient_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridGrossIncomeClient.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                    Dim DivFlagColor As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                    Dim gdi As Telerik.Web.UI.GridDataItem = e.Item
                    If gdi.GetDataKeyValue("ClientSharePercent") > getAgencySetting() Then
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivFlagColor, "standard-red")
                    Else
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivFlagColor, "standard-green")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeClient_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridGrossIncomeClient.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim Office As String
            Dim SalesClass As String
            Office = Me.ddOffice.SelectedValue
            If Office = "All" Then
                Office = ""
            End If
            client = "c"
            SalesClass = Me.RadComboBoxSalesClass.SelectedValue
            If SalesClass = "All" Then
                SalesClass = ""
            End If
            Me.RadGridGrossIncomeClient.DataSource = oDO.GetGrossIncome(Me.ddPPBegin.SelectedValue, Me.ddPPEnd.SelectedValue, Office, SalesClass, 0, Session("UserCode"), client, 2, Me.CheckboxIncludeManualInvoices.Checked, Me.CheckboxIncludeGLEntries.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeCDP_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridGrossIncomeCDP.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                    Dim DivFlagColor As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                    Dim gdi As Telerik.Web.UI.GridDataItem = e.Item
                    If gdi.GetDataKeyValue("ClientSharePercent") > getAgencySetting() Then
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivFlagColor, "standard-red")
                    Else
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivFlagColor, "standard-green")
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeCDP_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridGrossIncomeCDP.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim Office As String
            Dim SalesClass As String
            Office = Me.ddOffice.SelectedValue
            If Office = "All" Then
                Office = ""
            End If
            SalesClass = Me.RadComboBoxSalesClass.SelectedValue
            If SalesClass = "All" Then
                SalesClass = ""
            End If
            client = "cdp"

            Me.RadGridGrossIncomeCDP.DataSource = oDO.GetGrossIncome(Me.ddPPBegin.SelectedValue, Me.ddPPEnd.SelectedValue, Office, SalesClass, 0, Session("UserCode"), client, 2, Me.CheckboxIncludeManualInvoices.Checked, Me.CheckboxIncludeGLEntries.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonClient_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonClient.CheckedChanged
        Try
            If RadioButtonClient.Checked = True Then
                Me.RadGridGrossIncomeCDP.Visible = False
                Me.RadGridGrossIncomeClient.Visible = True
                LoadChart()
                Me.RadGridGrossIncomeClient.Rebind()
                Me.RadGridGrossIncomeCDP.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonCDP_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonCDP.CheckedChanged
        Try
            If RadioButtonCDP.Checked = True Then
                Me.RadGridGrossIncomeCDP.Visible = True
                Me.RadGridGrossIncomeClient.Visible = False
                LoadChart()
                Me.RadGridGrossIncomeClient.Rebind()
                Me.RadGridGrossIncomeCDP.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadComboBoxSalesClass_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSalesClass.SelectedIndexChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridGrossIncomeClient.SelectedIndexChanged
        Try
            Dim cli As String
            Dim manual As Integer
            Dim gl As Integer
            If Me.RadioButtonClient.Checked = True Then
                client = "c"
            End If
            If Me.RadioButtonCDP.Checked = True Then
                client = "cdp"
            End If
            If Me.CheckboxIncludeGLEntries.Checked = True Then
                gl = 1
            End If
            If Me.CheckboxIncludeManualInvoices.Checked = True Then
                manual = 1
            End If
            If Me.RadioButtonClient.Checked = True Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridGrossIncomeClient.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        cli = gridDataItem.GetDataKeyValue("ClientCode")
                    End If
                Next
            End If
            Me.OpenWindow("", "GrossIncomeDetail.aspx?o=" & ddOffice.SelectedValue & "&s=" & RadComboBoxSalesClass.SelectedValue & "&c=" & cli & "&start=" & Me.ddPPBegin.SelectedValue & "&end=" & Me.ddPPEnd.SelectedValue & "&group=" & client & "&manual=" & manual & "&gl=" & gl)
            LoadChart()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeCDP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridGrossIncomeCDP.SelectedIndexChanged
        Try
            Dim cli As String
            Dim div As String
            Dim prd As String
            Dim manual As Integer
            Dim gl As Integer
            If Me.RadioButtonCDP.Checked = True Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridGrossIncomeCDP.MasterTableView.Items
                    If gridDataItem.Selected = True Then
                        cli = gridDataItem.GetDataKeyValue("ClientCode")
                        div = gridDataItem.GetDataKeyValue("DivisionCode")
                        prd = gridDataItem.GetDataKeyValue("ProductCode")
                    End If
                Next
            End If
            If Me.RadioButtonClient.Checked = True Then
                client = "c"
            End If
            If Me.RadioButtonCDP.Checked = True Then
                client = "cdp"
            End If
            If Me.CheckboxIncludeGLEntries.Checked = True Then
                gl = 1
            End If
            If Me.CheckboxIncludeManualInvoices.Checked = True Then
                manual = 1
            End If
            Me.OpenWindow("", "GrossIncomeDetail.aspx?o=" & ddOffice.SelectedValue & "&s=" & RadComboBoxSalesClass.SelectedValue & "&c=" & cli & "&d=" & div & "&p=" & prd & "&start=" & Me.ddPPBegin.SelectedValue & "&end=" & Me.ddPPEnd.SelectedValue & "&group=" & client & "&manual=" & manual & "&gl=" & gl)
            LoadChart()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckboxIncludeGLEntries_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxIncludeGLEntries.CheckedChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckboxIncludeManualInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxIncludeManualInvoices.CheckedChanged
        Try
            LoadChart()
            Me.RadGridGrossIncomeClient.Rebind()
            Me.RadGridGrossIncomeCDP.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            With Me.ImageButtonExportExcel.Attributes

                Dim qs As New AdvantageFramework.Web.QueryString()
                With qs

                    .Page = "dtp_grossincome.aspx"
                    .OfficeCode = Me.ddOffice.SelectedValue
                    .SalesClassCode = Me.RadComboBoxSalesClass.SelectedValue
                    .Add("speriod", Me.ddPPBegin.SelectedValue)
                    .Add("eperiod", Me.ddPPEnd.SelectedValue)
                    .Add("export", 1)
                    If Me.RadioButtonClient.Checked = True Then
                        .Add("ctype", "c")
                    ElseIf Me.RadioButtonCDP.Checked = True Then
                        .Add("ctype", "cdp")
                    End If
                    If Me.CheckboxIncludeGLEntries.Checked = True Then
                        .Add("gl", 1)
                    End If
                    If Me.CheckboxIncludeManualInvoices.Checked = True Then
                        .Add("manual", 1)
                    End If
                    .Add("my", 1)

                End With

                .Remove("onclick")
                .Add("onclick", "window.open('" & qs.ToString(True) & "', 'PopLookup','screenX=100,left=100,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageButtonPrint_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonPrint.Click
        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "dtp_grossincome.aspx"
            .OfficeCode = Me.ddOffice.SelectedValue
            .SalesClassCode = Me.RadComboBoxSalesClass.SelectedValue
            .Add("speriod", Me.ddPPBegin.SelectedValue)
            .Add("eperiod", Me.ddPPEnd.SelectedValue)
            If Me.RadioButtonClient.Checked = True Then
                .Add("ctype", "c")
            ElseIf Me.RadioButtonCDP.Checked = True Then
                .Add("ctype", "cdp")
            End If
            If Me.CheckboxIncludeGLEntries.Checked = True Then
                .Add("gl", 1)
            End If
            If Me.CheckboxIncludeManualInvoices.Checked = True Then
                .Add("manual", 1)
            End If
            .Add("my", 1)

        End With

        Me.OpenFloatingWindow("My Gross Income", qs.ToString(True))

        LoadChart()
        Me.RadGridGrossIncomeClient.Rebind()
        Me.RadGridGrossIncomeCDP.Rebind()

    End Sub

    Private Sub ImageButtonRefresh_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefresh.Click

        LoadChart()
        Me.RadGridGrossIncomeClient.Rebind()
        Me.RadGridGrossIncomeCDP.Rebind()

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_MyGrossIncome
                .UserCode = Session("UserCode")
                .Name = "Gross Income (My)"
                .Description = "Gross Income (My)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
