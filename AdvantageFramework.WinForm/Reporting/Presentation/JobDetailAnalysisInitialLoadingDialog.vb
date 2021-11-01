Namespace Reporting.Presentation

    Public Class JobDetailAnalysisInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUserDefinedReport As Boolean = False
        Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary
        Private _Report As AdvantageFramework.Reporting.ReportTypes = ReportTypes.JobDetailAnalysisV1Summary
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Report As AdvantageFramework.Reporting.ReportTypes
            Get
                Report = _Report
            End Get
        End Property
        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal IsUserDefinedReport As Boolean, ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _IsUserDefinedReport = IsUserDefinedReport
            _AdvancedReportWriterReport = AdvancedReportWriterReport

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadJobs()

            'objects
            Dim ClientCodesList As Generic.List(Of String) = Nothing
            Dim SelectedCodeList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If RadioButtonSelectJobs_AllJobs.Checked = False Then

                    If RadioButtonInclude_OpenJobsOnly.Checked Then

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
        Private Sub LoadAccountExecutives()

            Dim DataTable As System.Data.DataTable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "usp_wv_dd_account_executive"

                        SqlCommand.Parameters.AddWithValue("Client", "")
                        SqlCommand.Parameters.AddWithValue("Division", "")
                        SqlCommand.Parameters.AddWithValue("Product", "")
                        SqlCommand.Parameters.AddWithValue("USER_CODE", Session.User.UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                    End Using

                Catch ex As Exception

                End Try

            End Using

            'objects
            'Dim AccountExecutives As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            'Dim AccessibleEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            'Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing
            'Dim UserCDPAccessList As System.Collections.Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

            '        'AccessibleEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(Me.Session, DbContext, SecurityDbContext).ToList

            '        UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList
            '        UserCDPAccessList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, Me.Session.UserCode).ToList
            '        AccountExecutives = AdvantageFramework.Database.Procedures.AccountExecutive.Load(DbContext).Include("Employee").Include("Product").ToList.Where(Function(Entity) Entity.Employee.TerminationDate Is Nothing).ToList

            '        If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

            '            AccountExecutives = (From Entity In AccountExecutives
            '                                 Where UserOfficeAccessList.Contains(Entity.Product.OfficeCode) = True
            '                                 Select Entity).ToList

            '        End If

            '        If UserCDPAccessList IsNot Nothing AndAlso UserCDPAccessList.Count > 0 Then

            '            AccountExecutives = (From Entity In AccountExecutives
            '                                 Join CDP In UserCDPAccessList On CDP.ClientCode Equals Entity.ClientCode And CDP.DivisionCode Equals Entity.DivisionCode And CDP.ProductCode Equals Entity.ProductCode
            '                                 Select Entity).ToList

            '        End If

            '        DataGridViewSelectAccountExecutives_AccountExecutives.DataSource = (From Entity In AccountExecutives
            '                                                                            Select [Code] = Entity.Employee.Code,
            '                                                                                   [Name] = Entity.Employee.ToString
            '                                                                            Distinct).ToList
            DataGridViewSelectAccountExecutives_AccountExecutives.DataSource = DataTable
            DataGridViewSelectAccountExecutives_AccountExecutives.CurrentView.BestFitColumns()

            '    End Using

            'End Using

        End Sub
        Private Sub LoadSalesClasses()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectSalesClasses_SalesClasses.DataSource = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                                                          Select [Code] = Entity.Code,
                                                                                 [Description] = Entity.Description).ToList

                DataGridViewSelectSalesClasses_SalesClasses.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Report As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object),
                                              ByVal IsUserDefinedReport As Boolean, Optional ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary) As Windows.Forms.DialogResult

            'objects
            Dim JobDetailAnalysisInitialLoadingDialog As JobDetailAnalysisInitialLoadingDialog = Nothing

            JobDetailAnalysisInitialLoadingDialog = New JobDetailAnalysisInitialLoadingDialog(IsUserDefinedReport, AdvancedReportWriterReport)

            ShowFormDialog = JobDetailAnalysisInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                Report = JobDetailAnalysisInitialLoadingDialog.Report
                ParameterDictionary = JobDetailAnalysisInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobDetailAnalysisInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            TabControlForm_JDA.SelectedTab = TabItemJDA_VersionAndOptionsTab

            DataGridViewVersionAndOptions_Versions.OptionsView.ShowFooter = False
            DataGridViewVersionAndOptions_Versions.MultiSelect = False
            RadioButtonSummaryOption_JobComp.Enabled = False

            RadioButtonJobStatus_OpenClosedJobs.Visible = False
            RadioButtonJobStatus_OpenJobs.Visible = False

            ComboBoxForm_PostPeriod.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try
                    ComboBoxForm_PostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
                    'ComboBoxForm_PostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Now.Month, Now.Year).Code
                Catch ex As Exception
                    ComboBoxForm_PostPeriod.SelectedValue = Nothing
                End Try


            End Using

            DataGridViewVersionAndOptions_Versions.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.JobDetailAnalysisReportTypes))
                                                                 Select [Code] = EnumObject.Code,
                                                                        [Description] = EnumObject.ToString).ToList

            If DataGridViewVersionAndOptions_Versions.Columns("Code") IsNot Nothing Then

                If DataGridViewVersionAndOptions_Versions.Columns("Code").Visible Then

                    DataGridViewVersionAndOptions_Versions.Columns("Code").Visible = False
                    DataGridViewVersionAndOptions_Versions.Columns("Code").OptionsColumn.AllowShowHide = False
                    DataGridViewVersionAndOptions_Versions.Columns("Code").OptionsColumn.ShowInCustomizationForm = False
                    DataGridViewVersionAndOptions_Versions.Columns("Code").OptionsColumn.ShowInExpressionEditor = False

                End If

            End If

            If DataGridViewVersionAndOptions_Versions.Columns("TypeId") IsNot Nothing Then

                If DataGridViewVersionAndOptions_Versions.Columns("TypeId").Visible Then

                    DataGridViewVersionAndOptions_Versions.Columns("TypeId").Visible = False
                    DataGridViewVersionAndOptions_Versions.Columns("TypeId").OptionsColumn.AllowShowHide = False
                    DataGridViewVersionAndOptions_Versions.Columns("TypeId").OptionsColumn.ShowInCustomizationForm = False
                    DataGridViewVersionAndOptions_Versions.Columns("TypeId").OptionsColumn.ShowInExpressionEditor = False

                End If

            End If

            DataGridViewVersionAndOptions_Versions.CurrentView.BestFitColumns()

            If _IsUserDefinedReport Then

                If _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v010.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v010.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v001.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v001.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v011.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v011.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp Then

                    RadioButtonSummaryOption_JobComp.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v011.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v029.ToString)
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v030.ToString)
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v030.ToString)
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp Then

                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v030.ToString)
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v030.ToString)
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v002.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v002.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v003.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp Then

                    RadioButtonSummaryOption_JobComp.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v003.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v004.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v004.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd Then

                    RadioButtonSummaryOption_JobComp.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Cli/Div/Prd"
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v005.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Cli/Div/Prd"
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v005.ToString)
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = True

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 Then

                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v006.ToString)
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 Then

                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v007.ToString)
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 Then

                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v008.ToString)
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary Then

                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v009.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail Then

                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v009.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                    RadioButtonSummaryOption_JobComp.Checked = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    DataGridViewVersionAndOptions_Versions.SelectRow(0, AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v009.ToString)
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

                End If

                DataGridViewVersionAndOptions_Versions.Enabled = False
                PanelVersionAndOptions_SummaryOptions.Enabled = False

            End If

            DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = True
            DataGridViewSelectOffices_Offices.MultiSelect = True

            DataGridViewSelectOffices_Offices.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Office)
                                                            Select [Code] = Entity.Code,
                                                                    [Name] = Entity.Name).ToList

            DataGridViewSelectJobs_Jobs.ShowSelectDeselectAllButtons = True
            DataGridViewSelectJobs_Jobs.MultiSelect = True

            DataGridViewSelectJobs_Jobs.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Job)
                                                      Select [Number] = Entity.Number,
                                                             [Description] = Entity.Description).ToList

            DataGridViewSelectAccountExecutives_AccountExecutives.ShowSelectDeselectAllButtons = True
            DataGridViewSelectAccountExecutives_AccountExecutives.MultiSelect = True

            'DataGridViewSelectAccountExecutives_AccountExecutives.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive)
            '                                                                    Select [Code] = "",
            '                                                                            [Name] = "").ToList

            DataGridViewSelectSalesClasses_SalesClasses.ShowSelectDeselectAllButtons = True
            DataGridViewSelectSalesClasses_SalesClasses.MultiSelect = True

            DataGridViewSelectSalesClasses_SalesClasses.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)
                                                                      Select [Code] = Entity.Code,
                                                                             [Description] = Entity.Description).ToList

            CDPChooserControlSelectClients_SelectClients.LoadControl()

            RadioButtonSummaryOptions_SummaryByFunction.Checked = True
            CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False

        End Sub
        Private Sub JobDetailAnalysisInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

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
        Private Sub RadioButtonSelectAccountExecutives_AllAccountExecutives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectAccountExecutives_AllAccountExecutives.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectAccountExecutives_AllAccountExecutives.Checked Then

                    DataGridViewSelectAccountExecutives_AccountExecutives.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectAccountExecutives_ChooseAccountExecutives_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectAccountExecutives_ChooseAccountExecutives.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectAccountExecutives_ChooseAccountExecutives.Checked Then

                    If DataGridViewSelectAccountExecutives_AccountExecutives.HasRows = False Then

                        LoadAccountExecutives()

                    End If

                    DataGridViewSelectAccountExecutives_AccountExecutives.Enabled = True

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectSalesClasses_AllSalesClasses_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectSalesClasses_AllSalesClasses.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectSalesClasses_AllSalesClasses.Checked Then

                    DataGridViewSelectSalesClasses_SalesClasses.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectSalesClasses_ChooseSalesClasses_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectSalesClasses_ChooseSalesClasses.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectSalesClasses_ChooseSalesClasses.Checked Then

                    If DataGridViewSelectSalesClasses_SalesClasses.HasRows = False Then

                        LoadSalesClasses()

                    End If

                    DataGridViewSelectSalesClasses_SalesClasses.Enabled = True

                End If

            End If

        End Sub
        Private Sub ButtonForm_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_View.Click

            'objects
            Dim LoadReportOptions As Boolean = True
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _IsUserDefinedReport Then

                    If _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV10Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11JobComp Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29 Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30JobComp Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31 Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV2Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV3JobComp Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV6 Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV7 Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV8 Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Summary Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9Detail Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail

                    ElseIf _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV9JobComp Then

                        _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp

                    End If

                Else

                    If DataGridViewVersionAndOptions_Versions.HasASelectedRow Then

                        If DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v001.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Detail

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v010.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV10Detail

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v011.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Summary

                            ElseIf RadioButtonSummaryOptions_DetailByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11Detail

                            ElseIf RadioButtonSummaryOption_JobComp.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV11JobComp

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v029.ToString Then

                            _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV29

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v030.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Summary

                            ElseIf RadioButtonSummaryOptions_DetailByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30Detail

                            ElseIf RadioButtonSummaryOption_JobComp.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV30JobComp

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v031.ToString Then

                            _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV31

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v002.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV2Detail

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v003.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV3JobComp

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v004.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV4Detail

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v005.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5Summary

                            Else

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV5CliDivPrd

                            End If

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v006.ToString Then

                            _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV6

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v007.ToString Then

                            _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV7

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v008.ToString Then

                            _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV8

                        ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowBookmarkValue(0) = AdvantageFramework.Reporting.JobDetailAnalysisReportTypes.v009.ToString Then

                            If RadioButtonSummaryOptions_SummaryByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Summary

                            ElseIf RadioButtonSummaryOptions_DetailByFunction.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9Detail

                            ElseIf RadioButtonSummaryOption_JobComp.Checked Then

                                _Report = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV9JobComp

                            End If

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a report version.")
                        LoadReportOptions = False

                    End If

                End If

                If LoadReportOptions Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_SelectedOffices") = Nothing

                    Else

                        _ParameterDictionary("JobDetailAnalysis_SelectedOffices") = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_AllClients.Checked Then

                        ClientCodeList = Nothing
                        DivisionCodeList = Nothing
                        ProductCodeList = Nothing

                    Else

                        If CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClients.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ClientCodeList

                            ClientCodeList = SelectedCodesList
                            DivisionCodeList = Nothing
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisions.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.DivisionCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = SelectedCodesList
                            ProductCodeList = Nothing

                        ElseIf CDPChooserControlSelectClients_SelectClients.RadioButtonControl_ChooseClientDivisionProducts.Checked Then

                            SelectedCodesList = CDPChooserControlSelectClients_SelectClients.ProductCodeList

                            ClientCodeList = Nothing
                            DivisionCodeList = Nothing
                            ProductCodeList = SelectedCodesList

                        End If

                    End If

                    _ParameterDictionary("JobDetailAnalysis_SelectedClients") = ClientCodeList
                    _ParameterDictionary("JobDetailAnalysis_SelectedDivisions") = DivisionCodeList
                    _ParameterDictionary("JobDetailAnalysis_SelectedProducts") = ProductCodeList

                    If RadioButtonSelectJobs_AllJobs.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_SelectedJobs") = Nothing

                    Else

                        _ParameterDictionary("JobDetailAnalysis_SelectedJobs") = DataGridViewSelectJobs_Jobs.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                    End If

                    If RadioButtonSelectAccountExecutives_AllAccountExecutives.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = Nothing

                    Else

                        _ParameterDictionary("JobDetailAnalysis_SelectedAccountExecutives") = DataGridViewSelectAccountExecutives_AccountExecutives.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If RadioButtonSelectSalesClasses_AllSalesClasses.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = Nothing

                    Else

                        _ParameterDictionary("JobDetailAnalysis_SelectedSalesClasses") = DataGridViewSelectSalesClasses_SalesClasses.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If RadioButtonSortBy_ClientDivisionProduct.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_SortBy") = "ClientDivisionProduct"

                    Else

                        _ParameterDictionary("JobDetailAnalysis_SortBy") = "AccountExecutive"

                    End If

                    If RadioButtonInclude_OpenJobsOnly.Checked Then

                        _ParameterDictionary("JobDetailAnalysis_Include") = "OpenJobsOnly"

                    Else

                        _ParameterDictionary("JobDetailAnalysis_Include") = "OpenAndClosedJobs"

                    End If

                    _ParameterDictionary("JobDetailAnalysis_ExcludeNonBillableHours") = CheckBoxVersionAndOptions_ExcludeNonBillableHours.Checked
                    _ParameterDictionary("JobDetailAnalysis_DateCutOff") = ComboBoxForm_PostPeriod.SelectedValue
                    _ParameterDictionary("JobDetailAnalysis_SuppressZeroMU") = CheckBoxVersionAndOptions_SuppressZeroMUDown.Checked

                    If _IsUserDefinedReport Then

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Report, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    End If



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
        Private Sub CDPChooserControlSelectClients_SelectClients_DataGridViewSelectionChangedEvent() Handles CDPChooserControlSelectClients_SelectClients.DataGridViewSelectionChangedEvent

            LoadJobs()

        End Sub
        Private Sub DataGridViewVersionAndOptions_Versions_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewVersionAndOptions_Versions.SelectionChangedEvent

            If Me.DataGridViewVersionAndOptions_Versions.HasASelectedRow Then
                If DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v011") = True Then
                    CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v029") = True Then
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = True
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v030") = True Then
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v031") = True Then
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v003") = True Then
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v005") = True Then
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Cli/Div/Prd"
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = True
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = False
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v006") = True Or
                       DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v007") = True Then
                    Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = False
                    Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = False
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v008") = True Then
                    Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = False
                    Me.CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Checked = False
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = False
                    ComboBoxForm_PostPeriod.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSortBy_AccountExecutive.Checked = False
                    RadioButtonSortBy_AccountExecutive.Enabled = False
                ElseIf DataGridViewVersionAndOptions_Versions.GetFirstSelectedRowDataBoundItem.ToString.Contains("v009") = True Then
                    Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = False
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = True
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    'RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                Else
                    Me.CheckBoxVersionAndOptions_ExcludeNonBillableHours.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Enabled = True
                    RadioButtonSummaryOptions_SummaryByFunction.Checked = True
                    RadioButtonSummaryOptions_DetailByFunction.Enabled = True
                    RadioButtonSummaryOption_JobComp.Enabled = False
                    RadioButtonSummaryOption_JobComp.Checked = False
                    RadioButtonSummaryOption_JobComp.Text = "Summary by Job Comp"
                    ComboBoxForm_PostPeriod.Enabled = True
                    'RadioButtonSummaryOptions_SummaryByFunction.Checked = False
                    RadioButtonSortBy_AccountExecutive.Enabled = True
                    CheckBoxVersionAndOptions_SuppressZeroMUDown.Enabled = False
                End If
            End If

        End Sub

        Private Sub RadioButtonInclude_OpenJobsOnly_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonInclude_OpenJobsOnly.CheckedChanged

            If RadioButtonSelectJobs_ChooseJobs.Checked AndAlso RadioButtonJobStatus_OpenJobs.Checked Then

                LoadJobs()

            End If

        End Sub

        Private Sub RadioButtonInclude_OpenAndClosedJobs_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonInclude_OpenAndClosedJobs.CheckedChanged

            If RadioButtonSelectJobs_ChooseJobs.Checked AndAlso RadioButtonInclude_OpenAndClosedJobs.Checked Then

                LoadJobs()

            End If

        End Sub


#End Region

#End Region

    End Class

End Namespace
