Namespace Reporting.Presentation

    Public Class MediaResultsInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub HideShowSelection()
            If RadioButtonDates_Standard.Checked = True Then

                CheckBoxBroadcastDates.Checked = False

                LabelForm_Criteria.Enabled = True
                ComboBoxForm_Criteria.Enabled = True
                DateTimePickerForm_From.Enabled = True
                DateTimePickerForm_To.Enabled = True
                ButtonForm_YTD.Enabled = True
                ButtonForm_1Year.Enabled = True
                ButtonForm_MTD.Enabled = True
                ButtonForm_2Years.Enabled = True

                CheckBoxBroadcastDates.Enabled = False
                LabelOptions_MonthlyBroadcast.Enabled = False
                ComboBoxMonthlyBroadcast_FromMonth.Enabled = False
                ComboBoxMonthlyBroadcast_ToMonth.Enabled = False
                NumericInputMonthlyBroadcast_FromYear.Enabled = False
                NumericInputMonthlyBroadcast_ToYear.Enabled = False

            Else

                CheckBoxBroadcastDates.Checked = True

                LabelOptions_MonthlyBroadcast.Enabled = True
                ComboBoxMonthlyBroadcast_FromMonth.Enabled = True
                ComboBoxMonthlyBroadcast_ToMonth.Enabled = True
                NumericInputMonthlyBroadcast_FromYear.Enabled = True
                NumericInputMonthlyBroadcast_ToYear.Enabled = True

                LabelForm_Criteria.Enabled = False
                ComboBoxForm_Criteria.Enabled = False
                DateTimePickerForm_From.Enabled = False
                DateTimePickerForm_To.Enabled = False
                ButtonForm_YTD.Enabled = False
                ButtonForm_1Year.Enabled = False
                ButtonForm_MTD.Enabled = False
                ButtonForm_2Years.Enabled = False

            End If
        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MediaResultsInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaResultsInitialLoadingDialog = Nothing

            MediaResultsInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaResultsInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = MediaResultsInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaResultsInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaResultsInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerForm_From.Value = Now
            DateTimePickerForm_To.Value = Now

            DateTimePickerForm_From.SetRequired(True)
            DateTimePickerForm_To.SetRequired(True)

            ComboBoxForm_Criteria.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.DigitalResultsCriteria), False)

            If _DynamicReport = AdvantageFramework.Reporting.DynamicReports.MediaResults Then

                'CheckBoxBroadcastDates.Visible = True
                LabelOptions_SelectBy.Visible = True
                PanelOptions_Dates.Visible = True
                RadioButtonDates_Standard.Visible = True
                RadioButtonDates_Broadcast.Visible = True

                NumericInputMonthlyBroadcast_FromYear.SetRequired(True)
                NumericInputMonthlyBroadcast_ToYear.SetRequired(True)

                NumericInputMonthlyBroadcast_FromYear.Properties.MinValue = 1900
                NumericInputMonthlyBroadcast_ToYear.Properties.MinValue = 1900

                ComboBoxMonthlyBroadcast_FromMonth.SetRequired(True)
                ComboBoxMonthlyBroadcast_ToMonth.SetRequired(True)

            End If

            HideShowSelection()

            ComboBoxMonthlyBroadcast_FromMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxMonthlyBroadcast_ToMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

            ComboBoxMonthlyBroadcast_FromMonth.SelectedValue = CLng(Now.Month)
            NumericInputMonthlyBroadcast_FromYear.EditValue = Now.Year

            ComboBoxMonthlyBroadcast_ToMonth.SelectedValue = CLng(Now.Month)
            NumericInputMonthlyBroadcast_ToYear.EditValue = Now.Year



        End Sub
        Private Sub MediaResultsInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click
            Dim SelectedCodesList As Generic.List(Of String) = Nothing
            Dim ClientCodeList As Generic.List(Of String) = Nothing
            Dim DivisionCodeList As Generic.List(Of String) = Nothing
            Dim ProductCodeList As Generic.List(Of String) = Nothing
            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.Criteria.ToString) = ComboBoxForm_Criteria.SelectedValue
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.StartDate.ToString) = DateTimePickerForm_From.Value
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.EndDate.ToString) = DateTimePickerForm_To.Value

                _ParameterDictionary("BroadcastDates") = CheckBoxBroadcastDates.Checked

                Dim sStartDate As String, sEndDate As String
                Dim dStartDate As DateTime, dEndDate As DateTime
                sStartDate = ComboBoxMonthlyBroadcast_FromMonth.SelectedValue.ToString + "-01-" + NumericInputMonthlyBroadcast_FromYear.EditValue.ToString
                sEndDate = ComboBoxMonthlyBroadcast_ToMonth.SelectedValue.ToString + "-01-" + NumericInputMonthlyBroadcast_ToYear.EditValue.ToString
                dStartDate = sStartDate
                dEndDate = sEndDate
                dEndDate = dEndDate.AddMonths(1)
                dEndDate = dEndDate.AddDays(-1)

                If CheckBoxBroadcastDates.Checked = True Then
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.StartDate.ToString) = dStartDate
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusParameters.EndDate.ToString) = dEndDate
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

                If RadioButtonSelectOffices_AllOffices.Checked Then
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.SelectedOffices.ToString) = Nothing
                Else
                    _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                End If


                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.SelectedClients.ToString) = ClientCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.SelectedDivisions.ToString) = DivisionCodeList
                _ParameterDictionary(AdvantageFramework.Reporting.MediaResultsParameters.SelectedProducts.ToString) = ProductCodeList


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
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, 1, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

            DateTimePickerForm_From.Value = New Date(Now.Year, Now.Month, 1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

            DateTimePickerForm_From.Value = Now.AddYears(-1)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

            DateTimePickerForm_From.Value = Now.AddYears(-2)
            DateTimePickerForm_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_To.ValueChanged

            DateTimePickerForm_From.MaxDate = DateTimePickerForm_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerForm_From.ValueChanged

            DateTimePickerForm_To.MinDate = DateTimePickerForm_From.Value

        End Sub
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

        Private Sub RadioButtonDates_Standard_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_Standard.CheckedChanged
            HideShowSelection()
        End Sub

        Private Sub RadioButtonDates_Broadcast_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDates_Broadcast.CheckedChanged
            HideShowSelection()
        End Sub

        Private Sub PanelOptions_Dates_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles PanelOptions_Dates.Paint

        End Sub

#End Region

#End Region

    End Class

End Namespace
