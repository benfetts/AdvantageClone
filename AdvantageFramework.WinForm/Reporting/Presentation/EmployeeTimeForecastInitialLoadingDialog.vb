Namespace Reporting.Presentation

    Public Class EmployeeTimeForecastInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))
            'Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            '_ReportType = ReportType
            '_DynamicReport = DynamicReport
            '_ShowReportOption = ShowReportOption

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult
            'Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimeForecastInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.EmployeeTimeForecastInitialLoadingDialog = Nothing

            EmployeeTimeForecastInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.EmployeeTimeForecastInitialLoadingDialog(ParameterDictionary)
            'DynamicReport, ShowReportOption, ReportType, ParameterDictionary

            ShowFormDialog = EmployeeTimeForecastInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EmployeeTimeForecastInitialLoadingDialog.ParameterDictionary

            End If

        End Function

        Private Sub EnableOrDisableActions()

        End Sub

        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxForm_EndPostPeriod.SetRequired(True)


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_EndPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                Try

                    ComboBoxForm_EndPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

                Catch ex As Exception
                    ComboBoxForm_EndPostPeriod.SelectedValue = Nothing
                End Try

            End Using

            If _ParameterDictionary IsNot Nothing Then

                Try

                    ComboBoxForm_EndPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.PostPeriod.ToString)

                Catch ex As Exception

                End Try

            End If

            'CDPChooserControlSelectClients_SelectClients.ForceResize()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Employees.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Code)
                'AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                ComboBoxForm_Employees.SelectedValue = Nothing

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Offices.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Code)

                ComboBoxForm_Offices.SelectedValue = Nothing

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            'Dim ClientCodeList As Generic.List(Of String) = Nothing
            'Dim DivisionCodeList As Generic.List(Of String) = Nothing
            'Dim ProductCodeList As Generic.List(Of String) = Nothing
            Dim SelectedCodesList As Generic.List(Of String) = Nothing

            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                'If _ShowReportOption Then

                '    _ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

                'Else

                'End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.UserID.ToString) = Session.UserCode

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.PostPeriod.ToString) = ComboBoxForm_EndPostPeriod.SelectedValue

                'If RadioButtonSelectOffices_AllOffices.Checked Then

                '    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.OfficeCode.ToString) = Nothing

                'Else

                '    SelectedCodesList = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                '    _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.OfficeCode.ToString) = SelectedCodesList(0).ToString
                '    'DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList

                'End If

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.EmployeeCode.ToString) = ComboBoxForm_Employees.SelectedValue

                _ParameterDictionary(AdvantageFramework.Reporting.EmployeeTimeForecastInitialParameters.OfficeCode.ToString) = ComboBoxForm_Offices.SelectedValue

                'AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)
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

        'Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

        '    If Me.FormShown Then

        '        If RadioButtonSelectOffices_AllOffices.Checked Then

        '            DataGridViewSelectOffices_Offices.Enabled = False

        '        End If

        '    End If

        'End Sub
        'Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

        '    If Me.FormShown Then

        '        If RadioButtonSelectOffices_ChooseOffices.Checked Then

        '            If DataGridViewSelectOffices_Offices.HasRows = False Then

        '                LoadOffices()

        '            End If

        '            DataGridViewSelectOffices_Offices.Enabled = True

        '        End If

        '    End If

        'End Sub


#End Region

#End Region

    End Class

End Namespace
