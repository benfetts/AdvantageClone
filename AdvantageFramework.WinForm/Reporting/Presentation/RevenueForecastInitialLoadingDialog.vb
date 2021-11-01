Namespace Reporting.Presentation

    Public Class RevenueForecastInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUserDefinedReport As Boolean = False
        Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary
        Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.JobDetailAnalysisV1Summary
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _ShowReportOption As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property Report As AdvantageFramework.Reporting.ReportTypes
            Get
                Report = _ReportType
            End Get
        End Property
        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ShowReportOption = ShowReportOption
            _ReportType = ReportType
            _ParameterDictionary = ParameterDictionary

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

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

        Public Shared Function ShowFormDialog(ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim RevenueForecastInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.RevenueForecastInitialLoadingDialog = Nothing

            RevenueForecastInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.RevenueForecastInitialLoadingDialog(ShowReportOption, ReportType, ParameterDictionary)

            ShowFormDialog = RevenueForecastInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = RevenueForecastInitialLoadingDialog.ParameterDictionary
                ReportType = RevenueForecastInitialLoadingDialog.Report

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobDetailAnalysisInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            TabControlForm_JDA.SelectedTab = TabItemJDA_VersionAndOptionsTab
            RadioButtonSummaryOption_JobComp.Enabled = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_StartingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    Try

                        ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                    Catch ex As Exception
                        ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                    Catch ex As Exception
                        ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
                    End Try

                    ComboBoxForm_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext).ToList

                End Using

            End Using

            DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = True
            DataGridViewSelectOffices_Offices.MultiSelect = True

            DataGridViewSelectOffices_Offices.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.Office)
                                                            Select [Code] = Entity.Code,
                                                                    [Name] = Entity.Name).ToList

            DataGridViewSelectSalesClasses_SalesClasses.ShowSelectDeselectAllButtons = True
            DataGridViewSelectSalesClasses_SalesClasses.MultiSelect = True

            DataGridViewSelectSalesClasses_SalesClasses.DataSource = (From Entity In New Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)
                                                                      Select [Code] = Entity.Code,
                                                                             [Description] = Entity.Description).ToList

        End Sub
        Private Sub JobDetailAnalysisInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown



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
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.CurrentPeriod.ToString) = ComboBoxForm_CurrentPeriod.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.ActualizeDate.ToString) = DateTimePickerForm_Actualize.Value

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedOffices.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                    If RadioButtonSelectSalesClasses_AllSalesClasses.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedSalesClass.ToString) = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.RevenueForecastInitialParameters.SelectedSalesClass.ToString) = DataGridViewSelectSalesClasses_SalesClasses.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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

#End Region

#End Region

    End Class

End Namespace
