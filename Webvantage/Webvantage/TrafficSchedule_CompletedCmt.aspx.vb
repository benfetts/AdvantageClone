Public Partial Class TrafficSchedule_CompletedCmt
    Inherits Webvantage.BaseChildPage

    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    Private dCompletedDate As DateTime = Date.MinValue
    Private sCompletedComment As String = ""
    Private iPercentCompleted As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("RowID") = Request.QueryString("ID")
            LoadComments(Session("RowID"))
        End If
    End Sub

    Private Sub LoadComments(ByVal sRowID As String)
        Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim bReturn As Boolean = False
        bReturn = s.GetTaskTempListByID(sRowID, dCompletedDate, sCompletedComment, iPercentCompleted)
        If bReturn = True Then
            Me.txtCompletedComments.Text = sCompletedComment
            Me.HFDateCompleted.Value = dCompletedDate
            Me.HFPercentCompleted.Value = iPercentCompleted
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim iReturn As Boolean = False
        iReturn = s.UpdateTrafficScheduleEmployee(Session("RowID"), HFDateCompleted.Value, txtCompletedComments.Text, HFPercentCompleted.Value)
        CloseAndRefresh()
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("TrafficSchedule_TaskDetail.aspx")
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.CloseThisWindow()
    End Sub

End Class