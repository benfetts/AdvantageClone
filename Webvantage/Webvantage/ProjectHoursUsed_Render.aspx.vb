Imports Telerik.Web.UI
Imports Webvantage.cGlobals.Globals

Public Class ProjectHoursUsed_Render
    Inherits Webvantage.BaseChildPage

    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblClient As System.Web.UI.WebControls.Label

#Region " Variables and Properties "

    Public OfficeCode As String = ""
    Public DeptCode As String = ""
    Public EmpCode As String = ""
    Public month As String = ""
    Public year As String = ""
    Public dashboard As String = ""
    Public include As Integer = 0
    Public period As Integer = 0
    Public yearValue As String = ""
    Dim client As String = ""
    Dim product As String = ""
    Dim division As String = ""
    Dim job As Integer
    Dim comp As Integer

    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Not Session("ConnString") Is Nothing Then
                If Session("ConnString") <> "" Then
                Else
                    'Page.RegisterStartupScript("CloseMe", CloseScript)
                End If
                If Request.QueryString("From") = "projecthours" Then
                    ' Me.lblTitle.Text = "Productivity Summary - Goal vs. Actual"
                    Me.pnlHours.Visible = True
                End If
            Else
                'Page.RegisterStartupScript("CloseMe", CloseScript)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                If Request.QueryString("From") = "projecthours" Then
                    str = "PROJECT_HOURS_" & AdvantageFramework.StringUtilities.GUID_Date(False, False, False, False)
                    If Request.QueryString("group") = "0" Then
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridHoursNoGroup, str)
                        RadGridHoursNoGroup.MasterTableView.ExportToExcel()
                    Else
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridHours, str)
                        RadGridHours.MasterTableView.ExportToExcel()
                    End If
                    
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridHours_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridHours.ItemDataBound
        Try
            RadGridHours.MasterTableView.Caption = "<strong>Project Hours Report</strong>"
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType.Item = GridItemType.AlternatingItem Then
                For i As Integer = 0 To e.Item.Cells.Count - 1
                    If IsNumeric(e.Item.Cells(i).Text) = True Then
                        e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDbl(e.Item.Cells(i).Text))
                    End If
                Next
                'e.Item.Cells(1).Text = e.Item.Cells(1).Text.PadLeft(6, "0")
                'e.Item.Cells(4).Text = e.Item.Cells(4).Text.PadLeft(2, "0")
               
            ElseIf e.Item.ItemType = GridItemType.GroupFooter Then
                Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                GrpFtr = e.Item
                If Not GrpFtr Is Nothing Then

                    GrpFtr("column1").Text = "Total:"

                End If
            ElseIf e.Item.ItemType = GridItemType.Footer Then
                Dim Ftr As Telerik.Web.UI.GridFooterItem
                Ftr = e.Item

                If Not Ftr Is Nothing Then
                    Ftr("column1").Text = "Grand Total:"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridHoursNoGroup_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridHoursNoGroup.ItemDataBound
        Try
            Try
                RadGridHoursNoGroup.MasterTableView.Caption = "<strong>Project Hours Report</strong>"
                If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType.Item = GridItemType.AlternatingItem Then
                    For i As Integer = 0 To e.Item.Cells.Count - 1
                        If IsNumeric(e.Item.Cells(i).Text) = True Then
                            e.Item.Cells(i).Text = String.Format("{0:#,##0.00}", CDbl(e.Item.Cells(i).Text))
                        End If
                    Next
                    e.Item.Cells(0).Text = e.Item.Cells(0).Text.PadLeft(6, "0")
                    e.Item.Cells(3).Text = e.Item.Cells(3).Text.PadLeft(2, "0")

                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridHoursNoGroup_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridHoursNoGroup.NeedDataSource
        Try
            Dim oReports As New cReports(Session("ConnString"))
            Dim dt As DataTable
            Dim sort As String = Request.QueryString("sort")
            Dim openonly As Integer = CInt(Request.QueryString("openonly"))
            Dim startdate As String = Request.QueryString("StartDate")
            Dim enddate As String = Request.QueryString("EndDate")
            Dim MainDView As DataView

            If startdate = "" And enddate = "" Then
                dt = oReports.GetProjectHoursUsed(Session("UserCode"), "01/01/1950", "01/01/2050", sort, openonly, 0)
            Else
                dt = oReports.GetProjectHoursUsed(Session("UserCode"), wvCDate(startdate).ToShortDateString, wvCDate(enddate).ToShortDateString, sort, openonly, 0)
            End If
            MainDView = New DataView(dt)
            MainDView.RowFilter = Session("rptProjectHoursStrFilter")
            dt = MainDView.ToTable
            Me.RadGridHoursNoGroup.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridHours_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridHours.NeedDataSource
        Try
            Dim oReports As New cReports(Session("ConnString"))
            Dim dt As DataTable
            Dim sort As String = Request.QueryString("sort")
            Dim openonly As Integer = CInt(Request.QueryString("openonly"))
            Dim startdate As String = Request.QueryString("StartDate")
            Dim enddate As String = Request.QueryString("EndDate")
            Dim MainDView As DataView
            
            If startdate = "" And enddate = "" Then
                dt = oReports.GetProjectHoursUsed(Session("UserCode"), "01/01/1950", "01/01/2050", sort, openonly, 1)
            Else
                dt = oReports.GetProjectHoursUsed(Session("UserCode"), wvCDate(startdate).ToShortDateString, wvCDate(enddate).ToShortDateString, sort, openonly, 1)
            End If
            MainDView = New DataView(dt)
            MainDView.RowFilter = Session("rptProjectHoursStrFilter")
            dt = MainDView.ToTable

            SetGridSort()

            Me.RadGridHours.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridHours_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridHours.PreRender
        Try
            If Request.QueryString("group") = "0" Then
                If CBool(Request.Params("chkJob")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(0).Visible = False
                End If
                If CBool(Request.Params("chkJobDesc")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(1).Visible = False
                End If
                If CBool(Request.Params("chkComponent")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(2).Visible = False
                End If
                If CBool(Request.Params("chkJobCompDesc")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(3).Visible = False
                End If
                If CBool(Request.Params("chkClient")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(4).Visible = False
                End If
                If CBool(Request.Params("chkClientName")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(5).Visible = False
                End If
                If CBool(Request.Params("chkDivision")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(6).Visible = False
                End If
                If CBool(Request.Params("chkDivisionName")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(7).Visible = False
                End If
                If CBool(Request.Params("chkProduct")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(8).Visible = False
                End If
                If CBool(Request.Params("chkProductName")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(9).Visible = False
                End If
                If CBool(Request.Params("chkCampaign")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(10).Visible = False
                End If
                If CBool(Request.Params("chkCampaignName")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(11).Visible = False
                End If
                If CBool(Request.Params("chkEmp")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(13).Visible = False
                End If
                If CBool(Request.Params("chkHoursPosted")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(14).Visible = False
                End If
                If CBool(Request.Params("chkHoursAssigned")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(15).Visible = False
                End If
                If CBool(Request.Params("chkTotalHoursPosted")) = False Then
                    Me.RadGridHoursNoGroup.MasterTableView.Columns(16).Visible = False
                End If
                Me.RadGridHoursNoGroup.MasterTableView.Columns(12).Visible = False
            Else
                If CBool(Request.Params("chkJob")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(1).Visible = False
                End If
                If CBool(Request.Params("chkJobDesc")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(2).Visible = False
                End If
                If CBool(Request.Params("chkComponent")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(3).Visible = False
                End If
                If CBool(Request.Params("chkJobCompDesc")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(4).Visible = False
                End If
                If CBool(Request.Params("chkClient")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(5).Visible = False
                End If
                If CBool(Request.Params("chkClientName")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(6).Visible = False
                End If
                If CBool(Request.Params("chkDivision")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(7).Visible = False
                End If
                If CBool(Request.Params("chkDivisionName")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(8).Visible = False
                End If
                If CBool(Request.Params("chkProduct")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(9).Visible = False
                End If
                If CBool(Request.Params("chkProductName")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(10).Visible = False
                End If
                If CBool(Request.Params("chkCampaign")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(11).Visible = False
                End If
                If CBool(Request.Params("chkCampaignName")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(12).Visible = False
                End If
                If CBool(Request.Params("chkEmp")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(14).Visible = False
                End If
                If CBool(Request.Params("chkHoursPosted")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(15).Visible = False
                End If
                If CBool(Request.Params("chkHoursAssigned")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(16).Visible = False
                End If
                If CBool(Request.Params("chkTotalHoursPosted")) = False Then
                    Me.RadGridHours.MasterTableView.Columns(17).Visible = False
                End If
                Me.RadGridHours.MasterTableView.Columns(13).Visible = False
            End If
            
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetGridSort()
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression
            Dim GrpByField As Telerik.Web.UI.GridGroupByField
            Dim SortExpr As Telerik.Web.UI.GridSortExpression
            Dim group As Integer = Request.QueryString("group")
            Select Case group
                Case "1"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("JOBPAD Job, COMPPAD Comp Group By JobNum ")
                    'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                    'GrpExpr.GroupByFields.Add(GrpByField)
                    With Me.RadGridHours
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        .MasterTableView.ShowGroupFooter = True
                        .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case "2"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("CMP_NAME Campaign Group By CMP_ID")
                    GrpExpr2 = Telerik.Web.UI.GridGroupByExpression.Parse("JOBPAD Job, COMPPAD Comp Group By JobNum ")
                    'GrpByField.Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
                    'GrpExpr.GroupByFields.Add(GrpByField)
                    With Me.RadGridHours
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                        .MasterTableView.GroupsDefaultExpanded = True
                        .MasterTableView.ShowGroupFooter = True
                        .MasterTableView.GroupHeaderItemStyle.HorizontalAlign = WebControls.HorizontalAlign.Left
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
            End Select
            Session("EstimateGridSort") = group
        Catch ex As Exception

        End Try
    End Sub
End Class