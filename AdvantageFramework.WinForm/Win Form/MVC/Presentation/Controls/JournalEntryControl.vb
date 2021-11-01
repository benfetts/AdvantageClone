Namespace WinForm.MVC.Presentation.Controls

    Public Class JournalEntryControl

        Public Event Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event Details_SelectionChangedEvent(sender As Object, e As EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.GeneralLedger.JournalEntriesBudgets.JournalEntryViewModel
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

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.GeneralLedger.JournalEntriesBudgets.JournalEntryController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                    NumericInputControl_Transaction.SetRequired(True)
                    NumericInputControl_Transaction.ReadOnly = True

                    'TextBoxControl_SourceCode.SetRequired(True)
                    TextBoxControl_SourceCode.ReadOnly = True
                    TextBoxControl_SourceCode.BackColor = System.Drawing.SystemColors.Control

                    GridLookUpEditControl_PostPeriod.SetRequired(True)
                    GridLookUpEditControl_PostPeriod.AddInactiveItemsOnSelectedValue = True
                    GridLookUpEditControl_PostPeriod.Properties.ImmediatePopup = False
                    GridLookUpEditControl_PostPeriod.Properties.SearchMode = DevExpress.XtraEditors.Repository.GridLookUpSearchMode.AutoComplete
                    GridLookUpEditControl_PostPeriod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
                    GridLookUpEditControl_PostPeriod.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup

                    GridLookUpEditControl_PostPeriod.DataSource = _Controller.LoadGLPostPeriods

                    TextBoxControl_Description.SetPropertySettings(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntry.Properties.Description)

                    RadioButtonType_Standard.ByPassUserEntryChanged = False
                    RadioButtonType_Reversing.ByPassUserEntryChanged = False

                    DateEditControl_TransactionDate.SetRequired(True)
                    DateEditControl_TransactionDate.ReadOnly = False
                    DateEditControl_TransactionDate.ByPassUserEntryChanged = False
                    DateEditControl_TransactionDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False

                    DateEditControl_CreateDate.ReadOnly = True
                    TextBoxControl_CreatedBy.ReadOnly = True
                    DateEditControl_PostedDate.ReadOnly = True
                    DateEditControl_PostedDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                    DateEditControl_PostedDate.Properties.NullDate = Date.MinValue
                    DateEditControl_PostedDate.Properties.NullText = String.Empty

                    ClearControl()

                    FormatGrid()

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadViewModel()

            NumericInputControl_Transaction.EditValue = _ViewModel.JournalEntry.Transaction
            GridLookUpEditControl_PostPeriod.SelectedValue = _ViewModel.JournalEntry.PostPeriodCode
            TextBoxControl_Description.Text = _ViewModel.JournalEntry.Description

            If _ViewModel.JournalEntry.ReverseFlag = False Then

                RadioButtonType_Standard.Checked = True
                RadioButtonType_Reversing.Checked = False

            Else

                RadioButtonType_Reversing.Checked = True
                RadioButtonType_Standard.Checked = False

            End If

            If _ViewModel.JournalEntry.IsVoided Then

                LabelControl_Voided.Visible = True

            Else

                LabelControl_Voided.Visible = False

            End If

            TextBoxControl_SourceCode.Text = _ViewModel.JournalEntry.GLSourceCode
            DateEditControl_TransactionDate.EditValue = _ViewModel.JournalEntry.EnteredDate
            DateEditControl_CreateDate.EditValue = _ViewModel.JournalEntry.CreateDate
            TextBoxControl_CreatedBy.Text = _ViewModel.JournalEntry.UserCode
            DateEditControl_PostedDate.EditValue = _ViewModel.JournalEntry.PostedDate.GetValueOrDefault(Nothing)

            DataGridViewControl_JEDetails.DataSource = _ViewModel.JournalEntryDetails

            If _ViewModel.AllowEdit Then

                GridLookUpEditControl_PostPeriod.ReadOnly = False
                TextBoxControl_Description.ReadOnly = False
                RadioButtonType_Standard.Enabled = True
                RadioButtonType_Reversing.Enabled = True
                DateEditControl_TransactionDate.ReadOnly = False

                DataGridViewControl_JEDetails.OptionsBehavior.Editable = True
                DataGridViewControl_JEDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.Remark.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ClientCode.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString).OptionsColumn.AllowEdit = True
                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ProductCode.ToString).OptionsColumn.AllowEdit = True

            Else

                GridLookUpEditControl_PostPeriod.ReadOnly = True
                TextBoxControl_Description.ReadOnly = True
                RadioButtonType_Standard.Enabled = False
                RadioButtonType_Reversing.Enabled = False
                DateEditControl_TransactionDate.ReadOnly = True

                DataGridViewControl_JEDetails.OptionsBehavior.Editable = False
                DataGridViewControl_JEDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                If _ViewModel.AllowEnteredDateEditIfPostedToSummary Then

                    DateEditControl_TransactionDate.ReadOnly = False

                End If

                If _ViewModel.AllowDescriptionEditIfPostedToSummary Then

                    TextBoxControl_Description.ReadOnly = False
                    DataGridViewControl_JEDetails.OptionsBehavior.Editable = True

                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.Remark.ToString).OptionsColumn.AllowEdit = True
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ClientCode.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString).OptionsColumn.AllowEdit = False
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ProductCode.ToString).OptionsColumn.AllowEdit = False

                End If

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.JournalEntry.PostPeriodCode = GridLookUpEditControl_PostPeriod.GetSelectedValue
            _ViewModel.JournalEntry.Description = TextBoxControl_Description.Text
            _ViewModel.JournalEntry.EnteredDate = DateEditControl_TransactionDate.EditValue

            If RadioButtonType_Standard.Checked Then

                _ViewModel.JournalEntry.ReverseFlag = False

            Else

                _ViewModel.JournalEntry.ReverseFlag = True

            End If

        End Sub
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewControl_JEDetails.CurrentView.PostEditor() Then

                DataGridViewControl_JEDetails.CurrentView.UpdateCurrentRow()

            End If

            DataGridViewControl_JEDetails.CurrentView.UpdateTotalSummary()

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            DataGridViewControl_JEDetails.OptionsCustomization.AllowFilter = False
            DataGridViewControl_JEDetails.OptionsCustomization.AllowGroup = False
            DataGridViewControl_JEDetails.OptionsCustomization.AllowSort = False
            DataGridViewControl_JEDetails.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewControl_JEDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewControl_JEDetails.CurrentView.OptionsBehavior.AutoUpdateTotalSummary = True
            'DataGridViewControl_JEDetails.MultiSelect = False

            If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.SequenceNumber.ToString) IsNot Nothing Then

                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.SequenceNumber.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CDPRequired.ToString) IsNot Nothing Then

                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CDPRequired.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString) IsNot Nothing Then

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

                AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup

                DataGridViewControl_JEDetails.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub
        Protected Sub SubItemGridLookUpEditControl_QueryPopup(sender As Object, e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewControl_JEDetails.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewControl_JEDetails.CurrentView.ActiveEditor

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _Controller.LoadGeneralLedgerAccounts(_ViewModel)

                GridLookUpEdit.Properties.DataSource = BindingSource

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(Transaction As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ViewModel = _Controller.Load(Transaction)

            LoadViewModel()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            DataGridViewControl_JEDetails.CurrentView.BestFitColumns()

            LoadControl = Loaded

        End Function
        Public Function Add(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            DataGridViewControl_JEDetails.ValidateAllRows()

            SaveViewModel()

            If _ViewModel.JournalEntryDetails IsNot Nothing AndAlso _ViewModel.JournalEntryDetails.Any(Function(Entity) Entity.HasError) = False Then

                If _Controller.Validate(_ViewModel, ErrorMessage, False) Then

                    Added = _Controller.Add(_ViewModel, ErrorMessage)

                End If

            Else

                ErrorMessage = "Please fix invalid rows before continuing."

            End If

            Add = Added

        End Function
        Public Function Save(ByRef ErrorMessage As String, ByRef RefreshOnAlreadyPostedError As Boolean) As Boolean

            'objects
            Dim Saved As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            DataGridViewControl_JEDetails.ValidateAllRows()

            SaveViewModel()

            If _ViewModel.JournalEntryDetails IsNot Nothing AndAlso _ViewModel.JournalEntryDetails.Any(Function(Entity) Entity.HasError) = False Then

                RefreshOnAlreadyPostedError = False

                If _Controller.Validate(_ViewModel, ErrorMessage, RefreshOnAlreadyPostedError) Then

                    Saved = _Controller.Save(_ViewModel, ErrorMessage)

                End If

            Else

                ErrorMessage = "Please fix invalid rows before continuing."

            End If

            If Saved Then

                DataGridViewControl_JEDetails.CurrentView.RefreshData()

            End If

            Save = Saved

        End Function
        Public Function Void(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Voided As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            SaveViewModel()

            Voided = _Controller.Void(_ViewModel, ErrorMessage)

            Void = Voided

        End Function
        Public Function Copy(ByRef Transaction As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False

            ErrorMessage = String.Empty

            CloseGridEditorAndSaveValueToDataSource()

            SaveViewModel()

            Copied = _Controller.Copy(_ViewModel, Transaction, ErrorMessage)

            Copy = Copied

        End Function
        Public Function Details_CopyFrom(Transaction As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False

            ErrorMessage = String.Empty

            Copied = _Controller.Details_CopyFrom(_ViewModel, Transaction, ErrorMessage)

            If Copied Then

                DataGridViewControl_JEDetails.CurrentView.RefreshData()

                DataGridViewControl_JEDetails.GridViewSelectionChanged()

                DataGridViewControl_JEDetails.SetUserEntryChanged()

            End If

            Details_CopyFrom = Copied

        End Function
        Public Sub Details_CancelNewItemRow()

            DataGridViewControl_JEDetails.CancelNewItemRow()

            _Controller.Details_CancelNewItemRow(_ViewModel)

            DataGridViewControl_JEDetails.CurrentView.UpdateTotalSummary()

        End Sub
        Public Sub Details_Delete()

            _Controller.Details_Delete(_ViewModel)

            DataGridViewControl_JEDetails.CurrentView.RefreshData()

            DataGridViewControl_JEDetails.GridViewSelectionChanged()

            DataGridViewControl_JEDetails.SetUserEntryChanged()

        End Sub
        Public Sub ClearControl()

            _ViewModel = _Controller.Load(-1)

            GridLookUpEditControl_PostPeriod.RemoveAddedItemsFromDataSource()

            LoadViewModel()

        End Sub
        Public Sub ReverseDebitCredit()

            _Controller.ReverseDebitCredit(_ViewModel)

            DataGridViewControl_JEDetails.CurrentView.RefreshData()

            DataGridViewControl_JEDetails.SetUserEntryChanged()

        End Sub
        Public Sub ViewDocuments()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry, Database.Entities.DocumentSubLevel.Default)

            DocumentLevelSetting.GLTransaction = _ViewModel.JournalEntry.Transaction

            AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm.ShowFormDialog(Database.Entities.DocumentLevel.JournalEntry, DocumentLevelSetting,
                                                                                           WinForm.Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default,
                                                                                           True, True, True)

        End Sub
        Public Function UploadDocument() As Boolean

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim DocumentUploaded As Boolean = False

            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry, Database.Entities.DocumentSubLevel.Default)

            DocumentLevelSetting.GLTransaction = _ViewModel.JournalEntry.Transaction

            If AdvantageFramework.Desktop.Presentation.DocumentUploadDialog.ShowFormDialog(Database.Entities.DocumentLevel.JournalEntry, DocumentLevelSetting) = Windows.Forms.DialogResult.OK Then

                DocumentUploaded = True

            End If

            UploadDocument = DocumentUploaded

        End Function
        Public Sub SendASPUploadEmail()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim DocumentUploaded As Boolean = False

            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JournalEntry, Database.Entities.DocumentSubLevel.Default)

            DocumentLevelSetting.GLTransaction = _ViewModel.JournalEntry.Transaction

            If AdvantageFramework.WinForm.Presentation.SendASPUploadEmail(_Controller.Session, Database.Entities.Methods.DocumentLevel.JournalEntry, Database.Entities.Methods.DocumentSubLevel.Default, DocumentLevelSetting) Then

                AdvantageFramework.WinForm.MessageBox.Show("Upload email sent!")

            End If

        End Sub
        Public Sub SelectedOfficeChanged(OfficeCode As String)

            _Controller.SelectedOfficeChanged(_ViewModel, OfficeCode)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub JournalEntryControl_Load(sender As Object, e As EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TextBoxControl_Description_PreviewKeyDown(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles TextBoxControl_Description.PreviewKeyDown

            If e.KeyCode = Windows.Forms.Keys.Tab OrElse e.KeyCode = Windows.Forms.Keys.Enter Then

                If e.Shift = False Then

                    e.IsInputKey = True

                End If

            End If

        End Sub
        Private Sub TextBoxControl_Description_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBoxControl_Description.KeyDown

            If e.KeyCode = Windows.Forms.Keys.Tab OrElse e.KeyCode = Windows.Forms.Keys.Enter Then

                If e.Shift = False Then

                    DataGridViewControl_JEDetails.CurrentView.Focus()

                    If DataGridViewControl_JEDetails.CurrentView.RowCount = 0 Then

                        DataGridViewControl_JEDetails.CurrentView.AddNewRow()

                        DataGridViewControl_JEDetails.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle

                    Else

                        DataGridViewControl_JEDetails.CurrentView.FocusedRowHandle = 0

                    End If

                    DataGridViewControl_JEDetails.CurrentView.FocusedColumn = DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString)

                    DataGridViewControl_JEDetails.CurrentView.ShowEditor()

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_JEDetails_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_JEDetails.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewControl_JEDetails.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewControl_JEDetails.CurrentView.NewItemRowText = e.ErrorText

                End If

            End If

            DataGridViewControl_JEDetails.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewControl_JEDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_JEDetails.SelectionChangedEvent

            _Controller.SelectedDetailChanged(_ViewModel, DataGridViewControl_JEDetails.IsNewItemRow, DataGridViewControl_JEDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail).ToList)

            RaiseEvent Details_SelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_JEDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_JEDetails.InitNewRowEvent

            'objects
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing

            _Controller.Details_InitNewRowEvent(_ViewModel)

            JournalEntryDetail = DirectCast(DataGridViewControl_JEDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            If DataGridViewControl_JEDetails.CurrentView.RowCount > 0 Then

                JournalEntryDetail.Remark = DirectCast(DataGridViewControl_JEDetails.CurrentView.GetRow(DataGridViewControl_JEDetails.CurrentView.RowCount - 1), AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail).Remark

            Else

                JournalEntryDetail.Remark = TextBoxControl_Description.Text

            End If

            If _ViewModel.AddEnabled = False Then

                If JournalEntryDetail.Remark = TextBoxControl_Description.Text Then

                    JournalEntryDetail.RemarkIsTheSameAsHeaderDescription = True

                End If

            End If

            RaiseEvent Details_InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_JEDetails_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_JEDetails.CellValueChangedEvent

            'objects
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing

            JournalEntryDetail = DirectCast(DataGridViewControl_JEDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail)

            If e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString Then

                JournalEntryDetail.CreditAmount = -Math.Abs(e.Value)

                If e.Value IsNot Nothing AndAlso JournalEntryDetail.DebitAmount.HasValue Then

                    JournalEntryDetail.DebitAmount = Nothing

                End If

                DataGridViewControl_JEDetails.CurrentView.UpdateTotalSummary()

            ElseIf e.Value IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString Then

                JournalEntryDetail.DebitAmount = Math.Abs(e.Value)

                If JournalEntryDetail.CreditAmount.HasValue Then

                    JournalEntryDetail.CreditAmount = Nothing

                End If

                DataGridViewControl_JEDetails.CurrentView.UpdateTotalSummary()

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString Then

                _Controller.GetRepositoryGLDetails(_ViewModel, e.Value, JournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ClientCode.ToString Then

                _Controller.JournalEntryDetailClientCodeChanged(_ViewModel, e.Value, JournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString Then

                _Controller.JournalEntryDetailDivisionCodeChanged(_ViewModel, e.Value, JournalEntryDetail)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.Remark.ToString Then

                _Controller.RemarkChanged(_ViewModel, TextBoxControl_Description.Text, e.Value, JournalEntryDetail)

            End If

        End Sub
        Private Sub DataGridViewControl_JEDetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_JEDetails.DataSourceChangedEvent

            DataGridViewControl_JEDetails.CurrentView.OptionsView.ShowFooter = True

            If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString) IsNot Nothing Then

                If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.CreditAmount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString) IsNot Nothing Then

                If DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewControl_JEDetails.Columns(AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DebitAmount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_JEDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_JEDetails.QueryPopupNeedDatasourceEvent

            'objects
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing

            JournalEntryDetail = DataGridViewControl_JEDetails.CurrentView.GetRow(DataGridViewControl_JEDetails.CurrentView.FocusedRowHandle)

            If FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString Then

                OverrideDefaultDatasource = True

                _Controller.LoadRepositoryDivisions(_ViewModel, JournalEntryDetail.ClientCode)

                Datasource = _ViewModel.RepositoryDivisions

            ElseIf FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ProductCode.ToString Then

                OverrideDefaultDatasource = True

                _Controller.LoadRepositoryProducts(_ViewModel, JournalEntryDetail.ClientCode, JournalEntryDetail.DivisionCode)

                Datasource = _ViewModel.RepositoryProducts

            End If

        End Sub
        Private Sub DataGridViewControl_JEDetails_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_JEDetails.RepositoryDataSourceLoadingEvent

            Select Case FieldName

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.GLACode.ToString

                    Datasource = _ViewModel.RepositoryGeneralLedgerAccounts

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ClientCode.ToString

                    Datasource = _ViewModel.RepositoryClients

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString

                    Datasource = _ViewModel.RepositoryDivisions

                Case AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ProductCode.ToString

                    Datasource = _ViewModel.RepositoryProducts

            End Select

        End Sub
        Private Sub DataGridViewControl_JEDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_JEDetails.ShowingEditorEvent

            'objects
            Dim JournalEntryDetail As AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail = Nothing

            JournalEntryDetail = DataGridViewControl_JEDetails.CurrentView.GetRow(DataGridViewControl_JEDetails.CurrentView.FocusedRowHandle)

            If DataGridViewControl_JEDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.DivisionCode.ToString AndAlso
                    (JournalEntryDetail Is Nothing OrElse String.IsNullOrWhiteSpace(JournalEntryDetail.ClientCode)) Then

                e.Cancel = True

            ElseIf DataGridViewControl_JEDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.GeneralLedger.JournalEntry.JournalEntryDetail.Properties.ProductCode.ToString AndAlso
                    (JournalEntryDetail Is Nothing OrElse String.IsNullOrWhiteSpace(JournalEntryDetail.DivisionCode)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewControl_JEDetails_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewControl_JEDetails.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit,
                                DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns

                            MenuItem.Visible = True

                        Case Else

                            MenuItem.Visible = False

                    End Select

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Group Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    MenuItem.Visible = False

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Summary Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    MenuItem.Visible = False

                Next

            ElseIf e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    MenuItem.Visible = False

                Next

            End If

        End Sub
        Private Sub GridLookUpEditControl_PostPeriod_SetInactiveValue(Value As Object) Handles GridLookUpEditControl_PostPeriod.SetInactiveValue

            'objects
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            PostPeriod = _Controller.GetInactivePostPeriod(Value)

            If PostPeriod IsNot Nothing Then

                GridLookUpEditControl_PostPeriod.AddComboItemToExistingDataSource(PostPeriod.Description, PostPeriod.Code, False)

                GridLookUpEditControl_PostPeriod.EditValue = PostPeriod.Code

            End If

        End Sub
        Private Sub TextBoxControl_Description_TextChanged(sender As Object, e As EventArgs) Handles TextBoxControl_Description.TextChanged

            If TextBoxControl_Description.Focused AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.AddEnabled = False Then

                _Controller.DescriptionChanged(_ViewModel, TextBoxControl_Description.Text)

                DataGridViewControl_JEDetails.CurrentView.RefreshData()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
