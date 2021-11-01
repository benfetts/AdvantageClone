Imports Webvantage.cGlobals
Partial Public Class TrafficSchedule_TaskContacts
    Inherits Webvantage.BaseChildPage

    Private ThisTask_JobNum As Integer = 0
    Private ThisTask_JobComp As Integer = 0
    Private ThisTask_SeqNum As Integer = 0
    Private ThisTask_Client As String = ""
    Private ThisTask_Division As String = ""
    Private ThisTask_Product As String = ""
    Private ThisTask_StartDate As Date
    Private ThisTask_DueDate As Date
    Private dtTaskDetails As DataTable
    Public ThisTask_DefaultHours As String = "0.00"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

        End If
        Try
            ThisTask_JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            ThisTask_JobNum = 0
        End Try
        Try
            ThisTask_JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            ThisTask_JobComp = 0
        End Try
        Try
            ThisTask_SeqNum = CType(Request.QueryString("SeqNum"), Integer)
        Catch ex As Exception
            ThisTask_SeqNum = -1
        End Try
        Try
            ThisTask_Client = Request.QueryString("Client")
        Catch ex As Exception
            ThisTask_Client = ""
        End Try
        Try
            ThisTask_Division = Request.QueryString("Division")
        Catch ex As Exception
            ThisTask_Division = ""
        End Try
        Try
            ThisTask_Product = Request.QueryString("Product")
        Catch ex As Exception
            ThisTask_Product = ""
        End Try

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.ThisTask_JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.ThisTask_JobComp = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.TaskSequenceNumber > 0 Then Me.ThisTask_SeqNum = Me.CurrentQuerystring.TaskSequenceNumber
        If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ClientCode) = False Then Me.ThisTask_Client = Me.CurrentQuerystring.ClientCode
        If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.DivisionCode) = False Then Me.ThisTask_Division = Me.CurrentQuerystring.DivisionCode
        If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ProductCode) = False Then Me.ThisTask_Product = Me.CurrentQuerystring.ProductCode

        If Not Me.IsPostBack Then
            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            dtTaskDetails = oSchedule.GetScheduleTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum)
            Dim HeaderText As String = ""

            If IsDBNull(dtTaskDetails.Rows(0)("TASK_CODE")) = False Then
                HeaderText = dtTaskDetails.Rows(0)("TASK_CODE") & " - "
            End If

            If IsDBNull(dtTaskDetails.Rows(0)("TASK_DESCRIPTION")) = False Then
                HeaderText &= dtTaskDetails.Rows(0)("TASK_DESCRIPTION")
            End If

            Me.LblHeader.Text = "Task:  " & HeaderText

            If IsDBNull(dtTaskDetails.Rows(0)("TASK_START_DATE")) = False Then
                If cGlobals.wvIsDate(dtTaskDetails.Rows(0)("TASK_START_DATE")) Then
                    ThisTask_StartDate = cGlobals.wvCDate(dtTaskDetails.Rows(0)("TASK_START_DATE")).ToShortDateString
                    LblStartDate.Text = ThisTask_StartDate.ToShortDateString
                End If
            End If
            If IsDBNull(dtTaskDetails.Rows(0)("JOB_REVISED_DATE")) = False Then
                If cGlobals.wvIsDate(dtTaskDetails.Rows(0)("JOB_REVISED_DATE")) Then
                    ThisTask_DueDate = cGlobals.wvCDate(dtTaskDetails.Rows(0)("JOB_REVISED_DATE")).ToShortDateString
                    LblDueDate.Text = ThisTask_DueDate.ToShortDateString
                End If
            End If
            If IsDBNull(dtTaskDetails.Rows(0)("DUE_TIME")) = False Then
                LblTimeDue.Text = dtTaskDetails.Rows(0)("DUE_TIME")
            End If
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Try
            If Me.CallingPage <> "" Then
                If Me.CallingPage = "TrafficSchedule.aspx" Then
                    Me.CloseThisWindowAndRefreshCaller("Content")
                Else
                    Me.CloseThisWindowAndRefreshCaller(Me.CallingPage)
                End If
            Else
                Me.CloseThisWindowAndRefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
            End If
        Catch ex As Exception
            Me.CloseThisWindowAndRefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
        End Try
    End Sub

    Private Sub RadGridTaskContacts_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTaskContacts.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim index As Integer = e.Item.ItemIndex
            Dim CurrRecordID As Integer = 0
            Try
                CurrRecordID = e.Item.OwnerTableView.DataKeyValues(index)("ID")
            Catch ex As Exception
                CurrRecordID = 0
            End Try
            Select Case e.CommandName
                Case "RemoveContactFromTask"
                    If CurrRecordID > 0 Then
                        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        oSchedule.RemoveContactFromTask(CurrRecordID)
                    End If
                    RebindGrids()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridTaskContacts_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTaskContacts.ItemDataBound

    End Sub

    Private Sub RadGridTaskContacts_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTaskContacts.NeedDataSource
        Try
            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Me.RadGridTaskContacts.DataSource = oSchedule.GetTaskContactList(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RebindGrids()
        RadGridContactsList.Rebind()
        RadGridTaskContacts.Rebind()
    End Sub

    Private Sub RadGridContactsList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContactsList.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim index As Integer = e.Item.ItemIndex
            Dim CurrContactCode As String = ""
            Dim CurrCDPID As Integer = 0
            Try
                CurrCDPID = e.Item.OwnerTableView.DataKeyValues(index)("CDP_CONTACT_ID")
                'CurrContactCode = e.Item.OwnerTableView.DataKeyValues(index)("CONT_CODE")
            Catch ex As Exception
                CurrCDPID = 0
            End Try
            Select Case e.CommandName
                Case "AddContactToTask"
                    If CurrCDPID <> 0 Then
                        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        oSchedule.AddContactToTask(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, CurrCDPID)
                        RebindGrids()
                    End If
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridContactsList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContactsList.ItemDataBound

    End Sub

    Private Sub RadGridContactsList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridContactsList.NeedDataSource
        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Me.RadGridContactsList.DataSource = oSchedule.GetAvailableContactList(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, ThisTask_Client, ThisTask_Division, ThisTask_Product)
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Me.RebindGrids()
    End Sub

    Private Sub BtnUpdateContacts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateContacts.Click
        'SaveTaskGrid()
        Me.CloseAndRefresh()
    End Sub

End Class
