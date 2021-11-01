Imports Telerik.Web.UI
Imports Telerik.Web.UI.ExportInfrastructure


Partial Public Class dtp_jobrequests
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
            taskVar = otask.getAppVars(Session("UserCode"), "MyJobRequests", "dDateStart")
            If taskVar <> "" Then
                str &= LoGlo.FormatDate(taskVar)
            End If
            str &= " - "
            taskVar = otask.getAppVars(Session("UserCode"), "MyJobRequests", "dDateDue")
            If taskVar <> "" Then
                str &= LoGlo.FormatDate(taskVar)
            End If
            dDateStart = otask.getAppVars(Session("UserCode"), "MyJobRequests", "dDateStart")
            dDateEnd = otask.getAppVars(Session("UserCode"), "MyJobRequests", "dDateDue")

            sSearch = otask.getAppVars(Session("UserCode"), "MyJobRequests", "sSearch")

            taskVar = otask.getAppVars(Session("UserCode"), "MyJobRequests", "CheckboxExclude")
            If taskVar <> "" Then
                ExcludeCompletedRequests = CType(otask.getAppVars(Session("UserCode"), "MyJobRequests", "CheckboxExclude"), Boolean)
            End If

        Else
            taskVar = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateStart")
            If taskVar <> "" Then
                str &= LoGlo.FormatDate(taskVar)
            End If
            str &= " - "
            taskVar = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateDue")
            If taskVar <> "" Then
                str &= LoGlo.FormatDate(taskVar)
            End If
            dDateStart = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateStart")
            dDateEnd = otask.getAppVars(Session("UserCode"), "JobRequests", "dDateDue")

            sSearch = otask.getAppVars(Session("UserCode"), "JobRequests", "sSearch")

            taskVar = otask.getAppVars(Session("UserCode"), "JobRequests", "CheckboxExclude")
            If taskVar <> "" Then
                ExcludeCompletedRequests = CType(otask.getAppVars(Session("UserCode"), "JobRequests", "CheckboxExclude"), Boolean)
            End If
        End If

        Me.Label.Text = str


        If dDateStart = "" Or dDateEnd = "" Then
            dDateStart = LoGlo.FormatDate(Date.Today.ToShortDateString)
            dDateEnd = LoGlo.FormatDate(CDate(dDateStart).AddMonths(1).ToShortDateString)
            Me.Label.Text = "Date Range: " & dDateStart & " - " & dDateEnd

        End If

    End Sub

    Private Sub RadGridJobRequestsDO_BiffExporting(sender As Object, e As GridBiffExportingEventArgs) Handles RadGridJobRequestsDO.BiffExporting
        Try
            Dim col As Column = e.ExportStructure.Tables(0).Columns(2)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(3)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(4)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(5)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(6)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(7)
            col.Width = 300
            col = e.ExportStructure.Tables(0).Columns(8)
            col.Width = 100
            col = e.ExportStructure.Tables(0).Columns(9)
            col.Width = 150
            col = e.ExportStructure.Tables(0).Columns(10)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(11)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(12)
            col.Width = 250
            col = e.ExportStructure.Tables(0).Columns(13)
            col.Width = 70
            col = e.ExportStructure.Tables(0).Columns(14)
            col.Width = 250
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobRequestsDO_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobRequestsDO.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim jv As New JobVersion(Session("ConnString"))

            If IsClientPortal = True Then
                RadGridJobRequestsDO.DataSource = jv.GetJobRequestsDO(Session("CL_CODE"), "", "", dDateStart, dDateEnd, sSearch, ExcludeCompletedRequests, DesktopObject, True, Session("UserID"))
            Else
                RadGridJobRequestsDO.DataSource = jv.GetJobRequestsDO("", "", "", dDateStart, dDateEnd, sSearch, ExcludeCompletedRequests, DesktopObject, False)
            End If
            ' Me.RadGridJobRequestsDO.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridJobRequestsDO.PageSize = MiscFN.LoadPageSize(Me.RadGridJobRequestsDO.ID)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridJobRequestsDO_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobRequestsDO.ItemDataBound
        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)

                'Dim ViewImage As WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")

                'Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("ViewLinkButton")
                'ViewLinkButton.Text = e.Item.DataItem("JobData")
                'ViewLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Content.aspx?From=DO&PageMode=Edit&JobNum=" & e.Item.DataItem("JOB_NUMBER") & "&JobCompNum=" & e.Item.DataItem("JOB_COMPONENT_NBR") & "&NewComp=0"))

                Dim job As Integer = e.Item.DataItem("JOB_NUMBER")
                Dim comp As Integer = e.Item.DataItem("JOB_COMPONENT_NBR")

                If job = 0 Then
                    GridRow("JobNumber").Text = ""
                Else
                    GridRow("JobNumber").Text = job.ToString().PadLeft(6, "0")
                End If

                If comp = 0 Then
                    GridRow("ComponentNumber").Text = ""
                Else
                    GridRow("ComponentNumber").Text = comp.ToString().PadLeft(2, "0")
                End If

                Try
                    If IsDate(e.Item.DataItem("CREATE_DATE")) = True Then
                        GridRow("RequestDate").Text = LoGlo.FormatDate(CType(e.Item.DataItem("CREATE_DATE"), Date))
                    End If
                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dt_tasklistPrint_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Request.QueryString("export") = 1 Then
                Dim str As String = ""
                str = "JobRequest" & AdvantageFramework.StringUtilities.GUID_Date()
                Me.RadGridJobRequestsDO.MasterTableView.Caption = "Job Requests - " & Me.Label.Text
                AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridJobRequestsDO, str, True, False)
                RadGridJobRequestsDO.MasterTableView.ExportToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class