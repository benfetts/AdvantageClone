Imports Webvantage.MiscFN
Imports System.Data.SqlClient

Partial Public Class jobVerNew
    Inherits Webvantage.BaseChildPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private JobVerHdrID As Integer
    Private JobVerCPID As Integer
#End Region

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        If Request.QueryString("JobNum") IsNot Nothing Then Me.JobNum = Request.QueryString("JobNum")
        If Request.QueryString("JobCompNum") IsNot Nothing Then Me.JobCompNum = Request.QueryString("JobCompNum")

        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNum = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobCompNum = Me.CurrentQuerystring.JobComponentNumber

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("NewSaved") = 1 Then
            Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
            With sbScript
                .Append("<script type=""text/javascript"">CallFunctionOnParentPage('HidePopUpWindows');</script>")
            End With
            Try
                If Not Page.IsStartupScriptRegistered("JVNew2") Then
                    Dim str As String = sbScript.ToString
                    Page.RegisterStartupScript("JVNew2", str)
                End If
            Catch ex As Exception
                Me.ShowMessage("Error! " & ex.Message.ToString())
            End Try

        End If


        If Not Page.IsPostBack Then
            Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)
            Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
            Dim desc As String

            desc = MyJV.GetAgencyDesc()
            If desc <> "" Then
                Me.Form.Page.Title = "New " & desc
            End If
            LoadDropDowns()
            Session("NewSaved") = 0
            If Request.QueryString("mode") = "copy" Then
                Me.pnlJVCopy.Visible = True
                Me.pnlJSNew.Visible = False
                Me.PanelJobRequest.Visible = False
                LoadLookups()
                LoadDefaults()
                LoadVersions()
            ElseIf Request.QueryString("mode") = "request" Then
                Me.pnlJVCopy.Visible = False
                Me.PanelJobRequest.Visible = True
                Me.pnlJSNew.Visible = False
                Me.Title = "New Job Request"
                Me.RadComboBoxJobRequest.SelectedValue = a.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_TMPLT)
            Else
                Me.pnlJVCopy.Visible = False
                Me.PanelJobRequest.Visible = False
            End If
            If Me.IsClientPortal = True Then
                Me.HlClientSource.Attributes.Add("onclick", "")
                Me.TxtClientSource.ReadOnly = True
            End If
        End If

    End Sub

    Private Sub LoadDropDowns()
        Dim jv As New JobVersion(Session("ConnString"))

        With Me.ddJVTemplates
            .DataSource = jv.GetJobVerTmplt_dd
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
        End With

        With Me.RadComboBoxJobRequest
            .DataSource = jv.GetJobVerTmplt_dd
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
        End With

    End Sub

    Private Sub LoadVersions()
        Try
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim oSQL As SqlHelper
            Dim scale As Integer

            SQL_STRING = " SELECT JVH.JOB_VER_HDR_ID, JVH.JOB_VER_SEQ_NBR, RTRIM(LTRIM(REPLACE(STR(JVH.JOB_VER_SEQ_NBR, 3), SPACE(1), '0') + ' - ' + JVH.JOB_VER_DESC)) AS JOB_VER_DESC, JOB_VER_TMPLT_HDR.JV_TMPLT_DESC "
            SQL_STRING += " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR ON JVH.JV_TMPLT_CODE = JOB_VER_TMPLT_HDR.JV_TMPLT_CODE"
            SQL_STRING += " WHERE JVH.JOB_NUMBER = " & Me.TxtJobNum.Text
            SQL_STRING += " AND JVH.JOB_COMPONENT_NBR = " & Me.TxtJobCompNum.Text
            SQL_STRING += " ORDER BY JVH.JOB_VER_HDR_ID DESC"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:jobVersions.ascx Routine:AddControl", Err.Description)
            Finally

            End Try

            With Me.ddVersions
                .DataSource = dr
                .DataValueField = "JOB_VER_HDR_ID"
                .DataTextField = "JOB_VER_DESC"
                .DataBind()
            End With
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
                Me.TxtJobNum.Text = dr("JOB_NUMBER")
                Me.TxtJobCompNum.Text = dr("JOB_COMPONENT_NBR")
                Me.TxtJobDescription.Text = dr("JOB_DESC")
                Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
            End If
            dr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveTemplate()

        Dim jv As New JobVersion(Session("ConnString"))
        Dim tmpcode As String
        Dim dr As SqlDataReader

        tmpcode = Me.ddJVTemplates.SelectedValue
        Session("NewSaved") = 1

        If IsClientPortal = True Then

            dr = jv.InsJobVers(JobNum, JobCompNum, tmpcode, "", Session("UserID"))
        Else

            dr = jv.InsJobVers(JobNum, JobCompNum, tmpcode, Session("UserCode"))

        End If

        If dr.HasRows Then

            Dim qs As New AdvantageFramework.Web.QueryString

            dr.Read()

            JobVerHdrID = dr.GetInt32(0)
            JobVerCPID = dr.GetInt32(1)

            Session("JobVerHdrID") = JobVerHdrID

            qs.Page = "jobVerTmplt.aspx"
            qs.Add("JobNum", JobNum)
            qs.Add("JobCompNum", JobCompNum)
            qs.Add("JobVerHdrID", JobVerHdrID)
            qs.JobNumber = JobNum
            qs.JobComponentNumber = JobCompNum
            qs.JobVersionHeaderID = JobVerHdrID
            qs.Add("JobVerCPID", JobVerCPID)
            qs.Add("NewSaved", "1")

            If Me.CurrentQuerystring.IsJobDashboard = True Then

                MiscFN.ResponseRedirect(qs.ToString(True), True)

            Else

                Me.RefreshCaller(qs.ToString(True), True, True, True)

            End If

        End If

    End Sub

    Private Sub SaveJobRequest()

        Dim jv As New JobVersion(Session("ConnString"))
        Dim tmpcode As String
        Dim dr As SqlDataReader

        tmpcode = Me.RadComboBoxJobRequest.SelectedValue
        Session("NewSaved") = 1

        If IsClientPortal = True Then

            dr = jv.InsJobVers(0, 0, tmpcode, "", Session("UserID"))

        Else

            dr = jv.InsJobVers(0, 0, tmpcode, Session("UserCode"))

        End If

        If dr.HasRows Then

            Dim qs As New AdvantageFramework.Web.QueryString

            dr.Read()

            JobVerHdrID = dr.GetInt32(0)
            JobVerCPID = dr.GetInt32(1)

            Session("JobVerHdrID") = JobVerHdrID

            qs.Page = "jobVerTmplt.aspx"

            qs.Add("mode", "request")
            qs.Add("JobNum", JobNum)
            qs.Add("JobCompNum", JobCompNum)
            qs.Add("JobVerHdrID", JobVerHdrID)
            qs.JobNumber = JobNum
            qs.JobComponentNumber = JobCompNum
            qs.JobVersionHeaderID = JobVerHdrID
            qs.Add("JobVerCPID", JobVerCPID)
            qs.Add("NewSaved", "1")

            Me.RefreshCaller(qs.ToString(True), True, True, True)
            'Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)
        End If

    End Sub

    Private Sub LoadData(ByVal job As Integer, ByVal comp As Integer)
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
            SQL_STRING += " WHERE JOB_LOG.JOB_NUMBER = " & job
            SQL_STRING += " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & comp

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
                Me.TxtJobNum.Text = dr("JOB_NUMBER")
                Me.TxtJobCompNum.Text = dr("JOB_COMPONENT_NBR")
                Me.TxtJobDescription.Text = dr("JOB_DESC")
                Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
            End If
            dr.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonNewSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewSave.Click
        SaveTemplate()
    End Sub

    Private Sub ButtonNewSaveRequest_Click(sender As Object, e As EventArgs) Handles ButtonNewSaveRequest.Click
        SaveJobRequest()
    End Sub

    Private Sub LoadLookups()
        If Me.IsClientPortal = True Then
            Me.HlDivisionSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
            Me.HlProductSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

            Me.HlJob.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobversion&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
            Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobversionjj&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

            Me.TxtDivisionSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtProductSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtJobNum.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
        Else
            Me.HlClientSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
            Me.HlDivisionSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
            Me.HlProductSource.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

            Me.HlJob.Attributes.Add("onclick", "ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobversion&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
            Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobvercopy&type=jobversionjj&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")

            Me.TxtClientSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtClientSourceDesc.ClientID & "');ClearTB('" & Me.TxtDivisionSource.ClientID & "');ClearTB('" & Me.TxtDivisionSourceDesc.ClientID & "');ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtDivisionSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtProductSource.ClientID & "');ClearTB('" & Me.TxtProductSourceDesc.ClientID & "');ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtProductSource.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobNum.ClientID & "');ClearTB('" & Me.TxtJobDescription.ClientID & "');ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
            Me.TxtJobNum.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.TxtJobCompNum.ClientID & "');ClearTB('" & Me.TxtJobCompDescription.ClientID & "');")
        End If

    End Sub

    Private Sub ButtonCopySave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopySave.Click
        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim dr As SqlDataReader

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
            End If
            If Me.ddVersions.Items.Count = 0 Then
                Me.ShowMessage("Please select a version!")
                Exit Sub
            End If

            If IsClientPortal = True Then

                dr = jv.CopyJobVers(Me.JobNum, Me.JobCompNum, "", Me.ddVersions.SelectedValue, "", Session("UserID"))

            Else

                dr = jv.CopyJobVers(Me.JobNum, Me.JobCompNum, "", Me.ddVersions.SelectedValue, Session("UserCode"))

            End If

            If dr.HasRows Then

                dr.Read()

                JobVerHdrID = dr.GetInt32(0)
                JobVerCPID = dr.GetInt32(1)

                Session("JobVerHdrID") = JobVerHdrID

            End If

            dr.Close()

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "jobVerTmplt.aspx"

            qs.Add("JobNum", JobNum)
            qs.Add("JobCompNum", JobCompNum)
            qs.Add("JobVerHdrID", JobVerHdrID)
            qs.JobNumber = JobNum
            qs.JobComponentNumber = JobCompNum
            qs.JobVersionHeaderID = JobVerHdrID
            qs.Add("JobVerCPID", JobVerCPID)
            qs.Add("NewSaved", "1")

            If Me.CurrentQuerystring.IsJobDashboard = True Then

                MiscFN.ResponseRedirect(qs.ToString(True), True)

            Else

                'Me.RefreshCaller(qs.ToString(True), True, True, True)
                Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)

            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGetVersions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetVersions.Click
        Try
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
            End If

            LoadVersions()
            LoadData(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text)
            Me.ddVersions.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonNewCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNewCopy.Click
        Try
            Me.pnlJSNew.Visible = False
            Me.pnlJVCopy.Visible = True
            LoadDefaults()
            LoadLookups()
            LoadVersions()
            Me.TxtJobNum.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonCopyNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopyNew.Click
        Try
            Me.pnlJSNew.Visible = True
            Me.pnlJVCopy.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonCopyCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCopyCancel.Click
        Try
            Me.pnlJSNew.Visible = True
            Me.pnlJVCopy.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButtonNewCancel_Click(sender As Object, e As EventArgs) Handles ButtonNewCancel.Click
        Me.CloseThisWindow()
    End Sub
End Class
