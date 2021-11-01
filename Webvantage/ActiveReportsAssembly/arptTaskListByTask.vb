Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptTaskListByTask
    Public strEmpName As String
    Public strUserID As String
    Public strEmpCode As String
    Public strClientCode As String
    Public strDivCode As String
    Public strProdCode As String
    Public strJobNumber As String
    Public strSortOrder As String
    Public strStartDate As String
    Public strEndDate As String
    Public strCompleted As String
    Public chkClient As Boolean
    Public chkDivision As Boolean
    Public chkProduct As Boolean
    Public chkJob As Boolean
    Public chkRevDueDate As Boolean
    Public chkCompleted As Boolean
    Public chkComponent As Boolean
    Public chkHrsAllowed As Boolean
    Public chkDueDate As Boolean
    Public chkComments As Boolean
    Public chkTimeDue As Boolean
    Public dt As DataTable
    Private tempDView As DataView
    'Public ds As arptTaskDS
    'Public dt As New arptTaskDS.usp_wv_rpt_TaskListDataTable
    Public CultureCode As String = "en-US"
    Private Sub arptTaskListByTask_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptTaskDS
        'Dim t As New arptTaskDSTableAdapters.usp_wv_rpt_TaskListTableAdapter
        't.Fill(dt, strUserID, strEmpCode, strClientCode, strDivCode, strProdCode, strJobNumber, strSortOrder, strStartDate, strEndDate, strCompleted)
        ''tempDView = New DataView(dt)
        ''tempDView.Sort = "task,CCode,DCode,PCode,JobNum,CompNum"
        Me.DataSource = dt
        If Me.chkHrsAllowed = True Then
            Me.Label11.Visible = False
        End If
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        Me.MyTaskList.Text = Me.MyTaskList.Text & " (" & strEmpName & ") by Task"
        Me.Label2.Text = Now.Date.Date
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        If Me.chkClient = True Then
            Me.txtCName1.Visible = False
        End If
        If Me.chkDivision = True Then
            Me.txtDName1.Visible = False
        End If
        If Me.chkProduct = True Then
            Me.txtPName1.Visible = False
        End If
        If Me.chkJob = True Then
            Me.txtJobNum1.Visible = False
        End If
        If Me.chkCompleted = True Then
            Me.txtCompleted_Date1.Visible = False
        End If
        If Me.chkComponent = True Then
            Me.txtCompNum1.Visible = False
        End If
        If Me.chkHrsAllowed = True Then
            Me.txtHoursAllowed1.Visible = False
        End If
        If Me.chkDueDate = True Then
            Me.txtDue_Date1.Visible = False
        End If
        If Me.chkRevDueDate = True Then
            Me.txtRev_Due_Date1.Visible = False
        End If
        If Me.chkComments = True Then
            Me.txtComments1.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.txtTimeDue.Visible = False
        End If
    End Sub
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtJobNum1.Text = "(" & Me.txtJobNum1.Text & ") " & Me.txtJobDesc1.Text
        Me.txtCompNum1.Text = "(" & Me.txtCompNum1.Text & ") " & Me.txtCompDesc1.Text
        If Me.txtDue_Date1.Text <> "" Then
            Me.txtDue_Date1.Text = CDate(Me.txtDue_Date1.Text).ToShortDateString
        End If
        If Me.txtRev_Due_Date1.Text <> "" Then
            Me.txtRev_Due_Date1.Text = CDate(Me.txtRev_Due_Date1.Text).ToShortDateString
        End If
        If Me.txtCompleted_Date1.Text <> "" Then
            Me.txtCompleted_Date1.Text = CDate(Me.txtCompleted_Date1.Text).ToShortDateString
        End If
    End Sub


    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint
        If Me.chkClient = True Then
            Me.Client.Visible = False
        End If
        If Me.chkDivision = True Then
            Me.Division.Visible = False
        End If
        If Me.chkProduct = True Then
            Me.Product.Visible = False
        End If
        If Me.chkJob = True Then
            Me.Job.Visible = False
        End If
        If Me.chkCompleted = True Then
            Me.Complete.Visible = False
        End If
        If Me.chkComponent = True Then
            Me.CompDesc.Visible = False
        End If
        If Me.chkHrsAllowed = True Then
            Me.Hours.Visible = False
        End If
        If Me.chkDueDate = True Then
            Me.Original.Visible = False
        End If
        If Me.chkRevDueDate = True Then
            Me.DueDate.Visible = False
        End If
        If Me.chkComments = True Then
            Me.Comments.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.lblTimeDue.Visible = False
        End If
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        If Me.chkHrsAllowed = True Then
            Me.txtsumHours2.Visible = False
        End If
    End Sub
End Class
