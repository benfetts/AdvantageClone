Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptMyTaskListByTask
    'Public strEmpName As String
    Public strUserID As String
    Public strEmpCodes As String
    Public strOfficeCodes As String
    Public strClientCodes As String
    Public strAECodes As String
    'Public strDivCode As String
    'Public strProdCode As String
    'Public strJobNumber As String
    Public strSortOrder As String
    Public strStartDate As String
    Public strEndDate As String
    Public strCompleted As String
    Public chkClient As Boolean
    Public chkDivision As Boolean
    Public chkProduct As Boolean
    Public chkJob As Boolean
    Public chkRevDueDate As Boolean
    Public chkTimeDue As Boolean
    Public chkCompleted As Boolean
    Public chkComponent As Boolean
    Public chkHrsAllowed As Boolean
    Public chkEmp As Boolean
    Public chkCDate As Boolean
    Public chkComments As Boolean
    Public dt As DataTable
    Private tempDView As DataView
    Public CultureCode As String = "en-US"
    'Public prevJob As String = ""
    'Public currentJob As String = "a"
    'Public prevComp As String = ""
    'Public currentComp As String = "a"
    'Public ds As arptTaskDS
    'Public dt As New arptTaskDS.usp_wv_rpt_TaskListDataTable
    Private Sub arptMyTaskListByTask_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptTaskDS
        'Dim t As New arptTaskDSTableAdapters.usp_wv_rpt_TaskListTableAdapter
        't.Fill(dt, strUserID, strEmpCode, strClientCode, strDivCode, strProdCode, strJobNumber, strSortOrder, strStartDate, strEndDate, strCompleted)
        tempDView = New DataView(dt)
        'tempDView.Sort = "task,CCode,DCode,PCode,JobNum,CompNum"
        Me.DataSource = tempDView
        If Me.chkHrsAllowed = True Then
            Me.Label11.Visible = False
        End If
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        'Me.MyTaskList.Text = Me.MyTaskList.Text & " (" & strEmpName & ") by Task"
        'Me.Label2.Text = Now.Date.Date
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
        If Me.chkEmp = True Then
            Me.txtEmp_Assign1.Visible = False
        End If
        If Me.chkRevDueDate = True Then
            Me.txtRev_Due_Date1.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.txtTimeDue.Visible = False
        End If
        If Me.chkComments = True Then
            Me.txtComments1.Visible = False
        End If

        'prevJob = currentJob
        'prevComp = currentComp
        'currentJob = Me.txtJobNum1.Text.Trim
        'currentComp = Me.txtCompNum1.Text.Trim

        'If prevJob = "a" And prevComp = "a" Then
        '    Me.Line4.Visible = False
        'ElseIf Not prevJob = currentJob Or Not prevComp = currentComp Then
        '    Me.Line4.Visible = True
        '    Me.Line4.Y1 = Me.txtJobNum1.Top
        '    Me.Line4.Y2 = Me.txtJobNum1.Top
        'Else
        '    Me.Line4.Visible = False
        'End If
    End Sub
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtJobNum1.Text = "(" & Me.txtJobNum1.Text & ") " & Me.txtJobDesc1.Text
        Me.txtCompNum1.Text = "(" & Me.txtCompNum1.Text & ") " & Me.txtCompDesc1.Text
        If Me.txtRev_Due_Date1.Text <> "" Then
            Me.txtRev_Due_Date1.Text = CDate(Me.txtRev_Due_Date1.Text).ToShortDateString
        End If
        If Me.txtCompleted_Date1.Text <> "" Then
            Me.txtCompleted_Date1.Text = CDate(Me.txtCompleted_Date1.Text).ToShortDateString
        End If
    End Sub


    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint
        
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        If Me.chkHrsAllowed = True Then
            Me.txtsumHours2.Visible = False
        End If
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        lbluser.Text = Me.strUserID
    End Sub

    Private Sub GroupHeader2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.BeforePrint
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
        If Me.chkEmp = True Then
            Me.Emp.Visible = False
        End If
        If Me.chkRevDueDate = True Then
            Me.DueDate.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.TimeDue.Visible = False
        End If
        If Me.chkComments = True Then
            Me.Comments.Visible = False
        End If
    End Sub
End Class
