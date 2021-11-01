'HEY!
'there is a page called: JobTemplate_Search.aspx
'this page basically will replace everything in pnlJS on this page...eventually
'right now, they are both in use...so if you make changes to pnlJS, be sure to make the equivalent change to JobTemplate_Search.aspx

Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet

'Page looks for these querystring vars:
'PageMode = determines whether textboxes and submit buttons are enabled/disabled (allow edit or not)
'JobNumber,JobComponentNbr 
'NewComp = determines whether this is a new component
Partial Public Class JobTemplatePage
    Inherits Webvantage.BaseChildPage

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

#Region " Private vars: "

    Private PageEdit As Boolean = False
    Private NewJob As Boolean = False
    Private NewComp As Boolean = False

    Private Office As String = ""
    Public Client As String = ""
    Private Division As String = ""
    Private Product As String = ""

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0

    Private Closed As Boolean = False
    Private SalesCode As String = ""
    Private taxflag As Boolean = False
    Private SalesClass As String = ""
    Private AE As String = ""

    Private CurrTemplate As String = String.Empty
    Private NewTemplate As String = String.Empty

    Private dtFormData As DataTable = New DataTable("FormData")
    Private dtUserData As DataTable = New DataTable("UserData")
    Private dtAlertReqs As DataTable = New DataTable("AlertReqs")
    Private dtEdits As DataTable = New DataTable

    Private IsAgencyRequiredEmail As Boolean = False
    Private IsAutoEmailPromptOnNew As Boolean = False
    Private IsAutoEmailPromptOnUpdate As Boolean = False
    Private IsClientGetsEmailOnNew As Boolean = False
    Private IsClientGetsEmailOnUpdate As Boolean = False

    Private MessageID As Integer = 0
    Private bool As Boolean
    Private rights As String

    Protected WithEvents RadComboBoxJobTemplateTop As Telerik.Web.UI.RadComboBox

    Protected WithEvents labellist As System.Web.UI.WebControls.Label

    Private ClientChange As String = ""
    Private DivisionChange As String = ""
    Private ProductChange As String = ""

#End Region

#Region " Page "

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)

        End If
        Try

            If Not Request.QueryString("JobNum") Is Nothing Then

                If IsNumeric(Request.QueryString("JobNum")) Then

                    JobNumber = CType(Request.QueryString("JobNum"), Integer)

                End If
                If Not Request.QueryString("JobCompNum") Is Nothing Then

                    If IsNumeric(Request.QueryString("JobCompNum")) Then

                        JobComponentNbr = CType(Request.QueryString("JobCompNum"), Integer)

                    End If

                End If

            End If

            'Clean up old querystring names by letting clean qs class override
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If qs.JobNumber > 0 Then Me.JobNumber = qs.JobNumber
            If qs.JobComponentNumber > 0 Then Me.JobComponentNbr = qs.JobComponentNumber
            'Me.IsLoadedIntoDashboard = qs.IsJobDashboard 

            Me.RadToolbarJobTemplateTop.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            'If Me.CurrentQuerystring.IsJobDashboard = True Then

            Me.RadToolbarJobTemplateTop.FindItemByValue("Search").Visible = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("New").Visible = False
            Me.RadToolbarJobTemplateTop.FindItemByText("Modules").Visible = False
            Me.RadToolbarJobTemplateTop.FindItemByText("Print/Send2").Visible = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("Bookmark").Visible = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("PrintAndModuleSeparator").Visible = False

            'End If

            Me.MyUnityContextMenu.JobNumber = Me.JobNumber
            Me.MyUnityContextMenu.JobComponentNumber = Me.JobComponentNbr
            Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.JobJacket}

            If Not Session("CurrClosedJobs") Is Nothing Then

                Closed = Session("CurrClosedJobs")

            End If
            If Not Request.QueryString("NewComp") Is Nothing Then
                If Request.QueryString("NewComp") = "1" Then
                    NewComp = True
                Else
                    NewComp = False
                End If
            End If

            Dim v As New cValidations(Session("ConnString"))
            If v.ValidateJobCompIsViewable(Session("UserCode"), JobNumber, JobComponentNbr) = False Then
                'Server.Transfer("NoAccess.aspx")
                Me.ShowMessage("Access to this job/comp is denied")
                Me.CloseThisWindow()
                Exit Sub
            End If

            SetPageMode(JobNumber, JobComponentNbr)
            Session("popupJSJobNum") = Me.JobNumber
            Session("popupJSJobCompNum") = Me.JobComponentNbr
            CheckUserRights()
        Catch ex As Exception
            lblMSG.Text = "Error processing querystring vars<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString
        Finally
        End Try

        'set permission to session so SecuritySession doesn't have to be passed into class
        'Me.CheckModuleAccess(AdvantageFramework.Security.Modules.FinanceAccounting_JobProcessCtrl.ToString, False)
        Dim SessionKey As String = "CheckModuleAccess" & AdvantageFramework.Security.Modules.FinanceAccounting_JobProcessCtrl.ToString
        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.FinanceAccounting_JobProcessCtrl.ToString, _Session.UserCode) = True Then

                Session(SessionKey) = 1

            Else

                Session(SessionKey) = 0

            End If


        End Using

        Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
        Dim SpellCheckObjects As String = ""

        Try
            If JobNumber > 0 And JobComponentNbr > 0 Then

                LoGlo.PageCultureSetDatabaseAndUser(Me.Page)

                dtFormData.CaseSensitive = True
                dtFormData = MyJobTemplate.BuildJobTemplateForm(Me._Session, PageEdit, Me.PlaceHolderMain, JobNumber, JobComponentNbr, Session("Empcode"), NewComp, Me.Client, Session("UserCode"), SpellCheckObjects,
                                                                 Me.Office, Me.Client, Me.Division, Me.Product, Me.AE, Me.SalesClass, Me.CurrTemplate, Me.IsClientPortal)
                'Spellchecker functions
                Session("SpellCheckObjects") = SpellCheckObjects
                Session("JobTemplateHasBlackplate1") = PageHasBlackPlate1(dtFormData)
                Session("JobTemplateHasBlackplate2") = PageHasBlackPlate2(dtFormData)

            Else

                Exit Sub

            End If
        Catch ex As Exception
            PnlContainer.Visible = False
            lblMSG.Text = ex.Message.ToString
        Finally
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If JobNumber > 0 And JobComponentNbr > 0 Then

                Dim CurrentPSStatus As String = MyJobTemplate.GetProjectScheduleStatusForDisplay(Me.JobNumber, Me.JobComponentNbr)
                If CurrentPSStatus <> "" Then

                    Me.RadToolbarJobTemplateTop.FindItemByValue("Schedule").ToolTip = CurrentPSStatus

                End If

                Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
                Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)
                Me.RadToolbarJobTemplateTop.FindItemByValue("CpPermaLink").Visible = Deep.ClientPortalVisible
                If Me.IsClientPortal = True Then

                    Me.RadToolbarJobTemplateTop.FindItemByValue("WvPermaLink").Visible = False
                    Me.RadToolbarJobTemplateTop.FindItemByValue("CpPermaLink").Visible = False

                End If

            End If

        End If
        'If JobNumber > 0 And JobComponentNbr > 0 Then

        '    Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
        '    Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)

        'End If

    End Sub

    Private Function PageHasBlackPlate1(ByVal dt As DataTable) As Boolean
        Dim dv As New DataView
        dv = dt.DefaultView
        dv.RowFilter = "ItemCode LIKE '%BLACKPLT_VER_%'"
        If dv.ToTable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function PageHasBlackPlate2(ByVal dt As DataTable) As Boolean
        Dim dv As New DataView
        dv = dt.DefaultView
        dv.RowFilter = "ItemCode LIKE '%BLACKPLT_VER2_%'"
        If dv.ToTable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.RadComboBoxJobTemplateTop = Me.RadToolbarButtonRadComboBoxJobTemplateTop.FindControl("RadComboBoxJobTemplateTop")
            If Not Me.IsPostBack Then
                setJVDesc()
                CheckUserRightsEst()
                If JobNumber = 0 And JobComponentNbr = 0 Then

                Else
                    BindDropTemplates(CurrTemplate)
                End If
                Session("JobTemplatedtFormData") = Me.dtFormData
                Session("NewJSNew") = Request.QueryString("NewJS")
            End If
            Select Case Me.EventArgument
                Case "Refresh"
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()
                    MiscFN.ResponseRedirect(qs.ToString(True), True)

                    'Me.RadWindowManager.Windows(0).VisibleOnPageLoad = False
                    'Dim q As New AdvantageFramework.Web.QueryString()
                    'With q
                    '    .PassThroughTo("JobTemplate.aspx")
                    '    .Go()
                    'End With
                Case "JobVersions"
                    Dim strURL As String = "jobVersions.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                    Me.OpenWindow("", strURL)
                Case "OpenNewVersion"
                    'Session("FromWindow") = "jobtemplate"
                    Dim JobVerHdrID As Integer
                    JobVerHdrID = Session("JobVerHdrID")
                    Dim strURL As String = "jobVerTmplt.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&JobVerHdrID=" & JobVerHdrID & "&NewSaved=1"
                    Me.OpenWindow("", strURL)
                Case "Cancel"
                    Session("NewJSNew") = 0
                    Session("CBNewSaved") = 0
                Case "OpenCreativeBrief"
                    OpenCreativeBrief(CStr(JobNumber), CStr(JobComponentNbr))
                Case "Comments"
                    Me.OpenWindow("", "JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0")

            End Select
            If JobNumber > 0 And JobComponentNbr > 0 Then
                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                If myVal.ValidateJobIsOpen(JobNumber, Me.JobComponentNbr) = False Then
                    Me.LblClosed.Visible = True
                Else
                    Me.LblClosed.Visible = False
                End If
                GetCDPContact(JobNumber, JobComponentNbr)
                'GetSC_Code(JobNumber)
            End If

            If Not Request.QueryString("MSG") Is Nothing Then
                If IsNumeric(Request.QueryString("MSG")) Then
                    MessageID = Request.QueryString("MSG")
                End If
            End If

            Dim StrMessage As String = String.Empty
            Select Case MessageID
                Case 1
                    StrMessage = "Data Successfully Saved"
                Case 2
                    StrMessage = "New Component Created"
            End Select

            If StrMessage <> "" Then
                Me.lblMSG.Text = "<br />" & StrMessage & "<br />"
            End If

            'FillLocationDropDown()
            ShowTemplatesDDL(PageEdit)

            Dim btn As System.Web.UI.WebControls.ImageButton
            Dim btn3 As System.Web.UI.WebControls.ImageButton
            Dim btn4 As System.Web.UI.WebControls.ImageButton
            Dim btn5 As System.Web.UI.WebControls.ImageButton
            Dim btn6 As System.Web.UI.WebControls.ImageButton
            Dim btn7 As System.Web.UI.WebControls.ImageButton
            Dim btn8 As System.Web.UI.WebControls.ImageButton
            Dim btn9 As System.Web.UI.WebControls.ImageButton
            Dim hfJS As System.Web.UI.WebControls.HiddenField
            Dim hfPS As System.Web.UI.WebControls.HiddenField
            Dim hfJV As System.Web.UI.WebControls.HiddenField
            Dim hfEST As System.Web.UI.WebControls.HiddenField
            Dim hfCon As System.Web.UI.WebControls.HiddenField
            Dim hfJobComments As System.Web.UI.WebControls.HiddenField
            Dim hfJobCompComments As System.Web.UI.WebControls.HiddenField
            Dim hfCreativeInstr As System.Web.UI.WebControls.HiddenField
            Dim hfJobDelInstruct As System.Web.UI.WebControls.HiddenField
            Dim hfJSlb As System.Web.UI.WebControls.HiddenField
            Dim hfPSlb As System.Web.UI.WebControls.HiddenField
            Dim hfJVlb As System.Web.UI.WebControls.HiddenField
            Dim hfESTlb As System.Web.UI.WebControls.HiddenField
            Dim lb As System.Web.UI.WebControls.LinkButton
            Dim lb2 As System.Web.UI.WebControls.LinkButton
            Dim lb3 As System.Web.UI.WebControls.LinkButton
            Dim lb4 As System.Web.UI.WebControls.LinkButton

            hfJS = Me.PnlContainer.FindControl("HfJobSpec")
            hfPS = Me.PnlContainer.FindControl("HfTrafficSchedule")
            hfJV = Me.PnlContainer.FindControl("HfJobVersions")
            hfEST = Me.PnlContainer.FindControl("HfEstimating")
            hfJobComments = Me.PnlContainer.FindControl("HfJobComments")
            hfJobCompComments = Me.PnlContainer.FindControl("HfJobCompComments")
            hfCreativeInstr = Me.PnlContainer.FindControl("HfCreativeInstr")
            hfJobDelInstruct = Me.PnlContainer.FindControl("HfJobDelInstruct")
            hfJSlb = Me.PnlContainer.FindControl("HfJobSpecLb")
            hfPSlb = Me.PnlContainer.FindControl("HfTrafficScheduleLb")
            hfJVlb = Me.PnlContainer.FindControl("HfJobVersionsLb")
            hfESTlb = Me.PnlContainer.FindControl("HfEstimatingLb")
            'hfCon = Me.PnlContainer.FindControl("HfContact")
            If Not hfJS Is Nothing Then
                btn = Me.PnlContainer.FindControl(hfJS.Value)
                AddHandler btn.Command, AddressOf btnJobSpecs
            End If
            If Not hfPS Is Nothing Then
                btn3 = Me.PnlContainer.FindControl(hfPS.Value)
                AddHandler btn3.Command, AddressOf btnProjectSchedule
            End If
            If Not hfJV Is Nothing Then
                btn4 = Me.PnlContainer.FindControl(hfJV.Value)
                AddHandler btn4.Command, AddressOf btnJobVersions
            End If
            If Not hfEST Is Nothing Then
                btn5 = Me.PnlContainer.FindControl(hfEST.Value)
                AddHandler btn5.Command, AddressOf btnEstimating
            End If
            If Not hfJobComments Is Nothing Then
                btn6 = Me.PnlContainer.FindControl(hfJobComments.Value)
                AddHandler btn6.Command, AddressOf btnComments
            End If
            If Not hfJobCompComments Is Nothing Then
                btn7 = Me.PnlContainer.FindControl(hfJobCompComments.Value)
                AddHandler btn7.Command, AddressOf btnComments
            End If
            If Not hfCreativeInstr Is Nothing Then
                btn8 = Me.PnlContainer.FindControl(hfCreativeInstr.Value)
                AddHandler btn8.Command, AddressOf btnComments
            End If
            If Not hfJobDelInstruct Is Nothing Then
                btn9 = Me.PnlContainer.FindControl(hfJobDelInstruct.Value)
                AddHandler btn9.Command, AddressOf btnComments
            End If
            If Not hfJSlb Is Nothing Then
                lb = Me.PnlContainer.FindControl(hfJSlb.Value)
                AddHandler lb.Command, AddressOf lbJobSpecs
            End If
            If Not hfPSlb Is Nothing Then
                lb2 = Me.PnlContainer.FindControl(hfPSlb.Value)
                AddHandler lb2.Command, AddressOf lbProjectSchedule
            End If
            If Not hfJVlb Is Nothing Then
                lb3 = Me.PnlContainer.FindControl(hfJVlb.Value)
                AddHandler lb3.Command, AddressOf lbJobVersions
            End If
            If Not hfESTlb Is Nothing Then
                lb4 = Me.PnlContainer.FindControl(hfESTlb.Value)
                AddHandler lb4.Command, AddressOf lbEstimating
            End If

        Catch ex As Exception
            lblMSG.Text = "Page_load err: " & ex.Message.ToString
        End Try
        'ShowTestGrid()
        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
            Me.SetTooltipToLabel(Me.Page)
        End If
        If Me.IsClientPortal = True Then

            Me.RadToolbarJobTemplateTop.FindItemByValue("SendAssignment").Visible = False

        End If

    End Sub

#End Region

#Region " Controls "

    Dim lab As System.Web.UI.WebControls.Label
    Dim labJT As System.Web.UI.WebControls.Label

    Private Sub MainToolbarsAction(ByVal Command_Name As String, ByVal IsBottomToolbar As Boolean)
        Select Case Command_Name
            'Case "Search"
            '    Reset()
            '    Me.OpenWindow("", "JobTemplate_Search.aspx")
            Case "Docs"
                Session("DocFilterLevel") = "JC"
                Session("DocFilterValue") = Me.JobNumber & "," & Me.JobComponentNbr
                Me.OpenWindow("", "Documents_JobComponent.aspx?m=D&JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr)
            Case "Save"
                Try
                    Dim s As String = ""
                    Me.lblMSG.Text = ""
                    If SaveChangedData(Me.RadComboBoxJobTemplateTop.SelectedValue, s) = False Then
                        If s <> "" Then
                            'Me.ShowMessage(s)
                            Me.lblMSG.Text = "<br />" & s & "<br />"
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
                End Try
            Case "NewComp"

                'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                '    If AdvantageFramework.ProjectManagement.JobComponentIsMissingRequiredField(DbContext, Me.JobNumber, Me.JobComponentNbr) = True Then

                '        Me.ShowMessage("Job missing required information")
                '        Exit Sub

                '    Else

                NewCompClick()

                '    End If

                'End Using

            Case "Print"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobTemplate_Print.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr
                qs.Add("fromapp", "jobtemplate")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendAlert"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobTemplate_Print.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr
                qs.Add("fromapp", "jobtemplate")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendAssignment"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobTemplate_Print.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr
                qs.Add("fromapp", "jobtemplate")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendEmail"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobTemplate_Print.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr
                qs.Add("fromapp", "jobtemplate")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "PrintSendOptions"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobTemplate_Print.aspx"
                qs.JobNumber = Me.JobNumber
                qs.JobComponentNumber = Me.JobComponentNbr
                qs.Add("fromapp", "jobtemplate")
                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                Me.OpenWindow(qs)


            'Case "New"
            '    'Me.OpenWindow("New Job", "JobTemplate_New.aspx")
            '    Me.CloseThisWindowAndOpenNewWindow("JobTemplate_New.aspx")
            Case "Refresh"
                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                MiscFN.ResponseRedirect(qs.ToString(True), True)
                'MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0")
                Exit Sub
            Case "JobSpecs"
                Try
                    ''Dim save As Boolean = False
                    ''If PageEdit = True Then
                    ''    If IsBottomToolbar = False Then
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
                    ''    Else
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
                    ''    End If
                    ''    If save = False Then
                    ''        Exit Sub
                    ''    End If
                    ''End If

                    Dim js As New Job_Specs(Session("ConnString"))
                    Dim dr As SqlDataReader
                    Dim strURL As String = ""
                    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                    dr = js.GetJobSpecData(Me.JobNumber, Me.JobComponentNbr, -1, -1)
                    If dr.HasRows = False Then
                        If Me.IsClientPortal = True Then
                            Me.ShowMessage("No Specifications exist for this job.")
                        Else
                            strURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr & "&AddType=4"
                            Me.OpenWindow("Specifications", strURL, 325, 625, False, True)
                        End If
                    Else
                        strURL = "jobspecs.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                        Me.OpenWindow("Specifications", strURL)
                    End If
                Catch ex As Exception
                    Me.ShowMessage("err opening job specs data window")
                End Try

            Case "JobVersions"
                Try
                    ''Dim save As Boolean = False
                    ''If PageEdit = True Then
                    ''    If IsBottomToolbar = False Then
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
                    ''    Else
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
                    ''    End If
                    ''    If save = False Then
                    ''        'lblMSG.Text = "Save Failed!"
                    ''        Exit Sub
                    ''    End If
                    ''End If
                    Dim jv As New JobVersion(Session("ConnString"))
                    Dim strURL As String = ""
                    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                    Dim existingtemps As Boolean

                    'Session("FromWindow") = "jobtemplate"

                    existingtemps = jv.ExistingTemplates(Me.JobNumber, Me.JobComponentNbr)
                    If existingtemps = False Then
                        'If Me.IsClientPortal = True Then
                        '    Me.ShowMessage("No Forms exist for this job.")
                        'Else
                        strURL = "jobVerNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                        Me.OpenWindow("", strURL)
                        'End If
                    Else
                        strURL = "jobVersions.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                        Me.OpenWindow("", strURL)
                    End If
                Catch ex As Exception
                    Me.ShowMessage("error opening job version window")
                End Try

            Case "qva"
                Try
                    ''Dim save As Boolean = False
                    ''If PageEdit = True Then
                    ''    If IsBottomToolbar = False Then
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
                    ''    Else
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
                    ''    End If
                    ''    If save = False Then
                    ''        'lblMSG.Text = "Save Failed!"
                    ''        Exit Sub
                    ''    End If
                    ''End If
                    Dim strURL As String
                    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                    strURL = "QuoteVsActualSummaryPopup.aspx?JobNo=" & JobNumber & "&JobComp=" & JobComponentNbr
                    Me.OpenWindow("Quote Vs Actual Summary", strURL, 636, 1203)

                Catch ex As Exception
                End Try

            Case "CB"
                OpenCreativeBrief(CStr(JobNumber), CStr(JobComponentNbr))
            Case "Schedule"
                Try
                    ''Dim save As Boolean = False
                    ''If PageEdit = True Then
                    ''    If IsBottomToolbar = False Then
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
                    ''    Else
                    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
                    ''    End If
                    ''    If save = False Then
                    ''        Exit Sub
                    ''    End If
                    ''End If
                    Session("FromWindow") = "jobtemplate"
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim x As Integer = oTrafficSchedule.CheckExistsClosed(JobNumber, JobComponentNbr)
                    Select Case x
                        Case 0, -2
                            Me.OpenWindow("", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & JobNumber & "/" & JobComponentNbr & "?JT=1")
                        Case -1
                            If Me.IsClientPortal = True Then
                                Me.ShowMessage("No Project Schedule exists for this Job")
                            Else
                                Me.OpenWindow("", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?JobNumber=" & JobNumber & "&JobComponentNumber=" & JobComponentNbr & "&JT=1")
                            End If
                    End Select
                Catch ex As Exception
                End Try
            'Case "po"
            '    ''Try
            '    ''    ''Dim save As Boolean = False
            '    ''    ''If PageEdit = True Then
            '    ''    ''    If IsBottomToolbar = False Then
            '    ''    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            '    ''    ''    Else
            '    ''    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
            '    ''    ''    End If
            '    ''    ''    If save = False Then
            '    ''    ''        Exit Sub
            '    ''    ''    End If
            '    ''    ''End If
            '    ''    Dim strURL As String
            '    ''    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            '    ''    strURL = "purchaseOrderbyJobCompPopup.aspx?JobNo=" & JobNumber & "&JobComp=" & JobComponentNbr
            '    ''    Me.OpenWindow("Purchase Orders", strURL)
            '    ''Catch ex As Exception
            '    ''End Try

            Case "Alerts"
                'Dim a As New cAlerts()
                'a.ClearAllAlertAppVars()

                Session("AlertsCurrentPageNumber") = 0

                Dim ThisJobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
                If Me.IsClientPortal = True Then

                    Me.OpenWindow("Alerts for Job:  " & JobNumber.ToString().PadLeft(6, "0") & "/" & JobComponentNbr.ToString().PadLeft(3, "0"), "Alert_Inbox.aspx?j=" & JobNumber.ToString() & "&jc=" & JobComponentNbr.ToString())
                Else
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                        ThisJobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNbr)
                    End Using
                    Me.OpenWindow("Alerts for Job:  " & JobNumber.ToString().PadLeft(6, "0") & "/" & JobComponentNbr.ToString().PadLeft(3, "0") & " - " & ThisJobComponent.Description, "Alert_Inbox.aspx?j=" & JobNumber.ToString() & "&jc=" & JobComponentNbr.ToString())
                End If


            'Case "Docs"
            '    ''Session("FromWindow") = "jobtemplate"
            '    ''''Dim save As Boolean = False
            '    ''''If PageEdit = True Then
            '    ''''    If IsBottomToolbar = False Then
            '    ''''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            '    ''''    Else
            '    ''''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
            '    ''''    End If
            '    ''''    If save = False Then
            '    ''''        'lblMSG.Text = "Save Failed!"
            '    ''''        Exit Sub
            '    ''''    End If
            '    ''''End If
            '    ''Me.OpenWindow("Documents for Job " & JobNumber & "-" & JobComponentNbr, "Documents_JobComponent.aspx?m=D&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr)
            'Case "Events"
            '    'Try
            '    '    ''Dim save As Boolean = False
            '    '    ''If PageEdit = True Then
            '    '    ''    If IsBottomToolbar = False Then
            '    '    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            '    '    ''    Else
            '    '    ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
            '    '    ''    End If
            '    '    ''    If save = False Then
            '    '    ''        'lblMSG.Text = "Save Failed!"
            '    '    ''        Exit Sub
            '    '    ''    End If
            '    '    ''End If
            '    '    Dim strURL As String
            '    '    Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            '    '    strURL = "Event_View.aspx?j=" & JobNumber & "&jc=" & JobComponentNbr & "&cli=" & Me.Client
            '    '    Me.OpenWindow("", strURL)
            '    'Catch ex As Exception
            '    'End Try
            Case "Estimate"
                Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                Session("FromWindow") = "jobtemplate"
                ''Dim save As Boolean = False
                ''If PageEdit = True Then
                ''    If IsBottomToolbar = False Then
                ''        save = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
                ''    Else
                ''        save = Me.SaveData(Me.RadComboBoxJobTemplateBottom.SelectedValue)
                ''    End If
                ''    If save = False Then
                ''        'lblMSG.Text = "Save Failed!"
                ''        Exit Sub
                ''    End If
                ''End If
                Dim dr As SqlDataReader
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                dr = oEstimating.GetEstJob(JobNumber, JobComponentNbr)
                If dr.HasRows = True Then
                    dr.Read()
                    If dr("ESTIMATE_NUMBER") <> 0 Then
                        Me.OpenWindow("Estimate", "Estimating.aspx?JT=1&EstNum=" & dr("ESTIMATE_NUMBER") & "&EstComp=" & dr("EST_COMPONENT_NBR") & "&newEst=edit")
                    Else
                        Me.OpenWindow("New Estimate", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    End If
                Else
                    Me.OpenWindow("New Estimate", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                End If


            Case "startSpell"
                'startSpell()
                ''Case "NewJobAlert"
                ''    Me.OpenWindow("New Alert", "Alert_New.aspx?caller=jobtemplate&f=" & CType(MiscFN.Source_App.JobJacket, Integer).ToString() & "&jt=1&j=" & JobNumber & "&jc=" & JobComponentNbr)
                ''Case "NewAlertAssignment"
                ''    Me.OpenWindow("New Alert", "Alert_New.aspx?caller=jobtemplate&assn=1&f=" & CType(MiscFN.Source_App.JobJacket, Integer).ToString() & "&jt=1&j=" & JobNumber & "&jc=" & JobComponentNbr)

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                    .UserCode = Session("UserCode")
                    .Name = "JC: " & Me.JobNumber.ToString() & "/" & Me.JobComponentNbr.ToString()
                    .PageURL = "JobTemplate.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "DL_EXTERNAL"

                'Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
                'Dim s As String = Deep.Build(AdvantageFramework.Web.DeepLink.LinkType.External, Me.CurrentQuerystring)

                'If String.IsNullOrWhiteSpace(s) = False Then

                '    Me.CopyToClipboard(s)

                'End If

        End Select

    End Sub

    Private Sub OpenCreativeBrief(ByVal jobNbr As String, ByVal compNbr As String)

        Try
            Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
            Dim strURL As String
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim existingtemps As Boolean

            Session("FromWindow") = "JT"
            Session("CBDeleted") = 0
            Session("CBNewSaved") = 1
            existingtemps = cb.ExistingTemplates(jobNbr, compNbr)
            If existingtemps = False Then
                If Me.IsClientPortal = True Then
                    Me.ShowMessage("No Creative Brief exist for this job.")
                Else
                    Session("CBNewSaved") = 0
                    Session("CBNewCanceled") = 0
                    Me.OpenWindow("", "CreativeBrief_New.aspx?JobNo=" & jobNbr & "&JobComp=" & compNbr)
                End If
            Else
                strURL = "CreativeBrief.aspx?JobNo=" & jobNbr & "&JobComp=" & compNbr
                Me.OpenWindow("Creative Brief", strURL)
            End If
        Catch ex As Exception
            Me.ShowMessage("error opening Creative Brief window")
        End Try

    End Sub

    Private Sub btnJobSpecs(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim qs As New AdvantageFramework.Web.QueryString

            If e.CommandName = "GoToJS" Then
                Dim js As New Job_Specs(Session("ConnString"))
                Dim dr As SqlDataReader
                Dim strURL As String = ""
                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                dr = js.GetJobSpecData(Me.JobNumber, Me.JobComponentNbr, -1, -1)
                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications
                If dr.HasRows = False Then
                    If Me.IsClientPortal = True Then
                        Me.ShowMessage("No Specifications exist for this job.")
                    Else
                        qs.Add("AddType", "4")
                        qs.Page = "jobspecs_AddNew.aspx"
                        Response.Redirect(qs.ToString(True))
                        'strURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr & "&AddType=4"
                        'Me.OpenWindow("", strURL)
                    End If
                Else
                    qs.Page = "jobspecs.aspx"
                    Response.Redirect(qs.ToString(True))
                    'strURL = "jobspecs.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                    'Me.OpenWindow("", strURL)
                End If
            End If
        Catch ex As Exception
            Me.ShowMessage("err opening job specs data window")
        End Try
    End Sub

    Private Sub btnProjectSchedule(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim qs As New AdvantageFramework.Web.QueryString

            If e.CommandName = "GoToTS" Then
                Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(JobNumber, JobComponentNbr)
                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                Select Case x
                    Case 0, -2
                        qs.Add("JT", "2")
                        qs.Page = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & qs.JobNumber & "/" & qs.JobComponentNumber
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "TrafficSchedule.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    Case -1
                        If Me.IsClientPortal = True Then
                            Me.ShowMessage("No Project Schedule exists for this Job")
                        Else
                            qs.Add("JT", "2")
                            qs.Add("JobNumber", qs.JobNumber)
                            qs.Add("JobComponentNumber", qs.JobComponentNumber)
                            qs.Page = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create"
                            Response.Redirect(qs.ToString(True))
                            'Me.OpenWindow("", "TrafficSchedule_AddNew.aspx?JT=1&j=" & JobNumber & "&jc=" & JobComponentNbr)
                        End If
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnContact(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbJobSpecs(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim qs As New AdvantageFramework.Web.QueryString

            If e.CommandName = "GoToJS" Then
                Dim js As New Job_Specs(Session("ConnString"))
                Dim dr As SqlDataReader
                Dim strURL As String = ""
                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                dr = js.GetJobSpecData(Me.JobNumber, Me.JobComponentNbr, -1, -1)
                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications
                If dr.HasRows = False Then
                    If Me.IsClientPortal = True Then
                        Me.ShowMessage("No Specifications exist for this job.")
                    Else
                        qs.Add("AddType", "4")
                        qs.Page = "jobspecs_AddNew.aspx"
                        Response.Redirect(qs.ToString(True))
                        'strURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr & "&AddType=4"
                        'Me.OpenWindow("", strURL)
                    End If
                Else
                    qs.Page = "jobspecs.aspx"
                    Response.Redirect(qs.ToString(True))
                    'strURL = "jobspecs.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                    'Me.OpenWindow("", strURL)
                End If
            End If

        Catch ex As Exception
            Me.ShowMessage("err opening job specs data window")
        End Try
    End Sub

    Private Sub lbProjectSchedule(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim qs As New AdvantageFramework.Web.QueryString

            If e.CommandName = "GoToTS" Then
                Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(JobNumber, JobComponentNbr)
                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                Select Case x
                    Case 0, -2
                        qs.Add("JT", "2")
                        qs.Page = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index/" & qs.JobNumber & "/" & qs.JobComponentNumber
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "TrafficSchedule.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    Case -1
                        If Me.IsClientPortal = True Then
                            Me.ShowMessage("No Project Schedule exists for this Job")
                        Else
                            qs.Add("JobNumber", qs.JobNumber)
                            qs.Add("JobComponentNumber", qs.JobComponentNumber)
                            qs.Add("JT", "2")
                            qs.Page = Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create"
                            Response.Redirect(qs.ToString(True))
                            'Me.OpenWindow("", "TrafficSchedule_AddNew.aspx?JT=1&j=" & JobNumber & "&jc=" & JobComponentNbr)
                        End If
                End Select
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnJobVersions(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim strURL As String
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim existingtemps As Boolean
            Dim qs As New AdvantageFramework.Web.QueryString

            'Session("FromWindow") = "jobtemplate"
            If e.CommandName = "GoToJV" Then
                existingtemps = jv.ExistingTemplates(Me.JobNumber, Me.JobComponentNbr)

                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                If existingtemps = False Then
                    'If Me.IsClientPortal = True Then
                    '    Me.ShowMessage("No Forms exist for this job.")
                    'Else
                    qs.Page = "jobVerNew.aspx"
                    'strURL = "jobVerNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                    Response.Redirect(qs.ToString(True))
                    'Me.OpenWindow("", strURL)
                    'End If
                Else
                    qs.Page = "jobVersions.aspx"
                    'strURL = "jobVersions.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                    Response.Redirect(qs.ToString(True))
                    Me.OpenWindow("", strURL)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEstimating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Session("FromWindow") = "jobtemplate"
            ''Dim save As Boolean = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            ''If save = False Then
            ''    'lblMSG.Text = "Save Failed!"
            ''    Exit Sub
            ''End If
            If e.CommandName = "GoToEST" Then

                Dim qs As New AdvantageFramework.Web.QueryString
                Dim dr As SqlDataReader
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                dr = oEstimating.GetEstJob(JobNumber, JobComponentNbr)

                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                If dr.HasRows = True Then
                    dr.Read()
                    If dr("ESTIMATE_NUMBER") <> 0 Then
                        qs.EstimateNumber = dr("ESTIMATE_NUMBER")
                        qs.EstimateComponentNumber = dr("EST_COMPONENT_NBR")
                        qs.Page = "Estimating.aspx"
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "Estimating.aspx?JT=1&EstNum=" & dr("ESTIMATE_NUMBER") & "&EstComp=" & dr("EST_COMPONENT_NBR") & "&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr & "&newEst=edit")
                    Else
                        qs.Page = "Estimating_AddNew.aspx"
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    End If
                Else
                    qs.Page = "Estimating_AddNew.aspx"
                    Response.Redirect(qs.ToString(True))
                    'Me.OpenWindow("", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbJobVersions(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim strURL As String
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim existingtemps As Boolean
            Dim qs As New AdvantageFramework.Web.QueryString

            'Session("FromWindow") = "jobtemplate"
            If e.CommandName = "GoToJV" Then
                existingtemps = jv.ExistingTemplates(Me.JobNumber, Me.JobComponentNbr)

                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                If existingtemps = False Then
                    'If Me.IsClientPortal = True Then
                    '    Me.ShowMessage("No Forms exist for this job.")
                    'Else
                    qs.Page = "jobVerNew.aspx"
                    'strURL = "jobVerNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                    Response.Redirect(qs.ToString(True))
                    'Me.OpenWindow("", strURL)
                    'End If
                Else
                    qs.Page = "jobVersions.aspx"
                    'strURL = "jobVersions.aspx?JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr
                    Response.Redirect(qs.ToString(True))
                    Me.OpenWindow("", strURL)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbEstimating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Session("FromWindow") = "jobtemplate"
            ''Dim save As Boolean = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            ''If save = False Then
            ''    'lblMSG.Text = "Save Failed!"
            ''    Exit Sub
            ''End If
            If e.CommandName = "GoToEST" Then
                Dim qs As New AdvantageFramework.Web.QueryString
                Dim dr As SqlDataReader
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                dr = oEstimating.GetEstJob(JobNumber, JobComponentNbr)

                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.IsJobDashboard = True
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                If dr.HasRows = True Then
                    dr.Read()
                    If dr("ESTIMATE_NUMBER") <> 0 Then
                        qs.EstimateNumber = dr("ESTIMATE_NUMBER")
                        qs.EstimateComponentNumber = dr("EST_COMPONENT_NBR")
                        qs.Page = "Estimating.aspx"
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "Estimating.aspx?JT=1&EstNum=" & dr("ESTIMATE_NUMBER") & "&EstComp=" & dr("EST_COMPONENT_NBR") & "&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr & "&newEst=edit")
                    Else
                        qs.Page = "Estimating_AddNew.aspx"
                        qs.Add("JT", "0")
                        qs.Add("newEst", "job")
                        Response.Redirect(qs.ToString(True))
                        'Me.OpenWindow("", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                    End If
                Else
                    qs.Page = "Estimating_AddNew.aspx"
                    qs.Add("JT", "0")
                    qs.Add("newEst", "job")
                    Response.Redirect(qs.ToString(True))
                    'Me.OpenWindow("", "Estimating_AddNew.aspx?JT=1&JobNum=" & JobNumber & "&JobComp=" & JobComponentNbr)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnComments(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Try
            ''Dim save As Boolean = Me.SaveData(Me.RadComboBoxJobTemplateTop.SelectedValue)
            ''If save = False Then
            ''    Exit Sub
            ''End If

            Dim jv As New JobVersion(Session("ConnString"))
            Dim strURL As String
            Dim title As String

            If e.CommandArgument = "JOBCOMMENTS" Then
                strURL = "popcomments.aspx?Type=jobcomments&JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                title = "Job Comments"
            End If
            If e.CommandArgument = "JOBCOMPCOMMENTS" Then
                strURL = "popcomments.aspx?Type=jobcompcomments&JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                title = "Component Comments"
            End If
            If e.CommandArgument = "CREATIVEINSTR" Then
                strURL = "popcomments.aspx?Type=creativeinstr&JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                title = "Creative Instructions"
            End If
            If e.CommandArgument = "JOBDELINSTRUCT" Then
                strURL = "popcomments.aspx?Type=jobdelinstruct&JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr
                title = "Shipping Instructions"
            End If

            If e.CommandName = "GoToComments" Then
                'With Me.RadWindowManager.Windows(0)
                '    .NavigateUrl = strURL
                '    .Title = title
                '    .Modal = True
                '    .Height = New Unit(410, UnitType.Pixel)
                '    .Width = New Unit(690, UnitType.Pixel)
                '    .InitialBehavior = Telerik.Web.UI.WindowBehaviors.None
                '    .ReloadOnShow = True
                '    .Behavior = Telerik.Web.UI.WindowBehaviors.None
                '    .VisibleOnPageLoad = True
                '    .VisibleStatusbar = False
                'End With
                Me.OpenWindow("Comments", strURL, 0, 0, False, False, "RefreshPage")
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " SubRoutines "


    Private Sub SetButtonVisibility(ByVal PageIsInEdit As Boolean)

        'objects
        Dim secView As String = ""
        Dim secEdit As String = ""
        Dim secInsert As String = ""

        secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
        secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
        secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

        If (secView = "" Or secView = "N") AndAlso Me.IsClientPortal = False Then

            rights = "N"

            Me.RadToolbarJobTemplateTop.FindItemByValue("Print").Enabled = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("SendAlert").Enabled = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("SendEmail").Enabled = False
            Me.RadToolbarJobTemplateTop.FindItemByValue("PrintSendOptions").Enabled = False

        Else

            Me.RadToolbarJobTemplateTop.FindItemByValue("Print").Enabled = True
            Me.RadToolbarJobTemplateTop.FindItemByValue("SendAlert").Enabled = True
            Me.RadToolbarJobTemplateTop.FindItemByValue("SendEmail").Enabled = True
            Me.RadToolbarJobTemplateTop.FindItemByValue("PrintSendOptions").Enabled = True

        End If

        If secEdit = "N" Then

            If Request.QueryString("NewJob") = "1" OrElse Request.QueryString("NewComp") = "new" Then

                RadToolBarButtonSaveJT.Enabled = True

            Else

                RadToolBarButtonSaveJT.Enabled = False

            End If

            PageEdit = False

        Else

            RadToolBarButtonSaveJT.Enabled = True

        End If

        If secInsert = "N" Then

            RadToolBarButtonNewCompJT.Enabled = False
            RadToolBarButtonNewJT.Enabled = False

        Else

            RadToolBarButtonNewCompJT.Enabled = True
            RadToolBarButtonNewJT.Enabled = True

        End If

        Dim access As Integer
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Specifications, False)
        If access = 0 Then
            Me.RadToolBarButtonJobSpecs.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False)
        If access = 0 Then
            Me.RadToolBarButtonJobVersion.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_QuotevsActualsDQ, False)
        If access = 0 Then
            Me.RadToolBarButtonQvA.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectEvents, False)
        If access = 0 Then
            Me.RadToolbarButtonEvent.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating, False)
        If access = 0 Then
            Me.RadToolBarButtonEstimate.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief, False)
        If access = 0 Then
            Me.RadToolBarButtonCreativeBrief.Visible = False
        End If
        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False)
        If access = 0 Then
            Me.RadToolBarButtonSchedule.Visible = False
        End If

        If Me.IsClientPortal = True Then
            access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents, False)
            If access = 0 Then
                Me.RadToolBarButtonDocs.Visible = False
            End If
        Else
            access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False)
            If access = 0 Then
                Me.RadToolBarButtonDocs.Visible = False
            Else

                RadToolBarButtonDocs.Visible = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False))

            End If

        End If

        access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False)
        If access = 0 Then
            Me.RadToolBarButtonAlert.Visible = False
        End If

        If Me.IsClientPortal = True Then
            Me.RadToolbarButtonRadComboBoxJobTemplateTop.Visible = False
            Me.RadToolBarButtonSaveJT.Visible = False
            Me.RadToolBarButtonNewJT.Visible = False
            Me.RadToolBarButtonNewCompJT.Visible = False
            Me.RadToolBarButtonEstimate.Visible = False
            Me.RadToolBarButtonQvA.Visible = False
            Me.RadToolBarButtonPO.Visible = False
            Me.RadToolbarButtonEvent.Visible = False
            Me.RadToolbarButtonNewAlertAssignment.Visible = False
            Me.RadToolBarButtonSpellCheck.Visible = False
            Me.RadToolbarJobTemplateTop.Items(2).Visible = False
            Me.RadToolbarJobTemplateTop.Items(4).Visible = False
            Me.RadToolbarJobTemplateTop.Items(6).Visible = False
            Me.RadToolbarJobTemplateTop.Items(8).Visible = False
            'Me.RadToolbarJobTemplateTop.Items(25).Visible = False

        End If

    End Sub

    Private Sub ShowTemplatesDDL(ByVal PageIsInEdit As Boolean)
        If PageIsInEdit = True Then
            'lblChangeTemplate.Visible = False
            'dropValue_Template.Visible = False
            'droplist.Visible = True
            'labellist.Visible = True
        Else
            'lblChangeTemplate.Visible = False
            'dropValue_Template.Visible = False
            'droplist.Visible = False
            'labellist.Visible = False
        End If
    End Sub

    Public Sub BindDropTemplates(Optional ByVal CurrValue As String = "")
        Dim MyDrop As cDropDowns = New cDropDowns(Session("ConnString"))
        'With Me.dropValue_Template
        '    .DataSource = MyDrop.GetJobTemplatesList()
        '    .DataValueField = "Code"
        '    .DataTextField = "Description"
        '    .DataBind()
        'End With
        Dim curFoundinDD As Boolean = False

        With Me.RadComboBoxJobTemplateTop
            .DataSource = MyDrop.GetJobTemplatesList
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
        End With

        'Add possible inactive CurrValue template to list if inactive
        Dim templateDesc As String = ""
        Try
            If CurrValue <> "" Then
                If isTemplateActive(CurrValue) = False Then
                    templateDesc = getTemplateDesc(CurrValue)
                    Dim itm As New Telerik.Web.UI.RadComboBoxItem
                    With itm
                        .Text = templateDesc & "*"
                        .Value = CurrValue
                        .Selected = True
                    End With
                    Me.RadComboBoxJobTemplateTop.Items.Insert(0, itm)
                Else
                    Me.RadComboBoxJobTemplateTop.FindItemByValue(CurrValue).Selected = True
                End If
            End If
        Catch ex As Exception
        Finally
        End Try


    End Sub

    Private Function isTemplateActive(ByVal jobTemplateCode As String) As Boolean
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim inactive As Int16

        SQL_STRING = " SELECT INACTIVE_FLAG "
        SQL_STRING += " FROM JOB_TMPLT_HDR "
        SQL_STRING += " WHERE JOB_TMPLT_CODE = '" & jobTemplateCode & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:JobTemplate.aspx Routine:isTemplateActive", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()


            If IsDBNull(dr("INACTIVE_FLAG")) Then
                inactive = 0
            Else
                inactive = dr.GetInt16(0)
            End If

            If inactive = 1 Then ' only inactive if = 1
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If



    End Function

    Private Function getTemplateDesc(ByVal jobTemplateCode As String) As String
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim TemplateDesc As String

        SQL_STRING = " SELECT JOB_TMPLT_DESC "
        SQL_STRING += " FROM JOB_TMPLT_HDR "
        SQL_STRING += " WHERE JOB_TMPLT_CODE = '" & jobTemplateCode & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:jobtemplate.ascx Routine:getTemplateDesc", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            If IsDBNull(dr.GetString(0)) Then
                TemplateDesc = jobTemplateCode
            Else
                TemplateDesc = dr.GetString(0)
            End If

        Else
            TemplateDesc = jobTemplateCode
        End If

        Return TemplateDesc
    End Function

    Private Sub SetPageMode(ByVal TheJobNum As Integer, ByVal TheCompNum As Integer)
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If myVal.ValidateJobIsOpen(TheJobNum, TheCompNum) = True Then
                If Not Request.QueryString("PageMode") Is Nothing Then
                    If Request.QueryString("PageMode") = "Edit" Then
                        PageEdit = True
                    Else
                        PageEdit = False
                        Client = ""
                        Division = ""
                        Product = ""
                        Office = ""
                        SalesClass = ""
                        AE = ""
                        JobNumber = 0
                        JobComponentNbr = 0
                        Closed = False
                    End If
                Else
                    PageEdit = False
                    Client = ""
                    Division = ""
                    Product = ""
                    Office = ""
                    SalesClass = ""
                    AE = ""
                    JobNumber = 0
                    JobComponentNbr = 0
                    Closed = False
                End If
            Else
                If Not Request.QueryString("PageMode") Is Nothing Then
                    If Request.QueryString("PageMode") = "Edit" Then
                        PageEdit = True
                    Else
                        PageEdit = False
                        Client = ""
                        Division = ""
                        Product = ""
                        Office = ""
                        SalesClass = ""
                        AE = ""
                        JobNumber = 0
                        JobComponentNbr = 0
                        Closed = False
                    End If
                Else
                    PageEdit = False
                    Client = ""
                    Division = ""
                    Product = ""
                    Office = ""
                    SalesClass = ""
                    AE = ""
                    JobNumber = 0
                    JobComponentNbr = 0
                    Closed = False
                End If
            End If
            SetButtonVisibility(PageEdit)
        Catch ex As Exception
            lblMSG.Text = "Error<br />" & ex.Message.ToString
        Finally
        End Try
    End Sub

    Private Sub setJVDesc()
        Dim ReturnString As String = ""

        Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
        ReturnString = MyJV.GetAgencyDesc()

        If ReturnString <> "" Then
            With Me.RadToolBarButtonJobVersion
                .ToolTip = ReturnString
            End With
        End If

    End Sub

    Private Sub CheckUserRightsEst()
        Dim SessionKey As String = "CheckUserRightsEst" & JobNumber.ToString() & JobComponentNbr.ToString()
        Dim EstimateNumber As Integer = 0

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim dr As SqlDataReader
                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                dr = oEstimating.GetEstJob(JobNumber, JobComponentNbr)
                If dr.HasRows = True Then
                    dr.Read()
                    EstimateNumber = CType(dr("ESTIMATE_NUMBER"), Integer)
                    dr.Close()
                End If
            Catch ex As Exception
                EstimateNumber = 0
            End Try

            HttpContext.Current.Session(SessionKey) = EstimateNumber
        Else
            EstimateNumber = CType(HttpContext.Current.Session(SessionKey), Integer)
        End If

        If Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating) = False And EstimateNumber = 0 Then
            Me.RadToolBarButtonEstimate.Enabled = False
        End If

    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

            If secView = "N" Then
                rights = "N"
            End If

            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")

            If secInsert = "N" And Me.IsClientPortal = False Then
                Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(JobNumber, JobComponentNbr)
                Select Case x
                    Case -1
                        Me.RadToolBarButtonSchedule.Enabled = False
                End Select
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region " To be refactored to cJobs "

    Private Function SaveChangedData(ByVal TemplateCode As String, ByRef ErrorMessage As String) As Boolean

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent) = Nothing
            Dim JobComponentSave As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim HasComponentChange As Boolean = False
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            Dim oReqCheck As cRequired = New cRequired(CStr(Session("ConnString")))
            Dim oValidations As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim oJob As Job = New Job(Session("ConnString"))
            Dim oAgency As New cAgency(Session("ConnString"))
            Dim ocJobs As New cJobs(Session("ConnString"))
            Dim camp As New cCampaign(Session("ConnString"))
            Dim SaveSuccessful As Boolean = False
            Dim SaveMessageReturn As String = ""
            Dim SaveTemplate As Boolean = False

            oJob.GetJob(JobNumber, JobComponentNbr)

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNbr)

            'JobComponents = Job.JobComponents.Where(Function(Entity) Entity.JobProcessNumber <> 6 AndAlso Entity.JobProcessNumber <> 12 AndAlso
            '                                        (Entity.IsAdvanceBilling Is Nothing OrElse Entity.IsAdvanceBilling = 0 OrElse Entity.IsAdvanceBilling = 2)).ToList

            'If JobComponents.Count > 0 Then
            '    'update all here
            '    Dim JobComponentRow As Integer = 1
            '    While JobComponentRow <= JobComponents.Count
            '        JobComponents(JobComponentRow).ModifiedDate = Date.Now
            '        JobComponents(JobComponentRow).ModifiedBy = Session("UserCode")
            '    End While
            'End If

            Dim DefaultTaxCode As String = ""
            Try
                DefaultTaxCode = MyJobTemplate.GetDefaultTaxCode(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
            Catch ex As Exception
                DefaultTaxCode = ""
            End Try

            Try

                If JobComponent.JobTemplateCode <> TemplateCode Then

                    JobComponent.JobTemplateCode = TemplateCode
                    HasComponentChange = True

                End If

            Catch ex As Exception
            End Try

            Try

                LoGlo.PageCultureSetDatabaseAndUser(Me.Page)

                With MyJobTemplate
                    dtUserData = .CreateUserDataDataTable(Page) 'Get the form data
                    .UpdateDTFormValues(dtFormData, dtUserData)
                End With

                Dim dvChanges As DataView = New DataView(dtFormData)
                dvChanges.Table.CaseSensitive = True

                'Set the datatable to filter only changed rows
                Dim StrDefaultFilter As String = ""

                Dim SbDefaultFilter As New System.Text.StringBuilder
                With SbDefaultFilter
                    .Append("(")

                    'exclusions
                    .Append("(ItemCode <> 'JOB_LOG.JOB_NUMBER')")
                    .Append(" AND ")
                    .Append("(ItemCode <> 'JOB_COMPONENT.JOB_NUMBER')")
                    .Append(" AND ")
                    .Append("(ItemCode <> 'JOB_LOG.JOB_COMPONENT_NBR')")
                    .Append(" AND ")
                    '.Append("(ItemCode <> 'JOB_LOG.CL_CODE')")
                    '.Append(" AND ")
                    '.Append("(ItemCode <> 'JOB_LOG.DIV_CODE')")
                    '.Append(" AND ")
                    '.Append("(ItemCode <> 'JOB_LOG.PRD_CODE')")
                    '.Append(" AND ")
                    '.Append("DBValue NOT LIKE '%&nbsp;-&nbsp;%'")
                    '.Append(" AND ")
                    'inclusions
                    .Append("(ItemCode LIKE 'JOB_LOG%' OR ItemCode LIKE 'JOB_COMPONENT%' OR ItemCode LIKE 'JOB_CLIENT_REF%' OR ItemCode LIKE 'SERVICE_FEE_TYPE_ID%')")
                    .Append(" AND ")
                    .Append("(DBValue <> FormValue)")

                    .Append(")")
                End With

                StrDefaultFilter = SbDefaultFilter.ToString()

                'Include the tax flag and tax code regardless if changed or not
                Dim StrIncludeTaxFilter As String = " OR ItemCode = 'JOB_COMPONENT.TAX_FLAG' OR ItemCode = 'JOB_COMPONENT.TAX_CODE'"

                'only force the tax change if there are rows
                Dim dvChanges2 As DataView = New DataView(dtFormData)
                Dim dtChanges2 As DataTable = New DataTable
                dvChanges2.Table.CaseSensitive = True
                dvChanges2.RowFilter = StrDefaultFilter
                dtChanges2 = dvChanges2.ToTable()
                If dtChanges2.Rows.Count > 0 Then
                    StrDefaultFilter &= StrIncludeTaxFilter
                End If

                dvChanges.RowFilter = StrDefaultFilter

                Dim dtChanges As DataTable = New DataTable
                dtChanges = dvChanges.ToTable()
                dtEdits = dvChanges.ToTable()

                ''Just testing by outputting to gridview
                If GridViewFormData.Visible = True Then
                    With GridViewFormData
                        .DataSource = dtFormData
                        .DataBind()
                    End With
                End If
                If GridViewUserData.Visible = True Then
                    With GridViewUserData
                        .DataSource = dtUserData
                        .DataBind()
                    End With
                End If
                If GridViewChanges.Visible = True Then
                    With GridViewChanges
                        .DataSource = dtChanges
                        .DataBind()
                    End With
                End If
                If GridViewFormData.Visible = True Or GridViewUserData.Visible = True Or GridViewChanges.Visible = True Then
                    Exit Function
                End If

                Dim IsTaxable As Boolean = False

                'Validate user input
                If dtChanges.Rows.Count > 0 And Page.IsValid Then
                    Try
                        Dim dtAllLookUps As DataTable = New DataTable
                        Dim sbInvalid As StringBuilder = New StringBuilder
                        Dim strSHORT_DESC As String = String.Empty
                        Dim IsValidUserData As Boolean = True
                        dtAllLookUps = MyJobTemplate.CreateLookupDataTable(JobNumber, JobComponentNbr)

                        dtAllLookUps.CaseSensitive = True

                        'Create dataview of ALL lookups:
                        Dim dvLookups As DataView = New DataView(dtAllLookUps)

                        'loop through all the changes in the changes datatable
                        For i As Integer = 0 To dtChanges.Rows.Count - 1
                            'Create another dataview to hold possible values for one lookup type.
                            Dim dvFilter As New DataView
                            'set the filter dataview to include all the lookups
                            dvFilter = dvLookups
                            'filter it to one type
                            dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "'"

                            'Check tax flag and whether tax code is checked
                            If InStr(dtChanges.Rows(i)("ItemCode"), "TAX_FLAG") > 0 Then
                                If oReqCheck.JobCompIsTaxableVisible = True Then
                                    If dtChanges.Rows(i)("FormValue").ToString() = "1" Then
                                        taxflag = True
                                    End If
                                    If oReqCheck.JobCompIsTaxable(Me.Client) = True Then
                                        'IsTaxable = True
                                        If Not dtChanges.Rows(i)("FormValue") Is Nothing Then
                                            If dtChanges.Rows(i)("FormValue") = "1" Then
                                                IsTaxable = True
                                            Else
                                                IsTaxable = False
                                            End If
                                        Else
                                            ErrorMessage = "This component must be marked taxable or not; please select Yes/No"
                                            Return False
                                        End If
                                    End If
                                End If
                            End If

                            'If taxable, make sure a code is applied
                            If InStr(dtChanges.Rows(i)("ItemCode"), "TAX_CODE") > 0 And IsTaxable = True Or InStr(dtChanges.Rows(i)("ItemCode"), "TAX_CODE") > 0 And taxflag = True Then
                                If dtChanges.Rows(i)("FormValue") = "" And DefaultTaxCode = "" Then
                                    ErrorMessage = "Component is marked taxable and no tax code has been set"
                                    Return False
                                End If
                            End If

                            'jtg - Post QA issue 758 - specifically validate job qty as numeric
                            'Validate Job Quantity is numeric
                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_QTY") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length > 0 And IsNumeric(dtChanges.Rows(i)("FormValue")) = False Then
                                    ErrorMessage = "Please enter a valid number for Job Quantity"
                                    Return False
                                ElseIf dtChanges.Rows(i)("FormValue").ToString().Length > 0 And IsNumeric(dtChanges.Rows(i)("FormValue")) = True Then
                                    Try
                                        dtChanges.Rows(i)("FormValue") = CType(dtChanges.Rows(i)("FormValue"), Integer).ToString()
                                    Catch ex As Exception
                                    End Try
                                End If
                            End If
                            If InStr(dtChanges.Rows(i)("ItemCode"), "OFFICE_CODE") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length = 0 Then
                                    ErrorMessage = "Please select an office"
                                    Return False
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "CL_CODE") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length = 0 Then
                                    ErrorMessage = "Please select an Client"
                                    Return False
                                Else
                                    ClientChange = dtChanges.Rows(i)("FormValue").ToString()
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "DIV_CODE") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length = 0 Then
                                    ErrorMessage = "Please select an Division"
                                    Return False
                                Else
                                    DivisionChange = dtChanges.Rows(i)("FormValue").ToString()
                                    If ClientChange = "" Then
                                        ClientChange = Client
                                    End If
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "PRD_CODE") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length = 0 Then
                                    ErrorMessage = "Please select an Product"
                                    Return False
                                Else
                                    ProductChange = dtChanges.Rows(i)("FormValue").ToString()
                                    If ClientChange = "" Then
                                        ClientChange = Client
                                    End If
                                    If DivisionChange = "" Then
                                        DivisionChange = Division
                                    End If
                                End If
                            End If

                            'Check for valid CDP
                            If ClientChange <> "" And DivisionChange <> "" And ProductChange <> "" And (i + 1 = dtChanges.Rows.Count) Then
                                If oValidations.ValidateCDP(Me.ClientChange, Me.DivisionChange, Me.ProductChange, True) = False Then
                                    Me.ShowMessage("Invalid Client, Division, Product!")
                                    Exit Function
                                End If

                                If oValidations.ValidateCDPIsViewable("PR", Session("UserCode"), Me.ClientChange.Trim, Me.DivisionChange.Trim, Me.ProductChange.Trim) = False Then
                                    Me.ShowMessage("Access to this Client,Division,Product is denied.")
                                    Exit Function
                                End If
                                Dim AccExec As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
                                Try
                                    AccExec = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, ClientChange, DivisionChange, ProductChange).First
                                Catch ex As Exception
                                End Try
                                Dim ae As String = MyJobTemplate.GetDefaultAE(ClientChange, DivisionChange, ProductChange)
                                If ae = "" And AccExec Is Nothing Then
                                    Me.ShowMessage("Invalid Client, Division, Product. No Account Executive assigned to this Product.")
                                    Exit Function
                                End If

                                Try
                                    DefaultTaxCode = MyJobTemplate.GetDefaultTaxCode(Me.ClientChange.Trim, Me.DivisionChange.Trim, Me.ProductChange.Trim)
                                Catch ex As Exception
                                    DefaultTaxCode = ""
                                End Try
                            End If

                            ''Date check handled by control
                            ''Check for valid dates
                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_FIRST_USE_DATE") > 0 Then
                                If dtChanges.Rows(i)("FormValue") <> "" Then
                                    'If cGlobals.wvIsDate(dtChanges.Rows(i)("FormValue")) = False Then
                                    '    ErrorMessage = "Due date is not a valid date"
                                    '    Return False
                                    'Else
                                    dtChanges.Rows(i).Item(3) = cGlobals.wvCDate(dtChanges.Rows(i)("FormValue"))
                                    'End If
                                End If
                            End If
                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_COMP_DATE") > 0 Then
                                If dtChanges.Rows(i)("FormValue") <> "" Then
                                    'If cGlobals.wvIsDate(dtChanges.Rows(i)("FormValue")) = False Then
                                    '    ErrorMessage = "Date Opened date is not a valid date"
                                    '    Return False
                                    'Else
                                    dtChanges.Rows(i).Item(3) = cGlobals.wvCDate(dtChanges.Rows(i)("FormValue"))
                                    'End If
                                End If
                            End If
                            If InStr(dtChanges.Rows(i)("ItemCode"), "START_DATE") > 0 Then
                                If dtChanges.Rows(i)("FormValue") <> "" Then
                                    'If cGlobals.wvIsDate(dtChanges.Rows(i)("FormValue")) = False Then
                                    '    ErrorMessage = "Start date is not a valid date"
                                    '    Return False
                                    'Else
                                    dtChanges.Rows(i).Item(3) = cGlobals.wvCDate(dtChanges.Rows(i)("FormValue"))
                                    'End If
                                End If
                            End If

                            'Check Client PO length
                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_CL_PO_NBR") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length > 40 Then
                                    ErrorMessage = "Client PO cannot exceed 40 characters"
                                    Return False
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_MARKUP_PCT") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length > 0 And IsNumeric(dtChanges.Rows(i)("FormValue").replace("%", "")) = False Then
                                    ErrorMessage = "Please enter a valid number for Job Component markup"
                                    Return False
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_COMP_BUDGET_AM") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString().Length = 0 Or dtChanges.Rows(i)("FormValue").ToString() = "" Or dtChanges.Rows(i)("FormValue").ToString() = String.Empty Then
                                    dtChanges.Rows(i)("FormValue") = "0"
                                End If

                                If IsNumeric(dtChanges.Rows(i)("FormValue").ToString().Replace(",", "").Replace("$", "")) = False Then
                                    ErrorMessage = "Please enter a valid number for job component budget"
                                    Return False
                                Else
                                    dtChanges.Rows(i)("FormValue") = dtChanges.Rows(i)("FormValue").ToString().Replace("$", "")
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "EMAIL_GR_CODE") > 0 Then
                                If oReqCheck.RequiredEmailGroupCode(Me.Client) = True Then
                                    If dtChanges.Rows(i)("FormValue").ToString() = "" Then
                                        ErrorMessage = "Please select an email group"
                                        Return False
                                    End If
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "ACCT_NBR") > 0 Then
                                If oReqCheck.RequiredJCAccountNumber = True Then
                                    If dtChanges.Rows(i)("FormValue").ToString() = "" Then
                                        ErrorMessage = "Please enter a Job Component Account Number"
                                        Return False
                                    End If
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "CMP_CODE") > 0 And dtChanges.Rows(i)("FormValue").ToString().Trim() <> "" Then
                                Dim cmptype As Integer
                                Dim cmpid As Integer = ocJobs.GetCampaignIdentifier(dtChanges.Rows(i)("FormValue").ToString(), oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
                                Dim drcmp As SqlDataReader = camp.GetCampaignByCmpIdentifier(cmpid)
                                If drcmp.HasRows = True Then
                                    drcmp.Read()
                                    cmptype = drcmp("CMP_TYPE")
                                    drcmp.Close()
                                End If
                                If cmpid = 0 Or cmptype = 1 Then
                                    ErrorMessage = "Please enter a valid campaign"
                                    Return False
                                End If
                            End If

                            If InStr(dtChanges.Rows(i)("ItemCode"), "FORMAT_CODE") > 0 And dtChanges.Rows(i)("FormValue").ToString().Trim() <> "" Then
                                If oValidations.ValidateSalesClassFormat(oJob.SC_CODE, dtChanges.Rows(i)("FormValue").ToString()) = False Then
                                    ErrorMessage = "Please enter a valid Sales Class Format"
                                    Return False
                                End If
                            End If

                            ''''BLACKPLATE VALIDATION MOVED TOWARD THE END OF THIS FUNCTION

                            If InStr(dtChanges.Rows(i)("ItemCode"), "JOB_COMP_BUDGET_AM") > 0 Then
                                If dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                    Dim value As String = dtChanges.Rows(i)("FormValue").ToString
                                    If IsNumeric(value) = False Then
                                        ErrorMessage = "Component Budget invalid"
                                        Return False
                                    End If
                                End If
                            End If

                            'ad number
                            If InStr(dtChanges.Rows(i)("ItemCode"), "AD_NBR") > 0 And dtChanges.Rows(i)("FormValue").ToString().Trim() <> "" Then
                                If oValidations.ValidateAdNumber(dtChanges.Rows(i)("FormValue").ToString()) = False Then
                                    ErrorMessage = "Ad Number invalid"
                                    Return False
                                End If
                            End If

                            If dvFilter.ToTable.Rows.Count > 0 Then ' Less than zero means it doesn't have a lookup
                                strSHORT_DESC = dvFilter.ToTable.Rows(0)("SHORT_DESC")
                                'refilter
                                Dim s As String = dtChanges.Rows(i)("FormValue").ToString
                                If dtChanges.Rows(i)("FormValue") <> "" Then 'Make sure we don't validate a change to empty data
                                    dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "' AND code = '" & dtChanges.Rows(i)("FormValue").ToString().Replace("'", "") & "'"
                                    If dvFilter.ToTable.Rows.Count <= 0 Then 'Not valid lookup
                                        With sbInvalid
                                            .Append("Invalid ")
                                            .Append(strSHORT_DESC)
                                            .Append("<br />")
                                        End With
                                        IsValidUserData = False
                                    End If
                                End If

                            Else

                                Dim ItemCode As String = dtChanges.Rows(i)("ItemCode")
                                Dim CustomField As String = ""
                                If ItemCode.Contains("UDV") = True Then

                                    Select Case ItemCode
                                        Case "JOB_LOG.UDV1_CODE"
                                            CustomField = "Job Custom 1"
                                        Case "JOB_LOG.UDV2_CODE"
                                            CustomField = "Job Custom 2"
                                        Case "JOB_LOG.UDV3_CODE"
                                            CustomField = "Job Custom 3"
                                        Case "JOB_LOG.UDV4_CODE"
                                            CustomField = "Job Custom 4"
                                        Case "JOB_LOG.UDV5_CODE"
                                            CustomField = "Job Custom 5"
                                        Case "JOB_COMPONENT.UDV1_CODE"
                                            CustomField = "Job Custom Component 1"
                                        Case "JOB_COMPONENT.UDV2_CODE"
                                            CustomField = "Job Custom Component 2"
                                        Case "JOB_COMPONENT.UDV3_CODE"
                                            CustomField = "Job Custom Component 3"
                                        Case "JOB_COMPONENT.UDV4_CODE"
                                            CustomField = "Job Custom Component 4"
                                        Case "JOB_COMPONENT.UDV5_CODE"
                                            CustomField = "Job Custom Component 5"
                                    End Select

                                    CustomField = CustomField & " is set to &quot;Use Lookup&quot; but does not have any lookup values defined."
                                    ItemCode = ItemCode.Replace(".", "_").Replace("_CODE", "")

                                    If MyJobTemplate.UserDefinedFieldAllowsUserEntry(ItemCode) = False Then ' udf set to be a lookup but no look up values

                                        With sbInvalid
                                            .Append(CustomField)
                                            .Append("<br />")
                                        End With
                                        IsValidUserData = False

                                    End If

                                End If
                            End If

                        Next

                        If IsValidUserData = False Then
                            ErrorMessage = "Your input had the following validation problems:  " & sbInvalid.ToString()
                            Return False
                        End If

                    Catch ex As Exception
                        ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                        Return False
                    End Try
                End If

                Dim IsNewJob As Boolean = False
                Dim IsNewJobComponent As Boolean = False

                Try
                    If Not Request.QueryString("NewJob") Is Nothing Then
                        If CType(Request.QueryString("NewJob"), Integer) = 1 Then
                            IsNewJob = True
                        End If
                    End If
                Catch ex As Exception
                    IsNewJob = False
                End Try
                Try
                    If Not Request.QueryString("NewComp") Is Nothing Then
                        If Request.QueryString("NewComp").ToString().Trim().ToLower() = "new" Then
                            IsNewJobComponent = True
                        End If
                    End If
                Catch ex As Exception
                    IsNewJobComponent = False
                End Try

                Try
                    If (dtChanges.Rows.Count > 0 OrElse HasComponentChange = True) AndAlso Page.IsValid Then
                        'stringbuilders for sql
                        Dim sbJobUpdate As StringBuilder = New StringBuilder
                        Dim sbJobCompUpdate As StringBuilder = New StringBuilder
                        Dim sbJobCliRef As StringBuilder = New StringBuilder
                        Dim sbJobUDF As StringBuilder = New StringBuilder
                        Dim sbJobCompUDF As StringBuilder = New StringBuilder
                        Dim sbJobEstSC As StringBuilder = New StringBuilder
                        Dim SbEstimate As StringBuilder = New StringBuilder

                        'stringbuilder for alert
                        Dim sbAlertEmail As StringBuilder = New StringBuilder

                        sbJobUpdate.Append("UPDATE JOB_LOG SET ")
                        sbJobCompUpdate.Append("UPDATE JOB_COMPONENT SET ")
                        sbJobCliRef.Append("UPDATE JOB_CLIENT_REF SET ")

                        Dim JobHasChange As Boolean = False
                        Dim CompHasChange As Boolean = False
                        Dim JobCliRefHasChange As Boolean = False
                        Dim parametertJobCompDate As New SqlParameter("@jcdate", SqlDbType.SmallDateTime)
                        Dim parametertJobFirstUseDate As New SqlParameter("@jfuddate", SqlDbType.SmallDateTime)
                        Dim parametertStartDate As New SqlParameter("@sdate", SqlDbType.SmallDateTime)
                        Dim parametertbudget As New SqlParameter("@budget", SqlDbType.Decimal)
                        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                        Dim arParams(4) As SqlParameter

                        Dim HasBlackplate1 As Boolean = False
                        Dim HasBlackplate2 As Boolean = False

                        Dim Blackplate1_Code As String = ""
                        Dim Blackplate1_Description As String = ""
                        Dim Blackplate2_Code As String = ""
                        Dim Blackplate2_Description As String = ""


                        Dim Blackplate1_Complete As Boolean = False
                        Dim Blackplate2_Complete As Boolean = False
                        Dim CampaignCode As String = ""
                        Dim CampaignID As Integer = 0
                        'This is main loop that builds the change sql
                        'includes DBValue field which is data pulled from db
                        'and FormValue field which is data pulled from form

                        Dim JobCheck As AdvantageFramework.Database.Entities.Job = Nothing
                        JobCheck = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                        Dim JobChangeCount As Integer = 0

                        For i As Integer = 0 To dtChanges.Rows.Count - 1
                            If InStr(dtChanges.Rows(i)("ItemCode"), "_LOG") > 0 Then
                                If ClientChange <> "" And ClientChange.Trim <> JobCheck.ClientCode And DivisionChange <> "" And DivisionChange.Trim <> JobCheck.DivisionCode And ProductChange <> "" And ProductChange.Trim <> JobCheck.ProductCode Then

                                    If dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.JOB_ESTIMATE_REQ" And oReqCheck.OverrideApprovedEstimate = False And oReqCheck.RequiredApprovedEstimate(ClientChange, DivisionChange, ProductChange) = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '1', ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV1_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV1") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV1 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV1 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV2_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV2") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV2 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV2 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV3_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV3") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV3 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV3 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV4_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV4") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV4 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV4 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV5_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV5") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV5 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV5 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.SC_CODE" Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        Dim dr As SqlDataReader = est.GetEstimateNumJob(Me.JobNumber.ToString())
                                        If dr.HasRows = True Then
                                            dr.Read()
                                            If dr("ESTIMATE_NUMBER") <> 0 Then
                                                sbJobEstSC.Append("UPDATE ESTIMATE_LOG SET SC_CODE = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE ESTIMATE_NUMBER = '" & dr("ESTIMATE_NUMBER") & "'")
                                            End If
                                        End If
                                    Else
                                        If dtChanges.Rows(i)("ItemCode").ToString() <> "JOB_LOG.CMP_CODE" Then
                                            sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        End If
                                    End If
                                Else
                                    If dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.JOB_ESTIMATE_REQ" And oReqCheck.OverrideApprovedEstimate = False And oReqCheck.RequiredApprovedEstimate(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE) = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '1', ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV1_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV1") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV1 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV1 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV2_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV2") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV2 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV2 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV3_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV3") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV3 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV3 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV4_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV4") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV4 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV4 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.UDV5_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_LOG_UDV5") = True Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "', ")
                                        If oValidations.ValidateJobNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobUDF.Append("UPDATE JOB_LOG_UDV5 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "'")
                                        Else
                                            sbJobUDF.Append("INSERT INTO JOB_LOG_UDV5 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.SC_CODE" Then
                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        Dim dr As SqlDataReader = est.GetEstimateNumJob(Me.JobNumber.ToString())
                                        If dr.HasRows = True Then
                                            dr.Read()
                                            If dr("ESTIMATE_NUMBER") <> 0 Then
                                                sbJobEstSC.Append("UPDATE ESTIMATE_LOG SET SC_CODE = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE ESTIMATE_NUMBER = '" & dr("ESTIMATE_NUMBER") & "'")
                                            End If
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.CMP_CODE" Then

                                        CampaignCode = ""
                                        CampaignID = 0

                                        Try

                                            CampaignCode = dtChanges.Rows(i)("FormValue")

                                        Catch ex As Exception
                                            CampaignCode = ""
                                        End Try

                                        Try

                                            CampaignID = ocJobs.GetCampaignIdentifier(MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")), oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)

                                        Catch ex As Exception
                                            CampaignID = 0
                                        End Try

                                        If String.IsNullOrWhiteSpace(CampaignCode) = False AndAlso CampaignID > 0 Then

                                            sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                            sbJobUpdate.Append("CMP_IDENTIFIER = '" & CampaignID & "', ")

                                        Else

                                            sbJobUpdate.Append("JOB_LOG.CMP_IDENTIFIER = NULL, ")
                                            sbJobUpdate.Append("JOB_LOG.CMP_CODE = NULL, ")

                                        End If

                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_LOG.JOB_COMMENTS" Then

                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        'sbJobUpdate.Append("JOB_LOG.JOB_COMMENTS_HTML = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")

                                    Else

                                        sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")

                                    End If
                                End If
                                JobHasChange = True
                                If InStr(dtChanges.Rows(i)("ItemCode"), "_LOG.CL_CODE") > 0 Then
                                    If ClientChange <> "" And ClientChange.Trim <> JobCheck.ClientCode Then
                                        JobChangeCount = JobChangeCount + 1
                                    End If
                                ElseIf InStr(dtChanges.Rows(i)("ItemCode"), "_LOG.DIV_CODE") > 0 Then
                                    If DivisionChange <> "" And DivisionChange.Trim <> JobCheck.DivisionCode Then
                                        JobChangeCount = JobChangeCount + 1
                                    End If
                                ElseIf InStr(dtChanges.Rows(i)("ItemCode"), "_LOG.PRD_CODE") > 0 Then
                                    If ProductChange <> "" And ProductChange.Trim <> JobCheck.ProductCode Then
                                        JobChangeCount = JobChangeCount + 1
                                    End If
                                ElseIf InStr(dtChanges.Rows(i)("ItemCode"), "_LOG") > 0 Then
                                    JobChangeCount = JobChangeCount + 1
                                End If
                            ElseIf InStr(dtChanges.Rows(i)("ItemCode"), "_COMPONENT") > 0 Or dtChanges.Rows(i)("ItemCode").ToString() = "SERVICE_FEE_TYPE_ID" Then
                                Dim s1 As String = dtChanges.Rows(i)("ControlID").ToString
                                Dim s2 As String = dtChanges.Rows(i)("ItemCode").ToString
                                Dim s3 As String = dtChanges.Rows(i)("FormValue").ToString
                                If dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.PRD_CONT_CODE" Then
                                    'Ignore 
                                Else
                                    'need to process all 4 blackplate fields; don't add them until the end
                                    If dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.BLACKPLT_VER_DESC" Then
                                        If dtChanges.Rows(i)("ControlID").ToString().Contains("TxtValue") = True Then
                                            HasBlackplate1 = True
                                            Blackplate1_Code = dtChanges.Rows(i)("FormValue").ToString()
                                        End If
                                        If dtChanges.Rows(i)("ControlID").ToString().Contains("TxtDescript") = True Then
                                            HasBlackplate1 = True
                                            Blackplate1_Description = dtChanges.Rows(i)("FormValue").ToString()
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.BLACKPLT_VER2_DESC" Then
                                        If dtChanges.Rows(i)("ControlID").ToString().Contains("TxtValue") = True Then
                                            HasBlackplate2 = True
                                            Blackplate2_Code = dtChanges.Rows(i)("FormValue").ToString()
                                        End If
                                        If dtChanges.Rows(i)("ControlID").ToString().Contains("TxtDescript") = True And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                            HasBlackplate2 = True
                                            Blackplate2_Description = dtChanges.Rows(i)("FormValue").ToString()
                                        End If

                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.TAX_FLAG" And dtChanges.Rows(i)("FormValue").ToString() = "" Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = NULL, ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.TAX_CODE" And taxflag = True And dtChanges.Rows(i)("FormValue").ToString() = "" Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & DefaultTaxCode & "', ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.TAX_CODE" And taxflag = False And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = NULL, ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.JOB_MARKUP_PCT" And dtChanges.Rows(i)("FormValue").ToString() = "" Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = NULL, ")
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.UDV1_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_CMP_UDV1") = True Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', ")
                                        If oValidations.ValidateJobCompNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobCompUDF.Append("UPDATE JOB_CMP_UDV1 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "'")
                                        Else
                                            sbJobCompUDF.Append("INSERT INTO JOB_CMP_UDV1 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.UDV2_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_CMP_UDV2") = True Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', ")
                                        If oValidations.ValidateJobCompNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobCompUDF.Append("UPDATE JOB_CMP_UDV2 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "'")
                                        Else
                                            sbJobCompUDF.Append("INSERT INTO JOB_CMP_UDV2 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.UDV3_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_CMP_UDV3") = True Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', ")
                                        If oValidations.ValidateJobCompNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobCompUDF.Append("UPDATE JOB_CMP_UDV3 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "'")
                                        Else
                                            sbJobCompUDF.Append("INSERT INTO JOB_CMP_UDV3 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.UDV4_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_CMP_UDV4") = True Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', ")
                                        If oValidations.ValidateJobCompNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobCompUDF.Append("UPDATE JOB_CMP_UDV4 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "'")
                                        Else
                                            sbJobCompUDF.Append("INSERT INTO JOB_CMP_UDV4 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                    ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.UDV5_CODE" And MyJobTemplate.UserDefinedFieldAllowsUserEntry("JOB_CMP_UDV5") = True Then
                                        sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', ")
                                        If oValidations.ValidateJobCompNumberUserDefined(Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0"), dtChanges.Rows(i)("ItemCode").ToString()) = True Then
                                            sbJobCompUDF.Append("UPDATE JOB_CMP_UDV5 SET UDV_DESC = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "' WHERE UDV_CODE = '" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "'")
                                        Else
                                            sbJobCompUDF.Append("INSERT INTO JOB_CMP_UDV5 VALUES ('" & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString().PadLeft(2, "0") & "', '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "',NULL);")
                                        End If
                                        'ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.JOB_COMP_DATE" And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                        '    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = CAST(@jcdate AS VARCHAR), ")
                                        '    parametertJobCompDate.Value = MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        '    arParams(0) = parametertJobCompDate
                                        'ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.JOB_FIRST_USE_DATE" And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                        '    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = CAST(@jfuddate AS VARCHAR), ")
                                        '    parametertJobFirstUseDate.Value = MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        '    arParams(1) = parametertJobFirstUseDate
                                        'ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.START_DATE" And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                        '    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = CAST(@sdate AS VARCHAR), ")
                                        '    parametertStartDate.Value = MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        '    arParams(2) = parametertStartDate
                                        'ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.JOB_COMP_BUDGET_AM" And dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                        '    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = @budget, ")
                                        '    parametertbudget.Value = MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        '    arParams(3) = parametertbudget
                                    Else
                                        If dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.JOB_MARKUP_PCT" Then
                                            sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue").ToString.Replace("%", "")) & "', ")
                                        ElseIf dtChanges.Rows(i)("ItemCode").ToString() = "JOB_COMPONENT.TAX_CODE" Then
                                            If ClientChange <> "" And ClientChange.Trim <> JobCheck.ClientCode And DivisionChange <> "" And DivisionChange.Trim <> JobCheck.DivisionCode And ProductChange <> "" And ProductChange.Trim <> JobCheck.ProductCode Then
                                                If taxflag = True Then
                                                    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & DefaultTaxCode & "', ")
                                                End If
                                                If taxflag = False Then
                                                    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = NULL, ")
                                                End If
                                            Else
                                                sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                            End If
                                        Else

                                            Dim ChangeValue As String = dtChanges.Rows(i)("FormValue")

                                            Select Case dtChanges.Rows(i)("ItemCode").ToString()
                                                Case "JOB_COMPONENT.MEDIA_BILL_DATE"

                                                    If String.IsNullOrWhiteSpace(ChangeValue) = True Then

                                                        JobComponent.MediaBillDate = Nothing

                                                    Else

                                                        JobComponent.MediaBillDate = CDate(ChangeValue)

                                                    End If

                                                    HasComponentChange = True

                                                Case "JOB_COMPONENT.JOB_COMP_DATE"

                                                    If String.IsNullOrWhiteSpace(ChangeValue) = True Then

                                                        JobComponent.CreatedDate = Nothing

                                                    Else

                                                        JobComponent.CreatedDate = CDate(ChangeValue)

                                                    End If
                                                    HasComponentChange = True

                                                Case "JOB_COMPONENT.JOB_FIRST_USE_DATE"

                                                    If String.IsNullOrWhiteSpace(ChangeValue) = True Then

                                                        JobComponent.DueDate = Nothing

                                                    Else

                                                        JobComponent.DueDate = CDate(ChangeValue)

                                                    End If
                                                    HasComponentChange = True

                                                Case "JOB_COMPONENT.START_DATE"

                                                    If String.IsNullOrWhiteSpace(ChangeValue) = True Then

                                                        JobComponent.StartDate = Nothing

                                                    Else

                                                        JobComponent.StartDate = CDate(ChangeValue)

                                                    End If
                                                    HasComponentChange = True

                                                Case "JOB_COMPONENT.JOB_COMP_BUDGET_AM"

                                                    If String.IsNullOrWhiteSpace(ChangeValue) = True Then

                                                        JobComponent.BudgetAmount = Nothing

                                                    Else

                                                        JobComponent.BudgetAmount = CType(ChangeValue, Decimal)

                                                    End If
                                                    HasComponentChange = True

                                                Case Else

                                                    sbJobCompUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(ChangeValue) & "', ")
                                                    CompHasChange = True

                                            End Select

                                        End If
                                    End If
                                    CompHasChange = True
                                End If

                            ElseIf InStr(dtChanges.Rows(i)("ItemCode"), "_CLIENT_REF") > 0 Then
                                'TODO:  check client ref unique:
                                If oReqCheck.RequiredUniqueClientRef() = True Then
                                    If dtChanges.Rows(i)("FormValue") = "" Then
                                        ErrorMessage = "Please enter a value for Client Reference"
                                        Return False
                                    End If
                                    If dtChanges.Rows(i)("FormValue") <> "" Then
                                        If oReqCheck.IsUniqueClient(dtChanges.Rows(i)("FormValue"), JobNumber) = False Then
                                            ErrorMessage = "Please enter a unique value for Client Reference"
                                            Return False
                                        End If
                                    End If
                                End If
                                sbJobCliRef.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobTemplate.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                JobCliRefHasChange = True
                                JobHasChange = True
                                JobChangeCount = JobChangeCount + 1
                            End If
                        Next

                        'process blackplate
                        If HasBlackplate1 = True Then
                            If Blackplate1_Code = "" And Blackplate1_Description = "" Then 'path to clear value
                                If oReqCheck.RequiredBlackplate(oJob.CL_CODE, TemplateCode, "JOB_COMPONENT.BLACKPLT_VER_DESC", 1) = False Then
                                    ErrorMessage = "BlackPlate 1 is required"
                                    Return False
                                End If
                                sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER_DESC = NULL,")
                            ElseIf Blackplate1_Code = "" And Blackplate1_Description <> "" Then 'path if user entered custom desc
                                sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate1_Description) & "',")
                            ElseIf Blackplate1_Code <> "" And Blackplate1_Description = "" Then 'path if user entered a code
                                If oValidations.ValidateBlackplate(Blackplate1_Code) = False Then
                                    ErrorMessage = "BlackPlate 1 invalid"
                                    Return False
                                End If
                                Blackplate1_Description = MyJobTemplate.GetBlackPltDesc(Blackplate1_Code)
                                If Blackplate1_Description = "" Then 'description is required but not found
                                    'something went wrong? leave it alone
                                Else
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER_CODE = '" & Blackplate1_Code & "', JOB_COMPONENT.BLACKPLT_VER_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate1_Description) & "',")
                                End If
                            ElseIf Blackplate1_Code <> "" And Blackplate1_Description <> "" Then
                                Dim DbBlackplate1_Description As String = ""
                                DbBlackplate1_Description = MyJobTemplate.GetBlackPltDesc(Blackplate1_Code)
                                If Blackplate1_Description = DbBlackplate1_Description Then
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER_CODE = '" & Blackplate1_Code & "', JOB_COMPONENT.BLACKPLT_VER_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate1_Description) & "',")
                                Else
                                    'user either typed in the code and tried to type in the desc
                                    'user used the lookup to grab the code and the desc and modified the desc = custome desc (?)
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate1_Description) & "',")
                                End If
                            End If
                        End If
                        If HasBlackplate2 = True Then
                            If Blackplate2_Code = "" And Blackplate2_Description = "" Then 'path to clear value
                                If oReqCheck.RequiredBlackplate(oJob.CL_CODE, TemplateCode, "JOB_COMPONENT.BLACKPLT_VER2_DESC", 1) = False Then
                                    ErrorMessage = "BlackPlate 2 is required"
                                    Return False
                                End If
                                sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER2_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER2_DESC = NULL,")
                            ElseIf Blackplate2_Code = "" And Blackplate2_Description <> "" Then 'path if user entered custom desc
                                sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER2_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER2_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate2_Description) & "',")
                            ElseIf Blackplate2_Code <> "" And Blackplate2_Description = "" Then 'path if user entered a code
                                If oValidations.ValidateBlackplate(Blackplate2_Code) = False Then
                                    ErrorMessage = "BlackPlate 2 invalid"
                                    Return False
                                End If
                                Blackplate2_Description = MyJobTemplate.GetBlackPltDesc(Blackplate2_Code)
                                If Blackplate2_Description = "" Then 'description is required but not found
                                    'something went wrong? leave it alone
                                Else
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER2_CODE = '" & Blackplate2_Code & "', JOB_COMPONENT.BLACKPLT_VER2_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate2_Description) & "',")
                                End If
                            ElseIf Blackplate2_Code <> "" And Blackplate2_Description <> "" Then
                                Dim DbBlackplate2_Description As String = ""
                                DbBlackplate2_Description = MyJobTemplate.GetBlackPltDesc(Blackplate2_Code)
                                If Blackplate2_Description = DbBlackplate2_Description Then
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER2_CODE = '" & Blackplate2_Code & "', JOB_COMPONENT.BLACKPLT_VER2_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate2_Description) & "',")
                                Else
                                    'user either typed in the code and tried to type in the desc
                                    'user used the lookup to grab the code and the desc and modified the desc = custome desc (?)
                                    sbJobCompUpdate.Append("JOB_COMPONENT.BLACKPLT_VER2_CODE = NULL, JOB_COMPONENT.BLACKPLT_VER2_DESC = '" & MyJobTemplate.EncodeSQL(Blackplate2_Description) & "',")
                                End If
                            End If
                        End If

                        If ClientChange <> "" And DivisionChange <> "" And ProductChange <> "" Then
                            Dim prod As AdvantageFramework.Database.Entities.Product = Nothing
                            Dim AccExe As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
                            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
                            'Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                            Try
                                prod = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientChange, DivisionChange, ProductChange)
                                AccExe = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, ClientChange, DivisionChange, ProductChange).Where(Function(Acc) Acc.IsInactive Is Nothing OrElse Acc.IsInactive = 0).First
                                'Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                                If Job IsNot Nothing Then
                                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Job.CampaignID)
                                End If
                            Catch ex As Exception
                            End Try
                            Dim ae As String = MyJobTemplate.GetDefaultAE(ClientChange, DivisionChange, ProductChange)
                            If ae = "" And AccExe IsNot Nothing Then
                                ae = AccExe.EmployeeCode
                            End If
                            If prod IsNot Nothing Then
                                If Job.ClientCode <> ClientChange.Trim Or Job.DivisionCode <> DivisionChange.Trim Or Job.ProductCode <> ProductChange.Trim Then
                                    If sbJobUpdate.ToString.Contains("OFFICE_CODE") = False Then
                                        sbJobUpdate.Append("JOB_LOG.OFFICE_CODE = '" & prod.OfficeCode & "', ")
                                    End If
                                End If
                                If Campaign IsNot Nothing Then
                                    If Campaign.ClientCode IsNot Nothing And Campaign.DivisionCode Is Nothing And Campaign.ProductCode Is Nothing Then
                                        If Campaign.ClientCode <> ClientChange.Trim Then
                                            sbJobUpdate.Append("JOB_LOG.CMP_IDENTIFIER = NULL, ")
                                            sbJobUpdate.Append("JOB_LOG.CMP_CODE = NULL, ")
                                        End If
                                    ElseIf Campaign.ClientCode IsNot Nothing And Campaign.DivisionCode IsNot Nothing And Campaign.ProductCode Is Nothing Then
                                        If Campaign.ClientCode <> ClientChange.Trim Or Campaign.DivisionCode <> DivisionChange.Trim Then
                                            sbJobUpdate.Append("JOB_LOG.CMP_IDENTIFIER = NULL, ")
                                            sbJobUpdate.Append("JOB_LOG.CMP_CODE = NULL, ")
                                        End If
                                    ElseIf Campaign.ClientCode IsNot Nothing And Campaign.DivisionCode IsNot Nothing And Campaign.ProductCode IsNot Nothing Then
                                        If Campaign.ClientCode <> ClientChange.Trim Or Campaign.DivisionCode <> DivisionChange.Trim Or Campaign.ProductCode <> ProductChange.Trim Then
                                            sbJobUpdate.Append("JOB_LOG.CMP_IDENTIFIER = NULL, ")
                                            sbJobUpdate.Append("JOB_LOG.CMP_CODE = NULL, ")
                                        End If
                                    End If
                                End If
                                If Job.ClientCode <> ClientChange.Trim Or Job.DivisionCode <> DivisionChange.Trim Or Job.ProductCode <> ProductChange.Trim Then
                                    If sbJobUpdate.ToString.Contains("JOB_ESTIMATE_REQ") = False Then
                                        If prod.ProductionApprovedEstimatedRequired Is Nothing Then
                                            sbJobUpdate.Append("JOB_LOG.JOB_ESTIMATE_REQ = 0, ")
                                        Else
                                            sbJobUpdate.Append("JOB_LOG.JOB_ESTIMATE_REQ = " & prod.ProductionApprovedEstimatedRequired & ", ")
                                        End If
                                    End If
                                    If sbJobCompUpdate.ToString.Contains("JOB_MARKUP_PCT") = False Then
                                        sbJobCompUpdate.Append("JOB_COMPONENT.JOB_MARKUP_PCT = '" & prod.ProductionMarkup & "', ")
                                        CompHasChange = True
                                    End If
                                    If sbJobCompUpdate.ToString.Contains("EMP_CODE") = False Then
                                        sbJobCompUpdate.Append("JOB_COMPONENT.EMP_CODE = '" & ae & "', ")
                                        CompHasChange = True
                                    End If
                                    sbJobCompUpdate.Append("JOB_COMPONENT.CDP_CONTACT_ID = NULL, ")
                                    If sbJobCompUpdate.ToString.Contains("EMAIL_GR_CODE") = False Then
                                        sbJobCompUpdate.Append("JOB_COMPONENT.EMAIL_GR_CODE = '" & prod.ProductionAlertGroup & "', ")
                                        CompHasChange = True
                                    End If
                                End If
                            End If

                            Dim dr As SqlDataReader = est.GetEstimateNumJob(Me.JobNumber.ToString())
                            Do While dr.Read()
                                If dr.HasRows = True Then
                                    If dr("ESTIMATE_NUMBER") <> 0 Then
                                        SbEstimate.Append("UPDATE ESTIMATE_LOG SET CL_CODE = '" & ClientChange & "', DIV_CODE = '" & DivisionChange & "', PRD_CODE = '" & ProductChange & "' WHERE ESTIMATE_NUMBER = '" & dr("ESTIMATE_NUMBER") & "'")
                                        Exit Do
                                    End If
                                End If
                            Loop
                        End If

                        If JobHasChange = True Then
                            'sbJobUpdate.Append(" JOB_LOG.MODIFY_DATE = '" & CType(Date.Now.ToString, Date).ToString & "', ")
                            'sbJobUpdate.Append(" JOB_LOG.MODIFIED_BY = '" & Session("UserCode") & "', ")

                            If JobChangeCount > 0 Then

                                Job.ModifiedDate = Date.Now
                                Job.ModifiedBy = Session("UserCode")

                                HasComponentChange = True

                            End If

                        End If
                        If CompHasChange = True Or HasComponentChange = True Then
                            'sbJobCompUpdate.Append(" JOB_COMPONENT.MODIFY_DATE = '" & CType(Date.Now.ToString, Date).ToString & "', ")
                            'sbJobCompUpdate.Append(" JOB_COMPONENT.MODIFIED_BY = '" & Session("UserCode") & "', ")

                            HasComponentChange = True
                            CompHasChange = True

                            JobComponent.ModifiedDate = Date.Now
                            JobComponent.ModifiedBy = Session("UserCode")

                        End If

                        sbJobUpdate.Append(" WHERE JOB_NUMBER = " & JobNumber)
                        sbJobCompUpdate.Append(" WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr)
                        sbJobCliRef.Append(" WHERE JOB_NUMBER = " & JobNumber)

                        Dim sbMainSQL As StringBuilder = New StringBuilder
                        With sbMainSQL
                            If JobHasChange = True Then
                                .Append(sbJobUDF.ToString())
                                .Append(sbJobEstSC.ToString())
                                .Append(sbJobUpdate.ToString() & ";")
                                .Append(SbEstimate.ToString() & ";")
                            End If
                            If CompHasChange = True Then
                                .Append(sbJobCompUDF.ToString())
                                .Append(sbJobCompUpdate.ToString() & ";")
                            End If
                            If JobCliRefHasChange = True Then
                                .Append(sbJobCliRef.ToString() & ";")
                            End If
                        End With

                        ''Just a test string
                        If Trace.IsEnabled = True Then
                            ErrorMessage = "<hr/><Strong>SQL:</Strong><BR/>" & sbMainSQL.ToString().Replace(",  WHERE", " WHERE") & "<BR/><BR/><hr/>"
                        End If

                        'do more req checks on string here?
                        'like tax field and tax flag?

                        ''run actual update
                        'If Trace.IsEnabled = False Then
                        Try

                            If HasComponentChange = True Then

                                If AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent) = True Then

                                    'SaveSuccessful = True
                                    SaveTemplate = True

                                End If

                            End If

                            If JobHasChange = True Then

                                If JobChangeCount > 0 Then

                                    JobComponents = Job.JobComponents.Where(Function(Entity) Entity.Number <> JobComponentNbr AndAlso
                                                    Entity.JobProcessNumber <> 6 AndAlso Entity.JobProcessNumber <> 12).ToList

                                    If JobComponents.Count > 0 Then
                                        'update other components here
                                        Dim JobComponentRow As Integer = 0
                                        While JobComponentRow < JobComponents.Count
                                            JobComponents(JobComponentRow).ModifiedDate = Date.Now
                                            JobComponents(JobComponentRow).ModifiedBy = Session("UserCode")

                                            JobComponentSave = JobComponents(JobComponentRow)

                                            AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponentSave)

                                            JobComponentRow = JobComponentRow + 1

                                        End While

                                    End If

                                End If

                            End If

                            If JobHasChange = True OrElse HasComponentChange = True Then

                                If AdvantageFramework.Database.Procedures.Job.Update(DbContext, Job) = True Then

                                    'SaveSuccessful = True
                                    SaveTemplate = True

                                End If

                            End If

                            Dim str As String = sbMainSQL.ToString().Replace(",  WHERE", " WHERE")

                            str = str.Replace(", WHERE", " WHERE")
                            str = str.Replace("= ''", "= NULL ")
                            str = str.Replace(String.Format("UPDATE JOB_COMPONENT SET  WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", JobNumber, JobComponentNbr), "")

                            If str <> "" Then 'And (JobHasChange = True Or CompHasChange = True Or JobCliRefHasChange = True) Then
                                str = str & AppendCommentFix(JobNumber, JobComponentNbr)
                                'save
                                SaveMessageReturn = MyJobTemplate.UpdateJob(str, arParams, SaveSuccessful).ToString()
                                If SaveMessageReturn <> "" Then
                                    ErrorMessage = SaveMessageReturn
                                    Return False
                                Else
                                    Try
                                        Dim SessionKeyJobNumber As String = "GetJobInfo" & JobNumber.ToString().PadLeft(6, "0")
                                        Dim SessionKeyJobComponentNbr As String = "GetJobComponentInfo" & JobNumber.ToString().PadLeft(6, "0") & JobComponentNbr.ToString.PadLeft(3, "0")
                                        HttpContext.Current.Session(SessionKeyJobNumber) = Nothing
                                        HttpContext.Current.Session(SessionKeyJobComponentNbr) = Nothing
                                    Catch ex As Exception
                                    End Try
                                End If
                            ElseIf GetOneChangeValue(dvChanges, "JOB_COMPONENTPRD_CONT_CODE") <> "" Or GetOneChangeValue(dvChanges, "JOB_COMPONENTPRD_CONT_CODE") = "" Then
                                'ErrorMessage = ""
                            Else
                                'ErrorMessage = "No changes detected"
                            End If


                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                        Dim ChangedContactCode As String = GetOneChangeValue(dvChanges, "JOB_COMPONENTPRD_CONT_CODE")
                        Dim SaveSuccessfulContact As Boolean
                        If ChangedContactCode <> "-1" Then
                            Dim s As String = ""
                            If Me.SaveCDPContact(JobNumber, JobComponentNbr, ChangedContactCode, s) = False Then
                                ErrorMessage = s
                                Return False
                            End If
                        End If

                        'Pop the Job Jacket alert window:
                        'Get the requirements:
                        Dim dtAlertReqs As New DataTable("AlertReqs")
                        dtAlertReqs = MyJobTemplate.GetAlertRequirements(JobNumber, JobComponentNbr, oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
                        Dim strReqDescript As String = String.Empty
                        For j As Integer = 0 To dtAlertReqs.Rows.Count - 1
                            strReqDescript = dtAlertReqs.Rows(j)("ReqDescript")
                            Select Case strReqDescript
                                Case "AgencyRequiredEmail"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAgencyRequiredEmail = True
                                    End If
                                Case "AutoEmailPromptOnNew"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAutoEmailPromptOnNew = True
                                    End If
                                Case "AutoEmailPromptOnUpdate"
                                    Dim req As String = dtAlertReqs.Rows(j)("IsRequired").ToString
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAutoEmailPromptOnUpdate = True
                                    End If
                                Case "ClientGetsEmailOnNew"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsClientGetsEmailOnNew = True
                                    End If
                                Case "ClientGetsEmailOnUpdate"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsClientGetsEmailOnUpdate = True
                                    End If
                            End Select
                        Next

                        If SaveSuccessful = True OrElse SaveSuccessfulContact = True Then
                            Dim strAlertPopUp_title As String
                            Dim strAlertPopUp_body As String
                            Dim strAlertBody As String
                            Dim boolIsNew As Boolean
                            Dim oJob2 As Job = New Job(Session("ConnString"))
                            oJob2.GetJob(JobNumber, JobComponentNbr)
                            Dim sendalert As Boolean = Me.CheckChanges(oJob2, strAlertBody, Me.dtEdits)
                            Dim strJS_RedirectToReadOnly As String = Server.UrlDecode("location.href=""JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0" & """")
                            Try
                                If Request.QueryString("NewJob") = "1" Then   'this is a new job
                                    strAlertPopUp_title = "New Job/Comp - " & JobNumber.ToString().PadLeft(6, "0") & "/01 - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                    boolIsNew = True
                                ElseIf Request.QueryString("NewComp") = "new" Then 'this is a new component
                                    strAlertPopUp_title = "New Job/Comp - " & JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNbr.ToString().PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                    boolIsNew = True
                                ElseIf IsNumeric(JobNumber) And IsNumeric(JobComponentNbr) Then 'this is an edit
                                    strAlertPopUp_title = "Existing Job/Comp - " & JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNbr.ToString().PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " modified by " & Session("EmployeeName")
                                    boolIsNew = False
                                End If
                                strAlertPopUp_body = strAlertBody.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                            Catch ex As Exception
                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                Return False
                            End Try

                            Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
                            Dim od As cAlerts = New cAlerts(CStr(Session("ConnString")))
                            Dim Employee As New cEmployee(CStr(Session("ConnString")))
                            Dim strCurrEmailGroup As String
                            strCurrEmailGroup = od.GetDefaultGroup(Me.Client, Me.Division, Me.Product, Me.JobNumber, Me.JobComponentNbr)
                            Try
                                With sbQSVars
                                    .Append("?")
                                    .Append("EmailGroup=" & strCurrEmailGroup.Replace("/", "-").Replace("&", "and").Replace("'", "").Replace(",", ""))
                                    .Append("&DivCode=" & Me.Division)
                                    .Append("&JobCompNo=" & JobComponentNbr)
                                    .Append("&JobNo=" & JobNumber)
                                    .Append("&ProdCode=" & Me.Product)
                                    .Append("&Recipients=" & "")
                                    .Append("&ClientCode=" & Me.Client)
                                    If boolIsNew = True Then
                                        .Append("&New=1")
                                    Else
                                        .Append("&New=0")
                                    End If
                                    .Append("&f=")
                                    .Append(MiscFN.SourceApp_ToInt(Source_App.JobJacket))
                                End With
                            Catch ex As Exception
                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                Return False
                            End Try

                            Try
                                'st:   test using session instead of qs to pass what could potentially be too much data for a qs
                                Session("AlertPopUp_Title") = strAlertPopUp_title
                                Session("AlertPopUp_Body") = strAlertPopUp_body
                            Catch ex As Exception
                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                Return False
                            End Try

                            Try
                                If IsAgencyRequiredEmail = True Then
                                    Try
                                        If IsClientGetsEmailOnUpdate = True And IsNewJob = False And IsNewJobComponent = False Then
                                            If IsAutoEmailPromptOnUpdate = True Then   'do prompt check here   , if prompt is true
                                                Me.OpenWindow("Email Alert", "popup_email_alert.aspx" & sbQSVars.ToString(), 500, 750, , True)
                                            Else 'prompt is false , Send silent
                                                Me.SendSilentEmail(strCurrEmailGroup, 2, 4, strAlertPopUp_title, strAlertPopUp_body, strJS_RedirectToReadOnly)
                                            End If
                                        ElseIf IsClientGetsEmailOnNew = True And (IsNewJob = True Or IsNewJobComponent = True) Then
                                            Try
                                                If IsAutoEmailPromptOnNew = True And (IsNewJob = True Or IsNewJobComponent = True) Then
                                                    Me.OpenWindow("Email Alert", "popup_email_alert.aspx" & sbQSVars.ToString(), 500, 750,  , True)
                                                Else
                                                    Me.SendSilentEmail(strCurrEmailGroup, 2, 3, strAlertPopUp_title, strAlertPopUp_body, strJS_RedirectToReadOnly)
                                                End If
                                            Catch ex As Exception
                                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                                Return False
                                            End Try
                                        Else
                                            Try
                                                Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                                                PageLoadJS(strJS_RedirectToReadOnly)
                                            Catch ex As Exception
                                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                                Return False
                                            End Try
                                        End If
                                    Catch ex As Exception
                                        ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                        Return False
                                    End Try
                                Else
                                    PageLoadJS(strJS_RedirectToReadOnly)
                                End If
                                Return True
                            Catch ex As Exception
                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                Return False
                            Finally
                            End Try
                        End If
                    ElseIf SaveSuccessful = False And SaveTemplate = True Then
                        MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0")
                        Return True
                    Else
                        Dim dtAlertReqs As New DataTable("AlertReqs")
                        dtAlertReqs = MyJobTemplate.GetAlertRequirements(JobNumber, JobComponentNbr, oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
                        Dim strReqDescript As String = String.Empty
                        For j As Integer = 0 To dtAlertReqs.Rows.Count - 1
                            strReqDescript = dtAlertReqs.Rows(j)("ReqDescript")
                            Select Case strReqDescript
                                Case "AgencyRequiredEmail"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAgencyRequiredEmail = True
                                    End If
                                Case "AutoEmailPromptOnNew"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAutoEmailPromptOnNew = True
                                    End If
                                Case "AutoEmailPromptOnUpdate"
                                    Dim req As String = dtAlertReqs.Rows(j)("IsRequired").ToString
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsAutoEmailPromptOnUpdate = True
                                    End If
                                Case "ClientGetsEmailOnNew"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsClientGetsEmailOnNew = True
                                    End If
                                Case "ClientGetsEmailOnUpdate"
                                    If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                        IsClientGetsEmailOnUpdate = True
                                    End If
                            End Select
                        Next

                        Dim strAlertPopUp_title As String
                        Dim strAlertPopUp_body As String
                        Dim strAlertBody As String
                        Dim boolIsNew As Boolean
                        Dim oJob2 As Job = New Job(Session("ConnString"))
                        oJob2.GetJob(JobNumber, JobComponentNbr)
                        Dim sendalert As Boolean = Me.GetJobDateForAlert(oJob2, strAlertBody)
                        Dim strJS_RedirectToReadOnly As String = Server.UrlDecode("location.href=""JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0" & """")
                        Try
                            If Request.QueryString("NewJob") = "1" Then   'this is a new job
                                strAlertPopUp_title = "New Job/Comp - " & JobNumber.ToString().PadLeft(6, "0") & "/01 - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                boolIsNew = True
                            ElseIf Request.QueryString("NewComp") = "new" Then 'this is a new component
                                strAlertPopUp_title = "New Job/Comp - " & JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNbr.ToString().PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                boolIsNew = True
                            ElseIf IsNumeric(JobNumber) And IsNumeric(JobComponentNbr) Then 'this is an edit
                                strAlertPopUp_title = "Job/Comp  - " & JobNumber.ToString().PadLeft(6, "0") & "-" & JobComponentNbr.ToString().PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " by " & Session("EmployeeName")
                                boolIsNew = False
                            End If
                            strAlertPopUp_body = strAlertBody.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                        'Set querystring vars:
                        Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
                        Dim od As cAlerts = New cAlerts(CStr(Session("ConnString")))
                        Dim Employee As New cEmployee(CStr(Session("ConnString")))
                        Dim strCurrEmailGroup As String
                        strCurrEmailGroup = od.GetDefaultGroup(Me.Client, Me.Division, Me.Product, Me.JobNumber, Me.JobComponentNbr)
                        Try
                            With sbQSVars
                                .Append("?")
                                .Append("EmailGroup=" & strCurrEmailGroup.Replace("/", "-").Replace("&", "and").Replace("'", "").Replace(",", ""))
                                .Append("&DivCode=" & Me.Division)
                                .Append("&JobCompNo=" & JobComponentNbr)
                                .Append("&JobNo=" & JobNumber)
                                .Append("&ProdCode=" & Me.Product)
                                .Append("&Recipients=" & "")
                                .Append("&ClientCode=" & Me.Client)
                                If boolIsNew = True Then
                                    .Append("&New=1")
                                Else
                                    .Append("&New=0")
                                End If
                            End With
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                        Try
                            Session("AlertPopUp_Title") = strAlertPopUp_title
                            Session("AlertPopUp_Body") = strAlertPopUp_body
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                        Try
                            If IsAgencyRequiredEmail = True Then
                                Try
                                    If IsClientGetsEmailOnUpdate = True And IsNewJob = False And IsNewJobComponent = False Then
                                        If IsAutoEmailPromptOnUpdate = True Then   'do prompt check here   , if prompt is true
                                            Me.OpenWindow("Email Alert", "popup_email_alert.aspx" & sbQSVars.ToString(), 500, 750,  , True)
                                        Else 'prompt is false , Send silent
                                            Me.SendSilentEmail(strCurrEmailGroup, 2, 4, strAlertPopUp_title, strAlertPopUp_body, strJS_RedirectToReadOnly)
                                        End If
                                    ElseIf IsClientGetsEmailOnNew = True And (IsNewJob = True Or IsNewJobComponent = True) Then
                                        Try
                                            If IsAutoEmailPromptOnNew = True And (IsNewJob = True Or IsNewJobComponent = True) Then
                                                Me.OpenWindow("Email Alert", "popup_email_alert.aspx" & sbQSVars.ToString(), 500, 750,  , True)
                                            Else
                                                Me.SendSilentEmail(strCurrEmailGroup, 2, 3, strAlertPopUp_title, strAlertPopUp_body, strJS_RedirectToReadOnly)
                                            End If
                                        Catch ex As Exception
                                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                            Return False
                                        End Try
                                    Else
                                        Try
                                            Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                                            Dim AlertID As Integer
                                            PageLoadJS(strJS_RedirectToReadOnly)
                                        Catch ex As Exception
                                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                            Return False
                                        End Try
                                    End If
                                Catch ex As Exception
                                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                Finally
                                End Try
                            Else
                                PageLoadJS(strJS_RedirectToReadOnly)
                            End If
                            Return True
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try
                    End If
                    Return True
                Catch ex As Exception
                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                    Return False
                End Try
                Try
                    If Not dvChanges Is Nothing Then
                        dvChanges.Dispose()
                        dvChanges = Nothing
                    End If
                    If Not dvChanges2 Is Nothing Then
                        dvChanges2.Dispose()
                        dvChanges2 = Nothing
                    End If
                    If Not dtChanges2 Is Nothing Then
                        dtChanges2.Dispose()
                        dtChanges2 = Nothing
                    End If
                    If Not dtChanges Is Nothing Then
                        dtChanges.Dispose()
                        dtChanges = Nothing
                    End If
                Catch ex As Exception
                End Try
                Return True
            Catch ex As Exception
                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try

        End Using

    End Function

    Private Sub AppendNewToAlertSB()
        '''Make it show all????
        'If Page.IsValid Then
        Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
        Dim dtAllData As DataTable
        With MyJobTemplate
            dtAllData = .CreateUserDataDataTable(Page) 'Get the form data
        End With
        Dim dvData As DataView = New DataView(dtAllData)
        dvData.RowFilter = " (NOT (FormValue IS NULL)) AND FormValue <> '' "
        '''With GridView1
        '''    .DataSource = dvData
        '''    .DataBind()
        '''End With
        'End If
    End Sub

    Private Sub NewCompClick()

        If JobNumber > 0 Then

            Using MyConn As New SqlConnection(Session("ConnString"))

                Dim i As Integer = 0
                MyConn.Open()

                Dim MyCmd As New SqlCommand("SELECT COUNT(1) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = " & JobNumber & ";", MyConn)
                Try

                    i = CType(MyCmd.ExecuteScalar, Integer)

                Catch ex As Exception

                    Me.lblMSG.Text = "<br />" & ex.Message.ToString() & "<br />"

                Finally

                    If MyConn.State = ConnectionState.Open Then MyConn.Close()

                End Try
                If i >= 999 Then

                    Me.lblMSG.Text = "<br />A job can have a maximum of 999 components<br />"
                    Exit Sub

                End If

            End Using
            'Me.OpenWindow("New Job", "jobtemplate_newcomponent.aspx")
            Dim qs As New AdvantageFramework.Web.QueryString()
            With qs

                .Page = "JobTemplate_NewComponent.aspx"
                .JobNumber = JobNumber
                .JobComponentNumber = JobComponentNbr
                .Add("tmplt", CurrTemplate)

            End With

            Me.OpenWindow(qs, "New Job Component", 840, 1100)

        End If
    End Sub

    Private Sub SetAddNewCompButtons(ByVal IsVisible As Boolean)
        Dim NotVisible As Boolean
        If IsVisible = True Then
            NotVisible = False
        Else
            NotVisible = True
        End If
    End Sub

    Private Sub AppendChangeToAlertSB(ByVal AlertSB As StringBuilder, ByVal ChangedEntity As String, ByVal OriginalData As String, ByVal NewData As String)
        With AlertSB
            .Append(ChangedEntity)
            .Append("<br />")
            .Append("New Value: ")
            .Append(NewData)
            .Append("<br />")
            .Append("Original Value: ")
            .Append(OriginalData)
            .Append("<br />")
            .Append("--------------------------------------")
            .Append("<br />")
        End With
    End Sub

#End Region

    Public Function PrintPage() As String
        Dim sb As StringBuilder = New StringBuilder
        Dim qs As String = ""
        Try
            'Dim fieldValue As String
            'For Each fieldName As String In HttpContext.Current.Request.Form
            '    If fieldName = "__VIEWSTATE" OrElse fieldName = "Submit" Then
            '    Else
            '        fieldValue = HttpContext.Current.Request.Form(fieldName)
            '        qs = qs + "&" + fieldName + "=" + fieldValue
            '        If fieldValue.Length > 100 Then
            '            sb.Append(fieldName + ": " + fieldValue.Substring(0, 50) + "" & "<br>")
            '            sb.Append(" " + fieldValue.Substring(50, 50) + "" & "<br>")
            '            sb.Append(" " + fieldValue.Substring(100, fieldValue.Length - 100) + "" & "<br>")
            '        Else
            '            If fieldValue.Length > 50 Then
            '                sb.Append(fieldName + ": " + fieldValue.Substring(0, 50) + "" & "<br>")
            '                sb.Append(" " + fieldValue.Substring(50, fieldValue.Length - 50) + "" & "<br>")
            '            Else
            '                sb.Append(fieldName + ": " + fieldValue + "" & "<br>")
            '            End If
            '        End If
            '    End If
            'Next
            Return sb.ToString

        Catch ex As Exception
            Return ex.Message.ToString
        Finally

        End Try

    End Function

    Private Sub PageLoadJS(ByVal strJS As String)
        Dim strTmpJS As String = String.Empty
        strTmpJS = "<script type=""text/javascript"">function init() { " & strJS & " } window.onload = init;</script>"
        If Not Page.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then
            Page.RegisterStartupScript("JSAlert", strTmpJS)
        End If
    End Sub

    Private Function GetEmailAddressFromGroup(ByVal strEmailGroup As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim dr As SqlDataReader
            If strEmailGroup <> "" Then
                Dim arParams(1) As SqlParameter
                Dim paramEmailGroup As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 50)
                paramEmailGroup.Value = strEmailGroup
                arParams(0) = paramEmailGroup
                'use mConnString if moving to class instead of session
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", arParams)
            End If
            Return dr
        Catch ex As Exception
        End Try
    End Function

    Private Function GetAEDescript(ByVal strEmpCode As String) As String
        Dim SessionKey As String = "GetAEDescript" & strEmpCode
        Dim ReturnString As String = ""

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                If strEmpCode <> "" Then
                    Dim oSQL As SqlHelper

                    Dim arParams(1) As SqlParameter

                    Dim paramEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                    paramEmpCode.Value = strEmpCode
                    arParams(0) = paramEmpCode

                    'use mConnString if moving to class instead of session
                    ReturnString = oSQL.ExecuteScalar(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetAEDescript", arParams)

                    If ReturnString <> "" And ReturnString.Length > 0 Then
                        ReturnString = ReturnString
                    Else
                        ReturnString = "-"
                    End If
                Else
                    ReturnString = "-"
                End If
            Catch ex As Exception
                ReturnString = "-"
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

    Private Function GetYesNo(ByVal ThisShort As Short) As String
        If ThisShort = 1 Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

    Dim oTF As String
    Dim pTF As String

    Private Function Spacer() As String
        Return "--------------------------------------------------" & "<br />"
        'Return "<hr style='border: 1px solid #cecece !important;' />"
    End Function
    Private Function CheckChanges(ByRef ojob As Job,
                                  ByRef strBody As String,
                                  ByRef dtchanges As DataTable) As Boolean

        Dim Changes As Boolean = False
        Dim BudgetAmt As Decimal = 0
        Dim HasCdpChange As Boolean = False
        Dim NewClientCode As String = String.Empty
        Dim NewDivisionCode As String = String.Empty
        Dim NewProductCode As String = String.Empty

        Try


            strBody &= "Client: " & ojob.CL_CODE & " - " & ojob.ClientDesc & "<br />"
            strBody &= "Division: " & ojob.DIV_CODE & " - " & ojob.DivisionDesc & "<br />"
            strBody &= "Product: " & ojob.PRD_CODE & " - " & ojob.ProductDesc & "<br />"

            If Request.QueryString("NewJob") = "1" Then
                strBody &= "NEW JOB CREATED!" & "<br />" & "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />"
            Else
                strBody &= "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />"
            End If
            If Request.QueryString("NewComp") = "new" Or (Request.QueryString("NewJob") = "1" And Request.QueryString("NewComp") = "0") Then
                strBody &= "<br />" & "NEW COMPONENT CREATED!" & "<br />" & "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            Else
                strBody &= "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            End If

            strBody &= "Acct Exec: " & GetAEDescript(ojob.JobComponent.EMP_CODE) & "<br />"
            strBody &= "Office: " & ojob.OFFICE_CODE & "<br />" & "<br />"

            If Request.QueryString("NewJob") = "1" Then

                strBody &= "NEW JOB DETAILS ARE AS FOLLOWS:"
                strBody &= "<hr />"
                strBody &= "Job Opened Date: " & ojob.CREATE_DATE.ToShortDateString & "<br />"
                strBody &= "Client Reference: " & IIf(ojob.JOB_CLI_REF.Trim().Length > 0, ojob.JOB_CLI_REF, "N/A") & "<br />"
                strBody &= "Sales Class: " & IIf(ojob.SalesClassDesc.Trim().Length > 0, ojob.SalesClassDesc, "N/A") & "<br />"
                Dim dblTotalBudget As Decimal = 0.0
                If Request.QueryString("jobcomponent") = "new" Or (Request.QueryString("NewJob") = "1" And Request.QueryString("NewComp") = "1") Then
                    BudgetAmt = CType(ojob.JobComponent.JOB_COMP_BUDGET_AM.ToString().Replace(",", ""), Decimal)
                    If IsNumeric(BudgetAmt) = True Then
                        dblTotalBudget = ojob.TotalBudget + BudgetAmt
                    Else
                        dblTotalBudget = ojob.TotalBudget
                    End If
                End If
                'If dblTotalBudget > 0 Then
                strBody &= "Total Budget: $" & dblTotalBudget.ToString() & "<br />"
                If ojob.CMP_CODE.Trim().Length > 0 Then strBody &= "Campaign code: " & ojob.CMP_CODE & "<br />"
                If ojob.BILL_COOP_CODE.Trim().Length > 0 Then strBody &= "COOP Billing code: " & ojob.BILL_COOP_CODE & "<br />"
                strBody &= "Rush Charges Approved: " & GetYesNo(ojob.JOB_RUSH_CHARGES) & "<br />"
                strBody &= "Approved Estimate Required: " & GetYesNo(ojob.JOB_ESTIMATE_REQ) & "<br />"
                If ojob.SalesClassFormatDesc.Trim().Length > 0 Then strBody &= "Sales Class Format code: " & ojob.SalesClassFormatDesc & "<br />"
                If ojob.ComplexityDesc.Trim().Length > 0 Then strBody &= "Complexity code: " & ojob.ComplexityDesc & "<br />"
                If ojob.PromotionDesc.Trim().Length > 0 Then strBody &= "Promotion code: " & ojob.PromotionDesc & "<br />"
                If ojob.JOB_COMMENTS_HTML.Trim().Length > 0 Then strBody &= "Job Comment: " & ojob.JOB_COMMENTS_HTML & "<br />" Else strBody &= "Job Comment: " & ojob.JOB_COMMENTS & "<br />"
                If ojob.JOB_BILL_COMMENT.Trim().Length > 0 Then strBody &= "Billing Comment: " & ojob.JOB_BILL_COMMENT & "<br />"
                'TODO: JOB UDF's
                If Not ojob.UDF1 Is Nothing Then
                    If Not ojob.UDF1.Code Is Nothing And ojob.UDF1.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= ojob.UDF1.Label & ": " & ojob.UDF1.Code & "<br />" Else If Not ojob.UDF1.Description Is Nothing Then strBody &= ojob.UDF1.Label & ": " & ojob.UDF1.Description & "<br />"
                End If
                If Not ojob.UDF2 Is Nothing Then
                    If Not ojob.UDF2.Code Is Nothing And ojob.UDF2.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= ojob.UDF2.Label & ": " & ojob.UDF2.Code & "<br />" Else If Not ojob.UDF2.Description Is Nothing Then strBody &= ojob.UDF2.Label & ": " & ojob.UDF2.Description & "<br />"
                End If
                If Not ojob.UDF3 Is Nothing Then
                    If Not ojob.UDF3.Code Is Nothing And ojob.UDF3.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= ojob.UDF3.Label & ": " & ojob.UDF3.Code & "<br />" Else If Not ojob.UDF3.Description Is Nothing Then strBody &= ojob.UDF3.Label & ": " & ojob.UDF3.Description & "<br />"
                End If
                If Not ojob.UDF4 Is Nothing Then
                    If Not ojob.UDF4.Code Is Nothing And ojob.UDF4.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= ojob.UDF4.Label & ": " & ojob.UDF4.Code & "<br />" Else If Not ojob.UDF4.Description Is Nothing Then strBody &= ojob.UDF4.Label & ": " & ojob.UDF4.Description & "<br />"
                End If
                If Not ojob.UDF5 Is Nothing Then
                    If Not ojob.UDF5.Code Is Nothing And ojob.UDF5.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= ojob.UDF5.Label & ": " & ojob.UDF5.Code & "<br />" & "<br />" Else If Not ojob.UDF5.Description Is Nothing Then strBody &= ojob.UDF5.Label & ": " & ojob.UDF5.Description & "<br />" & "<br />"
                End If
                Changes = True
            Else
                Dim myJobChangePlaceHolder As String = "|||JobChanges|||"
                strBody &= myJobChangePlaceHolder
                'Job changes:
                Dim i As Integer
                For i = 0 To Me.dtEdits.Rows.Count - 1
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.CL_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        NewClientCode = Me.dtEdits.Rows(i).Item(3).ToString().Trim()
                        strBody &= "Client" & "<br />"
                        strBody &= "New Value: " & NewClientCode & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                        HasCdpChange = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.DIV_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        NewDivisionCode = Me.dtEdits.Rows(i).Item(3).ToString().Trim()
                        strBody &= "Division" & "<br />"
                        strBody &= "New Value: " & NewDivisionCode & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                        HasCdpChange = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.PRD_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        NewProductCode = Me.dtEdits.Rows(i).Item(3).ToString().Trim()
                        strBody &= "Product" & "<br />"
                        strBody &= "New Value: " & NewProductCode & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                        HasCdpChange = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.JOB_DESC" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Job Description" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_CLIENT_REF.JOB_CLI_REF" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Client Reference" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.OFFICE_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Office" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.CMP_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Campaign" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.BILL_COOP_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Coop Billing" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.JOB_RUSH_CHARGES" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Rush Charges" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    'If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.JOB_ESTIMATE_REQ" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                    '    strBody &= "Approved Estimate" & "<br />"
                    '    strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                    '    strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                    '    strBody &= Spacer()
                    '    Changes = True
                    'End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.FORMAT_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Sales Class Format" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.COMPLEX_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Complexity" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.PROMO_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Promotion" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    Try

                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.JOB_COMMENTS" AndAlso
                            Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() AndAlso
                            i + 1 < dtEdits.Rows.Count Then

                            strBody &= "Job Comments" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i + 1).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i + 1).Item(2).ToString() & "<br />"
                            strBody &= Spacer()
                            Changes = True

                        End If

                    Catch ex As Exception
                    End Try
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.JOB_BILL_COMMENT" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Job Billing Comments" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        Changes = True
                    End If
                    With ojob
                        If Not .UDF1 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.UDV1_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF1.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                Changes = True
                            End If
                        End If
                        If Not .UDF2 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.UDV2_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF2.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                Changes = True
                            End If
                        End If
                        If Not .UDF3 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.UDV3_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF3.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                Changes = True
                            End If
                        End If
                        If Not .UDF4 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.UDV4_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF4.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                Changes = True
                            End If
                        End If
                        If Not .UDF5 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_LOG.UDV5_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF5.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                Changes = True
                            End If
                        End If
                    End With
                Next

                If Changes = True Then
                    Dim strHDR As String = String.Empty
                    strHDR &= "JOB CHANGES ARE AS FOLLOWS:"
                    strHDR &= "<hr />"
                    strBody = Replace(strBody, myJobChangePlaceHolder, strHDR)
                Else
                    strBody = Replace(strBody, myJobChangePlaceHolder, "")
                End If

            End If

            strBody &= "<br />" & "<br />"

            If Request.QueryString("NewComp") = "new" Or (Request.QueryString("NewJob") = "1" And Request.QueryString("NewComp") = "0") Then
                strBody &= "NEW JOB COMPONENT DETAILS ARE AS FOLLOWS:"
                strBody &= "<hr />"
                strBody &= "Description: " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
                strBody &= "Account Executive: " & GetAEDescript(ojob.JobComponent.EMP_CODE) & "<br />"

                If ojob.JobComponent.EMAIL_GR_CODE.Trim().Length > 0 Then strBody &= "Email Group Code: " & ojob.JobComponent.EMAIL_GR_CODE & "<br />"
                If ojob.JobComponent.ContactDesc.Trim().Length > 0 Then strBody &= "Contact Code: " & ojob.JobComponent.ContactDesc & "<br />"
                If ojob.JobComponent.JT_CODE.Trim().Length > 0 Then strBody &= "Job Type Code: " & ojob.JobComponent.JT_CODE & "<br />"
                If ojob.JobComponent.DP_TM_CODE.Trim().Length > 0 Then strBody &= "Dept/Team Code: " & ojob.JobComponent.DP_TM_CODE & "<br />"
                If ojob.JobComponent.AD_NBR.Trim().Length > 0 Then strBody &= "Ad Number: " & ojob.JobComponent.AD_NBR & "<br />"
                If ojob.JobComponent.MARKET_CODE.Trim().Length > 0 Then strBody &= "Market Code: " & ojob.JobComponent.MARKET_CODE & "<br />"
                If wvIsDate(ojob.JobComponent.JOB_COMP_DATE) Then strBody &= "Date opened: " & ojob.JobComponent.JOB_COMP_DATE.ToShortDateString & "<br />"
                If wvIsDate(ojob.JobComponent.MEDIA_BILL_DATE) Then strBody &= "Date opened: " & ojob.JobComponent.MEDIA_BILL_DATE.ToShortDateString & "<br />"
                If ojob.JobComponent.JOB_COMP_BUDGET_AM > 0 Then strBody &= "Budget: $" & ojob.JobComponent.JOB_COMP_BUDGET_AM.ToString() & "<br />"
                If ojob.JobComponent.ESTIMATE_NUMBER > 0 Then strBody &= "Estimate: " & ojob.JobComponent.ESTIMATE_NUMBER.ToString() & "<br />"
                If ojob.JobComponent.JOB_CL_PO_NBR.Trim().Length > 0 Then strBody &= "Client PO Number: " & ojob.JobComponent.JOB_CL_PO_NBR & "<br />"
                If wvIsDate(ojob.JobComponent.START_DATE) Then strBody &= "Start Date: " & ojob.JobComponent.START_DATE.ToShortDateString & "<br />"
                If wvIsDate(ojob.JobComponent.JOB_FIRST_USE_DATE) Then strBody &= "Due Date: " & ojob.JobComponent.JOB_FIRST_USE_DATE.ToShortDateString & "<br />"
                If ojob.JobComponent.TRF_SCHEDULE_REQ > -1 Then strBody &= "Schedule needed: " & GetYesNo(ojob.JobComponent.TRF_SCHEDULE_REQ) & "<br />"
                If ojob.JobComponent.ACCT_NBR.Trim().Length > 0 Then strBody &= "Account Number: " & ojob.JobComponent.ACCT_NBR.Trim() & "<br />"
                If ojob.JobComponent.JOB_PROCESS_CONTRL > 0 Then strBody &= "Process Control: " & ojob.JobComponent.JOB_PROCESS_CONTRL & "<br />"
                If ojob.JobComponent.NOBILL_FLAG = 1 Then
                    strBody &= "Nonbillable" & "<br />"
                    'strBody &= "Is Job component non-billable: Yes, it is non-billable." & "<br />"
                Else
                    strBody &= "Billable" & "<br />"
                    'strBody &= "Is Job component non-billable: No, job is billable!" & "<br />"
                End If
                If ojob.JobComponent.JOB_MARKUP_PCT = -1 Or ojob.JobComponent.JOB_MARKUP_PCT.ToString = "" Or ojob.JobComponent.JOB_MARKUP_PCT.ToString.Length = 0 Then

                    strBody &= "Markup Pct: " & CStr(ojob.JobComponent.GetMarkupAmt(ojob.CL_CODE, ojob.DIV_CODE, ojob.PRD_CODE)) & "%" & "<br />"
                    'strBody &= "Markup Pct: 0%" & "<br />"
                Else
                    strBody &= "Markup Pct: " & ojob.JobComponent.JOB_MARKUP_PCT & "%" & "<br />"
                End If
                If ojob.JobComponent.TAX_FLAG > -1 Then strBody &= "Taxable: " & GetYesNo(ojob.JobComponent.TAX_FLAG) & "<br />"
                If ojob.JobComponent.TAX_CODE.Trim().Length > 0 Then strBody &= "Tax Code: " & ojob.JobComponent.TAX_CODE & "<br />"
                If ojob.JobComponent.JC_COMMENTS_HTML.Trim().Length > 0 Then strBody &= "Component Comments: " & ojob.JobComponent.JC_COMMENTS_HTML & "<br />" Else strBody &= "Component Comments: " & ojob.JobComponent.JOB_COMP_COMMENTS.Trim() & "<br />"

                If ojob.JobComponent.CREATIVE_INSTR_HTML.Trim().Length > 0 Then strBody &= "Creative Instructions: " & ojob.JobComponent.CREATIVE_INSTR_HTML & "<br />" Else strBody &= "Creative Instructions: " & ojob.JobComponent.CREATIVE_INSTR.Trim() & "<br />"
                If ojob.JobComponent.JOB_DEL_INSTR_HTML.Trim().Length > 0 Then strBody &= "Shipping Instructions: " & ojob.JobComponent.JOB_DEL_INSTR_HTML & "<br />" Else strBody &= "Shipping Instructions: " & ojob.JobComponent.JOB_DEL_INSTRUCT & "<br />"
                'TODO: JOB COMP UDF's
                If Not ojob.JobComponent.UDF1 Is Nothing Then
                    If Not ojob.JobComponent.UDF1.Code Is Nothing And ojob.JobComponent.UDF1.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= ojob.JobComponent.UDF1.Label & ": " & ojob.JobComponent.UDF1.Code & "<br />" Else If Not ojob.JobComponent.UDF1.Description Is Nothing Then strBody &= ojob.JobComponent.UDF1.Label & ": " & ojob.JobComponent.UDF1.Description & "<br />"
                End If
                If Not ojob.JobComponent.UDF2 Is Nothing Then
                    If Not ojob.JobComponent.UDF2.Code Is Nothing And ojob.JobComponent.UDF2.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= ojob.JobComponent.UDF2.Label & ": " & ojob.JobComponent.UDF2.Code & "<br />" Else If Not ojob.JobComponent.UDF2.Description Is Nothing Then strBody &= ojob.JobComponent.UDF2.Label & ": " & ojob.JobComponent.UDF2.Description & "<br />"
                End If
                If Not ojob.JobComponent.UDF3 Is Nothing Then
                    If Not ojob.JobComponent.UDF3.Code Is Nothing And ojob.JobComponent.UDF3.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= ojob.JobComponent.UDF3.Label & ": " & ojob.JobComponent.UDF3.Code & "<br />" Else If Not ojob.JobComponent.UDF3.Description Is Nothing Then strBody &= ojob.JobComponent.UDF3.Label & ": " & ojob.JobComponent.UDF3.Description & "<br />"
                End If
                If Not ojob.JobComponent.UDF4 Is Nothing Then
                    If Not ojob.JobComponent.UDF4.Code Is Nothing And ojob.JobComponent.UDF4.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= ojob.JobComponent.UDF4.Label & ": " & ojob.JobComponent.UDF4.Code & "<br />" Else If Not ojob.JobComponent.UDF4.Description Is Nothing Then strBody &= ojob.JobComponent.UDF4.Label & ": " & ojob.JobComponent.UDF4.Description & "<br />"
                End If
                If Not ojob.JobComponent.UDF5 Is Nothing Then
                    If Not ojob.JobComponent.UDF5.Code Is Nothing And ojob.JobComponent.UDF5.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= ojob.JobComponent.UDF5.Label & ": " & ojob.JobComponent.UDF5.Code & "<br />" Else If Not ojob.JobComponent.UDF5.Description Is Nothing Then strBody &= ojob.JobComponent.UDF5.Label & ": " & ojob.JobComponent.UDF5.Description & "<br />"
                End If
                If ojob.JobComponent.BLACKPLT_VER_CODE.Trim().Length > 0 Then strBody &= "Blackplate Version:  " & ojob.JobComponent.BLACKPLT_VER_CODE & "<br />"
                If ojob.JobComponent.BLACKPLT_VER_DESC.Trim().Length > 0 Then strBody &= "Blackplate Version Description:  " & ojob.JobComponent.BLACKPLT_VER_DESC & "<br />"
                If ojob.JobComponent.BLACKPLT_VER2_CODE.Trim().Length > 0 Then strBody &= "Blackplate Version 2:  " & ojob.JobComponent.BLACKPLT_VER2_CODE & "<br />"
                If ojob.JobComponent.BLACKPLT_VER2_DESC.Trim().Length > 0 Then strBody &= "Blackplate Version 2 Description:  " & ojob.JobComponent.BLACKPLT_VER2_DESC & "<br />"
                If ojob.JobComponent.FISCAL_PERIOD_CODE.Trim().Length > 0 Then strBody &= "Fiscal Period:  " & ojob.JobComponent.FISCAL_PERIOD_CODE & "<br />"
                If ojob.JobComponent.JOB_QTY.Trim().Length > 0 Then strBody &= "Job Quantity:  " & ojob.JobComponent.JOB_QTY & "<br />"
                If ojob.JobComponent.SERVICE_FEE_TYPE_ID > 0 Then strBody &= "Service Fee Type:  " & ojob.JobComponent.SERVICE_FEE_TYPE_CODE & "<br />"

                Try
                    ' If ojob.JobComponent.ALRT_NOTIFY_HDR_ID > 0 Then strBody &= "Job Quantity:  " & ojob.JobComponent.ALRT_NOTIFY_HDR_ID & "<br />"
                    If ojob.JobComponent.ALERT_NOTIFY_NAME.Trim().Length > 0 Then strBody &= "Alert Notify Template:  " & ojob.JobComponent.ALERT_NOTIFY_NAME & "<br />"
                Catch ex As Exception
                End Try
                Changes = True
            Else 'consider it a modify
                Dim boolJCChanges As Boolean = False
                Dim strJCChangeHdr As String = String.Empty
                Dim strJCChangePlaceHolder As String = "|||JCChangePlaceHolder|||"

                strJCChangeHdr &= "JOB COMPONENT CHANGES ARE AS FOLLOWS:"
                strJCChangeHdr &= "<hr />"

                strBody &= strJCChangePlaceHolder
                Dim i As Integer
                For i = 0 To Me.dtEdits.Rows.Count - 1
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_COMP_DESC" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Job Component Description" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.EMP_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Account Executive" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.EMAIL_GR_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "E-mail Group" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If HasCDPContactChange And CDPContactChangeAddedToMessage = False Then
                        strBody &= "Product Contact" & "<br />"
                        strBody &= "New Value: " & GetCDPContactName(Me.HfNewCDP_CONTACT_ID.Value) & "<br />"
                        strBody &= "Original Value: " & GetCDPContactName(Me.HfOldCDP_CONTACT_ID.Value) & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                        CDPContactChangeAddedToMessage = True
                    End If

                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JT_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Job Type" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.DP_TM_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Dept Team" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.AD_NBR" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Ad Number" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.MARKET_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Market Code" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_COMP_DATE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Date Opened" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.MEDIA_BILL_DATE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Media Date to Bill" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_COMP_BUDGET_AM" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Budget" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_CL_PO_NBR" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Client PO Number" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.START_DATE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Start Date" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_FIRST_USE_DATE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Due Date" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.TRF_SCHEDULE_REQ" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Schedule Needed" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.ACCT_NBR" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Account Number Changed" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.NOBILL_FLAG" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Job Comp Billable Status" & "<br />"
                            strBody &= "New Value: " & IIf(Me.dtEdits.Rows(i).Item(3).ToString() = "0", "Billable", "Nonbillable") & "<br />"
                            'strBody &= "New Value: " & IIf(Me.dtEdits.Rows(i).Item(3).ToString() = "0", "Unchecked. (Billable)", "Checked. (No longer Billable)") & "<br />"
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Job Comp Billable Status" & "<br />"
                            strBody &= "New Value: " & IIf(Me.dtEdits.Rows(i).Item(3).ToString() = "1", "Nonbillable", "Billable") & "<br />"
                            'strBody &= "New Value: " & IIf(Me.dtEdits.Rows(i).Item(3).ToString() = "1", "Checked. (No longer Billable)", "Unchecked. (Billable)") & "<br />"
                        End If
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_MARKUP_PCT" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "-1" Or Me.dtEdits.Rows(i).Item(3).ToString() = "" Or Me.dtEdits.Rows(i).Item(3).ToString().Trim().Length = 0 Then
                            strBody &= "Job Markup Percentage" & "<br />"
                            strBody &= "New Value: 0%" & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "%" & "<br />"
                        Else
                            strBody &= "Job Markup Percentage" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "%" & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "%" & "<br />"
                        End If
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.TAX_FLAG" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then 'db flag is taxable, radio taxable index for yes is zero.  so this if is when tax is true but radio is "no"
                            strBody &= "Job Taxable Status" & "<br />"
                            strBody &= "New Value: Not taxable" & "<br />"
                            strBody &= "Original Value: Taxable" & "<br />"
                            strBody &= Spacer()
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Job Comp Taxable Status" & "<br />"
                            strBody &= "New Value: Taxable" & "<br />"
                            strBody &= "Original Value: Not taxable" & "<br />"
                            strBody &= Spacer()
                        End If
                        boolJCChanges = True
                        Me.oTF = Me.dtEdits.Rows(i).Item(2).ToString
                        Me.pTF = Me.dtEdits.Rows(i).Item(3).ToString
                    End If
                    With ojob.JobComponent
                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.TAX_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                            If .TAX_FLAG <> 1 And Me.oTF = "0" Then
                                If Me.dtEdits.Rows(i).Item(3).ToString() <> .TAX_CODE.ToString() Then
                                    strBody &= "Job Comp Tax Code" & "<br />"
                                    strBody &= "New Value: Not set" & "<br />"
                                    strBody &= "Original Value: " & .TAX_CODE & "<br />"
                                    strBody &= Spacer()
                                End If
                            ElseIf .TAX_FLAG = 1 And Me.oTF = "0" Then
                                If Me.dtEdits.Rows(i).Item(3).ToString() <> .TAX_CODE.ToString() Then
                                    strBody &= "Job Comp Tax Code" & "<br />"
                                    strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                    strBody &= "Original Value: " & .TAX_CODE & "<br />"
                                    strBody &= Spacer()
                                End If
                            ElseIf .TAX_FLAG = 1 And Me.oTF = "1" Then
                                If Me.dtEdits.Rows(i).Item(3).ToString() <> .TAX_CODE.ToString() Then
                                    strBody &= "Job Comp Tax Code" & "<br />"
                                    strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                    strBody &= "Original Value: " & .TAX_CODE & "<br />"
                                    strBody &= Spacer()
                                End If
                            End If
                            boolJCChanges = True
                        End If
                    End With
                    Try

                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_COMP_COMMENTS" AndAlso
                            Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() AndAlso
                            i + 1 < dtEdits.Rows.Count Then

                            strBody &= "Job Component Comments" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i + 1).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i + 1).Item(2).ToString() & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.CREATIVE_INSTR" AndAlso
                            Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() AndAlso
                            i + 1 < dtEdits.Rows.Count Then

                            strBody &= "Creative Instructions" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i + 1).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i + 1).Item(2).ToString() & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_DEL_INSTRUCT" AndAlso
                            Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() AndAlso
                            i + 1 < dtEdits.Rows.Count Then

                            strBody &= "Shipping Instructions" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i + 1).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i + 1).Item(2).ToString() & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True

                        End If

                    Catch ex As Exception
                    End Try
                    With ojob.JobComponent
                        If Not .UDF1 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.UDV1_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF1.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                boolJCChanges = True
                            End If
                        End If
                        If Not .UDF2 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.UDV2_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF2.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                boolJCChanges = True
                            End If
                        End If
                        If Not .UDF3 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.UDV3_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF3.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                boolJCChanges = True
                            End If
                        End If
                        If Not .UDF4 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.UDV4_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF4.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                boolJCChanges = True
                            End If
                        End If
                        If Not .UDF5 Is Nothing Then
                            If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.UDV5_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                                strBody &= .UDF5.Label & "<br />"
                                strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                                strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                                strBody &= Spacer()
                                boolJCChanges = True
                            End If
                        End If

                    End With
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_THUMB" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Layout Thumb" & "<br />"
                            strBody &= "New Value: Yes" & "<br />"
                            strBody &= "Original Value: No" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Layout Thumb" & "<br />"
                            strBody &= "New Value: No" & "<br />"
                            strBody &= "Original Value: Yes" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_COMP" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Layout Comp" & "<br />"
                            strBody &= "New Value: Yes" & "<br />"
                            strBody &= "Original Value: No" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Layout Comp" & "<br />"
                            strBody &= "New Value: No" & "<br />"
                            strBody &= "Original Value: Yes" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_ROUGH" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Layout Rough" & "<br />"
                            strBody &= "New Value: Yes" & "<br />"
                            strBody &= "Original Value: No" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Layout Rough" & "<br />"
                            strBody &= "New Value: No" & "<br />"
                            strBody &= "Original Value: Yes" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_NONE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Layout None" & "<br />"
                            strBody &= "New Value: Yes" & "<br />"
                            strBody &= "Original Value: No" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Layout None" & "<br />"
                            strBody &= "New Value: No" & "<br />"
                            strBody &= "Original Value: Yes" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_SPECIAL" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                            strBody &= "Layout Special" & "<br />"
                            strBody &= "New Value: Yes" & "<br />"
                            strBody &= "Original Value: No" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        ElseIf Me.dtEdits.Rows(i).Item(3).ToString() = "1" Then
                            strBody &= "Layout Special" & "<br />"
                            strBody &= "New Value: No" & "<br />"
                            strBody &= "Original Value: Yes" & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_LAYOUT_SPC_EXP" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        'If Me.dtEdits.Rows(i).Item(3).ToString() = "0" Then
                        strBody &= "Special - Explain" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                        'End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.BLACKPLT_VER_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Blackplate Version" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        If Me.dtEdits.Rows(i).Item(3).ToString() <> "" Then
                            strBody &= "Blackplate Version Description" & "<br />"
                            strBody &= "New Value: " & ojob.JobComponent.BLACKPLT_VER_DESC & "<br />"
                            strBody &= Spacer()
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.BLACKPLT_VER_DESC" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Blackplate Version Description" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.BLACKPLT_VER2_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Blackplate Version 2" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        If Me.dtEdits.Rows(i).Item(3).ToString() <> "" Then
                            strBody &= "Blackplate Version Description 2" & "<br />"
                            strBody &= "New Value: " & ojob.JobComponent.BLACKPLT_VER2_DESC & "<br />"
                            strBody &= Spacer()
                        End If
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.BLACKPLT_VER2_DESC" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Blackplate Version Description 2" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.JOB_QTY" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Job Quantity" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.FISCAL_PERIOD_CODE" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        strBody &= "Fiscal Period" & "<br />"
                        strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                        strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                        strBody &= Spacer()
                        boolJCChanges = True
                    End If
                    Try
                        If Me.dtEdits.Rows(i).Item(0).ToString() = "JOB_COMPONENT.ALRT_NOTIFY_HDR_ID" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                            strBody &= "Alert Notify Template" & "<br />"
                            strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        Dim stNew As AdvantageFramework.Database.Entities.ServiceFeeType
                        Dim stOrig As AdvantageFramework.Database.Entities.ServiceFeeType
                        If Me.dtEdits.Rows(i).Item(0).ToString() = "SERVICE_FEE_TYPE_ID" And Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                            strBody &= "Service Fee Type" & "<br />"
                            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                                If Me.dtEdits.Rows(i).Item(3).ToString <> "" Then
                                    stNew = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeID(DbContext, Me.dtEdits.Rows(i).Item(3))
                                    strBody &= "New Value: " & stNew.Code & "<br />"
                                Else
                                    strBody &= "New Value: " & "<br />"
                                End If
                                If Me.dtEdits.Rows(i).Item(2).ToString <> "" Then
                                    stOrig = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeID(DbContext, Me.dtEdits.Rows(i).Item(2))
                                    strBody &= "Original Value: " & stOrig.Code & "<br />"
                                Else
                                    strBody &= "Original Value: " & "<br />"
                                End If
                            End Using
                            strBody &= Spacer()
                            boolJCChanges = True
                        End If
                    Catch ex As Exception
                    End Try
                Next

                If boolJCChanges = True Then
                    strBody = Replace(strBody, strJCChangePlaceHolder, strJCChangeHdr)
                    Changes = True
                Else
                    strBody = Replace(strBody, strJCChangePlaceHolder, "")
                End If
            End If

            Return True

        Catch ex As Exception
            Me.ShowMessage("Error in CheckChanges" & ex.Message.ToString())
        Finally

            If HasCdpChange = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Dim a As New AdvantageFramework.Controller.Desktop.AlertController(Me._Session)
                    Dim Msg As String = String.Empty

                    If a.UpdateAssignmentsCDP(DbContext, NewClientCode, NewDivisionCode, NewProductCode, ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, Msg) = False Then

                        If String.IsNullOrWhiteSpace(Msg) = False Then

                            Me.ShowMessage("Could not update assignments CDP.  " & Msg)

                        End If

                    End If

                End Using

            End If

        End Try

    End Function

    Private Function GetJobDateForAlert(ByRef ojob As Job, ByRef strBody As String)
        Try
            strBody &= "Client: " & ojob.CL_CODE & " - " & ojob.ClientDesc & "<br />"
            strBody &= "Division: " & ojob.DIV_CODE & " - " & ojob.DivisionDesc & "<br />"
            strBody &= "Product: " & ojob.PRD_CODE & " - " & ojob.ProductDesc & "<br />"
            strBody &= "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />"
            strBody &= "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            strBody &= "Acct Exec: " & GetAEDescript(ojob.JobComponent.EMP_CODE) & "<br />"
            strBody &= "Office: " & ojob.OFFICE_CODE & "<br />" & "<br />"
            strBody &= "--------------------------------------" & "<br />"
            strBody &= "JOB DETAILS ARE AS FOLLOWS:" & "<br />"
            strBody &= "--------------------------------------" & "<br />"
            strBody &= "Job Opened Date: " & ojob.CREATE_DATE.ToShortDateString & "<br />"
            strBody &= "Client Reference: " & IIf(ojob.JOB_CLI_REF.Trim().Length > 0, ojob.JOB_CLI_REF, "N/A") & "<br />"
            strBody &= "Sales Class: " & IIf(ojob.SalesClassDesc.Trim().Length > 0, ojob.SalesClassDesc, "N/A") & "<br />"
            Dim dblTotalBudget As Decimal = 0.0
            Dim BudgetAmt As Decimal = 0.0
            If Request.QueryString("jobcomponent") = "new" Or (Request.QueryString("NewJob") = "1" And Request.QueryString("NewComp") = "1") Then
                BudgetAmt = CType(ojob.JobComponent.JOB_COMP_BUDGET_AM.ToString().Replace(",", ""), Decimal)
                If IsNumeric(BudgetAmt) = True Then
                    dblTotalBudget = ojob.TotalBudget + BudgetAmt
                Else
                    dblTotalBudget = ojob.TotalBudget
                End If
            End If
            'If dblTotalBudget > 0 Then
            strBody &= "Total Budget: $" & dblTotalBudget.ToString() & "<br />"
            If ojob.CMP_CODE.Trim().Length > 0 Then strBody &= "Campaign code: " & ojob.CMP_CODE & "<br />"
            If ojob.BILL_COOP_CODE.Trim().Length > 0 Then strBody &= "COOP Billing code: " & ojob.BILL_COOP_CODE & "<br />"
            strBody &= "Rush Charges Approved: " & GetYesNo(ojob.JOB_RUSH_CHARGES) & "<br />"
            strBody &= "Approved Estimate Required: " & GetYesNo(ojob.JOB_ESTIMATE_REQ) & "<br />"
            If ojob.SalesClassFormatDesc.Trim().Length > 0 Then strBody &= "Sales Class Format code: " & ojob.SalesClassFormatDesc & "<br />"
            If ojob.ComplexityDesc.Trim().Length > 0 Then strBody &= "Complexity code: " & ojob.ComplexityDesc & "<br />"
            If ojob.PromotionDesc.Trim().Length > 0 Then strBody &= "Promotion code: " & ojob.PromotionDesc & "<br />"
            If ojob.JOB_COMMENTS.Trim().Length > 0 Then strBody &= "Job Comment: " & ojob.JOB_COMMENTS & "<br />"
            If ojob.JOB_BILL_COMMENT.Trim().Length > 0 Then strBody &= "Billing Comment: " & ojob.JOB_BILL_COMMENT & "<br />"
            'TODO: JOB UDF's
            If Not ojob.UDF1 Is Nothing Then
                If Not ojob.UDF1.Code Is Nothing And ojob.UDF1.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= "User Defined 1: " & ojob.UDF1.Code & "<br />" Else strBody &= "User Defined 1: " & ojob.UDF1.Description & "<br />"
            End If
            If Not ojob.UDF2 Is Nothing Then
                If Not ojob.UDF2.Code Is Nothing And ojob.UDF2.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= "User Defined 2: " & ojob.UDF2.Code & "<br />" Else strBody &= "User Defined 2: " & ojob.UDF2.Description & "<br />"
            End If
            If Not ojob.UDF3 Is Nothing Then
                If Not ojob.UDF3.Code Is Nothing And ojob.UDF3.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= "User Defined 3: " & ojob.UDF3.Code & "<br />" Else strBody &= "User Defined 3: " & ojob.UDF3.Description & "<br />"
            End If
            If Not ojob.UDF4 Is Nothing Then
                If Not ojob.UDF4.Code Is Nothing And ojob.UDF4.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= "User Defined 4: " & ojob.UDF4.Code & "<br />" Else strBody &= "User Defined 4: " & ojob.UDF4.Description & "<br />"
            End If
            If Not ojob.UDF5 Is Nothing Then
                If Not ojob.UDF5.Code Is Nothing And ojob.UDF5.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") Then strBody &= "User Defined 5: " & ojob.UDF5.Code & "<br />" & "<br />" Else strBody &= "User Defined 5: " & ojob.UDF5.Description & "<br />" & "<br />"
            End If
            strBody &= "--------------------------------------" & "<br />"
            strBody &= "JOB COMPONENT DETAILS ARE AS FOLLOWS:" & "<br />"
            strBody &= "--------------------------------------" & "<br />"
            strBody &= "Description: " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            strBody &= "Account Executive: " & GetAEDescript(ojob.JobComponent.EMP_CODE) & "<br />"

            If ojob.JobComponent.EMAIL_GR_CODE.Trim().Length > 0 Then strBody &= "Email Group Code: " & ojob.JobComponent.EMAIL_GR_CODE & "<br />"
            If ojob.JobComponent.ContactDesc.Trim().Length > 0 Then strBody &= "Contact Code: " & ojob.JobComponent.ContactDesc & "<br />"
            If ojob.JobComponent.JOB_SPEC_TYPE.Trim().Length > 0 Then strBody &= "Job Type Code: " & ojob.JobComponent.JOB_SPEC_TYPE & "<br />"
            If ojob.JobComponent.DP_TM_CODE.Trim().Length > 0 Then strBody &= "Dept/Team Code: " & ojob.JobComponent.DP_TM_CODE & "<br />"
            If ojob.JobComponent.AD_NBR.Trim().Length > 0 Then strBody &= "Ad Number: " & ojob.JobComponent.AD_NBR & "<br />"
            If ojob.JobComponent.MARKET_CODE.Trim().Length > 0 Then strBody &= "Market Code: " & ojob.JobComponent.MARKET_CODE & "<br />"
            If wvIsDate(ojob.JobComponent.JOB_COMP_DATE) Then strBody &= "Date opened: " & ojob.JobComponent.JOB_COMP_DATE.ToShortDateString & "<br />"
            If wvIsDate(ojob.JobComponent.MEDIA_BILL_DATE) Then strBody &= "Date opened: " & ojob.JobComponent.MEDIA_BILL_DATE.ToShortDateString & "<br />"
            If ojob.JobComponent.JOB_COMP_BUDGET_AM > 0 Then strBody &= "Budget: $" & ojob.JobComponent.JOB_COMP_BUDGET_AM.ToString() & "<br />"
            If ojob.JobComponent.ESTIMATE_NUMBER > 0 Then strBody &= "Estimate: " & ojob.JobComponent.ESTIMATE_NUMBER.ToString() & "<br />"
            If ojob.JobComponent.JOB_CL_PO_NBR.Trim().Length > 0 Then strBody &= "Client PO Number: " & ojob.JobComponent.JOB_CL_PO_NBR & "<br />"
            If wvIsDate(ojob.JobComponent.START_DATE) Then strBody &= "Start Date: " & ojob.JobComponent.START_DATE.ToShortDateString & "<br />"
            If wvIsDate(ojob.JobComponent.JOB_FIRST_USE_DATE) Then strBody &= "Due Date: " & ojob.JobComponent.JOB_FIRST_USE_DATE.ToShortDateString & "<br />"
            If ojob.JobComponent.TRF_SCHEDULE_REQ > -1 Then strBody &= "Schedule needed: " & GetYesNo(ojob.JobComponent.TRF_SCHEDULE_REQ) & "<br />"
            If ojob.JobComponent.ACCT_NBR.Trim().Length > 0 Then strBody &= "Account Number: " & ojob.JobComponent.ACCT_NBR.Trim().Length & "<br />"
            If ojob.JobComponent.JOB_PROCESS_CONTRL > 0 Then strBody &= "Process Control: " & ojob.JobComponent.JOB_PROCESS_CONTRL & "<br />"
            If ojob.JobComponent.NOBILL_FLAG = 1 Then
                strBody &= "Nonbillable" & "<br />"
                'strBody &= "Is Job component non-billable: Yes, it is non-billable." & "<br />"
            Else
                strBody &= "Billable" & "<br />"
                'strBody &= "Is Job component non-billable: No, job is billable!" & "<br />"
            End If
            If ojob.JobComponent.MARKUP_PERC = "-1" Or ojob.JobComponent.MARKUP_PERC = "" Or ojob.JobComponent.MARKUP_PERC.Trim().Length = 0 Then
                strBody &= "Markup Pct: 0%" & "<br />"
            Else
                strBody &= "Markup Pct: " & ojob.JobComponent.MARKUP_PERC & "%" & "<br />"
            End If
            If ojob.JobComponent.TAX_FLAG > -1 Then strBody &= "Taxable: " & GetYesNo(ojob.JobComponent.TAX_FLAG) & "<br />"
            If ojob.JobComponent.TAX_CODE.Trim().Length > 0 Then strBody &= "Tax Code: " & ojob.JobComponent.TAX_CODE & "<br />"
            If ojob.JobComponent.JOB_COMP_COMMENTS.Trim().Length > 0 Then strBody &= "Component Comments: " & ojob.JobComponent.JOB_COMP_COMMENTS & "<br />"
            If ojob.JobComponent.CREATIVE_INSTR.Trim().Length > 0 Then strBody &= "Creative Instructions: " & ojob.JobComponent.CREATIVE_INSTR & "<br />"
            If ojob.JobComponent.JOB_DEL_INSTRUCT.Trim().Length > 0 Then strBody &= "Shipping Instructions: " & ojob.JobComponent.JOB_DEL_INSTRUCT & "<br />"
            'TODO: JOB COMP UDF's
            If Not ojob.JobComponent.UDF1 Is Nothing Then
                If Not ojob.JobComponent.UDF1.Code Is Nothing And ojob.JobComponent.UDF1.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= "User Defined 1: " & ojob.JobComponent.UDF1.Code & "<br />" Else strBody &= "User Defined 1: " & ojob.JobComponent.UDF1.Description & "<br />"
            End If
            If Not ojob.JobComponent.UDF2 Is Nothing Then
                If Not ojob.JobComponent.UDF2.Code Is Nothing And ojob.JobComponent.UDF2.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= "User Defined 2: " & ojob.JobComponent.UDF2.Code & "<br />" Else strBody &= "User Defined 2: " & ojob.JobComponent.UDF2.Description & "<br />"
            End If
            If Not ojob.JobComponent.UDF3 Is Nothing Then
                If Not ojob.JobComponent.UDF3.Code Is Nothing And ojob.JobComponent.UDF3.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= "User Defined 3: " & ojob.JobComponent.UDF3.Code & "<br />" Else strBody &= "User Defined 3: " & ojob.JobComponent.UDF3.Description & "<br />"
            End If
            If Not ojob.JobComponent.UDF4 Is Nothing Then
                If Not ojob.JobComponent.UDF4.Code Is Nothing And ojob.JobComponent.UDF4.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= "User Defined 4: " & ojob.JobComponent.UDF4.Code & "<br />" Else strBody &= "User Defined 4: " & ojob.JobComponent.UDF4.Description & "<br />"
            End If
            If Not ojob.JobComponent.UDF5 Is Nothing Then
                If Not ojob.JobComponent.UDF5.Code Is Nothing And ojob.JobComponent.UDF5.Code <> ojob.JOB_NUMBER.ToString().PadLeft(6, "0") & "-" & ojob.JobComponent.JOB_COMPONENT_NBR.ToString().PadLeft(3, "0") Then strBody &= "User Defined 5: " & ojob.JobComponent.UDF5.Code & "<br />" Else strBody &= "User Defined 5: " & ojob.JobComponent.UDF5.Description & "<br />"
            End If
            If ojob.JobComponent.BLACKPLT_VER_CODE.Trim().Length > 0 Then strBody &= "Blackplate Version:  " & ojob.JobComponent.BLACKPLT_VER_CODE & "<br />"
            If ojob.JobComponent.BLACKPLT_VER_DESC.Trim().Length > 0 Then strBody &= "Blackplate Version Description:  " & ojob.JobComponent.BLACKPLT_VER_DESC & "<br />"
            If ojob.JobComponent.BLACKPLT_VER2_CODE.Trim().Length > 0 Then strBody &= "Blackplate Version 2:  " & ojob.JobComponent.BLACKPLT_VER2_CODE & "<br />"
            If ojob.JobComponent.BLACKPLT_VER2_DESC.Trim().Length > 0 Then strBody &= "Blackplate Version 2 Description:  " & ojob.JobComponent.BLACKPLT_VER2_DESC & "<br />"
            If ojob.JobComponent.FISCAL_PERIOD_CODE.Trim().Length > 0 Then strBody &= "Fiscal Period:  " & ojob.JobComponent.FISCAL_PERIOD_CODE & "<br />"
            If ojob.JobComponent.JOB_QTY.Trim().Length > 0 Then strBody &= "Job Quantity:  " & ojob.JobComponent.JOB_QTY & "<br />"
        Catch ex As Exception
            Me.ShowMessage("Error in GetJobDateForAlert" & ex.Message.ToString())
        End Try

    End Function

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Session("NewJSNew") = 1 Then
            Me.OpenWindow("", "jobspecs_AddNew.aspx?JobNum=" & Me.JobNumber & "&JobCompNum=" & Me.JobComponentNbr & "&AddType=4")
        End If

        Try
            If JobNumber > 0 And JobComponentNbr > 0 Then
                Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
                Dim jc As New Job(Session("Connstring"))
                'CurrTemplate = MyJobTemplate.GetTemplateCode(JobNumber, JobComponentNbr)
                BindDropTemplates(CurrTemplate)

                Try
                    Dim SessionKey As String = "JOB_COMPONENT_NOBILL_FLAG" & JobNumber.ToString() & JobComponentNbr.ToString()
                    Dim ReturnInteger As Integer = 0
                    'If HttpContext.Current.Session(SessionKey) Is Nothing Then
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyCmd As New SqlCommand("SELECT ISNULL(JOB_COMPONENT.NOBILL_FLAG,0) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_COMPONENT.JOB_NUMBER = " & JobNumber &
                                                    " AND JOB_COMPONENT.JOB_COMPONENT_NBR = " & JobComponentNbr & ";", MyConn)
                        Try
                            ReturnInteger = CType(MyCmd.ExecuteScalar, Integer)
                        Catch ex As Exception
                            ReturnInteger = 0
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    '    HttpContext.Current.Session(SessionKey) = ReturnInteger
                    'Else
                    '    ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
                    'End If
                    If ReturnInteger > 0 Then
                        Me.LblNonBillable.Visible = True
                    Else
                        Me.LblNonBillable.Visible = False
                    End If
                Catch ex As Exception
                    Me.LblNonBillable.Visible = False
                End Try

            End If

        Catch
        End Try

    End Sub


#Region "CDP Contact Stuff"
    'keep contact separate to make cdp contact mod less complicated

    Private HasCDPContactChange As Boolean
    Private CDPContactChangeAddedToMessage As Boolean
    Private ContactCodeFromDB As String
    Private ContactCodeFromForm As String
    Private ClientCodeForContact As String

    Private Sub GetCDPContact(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer)
        If JobNumber > 0 And JobComponentNbr > 0 Then
            'Dim SessionKey As String = "GetCDPContact" & JobNumber.ToString() & JobComponentNbr.ToString()
            Dim ReturnString As String = ""
            'If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim jc As New JOB_COMPONENT(Session("ConnString"))
            If jc.LoadByPrimaryKey(JobComponentNbr, JobNumber) Then
                ReturnString = jc.CDP_CONTACT_ID
            End If
            '    HttpContext.Current.Session(SessionKey) = ReturnString
            'Else
            '    ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            'End If
            Me.HfOldCDP_CONTACT_ID.Value = ReturnString
        End If
    End Sub

    Private Function SaveCDPContact(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer, ByVal ContactCode As String, ByRef ErrorMessage As String) As Boolean
        ErrorMessage = ""
        If JobNumber > 0 And JobComponentNbr > 0 Then
            Dim oldCDPContact As String = Me.HfOldCDP_CONTACT_ID.Value
            Dim newCDPContact As String = Me.HfNewCDP_CONTACT_ID.Value
            Dim Saved As Boolean = False

            If ContactCode <> "" AndAlso IsNumeric(ContactCode) = False Then
                Dim j As New JOB_LOG(Session("ConnString"))
                If j.LoadByPrimaryKey(JobNumber) Then
                    Dim jf As New cJobFunctions()
                    newCDPContact = jf.GetCDPContactID(ContactCode, j.CL_CODE)
                    If newCDPContact = -1 Then
                        ErrorMessage = "Invalid Contact Code"
                        Return False
                    End If
                End If
            End If

            If oldCDPContact <> newCDPContact Then
                'validate
                If newCDPContact = "" Or newCDPContact = "0" Then 'Set null
                    Try
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "UPDATE JOB_COMPONENT SET CDP_CONTACT_ID = NULL WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr)
                        Return True
                    Catch ex As Exception
                        ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                        Return False
                    End Try
                ElseIf IsNumeric(newCDPContact) Then 'update
                    If CType(newCDPContact, Integer) > 0 Then
                        Dim oVal As New cValidations(Session("ConnString"))
                        If oVal.ValidateCDPContact(newCDPContact, Session("UserCode")) = True Then
                            Try
                                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "UPDATE JOB_COMPONENT SET CDP_CONTACT_ID = " & newCDPContact & " WHERE JOB_NUMBER = " & JobNumber & " AND JOB_COMPONENT_NBR = " & JobComponentNbr)
                                Return True
                            Catch ex As Exception
                                ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                Return False
                            End Try
                        Else
                            ErrorMessage = "Invalid Contact Code"
                            Return False
                        End If
                    Else
                        ErrorMessage = ""
                        Return True
                    End If
                End If
            End If

            ErrorMessage = ""
            Return True
        Else
            ErrorMessage = "Could not get Job/Comp number"
            Return False
        End If


    End Function

    Private Function GetCDPContactName(ByVal StrCDPContactID As String) As String
        Dim SessionKey As String = "GetCDPContactName" & StrCDPContactID.ToString()
        Dim ReturnString As String = ""
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim CDPContactID As Integer = 0
                If IsNumeric(StrCDPContactID) Then
                    CDPContactID = CType(StrCDPContactID, Integer)
                Else
                    CDPContactID = 0
                    ReturnString = ""
                End If
                If CDPContactID > 0 Then
                    Dim cdpc As New CDP_CONTACT_HDR(Session("ConnString"))
                    If cdpc.LoadByPrimaryKey(CDPContactID) Then
                        ReturnString = cdpc.s_CONT_FML
                    End If
                Else
                    ReturnString = ""
                End If
            Catch ex As Exception
                ReturnString = ""
            End Try
            HttpContext.Current.Session(SessionKey) = ReturnString
        Else
            ReturnString = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return ReturnString

    End Function

#End Region

    Private Function GetOneChangeValue(ByVal dv As DataView, ByVal ControlName As String) As String
        Dim StrReturn As String
        Dim DBVal As String
        Dim FormVal As String
        dv.RowFilter = "ControlID LIKE '%" & ControlName & "%'"
        Dim dt As DataTable = dv.ToTable
        If dt.Rows.Count > 0 Then
            DBVal = dt.Rows(0)("DBValue")
            FormVal = dt.Rows(0)("FormValue")
            If DBVal <> FormVal Then
                Return FormVal
            Else
                Return "-1"
            End If
        Else
            Return "-1"
        End If
    End Function

    'quick fix for problem with semicolon replacement code:
    Private Function AppendCommentFix(ByVal ThisJobNumber As Integer, ByVal ThisJobComponentNumber As Integer) As String
        If ThisJobNumber > 0 And ThisJobComponentNumber > 0 Then
            Dim sb As New StringBuilder
            With sb
                .Append("UPDATE JOB_COMPONENT SET ")
                .Append("JOB_COMP_DESC=REPLACE(SUBSTRING(JOB_COMP_DESC,1, DATALENGTH(JOB_COMP_DESC)),'#semicolon#',';'), ")
                .Append("JOB_CL_PO_NBR=REPLACE(SUBSTRING(JOB_CL_PO_NBR,1, DATALENGTH(JOB_CL_PO_NBR)),'#semicolon#',';'), ")
                .Append("JOB_AD_SIZE=REPLACE(SUBSTRING(JOB_AD_SIZE,1, DATALENGTH(JOB_AD_SIZE)),'#semicolon#',';'), ")
                .Append("JOB_DEL_INSTRUCT=REPLACE(SUBSTRING(JOB_DEL_INSTRUCT,1, DATALENGTH(JOB_DEL_INSTRUCT)),'#semicolon#',';'), ")
                .Append("CREATIVE_INSTR=REPLACE(SUBSTRING(CREATIVE_INSTR,1, DATALENGTH(CREATIVE_INSTR)),'#semicolon#',';'), ")
                .Append("JOB_COMP_COMMENTS=REPLACE(SUBSTRING(JOB_COMP_COMMENTS,1, DATALENGTH(JOB_COMP_COMMENTS)),'#semicolon#',';'), ")
                .Append("JOB_LAYOUT_SPC_EXP=REPLACE(SUBSTRING(JOB_LAYOUT_SPC_EXP,1, DATALENGTH(JOB_LAYOUT_SPC_EXP)),'#semicolon#',';') ")
                .Append("WHERE (JOB_NUMBER = ")
                .Append(ThisJobNumber)
                .Append(") AND (JOB_COMPONENT_NBR = ")
                .Append(ThisJobComponentNumber)
                .Append(");")
                .Append("UPDATE JOB_LOG SET ")
                .Append("JOB_COMMENTS=REPLACE(SUBSTRING(JOB_COMMENTS,1, DATALENGTH(JOB_COMMENTS)),'#semicolon#',';')")
                .Append(", JOB_DESC=REPLACE(SUBSTRING(JOB_DESC,1, DATALENGTH(JOB_DESC)),'#semicolon#',';') ")
                .Append(", JOB_CLI_REF=REPLACE(SUBSTRING(JOB_CLI_REF,1, DATALENGTH(JOB_CLI_REF)),'#semicolon#',';') ")
                .Append(", JOB_BILL_COMMENT=REPLACE(SUBSTRING(JOB_BILL_COMMENT,1, DATALENGTH(JOB_BILL_COMMENT)),'#semicolon#',';') ")
                .Append("WHERE (JOB_NUMBER = ")
                .Append(ThisJobNumber)
                .Append(")")
            End With
            Return sb.ToString
        Else
            Return ""
        End If
    End Function

    ' '' ''batch tooltip:
    '' ''Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)
    '' ''    'Me.UpdateToolTip(args.Value, args.UpdatePanel)
    '' ''End Sub

    '' ''Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
    '' ''    'Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Batch_Tooltip.ascx")
    '' ''    'panel.ContentTemplateContainer.Controls.Add(ctrl)

    '' ''    'Dim t As BillingApproval_Batch_Tooltip = DirectCast(ctrl, BillingApproval_Batch_Tooltip)
    '' ''    'With t
    '' ''    '    .BatchID = ArguementValue
    '' ''    'End With
    '' ''End Sub

    Private Sub SetTooltipToLabel(ByVal parent As System.Web.UI.Control)

        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Dim str As String = String.Empty

            Try

                For Each ctrl As System.Web.UI.Control In parent.Controls

                    Select Case ctrl.GetType.ToString()
                        Case "System.Web.UI.WebControls.HyperLink"

                            Dim hl As System.Web.UI.WebControls.HyperLink = CType(ctrl, HyperLink)

                            'If hl.ID.IndexOf("JOB_LOG.JOB_NUMBER") > -1 Then

                            '    hl.Attributes.Add("onclick", "OpenRadWindow('','JobTemplate_Search.aspx?f=1&l=1&j=" & Me.JobNumber.ToString() & "&jc=" & Me.JobComponentNbr.ToString() & "', 0, 0, false);return false;")
                            '    hl.CssClass = Nothing

                            'End If

                            'If hl.ID.IndexOf("JOB_COMPONENT.JOB_COMPONENT_NBR") > -1 Then

                            '    hl.Attributes.Add("onclick", "OpenRadWindow('','JobTemplate_Search.aspx?f=1&l=2&j=" & Me.JobNumber.ToString() & "&jc=" & Me.JobComponentNbr.ToString() & "', 0, 0, false);return false;")
                            '    hl.CssClass = Nothing

                            'End If
                    End Select

                    If ctrl.Controls.Count > 0 Then

                        SetTooltipToLabel(ctrl)

                    End If

                    str = String.Empty

                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadToolbarJobTemplateTop_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarJobTemplateTop.ButtonClick
        Me.MainToolbarsAction(e.Item.Value, False)
    End Sub

    Private Sub SendSilentEmail(ByVal EmailGroupCode As String, ByVal AlertTypeId As Integer, ByVal AlertCategoryId As Integer, ByVal AlertSubject As String,
                                ByVal AlertBody As String, Optional ByVal RedirectJavascript As String = "")
        Try
            Dim Employee As New cEmployee(CStr(Session("ConnString")))
            Dim EmailFlag As Integer
            Dim dr As SqlDataReader = GetEmailAddressFromGroup(EmailGroupCode)

            Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
            Dim AlertID As Integer
            AlertID = oAlert.AddAlerts(AlertTypeId, AlertCategoryId, AlertSubject, AlertBody, Now, "", Me.Client, Me.Division, Me.Product, "",
            JobNumber, JobComponentNbr, Session("EmpCode"), "JC", Session("UserCode"))

            If Not dr Is Nothing Then
                If dr.HasRows = True Then

                    Dim wsEmail As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

                    Dim EmpList As New System.Text.StringBuilder

                    Do While dr.Read()
                        Dim IsSelf As Boolean = False
                        If IsDBNull(dr(1)) = False Then
                            If dr(1).ToString().Trim() = HttpContext.Current.Session("ConnString") Then
                                IsSelf = True
                            End If
                            EmailFlag = Employee.GetAlertEmailFlag(dr.GetString(0))
                            If EmailFlag = 1 And IsSelf = False Then
                                With EmpList
                                    .Append(dr.GetString(0))
                                    .Append(",")
                                End With
                            ElseIf EmailFlag = 2 Then
                                oAlert.AddAlertRecipient(AlertID, dr.GetString(0), dr.GetString(1))
                            ElseIf EmailFlag = 3 Then
                                If IsSelf = False Then
                                    With EmpList
                                        .Append(dr.GetString(0))
                                        .Append(",")
                                    End With
                                End If
                                oAlert.AddAlertRecipient(AlertID, dr.GetString(0), dr.GetString(1))
                            End If
                        End If
                    Loop


                    Dim dtEmailList As New DataTable
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim StrEmps As String = EmpList.ToString()
                    StrEmps = MiscFN.CleanStringForSplit(StrEmps, ",")
                    dtEmailList = oTrafficSchedule.NotifyGetEmailEmployees(StrEmps)

                    If dtEmailList.Rows.Count > 0 Then
                        Dim SendToList As New System.Text.StringBuilder
                        Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                        For i As Integer = 0 To dtEmailList.Rows.Count - 1
                            With SendToList
                                If dtEmailList.Rows(i)("EMP_CODE").ToString().Trim() <> HttpContext.Current.Session("EmpCode").ToString().Trim() Then
                                    .Append(dtEmailList.Rows(i)("MAILBEE_TITLE").ToString())
                                    .Append(",")
                                End If
                            End With
                        Next
                        Dim s As String = SendToList.ToString()
                        s = MiscFN.CleanStringForSplit(s, ",", False, True, True, False, True)
                        bool = ws.SendEmail("", s, AlertSubject, AlertBody, , , True, )
                        If bool = False Then
                            Me.ShowMessage(ws.getErrMsg)
                        End If
                    End If

                End If
            End If

            Me.RefreshAlertWindows(False, True, False)

            'If RedirectJavascript.Trim() <> "" Then
            '    PageLoadJS(RedirectJavascript.Trim())
            'End If
        Catch ex As Exception
            Me.ShowMessage("Error in PopEmailUpdate conditional else case: " & ex.Message.ToString())
        End Try
    End Sub

End Class


