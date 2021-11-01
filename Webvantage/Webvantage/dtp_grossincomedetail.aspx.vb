Imports System.Text
Imports Telerik.Web.UI

Public Class dtp_grossincomedetail
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

    Private client As String = ""
    Private division As String = ""
    Private product As String = ""
    Private startperiod As String = ""
    Private endperiod As String = ""
    Private office As String = ""
    Private salesclass As String = ""
    Private type As String = ""
    Private group As String = ""
    Private manualinvoices As Integer = 0
    Private glentries As Integer = 0
    Private DtGraphData As New DataTable
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
    Private sf As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ServiceFee) = Nothing

#End Region

#Region " Properties "



#End Region

    Private IsMy As Boolean = False

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            Me.startperiod = qs.Get("speriod")
            Me.endperiod = qs.Get("eperiod")
            Me.office = qs.OfficeCode
            Me.salesclass = qs.SalesClassCode
            Me.client = qs.ClientCode
            Me.division = qs.DivisionCode
            Me.product = qs.ProductCode
            Me.type = qs.Get("type")
            Me.group = qs.Get("group")
            If qs.Get("manual") <> "" Then
                Me.manualinvoices = qs.Get("manual")
            End If
            If qs.Get("gl") <> "" Then
                Me.glentries = qs.Get("gl")
            End If
            If office = "All" Then
                office = ""
            End If
            If salesclass = "All" Then
                salesclass = ""
            End If
            LoadChart()
        Catch ex As Exception
            IsMy = False
        End Try

    End Sub

    Private Sub LoadChart()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Try
            If group = "c" Then
                DtGraphData = oDO.GetGrossIncome(startperiod, endperiod, office, salesclass, 1, Session("UserCode"), group, 0, manualinvoices, glentries)
                Dim dv As DataView = DtGraphData.DefaultView
                dv.RowFilter = "ClientCode = '" & client & "'"
                DtGraphData = dv.ToTable
            End If
            If group = "cdp" Then
                DtGraphData = oDO.GetGrossIncome(startperiod, endperiod, office, salesclass, 1, Session("UserCode"), group, 0, manualinvoices, glentries)
                Dim dv As DataView = DtGraphData.DefaultView
                dv.RowFilter = "ClientCode = '" & client & "' AND DivisionCode = '" & division & "' AND ProductCode = '" & product & "'"
                DtGraphData = dv.ToTable
            End If
        Catch
            Err.Raise(Err.Number, "Class:dt_grossincome_graph Routine:LoadChart", Err.Description)
        End Try

        CreateChart(DtGraphData)

    End Sub

    Private Sub CreateChart(ByVal DataTable As System.Data.DataTable)

        'objects
        Dim Dashboard As Webvantage.cDashboard = Nothing
        Dim PieSeries As Telerik.Web.UI.PieSeries = Nothing
        Dim DataSourceList As IEnumerable = Nothing
        Dim NamePosition As Integer = 0
        Dim ValuePosition As Integer = 0
        Dim Caption As String = ""

        Try

            RadHtmlChartGrossIncomeDetail.PlotArea.Series.Clear()

            PieSeries = New Telerik.Web.UI.PieSeries
            PieSeries.Name = "Gross Income"
            PieSeries.TooltipsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:N2}\', value)#"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.NameField = "Name"
            PieSeries.DataFieldY = "Value"

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Caption = DataTable.Rows(0).Item(1)

            Dashboard.InitializePieChart(RadHtmlChartGrossIncomeDetail, Caption)

            If group = "c" Then

                NamePosition = 3
                ValuePosition = 2

            ElseIf group = "cdp" Then

                NamePosition = 7
                ValuePosition = 6

            End If

            DataSourceList = DataTable.AsEnumerable() _
                                .Where(Function(DataRow) DataRow.Item(ValuePosition).ToString <> "0.00") _
                                .Select(Function(DataRow) New With {.Name = DataRow.Item(NamePosition), _
                                                                    .Value = DataRow.Item(ValuePosition), _
                                                                    .SeriesClickURL = "GrossIncomeDetail.aspx?o=" & office & "&s=" & salesclass & "&c=" & client & "&d=" & division & "&p=" & product & "&start=" & startperiod & "&end=" & endperiod & "&type=" & DataRow.Item(NamePosition) & "&group=" & group & "&manual=" & manualinvoices & "&gl=" & glentries}).ToList

            RadHtmlChartGrossIncomeDetail.PlotArea.Series.Add(PieSeries)

            RadHtmlChartGrossIncomeDetail.DataSource = DataSourceList
            RadHtmlChartGrossIncomeDetail.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function

    Private Function getAgencySetting() As Int16
        Dim AgySetting As Int16
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDO.GetAgencySetting("CLI_INC_ALERT_PCT")
        Return AgySetting
    End Function

    Private Sub RadGridGrossIncome_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridGrossIncome.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim di As GridDataItem = e.Item

                Dim str3 As String = e.Item.Cells(7).Text
                If di.GetDataKeyValue("JobNumber") <> 0 Then
                    Me.RadGridGrossIncome.MasterTableView.GetColumn("column34").Display = True
                    e.Item.Cells(7).Text = di.GetDataKeyValue("JobNumber").ToString.PadLeft(6, "0") & "/" & di.GetDataKeyValue("ComponentNumber").ToString.PadLeft(3, "0") & " - " & di.GetDataKeyValue("ComponentDescription")
                Else
                    Me.RadGridGrossIncome.MasterTableView.GetColumn("column34").Display = False
                End If
                If di.GetDataKeyValue("OrderNumber") <> 0 Then
                    Me.RadGridGrossIncome.MasterTableView.GetColumn("column39").Display = True
                    e.Item.Cells(8).Text = di.GetDataKeyValue("OrderNumber") & "/" & di.GetDataKeyValue("LineNumber")
                Else
                    Me.RadGridGrossIncome.MasterTableView.GetColumn("column39").Display = False
                End If


            ElseIf e.Item.ItemType = GridItemType.Footer Then
                'Dim fee As Decimal
                'Dim actual As Decimal

                'e.Item.Font.Bold = True

                'Dim GrpFtr As Telerik.Web.UI.GridFooterItem
                'GrpFtr = e.Item

                'If Not GrpFtr Is Nothing Then

                '    If GrpFtr("column36").Text <> "" Then
                '        fee = CDec(GrpFtr("column36").Text)
                '    End If
                '    If GrpFtr("column35").Text <> "" Then
                '        actual = CDec(GrpFtr("column35").Text)
                '    End If

                '    If fee > 0 Then
                '        GrpFtr("taskcolumn").Text = String.Format("{0:#,##0.00}", (fee - actual))
                '    End If

                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridGrossIncome_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridGrossIncome.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim dt As DataTable
            If group = "c" Then
                dt = oDO.GetGrossIncome(startperiod, endperiod, office, salesclass, 2, Session("UserCode"), group, 0, manualinvoices, glentries)
                If type = "" Then
                    If dt.Rows.Count > 0 Then
                        type = dt.Rows(0)("Type").ToString
                    End If
                End If
                Dim dv As DataView = dt.DefaultView
                dv.RowFilter = "ClientCode = '" & client & "' AND Type = '" & type & "'"
                Me.RadGridGrossIncome.DataSource = dv.ToTable
            End If
            If group = "cdp" Then
                dt = oDO.GetGrossIncome(startperiod, endperiod, office, salesclass, 2, Session("UserCode"), group, 0, manualinvoices, glentries)
                If type = "" Then
                    If dt.Rows.Count > 0 Then
                        type = dt.Rows(0)("Type").ToString
                    End If
                End If
                Dim dv As DataView = dt.DefaultView
                dv.RowFilter = "ClientCode = '" & client & "' AND DivisionCode = '" & division & "' AND ProductCode = '" & product & "' AND Type = '" & type & "'"
                Me.RadGridGrossIncome.DataSource = dv.ToTable
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Try
            Dim str As String
            If Request.QueryString("Export") = 1 Then
                str = "GrossIncome" & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridGrossIncome, str)
                RadGridGrossIncome.MasterTableView.ExportToExcel()
            End If
           
        Catch ex As Exception

        End Try
    End Sub
End Class