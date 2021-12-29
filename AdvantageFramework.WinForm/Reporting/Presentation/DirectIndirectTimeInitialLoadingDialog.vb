Namespace Reporting.Presentation

    Public Class DirectIndirectTimeInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.SalesJournal
        Private _ShowReportOption As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
            Get
                ReportType = _ReportType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _ReportType = ReportType
            _DynamicReport = DynamicReport
            _ShowReportOption = ShowReportOption

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim DirectIndirectTimeInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.DirectIndirectTimeInitialLoadingDialog = Nothing

            DirectIndirectTimeInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.DirectIndirectTimeInitialLoadingDialog(DynamicReport, ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = DirectIndirectTimeInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = DirectIndirectTimeInitialLoadingDialog.ParameterDictionary
                ReportType = DirectIndirectTimeInitialLoadingDialog.ReportType

            End If

        End Function

        Private Sub EnableOrDisableActions()

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournal Then

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.SalesJournalReportTypes.SalesJournalExpanded Then

                    End If

                Else


                End If

            End If

        End Sub

        'Private Sub LoadOffices()

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
        '                                                        Select [Code] = Entity.Code,
        '                                                               [Name] = Entity.Name).ToList

        '        DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

        '    End Using

        'End Sub
        Private Sub LoadJobs()

            'objects
            Dim ClientCodesList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If RadioButtonSelectJobs_AllJobs.Checked = False Then

                    If RadioButtonJobStatus_OpenJobs.Checked Then

                        If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked = True OrElse CDPChooserControlSelectClients_SelectClients.DataGridViewControl_Clients.HasASelectedRow = False Then

                            DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext)
                                                                      Select [Number] = Entity.Number,
                                                                             [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                        Else

                            If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                         [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                End If

                            ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                         [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                End If

                            ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                         [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                End If

                            End If

                            'SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ClientCodeList



                        End If

                    Else

                        If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked = True OrElse CDPChooserControlSelectClients_SelectClients.DataGridViewControl_Clients.HasASelectedRow = False Then

                            DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.Load(DbContext)
                                                                      Select [Number] = Entity.Number,
                                                                             [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                        Else

                            SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                            If SelectedCodeList IsNot Nothing Then

                                If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.Load(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.Load(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Job.Load(DbContext).ToList
                                                                              Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True
                                                                              Select [Number] = Entity.Number,
                                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                                End If

                            End If

                        End If

                    End If

                Else

                    DataGridViewSelectJobs_Jobs.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Job)
                                                              Select [Number] = Entity.Number,
                                                                     [Description] = Entity.Description).ToList.OrderByDescending(Function(Job) Job.Number).ToList

                End If

                DataGridViewSelectJobs_Jobs.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadCampaigns()

            Dim ClientCodesList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If RadioButtonSelectCampaigns_AllCampaigns.Checked = False Then

                        If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked = True OrElse CDPChooserControlSelectClients_SelectClients.DataGridViewControl_Clients.HasASelectedRow = False Then

                            DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode)
                                                                 Where (Entity.IsClosed Is Nothing OrElse
                                                                                       Entity.IsClosed = 0)
                                                                 Select [ID] = Entity.ID,
                                                                                       [Code] = Entity.CampaignCode,
                                                                                       [Description] = Entity.CampaignName).ToList

                        Else

                            If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode) = True AndAlso
                                                                                                  (Entity.IsClosed Is Nothing OrElse
                                                                                                   Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                                   [Code] = Entity.CampaignCode,
                                                                                                   [Description] = Entity.CampaignName).ToList
                                End If



                            ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode) = True AndAlso
                                                                                                  (Entity.IsClosed Is Nothing OrElse
                                                                                                   Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                                   [Code] = Entity.CampaignCode,
                                                                                                   [Description] = Entity.CampaignName).ToList
                                End If



                            ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                                SelectedCodeList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                                If SelectedCodeList IsNot Nothing Then

                                    DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode).ToList
                                                                         Where SelectedCodeList.Contains(Entity.ClientCode & "|" & Entity.DivisionCode & "|" & Entity.ProductCode) = True AndAlso
                                                                                                  (Entity.IsClosed Is Nothing OrElse
                                                                                                   Entity.IsClosed = 0)
                                                                         Select [ID] = Entity.ID,
                                                                                                   [Code] = Entity.CampaignCode,
                                                                                                   [Description] = Entity.CampaignName).ToList
                                End If

                            End If

                        End If

                    Else

                        DataGridView_Campaigns.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Session, DbContext, SecurityDbContext, Session.UserCode)
                                                             Where (Entity.IsClosed Is Nothing OrElse
                                                                                       Entity.IsClosed = 0)
                                                             Select [ID] = Entity.ID,
                                                                                   [Code] = Entity.CampaignCode,
                                                                                   [Description] = Entity.CampaignName).ToList
                    End If



                    DataGridView_Campaigns.CurrentView.BestFitColumns()

                    'DataGridViewSelectCampaigns_Campaigns.MakeColumnNotVisible("ID")

                End Using

            End Using

        End Sub
        Private Sub LoadDepartments()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectDepartments_Departments.DataSource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                                                        Select [Code] = Entity.Code,
                                                                               [Name] = Entity.Description).ToList

                DataGridViewSelectDepartments_Departments.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadEmployees()

            Dim EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                DataGridView_Employees.DataSource = EmployeeList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                          .Name = Employee.ToString}).OrderBy(Function(Employee) Employee.Name)

                DataGridView_Employees.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadFunctions()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridView_Functions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeFunctions(DbContext)
                                                     Select [Code] = Entity.Code,
                                                            [Name] = Entity.Description).ToList

                DataGridView_Functions.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DirectTimeInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            PanelForm_TopSection.Visible = _ShowReportOption

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"
                Me.CheckBox_OnlyActiveEmployees.Visible = False

            Else

                'Me.CheckBoxFrom_IncludeMarkup.Visible = False

            End If

            ComboBoxTopSection_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.EmployeeTimeReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList
            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DirectIndirectTimeInitialCriteria), False)



            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)



            End Using

            If _ParameterDictionary IsNot Nothing Then



            End If

            'CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                If _ShowReportOption Then

                    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                End If


                _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.DateType.ToString) = ComboBoxForm_Criteria.SelectedValue
                '_ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.IncludeMarkup.ToString) = If(CheckBoxFrom_IncludeMarkup.Checked, 1, 0)
                _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.FromDate.ToString) = DateTimePickerForm_From.Value.Date
                _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.ToDate.ToString) = DateTimePickerForm_To.Value.Date
                _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.OnlyActiveEmployees.ToString) = If(CheckBox_OnlyActiveEmployees.Checked, 1, 0)

                'If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                '    ClientCodeList = Nothing
                '    DivisionCodeList = Nothing
                '    ProductCodeList = Nothing

                'Else

                '    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                '        ClientCodeList = SelectedCodesList
                '        DivisionCodeList = Nothing
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = SelectedCodesList
                '        ProductCodeList = Nothing

                '    ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                '        SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                '        ClientCodeList = Nothing
                '        DivisionCodeList = Nothing
                '        ProductCodeList = SelectedCodesList

                '    End If

                'End If

                'If RadioButtonSelectCampaigns_AllCampaigns.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedCampaigns.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedCampaigns.ToString) = DataGridView_Campaigns.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                'End If

                '_ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedClients.ToString) = ClientCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedDivisions.ToString) = DivisionCodeList
                '_ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedProducts.ToString) = ProductCodeList

                'If RadioButtonSelectJobs_AllJobs.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedJobs.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedJobs.ToString) = DataGridViewSelectJobs_Jobs.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                'End If

                'If RadioButtonSelectDepartments_AllDepartments.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedDepartments.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedDepartments.ToString) = DataGridViewSelectDepartments_Departments.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                'End If

                'If RadioButtonControl_AllEmployees.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedEmployees.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedEmployees.ToString) = DataGridView_Employees.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                'End If

                'If RadioButtonControl_AllFunctions.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedFunctions.ToString) = Nothing

                'Else

                '    _ParameterDictionary(AdvantageFramework.Reporting.DirectTimeParameters.SelectedFunctions.ToString) = DataGridView_Functions.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                'End If


                If _ShowReportOption Then

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, ComboBoxForm_Criteria.SelectedValue, Nothing, DateTimePickerForm_From.Value, DateTimePickerForm_To.Value)

                Else

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

        End Sub

        Private Sub ButtonInvoiceDate_YTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_MTD_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_1Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonInvoiceDate_2Year_Click(sender As Object, e As EventArgs) Handles ButtonInvoiceDate_2Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub CheckBoxFrom_IncludeMarkup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFrom_IncludeMarkup.CheckedChanged

            'If CheckBoxFrom_IncludeMarkup.Checked = True Then
            '    Me.DateTimePickerForm_From.Enabled = True
            '    Me.DateTimePickerForm_To.Enabled = True
            '    Me.ButtonInvoiceDate_YTD.Enabled = True
            '    Me.ButtonInvoiceDate_MTD.Enabled = True
            '    Me.ButtonInvoiceDate_1Year.Enabled = True
            '    Me.ButtonInvoiceDate_2Year.Enabled = True
            'Else
            '    Me.DateTimePickerForm_From.Enabled = False
            '    Me.DateTimePickerForm_To.Enabled = False
            '    Me.ButtonInvoiceDate_YTD.Enabled = False
            '    Me.ButtonInvoiceDate_MTD.Enabled = False
            '    Me.ButtonInvoiceDate_1Year.Enabled = False
            '    Me.ButtonInvoiceDate_2Year.Enabled = False
            'End If

        End Sub

        Private Sub RadioButtonSelectCampaigns_AllCampaigns_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_AllCampaigns.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCampaigns_AllCampaigns.Checked Then

                    DataGridView_Campaigns.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectCampaigns_ChooseCampaigns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectCampaigns_ChooseCampaigns.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectCampaigns_ChooseCampaigns.Checked Then

                    'If DataGridViewSelectCampaigns_Campaigns.HasRows = False Then

                    LoadCampaigns()

                    'End If

                    DataGridView_Campaigns.Enabled = True

                End If

            End If

        End Sub

        Private Sub RadioButtonSelectJobs_AllJobs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectJobs_AllJobs.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectJobs_AllJobs.Checked Then

                    PanelSelectJobs_JobStatus.Enabled = False
                    DataGridViewSelectJobs_Jobs.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectJobs_ChooseJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectJobs_ChooseJobs.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectJobs_ChooseJobs.Checked Then

                    LoadJobs()

                    PanelSelectJobs_JobStatus.Enabled = True
                    DataGridViewSelectJobs_Jobs.Enabled = True

                End If

            End If

        End Sub
        Private Sub RadioButtonJobStatus_OpenJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonJobStatus_OpenJobs.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectJobs_ChooseJobs.Checked AndAlso RadioButtonJobStatus_OpenJobs.Checked Then

                    LoadJobs()

                End If

            End If

        End Sub
        Private Sub RadioButtonJobStatus_OpenClosedJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonJobStatus_OpenClosedJobs.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectJobs_ChooseJobs.Checked AndAlso RadioButtonJobStatus_OpenClosedJobs.Checked Then

                    LoadJobs()

                End If

            End If

        End Sub

        Private Sub RadioButtonSelectDepartments_AllDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectDepartments_AllDepartments.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectDepartments_AllDepartments.Checked Then

                    DataGridViewSelectDepartments_Departments.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectDepartments_ChooseDepartments_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonSelectDepartments_ChooseDepartments.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectDepartments_ChooseDepartments.Checked Then

                    LoadDepartments()

                    DataGridViewSelectDepartments_Departments.Enabled = True

                End If

            End If

        End Sub

        Private Sub RadioButtonControl_AllEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllEmployees.CheckedChanged

            If Me.FormShown Then

                If RadioButtonControl_AllEmployees.Checked Then

                    DataGridView_Employees.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseEmployees.CheckedChanged

            If Me.FormShown Then

                If RadioButtonControl_ChooseEmployees.Checked Then

                    LoadEmployees()

                    DataGridView_Employees.Enabled = True

                End If

            End If

        End Sub

        Private Sub RadioButtonControl_AllFunctions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_AllFunctions.CheckedChanged

            If Me.FormShown Then

                If RadioButtonControl_AllFunctions.Checked Then

                    DataGridView_Functions.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonControl_ChooseFunctions_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControl_ChooseFunctions.CheckedChanged

            If Me.FormShown Then

                If RadioButtonControl_ChooseFunctions.Checked Then

                    LoadFunctions()

                    DataGridView_Functions.Enabled = True

                End If

            End If

        End Sub


#End Region

#End Region

    End Class

End Namespace
