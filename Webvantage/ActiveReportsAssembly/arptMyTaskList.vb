Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptMyTaskList
    Public strEmpName As String
    Public strUserID As String
    Public strEmpCodes As String
    Public strClientCodes As String
    Public strOfficeCodes As String
    Public strAECodes As String
    Public strDivCode As String
    Public strProdCode As String
    Public strJobNumber As String
    Public strSortOrder As String
    Public strStartDate As String
    Public strEndDate As String
    Public strCompleted As String
    Public chkJob As Boolean = False
    Public chkRevDueDate As Boolean
    Public chkTimeDue As Boolean
    Public chkCompleted As Boolean
    Public chkComponent As Boolean
    Public chkHrsAllowed As Boolean
    Public chkEmp As Boolean
    Public chkCDate As Boolean
    Public chkComments As Boolean
    Public chkJTComments As Boolean
    Public dt As DataTable
    Private tempDView As DataView
    'Public ds As arptTaskDS
    'Public dt As New arptTaskDS.usp_wv_rpt_TaskListDataTable
    Public prevJob As String = ""
    Public currentJob As String = "a"
    Public prevComp As String = ""
    Public currentComp As String = "a"

    Public CultureCode As String = "en-US"
    Private Sub arptMyTaskList_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptTaskDS
        'Dim t As New arptTaskDSTableAdapters.usp_wv_rpt_TaskListTableAdapter
        't.Fill(dt, strUserID, strEmpCode, strClientCode, strDivCode, strProdCode, strJobNumber, strSortOrder, strStartDate, strEndDate, strCompleted)
        tempDView = New DataView(dt)
        'tempDView.Sort = "CCode,DCode,PCode,JBNUM,task,[Due Date]"
        'Me.DataSource = dt
        If Me.strSortOrder = "4" Then
            Me.GroupHeader1.DataField = "CCode"
        End If
        Me.DataSource = tempDView
        If Me.chkHrsAllowed = True Then
            Me.GroupFooter2.Visible = False
            'Me.GroupFooter1.Visible = False
            Me.Label11.Visible = False
            Me.Label1.Visible = False
        End If
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        'Me.MyTaskList.Text = Me.MyTaskList.Text & " (" & strEmpName & ")"
        'Me.Label2.Text = Now.Date.Date
        
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If Me.txtProductCode.Text = Me.txtDivisionCode.Text Then
                Me.txtProduct.Text = ""
                Me.txtPName1.Text = ""
                Me.txtProduct.Text = ""
            Else
                Me.txtProduct.Text = "Product:"
                Me.txtDivision.Text = "Division:"
            End If
            If Me.txtProduct.Text <> "Product:" Then
                If Me.txtDivisionCode.Text = Me.txtClientCode.Text Then
                    Me.txtDivision.Text = ""
                    Me.txtDName1.Text = ""
                    Me.txtDivision.Text = ""
                Else
                    Me.txtDivision.Text = "Division:"
                End If
            End If
            If Me.strSortOrder = "4" Then
                Me.txtDivision.Visible = False
                Me.txtDName1.Visible = False
                Me.txtProduct.Visible = False
                Me.txtPName1.Visible = False
            End If
            If Me.strSortOrder = "5" Then
                Me.txtDivision.Visible = False
                Me.txtDName1.Visible = False
                Me.txtProduct.Visible = False
                Me.txtPName1.Visible = False
                Me.GroupHeader1.Visible = False
                Me.GroupFooter1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        If Me.chkJob = True Then
            Me.txtJobNum1.Visible = False
        End If
        If Me.chkRevDueDate = True Then
            Me.txtRev_Due_Date1.Visible = False
            'Me.DueDate.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.txtTimeDue.Visible = False
            'Me.TimeDue.Visible = False
        End If
        If Me.chkCompleted = True Then
            Me.txtCompleted_Date1.Visible = False
            Me.Label3.Visible = False
        End If
        If Me.chkComponent = True Then
            Me.txtCompNum1.Visible = False
        End If
        If Me.chkHrsAllowed = True Then
            Me.txtHoursAllowed1.Visible = False
            'Me.Hours.Visible = False
        End If
        If Me.chkEmp = True Then
            Me.txtEmp_Assign1.Visible = False
            'Me.Emp.Visible = False
        End If
        If Me.chkComments = True Then
            Me.txtComments1.Visible = False
            'Me.Comments.Visible = False
        End If

        prevJob = currentJob
        prevComp = currentComp
        currentJob = Me.txtJobNum1.Text.Trim
        currentComp = Me.txtCompNum1.Text.Trim

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
        ' Me.txtJobNum1.Text = "(" & Me.txtJobNum1.Text & ") " & Me.txtJobDesc1.Text
        'Me.txtCompNum1.Text = "(" & Me.txtCompNum1.Text & ") " & Me.txtCompDesc1.Text
        If Me.txtRev_Due_Date1.Text <> "" Then
            Me.txtRev_Due_Date1.Text = CDate(Me.txtRev_Due_Date1.Text).ToShortDateString
        End If
        If Me.txtCompleted_Date1.Text <> "" Then
            Me.txtCompleted_Date1.Text = CDate(Me.txtCompleted_Date1.Text).ToShortDateString
        End If
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        'Me.Product.Text = "Product: " & Me.txtPName1.Text
    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint
        'If Me.chkJob = True Then
        Me.Job.Visible = False
        'End If
        If Me.chkRevDueDate = True Then
            Me.DueDate.Visible = False
        End If
        If Me.chkTimeDue = True Then
            Me.TimeDue.Visible = False
        End If
        If Me.chkCompleted = True Then
            Me.Completed.Visible = False
        End If
        'If Me.chkComponent = True Then
        Me.CompDesc.Visible = False
        'End If
        If Me.chkHrsAllowed = True Then
            Me.Hours.Visible = False
        End If
        If Me.chkEmp = True Then
            Me.Emp.Visible = False
        End If
        If Me.chkComments = True Then
            Me.Comments.Visible = False
        End If
    End Sub

    Private Sub GroupFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.BeforePrint
        If Me.chkHrsAllowed = True Then
            Me.txtsumHours2.Visible = False
        End If
    End Sub

    Private Sub GroupFooter2_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.BeforePrint
        If Me.chkHrsAllowed = True Then
            Me.txtsumHours1.Visible = False
        End If
        If Me.strSortOrder = "4" Then
            Me.GroupFooter2.Visible = False
        End If
        If Me.strSortOrder = "5" Then
            Me.GroupFooter2.Visible = False
        End If
    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        lbluser.Text = Me.strUserID
    End Sub

    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.BeforePrint

    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        txtJobComp.Text = "(" & Me.txtJobNum1.Text & ") " & Me.txtJobDesc1.Text & " / " & "(" & Me.txtCompNum1.Text & ") " & Me.txtCompDesc1.Text
        If Me.chkJTComments = True Then
            Me.txtJTComments.Text = ""
            Me.txtCommentJT.Text = ""
        Else
            Me.txtCommentJT.Text = "Comment:"
        End If
    End Sub

    Private Sub GroupFooter3_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.BeforePrint

    End Sub

    Private Sub GroupFooter4_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter4.BeforePrint
        If Me.chkHrsAllowed = True Then
            Me.txtsumHours3.Visible = False
        End If
    End Sub

    Private Sub GroupHeader4_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader4.BeforePrint

    End Sub
End Class
