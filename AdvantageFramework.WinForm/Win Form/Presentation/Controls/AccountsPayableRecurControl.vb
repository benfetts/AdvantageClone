Namespace WinForm.Presentation.Controls

    Public Class AccountsPayableRecurControl

        Public Event TotalsChanged(ByVal Balance As Decimal, ByVal DetailRecordsExist As Boolean)
        Public Event RecurGLInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event RecurGLSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ID As Integer = Nothing
        Private _IsLoading As Boolean = False
        Private _CalculatingDiscount As Boolean = False
        Private _IsSettingFocus As Boolean = False
        Private WithEvents MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing
        Private _MemoExEditValue As String = Nothing
        Private _RecurGLNewRowInitialized As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DataGridViewDistributionDetailsHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewDistributionDetailsHasOnlyOneSelectedRow = DataGridViewDistribution_Details.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DataGridViewDistributionDetailsIsNewItemRow() As Boolean
            Get
                DataGridViewDistributionDetailsIsNewItemRow = DataGridViewDistribution_Details.CurrentView.IsNewItemRow(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DataGridViewDistributionDetailsHasRows As Boolean
            Get
                DataGridViewDistributionDetailsHasRows = DataGridViewDistribution_Details.HasRows
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

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

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.AccountPayableRecur)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            DbContext.Database.Connection.Open()

                            ComboBoxControl_Currency.Enabled = False

                            TextBoxDropDownControl_Note.ReadOnly = True

                            SearchableComboBoxControl_Vendor.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                            SearchableComboBoxControl_Vendor.AddInactiveItemsOnSelectedValue = True
                            SearchableComboBoxControl_Vendor.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.VendorCode)

                            TextBoxControl_Vendor.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.VendorCode)

                            If AdvantageFramework.Database.Procedures.Agency.APFlagVendor1099(DbContext) = 0 Then

                                CheckBoxControl_1099Invoice.Visible = False

                            End If

                            TextBoxControl_InvoiceNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.InvoiceNumber)
                            TextBoxControl_InvoiceNumber.SetRequired(True)
                            TextBoxControl_Description.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.Description)

                            ComboBoxControl_Cycle.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.CycleCode)
                            ComboBoxControl_Cycle.SetRequired(True)
                            ComboBoxControl_Cycle.DataSource = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext)

                            NumericInputControl_NumberOfPostings.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.NumberToPost)
                            NumericInputControl_NumberOfPostings.SetRequired(True)

                            If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse
                                    AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                ComboBoxControl_Office.Visible = True
                                LabelControl_Office.Visible = True
                                ComboBoxControl_Office.SetRequired(True)
                                ComboBoxControl_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)

                            Else

                                ComboBoxControl_Office.Visible = False
                                LabelControl_Office.Visible = False
                                ComboBoxControl_Office.SetRequired(False)

                                ComboBoxControl_APAccount.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True, True)
                                                                        Where Entity.Type = "5").ToList

                            End If

                            ComboBoxControl_APAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.GLACode)
                            ComboBoxControl_APAccount.SetRequired(True)

                            If AdvantageFramework.Database.Procedures.Agency.APLockGLAccountCode(DbContext) = 1 Then

                                ComboBoxControl_APAccount.ReadOnly = True
                                ComboBoxControl_APAccount.Tag = "READONLY"

                            Else

                                ComboBoxControl_APAccount.Enabled = True

                            End If

                            ComboBoxControl_Terms.DataSource = AdvantageFramework.Database.Procedures.VendorTerm.LoadAllActive(DbContext)
                            ComboBoxControl_Terms.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.VendorTermCode)
                            ComboBoxControl_Terms.SetRequired(True)

                            ComboBoxControl_StartPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                            ComboBoxControl_StartPostPeriod.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.StartPostPeriodCode)
                            ComboBoxControl_StartPostPeriod.SetRequired(True)

                            NumericInputControl_InvoiceAmount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.AccountPayableRecur.Properties.InvoiceAmount)
                            NumericInputControl_InvoiceAmount.Properties.MinValue = -999999999.99

                            NumericInputControl_DiscountPercentage.Properties.MinValue = 0
                            NumericInputControl_DiscountPercentage.Properties.MaxValue = 100

                            DbContext.Database.Connection.Close()

                        End Using

                        SearchableComboBoxControl_Vendor.ByPassUserEntryChanged = True

                        TextBoxControl_PayTo.ByPassUserEntryChanged = True
                        AddressControlControl_Address.ByPassUserEntryChanged = True

                        NumericInputDistribution_TotalRecurGL.ByPassUserEntryChanged = True
                        NumericInputDistribution_Balance.ByPassUserEntryChanged = True

                        DataGridViewDistribution_Details.AutoloadRepositoryDatasource = False

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function CalculateTotalAmount() As Boolean

            Dim AccountPayableRecurGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing
            Dim TotalRecurGL As Decimal = 0

            If Not _IsLoading AndAlso Me.FindForm IsNot Nothing Then

                NumericInputControl_InvoiceTotal.EditValue = NumericInputControl_InvoiceAmount.EditValue + NumericInputControl_SalesTax.EditValue

                NumericInputDistribution_TotalRecurGL.EditValue = 0

                If Me.FindForm.Modal OrElse TabItemAPDetails_DistributionTab.Tag = True Then

                    AccountPayableRecurGLDistributionDetailList = DataGridViewDistribution_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList
                    TotalRecurGL = AccountPayableRecurGLDistributionDetailList.Where(Function(APRecurGLDist) APRecurGLDist.IsDeleted = False).Sum(Function(APRecurGLDist) APRecurGLDist.Amount)

                Else

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TotalRecurGL = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Load(DbContext)
                                            Where Entity.AccountPayableRecurID = _ID
                                            Select Entity).ToList.Sum(Function(Entity) Entity.Amount)

                        End Using

                    Catch ex As Exception
                        TotalRecurGL = 0
                    End Try

                End If

                NumericInputDistribution_TotalRecurGL.EditValue = TotalRecurGL

                NumericInputDistribution_Balance.EditValue = NumericInputControl_InvoiceTotal.EditValue - NumericInputDistribution_TotalRecurGL.EditValue

                RaiseEvent TotalsChanged(NumericInputDistribution_Balance.EditValue, DetailRecordsExist)

            End If

            If NumericInputDistribution_Balance.EditValue = 0 Then

                CalculateTotalAmount = True

            Else

                CalculateTotalAmount = False

            End If

        End Function
        Private Sub CalculateCheckAmount()

            NumericInputControl_TotalDue.EditValue = NumericInputControl_InvoiceTotal.EditValue - NumericInputControl_Discount.EditValue

        End Sub
        Private Sub CalculateTotalDiscount()

            _CalculatingDiscount = True

            If NumericInputControl_DiscountPercentage.EditValue <> 0 Then

                NumericInputControl_Discount.EditValue = Format((NumericInputControl_InvoiceAmount.EditValue + NumericInputControl_SalesTax.EditValue) * NumericInputControl_DiscountPercentage.EditValue / 100, "#0.00")

            Else

                NumericInputControl_Discount.EditValue = 0

            End If

            _CalculatingDiscount = False

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim IsOkay As Boolean = True
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = ValidateControl(ErrorMessage)

                    If IsOkay Then

                        Me.ShowWaitForm("Processing...")

                        If NumericInputDistribution_Balance.EditValue = 0 Then

                            If Me.FindForm.Modal = True Then

                                Try

                                    IsOkay = Insert(Nothing)

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

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The amount disbursed and the invoice amount are not equal.", , "Save not allowed")
                            IsOkay = False

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function DetailRecordsExist() As Boolean

            Dim AccountPayableRecurGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing

            AccountPayableRecurGLDistributionDetailList = DataGridViewDistribution_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList

            DetailRecordsExist = AccountPayableRecurGLDistributionDetailList.Where(Function(APRecurGLDist) APRecurGLDist.IsDeleted = False).Any

        End Function
        Private Sub EnableDisableOffice()

            If ComboBoxControl_Office.Visible AndAlso _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) Then

                        If DataGridViewDistribution_Details.CurrentView.RowCount = 0 Then

                            ComboBoxControl_Office.ReadOnly = False

                        Else

                            ComboBoxControl_Office.ReadOnly = True

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub LoadAccountPayableRecurEntity(ByVal AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur)

            If AccountPayableRecur IsNot Nothing Then

                If _ID = 0 Then

                    AccountPayableRecur.VendorCode = SearchableComboBoxControl_Vendor.GetSelectedValue
                    AccountPayableRecur.InvoiceNumber = TextBoxControl_InvoiceNumber.Text

                End If

                AccountPayableRecur.Description = TextBoxControl_Description.Text

                AccountPayableRecur.InvoiceAmount = NumericInputControl_InvoiceAmount.EditValue + AccountPayableRecur.ShippingAmount.GetValueOrDefault(0)
                AccountPayableRecur.ShippingAmount = 0
                AccountPayableRecur.SalesTaxAmount = NumericInputControl_SalesTax.EditValue

                If NumericInputControl_DiscountPercentage.EditValue IsNot Nothing Then

                    AccountPayableRecur.DiscountPercent = NumericInputControl_DiscountPercentage.EditValue

                End If

                AccountPayableRecur.GLACode = ComboBoxControl_APAccount.GetSelectedValue
                AccountPayableRecur.VendorTermCode = ComboBoxControl_Terms.GetSelectedValue
                AccountPayableRecur.CycleCode = ComboBoxControl_Cycle.GetSelectedValue
                AccountPayableRecur.StartPostPeriodCode = ComboBoxControl_StartPostPeriod.GetSelectedValue

                If CheckBoxControl_Unlimited.Checked Then

                    AccountPayableRecur.IsUnlimited = 1
                    AccountPayableRecur.NumberToPost = Nothing

                Else

                    AccountPayableRecur.IsUnlimited = 0
                    AccountPayableRecur.NumberToPost = CInt(NumericInputControl_NumberOfPostings.EditValue)

                End If

                AccountPayableRecur.SequenceBy = 1

                If ComboBoxControl_Office.HasASelectedValue Then

                    AccountPayableRecur.OfficeCode = ComboBoxControl_Office.GetSelectedValue

                End If

                If CheckBoxControl_Inactive.Checked Then

                    AccountPayableRecur.InactiveDate = Now.ToShortDateString
                    AccountPayableRecur.InactiveByUserCode = _Session.UserCode
                    AccountPayableRecur.IsInactive = 1

                Else

                    AccountPayableRecur.IsInactive = 0

                End If

                If CheckBoxControl_1099Invoice.Checked Then

                    AccountPayableRecur.Is1099Invoice = 1

                Else

                    AccountPayableRecur.Is1099Invoice = 0

                End If

            End If

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewDistribution_Details.UseEmbeddedNavigator = True
                DataGridViewDistribution_Details.CurrentView.EnableDisabledRows = False

            Else

                DataGridViewDistribution_Details.UseEmbeddedNavigator = False
                DataGridViewDistribution_Details.CurrentView.EnableDisabledRows = True

            End If

        End Sub
        Private Sub LoadRecurGL()

            Dim AccountPayableRecurGLDistributionDetail As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing

            AccountPayableRecurGLDistributionDetail = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AccountPayableRecurGLDistributionDetail.AddRange(From APRecurGLDist In AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Load(DbContext).ToList
                                                                 Where APRecurGLDist.AccountPayableRecurID = _ID
                                                                 Order By APRecurGLDist.GLACode
                                                                 Select New AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail(DbContext, APRecurGLDist))

                DataGridViewDistribution_Details.DataSource = AccountPayableRecurGLDistributionDetail

                DataGridViewDistribution_Details.CurrentView.BestFitColumns()

            End Using

            TabItemAPDetails_DistributionTab.Tag = True

            CalculateTotalAmount()

            DataGridViewDistribution_Details.ValidateAllRows()
            DataGridViewDistribution_Details.ClearChanged()

            LoadRecurGLRepositoryItems()

        End Sub
        Private Sub LoadRecurGLRepositoryItems()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each GridColumn In DataGridViewDistribution_Details.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    If GridColumn.Visible AndAlso TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        Try

                            SubItemGridLookUpEditControl = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl)

                        Catch ex As Exception
                            SubItemGridLookUpEditControl = Nothing
                        End Try

                        If SubItemGridLookUpEditControl IsNot Nothing Then

                            Select Case GridColumn.FieldName

                                Case AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLACode.ToString

                                    SubItemGridLookUpEditControl.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(GLA) GLA.Code Is Nothing)

                            End Select

                        End If

                    End If

                Next

            End Using

        End Sub
        Private Function RecurGLComplete(ByRef IsValid As Boolean) As String

            Dim AccountPayableRecurGLDistributionDetails As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing
            Dim ErrorText As String = Nothing
            Dim PropertyErrorText As String = Nothing
            Dim FailedOnce As Boolean = False

            AccountPayableRecurGLDistributionDetails = DataGridViewDistribution_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each AccountPayableRecurGLDistributionDetail In AccountPayableRecurGLDistributionDetails

                    AccountPayableRecurGLDistributionDetail.DbContext = DbContext

                    PropertyErrorText = AccountPayableRecurGLDistributionDetail.ValidateEntity(IsValid)

                    If IsValid = False Then

                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

                        FailedOnce = True

                    End If

                Next

            End Using

            IsValid = Not FailedOnce

            RecurGLComplete = ErrorText

        End Function
        Private Sub SetVendorDefaults()

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            If SearchableComboBoxControl_Vendor.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, SearchableComboBoxControl_Vendor.GetSelectedValue)

                    If Vendor IsNot Nothing Then

                        SetVendorPayToAddress(Vendor)

                        ComboBoxControl_Currency.Text = Vendor.CurrencyCode

                        TextBoxControl_VendorNote.Text = Vendor.Notes
                        TextBoxDropDownControl_Note.Text = Vendor.Notes
                        TextBoxControl_Description.Text = Vendor.AccountNumber

                        If CheckBoxControl_1099Invoice.Visible Then

                            If Vendor.Vendor1099Flag = 1 Then

                                CheckBoxControl_1099Invoice.Checked = True

                            Else

                                CheckBoxControl_1099Invoice.Checked = False

                            End If

                        End If

                        If ComboBoxControl_Office.Visible Then

                            If Vendor.OfficeCode IsNot Nothing AndAlso (AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)) Then

                                ComboBoxControl_Office.SelectedValue = Vendor.OfficeCode
                                ComboBoxControl_APAccount.SelectedValue = Vendor.DefaultAPAccount

                            ElseIf Vendor.OfficeCode Is Nothing AndAlso (AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext)) Then

                                ComboBoxControl_Office.SelectedIndex = -1

                            End If

                        End If

                        ComboBoxControl_Terms.SelectedValue = Vendor.VendorTermCode

                        ComboBoxControl_APAccount.RemoveAddedItemsFromDataSource()
                        ComboBoxControl_APAccount.SelectedValue = Vendor.DefaultAPAccount

                        If ComboBoxControl_APAccount.SelectedValue <> Vendor.DefaultAPAccount Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultAPAccount)
                            ComboBoxControl_APAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString, GeneralLedgerAccount.Code, True)
                            ComboBoxControl_APAccount.SelectedValue = Vendor.DefaultAPAccount

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub SetVendorPayToAddress(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            Dim VendorPayTo As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim APShowPayToInformation As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Vendor Is Nothing Then

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, SearchableComboBoxControl_Vendor.GetSelectedValue)

                End If

                APShowPayToInformation = AdvantageFramework.Database.Procedures.Agency.APShowPayToInformation(DbContext)

            End Using

            AddressControlControl_Address.ClearControl()

            If Vendor IsNot Nothing Then

                ComboBoxControl_Currency.Text = Vendor.CurrencyCode
                TextBoxControl_VendorNote.Text = Vendor.Notes
                TextBoxDropDownControl_Note.Text = Vendor.Notes

                If APShowPayToInformation Then

                    If Vendor.Code = Vendor.PayToCode Then

                        TextBoxControl_PayTo.Text = Vendor.PayToName
                        AddressControlControl_Address.Address = Vendor.PayToAddressLine1
                        AddressControlControl_Address.Address2 = Vendor.PayToAddressLine2
                        AddressControlControl_Address.City = Vendor.PayToCity
                        AddressControlControl_Address.County = Vendor.PayToCounty
                        AddressControlControl_Address.State = Vendor.PayToState
                        AddressControlControl_Address.Zip = Vendor.PayToZipCode
                        AddressControlControl_Address.Country = Vendor.PayToCountry

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            VendorPayTo = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Vendor.PayToCode)

                        End Using

                        If VendorPayTo IsNot Nothing Then

                            TextBoxControl_PayTo.Text = VendorPayTo.PayToName
                            AddressControlControl_Address.Address = VendorPayTo.PayToAddressLine1
                            AddressControlControl_Address.Address2 = VendorPayTo.PayToAddressLine2
                            AddressControlControl_Address.City = VendorPayTo.PayToCity
                            AddressControlControl_Address.County = VendorPayTo.PayToCounty
                            AddressControlControl_Address.State = VendorPayTo.PayToState
                            AddressControlControl_Address.Zip = VendorPayTo.PayToZipCode
                            AddressControlControl_Address.Country = VendorPayTo.PayToCountry

                        End If

                    End If

                Else

                    TextBoxControl_PayTo.Text = Vendor.Name
                    AddressControlControl_Address.Address = Vendor.StreetAddressLine1
                    AddressControlControl_Address.Address2 = Vendor.StreetAddressLine2
                    AddressControlControl_Address.City = Vendor.City
                    AddressControlControl_Address.County = Vendor.County
                    AddressControlControl_Address.State = Vendor.State
                    AddressControlControl_Address.Zip = Vendor.ZipCode
                    AddressControlControl_Address.Country = Vendor.Country

                End If

            End If

        End Sub
        Private Function ValidateControl(ByRef ErrorText As String) As Boolean

            Dim IsRecurGLValid As Boolean = True
            Dim IsValid As Boolean = False

            DataGridViewDistribution_Details.CurrentView.CloseEditorForUpdating()

            If CalculateTotalAmount() = True Then

                ErrorText = RecurGLComplete(IsRecurGLValid)

                If Me.Validate AndAlso IsRecurGLValid Then

                    IsValid = True

                End If

            Else

                ErrorText += "The amount disbursed and the invoice amount are not equal."

            End If

            If NumericInputControl_NumberOfPostings.EditValue <= 0 AndAlso CheckBoxControl_Unlimited.Checked = False Then

                IsValid = False

                ErrorText += "You must enter the number of postings or check 'Unlimited'."

            End If

            ValidateControl = IsValid

        End Function
        Private Function VendorHasDefaultExpenseAccount(Optional ByVal RowHandle As Integer = -1) As Boolean

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim OfficeCode As String = Nothing
            Dim GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim ReturnValue As Boolean = False

            If SearchableComboBoxControl_Vendor.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, SearchableComboBoxControl_Vendor.GetSelectedValue)

                    If Vendor.DefaultExpenseAccount IsNot Nothing Then

                        Try

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultExpenseAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                OfficeCode = DataGridViewDistribution_Details.CurrentView.GetRowCellValue(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.OfficeCode.ToString)

                                GeneralLedgerAccountList = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, _Session, ComboBoxControl_Office.GetSelectedValue, OfficeCode)

                                If GeneralLedgerAccountList.Where(Function(Entity) Entity.Code = GeneralLedgerAccount.Code).Any = False Then

                                    GeneralLedgerAccount = Nothing

                                End If

                            End If

                        Catch ex As Exception
                            GeneralLedgerAccount = Nothing
                        End Try

                        If GeneralLedgerAccount IsNot Nothing Then

                            ReturnValue = True

                            If RowHandle <> -1 Then

                                If GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode IsNot Nothing Then

                                    DataGridViewDistribution_Details.CurrentView.SetRowCellValue(RowHandle, DataGridViewDistribution_Details.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.OfficeCode.ToString), GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode)

                                End If

                                DataGridViewDistribution_Details.CurrentView.SetRowCellValue(RowHandle, DataGridViewDistribution_Details.CurrentView.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLACode.ToString), Vendor.DefaultExpenseAccount)

                            End If

                        End If

                    End If

                End Using

            End If

            VendorHasDefaultExpenseAccount = ReturnValue

        End Function

#Region "  Public "

        Public Sub CancelAddNewRecurGL()

            DataGridViewDistribution_Details.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedRecurGL()

            Dim AccountPayableRecurGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing

            If DataGridViewDistribution_Details.HasASelectedRow Then

                DataGridViewDistribution_Details.CurrentView.CloseEditorForUpdating()

                AccountPayableRecurGLDistributionDetailList = DataGridViewDistribution_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList

                If _ID <> 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each AccountPayableRecurGLDistributionDetail In AccountPayableRecurGLDistributionDetailList

                            If AccountPayableRecurGLDistributionDetail.AccountPayableRecurGeneralLedger.IsEntityBeingAdded() = False Then

                                If DataGridViewDistribution_Details.CurrentView.DisabledRows.Where(Function(dr) dr.DataSourceRowIndex = DataGridViewDistribution_Details.CurrentView.GetDataSourceRowIndex(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle)).Any Then

                                    DataGridViewDistribution_Details.CurrentView.EnableRow(DataGridViewDistribution_Details.CurrentView.GetDataSourceRowIndex(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle))
                                    AccountPayableRecurGLDistributionDetail.IsDeleted = False

                                Else

                                    DataGridViewDistribution_Details.CurrentView.DisableRow(DataGridViewDistribution_Details.CurrentView.GetDataSourceRowIndex(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle))
                                    AccountPayableRecurGLDistributionDetail.IsDeleted = True

                                End If

                                DataGridViewDistribution_Details.SetUserEntryChanged()

                                DataGridViewDistribution_Details.Focus()

                            Else

                                DataGridViewDistribution_Details.CurrentView.DeleteSelectedRows()

                            End If

                        Next

                    End Using

                Else

                    DataGridViewDistribution_Details.CurrentView.DeleteSelectedRows()

                End If

                CalculateTotalAmount()

            End If

        End Sub
        Public Sub ClearControl()

            Me.SuspendLayout()

            _ID = 0

            'header
            SearchableComboBoxControl_Vendor.SelectedValue = Nothing
            TextBoxControl_Vendor.Text = Nothing

            ComboBoxControl_Currency.SelectedIndex = -1
            TextBoxControl_InvoiceNumber.Text = Nothing
            CheckBoxControl_1099Invoice.Checked = False
            TextBoxControl_Description.Text = Nothing

            CheckBoxControl_Inactive.Checked = False
            ComboBoxControl_Cycle.SelectedIndex = -1
            CheckBoxControl_Unlimited.Checked = False
            NumericInputControl_NumberOfPostings.EditValue = Nothing

            TextBoxDropDownControl_Note.Text = Nothing

            ComboBoxControl_Office.SelectedIndex = -1
            ComboBoxControl_Terms.SelectedIndex = -1
            ComboBoxControl_APAccount.SelectedIndex = -1
            ComboBoxControl_StartPostPeriod.SelectedIndex = -1
            ComboBoxControl_StartPostPeriod.Text = ""

            NumericInputDistribution_Balance.EditValue = Nothing
            NumericInputDistribution_TotalRecurGL.EditValue = Nothing

            NumericInputControl_InvoiceAmount.EditValue = Nothing
            NumericInputControl_SalesTax.EditValue = Nothing
            NumericInputControl_InvoiceTotal.EditValue = Nothing
            NumericInputControl_DiscountPercentage.EditValue = Nothing
            NumericInputControl_Discount.EditValue = Nothing
            NumericInputControl_TotalDue.EditValue = Nothing

            TextBoxControl_PayTo.Text = Nothing

            AddressControlControl_Address.ClearControl()
            AddressControlControl_Address.ReadOnly = True

            TextBoxControl_LastInvoiceDate.Text = Nothing
            TextBoxControl_ForPeriod.Text = Nothing
            TextBoxControl_TotalNumberPosted.Text = Nothing

            'Distribution tab
            DataGridViewDistribution_Details.ClearGridCustomization()
            DataGridViewDistribution_Details.CurrentView.ClearDisabledRows()

            TabItemAPDetails_DistributionTab.Text = "Distribution"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            Me.ResumeLayout(True)

        End Sub
        Public Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.AccountPayableRecur

            Dim AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur = Nothing

            Try

                If IsNew Then

                    AccountPayableRecur = New AdvantageFramework.Database.Entities.AccountPayableRecur

                    AccountPayableRecur.DbContext = DbContext

                    LoadAccountPayableRecurEntity(AccountPayableRecur)

                Else

                    AccountPayableRecur = AdvantageFramework.Database.Procedures.AccountPayableRecur.LoadByID(DbContext, _ID)

                    LoadAccountPayableRecurEntity(AccountPayableRecur)

                End If

            Catch ex As Exception
                AccountPayableRecur = Nothing
            End Try

            FillObject = AccountPayableRecur

        End Function
        Public Function LoadControl(ByVal VendorCode As String, ByVal ID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur = Nothing
            Dim TotalRecurGL As Decimal = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

            If _ID <> ID OrElse (ID = 0) Then

                _ID = ID

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewDistribution_Details.CurrentView.ClearDisabledRows()

                    If _ID <> 0 Then

                        For Each TabItem In TabControlControl_APDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            TabItem.Tag = False

                        Next

                        AccountPayableRecur = AdvantageFramework.Database.Procedures.AccountPayableRecur.LoadByID(DbContext, _ID)

                        If AccountPayableRecur IsNot Nothing Then

                            _IsLoading = True

                            SearchableComboBoxControl_Vendor.Visible = False
                            SearchableComboBoxControl_Vendor.Enabled = False
                            TextBoxControl_Vendor.Text = AccountPayableRecur.VendorCode

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, AccountPayableRecur.VendorCode)
                            ComboBoxControl_Currency.Text = Vendor.CurrencyCode
                            TextBoxControl_VendorNote.Text = Vendor.Notes
                            TextBoxDropDownControl_Note.Text = Vendor.Notes

                            TextBoxControl_InvoiceNumber.Text = AccountPayableRecur.InvoiceNumber

                            CheckBoxControl_Inactive.Checked = CBool(AccountPayableRecur.IsInactive.GetValueOrDefault(0))

                            CheckBoxControl_1099Invoice.Checked = CBool(AccountPayableRecur.Is1099Invoice.GetValueOrDefault(0))

                            TextBoxControl_Description.Text = AccountPayableRecur.Description

                            Try

                                TotalRecurGL = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Load(DbContext)
                                                Where Entity.AccountPayableRecurID = _ID
                                                Select Entity.Amount).Sum

                            Catch ex As Exception
                                TotalRecurGL = 0
                            End Try

                            NumericInputDistribution_TotalRecurGL.EditValue = TotalRecurGL

                            NumericInputControl_InvoiceAmount.EditValue = AccountPayableRecur.InvoiceAmount + AccountPayableRecur.ShippingAmount.GetValueOrDefault(0)
                            NumericInputControl_SalesTax.EditValue = AccountPayableRecur.SalesTaxAmount.GetValueOrDefault(0)
                            NumericInputControl_DiscountPercentage.EditValue = AccountPayableRecur.DiscountPercent.GetValueOrDefault(0)

                            NumericInputDistribution_Balance.EditValue = NumericInputControl_InvoiceAmount.Value + NumericInputControl_SalesTax.Value - NumericInputDistribution_TotalRecurGL.Value

                            SetVendorPayToAddress(Vendor)

                            ComboBoxControl_Cycle.SelectedValue = AccountPayableRecur.CycleCode

                            ComboBoxControl_StartPostPeriod.RemoveAddedItemsFromDataSource()

                            If AccountPayableRecur.PostPeriod.APStatus = "X" Then

                                ComboBoxControl_StartPostPeriod.AddComboItemToExistingDataSource(AccountPayableRecur.StartPostPeriodCode.ToString, AccountPayableRecur.StartPostPeriodCode, True)

                            End If

                            ComboBoxControl_StartPostPeriod.SelectedValue = AccountPayableRecur.StartPostPeriodCode

                            NumericInputControl_NumberOfPostings.EditValue = AccountPayableRecur.NumberToPost

                            CheckBoxControl_Unlimited.Checked = CBool(AccountPayableRecur.IsUnlimited.GetValueOrDefault(0))

                            ComboBoxControl_APAccount.Enabled = True
                            ComboBoxControl_Terms.Enabled = True

                            If AccountPayableRecur.OfficeCode IsNot Nothing Then

                                ComboBoxControl_Office.SelectedValue = AccountPayableRecur.OfficeCode

                            ElseIf AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) OrElse AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                If AccountPayableRecur.GeneralLedgerAccount IsNot Nothing AndAlso AccountPayableRecur.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                    ComboBoxControl_Office.SelectedValue = AccountPayableRecur.GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

                                End If

                            Else

                                ComboBoxControl_Office.SelectedValue = Nothing

                            End If

                            ComboBoxControl_APAccount.SelectedValue = AccountPayableRecur.GLACode

                            If AccountPayableRecur.VendorTermCode IsNot Nothing Then

                                ComboBoxControl_Terms.SelectedValue = AccountPayableRecur.VendorTermCode

                            End If

                            If AccountPayableRecur.LastPostedDate IsNot Nothing Then

                                TextBoxControl_LastInvoiceDate.Text = CDate(AccountPayableRecur.LastPostedDate).ToShortDateString

                            End If

                            If AccountPayableRecur.LastPostPeriodCode IsNot Nothing Then

                                TextBoxControl_ForPeriod.Text = AccountPayableRecur.LastPostPeriodCode

                            End If

                            TextBoxControl_TotalNumberPosted.Text = AccountPayableRecur.TotalPosted.ToString

                            LoadRecurGL()

                            _IsLoading = False

                            CalculateTotalAmount()

                            CalculateCheckAmount()

                        Else

                            Loaded = False

                        End If

                    Else

                        _IsLoading = True

                        TextBoxControl_Vendor.SetRequired(False)
                        TextBoxControl_Vendor.Visible = False
                        SearchableComboBoxControl_Vendor.Focus()

                        TextBoxControl_InvoiceNumber.SetRequired(True)
                        TextBoxControl_InvoiceNumber.ReadOnly = False
                        TextBoxControl_InvoiceNumber.TabStop = True

                        TextBoxControl_PayTo.Text = Nothing

                        AddressControlControl_Address.ClearControl()
                        AddressControlControl_Address.ReadOnly = True

                        NumericInputControl_NumberOfPostings.EditValue = Nothing

                        ComboBoxControl_Office.SelectedIndex = -1
                        ComboBoxControl_Terms.SelectedIndex = -1
                        ComboBoxControl_APAccount.SelectedIndex = -1

                        PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentAPPostPeriod(DbContext)

                        If PostPeriod IsNot Nothing Then

                            ComboBoxControl_StartPostPeriod.SelectedValue = PostPeriod.Code

                        Else

                            ComboBoxControl_StartPostPeriod.SelectedIndex = 0

                        End If

                        Try

                            If VendorCode IsNot Nothing Then

                                SearchableComboBoxControl_Vendor.SelectedValue = VendorCode

                            End If

                        Catch ex As Exception

                        End Try

                        LoadRecurGL()

                        _IsLoading = False

                        CalculateTotalAmount()

                    End If

                End Using

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            Dim AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur = Nothing
            Dim AccountPayableRecurGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing
            Dim AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = Nothing

            If ValidateControl(ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableRecur = FillObject(DbContext, False)

                    If AccountPayableRecur IsNot Nothing Then

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            If AdvantageFramework.Database.Procedures.AccountPayableRecur.Update(DbContext, AccountPayableRecur) = False Then

                                Throw New Exception("Failed to update AP Recur Header.")

                            End If

                            AccountPayableRecurGLDistributionDetailList = DataGridViewDistribution_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList

                            For Each AccountPayableRecurGLDistributionDetail In AccountPayableRecurGLDistributionDetailList

                                AccountPayableRecurGeneralLedger = AccountPayableRecurGLDistributionDetail.AccountPayableRecurGeneralLedger

                                AccountPayableRecurGeneralLedger.DbContext = DbContext

                                If AccountPayableRecurGLDistributionDetail.IsDeleted Then

                                    If AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Delete(DbContext, AccountPayableRecurGeneralLedger) = False Then

                                        Throw New Exception("Failed to delete AP Recur GL.")

                                    End If

                                ElseIf AccountPayableRecurGeneralLedger.IsEntityBeingAdded() Then

                                    AccountPayableRecurGeneralLedger.AccountPayableRecurID = AccountPayableRecur.ID
                                    If AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Insert(DbContext, AccountPayableRecurGeneralLedger) = False Then

                                        Throw New Exception("Failed to insert AP Recur GL.")

                                    End If

                                Else

                                    If AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Update(DbContext, AccountPayableRecurGeneralLedger) = False Then

                                        Throw New Exception("Failed to update AP Recur GL.")

                                    End If

                                End If

                            Next

                            DbTransaction.Commit()

                            Saved = True

                            DataGridViewDistribution_Details.CurrentView.ClearDisabledRows()

                            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    End If

                End Using

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Insert(ByRef AccountPayableRecurID As Integer) As Boolean

            Dim AccountPayableRecur As AdvantageFramework.Database.Entities.AccountPayableRecur = Nothing
            Dim AccountPayableRecurGLDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail) = Nothing
            Dim AccountPayableRecurGeneralLedger As AdvantageFramework.Database.Entities.AccountPayableRecurGeneralLedger = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing

            If ValidateControl(ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableRecur = FillObject(DbContext, True)

                    If AccountPayableRecur IsNot Nothing Then

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            AccountPayableRecur.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.AccountPayableRecur.Insert(DbContext, AccountPayableRecur) = False Then

                                Throw New Exception("Insert AP Recur Header failed.")

                            End If

                            AccountPayableRecurGLDistributionDetailList = DataGridViewDistribution_Details.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail)().ToList

                            For Each AccountPayableRecurGLDistributionDetail In AccountPayableRecurGLDistributionDetailList

                                AccountPayableRecurGeneralLedger = AccountPayableRecurGLDistributionDetail.AccountPayableRecurGeneralLedger

                                AccountPayableRecurGeneralLedger.DbContext = DbContext
                                AccountPayableRecurGeneralLedger.AccountPayableRecurID = AccountPayableRecur.ID

                                If AdvantageFramework.Database.Procedures.AccountPayableRecurGeneralLedger.Insert(DbContext, AccountPayableRecurGeneralLedger) = False Then

                                    Throw New Exception("Insert AP Recur GL failed.")

                                End If

                            Next

                            DbTransaction.Commit()

                            AccountPayableRecurID = AccountPayableRecur.ID

                            Inserted = True

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    End If

                End Using

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub AccountsPayableControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxControl_Inactive.ByPassUserEntryChanged = True
            LoadModalOptions()
            TextBoxDropDownControl_Note.TabStop = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ComboBoxControl_Office_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxControl_Office.SelectedValueChanged

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerOfficeCrossReferenceCode As String = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ComboBoxControl_Office.HasASelectedValue Then

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, ComboBoxControl_Office.GetSelectedValue)

                        If Office IsNot Nothing Then

                            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, Office.Code)

                            If GeneralLedgerOfficeCrossReference IsNot Nothing Then

                                GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReference.Code

                                ComboBoxControl_APAccount.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True, True).Include("GeneralLedgerOfficeCrossReference")
                                                                        Where Entity.GeneralLedgerOfficeCrossReferenceCode = GeneralLedgerOfficeCrossReferenceCode
                                                                        Where Entity.Type = "5").ToList

                            Else

                                ComboBoxControl_APAccount.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True, True).Include("GeneralLedgerOfficeCrossReference")
                                                                        Where Entity.Type = "5").ToList

                            End If

                            ComboBoxControl_APAccount.SelectedValue = Office.AccountsPayableGLACode

                        End If

                    Else

                        ComboBoxControl_APAccount.DataSource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True, True)
                                                                Where Entity.Type = "5").ToList

                        ComboBoxControl_APAccount.SelectedValue = Nothing

                    End If

                End Using

            End If

        End Sub
        Private Sub ComboBoxControl_Terms_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_Terms.SelectedValueChanged

            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing

            If ComboBoxControl_Terms.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(DbContext, ComboBoxControl_Terms.GetSelectedValue)

                    NumericInputControl_DiscountPercentage.EditValue = VendorTerm.DiscountPercentage.GetValueOrDefault(0)

                End Using

            End If

        End Sub
        Private Sub DataGridViewDistribution_Details_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewDistribution_Details.AddNewRowEvent

            DataGridViewDistribution_Details.SetUserEntryChanged()

            _RecurGLNewRowInitialized = False

        End Sub
        Private Sub DataGridViewDistribution_Details_ColumnValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ByVal ViaCellValueChangedEvent As Boolean) Handles DataGridViewDistribution_Details.ColumnValueChangedEvent

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing

            If e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLACode.ToString Then

                If e.Value IsNot Nothing AndAlso e.Value <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                        If GeneralLedgerAccount IsNot Nothing Then

                            DataGridViewDistribution_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLADescription.ToString, GeneralLedgerAccount.Description)

                            GeneralLedgerOfficeCrossReference = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerAccount.GeneralLedgerOfficeCrossReferenceCode)

                            If GeneralLedgerOfficeCrossReference IsNot Nothing AndAlso GeneralLedgerOfficeCrossReference.OfficeCode IsNot Nothing Then

                                DirectCast(DataGridViewDistribution_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail).OfficeCode = GeneralLedgerOfficeCrossReference.OfficeCode

                            End If

                        End If

                    End Using

                Else

                    DataGridViewDistribution_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLADescription.ToString, Nothing)

                End If

            End If

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewDistribution_Details_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDistribution_Details.CellValueChangingEvent

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewDistribution_Details_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDistribution_Details.Enter

            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            DataGridView = CType(sender, AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If DataGridView.GridControl.MainView.DataRowCount = 0 Then

                If DataGridView.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

                    DataGridView.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridView.CurrentView.FocusedColumn = DataGridViewDistribution_Details.CurrentView.VisibleColumns(0)

                End If

                DataGridView.CurrentView.ShowEditor()

            End If

        End Sub
        Private Sub DataGridViewDistribution_Details_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewDistribution_Details.InitNewRowEvent

            _RecurGLNewRowInitialized = True

            VendorHasDefaultExpenseAccount(e.RowHandle)

            RaiseEvent RecurGLInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewDistribution_Details_RowCountChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDistribution_Details.RowCountChangedEvent

            EnableDisableOffice()

            If Not _IsLoading Then

                CalculateTotalAmount()

            End If

        End Sub
        Private Sub DataGridViewDistribution_Details_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDistribution_Details.SelectionChangedEvent

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewDistribution_Details_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewDistribution_Details.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AllowContinue As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAPLimitByOfficeEnabled(DbContext) Then

                    If ComboBoxControl_Office.HasASelectedValue = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an office.")
                        AllowContinue = False
                        DataGridViewDistribution_Details.CurrentView.CloseEditorForUpdating()
                        ComboBoxControl_Office.Focus()

                    End If

                End If

                If AllowContinue Then

                    If DataGridViewDistribution_Details.CurrentView.IsNewItemRow(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle) AndAlso VendorHasDefaultExpenseAccount() AndAlso Not _RecurGLNewRowInitialized Then

                        DataGridViewDistribution_Details.CurrentView.ActiveEditor.IsModified = True

                    End If

                    If TypeOf DataGridViewDistribution_Details.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                        GridLookUpEdit = DataGridViewDistribution_Details.CurrentView.ActiveEditor

                        If DataGridViewDistribution_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.GLACode.ToString Then

                            BindingSource = New System.Windows.Forms.BindingSource
                            BindingSource.DataSource = AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, _Session, ComboBoxControl_Office.GetSelectedValue, Nothing)

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        End If

                    ElseIf TypeOf DataGridViewDistribution_Details.CurrentView.ActiveEditor Is DevExpress.XtraEditors.MemoExEdit Then

                        _MemoExEditValue = DataGridViewDistribution_Details.CurrentView.GetRowCellValue(DataGridViewDistribution_Details.CurrentView.FocusedRowHandle, AdvantageFramework.AccountPayable.Classes.AccountPayableRecurGLDistributionDetail.Properties.Comment.ToString)
                        MemoExEdit = DataGridViewDistribution_Details.CurrentView.ActiveEditor

                    End If

                End If

            End Using

            CalculateTotalAmount()

        End Sub
        Private Sub DataGridViewDistribution_Details_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewDistribution_Details.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        CancelAddNewRecurGL()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteSelectedRecurGL()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub NumericInputControl_InvoiceAmount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputControl_InvoiceAmount.EditValueChanged

            CalculateTotalAmount()
            CalculateTotalDiscount()

        End Sub
        Private Sub NumericInputControl_SalesTax_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputControl_SalesTax.EditValueChanged

            CalculateTotalAmount()
            CalculateTotalDiscount()

        End Sub
        Private Sub NumericInputControl_DiscountPercentage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputControl_DiscountPercentage.EditValueChanged

            CalculateTotalDiscount()

        End Sub
        Private Sub NumericInputControl_Discount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputControl_Discount.EditValueChanged

            If _CalculatingDiscount = False Then

                If NumericInputControl_InvoiceAmount.EditValue IsNot Nothing OrElse NumericInputControl_SalesTax.EditValue IsNot Nothing Then

                    NumericInputControl_DiscountPercentage.EditValue = NumericInputControl_Discount.EditValue / (NumericInputControl_InvoiceAmount.EditValue + NumericInputControl_SalesTax.EditValue) * 100

                End If

            End If

            CalculateCheckAmount()

        End Sub
        Private Sub NumericInputControl_InvoiceTotal_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericInputControl_InvoiceTotal.EditValueChanged

            CalculateCheckAmount()

        End Sub
        Private Sub SearchableComboBoxControl_Vendor_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxControl_Vendor.EditValueChanged

            If Me.FindForm.Modal Then

                SetVendorDefaults()

            End If

        End Sub
        Private Sub SearchableComboBoxControl_Vendor_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SearchableComboBoxControl_Vendor.EditValueChanging

            If Not _IsLoading AndAlso SearchableComboBoxControl_Vendor.SelectedValue IsNot Nothing AndAlso SearchableComboBoxControl_Vendor.SelectedValue <> "" Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub SearchableComboBoxControl_Vendor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxControl_Vendor.GotFocus

            Dim ParentForm As System.Windows.Forms.Form = Nothing

            If TextBoxControl_InvoiceNumber.Text = "" Then

                ParentForm = Me.FindForm

                If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    If DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuperValidator.ClearFailedValidations()

                    End If

                End If

            End If

        End Sub
        Private Sub TextBoxControl_InvoiceNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextBoxControl_InvoiceNumber.Validating

            Dim VendorCode As String = Nothing

            If SearchableComboBoxControl_Vendor.HasASelectedValue AndAlso _ID = 0 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorCode = SearchableComboBoxControl_Vendor.GetSelectedValue

                    If (From Entity In AdvantageFramework.Database.Procedures.AccountPayableRecur.Load(DbContext)
                        Where Entity.VendorCode = VendorCode AndAlso
                              Entity.InvoiceNumber.ToUpper = TextBoxControl_InvoiceNumber.Text.ToUpper
                        Select Entity).Any Then

                        AdvantageFramework.WinForm.MessageBox.Show("Invoice on File")

                        TextBoxControl_InvoiceNumber.Text = ""

                        e.Cancel = True

                    End If

                End Using

            End If

        End Sub
        Private Sub TextBoxDropDownControl_Note_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxDropDownControl_Note.Enter

            Windows.Forms.SendKeys.Send("{TAB}")

        End Sub
        Private Sub CheckBoxControl_Unlimited_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControl_Unlimited.CheckedChanged

            If CheckBoxControl_Unlimited.Checked Then

                NumericInputControl_NumberOfPostings.EditValue = Nothing
                NumericInputControl_NumberOfPostings.Enabled = False
                NumericInputControl_NumberOfPostings.SetRequired(False)

                If Not _IsLoading Then

                    TryCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me.NumericInputControl_NumberOfPostings)

                End If

            Else

                NumericInputControl_NumberOfPostings.Enabled = True
                NumericInputControl_NumberOfPostings.SetRequired(True)

            End If

        End Sub
        Private Sub MemoExEdit_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles MemoExEdit.CloseUp

            Dim DropDownWindow As Windows.Forms.Control = Nothing
            Dim FieldInfo As System.Reflection.FieldInfo = Nothing
            Dim MemoEditEdit As DevExpress.XtraEditors.MemoEdit = Nothing

            DropDownWindow = CType(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow
            FieldInfo = GetType(DevExpress.XtraEditors.Popup.MemoExPopupForm).GetField("memo", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            MemoEditEdit = CType(FieldInfo.GetValue(DropDownWindow), DevExpress.XtraEditors.MemoEdit)

            _MemoExEditValue = MemoEditEdit.Text

        End Sub
        Private Sub MemoExEdit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MemoExEdit.KeyPress

            Dim EditValue As String = Nothing

            EditValue = DirectCast(sender, DevExpress.XtraEditors.MemoExEdit).EditValue

            If Char.IsControl(e.KeyChar) Then

                e.Handled = True

            Else

                _MemoExEditValue = EditValue + e.KeyChar
                MemoExEdit.ShowPopup()
                e.Handled = True

            End If

        End Sub
        Private Sub MemoExEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MemoExEdit.Popup

            Dim DropDownWindow As Windows.Forms.Control = Nothing
            Dim FieldInfo As System.Reflection.FieldInfo = Nothing
            Dim MemoEditEdit As DevExpress.XtraEditors.MemoEdit = Nothing

            DropDownWindow = CType(sender, DevExpress.Utils.Win.IPopupControl).PopupWindow
            FieldInfo = GetType(DevExpress.XtraEditors.Popup.MemoExPopupForm).GetField("memo", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            MemoEditEdit = CType(FieldInfo.GetValue(DropDownWindow), DevExpress.XtraEditors.MemoEdit)

            MemoEditEdit.Text = _MemoExEditValue
            MemoEditEdit.SelectionStart = MemoEditEdit.Text.Length
            MemoEditEdit.SelectionLength = 0

        End Sub
        Private Sub CheckBoxControl_Inactive_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxControl_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxControl_Inactive.Checked = Not CheckBoxControl_Inactive.Checked

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
