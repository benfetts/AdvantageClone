Namespace WinForm.Presentation.Controls

    Public Class OtherCashReceiptControl

        Public Event TotalsChanged()
        Public Event ReceiptDetailInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event ReceiptDetailSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "

        Protected Const _GLSourceCode As String = "OR"

#End Region

#Region " Enum "

        Private Enum HeaderModifyState
            NoRestrictions = 1
            PostPeriodClosed = 2
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ID As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _BatchDate As Date = Nothing
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False
        Private _BankCode As String = Nothing
        Private _HeaderModifyState As HeaderModifyState = HeaderModifyState.NoRestrictions

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            SearchableComboBoxDepositInfo_Bank.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            NumericInputCheckInfo_Amount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.OtherCashReceipt)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            DbContext.Database.Connection.Open()

                            TextBoxPanel_CheckNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.CheckNumber)
                            TextBoxPanel_Description.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.Description)

                            DateTimePickerCheckInfo_Date.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.CheckDate)
                            NumericInputCheckInfo_Amount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.CheckAmount)
                            NumericInputCheckInfo_Amount.Properties.MinValue = -NumericInputCheckInfo_Amount.Properties.MaxValue

                            DateTimePickerDepositInfo_Date.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.DepositDate)

                            SearchableComboBoxDepositInfo_Bank.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.BankCode)
                            SearchableComboBoxDepositInfo_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).Where(Function(Entity) _Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode))

                            SearchableComboBoxDepositInfo_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                            SearchableComboBoxDepositInfo_GLAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext)

                            ComboBoxPanel_PostPeriod.AddInactiveItemsOnSelectedValue = True
                            ComboBoxPanel_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            ComboBoxPanel_PostPeriod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.PostPeriodCode)

                            ComboBoxPanel_PostPeriodForMod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            ComboBoxPanel_PostPeriodForMod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.OtherCashReceipt.Properties.PostPeriodCode)

                            SearchableComboBoxPanel_PaymentType.DataSource = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.LoadAllActive(DbContext).ToList
                            SearchableComboBoxPanel_PaymentType.AddInactiveItemsOnSelectedValue = True

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.OtherCashReceipt)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            NumericInputCheckInfo_Amount.SetFormat("n2")
                            NumericInputDisbursedTo_Balance.SetFormat("n2")
                            NumericInputDisbursedTo_ClientInvoice.SetFormat("n2")

                            DbContext.Database.Connection.Close()

                        End Using

                        NumericInputDisbursedTo_ClientInvoice.ByPassUserEntryChanged = True
                        NumericInputDisbursedTo_Balance.ByPassUserEntryChanged = True

                        DataGridViewPanel_OtherReceiptDetails.AutoFilterLookupColumns = True

                        DataGridViewTransactions_GLTransactions.MultiSelect = False
                        DataGridViewTransactions_GLTransactions.OptionsView.ShowFooter = False

                        TextBoxPanel_MessageDetails.ByPassUserEntryChanged = True

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function CalculateTotalAmount() As Boolean

            Dim OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail) = Nothing
            Dim TotalPayment As Decimal = 0

            If Not _IsLoading AndAlso Me.FindForm IsNot Nothing AndAlso Not _IsClearing Then

                NumericInputDisbursedTo_ClientInvoice.EditValue = 0

                OtherCashReceiptDetailList = DataGridViewPanel_OtherReceiptDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)().ToList
                TotalPayment = OtherCashReceiptDetailList.Where(Function(Entity) Entity.IsDeleted = False).Sum(Function(Entity) Entity.Amount)

                NumericInputDisbursedTo_ClientInvoice.EditValue = TotalPayment
                NumericInputDisbursedTo_Balance.EditValue = NumericInputCheckInfo_Amount.Value - TotalPayment

                RaiseEvent TotalsChanged()

            End If

            If NumericInputDisbursedTo_Balance.EditValue = 0 Then

                CalculateTotalAmount = True

            Else

                CalculateTotalAmount = False

            End If

        End Function
        Private Sub LoadOtherReceiptDetails(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail) = Nothing

            DataGridViewPanel_OtherReceiptDetails.CurrentView.BeginUpdate()

            OtherCashReceiptDetailList = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)

            OtherCashReceiptDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Load(DbContext).Where(Function(E) E.OtherCashReceiptID = _ID AndAlso E.OtherCashReceiptSequenceNumber = _SequenceNumber AndAlso E.ModifyDelete = False).ToList()
                                                Select New AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail(Entity))

            DataGridViewPanel_OtherReceiptDetails.DataSource = OtherCashReceiptDetailList

            DataGridViewPanel_OtherReceiptDetails.CurrentView.BestFitColumns()

            DataGridViewPanel_OtherReceiptDetails.ClearChanged()

            DataGridViewPanel_OtherReceiptDetails.CurrentView.EndUpdate()

            LoadOtherReceiptRepositoryItems()

        End Sub
        Private Sub LoadGLTransactions(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim TransactionIDs As Generic.List(Of Integer) = Nothing
            Dim TransactionList As IEnumerable(Of Object) = Nothing

            DataGridViewTransactions_GLTransactions.DataSource = Nothing

            TransactionIDs = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Load(DbContext)
                              Where Entity.OtherCashReceiptID = _ID
                              Select Entity.GLTransaction).Distinct.ToList

            TransactionList = (From GeneralLedger In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext)
                               Where TransactionIDs.Distinct.Contains(GeneralLedger.Transaction)
                               Select (New With {.Transaction = GeneralLedger.Transaction,
                                                 .PostPeriod = GeneralLedger.PostPeriodCode,
                                                 .Status = If(GeneralLedger.PostedDate IsNot Nothing, "Posted", "")})).ToList

            DataGridViewTransactions_GLTransactions.DataSource = TransactionList

            DataGridViewTransactions_GLTransactions.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadOtherCashReceiptEntity(ByVal OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt, ByVal IsNew As Boolean)

            If OtherCashReceipt IsNot Nothing Then

                If IsNew Then

                    OtherCashReceipt.CheckNumber = TextBoxPanel_CheckNumber.GetText

                End If

                OtherCashReceipt.Description = TextBoxPanel_Description.GetText

                OtherCashReceipt.DepositDate = DateTimePickerDepositInfo_Date.Value
                OtherCashReceipt.BankCode = SearchableComboBoxDepositInfo_Bank.GetSelectedValue
                OtherCashReceipt.OfficeCode = SearchableComboBoxDepositInfo_Office.GetSelectedValue
                OtherCashReceipt.GLACode = SearchableComboBoxDepositInfo_GLAccount.GetSelectedValue

                OtherCashReceipt.CheckDate = DateTimePickerCheckInfo_Date.Value
                OtherCashReceipt.CheckAmount = NumericInputCheckInfo_Amount.Value

                OtherCashReceipt.PostPeriodCode = ComboBoxPanel_PostPeriodForMod.GetSelectedValue

                OtherCashReceipt.CashReceiptPaymentTypeID = SearchableComboBoxPanel_PaymentType.GetSelectedValue

            End If

        End Sub
        Private Function OkayToDelete(ByRef PostPeriodCode As String) As Boolean

            Dim IsOkay As Boolean = False
            Dim SelectedPostPeriods As IEnumerable = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to reverse this check?", MessageBox.MessageBoxButtons.YesNo, "Reverse Check", Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2) = MessageBox.DialogResults.Yes Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.PostPeriodActiveAR, True, True, SelectedPostPeriods) = System.Windows.Forms.DialogResult.OK Then

                    If SelectedPostPeriods IsNot Nothing Then

                        Try

                            PostPeriodCode = (From Entity In SelectedPostPeriods
                                              Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            PostPeriodCode = Nothing
                        End Try

                    End If

                    If Not String.IsNullOrEmpty(PostPeriodCode) Then

                        IsOkay = True

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Reverse posting period was not selected.  Check not reversed.", , "Reverse Check")

                End If

            End If

            OkayToDelete = IsOkay

        End Function
        Private Function OkayToSave(ByRef ErrorMessage As String) As Boolean

            Dim IsOkay As Boolean = True
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If ComboBoxPanel_PostPeriodForMod.HasASelectedValue Then

                    PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, ComboBoxPanel_PostPeriodForMod.GetSelectedValue)

                    If PostPeriod IsNot Nothing AndAlso PostPeriod.ARStatus = "X" Then

                        IsOkay = False
                        ErrorMessage = "Posting period has been closed."

                    End If

                End If

            End Using

            OkayToSave = IsOkay

        End Function
        Private Sub RefreshCheck(ByVal ID As Integer, ByVal SequenceNumber As Short, ByVal BatchDate As Date)

            _ID = 0
            _SequenceNumber = 0

            LoadControl(ID, SequenceNumber, BatchDate, Nothing)

        End Sub
        Private Sub SetCurrentPostPeriod(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal HeaderPostPeriodCode As String)

            Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim PostPeriodList As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            If _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                PostPeriodList = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).ToList

            Else

                PostPeriodList = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                                  Where Entity.Code > HeaderPostPeriodCode
                                  Select Entity).ToList

            End If

            ComboBoxPanel_PostPeriodForMod.DataSource = PostPeriodList
            ComboBoxPanel_PostPeriodForMod.SelectedIndex = -1

            CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

            If HeaderPostPeriodCode IsNot Nothing Then

                If PostPeriodList.Select(Function(PPL) PPL.Code).ToArray.Contains(HeaderPostPeriodCode) Then

                    ComboBoxPanel_PostPeriodForMod.SelectedValue = HeaderPostPeriodCode

                ElseIf CurrentPostPeriod IsNot Nothing Then

                    ComboBoxPanel_PostPeriodForMod.SelectedValue = CurrentPostPeriod.Code

                End If

            Else

                If CurrentPostPeriod IsNot Nothing Then

                    ComboBoxPanel_PostPeriod.SelectedValue = CurrentPostPeriod.Code
                    ComboBoxPanel_PostPeriodForMod.SelectedValue = CurrentPostPeriod.Code

                Else

                    ComboBoxPanel_PostPeriodForMod.SelectedValue = ComboBoxPanel_PostPeriod.SelectedValue

                End If

            End If

            If PostPeriodList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("All AR Posting Periods are closed.")

                TextBoxPanel_MessageDetails.Text += Space(2) & "All AR Posting Periods are closed."
                TextBoxPanel_MessageDetails.Text = Trim(TextBoxPanel_MessageDetails.Text)

            End If

        End Sub
        Private Function ValidateControl(ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True

            DataGridViewPanel_OtherReceiptDetails.CurrentView.CloseEditorForUpdating()

            If DataGridViewPanel_OtherReceiptDetails.HasAnyInvalidRows Then

                IsValid = False
                ErrorMessage = "Fix errors in grid."

            End If

            ValidateControl = IsValid

        End Function
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewPanel_OtherReceiptDetails.UseEmbeddedNavigator = True
                DataGridViewPanel_OtherReceiptDetails.CurrentView.EnableDisabledRows = False

            Else

                DataGridViewPanel_OtherReceiptDetails.UseEmbeddedNavigator = False
                DataGridViewPanel_OtherReceiptDetails.CurrentView.EnableDisabledRows = True

            End If

        End Sub
        Private Sub LoadOtherReceiptRepositoryItems()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewPanel_OtherReceiptDetails.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Select Case GridColumn.FieldName

                                Case AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail.Properties.GLACode.ToString,
                                        AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail.Properties.GLACodeDescription.ToString

                                    SubItemGridLookUpEditControl.DataSource = AdvantageFramework.CashReceipts.GetGLAccountListExcludeBankARAPCashAccounts(DbContext)

                            End Select

                        End Using

                    End If

                End If

            Next

        End Sub
        Private Sub LoadBankDetails(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim BankCode As String = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            BankCode = SearchableComboBoxDepositInfo_Bank.GetSelectedValue

            Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, BankCode)

            If Bank IsNot Nothing Then

                SearchableComboBoxDepositInfo_Office.SelectedValue = Bank.OfficeCode
                SearchableComboBoxDepositInfo_GLAccount.SelectedValue = Bank.ARCashAccount

            End If

        End Sub
        Private Function OtherCashReceiptDetailRequiresJournalEntry(ByVal OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)) As Boolean

            Dim RequiresJE As Boolean = False

            For Each OtherCashReceiptDetail In OtherCashReceiptDetailList

                If OtherCashReceiptDetail.GLACode <> OtherCashReceiptDetail.OriginalGLACode OrElse
                        OtherCashReceiptDetail.Amount <> OtherCashReceiptDetail.OriginalAmount Then

                    RequiresJE = True
                    Exit For

                End If

            Next

            OtherCashReceiptDetailRequiresJournalEntry = RequiresJE

        End Function

#Region "  Public "

        Public Sub ClearControl()

            Me.SuspendLayout()

            _IsClearing = True

            _ID = 0
            _SequenceNumber = 0

            TextBoxPanel_CheckNumber.Text = Nothing
            TextBoxPanel_Description.Text = Nothing

            DateTimePickerCheckInfo_Date.Value = Nothing
            NumericInputCheckInfo_Amount.EditValue = Nothing

            DateTimePickerDepositInfo_Date.Value = Nothing

            If _BankCode Is Nothing Then

                SearchableComboBoxDepositInfo_Bank.SelectedValue = Nothing

            End If

            SearchableComboBoxDepositInfo_Office.SelectedValue = Nothing
            SearchableComboBoxDepositInfo_GLAccount.SelectedValue = Nothing
            CheckBoxDepositInfo_Cleared.Checked = False

            ComboBoxPanel_PostPeriod.SelectedValue = Nothing
            ComboBoxPanel_PostPeriodForMod.SelectedValue = Nothing

            SearchableComboBoxPanel_PaymentType.SelectedValue = Nothing

            DataGridViewTransactions_GLTransactions.ClearDatasource()

            NumericInputDisbursedTo_ClientInvoice.EditValue = Nothing
            NumericInputDisbursedTo_Balance.EditValue = Nothing

            DataGridViewPanel_OtherReceiptDetails.ClearDatasource()
            DataGridViewPanel_OtherReceiptDetails.ClearGridCustomization()
            DataGridViewPanel_OtherReceiptDetails.CurrentView.ClearDisabledRows()

            TextBoxPanel_MessageDetails.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

            Me.ResumeLayout()

        End Sub
        Public Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) AndAlso Me.NumericInputDisbursedTo_Balance.EditValue = 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = CalculateTotalAmount() AndAlso (DataGridViewPanel_OtherReceiptDetails.HasAnyInvalidRows = False)

                    If IsOkay Then

                        Me.ShowWaitForm("Processing...")

                        If Me.FindForm.Modal = True Then

                            Try

                                IsOkay = Insert(Nothing, Nothing, _BatchDate, Nothing)

                            Catch ex As Exception
                                IsOkay = False
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                        Else

                            Try

                                IsOkay = Save()

                            Catch ex As Exception
                                IsOkay = False
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                        End If

                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                End If

            ElseIf AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) AndAlso Me.NumericInputDisbursedTo_Balance.EditValue <> 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes, but the amount disbursed and the check amount are not equal." & vbCrLf & "Discard changes?", MessageBox.MessageBoxButtons.YesNo, "Save not allowed", Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button2) = MessageBox.DialogResults.No Then

                    IsOkay = False

                Else

                    RefreshCheck(_ID, _SequenceNumber, _BatchDate)

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Public Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.OtherCashReceipt

            Dim OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing

            Try

                If IsNew Then

                    OtherCashReceipt = New AdvantageFramework.Database.Entities.OtherCashReceipt

                    OtherCashReceipt.DbContext = DbContext

                    LoadOtherCashReceiptEntity(OtherCashReceipt, IsNew)

                Else

                    OtherCashReceipt = AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                    LoadOtherCashReceiptEntity(OtherCashReceipt, IsNew)

                End If

            Catch ex As Exception
                OtherCashReceipt = Nothing
            End Try

            FillObject = OtherCashReceipt

        End Function
        Public Function LoadControl(ByVal ID As Integer, ByVal SequenceNumber As Short, ByVal BatchDate As Date, ByVal BankCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing

            _BatchDate = BatchDate
            _BankCode = BankCode

            Me.SuspendLayout()

            _ID = ID
            _SequenceNumber = SequenceNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ID <> 0 Then

                    OtherCashReceipt = AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                    If OtherCashReceipt IsNot Nothing Then

                        _IsLoading = True

                        TextBoxPanel_CheckNumber.Text = OtherCashReceipt.CheckNumber
                        TextBoxPanel_CheckNumber.ReadOnly = True

                        TextBoxPanel_Description.Text = OtherCashReceipt.Description

                        ComboBoxPanel_PostPeriod.RemoveAddedItemsFromDataSource()
                        ComboBoxPanel_PostPeriodForMod.RemoveAddedItemsFromDataSource()

                        If OtherCashReceipt.PostPeriod.APStatus = "X" Then

                            ComboBoxPanel_PostPeriod.AddComboItemToExistingDataSource(OtherCashReceipt.PostPeriod.ToString, OtherCashReceipt.PostPeriodCode, True)
                            'ComboBoxPanel_PostPeriodForMod.AddComboItemToExistingDataSource(OtherCashReceipt.PostPeriod.Description, OtherCashReceipt.PostPeriodCode, True)

                        End If

                        ComboBoxPanel_PostPeriod.SelectedValue = OtherCashReceipt.PostPeriodCode

                        ComboBoxPanel_PostPeriodForMod.SelectedValue = OtherCashReceipt.PostPeriodCode

                        DateTimePickerCheckInfo_Date.Value = OtherCashReceipt.CheckDate
                        NumericInputCheckInfo_Amount.Value = OtherCashReceipt.CheckAmount

                        DateTimePickerDepositInfo_Date.Value = OtherCashReceipt.DepositDate
                        SearchableComboBoxDepositInfo_Bank.SelectedValue = OtherCashReceipt.BankCode

                        SearchableComboBoxDepositInfo_Office.SelectedValue = OtherCashReceipt.OfficeCode
                        SearchableComboBoxDepositInfo_GLAccount.SelectedValue = OtherCashReceipt.GLACode

                        SearchableComboBoxPanel_PaymentType.RemoveAddedItemsFromDataSource()
                        SearchableComboBoxPanel_PaymentType.SelectedValue = OtherCashReceipt.CashReceiptPaymentTypeID

                        CheckBoxDepositInfo_Cleared.Checked = If(OtherCashReceipt.IsCleared.GetValueOrDefault(0) = 1, True, False)

                        ComboBoxPanel_PostPeriod.ReadOnly = True

                        LabelPanel_PostingPeriodForMod.Visible = True
                        ComboBoxPanel_PostPeriodForMod.Visible = True
                        ComboBoxPanel_PostPeriodForMod.Enabled = True

                        LoadGLTransactions(DbContext)

                        LoadOtherReceiptDetails(DbContext)

                        TextBoxPanel_MessageDetails.Text = ""

                        If OtherCashReceipt.PostPeriod.ARStatus = "X" Then

                            TextBoxPanel_MessageDetails.Text = "Posting period has been closed.  You will not be able to change key header information.  You will be able to modify the detail distribution."

                            _HeaderModifyState = HeaderModifyState.PostPeriodClosed

                        Else

                            _HeaderModifyState = HeaderModifyState.NoRestrictions

                        End If

                        SetCurrentPostPeriod(DbContext, OtherCashReceipt.PostPeriodCode)

                        _IsLoading = False

                    Else

                        Loaded = False

                    End If

                Else

                    _IsLoading = True

                    TextBoxPanel_CheckNumber.SetRequired(True)
                    TextBoxPanel_CheckNumber.ReadOnly = False
                    TextBoxPanel_CheckNumber.Focus()

                    DateTimePickerCheckInfo_Date.Value = Nothing
                    NumericInputCheckInfo_Amount.EditValue = Nothing

                    DateTimePickerDepositInfo_Date.Value = Nothing

                    If String.IsNullOrWhiteSpace(_BankCode) = False Then

                        SearchableComboBoxDepositInfo_Bank.SelectedValue = _BankCode

                    Else

                        SearchableComboBoxDepositInfo_Bank.SelectSingleItemDataSource()

                    End If

                    LoadBankDetails(DbContext)

                    SetCurrentPostPeriod(DbContext, Nothing)
                    LabelPanel_PostingPeriodForMod.Visible = False
                    ComboBoxPanel_PostPeriodForMod.Visible = False

                    DataGridViewPanel_OtherReceiptDetails.DataSource = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)

                    DataGridViewPanel_OtherReceiptDetails.CurrentView.BestFitColumns()

                    LoadOtherReceiptRepositoryItems()

                    _IsLoading = False

                End If

                DateTimePickerCheckInfo_Date.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked
                NumericInputCheckInfo_Amount.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked

                DateTimePickerDepositInfo_Date.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked
                SearchableComboBoxDepositInfo_Bank.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked

                SearchableComboBoxPanel_PaymentType.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked

                CalculateTotalAmount()

            End Using

            Me.ResumeLayout()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            Dim OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
            Dim OtherCashReceiptOld As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
            Dim OtherCashReceiptReversal As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail) = Nothing
            Dim GLTransaction As Nullable(Of Integer) = Nothing
            Dim PostPeriodChanged As Boolean = False
            Dim GLReversalTransaction As Integer = -1

            If OkayToSave(ErrorMessage) Then

                If ValidateControl(ErrorMessage) Then

                    ErrorMessage = ""

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OtherCashReceipt = FillObject(DbContext, False)

                        OtherCashReceiptOld = AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                        If OtherCashReceipt IsNot Nothing AndAlso OtherCashReceiptOld IsNot Nothing Then

                            OtherCashReceiptDetailList = DataGridViewPanel_OtherReceiptDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)().ToList

                            If OtherCashReceipt.PostPeriodCode <> OtherCashReceiptOld.PostPeriodCode OrElse OtherCashReceipt.BankCode <> OtherCashReceiptOld.BankCode OrElse OtherCashReceipt.CheckAmount <> OtherCashReceiptOld.CheckAmount OrElse
                                   OtherCashReceiptDetailRequiresJournalEntry(OtherCashReceiptDetailList) Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Have you verified Posting Period?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                                    If OtherCashReceiptOld.PostPeriodCode <> OtherCashReceipt.PostPeriodCode AndAlso _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                        PostPeriodChanged = True

                                    End If

                                    If PostPeriodChanged OrElse OtherCashReceipt.PostPeriodCode <> OtherCashReceiptOld.PostPeriodCode OrElse OtherCashReceipt.BankCode <> OtherCashReceiptOld.BankCode OrElse OtherCashReceipt.CheckAmount <> OtherCashReceiptOld.CheckAmount OrElse
                                            OtherCashReceiptDetailRequiresJournalEntry(OtherCashReceiptDetailList) Then

                                        Try

                                            DbContext.Database.Connection.Open()

                                            DbTransaction = DbContext.Database.BeginTransaction

                                            If _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                                OtherCashReceiptReversal = AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                                                If OtherCashReceiptReversal Is Nothing OrElse OtherCashReceiptReversal.Status = "D" Then

                                                    Throw New Exception("Failed to load other cash receipt for reversal.")

                                                End If

                                                If PostPeriodChanged OrElse OtherCashReceiptOld.BankCode <> OtherCashReceipt.BankCode OrElse OtherCashReceiptOld.CheckAmount <> OtherCashReceipt.CheckAmount Then

                                                    If PostPeriodChanged Then

                                                        GLReversalTransaction = AdvantageFramework.CashReceipts.ReverseOtherCashReceipt(DbContext, OtherCashReceiptReversal, OtherCashReceiptReversal.PostPeriodCode, _BatchDate, _GLSourceCode, False)

                                                        AdvantageFramework.CashReceipts.InsertOtherCashReceipt(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.CheckState.Modify)

                                                    Else

                                                        GLTransaction = AdvantageFramework.CashReceipts.ReverseOtherCashReceipt(DbContext, OtherCashReceiptReversal, OtherCashReceipt.PostPeriodCode, _BatchDate, _GLSourceCode, False)

                                                        AdvantageFramework.CashReceipts.InsertOtherCashReceipt(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.CheckState.Modify)

                                                    End If

                                                Else

                                                    OtherCashReceipt.DbContext = DbContext

                                                    If AdvantageFramework.Database.Procedures.OtherCashReceipt.Update(DbContext, OtherCashReceipt) = False Then

                                                        Throw New Exception("Failed to update other cash receipt.")

                                                    End If

                                                    AdvantageFramework.CashReceipts.SaveOtherCashReceiptDetail(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, _GLSourceCode, _BatchDate)

                                                End If

                                            Else

                                                AdvantageFramework.CashReceipts.SaveOtherCashReceiptDetail(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, _GLSourceCode, _BatchDate)

                                            End If

                                            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_othercashreceipt_check_balanced] {0}, {1}, {2}", OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber, OtherCashReceipt.GLTransaction)).FirstOrDefault

                                            If IsBalanced = 1 Then

                                                DbTransaction.Commit()

                                            Else

                                                Throw New Exception("Cannot save.  Check out of balance.")

                                            End If

                                            Saved = True

                                            DataGridViewPanel_OtherReceiptDetails.CurrentView.ClearDisabledRows()

                                            RefreshCheck(OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber, _BatchDate)

                                        Catch ex As Exception
                                            If Not Saved Then
                                                DbTransaction.Rollback()
                                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                                ErrorMessage += vbCrLf & ex.Message
                                            End If
                                        Finally

                                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                                DbContext.Database.Connection.Close()

                                            End If

                                        End Try

                                    End If

                                End If

                            Else

                                Try

                                    If _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                        OtherCashReceiptOld.Description = TextBoxPanel_Description.GetText
                                        OtherCashReceiptOld.CheckDate = OtherCashReceipt.CheckDate
                                        OtherCashReceiptOld.DepositDate = OtherCashReceipt.DepositDate
                                        OtherCashReceiptOld.CashReceiptPaymentTypeID = SearchableComboBoxPanel_PaymentType.GetSelectedValue

                                        If AdvantageFramework.Database.Procedures.OtherCashReceipt.Update(DbContext, OtherCashReceiptOld) = False Then

                                            Throw New Exception("Problem updating Other Cash Receipt Header.")

                                        End If

                                    End If

                                    For Each OtherCashReceiptDetail In OtherCashReceiptDetailList

                                        If AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Update(DbContext, OtherCashReceiptDetail.OtherCashReceiptDetail) = False Then

                                            Throw New Exception("Problem updating Other Cash Receipt Detail.")
                                            Exit For

                                        End If

                                    Next

                                    Saved = True

                                Catch ex As Exception
                                    If Not Saved Then
                                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                        ErrorMessage += vbCrLf & ex.Message
                                    End If
                                End Try

                            End If

                        End If

                    End Using

                End If

                If ErrorMessage <> "" Then

                    Throw New System.Exception(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage, , "Check will refresh.")

                RefreshCheck(_ID, _SequenceNumber, _BatchDate)

            End If

            Save = Saved

        End Function
        Public Function Insert(ByRef OtherCashReceiptID As Integer, ByRef SequenceNumber As Short, ByVal BatchDate As Date, ByRef BankCode As String) As Boolean

            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
            Dim IsValid As Boolean = True
            Dim OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail) = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsBalanced As Integer = 0
            Dim GLTransaction As Nullable(Of Integer) = Nothing

            DataGridViewPanel_OtherReceiptDetails.CurrentView.CloseEditorForUpdating()

            If OkayToSave(ErrorMessage) Then

                If Me.ValidateControl(ErrorMessage) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OtherCashReceipt = FillObject(DbContext, True)

                        If OtherCashReceipt IsNot Nothing Then

                            ErrorMessage = OtherCashReceipt.ValidateEntity(IsValid)

                            If IsValid Then

                                OtherCashReceiptDetailList = DataGridViewPanel_OtherReceiptDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail)().ToList

                                Try

                                    DbContext.Database.Connection.Open()

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    OtherCashReceipt.DbContext = DbContext

                                    AdvantageFramework.CashReceipts.InsertOtherCashReceipt(DbContext, OtherCashReceipt, OtherCashReceiptDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.Methods.CheckState.Add)

                                    IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_othercashreceipt_check_balanced] {0}, {1}, {2}", OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber, OtherCashReceipt.GLTransaction)).FirstOrDefault

                                    If IsBalanced = 1 Then

                                        DbTransaction.Commit()

                                    Else

                                        Throw New Exception("Cannot save.  Check out of balance.")

                                    End If

                                    OtherCashReceiptID = OtherCashReceipt.ID
                                    SequenceNumber = OtherCashReceipt.SequenceNumber
                                    BankCode = OtherCashReceipt.BankCode

                                    Inserted = True

                                Catch ex As Exception
                                    DbTransaction.Rollback()
                                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                    ErrorMessage += vbCrLf & ex.Message
                                Finally

                                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                                        DbContext.Database.Connection.Close()

                                    End If

                                End Try

                            End If

                        End If

                    End Using

                End If

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function Delete() As Boolean

            Dim Deleted As Boolean = False
            Dim PostPeriodCode As String = Nothing
            Dim OtherCashReceipt As AdvantageFramework.Database.Entities.OtherCashReceipt = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1

            If OkayToDelete(PostPeriodCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OtherCashReceipt = AdvantageFramework.Database.Procedures.OtherCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                    If OtherCashReceipt IsNot Nothing AndAlso OtherCashReceipt.Status <> "D" AndAlso OtherCashReceipt.IsCleared.GetValueOrDefault(0) = 0 Then

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            OtherCashReceipt.PostPeriodCode = PostPeriodCode

                            AdvantageFramework.CashReceipts.ReverseOtherCashReceipt(DbContext, OtherCashReceipt, PostPeriodCode, _BatchDate, _GLSourceCode, True)

                            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_othercashreceipt_check_balanced] {0}, {1}, {2}", OtherCashReceipt.ID, OtherCashReceipt.SequenceNumber, OtherCashReceipt.GLTransaction)).FirstOrDefault

                            If IsBalanced = 1 Then

                                DbTransaction.Commit()

                                Deleted = True

                                AdvantageFramework.WinForm.MessageBox.Show("Check reversed.  GL Transaction: " & OtherCashReceipt.GLTransaction)

                            Else

                                Throw New Exception("Cannot reverse.  Check out of balance.")

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                        If ErrorMessage <> "" Then

                            Throw New System.Exception(ErrorMessage)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The receipt you are trying to delete does not exist, has already been deleted or is cleared.")

                    End If

                End Using

            End If

            Delete = Deleted

        End Function
        Public Sub CancelAddNewReceiptDetail()

            DataGridViewPanel_OtherReceiptDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedReceiptDetail()

            Dim OtherCashReceiptDetail As AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail = Nothing

            If DataGridViewPanel_OtherReceiptDetails.HasASelectedRow Then

                DataGridViewPanel_OtherReceiptDetails.CurrentView.CloseEditorForUpdating()

                If _ID <> 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each RowHandlesAndDataBoundItem In DataGridViewPanel_OtherReceiptDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                            Try

                                OtherCashReceiptDetail = RowHandlesAndDataBoundItem.Value

                            Catch ex As Exception
                                OtherCashReceiptDetail = Nothing
                            End Try

                            If OtherCashReceiptDetail IsNot Nothing Then

                                If OtherCashReceiptDetail.OtherCashReceiptDetail.IsEntityBeingAdded() = False Then

                                    If DataGridViewPanel_OtherReceiptDetails.CurrentView.DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataGridViewPanel_OtherReceiptDetails.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key)).Any Then

                                        DataGridViewPanel_OtherReceiptDetails.CurrentView.EnableRow(DataGridViewPanel_OtherReceiptDetails.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key))
                                        OtherCashReceiptDetail.IsDeleted = False

                                    Else

                                        DataGridViewPanel_OtherReceiptDetails.CurrentView.DisableRow(DataGridViewPanel_OtherReceiptDetails.CurrentView.GetDataSourceRowIndex(RowHandlesAndDataBoundItem.Key))
                                        OtherCashReceiptDetail.IsDeleted = True

                                    End If

                                    DataGridViewPanel_OtherReceiptDetails.SetUserEntryChanged()

                                    DataGridViewPanel_OtherReceiptDetails.Focus()

                                Else

                                    DataGridViewPanel_OtherReceiptDetails.CurrentView.DeleteRow(RowHandlesAndDataBoundItem.Key)

                                End If

                            End If

                        Next

                    End Using

                Else

                    DataGridViewPanel_OtherReceiptDetails.CurrentView.DeleteSelectedRows()

                End If

                CalculateTotalAmount()

            End If

        End Sub
        Public Sub SetBatchDate(ByVal BatchDate As Date)

            _BatchDate = BatchDate

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub OtherCashReceiptControl_Load(sender As Object, e As EventArgs) Handles Me.Load

            DataGridViewPanel_OtherReceiptDetails.AutoloadRepositoryDatasource = False

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewTransactions_GLTransactions_RowDoubleClickEvent() Handles DataGridViewTransactions_GLTransactions.RowDoubleClickEvent

            Dim GLTransaction As Integer = Nothing

            If DataGridViewTransactions_GLTransactions.HasASelectedRow Then

                GLTransaction = DataGridViewTransactions_GLTransactions.CurrentView.GetRowCellValue(DataGridViewTransactions_GLTransactions.CurrentView.FocusedRowHandle, DataGridViewTransactions_GLTransactions.Columns(0))

                AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog.ShowFormDialog(GLTransaction)

            End If

        End Sub
        Private Sub DateTimePickerCheckInfo_Date_Leave(sender As Object, e As EventArgs) Handles DateTimePickerCheckInfo_Date.Leave

            If _ID = 0 AndAlso DateTimePickerCheckInfo_Date.ValueObject Is Nothing Then

                DateTimePickerCheckInfo_Date.Value = Now.ToShortDateString

            End If

        End Sub
        Private Sub DateTimePickerDepositInfo_Date_Leave(sender As Object, e As EventArgs) Handles DateTimePickerDepositInfo_Date.Leave

            If _ID = 0 AndAlso DateTimePickerDepositInfo_Date.ValueObject Is Nothing Then

                DateTimePickerDepositInfo_Date.Value = Now.ToShortDateString

            End If

        End Sub
        Private Sub SearchableComboBoxDepositInfo_Bank_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxDepositInfo_Bank.EditValueChanged

            If Not _IsLoading AndAlso SearchableComboBoxDepositInfo_Bank.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadBankDetails(DbContext)

                End Using

            End If

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_AddNewRowEvent(RowObject As Object) Handles DataGridViewPanel_OtherReceiptDetails.AddNewRowEvent

            DataGridViewPanel_OtherReceiptDetails.SetUserEntryChanged()

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewPanel_OtherReceiptDetails.CellValueChangedEvent

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewPanel_OtherReceiptDetails.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        CancelAddNewReceiptDetail()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteSelectedReceiptDetail()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewPanel_OtherReceiptDetails.InitNewRowEvent

            RaiseEvent ReceiptDetailInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewPanel_OtherReceiptDetails.QueryPopupNeedDatasourceEvent

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case FieldName

                    Case AdvantageFramework.CashReceipts.Classes.OtherCashReceiptDetail.Properties.GLACode.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.CashReceipts.GetGLAccountListExcludeBankARAPCashAccounts(DbContext, _Session)

                End Select

            End Using

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_OtherReceiptDetails.RowCountChangedEvent

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewPanel_OtherReceiptDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_OtherReceiptDetails.SelectionChangedEvent

            RaiseEvent ReceiptDetailSelectionChangedEvent(sender, e)

        End Sub
        Private Sub NumericInputCheckInfo_Amount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputCheckInfo_Amount.EditValueChanged

            CalculateTotalAmount()

        End Sub
        Private Sub ComboBoxPanel_PostPeriod_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxPanel_PostPeriod.SelectedValueChanged

            ComboBoxPanel_PostPeriodForMod.SelectedValue = ComboBoxPanel_PostPeriod.GetSelectedValue

        End Sub

#End Region

#End Region

    End Class

End Namespace
