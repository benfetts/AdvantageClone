'This page is super old; still had wiring from VS2003.
'Created a fresh page and copy/paste over code/form so that VS wires it up correctly
'That's why source control shows this as a new file

Imports Webvantage.wvTimeSheet
Imports eWorld.UI.CollapsablePanel
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class JobTemplate_New
    Inherits Webvantage.BaseChildPage

#Region " Variables "

    Private ShowOffice As Boolean = False
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private JobVerHdrID As Integer = 0

    Private ProjectSheduleRequired = False
    Private DefaultStatusCode As String = ""

    Private _JobNumber As Integer = 0
    Private oSQL As SqlHelper
    Private rebind As Boolean = True

#End Region


    Public JavascriptArrayBudget As String = ""

#Region " Page Events "

    Private Sub JobTemplate_New_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.txtJobDesc.Attributes.Add("onKeyup", "copytext()")

        If IsNumeric(Request.QueryString("EstNum")) Then
            EstNum = CInt(Request.QueryString("EstNum"))
        End If

        If IsNumeric(Request.QueryString("EstComp")) Then
            EstComp = CInt(Request.QueryString("EstComp"))
        End If

        If Request.QueryString("from") = "estimate" Then
            Me.getEstimateDefaults()
        End If

        If Request.QueryString("from") = "jobrequest" Then
            If IsNumeric(Request.QueryString("JobVerHdrID")) Then
                JobVerHdrID = CInt(Request.QueryString("JobVerHdrID"))
            End If
            Me.LoadJobRequestDefaults()
        End If

        If Request.QueryString("from") = "search" Then

            If Request.QueryString("client") <> "" Then
                Me.txtClient.Text = Request.QueryString("client")
            End If
            If Request.QueryString("division") <> "" Then
                Me.txtDivision.Text = Request.QueryString("division")
            End If
            If Request.QueryString("product") <> "" Then
                Me.txtProduct.Text = Request.QueryString("product")
            End If
            If Request.QueryString("salesclass") <> "" Then
                Me.txtSalesClass.Text = Request.QueryString("salesclass")
            End If
            If Request.QueryString("ae") <> "" Then
                Me.txtAE.Text = Request.QueryString("ae")
            End If
            If Request.QueryString("campcode") <> "" Then
                Me.txtCampaign.Text = Request.QueryString("campcode")
            End If
            If Request.QueryString("campid") <> "" Then
                Me.hfCampaignID.Value = Request.QueryString("campid")
            End If

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me._JobNumber = qs.JobNumber
        If qs.EstimateNumber > 0 Then Me.EstNum = qs.EstimateNumber
        If qs.EstimateComponentNumber > 0 Then Me.EstComp = qs.EstimateComponentNumber
        If qs.ClientCode <> "" Then Me.txtClient.Text = qs.ClientCode
        If qs.DivisionCode <> "" Then Me.txtDivision.Text = qs.DivisionCode
        If qs.ProductCode <> "" Then Me.txtProduct.Text = qs.ProductCode
        If qs.SalesClassCode <> "" Then Me.txtSalesClass.Text = qs.SalesClassCode
        If qs.AccountExecutiveCode <> "" Then Me.txtAE.Text = qs.AccountExecutiveCode
        If qs.CampaignCode <> "" Then Me.txtCampaign.Text = qs.CampaignCode
        If qs.CampaignIdentifier > 0 Then Me.hfCampaignID.Value = qs.CampaignIdentifier

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Me._JobNumber > 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim j As New AdvantageFramework.Database.Entities.Job
                    j = Nothing

                    j = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me._JobNumber)

                    If Not j Is Nothing Then

                        Me.txtClient.Text = j.ClientCode
                        Me.txtDivision.Text = j.DivisionCode
                        Me.txtProduct.Text = j.ProductCode
                        Me.txtSalesClass.Text = j.SalesClassCode

                    End If

                End Using

            End If

        End If

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'If Me.TxtJobSource.Text <> "" Then
        '    loadjobdefaults()
        'End If
        Dim str As String = Me.btnComps.ClientID
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.btnCopyJob.Enabled = False
            'Me.RadComboBoxJobTemplate.Focus()
            Me.SetProjectScheduleRequirement()

            If MiscFN.GetOneValue("SELECT ISNULL(EDIT_OFFICE,0) FROM AGENCY WITH(NOLOCK);") = "1" Then

                Me.ShowOffice = True
                'Me.TxtOffice.Focus()

            Else

                Me.ShowOffice = False
                'Me.txtClient.Focus()

            End If

            SetLookUps()
            BindDropTemplates()

            For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.CopyOptions))

                CheckBoxListCopyOptions.Items.Add(New System.Web.UI.WebControls.ListItem(EnumObject.Description, EnumObject.Code))

            Next

            '734-2-1093 - Marriott Digital - Copy Job Default Options Checked 'On'
            CheckBoxListCopyOptions.Items.FindByText("Include Task Employee(s)").Selected = True
            CheckBoxListCopyOptions.Items.FindByText("Include Task Comment").Selected = True
            Me.cbCopyProjectSchedule.Checked = True

            If Me.ProjectSheduleRequired = True Then

                Me.cbCopyProjectSchedule.Enabled = False

                Me.CheckBoxCreateSchedule.Checked = True
                Me.CheckBoxCreateSchedule.Enabled = False

                Me.TextBoxTrafficScheduleStatus.CssClass = "RequiredInput"
                Me.txtStatusCopy.CssClass = "RequiredInput"



            End If

            SetCopyProjectScheduleOptions()

            'Me.DivCopyJobProjectScheduleDate.Visible = Me.cbCopyProjectSchedule.Checked
            'Me.DivCopyJobProjectScheduleStatus.Visible = Me.cbCopyProjectSchedule.Checked
            'Me.DivCopyTrafficManager.Visible = Me.cbCopyProjectSchedule.Checked

            'Me.CollapsablePanelHeader.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked
            'Me.CollapsablePanel1.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked

            Me.GetProjectScheduleDefaults()

            If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

                CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

            End If

            Me.LoadBoards()

        Else

            Select Case Me.EventTarget
                Case "CheckRequirements"

                    If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

                        CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

                    End If
                    'MiscFN.SetFocus(Me.txtJobDesc)

            End Select

        End If

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridJobCopy)

        CheckUserRights()

    End Sub
    Private Sub JobTemplate_New_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        'Me.DivSchedule.Visible = Me.CheckBoxCreateSchedule.Checked
        Me.TextBoxTrafficScheduleStatus.Enabled = Me.CheckBoxCreateSchedule.Checked
        Me.TextBoxTrafficManager.Enabled = Me.CheckBoxCreateSchedule.Checked

        Me.HyperLinkStatus.Visible = Me.CheckBoxCreateSchedule.Checked
        Me.LabelStatus.Visible = Not Me.CheckBoxCreateSchedule.Checked
        Me.HyperLinkTrafficManager.Visible = Me.CheckBoxCreateSchedule.Checked
        Me.LabelManager.Visible = Not Me.CheckBoxCreateSchedule.Checked

        Dim IsCampaignRequired As Boolean = False
        Dim IsJobTypeRequired As Boolean = False
        Dim IsManagerRequired As Boolean = False

        Dim val As String = IsRequiredWebMethod(Me.RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text)

        Dim ar() As String

        ar = val.Split("|")

        IsCampaignRequired = ar(0).ToString() = "true"
        IsJobTypeRequired = ar(1).ToString() = "true"
        IsManagerRequired = ar(2).ToString() = "true"

        If IsManagerRequired = True Then

            If String.IsNullOrWhiteSpace(Me.TextBoxCopyTrafficManager.Text) = True Then

                Me.TextBoxCopyTrafficManager.Text = Me.TextBoxTrafficManager.Text

            End If

        End If

    End Sub

#End Region

#Region " Controls "
    Protected Sub butCreateJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCreateJob.Click

        Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
        Dim est As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim s As New cSchedule()
        Dim camp As New cCampaign(Session("ConnString"))

        Dim cmpid As Integer

        Dim SQL_STRING As String

        Dim JobNo As Integer = 0
        Dim ReturnMessage As String = ""
        Dim TemplateEnabled As Boolean = False
        Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("enableButton();")

        Try

            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            If myVal.ValidateCDP(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, True) = False Then

                Me.ShowMessage("Invalid Client, Division, Product!")
                Exit Sub

            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then

                Me.ShowMessage("Access to this Client,Division,Product Is denied.")
                Exit Sub

            End If
            If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

                If CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, True) = False Then

                    Exit Sub

                End If

            End If
            If Request.QueryString("from") = "estimate" Then

                If est.CheckJobEstimateCompNumber(Me.EstNum, Me.EstComp) = True Then

                    Me.ShowMessage("This Estimate has already been assigned to a Job.")
                    Exit Sub

                End If

            End If

            If Me.txtCampaign.Text <> "" Then

                Dim cmptype As Integer
                cmpid = oJob.GetCampaignIdentifier(Me.txtCampaign.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)

                Dim drcmp As SqlDataReader = camp.GetCampaignByCmpIdentifier(cmpid)

                If drcmp.HasRows = True Then

                    drcmp.Read()
                    cmptype = drcmp("CMP_TYPE")
                    drcmp.Close()

                End If
                If cmpid = 0 Or cmptype = 1 Then

                    Me.ShowMessage("Invalid Campaign.")
                    Exit Sub

                Else

                    Me.hfCampaignID.Value = cmpid

                End If

            End If

            If Me.txtCampaign.Text = "" Then

                Me.hfCampaignID.Value = "0"

            End If

            Dim ThisOfficeCode As String = ""
            If Me.DivOffice.Visible = True Then

                ThisOfficeCode = Me.TxtOffice.Text.Trim()

            End If

            Me.SetProjectScheduleRequirement()

            If String.IsNullOrWhiteSpace(Me.TextBoxJobType.Text) = False Then

                If myVal.ValidateJobType(Me.TextBoxJobType.Text) = False Then

                    Me.ShowMessage("Invalid Job Type Code.")
                    Me.TextBoxJobType.Focus()
                    Exit Sub

                End If

            End If

            If Me.CheckBoxCreateSchedule.Checked = True Then

                If Me.TextBoxTrafficScheduleStatus.Text.Trim() = "" Then

                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Me.TextBoxTrafficScheduleStatus.Focus()
                    Exit Sub

                End If

                Dim v As New cValidations(Session("ConnString"))
                If Me.TextBoxTrafficScheduleStatus.Text.Trim() <> "" Then

                    If v.ValidateTrafficStatus(Me.TextBoxTrafficScheduleStatus.Text) = False Then

                        Me.ShowMessage("Invalid Project Schedule Status.")
                        Me.TextBoxTrafficScheduleStatus.Focus()
                        Exit Sub

                    End If

                End If


                If Me.TextBoxTrafficManager.Text.Trim() <> "" Then

                    If v.ValidateEmpCodetd(Me.TextBoxTrafficManager.Text.Trim()) = False Then

                        Me.ShowMessage("Invalid " & s.GetManagerLabel & " code.")
                        Exit Sub

                    End If

                End If

            End If

            JobNo = oJob.CreateNewJob(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtSalesClass.Text.Trim, CStr(Session("UserCode")), Me.txtJobDesc.Text.Trim,
                                      Me.txtAE.Text.Trim, Me.txtCompDesc.Text.Trim, True, ReturnMessage, Me.RadComboBoxJobTemplate.SelectedValue, ThisOfficeCode, Me.hfCampaignID.Value,
                                      Me.txtCampaign.Text, Me.TextBoxJobType.Text.Trim)

            TemplateEnabled = True

            If JobNo > 0 Then

                est.UpdateJobEstimate(JobNo, 1, EstNum, EstComp)

                If JobVerHdrID <> 0 Then
                    SQL_STRING = "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET JOB_NUMBER = '" & JobNo & "',  JOB_COMPONENT_NBR = 1, JOB_VER_SEQ_NBR = 1 WHERE JOB_VER_HDR_ID = " & Me.JobVerHdrID.ToString() & ";"

                    Try
                        oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                    Catch
                        'Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:SaveTemplate", Err.Description)
                    Finally
                    End Try

                    Dim Alerts As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing
                    Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
                    Dim JobCompDocument As AdvantageFramework.Database.Entities.JobComponentDocument = Nothing
                    Dim DocumentPrefix As String = ""
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByJobVersionID(DbContext, Me.JobVerHdrID).ToList
                        If Alerts IsNot Nothing Then
                            For Each ar In Alerts
                                ar.JobNumber = JobNo
                                ar.JobComponentNumber = 1
                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, ar)

                                If ar.AlertAttachments.Count > 0 Then
                                    For Each AlertAttachment In ar.AlertAttachments
                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)
                                        If Document IsNot Nothing Then
                                            JobCompDocument = New AdvantageFramework.Database.Entities.JobComponentDocument
                                            JobCompDocument.DbContext = DbContext
                                            JobCompDocument.DocumentID = Document.ID
                                            JobCompDocument.JobComponentNumber = 1
                                            JobCompDocument.JobNumber = JobNo
                                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                                AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobCompDocument)
                                            End Using
                                        End If
                                    Next
                                End If
                            Next

                        End If

                        Dim jv As New JobVersion(Session("ConnString"))
                        jv.UpdateJobTemplatePerJVMapping(Me.JobVerHdrID, "job")

                        Me.RefreshJobRequestObjects("DesktopMyJobRequests")
                        Me.RefreshJobRequestObjects("DesktopJobRequests")

                    End Using

                End If

                If Me.CheckBoxCreateSchedule.Checked = True Then

                    Dim str As String = ""

                    If s.QuickAddScheduleHeader(JobNo, 1, Me.TextBoxTrafficScheduleStatus.Text, Me.TextBoxTrafficManager.Text, _Session.UserCode, str) = False Then

                        If str.Trim <> "" Then Me.ShowMessage(str)

                    End If

                End If

                If Me.RadListBoxBoards.Visible = True AndAlso
                    Me.RadListBoxBoards.CheckedItems.Count > 0 Then

                    Dim AgileController As New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)
                    Dim ErrorMessages As Generic.List(Of String)
                    Dim ErrorMessage As String = String.Empty

                    If AgileController IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            For Each Item As RadListBoxItem In Me.RadListBoxBoards.CheckedItems

                                If AgileController.AddJobToBoard(DbContext, Item.Value, JobNo, 1, ErrorMessage) = False Then

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        ErrorMessages.Add(ErrorMessage)
                                        ErrorMessage = String.Empty

                                    End If

                                End If

                            Next

                        End Using

                    End If

                End If

                'If Request.QueryString("from") = "jobrequest" Then

                '    Me.RefreshCaller("JobRequest_Search.aspx")
                '    Me.RefreshCaller("jobVerTmplt.aspx?JobNum=" & JobNo & "&JobCompNum=1&JobVerHdrID=" & JobVerHdrID.ToString(), False, True, True)
                '    Me.RefreshCaller("JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNo & "&JobCompNum=1&NewJob=1&NewComp=0", True, True, True)

                'Else

                '    If Me.CurrentQuerystring.IsJobDashboard = True Then
                '        MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=Edit&JobNum=" & JobNo & "&JobCompNum=1&NewJob=1&NewComp=0", True)
                '    Else
                '        Me.CloseThisWindowAndRefreshCaller("Content.aspx?PageMode=Edit&JobNum=" & JobNo & "&JobCompNum=1&NewJob=1&NewComp=0", True, True)
                '    End If

                'End If

                Dim qs As New AdvantageFramework.Web.QueryString
                qs.Page = "Content.aspx"
                qs.JobNumber = JobNo
                qs.JobComponentNumber = 1
                qs.Add("NewJob", "1")

                'If Request.QueryString("from") = "estimate" Then

                '    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                'Else

                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate

                'End If

                Me.CloseThisWindowAndRefreshCaller(qs.ToString(True), True, True)

            Else

                Me.ShowMessage(ReturnMessage)

            End If

        Catch

            Me.ShowMessage(Err.Description)

        End Try
    End Sub
    Protected Sub butCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butCancel.Click
        Me.CloseThisWindow()
    End Sub
    Protected Sub RadComboBoxJobTemplate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadComboBoxJobTemplate.SelectedIndexChanged

        Dim value As String
        Dim JV As Job_Template = New Job_Template(Session("ConnString"))
        Dim defSC As String

        If Request.QueryString("from") <> "estimate" Then

            value = Me.RadComboBoxJobTemplate.SelectedValue
            defSC = JV.GetTmpltDefSC(value)
            Me.txtSalesClass.Text = defSC

        End If

        If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

            CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageFramework.ProjectManagement.LoadLabelsFromJobTemplate(DbContext, Me.RadComboBoxJobTemplate.SelectedItem.Value,
                                                                               Me.HlOffice.Text, Me.hlClient.Text, Me.hlDivision.Text, Me.hlProduct.Text,
                                                                               Me.hlAE.Text, Me.hlSalesClass.Text, Nothing, Me.HyperLinkJobType.Text)

                Me.HlOffice.Text &= ":"
                Me.hlClient.Text &= ":"
                Me.hlDivision.Text &= ":"
                Me.hlProduct.Text &= ":"
                Me.hlAE.Text &= ":"
                Me.hlSalesClass.Text &= ":"
                Me.HyperLinkJobType.Text &= ":"

                Me.HlClientSource.Text = Me.hlClient.Text
                Me.HlDivisionSource.Text = Me.hlDivision.Text
                Me.HlProductSource.Text = Me.hlProduct.Text
                Me.LabelSalesClassSource.Text = Me.hlSalesClass.Text
                Me.HlJobTypeSource.Text = Me.HyperLinkJobType.Text

            End Using

        End If

    End Sub
    Protected Sub RadGridJobCopy_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobCopy.NeedDataSource
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.TxtJobSource.Text <> "" Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TxtJobSource.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TxtJobSource.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Exit Sub
                    Else
                        Me.RadGridJobCopy.DataSource = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
                    End If
                End Using
            Else
                Me.RadGridJobCopy.DataSource = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
            End If

            Me.SetGridSort("Job")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridJobCopy_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridJobCopy.ItemCreated
        Try
            If e.Item.ItemType = GridItemType.Header Then
                Dim item As GridHeaderItem = e.Item
                Dim checkbox As CheckBox = item("ColumnClientSelect").Controls(0)
                'checkbox.AutoPostBack = True
                'AddHandler checkbox.CheckedChanged, New EventHandler(AddressOf SelectCheckbox_CheckChanged)

                'Dim textbox As TextBox = item("colTextBoxDuplicate").Controls(0)
                'textbox.AutoPostBack = True
                'AddHandler textbox.TextChanged, New EventHandler(AddressOf OnTextChanged)
            End If
            If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
                Dim item As GridDataItem = e.Item
                Dim checkbox As CheckBox = item("ColumnClientSelect").Controls(0)
                'checkbox.AutoPostBack = True
                'AddHandler checkbox.CheckedChanged, New EventHandler(AddressOf SelectCheckbox_CheckChangedItem)

                'Dim textbox As TextBox = item("colTextBoxDuplicate").Controls(0)
                'textbox.AutoPostBack = True
                'AddHandler textbox.TextChanged, New EventHandler(AddressOf OnTextChanged)
            End If
            If e.Item.ItemType = GridItemType.FilteringItem Then
                Dim item As GridFilteringItem = e.Item
                item("Component").HorizontalAlign = HorizontalAlign.Right
                item("CompBudget").HorizontalAlign = HorizontalAlign.Right
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub SelectCheckbox_CheckChanged(sender As Object, e As EventArgs)
        Try
            Dim chkbox As CheckBox
            Dim textbox As TextBox
            Dim rtb As RadNumericTextBox
            Dim textbox2 As TextBox
            Dim count As Integer = 0
            Dim compbudget As Decimal = 0
            Dim compbudgettotal As Decimal = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items
                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chkbox.Checked = True Then
                    textbox = gridDataItem.FindControl("TextBoxDuplicate")
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")

                    If textbox.Text <> "" Then
                        count = textbox.Text
                    End If

                    If count > 0 Then
                        compbudget = CDec(gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")) * count
                        compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM") * count
                    Else
                        compbudget = gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
                        compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
                    End If

                    If rtb.Text = "0.00" Then
                        rtb.Text = compbudget
                    End If

                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.00
                End If

            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopy.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), TextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)


        Catch ex As Exception

        End Try
    End Sub
    Protected Sub SelectCheckbox_CheckChangedItem(sender As Object, e As EventArgs)
        Try
            Dim chkbox As CheckBox
            Dim textbox As TextBox
            Dim textbox2 As TextBox
            Dim rtb As RadNumericTextBox
            Dim count As Integer = 0
            Dim row As Integer = 0
            Dim compbudget As Decimal = 0
            Dim compbudgettotal As Decimal = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items
                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chkbox.Checked = True Then
                    textbox = gridDataItem.FindControl("TextBoxDuplicate")
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")

                    If textbox.Text <> "" Then
                        count = textbox.Text
                    End If

                    If count > 0 Then
                        compbudget = CDec(gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")) * count
                        compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM") * count
                    Else
                        compbudget = gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
                        compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
                    End If

                    If rtb.Text = "0.00" Then
                        rtb.Text = compbudget
                    End If

                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.000

                End If

                JavascriptArrayBudget &= "try { JavascriptArrayBudget[" & row & "] = document.getElementById('" & rtb.ClientID & "').value; }catch(err){}" & Environment.NewLine
                row += 1
            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopy.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), TextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)

        Catch ex As Exception

        End Try
    End Sub

    Dim Compbudget As Decimal = 0
    Dim SelectedCompBudget As Decimal = 0
    Dim sumBudgetTotal As Decimal = CType(0.0, Decimal)
    Private Sub RadGridJobCopy_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridJobCopy.ItemDataBound
        Try
            Dim tb As TextBox
            Dim rtb As RadNumericTextBox
            Dim tb2 As TextBox
            Dim cb As CheckBox
            Dim count As Integer = 1
            Dim checked As Integer = 0
            Dim JavascriptFooterFunction As String = ""

            If e.Item.ItemType = GridItemType.Header Then
                sumBudgetTotal = 0.0
            End If

            If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then

                Compbudget += CDec(e.Item.DataItem("JOB_COMP_BUDGET_AM"))
                sumBudgetTotal += CDec(e.Item.DataItem("SELECTED"))

                tb = e.Item.FindControl("TextBoxDuplicate")
                rtb = e.Item.FindControl("TextBoxSelectedBudget")

                Dim gr As GridDataItem = e.Item
                cb = CType(gr("ColumnClientSelect").Controls(0), CheckBox)

                If tb.Text <> "" Then
                    tb.Text = 1
                End If

                If cb.Checked = True Then
                    checked = 1
                End If

                JavascriptFooterFunction = "SumItUpBudget();"

                tb.Attributes.Add("onkeyup", "MultiplyDup('" & tb.ClientID & "','" & e.Item.DataItem("JOB_COMP_BUDGET_AM") & "','" & rtb.ClientID & "','" & cb.ClientID & "');" & JavascriptFooterFunction)
                rtb.Attributes.Add("onkeyup", "calculateBudget();")

            End If

            If e.Item.ItemType = GridItemType.Footer Then

                Dim footeritem As GridFooterItem = e.Item
                footeritem("CompBudget").Text = String.Format("{0:#,##0.00}", Compbudget)
                footeritem("Description").Text = "Budget Total:"

                'CType(footeritem.FindControl("TextBoxSumSelectedBudget"), TextBox).Text = String.Format("{0:#,##0.00}", sumBudgetTotal)

                Compbudget = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadGridJobCopy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridJobCopy.SelectedIndexChanged
    '    Try
    '        Dim chkbox As CheckBox
    '        Dim textbox As TextBox
    '        Dim textbox2 As TextBox
    '        Dim count As Integer = 0
    '        Dim compbudget As Decimal = 0
    '        Dim compbudgettotal As Decimal = 0
    '        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items
    '            chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
    '            If chkbox.Checked = True Then
    '                textbox = gridDataItem.FindControl("TextBoxDuplicate")
    '                textbox2 = gridDataItem.FindControl("TextBoxSelectedBudget")

    '                If textbox.Text <> "" Then
    '                    count = textbox.Text
    '                End If

    '                If count > 0 Then
    '                    compbudget = CDec(gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")) * count
    '                    compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM") * count
    '                Else
    '                    compbudget = gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
    '                    compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
    '                End If

    '                textbox2.Text = compbudget
    '                count = 0
    '            Else
    '                textbox2 = gridDataItem.FindControl("TextBoxSelectedBudget")
    '                textbox2.Text = 0.00
    '            End If

    '        Next

    '        Dim gridfooteritem As GridFooterItem = RadGridJobCopy.MasterTableView.GetItems(GridItemType.Footer)(0)
    '        gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub OnTextChanged(sender As Object, e As EventArgs)
    '    Try
    '        Dim chkbox As CheckBox
    '        Dim textbox As TextBox
    '        Dim count As Integer = 0
    '        Dim compbudget As Decimal = 0
    '        Dim compbudgettotal As Decimal = 0
    '        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items
    '            chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
    '            If chkbox.Checked = True Then
    '                textbox = gridDataItem.FindControl("TextBoxDuplicate")

    '                If textbox.Text <> "" Then
    '                    count = textbox.Text
    '                End If

    '                If count > 0 Then
    '                    compbudget = CDec(gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")) * count
    '                    compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM") * count
    '                Else
    '                    compbudget = gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
    '                    compbudgettotal += gridDataItem.GetDataKeyValue("JOB_COMP_BUDGET_AM")
    '                End If

    '                gridDataItem("colCompBudgetSelected").Text = compbudget
    '                count = 0
    '            Else
    '                gridDataItem("colCompBudgetSelected").Text = 0.00
    '            End If

    '        Next

    '        Dim gridfooteritem As GridFooterItem = RadGridJobCopy.MasterTableView.GetItems(GridItemType.Footer)(0)
    '        gridfooteritem("colCompBudgetSelected").Text = compbudgettotal


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub GetCopyOptions(ByRef IncludeStartDate As Boolean, ByRef IncludeDueDate As Boolean, ByRef IncludeTaskEmployees As Boolean, ByRef IncludeTaskComment As Boolean, ByRef IncludeDueDateComment As Boolean, ByRef ScheduleTemplate As Boolean, ByRef IncludeTaskStatus As Boolean)

        For Each ListItem In Me.CheckBoxListCopyOptions.Items.OfType(Of System.Web.UI.WebControls.ListItem)()

            Select Case ListItem.Value

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeStartDate.ToString

                    IncludeStartDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDate.ToString

                    IncludeDueDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskEmployees.ToString

                    IncludeTaskEmployees = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskComment.ToString

                    IncludeTaskComment = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDateComment.ToString

                    IncludeDueDateComment = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskStatus.ToString

                    IncludeTaskStatus = ListItem.Selected

                    'Case AdvantageFramework.ProjectSchedule.CopyOptions.ScheduleTemplate.ToString

                    '    ScheduleTemplate = ListItem.Selected

            End Select

        Next

    End Sub
    Protected Sub btnCopyJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyJob.Click

        Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
        Dim jt As Job_Template = New Job_Template(Session("ConnString"))
        Dim est As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim NewJobNumber As Integer
        Dim ReturnMessage As String
        Dim TemplateEnabled As Boolean = False
        Dim s As New cSchedule()
        Dim template As String = ""
        Dim SQL_STRING As String
        Dim IncludeStartDate As Boolean = False
        Dim IncludeDueDate As Boolean = False
        Dim IncludeTaskEmployees As Boolean = True
        Dim IncludeTaskComment As Boolean = True
        Dim IncludeDueDateComment As Boolean = False
        Dim ScheduleTemplate As Boolean = False
        Dim IncludeTaskStatus As Boolean = False
        Dim camp As New cCampaign(Session("ConnString"))
        Dim cmpid As Integer = 0

        Try
            'ST:
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            If myVal.ValidateCDP(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, True) = False Then
                Me.ShowMessage("Invalid Client, Division, Product!")
                Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                Me.ShowMessage("Invalid Client, Division, Product!")
                Exit Sub
            End If
            If Me.cbCopyProjectSchedule.Checked = True Then
                If myVal.ValidateTrafficStatus(Me.txtStatusCopy.Text) = False Then
                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Exit Sub
                End If
            End If
            If Request.QueryString("from") = "estimate" Then
                If est.CheckJobEstimateCompNumber(Me.EstNum, Me.EstComp) = True Then
                    Me.ShowMessage("This Estimate has already been assigned to a Job.")
                    Exit Sub
                End If
            End If

            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False
            Dim IsManagerRequired As Boolean = False

            Dim val As String = IsRequiredWebMethod(Me.RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text)

            Dim ar() As String

            ar = val.Split("|")

            IsCampaignRequired = ar(0).ToString() = "true"
            IsJobTypeRequired = ar(1).ToString() = "true"
            IsManagerRequired = ar(2).ToString() = "true"

            If IsJobTypeRequired Then

                If String.IsNullOrWhiteSpace(Me.TxtJobTypeSource.Text) = True Then

                    Me.TxtJobTypeSource.Text = Me.TextBoxJobType.Text

                End If
                If String.IsNullOrWhiteSpace(Me.TxtJobTypeSource.Text) = True Then

                    Me.ShowMessage("Job Type is required in copy section.")
                    Me.TxtJobTypeSource.Focus()
                    Exit Sub

                End If

            End If

            If Me.cbCopyProjectSchedule.Checked = True Then

                If Me.txtStatusCopy.Text.Trim() = "" Then

                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Me.TextBoxTrafficScheduleStatus.Focus()
                    Exit Sub

                End If

                Dim v As New cValidations(Session("ConnString"))
                If Me.txtStatusCopy.Text.Trim() <> "" Then

                    If v.ValidateTrafficStatus(Me.txtStatusCopy.Text) = False Then

                        Me.ShowMessage("Invalid Project Schedule Status.")
                        Me.txtStatusCopy.Focus()
                        Exit Sub

                    End If

                End If

                If IsManagerRequired = True Then
                    If Me.TextBoxCopyTrafficManager.Text.Trim() = "" Then
                        Me.ShowMessage(s.GetManagerLabel & " is required in copy section.")
                        Exit Sub
                    End If
                End If

                If Me.TextBoxTrafficManager.Text.Trim() <> "" Then

                    If v.ValidateEmpCodetd(Me.TextBoxTrafficManager.Text.Trim()) = False Then

                        Me.ShowMessage("Invalid " & s.GetManagerLabel & " code.")
                        Exit Sub

                    End If

                End If

            End If

            If Me.txtCampaign.Text <> "" Then
                Dim cmptype As Integer
                cmpid = oJob.GetCampaignIdentifier(Me.txtCampaign.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                Dim drcmp As SqlDataReader = camp.GetCampaignByCmpIdentifier(cmpid)
                If drcmp.HasRows = True Then
                    drcmp.Read()
                    cmptype = drcmp("CMP_TYPE")
                    drcmp.Close()
                End If
                If cmpid = 0 Or cmptype = 1 Then
                    Me.ShowMessage("Invalid Campaign.")
                    Exit Sub
                Else
                    Me.hfCampaignID.Value = cmpid
                End If

            End If

            If Me.txtCampaign.Text = "" Then
                Me.hfCampaignID.Value = "0"
            End If

            Dim chkbox As CheckBox
            Dim tb As TextBox
            Dim tbBudget As RadNumericTextBox
            Dim items As Boolean = False
            Dim itemsCount As Integer = 0
            Dim InvalidBudget As Boolean = False
            Dim cp
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items
                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chkbox.Checked = True Then
                    cp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    tb = gridDataItem.FindControl("TextBoxDuplicate")
                    tbBudget = gridDataItem.FindControl("TextBoxSelectedBudget")
                    If tb.Text <> "" AndAlso IsNumeric(tb.Text) = True Then
                        itemsCount += CInt(tb.Text)
                    Else
                        itemsCount += 1
                    End If
                    'If IsNumeric(tbBudget.Text) = False Then
                    '    InvalidBudget = True
                    'End If
                    items = True
                End If
            Next

            If items = False Then

                Me.ShowMessage("No Components Selected for Copy.")
                Exit Sub

            End If

            If itemsCount > 999 Then
                Me.ShowMessage("A job can have a maximum of 999 components.")
                Exit Sub
            End If

            If InvalidBudget = True Then
                Me.ShowMessage("Invalid Budget on selected Component.")
                Exit Sub
            End If


            If Me.cbCopyProjectSchedule.Checked = True Then

                If IsManagerRequired Then

                    If String.IsNullOrWhiteSpace(Me.TextBoxCopyTrafficManager.Text) = True Then

                        Me.TextBoxCopyTrafficManager.Text = Me.TextBoxTrafficManager.Text

                    End If
                    If String.IsNullOrWhiteSpace(Me.TextBoxCopyTrafficManager.Text) = True Then

                        Me.ShowMessage(s.GetManagerLabel & " is required in copy section.")
                        Me.TextBoxCopyTrafficManager.Focus()
                        Exit Sub

                    End If

                End If

                If Me.txtStatusCopy.Text.Trim() = "" Then

                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Me.txtStatusCopy.Focus()
                    Exit Sub

                End If

                Dim v As New cValidations(Session("ConnString"))
                If Me.txtStatusCopy.Text.Trim() <> "" Then

                    If v.ValidateTrafficStatus(Me.txtStatusCopy.Text) = False Then

                        Me.ShowMessage("Invalid Project Schedule Status.")
                        Me.txtStatusCopy.Focus()
                        Exit Sub

                    End If

                End If

                If Me.TextBoxCopyTrafficManager.Text.Trim() <> "" Then

                    If v.ValidateEmpCodetd(Me.TextBoxCopyTrafficManager.Text.Trim()) = False Then

                        Me.ShowMessage("Invalid " & s.GetManagerLabel & " code.")
                        Exit Sub

                    End If

                End If

            End If

            NewJobNumber = oJob.CreateNewJobCopy(Me.TxtJobSource.Text, Me.txtJobDesc.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, Me.txtSalesClass.Text, Me.txtAE.Text, True, Session("UserCode"), ReturnMessage, "", "", Me.hfCampaignID.Value, Me.txtCampaign.Text)
            TemplateEnabled = True

            Dim chk As CheckBox
            'Dim tb As TextBox
            Dim ComponentNumberToCopy As Integer = 0
            Dim NewComponentNumber As Integer = 0
            Dim SelectedBudget As Decimal = 0
            Dim save As Boolean = False
            Dim SelectedComponentDescription As String = ""
            Dim docID As Integer
            Dim privateflag As Integer = 0
            Dim count As Integer = 1
            Dim pssave As Integer = 0
            Dim ComponentCopy As Integer = 0
            Dim AgileController As New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)
            Dim ErrorMessages As Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty

            If NewJobNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        If Me.CheckBoxJobDocumentAssociations.Checked AndAlso IsNumeric(Me.TxtJobSource.Text) = True Then

                            Try
                                If Me.CheckBoxJobDocumentAssociations.Checked Then

                                    Dim newjob As New JobDocument(Session("ConnString"))
                                    Dim oldjob As New JobDocument(Session("ConnString"))
                                    Dim Document As New Document(Session("ConnString"))

                                    oldjob.Where.JOB_NUMBER.Value = Me.TxtJobSource.Text

                                    If oldjob.Query.Load() Then
                                        If oldjob.RowCount > 0 Then
                                            Do Until oldjob.EOF
                                                Document = New Document(Session("ConnString"))
                                                Document.Where.DOCUMENT_ID.Value = oldjob.DOCUMENT_ID
                                                If Document.Query.Load Then
                                                    If Document.s_PRIVATE_FLAG = "1" Then
                                                        privateflag = 1
                                                    End If
                                                    docID = newjob.Add(NewJobNumber, Document.FILENAME, Document.MIME_TYPE, Document.REPOSITORY_FILENAME, Document.FILE_SIZE, Document.USER_CODE, Document.DESCRIPTION, Document.KEYWORDS, privateflag, Document.DOCUMENT_TYPE_ID)
                                                End If
                                                oldjob.MoveNext()
                                            Loop
                                        End If
                                    End If

                                End If
                            Catch ex As Exception

                            End Try

                            'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                            '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            '        Dim document As AdvantageFramework.Database.Entities.Document
                            '        Dim newdocument As AdvantageFramework.Database.Entities.Document
                            '        Dim newjobdocument As AdvantageFramework.Database.Entities.JobDocument
                            '        Dim JobDocuments As Generic.List(Of AdvantageFramework.Database.Entities.JobDocument) = Nothing

                            '        Dim JobDocumentCount As Integer = AdvantageFramework.Database.Procedures.JobDocument.LoadByJobNumber(DataContext, Me.TxtJobSource.Text).Count

                            '        If JobDocumentCount > 0 Then

                            '            JobDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadByJobNumber(DataContext, Me.TxtJobSource.Text).ToList

                            '            For Each doc In JobDocuments

                            '                document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, doc.DocumentID)

                            '                newdocument = New AdvantageFramework.Database.Entities.Document

                            '                newdocument.FileName = document.FileName
                            '                newdocument.MIMEType = document.MIMEType
                            '                newdocument.FileSystemFileName = document.FileSystemFileName
                            '                newdocument.FileSize = document.FileSize
                            '                newdocument.UserCode = document.UserCode
                            '                newdocument.Description = document.Description
                            '                newdocument.Keywords = document.Keywords
                            '                newdocument.IsPrivate = document.IsPrivate
                            '                newdocument.DocumentTypeID = document.DocumentTypeID

                            '                AdvantageFramework.Database.Procedures.Document.Insert(DbContext, newdocument)

                            '                newjobdocument = New AdvantageFramework.Database.Entities.JobDocument
                            '                newjobdocument.DocumentID = newdocument.ID
                            '                newjobdocument.JobNumber = NewJobNumber

                            '                AdvantageFramework.Database.Procedures.JobDocument.Insert(DataContext, newjobdocument)

                            '            Next

                            '        End If


                            '        'Dim CopySQL As String = String.Format("INSERT INTO JOB_DOCUMENTS (DOCUMENT_ID, JOB_NUMBER) SELECT DOCUMENT_ID, {0} FROM JOB_DOCUMENTS WHERE JOB_NUMBER = {1};",
                            '        '                                  NewJobNumber, Me.TxtJobSource.Text)

                            '        'DataContext.ExecuteCommand(CopySQL)

                            '    End Using

                            'End Using

                        End If

                    Catch ex As Exception
                    End Try

                    'Add for comp 1
                    If Me.RadListBoxBoards.Visible = True AndAlso Me.RadListBoxBoards.CheckedItems.Count > 0 Then

                        If AgileController IsNot Nothing Then

                            For Each Item As RadListBoxItem In Me.RadListBoxBoards.CheckedItems

                                If AgileController.AddJobToBoard(DbContext, Item.Value, NewJobNumber, 1, ErrorMessage) = False Then

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        ErrorMessages.Add(ErrorMessage)
                                        ErrorMessage = String.Empty

                                    End If

                                End If

                            Next

                        End If

                    End If
                    If TemplateEnabled = True Then

                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopy.MasterTableView.Items

                            Dim ScheduleCreated As Boolean = False

                            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                            tb = gridDataItem.FindControl("TextBoxDuplicate")

                            If chk.Checked = True Then

                                Try

                                    ComponentNumberToCopy = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")

                                Catch ex As Exception
                                    ComponentNumberToCopy = 0
                                End Try
                                If ComponentNumberToCopy = 0 Then

                                    Try

                                        ComponentNumberToCopy = CInt(gridDataItem("Component").Text.Replace("&nbsp;", ""))

                                    Catch ex As Exception
                                        ComponentNumberToCopy = 0
                                    End Try

                                End If
                                Try

                                    SelectedComponentDescription = ""
                                    SelectedComponentDescription = DirectCast(gridDataItem.FindControl("TextBoxJobComponentDescription"), TextBox).Text
                                    'SelectedComponentDescription = gridDataItem("Description").Text.Replace("&nbsp;", "")

                                Catch ex As Exception
                                    SelectedComponentDescription = Me.txtCompDesc.Text
                                End Try
                                Try

                                    SelectedBudget = CDec(DirectCast(gridDataItem.FindControl("TextBoxSelectedBudget"), RadNumericTextBox).Text)

                                Catch ex As Exception
                                    SelectedBudget = 0
                                End Try
                                If ComponentNumberToCopy > 0 Then

                                    ComponentCopy += 1

                                End If
                                If Me.txtCompDesc.Text <> "" And ComponentCopy = 1 And Me.CheckBoxOverride.Checked = True Then

                                    SelectedComponentDescription = Me.txtCompDesc.Text

                                End If
                                If SelectedComponentDescription = "" Then

                                    SelectedComponentDescription = "Component Description"

                                End If

                                template = jt.GetTemplateCode(Me.TxtJobSource.Text, ComponentNumberToCopy)

                                If tb.Text <> "" Then

                                    count = tb.Text

                                Else

                                    count = 1

                                End If
                                For i As Integer = 0 To count - 1

                                    If Me.cbCopyProjectSchedule.Checked = True Then

                                        GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ScheduleTemplate, IncludeTaskStatus)
                                        NewComponentNumber = oJob.CreateNewJobComponentCopy(NewJobNumber, Me.TxtJobSource.Text, ComponentNumberToCopy, SelectedComponentDescription, IncludeStartDate, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                    Else

                                        NewComponentNumber = oJob.CreateNewJobComponentCopy(NewJobNumber, Me.TxtJobSource.Text, ComponentNumberToCopy, SelectedComponentDescription, True, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                    End If
                                    If NewComponentNumber > 0 Then

                                        est.UpdateJobEstimate(NewJobNumber, NewComponentNumber, EstNum, EstComp)

                                        If JobVerHdrID <> 0 Then

                                            SQL_STRING = "UPDATE JOB_VER_HDR With(ROWLOCK) Set JOB_NUMBER = '" & NewJobNumber & "',  JOB_COMPONENT_NBR = '" & NewComponentNumber & "', JOB_VER_SEQ_NBR = 1 WHERE JOB_VER_HDR_ID = " & Me.JobVerHdrID.ToString() & ";"

                                            Try
                                                oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                                            Catch
                                                'Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:SaveTemplate", Err.Description)
                                            Finally
                                            End Try

                                            Dim Alerts As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing
                                            Alerts = AdvantageFramework.Database.Procedures.Alert.LoadByJobVersionID(DbContext, Me.JobVerHdrID).ToList

                                            If Alerts IsNot Nothing Then

                                                For Each alert In Alerts

                                                    alert.JobNumber = NewJobNumber
                                                    alert.JobComponentNumber = NewComponentNumber
                                                    AdvantageFramework.Database.Procedures.Alert.Update(DbContext, alert)

                                                Next

                                            End If

                                            Dim jv As New JobVersion(Session("ConnString"))
                                            jv.UpdateJobTemplatePerJVMapping(Me.JobVerHdrID, "job")

                                            Me.RefreshJobRequestObjects("DesktopMyJobRequests")
                                            Me.RefreshJobRequestObjects("DesktopJobRequests")

                                        End If
                                        If Me.cbCopyCreativeBrief.Checked = True Then

                                            save = oJob.CopyCreativeBrief(Me.TxtJobSource.Text, ComponentNumberToCopy, NewJobNumber, NewComponentNumber)

                                        End If
                                        If Me.cbCopySpecs.Checked = True Then

                                            save = oJob.CopyJobSpecs(Me.TxtJobSource.Text, ComponentNumberToCopy, NewJobNumber, NewComponentNumber)

                                            If save = False Then

                                                Me.ShowMessage("Error saving job specs.")
                                                Exit Sub

                                            End If

                                        End If
                                        If Me.cbCopyProjectSchedule.Checked = True Then

                                            GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ScheduleTemplate, IncludeTaskStatus)

                                            pssave = oJob.CopyProjectSchedule(Me.TxtJobSource.Text, ComponentNumberToCopy, NewJobNumber, NewComponentNumber, Me.txtStatusCopy.Text, IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment,
                                                                            Me.TextBoxCopyTrafficManager.Text.Trim(), ScheduleTemplate, IncludeTaskStatus)

                                            If pssave = 0 Then

                                                'Me.ShowMessage("Error saving project schedule.")

                                            Else

                                                ScheduleCreated = True

                                            End If

                                            If ScheduleCreated = False Then

                                                Dim x As Integer = s.CheckExistsClosed(NewJobNumber, NewComponentNumber)
                                                If x = -1 Then

                                                    Dim str As String = ""
                                                    If s.QuickAddScheduleHeader(NewJobNumber, NewComponentNumber, Me.txtStatusCopy.Text, Me.TextBoxCopyTrafficManager.Text, _Session.UserCode, str) = False Then

                                                        If str.Trim <> "" Then

                                                            Me.ShowMessage(str)

                                                        Else

                                                            ScheduleCreated = True

                                                        End If

                                                    Else

                                                        ScheduleCreated = True

                                                    End If

                                                End If

                                            End If

                                        End If
                                        If Me.CheckBoxCreateSchedule.Checked = True AndAlso ScheduleCreated = False Then

                                            Dim str As String = ""
                                            If s.QuickAddScheduleHeader(NewJobNumber, NewComponentNumber, Me.TextBoxTrafficScheduleStatus.Text, Me.TextBoxTrafficManager.Text, _Session.UserCode, str) = False Then

                                                If str.Trim <> "" Then

                                                    Me.ShowMessage(str)

                                                End If

                                            End If

                                        End If
                                        If Me.cbCopyDestinations.Checked = True Then

                                        End If

                                        Try

                                            If Me.CheckBoxJobCompDocumentAssociations.Checked AndAlso IsNumeric(Me.TxtJobSource.Text) = True AndAlso ComponentNumberToCopy > 0 AndAlso NewComponentNumber > 0 Then

                                                Try

                                                    Dim newjob As New JobComponentDocuments(Session("ConnString"))
                                                    Dim oldjob As New JobComponentDocuments(Session("ConnString"))
                                                    Dim Document As New Document(Session("ConnString"))

                                                    oldjob.Where.JOB_NUMBER.Value = Me.TxtJobSource.Text
                                                    oldjob.Where.JOB_COMPONENT_NUMBER.Value = ComponentNumberToCopy

                                                    If oldjob.Query.Load() Then
                                                        If oldjob.RowCount > 0 Then
                                                            Do Until oldjob.EOF
                                                                Document = New Document(Session("ConnString"))
                                                                Document.Where.DOCUMENT_ID.Value = oldjob.DOCUMENT_ID
                                                                If Document.Query.Load Then
                                                                    If Document.s_PRIVATE_FLAG = "1" Then
                                                                        privateflag = 1
                                                                    End If
                                                                    docID = newjob.Add(NewJobNumber, NewComponentNumber, Document.FILENAME, Document.MIME_TYPE, Document.REPOSITORY_FILENAME, Document.FILE_SIZE, Document.USER_CODE, Document.DESCRIPTION, Document.KEYWORDS, privateflag, Document.DOCUMENT_TYPE_ID)
                                                                End If
                                                                oldjob.MoveNext()
                                                            Loop
                                                        End If
                                                    End If


                                                Catch ex As Exception

                                                End Try

                                                'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                                '    Dim CopySQL As String = String.Format("INSERT INTO JOB_COMPONENT_DOCUMENTS (DOCUMENT_ID, JOB_NUMBER, JOB_COMPONENT_NUMBER) SELECT DOCUMENT_ID, {0}, {1} FROM JOB_COMPONENT_DOCUMENTS WHERE JOB_NUMBER = {2} AND JOB_COMPONENT_NUMBER = {3};",
                                                '                                          NewJobNumber, NewComponentNumber, Me.TxtJobSource.Text, ComponentNumberToCopy)

                                                '    DataContext.ExecuteCommand(CopySQL)

                                                'End Using

                                            End If

                                        Catch ex As Exception
                                        End Try

                                        If NewComponentNumber > 1 Then

                                            If Me.RadListBoxBoards.Visible = True AndAlso Me.RadListBoxBoards.CheckedItems.Count > 0 Then

                                                If AgileController IsNot Nothing Then

                                                    For Each Item As RadListBoxItem In Me.RadListBoxBoards.CheckedItems

                                                        If AgileController.AddJobToBoard(DbContext, Item.Value, NewJobNumber, 1, ErrorMessage) = False Then

                                                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                                ErrorMessages.Add(ErrorMessage)
                                                                ErrorMessage = String.Empty

                                                            End If

                                                        End If

                                                    Next

                                                End If

                                            End If

                                        End If

                                    End If
                                Next

                            End If

                        Next

                    End If

                End Using

                Me.btnCopyJob.Enabled = False
                Me.CloseThisWindowAndRefreshCaller("Content.aspx?PageMode=Edit&JobNum=" & NewJobNumber & "&JobCompNum=1&NewJob=1&NewComp=0", True, True)

            Else

                Me.ShowMessage(ReturnMessage)

            End If
        Catch ex As Exception
            Me.ShowMessage(Err.Description)
        End Try
    End Sub
    Protected Sub btnComps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComps.Click
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim job As New Job_Template(Session("ConnString"))
        Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
        If Me.TxtJobSource.Text = "" Then
            Me.TxtJobSource.Focus()
            Me.ShowMessage("Please enter a valid job number.")
            Exit Sub
        End If
        If myVal.ValidateJobNumber(Me.TxtJobSource.Text) = False Then
            Me.ShowMessage("Please enter a valid job number.")
            Me.TxtJobSource.Focus()
            Exit Sub
        End If
        If Me.TxtJobSource.Text <> "" Then
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TxtJobSource.Text)
                If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TxtJobSource.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                    Me.ShowMessage("Access to this job is denied.\n.")
                    Exit Sub
                End If
            End Using
        End If

        If Me.TxtClientSource.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientSource.Text, "", "") = False Then
                Me.ShowMessage("Access to this client is denied.")
                Exit Sub
            End If
        End If
        If Me.TxtDivisionSource.Text <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientSource.Text, Me.TxtDivisionSource.Text, "") = False Then
                Me.ShowMessage("Access to this division is denied.")
                Exit Sub
            End If
        End If
        If Me.TxtProductSource.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientSource.Text, Me.TxtDivisionSource.Text, Me.TxtProductSource.Text) = False Then
                Me.ShowMessage("Access to this product is denied.")
                Exit Sub
            End If
        End If
        If Me.cbShowClosed.Checked = False Then
            If myVal.ValidateJobIsViewable(Session("UserCode"), Me.TxtJobSource.Text) = False Then
                Me.ShowMessage("Access to this job is denied.")
                Me.RadGridJobCopy.Rebind()
                Exit Sub
            End If
        End If
        If myVal.ValidateJobIsViewableCDP(Session("UserCode"), Me.TxtJobSource.Text) = False Then
            Me.ShowMessage("Access to this job is denied.")
            Exit Sub
        End If
        Dim dt As DataTable = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
        If dt.Rows.Count > 0 Then
            If Me.txtClient.Text = "" And Me.txtDivision.Text = "" And Me.txtProduct.Text = "" Then
                Me.txtClient.Text = dt.Rows(0)("CL_CODE")
                Me.txtDivision.Text = dt.Rows(0)("DIV_CODE")
                Me.txtProduct.Text = dt.Rows(0)("PRD_CODE")
            End If
            If Me.txtAE.Text = "" Then
                If myVal.ValidateAccountExecutive(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, dt.Rows(0)("EMP_CODE")) = True Then
                    Me.txtAE.Text = dt.Rows(0)("EMP_CODE")
                End If
            End If
            If Me.txtJobDesc.Text = "" Then
                Me.txtJobDesc.Text = dt.Rows(0)("JOB_DESC")
            End If
            If Me.txtCompDesc.Text = "" Then
                Me.txtCompDesc.Text = dt.Rows(0)("JOB_COMP_DESC")
            End If
            If Me.txtSalesClass.Text = "" Then
                Me.txtSalesClass.Text = dt.Rows(0)("SC_CODE")
            End If
            If Me.txtCampaign.Text = "" Then
                If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                    Me.txtCampaign.Text = dt.Rows(0)("CMP_CODE")
                End If
                If IsDBNull(dt.Rows(0)("CMP_IDENTIFIER")) = False Then
                    Me.hfCampaignID.Value = dt.Rows(0)("CMP_IDENTIFIER")
                End If
            End If

            'If Me.txtAE.Text <> "" Then
            '    If myVal.ValidateAccountExecutive(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, Me.txtAE.Text) = False Then
            '        Me.txtAE.Text = ""
            '    End If
            'End If

            If Me.txtCampaign.Text <> "" Then
                Dim cmpid As Integer
                cmpid = oJob.GetCampaignIdentifier(Me.txtCampaign.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                If cmpid = 0 Then
                    Me.txtCampaign.Text = ""
                    Me.hfCampaignID.Value = 0
                End If

            End If

        End If

        loadjobdefaults()

        Dim IsCampaignRequired As Boolean = False
        Dim IsJobTypeRequired As Boolean = False
        Dim IsManagerRequired As Boolean = False

        Dim val As String = IsRequiredWebMethod(Me.RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text)

        Dim ar() As String

        ar = val.Split("|")

        IsCampaignRequired = ar(0).ToString() = "true"
        IsJobTypeRequired = ar(1).ToString() = "true"
        IsManagerRequired = ar(2).ToString() = "true"

        If Me.CheckBoxShowCopyFromExistingJob.Checked = True AndAlso IsManagerRequired = True Then

            'Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.Enabled = True
            'Me.TextBoxCopyTrafficManager.CssClass = "RequiredInput"

            If String.IsNullOrWhiteSpace(Me.TextBoxCopyTrafficManager.Text) = True Then

                Me.TextBoxCopyTrafficManager.Text = Me.TextBoxTrafficManager.Text

            End If

        Else

            'Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.Enabled = False
            'Me.TextBoxCopyTrafficManager.CssClass = Nothing

        End If

        Me.RadGridJobCopy.Rebind()

        MiscFN.SetFocus(TxtJobSource)

        Me.butCreateJob.Enabled = False
        Me.btnCopyJob.Enabled = True

        Me.CheckBoxOverride.Visible = True

        If Me.CheckBoxOverride.Visible = True Then
            If CheckBoxOverride.Checked = True Then
                Me.txtCompDesc.Enabled = True
                Me.txtCompDesc.Visible = True
                Me.MessageComp.Visible = False
            Else
                Me.txtCompDesc.Enabled = False
                Me.txtCompDesc.Visible = False
                Me.MessageComp.Visible = True
            End If
        Else
            Me.txtCompDesc.Enabled = True
            Me.txtCompDesc.Visible = True
            Me.MessageComp.Visible = False
        End If


    End Sub
    Protected Sub cbCopyProjectSchedule_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCopyProjectSchedule.CheckedChanged

        SetCopyProjectScheduleOptions()

    End Sub
    Private Sub SetCopyProjectScheduleOptions()

        'Me.DivCopyJobProjectScheduleDate.Visible = Me.cbCopyProjectSchedule.Checked
        'Me.DivCopyJobProjectScheduleStatus.Visible = Me.cbCopyProjectSchedule.Checked
        'Me.DivCopyTrafficManager.Visible = Me.cbCopyProjectSchedule.Checked
        If Me.cbCopyProjectSchedule.Checked = True Then
            If Me.ProjectSheduleRequired = True Then
                Me.CheckBoxCreateSchedule.Checked = True
            Else
                Me.CheckBoxCreateSchedule.Checked = False
            End If
            Me.DivSchedule.Visible = True

            Me.CheckBoxListCopyOptions.Enabled = True
            Me.hlStatusCopy.Enabled = True
            Me.hlStatusCopy.Visible = True
            Me.LabelStatusCopy.Visible = False
            'Me.hlStatusCopy.Attributes.Add("onclick", "FocusTB('" & Me.txtStatusCopy.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=statuscodes&control=" & Me.txtStatusCopy.ClientID & "&type=statuscodes');return false;")
            Me.txtStatusCopy.Enabled = True
            Me.txtStatusDescCopy.Enabled = True
            Me.HyperLinkCopyTrafficManager.Enabled = True
            Me.HyperLinkCopyTrafficManager.Visible = True
            Me.LabelTrafficManager.Visible = False
            'Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxCopyTrafficManager.ClientID.ToString() & "');return false;")
            Me.TextBoxCopyTrafficManager.Enabled = True
            Me.TextBoxCopyTrafficManagerDescription.Enabled = True
        Else
            Me.CheckBoxListCopyOptions.Enabled = False
            Me.hlStatusCopy.Enabled = False
            Me.hlStatusCopy.Visible = False
            Me.LabelStatusCopy.Visible = True
            'Me.hlStatusCopy.Attributes.Add("onclick", "")
            Me.txtStatusCopy.Enabled = False
            Me.txtStatusDescCopy.Enabled = False
            Me.HyperLinkCopyTrafficManager.Enabled = False
            Me.HyperLinkCopyTrafficManager.Visible = False
            Me.LabelTrafficManager.Visible = True
            'Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "")
            Me.TextBoxCopyTrafficManager.Enabled = False
            Me.TextBoxCopyTrafficManagerDescription.Enabled = False
        End If


        If Me.cbCopyProjectSchedule.Checked = False Then

        End If

        Me.cbCopyProjectSchedule.Focus()

    End Sub
    Protected Sub cbShowClosed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowClosed.CheckedChanged
        Me.SetLookUps()
    End Sub
    Private Sub CheckBoxShowCopyFromExistingJob_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxShowCopyFromExistingJob.CheckedChanged

        'Me.CollapsablePanelHeader.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked
        'Me.CollapsablePanel1.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked

        'Me.CollapsablePanelHeader.Collapsed = Not Me.CollapsablePanelHeader.Collapsed
        'Me.CollapsablePanel1.Collapsed = Not Me.CollapsablePanel1.Visible




    End Sub

    Private Sub ButtonClearCopy_Click(sender As Object, e As EventArgs) Handles ButtonClearCopy.Click
        Try
            Me.butCreateJob.Enabled = True
            Me.CheckBoxOverride.Visible = False
            Me.CheckBoxOverride.Checked = False
            Me.txtCompDesc.Enabled = True
            Me.txtCompDesc.Visible = True
            Me.MessageComp.Visible = False
            Me.btnCopyJob.Enabled = False
            Me.TxtClientSource.Text = ""
            Me.TxtClientSourceDesc.Text = ""
            Me.TxtDivisionSource.Text = ""
            Me.TxtDivisionSourceDesc.Text = ""
            Me.TxtProductSource.Text = ""
            Me.TxtProductSourceDesc.Text = ""
            Me.TxtJobSource.Text = ""
            Me.TxtJobSourceDesc.Text = ""
            Me.TxtJobTypeSource.Text = ""
            Me.TxtJobTypeSourceDesc.Text = ""
            Me.TxtSalesClassSource.Text = ""
            Me.TxtSalesClassDescriptionSource.Text = ""
            Me.RadGridJobCopy.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtJobSource_TextChanged(sender As Object, e As EventArgs) Handles TxtJobSource.TextChanged
        Try
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim job As New Job_Template(Session("ConnString"))
            Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

            If Me.TxtJobSource.Text <> "" Then
                If Me.TxtJobSource.Text = "" Then
                    Me.TxtJobSource.Focus()
                    Me.ShowMessage("Please enter a valid job number.")
                    Exit Sub
                End If
                If myVal.ValidateJobNumber(Me.TxtJobSource.Text) = False Then
                    Me.ShowMessage("Please enter a valid job number.")
                    Me.TxtJobSource.Focus()
                    Exit Sub
                End If
                If Me.TxtJobSource.Text <> "" Then
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TxtJobSource.Text)
                        If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, TxtJobSource.Text) = False AndAlso
                                AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                            Me.ShowMessage("Access to this job is denied.\n.")
                            Exit Sub
                        End If
                    End Using
                End If

                If Me.TxtClientSource.Text <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientSource.Text, "", "") = False Then
                        Me.ShowMessage("Access to this client is denied.")
                        Exit Sub
                    End If
                End If
                If Me.TxtDivisionSource.Text <> "" Then
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientSource.Text, Me.TxtDivisionSource.Text, "") = False Then
                        Me.ShowMessage("Access to this division is denied.")
                        Exit Sub
                    End If
                End If
                If Me.TxtProductSource.Text <> "" Then
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientSource.Text, Me.TxtDivisionSource.Text, Me.TxtProductSource.Text) = False Then
                        Me.ShowMessage("Access to this product is denied.")
                        Exit Sub
                    End If
                End If
                If Me.cbShowClosed.Checked = False Then
                    If myVal.ValidateJobIsViewable(Session("UserCode"), Me.TxtJobSource.Text) = False Then
                        Me.ShowMessage("Access to this job is denied.")
                        Me.RadGridJobCopy.Rebind()
                        Exit Sub
                    End If
                End If
                If myVal.ValidateJobIsViewableCDP(Session("UserCode"), Me.TxtJobSource.Text) = False Then
                    Me.ShowMessage("Access to this job is denied.")
                    Exit Sub
                End If
                Dim dt As DataTable = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    If Me.txtClient.Text = "" And Me.txtDivision.Text = "" And Me.txtProduct.Text = "" Then
                        Me.txtClient.Text = dt.Rows(0)("CL_CODE")
                        Me.txtDivision.Text = dt.Rows(0)("DIV_CODE")
                        Me.txtProduct.Text = dt.Rows(0)("PRD_CODE")
                    End If
                    If Me.txtAE.Text = "" Then
                        If myVal.ValidateAccountExecutive(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, dt.Rows(0)("EMP_CODE")) = True Then
                            Me.txtAE.Text = dt.Rows(0)("EMP_CODE")
                        End If
                    End If
                    If Me.txtJobDesc.Text = "" Then
                        Me.txtJobDesc.Text = dt.Rows(0)("JOB_DESC")
                    End If
                    If Me.txtCompDesc.Text = "" Then
                        Me.txtCompDesc.Text = dt.Rows(0)("JOB_COMP_DESC")
                    End If
                    If Me.txtSalesClass.Text = "" Then
                        Me.txtSalesClass.Text = dt.Rows(0)("SC_CODE")
                    End If
                    If Me.txtCampaign.Text = "" Then
                        If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                            Me.txtCampaign.Text = dt.Rows(0)("CMP_CODE")
                        End If
                        If IsDBNull(dt.Rows(0)("CMP_IDENTIFIER")) = False Then
                            Me.hfCampaignID.Value = dt.Rows(0)("CMP_IDENTIFIER")
                        End If
                    End If

                    'If Me.txtAE.Text <> "" Then
                    '    If myVal.ValidateAccountExecutive(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, Me.txtAE.Text) = False Then
                    '        Me.txtAE.Text = ""
                    '    End If
                    'End If

                    If Me.txtCampaign.Text <> "" Then
                        Dim cmpid As Integer
                        cmpid = oJob.GetCampaignIdentifier(Me.txtCampaign.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                        If cmpid = 0 Then
                            Me.txtCampaign.Text = ""
                            Me.hfCampaignID.Value = 0
                        End If

                    End If

                End If

                loadjobdefaults()

                Dim IsCampaignRequired As Boolean = False
                Dim IsJobTypeRequired As Boolean = False
                Dim IsManagerRequired As Boolean = False

                Dim val As String = IsRequiredWebMethod(Me.RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text)

                Dim ar() As String

                ar = val.Split("|")

                IsCampaignRequired = ar(0).ToString() = "true"
                IsJobTypeRequired = ar(1).ToString() = "true"
                IsManagerRequired = ar(2).ToString() = "true"

                If Me.CheckBoxShowCopyFromExistingJob.Checked = True AndAlso IsManagerRequired = True Then

                    'Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.Enabled = True
                    'Me.TextBoxCopyTrafficManager.CssClass = "RequiredInput"

                    If String.IsNullOrWhiteSpace(Me.TextBoxCopyTrafficManager.Text) = True Then

                        Me.TextBoxCopyTrafficManager.Text = Me.TextBoxTrafficManager.Text

                    End If

                Else

                    'Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.Enabled = False
                    'Me.TextBoxCopyTrafficManager.CssClass = Nothing

                End If

                Me.RadGridJobCopy.Rebind()

                MiscFN.SetFocus(TxtJobSource)

                Me.butCreateJob.Enabled = False
                Me.btnCopyJob.Enabled = True
                Me.CheckBoxOverride.Visible = True
                If CheckBoxOverride.Checked = True Then
                    Me.txtCompDesc.Enabled = True
                    Me.txtCompDesc.Visible = True
                    Me.MessageComp.Visible = False
                Else
                    Me.txtCompDesc.Enabled = False
                    Me.txtCompDesc.Visible = False
                    Me.MessageComp.Visible = True
                End If
            Else
                Me.butCreateJob.Enabled = True
                Me.btnCopyJob.Enabled = False
                Me.CheckBoxOverride.Visible = False
                Me.CheckBoxOverride.Checked = False
                If Me.CheckBoxOverride.Visible = True Then
                    If CheckBoxOverride.Checked = True Then
                        Me.txtCompDesc.Enabled = True
                        Me.txtCompDesc.Visible = True
                        Me.MessageComp.Visible = False
                    Else
                        Me.txtCompDesc.Enabled = False
                        Me.txtCompDesc.Visible = False
                        Me.MessageComp.Visible = True
                    End If
                Else
                    Me.txtCompDesc.Enabled = True
                    Me.txtCompDesc.Visible = True
                    Me.MessageComp.Visible = False
                End If

                Me.TxtClientSource.Text = ""
                Me.TxtClientSourceDesc.Text = ""
                Me.TxtDivisionSource.Text = ""
                Me.TxtDivisionSourceDesc.Text = ""
                Me.TxtProductSource.Text = ""
                Me.TxtProductSourceDesc.Text = ""
                Me.TxtJobSource.Text = ""
                Me.TxtJobSourceDesc.Text = ""
                Me.TxtJobTypeSource.Text = ""
                Me.TxtJobTypeSourceDesc.Text = ""
                Me.TxtSalesClassSource.Text = ""
                Me.TxtSalesClassDescriptionSource.Text = ""
                Me.RadGridJobCopy.Rebind()
            End If


        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " Methods "

    Private Sub LoadBoards()

        Dim AgileController As New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)

        If AgileController IsNot Nothing Then

            Dim Boards As Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Boards = DbContext.Database.SqlQuery(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)(String.Format("EXEC [dbo].[advsp_agile_load_agile_boards] {0}, {1}, 1, '{2}';",
                                                                                                                                                 0, 0, Me.SecuritySession.UserCode)).ToList

                Catch ex As Exception
                    Boards = Nothing
                End Try
                If Boards IsNot Nothing AndAlso Boards.Count > 0 Then

                    Me.RadListBoxBoards.DataSource = Boards
                    Me.RadListBoxBoards.DataValueField = Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay.Properties.ID.ToString
                    Me.RadListBoxBoards.DataTextField = Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay.Properties.Name.ToString
                    Me.RadListBoxBoards.DataBind()

                Else

                    Me.TableCellBoards.Visible = False
                    Me.TableCellCreate.Attributes.Remove("style")

                End If

            End Using

        End If

    End Sub
    Private Sub getEstimateDefaults()
        Try
            Dim dt As DataTable
            Dim est As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim job As Job_Template = New Job_Template(Session("ConnString"))
            dt = est.GetEstimateData(EstNum, EstComp, 0, 0, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    Me.txtClient.Text = dt.Rows(0)("CL_CODE")
                End If
                If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                    Me.txtDivision.Text = dt.Rows(0)("DIV_CODE")
                End If
                If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                    Me.txtProduct.Text = dt.Rows(0)("PRD_CODE")
                End If
                If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                    Me.txtSalesClass.Text = dt.Rows(0)("SC_CODE")
                End If
                If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                    Me.txtJobDesc.Text = dt.Rows(0)("EST_LOG_DESC")
                End If
                If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                    Me.txtCompDesc.Text = dt.Rows(0)("EST_COMP_DESC")
                End If
            End If
            If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
                Me.txtAE.Text = job.GetDefaultAE(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
            End If
            Me.hlClient.Attributes.Add("onclick", "")
            Me.hlDivision.Attributes.Add("onclick", "")
            Me.hlProduct.Attributes.Add("onclick", "")
            Me.hlSalesClass.Attributes.Add("onclick", "")
            Me.hlClient.Enabled = False
            Me.hlDivision.Enabled = False
            Me.hlProduct.Enabled = False
            Me.hlSalesClass.Enabled = False
            Me.txtClient.ReadOnly = True
            Me.txtDivision.ReadOnly = True
            Me.txtProduct.ReadOnly = True
            Me.txtSalesClass.ReadOnly = True

        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadJobRequestDefaults()
        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim job As Job_Template = New Job_Template(Session("ConnString"))
            Dim office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim dr As SqlDataReader
            dr = jv.GetJVRequestDescriptions(JobVerHdrID)
            If dr.HasRows Then
                dr.Read()
                'CDP
                If IsDBNull(dr("CL_CODE")) = False Then
                    Me.txtClient.Text = dr.GetString(0)
                End If
                If IsDBNull(dr("DIV_CODE")) = False Then
                    Me.txtDivision.Text = dr.GetString(2)
                End If
                If IsDBNull(dr("PRD_CODE")) = False Then
                    Me.txtProduct.Text = dr.GetString(4)
                End If
                If IsDBNull(dr("JOB_VER_DESC")) = False Then
                    Me.txtJobDesc.Text = dr.GetString(6)
                    Me.txtCompDesc.Text = dr.GetString(6)
                End If
            End If

            If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
                Me.txtAE.Text = job.GetDefaultAE(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                    If Product IsNot Nothing Then
                        Me.TxtOffice.Text = Product.OfficeCode
                    End If
                End Using
            End If
            Me.hlClient.Attributes.Add("onclick", "")
            Me.hlDivision.Attributes.Add("onclick", "")
            Me.hlProduct.Attributes.Add("onclick", "")
            Me.hlSalesClass.Attributes.Add("onclick", "")
            Me.hlClient.Enabled = False
            Me.hlDivision.Enabled = False
            Me.hlProduct.Enabled = False
            Me.txtClient.ReadOnly = True
            Me.txtDivision.ReadOnly = True
            Me.txtProduct.ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CallJavaScript(ByVal pScript As String)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">"
        strScript &= pScript & "</script>"
        If Not Page.IsStartupScriptRegistered("Webvantage") Then
            Page.RegisterStartupScript("Webvantage", strScript)
        End If
    End Sub
    Private Sub SetLookUps()
        Dim OffVis As Integer = 0
        If Me.ShowOffice = True Then
            OffVis = 1
        End If
        Me.HlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacketnewoffice&control=" & Me.TxtOffice.ClientID & "&type=office&ddtype=client');return false;")
        If Request.QueryString("from") <> "estimate" Then
            Me.hlClient.Attributes.Add("onclick", "FocusTB('" & Me.txtClient.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacketnew&control=" & Me.txtClient.ClientID & "&type=client&ddtype=client');return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=jobnew&type=division&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobnew&type=product&offvis=" & OffVis.ToString() & "&control=" & Me.txtProduct.ClientID & "&office=&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value+ '&ae=' + document.forms[0]." & Me.txtAE.ClientID & ".value);return false;")
            Me.hlSalesClass.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtSalesClass.ClientID & "&type=salesclass');return false;")
        End If

        Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAE.ClientID & "&type=accountexec&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
        Me.LinkButtonCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=jobcmpnew&type=campaignjobnew&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
        'Me.LinkButtonCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=campaignjobnew&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

        Me.HlClientSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
        Me.HlDivisionSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")

        Me.HlProductSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")



        Me.HyperLinkJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jtn1&control=" & Me.TextBoxJobType.ClientID & "&type=jobtype&salesclass=' + document.forms[0]." & Me.txtSalesClass.ClientID & ".value + '&job=0');return false;")
        Me.HlJobTypeSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jtn&control=" & Me.TxtJobTypeSource.ClientID & "&type=jobtype&salesclass=' + document.forms[0]." & Me.TxtSalesClassSource.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobSource.ClientID & ".value);return false;")



        Me.HyperLinkStatus.Attributes.Add("onclick", "FocusTB('" & Me.TextBoxTrafficScheduleStatus.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?form=statuscodes&control=" & Me.TextBoxTrafficScheduleStatus.ClientID & "&type=statuscodes');return false;")
        Me.HyperLinkStatusFilter.Attributes.Add("onclick", "FocusTB('" & Me.TextBoxStatusFilter.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=copyjob_statuscodes&control=" & Me.TextBoxStatusFilter.ClientID & "&type=statuscodes');return false;")
        Me.hlStatusCopy.Attributes.Add("onclick", "FocusTB('" & Me.txtStatusCopy.ClientID & "');OpenRadWindowLookup('LookUp.aspx?form=statuscodes&control=" & Me.txtStatusCopy.ClientID & "&type=statuscodes');return false;")

        If Me.cbShowClosed.Checked = True Then
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopy&type=jobcopy&checked=1&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value + '&status=' + document.forms[0]." & Me.TextBoxStatusFilter.ClientID & ".value);return false;")
        Else
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopy&type=jobcopy&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value + '&status=' + document.forms[0]." & Me.TextBoxStatusFilter.ClientID & ".value);return false;")
        End If

        Dim s As New cSchedule()
        Dim ManagerLabel As String = s.GetManagerLabel()

        Me.HyperLinkCopyTrafficManager.Text = ManagerLabel & ":"
        Me.HyperLinkTrafficManager.Text = ManagerLabel & ":"
        Me.LabelTrafficManager.Text = ManagerLabel & ":"
        Me.LabelManager.Text = ManagerLabel & ":"
        'Me.RequiredfieldvalidatorTrafficManager.ErrorMessage = String.Format("{0} is required.", ManagerLabel)
        'Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.ErrorMessage = String.Format("{0} is required.", ManagerLabel)

        Me.HyperLinkTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxTrafficManager.ClientID.ToString() & "');return false;")
        Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxCopyTrafficManager.ClientID.ToString() & "');return false;")

        Me.DivOffice.Visible = Me.ShowOffice
        Me.RFVOffice.Enabled = Me.ShowOffice

    End Sub
    Private Sub BindDropTemplates()

        Dim MyDrop As cDropDowns = New cDropDowns(Session("ConnString"))

        With Me.RadComboBoxJobTemplate

            .DataSource = MyDrop.GetJobTemplatesList()
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()

        End With

        If RadComboBoxJobTemplate.Items.Count > 0 Then

            Dim idx As Int16
            Dim value As String
            Dim found As Boolean = False

            For idx = 0 To RadComboBoxJobTemplate.Items.Count - 1

                If found = False Then

                    value = RadComboBoxJobTemplate.Items.Item(idx).Value

                    If RadComboBoxJobTemplate.Items.Item(idx).Value = "DFLT" Then

                        found = True
                        RadComboBoxJobTemplate.SelectedIndex = idx

                        Dim JV As Job_Template = New Job_Template(Session("ConnString"))
                        Dim defSC As String

                        defSC = JV.GetTmpltDefSC(value)

                        If Request.QueryString("from") <> "estimate" Then

                            Me.txtSalesClass.Text = defSC

                        End If

                        Exit For

                    End If

                End If

            Next
            If found = False Then   'jtg: Issue when user inactivates default template...

                RadComboBoxJobTemplate.SelectedIndex = 0
                value = RadComboBoxJobTemplate.Items.Item(0).Value

                Dim JV As Job_Template = New Job_Template(Session("ConnString"))
                Dim defSC As String

                defSC = JV.GetTmpltDefSC(value)

                If Request.QueryString("from") <> "estimate" Then

                    Me.txtSalesClass.Text = defSC

                End If

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageFramework.ProjectManagement.LoadLabelsFromJobTemplate(DbContext, Me.RadComboBoxJobTemplate.SelectedItem.Value,
                                                                               Me.HlOffice.Text, Me.hlClient.Text, Me.hlDivision.Text, Me.hlProduct.Text,
                                                                               Me.hlAE.Text, Me.hlSalesClass.Text, Nothing, Me.HyperLinkJobType.Text)

                Me.HlOffice.Text &= ":"
                Me.hlClient.Text &= ":"
                Me.hlDivision.Text &= ":"
                Me.hlProduct.Text &= ":"
                Me.hlAE.Text &= ":"
                Me.hlSalesClass.Text &= ":"
                Me.HyperLinkJobType.Text &= ":"

                Me.HlClientSource.Text = Me.hlClient.Text
                Me.HlDivisionSource.Text = Me.hlDivision.Text
                Me.HlProductSource.Text = Me.hlProduct.Text
                Me.LabelSalesClassSource.Text = Me.hlSalesClass.Text
                Me.HlJobTypeSource.Text = Me.HyperLinkJobType.Text

            End Using

        End If

    End Sub
    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Select Case StrSort
                Case "Job"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("JOB_NUMBER Job Group By JOB_NUMBER")
                    With Me.RadGridJobCopy
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case Else
                    Me.RadGridJobCopy.MasterTableView.GroupByExpressions.Clear()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub loadjobdefaults()
        Try

            Dim job As New Job(Session("ConnString"))
            Dim ojob As New cJobs(Session("ConnString"))

            If Me.TxtJobSource.Text <> "" Then

                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                Dim i As Integer = s.CountHeaderComponentsOneComp(CInt(Me.TxtJobSource.Text), True)
                Dim ManagerCode As String = String.Empty

                job.GetJob(CInt(Me.TxtJobSource.Text))

                Me.TxtClientSource.Text = job.CL_CODE
                Me.TxtClientSourceDesc.Text = job.ClientDesc
                Me.TxtDivisionSource.Text = job.DIV_CODE
                Me.TxtDivisionSourceDesc.Text = job.DivisionDesc
                Me.TxtProductSource.Text = job.PRD_CODE
                Me.TxtProductSourceDesc.Text = job.ProductDesc
                Me.TxtJobSourceDesc.Text = job.JOB_DESC
                Me.TxtSalesClassSource.Text = job.SC_CODE
                Me.TxtSalesClassDescriptionSource.Text = job.SalesClassDesc

                If i = 1 Then

                    job.GetJob(CInt(Me.TxtJobSource.Text), i)

                    Me.TxtJobTypeSource.Text = job.JobComponent.JT_CODE
                    Me.TxtJobTypeSourceDesc.Text = job.JobComponent.JobTypeDesc

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ManagerCode = (DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL({0}, '') FROM JOB_TRAFFIC WITH(NOLOCK) WHERE JOB_NUMBER = {1} AND JOB_COMPONENT_NBR = {2};", s.GetManagerField(), CInt(Me.TxtJobSource.Text), i)).FirstOrDefault).ToString

                            If String.IsNullOrWhiteSpace(ManagerCode) = False Then

                                Me.TextBoxCopyTrafficManager.Text = ManagerCode

                            End If

                        End Using

                    Catch ex As Exception
                    End Try

                Else

                    Me.TxtJobTypeSource.Text = ""
                    Me.TxtJobTypeSourceDesc.Text = ""

                    Me.TextBoxCopyTrafficManager.Text = ""

                End If

            End If

            If Me.txtStatusCopy.Text <> "" Then

                Me.txtStatusDescCopy.Text = ojob.GetStatusDesc(Me.txtStatusCopy.Text)

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlClient.SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String

            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")

            If secInsert = "N" Then
                Me.cbCopyProjectSchedule.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetProjectScheduleDefaults()
        If Me.DefaultStatusCode <> "" Then
            Dim d As New cDropDowns(Session("ConnString"))
            Me.TextBoxTrafficScheduleStatus.Text = Me.DefaultStatusCode
            Me.txtStatusCopy.Text = Me.DefaultStatusCode
            If Me.txtStatusCopy.Text <> "" Then
                Dim ojob As New cJobs(Session("ConnString"))
                Me.txtStatusDescCopy.Text = ojob.GetStatusDesc(Me.txtStatusCopy.Text)
            End If
        End If
    End Sub
    Private Sub SetProjectScheduleRequirement()

        Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
        Me.DefaultStatusCode = a.GetValue(AdvantageFramework.Agency.Settings.TRF_DFLT_STATUS, "")
        If Me.DefaultStatusCode <> "" Then
            Dim v As New cValidations(Session("ConnString"))
            If v.ValidateTrafficStatus(Me.DefaultStatusCode) = False Then

                Me.DefaultStatusCode = ""

            End If
        End If
        Dim psr As String = a.GetValue(AdvantageFramework.Agency.Settings.JOB_PS_REQ_ON_NEW, "")
        Me.ProjectSheduleRequired = psr = "1"

        If Me.ProjectSheduleRequired = True Then

            Me.cbCopyProjectSchedule.Checked = True
            Me.cbCopyProjectSchedule.Enabled = False

            Me.CheckBoxCreateSchedule.Checked = True
            Me.CheckBoxCreateSchedule.Enabled = False

            Me.TextBoxTrafficScheduleStatus.CssClass = "RequiredInput"
            Me.txtStatusCopy.CssClass = "RequiredInput"

        Else

            Me.cbCopyProjectSchedule.Enabled = True
            Me.CheckBoxCreateSchedule.Enabled = True

            Me.TextBoxTrafficScheduleStatus.CssClass = Nothing
            Me.txtStatusCopy.CssClass = Nothing

        End If

    End Sub

    Private Sub LoadTemplateRequirements()

        If Me.RadComboBoxJobTemplate.Items IsNot Nothing AndAlso Me.RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


            End Using

        End If

    End Sub

    Private Sub CheckBoxCreateSchedule_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCreateSchedule.CheckedChanged

        If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

            CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

        End If

        If CheckBoxCreateSchedule.Checked = True Then
            Me.cbCopyProjectSchedule.Checked = False
            'Me.DivCopyJobProjectScheduleStatus.Visible = False
            'Me.DivCopyTrafficManager.Visible = False
            'Me.DivCopyJobProjectScheduleDate.Visible = False

            Me.CheckBoxListCopyOptions.Enabled = False
            Me.hlStatusCopy.Enabled = False
            'Me.hlStatusCopy.Attributes.Add("onclick", "")
            Me.hlStatusCopy.Visible = False
            Me.LabelStatusCopy.Visible = True
            Me.txtStatusCopy.Enabled = False
            Me.txtStatusDescCopy.Enabled = False
            Me.HyperLinkCopyTrafficManager.Enabled = False
            Me.HyperLinkCopyTrafficManager.Visible = False
            Me.LabelTrafficManager.Visible = True
            'Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "")
            Me.TextBoxCopyTrafficManager.Enabled = False
            Me.TextBoxCopyTrafficManagerDescription.Enabled = False

        End If

    End Sub
    Private Function CheckRequirements(ByVal JobTemplateCode As String, ByVal ClientCode As String, ByVal IsSaving As Boolean) As Boolean

        Dim HasRequirements As Boolean = True

        Try

            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False
            Dim IsManagerRequired As Boolean = False

            Dim val As String = IsRequiredWebMethod(JobTemplateCode, ClientCode)

            Dim ar() As String

            ar = val.Split("|")

            IsCampaignRequired = ar(0).ToString() = "true"
            IsJobTypeRequired = ar(1).ToString() = "true"
            IsManagerRequired = ar(2).ToString() = "true"

            If IsManagerRequired = True Then

                If Me.CheckBoxCreateSchedule.Checked = True AndAlso IsSaving = True AndAlso String.IsNullOrWhiteSpace(Me.TextBoxTrafficManager.Text) = True Then

                    Me.TextBoxTrafficManager.CssClass = "required-missing"
                    HasRequirements = False
                    Dim s As New cSchedule()
                    Me.ShowMessage(s.GetManagerLabel & " is required")

                ElseIf Me.CheckBoxCreateSchedule.Checked = False Then

                    Me.TextBoxTrafficManager.CssClass = Nothing

                Else

                    Me.TextBoxTrafficManager.CssClass = "RequiredInput"

                End If

            Else

                Me.TextBoxTrafficManager.CssClass = Nothing

            End If

            If Me.cbCopyProjectSchedule.Checked = True AndAlso IsManagerRequired = True Then
                Me.TextBoxCopyTrafficManager.CssClass = "RequiredInput"
            Else
                Me.TextBoxCopyTrafficManager.CssClass = Nothing
            End If

            If Me.CheckBoxCreateSchedule.Checked = True AndAlso IsManagerRequired = True Then

                'Me.RequiredfieldvalidatorTrafficManager.Enabled = True

            ElseIf Me.CheckBoxCreateSchedule.Checked = False Then

                ' Me.RequiredfieldvalidatorTrafficManager.Enabled = False

            End If
            'If Me.CheckBoxShowCopyFromExistingJob.Checked = True AndAlso IsManagerRequired = True Then

            '    Me.RequiredfieldvalidatorTextBoxCopyTrafficManager.Enabled = True

            'End If

            If IsCampaignRequired = True Then

                If IsSaving = True AndAlso String.IsNullOrWhiteSpace(Me.txtCampaign.Text) = True Then

                    Me.txtCampaign.CssClass = "required-missing"
                    HasRequirements = False
                    Me.ShowMessage("Campaign is required")

                Else

                    Me.txtCampaign.CssClass = "RequiredInput"

                End If

            Else

                Me.txtCampaign.CssClass = Nothing

            End If
            Me.RequiredfieldvalidatorCampaign.Enabled = IsCampaignRequired

            If IsJobTypeRequired = True Then

                If IsSaving = True AndAlso String.IsNullOrWhiteSpace(Me.TextBoxJobType.Text) = True Then

                    Me.TextBoxJobType.CssClass = "required-missing"
                    HasRequirements = False
                    Me.ShowMessage("Job Type is required")

                Else

                    Me.TextBoxJobType.CssClass = "RequiredInput"

                End If

            Else

                Me.TextBoxJobType.CssClass = Nothing

            End If
            Me.RequiredFieldValidatorJobType.Enabled = IsJobTypeRequired

            Return HasRequirements

        Catch ex As Exception
        End Try

    End Function

    Public Shared Function SetIsRequiredHierarchy(ByVal AgencyRequired As Boolean, ByVal ClientRequired As Boolean, ByVal TemplateRequired As Boolean, ByVal JobTemplateOverridesAgency As Boolean) As Boolean

        Dim IsRequiredField As Boolean = False

        If AgencyRequired = True And ClientRequired = True Then

            IsRequiredField = True

        ElseIf AgencyRequired = True And ClientRequired = False Then

            If JobTemplateOverridesAgency Then

                IsRequiredField = False

            Else

                IsRequiredField = True

            End If

        ElseIf AgencyRequired = False And ClientRequired = True Then

            If JobTemplateOverridesAgency = True Then

                IsRequiredField = True

            Else

                IsRequiredField = False

            End If
        ElseIf AgencyRequired = False And ClientRequired = False Then

            If TemplateRequired = True Then

                IsRequiredField = True

            Else

                IsRequiredField = False

            End If

        Else

            IsRequiredField = False

        End If

        Return IsRequiredField

    End Function
    <System.Web.Services.WebMethod(True)>
    Public Shared Function IsRequiredWebMethod(ByVal JobTemplateCode As String, ByVal ClientCode As String) As String

        Dim ReturnValue As String = "false|false|false"

        Try

            Dim oAgency As New cAgency(HttpContext.Current.Session("ConnString"))

            Dim JobTemplateOverrideAgencyCheck As Boolean = False

            Dim IsManagerRequired As Boolean = False
            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False

            Dim IsCampaignRequiredAgency As Boolean = False
            Dim IsJobTypeRequiredAgency As Boolean = False

            Dim IsCampaignRequiredTemplate As Boolean = False
            Dim IsJobTypeRequiredTemplate As Boolean = False

            Dim IsCampaignRequiredClient As Boolean = False
            Dim IsJobTypeRequiredClient As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                IsCampaignRequiredAgency = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(CMP_CODE_R, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault = 1)
                IsJobTypeRequiredAgency = (DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(JT_CODE_R, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault = 1)

                If String.IsNullOrWhiteSpace(ClientCode) = False Then

                    IsCampaignRequiredClient = (DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(CMP_CODE_R, 0) AS SMALLINT) FROM CLIENT WITH(NOLOCK) WHERE CL_CODE = '{0}';", ClientCode)).FirstOrDefault = 1)
                    IsJobTypeRequiredClient = (DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(JT_CODE_R, 0) AS SMALLINT) FROM CLIENT WITH(NOLOCK) WHERE CL_CODE = '{0}';", ClientCode)).FirstOrDefault = 1)

                    JobTemplateOverrideAgencyCheck = oAgency.JobTemplateOverrideAgencyCheck(ClientCode)

                End If
                If String.IsNullOrWhiteSpace(JobTemplateCode) = False Then

                    IsCampaignRequiredTemplate = (DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(REQUIRED, 0) AS SMALLINT) FROM JOB_TMPLT_DTL WITH(NOLOCK) WHERE JOB_TMPLT_CODE = '{0}' AND ITEM_CODE = 'JOB_LOG.CMP_CODE' AND [INCLUDE] = 1;", JobTemplateCode)).FirstOrDefault = 1)
                    IsJobTypeRequiredTemplate = (DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT CAST(ISNULL(REQUIRED, 0) AS SMALLINT) FROM JOB_TMPLT_DTL WITH(NOLOCK) WHERE JOB_TMPLT_CODE = '{0}' AND ITEM_CODE = 'JOB_COMPONENT.JT_CODE' AND [INCLUDE] = 1;", JobTemplateCode)).FirstOrDefault = 1)

                End If

                IsManagerRequired = (DbContext.Database.SqlQuery(Of Short)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, AGY_SETTINGS_DESC) AS SMALLINT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'PS_REQ_MGR';").FirstOrDefault = 1)
                IsCampaignRequired = SetIsRequiredHierarchy(IsCampaignRequiredAgency, IsCampaignRequiredClient, IsCampaignRequiredTemplate, JobTemplateOverrideAgencyCheck)
                IsJobTypeRequired = SetIsRequiredHierarchy(IsJobTypeRequiredAgency, IsJobTypeRequiredClient, IsJobTypeRequiredTemplate, JobTemplateOverrideAgencyCheck)

            End Using

            Return String.Format("{0}|{1}|{2}", IsCampaignRequired.ToString().ToLower(), IsJobTypeRequired.ToString().ToLower(), IsManagerRequired.ToString().ToLower())

        Catch ex As Exception
            Return "false|false|false"
        End Try

    End Function

    Private Sub CheckBoxOverride_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOverride.CheckedChanged
        Try
            If CheckBoxOverride.Checked = True Then
                Me.txtCompDesc.Enabled = True
                Me.txtCompDesc.Visible = True
                Me.MessageComp.Visible = False
            Else
                Me.txtCompDesc.Enabled = False
                Me.txtCompDesc.Visible = False
                Me.MessageComp.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
