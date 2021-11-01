Partial Public Class TrafficSchedule_TaskComments
    Inherits Webvantage.BaseChildPage

    Private ThisTask_JobNum As Integer = 0
    Private ThisTask_JobComp As Integer = 0
    Private ThisTask_SeqNum As Integer = 0
    Private StrTaskComments As String = ""
    Private StrDueDateComments As String = ""
    Private StrRevisedDateComments As String = ""
    Private StrFunctionComments As String = ""

    Private Sub TrafficSchedule_TaskComments_Init(sender As Object, e As EventArgs) Handles Me.Init

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
            ThisTask_SeqNum = 0
        End Try

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.ThisTask_JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.ThisTask_JobComp = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.TaskSequenceNumber > 0 Then Me.ThisTask_SeqNum = Me.CurrentQuerystring.TaskSequenceNumber

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Try
                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                s.GetTaskComments(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, StrDueDateComments, StrRevisedDateComments, StrFunctionComments, StrTaskComments)
                Me.TxtDueDateComments.Text = StrDueDateComments
                Me.TxtRevisionDateComments.Text = StrRevisedDateComments
                Me.TxtFunctionComments.Text = StrFunctionComments
            Catch ex As Exception
            End Try
        End If
        CheckUserRights()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        s.UpdateTaskComments(ThisTask_JobNum, ThisTask_JobComp, ThisTask_SeqNum, Me.TxtDueDateComments.Text, Me.TxtRevisionDateComments.Text, Me.TxtFunctionComments.Text)
        CloseAndRefresh()
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("Content")
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlClient.SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String
            Dim custom1 As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")

            If secEdit = "N" And secInsert = "N" Then
                Me.BtnSave.Enabled = False
            ElseIf secEdit = "Y" And secInsert = "N" Then

            ElseIf secEdit = "N" And secInsert = "Y" Then
                Me.BtnSave.Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class
