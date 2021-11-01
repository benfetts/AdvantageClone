Imports System.Collections.Generic
Imports System.Text
Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure

Public Class dtp_grossincome
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PageMode

        ServiceFee = 1
        MyServiceFee = 2

    End Enum

#End Region

#Region " Variables "

    Public CurrentPageMode As PageMode = PageMode.ServiceFee

    Private StartPeriod As String = ""
    Private EndPeriod As String = ""
    Private ClientType As String = ""
    Private Office As String = ""
    Private SalesClass As String = ""
    Private ManualInvoices As Integer = 0
    Private GLEntries As Integer = 0
    Private Export As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing
    Private sfgraph As AdvantageFramework.Reporting.Database.Classes.ServiceFee

#End Region

#Region " Properties "



#End Region

    Private IsMy As Boolean = False

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me.StartPeriod = qs.Get("speriod")
        Me.EndPeriod = qs.Get("eperiod")
        Me.ClientType = qs.Get("ctype")
        Me.Office = qs.OfficeCode
        Me.SalesClass = qs.SalesClassCode
        Me.ManualInvoices = qs.Get("manual")
        Me.GLEntries = qs.Get("gl")
        Me.Export = qs.Get("export")

        If Me.ClientType = "c" Then
            Me.RadGridGrossIncomeClient.Visible = True
            Me.RadGridGrossIncomeCDP.Visible = False
        End If
        If Me.ClientType = "cdp" Then
            Me.RadGridGrossIncomeClient.Visible = False
            Me.RadGridGrossIncomeCDP.Visible = True
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Request.QueryString("my") Is Nothing Then
                If CType(Request.QueryString("my"), Integer) = 1 Then
                    IsMy = True
                Else
                    IsMy = False
                End If
            End If
        Catch ex As Exception
            IsMy = False
        End Try
        If IsMy = True Then
            Me.Page.Title = "My Gross Income"
            Me.lblTitle.Text = "My Gross Income"
        Else
            Me.Page.Title = "Gross Income"
            Me.lblTitle.Text = "Gross Income"
        End If
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                    LoadChart()
                End If
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private DtGraphData As New DataTable
    Private Sub LoadChart()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        Dim startPP, endPP As String
        Dim descr As String
        Dim amt, total_amt As Double
        Dim goal_pct As Decimal

        startPP = StartPeriod
        endPP = EndPeriod

        Session("PPBEGIN_AGLSG") = startPP
        Session("PPEND_AGLSG") = endPP
        Session("OFFICE_AGLSG") = Office

        If Office = "All" Then
            Office = ""
        End If

        If SalesClass = "All" Then
            SalesClass = ""
        End If

        Try
            If IsMy = True Then
                DtGraphData = oDO.GetGrossIncome(startPP, endPP, Office, SalesClass, 0, Session("UserCode"), ClientType, 2, Me.ManualInvoices, Me.GLEntries)
            Else
                DtGraphData = oDO.GetGrossIncome(startPP, endPP, Office, SalesClass, 0, Session("UserCode"), ClientType, 0, Me.ManualInvoices, Me.GLEntries)
            End If
        Catch
            Err.Raise(Err.Number, "Class:dt_agencygoals_graph Routine:LoadChart", Err.Description)
        End Try

        CreateChart(DtGraphData, "")

    End Sub
    Public Sub CreateChart(ByVal DataTable As System.Data.DataTable, Optional ByVal Caption As String = "")

        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataSourceList As IEnumerable = Nothing
        Dim ValuePosition As Integer = 0
        Dim NamePosition As Integer = 0
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
            PieSeries.LabelsAppearance.ClientTemplate = "#if(dataItem.ShowLabel){# #=dataItem.Name#, #= kendo.format(\'{0:P2}\', percentage)# #}#"
            PieSeries.NameField = "Name"
            PieSeries.DataFieldY = "Value"
            PieSeries.ExplodeField = "Exploded"
            PieSeries.ColorField = "Color"

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Dashboard.InitializePieChart(RadHtmlChartGrossIncomeGraph, Caption)

            AgencySetting = getAgencySetting()

            If ClientType = "c" Then

                ValuePosition = 2
                NamePosition = 1
                ExplodedPosition = 3

            ElseIf ClientType = "cdp" Then

                ValuePosition = 6
                NamePosition = 5
                ExplodedPosition = 7
                ClientPosition = 0
                DivisionPosition = 2
                ProductPosition = 4

            End If

            Dim MaxLabels As Integer = 45
            Dim ListCount As Integer = 0

            DataSourceList = DataTable.AsEnumerable() _
                                .Where(Function(DataRow) DataRow.Item(ValuePosition).ToString <> "0.00") _
                                .Select(Function(DataRow) New With {.Name = DataRow.Item(NamePosition),
                                                                    .Value = DataRow.Item(ValuePosition),
                                                                    .Exploded = If(DataRow.Item(ExplodedPosition) > AgencySetting, True, False),
                                                                    .Client = DataRow.Item(ClientPosition),
                                                                    .Division = If(DivisionPosition > 0, DataRow.Item(DivisionPosition), ""),
                                                                    .Product = If(ProductPosition > 0, DataRow.Item(ProductPosition), ""),
                                                                    .ShowLabel = True,
                                                                    .Color = StandardColors(DataTable.Rows.IndexOf(DataRow) Mod StandardColors.Count)}).ToList

            ListCount = (From Item In DataSourceList Select Item).Count()

            If ListCount > MaxLabels Then

                Dim Modulus As Integer = 0

                Modulus = Math.Round(ListCount / MaxLabels, 0, MidpointRounding.ToEven)

                For I = 0 To ListCount - 1

                    DataSourceList(I).ShowLabel = ((I Mod Modulus) = 0)

                Next

            End If

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
    Private AgencyPerc As Int16 = 0

    Private Sub RadGridGrossIncomeClient_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles RadGridGrossIncomeClient.BiffExporting
        Try
            Dim col As Column = e.ExportStructure.Tables(0).Columns(1)
            col.Width = 50
            col = e.ExportStructure.Tables(0).Columns(2)
            col.Width = 50
            col = e.ExportStructure.Tables(0).Columns(3)
            col.Width = 30

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeClient_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridGrossIncomeClient.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case GridItemType.Header

                    AgencyPerc = getAgencySetting()

                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                    Dim gdi As Telerik.Web.UI.GridDataItem = e.Item
                    Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

                    If gdi.GetDataKeyValue("ClientSharePercent") > AgencyPerc Then

                        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                    Else

                        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Green)

                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeClient_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridGrossIncomeClient.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim DataTable As System.Data.DataTable = Nothing

            If Office = "All" Then
                Office = ""
            End If
            If SalesClass = "All" Then
                SalesClass = ""
            End If
            If IsMy = True Then
                DataTable = oDO.GetGrossIncome(StartPeriod, EndPeriod, Office, SalesClass, 0, Session("UserCode"), ClientType, 2, Me.ManualInvoices, Me.GLEntries)
            Else
                DataTable = oDO.GetGrossIncome(StartPeriod, EndPeriod, Office, SalesClass, 0, Session("UserCode"), ClientType, 0, Me.ManualInvoices, Me.GLEntries)
            End If
            DataTable.Columns.Add("ClientSharePercentDisplay", GetType(System.Decimal))
            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()
                DataRow("ClientSharePercentDisplay") = CDec(DataRow("ClientSharePercent")) / 100
            Next
            Me.RadGridGrossIncomeClient.DataSource = DataTable
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridGrossIncomeCDP_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles RadGridGrossIncomeCDP.BiffExporting
        Try
            Dim col As Column = e.ExportStructure.Tables(0).Columns(1)
            col.Width = 50
            col = e.ExportStructure.Tables(0).Columns(2)
            col.Width = 50
            col = e.ExportStructure.Tables(0).Columns(3)
            col.Width = 30

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeCDP_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridGrossIncomeCDP.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case GridItemType.Header

                    AgencyPerc = getAgencySetting()

                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                    Dim gdi As Telerik.Web.UI.GridDataItem = e.Item
                    Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

                    If gdi.GetDataKeyValue("ClientSharePercent") > AgencyPerc Then

                        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Red)

                    Else

                        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(FlagColorDiv, AdvantageFramework.Web.Presentation.Controls.Methods.StandardColor.Green)

                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncomeCDP_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridGrossIncomeCDP.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim DataTable As System.Data.DataTable = Nothing

            If Office = "All" Then
                Office = ""
            End If
            If SalesClass = "All" Then
                SalesClass = ""
            End If
            If IsMy = True Then
                DataTable = oDO.GetGrossIncome(StartPeriod, EndPeriod, Office, SalesClass, 0, Session("UserCode"), ClientType, 2, Me.ManualInvoices, Me.GLEntries)
            Else
                DataTable = oDO.GetGrossIncome(StartPeriod, EndPeriod, Office, SalesClass, 0, Session("UserCode"), ClientType, 0, Me.ManualInvoices, Me.GLEntries)
            End If
            DataTable.Columns.Add("ClientSharePercentDisplay", GetType(System.Decimal))
            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()
                DataRow("ClientSharePercentDisplay") = CDec(DataRow("ClientSharePercent")) / 100
            Next
            Me.RadGridGrossIncomeCDP.DataSource = DataTable
        Catch ex As Exception

        End Try
    End Sub

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDO.GetAgencySetting("CLI_INC_ALERT_PCT")
        Return AgySetting
    End Function

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            Dim str As String = ""
            If Me.Export = 1 Then
                If Me.ClientType = "c" Then
                    str = "GrossIncome" & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridGrossIncomeClient, str, True, False)
                    RadGridGrossIncomeClient.MasterTableView.ExportToExcel()
                End If
                If Me.ClientType = "cdp" Then
                    str = "GrossIncome" & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)
                    AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridGrossIncomeCDP, str, True, False)
                    RadGridGrossIncomeCDP.MasterTableView.ExportToExcel()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class