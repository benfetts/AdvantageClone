Namespace WinForm.MVC.Presentation.Controls

    Public Class RecurringJournalEntryControl

        Public Event Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event Details_SelectionChangedEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryViewModel
            Get
                ViewModel = _ViewModel
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.RecurringJournalEntryController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                    NumericInputControl_ControlNumber.SetRequired(True)
                    NumericInputControl_ControlNumber.ReadOnly = True

                    ComboBoxControl_Cycle.AddInactiveItemsOnSelectedValue = True
                    ComboBoxControl_Cycle.SetRequired(True)
                    ComboBoxControl_Cycle.DisplayMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle.Properties.Name.ToString
                    ComboBoxControl_Cycle.ValueMember = AdvantageFramework.DTO.GeneralLedger.JournalEntry.Cycle.Properties.Code.ToString
                    ComboBoxControl_Cycle.DataSource = _Controller.LoadCycles()

                    'ComboBoxControl_StartingPostPeriod.SetRequired(True)
                    ComboBoxControl_StartingPostPeriod.DisplayMember = "Display"
                    ComboBoxControl_StartingPostPeriod.ValueMember = "Value"
                    ComboBoxControl_StartingPostPeriod.DataSource = _Controller.LoadPostPeriods()

                    NumericInputControl_NumberOfPostings.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                    NumericInputControl_NumberOfPostings.Properties.MinValue = 1
                    NumericInputControl_NumberOfPostings.Properties.MaxValue = Integer.MaxValue

                    TextBoxControl_Description.SetPropertySettings(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntry.Properties.Description)

                    TextBoxControl_CreatedBy.Enabled = False

                    DateTimePickerControl_LastPostingDate.Enabled = False
                    DateTimePickerControl_LastPostingDate.AllowEmptyState = True

                    TextBoxControl_LastPostingPeriod.Enabled = False

                    NumericInputControl_TotalNumberPosted.Enabled = False
                    NumericInputControl_TotalNumberPosted.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                    TextBoxControl_PostedBy.Enabled = False

                    RadioButtonType_Standard.ByPassUserEntryChanged = False
                    RadioButtonType_Reversing.ByPassUserEntryChanged = False

                    ClearControl()

                    FormatGrid()

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadViewModel()

            NumericInputControl_ControlNumber.EditValue = _ViewModel.RecurringJournalEntry.ControlNumber
            CheckBoxControl_Inactive.Checked = _ViewModel.RecurringJournalEntry.IsInactive
            ComboBoxControl_Cycle.SelectedValue = _ViewModel.RecurringJournalEntry.CycleCode
            ComboBoxControl_StartingPostPeriod.SelectedValue = _ViewModel.RecurringJournalEntry.StartingPostPeriodCode
            TextBoxControl_CreatedBy.Text = _ViewModel.RecurringJournalEntry.UserCode
            CheckBoxControl_UnlimitedPostings.Checked = _ViewModel.RecurringJournalEntry.UnlimitedPostings
            NumericInputControl_NumberOfPostings.EditValue = _ViewModel.RecurringJournalEntry.NumberOfPostings

            TextBoxControl_Description.Text = _ViewModel.RecurringJournalEntry.Description

            If _ViewModel.RecurringJournalEntry.ReverseFlag = False Then

                RadioButtonType_Standard.Checked = True
                RadioButtonType_Reversing.Checked = False

            Else

                RadioButtonType_Reversing.Checked = True
                RadioButtonType_Standard.Checked = False

            End If

            DateTimePickerControl_LastPostingDate.Value = _ViewModel.RecurringJournalEntry.LastPostingDate.GetValueOrDefault(Nothing)
            TextBoxControl_LastPostingPeriod.Text = _ViewModel.RecurringJournalEntry.LastPostPeriodCode
            NumericInputControl_TotalNumberPosted.EditValue = _Controller.LoadTotalNumberOfPosted(_ViewModel)
            TextBoxControl_PostedBy.Text = _ViewModel.RecurringJournalEntry.LastPostingUserCode

            DataGridViewControl_RJEDetails.DataSource = _ViewModel.RecurringJournalEntryDetails

            If _ViewModel.RecurringJournalEntry.LegacyEntry Then

                NumericInputControl_NumberOfPostings.ReadOnly = True
                CheckBoxControl_UnlimitedPostings.Enabled = False
                ComboBoxControl_StartingPostPeriod.ReadOnly = True
                ComboBoxControl_StartingPostPeriod.SetRequired(False)

            Else

                CheckBoxControl_UnlimitedPostings.Enabled = True

                If CheckBoxControl_UnlimitedPostings.Checked Then

                    NumericInputControl_NumberOfPostings.ReadOnly = True
                    NumericInputControl_NumberOfPostings.SetRequired(False)
                    NumericInputControl_NumberOfPostings.EditValue = Nothing

                Else

                    NumericInputControl_NumberOfPostings.ReadOnly = False
                    NumericInputControl_NumberOfPostings.SetRequired(True)

                    If NumericInputControl_NumberOfPostings.EditValue Is Nothing Then

                        NumericInputControl_NumberOfPostings.EditValue = 1

                    End If

                End If

                ComboBoxControl_StartingPostPeriod.ReadOnly = False
                ComboBoxControl_StartingPostPeriod.SetRequired(True)

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.RecurringJournalEntry.CycleCode = ComboBoxControl_Cycle.GetSelectedValue
            _ViewModel.RecurringJournalEntry.StartingPostPeriodCode = ComboBoxControl_StartingPostPeriod.GetSelectedValue
            _ViewModel.RecurringJournalEntry.NumberOfPostings = NumericInputControl_NumberOfPostings.GetValue
            _ViewModel.RecurringJournalEntry.UnlimitedPostings = CheckBoxControl_UnlimitedPostings.Checked

            _ViewModel.RecurringJournalEntry.IsInactive = CheckBoxControl_Inactive.Checked

            _ViewModel.RecurringJournalEntry.Description = TextBoxControl_Description.Text

            If RadioButtonType_Standard.Checked Then

                _ViewModel.RecurringJournalEntry.ReverseFlag = False

            Else

                _ViewModel.RecurringJournalEntry.ReverseFlag = True

            End If

        End Sub
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewControl_RJEDetails.CurrentView.PostEditor() Then

                DataGridViewControl_RJEDetails.CurrentView.UpdateCurrentRow()

            End If

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            DataGridViewControl_RJEDetails.OptionsCustomization.AllowFilter = False
            DataGridViewControl_RJEDetails.OptionsCustomization.AllowGroup = False
            DataGridViewControl_RJEDetails.OptionsCustomization.AllowSort = False
            DataGridViewControl_RJEDetails.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewControl_RJEDetails.OptionsCustomization.AllowColumnMoving = False

            'DataGridViewControl_RJEDetails.MultiSelect = False

            If DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.GLACode.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Code"
                SubItemGridLookUpEditControl.ValueMember = "Code"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Office"))

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _ViewModel.RepositoryGeneralLedgerAccounts

                SubItemGridLookUpEditControl.DataSource = BindingSource

                DataGridViewControl_RJEDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.GLACode.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ControlNumber As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ViewModel = _Controller.Load(ControlNumber)

            LoadViewModel()

            If _ViewModel.AddEnabled Then

                CheckBoxControl_Inactive.Visible = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            DataGridViewControl_RJEDetails.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function
        Public Function Add(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            SaveViewModel()

            If _Controller.Validate(_ViewModel, ErrorMessage) Then

                Added = _Controller.Add(_ViewModel, ErrorMessage)

            End If

            Add = Added

        End Function
        Public Function Save(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            SaveViewModel()

            If _Controller.Validate(_ViewModel, ErrorMessage) Then

                Saved = _Controller.Save(_ViewModel, ErrorMessage)

            End If

            If Saved Then

                DataGridViewControl_RJEDetails.CurrentView.RefreshData()

            End If

            Save = Saved

        End Function
        Public Function Copy(ByRef ControlNumber As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            SaveViewModel()

            Copied = _Controller.Copy(_ViewModel, ControlNumber, ErrorMessage)

            Copy = Copied

        End Function
        Public Function Details_CopyFrom(ControlNumber As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False

            ErrorMessage = String.Empty

            Copied = _Controller.Details_CopyFrom(_ViewModel, ControlNumber, ErrorMessage)

            If Copied Then

                DataGridViewControl_RJEDetails.CurrentView.RefreshData()

                DataGridViewControl_RJEDetails.GridViewSelectionChanged()

                DataGridViewControl_RJEDetails.SetUserEntryChanged()

            End If

            Details_CopyFrom = Copied

        End Function
        Public Sub Details_CancelNewItemRow()

            DataGridViewControl_RJEDetails.CancelNewItemRow()

            _Controller.Details_CancelNewItemRow(_ViewModel)

        End Sub
        Public Sub Details_Delete()

            _Controller.Details_Delete(_ViewModel)

            DataGridViewControl_RJEDetails.CurrentView.RefreshData()

            DataGridViewControl_RJEDetails.GridViewSelectionChanged()

            DataGridViewControl_RJEDetails.SetUserEntryChanged()

        End Sub
        Public Sub ClearControl()

            _ViewModel = _Controller.Load(-1)

            LoadViewModel()

        End Sub
        Public Sub ReverseDebitCredit()

            _Controller.ReverseDebitCredit(_ViewModel)

            DataGridViewControl_RJEDetails.CurrentView.RefreshData()

            DataGridViewControl_RJEDetails.SetUserEntryChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RecurringJournalEntryControl_Load(sender As Object, e As EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_RJEDetails_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_RJEDetails.ValidateRowEvent

            e.Valid = True

            DataGridViewControl_RJEDetails.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewControl_RJEDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_RJEDetails.SelectionChangedEvent

            _Controller.SelectedDetailChanged(_ViewModel, DataGridViewControl_RJEDetails.IsNewItemRow, DataGridViewControl_RJEDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail).ToList)

            RaiseEvent Details_SelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_RJEDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_RJEDetails.InitNewRowEvent

            'objects
            Dim RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail = Nothing

            _Controller.Details_InitNewRowEvent(_ViewModel)

            RecurringJournalEntryDetail = DirectCast(DataGridViewControl_RJEDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            If DataGridViewControl_RJEDetails.CurrentView.RowCount > 0 Then

                RecurringJournalEntryDetail.Remark = DirectCast(DataGridViewControl_RJEDetails.CurrentView.GetRow(DataGridViewControl_RJEDetails.CurrentView.RowCount - 1), AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail).Remark

            Else

                RecurringJournalEntryDetail.Remark = TextBoxControl_Description.Text

            End If

            If _ViewModel.AddEnabled = False Then

                If RecurringJournalEntryDetail.Remark = TextBoxControl_Description.Text Then

                    RecurringJournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                End If

            End If

            RaiseEvent Details_InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_RJEDetails_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_RJEDetails.CellValueChangedEvent

            'objects
            Dim RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail = Nothing

            RecurringJournalEntryDetail = DirectCast(DataGridViewControl_RJEDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail)

            If e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString Then

                RecurringJournalEntryDetail.CreditAmount = -Math.Abs(e.Value)

                If e.Value IsNot Nothing AndAlso RecurringJournalEntryDetail.DebitAmount.HasValue Then

                    RecurringJournalEntryDetail.DebitAmount = Nothing

                End If

            ElseIf e.Value IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString Then

                RecurringJournalEntryDetail.DebitAmount = Math.Abs(e.Value)

                If RecurringJournalEntryDetail.CreditAmount.HasValue Then

                    RecurringJournalEntryDetail.CreditAmount = Nothing

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.GLACode.ToString Then

                _Controller.GetRepositoryGLDetails(_ViewModel, e.Value, RecurringJournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.ClientCode.ToString Then

                _Controller.RecurringJournalEntryDetailClientCodeChanged(_ViewModel, e.Value, RecurringJournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DivisionCode.ToString Then

                _Controller.RecurringJournalEntryDetailDivisionCodeChanged(_ViewModel, e.Value, RecurringJournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.Remark.ToString Then

                _Controller.RemarkChanged(_ViewModel, TextBoxControl_Description.Text, e.Value, RecurringJournalEntryDetail)

            End If

        End Sub
        Private Sub DataGridViewControl_RJEDetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_RJEDetails.DataSourceChangedEvent

            DataGridViewControl_RJEDetails.CurrentView.OptionsView.ShowFooter = True

            If DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString) IsNot Nothing Then

                If DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString) IsNot Nothing Then

                If DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_RJEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_RJEDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_RJEDetails.QueryPopupNeedDatasourceEvent

            'objects
            Dim RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail = Nothing

            RecurringJournalEntryDetail = DataGridViewControl_RJEDetails.CurrentView.GetRow(DataGridViewControl_RJEDetails.CurrentView.FocusedRowHandle)

            If FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DivisionCode.ToString Then

                OverrideDefaultDatasource = True

                _Controller.LoadRepositoryDivisions(_ViewModel, RecurringJournalEntryDetail.ClientCode)

                Datasource = _ViewModel.RepositoryDivisions

            ElseIf FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.ProductCode.ToString Then

                OverrideDefaultDatasource = True

                _Controller.LoadRepositoryProducts(_ViewModel, RecurringJournalEntryDetail.ClientCode, RecurringJournalEntryDetail.DivisionCode)

                Datasource = _ViewModel.RepositoryProducts

            End If

        End Sub
        Private Sub DataGridViewControl_RJEDetails_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_RJEDetails.RepositoryDataSourceLoadingEvent

            Select Case FieldName

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.GLACode.ToString

                    Datasource = _ViewModel.RepositoryGeneralLedgerAccounts

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.ClientCode.ToString

                    Datasource = _ViewModel.RepositoryClients

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DivisionCode.ToString

                    Datasource = _ViewModel.RepositoryDivisions

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.ProductCode.ToString

                    Datasource = _ViewModel.RepositoryProducts

            End Select

        End Sub
        Private Sub DataGridViewControl_RJEDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_RJEDetails.ShowingEditorEvent

            'objects
            Dim RecurringJournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail = Nothing

            RecurringJournalEntryDetail = DataGridViewControl_RJEDetails.CurrentView.GetRow(DataGridViewControl_RJEDetails.CurrentView.FocusedRowHandle)

            If DataGridViewControl_RJEDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.DivisionCode.ToString AndAlso
                    (RecurringJournalEntryDetail Is Nothing OrElse String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.ClientCode)) Then

                e.Cancel = True

            ElseIf DataGridViewControl_RJEDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.RecurringJournalEntryDetail.Properties.ProductCode.ToString AndAlso
                    (RecurringJournalEntryDetail Is Nothing OrElse String.IsNullOrWhiteSpace(RecurringJournalEntryDetail.DivisionCode)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ComboBoxControl_Cycle_SetInactiveValue(Value As Object) Handles ComboBoxControl_Cycle.SetInactiveValue

            'objects
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing

            Cycle = _Controller.GetInactiveCycle(Value)

            If Cycle IsNot Nothing Then

                ComboBoxControl_Cycle.AddComboItemToExistingDataSource(Cycle.Name, Cycle.Code, False)

                ComboBoxControl_Cycle.SelectedValue = Cycle.Code

            End If

        End Sub
        Private Sub CheckBoxControl_UnlimitedPostings_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxControl_UnlimitedPostings.CheckedChanged

            If _ViewModel IsNot Nothing AndAlso _ViewModel.RecurringJournalEntry.LegacyEntry = False Then

                If CheckBoxControl_UnlimitedPostings.Checked Then

                    NumericInputControl_NumberOfPostings.ReadOnly = True
                    NumericInputControl_NumberOfPostings.EditValue = Nothing
                    NumericInputControl_NumberOfPostings.SetRequired(False)

                Else

                    NumericInputControl_NumberOfPostings.ReadOnly = False
                    NumericInputControl_NumberOfPostings.SetRequired(True)
                    NumericInputControl_NumberOfPostings.EditValue = 1

                End If

            Else

                NumericInputControl_NumberOfPostings.ReadOnly = True

            End If

        End Sub
        Private Sub TextBoxControl_Description_TextChanged(sender As Object, e As EventArgs) Handles TextBoxControl_Description.TextChanged

            If TextBoxControl_Description.Focused AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.AddEnabled = False Then

                _Controller.DescriptionChanged(_ViewModel, TextBoxControl_Description.Text)

                DataGridViewControl_RJEDetails.CurrentView.RefreshData()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace