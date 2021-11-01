Imports Webvantage
Imports Webvantage.MiscFN
Imports System.Data.SqlClient

Partial Public Class CreativeBrief_New
    Inherits Webvantage.BaseChildPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private IsJobDashboard As Boolean = False
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("JobNo") IsNot Nothing Then Me.JobNum = Request.QueryString("JobNo")
        If Request.QueryString("JobComp") IsNot Nothing Then Me.JobCompNum = Request.QueryString("JobComp")
        If Request.QueryString("jd") IsNot Nothing Then Me.IsJobDashboard = Request.QueryString("jd")

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobCompNum = Me.CurrentQuerystring.JobComponentNumber
        Me.IsJobDashboard = Me.CurrentQuerystring.IsJobDashboard

        If Not Page.IsPostBack Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief)
            Me.Form.Page.Title = "New Creative Brief"

            LoadDropDowns()
            Me.pnlCBCopy.Visible = False

        Else

            If Session("CBNewSaved") = 1 Then

                Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
                With sbScript
                    .Append("<script type=""text/javascript"">CallFunctionOnParentPage('OpenCreativeBrief');</script>")
                End With
                Try
                    If Not Page.IsStartupScriptRegistered("CBNew33") Then
                        Dim str As String = sbScript.ToString
                        Page.RegisterStartupScript("CBNew33", str)
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error! " & ex.Message.ToString())
                End Try

            End If
        End If
    End Sub

    Private Sub SaveTemplate()

        Dim tmpcode As String
        Dim dr As SqlDataReader
        Dim SQLSTRING As String
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        Dim rc As Int16
        Dim existingtemps As Boolean

        tmpcode = Me.ddCBTemplates.SelectedValue
        rc = cb.AddCreativeBriefJobComp(tmpcode, JobNum, JobCompNum)

        If rc = 1 Then
            Session("CBNewSaved") = 1
        Else
            Session("CBNewSaved") = 0
        End If

        'If Me.CurrentQuerystring.IsJobDashboard = True Or Me.IsJobDashboard = True Then

        Dim qs As New AdvantageFramework.Web.QueryString

        qs.Page = "CreativeBrief.aspx"
        qs.JobNumber = JobNum
        qs.JobComponentNumber = JobCompNum
        qs.Add("fw", "ProjectView")
        qs.IsJobDashboard = True
        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief

        MiscFN.ResponseRedirect(qs.ToString(True), True)

        'Else
        '    If Request.QueryString("fw") = "ProjectView" Then
        '        Me.CloseThisWindowAndOpenNewWindow("CreativeBrief.aspx?JobNo=" & JobNum & "&JobComp=" & JobCompNum & "&fw=ProjectView")
        '    Else
        '        Me.CallFunctionOnParentPage("JobTemplate.aspx", "OpenCreativeBrief();", True)
        '    End If
        'End If

    End Sub

    Private Sub LoadDropDowns()
        Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
        With Me.ddCBTemplates
            .DataSource = cb.GetCreativeBriefTmplt_dd
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
        End With

    End Sub

    Private Sub ButtonNewSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewSave.Click
        SaveTemplate()
    End Sub

    Private Sub ButtonNewCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewCopy.Click
        Try
            Me.pnlCBNew.Visible = False
            Me.pnlCBCopy.Visible = True
            LoadDefaults()
            LoadLookups()
            Me.TxtJobNum.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCopySave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopySave.Click
        Try
            Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            Dim rc As Int16

            If Me.TxtJobNum.Text = "" And Me.TxtJobCompNum.Text = "" Then
                Me.TxtClientSourceDesc.Text = ""
                Me.TxtDivisionSourceDesc.Text = ""
                Me.TxtProductSourceDesc.Text = ""
                Me.TxtJobDescription.Text = ""
                Me.TxtJobCompDescription.Text = ""
            End If


            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If Me.TxtJobNum.Text <> "" Then
                If myVal.ValidateJobNumber(Me.TxtJobNum.Text) = False Then
                    Me.ShowMessage("This job does not exist!")
                    Exit Sub
                End If
            End If
            If Me.TxtJobNum.Text = "" Then
                Me.ShowMessage("Please enter a Job Number!")
                Exit Sub
            End If
            If Me.TxtJobCompNum.Text = "" Then
                Me.ShowMessage("Please enter a Component Number!")
                Exit Sub
            End If
            If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
                If IsNumeric(Me.TxtJobNum.Text) = False Or IsNumeric(Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("Job Number and Component must be valid numbers!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompNumber(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("This is not a valid job/component!")
                    Exit Sub
                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then
                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub
                End If

                Dim oSQL As SqlHelper
                Dim SQL_STRING As String
                Dim dr2 As SqlDataReader

                Session("SaveOK") = 0

                SQL_STRING = "SELECT * "
                SQL_STRING &= " FROM CRTV_BRF_DTL "
                SQL_STRING &= " WHERE JOB_NUMBER = " & Me.TxtJobNum.Text & " AND JOB_COMPONENT_NBR = " & Me.TxtJobCompNum.Text

                Try
                    dr2 = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                Catch

                    Err.Raise(Err.Number, "Class:CreativeBrief.ascx Routine:SaveTemplate", Err.Description)
                Finally
                End Try

                If dr2.HasRows = False Then
                    Me.ShowMessage("This Job/Component does not have an existing Creative Brief.")
                    Exit Sub
                End If
            End If

            'tmpcode = Me.ddCBTemplates.Text
            rc = cb.CopyCreativeBriefJobComp("", JobNum, JobCompNum, Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)

            If rc = 1 Then
                Session("CBNewSaved") = 1
            Else
                Session("CBNewSaved") = 0
            End If

            'InjectScriptLabel.Text = "<script>CallFunctionOnParentPage('OpenCreativeBrief');</script>"

            'If Me.CurrentQuerystring.IsJobDashboard = True OrElse Me.IsJobDashboard Then

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "CreativeBrief.aspx"
            qs.JobNumber = JobNum
            qs.JobComponentNumber = JobCompNum
            qs.Add("fw", "ProjectView")
            qs.IsJobDashboard = True
            qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief

            MiscFN.ResponseRedirect(qs.ToString(True), True)

            'Else
            '    If Request.QueryString("fw") = "ProjectView" Then
            '        Me.CloseThisWindowAndOpenNewWindow("CreativeBrief.aspx?JobNo=" & JobNum & "&JobComp=" & JobCompNum & "&fw=ProjectView")
            '    Else
            '        Me.CallFunctionOnParentPage("JobTemplate.aspx", "OpenCreativeBrief();", True)
            '    End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCopyNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopyNew.Click
        Try
            Me.pnlCBNew.Visible = True
            Me.pnlCBCopy.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadLookups()
        Try
            Me.HlClientSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
            Me.HlDivisionSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
            Me.HlProductSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

            Me.HlJob.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=creativebrief&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
            Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=creativebriefjj&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

            Me.TxtClientSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtClientSourceDesc.ClientID & "');ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtDivisionSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtProductSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtJobNum.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub LoadDefaults()
        Try
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper
            Dim scale As Integer

            SQL_STRING = " SELECT JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC,"
            SQL_STRING += " JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION"
            SQL_STRING += " FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN"
            SQL_STRING += " SALES_CLASS ON JOB_LOG.SC_CODE = SALES_CLASS.SC_CODE INNER JOIN"
            SQL_STRING += " PRODUCT ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN"
            SQL_STRING += " DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN"
            SQL_STRING += " CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE"
            SQL_STRING += " WHERE JOB_LOG.JOB_NUMBER = " & Me.JobNum
            SQL_STRING += " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & Me.JobCompNum

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:jobVersions.ascx Routine:AddControl", Err.Description)
            Finally

            End Try

            If dr.HasRows Then
                dr.Read()
                Me.TxtClientSource.Text = dr("CL_CODE")
                Me.TxtClientSourceDesc.Text = dr("CL_NAME")
                Me.TxtDivisionSource.Text = dr("DIV_CODE")
                Me.TxtDivisionSourceDesc.Text = dr("DIV_NAME")
                Me.TxtProductSource.Text = dr("PRD_CODE")
                Me.TxtProductSourceDesc.Text = dr("PRD_DESCRIPTION")
                'Me.TxtJobNum.Text = dr("JOB_NUMBER")
                'Me.TxtJobCompNum.Text = dr("JOB_COMPONENT_NBR")
                'Me.TxtJobDescription.Text = dr("JOB_DESC")
                'Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
            End If
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCopyCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopyCancel.Click
        Try
            Me.pnlCBNew.Visible = True
            Me.pnlCBCopy.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    
End Class