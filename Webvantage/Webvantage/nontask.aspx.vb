Public Class nontask
    Inherits System.Web.UI.Page
    Protected WithEvents dlTask As System.Web.UI.WebControls.DataList
    Protected WithEvents butMarkCompleted As System.Web.UI.WebControls.Button
    Dim JobNo As Integer
    Dim JobComp As Integer
    Dim SeqNo As Integer
    Dim EmpCode As String = ""
    Protected PageTitle As System.Web.UI.HtmlControls.HtmlGenericControl
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.PageTitle.InnerText = System.Configuration.ConfigurationManager.AppSettings("AppTitle") & " - Task"
        If Page.IsPostBack = False Then
            LoadTask()
            Me.butMarkCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Task as Complete?')==false) return false;")
        End If
    End Sub
    Private Sub LoadTask()
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, "")
        dlTask.DataBind()

    End Sub

    Private Sub butMarkCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMarkCompleted.Click
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Session("EmpCode")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        'If oTasks.MarkCompleted(JobNo, JobComp, SeqNo, EmpCode, Today.Date) = True Then
        '    'butMarkCompleted.Enabled = False
        'End If
        Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            Using sc As New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                If AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNo, JobComp, SeqNo, EmpCode, CType(Now, DateTime)) = True Then

                    'butMarkCompleted.Enabled = False

                End If

            End Using

        End Using

        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, "")
        dlTask.DataBind()
    End Sub
    Public Function ShowTaskStatus(ByVal TaskStatus As String) As String
        Select Case TaskStatus.ToUpper
            Case "P"
                Return "Projected"
            Case "A"
                Return "Active"
            Case Else
                Return "Projected"
        End Select
    End Function
End Class
