Public Class TrafficSchedule_ViewTasks
    Inherits Webvantage.BaseChildPage

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0

    Private Sub TrafficSchedule_ViewTasks_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            Me.JobNumber = CInt(Request.Params("JobNo"))
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            Me.JobComponentNbr = CInt(Request.Params("JobComp"))
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNbr = Me.CurrentQuerystring.JobComponentNumber
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.LoadTasks()
        End If
    End Sub

    Private Sub LoadTasks()

        If Me.JobNumber = 0 Or Me.JobComponentNbr = 0 Then Exit Sub

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim DtHeader As New DataTable

        DtHeader = oDO.GetMyProjectDrillDownHeader(CStr(Session("EmpCode")), Me.JobNumber, Me.JobComponentNbr)

        If DtHeader.Rows.Count > 0 Then
            Me.LabelClient.Text = DtHeader(0)("CLIENT").ToString()
            Me.LabelDivision.Text = DtHeader(0)("DIVISION").ToString()
            Me.LabelProduct.Text = DtHeader(0)("PRODUCT").ToString()
            Me.LabelJob.Text = DtHeader(0)("Job").ToString()
            Me.LabelJobComponent.Text = DtHeader(0)("JobComp").ToString()
            Try
                If IsDBNull(DtHeader(0)("JobStartDate")) = False Then
                    Me.LabelStartDate.Text = LoGlo.FormatDate(DtHeader(0)("JobStartDate").ToString())
                End If
            Catch ex As Exception
            End Try
            Try
                If IsDBNull(DtHeader(0)("JobDueDate")) = False Then
                    Me.LabelDueDate.Text = LoGlo.FormatDate(DtHeader(0)("JobDueDate").ToString())
                End If
            Catch ex As Exception
            End Try
            Me.LabelTrafficStatus.Text = DtHeader(0)("TrafficStatus").ToString()
            Me.LabelTrafficComments.Text = DtHeader(0)("TrafficComments").ToString()
        Else
            Me.ShowMessage("No Tasks or All Tasks have been completed")
        End If

    End Sub

    Private Sub RadGridTasks_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTasks.ItemDataBound
        'Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        'If dt.Rows(i)("EmpCode").ToString.Trim = "..." Then
        '    Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(Me.JobNumber, Me.JobComponentNbr, CInt(dt.Rows(i)("SEQ_NBR").ToString()))
        '    If strEmps <> "" Then
        '        dt.Rows(i)("EmpCode") = strEmps
        '    End If
        'Else
        '    Dim strEmps As String = oTrafficSchedule.GetTaskEmpListStringName(Me.JobNumber, Me.JobComponentNbr, CInt(dt.Rows(i)("SEQ_NBR").ToString()))
        '    If strEmps <> "" Then
        '        dt.Rows(i)("EmpCode") = strEmps
        '    End If
        'End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = -1
            Try
                JobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
            Catch ex As Exception
                JobNumber = 0
            End Try
            Try
                JobComponentNbr = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
            Catch ex As Exception
                JobComponentNbr = 0
            End Try
            Try
                SeqNbr = CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer)
            Catch ex As Exception
                SeqNbr = -1
            End Try
            Try
                If JobNumber > 0 And JobComponentNbr > 0 And SeqNbr > -1 Then
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim EmpList = oTrafficSchedule.GetTaskEmpListStringName(JobNumber, JobComponentNbr, SeqNbr)
                    CurrentGridRow("GridBoundColumnEmpCode").Text = EmpList
                End If
            Catch ex As Exception
            End Try
            Try
                CurrentGridRow("GridBoundColumnDueDate").Text = LoGlo.FormatDate(CurrentGridRow("GridBoundColumnDueDate").Text)
            Catch ex As Exception
            End Try
            Try
                CurrentGridRow("GridBoundColumnRevDueDate").Text = LoGlo.FormatDate(CurrentGridRow("GridBoundColumnRevDueDate").Text)
            Catch ex As Exception
            End Try
            Try
                CurrentGridRow("GridBoundColumnTempCompDate").Text = LoGlo.FormatDate(CurrentGridRow("GridBoundColumnTempCompDate").Text)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadGridTasks_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTasks.NeedDataSource
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Me.RadGridTasks.DataSource = oDO.GetMyProjectDrillDown(CStr(Session("EmpCode")), Me.JobNumber, Me.JobComponentNbr)
    End Sub


End Class