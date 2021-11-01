Imports System.Data.SqlClient
Imports System.Text

Imports System
Imports System.Data
Imports System.Data.DataRow
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals

Partial Public Class CreativeBrief_Approved
    Inherits Webvantage.BaseChildPage

    Private JobNum As Integer
    Private JobCompNum As Int16
    Private CreativeBrfCPID As Integer = 0

    Private Sub CreativeBriefApproved_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.JobNum = CType(Request.QueryString("JobNo"), Integer)
        Me.JobCompNum = CType(Request.QueryString("JobComp"), Int16)
        PopulatePage()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            TextBoxApprovedBy.Focus()

        End If

    End Sub

    Private Sub UpdateCreativeBriefAppr()
        Dim SQL_UPDATE_STR, textboxText, textStr As String
        Dim TextBoxApprovedBy_txt, TBApprvdate_txt As String
        Dim ApprDate As DateTime = Now
        Dim oSQL As SqlHelper
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))

        If Me.TextBoxComment.Text = Nothing Then
            textboxText = ""
        Else
            textboxText = Me.TextBoxComment.Text
        End If
        textStr = textboxText.Replace("'", "''")

        If Me.TextBoxApprovedBy.Text = Nothing Then
            TextBoxApprovedBy_txt = ""
        Else
            TextBoxApprovedBy_txt = Me.TextBoxApprovedBy.Text
        End If

        If Me.RadDatePickerApprovalDate.SelectedDate = Nothing Then
            TBApprvdate_txt = CStr(ApprDate.ToShortDateString)
        Else
            TBApprvdate_txt = wvCDate(Me.RadDatePickerApprovalDate.SelectedDate, True).ToString()
        End If

        If isApprovedVersion() = True Then

            cb.UpdateCreativeBriefApproval(JobNum, JobCompNum, TextBoxApprovedBy_txt, textStr, Session("UserCode"), TBApprvdate_txt, Me.IsClientPortal, Session("UserID"))

            'If IsClientPortal = True Then
            '    SQL_UPDATE_STR = "UPDATE CRTV_BRF_APPR SET CB_APPR_COMMENT = '"
            '    SQL_UPDATE_STR += textStr & "', CB_APPR_USER_ID = '', CB_APPR_BY = '" & TextBoxApprovedBy_txt & "', CB_APPR_DATE = '" & TBApprvdate_txt
            '    SQL_UPDATE_STR += "' WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)
            'Else
            '    SQL_UPDATE_STR = "UPDATE CRTV_BRF_APPR SET CB_APPR_COMMENT = '"
            '    SQL_UPDATE_STR += textStr & "', CB_APPR_USER_ID = '" & Session("UserCode") & "', CB_APPR_BY = '" & TextBoxApprovedBy_txt & "', CB_APPR_DATE = '" & TBApprvdate_txt
            '    SQL_UPDATE_STR += "' WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)
            'End If
        Else
            'If IsClientPortal = True Then
            '    SQL_UPDATE_STR = "INSERT INTO CRTV_BRF_APPR (JOB_NUMBER, JOB_COMPONENT_NBR, CB_APPR_BY, CB_APPR_COMMENT, CB_APPR_USER_ID, CB_APPR_DATE, CB_APPR_USER_ID_CP) "
            '    SQL_UPDATE_STR += " VALUES(" & CStr(JobNum) & ", " & CStr(JobCompNum) & ", '" & TextBoxApprovedBy_txt & "', '" & textStr & "', '', '" & TBApprvdate_txt & "', '" & Session("UserID") & "')"
            'Else

            cb.AddCreativeBriefApproval(JobNum, JobCompNum, TextBoxApprovedBy_txt, textStr, Session("UserCode"), TBApprvdate_txt, Me.IsClientPortal, Session("UserID"))

            '    SQL_UPDATE_STR = "INSERT INTO CRTV_BRF_APPR (JOB_NUMBER, JOB_COMPONENT_NBR, CB_APPR_BY, CB_APPR_COMMENT, CB_APPR_USER_ID, CB_APPR_DATE) "
            '    SQL_UPDATE_STR += " VALUES(" & CStr(JobNum) & ", " & CStr(JobCompNum) & ", '" & TextBoxApprovedBy_txt & "', '" & textStr & "', '" & Session("UserCode") & "', '" & TBApprvdate_txt & "')"
            'End If
        End If

        'oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)

    End Sub

    Private Sub PopulatePage()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim apprBy, comment As String
        Dim apprDate As DateTime


        SQL_STRING = "SELECT CB_APPR_BY, CB_APPR_DATE, CAST(CB_APPR_COMMENT AS VARCHAR(2000)) AS COMMENT, ISNULL(CB_APPR_USER_ID_CP,0) FROM CRTV_BRF_APPR "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(JobCompNum)

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            apprBy = dr.GetString(0)
            apprDate = dr.GetDateTime(1).ToShortDateString
            comment = dr.GetString(2)
            CreativeBrfCPID = dr.GetInt32(3)

            Me.TextBoxApprovedBy.Text = apprBy
            Me.RadDatePickerApprovalDate.SelectedDate = CStr(apprDate)
            Me.TextBoxComment.Text = comment

            If Me.IsClientPortal = True And CreativeBrfCPID = 0 Then
                Me.RadToolBarCreativeBrief.FindItemByValue("Save").Visible = False
                Me.TextBoxApprovedBy.ReadOnly = True
                Me.RadDatePickerApprovalDate.Enabled = False
                Me.TextBoxComment.ReadOnly = True
            End If
        Else
            apprDate = cEmployee.TimeZoneToday
            Me.RadDatePickerApprovalDate.SelectedDate = CStr(apprDate.ToShortDateString)
        End If


    End Sub

    Private Function isApprovedVersion() As Boolean
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim count As Int16

        SQL_STRING = "SELECT COUNT(*) FROM CRTV_BRF_APPR "
        SQL_STRING &= " WHERE JOB_NUMBER = " & CStr(Me.JobNum) & " AND JOB_COMPONENT_NBR = " & CStr(Me.JobCompNum)

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:getLevel1Data", Err.Description)
        Finally
        End Try

        dr.Read()
        count = dr.GetInt32(0)
        If count > 0 Then
            Return True
        End If
        Return False

    End Function

    Private Sub RadToolBarCreativeBrief_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCreativeBrief.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                If Me.TextBoxApprovedBy.Text = "" Then
                    Me.ShowMessage("Approved By is required")
                    Exit Sub
                End If
                If Me.RadDatePickerApprovalDate.SelectedDate Is Nothing Then
                    Me.ShowMessage("Approval Date is required")
                    Exit Sub
                End If
                Try
                    Me.UpdateCreativeBriefAppr()
                    Me.CloseThisWindowAndRefreshCaller("CreativeBrief.aspx")
                Catch ex As Exception
                    Me.ShowMessage(ex.Message.ToString())
                End Try

            Case "Cancel"

                Try
                    Me.CloseThisWindow()
                Catch ex As Exception
                End Try

        End Select

    End Sub

End Class
