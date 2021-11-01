Namespace WinForm.Presentation.Controls

    Public Class ClientCashReceiptControl

        Public Event TotalsChanged()
        Public Event ClientCheckNumberChanged()
        Public Event CollapseClient(ByVal ClientCode As String)
        Public Event ClientInvoiceSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "

        Protected Const _GLSourceCode As String = "CR"

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
        Private _ShowAllOpenInvoices As Boolean = False
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False
        Private _ClientCashReceiptsPartialPaymentEnabled As Boolean = False
        Private _ClientCashReceiptsPartialPaymentRequired As Boolean = False
        Private _BankCode As String = Nothing
        Private _HeaderModifyState As HeaderModifyState = HeaderModifyState.NoRestrictions
        Private _LaunchingPartialPaymentDialog As Boolean = False
        Private _ObjectContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property HasCheckSelected As Boolean
            Get
                HasCheckSelected = SearchableComboBoxPanel_CheckNumber.HasASelectedValue
            End Get
        End Property
        Public ReadOnly Property ClientCashReceiptsPartialPaymentEnabled As Boolean
            Get
                ClientCashReceiptsPartialPaymentEnabled = _ClientCashReceiptsPartialPaymentEnabled
            End Get
        End Property
        Public ReadOnly Property SelectedInvoiceIsManual As Boolean
            Get
                If DataGridViewPanel_ClientInvoices.HasOnlyOneSelectedRow Then
                    SelectedInvoiceIsManual = DirectCast(DataGridViewPanel_ClientInvoices.CurrentView.GetRow(DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail).IsManualInvoice
                Else
                    SelectedInvoiceIsManual = False
                End If
            End Get
        End Property
        Public ReadOnly Property ID As Integer
            Get
                ID = _ID
            End Get
        End Property
        Public ReadOnly Property SequenceNumber As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            SearchableComboBoxDepositInfo_Bank.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            NumericInputCheckInfo_Amount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            SearchableComboBoxOnAccount_Division.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxOnAccount_Product.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft
            SearchableComboBoxOnAccount_GLAccount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            NumericInputOnAccount_Amount.ErrorIconAlignment = Windows.Forms.ErrorIconAlignment.MiddleLeft

            Me.DoubleBuffered = True

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

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ClientCashReceipt)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            DbContext.Database.Connection.Open()

                            TextBoxDropDownPanel_ARComment.ReadOnly = True

                            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                SearchableComboBoxPanel_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(C) C.IsActive = 1)

                            End Using

                            SearchableComboBoxPanel_Client.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxPanel_Client.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.ClientCode)

                            SearchableComboBoxPanel_CheckNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.CheckNumber)
                            TextBoxPanel_CheckNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.CheckNumber)

                            DateTimePickerCheckInfo_Date.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.CheckDate)
                            NumericInputCheckInfo_Amount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.CheckAmount)
                            NumericInputCheckInfo_Amount.Properties.MinValue = -NumericInputCheckInfo_Amount.Properties.MaxValue

                            DateTimePickerDepositInfo_Date.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.DepositDate)

                            SearchableComboBoxDepositInfo_Bank.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.BankCode)
                            SearchableComboBoxDepositInfo_Bank.AddInactiveItemsOnSelectedValue = True

                            SearchableComboBoxDepositInfo_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                            SearchableComboBoxDepositInfo_GLAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext)

                            ComboBoxPanel_PostPeriod.AddInactiveItemsOnSelectedValue = True
                            ComboBoxPanel_PostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            ComboBoxPanel_PostPeriod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.PostPeriodCode)

                            ComboBoxPanel_PostPeriodForMod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext)
                            ComboBoxPanel_PostPeriodForMod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceipt.Properties.PostPeriodCode)

                            SearchableComboBoxPanel_PaymentType.DataSource = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.LoadAllActive(DbContext).ToList
                            SearchableComboBoxPanel_PaymentType.AddInactiveItemsOnSelectedValue = True

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            SearchableComboBoxOnAccount_Division.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.DivisionCode)
                            SearchableComboBoxOnAccount_Product.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.ProductCode)
                            SearchableComboBoxOnAccount_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(DbContext)
                            SearchableComboBoxOnAccount_Campaign.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.CampaignCode)
                            SearchableComboBoxOnAccount_GLAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.GLACodeOnAccount)
                            SearchableComboBoxOnAccount_GLAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True)

                            NumericInputOnAccount_Amount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.Amount)

                            TextBoxOnAccount_Comment.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount.Properties.Comment)

                            NumericInputCheckInfo_Amount.SetFormat("n2")
                            NumericInputDisbursedTo_Balance.SetFormat("n2")
                            NumericInputDisbursedTo_ClientInvoice.SetFormat("n2")
                            NumericInputDisbursedTo_OnAccount.SetFormat("n2")

                            DbContext.Database.Connection.Close()

                        End Using

                        SearchableComboBoxPanel_Client.ByPassUserEntryChanged = True
                        SearchableComboBoxPanel_CheckNumber.ByPassUserEntryChanged = True

                        NumericInputDisbursedTo_ClientInvoice.ByPassUserEntryChanged = True
                        NumericInputDisbursedTo_OnAccount.ByPassUserEntryChanged = True
                        NumericInputDisbursedTo_Balance.ByPassUserEntryChanged = True

                        DataGridViewPanel_ClientInvoices.AutoFilterLookupColumns = True

                        DataGridViewTransactions_GLTransactions.MultiSelect = False
                        DataGridViewTransactions_GLTransactions.OptionsView.ShowFooter = False

                        TextBoxPanel_MessageDetails.ByPassUserEntryChanged = True

                        If Not Me.FindForm.Modal Then

                            SearchableComboBoxPanel_Client.SetRequired(False)
                            SearchableComboBoxPanel_CheckNumber.SetRequired(False)

                        End If

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub EnableClientSearchControls(ByVal Enabled As Boolean)

            DateTimePickerCheckInfo_Date.ReadOnly = Not Enabled
            NumericInputCheckInfo_Amount.ReadOnly = Not Enabled

            DateTimePickerDepositInfo_Date.ReadOnly = Not Enabled
            SearchableComboBoxDepositInfo_Bank.SetRequired(Enabled)
            SearchableComboBoxDepositInfo_Bank.Enabled = Enabled
            SearchableComboBoxDepositInfo_Office.Enabled = Enabled
            SearchableComboBoxDepositInfo_GLAccount.Enabled = Enabled

            ComboBoxPanel_PostPeriod.Enabled = Enabled
            ComboBoxPanel_PostPeriodForMod.Enabled = Enabled

            SearchableComboBoxOnAccount_Division.Enabled = Enabled
            SearchableComboBoxOnAccount_Product.Enabled = Enabled
            SearchableComboBoxOnAccount_Office.Enabled = Enabled
            SearchableComboBoxOnAccount_Campaign.Enabled = Enabled
            SearchableComboBoxOnAccount_GLAccount.Enabled = Enabled

            NumericInputOnAccount_Amount.ReadOnly = Not Enabled

            TextBoxOnAccount_Comment.ReadOnly = Not Enabled
            TextBoxOnAccount_Comment.TabStop = Enabled

            DataGridViewPanel_ClientInvoices.Enabled = Enabled

        End Sub
        Private Sub LoadClientCashReceiptEntity(ByVal ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt, ByVal IsNew As Boolean)

            If ClientCashReceipt IsNot Nothing Then

                If IsNew Then

                    ClientCashReceipt.CheckNumber = TextBoxPanel_CheckNumber.Text

                Else

                    ClientCashReceipt.CheckNumber = SearchableComboBoxPanel_CheckNumber.GetSelectedValue

                End If

                ClientCashReceipt.ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue

                ClientCashReceipt.DepositDate = DateTimePickerDepositInfo_Date.Value
                ClientCashReceipt.BankCode = SearchableComboBoxDepositInfo_Bank.GetSelectedValue
                ClientCashReceipt.OfficeCode = SearchableComboBoxDepositInfo_Office.GetSelectedValue
                ClientCashReceipt.GLACode = SearchableComboBoxDepositInfo_GLAccount.GetSelectedValue

                ClientCashReceipt.CheckDate = DateTimePickerCheckInfo_Date.Value
                ClientCashReceipt.CheckAmount = NumericInputCheckInfo_Amount.Value

                ClientCashReceipt.PostPeriodCode = ComboBoxPanel_PostPeriodForMod.GetSelectedValue

                ClientCashReceipt.CashReceiptPaymentTypeID = SearchableComboBoxPanel_PaymentType.GetSelectedValue

            End If

        End Sub
        Private Sub LoadClientCashReceiptOnAccountEntity(ByVal ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount)

            If ClientCashReceiptOnAccount IsNot Nothing Then

                ClientCashReceiptOnAccount.DivisionCode = SearchableComboBoxOnAccount_Division.GetSelectedValue
                ClientCashReceiptOnAccount.ProductCode = SearchableComboBoxOnAccount_Product.GetSelectedValue
                ClientCashReceiptOnAccount.CampaignCode = SearchableComboBoxOnAccount_Campaign.GetSelectedValue
                ClientCashReceiptOnAccount.Amount = NumericInputOnAccount_Amount.Value
                ClientCashReceiptOnAccount.GLACodeOnAccount = SearchableComboBoxOnAccount_GLAccount.GetSelectedValue
                ClientCashReceiptOnAccount.PostPeriodCode = ComboBoxPanel_PostPeriodForMod.GetSelectedValue
                ClientCashReceiptOnAccount.OfficeCode = SearchableComboBoxOnAccount_Office.GetSelectedValue

                If Not String.IsNullOrEmpty(TextBoxOnAccount_Comment.Text.Trim) Then

                    ClientCashReceiptOnAccount.Comment = TextBoxOnAccount_Comment.GetText

                End If

            End If

        End Sub
        Private Sub LoadClientInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String)

            Dim ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing

            If ClientCode IsNot Nothing Then

                DataGridViewPanel_ClientInvoices.CurrentView.BeginUpdate()

                If Me.FindForm.Modal Then

                    ClientInvoiceDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) _
                        (String.Format("exec advsp_clientcashreceipt_select_open_invoices_by_client '{0}', {1}, {2}, '{3}'", ClientCode, If(_ID <> 0, _ID, "NULL"), If(_ShowAllOpenInvoices, 1, 0), _Session.UserCode)).ToList

                Else

                    ClientInvoiceDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) _
                        (String.Format("exec advsp_clientcashreceipt_select_open_invoices_by_client '{0}', {1}, {2}", ClientCode, If(_ID <> 0, _ID, "NULL"), If(_ShowAllOpenInvoices, 1, 0))).ToList

                End If

                For Each ClientInvoiceDetail In ClientInvoiceDetailList

                    ClientInvoiceDetail.Session = _Session

                Next

                DataGridViewPanel_ClientInvoices.DataSource = ClientInvoiceDetailList

                If DataGridViewPanel_ClientInvoices.HasRows = False AndAlso _ID = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("There are no unpaid invoices available for this client.  You may add an on-account amount.")

                End If

                DataGridViewPanel_ClientInvoices.CurrentView.BestFitColumns()

                DataGridViewPanel_ClientInvoices.ClearChanged()

                DataGridViewPanel_ClientInvoices.CurrentView.EndUpdate()

                LoadClientInvoiceRepositoryItems()

            End If

        End Sub
        Private Sub LoadGLTransactions(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim TransactionIDs As Generic.List(Of Nullable(Of Integer)) = Nothing
            Dim TransactionList As IEnumerable(Of Object) = Nothing

            DataGridViewTransactions_GLTransactions.DataSource = Nothing

            TransactionIDs = New Generic.List(Of Nullable(Of Integer))

            TransactionIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Load(DbContext)
                                     Where Entity.ClientCashReceiptID = _ID
                                     Select Entity.GLTransaction).Distinct.ToList())

            TransactionIDs.AddRange((DbContext.Database.SqlQuery(Of Nullable(Of Integer))(String.Format("select DISTINCT GLEXACT from dbo.CR_ON_ACCT where REC_ID={0}", _ID))).ToList)

            TransactionList = (From GeneralLedger In AdvantageFramework.Database.Procedures.GeneralLedger.Load(DbContext)
                               Where TransactionIDs.Contains(GeneralLedger.Transaction)
                               Select (New With {.Transaction = GeneralLedger.Transaction,
                                                 .PostPeriod = GeneralLedger.PostPeriodCode,
                                                 .Status = If(GeneralLedger.PostedDate IsNot Nothing, "Posted", "")})).Distinct.ToList

            DataGridViewTransactions_GLTransactions.DataSource = TransactionList

            DataGridViewTransactions_GLTransactions.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                TextBoxPanel_CheckNumber.Visible = True
                SearchableComboBoxPanel_CheckNumber.Visible = False

            Else

                TextBoxPanel_CheckNumber.Visible = False
                SearchableComboBoxPanel_CheckNumber.Visible = True

            End If

        End Sub
        Private Sub LoadOnAccount(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            ClientCashReceiptOnAccount = AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.LoadActiveByClientCashReceiptID(DbContext, _ID)

            If ClientCashReceiptOnAccount IsNot Nothing Then

                SearchableComboBoxOnAccount_Division.SelectedValue = ClientCashReceiptOnAccount.DivisionCode

                If Not SearchableComboBoxOnAccount_Division.HasASelectedValue Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCashReceiptOnAccount.ClientCashReceipt.ClientCode, ClientCashReceiptOnAccount.DivisionCode)

                    If Division IsNot Nothing Then

                        SearchableComboBoxOnAccount_Division.AddComboItemToExistingDataSource(Division.Name, Division.Code, False)
                        SearchableComboBoxOnAccount_Division.SelectedValue = ClientCashReceiptOnAccount.DivisionCode

                    End If

                End If

                SearchableComboBoxOnAccount_Product.SelectedValue = ClientCashReceiptOnAccount.ProductCode

                If Not SearchableComboBoxOnAccount_Product.HasASelectedValue Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCashReceiptOnAccount.ClientCashReceipt.ClientCode, ClientCashReceiptOnAccount.DivisionCode, ClientCashReceiptOnAccount.ProductCode)

                    If Product IsNot Nothing Then

                        SearchableComboBoxOnAccount_Product.AddComboItemToExistingDataSource(Product.Name, Product.Code, False)
                        SearchableComboBoxOnAccount_Product.SelectedValue = ClientCashReceiptOnAccount.ProductCode

                    End If

                End If

                SearchableComboBoxOnAccount_Office.SelectedValue = ClientCashReceiptOnAccount.OfficeCode
                SearchableComboBoxOnAccount_Campaign.SelectedValue = ClientCashReceiptOnAccount.CampaignCode
                SearchableComboBoxOnAccount_GLAccount.SelectedValue = ClientCashReceiptOnAccount.GLACodeOnAccount

                NumericInputOnAccount_Amount.EditValue = ClientCashReceiptOnAccount.Amount

                TextBoxOnAccount_Comment.Text = ClientCashReceiptOnAccount.Comment

            Else

                SearchableComboBoxOnAccount_Division.SelectedValue = Nothing
                SearchableComboBoxOnAccount_Product.SelectedValue = Nothing
                SearchableComboBoxOnAccount_Office.SelectedValue = Nothing
                SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing
                SearchableComboBoxOnAccount_GLAccount.SelectedValue = Nothing

                SearchableComboBoxOnAccount_Product.Enabled = False
                SearchableComboBoxOnAccount_Campaign.Enabled = False

                NumericInputOnAccount_Amount.EditValue = Nothing

                TextBoxOnAccount_Comment.Text = Nothing

            End If

        End Sub
        Private Sub RefreshCheck(ByVal ID As Integer, ByVal SequenceNumber As Short, ByVal BatchDate As Date)

            _ID = 0
            _SequenceNumber = 0

            LoadControl(Nothing, ID, SequenceNumber, _BatchDate, _ShowAllOpenInvoices, Nothing)

        End Sub
        Private Sub SetClientDependentObjects(ByVal ClientCode As String)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                    If Client IsNot Nothing Then

                        TextBoxDropDownPanel_ARComment.Text = Client.ARComment
                        TextBoxPanel_ClientARComment.Text = Client.ARComment

                    End If

                End Using

            End Using

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

            'If CurrentPostPeriod IsNot Nothing Then

            '    If _ID = 0 Then

            '        ComboBoxPanel_PostPeriod.SelectedValue = CurrentPostPeriod.Code

            '    End If

            '    ComboBoxPanel_PostPeriodForMod.SelectedValue = CurrentPostPeriod.Code

            'Else

            '    If _ID = 0 Then

            '        If Not ComboBoxPanel_PostPeriod.SelectSingleItemDataSource() Then

            '            ComboBoxPanel_PostPeriod.SelectedIndex = -1

            '        End If

            '        If Not ComboBoxPanel_PostPeriodForMod.SelectSingleItemDataSource() Then

            '            ComboBoxPanel_PostPeriodForMod.SelectedIndex = -1

            '        End If

            '    End If

            'End If

            'If _ID <> 0 AndAlso ComboBoxPanel_PostPeriodForMod.HasASelectedValue = False Then

            '    ComboBoxPanel_PostPeriodForMod.SelectedValue = HeaderPostPeriodCode

            '    If ComboBoxPanel_PostPeriodForMod.HasASelectedValue = False AndAlso ComboBoxPanel_PostPeriodForMod.SelectSingleItemDataSource = False Then

            '        ComboBoxPanel_PostPeriodForMod.SelectedIndex = -1

            '    End If

            'End If

            If PostPeriodList.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("All AR Posting Periods are closed.")

                TextBoxPanel_MessageDetails.Text += Space(2) & "All AR Posting Periods are closed."
                TextBoxPanel_MessageDetails.Text = Trim(TextBoxPanel_MessageDetails.Text)

            End If

        End Sub
        Private Function CalculateTotalAmount() As Boolean

            Dim ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing
            Dim TotalPayment As Decimal = 0

            If Not _IsLoading AndAlso Me.FindForm IsNot Nothing AndAlso Not _IsClearing Then

                NumericInputDisbursedTo_ClientInvoice.EditValue = 0

                ClientInvoiceDetailList = DataGridViewPanel_ClientInvoices.GetBindingSourceDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList
                TotalPayment = ClientInvoiceDetailList.Sum(Function(Entity) Entity.PaymentAmount)

                NumericInputDisbursedTo_ClientInvoice.EditValue = TotalPayment
                NumericInputDisbursedTo_OnAccount.EditValue = CDec(NumericInputOnAccount_Amount.EditValue)
                NumericInputDisbursedTo_Balance.EditValue = NumericInputCheckInfo_Amount.Value - TotalPayment - NumericInputDisbursedTo_OnAccount.EditValue

                RaiseEvent TotalsChanged()

            End If

            If NumericInputDisbursedTo_Balance.EditValue = 0 Then

                CalculateTotalAmount = True

            Else

                CalculateTotalAmount = False

            End If

        End Function
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
        Private Function ValidateControl(ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True
            Dim ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            ValidateAllRows(False)

            If DataGridViewPanel_ClientInvoices.HasAnyInvalidRows Then

                ClientInvoiceDetailList = DataGridViewPanel_ClientInvoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail).ToList

                ClientInvoiceDetailList = ClientInvoiceDetailList.Where(Function(CID) CID.HasBeenVoided = False).ToList

                DataGridViewPanel_ClientInvoices.DataSource = ClientInvoiceDetailList

                ValidateAllRows(False)

            End If

            If DataGridViewPanel_ClientInvoices.HasAnyInvalidRows Then

                IsValid = False
                ErrorMessage = "Fix errors in grid."

            End If

            ValidateControl = IsValid

        End Function
        Private Sub LoadBankDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim BankCode As String = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            BankCode = SearchableComboBoxDepositInfo_Bank.SelectedValue

            Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, BankCode)

            If Bank IsNot Nothing Then

                SearchableComboBoxDepositInfo_Office.SelectedValue = Bank.OfficeCode
                SearchableComboBoxDepositInfo_GLAccount.SelectedValue = Bank.ARCashAccount

            End If

        End Sub
        Private Sub LoadClientInvoiceRepositoryItems()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            For Each GridColumn In DataGridViewPanel_ClientInvoices.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                    Try

                        SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                    Catch ex As Exception
                        SubItemGridLookUpEditControl = Nothing
                    End Try

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Select Case GridColumn.FieldName

                                Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustment.ToString,
                                        AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustmentDescription.ToString

                                    SubItemGridLookUpEditControl.DataSource = AdvantageFramework.CashReceipts.GetGLAccountListExcludeBankARAPCashAccounts(DbContext)

                            End Select

                        End Using

                    End If

                End If

            Next

        End Sub
        Private Sub SetDefaultWriteoffGL(ByRef ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

            Dim DefaultWriteoffGL As String = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    DefaultWriteoffGL = AdvantageFramework.Agency.GetOptionClientCashReceiptsDefaultWriteoffGL(DataContext)

                    If String.IsNullOrWhiteSpace(DefaultWriteoffGL) = False Then

                        If ClientInvoiceDetail.GeneralLedgerOfficeCrossReferenceCode IsNot Nothing Then

                            GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeSegment(DbContext, DefaultWriteoffGL, ClientInvoiceDetail.GeneralLedgerOfficeCrossReferenceCode)

                        Else

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, DefaultWriteoffGL)

                        End If

                        If GeneralLedgerAccount IsNot Nothing Then

                            ClientInvoiceDetail.GLACodeAdjustment = GeneralLedgerAccount.Code
                            ClientInvoiceDetail.GLACodeAdjustmentDescription = GeneralLedgerAccount.Description

                        End If

                    End If

                End Using

            End Using

        End Sub
        Private Function ClientInvoiceDetailRequiresJournalEntry(ByVal ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)) As Boolean

            Dim RequiresJE As Boolean = False

            For Each ClientInvoiceDetail In ClientInvoiceDetailList

                If ClientInvoiceDetail.AdjustmentAmountCopy.GetValueOrDefault(0) <> ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) OrElse
                        ClientInvoiceDetail.PaymentAmountCopy.GetValueOrDefault(0) <> ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) OrElse
                        ClientInvoiceDetail.GLACodeAdjustmentCopy <> ClientInvoiceDetail.GLACodeAdjustment Then

                    RequiresJE = True
                    Exit For

                End If

            Next

            ClientInvoiceDetailRequiresJournalEntry = RequiresJE

        End Function
        Private Sub ValidateAllRows(ByVal ClearChanged As Boolean)

            Try

                _ObjectContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DataGridViewPanel_ClientInvoices.RunStandardValidation = False

                Try

                    If ClearChanged Then

                        DataGridViewPanel_ClientInvoices.ValidateAllRowsAndClearChanged()

                    Else

                        DataGridViewPanel_ClientInvoices.ValidateAllRows()

                    End If

                Catch ex As Exception

                End Try

                Try

                    _ObjectContext.Dispose()

                    _ObjectContext = Nothing

                Catch ex As Exception

                End Try

                DataGridViewPanel_ClientInvoices.RunStandardValidation = True

            Catch ex As Exception

            End Try

        End Sub

#Region "  Public "

        Public Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim ClientCode As String = Nothing
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) AndAlso Me.NumericInputDisbursedTo_Balance.EditValue = 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = CalculateTotalAmount() AndAlso (DataGridViewPanel_ClientInvoices.HasAnyInvalidRows = False)

                    If IsOkay Then

                        Me.ShowWaitForm("Processing...")

                        If Me.FindForm.Modal = True Then

                            Try

                                IsOkay = Insert(ClientCode, Nothing, Nothing, _BatchDate, Nothing)

                                If IsOkay Then

                                    RaiseEvent CollapseClient(ClientCode)

                                End If

                            Catch ex As Exception
                                IsOkay = False
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                        Else

                            Try

                                IsOkay = Save(Nothing)

                                If IsOkay Then

                                    RaiseEvent CollapseClient(ClientCode)

                                End If

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
        Public Sub ClearControl(Optional ByVal ClearClient As Boolean = True)

            Me.SuspendLayout()

            _IsClearing = True

            _ID = 0
            _SequenceNumber = 0

            'header
            If ClearClient Then

                SearchableComboBoxPanel_Client.SelectedValue = Nothing

                EnableClientSearchControls(False)

            End If

            SearchableComboBoxPanel_CheckNumber.SelectedValue = Nothing
            SearchableComboBoxPanel_CheckNumber.DataSource = Nothing

            TextBoxPanel_CheckNumber.Text = Nothing

            TextBoxDropDownPanel_ARComment.Text = Nothing
            TextBoxPanel_ClientARComment.Text = Nothing

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

            SearchableComboBoxOnAccount_Division.SelectedValue = Nothing
            SearchableComboBoxOnAccount_Product.SelectedValue = Nothing
            SearchableComboBoxOnAccount_Office.SelectedValue = Nothing
            SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing
            SearchableComboBoxOnAccount_GLAccount.SelectedValue = Nothing
            NumericInputOnAccount_Amount.EditValue = Nothing
            TextBoxOnAccount_Comment.Text = Nothing

            DataGridViewTransactions_GLTransactions.ClearDatasource()

            NumericInputDisbursedTo_ClientInvoice.EditValue = Nothing
            NumericInputDisbursedTo_OnAccount.EditValue = Nothing
            NumericInputDisbursedTo_Balance.EditValue = Nothing

            DataGridViewPanel_ClientInvoices.ClearDatasource()

            TextBoxPanel_MessageDetails.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

            Me.ResumeLayout()

        End Sub
        Public Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.ClientCashReceipt

            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing

            Try

                If IsNew Then

                    ClientCashReceipt = New AdvantageFramework.Database.Entities.ClientCashReceipt

                    ClientCashReceipt.DbContext = DbContext

                    LoadClientCashReceiptEntity(ClientCashReceipt, IsNew)

                Else

                    ClientCashReceipt = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                    ClientCashReceipt.DbContext = DbContext

                    LoadClientCashReceiptEntity(ClientCashReceipt, IsNew)

                End If

            Catch ex As Exception
                ClientCashReceipt = Nothing
            End Try

            FillObject = ClientCashReceipt

        End Function
        Public Function LoadControl(ByRef ClientCode As String, ByVal ID As Integer, ByVal SequenceNumber As Short, ByVal BatchDate As Date, ByVal ShowAllOpenInvoices As Boolean, ByRef BankCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ClientCashReceiptList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceipt) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            _ID = ID
            _SequenceNumber = SequenceNumber
            _BatchDate = BatchDate
            _ShowAllOpenInvoices = ShowAllOpenInvoices
            _BankCode = BankCode

            Me.SuspendLayout()

            EnableClientSearchControls(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        _ClientCashReceiptsPartialPaymentEnabled = AdvantageFramework.Agency.GetOptionClientCashReceiptsPartialPaymentEnabled(DataContext)
                        _ClientCashReceiptsPartialPaymentRequired = AdvantageFramework.Agency.GetOptionClientCashReceiptsPartialPaymentRequired(DataContext)

                    End Using

                    If _ID <> 0 Then

                        ClientCashReceipt = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                        If ClientCashReceipt IsNot Nothing Then

                            _IsLoading = True

                            SearchableComboBoxPanel_Client.SelectedValue = ClientCashReceipt.ClientCode

                            SetClientDependentObjects(ClientCashReceipt.ClientCode)

                            ClientCashReceiptList = AdvantageFramework.CashReceipts.GetAllCashReceiptListByClient(DbContext, ClientCashReceipt.ClientCode)

                            SearchableComboBoxPanel_CheckNumber.DataSource = ClientCashReceiptList.OrderByDescending(Function(CR) CR.CheckDate).ThenByDescending(Function(CR) CR.CheckNumber).ToList

                            SearchableComboBoxPanel_CheckNumber.SelectedValue = ClientCashReceipt.CheckNumber

                            TextBoxDropDownPanel_ARComment.Text = ClientCashReceipt.Client.ARComment
                            TextBoxPanel_ClientARComment.Text = ClientCashReceipt.Client.ARComment

                            TextBoxPanel_CheckNumber.SetRequired(False)
                            TextBoxPanel_CheckNumber.Visible = False

                            ComboBoxPanel_PostPeriod.RemoveAddedItemsFromDataSource()
                            ComboBoxPanel_PostPeriodForMod.RemoveAddedItemsFromDataSource()

                            If ClientCashReceipt.PostPeriod.APStatus = "X" Then

                                ComboBoxPanel_PostPeriod.AddComboItemToExistingDataSource(ClientCashReceipt.PostPeriod.ToString, ClientCashReceipt.PostPeriodCode, True)

                            End If

                            ComboBoxPanel_PostPeriod.SelectedValue = ClientCashReceipt.PostPeriodCode
                            ComboBoxPanel_PostPeriod.Tag = ClientCashReceipt.PostPeriodCode

                            DateTimePickerCheckInfo_Date.Value = ClientCashReceipt.CheckDate
                            NumericInputCheckInfo_Amount.Value = ClientCashReceipt.CheckAmount

                            DateTimePickerDepositInfo_Date.Value = ClientCashReceipt.DepositDate

                            SearchableComboBoxDepositInfo_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).Where(Function(Entity) _Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode))
                            SearchableComboBoxDepositInfo_Bank.SelectedValue = ClientCashReceipt.BankCode

                            If Not SearchableComboBoxDepositInfo_Bank.HasASelectedValue Then

                                Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, ClientCashReceipt.BankCode)

                                If Bank IsNot Nothing Then

                                    SearchableComboBoxDepositInfo_Bank.AddComboItemToExistingDataSource(Bank.Description, Bank.Code, False)
                                    SearchableComboBoxDepositInfo_Bank.SelectedValue = ClientCashReceipt.BankCode

                                End If

                            End If

                            SearchableComboBoxDepositInfo_Office.SelectedValue = ClientCashReceipt.OfficeCode
                            SearchableComboBoxDepositInfo_GLAccount.SelectedValue = ClientCashReceipt.GLACode

                            SearchableComboBoxPanel_PaymentType.RemoveAddedItemsFromDataSource()
                            SearchableComboBoxPanel_PaymentType.SelectedValue = ClientCashReceipt.CashReceiptPaymentTypeID

                            SearchableComboBoxOnAccount_Campaign.DataSource = AdvantageFramework.Database.Procedures.Campaign.LoadByClientCode(DbContext, ClientCashReceipt.ClientCode).ToList

                            CheckBoxDepositInfo_Cleared.Checked = If(ClientCashReceipt.IsCleared.GetValueOrDefault(0) = 1, True, False)

                            ComboBoxPanel_PostPeriod.ReadOnly = True

                            LabelPanel_PostingPeriodForMod.Visible = True
                            ComboBoxPanel_PostPeriodForMod.Visible = True
                            ComboBoxPanel_PostPeriodForMod.Enabled = True

                            LoadGLTransactions(DbContext)

                            SearchableComboBoxOnAccount_Division.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                                               Where Entity.ClientCode = ClientCashReceipt.ClientCode AndAlso
                                                                                     Entity.IsActive = 1).ToList

                            LoadOnAccount(DbContext)

                            TextBoxPanel_MessageDetails.Text = ""

                            If ClientCashReceipt.PostPeriod.ARStatus = "X" Then

                                TextBoxPanel_MessageDetails.Text = "Posting period has been closed.  You will not be able to change key header information.  You will be able to modify the detail distribution."

                                _HeaderModifyState = HeaderModifyState.PostPeriodClosed

                            Else

                                _HeaderModifyState = HeaderModifyState.NoRestrictions

                            End If

                            SetCurrentPostPeriod(DbContext, ClientCashReceipt.PostPeriodCode)

                            _IsLoading = False

                            ClientCode = ClientCashReceipt.ClientCode

                        Else

                            Loaded = False

                        End If

                    Else

                        _IsLoading = True

                        SearchableComboBoxPanel_Client.SelectedValue = ClientCode
                        SearchableComboBoxPanel_Client.Enabled = False

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                        If Client IsNot Nothing Then

                            TextBoxDropDownPanel_ARComment.Text = Client.ARComment
                            TextBoxPanel_ClientARComment.Text = Client.ARComment

                            SearchableComboBoxOnAccount_Division.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                                               Where Entity.ClientCode = Client.Code AndAlso
                                                                                     Entity.IsActive = 1).ToList

                        End If

                        SearchableComboBoxPanel_CheckNumber.Visible = False
                        SearchableComboBoxPanel_CheckNumber.SetRequired(False)

                        TextBoxPanel_CheckNumber.Visible = True

                        DateTimePickerCheckInfo_Date.Value = Nothing
                        NumericInputCheckInfo_Amount.EditValue = Nothing

                        DateTimePickerDepositInfo_Date.Value = Nothing

                        SearchableComboBoxDepositInfo_Bank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext).Where(Function(Entity) _Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode))

                        If String.IsNullOrWhiteSpace(_BankCode) = False Then

                            SearchableComboBoxDepositInfo_Bank.SelectedValue = _BankCode

                        Else

                            SearchableComboBoxDepositInfo_Bank.SelectSingleItemDataSource()

                        End If

                        LoadBankDefaults(DbContext)

                        SetCurrentPostPeriod(DbContext, Nothing)
                        LabelPanel_PostingPeriodForMod.Visible = False
                        ComboBoxPanel_PostPeriodForMod.Visible = False

                        SearchableComboBoxOnAccount_Product.Enabled = False
                        SearchableComboBoxOnAccount_Campaign.Enabled = False

                        _IsLoading = False

                    End If

                    DateTimePickerCheckInfo_Date.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked
                    NumericInputCheckInfo_Amount.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked

                    DateTimePickerDepositInfo_Date.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked
                    SearchableComboBoxDepositInfo_Bank.ReadOnly = (_HeaderModifyState = HeaderModifyState.PostPeriodClosed) OrElse CheckBoxDepositInfo_Cleared.Checked

                    LoadClientInvoices(DbContext, SearchableComboBoxPanel_Client.GetSelectedValue)

                    CalculateTotalAmount()

                End Using

            End Using

            Me.ResumeLayout()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save(ByRef ClientCode As String) As Boolean

            Dim ErrorMessage As String = Nothing
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ClientCashReceiptOld As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ClientCashReceiptReversal As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim ClientCashReceiptOnAccountOld As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim ClientCashReceiptOnAccountReversal As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing
            Dim IsBalanced As Integer = -1
            Dim Saved As Boolean = False
            Dim IsInterCompanyTransactionsEnabled As Boolean = False
            Dim PostPeriodChanged As Boolean = False
            Dim GLTransaction As Nullable(Of Integer) = Nothing
            Dim GLReversalTransaction As Integer = -1
            Dim ContinueSave As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If OkayToSave(ErrorMessage) Then

                If ValidateControl(ErrorMessage) Then

                    ErrorMessage = ""

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientCashReceipt = FillObject(DbContext, False)

                        If AdvantageFramework.AccountPayable.IsDateOutsidePostPeriod(DbContext, ClientCashReceipt.CheckDate, ClientCashReceipt.PostPeriodCode) Then

                            If AdvantageFramework.WinForm.MessageBox.Show("The check date is outside of normal range based on the posting period selected, are you sure you want to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                                ContinueSave = False
                                DateTimePickerCheckInfo_Date.Focus()

                            End If

                        End If

                        ClientCashReceiptOld = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                        ClientCashReceiptOnAccountOld = AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.LoadActiveByClientCashReceiptID(DbContext, _ID)

                        If NumericInputOnAccount_Amount.Value <> 0 Then

                            ClientCashReceiptOnAccount = New AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount

                            LoadClientCashReceiptOnAccountEntity(ClientCashReceiptOnAccount)

                        End If

                        ClientInvoiceDetailList = DataGridViewPanel_ClientInvoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList

                        If ContinueSave AndAlso ClientCashReceiptOld.BankCode <> ClientCashReceipt.BankCode OrElse ClientCashReceiptOld.CheckAmount <> ClientCashReceipt.CheckAmount OrElse
                                    (ClientCashReceiptOnAccountOld IsNot Nothing AndAlso ClientCashReceiptOnAccount Is Nothing) OrElse
                                    (ClientCashReceiptOnAccountOld Is Nothing AndAlso ClientCashReceiptOnAccount IsNot Nothing) OrElse
                                    (ClientCashReceiptOnAccountOld IsNot Nothing AndAlso ClientCashReceiptOnAccount IsNot Nothing AndAlso
                                    (ClientCashReceiptOnAccountOld.Amount <> ClientCashReceiptOnAccount.Amount OrElse ClientCashReceiptOnAccountOld.GLACodeOnAccount <> ClientCashReceiptOnAccount.GLACodeOnAccount)) OrElse
                                    ClientInvoiceDetailRequiresJournalEntry(ClientInvoiceDetailList) Then

                            If AdvantageFramework.WinForm.MessageBox.Show("Have you verified Posting Period?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                                ContinueSave = False

                            End If

                        End If

                        If ContinueSave AndAlso ClientCashReceipt IsNot Nothing AndAlso ClientCashReceiptOld IsNot Nothing Then

                            If ClientCashReceiptOld.PostPeriodCode <> ClientCashReceipt.PostPeriodCode AndAlso _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                PostPeriodChanged = True

                            End If

                            If PostPeriodChanged OrElse ClientCashReceiptOld.BankCode <> ClientCashReceipt.BankCode OrElse ClientCashReceiptOld.CheckAmount <> ClientCashReceipt.CheckAmount OrElse
                                        (ClientCashReceiptOnAccountOld IsNot Nothing AndAlso ClientCashReceiptOnAccount Is Nothing) OrElse
                                        (ClientCashReceiptOnAccountOld Is Nothing AndAlso ClientCashReceiptOnAccount IsNot Nothing) OrElse
                                        (ClientCashReceiptOnAccountOld IsNot Nothing AndAlso ClientCashReceiptOnAccount IsNot Nothing AndAlso
                                        (ClientCashReceiptOnAccountOld.Amount <> ClientCashReceiptOnAccount.Amount OrElse ClientCashReceiptOnAccountOld.GLACodeOnAccount <> ClientCashReceiptOnAccount.GLACodeOnAccount)) OrElse
                                        ClientInvoiceDetailRequiresJournalEntry(ClientInvoiceDetailList) Then

                                Try

                                    DbContext.Database.Connection.Open()

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    IsInterCompanyTransactionsEnabled = AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)

                                    If _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                        ClientCashReceiptReversal = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                                        If ClientCashReceiptReversal Is Nothing OrElse ClientCashReceiptReversal.Status = "D" Then

                                            Throw New Exception("The Client Cash Receipt you are trying to edit cannot be found or has been modified.")

                                        End If

                                        If PostPeriodChanged OrElse ClientCashReceiptOld.BankCode <> ClientCashReceipt.BankCode OrElse ClientCashReceiptOld.CheckAmount <> ClientCashReceipt.CheckAmount Then

                                            If PostPeriodChanged Then

                                                GLReversalTransaction = AdvantageFramework.CashReceipts.ReverseClientCashReceipt(DbContext, ClientCashReceiptReversal, ClientCashReceiptReversal.PostPeriodCode, _BatchDate, _GLSourceCode, False)

                                                AdvantageFramework.CashReceipts.InsertClientCashReceipt(DbContext, ClientCashReceipt, ClientCashReceiptOnAccount, ClientInvoiceDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.CheckState.Modify)

                                            Else

                                                GLTransaction = AdvantageFramework.CashReceipts.ReverseClientCashReceipt(DbContext, ClientCashReceiptReversal, ClientCashReceipt.PostPeriodCode, _BatchDate, _GLSourceCode, False)

                                                AdvantageFramework.CashReceipts.InsertClientCashReceipt(DbContext, ClientCashReceipt, ClientCashReceiptOnAccount, ClientInvoiceDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.CheckState.Modify)

                                            End If

                                        Else

                                            ClientCashReceipt.DbContext = DbContext

                                            If AdvantageFramework.Database.Procedures.ClientCashReceipt.Update(DbContext, ClientCashReceipt) = False Then

                                                Throw New Exception("Failed to update client cash receipt.")

                                            End If

                                            AdvantageFramework.CashReceipts.UpdateClientCashReceiptDetail(DbContext, ClientCashReceipt, ClientInvoiceDetailList, _GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceipt.PostPeriodCode, _BatchDate, GLTransaction)

                                        End If

                                    Else

                                        AdvantageFramework.CashReceipts.UpdateClientCashReceiptDetail(DbContext, ClientCashReceipt, ClientInvoiceDetailList, _GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceipt.PostPeriodCode, _BatchDate, GLTransaction)

                                    End If

                                    ClientCashReceiptOnAccountReversal = AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.LoadActiveByClientCashReceiptID(DbContext, ClientCashReceipt.ID)

                                    If ClientCashReceiptOnAccountReversal IsNot Nothing Then

                                        If ClientCashReceiptOnAccount Is Nothing OrElse
                                                        ClientCashReceiptOnAccountReversal.Amount <> ClientCashReceiptOnAccount.Amount OrElse
                                                        ClientCashReceiptOnAccountReversal.GLACodeOnAccount <> ClientCashReceiptOnAccount.GLACodeOnAccount OrElse
                                                        ClientCashReceiptOnAccountReversal.OfficeCode <> ClientCashReceiptOnAccount.OfficeCode Then

                                            AdvantageFramework.CashReceipts.ReverseClientCashReceiptOnAccount(DbContext, ClientCashReceipt, GLTransaction, _GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceiptOnAccountReversal, False, Nothing, _BatchDate)

                                        ElseIf ClientCashReceiptOnAccount IsNot Nothing Then

                                            ClientCashReceiptOnAccountReversal.DivisionCode = ClientCashReceiptOnAccount.DivisionCode
                                            ClientCashReceiptOnAccountReversal.ProductCode = ClientCashReceiptOnAccount.ProductCode
                                            ClientCashReceiptOnAccountReversal.CampaignCode = ClientCashReceiptOnAccount.CampaignCode
                                            ClientCashReceiptOnAccountReversal.Comment = ClientCashReceiptOnAccount.Comment

                                            If AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Update(DbContext, ClientCashReceiptOnAccountReversal) = False Then

                                                Throw New Exception("Problem updating Client Cash Receipt On Account.")

                                            End If

                                            ClientCashReceiptOnAccount = Nothing

                                        End If

                                    End If

                                    If ClientCashReceiptOnAccount IsNot Nothing Then

                                        AdvantageFramework.CashReceipts.InsertClientCashReceiptOnAccount(DbContext, ClientCashReceipt, GLTransaction, _GLSourceCode, IsInterCompanyTransactionsEnabled, ClientCashReceiptOnAccount, False, _BatchDate)

                                    End If

                                    If GLTransaction IsNot Nothing Then

                                        IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_clientcashreceipt_check_balanced] {0}, {1}", ClientCashReceipt.ID, GLTransaction)).FirstOrDefault

                                    Else

                                        IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_clientcashreceipt_check_balanced] {0}", ClientCashReceipt.ID)).FirstOrDefault

                                    End If

                                    If IsBalanced = 1 Then

                                        DbTransaction.Commit()

                                    Else

                                        Throw New Exception("Cannot save.  Check out of balance.")

                                    End If

                                    Saved = True

                                Catch ex As Exception
                                    If Not Saved Then
                                        DbTransaction.Rollback()
                                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                        ErrorMessage += vbCrLf & ex.Message
                                    End If
                                End Try

                            Else

                                Try

                                    If _HeaderModifyState = HeaderModifyState.NoRestrictions Then

                                        ClientCashReceiptOld.CheckDate = ClientCashReceipt.CheckDate
                                        ClientCashReceiptOld.DepositDate = ClientCashReceipt.DepositDate
                                        ClientCashReceiptOld.CashReceiptPaymentTypeID = ClientCashReceipt.CashReceiptPaymentTypeID

                                        If AdvantageFramework.Database.Procedures.ClientCashReceipt.Update(DbContext, ClientCashReceiptOld) = False Then

                                            Throw New Exception("Problem updating Cash Receipt Header.")

                                        End If

                                    End If

                                    If ClientCashReceiptOnAccountOld IsNot Nothing AndAlso ClientCashReceiptOnAccount IsNot Nothing Then

                                        ClientCashReceiptOnAccountOld.DivisionCode = ClientCashReceiptOnAccount.DivisionCode
                                        ClientCashReceiptOnAccountOld.ProductCode = ClientCashReceiptOnAccount.ProductCode
                                        ClientCashReceiptOnAccountOld.OfficeCode = ClientCashReceiptOnAccount.OfficeCode
                                        ClientCashReceiptOnAccountOld.CampaignCode = ClientCashReceiptOnAccount.CampaignCode
                                        ClientCashReceiptOnAccountOld.Comment = ClientCashReceiptOnAccount.Comment

                                        If AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Update(DbContext, ClientCashReceiptOnAccountOld) = False Then

                                            Throw New Exception("Problem updating Cash Receipt On Account.")

                                        End If

                                    End If

                                    For Each ClientInvoiceDetail In ClientInvoiceDetailList

                                        AdvantageFramework.CashReceipts.UpdateClientCashReceiptDetailPayments(DbContext, ClientInvoiceDetail)

                                        AdvantageFramework.CashReceipts.SaveCollectionNote(DbContext, ClientInvoiceDetail)

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

                ElseIf Saved Then

                    ClientCode = ClientCashReceipt.ClientCode

                    RefreshCheck(ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber, _BatchDate)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage, , "Check will refresh.")

                RefreshCheck(_ID, _SequenceNumber, _BatchDate)

            End If

            Save = Saved

        End Function
        Public Function Insert(ByRef ClientCode As String, ByRef ClientCashReceiptID As Integer, ByRef SequenceNumber As Short, ByVal BatchDate As Date, ByRef BankCode As String) As Boolean

            Dim ErrorMessage As String = Nothing
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim IsValid As Boolean = True
            Dim ClientInvoiceDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing
            Dim ClientCashReceiptOnAccount As AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount = Nothing
            Dim IsBalanced As Integer = 0
            Dim Inserted As Boolean = False
            Dim GLTransaction As Nullable(Of Integer) = Nothing
            Dim ContinueSave As Boolean = True
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            If OkayToSave(ErrorMessage) Then

                If Me.ValidateControl(ErrorMessage) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientCashReceipt = FillObject(DbContext, True)

                        If AdvantageFramework.AccountPayable.IsDateOutsidePostPeriod(DbContext, ClientCashReceipt.CheckDate, ClientCashReceipt.PostPeriodCode) Then

                            If AdvantageFramework.WinForm.MessageBox.Show("The check date is outside of normal range based on the posting period selected, are you sure you want to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                                ContinueSave = False
                                DateTimePickerCheckInfo_Date.Focus()

                            End If

                        End If

                        If ContinueSave AndAlso ClientCashReceipt IsNot Nothing Then

                            ErrorMessage = ClientCashReceipt.ValidateEntity(IsValid)

                            If IsValid Then

                                If NumericInputOnAccount_Amount.Value <> 0 Then

                                    ClientCashReceiptOnAccount = New AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount

                                    LoadClientCashReceiptOnAccountEntity(ClientCashReceiptOnAccount)

                                End If

                                ClientInvoiceDetailList = DataGridViewPanel_ClientInvoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList

                                Try

                                    DbContext.Database.Connection.Open()

                                    DbTransaction = DbContext.Database.BeginTransaction

                                    ClientCashReceipt.DbContext = DbContext

                                    AdvantageFramework.CashReceipts.InsertClientCashReceipt(DbContext, ClientCashReceipt, ClientCashReceiptOnAccount, ClientInvoiceDetailList, _GLSourceCode, _BatchDate, GLTransaction, CashReceipts.CheckState.Add)

                                    IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_clientcashreceipt_check_balanced] {0}, {1}", ClientCashReceipt.ID, GLTransaction)).FirstOrDefault

                                    If IsBalanced = 1 Then

                                        DbTransaction.Commit()

                                    Else

                                        Throw New Exception("Cannot save.  Check out of balance.")

                                    End If

                                    ClientCode = ClientCashReceipt.ClientCode
                                    ClientCashReceiptID = ClientCashReceipt.ID
                                    SequenceNumber = ClientCashReceipt.SequenceNumber
                                    BankCode = ClientCashReceipt.BankCode

                                    Inserted = True

                                Catch ex As Exception
                                    DbTransaction.Rollback()
                                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                                    ErrorMessage += vbCrLf & ex.Message
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
        Public Function Delete(ByRef ClientCode As String) As Boolean

            Dim PostPeriodCode As String = Nothing
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim Deleted As Boolean = False
            Dim GLTransaction As Integer = 0
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If OkayToDelete(PostPeriodCode) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCashReceipt = AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByIDandSequenceNumber(DbContext, _ID, _SequenceNumber)

                    If ClientCashReceipt IsNot Nothing AndAlso ClientCashReceipt.Status <> "D" AndAlso ClientCashReceipt.IsCleared.GetValueOrDefault(0) = 0 Then

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            GLTransaction = AdvantageFramework.CashReceipts.ReverseClientCashReceipt(DbContext, ClientCashReceipt, PostPeriodCode, _BatchDate, _GLSourceCode, True)

                            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_clientcashreceipt_check_balanced_for_delete] {0}, {1}", ClientCashReceipt.ID, GLTransaction)).FirstOrDefault

                            If IsBalanced = 1 Then

                                DbTransaction.Commit()

                                Deleted = True

                                AdvantageFramework.WinForm.MessageBox.Show("Check reversed.  GL Transaction: " & GLTransaction)

                                ClientCode = ClientCashReceipt.ClientCode

                            Else

                                Throw New Exception("Cannot reverse.  Check out of balance.")

                            End If

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
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
        Public Sub SetClient(ByVal ClientCode As String)

            _IsLoading = True

            ClearControl(True)

            SearchableComboBoxPanel_Client.SelectedValue = ClientCode

            SetClientDependentObjects(ClientCode)

            EnableClientSearchControls(False)

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsLoading = False

        End Sub
        Public Function ValidateCheckNumber() As Boolean

            'objects
            Dim ClientCode As String = Nothing
            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim IsValid As Boolean = True

            If SearchableComboBoxPanel_Client.HasASelectedValue AndAlso _ID = 0 Then

                TextBoxPanel_CheckNumber.Text = TextBoxPanel_CheckNumber.Text.Trim()

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue

                    Try

                        ClientCashReceipt = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceipt.Load(DbContext)
                                             Where Entity.ClientCode = ClientCode AndAlso
                                                   Entity.Status Is Nothing AndAlso
                                                   Entity.CheckNumber.ToUpper = TextBoxPanel_CheckNumber.Text.ToUpper).FirstOrDefault

                    Catch ex As Exception
                        ClientCashReceipt = Nothing
                    End Try

                    If ClientCashReceipt IsNot Nothing Then

                        AdvantageFramework.WinForm.MessageBox.Show("Check number has already been entered for this client.  Please enter a different check number.")

                        TextBoxPanel_CheckNumber.Text = ""

                        IsValid = False

                    End If

                End Using

            End If

            ValidateCheckNumber = IsValid

        End Function
        Public Sub ApplyPaymentsUptoCheckAmountToSelectedInvoices()

            Dim KeyValuePair As System.Collections.Generic.KeyValuePair(Of Integer, Object) = Nothing
            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing
            Dim AmountToApply As Decimal = 0
            Dim AppliedTotal As Decimal = 0
            Dim ClientInvoiceDetailCredits As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail) = Nothing
            Dim CreditAmount As Decimal = 0

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            'apply credits
            ClientInvoiceDetailCredits = (From CI In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail).ToList()
                                          Where CI.CurrentBalance < 0).ToList

            For Each ClientInvoiceDetailCredit In ClientInvoiceDetailCredits

                CreditAmount += Math.Abs(ClientInvoiceDetailCredit.CurrentBalance)
                ClientInvoiceDetailCredit.PaymentAmount = ClientInvoiceDetailCredit.CurrentBalance

            Next

            AppliedTotal = DataGridViewPanel_ClientInvoices.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList.Sum(Function(CI) CI.PaymentAmount.GetValueOrDefault(0)) -
                DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList.Sum(Function(CI) CI.PaymentAmount.GetValueOrDefault(0))

            If NumericInputCheckInfo_Amount.EditValue IsNot Nothing Then

                CreditAmount += NumericInputCheckInfo_Amount.EditValue

                For Each KeyValuePair In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                    ClientInvoiceDetail = TryCast(KeyValuePair.Value, AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

                    If ClientInvoiceDetail IsNot Nothing AndAlso ClientInvoiceDetail.CurrentBalance <> 0 Then

                        AmountToApply = ClientInvoiceDetail.OriginalInvoiceAmount - ClientInvoiceDetail.OtherPayments.GetValueOrDefault(0) - ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0)

                        If AmountToApply > 0 Then

                            If (AmountToApply + AppliedTotal) > CreditAmount Then

                                AmountToApply = CreditAmount - AppliedTotal

                            End If

                            If AmountToApply <> 0 Then

                                ClientInvoiceDetail.PaymentAmount = AmountToApply

                                AppliedTotal += AmountToApply

                                If ClientInvoiceDetail.CurrentBalance > 0 AndAlso ClientInvoiceDetail.IsManualInvoice = False Then

                                    DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle = KeyValuePair.Key

                                    LaunchPartialPaymentDialog()

                                End If

                            End If

                        End If

                    End If

                Next

                CalculateTotalAmount()

                DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
                DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

            End If

        End Sub
        'Public Sub ApplyPaymentsToSelectedInvoices()

        '    Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

        '    DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

        '    For Each ClientInvoiceDetail In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)()

        '        ClientInvoiceDetail.PaymentAmount = ClientInvoiceDetail.OriginalInvoiceAmount - ClientInvoiceDetail.OtherPayments.GetValueOrDefault(0) - ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0)

        '        If ClientInvoiceDetail.CurrentBalance <> 0 Then

        '            LaunchPartialPaymentDialog()

        '        End If

        '    Next

        '    CalculateTotalAmount()

        '    DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
        '    DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

        'End Sub
        Public Sub UndoPaymentsOnSelectedInvoices()

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            For Each ClientInvoiceDetail In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)()

                ClientInvoiceDetail.PaymentAmount = Nothing

            Next

            CalculateTotalAmount()

            DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
            DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

        End Sub
        Public Sub ApplyWriteoffsToSelectedInvoices()

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each ClientInvoiceDetail In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems().OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)().ToList

                    If String.IsNullOrWhiteSpace(ClientInvoiceDetail.GLACodeAdjustment) Then

                        SetDefaultWriteoffGL(ClientInvoiceDetail)

                    End If

                    ClientInvoiceDetail.AdjustmentAmount = ClientInvoiceDetail.OriginalInvoiceAmount - ClientInvoiceDetail.OtherPayments.GetValueOrDefault(0) - ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0)

                    ClientInvoiceDetail.DbContext = DbContext
                    ClientInvoiceDetail.ValidateEntity(True)

                Next

            End Using

            CalculateTotalAmount()

            DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
            DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

        End Sub
        Public Sub UndoWriteoffsOnSelectedInvoices()

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each ClientInvoiceDetail In DataGridViewPanel_ClientInvoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)()

                    ClientInvoiceDetail.AdjustmentAmount = 0
                    ClientInvoiceDetail.GLACodeAdjustment = Nothing
                    ClientInvoiceDetail.GLACodeAdjustmentDescription = Nothing

                    ClientInvoiceDetail.DbContext = DbContext
                    ClientInvoiceDetail.ValidateEntity(True)

                Next

            End Using

            CalculateTotalAmount()

            DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
            DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

        End Sub
        Public Sub ApplyToOnAccount()

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            NumericInputOnAccount_Amount.EditValue = Nothing

            CalculateTotalAmount()

            NumericInputOnAccount_Amount.EditValue = NumericInputDisbursedTo_Balance.EditValue

            SearchableComboBoxOnAccount_Division.SelectSingleItemDataSource()
            SearchableComboBoxOnAccount_Product.SelectSingleItemDataSource()

        End Sub
        Public Sub UndoOnAccount()

            NumericInputOnAccount_Amount.EditValue = Nothing

        End Sub
        Public Sub RefreshInvoices(ByVal IncludeOpenInvoices As Boolean)

            _ShowAllOpenInvoices = IncludeOpenInvoices

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadClientInvoices(DbContext, SearchableComboBoxPanel_Client.GetSelectedValue)

            End Using

        End Sub
        Public Sub SetBatchDate(ByVal BatchDate As Date)

            _BatchDate = BatchDate

        End Sub
        Public Sub EnableSearch()

            Me.ClearControl()
            EnableClientSearchControls(False)

        End Sub
        Public Sub LaunchPartialPaymentDialog(Optional ByVal ShowPartialPaymentDialog As Boolean = False)

            'objects
            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing
            Dim IsValid As Boolean = True
            Dim ClientCashReceiptPaymentDetailList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail) = Nothing

            _LaunchingPartialPaymentDialog = True

            DataGridViewPanel_ClientInvoices.CurrentView.CloseEditorForUpdating()

            ClientInvoiceDetail = DirectCast(DataGridViewPanel_ClientInvoices.CurrentView.GetRow(DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle), AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

            If ClientInvoiceDetail IsNot Nothing Then

                If ClientInvoiceDetail.CurrentBalance <> 0 Then

                    If _ClientCashReceiptsPartialPaymentEnabled AndAlso Not _ClientCashReceiptsPartialPaymentRequired AndAlso Not ShowPartialPaymentDialog Then

                        If AdvantageFramework.WinForm.MessageBox.Show("Enter Partial Payments?", MessageBox.MessageBoxButtons.YesNo, "", Windows.Forms.MessageBoxIcon.Question, Windows.Forms.MessageBoxDefaultButton.Button1) = MessageBox.DialogResults.Yes Then

                            ShowPartialPaymentDialog = True

                        End If

                    ElseIf _ClientCashReceiptsPartialPaymentRequired Then

                        ShowPartialPaymentDialog = True

                    End If

                    If ShowPartialPaymentDialog Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ClientInvoiceDetail.DbContext = DbContext
                            ClientInvoiceDetail.ValidateEntity(True)

                        End Using

                        ClientCashReceiptPaymentDetailList = (From CRPD In ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList
                                                              Select New AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail(CRPD)).ToList

                        If AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptPartialPaymentEditDialog.ShowFormDialog(ClientCashReceiptPaymentDetailList, ClientInvoiceDetail.PaymentAmount, ClientInvoiceDetail.CurrentBalance) = Windows.Forms.DialogResult.OK Then

                            ClientInvoiceDetail.SetClientCashReceiptPaymentDetailList(ClientCashReceiptPaymentDetailList)

                            If ClientInvoiceDetail.PaymentAmount Is Nothing Then

                                ClientInvoiceDetail.PaymentAmount = ClientInvoiceDetail.GetClientCashReceiptPaymentDetailList.Sum(Function(PDL) PDL.PaymentAmount.GetValueOrDefault)

                                DataGridViewPanel_ClientInvoices.CurrentView.RefreshRow(DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle)

                            End If

                            DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

                        End If

                        CalculateTotalAmount()

                    End If

                End If

            End If

            _LaunchingPartialPaymentDialog = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientCashReceiptControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TextBoxDropDownPanel_ARComment.TabStop = False

            DataGridViewPanel_ClientInvoices.CurrentView.IndicatorWidth = 35
            DataGridViewPanel_ClientInvoices.AutoloadRepositoryDatasource = False

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub SearchableComboBoxPanel_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxPanel_Client.EditValueChanged

            If Not _IsLoading AndAlso SearchableComboBoxPanel_Client.HasASelectedValue Then

                If Me.FindForm.Modal Then

                    SearchableComboBoxOnAccount_Division.SelectedValue = Nothing
                    SearchableComboBoxOnAccount_Product.SelectedValue = Nothing
                    SearchableComboBoxOnAccount_Office.SelectedValue = Nothing
                    SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing
                    SearchableComboBoxOnAccount_GLAccount.SelectedValue = Nothing

                    SetClientDependentObjects(SearchableComboBoxPanel_Client.GetSelectedValue)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LoadClientInvoices(DbContext, SearchableComboBoxPanel_Client.GetSelectedValue)

                    End Using

                Else

                    SetClient(SearchableComboBoxPanel_Client.GetSelectedValue)

                End If

                RaiseEvent ClientCheckNumberChanged()

            End If

        End Sub
        Private Sub SearchableComboBoxPanel_Client_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SearchableComboBoxPanel_Client.EditValueChanging

            If Not _IsLoading AndAlso Not Me.FindForm.Modal Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub SearchableComboBoxPanel_CheckNumber_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxPanel_CheckNumber.EditValueChanged

            Dim ClientCashReceipt As AdvantageFramework.Database.Entities.ClientCashReceipt = Nothing
            Dim ClientCode As String = Nothing
            Dim CheckNumber As String = Nothing

            If Not _IsLoading AndAlso SearchableComboBoxPanel_Client.HasASelectedValue AndAlso SearchableComboBoxPanel_CheckNumber.HasASelectedValue Then

                ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue
                CheckNumber = SearchableComboBoxPanel_CheckNumber.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCashReceipt = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceipt.LoadByClient(DbContext, ClientCode)
                                         Where Entity.CheckNumber = CheckNumber AndAlso
                                               Entity.Status Is Nothing
                                         Select Entity).SingleOrDefault

                    If ClientCashReceipt IsNot Nothing Then

                        Me.ShowWaitForm("Processing...")

                        LoadControl(SearchableComboBoxPanel_Client.GetSelectedValue, ClientCashReceipt.ID, ClientCashReceipt.SequenceNumber, _BatchDate, _ShowAllOpenInvoices, Nothing)
                        AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                        Me.CloseWaitForm()

                    End If

                End Using

                RaiseEvent ClientCheckNumberChanged()

            ElseIf Not _IsLoading AndAlso SearchableComboBoxPanel_Client.HasASelectedValue AndAlso SearchableComboBoxPanel_CheckNumber.HasASelectedValue = False Then

                ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue
                Me.ClearControl()
                SetClient(ClientCode)

            End If

        End Sub
        Private Sub SearchableComboBoxPanel_CheckNumber_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SearchableComboBoxPanel_CheckNumber.EditValueChanging

            If Not _IsLoading AndAlso e.NewValue IsNot Nothing Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub SearchableComboBoxPanel_CheckNumber_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxPanel_CheckNumber.QueryPopupNeedDataSource

            Dim ClientCode As String = Nothing
            Dim ClientCashReceiptList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceipt) = Nothing

            If SearchableComboBoxPanel_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCashReceiptList = AdvantageFramework.CashReceipts.GetAllCashReceiptListByClient(DbContext, ClientCode)

                    SearchableComboBoxPanel_CheckNumber.DataSource = ClientCashReceiptList.OrderByDescending(Function(CR) CR.CheckDate).ThenByDescending(Function(CR) CR.CheckNumber).ToList

                    DataSourceSet = True

                End Using

            End If

        End Sub
        Private Sub DataGridViewTransactions_GLTransactions_RowDoubleClickEvent() Handles DataGridViewTransactions_GLTransactions.RowDoubleClickEvent

            Dim GLTransaction As Integer = Nothing

            If DataGridViewTransactions_GLTransactions.HasASelectedRow Then

                GLTransaction = DataGridViewTransactions_GLTransactions.CurrentView.GetRowCellValue(DataGridViewTransactions_GLTransactions.CurrentView.FocusedRowHandle, DataGridViewTransactions_GLTransactions.Columns(0))

                AdvantageFramework.FinanceAndAccounting.Presentation.GeneralLedgerTransactionDialog.ShowFormDialog(GLTransaction)

            End If

        End Sub
        Private Sub TextBoxDropDownPanel_ARComment_Enter(sender As Object, e As EventArgs) Handles TextBoxDropDownPanel_ARComment.Enter

            Windows.Forms.SendKeys.Send("{TAB}")

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
        Private Sub TextBoxPanel_CheckNumber_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles TextBoxPanel_CheckNumber.Validating

            e.Cancel = ValidateCheckNumber()

        End Sub
        Private Sub SearchableComboBoxDepositInfo_Bank_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxDepositInfo_Bank.EditValueChanged

            If Not _IsLoading AndAlso SearchableComboBoxDepositInfo_Bank.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadBankDefaults(DbContext)

                End Using

            End If

        End Sub
        Private Sub SearchableComboBoxOnAccount_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxOnAccount_Division.EditValueChanged

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            SearchableComboBoxOnAccount_Product.DataSource = Nothing
            SearchableComboBoxOnAccount_Product.SelectedValue = Nothing

            If SearchableComboBoxPanel_Client.HasASelectedValue AndAlso SearchableComboBoxOnAccount_Division.HasASelectedValue Then

                ClientCode = SearchableComboBoxPanel_Client.GetSelectedValue
                DivisionCode = SearchableComboBoxOnAccount_Division.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SearchableComboBoxOnAccount_Product.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                                                          Where Entity.IsActive = 1 AndAlso
                                                                                Entity.ClientCode = ClientCode AndAlso
                                                                                Entity.DivisionCode = DivisionCode).ToList

                    End Using

                End Using

                SearchableComboBoxOnAccount_Product.Enabled = True
                SearchableComboBoxOnAccount_Product.SelectSingleItemDataSource()

            ElseIf Not SearchableComboBoxOnAccount_Division.HasASelectedValue Then

                SearchableComboBoxOnAccount_Product.Enabled = False

                SearchableComboBoxOnAccount_Office.SelectedValue = Nothing

                SearchableComboBoxOnAccount_Campaign.DataSource = Nothing
                SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxOnAccount_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxOnAccount_Product.EditValueChanged

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If SearchableComboBoxOnAccount_Product.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = SearchableComboBoxPanel_Client.SelectedValue
                    DivisionCode = SearchableComboBoxOnAccount_Division.SelectedValue
                    ProductCode = SearchableComboBoxOnAccount_Product.SelectedValue

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                    If Product IsNot Nothing Then

                        SearchableComboBoxOnAccount_Office.SelectedValue = Product.OfficeCode

                        SearchableComboBoxOnAccount_Campaign.DataSource = AdvantageFramework.Database.Procedures.Campaign.LoadByClientCodeAndDivisionCodeAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode).ToList
                        SearchableComboBoxOnAccount_Campaign.Enabled = True

                    End If

                End Using

            Else

                SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing

                SearchableComboBoxOnAccount_Campaign.Enabled = False

            End If

        End Sub
        Private Sub DataGridViewPanel_ClientInvoices_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewPanel_ClientInvoices.CellValueChangedEvent

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            If Not _LaunchingPartialPaymentDialog AndAlso TypeOf DataGridViewPanel_ClientInvoices.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail Then

                ClientInvoiceDetail = DirectCast(DataGridViewPanel_ClientInvoices.CurrentView.GetRow(e.RowHandle), AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail)

                If e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.AdjustmentAmount.ToString Then

                    If e.Value IsNot Nothing AndAlso e.Value <> 0 AndAlso String.IsNullOrWhiteSpace(ClientInvoiceDetail.GLACodeAdjustment) Then

                        SetDefaultWriteoffGL(ClientInvoiceDetail)

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustment.ToString Then

                    If e.Value IsNot Nothing AndAlso ClientInvoiceDetail.AdjustmentAmount Is Nothing Then

                        ClientInvoiceDetail.AdjustmentAmount = ClientInvoiceDetail.CurrentBalance

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.PaymentAmount.ToString Then

                    If e.Value IsNot Nothing AndAlso e.Value <> 0 AndAlso ClientInvoiceDetail.CurrentBalance <> 0 AndAlso Not ClientInvoiceDetail.IsManualInvoice Then

                        LaunchPartialPaymentDialog()

                    End If

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientInvoiceDetail.DbContext = DbContext
                    ClientInvoiceDetail.ValidateEntity(True)

                End Using

            End If

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewPanel_ClientInvoices_CustomDrawRowIndicatorEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles DataGridViewPanel_ClientInvoices.CustomDrawRowIndicatorEvent

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            ClientInvoiceDetail = DataGridViewPanel_ClientInvoices.CurrentView.GetRow(e.RowHandle)

            If ClientInvoiceDetail IsNot Nothing AndAlso e.Info.IsRowIndicator AndAlso e.RowHandle >= 0 Then

                If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) <> ClientInvoiceDetail.PaymentAmountCopy.GetValueOrDefault(0) OrElse
                        ClientInvoiceDetail.AdjustmentAmount.GetValueOrDefault(0) <> ClientInvoiceDetail.AdjustmentAmountCopy.GetValueOrDefault(0) Then

                    e.Info.DisplayText = "*"

                End If

            End If

        End Sub
        Private Sub DataGridViewPanel_ClientInvoices_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewPanel_ClientInvoices.QueryPopupNeedDatasourceEvent

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case FieldName

                    Case AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.GLACodeAdjustment.ToString

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.CashReceipts.GetAdjustmentGLAccountList(DbContext, DataGridViewPanel_ClientInvoices.CurrentView.GetRowCellValue(DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle, AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail.Properties.OfficeCode.ToString), _Session)

                End Select

            End Using

        End Sub
        Private Sub DataGridViewPanel_ClientInvoices_RowDoubleClickEvent() Handles DataGridViewPanel_ClientInvoices.RowDoubleClickEvent

            Dim ClientInvoiceDetail As AdvantageFramework.CashReceipts.Classes.ClientInvoiceDetail = Nothing

            ClientInvoiceDetail = DataGridViewPanel_ClientInvoices.CurrentView.GetRow(DataGridViewPanel_ClientInvoices.CurrentView.FocusedRowHandle)

            If ClientInvoiceDetail IsNot Nothing Then

                If ClientInvoiceDetail.CurrentBalance <> 0 Then

                    If ClientInvoiceDetail.PaymentAmount.GetValueOrDefault(0) = ClientInvoiceDetail.PaymentAmountCopy.GetValueOrDefault(0) Then

                        ClientInvoiceDetail.PaymentAmount = ClientInvoiceDetail.CurrentBalance

                    Else

                        ClientInvoiceDetail.PaymentAmount = ClientInvoiceDetail.PaymentAmountCopy

                    End If

                Else

                    ClientInvoiceDetail.PaymentAmount = ClientInvoiceDetail.PaymentAmountCopy

                End If

                CalculateTotalAmount()

                DataGridViewPanel_ClientInvoices.CurrentView.RefreshData()
                DataGridViewPanel_ClientInvoices.SetUserEntryChanged()

            End If

        End Sub
        Private Sub NumericInputOnAccount_Amount_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputOnAccount_Amount.ValueChanged

            Dim Required As Boolean = False

            NumericInputDisbursedTo_OnAccount.EditValue = NumericInputOnAccount_Amount.EditValue

            Required = NumericInputOnAccount_Amount.Value <> 0

            SearchableComboBoxOnAccount_Division.SetRequired(Required)
            SearchableComboBoxOnAccount_Product.SetRequired(Required)
            SearchableComboBoxOnAccount_GLAccount.SetRequired(Required)

            CalculateTotalAmount()

        End Sub
        Private Sub NumericInputCheckInfo_Amount_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputCheckInfo_Amount.EditValueChanged

            CalculateTotalAmount()

        End Sub
        Private Sub NumericInputCheckInfo_Amount_Leave(sender As Object, e As EventArgs) Handles NumericInputCheckInfo_Amount.Leave

            If NumericInputCheckInfo_Amount.EditValue Is Nothing AndAlso Not NumericInputCheckInfo_Amount.Properties.ReadOnly Then

                NumericInputCheckInfo_Amount.EditValue = 0

            End If

        End Sub
        Private Sub ComboBoxPanel_PostPeriod_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxPanel_PostPeriod.SelectedValueChanged

            ComboBoxPanel_PostPeriodForMod.SelectedValue = ComboBoxPanel_PostPeriod.GetSelectedValue

        End Sub
        Private Sub DataGridViewPanel_ClientInvoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewPanel_ClientInvoices.SelectionChangedEvent

            RaiseEvent ClientInvoiceSelectionChangedEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
