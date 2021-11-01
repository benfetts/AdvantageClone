
Imports Webvantage.wvTimeSheet
Public Class task
    Inherits Webvantage.BaseChildPage
    Protected WithEvents dlTask As System.Web.UI.WebControls.DataList
    'Protected WithEvents butMarkCompleted As System.Web.UI.WebControls.Button
    'Protected WithEvents butMarkNotCompleted As System.Web.UI.WebControls.Button
    'Protected WithEvents butComments As System.Web.UI.WebControls.Button
    'Protected WithEvents butAddTime As System.Web.UI.WebControls.Button
    Protected WithEvents hlEmps As System.Web.UI.WebControls.HyperLink
    'Protected WithEvents RadWindowManager As Telerik.Web.UI.RadWindowManager
    Protected WithEvents RadToolBarTask As Telerik.Web.UI.RadToolBar
    Protected WithEvents CollapsablePanelClient As eWorld.UI.CollapsablePanel
    Protected WithEvents CollapsablePanelJob As eWorld.UI.CollapsablePanel
    Protected WithEvents CollapsablePanelTask As eWorld.UI.CollapsablePanel
    Dim JobNo As Integer
    Dim JobComp As Integer
    Dim SeqNo As Integer
    Dim EmpCode As String = ""
    Dim type As String
    Public comments As String
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
        Me.AllowFloat = True
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        If Page.IsPostBack = False Then
            LoadTask()
            Try
                Me.comments = Request.QueryString("Comments")
            Catch ex As Exception
                Me.comments = ""
            End Try
        End If
    End Sub

    Private Sub LoadTask()
        Dim dr As SqlClient.SqlDataReader
        JobNo = CInt(Request.Params("JobNo"))
        JobComp = CInt(Request.Params("JobComp"))
        SeqNo = CInt(Request.Params("SeqNo"))
        EmpCode = Request.QueryString("EmpCode")

        type = Request.QueryString("type")
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        dr = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)

        If EmpCode = "" Or type = "timeline" Then
            Me.RadToolBarTask.FindItemByValue("MarkCompleted").Enabled = False
            Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Enabled = False
            Me.RadToolBarTask.FindItemByValue("Comments").Enabled = False
            Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = False
            Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Visible = False
        End If

        Do While dr.Read
            If dr("TempCompDate").ToString.Trim <> "" Then
                Dim str As String = dr.GetDateTime(12).ToShortDateString
                If dr.GetDateTime(12).ToShortDateString <> "01/01/1900" Then
                    Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Visible = True
                    Me.RadToolBarTask.FindItemByValue("MarkCompleted").Visible = False
                Else
                    Me.RadToolBarTask.FindItemByValue("MarkCompleted").Visible = True
                    Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Visible = False
                End If
            End If
        Loop
        dr.Close()
        If EmpCode.Trim = "..." Then
            EmpCode = ""
        End If
        dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
        dlTask.DataBind()

        'CHECK job IS NOT IN 6,12
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = myVal.ValidateJobIsOpen(JobNo, JobComp)
        'check security settings
        If Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = True Then
            Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = myVal.ValidateJobCompIsEditable(JobNo, JobComp)
        End If
        If Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = True Then
            Dim oSec As New cSecurity(Session("ConnString"))
            Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet, False) = 1)
        End If
        If Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = True Then
            Dim ots As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            If ots.UserLimited(Session("UserCode")) = True Then
                If Session("EmpCode").ToString.Trim <> EmpCode.Trim Then
                    Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = False
                End If
            End If
        End If
        If EmpCode = "" Then
            Me.RadToolBarTask.FindItemByValue("AddTime").Enabled = False
        End If
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

    Private Sub dlTask_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlTask.ItemDataBound
        Dim hl As System.Web.UI.WebControls.HyperLink
        hl = e.Item.FindControl("hlEmps")
        hl.Attributes.Add("onclick", "OpenRadWindow('','taskEmployees.aspx?JobNo=" & JobNo & "&JobComp=" & JobComp & "&SeqNo=" & SeqNo & "&EmplCode=" & EmpCode & "', 0,0,true);return false;")
        hl.Style("cursor") = "hand"

        If EmpCode = "" Or type = "timeline" Then
            hl.Visible = False
        End If
    End Sub

    Private Sub RadToolBarTask_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTask.ButtonClick
        Select Case e.Item.Value
            Case "Comments"
                JobNo = CInt(Request.Params("JobNo"))
                JobComp = CInt(Request.Params("JobComp"))
                SeqNo = CInt(Request.Params("SeqNo"))
                EmpCode = Request.QueryString("EmpCode")
                If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
                    Session("TimesheetTaskComments") = "1"
                End If
                Me.OpenWindow("", "taskComments.aspx?caller=" & Me.PageFilename & "&JobNo=" & JobNo & "&JobComp=" & JobComp & "&SeqNo=" & SeqNo & "&Comments=1" & "&EmplCode=" & EmpCode, , , , True)
            Case "MarkCompleted"
                JobNo = CInt(Request.Params("JobNo"))
                JobComp = CInt(Request.Params("JobComp"))
                SeqNo = CInt(Request.Params("SeqNo"))
                EmpCode = Request.QueryString("EmpCode")

                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNo, JobComp, SeqNo, EmpCode, CType(Now, DateTime)) = True Then

                            Me.RadToolBarTask.FindItemByValue("MarkCompleted").Visible = False
                            Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Visible = True

                        End If

                    End Using

                End Using

                dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
                dlTask.DataBind()

                If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
                    Session("TimesheetTask") = "1"
                Else
                    Session("TimesheetTask") = ""
                End If

                If Request.QueryString("FromPage") <> "TimesheetCopyFrom" Then
                    'Dim cScript As String
                    'cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                    'RegisterStartupScript("parentwindow", cScript)
                    Me.CloseThisWindow()
                    'Else
                    '    Me.CloseThisWindowAndRefreshCaller("Timesheet_CopyFrom.aspx")
                End If

            Case "MarkNotCompleted"
                JobNo = CInt(Request.Params("JobNo"))
                JobComp = CInt(Request.Params("JobComp"))
                SeqNo = CInt(Request.Params("SeqNo"))
                EmpCode = Request.QueryString("EmpCode")

                Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, JobNo, JobComp, SeqNo, EmpCode, Nothing) = True Then

                            Me.RadToolBarTask.FindItemByValue("MarkCompleted").Visible = True
                            Me.RadToolBarTask.FindItemByValue("MarkNotCompleted").Visible = False

                        End If

                    End Using

                End Using

                dlTask.DataSource = oTasks.GetTask(JobNo, JobComp, SeqNo, EmpCode)
                dlTask.DataBind()

                If Request.QueryString("FromPage") <> "TimesheetCopyFrom" Then
                    'Dim cScript As String
                    'cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                    'RegisterStartupScript("parentwindow", cScript)
                    Me.CloseThisWindow()
                    'Else
                    '    Me.CloseThisWindowAndRefreshCaller("Timesheet_CopyFrom.aspx")
                End If
            Case "AddTime"
                JobNo = CInt(Request.Params("JobNo"))
                JobComp = CInt(Request.Params("JobComp"))
                SeqNo = CInt(Request.Params("SeqNo"))
                EmpCode = Request.QueryString("EmpCode")
                If Request.QueryString("FromPage") = "TimesheetCopyFrom" Then
                    Session("TimesheetTaskQuickAdd") = "1"
                End If
                Me.OpenWindow("", "Timesheet_QuickAdd.aspx?caller=" & Me.PageFilename & "&JobNum=" & JobNo & "&JobComp=" & JobComp & "&Seq=" & SeqNo & "&TaskEmp=" & EmpCode)
        End Select
    End Sub

End Class
