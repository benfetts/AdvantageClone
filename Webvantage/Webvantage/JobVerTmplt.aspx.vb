Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports Webvantage.cGlobals
Imports System.Drawing
Imports Telerik.Web.UI
Imports System.Collections.Generic

Partial Public Class JobVerTmplt
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _SqlHelper As SqlHelper

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _JobVersionHeaderID As Integer = 0
    Private _JobVersionClientPortalID As Integer = 0
    Private _CopyJobVersionHeaderID As Integer = 0
    Private _TemplateCode As String = String.Empty
    Private _DataReader As SqlDataReader
    Private _RadioGroupNameIndex As Integer = 0
    Private _Sql As String = String.Empty
    Private _SqlUpdate As String = String.Empty
    Private _VersionNumber As Integer = 0
    Private _HasJob As Boolean = False
    Private _VersionJobNumber As Integer = 0
    Private _IsValid As Boolean = True
    Private _AdvanDtype As New Dictionary(Of Integer, Integer)

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Property _PageTitle As String
        Get

            If ViewState("_PageTitle") Is Nothing Then ViewState("_PageTitle") = ""
            Return ViewState("_PageTitle")

        End Get
        Set(value As String)

            ViewState("_PageTitle") = value

        End Set
    End Property
    Private Property _BookmarkTitle As String
        Get

            If ViewState("_BookmarkTitle") Is Nothing Then ViewState("_BookmarkTitle") = ""
            Return ViewState("_BookmarkTitle")

        End Get
        Set(value As String)

            ViewState("_BookmarkTitle") = value

        End Set
    End Property
    Private Property _BookmarkDescription As String
        Get

            If ViewState("_BookmarkDescription") Is Nothing Then ViewState("_BookmarkDescription") = ""
            Return ViewState("_BookmarkDescription")

        End Get
        Set(value As String)

            ViewState("_BookmarkDescription") = value

        End Set
    End Property
    Private Property _IsRequest As Boolean
        Get

            If ViewState("_IsRequest") Is Nothing Then ViewState("_IsRequest") = False
            Return CType(ViewState("_IsRequest"), Boolean)

        End Get
        Set(value As Boolean)

            ViewState("_IsRequest") = value

        End Set
    End Property
    Private Property _IsRequestToForm As Boolean
        Get

            If ViewState("_IsRequestToForm") Is Nothing Then ViewState("_IsRequestToForm") = False
            Return CType(ViewState("_IsRequestToForm"), Boolean)

        End Get
        Set(value As Boolean)

            ViewState("_IsRequestToForm") = value

        End Set
    End Property
    Private ReadOnly Property _VersionsAlias As String
        Get

            Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
            _VersionsAlias = MyJV.GetAgencyDesc()

        End Get
    End Property
    Private Property _IsNewSave As Boolean
        Get

            If ViewState("_IsNewSave") Is Nothing Then ViewState("_IsNewSave") = False
            Return CType(ViewState("_IsNewSave"), Boolean)

        End Get
        Set(value As Boolean)

            ViewState("_IsNewSave") = value

        End Set
    End Property
    Private Property _HasSaved As Boolean
        Get

            If ViewState("_HasSaved") Is Nothing Then ViewState("_HasSaved") = False
            Return CType(ViewState("_HasSaved"), Boolean)

        End Get
        Set(value As Boolean)

            ViewState("_HasSaved") = value

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarJobVersionTemplate_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobVersionTemplate.ButtonClick
        Select Case e.Item.Value
            Case "Save"

                Try

                    If SaveTemplate() = True Then

                        'Me.RefreshJobRequestObjects("DesktopMyJobRequests")
                        'Me.RefreshJobRequestObjects("DesktopJobRequests")

                        If Me._IsRequest And _IsValid = True Then

                            Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
                            Dim notification As String = a.GetValue(AdvantageFramework.Agency.Settings.JR_ALERT_SETTING, "")
                            If notification = "Alert" Then
                                SendAlert()
                            ElseIf notification = "Assignment" And Me.IsClientPortal = False Then
                                SendAlert(False, True)
                            Else
                                SendAlert()
                            End If

                        End If
                        If Me._IsRequestToForm And _IsValid = True Then
                            Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
                            Dim notification As String = a.GetValue(AdvantageFramework.Agency.Settings.JR_ALERT_SETTING, "")
                            If Me.JobNbrRequest.Text = "" And Me.CompNbrRequest.Text = "" Then
                                If notification = "Alert" Then
                                    SendAlert()
                                ElseIf notification = "Assignment" And Me.IsClientPortal = False Then
                                    SendAlert(False, True)
                                Else
                                    SendAlert()
                                End If
                            Else
                                Me.RefreshCaller("JobRequest_Search.aspx")
                            End If

                        End If

                    End If

                Catch ex As Exception
                    Me.ShowMessage("Error! " & ex.Message.ToString())
                End Try

            Case "Delete"

                Session("JobVerHdrIDCopy") = ""
                DeleteVersion()

                Dim SQL_STRING As String
                Dim dr As SqlDataReader
                Dim oSQL As SqlHelper
                Dim scale As Integer

                SQL_STRING = " SELECT JVH.JOB_VER_HDR_ID, JVH.JOB_VER_SEQ_NBR, JVH.JOB_VER_DESC, JOB_VER_TMPLT_HDR.JV_TMPLT_DESC "
                SQL_STRING += " FROM JOB_VER_HDR JVH INNER JOIN JOB_VER_TMPLT_HDR ON JVH.JV_TMPLT_CODE = JOB_VER_TMPLT_HDR.JV_TMPLT_CODE"
                SQL_STRING += " WHERE JVH.JOB_NUMBER = " & _JobNumber
                SQL_STRING += " AND JVH.JOB_COMPONENT_NBR = " & _JobComponentNumber

                Try
                    dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                Catch
                    Err.Raise(Err.Number, "Class:jobVersions.ascx Routine:AddControl", Err.Description)
                Finally

                End Try

                Dim StrURL As String = ""
                If dr.HasRows = True Then
                    StrURL = "jobVersions.aspx?JobNum=" & _JobNumber.ToString() & "&JobCompNum=" & _JobComponentNumber.ToString()
                Else
                    StrURL = "jobVersions.aspx?newfrom=jvt&JobNum=" & _JobNumber.ToString() & "&JobCompNum=" & _JobComponentNumber.ToString()
                End If

                Try

                    dr.Close()
                    dr.Dispose()

                Catch ex As Exception

                End Try
                Me.RefreshCaller("JobRequest_Search.aspx")
                Me.CloseThisWindowAndRefreshCaller(StrURL, True)


                '' ''Case "Print"
                '' ''    'Save first
                '' ''    Try
                '' ''        SaveTemplate()
                '' ''        If Me.lblRequired.Visible = True Then
                '' ''            Exit Sub
                '' ''        End If
                '' ''        refreshHeader()
                '' ''    Catch ex As Exception
                '' ''        Me.ShowMessage("Error! " & ex.Message.ToString())
                '' ''    End Try
                '' ''    Dim cl, div, prd As String
                '' ''    Dim ojf As New cJobFunctions(Session("ConnString"))
                '' ''    If ojf.GetCliDivProdFromJob(JobNum, JobCompNum, cl, div, prd) = True Then
                '' ''        Me.OpenWindow("", "JobVersionPrint.aspx?client=" & cl & "&division=" & div & "&product=" & prd & "&Job=" & JobNum & "&JobComp=" & JobCompNum & "&JobVerHdrID=" & JobVerHdrID & "&seq=" & Session("versionNbr") & "&fromapp=jobVerTmplt")
                '' ''    End If

            Case "Print"

                If SaveTemplate() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "JobVersion_Print.aspx"
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.JobVersionHeaderID = Me._JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                    If Me._IsRequest And _IsValid = True Then

                        qs.Add("fromapp", "request")

                    Else

                        qs.Add("fromapp", "jobVerTmplt")

                    End If


                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendAlert"

                If SaveTemplate() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "JobVersion_Print.aspx"
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.JobVersionHeaderID = Me._JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")
                    qs.Add("fromapp", "jobVerTmplt")
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                    qs.Add("content", "1")

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendAssignment"

                If SaveTemplate() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "JobVersion_Print.aspx"
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.JobVersionHeaderID = Me._JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")
                    qs.Add("fromapp", "jobVerTmplt")
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                    qs.Add("content", "1")

                    Me.OpenPrintSendSilently(qs)

                End If

            Case "SendEmail"

                If SaveTemplate() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "JobVersion_Print.aspx"
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.JobVersionHeaderID = Me._JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")
                    qs.Add("fromapp", "jobVerTmplt")
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)
                    qs.Add("content", "1")

                    'Me.OpenWindow(qs)
                    Me.OpenPrintSendSilently(qs)

                End If

            Case "PrintSendOptions"

                If SaveTemplate() = True Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs.Page = "JobVersion_Print.aspx"
                    qs.JobNumber = Me._JobNumber
                    qs.JobComponentNumber = Me._JobComponentNumber
                    qs.JobVersionHeaderID = Me._JobVersionHeaderID
                    qs.JobVersionSequenceNumber = Session("versionNbr")
                    qs.Add("fromapp", "jobVerTmplt")
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                    Me.OpenWindow(qs)

                End If

            Case "Refresh"

                Me.LoadJobVersion()

            Case "Copy"

                If SaveTemplate() = True Then

                    Dim jv As New JobVersion(Session("ConnString"))
                    _DataReader = jv.CopyJobVers(Me._JobNumber, Me._JobComponentNumber, "", Me._JobVersionHeaderID, Session("UserCode"))

                    If _DataReader.HasRows Then

                        _DataReader.Read()
                        _JobVersionHeaderID = _DataReader.GetValue(0)

                    End If

                    _DataReader.Close()

                    MiscFN.ResponseRedirect("jobVerTmplt.aspx?JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber & "&JobVerHdrID=" & _JobVersionHeaderID & "&NewSaved=1")

                End If

            Case "Cancel"

                Me.CloseThisWindow()

            Case "CreateJob"

                If Me._JobVersionHeaderID > 0 Then Me.CloseThisWindowAndOpenNewWindow("JobTemplate_New.aspx?from=jobrequest&JobVerHdrID=" & Me._JobVersionHeaderID.ToString(), True)

            Case "CreateComponent"

                If Me._JobVersionHeaderID > 0 Then Me.CloseThisWindowAndOpenNewWindow("JobTemplate_NewComponent.aspx?from=jobrequest&JobVerHdrID=" & Me._JobVersionHeaderID.ToString(), True)

            Case "Bookmark"

                If Me.SaveTemplate() = True Then

                    Dim s As String = String.Empty
                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me._Session.ConnectionString, Me._Session.UserCode)
                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs = qs.FromCurrent()
                    qs.Page = "jobVerTmplt.aspx"

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.JobVersionTemplate_Detail
                        .UserCode = Me._Session.UserCode
                        .Name = Me._BookmarkTitle
                        .PageURL = qs.ToString(True).Replace("jobVerTmplt", "JobVerTmplt")
                        .Description = Me._BookmarkDescription

                    End With

                    If BmMethods.SaveBookmark(b, s) = False Then

                        If String.IsNullOrWhiteSpace(s) = False Then

                            Me.ShowMessage(s)

                        Else

                            Me.ShowMessage("Failed to save bookmark")

                        End If

                    Else

                        'Me.RefreshBookmarksDesktopObject()

                    End If

                End If

        End Select

    End Sub

#End Region
#Region " Page "

    Private Sub JobVerTmplt_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions)

        If Request.QueryString("JobNum") IsNot Nothing And Request.QueryString("JobNum") <> "" Then Me._JobNumber = CType(Request.QueryString("JobNum"), Integer)
        If Request.QueryString("JobCompNum") IsNot Nothing And Request.QueryString("JobCompNum") <> "" Then Me._JobComponentNumber = CType(Request.QueryString("JobCompNum"), Integer)
        If Request.QueryString("JobVerHdrID") IsNot Nothing Then Me._JobVersionHeaderID = CType(Request.QueryString("JobVerHdrID"), Integer)
        If Request.QueryString("JobVerCPID") IsNot Nothing Then Me._JobVersionClientPortalID = CType(Request.QueryString("JobVerCPID"), Integer)

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me._JobNumber = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me._JobComponentNumber = qs.JobComponentNumber
        If qs.JobVersionHeaderID > 0 Then Me._JobVersionHeaderID = qs.JobVersionHeaderID

        If IsNumeric(qs.Get("JobVerCPID")) = True Then Me._JobVersionClientPortalID = CType(qs.Get("JobVerCPID"), Integer)

        If Request.QueryString("mode") IsNot Nothing Then

            Select Case Request.QueryString("mode").ToString()
                Case "request"

                    Me._IsRequest = True

                Case "requesttoform"

                    Me._IsRequestToForm = True

            End Select

        End If

        Try

            If Me.IsPostBack = False AndAlso Me.IsCallback = False Then

                Me._IsNewSave = qs.GetValue("NewSaved") = "1"

            End If

        Catch ex As Exception
        End Try

        If Me._HasSaved = True Then Me._IsNewSave = False

        LoadJobVersion()

        If Me.IsClientPortal = True Then

            If Me._JobVersionClientPortalID = 0 Then

                Me.RadToolbarJobVersionTemplate.Items(0).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(1).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(2).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(3).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(4).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(5).Visible = False
                Me.TextBoxVersionDescription.ReadOnly = True

            Else

                Me.RadToolbarJobVersionTemplate.Items(2).Visible = False
                Me.RadToolbarJobVersionTemplate.Items(3).Visible = False

            End If

        End If

        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        _VersionJobNumber = MyJV.GetJVjob(Me._JobVersionHeaderID)

        If _VersionJobNumber <> 0 Then

            Me.PanelHDR.Visible = True
            Me.PanelHeaderRequest.Visible = False
            _HasJob = True

            RadToolBarButtonCreateJob.Visible = False
            RadToolBarButtonCreateComponent.Visible = False

        ElseIf Me._IsRequest Then

            Me.PanelHDR.Visible = False
            Me.PanelHeaderRequest.Visible = True
            Me.Title = "New Job Request"

            If Me.IsClientPortal = True Then

                Me.txtClient.Text = Session("CL_CODE")
                Me.txtClient.ReadOnly = True
                Me.hlDivision.Attributes.Add("onclick", "ClearTB('" & Me.txtProduct.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobnew&type=division&control=" & Me.txtDivision.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequest&type=product&control=" & Me.txtProduct.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.txtDivision.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtProduct.ClientID & "');")

            Else

                Me.hlClient.Attributes.Add("onclick", "ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobreq&control=" & Me.txtClient.ClientID & "&type=client&ddtype=client');return false;")
                Me.hlDivision.Attributes.Add("onclick", "ClearTB('" & Me.txtProduct.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobnew&type=division&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequest&type=product&control=" & Me.txtProduct.ClientID & "&office=&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.txtClient.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtDivision.ClientID & "');ClearTB('" & Me.txtProduct.ClientID & "');")
                Me.txtDivision.Attributes.Add("onkeyup", "javascript:ClearTB('" & Me.txtProduct.ClientID & "');")

            End If

            Me.lbJob.Attributes.Add("onclick", "")
            Me.lbComponent.Attributes.Add("onclick", "")
            Me.lbJob.Enabled = False
            Me.lbComponent.Enabled = False
            Me.JobNbrRequest.Enabled = False
            Me.CompNbrRequest.Enabled = False
            Me.TxtJobNum.Enabled = False
            Me.TxtJobCompNum.Enabled = False

            Me.DivRequestTemplate.Visible = False

            Me.RadToolBarButtonCreateJob.Visible = False
            Me.RadToolBarButtonCreateComponent.Visible = False
            Me.RadToolBarButtonCopy.Visible = False
            Me.RadToolBarButtonPrintSend.Visible = False
            Me.RadToolBarButtonSep3.Visible = False
            Me.RadToolBarButtonBookmark.Visible = False

        ElseIf Me._IsRequestToForm Then

            Me.PanelHDR.Visible = False
            Me.PanelHeaderRequest.Visible = True
            Me.Title = "Job Request"

            If Me.IsClientPortal = True Then

                Me.txtClient.Text = Session("CL_CODE")
                Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobnew&type=division&control=" & Me.txtDivision.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequest&type=product&control=" & Me.txtProduct.ClientID & "&client=" & Session("CL_CODE") & "&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.RadToolbarJobVersionTemplate.Items(1).Visible = True
                Me.RadToolbarJobVersionTemplate.Items(2).Visible = True
                Me.lbJob.Attributes.Add("onclick", "")
                Me.lbComponent.Attributes.Add("onclick", "")
                Me.lbJob.Enabled = False
                Me.lbComponent.Enabled = False
                Me.JobNbrRequest.Enabled = False
                Me.CompNbrRequest.Enabled = False
                Me.TxtJobNum.Enabled = False
                Me.TxtJobCompNum.Enabled = False

            Else

                Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobreq&control=" & Me.txtClient.ClientID & "&type=client&ddtype=client');return false;")
                Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobnew&type=division&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobrequest&type=product&control=" & Me.txtProduct.ClientID & "&office=&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
                Me.lbJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?office=&salesclass=&form=jobrequestjob&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.JobNbrRequest.ClientID & ".value);return false;")
                Me.lbComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?office=&salesclass=&form=jobrequestjob&type=jobcompjj&control=" & Me.CompNbrRequest.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.JobNbrRequest.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.CompNbrRequest.ClientID & ".value);return false;")

            End If

            Me.RadToolBarButtonCreateJob.Visible = True
            Me.RadToolBarButtonCreateComponent.Visible = True
            Me.RadToolBarButtonCopy.Visible = False
            Me.RadToolBarButtonPrintSend.Visible = False
            Me.RadToolBarButtonSep3.Visible = False
            Me.RadToolBarButtonBookmark.Visible = False

            SetButtonVisibility()

        End If

        If Me.IsClientPortal = True Then

            Me.RadToolBarButtonSendAssignment.Visible = False
            Me.RadToolBarButtonCreateJob.Visible = False
            Me.RadToolBarButtonCreateComponent.Visible = False
            Me.RadToolBarButtonBookmark.Visible = False

        End If

    End Sub
    Protected Sub JobVerTmplt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData()
            If cpd.Load() = True Then

                cpd.JobVersionHeaderID = Me._JobVersionHeaderID
                cpd.Save()

            End If

            If (Me._IsRequest = True OrElse Me._IsRequestToForm) Then
                Me.RadToolbarJobVersionTemplate.FindItemByValue("Bookmark").Visible = False
            Else
                Me.RadToolbarJobVersionTemplate.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
            End If

            Webvantage.MiscFN.SetFocus(Me.TextBoxVersionDescription)

        End If

    End Sub
    Private Sub JobVerTmplt_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If (Me._IsRequest = True OrElse Me._IsRequestToForm) AndAlso _HasJob = True Then

            Dim Alerts As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim JobCompDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByJobVersionID(DbContext, Me._JobVersionHeaderID).ToList

                    If Not Alerts Is Nothing Then

                        Dim JobNumber As Integer = 0
                        Dim JobComponentNumber As Short = 0

                        Try

                            If IsNumeric(Me.TxtJobNum.Text) = True Then

                                JobNumber = CType(Me.TxtJobNum.Text, Integer)

                            End If

                        Catch ex As Exception
                            JobNumber = 0
                        End Try
                        Try

                            If IsNumeric(Me.TxtJobCompNum.Text) = True Then

                                JobComponentNumber = CType(Me.TxtJobCompNum.Text, Short)

                            End If

                        Catch ex As Exception
                            JobComponentNumber = 0
                        End Try
                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            For Each ar In Alerts

                                ar.JobNumber = JobNumber
                                ar.JobComponentNumber = JobComponentNumber
                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, ar)

                                If ar.AlertAttachments.Count > 0 Then

                                    For Each AlertAttachment In ar.AlertAttachments

                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                        If Document IsNot Nothing Then

                                            JobCompDocument = New AdvantageFramework.Database.Entities.JobComponentDocument
                                            JobCompDocument.DbContext = DbContext
                                            JobCompDocument.DocumentID = Document.ID
                                            JobCompDocument.JobComponentNumber = JobComponentNumber
                                            JobCompDocument.JobNumber = JobNumber

                                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                                AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobCompDocument)

                                            End Using

                                        End If

                                        Document = Nothing
                                        JobCompDocument = Nothing

                                    Next

                                End If

                            Next

                        End If

                    End If

                    Dim jv As New JobVersion(Session("ConnString"))
                    jv.UpdateJobTemplatePerJVMapping(Me._JobVersionHeaderID, "job")

                End Using

            Catch ex As Exception
            End Try
            Try

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "Content.aspx"
                qs.JobNumber = Me.TxtJobNum.Text
                qs.JobComponentNumber = Me.TxtJobCompNum.Text
                qs.JobVersionHeaderID = Me._JobVersionHeaderID
                qs.Add("JobVerCPID", Me._JobVersionClientPortalID.ToString())
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion
                'Dim strURL As String = "jobVerTmplt.aspx?JobNum=" & Me.TxtJobNum.Text & "&JobCompNum=" & Me.TxtJobCompNum.Text & "&JobVerHdrID=" & Me.JobVerHdrID.ToString() & "&JobVerCPID=" & Me.JobVerCPID.ToString()
                Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True), True)

            Catch ex As Exception
            End Try
            Try

                Dim strURL As String = "jobVerTmplt.aspx?JobNum=" & Me.TxtJobNum.Text & "&JobCompNum=" & Me.TxtJobCompNum.Text & "&JobVerHdrID=" & Me._JobVersionHeaderID.ToString() & "&JobVerCPID=" & Me._JobVersionClientPortalID.ToString()
                Me.CloseThisWindowAndOpenNewWindow(strURL, True)

            Catch ex As Exception
            End Try

        End If
    End Sub

#End Region

    Private Sub LoadJobVersion()

        Dim JobVersion As New JobVersion(Session("ConnString"))
        Dim DataReader As SqlDataReader
        Dim JobDescription As String = String.Empty
        Dim ComponentDescription As String = String.Empty
        Dim JobVersionDescription As String = String.Empty
        Dim JobVersionTemplateDescription As String = String.Empty

        'Populate Header
        If (Me._IsRequest = True OrElse Me._IsRequestToForm = True) AndAlso _HasJob = False Then

            DataReader = JobVersion.GetJVRequestDescriptions(_JobVersionHeaderID)

            If DataReader.HasRows Then

                DataReader.Read()

                'CDP
                If IsDBNull(DataReader("CL_CODE")) = False Then Me.txtClient.Text = DataReader.GetString(0)
                If IsDBNull(DataReader("CL_NAME")) = False Then Me.TxtClientDescription.Text = DataReader.GetString(1)
                If IsDBNull(DataReader("DIV_CODE")) = False Then Me.txtDivision.Text = DataReader.GetString(2)
                If IsDBNull(DataReader("DIV_NAME")) = False Then Me.TxtDivisionDescription.Text = DataReader.GetString(3)
                If IsDBNull(DataReader("PRD_CODE")) = False Then Me.txtProduct.Text = DataReader.GetString(4)
                If IsDBNull(DataReader("PRD_DESCRIPTION")) = False Then Me.TxtProductDescription.Text = DataReader.GetString(5)

                'Job Version Nbr/Desc
                If IsDBNull(DataReader.GetValue(8)) = False Then

                    _VersionNumber = DataReader.GetValue(8)
                    Session("versionNbr") = DataReader.GetValue(8)

                End If

                Me.lblVersionRequest.Text = "Job Request:"

                If IsDBNull(DataReader.GetValue(6)) = False Then

                    Me.VersionDescRequest.Text = DataReader.GetString(6)
                    Session("JVDescription") = DataReader.GetString(6)

                End If
                'If String.IsNullOrWhiteSpace(Me.VersionDescRequest.Text) = True Then

                '                If Me._IsNewSave = False Then

                '                    Me.VersionDescRequest.CssClass = "required-missing"

                '                Else

                '                End If

                '            End If
                If IsDBNull(DataReader.GetString(9)) Then

                    Me.TmpltCodeRequest.Text = ""

                Else

                    Me.TmpltCodeRequest.Text = DataReader.GetString(9)

                End If

                If IsDBNull(DataReader.GetString(7)) = False Then

                    Me.TmpltCodeRequest.Text = Me.TmpltCodeRequest.Text & " - " & DataReader.GetString(7)
                    Session("JVTemplateName") = AdvantageFramework.StringUtilities.FileSystemFilenameAndPathSafe(DataReader.GetString(7))

                End If

            End If

        Else

            DataReader = JobVersion.GetJVDescriptions(_JobNumber, _JobComponentNumber, _JobVersionHeaderID)

            If DataReader IsNot Nothing AndAlso DataReader.HasRows Then

                Dim TitleToUse As String = String.Empty

                DataReader.Read()

                If IsDBNull(DataReader.GetString(0)) Then

                    Me.LabelJob.Text = Me._JobNumber.ToString.PadLeft(6, "0")

                Else

                    Me.LabelJob.Text = Me._JobNumber.ToString.PadLeft(6, "0") & " - " & DataReader.GetString(0)

                End If
                If IsDBNull(DataReader.GetString(1)) Then

                    Me.LabelJobComponent.Text = Me._JobComponentNumber.ToString.PadLeft(3, "0")

                Else

                    Me.LabelJobComponent.Text = Me._JobComponentNumber.ToString.PadLeft(3, "0") & " - " & DataReader.GetString(1)

                End If
                If IsDBNull(DataReader.GetValue(4)) = False Then

                    _VersionNumber = DataReader.GetValue(4)
                    Me.LabelVersionNumber.Text = _VersionNumber.ToString.PadLeft(3, "0")
                    Session("versionNbr") = DataReader.GetValue(4)

                End If

                'Me.lblVersion.Text = JobVersion.GetAgencyDesc() & ":"

                If IsDBNull(DataReader.GetValue(2)) = False Then

                    Me.TextBoxVersionDescription.Text = DataReader.GetString(2)
                    Session("JVDescription") = DataReader.GetString(2)

                End If
                If String.IsNullOrWhiteSpace(Me.TextBoxVersionDescription.Text) = True Then

                    If Me._IsNewSave = False Then

                        Me.TextBoxVersionDescription.CssClass = "required-missing"

                    Else

                        Me.TextBoxVersionDescription.CssClass = "RequiredInput"

                    End If

                Else

                    Me.TextBoxVersionDescription.CssClass = "RequiredInput"

                End If
                If IsDBNull(DataReader.GetString(5)) Then

                    Me.LabelTemplate.Text = ""

                Else

                    Me.LabelTemplate.Text = DataReader.GetString(5)

                    TitleToUse = DataReader.GetString(5)

                End If
                If IsDBNull(DataReader.GetString(3)) = False Then

                    Me.LabelTemplate.Text = Me.LabelTemplate.Text & " - " & DataReader.GetString(3)

                    TitleToUse = DataReader.GetString(3)


                End If

                Me._PageTitle = String.Format("{0}: {1}, v.{2} for Job: {3}/{4}",
                                              Me._VersionsAlias,
                                              TitleToUse,
                                              Me.LabelVersionNumber.Text,
                                              Me._JobNumber.ToString().PadLeft(6, "0"),
                                              Me.LabelJobComponent.Text)

                Me._BookmarkTitle = String.Format("{0}/{1} - {2}: {3}, v.{4}",
                                                  Me._JobNumber.ToString().PadLeft(6, "0"),
                                                  Me._JobComponentNumber.ToString().PadLeft(3, "0"),
                                                  Me._VersionsAlias,
                                                  TitleToUse,
                                                  Me.LabelVersionNumber.Text)

                Me._BookmarkDescription = String.Format("{0}: {1} - {2}, v.{3}, for Job: {4}/{5}",
                                                        Me._VersionsAlias,
                                                        TitleToUse,
                                                        Me.TextBoxVersionDescription.Text,
                                                        Me.LabelVersionNumber.Text,
                                                        Me._JobNumber.ToString().PadLeft(6, "0"),
                                                        Me.LabelJobComponent.Text)

            End If

        End If

        If String.IsNullOrEmpty(Me._PageTitle) = True Then

            Me._PageTitle = _VersionsAlias & " Detail for Job/Comp: " & Me._JobNumber.ToString.PadLeft(6, "0") & "/" & Me._JobComponentNumber.ToString.PadLeft(3, "0")

        End If
        If String.IsNullOrEmpty(Me._BookmarkTitle) = True Then

            Me._BookmarkTitle = Me._PageTitle

        End If

        Me.PageTitle = Me._PageTitle

        'Details
        Dim JobVersionTemplateDetailID As Integer = 0
        Dim AdvantageDataTypeID As Integer = 0
        Dim JobVersionDataTypeID As Integer = 0
        Dim LabelText As String = String.Empty
        Dim TheValue As Object
        Dim ItemOrder As Integer = 0
        Dim IsRequired As Boolean = False
        Dim Instruction As String = String.Empty
        Dim Precision As Integer = 0
        Dim Scale As Integer = 0
        Dim IsDateWithDefault As Boolean = False

        PlaceHolderDetails.Controls.Clear()
        DataReader = JobVersion.GetJobVersDtl(Me._JobVersionHeaderID)

        Dim HasSection As Boolean = False
        If DataReader.HasRows Then

            Dim SectionPanel As eWorld.UI.CollapsablePanel = Nothing

            Do While DataReader.Read

                JobVersionTemplateDetailID = DataReader.GetValue(DataReader.GetOrdinal("JobVersionTemplateDetailID"))

                Try

                    LabelText = DataReader.GetValue(DataReader.GetOrdinal("JobVersionTemplateLabel"))

                Catch ex As Exception
                    LabelText = String.Empty
                End Try

                TheValue = Nothing
                If IsDBNull(DataReader.GetValue(DataReader.GetOrdinal("JobVersionValue"))) = False Then

                    TheValue = DataReader.GetValue(DataReader.GetOrdinal("JobVersionValue"))

                End If
                Try

                    AdvantageDataTypeID = DataReader.GetValue(DataReader.GetOrdinal("AdvantageDataTypeID"))

                Catch ex As Exception
                    AdvantageDataTypeID = 0
                End Try
                Try

                    JobVersionDataTypeID = DataReader.GetValue(DataReader.GetOrdinal("JobVersionDataTypeID"))

                Catch ex As Exception
                    JobVersionDataTypeID = 0
                End Try
                Try

                    ItemOrder = DataReader.GetValue(DataReader.GetOrdinal("JobVersionTemplateOrder"))

                Catch ex As Exception
                    ItemOrder = 0
                End Try
                Try

                    IsRequired = DataReader.GetValue(DataReader.GetOrdinal("JobVersionTemplateIsRequired"))

                Catch ex As Exception
                    IsRequired = False
                End Try
                Try

                    Instruction = DataReader.GetValue(DataReader.GetOrdinal("JobVersionTemplateDetailInstructions"))

                Catch ex As Exception
                    Instruction = String.Empty
                End Try
                Try

                    Precision = DataReader.GetValue(DataReader.GetOrdinal("JobVersionDataTypePrecision"))

                Catch ex As Exception
                    Precision = 0
                End Try
                Try

                    Scale = DataReader.GetValue(DataReader.GetOrdinal("JobVersionDataTypeScale"))

                Catch ex As Exception
                    Scale = 0
                End Try
                Try

                    IsDateWithDefault = DataReader.GetValue(DataReader.GetOrdinal("IsDateWithDefault"))

                Catch ex As Exception
                    IsDateWithDefault = False
                End Try
                If DataReader.GetValue(DataReader.GetOrdinal("IsSection")) = True Then

                    HasSection = True

                    SectionPanel = New eWorld.UI.CollapsablePanel
                    SectionPanel.TitleText = LabelText
                    SectionPanel.ID = String.Format("colpnl_{0}_{1}", JobVersionTemplateDetailID, LabelText.Replace(" ", ""))

                    Me.PlaceHolderDetails.Controls.Add(SectionPanel)

                Else

                    AddControl(SectionPanel, JobVersionTemplateDetailID, TheValue, AdvantageDataTypeID, JobVersionDataTypeID, LabelText, ItemOrder, IsRequired, Instruction, Precision, Scale, IsDateWithDefault)

                End If

            Loop

        End If

        Try

            DataReader.Close()
            DataReader.Dispose()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub AddControl(ByVal CollapsablePanel As eWorld.UI.CollapsablePanel, ByVal JobVersionTemplateDetailID As Integer, ByVal TheValue As Object, ByVal AdvantageDataTypeID As Integer, ByVal JobVersionDataTypeID As Integer,
                           ByVal LableText As String, ByVal Order As Integer, ByVal IsRequired As Boolean, ByVal Instruction As String, ByVal Precision As Integer, ByVal Scale As Integer, ByVal IsDateWithDefault As Boolean)

        Dim MyLabel As New System.Web.UI.WebControls.Label
        Dim MyRequiredLabel As New System.Web.UI.WebControls.Label
        Dim MyTextBox As New System.Web.UI.WebControls.TextBox
        Dim MyCheckBox As New CheckBox
        Dim MyRadioButtonYes As New System.Web.UI.WebControls.RadioButton
        Dim MyRadioButtonNo As New System.Web.UI.WebControls.RadioButton
        Dim MyImageButton As New System.Web.UI.WebControls.ImageButton
        Dim MyMultiLineRadTextBox As New Telerik.Web.UI.RadTextBox With {.TextMode = InputMode.MultiLine}
        Dim MyRadEditor As New Telerik.Web.UI.RadEditor
        Dim MyLieteral As New Literal
        Dim MyCalendarLiteral As New Literal
        Dim MyRadComboBox As New Telerik.Web.UI.RadComboBox
        Dim MyRequiredFieldValidator As New RequiredFieldValidator
        Dim CommonWebControl As System.Web.UI.WebControls.WebControl = Nothing

        Dim StringValue As String = String.Empty
        Dim ValueString As String = String.Empty
        Dim DateValue As Date

        Dim RowSpacer As String = "&nbsp;&nbsp;"
        Dim OpenSpacerTable As String = "<table width=""100%"" border=""0"" cellpadding=""2"" cellspacing=""0"" align=""left""><tr><td width=""210"" align=""right"" valign=""top"" class=""tdpad"">"
        Dim OpenSpacerRCBTable As String = "<table width=""100%"" border=""0"" cellpadding=""2"" cellspacing=""0"" align=""left""><tr><td width=""210"" align=""right"" valign=""center"" class=""tdpad"">"
        Dim MiddleSpacerTable As String = "</td><td width=""1"" align=""center"" valign=""middle"" class=""tdpad"">&nbsp;</td><td align=""left"" valign=""top"" class=""tdpad"">"
        Dim CloseSpacerTable As String = "</td></tr></table><br />"

        MyRadEditor.Height = New Unit(310, UnitType.Pixel)
        MyRadEditor.ToolsFile = "~/RadEditorToolbars.xml"
        MyRadEditor.NewLineBr = True
        MyRadEditor.NewLineMode = EditorNewLineModes.Br
        MyRadEditor.OnClientLoad = "RadEditorOnClientLoad"
        MyRadEditor.OnClientCommandExecuted = "RadEditorOnClientCommandExecuted"
        MyRadEditor.ContentAreaCssFile = "~/CSS/RadEditorContentArea.min.css"
        MyRadEditor.Width = New Unit(98, UnitType.Percentage)
        MyRadEditor.EditModes = EditModes.Design
        MyRadEditor.ContentAreaMode = EditorContentAreaMode.Div
        MyRadEditor.StripFormattingOptions = EditorStripFormattingOptions.MSWord

        If CollapsablePanel IsNot Nothing Then

            If JobVersionDataTypeID = 11 Or AdvantageDataTypeID = 4 Or AdvantageDataTypeID = 2 Or AdvantageDataTypeID = 3 Or AdvantageDataTypeID = 5 Then
                CollapsablePanel.Controls.Add(MiscFN.NewLiteral(OpenSpacerRCBTable))
            Else
                CollapsablePanel.Controls.Add(MiscFN.NewLiteral(OpenSpacerTable))
            End If

        Else

            If JobVersionDataTypeID = 11 Or AdvantageDataTypeID = 4 Or AdvantageDataTypeID = 2 Or AdvantageDataTypeID = 3 Or AdvantageDataTypeID = 5 Then
                PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(OpenSpacerRCBTable))
            Else
                PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(OpenSpacerTable))
            End If

        End If

        ' Add the label and Text
        If CollapsablePanel IsNot Nothing Then

            CollapsablePanel.Controls.Add(MyLabel)

        Else

            PlaceHolderDetails.Controls.Add(MyLabel)

        End If

        MyLabel.Text = LableText & ":"
        MyLabel.CssClass = "JVlab"


        If CollapsablePanel IsNot Nothing Then

            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(MiddleSpacerTable))

        Else

            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(MiddleSpacerTable))

        End If

        Me.LoadAdvanDtype()

        Try

            If AdvantageDataTypeID = 0 AndAlso _AdvanDtype IsNot Nothing AndAlso _AdvanDtype.ContainsKey(JobVersionDataTypeID) = True Then

                AdvantageDataTypeID = _AdvanDtype.Item(JobVersionDataTypeID)

            End If

        Catch ex As Exception
            AdvantageDataTypeID = 0
        End Try

        If AdvantageDataTypeID > 0 Then

            Select Case AdvantageDataTypeID
                Case 1  'varchar - textbox (length determined by size) OR Listbox of pre-defined Value list

                    Select Case JobVersionDataTypeID
                        Case 11 'Value list

                            If CollapsablePanel IsNot Nothing Then

                                CollapsablePanel.Controls.Add(MyRadComboBox)

                            Else

                                PlaceHolderDetails.Controls.Add(MyRadComboBox)

                            End If

                            MyRadComboBox.TabIndex = Order + 5
                            MyRadComboBox.ID = "varchar" & JobVersionTemplateDetailID.ToString
                            MyRadComboBox.Width = 450

                            If IsRequired = True Then

                                'user can only choose from list items
                                MyRadComboBox.AllowCustomText = False
                                If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                                    MyRadComboBox.InputCssClass = "required-missing"

                                Else

                                    MyRadComboBox.InputCssClass = "RequiredInput"

                                End If

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MyRequiredLabel)

                                Else

                                    PlaceHolderDetails.Controls.Add(MyRequiredLabel)

                                End If

                                MyRequiredLabel.Text = " *"
                                MyRequiredLabel.ForeColor = Color.Red
                                MyRequiredLabel.Font.Size = FontUnit.Medium

                                With MyRequiredFieldValidator

                                    .ControlToValidate = MyRadComboBox.ID
                                    .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                                    .SetFocusOnError = True
                                    .ForeColor = Color.Red

                                End With

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                                    CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                                Else

                                    PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                                    PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                                End If

                            Else

                                'user can type in any value or pick from list
                                MyRadComboBox.AllowCustomText = True
                                MyRadComboBox.MaxLength = Precision

                            End If

                            _Sql = String.Format("SELECT JV_VALID_VALUE FROM JOB_VER_VALUE_LIST WHERE JV_TMPLT_DTL_ID = {0} ORDER BY JV_VALID_VALUE;", JobVersionTemplateDetailID)

                            Try

                                _DataReader = _SqlHelper.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, _Sql)

                            Catch ex As Exception
                            End Try

                            'Insert blank value at top
                            Dim item1 As New RadComboBoxItem()
                            ValueString = ""
                            item1.Value = ValueString
                            item1.Text = ValueString
                            item1.Height = Unit.Pixel(12)
                            item1.CssClass = Nothing
                            MyRadComboBox.Items.Add(item1)

                            'Populate dropdown with user defined list values
                            If _DataReader.HasRows Then

                                Do While _DataReader.Read

                                    Dim item As New RadComboBoxItem()

                                    ValueString = _DataReader.GetString(0)
                                    item.Value = ValueString
                                    item.Text = ValueString
                                    MyRadComboBox.Items.Add(item)

                                Loop

                                _DataReader.Close()

                            End If
                            If Not TheValue Is Nothing AndAlso TheValue <> "" Then

                                MyRadComboBox.SelectedValue = CType(TheValue, String)

                            Else

                                MyRadComboBox.SelectedValue = item1.Text

                            End If
                            If Not TheValue Is Nothing AndAlso TheValue <> "" AndAlso MyRadComboBox.SelectedIndex = -1 Then

                                MyRadComboBox.Text = TheValue

                            End If
                            If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                                MyRadComboBox.Enabled = False

                            End If

                        Case Else

                            ' calculate formula for textbox length according to precision size.
                            Dim szWid, szHt As Integer
                            szWid = Precision * 7

                            If szWid < 450 Then

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MyTextBox)

                                Else

                                    PlaceHolderDetails.Controls.Add(MyTextBox)

                                End If

                                MyTextBox.Width = szWid
                                MyTextBox.MaxLength = Precision

                                Try

                                    If IsDBNull(TheValue) = False AndAlso TheValue IsNot Nothing AndAlso String.IsNullOrWhiteSpace(TheValue) = False Then

                                        MyTextBox.Text = CType(TheValue, String).Replace("''", "'")

                                    End If

                                Catch ex As Exception
                                    MyTextBox.Text = ""
                                End Try

                                If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                                    MyTextBox.ReadOnly = True

                                End If

                                CommonWebControl = MyTextBox

                            Else

                                MyMultiLineRadTextBox.SkinID = "RadTextBoxJVMultiline"

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MyMultiLineRadTextBox)

                                Else

                                    PlaceHolderDetails.Controls.Add(MyMultiLineRadTextBox)

                                End If

                                szHt = szWid / 450
                                szHt = 18 * szHt

                                MyMultiLineRadTextBox.Height = szHt
                                MyMultiLineRadTextBox.Width = 450
                                MyMultiLineRadTextBox.Wrap = True
                                MyMultiLineRadTextBox.TextMode = TextBoxMode.MultiLine
                                MyMultiLineRadTextBox.MaxLength = Precision
                                MyMultiLineRadTextBox.Resize = ResizeMode.Both

                                Dim spanControlName As String = "SpanVarchar" & JobVersionTemplateDetailID.ToString
                                MyMultiLineRadTextBox.Attributes.Add("onkeyup", spanControlName & ".innerText=this.value.length + ' of " & Precision & "';")

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MiscFN.NewLiteral("<span id=" & spanControlName & " runat=""server"" />"))

                                Else

                                    PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("<span id=" & spanControlName & " runat=""server"" />"))

                                End If

                                If Not TheValue Is Nothing Then

                                    MyMultiLineRadTextBox.Text = CType(TheValue, String).Replace("''", "'")

                                End If

                                If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                                    MyMultiLineRadTextBox.ReadOnly = True

                                End If

                                CommonWebControl = MyMultiLineRadTextBox

                            End If

                            CommonWebControl.TabIndex = Order + 5
                            CommonWebControl.ID = "varchar" & JobVersionTemplateDetailID.ToString

                            If IsRequired = True Then

                                If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                                    CommonWebControl.CssClass = "required-missing"

                                Else

                                    CommonWebControl.CssClass = "RequiredInput"

                                End If

                                With MyRequiredFieldValidator

                                    .ControlToValidate = CommonWebControl.ID
                                    .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                                    .SetFocusOnError = True
                                    .ForeColor = Color.Red

                                End With

                                If CollapsablePanel IsNot Nothing Then

                                    CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                                    CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                                Else

                                    PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                                    PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                                End If

                            End If

                    End Select

                Case 2  'integer - textbox

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MyTextBox)

                    Else

                        PlaceHolderDetails.Controls.Add(MyTextBox)

                    End If

                    MyTextBox.TabIndex = Order + 5
                    MyTextBox.ID = "integer" & JobVersionTemplateDetailID.ToString
                    MyTextBox.Width = 100
                    MyTextBox.MaxLength = 9
                    MyTextBox.CssClass = "JVTextbox"

                    If IsRequired = True Then

                        If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                            MyTextBox.CssClass = "required-missing"

                        Else

                            MyTextBox.CssClass = "RequiredInput"

                        End If

                        With MyRequiredFieldValidator

                            .ControlToValidate = MyTextBox.ID
                            .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                            .SetFocusOnError = True
                            .ForeColor = Color.Red

                        End With

                        If CollapsablePanel IsNot Nothing Then

                            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                        Else

                            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                        End If

                    End If

                    If Not TheValue Is Nothing Then

                        MyTextBox.Text = CType(TheValue, Integer)

                    End If
                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        MyTextBox.ReadOnly = True

                    End If

                Case 3  'smallint - TextBox

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MyTextBox)

                    Else

                        PlaceHolderDetails.Controls.Add(MyTextBox)

                    End If

                    MyTextBox.TabIndex = Order + 5
                    MyTextBox.ID = "smallint" & JobVersionTemplateDetailID.ToString
                    MyTextBox.Width = 100
                    MyTextBox.MaxLength = 5
                    MyTextBox.CssClass = "JVTextbox"

                    If IsRequired = True Then

                        If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                            MyTextBox.CssClass = "required-missing"

                        Else

                            MyTextBox.CssClass = "RequiredInput"

                        End If

                        With MyRequiredFieldValidator

                            .ControlToValidate = MyTextBox.ID
                            .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                            .SetFocusOnError = True
                            .ForeColor = Color.Red

                        End With

                        If CollapsablePanel IsNot Nothing Then

                            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                        Else

                            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                        End If

                    End If
                    If Not TheValue Is Nothing Then

                        MyTextBox.Text = CType(TheValue, Integer)

                    End If
                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        MyTextBox.ReadOnly = True

                    End If

                Case 4  'smalldatetime - textbox, calendar object

                    Dim cal As New Telerik.Web.UI.RadDatePicker
                    With cal

                        .Width = New Unit(95, UnitType.Pixel)
                        .TabIndex = Order + 5
                        .ID = "date" & JobVersionTemplateDetailID.ToString()
                        .SkinID = "RadDatePickerStandardOld"
                        .MinDate = New DateTime(1900, 1, 1)
                        .DateInput.MinDate = New DateTime(1900, 1, 1)

                        If IsRequired = True Then

                            If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                                .DateInput.CssClass = "required-missing"

                            Else

                                .DateInput.CssClass = "RequiredInput"

                            End If

                        End If

                    End With

                    Dim DateSet As Boolean = False
                    Try

                        If Not TheValue Is Nothing Then

                            If TheValue <> "" Then

                                DateValue = CType(LoGlo.FormatDate(TheValue), Date)
                                cal.SelectedDate = DateValue
                                DateSet = True

                            End If

                        End If

                    Catch ex As Exception
                        DateSet = False
                    End Try

                    If DateSet = False AndAlso IsDateWithDefault = True AndAlso Me._IsNewSave = True AndAlso Me._HasSaved = False Then

                        cal.SelectedDate = Date.Today

                    End If

                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        cal.Enabled = False

                    End If

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(cal)

                    Else

                        PlaceHolderDetails.Controls.Add(cal)

                    End If

                    If IsRequired = True Then

                        With MyRequiredFieldValidator

                            .ControlToValidate = cal.ID
                            .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                            .SetFocusOnError = True
                            .ForeColor = Color.Red

                        End With

                        If CollapsablePanel IsNot Nothing Then

                            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                        Else

                            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                        End If

                    End If

                Case 5  'decimal - textbox

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MyTextBox)

                    Else

                        PlaceHolderDetails.Controls.Add(MyTextBox)

                    End If

                    MyTextBox.TabIndex = Order + 5
                    MyTextBox.ID = "decimal" & JobVersionTemplateDetailID.ToString
                    MyTextBox.Width = 150
                    MyTextBox.MaxLength = 15
                    MyTextBox.CssClass = "JVTextbox"

                    If IsRequired = True Then

                        If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                            MyTextBox.CssClass = "required-missing"

                        Else

                            MyTextBox.CssClass = "RequiredInput"

                        End If

                        With MyRequiredFieldValidator

                            .ControlToValidate = MyTextBox.ID
                            .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                            .SetFocusOnError = True
                            .ForeColor = Color.Red

                        End With

                        If CollapsablePanel IsNot Nothing Then

                            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                        Else

                            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(RowSpacer))
                            PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                        End If

                    End If
                    If Not TheValue Is Nothing Then

                        MyTextBox.Text = CType(TheValue, Decimal)

                    End If
                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        MyTextBox.ReadOnly = True

                    End If

                Case 6  'text - textbox (multi row) (memo)

                    Dim SpanControlName As String = String.Empty
                    Dim MemoCustomValidator As New CustomValidator

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MyRadEditor)

                    Else

                        PlaceHolderDetails.Controls.Add(MyRadEditor)

                    End If

                    MyRadEditor.TabIndex = Order + 5
                    MyRadEditor.ID = "text" & JobVersionTemplateDetailID.ToString

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MiscFN.NewLiteral("<span id=" & SpanControlName & " runat=""server"" />"))

                    Else

                        PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("<span id=" & SpanControlName & " runat=""server"" />"))

                    End If

                    If IsRequired = True Then

                        If Me._IsNewSave = False AndAlso (TheValue Is Nothing OrElse String.IsNullOrWhiteSpace(TheValue.ToString()) = True) Then

                            MyRadEditor.CssClass = "required-missing"

                        Else

                            MyRadEditor.CssClass = "RequiredInput"

                        End If

                        With MyRequiredFieldValidator

                            .ControlToValidate = MyRadEditor.ID
                            .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " is required."
                            .SetFocusOnError = True
                            .ForeColor = Color.Red

                        End With

                        If CollapsablePanel IsNot Nothing Then

                            'CollapsablePanel.Controls.Add(MiscFN.NewLiteral("<br />"))
                            CollapsablePanel.Controls.Add(MyRequiredFieldValidator)

                        Else

                            'PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("<br />"))
                            PlaceHolderDetails.Controls.Add(MyRequiredFieldValidator)

                        End If

                    End If

                    With MemoCustomValidator

                        .ControlToValidate = MyRadEditor.ID
                        .ClientValidationFunction = "checkMemoLength"
                        .ErrorMessage = Replace(LableText, "_", "&nbsp;").Replace("SLASH&nbsp;", "") & " must be less than 8000 characters."
                        .SetFocusOnError = True
                        .ForeColor = Color.Red

                    End With

                    If CollapsablePanel IsNot Nothing Then

                        'CollapsablePanel.Controls.Add(MiscFN.NewLiteral("<br />"))
                        CollapsablePanel.Controls.Add(MemoCustomValidator)

                    Else

                        'PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("<br />"))
                        PlaceHolderDetails.Controls.Add(MemoCustomValidator)

                    End If
                    If Not TheValue Is Nothing Then

                        If CType(TheValue, String) <> "" Then

                            MyRadEditor.Content = CType(TheValue, String).Replace(Environment.NewLine, "<br/>")

                        End If

                    End If
                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        'MyRadEditor.ReadOnly = True
                        MyRadEditor.Enabled = False

                    End If

                Case 7  'bit - Radio Buttons Y/N

                    If CollapsablePanel IsNot Nothing Then

                        CollapsablePanel.Controls.Add(MyRadioButtonYes)
                        CollapsablePanel.Controls.Add(MyRadioButtonNo)

                    Else

                        PlaceHolderDetails.Controls.Add(MyRadioButtonYes)
                        PlaceHolderDetails.Controls.Add(MyRadioButtonNo)

                    End If

                    _RadioGroupNameIndex = _RadioGroupNameIndex + 1

                    MyRadioButtonYes.GroupName = "radiogrp" & CType(_RadioGroupNameIndex, String)
                    MyRadioButtonNo.GroupName = "radiogrp" & CType(_RadioGroupNameIndex, String)
                    MyRadioButtonYes.Text = "Yes"
                    MyRadioButtonNo.Text = "No"
                    MyRadioButtonYes.TabIndex = Order + 5
                    MyRadioButtonNo.TabIndex = Order + 5

                    MyRadioButtonYes.ID = "bitY" & JobVersionTemplateDetailID.ToString
                    MyRadioButtonNo.ID = "bitN" & JobVersionTemplateDetailID.ToString

                    If Not TheValue Is Nothing Then

                        If TheValue = 1 Then

                            MyRadioButtonYes.Checked = True

                        Else

                            MyRadioButtonNo.Checked = True

                        End If

                    Else

                        MyRadioButtonNo.Checked = True

                    End If
                    If Me.IsClientPortal = True And Me._JobVersionClientPortalID = 0 Then

                        MyRadioButtonYes.Enabled = False
                        MyRadioButtonNo.Enabled = False

                    End If

            End Select

        End If

        If String.IsNullOrWhiteSpace(Instruction) = False Then

            If CollapsablePanel IsNot Nothing Then

                CollapsablePanel.Controls.Add(MiscFN.NewLiteral("   "))
                CollapsablePanel.Controls.Add(MiscFN.NewLiteral("<href style=""cursor: pointer;"" alt=""" & Instruction & """ title=""" & Instruction & """ >?</>"))

            Else

                PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("   "))
                PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral("<href style=""cursor: pointer;"" alt=""" & Instruction & """ title=""" & Instruction & """ >?</>"))

            End If

        End If

        If CollapsablePanel IsNot Nothing Then

            CollapsablePanel.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))

        Else

            PlaceHolderDetails.Controls.Add(MiscFN.NewLiteral(CloseSpacerTable))

        End If

    End Sub

    Private Function GetPrecisionFromDatabase(ByVal DatabaseTypeID As Integer) As Integer

        Dim precision As Integer = 0
        Try

            _Sql = "SELECT ISNULL(JV_DTYPE_PREC, 0) FROM JOB_VER_DTYPE WHERE JV_DTYPE_ID = " & CType(DatabaseTypeID, String)
            precision = _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _Sql)

        Catch ex As Exception
        End Try

        Return precision

    End Function
    Private Function GetScaleFromDatabase(ByVal DatabaseTypeID As Integer) As Integer

        Dim scale As Integer = 0
        Try

            _Sql = "SELECT JV_DTYPE_SCALE FROM JOB_VER_DTYPE WHERE JV_DTYPE_ID = " & CType(DatabaseTypeID, String)
            scale = _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _Sql)

        Catch ex As Exception
        End Try

        Return scale

    End Function
    Private Sub LoadAdvanDtype()

        If _AdvanDtype Is Nothing Then _AdvanDtype = New Dictionary(Of Integer, Integer)

        If _AdvanDtype.Count = 0 Then

            _Sql = "SELECT JV_DTYPE_ID, ADVAN_DTYPE_ID FROM JOB_VER_DTYPE;"

            Using connection As New SqlConnection(_Session.ConnectionString)

                connection.Open()

                Using cmd As New SqlCommand(_Sql, connection)

                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        If reader IsNot Nothing Then

                            While reader.Read()

                                _AdvanDtype.Add(reader.GetValue(0), reader.GetValue(1))

                            End While

                            Try
                                reader.Close()
                                reader.Dispose()
                            Catch ex As Exception

                            End Try


                        End If

                    End Using

                End Using

            End Using

        End If

    End Sub

    Private Function SaveTemplate() As Boolean

        Dim Saved As Boolean = True
        Dim jv As New JobVersion(Session("ConnString"))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim dr As SqlDataReader
        Dim tmplt_dtl_id As Integer
        Dim dtype_id As Integer
        Dim label_text, version_desc As String
        Dim anyvalue As Object
        Dim order, req As Integer
        Dim sdate As Date
        Dim validValue As Boolean
        Dim dtype_desc As String
        Dim columnLabel As String
        Dim jobversionseqnumber As Integer

        order = 1

        Me.lblRequired.Visible = False

        Dim myTextbox As System.Web.UI.WebControls.TextBox

        If (Me._IsRequest = True OrElse Me._IsRequestToForm = True) AndAlso _HasJob = False Then

            myTextbox = Me.VersionDescRequest

        Else

            myTextbox = Me.TextBoxVersionDescription

        End If
        If myTextbox.Text = Nothing Or myTextbox.Text.Trim = "" Then

        Else

            version_desc = myTextbox.Text

        End If

        dr = jv.GetJobVersDtl(Me._JobVersionHeaderID)

        If dr.HasRows Then

            Dim parameterJobVersionHeaderID As New SqlParameter("@JOB_VERSION_HDR_ID", SqlDbType.Int)
            Dim parameterJobVersionTemplateDetailID As New SqlParameter("@JV_TMPLT_DTL_ID", SqlDbType.Int)
            Dim parameterJobVersionValue As New SqlParameter("@JOB_VER_VALUE", SqlDbType.Variant)
            Dim TheValue As String

            _SqlUpdate = String.Empty

            Do While dr.Read

                TheValue = String.Empty

                '_SqlUpdate = "UPDATE JOB_VER_DTL SET JOB_VER_VALUE = "
                tmplt_dtl_id = dr.GetValue(0)   'JVD.JV_TMPLT_DTL_ID

                If IsDBNull(dr.GetValue(1)) Then 'JVD.JOB_VER_VALUE

                    anyvalue = Nothing

                Else

                    anyvalue = dr.GetValue(1)

                End If

                dtype_id = dr.GetValue(2)       'JVTD.JV_DTYPE_ID
                order = dr.GetValue(4)          'JVTD.JV_TMPLT_ORDER
                req = dr.GetValue(5)            'JVTD.JV_TMPLT_REQ

                validValue = True

                If SaveValue(tmplt_dtl_id, dtype_id, order, req, validValue, dtype_desc, TheValue) = True Then

                    If validValue = True Then

                        parameterJobVersionHeaderID.Value = Me._JobVersionHeaderID
                        parameterJobVersionTemplateDetailID.Value = tmplt_dtl_id

                        If String.IsNullOrWhiteSpace(TheValue) = True Then

                            parameterJobVersionValue.Value = DBNull.Value

                        Else

                            parameterJobVersionValue.Value = TheValue

                        End If

                    End If

                    '_SqlUpdate += " WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & " AND JV_TMPLT_DTL_ID = " & tmplt_dtl_id.ToString()

                    Try

                        '_SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _SqlUpdate)
                        _SqlHelper.ExecuteNonQuery(_Session.ConnectionString, CommandType.StoredProcedure, "advsp_job_version_update_value",
                                                   parameterJobVersionHeaderID,
                                                   parameterJobVersionTemplateDetailID,
                                                   parameterJobVersionValue)

                    Catch ex As Exception
                        Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
                    End Try

                Else

                    If validValue = False Then

                        Me.lblRequired.Visible = True
                        Me.lblRequired.Text = "Please input valid (" & dtype_desc & ") type.   "
                        Return False

                    End If

                    If req = 1 Then

                        Me.lblRequired.Visible = True
                        columnLabel = dr.GetString(3)
                        Me.lblRequired.Text = columnLabel & " is required. "
                        Return False

                    End If

                End If

            Loop

            Try

                dr.Close()
                dr.Dispose()

            Catch ex As Exception
            End Try

        End If

        sdate = System.DateTime.Now()

        If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then

            If Me.TxtJobNum.Text.Trim <> "" Then

                If IsNumeric(Me.TxtJobNum.Text.Trim) = False Then

                    Me.ShowMessage("Job invalid")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateJobNumber(Me.TxtJobNum.Text) = False Then

                    Me.ShowMessage("Job does not exist")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateJobIsViewable(Session("Usercode"), Me.TxtJobNum.Text.Trim) = False Then

                    Me.ShowMessage("Access to this Job is denied")
                    _IsValid = False
                    Return False

                End If

            End If
            If Me.TxtJobCompNum.Text <> "" Then

                If IsNumeric(Me.TxtJobCompNum.Text.Trim) = False Then

                    Me.ShowMessage("Component invalid")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateJobCompNumber(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text) = False Then

                    Me.ShowMessage("Component invalid")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.TxtJobNum.Text.Trim, Me.TxtJobCompNum.Text.Trim) = False Then

                    Me.ShowMessage("Access to this job/component is denied")
                    _IsValid = False
                    Return False

                End If

            End If

            _Sql = " SELECT ISNULL(MAX(JOB_VER_SEQ_NBR),0) FROM JOB_VER_HDR WHERE JOB_NUMBER = " & Me.TxtJobNum.Text & " AND JOB_COMPONENT_NBR = " & Me.TxtJobCompNum.Text

            Try

                jobversionseqnumber = _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _Sql)

            Catch ex As Exception
                Me.ShowMessage("Could not get version sequence number.\n\n" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
                _IsValid = False
            End Try

        End If

        'Save Version desription
        version_desc = version_desc.Replace("'", "^") 'REPLACE WITH NOT COMMONLY USED CHARACTER

        If IsClientPortal = True Then

            _SqlUpdate = "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET MODIFIED_DATE = '" & sdate.ToString() & "',  MODIFIED_BY_CP = '" & CStr(Session("UserID")) & "', JOB_VER_DESC = '" & version_desc & "'" & " WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & ";"

        Else

            _SqlUpdate = "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET MODIFIED_DATE = '" & sdate.ToString() & "',  MODIFIED_BY = '" & CStr(Session("UserCode")) & "', JOB_VER_DESC = '" & version_desc & "'" & " WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & ";"

        End If

        _SqlUpdate = _SqlUpdate & "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET JOB_VER_DESC = REPLACE(SUBSTRING(JOB_VER_DESC,1, DATALENGTH(JOB_VER_DESC)),'^','''') WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & ";"

        If Me._IsRequest = True OrElse Me._IsRequestToForm = True Then

            If Me.txtClient.Text <> "" Then

                If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then

                    Me.ShowMessage("Client invalid")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then

                    Me.ShowMessage("Access to this Client is denied")
                    _IsValid = False
                    Return False

                End If

            End If
            If Me.txtDivision.Text <> "" Then

                If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then

                    Me.ShowMessage("Client, Division invalid")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then

                    Me.ShowMessage("Access to this Division is denied")
                    _IsValid = False
                    Return False

                End If

            End If
            If Me.txtProduct.Text <> "" Then

                If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then

                    Me.ShowMessage("Invalid Client, Division, Product")
                    _IsValid = False
                    Return False

                End If
                If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then

                    Me.ShowMessage("Access to this product is denied")
                    _IsValid = False
                    Return False

                End If

            End If

            _SqlUpdate = _SqlUpdate & "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET CL_CODE = '" & Me.txtClient.Text & "',  DIV_CODE = '" & Me.txtDivision.Text & "', PRD_CODE = '" & Me.txtProduct.Text & "'" & " WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & ";"

        End If

        If Me._IsRequestToForm = True AndAlso _HasJob = False AndAlso IsNumeric(Me.TxtJobNum.Text) AndAlso IsNumeric(Me.TxtJobCompNum.Text) Then

            _SqlUpdate = _SqlUpdate & "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET JOB_NUMBER = '" & Me.TxtJobNum.Text & "',  JOB_COMPONENT_NBR = '" &
                Me.TxtJobCompNum.Text & "', JOB_VER_SEQ_NBR = '" & jobversionseqnumber + 1 & "'" & " WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString() & ";"
            _HasJob = True

        End If

        Try

            _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _SqlUpdate)

        Catch ex As Exception
            Saved = False
        End Try

        If Saved = True Then

            Me._HasSaved = True
            Me._IsNewSave = False
            Me.LoadJobVersion()

        End If

        Return Saved

    End Function
    Private Sub DeleteVersion()

        _SqlUpdate = "DELETE JOB_VER_DTL WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString

        Try
            _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _SqlUpdate)
        Catch
            Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:deleteVersion", Err.Description)
        End Try

        _SqlUpdate = "DELETE JOB_VER_HDR WHERE JOB_VER_HDR_ID = " & Me._JobVersionHeaderID.ToString

        Try
            _SqlHelper.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, _SqlUpdate)
        Catch
            Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:deleteVersion", Err.Description)
        End Try


    End Sub
    Private Function SaveValue(ByVal JobTemplateDetailID As Integer, ByVal DatabaseTypeID As Integer, ByVal Order As Integer, ByVal IsRequired As Short,
                               ByRef IsValidValue As Boolean, ByRef DataTypeDescription As String, ByRef ValueString As String) As Boolean

        Dim MyLiteral As New Literal
        Dim MyCalendarLiteral As New Literal
        Dim AdvantageDataType As Integer = 0
        Dim Precision As Integer = 0
        Dim Scale As Integer = 0
        'Dim ValueString As String = String.Empty
        Dim ValueAsInteger As Integer = 0
        Dim ValueAsSmallInt As Integer = 0
        Dim ValueAsDate As Date
        Dim ValueAsDecimal As Decimal = 0
        Dim ObjectID As String = String.Empty
        Dim IsDateOK As Boolean = False

        IsValidValue = True

        _Sql = " SELECT ADVAN_DTYPE_ID, JV_DTYPE_DESC FROM JOB_VER_DTYPE WHERE JV_DTYPE_ID = " & CType(DatabaseTypeID, String)

        Try

            _DataReader = _SqlHelper.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, _Sql)

        Catch ex As Exception
            Me.ShowMessage("Could not get data reader for save.\n\n" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
            Return False
        End Try

        If _DataReader IsNot Nothing AndAlso _DataReader.HasRows Then

            _DataReader.Read()
            AdvantageDataType = _DataReader.GetValue(0)

            If IsDBNull(_DataReader.GetString(1)) Then

                DataTypeDescription = ""

            Else

                DataTypeDescription = _DataReader.GetString(1)

            End If

            _DataReader.Close()

        End If

        Select Case AdvantageDataType
            Case 1  'varchar - textbox

                ObjectID = "varchar" & JobTemplateDetailID.ToString

                If DatabaseTypeID <> 11 Then

                    Dim WebControl As System.Web.UI.WebControls.WebControl = PlaceHolderDetails.FindControl(ObjectID)

                    If TypeOf WebControl Is System.Web.UI.WebControls.TextBox Then

                        ValueString = CType(WebControl, System.Web.UI.WebControls.TextBox).Text

                    ElseIf TypeOf WebControl Is Telerik.Web.UI.RadTextBox Then

                        ValueString = CType(WebControl, Telerik.Web.UI.RadTextBox).Text

                    End If

                    If WebControl IsNot Nothing Then

                        If IsRequired = True And ValueString = Nothing Then

                            Webvantage.MiscFN.SetFocus(WebControl)
                            Return False

                        Else

                            If ValueString = Nothing Then

                                _SqlUpdate += "NULL"
                                Return True

                            Else

                                'ValueString = ValueString.Replace("'", "''")
                                Precision = GetPrecisionFromDatabase(DatabaseTypeID)

                            End If

                            If ValueString.Length > 8000 Or Precision > 8000 Then Precision = 8000

                            If Precision > 0 Then

                                If Precision < ValueString.Length Then

                                    IsValidValue = False
                                    Webvantage.MiscFN.SetFocus(WebControl)
                                    Return False

                                End If

                            End If

                            _SqlUpdate += "'" & ValueString & "'"
                            Return True

                        End If

                    Else

                        Return False

                    End If

                Else 'DropdownListBox Value

                    Dim myradComboBox As RadComboBox = PlaceHolderDetails.FindControl(ObjectID)

                    If (Not myradComboBox Is Nothing) Then

                        ValueString = myradComboBox.Text

                        If IsRequired = True And (ValueString Is Nothing Or ValueString = "") Then

                            myradComboBox.Focus()
                            Return False

                        End If

                        If (ValueString = Nothing Or ValueString = "") Then

                            _SqlUpdate += "NULL"

                        Else

                            'ValueString = ValueString.Replace("'", "''")
                            _SqlUpdate += "'" & ValueString & "'"

                        End If

                        Return True

                    Else

                        Return False

                    End If

                End If

            Case 2  'integer - textbox

                Dim intType As Integer = 0
                ObjectID = "integer" & JobTemplateDetailID.ToString
                Dim myTextbox As System.Web.UI.WebControls.TextBox = PlaceHolderDetails.FindControl(ObjectID)

                If (Not myTextbox Is Nothing) Then

                    ValueString = myTextbox.Text

                    If IsRequired = True And ValueString = Nothing Then

                        Webvantage.MiscFN.SetFocus(myTextbox)
                        Return False

                    Else

                        If ValueString = Nothing Then

                            _SqlUpdate += "NULL"
                            Return True

                        Else

                            If Integer.TryParse(ValueString, intType) Then

                                If ValueString.Length < 10 Then

                                    _SqlUpdate += ValueString
                                    Return True

                                Else

                                    IsValidValue = False
                                    Webvantage.MiscFN.SetFocus(myTextbox)
                                    Return False

                                End If

                            Else

                                IsValidValue = False
                                Webvantage.MiscFN.SetFocus(myTextbox)
                                Return False

                            End If

                        End If

                    End If

                Else

                    Return False

                End If

            Case 3  'smallint - TextBox

                Dim intType As Integer = 0
                ObjectID = "smallint" & JobTemplateDetailID.ToString

                Dim myTextbox As System.Web.UI.WebControls.TextBox = PlaceHolderDetails.FindControl(ObjectID)

                If (Not myTextbox Is Nothing) Then

                    ValueString = myTextbox.Text

                    If IsRequired = True And ValueString = Nothing Then

                        Webvantage.MiscFN.SetFocus(myTextbox)
                        Return False

                    Else

                        If ValueString = Nothing Then

                            _SqlUpdate += "NULL"
                            Return True

                        Else

                            If Integer.TryParse(ValueString, intType) Then

                                If ValueString.Length < 6 Then

                                    If CType(ValueString, Integer) > 32767 Or CType(ValueString, Integer) < -32767 Then

                                        Webvantage.MiscFN.SetFocus(myTextbox)
                                        IsValidValue = False
                                        Return False

                                    End If

                                Else

                                    Webvantage.MiscFN.SetFocus(myTextbox)
                                    IsValidValue = False
                                    Return False

                                End If

                            Else

                                IsValidValue = False
                                Webvantage.MiscFN.SetFocus(myTextbox)
                                Return False

                            End If

                            _SqlUpdate += ValueString
                            Return True

                        End If

                    End If

                Else

                    Return False

                End If

            Case 4  'smalldatetime (Date)

                ObjectID = "date" & JobTemplateDetailID.ToString

                Dim myRadDatePicker As New Telerik.Web.UI.RadDatePicker
                myRadDatePicker = PlaceHolderDetails.FindControl(ObjectID)

                If (Not myRadDatePicker Is Nothing) Then

                    Try

                        ValueString = CType(myRadDatePicker.SelectedDate, Date).ToShortDateString()

                    Catch ex As Exception
                        ValueString = ""
                    End Try

                    If IsRequired = True And (ValueString = Nothing Or ValueString = "") Then

                        Return False

                    Else

                        If (ValueString = Nothing Or ValueString = "") Then

                            _SqlUpdate += "NULL"
                            Return True

                        Else

                            If IsDate(ValueString) = False Then

                                IsValidValue = False
                                Return False

                            Else

                                _SqlUpdate += "'" & ValueString & "'"
                                Return True

                            End If

                        End If

                    End If

                Else

                    Return False

                End If

            Case 5  'decimal - textbox

                Dim DecType As Decimal = 0
                Dim DecScale As Integer = 0
                Dim cnt As Integer = 0
                Dim idx As Integer = 0
                Dim Len As Integer = 0
                Dim chararr As Char()
                Dim chr As Char
                Dim found As Boolean = False
                ObjectID = "decimal" & JobTemplateDetailID.ToString
                Dim myTextbox As System.Web.UI.WebControls.TextBox = PlaceHolderDetails.FindControl(ObjectID)

                If (Not myTextbox Is Nothing) Then
                    ValueString = myTextbox.Text
                    If IsRequired = True And ValueString = Nothing Then
                        Webvantage.MiscFN.SetFocus(myTextbox)
                        Return False
                    Else
                        If ValueString = Nothing Then
                            _SqlUpdate += "NULL"
                            Return True
                        Else
                            If Not Decimal.TryParse(ValueString, DecType) Then
                                Webvantage.MiscFN.SetFocus(myTextbox)
                                IsValidValue = False
                                Return False
                            Else ' Check scale
                                ValueString = ValueString.Replace(",", "")
                                DecScale = GetScaleFromDatabase(DatabaseTypeID)
                                chararr = ValueString.ToCharArray
                                cnt = 0
                                For idx = 0 To ValueString.Length - 1
                                    chr = chararr(idx)
                                    If chr = "." Then
                                        found = True
                                    End If
                                    If found = True Then
                                        cnt = cnt + 1
                                    End If
                                Next
                                If (cnt - 1) > DecScale Then
                                    Webvantage.MiscFN.SetFocus(myTextbox)
                                    IsValidValue = False
                                    Return False
                                End If
                            End If

                            _SqlUpdate += ValueString
                            Return True

                        End If

                    End If

                Else

                    Return False

                End If

            Case 6  'text - textbox (multi row)

                ObjectID = "text" & JobTemplateDetailID.ToString
                'Dim myTextbox As Telerik.Web.UI.RadTextBox = PlaceHolderDetails.FindControl(ObjectID)
                Dim myRadEditor As Telerik.Web.UI.RadEditor = PlaceHolderDetails.FindControl(ObjectID)

                If (Not myRadEditor Is Nothing) Then

                    ValueString = myRadEditor.Content.Replace(Environment.NewLine, "")

                    If IsRequired = True And ValueString = Nothing Then

                        Webvantage.MiscFN.SetFocus(myRadEditor)
                        Return False

                    Else

                        If ValueString = Nothing Then

                            _SqlUpdate += "NULL"
                            Return True

                        Else

                            'ValueString = ValueString.Replace("'", "''")

                            If ValueString.Length > 8000 Then

                                IsValidValue = False
                                Webvantage.MiscFN.SetFocus(myRadEditor)
                                Return False

                            End If

                            _SqlUpdate += "'" & ValueString & "'"
                            Return True

                        End If

                    End If

                Else

                    Return False

                End If

            Case 7  'bit - Radio Buttons Y/N

                ObjectID = "bitY" & JobTemplateDetailID.ToString
                Dim myRadioButY As RadioButton = PlaceHolderDetails.FindControl(ObjectID)

                If myRadioButY.Checked = True Then

                    _SqlUpdate += "1"
                    ValueString = "1"
                    Return True

                Else

                    _SqlUpdate += "0"
                    ValueString = "0"
                    Return True

                End If

        End Select

    End Function
    Private Sub SendAlert(Optional ByVal AsEmail As Boolean = False, Optional ByVal IsAssignment As Boolean = False)

        Dim ojob As New Job(Session("ConnString"))
        Dim desc As String
        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        Dim ar() As String
        Dim update As String

        Session("JobVerSendClient") = Me.txtClient.Text
        Session("JobVerSendDivision") = Me.txtDivision.Text
        Session("JobVerSendProduct") = Me.txtProduct.Text
        Session("JVDescription") = Me.VersionDescRequest.Text
        Session("JVReportTitle") = Session("JVTemplateName")
        Session("JobVerHdrID") = Me._JobVersionHeaderID

        Try

            Dim EmailSwitch As String = ""
            If AsEmail = True Then

                EmailSwitch = "eml=1&"

            Else

                EmailSwitch = "eml=0&"

            End If
            If IsAssignment = True Then 'assignment switch overrides email switch

                EmailSwitch = "eml=0&assn=1&"

            End If
            If Me._IsRequestToForm = True Then

                update = "jrupdate"

            End If

            Dim strURL As String = "Alert_New.aspx?" & EmailSwitch & "send=1&caller=jobversionprint&jverid=" & Me._JobVersionHeaderID & "&pagetype=jr" &
                "&f=" & MiscFN.SourceApp_ToInt(MiscFN.Source_App.JobVersion) & "&c=" & Me.txtClient.Text & "&d=" & Me.txtDivision.Text & "&p=" & Me.txtProduct.Text & "&JVDescription=" & Me.VersionDescRequest.Text
            Me.OpenWindow("New Alert", strURL)

        Catch ex As Exception

            Me.ShowMessage("err opening print data window")

        End Try
    End Sub

    Private Sub SetButtonVisibility()

        'objects
        Dim secView As String = ""
        Dim secEdit As String = ""
        Dim secInsert As String = ""

        secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
        secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
        secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

        If secInsert = "N" Then

            RadToolBarButtonCreateJob.Enabled = False
            RadToolBarButtonCreateComponent.Enabled = False

        Else

            RadToolBarButtonCreateJob.Enabled = True
            RadToolBarButtonCreateComponent.Enabled = True

        End If

        If secEdit = "N" Then

            Me.lbJob.Attributes.Add("onclick", "")
            Me.lbComponent.Attributes.Add("onclick", "")
            Me.lbJob.Enabled = False
            Me.lbComponent.Enabled = False
            Me.JobNbrRequest.Enabled = False
            Me.CompNbrRequest.Enabled = False
            Me.TxtJobNum.Enabled = False
            Me.TxtJobCompNum.Enabled = False

        End If


    End Sub

#End Region

End Class
