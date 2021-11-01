Imports System.Drawing
Imports Webvantage.wvTimeSheet

Public Class popcomments
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private caller As String = ""
    Private Type As String = ""
    Private ID As String = ""
    Private EmpCode As String = ""
    Private TimesheetDate As Date = Nothing

#End Region

#Region " Properties "

    Private Property CommentsRequired As Boolean
        Get
            If ViewState("CommentsRequired") Is Nothing Then ViewState("CommentsRequired") = False
            Return ViewState("CommentsRequired")
        End Get
        Set(value As Boolean)
            ViewState("CommentsRequired") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub butSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSave.Click

        If Me.TxtComment.Text <> "" Then

            If Me.TxtComment.Text.Length > 32000 Then

                Me.ShowMessage("Comment exceeds 32,000 characters")
                Exit Sub

            End If

        End If

        Dim oComments As cComments = New cComments(CStr(Session("ConnString")))
        Dim oJob As New Job_Template(CStr(Session("ConnString")))
        Dim Type As String = Me.txtType.Text
        Dim ID As String = Me.txtID.Text
        Dim str As String = Me.TxtComment.Text
        Dim str2 As String = ""

        Select Case Me.Type
            Case "traffic"

                If oComments.SaveTrafficDetailComments(CInt(ID), str) = True Then

                    Me.RefreshParentPage()

                Else

                    Me.ShowMessage("Error when saving")

                End If

            Case "job"

                If oComments.SaveJobTrafficComments(CInt(ID), str) = True Then

                    Me.RefreshParentPage()

                Else

                    Me.ShowMessage("Error when saving")

                End If

            Case "hours"

                Dim Arr As String()
                Arr = Split(ID, "|")

                If oComments.SaveEmpTimeComments(Arr(0), CInt(Arr(1)), CInt(Arr(2)), str) = True Then

                    'Me.RefreshParentPage()
                    Me.CloseThisWindowAndRefreshChildPageGrid("Timesheet.aspx")

                End If

            Case "jobcomments", "jobcompcomments", "creativeinstr", "jobdelinstruct"

                str = Me.RadEditorComment.Text
                str2 = Me.RadEditorComment.Content

                oJob.UpdateJobTemplateComments(CInt(Request.QueryString("JobNum")), CInt(Request.QueryString("JobCompNum")), Type, str, str2)
                Me.RefreshParentPage()

        End Select
    End Sub
    Private Sub butClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butClose.Click

        Me.CloseThisWindow()

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
        Try
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            Me.caller = q.GetValue("caller")
            'Me.Type = q.GetValue("Type")
            'Me.ID = q.GetValue("ID")
            'Me.EmpCode = q.GetValue("empcode")
        Catch ex As Exception
        End Try
        If Not Request.QueryString("Type") Is Nothing Then
            Type = Request.QueryString("Type")
        End If
        If Not Request.QueryString("ID") Is Nothing Then
            ID = Request.QueryString("ID")
        End If
        If Not Request.QueryString("empcode") Is Nothing Then
            Me.EmpCode = Request.QueryString("empcode")
        End If
        Try
            If Not Request.QueryString("date") Is Nothing Then
                If IsDate(Request.QueryString("date")) = True Then
                    TimesheetDate = CType(Request.QueryString("date"), Date)
                End If
            End If
        Catch ex As Exception
            TimesheetDate = Nothing
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Page.IsPostBack = False Then
                Me.txtType.Text = Type
                Me.txtID.Text = ID

                If Type = "jobcomments" Or Type = "jobcompcomments" Or Type = "creativeinstr" Or Type = "jobdelinstruct" Then
                    Me.RadEditorComment.Visible = True
                    Me.TxtComment.Visible = False
                Else
                    Me.RadEditorComment.Visible = False
                    Me.TxtComment.Visible = True
                End If

                LoadComments(Type, ID)
            End If
        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub

#End Region

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlClient.SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

            If secEdit = "N" Then
                Me.butSave.Enabled = False
            End If


        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadComments(ByVal Type As String, ByVal ID As String)
        Try

            Dim LegacyComments As cComments = New cComments(CStr(Session("ConnString")))
            Dim LegacyJobTemplate As New Job_Template(CStr(Session("ConnString")))
            Dim ds As DataSet
            Dim Arr As String()
            Dim str As String = ""

            Select Case Type
                Case "traffic"
                    str = LegacyComments.GetTrafficDetailComments(CInt(ID))
                    Me.TxtComment.Text = LegacyComments.GetTrafficDetailComments(CInt(ID))
                Case "job"
                    str = LegacyComments.GetJobTrafficComments(CInt(ID))
                    Me.TxtComment.Text = LegacyComments.GetJobTrafficComments(CInt(ID))
                Case "hours"
                    'If comments requried, we force textbox and user never sees this pop up
                    'Dim oReq As New cRequired(Session("ConnString"))
                    'CommentsRequired = oReq.RequiredTimesheetComments(CInt(Arr(1)), CInt(Arr(2)))
                    'If CommentsRequired = True Then
                    '    Me.TxtComment.CssClass = "RequiredInput"
                    'End If
                    Arr = Split(ID, "|")
                    str = LegacyComments.GetEmpTimeComments(Arr(0), CInt(Arr(1)), CInt(Arr(2)))
                    Me.TxtComment.Text = str
                    If Not TimesheetDate = Nothing Then
                        Dim ts As New cTimeSheet(Session("ConnString"))
                        Dim ThisEdit As AdvantageFramework.Timesheet.TimesheetEditType = ts.CheckEditStatus(CInt(Arr(1)), CInt(Arr(2)))
                        Dim CanEdit As Boolean = False
                        If ThisEdit = AdvantageFramework.Timesheet.TimesheetEditType.Edit Or ThisEdit = AdvantageFramework.Timesheet.TimesheetEditType.Denied Then
                            CanEdit = True
                        End If
                        If ts.PostPeriodClosed(TimesheetDate) = True Then CanEdit = False
                        Dim QsEdit As String = ""
                        Try
                            If Not Request.QueryString("CanEdit") Is Nothing Then
                                QsEdit = Request.QueryString("CanEdit")
                            End If
                        Catch ex As Exception
                            QsEdit = ""
                        End Try

                        If QsEdit = "false" Then CanEdit = False

                        Me.TxtComment.Enabled = CanEdit
                        Me.butSave.Visible = CanEdit

                    End If
                Case "timeapproval"
                    Arr = Split(ID, "|")
                    Me.butSave.Visible = False
                    Me.TxtComment.Enabled = False
                    If LegacyComments.GetTimeSheetApproveComments(Arr(0), Arr(1)) = "" Then
                        Me.TxtComment.Text = ""
                    Else
                        str = LegacyComments.GetTimeSheetApproveComments(Arr(0), Arr(1))
                        Me.TxtComment.Text = str
                    End If

                Case "SuperApprExpense"
                    Me.TxtComment.Enabled = False
                    Me.butSave.Visible = False

                    'Arr = Split(ID, "|")
                    str = LegacyComments.GetSuperApprExpenseComment(CInt(ID))
                    Me.TxtComment.Text = str
                Case "jobcomments"
                    CheckUserRights()
                    ds = LegacyJobTemplate.GetJobTemplateComments(CInt(Request.QueryString("JobNum")), CInt(Request.QueryString("JobCompNum")))
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("JOB_COMMENTS_HTML") <> "" Then
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JOB_COMMENTS_HTML")
                        Else
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JOB_COMMENTS").Replace(Environment.NewLine, "<br/>")
                        End If
                    End If
                Case "jobcompcomments"
                    CheckUserRights()
                    ds = LegacyJobTemplate.GetJobTemplateComments(CInt(Request.QueryString("JobNum")), CInt(Request.QueryString("JobCompNum")))
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("JC_COMMENTS_HTML") <> "" Then
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JC_COMMENTS_HTML")
                        Else
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JOB_COMP_COMMENTS").Replace(Environment.NewLine, "<br/>")
                        End If
                    End If
                Case "creativeinstr"
                    CheckUserRights()
                    ds = LegacyJobTemplate.GetJobTemplateComments(CInt(Request.QueryString("JobNum")), CInt(Request.QueryString("JobCompNum")))
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("CREATIVE_INSTR_HTML") <> "" Then
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("CREATIVE_INSTR_HTML")
                        Else
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("CREATIVE_INSTR").Replace(Environment.NewLine, "<br/>")
                        End If
                    End If
                Case "jobdelinstruct"
                    CheckUserRights()
                    ds = LegacyJobTemplate.GetJobTemplateComments(CInt(Request.QueryString("JobNum")), CInt(Request.QueryString("JobCompNum")))
                    If ds.Tables(0).Rows.Count > 0 Then
                        If ds.Tables(0).Rows(0)("JOB_DEL_INSTR_HTML") <> "" Then
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JOB_DEL_INSTR_HTML")
                        Else
                            Me.RadEditorComment.Content = ds.Tables(0).Rows(0)("JOB_DEL_INSTRUCT").Replace(Environment.NewLine, "<br/>")
                        End If
                    End If
                Case Else

            End Select

            Try

                If Me.RadEditorComment.Content IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Me.RadEditorComment.Content) = False Then

                    Me.RadEditorComment.Content = LegacyJobTemplate.DecodeSQL(Me.RadEditorComment.Content)

                End If

            Catch ex As Exception
            End Try

        Catch ex As Exception
            'Me.CommentRadEditor.Html = ex.Message.ToString
        End Try
    End Sub
    Private Sub RefreshParentPage()
        Select Case Me.Type
            Case "traffic"
                Me.CloseThisWindowAndRefreshCaller("Content.aspx")
            Case "job"
                Me.CloseThisWindowAndRefreshCaller("Content.aspx")
            Case "hours"
                Me.CloseThisWindowAndRefreshCaller("Timesheet.aspx", True)
            Case "jobcomments", "jobcompcomments", "creativeinstr", "jobdelinstruct"
                Me.CloseThisWindowAndRefreshCaller("Content.aspx")
            Case Else
                Me.CloseThisWindow()
        End Select
    End Sub

#End Region


End Class