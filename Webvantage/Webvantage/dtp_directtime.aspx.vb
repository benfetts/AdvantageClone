Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure


Partial Public Class dtp_directtime
    Inherits Webvantage.BaseChildPage

    Public sSearch As String = ""
    Public dDateStart As String
    Public dDateEnd As String
    Public ExcludeCompletedRequests As Boolean = False
    Public DesktopObject As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        Dim str As String = String.Empty
        Dim strtype As String = String.Empty
        Dim taskVar As String

        DesktopObject = Request.QueryString("DesktopObject")

        str = "Date Range:  "
        If DesktopObject = "My" Then

            If Session("MyDirectTime_StartDate") IsNot Nothing Then
                dDateStart = Session("MyDirectTime_StartDate")
            Else
                dDateStart = LoGlo.FirstOfMonth()
            End If

            If Session("MyDirectTime_EndDate") IsNot Nothing Then
                dDateEnd = Session("MyDirectTime_EndDate")
            Else
                dDateEnd = LoGlo.LastOfMonth()
            End If

            str &= dDateStart
            str &= " - "
            str &= dDateEnd
        Else
            If Session("DirectTime_StartDate") IsNot Nothing Then
                dDateStart = Session("DirectTime_StartDate")
            Else
                dDateStart = LoGlo.FirstOfMonth()
            End If

            If Session("DirectTime_EndDate") IsNot Nothing Then
                dDateEnd = Session("DirectTime_EndDate")
            Else
                dDateEnd = LoGlo.LastOfMonth()
            End If

            str &= dDateStart
            str &= " - "
            str &= dDateEnd
        End If

        Me.Label.Text = str


        If dDateStart = "" Or dDateEnd = "" Then
            dDateStart = LoGlo.FormatDate(Date.Today.ToShortDateString)
            dDateEnd = LoGlo.FormatDate(CDate(dDateStart).AddMonths(1).ToShortDateString)
            Me.Label.Text = "Date Range: " & dDateStart & " - " & dDateEnd

        End If

    End Sub

    Private Sub RadGridDirectTimeDO_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles RadGridDirectTimeDO.BiffExporting
        Try
            Dim col As Column = e.ExportStructure.Tables(0).Columns(4)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(5)
            col.Width = 300
            col = e.ExportStructure.Tables(0).Columns(6)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(7)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(8)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(9)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(10)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(11)
            col.Width = 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDirectTimeDO_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDirectTimeDO.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim jv As New JobVersion(Session("ConnString"))
            Dim DirectTime As AdvantageFramework.Database.Classes.DirectTime

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim client As String = ""
            Dim job As Integer = 0
            Dim comp As Integer = 0
            Dim employee As String = ""

            If DesktopObject = "My" Then
                client = otask.getAppVars(Session("UserCode"), "MyDirectTime", "DTClient")
                employee = _Session.User.EmployeeCode
                If Session("MyDirectTime_Job") IsNot Nothing AndAlso Session("MyDirectTime_Job") <> "" Then
                    Dim jc() As String = Session("MyDirectTime_Job").Split("-")
                    job = jc(0)
                    comp = jc(1)
                End If
            Else
                client = otask.getAppVars(Session("UserCode"), "DirectTime", "DTClient")
                If Session("DirectTime_Employee") IsNot Nothing AndAlso Session("DirectTime_Employee") <> "" Then
                    employee = Session("DirectTime_Employee")
                End If
                If Session("DirectTime_Job") IsNot Nothing AndAlso Session("DirectTime_Job") <> "" Then
                    Dim jc() As String = Session("DirectTime_Job").Split("-")
                    job = jc(0)
                    comp = jc(1)
                End If
            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridDirectTimeDO.DataSource = AdvantageFramework.Database.Procedures.DirectTime.LoadByEmployee(DbContext, dDateStart, dDateEnd, employee, client, job, comp, _Session.UserCode)

            End Using

            SetGridSort()

            ' Me.RadGridJobRequestsDO.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridDirectTimeDO.PageSize = MiscFN.LoadPageSize(Me.RadGridDirectTimeDO.ID)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetGridSort()
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr2 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim GrpExpr3 As Telerik.Web.UI.GridGroupByExpression = New Telerik.Web.UI.GridGroupByExpression
            Dim gbf As Telerik.Web.UI.GridGroupByField

            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "CDPName"
            gbf.FieldAlias = "Client"
            gbf.HeaderText = ""
            GrpExpr.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "JobComponent"
            gbf.FieldAlias = "Job"
            gbf.HeaderText = ""
            GrpExpr.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Grouping"
            gbf.FieldAlias = "Grouping"
            gbf.HeaderText = ""
            GrpExpr.GroupByFields.Add(gbf)


            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Employee"
            gbf.FieldAlias = "Employee"
            gbf.HeaderText = ""
            GrpExpr2.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "Employee"
            gbf.FieldAlias = "Employee"
            gbf.HeaderText = ""
            GrpExpr2.GroupByFields.Add(gbf)


            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "FunctionDescription"
            gbf.FieldAlias = "Function"
            gbf.HeaderText = ""
            GrpExpr3.SelectFields.Add(gbf)
            gbf = New Telerik.Web.UI.GridGroupByField
            gbf.FieldName = "FunctionDescription"
            gbf.FieldAlias = "Function"
            gbf.HeaderText = ""
            GrpExpr3.GroupByFields.Add(gbf)
            With Me.RadGridDirectTimeDO
                .MasterTableView.GroupByExpressions.Clear()
                .MasterTableView.GroupByExpressions.Add(GrpExpr)
                .MasterTableView.GroupByExpressions.Add(GrpExpr2)
                .MasterTableView.GroupByExpressions.Add(GrpExpr3)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobRequestsDO_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDirectTimeDO.ItemDataBound
        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)

                Try
                    If IsDate(GridRow("Date").Text) = True Then
                        GridRow("Date").Text = LoGlo.FormatDate(CType(GridRow("Date").Text, Date).ToShortDateString)
                    End If
                Catch ex As Exception
                End Try

            End If

            If e.Item.ItemType = GridItemType.GroupFooter Then

                Dim GrpFtr As Telerik.Web.UI.GridGroupFooterItem
                GrpFtr = e.Item

                If Not GrpFtr Is Nothing Then
                    If GrpFtr.GroupIndex.Length >= 5 Then
                        GrpFtr("Date").Text = "Total for Function:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                    End If
                    If GrpFtr.GroupIndex.Length >= 3 And GrpFtr.GroupIndex.Length <= 4 Then
                        GrpFtr("Date").Text = "Total for Employee:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                    End If
                    If GrpFtr.GroupIndex.Length >= 1 And GrpFtr.GroupIndex.Length <= 2 Then
                        GrpFtr("Date").Text = "Total for Job Component:"
                        GrpFtr("Hours").Text = GrpFtr("Hours").Text.Replace("Sum : ", "")
                        GrpFtr("Amount").Text = GrpFtr("Amount").Text.Replace("Sum : ", "")
                    End If
                End If

            End If

            If e.Item.ItemType = GridItemType.Footer Then

                Dim Ftr As Telerik.Web.UI.GridFooterItem
                Ftr = e.Item

                Ftr("Date").Text = "Total for Report:"
                Ftr("Hours").Text = Ftr("Hours").Text.Replace("Sum : ", "")
                Ftr("Amount").Text = Ftr("Amount").Text.Replace("Sum : ", "")

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dt_tasklistPrint_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "DirectTime" & AdvantageFramework.StringUtilities.GUID_Date()
                Me.RadGridDirectTimeDO.MasterTableView.Caption = "Direct Time for " & Session("EmpCode") & " - " & Me.Label.Text
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridDirectTimeDO, str, False, True)
                RadGridDirectTimeDO.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class