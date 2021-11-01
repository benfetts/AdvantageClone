Imports Telerik.Web.UI

Partial Public Class TrafficSchedule_Search
    Inherits Webvantage.BaseChildPage


    Private SearchType As Integer = 1 ' 0 = single, 1 = multi, 2 = worksheet
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Private Office As String = ""
    Private SalesClass As String = ""
    Private CmpCode As String = ""
    Private JobType As String = ""
    Private AECode As String = ""
    Private rights As String
    Private dt As New DataTable
    Private _LoadingDatasource As Boolean = False

    Private Sub SetControls()
        Try

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub MultiWorksheetFilter_Show(ByVal ShowIt As Boolean)
        Me.Tr0.Visible = ShowIt
        Me.Tr1.Visible = ShowIt
        'Me.Tr2.Visible = ShowIt
        Me.Tr3.Visible = ShowIt
        'Me.Tr4.Visible = ShowIt
        Me.Tr5.Visible = ShowIt
        Me.Tr6.Visible = ShowIt
        Me.Tr7.Visible = ShowIt
        Me.Tr8.Visible = ShowIt
        Me.Tr9.Visible = ShowIt
        Me.Tr10.Visible = ShowIt
        Me.Tr11.Visible = ShowIt
        Me.Tr12.Visible = ShowIt
        Me.Tr13.Visible = ShowIt
        Me.Tr14.Visible = ShowIt
    End Sub

    Private Sub MultiWorksheetFilter_Reset()
        Me.TxtManager.Text = ""
        'Me.TxtAccountExecutive.Text = ""
        Me.ChkExcludeCompletedSchedules.Checked = True
        'Me.TxtCampaign.Text = ""
        Me.DropPhaseFilter.SelectedIndex = 0
        Me.ChkOnlyPendingTasks.Checked = False
        Me.TxtRole.Text = ""
        Me.ChkExcludeProjectedTasks.Checked = False
        Me.TxtTaskCode.Text = ""
        Me.ChkIncludeCompletedTasks.Checked = True
        Me.TxtEmployee.Text = ""
        Me.RadDatePickerDateCutoff.DateInput.Text = ""
    End Sub

    Private Sub SetControlFocus()
        Try
            'don't want to keep setting focus on different controls
            Dim CurrFocusControl As Integer = 0
            Dim AllBlank As Boolean = True
            If IsNumeric(Me.txtComponent.Text.Trim()) = False Then
                CurrFocusControl = 4
            Else
                If AllBlank = True Then AllBlank = False
            End If
            If IsNumeric(Me.txtJob.Text.Trim()) = False Then
                CurrFocusControl = 3
            Else
                If AllBlank = True Then AllBlank = False
            End If
            If Me.txtProduct.Text.Trim() = "" Then
                CurrFocusControl = 2
            Else
                If AllBlank = True Then AllBlank = False
            End If
            If Me.txtDivision.Text.Trim() = "" Then
                CurrFocusControl = 1
            Else
                If AllBlank = True Then AllBlank = False
            End If
            If Me.txtClient.Text.Trim() = "" Then
                CurrFocusControl = 0
            Else
                If AllBlank = True Then AllBlank = False
            End If



            If AllBlank = True Then
                Me.txtJob.Focus()
                Exit Sub
            End If
            Select Case CurrFocusControl
                Case 0
                    Me.txtClient.Focus()
                Case 1
                    Me.txtDivision.Focus()
                Case 2
                    Me.txtProduct.Focus()
                Case 3
                    Me.txtJob.Focus()
                Case 4
                    Me.txtComponent.Focus()
            End Select
        Catch ex As Exception
            Me.txtClient.Focus()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
        CheckUserRights()
        Me.PageTitle = "Find Project Schedule"
        Me.SetControls()

        Me.RadToolbarSearch.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        Try
            'clear sessions that belong to other traffic pages:
            Session("_ds") = Nothing 'holds the ds for single view
        Catch ex As Exception
        End Try
        If Not Me.Page.IsPostBack = True And Not Me.Page.IsCallback = True Then
            Try
                Me.LoadLookups()
                Me.SetQSVars()
                Me.SetControlFocus()
                Me.RblSelect.SelectedIndex = SearchType
            Catch ex As Exception
                Me.ShowMessage(ex.Message.ToString())
            End Try
            'Me.MultiWorksheetFilter_Reset()
            If Me.SearchType > 0 Then
                Me.MultiWorksheetFilter_Show(True)
            Else
                Me.MultiWorksheetFilter_Show(False)
            End If

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridProjectScheduleSearch)
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Schedule}

    End Sub
    Private Sub RunSearch()

        If IsNumeric(Me.txtJob.Text) = True Then Me.JobNum = CType(Me.txtJob.Text, Integer)
        If IsNumeric(Me.txtComponent.Text) = True Then Me.JobCompNum = CType(Me.txtComponent.Text, Integer)

        If Me.JobNum > 0 And Me.JobCompNum > 0 Then
            Me.RblSelect.SelectedIndex = 0
        End If
        Select Case Me.RblSelect.SelectedIndex 'single view, load grid
            Case 0
                If Me.ValidateSearch() = True Then
                    Me.RadGridProjectScheduleSearch.Rebind()
                End If
            Case 1 'multi
                Me.SearchMultiWorksheet("multi")
                'Case 2 'single
                '    Me.SearchMultiWorksheet("worksheet")
        End Select

    End Sub
    Private Sub RadToolbarSearch_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSearch.ButtonClick
        Try

            If IsNumeric(Me.txtJob.Text) = True Then Me.JobNum = CType(Me.txtJob.Text, Integer)
            If IsNumeric(Me.txtComponent.Text) = True Then Me.JobCompNum = CType(Me.txtComponent.Text, Integer)

            Select Case e.Item.Value
                Case "Search"

                    Me.RunSearch()

                Case "New"

                    'Me.OpenWindow("", "TrafficSchedule_AddNew.aspx?c=" & Me.Client & "&d=" & Me.Division & "&p=" & Me.Product & "&j=&jc=")
                    Me.OpenWindow("", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?ClientCode=" & Me.Client & "&DivisionCode=" & Me.Division & "&ProductCode=" & Me.Product)

                Case "Clear"
                    Me.txtOffice.Text = ""
                    Me.txtClient.Text = ""
                    Me.txtDivision.Text = ""
                    Me.txtProduct.Text = ""
                    Me.txtJob.Text = ""
                    Me.txtComponent.Text = ""
                    Me.TxtCampaign.Text = ""
                    Me.TxtManager.Text = ""
                    Me.TxtAccountExecutive.Text = ""
                    Me.TxtRole.Text = ""
                    Me.TxtTaskCode.Text = ""
                    Me.TxtEmployee.Text = ""
                    Me.txtSalesClass.Text = ""
                    Me.TextBoxJobType.Text = ""

                    Me.RadDatePickerDateCutoff.DateInput.Text = ""
                    Me.RadDatePickerDateCutoff.SelectedDate = Nothing

                    Me.ChkExcludeProjectedTasks.Checked = True
                    If Me.DropPhaseFilter.Items.Count > 0 Then
                        Me.DropPhaseFilter.SelectedIndex = 0
                    End If
                    Me.ChkOnlyPendingTasks.Checked = False
                    Me.ChkExcludeProjectedTasks.Checked = False
                    Me.ChkIncludeCompletedTasks.Checked = True
                    Me.CheckBoxOnlyScheduleTemplates.Checked = False

                    Me.JobNum = 0
                    Me.JobCompNum = 0
                    Me.RadGridProjectScheduleSearch.Rebind()

                Case "Bookmark"

                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                    Dim qs As New AdvantageFramework.Web.QueryString()

                    With qs

                        If RblSelect.SelectedValue = "single" Then

                            .Add("snglvw", "true")

                        Else

                            .Add("snglvw", "false")

                        End If

                        .OfficeCode = Me.txtOffice.Text
                        .ClientCode = Me.txtClient.Text
                        .DivisionCode = Me.txtDivision.Text
                        .ProductCode = Me.txtProduct.Text
                        .SalesClassCode = Me.txtSalesClass.Text
                        .CampaignCode = Me.TxtCampaign.Text

                        If IsNumeric(Me.txtJob.Text) = True Then
                            .JobNumber = Me.txtJob.Text
                        End If
                        If IsNumeric(Me.txtComponent.Text) = True Then
                            .JobComponentNumber = Me.txtComponent.Text
                        End If
                        .AccountExecutiveCode = Me.TxtAccountExecutive.Text
                        .ManagerCode = Me.TxtManager.Text

                        .IncludeCompletedSchedules = Not Me.ChkExcludeCompletedSchedules.Checked
                        .PhaseFilter = Me.DropPhaseFilter.SelectedValue.ToString()
                        .RoleCode = Me.TxtRole.Text
                        .TaskCode = Me.TxtTaskCode.Text
                        .EmployeeCode = Me.TxtEmployee.Text

                        If Me.RadDatePickerDateCutoff.SelectedDate IsNot Nothing Then

                            .CutOffDate = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()

                        End If

                        .IncludeOnlyPendingTasks = Me.ChkOnlyPendingTasks.Checked
                        .ExcludeProjectedTasks = Me.ChkExcludeProjectedTasks.Checked
                        .IncludeCompletedTasks = Me.ChkIncludeCompletedTasks.Checked

                        .Build()

                    End With

                    With b

                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule_Search
                        .UserCode = Session("UserCode")
                        .Name = "Custom Schedule search"
                        .PageURL = "TrafficSchedule_Search.aspx" & qs.ToString()

                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then

                        Me.ShowMessage(s)

                    Else

                        Me.RefreshBookmarksDesktopObject()

                    End If



            End Select
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try

    End Sub

    Private Function ValidateSearch() As Boolean
        If Me.ValidateInput = True Then

            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.txtJob.Text <> "" Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this job is denied.\n.")
                        Return False
                    End If
                End Using
            End If
            If Me.JobNum > 0 And Me.JobCompNum > 0 Then
                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(Me.JobNum, Me.JobCompNum)
                Select Case x
                    Case -1
                        Me.GoToNew()
                End Select
            End If
            Return True

        Else
            Return False
        End If
    End Function

    Private Function ValidateInput() As Boolean
        Me.Client = Me.txtClient.Text
        Me.Division = Me.txtDivision.Text
        Me.Product = Me.txtProduct.Text
        'validate:
        If Me.txtProduct.Text <> "" And (Me.txtClient.Text = "" Or Me.txtDivision.Text = "") Then
            Me.ShowMessage("Cannot filter by Product without both Client code and Division code")
            Return False
        End If
        If Me.txtDivision.Text <> "" And Me.txtClient.Text = "" Then
            Me.ShowMessage("Cannot filter by Division without a Client code")
            Return False
        End If
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If Me.txtOffice.Text <> "" Then
            If myVal.ValidateOffice(Me.txtOffice.Text, True) = False Then
                Me.ShowMessage("Invalid Office!")
                Exit Function
            End If
        End If
        If Me.txtClient.Text <> "" Then
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                Me.ShowMessage("Client invalid")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                Me.ShowMessage("Access to this Client is denied")
                Return False
            End If
        End If
        If Me.txtDivision.Text <> "" Then
            If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Then
                Me.ShowMessage("Please enter a Client and Division Code when filtering at the Division level")
                Return False
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                Me.ShowMessage("Client, Division invalid")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                Me.ShowMessage("Access to this Division is denied")
                Return False
            End If
        End If
        If Me.txtProduct.Text <> "" Then
            If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Or Me.txtProduct.Text = "" Then
                Me.ShowMessage("Please enter a Client, Division, and Product Code when filtering at the Product level")
                Return False
            End If
            If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                Me.ShowMessage("Invalid Client, Division, Product")
                Return False
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                Me.ShowMessage("Access to this product is denied")
                Return False
            End If
        End If
        If Me.txtJob.Text.Trim <> "" Then
            If IsNumeric(Me.txtJob.Text.Trim) = False Then
                Me.ShowMessage("Job invalid")
                Return False
            End If
            If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                Me.ShowMessage("Job does not exist")
                Return False
            End If
            If myVal.ValidateJobIsViewable(Session("Usercode"), Me.txtJob.Text.Trim) = False Then
                Me.ShowMessage("Access to this Job is denied")
                Return False
            End If
        End If
        If Me.txtComponent.Text <> "" Then
            If IsNumeric(Me.txtComponent.Text.Trim) = False Then
                Me.ShowMessage("Component invalid")
                Return False
            End If
            If Me.txtJob.Text = "" Or Me.txtComponent.Text = "" Then
                Me.ShowMessage("Please enter a Job and Job Component number when filtering at the Component level")
                Return False
            End If
            If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                Me.ShowMessage("Component invalid")
                Return False
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtComponent.Text.Trim) = False Then
                Me.ShowMessage("Access to this job/component is denied")
                Return False
            End If
        End If
        If Me.TextBoxJobType.Text <> "" Then
            If myVal.ValidateJobType(Me.TextBoxJobType.Text) = False Then
                Me.ShowMessage("Job Type invalid")
                Return False
            End If
        End If
        If Me.TxtCampaign.Text <> "" Then
            If Me.txtClient.Text.Trim = "" Or Me.TxtCampaign.Text.Trim = "" Then
                Me.ShowMessage("Please fill in Client, Division, Product, and Campaign Codes when using the Campaign filter")
                Exit Function
            End If
            If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                Me.ShowMessage("Campaign invalid")
                Exit Function
            End If
            If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                Me.ShowMessage("Access to this campaign is denied")
                Exit Function
            End If
        End If
        If Me.TxtAccountExecutive.Text <> "" Then
            If myVal.ValidateEmpCode(Me.TxtAccountExecutive.Text) = False Then
                Me.ShowMessage("Invalid employee selected as Account Executive")
                Exit Function
            End If
        End If
        If Me.txtSalesClass.Text <> "" Then
            If myVal.ValidateSalesClassCode(Me.txtSalesClass.Text, True) = False Then
                Me.ShowMessage("Invalid Sales Class.")
                Exit Function
            End If
        End If
        Try
            If Me.txtJob.Text.Trim() <> "" Then
                Me.JobNum = CType(Me.txtJob.Text, Integer)
            End If
        Catch ex As Exception
            Me.JobNum = 0
            Return False
        End Try
        Try
            If Me.txtComponent.Text.Trim() <> "" Then
                Me.JobCompNum = CType(Me.txtComponent.Text, Integer)
            End If
        Catch ex As Exception
            Me.JobCompNum = 0
            Return False
        End Try

        Return True
    End Function

    Private Sub LoadLookups()
        Dim s As New cSchedule()
        Me.HlManager.Text = s.GetManagerLabel() & ":"
        Dim AutoSearch As String = "autoSearch="

        If RblSelect.SelectedValue = "multi" Then

            AutoSearch = "autoSearch=0"

        Else

            AutoSearch = "autoSearch=1"

        End If

        Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=jobjacketnew&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
        Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=pssearch&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=pssearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=pssearch&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?" & AutoSearch & "&form=schedule_search&type=jobschedule&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value);return false;")
        ' Me.txtJob.Attributes.Add("onkeyup", "Javascript:ClearTB('" & Me.txtComponent.ClientID & "');")
        Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?" & AutoSearch & "&form=schedule_search&type=jobcompschedule&control=" & Me.txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
        Me.hlSalesClass.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.txtSalesClass.ClientID & "&type=salesclass');return false;")

        Me.HlEmployee.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.TxtEmployee.ClientID & "&type=empcode');return false;")
        Me.HlAccountExecutive.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.TxtAccountExecutive.ClientID & "&type=accountexec&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=&jobcomp=');return false;")
        Me.HyperLinkJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?" & AutoSearch & "&form=jtn1&control=" & Me.TextBoxJobType.ClientID & "&type=jobtype&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value);return false;")
        Me.HlTask.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.TxtTaskCode.ClientID & "&type=task');return false;")
        Me.HlRole.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.TxtRole.ClientID & "&type=roles');return false;")
        Me.HlManager.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?" & AutoSearch & "&calledfrom=custom&form=schedule_search&control=" & Me.TxtManager.ClientID & "&type=managers');return false;")
        Me.HlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?" & AutoSearch & "&calledfrom=custom&form=pscmpsearch&type=campaign&control=" & Me.TxtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&cmpID=' + document.forms[0]." & Me.hfCampaignID.ClientID & ".value);return false;")

        Dim d As New cDropDowns(Session("ConnString"))
        With Me.DropPhaseFilter
            .DataSource = d.GetTrafficPhasesAll
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With

    End Sub

    Private Sub SetQSVars()
        Try

            Try
                If Not Request.QueryString("t") = Nothing Then

                    Me.SearchType = CType(Request.QueryString("t"), Integer)

                End If
            Catch ex As Exception

                Me.SearchType = 0

            End Try

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            With qs

                If .GetValue("snglvw") = "true" Then

                    Me.SearchType = 0

                End If

                Me.RblSelect.SelectedIndex = Me.SearchType

                Me.Office = .OfficeCode
                Me.Client = .ClientCode
                Me.Division = .DivisionCode
                Me.Product = .ProductCode
                Me.SalesClass = .SalesClassCode
                Me.TxtCampaign.Text = .CampaignCode

                If .JobNumber > 0 Then Me.JobNum = .JobNumber
                If .JobComponentNumber > 0 Then Me.JobCompNum = .JobComponentNumber

                Me.TxtAccountExecutive.Text = .AccountExecutiveCode
                Me.TxtManager.Text = .ManagerCode

                Me.ChkExcludeCompletedSchedules.Checked = Not .IncludeCompletedSchedules

                If .PhaseFilter <> "" Then

                    MiscFN.RadComboBoxSetIndex(Me.DropPhaseFilter, .PhaseFilter, False)

                End If

                Me.TxtRole.Text = .RoleCode
                Me.TxtTaskCode.Text = .TaskCode
                Me.TxtEmployee.Text = .EmployeeCode

                If IsDate(.CutOffDate) = True Then Me.RadDatePickerDateCutoff.SelectedDate = CType(.CutOffDate, Date)

                Me.ChkOnlyPendingTasks.Checked = .IncludeOnlyPendingTasks
                Me.ChkExcludeProjectedTasks.Checked = .ExcludeProjectedTasks
                Me.ChkIncludeCompletedTasks.Checked = .IncludeCompletedTasks

            End With

            Me.txtOffice.Text = Me.Office
            Me.txtClient.Text = Me.Client
            Me.txtDivision.Text = Me.Division
            Me.txtProduct.Text = Me.Product
            Me.txtSalesClass.Text = Me.SalesClass

            If Me.JobNum > 0 Then

                Me.txtJob.Text = Me.JobNum.ToString()

            End If
            If Me.JobCompNum > 0 Then

                Me.txtComponent.Text = Me.JobCompNum.ToString()

            End If

            If qs.IsBookmark = True Then Me.RunSearch()

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())

        End Try
    End Sub

    Private Sub GoToNew()
        If Me.ValidateInput = True Then
            Dim StrJ As String = ""
            Dim StrJC As String = ""
            'only send job/comp if loaded
            If Me.JobNum > 0 And Me.JobCompNum > 0 Then
                StrJ = Me.JobNum.ToString()
                StrJC = Me.JobCompNum.ToString()
            Else
                StrJ = ""
                StrJC = ""
            End If
            Me.OpenWindow("", Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?ClientCode=" & Me.Client & "&DivisionCode=" & Me.Division & "&ProductCode=" & Me.Product & "&JobNumber=" & StrJ & "&JobComponentNumber=" & StrJC)
        End If
    End Sub

    Private Sub RadGridProjectScheduleSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProjectScheduleSearch.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridProjectScheduleSearch.ID, Me.RadGridProjectScheduleSearch.PageSize)
            Exit Sub
        End If
        Select Case e.CommandName
            Case "Detail"
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleSearch.MasterTableView.Items(index), Telerik.Web.UI.GridDataItem)
                Dim j As Integer = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                Dim jc As Integer = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim x As Integer = oTrafficSchedule.CheckExistsClosed(j, jc)
                Select Case x
                    Case -1
                        Me.GoToNew()
                    Case Else
                        ''Me.OpenWindow("", "TrafficSchedule.aspx?JobNum=" & j.ToString() & "&JobComp=" & jc.ToString())
                        Dim qs As New AdvantageFramework.Web.QueryString
                        qs.Page = "Content.aspx"
                        qs.JobNumber = j
                        qs.JobComponentNumber = jc
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                        Me.OpenWindow(qs)

                End Select
        End Select
    End Sub

    Dim lab As System.Web.UI.WebControls.Label
    Dim labJT As System.Web.UI.WebControls.Label
    Private Sub RadGridProjectScheduleSearch_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectScheduleSearch.ItemDataBound
        Try
            Select Case e.Item.ItemType
                Case GridItemType.Header
                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                    labJT = e.Item.FindControl("lblJobNum")
                    labJT.Text = labJT.Text.PadLeft(6, "0")
                    labJT = e.Item.FindControl("lblJobComp")
                    labJT.Text = labJT.Text.PadLeft(2, "0")
                    If rights = "N" Then
                        Dim imgbtn As System.Web.UI.WebControls.ImageButton
                        imgbtn = e.Item.FindControl("ImgBtnPrint")
                        imgbtn.Visible = False
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridProjectScheduleSearch_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjectScheduleSearch.NeedDataSource
        If Me.RblSelect.SelectedIndex > -1 Then Me.SearchType = Me.RblSelect.SelectedIndex

        If Me.SearchType = 0 Then

            _LoadingDatasource = True

            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Me.Client = Me.txtClient.Text
            Me.Division = Me.txtDivision.Text
            Me.Product = Me.txtProduct.Text
            Me.Office = Me.txtOffice.Text
            Me.SalesClass = Me.txtSalesClass.Text
            Me.CmpCode = Me.TxtCampaign.Text
            Me.AECode = Me.TxtAccountExecutive.Text
            Me.JobType = Me.TextBoxJobType.Text

            Dim dt As New DataTable
            dt = oTrafficSchedule.ScheduleSearch(Me.Client, Me.Division, Me.Product, Me.JobNum, Me.JobCompNum, Me.Office, Me.SalesClass, Me.CmpCode, Me.AECode, Session("UserCode"), Me.JobType)

            Me.RadGridProjectScheduleSearch.DataSource = dt
            Me.RadGridProjectScheduleSearch.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridProjectScheduleSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridProjectScheduleSearch.ID)

            If dt.Rows.Count = 1 Then

                Dim qs As New AdvantageFramework.Web.QueryString
                qs.Page = "Content.aspx"
                qs.JobNumber = dt.Rows(0)("JOB_NUMBER")
                qs.JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                Me.OpenWindow(qs)

            End If

            _LoadingDatasource = False

        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        'If Me.ValidateSearch() = True Then
        '    Me.RadGridProjectScheduleSearch.Rebind()
        'End If
        Me.RunSearch()
    End Sub

    Private Sub SearchMultiWorksheet(ByVal SwitchToView As String)

        If Me.ValidateInput = False Then

            Exit Sub

        End If
        Try
            Dim RemoveFilterForSingleView As Boolean = False
            'Make sure we filter on something:
            If Me.txtOffice.Text = "" And Me.txtClient.Text = "" And Me.txtDivision.Text = "" _
            And Me.txtProduct.Text = "" And Me.txtJob.Text = "" And Me.txtSalesClass.Text = "" _
            And Me.txtComponent.Text = "" And Me.TxtEmployee.Text = "" And Me.TxtCampaign.Text = "" _
            And Me.TxtEmployee.Text = "" And Me.TxtTaskCode.Text = "" And Me.TxtAccountExecutive.Text = "" _
            And Me.TxtManager.Text = "" And Me.TxtRole.Text = "" And Me.RadDatePickerDateCutoff.DateInput.Text = "" _
            And Me.ChkOnlyPendingTasks.Checked = False And Me.DropPhaseFilter.SelectedIndex = 0 Then 'nothing has been selected for filter
                Select Case SwitchToView
                    Case "multi"
                        'Me.ShowMessage("Please choose at least one filter")
                        'Exit Sub
                    Case "single"
                        RemoveFilterForSingleView = True
                End Select
            ElseIf Me.txtOffice.Text = "" And Me.txtClient.Text = "" And Me.txtDivision.Text = "" _
                And Me.txtProduct.Text = "" And Me.txtJob.Text = "" And Me.txtSalesClass.Text = "" _
                And Me.txtComponent.Text = "" And Me.TxtEmployee.Text = "" And Me.TxtCampaign.Text = "" _
                And Me.TxtEmployee.Text = "" And Me.TxtTaskCode.Text = "" And Me.TxtAccountExecutive.Text = "" _
                And Me.TxtManager.Text = "" And Me.TxtRole.Text = "" And Me.RadDatePickerDateCutoff.DateInput.Text = "" _
                And Me.ChkOnlyPendingTasks.Checked = False And Me.DropPhaseFilter.SelectedIndex > 0 And SwitchToView <> "single" Then 'only phase selected...
                'Me.ShowMessage("Please choose more than just the phase filter")
                'Exit Sub
            End If


            'validate:
            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing
            If Me.txtJob.Text <> "" Then
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                        AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                        Me.ShowMessage("Access to this job is denied.\n")
                        Exit Sub
                    End If
                End Using
            End If
            If Me.TextBoxJobType.Text <> "" Then
                If myVal.ValidateJobType(Me.TextBoxJobType.Text) = False Then
                    Me.ShowMessage("Job Type invalid")
                    Exit Sub
                End If
            End If
            If Me.TxtCampaign.Text <> "" Then
                If Me.txtClient.Text.Trim = "" Or Me.TxtCampaign.Text.Trim = "" Then
                    Me.ShowMessage("Please fill in Client, Division, Product, and Campaign Codes when using the Campaign filter")
                    Exit Sub
                End If
                If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                    Me.ShowMessage("Campaign invalid")
                    Exit Sub
                End If
                If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.TxtCampaign.Text.Trim) = False Then
                    Me.ShowMessage("Access to this campaign is denied")
                    Exit Sub
                End If
            End If
            If Me.TxtEmployee.Text <> "" Then
                If myVal.ValidateEmpCode(Me.TxtEmployee.Text) = False Then
                    Me.ShowMessage("Employee invalid")
                    Exit Sub
                End If
            End If
            If Me.TxtTaskCode.Text <> "" Then
                If myVal.ValidateTaskCode(Me.TxtTaskCode.Text) = False Then
                    Me.ShowMessage("Task invalid")
                    Exit Sub
                End If
            End If
            If Me.TxtAccountExecutive.Text <> "" Then
                If myVal.ValidateEmpCode(Me.TxtAccountExecutive.Text) = False Then
                    Me.ShowMessage("Invalid employee selected as Account Executive")
                    Exit Sub
                End If
            End If
            If Me.TxtManager.Text <> "" Then
                Dim dr As SqlClient.SqlDataReader
                Dim valid As Boolean = False
                dr = oDD.GetManagers(CStr(Session("UserCode")))
                If dr.HasRows = True Then
                    Do While dr.Read
                        If dr.GetString(1) = Me.TxtManager.Text Then
                            valid = True
                        End If
                    Loop
                End If
                dr.Close()
                If valid = False Then
                    Me.ShowMessage("Manager invalid")
                    Exit Sub
                End If
            End If
            If Me.TxtRole.Text <> "" Then
                If myVal.ValidateRoleCode(Me.TxtRole.Text) = False Then
                    Me.ShowMessage("Role invalid")
                    Exit Sub
                End If
            End If

            Try
                If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, True) = False Then
                    Me.ShowMessage("Date Cutoff invalid")
                    Exit Sub
                End If
            Catch ex As Exception
                Me.ShowMessage("Date Cutoff invalid")
                Exit Sub
            End Try

            Dim OfficeCode As String = ""
            Dim ClientCode As String = ""
            Dim DivisionCode As String = ""
            Dim ProductCode As String = ""
            Dim JobNumber As Integer = 0
            Dim JobCompNumber As Integer = 0
            Dim JobType As String = ""
            Dim EmpCode As String = ""
            Dim ManagerCode As String = ""
            Dim TaskCode As String = ""
            Dim AccountExecCode As String = ""
            Dim RoleCode As String = ""
            Dim CutOffDate As String = ""
            Dim Campaign As String = ""
            Dim SalesClass As String = ""
            Dim IncludeCompletedTasks As Boolean = True
            Dim IncludeOnlyPendingTasks As Boolean = False
            Dim ExcludeProjectedTasks As Boolean = False
            Dim IncludeCompletedSchedules As Boolean = True
            Dim OnlyScheduleTemplates As Boolean = False
            Dim TasksFilterValue As String = Me.DropPhaseFilter.SelectedValue
            Dim qs As New AdvantageFramework.Web.QueryString

            If TasksFilterValue = "0" Then

                TasksFilterValue = "is_null"

            End If

            OfficeCode = Me.txtOffice.Text
            ClientCode = Me.txtClient.Text
            DivisionCode = Me.txtDivision.Text
            ProductCode = Me.txtProduct.Text

            If IsNumeric(Me.txtJob.Text) = True Then

                JobNumber = CType(Me.txtJob.Text, Integer)

            End If
            If IsNumeric(Me.txtComponent.Text) = True Then

                JobCompNumber = CType(Me.txtComponent.Text, Integer)

            End If

            JobType = Me.TextBoxJobType.Text
            EmpCode = Me.TxtEmployee.Text
            TaskCode = Me.TxtTaskCode.Text
            AccountExecCode = Me.TxtAccountExecutive.Text
            RoleCode = Me.TxtRole.Text
            ManagerCode = Me.TxtManager.Text
            SalesClass = Me.txtSalesClass.Text

            If MiscFN.ValidDate(Me.RadDatePickerDateCutoff, False) = True Then

                CutOffDate = cGlobals.wvCDate(Me.RadDatePickerDateCutoff.SelectedDate).ToShortDateString()

            End If

            IncludeCompletedTasks = Me.ChkIncludeCompletedTasks.Checked
            IncludeOnlyPendingTasks = Me.ChkOnlyPendingTasks.Checked
            ExcludeProjectedTasks = Me.ChkExcludeProjectedTasks.Checked
            IncludeCompletedSchedules = Me.ChkExcludeCompletedSchedules.Checked
            OnlyScheduleTemplates = Me.CheckBoxOnlyScheduleTemplates.Checked
            Campaign = Me.TxtCampaign.Text

            qs.Add("Off", OfficeCode)
            qs.Add("Cli", ClientCode)
            qs.Add("Div", DivisionCode)
            qs.Add("Prod", ProductCode)

            If SwitchToView <> "single" Then

                qs.Add("Job", JobNumber)
                qs.Add("JobComp", JobCompNumber)

            End If

            qs.Add("JobType", JobType)
            qs.Add("OnlyScheduleTemplates", OnlyScheduleTemplates)
            qs.Add("Emp", EmpCode)
            qs.Add("Mgr", ManagerCode)
            qs.Add("Task", TaskCode)
            qs.Add("AE", AccountExecCode)
            qs.Add("Role", RoleCode)
            qs.Add("Cut", CutOffDate)
            qs.Add("Camp", Campaign)
            qs.Add("SC", SalesClass)
            qs.Add("Comp", IncludeCompletedTasks.ToString())
            qs.Add("Pend", IncludeOnlyPendingTasks.ToString())
            qs.Add("Proj", ExcludeProjectedTasks.ToString())
            qs.Add("CS", IncludeCompletedSchedules.ToString())
            qs.Add("P", TasksFilterValue)

            If SwitchToView = "multi" Then

                qs.Page = "TrafficSchedule_Multiview.aspx"

            ElseIf SwitchToView = "single" Then

                Session("PS_Ignore_Filter") = "0"
                qs.Page = "Content.aspx"
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                Dim j As Integer = 0
                Dim c As Integer = 0

                Try

                    j = CType(Request.QueryString("JobNum"), Integer)

                Catch ex As Exception

                    j = 0

                End Try
                Try

                    c = CType(Request.QueryString("JobCompNum"), Integer)

                Catch ex As Exception

                    c = 0

                End Try

                qs.Add("R", 1)
                qs.Add("JobNum", j)
                qs.Add("JobComp", c)

            End If

            Me.OpenWindow(qs)

        Catch ex1 As ArithmeticException

            Me.ShowMessage("This number not allowed.")

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())

        End Try
    End Sub

    Private Sub RblSelect_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblSelect.SelectedIndexChanged
        Me.LoadLookups()
        Select Case Me.RblSelect.SelectedIndex 'single view, load grid
            Case 0
                Me.MultiWorksheetFilter_Show(False)
            Case 1 'multi
                Me.MultiWorksheetFilter_Show(True)
        End Select

    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlClient.SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String
            Dim custom1 As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            custom1 = IIf(Me.UserCanCustom1Module(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")

            If secInsert = "N" Then
                Me.RadToolbarSearch.FindItemByValue("New").Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridProjectScheduleSearch_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridProjectScheduleSearch.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridProjectScheduleSearch.Rebind()

    End Sub

    Private Sub RadGridProjectScheduleSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridProjectScheduleSearch.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridProjectScheduleSearch.ID, e.NewPageSize)

        End If

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridProjectScheduleSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridProjectScheduleSearch.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub
End Class
