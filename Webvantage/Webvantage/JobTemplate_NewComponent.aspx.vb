Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Webvantage.wvTimeSheet

Partial Public Class jobtemplate_newcomponent
    Inherits Webvantage.BaseChildPage


#Region " Variables "

    Private CurrJobNum As Integer = 0
    Private CurrJobCompNum As Integer = 0
    Private CurrTemplate As String = ""

    Private CurrClient As String = String.Empty
    Private CurrDivision As String = String.Empty
    Private CurrProduct As String = String.Empty

    Public EstNum As Integer = 0
    Public EstComp As Integer = 0
    Private JobVerHdrID As Integer = 0

    Private ProjectSheduleRequired As Boolean = False
    Private DefaultStatusCode As String = ""
    Private FromPage As String = ""
    Private rebind As Boolean = True
    Private oSQL As SqlHelper

    Public JavascriptArrayBudget As String = ""

#End Region

#Region " Page Events "

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If IsNumeric(qs.JobNumber) Then Me.CurrJobNum = CType(qs.JobNumber, Integer)
        If IsNumeric(qs.JobComponentNumber) Then Me.CurrJobCompNum = CType(qs.JobComponentNumber, Integer)
        If IsNumeric(qs.EstimateNumber) Then Me.EstNum = CType(qs.EstimateNumber, Integer)
        If IsNumeric(qs.EstimateComponentNumber) Then Me.EstComp = CType(qs.EstimateComponentNumber, Integer)

        Me.FromPage = qs.Get("from")
        Me.CurrTemplate = qs.Get("tmplt")

        'If Request.QueryString("from") = "estimate" Then
        '    Me.getEstimateDefaults()
        'End If

        If Request.QueryString("from") = "jobrequest" Then
            If IsNumeric(Request.QueryString("JobVerHdrID")) Then
                JobVerHdrID = CInt(Request.QueryString("JobVerHdrID"))
            End If
            Me.lbJob.Visible = True
            Me.LabelJob.Visible = False
            Me.TxtJobNum.CssClass = "RequiredInput"

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then


        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("enableButton();")
            If Not Page.IsPostBack Then
                Me.cbCopyProjectSchedule.Checked = True

                'Me.btnCopyJob.Enabled = False
                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket)
                Me.SetProjectScheduleRequirement()

                BindDropTemplates()

                If Me.CurrTemplate <> "" Then
                    Me.RadComboBoxJobTemplate.SelectedValue = Me.CurrTemplate
                End If

                If JobVerHdrID = 0 Then
                    LoadJob()
                End If

                SetLookUps()

                If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.ProjectManagement.LoadLabelsFromJobTemplate(DbContext, Me.RadComboBoxJobTemplate.SelectedItem.Value,
                                                                               Nothing, Me.LabelClient.Text, Me.LabelDivision.Text, Me.LabelProduct.Text,
                                                                               Me.hlAE.Text, Me.LabelSalesClass.Text, Nothing, Me.HyperLinkJobType.Text)

                        Me.LabelClient.Text &= ":"
                        Me.LabelDivision.Text &= ":"
                        Me.LabelProduct.Text &= ":"
                        Me.hlAE.Text &= ":"
                        Me.LabelSalesClass.Text &= ":"
                        Me.HyperLinkJobType.Text &= ":"

                        Me.HlClientSource.Text = Me.LabelClient.Text
                        Me.HlDivisionSource.Text = Me.LabelDivision.Text
                        Me.HlProductSource.Text = Me.LabelProduct.Text
                        Me.HlJobTypeSource.Text = Me.HyperLinkJobType.Text

                    End Using

                End If


                If JobVerHdrID = 0 Then
                    Me.TxtJobSource.Text = CurrJobNum
                    Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAE.ClientID & "&type=accountexec&client=" & CurrClient & "&division=" & CurrDivision & "&product=" & CurrProduct & "&job=&jobcomp=');return false;")
                Else
                    Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAE.ClientID & "&type=accountexec&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
                End If

                If Me.TxtJobSource.Text <> "" Then

                    loadjobdefaults()

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

                End If

                If Me.ProjectSheduleRequired = True Then

                    Me.cbCopyProjectSchedule.Checked = True
                    Me.cbCopyProjectSchedule.Enabled = False

                    Me.CheckBoxCreateSchedule.Checked = True
                    Me.CheckBoxCreateSchedule.Enabled = False

                    Me.LabelStatusCopy.Visible = False
                    Me.LabelTrafficManager.Visible = False

                    Me.TextBoxTrafficScheduleStatus.CssClass = "RequiredInput"
                    Me.txtStatusCopy.CssClass = "RequiredInput"

                End If

                If Me.cbCopyProjectSchedule.Checked = False Then
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

                'Me.TrCopyJobProjectScheduleDate.Visible = Me.cbCopyProjectSchedule.Checked
                'Me.TrCopyJobProjectScheduleStatus.Visible = Me.cbCopyProjectSchedule.Checked
                'Me.TrCopyTrafficManager.Visible = Me.cbCopyProjectSchedule.Checked

                'Me.TableCopyFromExistingJob.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked

                Me.GetProjectScheduleDefaults()

                For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.CopyOptions))

                    CheckBoxListCopyOptions.Items.Add(New System.Web.UI.WebControls.ListItem(EnumObject.Description, EnumObject.Code))

                Next

                CheckBoxListCopyOptions.Items.FindByText("Include Task Employee(s)").Selected = True
                CheckBoxListCopyOptions.Items.FindByText("Include Task Comment").Selected = True

                Me.LoadBoards()

            End If

            'This has to be called on every load
            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridJobCopyComponent)


            CheckUserRights()

            If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

                CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

            End If

        Catch ex As Exception

            Me.ShowMessage("Error loading page:  " &
                         AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

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

        If JobVerHdrID > 0 Then
            LoadJobRequestDefaults()
        End If



    End Sub

#End Region

#Region " Controls "

    Protected Sub BtnSaveComponent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveComponent.Click
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Try
            If JobVerHdrID > 0 Then
                If Me.TxtJobNum.Text.Trim <> "" Then

                    If IsNumeric(Me.TxtJobNum.Text.Trim) = False Then

                        Me.ShowMessage("Job invalid")
                        Exit Sub

                    End If
                    If myVal.ValidateJobNumber(Me.TxtJobNum.Text) = False Then

                        Me.ShowMessage("Job does not exist")
                        Exit Sub

                    End If
                    If myVal.ValidateJobIsViewable(Session("Usercode"), Me.TxtJobNum.Text.Trim) = False Then

                        Me.ShowMessage("Access to this Job is denied")
                        Exit Sub

                    End If

                    Dim job As AdvantageFramework.Database.Entities.Job = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.TxtJobNum.Text)
                        If Me.txtClient.Text <> job.ClientCode And Me.txtDivision.Text <> job.DivisionCode And Me.txtDivision.Text <> job.ProductCode Then

                            Me.ShowMessage("This Job/Comp does not exist for selected Client/Division/Product")
                            Exit Sub

                        End If
                    End Using

                Else

                    Me.ShowMessage("Please enter a valid job number.")
                    Exit Sub

                End If

                CurrJobNum = Me.TxtJobNum.Text

            End If
        Catch ex As Exception

        End Try
        Try
            Using MyConn As New SqlConnection(Session("ConnString"))
                Dim i As Integer = 0
                MyConn.Open()
                Dim MyCmd As New SqlCommand("SELECT COUNT(1) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = " & CurrJobNum & ";", MyConn)
                Try
                    i = CType(MyCmd.ExecuteScalar, Integer)
                Catch ex As Exception
                    'Me.lblMSG.Text = "Error with find and replace SQL execution:<br /><br />" & ex.Message.ToString()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
                If i >= 999 Then
                    Me.ShowMessage("A job can have a maximum of 999 components.")
                    'Me.lblMSG.Text = "A job can have a maximum of 99 components"
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
        End Try
        Try
            Dim NewCompNum As Integer = 0

            'Save new comp
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            'validate AE!
            Dim oVal As New cValidations(Session("ConnString"))
            Dim oJob As Job = New Job(CStr(Session("ConnString")))
            Dim s As New cSchedule()
            Dim ae As String

            oJob.GetJob(CurrJobNum, 1)
            CurrClient = oJob.CL_CODE
            CurrDivision = oJob.DIV_CODE
            CurrProduct = oJob.PRD_CODE

            If oVal.ValidateAccountExecutive(CurrClient, CurrDivision, CurrProduct, Me.txtAE.Text) = False Then

                Me.ShowMessage("Invalid Account Executive.")
                Exit Sub

            End If

            Me.SetProjectScheduleRequirement()

            If Me.CheckBoxCreateSchedule.Checked = True Then

                Dim v As New cValidations(Session("ConnString"))
                If Me.TextBoxTrafficScheduleStatus.Text.Trim() = "" Then

                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Me.TextBoxTrafficScheduleStatus.Focus()
                    Exit Sub

                Else

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

            If Me.CheckBoxOverride.Checked = True And Me.txtCompDesc.Text = "" Then
                Me.ShowMessage("Component Description is required!")
                Exit Sub
            End If

            If Me.CheckBoxOverride.Checked = False And Me.JobVerHdrID = 0 Then
                Me.txtCompDesc.Text = "Component Description"
            End If



            NewCompNum = MyJobTemplate.AddNewComponentBase(CurrJobNum, Me.txtAE.Text, Me.txtCompDesc.Text, Me.RadComboBoxJobTemplate.SelectedValue, Me.TextBoxJobType.Text, _Session.UserCode)

            If NewCompNum > 0 Then

                If Me.CheckBoxCreateSchedule.Checked = True Then

                    Dim str As String = ""
                    If s.QuickAddScheduleHeader(CurrJobNum, NewCompNum, Me.TextBoxTrafficScheduleStatus.Text, Me.TextBoxTrafficManager.Text, _Session.UserCode, str) = False Then

                        If str.Trim <> "" Then Me.ShowMessage(str)

                    End If

                End If

                If EstNum > 0 And EstComp > 0 Then

                    est.UpdateJobEstimate(CurrJobNum, NewCompNum, EstNum, EstComp)

                End If

                Dim SQL_STRING As String

                If JobVerHdrID <> 0 Then
                    SQL_STRING = "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET JOB_NUMBER = '" & CurrJobNum & "',  JOB_COMPONENT_NBR = '" & NewCompNum & "', JOB_VER_SEQ_NBR = 1 WHERE JOB_VER_HDR_ID = " & Me.JobVerHdrID.ToString() & ";"

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
                                ar.JobNumber = CurrJobNum
                                ar.JobComponentNumber = NewCompNum
                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, ar)

                                If ar.AlertAttachments.Count > 0 Then
                                    For Each AlertAttachment In ar.AlertAttachments
                                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)
                                        If Document IsNot Nothing Then
                                            JobCompDocument = New AdvantageFramework.Database.Entities.JobComponentDocument
                                            JobCompDocument.DbContext = DbContext
                                            JobCompDocument.DocumentID = Document.ID
                                            JobCompDocument.JobComponentNumber = NewCompNum
                                            JobCompDocument.JobNumber = CurrJobNum
                                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                                AdvantageFramework.Database.Procedures.JobComponentDocument.Insert(DataContext, JobCompDocument)
                                            End Using
                                        End If
                                    Next
                                End If
                            Next

                        End If

                        Dim jv As New JobVersion(Session("ConnString"))
                        jv.UpdateJobTemplatePerJVMapping(Me.JobVerHdrID, "jobcomp")

                        Me.RefreshJobRequestObjects("DesktopMyJobRequests")
                        Me.RefreshJobRequestObjects("DesktopJobRequests")

                    End Using

                End If

                If Me.RadListBoxBoards.Visible = True AndAlso
                    Me.RadListBoxBoards.CheckedItems.Count > 0 Then

                    Dim AgileController As New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)
                    Dim ErrorMessages As Generic.List(Of String)
                    Dim ErrorMessage As String = String.Empty

                    If AgileController IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            For Each Item As RadListBoxItem In Me.RadListBoxBoards.CheckedItems

                                If AgileController.AddJobToBoard(DbContext, Item.Value, CurrJobNum, NewCompNum, ErrorMessage) = False Then

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        ErrorMessages.Add(ErrorMessage)
                                        ErrorMessage = String.Empty

                                    End If

                                End If

                            Next

                        End Using

                    End If

                End If


                'redirect back
                If Me.CurrentQuerystring.IsJobDashboard = True Then
                    MiscFN.ResponseRedirect("Content.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & NewCompNum & "&NewComp=new", True)
                Else
                    Me.CloseThisWindowAndOpenNewWindow("Content.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & NewCompNum & "&NewComp=new", True)
                End If

            End If

        Catch ex As Exception
            Me.ShowMessage("Error saving component:  " & ex.Message.ToString())
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            'Dim LastComp As String = Session("NewCompJobCompNum")
            Session("NewCompJobCompNum") = "0"
            If CurrJobCompNum = 0 Then
                Me.CloseThisWindow()
            Else
                MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & CurrJobCompNum & "&NewComp=0")
            End If
        Catch ex As Exception
            MiscFN.ResponseRedirect("JobTemplate.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & CurrJobCompNum & "&NewComp=0")
        End Try
    End Sub
    Private Sub RadGridJobCopy_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobCopyComponent.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            If e.CommandName = "RowClick" Then
                Dim chk As CheckBox
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        Me.txtCompDesc.Text = gridDataItem("colJOB_COMP_DESC").Text
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim Compbudget As Decimal = 0
    Dim SelectedCompBudget As Decimal = 0
    Dim sumBudgetTotal As Decimal = CType(0.0, Decimal)
    Private Sub RadGridJobCopy_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobCopyComponent.ItemDataBound
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
    Private Sub RadGridJobCopy_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobCopyComponent.NeedDataSource
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
                        Me.RadGridJobCopyComponent.DataSource = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
                    End If
                End Using
            Else
                Me.RadGridJobCopyComponent.DataSource = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
            End If

            Me.SetGridSort("Job")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobCopy_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridJobCopyComponent.ItemCreated
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
            Dim row As Integer = 0
            Dim count As Integer = 0
            Dim compbudget As Decimal = 0
            Dim compbudgettotal As Decimal = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items
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

                    rtb.Text = compbudget
                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.00
                End If

                If Me.txtCompDesc.Text = "" And row = 0 Then
                    Me.txtCompDesc.Text = gridDataItem("Description").Text
                End If

                row += 1

            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopyComponent.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), RadNumericTextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)

            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal + CDec(LabelBudget.Text))

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridRowSelectAllChanged()

        Try
            Dim chkbox As CheckBox
            Dim textbox As TextBox
            Dim rtb As RadNumericTextBox
            Dim textbox2 As TextBox
            Dim row As Integer = 0
            Dim count As Integer = 0
            Dim compbudget As Decimal = 0
            Dim compbudgettotal As Decimal = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items
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

                    rtb.Text = compbudget
                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.00
                End If

                If Me.txtCompDesc.Text = "" And row = 0 Then
                    Me.txtCompDesc.Text = gridDataItem("Description").Text
                End If

                row += 1

            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopyComponent.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), RadNumericTextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)

            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal + CDec(LabelBudget.Text))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridRowSelectionChanged()

        Try
            Dim chkbox As CheckBox
            Dim textbox As TextBox
            Dim textbox2 As TextBox
            Dim rtb As RadNumericTextBox
            Dim count As Integer = 0
            Dim row As Integer = 0
            Dim compbudget As Decimal = 0
            Dim compbudgettotal As Decimal = 0
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items
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

                    rtb.Text = compbudget
                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.000

                End If

                JavascriptArrayBudget &= "try { JavascriptArrayBudget[" & row & "] = document.getElementById('" & rtb.ClientID & "').value; }catch(err){}" & Environment.NewLine
                row += 1

                If Me.txtCompDesc.Text = "" And row = 1 Then
                    Me.txtCompDesc.Text = gridDataItem("Description").Text
                End If

            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopyComponent.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), RadNumericTextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)

            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal + CDec(LabelBudget.Text))

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
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items
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

                    rtb.Text = compbudget
                    count = 0
                Else
                    rtb = gridDataItem.FindControl("TextBoxSelectedBudget")
                    rtb.Text = 0.000

                End If

                JavascriptArrayBudget &= "try { JavascriptArrayBudget[" & row & "] = document.getElementById('" & rtb.ClientID & "').value; }catch(err){}" & Environment.NewLine
                row += 1

                If Me.txtCompDesc.Text = "" And row = 1 Then
                    Me.txtCompDesc.Text = gridDataItem("Description").Text
                End If

            Next

            Dim gridfooteritem As GridFooterItem = RadGridJobCopyComponent.MasterTableView.GetItems(GridItemType.Footer)(0)
            'gridfooteritem("colTextBoxSelectedBudget").Text = compbudgettotal
            CType(gridfooteritem.FindControl("TextBoxSumSelectedBudget"), RadNumericTextBox).Text = String.Format("{0:#,##0.00}", compbudgettotal)

            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", compbudgettotal + CDec(LabelBudget.Text))

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCopyJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopyJob.Click
        Dim i As Integer = 0
        Dim IncludeStartDate As Boolean = False
        Dim IncludeDueDate As Boolean = False
        Dim IncludeTaskEmployees As Boolean = False
        Dim IncludeTaskComment As Boolean = False
        Dim IncludeDueDateComment As Boolean = False
        Dim ScheduleTemplate As Boolean = False
        Dim IncludeTaskStatus As Boolean = False
        Dim SQL_STRING As String

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Try
            If JobVerHdrID > 0 Then
                If Me.TxtJobNum.Text.Trim <> "" Then

                    If IsNumeric(Me.TxtJobNum.Text.Trim) = False Then

                        Me.ShowMessage("Job invalid")
                        Exit Sub

                    End If
                    If myVal.ValidateJobNumber(Me.TxtJobNum.Text) = False Then

                        Me.ShowMessage("Job does not exist")
                        Exit Sub

                    End If
                    If myVal.ValidateJobIsViewable(Session("Usercode"), Me.TxtJobNum.Text.Trim) = False Then

                        Me.ShowMessage("Access to this Job is denied")
                        Exit Sub

                    End If

                    Dim job As AdvantageFramework.Database.Entities.Job = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.TxtJobNum.Text)
                        If Me.txtClient.Text <> job.ClientCode And Me.txtDivision.Text <> job.DivisionCode And Me.txtDivision.Text <> job.ProductCode Then

                            Me.ShowMessage("This Job/Comp does not exist for selected Client/Division/Product")
                            Exit Sub

                        End If
                    End Using

                Else

                    Me.ShowMessage("Please enter a valid job number.")
                    Exit Sub

                End If

                CurrJobNum = Me.TxtJobNum.Text

            End If
        Catch ex As Exception

        End Try

        Try
            Using MyConn As New SqlConnection(Session("ConnString"))
                MyConn.Open()
                Dim MyCmd As New SqlCommand("SELECT COUNT(1) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = " & CurrJobNum & ";", MyConn)
                Try
                    i = CType(MyCmd.ExecuteScalar, Integer)
                Catch ex As Exception
                    'Me.lblMSG.Text = "Error with find and replace SQL execution:<br /><br />" & ex.Message.ToString()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
                If i >= 999 Then
                    Me.ShowMessage("A job can have a maximum of 999 components.")
                    'Me.lblMSG.Text = "A job can have a maximum of 99 components"
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
        End Try

        Dim oJob As cJobs = New cJobs(CStr(Session("ConnString")))
        Dim jt As Job_Template = New Job_Template(Session("ConnString"))
        Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
        Dim JobNo As Integer
        Dim ReturnMessage As String
        Dim TemplateEnabled As Boolean = False
        Dim NewCompNum As Integer = 0
        Dim template As String = ""

        Try
            'ST:
            rfvComponentDesc.Enabled = False

            Page.Validate()

            rfvComponentDesc.Enabled = True

            If Not Page.IsValid Then

                'objects
                Dim ErrMsg As String = ""
                For Each Validator In Validators.OfType(Of IValidator)

                    If Validator.IsValid = False Then

                        ErrMsg &= Validator.ErrorMessage & "<br/>"

                    End If

                Next

                Me.ShowMessage(ErrMsg)

            End If

            If Not Page.IsValid Then Exit Sub
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            'validate AE!
            Dim oJobs As Job = New Job(CStr(Session("ConnString")))
            Dim s As New cSchedule()
            Dim ae As String
            oJobs.GetJob(CurrJobNum, 1)
            CurrClient = oJobs.CL_CODE
            CurrDivision = oJobs.DIV_CODE
            CurrProduct = oJobs.PRD_CODE

            If myVal.ValidateAccountExecutive(CurrClient, CurrDivision, CurrProduct, Me.txtAE.Text) = False Then

                Me.ShowMessage("Invalid Account Executive.")
                Exit Sub

            End If

            Me.SetProjectScheduleRequirement()

            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False
            Dim IsManagerRequired As Boolean = False

            Dim val As String = IsRequiredWebMethod(Me.RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text)

            Dim ar() As String

            ar = val.Split("|")

            IsCampaignRequired = ar(0).ToString() = "true"
            IsJobTypeRequired = ar(1).ToString() = "true"
            IsManagerRequired = ar(2).ToString() = "true"

            If Me.cbCopyProjectSchedule.Checked = True Then

                If Me.txtStatusCopy.Text.Trim() = "" Then

                    Me.ShowMessage("Invalid Project Schedule Status.")
                    Me.txtStatusCopy.Focus()
                    Exit Sub

                End If

                If Me.txtStatusCopy.Text <> "" Then

                    If myVal.ValidateTrafficStatus(Me.txtStatusCopy.Text) = False Then

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

                If Me.TextBoxCopyTrafficManager.Text.Trim() <> "" Then

                    If myVal.ValidateEmpCodetd(Me.TextBoxCopyTrafficManager.Text.Trim()) = False Then

                        Me.ShowMessage("Invalid " & s.GetManagerLabel & " code.")
                        Exit Sub

                    End If

                End If

            End If

            'If Me.CheckBoxCreateSchedule.Checked = True Then

            '    If Me.TextBoxTrafficScheduleStatus.Text.Trim() = "" Then

            '        Me.ShowMessage("Invalid Project Schedule Status.")
            '        Me.TextBoxTrafficScheduleStatus.Focus()
            '        Exit Sub

            '    End If

            '    Dim v As New cValidations(Session("ConnString"))
            '    If Me.TextBoxTrafficScheduleStatus.Text.Trim() <> "" Then

            '        If v.ValidateTrafficStatus(Me.TextBoxTrafficScheduleStatus.Text) = False Then

            '            Me.ShowMessage("Invalid Project Schedule Status.")
            '            Me.TextBoxTrafficScheduleStatus.Focus()
            '            Exit Sub

            '        End If

            '    End If

            '    If Me.TextBoxTrafficManager.Text.Trim() <> "" Then

            '        If v.ValidateEmpCodetd(Me.TextBoxTrafficManager.Text.Trim()) = False Then

            '            Me.ShowMessage("Invalid " & s.GetManagerLabel & " code.")
            '            Exit Sub

            '        End If

            '    End If

            'End If

            If Me.CheckBoxOverride.Checked = True And Me.txtCompDesc.Text = "" Then
                Me.ShowMessage("Component Description is required!")
                Exit Sub
            End If

            Dim chkbox As CheckBox
            Dim tb As TextBox
            Dim items As Boolean = False
            Dim itemsCount As Integer = 0
            Dim cp As Integer = 0
            Dim count As Integer = 1

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items

                chkbox = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

                If chkbox.Checked = True Then

                    cp = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")
                    tb = gridDataItem.FindControl("TextBoxDuplicate")
                    If tb.Text <> "" AndAlso IsNumeric(tb.Text) = True Then
                        itemsCount += CInt(tb.Text)
                    Else
                        itemsCount += 1
                    End If
                    items = True

                End If

            Next

            If items = False Then

                Me.ShowMessage("No Components Selected for Copy.")
                Exit Sub

            End If

            If itemsCount + i > 999 Then
                Me.ShowMessage("A job can have a maximum of 999 components")
                Exit Sub
            End If

            Dim chk As CheckBox
            Dim ComponentNumberToCopy As Integer = 0
            Dim desc As String = ""
            Dim NewComponentNumber As Integer = 0
            Dim save As Boolean
            Dim ct As Integer = 0
            Dim ComponentCopy As Integer = 0
            Dim SelectedBudget As Decimal = 0

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobCopyComponent.MasterTableView.Items

                Dim ScheduleCreated As Boolean = False

                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                tb = gridDataItem.FindControl("TextBoxDuplicate")

                If chk.Checked = True Then

                    Try

                        ComponentNumberToCopy = CInt(gridDataItem("Component").Text.Replace("&nbsp;", ""))
                        desc = DirectCast(gridDataItem.FindControl("TextBoxJobComponentDescription"), TextBox).Text
                        'desc = gridDataItem("Description").Text.Replace("&nbsp;", "")
                        ct += 1

                    Catch ex As Exception
                        ComponentNumberToCopy = 0
                    End Try

                    Try

                        SelectedBudget = CDec(DirectCast(gridDataItem.FindControl("TextBoxSelectedBudget"), RadNumericTextBox).Text)

                    Catch ex As Exception

                        SelectedBudget = 0

                    End Try

                    If ComponentNumberToCopy > 0 Then
                        ComponentCopy += 1
                    End If

                    If Me.txtCompDesc.Text = "" Then
                        Me.txtCompDesc.Text = "Component Description"
                    End If

                    If Me.txtCompDesc.Text <> "" And ComponentCopy = 1 And Me.CheckBoxOverride.Checked = True Then

                        desc = Me.txtCompDesc.Text

                    End If

                    If desc = "" Then
                        desc = "Component Description"
                    End If

                    Dim c As String = gridDataItem.GetDataKeyValue("JOB_COMPONENT_NBR")

                    template = Me.RadComboBoxJobTemplate.SelectedValue 'jt.GetTemplateCode(Me.TxtJobSource.Text, comp)

                    If tb.Text <> "" Then
                        count = tb.Text
                    Else
                        count = 1
                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        For w As Integer = 0 To count - 1

                            If ct > 1 Then

                                If Me.cbCopyProjectSchedule.Checked = True Then

                                    GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ScheduleTemplate, IncludeTaskStatus)

                                    NewComponentNumber = oJob.CreateNewJobComponentCopy(CurrJobNum, Me.TxtJobSource.Text, ComponentNumberToCopy, desc, IncludeStartDate, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                Else

                                    NewComponentNumber = oJob.CreateNewJobComponentCopy(CurrJobNum, Me.TxtJobSource.Text, ComponentNumberToCopy, desc, True, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                End If

                            Else 'When would it ever jump into here???

                                If Me.cbCopyProjectSchedule.Checked = True Then

                                    GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ScheduleTemplate, IncludeTaskStatus)

                                    NewComponentNumber = oJob.CreateNewJobComponentCopy(CurrJobNum, Me.TxtJobSource.Text, ComponentNumberToCopy, desc, IncludeStartDate, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                Else

                                    NewComponentNumber = oJob.CreateNewJobComponentCopy(CurrJobNum, Me.TxtJobSource.Text, ComponentNumberToCopy, desc, True, False, ReturnMessage, template, Me.TextBoxJobType.Text, Me.txtAE.Text, SelectedBudget, _Session.UserCode)

                                End If

                            End If
                            If NewComponentNumber > 0 Then

                                If Me.cbCopyCreativeBrief.Checked = True Then

                                    save = oJob.CopyCreativeBrief(Me.TxtJobSource.Text, ComponentNumberToCopy, CurrJobNum, NewComponentNumber)

                                End If
                                If Me.cbCopySpecs.Checked = True Then

                                    save = oJob.CopyJobSpecs(Me.TxtJobSource.Text, ComponentNumberToCopy, CurrJobNum, NewComponentNumber)

                                    If save = False Then

                                        Me.ShowMessage("Error saving job specs.")
                                        Exit Sub

                                    End If

                                End If
                                If Me.cbCopyProjectSchedule.Checked = True Then

                                    GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, ScheduleTemplate, IncludeTaskStatus)

                                    save = oJob.CopyProjectSchedule(Me.TxtJobSource.Text, ComponentNumberToCopy, CurrJobNum, NewComponentNumber, Me.txtStatusCopy.Text, IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment, Me.TextBoxCopyTrafficManager.Text.Trim(), ScheduleTemplate, IncludeTaskStatus)

                                    If save = False Then

                                        Me.ShowMessage("Error saving project schedule.")

                                    Else

                                        ScheduleCreated = True

                                    End If

                                    If ScheduleCreated = False Then

                                        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                        Dim x As Integer = oTrafficSchedule.CheckExistsClosed(CurrJobNum, NewComponentNumber)
                                        If x = -1 Then

                                            Dim str As String = ""

                                            If s.QuickAddScheduleHeader(CurrJobNum, NewComponentNumber, Me.txtStatusCopy.Text, Me.TextBoxCopyTrafficManager.Text, _Session.UserCode, str) = False Then

                                                If str.Trim <> "" Then Me.ShowMessage(str)

                                            Else

                                                ScheduleCreated = True

                                            End If

                                        End If

                                    End If

                                End If
                                If Me.CheckBoxCreateSchedule.Checked = True AndAlso ScheduleCreated = False Then

                                    Dim str As String = ""

                                    If s.QuickAddScheduleHeader(JobNo, NewComponentNumber, Me.TextBoxTrafficScheduleStatus.Text, Me.TextBoxTrafficManager.Text, _Session.UserCode, str) = False Then

                                        If str.Trim <> "" Then Me.ShowMessage(str)

                                    End If

                                End If
                                If JobVerHdrID <> 0 Then

                                    SQL_STRING = "UPDATE JOB_VER_HDR WITH(ROWLOCK) SET JOB_NUMBER = '" & CurrJobNum & "',  JOB_COMPONENT_NBR = '" & NewComponentNumber & "', JOB_VER_SEQ_NBR = 1 WHERE JOB_VER_HDR_ID = " & Me.JobVerHdrID.ToString() & ";"

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

                                            alert.JobNumber = CurrJobNum
                                            alert.JobComponentNumber = NewComponentNumber
                                            AdvantageFramework.Database.Procedures.Alert.Update(DbContext, alert)

                                        Next

                                    End If

                                    Dim jv As New JobVersion(Session("ConnString"))
                                    jv.UpdateJobTemplatePerJVMapping(Me.JobVerHdrID, "jobcomp")

                                    Me.RefreshJobRequestObjects("DesktopMyJobRequests")
                                    Me.RefreshJobRequestObjects("DesktopJobRequests")

                                End If

                                If Me.cbCopyDestinations.Checked = True Then

                                End If

                                Try

                                    If Me.CheckBoxJobCompDocumentAssociations.Checked AndAlso IsNumeric(Me.TxtJobSource.Text) = True AndAlso ComponentNumberToCopy > 0 AndAlso NewComponentNumber > 0 Then

                                        Try

                                            Dim newjob As New JobComponentDocuments(Session("ConnString"))
                                            Dim oldjob As New JobComponentDocuments(Session("ConnString"))
                                            Dim Document As New Document(Session("ConnString"))
                                            Dim privateflag As Integer = 0

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
                                                            newjob.Add(CurrJobNum, NewComponentNumber, Document.FILENAME, Document.MIME_TYPE, Document.REPOSITORY_FILENAME, Document.FILE_SIZE, Document.USER_CODE, Document.DESCRIPTION, Document.KEYWORDS, privateflag, Document.DOCUMENT_TYPE_ID)
                                                        End If
                                                        oldjob.MoveNext()
                                                    Loop
                                                End If
                                            End If


                                        Catch ex As Exception

                                        End Try

                                        'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                        '    Dim CopySQL As String = String.Format("INSERT INTO JOB_COMPONENT_DOCUMENTS (DOCUMENT_ID, JOB_NUMBER, JOB_COMPONENT_NUMBER) SELECT DOCUMENT_ID, {0}, {1} FROM JOB_COMPONENT_DOCUMENTS WHERE JOB_NUMBER = {2} AND JOB_COMPONENT_NUMBER = {3};",
                                        '                                          CurrJobNum, NewComponentNumber, Me.TxtJobSource.Text, ComponentNumberToCopy)

                                        '    DataContext.ExecuteCommand(CopySQL)

                                        'End Using

                                    End If

                                Catch ex As Exception
                                End Try

                                If Me.RadListBoxBoards.Visible = True AndAlso Me.RadListBoxBoards.CheckedItems.Count > 0 Then

                                    Dim AgileController As New AdvantageFramework.Controller.ProjectManagement.AgileController(Me.SecuritySession)
                                    Dim ErrorMessages As Generic.List(Of String)
                                    Dim ErrorMessage As String = String.Empty

                                    If AgileController IsNot Nothing Then

                                        For Each Item As RadListBoxItem In Me.RadListBoxBoards.CheckedItems

                                            If AgileController.AddJobToBoard(DbContext, Item.Value, CurrJobNum, NewComponentNumber, ErrorMessage) = False Then

                                                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                    ErrorMessages.Add(ErrorMessage)
                                                    ErrorMessage = String.Empty

                                                End If

                                            End If

                                        Next

                                    End If

                                End If

                            End If

                        Next

                    End Using

                End If

            Next

            'If Me.CurrentQuerystring.IsJobDashboard = True Then
            '    MiscFN.ResponseRedirect("Content.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & newComp & "&NewComp=new", True)
            'Else
            '    Me.CloseThisWindowAndOpenNewWindow("Content.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & newComp & "&NewComp=new")
            'End If

            Me.btnCopyJob.Enabled = False

            Me.CloseThisWindowAndOpenNewWindow("Content.aspx?PageMode=Edit&JobNum=" & CurrJobNum & "&JobCompNum=" & NewComponentNumber & "&NewComp=new", True)

        Catch ex As Exception
            'Me.lblMsgCopy.Text = Err.Description
        End Try
    End Sub
    Private Sub btnComps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComps.Click
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim job As New Job_Template(Session("ConnString"))
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
                Me.RadGridJobCopyComponent.Rebind()
                Exit Sub
            End If
        End If
        If myVal.ValidateJobIsViewableCDP(Session("UserCode"), Me.TxtJobSource.Text) = False Then
            Me.ShowMessage("Access to this job is denied.")
            Exit Sub
        End If
        Dim dt As DataTable = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
        If dt.Rows.Count > 0 Then
            If Me.txtCompDesc.Text = "" Then
                Me.txtCompDesc.Text = dt.Rows(0)("JOB_COMP_DESC")
            End If
        End If
        Me.loadjobdefaults()
        Me.RadGridJobCopyComponent.Rebind()

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
    Private Sub cbCopyProjectSchedule_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCopyProjectSchedule.CheckedChanged

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
    Private Sub cbShowClosed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowClosed.CheckedChanged
        Me.SetLookUps()
    End Sub
    Private Sub CheckBoxShowCopyFromExistingJob_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxShowCopyFromExistingJob.CheckedChanged

        'Me.TableCopyFromExistingJob.Visible = Me.CheckBoxShowCopyFromExistingJob.Checked

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

    End Sub
    Private Sub RadGridJobCopy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridJobCopyComponent.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtJobSource_TextChanged(sender As Object, e As EventArgs) Handles TxtJobSource.TextChanged
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim job As New Job_Template(Session("ConnString"))
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
                    Me.RadGridJobCopyComponent.Rebind()
                    Exit Sub
                End If
            End If
            If myVal.ValidateJobIsViewableCDP(Session("UserCode"), Me.TxtJobSource.Text) = False Then
                Me.ShowMessage("Access to this job is denied.")
                Exit Sub
            End If
            Dim dt As DataTable = job.GetInfoForJobCopy(Me.TxtJobSource.Text, Me.cbShowClosed.Checked, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                If Me.txtCompDesc.Text = "" Then
                    Me.txtCompDesc.Text = dt.Rows(0)("JOB_COMP_DESC")
                End If
            End If
            Me.loadjobdefaults()
            Me.RadGridJobCopyComponent.Rebind()

            Me.BtnSaveComponent.Enabled = False
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
            'If CheckBoxOverride.Checked = True Then
            '    Me.txtCompDesc.Enabled = True
            'Else
            '    Me.txtCompDesc.Enabled = False
            'End If
        Else
            Me.BtnSaveComponent.Enabled = True
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
            'If CheckBoxOverride.Checked = True Then
            '    Me.txtCompDesc.Enabled = True
            'Else
            '    Me.txtCompDesc.Enabled = False
            'End If
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
            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", 0)
            'Me.LabelBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.RadGridJobCopyComponent.Rebind()
        End If


    End Sub
    Private Sub ButtonClearCopy_Click(sender As Object, e As EventArgs) Handles ButtonClearCopy.Click
        Try
            Me.BtnSaveComponent.Enabled = True
            Me.btnCopyJob.Enabled = False
            Me.txtCompDesc.Enabled = True
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
            Me.LabelSelectedBudget.Text = String.Format("{0:#,##0.00}", 0)
            'Me.LabelBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", 0)
            Me.RadGridJobCopyComponent.Rebind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadComboBoxJobTemplate_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxJobTemplate.SelectedIndexChanged

        If RadComboBoxJobTemplate.SelectedItem IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageFramework.ProjectManagement.LoadLabelsFromJobTemplate(DbContext, Me.RadComboBoxJobTemplate.SelectedItem.Value,
                                                                               Nothing, Me.LabelClient.Text, Me.LabelDivision.Text, Me.LabelProduct.Text,
                                                                               Me.hlAE.Text, Me.LabelSalesClass.Text, Nothing, Me.HyperLinkJobType.Text)

                Me.LabelClient.Text &= ":"
                Me.LabelDivision.Text &= ":"
                Me.LabelProduct.Text &= ":"
                Me.hlAE.Text &= ":"
                Me.LabelSalesClass.Text &= ":"
                Me.HyperLinkJobType.Text &= ":"

                Me.HlClientSource.Text = Me.LabelClient.Text
                Me.HlDivisionSource.Text = Me.LabelDivision.Text
                Me.HlProductSource.Text = Me.LabelProduct.Text
                Me.HlJobTypeSource.Text = Me.HyperLinkJobType.Text

            End Using

            CheckRequirements(RadComboBoxJobTemplate.SelectedItem.Value, Me.txtClient.Text.Trim, False)

        End If

    End Sub

    'Private Sub CheckBoxOverride_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOverride.CheckedChanged
    '    Try
    '        If CheckBoxOverride.Checked = True Then
    '            Me.txtCompDesc.Enabled = True
    '        Else
    '            Me.txtCompDesc.Enabled = False
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub
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
    Private Sub LoadJob()
        Try
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            Dim oJob As Job = New Job(CStr(Session("ConnString")))
            Dim ae As String
            oJob.GetJob(CurrJobNum, 1)
            CurrClient = oJob.CL_CODE
            CurrDivision = oJob.DIV_CODE
            CurrProduct = oJob.PRD_CODE
            ae = MyJobTemplate.GetDefaultAE(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
            If ae <> "" Then
                Me.txtAE.Text = ae
            End If
            'Me.TxtOffice.Text = oJob.OFFICE_CODE
            'Me.TextBoxOfficeDescription.Text
            Me.txtClient.Text = oJob.CL_CODE
            Me.TextBoxClientDescription.Text = oJob.ClientDesc
            Me.txtDivision.Text = oJob.DIV_CODE
            Me.TextBoxDivisionDescription.Text = oJob.DivisionDesc
            Me.txtProduct.Text = oJob.PRD_CODE
            Me.TextBoxProductDescription.Text = oJob.ProductDesc
            Me.TxtJobNum.Text = CurrJobNum.ToString.PadLeft(6, "0")
            Me.TextBoxJobDescription.Text = oJob.JOB_DESC
            Me.TextBoxSalesClass.Text = oJob.SC_CODE
            Me.TextBoxSalesClassDescription.Text = oJob.SalesClassDesc

            Me.LabelBudget.Text = String.Format("{0:#,##0.00}", oJob.TotalBudget)

        Catch ex As Exception
            Me.ShowMessage("Error loading job data:  " & ex.Message.ToString())
        End Try
    End Sub
    Private Sub SetLookUps()

        Dim oJob As Job = New Job(CStr(Session("ConnString")))
        oJob.GetJob(CurrJobNum, 1)
        CurrClient = oJob.CL_CODE
        CurrDivision = oJob.DIV_CODE
        CurrProduct = oJob.PRD_CODE
        Me.hlAE.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAE.ClientID & "&type=accountexec&client=" & CurrClient & "&division=" & CurrDivision & "&product=" & CurrProduct & "&job=&jobcomp=');return false;")

        Me.HlClientSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtClientSource.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value);return false;")
        Me.HlDivisionSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=schedule&control=" & Me.TxtDivisionSource.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value);return false;")
        Me.HlProductSource.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductSource.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtProductSource.ClientID & "&type=product&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value);return false;")

        Me.HyperLinkJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jtn1&control=" & Me.TextBoxJobType.ClientID & "&type=jobtype&salesclass=' + document.forms[0]." & Me.TextBoxSalesClass.ClientID & ".value + '&job=0');return false;")

        'Me.HlJobTypeSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jtn1&control=" & Me.TxtJobTypeSource.ClientID & "&type=jobtype&salesclass=' + document.forms[0]." & Me.TextBoxSalesClass.ClientID & ".value + '&job=0');return false;")
        Me.HlJobTypeSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobtype&control=" &
                                  Me.TxtJobTypeSource.ClientID & "&type=jobtype&job=' + document.forms[0]." & Me.TxtJobSource.ClientID & ".value);return false;")


        Me.hlStatusCopy.Attributes.Add("onclick", "FocusTB('" & Me.txtStatusCopy.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtStatusCopy.ClientID & "&type=statuscodes');return false;")
        If Me.cbShowClosed.Checked = True Then
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopycomp&type=jobcopy&checked=1&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value);return false;")
        Else
            Me.HlJobSource.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobcopycomp&type=jobcopy&client=' + document.forms[0]." & Me.TxtClientSource.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionSource.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductSource.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobTypeSource.ClientID & ".value);return false;")
        End If

        Me.HyperLinkStatus.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TextBoxTrafficScheduleStatus.ClientID & "&type=statuscodes');return false;")

        Dim s As New cSchedule()

        Me.HyperLinkCopyTrafficManager.Text = s.GetManagerLabel() & ":"
        Me.HyperLinkTrafficManager.Text = s.GetManagerLabel() & ":"

        Me.LabelTrafficManager.Text = s.GetManagerLabel() & ":"
        Me.LabelManager.Text = s.GetManagerLabel() & ":"
        Me.HyperLinkTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxTrafficManager.ClientID.ToString() & "');return false;")
        Me.HyperLinkCopyTrafficManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TextBoxCopyTrafficManager.ClientID.ToString() & "');return false;")

        If JobVerHdrID > 0 Then
            Me.lbJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?office=&salesclass=&form=jobrequestComp&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value);return false;")
        End If

    End Sub
    Private Sub SetGridSort(ByVal StrSort As String)
        Try
            Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression
            Select Case StrSort
                Case "Job"
                    GrpExpr = Telerik.Web.UI.GridGroupByExpression.Parse("JOB_NUMBER Job Group By JOB_NUMBER")
                    With Me.RadGridJobCopyComponent
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                        '.MasterTableView.GetColumn("colPHASE_DESC").Display = False
                    End With
                Case Else
                    Me.RadGridJobCopyComponent.MasterTableView.GroupByExpressions.Clear()
            End Select
            'Session("EstimateGridSort") = StrSort
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

                'Me.LabelBudget.Text = String.Format("{0:#,##0.00}", job.TotalBudget)
                Me.LabelSelectedBudget.Text = "0.00"
                Me.LabelProjectedBudget.Text = String.Format("{0:#,##0.00}", job.TotalBudget)

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
    Private Sub LoadJobRequestDefaults()
        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim job As Job_Template = New Job_Template(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = jv.GetJVRequestDescriptions(JobVerHdrID)
            If dr.HasRows Then
                dr.Read()
                'CDP
                If IsDBNull(dr("CL_CODE")) = False Then
                    Me.txtClient.Text = dr.GetString(0)
                End If
                If IsDBNull(dr("CL_NAME")) = False Then
                    Me.TextBoxClientDescription.Text = dr.GetString(1)
                End If
                If IsDBNull(dr("DIV_CODE")) = False Then
                    Me.txtDivision.Text = dr.GetString(2)
                End If
                If IsDBNull(dr("DIV_NAME")) = False Then
                    Me.TextBoxDivisionDescription.Text = dr.GetString(3)
                End If
                If IsDBNull(dr("PRD_CODE")) = False Then
                    Me.txtProduct.Text = dr.GetString(4)
                End If
                If IsDBNull(dr("PRD_DESCRIPTION")) = False Then
                    Me.TextBoxProductDescription.Text = dr.GetString(5)
                End If
                If IsDBNull(dr("JOB_VER_DESC")) = False Then
                    'Me.txtJobDesc.Text = dr.GetString(6)
                    Me.txtCompDesc.Text = dr.GetString(6)
                End If
            End If
            If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
                Me.txtAE.Text = job.GetDefaultAE(Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
            End If

            If Me.TxtJobNum.Text <> "" Then
                Dim oJob As Job = New Job(CStr(Session("ConnString")))
                Dim ae As String
                oJob.GetJob(Me.TxtJobNum.Text, 1)

                Me.TextBoxJobDescription.Text = oJob.JOB_DESC
                Me.TextBoxSalesClass.Text = oJob.SC_CODE
                Me.TextBoxSalesClassDescription.Text = oJob.SalesClassDesc
            End If

            Me.txtClient.ReadOnly = True
            Me.txtDivision.ReadOnly = True
            Me.txtProduct.ReadOnly = True
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
            Me.txtStatusCopy.Text = Me.DefaultStatusCode
            Me.TextBoxTrafficScheduleStatus.Text = Me.DefaultStatusCode
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

            Me.LabelStatusCopy.Visible = False
            Me.LabelTrafficManager.Visible = False

            Me.TextBoxTrafficScheduleStatus.CssClass = "RequiredInput"
            Me.txtStatusCopy.CssClass = "RequiredInput"

        Else

            Me.cbCopyProjectSchedule.Enabled = True
            Me.CheckBoxCreateSchedule.Enabled = True

            Me.TextBoxTrafficScheduleStatus.CssClass = Nothing
            Me.txtStatusCopy.CssClass = Nothing

        End If

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
                value = RadComboBoxJobTemplate.Items.Item(idx).Value
                If RadComboBoxJobTemplate.Items.Item(idx).Value = "DFLT" Then
                    found = True
                    RadComboBoxJobTemplate.SelectedIndex = idx
                    Dim JV As Job_Template = New Job_Template(Session("ConnString"))
                    Dim defSC As String
                    defSC = JV.GetTmpltDefSC(value)
                    'If Request.QueryString("from") <> "estimate" Then
                    '    Me.txtSalesClass.Text = defSC
                    'End If
                    Exit Sub
                End If
            Next
            If found = False Then   'jtg: Issue when user inactivates default template...
                RadComboBoxJobTemplate.SelectedIndex = 0
                value = RadComboBoxJobTemplate.Items.Item(0).Value
                Dim JV As Job_Template = New Job_Template(Session("ConnString"))
                Dim defSC As String
                defSC = JV.GetTmpltDefSC(value)
                'If Request.QueryString("from") <> "estimate" Then
                '    Me.txtSalesClass.Text = defSC
                'End If
            End If
        End If
    End Sub
    Private Function CheckRequirements(ByVal JobTemplateCode As String, ByVal ClientCode As String, ByVal IsSaving As Boolean) As Boolean

        Dim HasRequirements As Boolean = True

        Try

            Dim IsCampaignRequired As Boolean = False
            Dim IsJobTypeRequired As Boolean = False
            Dim IsManagerRequired As Boolean = False

            Dim val As String = JobTemplate_New.IsRequiredWebMethod(JobTemplateCode, ClientCode)

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

            End If
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
