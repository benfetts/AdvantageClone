Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports Telerik.Charting.Styles
Imports Telerik.Charting
Imports System.Collections.Generic

Partial Public Class GrossIncomeDetail
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function

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

#Region " Page Functions "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client, False))

        Try

            RadGridGrossIncome.Columns.FindByUniqueName("GridTemplateColumnDocuments").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Request.QueryString("o") <> "" Then
                office = Request.QueryString("o")
            End If
            If Request.QueryString("s") <> "" Then
                salesclass = Request.QueryString("s")
            End If
            If Request.QueryString("c") <> "" Then
                client = Request.QueryString("c")
            End If
            If Request.QueryString("d") <> "" Then
                division = Request.QueryString("d")
            End If
            If Request.QueryString("p") <> "" Then
                product = Request.QueryString("p")
            End If
            If Request.QueryString("start") <> "" Then
                startperiod = Request.QueryString("start")
            End If
            If Request.QueryString("end") <> "" Then
                endperiod = Request.QueryString("end")
            End If
            If Request.QueryString("type") <> "" Then
                type = Request.QueryString("type")
            End If
            If Request.QueryString("group") <> "" Then
                group = Request.QueryString("group")
            End If
            If Request.QueryString("manual") <> "" Then
                manualinvoices = Request.QueryString("manual")
            End If
            If Request.QueryString("gl") <> "" Then
                glentries = Request.QueryString("gl")
            End If
            If office = "All" Then
                office = ""
            End If
            If salesclass = "All" Then
                salesclass = ""
            End If
            LoadChart()
            If Not Me.IsPostBack Then

            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            With qs

                .Page = "dtp_grossincomedetail.aspx"
                .OfficeCode = Request.QueryString("o")
                .SalesClassCode = Request.QueryString("s")
                .ClientCode = Request.QueryString("c")
                If Request.QueryString("d") <> "" Then
                    .DivisionCode = Request.QueryString("d")
                Else
                    .DivisionCode = ""
                End If
                If Request.QueryString("p") <> "" Then
                    .ProductCode = Request.QueryString("p")
                Else
                    .ProductCode = ""
                End If
                .Add("speriod", Request.QueryString("start"))
                .Add("eperiod", Request.QueryString("end"))
                .Add("type", Request.QueryString("type"))
                .Add("group", Request.QueryString("group"))
                .Add("manual", Request.QueryString("manual"))
                .Add("gl", Request.QueryString("gl"))
                .Add("export", 1)

            End With
            Me.RadToolbarButtonExport.Attributes.Add("onclick", "window.open('" & qs.ToString(True) & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1200,height=700,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " RadGrid Events "

    Private Sub RadGridGrossIncome_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridGrossIncome.ItemDataBound
        Try
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim di As GridDataItem = e.Item
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

                Dim str3 As String = e.Item.Cells(7).Text
                If IsDBNull(di.GetDataKeyValue("JobNumber")) = False Then
                    If di.GetDataKeyValue("JobNumber") <> 0 Then
                        Me.RadGridGrossIncome.MasterTableView.GetColumn("column34").Display = True
                        e.Item.Cells(7).Text = di.GetDataKeyValue("JobNumber").ToString.PadLeft(6, "0") & "/" & di.GetDataKeyValue("ComponentNumber").ToString.PadLeft(3, "0") & " - " & di.GetDataKeyValue("ComponentDescription")
                    Else
                        e.Item.Cells(7).Text = ""
                    End If
                End If
                If IsDBNull(di.GetDataKeyValue("OrderNumber")) = False Then
                    If di.GetDataKeyValue("OrderNumber") <> 0 Then
                        Me.RadGridGrossIncome.MasterTableView.GetColumn("column39").Display = True
                        e.Item.Cells(8).Text = di.GetDataKeyValue("OrderNumber") & "/" & di.GetDataKeyValue("LineNumber")
                    Else
                        e.Item.Cells(8).Text = ""
                    End If
                End If

                Dim DocumentsLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LinkButtonDocuments"), LinkButton)
                Dim DocumentsDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDocuments")
                If Not DocumentsLinkButton Is Nothing Then

                    If CType(e.Item.DataItem("AttachmentCount"), Integer) > 0 Then

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Documents_List2.aspx"
                            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice
                            .InvoiceNumber = CurrentGridRow.GetDataKeyValue("InvoiceNumber")
                            .InvoiceSequenceNumber = CurrentGridRow.GetDataKeyValue("InvoiceSequence")

                        End With

                        With DocumentsLinkButton

                            .Attributes.Remove("onclick")
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("Invoice Documents", qs.ToString(True)))
                            .ToolTip = e.Item.DataItem("AttachmentCount") & " attachments"

                        End With

                    Else

                        With DocumentsLinkButton

                            .Attributes.Remove("onclick")
                            .Enabled = False
                            .ToolTip = ""

                        End With
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsDiv)

                    End If

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

    Private Sub RadGridGrossIncome_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridGrossIncome.NeedDataSource
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

#End Region

#Region " Data Functions "

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

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        Try

            RadHtmlChartGrossIncome.PlotArea.Series.Clear()

            PieSeries = New Telerik.Web.UI.PieSeries
            PieSeries.Name = "Gross Income"
            PieSeries.TooltipsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:N2}\', value)#"
            PieSeries.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd
            PieSeries.LabelsAppearance.ClientTemplate = "#=dataItem.Name#, #= kendo.format(\'{0:P2}\', percentage)#"
            PieSeries.NameField = "Name"
            PieSeries.DataFieldY = "Value"
            PieSeries.ColorField = "Color"

            Dashboard = New cDashboard(_Session.ConnectionString, _Session.UserCode)

            Caption = DataTable.Rows(0).Item(1)

            Dashboard.InitializePieChart(RadHtmlChartGrossIncome, Caption)

            If group = "c" Then

                NamePosition = 3
                ValuePosition = 2

            ElseIf group = "cdp" Then

                NamePosition = 7
                ValuePosition = 6

            End If

            DataSourceList = DataTable.AsEnumerable() _
                                .Where(Function(DataRow) DataRow.Item(ValuePosition).ToString <> "0.00") _
                                .Select(Function(DataRow) New With {.Name = DataRow.Item(NamePosition),
                                                                    .Value = DataRow.Item(ValuePosition),
                                                                    .SeriesClickURL = "GrossIncomeDetail.aspx?o=" & office & "&s=" & salesclass & "&c=" & client & "&d=" & division & "&p=" & product & "&start=" & startperiod & "&end=" & endperiod & "&type=" & DataRow.Item(NamePosition) & "&group=" & group & "&manual=" & manualinvoices & "&gl=" & glentries,
                                                                    .Color = StandardColors(DataTable.Rows.IndexOf(DataRow) Mod StandardColors.Count)}).ToList

            RadHtmlChartGrossIncome.PlotArea.Series.Add(PieSeries)

            RadHtmlChartGrossIncome.DataSource = DataSourceList
            RadHtmlChartGrossIncome.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function cleanString(ByVal str As String) As String
        str = str.Replace("&", " and ")
        str = str.Replace("n's", "ns")
        str = str.Replace("12:00:00 AM", "")
        Return str
    End Function

#End Region

#Region " Controls "

    Private Sub RadToolbarGrossIncomePrint_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarGrossIncomePrint.ButtonClick
        Try
            Dim str As String
            Select Case e.Item.Value
                Case "Print"
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    With qs

                        .Page = "dtp_grossincomedetail.aspx"
                        .OfficeCode = Request.QueryString("o")
                        .SalesClassCode = Request.QueryString("s")
                        .ClientCode = Request.QueryString("c")
                        If Request.QueryString("d") <> "" Then
                            .DivisionCode = Request.QueryString("d")
                        Else
                            .DivisionCode = ""
                        End If
                        If Request.QueryString("p") <> "" Then
                            .ProductCode = Request.QueryString("p")
                        Else
                            .ProductCode = ""
                        End If
                        .Add("speriod", Request.QueryString("start"))
                        .Add("eperiod", Request.QueryString("end"))
                        .Add("type", Request.QueryString("type"))
                        .Add("group", Request.QueryString("group"))
                        .Add("manual", Request.QueryString("manual"))
                        .Add("gl", Request.QueryString("gl"))

                    End With
                    Me.OpenWindow("Gross Income", qs.ToString(True))
                    'Case "ExportExcel"
                    '    Dim qs As New AdvantageFramework.Web.QueryString()
                    '    With qs

                    '        .Page = "dtp_grossincomedetail.aspx"
                    '        .OfficeCode = Request.QueryString("o")
                    '        .ClCode = Request.QueryString("c")
                    '        If Request.QueryString("d") <> "" Then
                    '            .DivCode = Request.QueryString("d")
                    '        Else
                    '            .DivCode = ""
                    '        End If
                    '        If Request.QueryString("p") <> "" Then
                    '            .PrdCode = Request.QueryString("p")
                    '        Else
                    '            .PrdCode = ""
                    '        End If
                    '        .Add("speriod", Request.QueryString("start"))
                    '        .Add("eperiod", Request.QueryString("end"))
                    '        .Add("type", Request.QueryString("type"))
                    '        .Add("group", Request.QueryString("group"))
                    '        .Add("export", 1)

                    '    End With
                    '    Me.OpenWindow("Gross Income", qs.ToString(True))
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Functions "



#End Region






End Class
