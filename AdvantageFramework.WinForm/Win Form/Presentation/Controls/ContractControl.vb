Namespace WinForm.Presentation.Controls

    Public Class ContractControl
        Public Event SelectedDocumentChanged()
        Public Event SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event ContractFeesInitNewRowEvent()
        Public Event ContractFeesSelectionChangedEvent()
        Public Event ContractValueAddedInitNewRowEvent()
        Public Event ContractValueAddedSelectionChangedEvent()
        Public Event ContractContactInitNewRowEvent()
        Public Event ContractContactSelectionChangedEvent()
        Public Event ContractReportInitNewRowEvent()
        Public Event ContractReportSelectionChangedEvent()
        Public Event BillingRateCommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event BillingRateCommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event BillingTermsGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event BillingTermsLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event EstimatingTermsGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event EstimatingTermsLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentsGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentsLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SelectedReportDocumentChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ContractID As Integer = 0
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _ContractFeeItemList As Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem) = Nothing
        Private _ContractContactList As Generic.List(Of AdvantageFramework.Database.Entities.ContractContact) = Nothing
        Private _ContractValueAddedList As Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded) = Nothing
        Private _ContractReportDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail) = Nothing
        Private _HasAccessToDocuments As Boolean = False
        Private _HasAccessToReportDocuments As Boolean = False
        Private _HasAccessToValueAddedDocuments As Boolean = False
        Private _CanUserUpdateInClientMaintenance As Boolean = False
        Private _ShowAllContractReportDocuments As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInClientMaintenance() As Boolean
            Get
                CanUserUpdateInClientMaintenance = _CanUserUpdateInClientMaintenance
            End Get
        End Property
        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property DocumentManager() As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_ContractDocuments
            End Get
        End Property
        Public ReadOnly Property DataGridViewValueAdded_HasDocument As Boolean
            Get
                DataGridViewValueAdded_HasDocument = DataGridViewValueAdded_ValueAdded.CurrentView.GetRowCellValue(DataGridViewValueAdded_ValueAdded.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ContractValueAdded.Properties.HasDocument.ToString)
            End Get
        End Property
        Public ReadOnly Property DataGridViewValueAdded_DocumentIsAURL As Boolean
            Get
                DataGridViewValueAdded_DocumentIsAURL = DataGridViewValueAdded_HasDocument AndAlso DataGridViewValueAdded_ValueAdded.CurrentView.GetRowCellValue(DataGridViewValueAdded_ValueAdded.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.ContractValueAdded.Properties.IsDocumentAURL.ToString)
            End Get
        End Property
        Public ReadOnly Property DocumentManagerReports() As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManagerReports = DocumentManagerControlReportsDocuments_ReportsDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToReportDocuments As Boolean
            Get
                HasAccessToReportDocuments = _HasAccessToReportDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToValueAddedDocuments As Boolean
            Get
                HasAccessToValueAddedDocuments = _HasAccessToValueAddedDocuments
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Contract)
                        _HasAccessToReportDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ContractReport)
                        _HasAccessToValueAddedDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ContractValueAdded)

                        _CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                ' general tab
                                CheckBoxGeneral_Inactive.ByPassUserEntryChanged = True

                                TextBoxGeneral_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.Code)
                                TextBoxGeneral_Description.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.Description)

                                SearchableComboBoxGeneral_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ClientCode)
                                SearchableComboBoxGeneral_Division.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.DivisionCode)
                                SearchableComboBoxGeneral_Product.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ProductCode)

                                DateTimePickerGeneral_StartDate.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.StartDate)
                                DateTimePickerGeneral_EndDate.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.EndDate)

                                AddressControlGeneral_Address.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.City)
                                AddressControlGeneral_Address.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Country)
                                AddressControlGeneral_Address.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.County)
                                AddressControlGeneral_Address.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Address2)
                                AddressControlGeneral_Address.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.State)
                                AddressControlGeneral_Address.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Address)
                                AddressControlGeneral_Address.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Client.Properties.Zip)

                                ' rates / term tab
                                NumericInputContractType_BlendedHourlyBillingRate.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.BlendedHourlyRate)
                                NumericInputContractType_BlendedHourlyBillingRate.Properties.MinValue = 0
                                NumericInputContractType_BlendedHourlyBillingRate.Properties.MaxValue = 9999.99

                                NumericInputRateTerms_FeeRetainer.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.FeeRetainer)
                                NumericInputRateTerms_FeeIncentiveBonus.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.FeeIncentiveBonus)
                                NumericInputRateTerms_FeeRoyalty.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.FeeRoyalty)
                                NumericInputRateTerms_FeeProjectHourly.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.FeeProjectHourly)
                                NumericInputRateTerms_Hours.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.Hours)
                                NumericInputRateTerms_MediaCommission.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.MediaCommission)
                                NumericInputRateTerms_ProductionCommission.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ProductionCommission)
                                NumericInputRateTerms_TotalContractValue.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ProductionCommission)

                                _ContractFeeItemList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem)

                                DataGridViewRateTerm_ContractFees.DataSource = _ContractFeeItemList

                                ' comments tab
                                TextBoxComments_BillingRateComment.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.BillingRateComment)
                                TextBoxComments_BillingTerms.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.BillingTerms)
                                TextBoxComments_EstimatingTerms.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.EstimatingTerms)
                                TextBoxComments_Comments.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ContractComments)

                                ' value added tab
                                _ContractValueAddedList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded)

                                DataGridViewValueAdded_ValueAdded.DataSource = _ContractValueAddedList

                                ' reports tab
                                _ContractReportDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail)

                                DataGridViewReports_Reports.DataSource = _ContractReportDetailList

                                ' internal contacts tab
                                _ContractContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ContractContact)

                                DataGridViewInternalContacts_Contacts.DataSource = _ContractContactList

                                If Me.CanUserUpdateInClientMaintenance Then

                                    DataGridViewRateTerm_ContractFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewRateTerm_ContractFees.OptionsBehavior.Editable = True

                                    DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewInternalContacts_Contacts.OptionsBehavior.Editable = True

                                    DataGridViewReports_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewReports_Reports.OptionsBehavior.Editable = True

                                    DataGridViewValueAdded_ValueAdded.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewValueAdded_ValueAdded.OptionsBehavior.Editable = True

                                Else

                                    DataGridViewRateTerm_ContractFees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewRateTerm_ContractFees.OptionsBehavior.Editable = False

                                    DataGridViewInternalContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewInternalContacts_Contacts.OptionsBehavior.Editable = False

                                    DataGridViewReports_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewReports_Reports.OptionsBehavior.Editable = False

                                    DataGridViewValueAdded_ValueAdded.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewValueAdded_ValueAdded.OptionsBehavior.Editable = False

                                End If

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Contract

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Try

                If IsNew Then

                    Contract = New AdvantageFramework.Database.Entities.Contract

                    LoadContractEntity(Contract, True)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, _ContractID)

                        If Contract IsNot Nothing Then

                            LoadContractEntity(Contract, False)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Contract = Nothing
            End Try

            FillObject = Contract

        End Function
        Private Sub LoadContractEntity(ByVal Contract As AdvantageFramework.Database.Entities.Contract, ByVal IsNew As Boolean)

            If Contract IsNot Nothing Then

                If IsNew = True OrElse TabItemContractSetup_GeneralTab.Tag = True Then

                    SaveGeneralTab(Contract)

                End If

                If IsNew = True OrElse TabItemContractSetup_RatesTermsTab.Tag = True Then

                    SaveRatesTermsTab(Contract)

                End If

                If IsNew = True OrElse TabItemContractSetup_CommentsTab.Tag = True Then

                    SaveCommentsTab(Contract)

                End If

            End If

        End Sub
        Private Sub LoadContractFees()

            If _ContractID <> 0 Then

                _ContractFeeItemList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ContractFeeItemList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractFee.LoadByContractID(DbContext, _ContractID).ToList
                                                  Select New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, Entity))

                End Using

            End If

            DataGridViewRateTerm_ContractFees.DataSource = _ContractFeeItemList

            If DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString) IsNot Nothing Then

                If DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString) IsNot Nothing Then

                If DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            DataGridViewRateTerm_ContractFees.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadReportsTab()

            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            Contract = LoadSelectedContract()

            If Contract IsNot Nothing Then

                LoadReportsTab(Contract)

            End If

        End Sub
        Private Sub LoadReportsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                LoadContractReports()

                TabItemContractSetup_ReportsTab.Tag = True

            End If

        End Sub
        Private Sub LoadContractValueAdded()

            If _ContractID <> 0 Then

                _ContractValueAddedList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ContractValueAddedList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByContractID(DbContext, _ContractID).ToList
                                                     Select New AdvantageFramework.Database.Classes.ContractValueAdded(DbContext, Entity))

                End Using

            End If

            DataGridViewValueAdded_ValueAdded.DataSource = _ContractValueAddedList

            If DataGridViewValueAdded_ValueAdded.Columns(AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Amount.ToString) IsNot Nothing Then

                If DataGridViewValueAdded_ValueAdded.Columns(AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Amount.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridViewValueAdded_ValueAdded.Columns(AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Amount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewValueAdded_ValueAdded.Columns(AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Amount.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            DataGridViewValueAdded_ValueAdded.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadContractReports()

            If _ContractID <> 0 Then

                _ContractReportDetailList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        _ContractReportDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractReport.LoadByContractID(DbContext, _ContractID).ToList
                                                           Select New AdvantageFramework.Database.Classes.ContractReportDetail(DataContext, Entity))

                    End Using

                End Using

            End If

            DataGridViewReports_Reports.DataSource = _ContractReportDetailList
            DataGridViewReports_Reports.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadContractContacts()

            If _ContractID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ContractContactList = AdvantageFramework.Database.Procedures.ContractContact.LoadByContractID(DbContext, _ContractID).ToList

                End Using

            End If

            DataGridViewInternalContacts_Contacts.DataSource = _ContractContactList
            DataGridViewInternalContacts_Contacts.CurrentView.BestFitColumns()

        End Sub
        Private Function LoadSelectedContract() As AdvantageFramework.Database.Entities.Contract

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            If _ContractID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, _ContractID)

                    Catch ex As Exception
                        Contract = Nothing
                    End Try

                End Using

            End If

            LoadSelectedContract = Contract

        End Function
        Private Sub LoadContractDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

            If _ContractID <> 0 Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_ContractSetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_ContractSetup.SelectedTab

                End If

                If TabItem.Tag = False Then

                    Contract = LoadSelectedContract()

                    If Contract IsNot Nothing Then

                        If TabItem Is TabItemContractSetup_GeneralTab OrElse _IsCopy Then

                            LoadGeneralTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_RatesTermsTab OrElse _IsCopy Then

                            LoadRateTermsTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_CommentsTab OrElse _IsCopy Then

                            LoadCommentsTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_ValueAddedTab OrElse _IsCopy Then

                            LoadValueAddedTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_InternalContactsTab OrElse _IsCopy Then

                            LoadContactsTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_ReportsTab Then

                            LoadReportsTab(Contract)

                        End If

                        If TabItem Is TabItemContractSetup_DocumentsTab Then

                            LoadDocuments(Contract)

                        End If

                    End If

                End If

                If TabItem Is TabItemContractSetup_ReportsDocumentsTab Then

                    If TabItemContractSetup_ReportsTab.Tag = False Then

                        If Contract Is Nothing Then

                            Contract = LoadSelectedContract()

                        End If

                        LoadReportsTab(Contract)

                    End If

                    LoadReportsDocumentsTab()

                End If

            End If

        End Sub
        Private Sub UpdateAddressFields(UpdatedInfo As Object, Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Client Then

                Client = UpdatedInfo

                Address.Address = Client.Address
                Address.Address2 = Client.Address2
                Address.City = Client.City
                Address.County = Client.County
                Address.State = Client.State
                Address.Zip = Client.Zip
                Address.Country = Client.Country

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Division Then

                Division = UpdatedInfo

                Address.Address = Division.BillingAddress
                Address.Address2 = Division.BillingAddress2
                Address.City = Division.BillingCity
                Address.County = Division.BillingCounty
                Address.State = Division.BillingState
                Address.Zip = Division.BillingZip
                Address.Country = Division.BillingCountry

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Product Then

                Product = UpdatedInfo

                Address.Address = Product.BillingAddress
                Address.Address2 = Product.BillingAddress2
                Address.City = Product.BillingCity
                Address.County = Product.BillingCounty
                Address.State = Product.BillingState
                Address.Zip = Product.BillingZip
                Address.Country = Product.BillingCountry

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If Contract IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy Then

                        CheckBoxGeneral_Inactive.Checked = False

                    Else

                        CheckBoxGeneral_Inactive.Checked = Contract.IsInactive

                    End If

                    SearchableComboBoxGeneral_Client.SelectedValue = Contract.ClientCode
                    SearchableComboBoxGeneral_Division.SelectedValue = Contract.DivisionCode
                    SearchableComboBoxGeneral_Product.SelectedValue = Contract.ProductCode

                    If Contract.ClientCode <> "" AndAlso Contract.DivisionCode <> "" AndAlso Contract.ProductCode <> "" Then

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Contract.ClientCode, Contract.DivisionCode, Contract.ProductCode)

                        UpdateAddressFields(Product, AddressControlGeneral_Address)

                    ElseIf Contract.ClientCode <> "" AndAlso Contract.DivisionCode <> "" Then

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)

                        UpdateAddressFields(Division, AddressControlGeneral_Address)

                    ElseIf Contract.ClientCode <> "" Then

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)

                        UpdateAddressFields(Client, AddressControlGeneral_Address)

                    End If

                    RadioButtonCOType_Contract.Checked = Contract.IsContract
                    RadioButtonCOType_Opportunity.Checked = Not Contract.IsContract

                    DateTimePickerGeneral_StartDate.ValueObject = Contract.StartDate
                    DateTimePickerGeneral_EndDate.ValueObject = Contract.EndDate

                End Using

                TabItemContractSetup_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadRateTermsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                CheckBoxContractType_Fee.Checked = Contract.IsFeeType
                CheckBoxContractType_ProjectHourly.Checked = Contract.IsProjectHourlyType

                NumericInputContractType_BlendedHourlyBillingRate.EditValue = Contract.BlendedHourlyRate

                NumericInputRateTerms_FeeRetainer.EditValue = Contract.FeeRetainer
                NumericInputRateTerms_FeeIncentiveBonus.EditValue = Contract.FeeIncentiveBonus
                NumericInputRateTerms_FeeRoyalty.EditValue = Contract.FeeRoyalty
                NumericInputRateTerms_FeeProjectHourly.EditValue = Contract.FeeProjectHourly
                NumericInputRateTerms_Hours.EditValue = Contract.Hours
                NumericInputRateTerms_MediaCommission.EditValue = Contract.MediaCommission
                NumericInputRateTerms_ProductionCommission.EditValue = Contract.ProductionCommission

                LoadContractFees()

                TabItemContractSetup_RatesTermsTab.Tag = True

            End If

        End Sub
        Private Sub LoadCommentsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                TextBoxComments_BillingRateComment.Text = Contract.BillingRateComment
                TextBoxComments_BillingTerms.Text = Contract.BillingTerms
                TextBoxComments_EstimatingTerms.Text = Contract.EstimatingTerms
                TextBoxComments_Comments.Text = Contract.ContractComments

                TabItemContractSetup_CommentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadValueAddedTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                LoadContractValueAdded()

                TabItemContractSetup_ValueAddedTab.Tag = True

            End If

        End Sub
        Private Sub LoadContactsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                LoadContractContacts()

                TabItemContractSetup_InternalContactsTab.Tag = True

            End If

        End Sub
        Private Sub SaveGeneralTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                Contract.Code = TextBoxGeneral_Code.Text
                Contract.Description = TextBoxGeneral_Description.Text
                Contract.ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue

                If SearchableComboBoxGeneral_Division.HasASelectedValue Then

                    Contract.DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue

                End If

                If SearchableComboBoxGeneral_Product.HasASelectedValue Then

                    Contract.ProductCode = SearchableComboBoxGeneral_Product.GetSelectedValue

                End If

                Contract.IsInactive = CheckBoxGeneral_Inactive.Checked

                Contract.IsContract = RadioButtonCOType_Contract.Checked
                Contract.StartDate = DateTimePickerGeneral_StartDate.GetValue
                Contract.EndDate = DateTimePickerGeneral_EndDate.GetValue

            End If

        End Sub
        Private Sub SaveRatesTermsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                Contract.IsFeeType = CheckBoxContractType_Fee.Checked
                Contract.IsProjectHourlyType = CheckBoxContractType_ProjectHourly.Checked
                Contract.BlendedHourlyRate = NumericInputContractType_BlendedHourlyBillingRate.GetValue

                Contract.FeeRetainer = NumericInputRateTerms_FeeRetainer.GetValue
                Contract.FeeIncentiveBonus = NumericInputRateTerms_FeeIncentiveBonus.GetValue
                Contract.FeeRoyalty = NumericInputRateTerms_FeeRoyalty.GetValue
                Contract.FeeProjectHourly = NumericInputRateTerms_FeeProjectHourly.GetValue
                Contract.Hours = NumericInputRateTerms_Hours.GetValue
                Contract.MediaCommission = NumericInputRateTerms_MediaCommission.GetValue
                Contract.ProductionCommission = NumericInputRateTerms_ProductionCommission.GetValue

            End If

        End Sub
        Private Sub SaveCommentsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            If Contract IsNot Nothing Then

                Contract.BillingRateComment = TextBoxComments_BillingRateComment.GetText
                Contract.BillingTerms = TextBoxComments_BillingTerms.GetText
                Contract.EstimatingTerms = TextBoxComments_EstimatingTerms.GetText
                Contract.ContractComments = TextBoxComments_Comments.GetText

            End If

        End Sub
        Private Sub SaveContractFees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            For Each ContractFeeItem In _ContractFeeItemList

                If ContractFeeItem.ContractFee.IsEntityBeingAdded() Then

                    ContractFeeItem.ContractFee.DbContext = DbContext
                    ContractFeeItem.ContractFee.ContractID = Contract.ID

                    AdvantageFramework.Database.Procedures.ContractFee.Insert(DbContext, ContractFeeItem.ContractFee)

                Else

                    AdvantageFramework.Database.Procedures.ContractFee.Update(DbContext, ContractFeeItem.ContractFee)

                End If

            Next

        End Sub
        Private Sub SaveContractValueAddeds(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            For Each ContractValueAddedClass In _ContractValueAddedList

                If ContractValueAddedClass.ContractValueAdded.IsEntityBeingAdded() Then

                    ContractValueAddedClass.ContractValueAdded.DbContext = DbContext
                    ContractValueAddedClass.ContractValueAdded.ContractID = Contract.ID

                    AdvantageFramework.Database.Procedures.ContractValueAdded.Insert(DbContext, ContractValueAddedClass.ContractValueAdded)

                Else

                    AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAddedClass.ContractValueAdded)

                End If

            Next

        End Sub
        Private Sub SaveContractReports(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            For Each ContractReportDetail In _ContractReportDetailList

                If ContractReportDetail.ContractReport.IsEntityBeingAdded() Then

                    ContractReportDetail.ContractReport.DbContext = DbContext
                    ContractReportDetail.ContractReport.ContractID = Contract.ID

                    AdvantageFramework.Database.Procedures.ContractReport.Insert(DbContext, ContractReportDetail.ContractReport)

                Else

                    AdvantageFramework.Database.Procedures.ContractReport.Update(DbContext, ContractReportDetail.ContractReport)

                End If

            Next

        End Sub
        Private Sub SaveContractContacts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            For Each ContractContact In _ContractContactList

                If ContractContact.IsEntityBeingAdded() Then

                    ContractContact.DbContext = DbContext
                    ContractContact.ContractID = Contract.ID

                    AdvantageFramework.Database.Procedures.ContractContact.Insert(DbContext, ContractContact)

                Else

                    AdvantageFramework.Database.Procedures.ContractContact.Update(DbContext, ContractContact)

                End If

            Next

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue

                    SearchableComboBoxGeneral_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                    Where Division.ClientCode = ClientCode
                                                                    Select Division

                End Using

                SearchableComboBoxGeneral_Product.DataSource = Nothing

            End Using

        End Sub
        Private Sub LoadProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If SearchableComboBoxGeneral_Client.HasASelectedValue AndAlso SearchableComboBoxGeneral_Division.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue
                        DivisionCode = SearchableComboBoxGeneral_Division.GetSelectedValue

                        SearchableComboBoxGeneral_Product.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, True)
                                                                        Where Product.ClientCode = ClientCode AndAlso
                                                                              Product.DivisionCode = DivisionCode
                                                                        Select Product).ToList

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadDocuments(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If Contract IsNot Nothing Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Contract) With {.ContractID = Contract.ID}

                DocumentManagerControlDocuments_ContractDocuments.Enabled = DocumentManagerControlDocuments_ContractDocuments.LoadControl(Database.Entities.DocumentLevel.Contract, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemContractSetup_DocumentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadReportsDocumentsTab()

            'objects
            Dim DocumentLevelSettings As Generic.List(Of AdvantageFramework.Database.Classes.DocumentLevelSetting) = Nothing

            If _ShowAllContractReportDocuments Then

                DocumentLevelSettings = (From CRD In DataGridViewReports_Reports.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ContractReportDetail).ToList
                                         Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ContractReport) With {.ContractReportID = CRD.ID}).ToList

            Else

                DocumentLevelSettings = (From CRD In DataGridViewReports_Reports.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ContractReportDetail).ToList
                                         Select New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ContractReport) With {.ContractReportID = CRD.ID}).ToList

            End If

            DocumentManagerControlReportsDocuments_ReportsDocuments.Enabled = DocumentManagerControlReportsDocuments_ReportsDocuments.LoadControl(Database.Entities.DocumentLevel.ContractReport, DocumentLevelSettings, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            TabItemContractSetup_ReportsDocumentsTab.Tag = True

        End Sub
        Public Sub FilterDocuments(ByVal ShowAll As Boolean)

            _ShowAllContractReportDocuments = ShowAll

            LoadReportsDocumentsTab()

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal ContractID As Integer, ByVal IsCopy As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            _ContractID = ContractID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _IsCopy = IsCopy

            If _DivisionCode Is Nothing Then

                SearchableComboBoxGeneral_Division.SetRequired(False)
                SearchableComboBoxGeneral_Division.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                SearchableComboBoxGeneral_Division.Visible = False
                LabelGeneral_Division.Visible = False

                SearchableComboBoxGeneral_Product.SetRequired(False)
                SearchableComboBoxGeneral_Product.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                SearchableComboBoxGeneral_Product.Visible = False
                LabelGeneral_Product.Visible = False

            Else

                SearchableComboBoxGeneral_Division.SetRequired(True)

            End If

            If _ProductCode Is Nothing Then

                SearchableComboBoxGeneral_Product.SetRequired(False)
                SearchableComboBoxGeneral_Product.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                SearchableComboBoxGeneral_Product.Visible = False
                LabelGeneral_Product.Visible = False

            Else

                SearchableComboBoxGeneral_Product.SetRequired(True)

            End If

            DateTimePickerGeneral_StartDate.SetRequired(True)
            DateTimePickerGeneral_EndDate.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ClientCode <> "" Then

                        SearchableComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                    Else

                        SearchableComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                    End If

                End Using

                If _ContractID <> 0 Then

                    TextBoxGeneral_Code.Enabled = IsCopy
                    TextBoxGeneral_Code.ReadOnly = Not IsCopy
                    SearchableComboBoxGeneral_Client.Enabled = IsCopy
                    SearchableComboBoxGeneral_Division.Enabled = IsCopy
                    SearchableComboBoxGeneral_Product.Enabled = IsCopy

                    Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, _ContractID)

                    If Contract IsNot Nothing Then

                        If IsCopy = False Then

                            TextBoxGeneral_Code.Text = Contract.Code
                            TextBoxGeneral_Description.Text = Contract.Description

                            CheckBoxGeneral_Inactive.Checked = Contract.IsInactive

                            TabItemContractSetup_DocumentsTab.Visible = _HasAccessToDocuments

                        Else

                            TextBoxGeneral_Code.Text = Nothing
                            TextBoxGeneral_Description.Text = Nothing

                            CheckBoxGeneral_Inactive.Checked = False

                            TabItemContractSetup_DocumentsTab.Visible = False

                            TabItemContractSetup_ReportsDocumentsTab.Visible = False

                        End If

                        LoadContractDetails(Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The contract you are trying to edit does not exist anymore.")

                    End If

                Else

                    If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                        SearchableComboBoxGeneral_Client.Enabled = False
                        SearchableComboBoxGeneral_Division.Enabled = False
                        SearchableComboBoxGeneral_Product.Enabled = False

                        SearchableComboBoxGeneral_Client.SelectedValue = _ClientCode
                        SearchableComboBoxGeneral_Division.SelectedValue = _DivisionCode
                        SearchableComboBoxGeneral_Product.SelectedValue = _ProductCode

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                        UpdateAddressFields(Product, AddressControlGeneral_Address)

                    ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                        SearchableComboBoxGeneral_Client.Enabled = False
                        SearchableComboBoxGeneral_Division.Enabled = False

                        SearchableComboBoxGeneral_Client.SelectedValue = _ClientCode
                        SearchableComboBoxGeneral_Division.SelectedValue = _DivisionCode

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                        UpdateAddressFields(Division, AddressControlGeneral_Address)

                    ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                        SearchableComboBoxGeneral_Client.Enabled = False
                        SearchableComboBoxGeneral_Client.SelectedValue = _ClientCode

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                        UpdateAddressFields(Client, AddressControlGeneral_Address)

                    End If

                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False

                    TabItemContractSetup_DocumentsTab.Visible = False

                    TabItemContractSetup_ReportsDocumentsTab.Visible = False

                    DateTimePickerGeneral_StartDate.ValueObject = Now.Date
                    DateTimePickerGeneral_EndDate.ValueObject = Now.Date

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                DataGridViewInternalContacts_Contacts.CurrentView.CloseEditorForUpdating()
                DataGridViewRateTerm_ContractFees.CurrentView.CloseEditorForUpdating()
                DataGridViewValueAdded_ValueAdded.CurrentView.CloseEditorForUpdating()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Contract = Me.FillObject(False)

                    If Contract IsNot Nothing Then

                        Contract.ModifiedByUserCode = _Session.UserCode
                        Contract.ModifiedDate = Now

                        Saved = AdvantageFramework.Database.Procedures.Contract.Update(DbContext, Contract)

                        If Saved Then

                            SaveContractFees(DbContext, Contract)
                            SaveContractValueAddeds(DbContext, Contract)
                            SaveContractContacts(DbContext, Contract)
                            SaveContractReports(DbContext, Contract)

                        End If

                    End If

                End Using

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Contract = Me.FillObject(False)

                    If Contract IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Contract.Delete(DbContext, Contract)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The contract is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ClientCode As String, ByRef DivisionCode As String, ByRef ProductCode As String) As Boolean

            'objects
            Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Contract = Me.FillObject(True)

                    If Contract IsNot Nothing Then

                        Contract.DbContext = DbContext
                        Contract.CreateDate = Now
                        Contract.CreatedByUserCode = _Session.UserCode

                        Inserted = AdvantageFramework.Database.Procedures.Contract.Insert(DbContext, Contract)

                        If Inserted Then

                            SaveContractFees(DbContext, Contract)
                            SaveContractValueAddeds(DbContext, Contract)
                            SaveContractContacts(DbContext, Contract)
                            SaveContractReports(DbContext, Contract)

                            ClientCode = Contract.ClientCode
                            DivisionCode = Contract.DivisionCode
                            ProductCode = Contract.ProductCode

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub CancelAddNewContractFee()

            DataGridViewRateTerm_ContractFees.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedContractFee()

            'objects
            Dim ContractFeeItem As AdvantageFramework.Database.Classes.ContractFeeItem = Nothing

            If DataGridViewRateTerm_ContractFees.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ContractFeeItem = DataGridViewRateTerm_ContractFees.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ContractFeeItem = Nothing
                    End Try

                    If ContractFeeItem IsNot Nothing Then

                        If _ContractID <> 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ContractFee.Delete(DbContext, ContractFeeItem.ContractFee) Then

                                    LoadContractFees()

                                End If

                            End Using

                        Else

                            DataGridViewRateTerm_ContractFees.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewValueAdded()

            DataGridViewValueAdded_ValueAdded.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedValueAdded()

            'objects
            Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing

            If DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ContractValueAdded = DataGridViewValueAdded_ValueAdded.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ContractValueAdded = Nothing
                    End Try

                    If ContractValueAdded IsNot Nothing Then

                        If _ContractID <> 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ContractValueAdded.Delete(DbContext, ContractValueAdded.ContractValueAdded) Then

                                    LoadContractValueAdded()

                                End If

                            End Using

                        Else

                            DataGridViewValueAdded_ValueAdded.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewReport()

            DataGridViewReports_Reports.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedReport()

            'objects
            Dim ContractReportDetail As AdvantageFramework.Database.Classes.ContractReportDetail = Nothing

            If DataGridViewReports_Reports.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ContractReportDetail = DataGridViewReports_Reports.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ContractReportDetail = Nothing
                    End Try

                    If ContractReportDetail IsNot Nothing Then

                        If _ContractID <> 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ContractReport.Delete(DbContext, ContractReportDetail.ContractReport) Then

                                    LoadContractReports()

                                    DocumentManagerControlReportsDocuments_ReportsDocuments.ClearControl()

                                    LoadReportsDocumentsTab()

                                End If

                            End Using

                        Else

                            DataGridViewReports_Reports.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewContractContact()

            DataGridViewInternalContacts_Contacts.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedContractContact()

            'objects
            Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing

            If DataGridViewInternalContacts_Contacts.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ContractContact = DataGridViewInternalContacts_Contacts.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ContractContact = Nothing
                    End Try

                    If ContractContact IsNot Nothing Then

                        If _ContractID <> 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ContractContact.Delete(DbContext, ContractContact) Then

                                    LoadContractContacts()

                                End If

                            End Using

                        Else

                            DataGridViewInternalContacts_Contacts.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub ClearControl()

            ' general tab
            TextBoxGeneral_Code.Text = ""
            TextBoxGeneral_Description.Text = ""
            SearchableComboBoxGeneral_Client.SelectedValue = Nothing
            SearchableComboBoxGeneral_Division.SelectedValue = Nothing
            SearchableComboBoxGeneral_Product.SelectedValue = Nothing
            CheckBoxGeneral_Inactive.Checked = False
            CheckBoxGeneral_NewBusiness.Checked = False
            RadioButtonCOType_Contract.Checked = False
            RadioButtonCOType_Opportunity.Checked = False
            DateTimePickerGeneral_StartDate.ValueObject = Nothing
            DateTimePickerGeneral_EndDate.ValueObject = Nothing
            AddressControlGeneral_Address.ClearControl()

            ' rates / terms tab
            CheckBoxContractType_Fee.Checked = False
            CheckBoxContractType_ProjectHourly.Checked = False
            NumericInputRateTerms_FeeRetainer.EditValue = Nothing
            NumericInputRateTerms_FeeIncentiveBonus.EditValue = Nothing
            NumericInputRateTerms_FeeRoyalty.EditValue = Nothing
            NumericInputRateTerms_FeeProjectHourly.EditValue = Nothing
            NumericInputRateTerms_MediaCommission.EditValue = Nothing
            NumericInputRateTerms_ProductionCommission.EditValue = Nothing
            NumericInputRateTerms_TotalContractValue.EditValue = Nothing

            ' comments tab
            TextBoxComments_BillingRateComment.Text = Nothing
            TextBoxComments_BillingTerms.Text = Nothing
            TextBoxComments_EstimatingTerms.Text = Nothing
            TextBoxComments_Comments.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_ContractDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_ContractDocuments.DeleteSelectedDocument()

        End Sub
		Public Sub UploadDocument()

			DocumentManagerControlDocuments_ContractDocuments.UploadNewDocument()

		End Sub
		Public Sub SendASPUploadEmail()

			DocumentManagerControlDocuments_ContractDocuments.SendASPUploadEmail()

		End Sub
		Public Sub DownloadValueAddedDocument()

            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing
            Dim ContractValueAddedEntity As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

            Try

                ContractValueAdded = DataGridViewValueAdded_ValueAdded.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                ContractValueAdded = Nothing
            End Try

            If ContractValueAdded IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, ContractValueAdded.ContractValueAdded.ID)

                    If ContractValueAddedEntity IsNot Nothing Then

                        If ContractValueAddedEntity.Document IsNot Nothing Then

                            Documents = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                            Documents.Add(ContractValueAddedEntity.Document)

                            DocumentManagerControlDocuments_ContractDocuments.DownloadSelectedDocument(Documents)

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub DeleteValueAddedDocument()

            Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing
            Dim ContractValueAddedEntity As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

            If DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow Then

                ContractValueAdded = DataGridViewValueAdded_ValueAdded.GetFirstSelectedRowDataBoundItem

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, ContractValueAdded.ContractValueAdded.ID)

                    If ContractValueAddedEntity IsNot Nothing AndAlso ContractValueAddedEntity.Document IsNot Nothing Then

                        ContractValueAddedEntity.DocumentID = Nothing

                        If AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAddedEntity) Then

                            ContractValueAddedEntity.Document.DbContext = DbContext

                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, ContractValueAddedEntity.Document)

                            LoadContractValueAdded()

                            DataGridViewValueAdded_ValueAdded.SelectRow(ContractValueAddedEntity.ID)

                        End If

                    End If

                End Using

            End If

        End Sub
		Public Sub UploadValueAddedDocument()

			Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
			Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing

			If DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow Then

				ContractValueAdded = DataGridViewValueAdded_ValueAdded.GetFirstSelectedRowDataBoundItem

				DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ContractValueAdded) With {.ValueAddedID = ContractValueAdded.ContractValueAdded.ID}

				If AdvantageFramework.Desktop.Presentation.DocumentUploadDialog.ShowFormDialog(Database.Entities.DocumentLevel.ContractValueAdded, DocumentLevelSetting) = Windows.Forms.DialogResult.OK Then

					LoadContractValueAdded()

					DataGridViewValueAdded_ValueAdded.SelectRow(ContractValueAdded.ContractValueAdded.ID)

				End If

			End If

		End Sub
		Public Sub SendValueAddedDocumentASPUploadEmail()

			Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
			Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing

			If DataGridViewValueAdded_ValueAdded.HasOnlyOneSelectedRow Then

				ContractValueAdded = DataGridViewValueAdded_ValueAdded.GetFirstSelectedRowDataBoundItem

				DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ContractValueAdded) With {.ValueAddedID = ContractValueAdded.ContractValueAdded.ID}

				AdvantageFramework.WinForm.Presentation.SendASPUploadEmail(_Session, Database.Entities.DocumentLevel.ContractValueAdded, Database.Entities.DocumentSubLevel.Default, DocumentLevelSetting)

			End If

		End Sub
		Public Sub DownloadReportDocument()

            DocumentManagerControlReportsDocuments_ReportsDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub DeleteReportDocument()

            DocumentManagerControlReportsDocuments_ReportsDocuments.DeleteSelectedDocument()

            LoadReportsTab()

        End Sub
		Public Sub UploadReportDocument(Optional ByVal DefaultDescription As String = "")

			DocumentManagerControlReportsDocuments_ReportsDocuments.UploadNewDocument(DefaultDescription)

			LoadReportsTab()

		End Sub
		Public Sub SendReportDocumentASPUploadEmail(Optional ByVal DefaultDescription As String = "")

			DocumentManagerControlReportsDocuments_ReportsDocuments.SendASPUploadEmail(DefaultDescription)

		End Sub
		Public Sub LoadContractReportDocuments()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If DataGridViewReports_Reports.HasASelectedRow AndAlso _HasAccessToReportDocuments Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ContractReport, Database.Entities.DocumentSubLevel.Default) _
                                            With {.ContractReportID = DataGridViewReports_Reports.GetFirstSelectedRowBookmarkValue}

                AdvantageFramework.Desktop.Presentation.DocumentManagerEditForm.ShowFormDialog(Database.Entities.DocumentLevel.ContractReport, DocumentLevelSetting, Presentation.Controls.DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ContractControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewReports_Reports.MultiSelect = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub SearchableComboBoxGeneral_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Client.EditValueChanged

            Dim ClientCode As String = Nothing

            If SearchableComboBoxGeneral_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxGeneral_Client.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                        CheckBoxGeneral_NewBusiness.Checked = True
                        RadioButtonCOType_Opportunity.Checked = True
                        RadioButtonCOType_Contract.Visible = False

                    Else

                        CheckBoxGeneral_NewBusiness.Checked = False
                        RadioButtonCOType_Contract.Checked = True
                        RadioButtonCOType_Contract.Visible = True

                    End If

                End Using

                SearchableComboBoxGeneral_Division.DataSource = Nothing

                LoadDivisions()

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_Division.EditValueChanged

            If SearchableComboBoxGeneral_Division.HasASelectedValue Then

                LoadProducts()

            End If

        End Sub
        Private Sub TabControlControl_ContractSetup_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_ContractSetup.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False

            End If

        End Sub
        Private Sub TabControlControl_ContractSetup_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_ContractSetup.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True

            End If

            LoadContractDetails(e.NewTab)

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub NumericInput_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputRateTerms_FeeRetainer.EditValueChanged, NumericInputRateTerms_FeeIncentiveBonus.EditValueChanged, NumericInputRateTerms_FeeRoyalty.EditValueChanged, NumericInputRateTerms_FeeProjectHourly.EditValueChanged, NumericInputRateTerms_MediaCommission.EditValueChanged, NumericInputRateTerms_ProductionCommission.EditValueChanged

            If DirectCast(sender, NumericInput).Name = "NumericInputRateTerms_FeeProjectHourly" AndAlso
                    NumericInputContractType_BlendedHourlyBillingRate.EditValue IsNot Nothing AndAlso
                    NumericInputContractType_BlendedHourlyBillingRate.EditValue <> 0 Then

                NumericInputRateTerms_Hours.EditValue = AdvantageFramework.BillingSystem.CalculateQuantity(NumericInputContractType_BlendedHourlyBillingRate.EditValue, NumericInputRateTerms_FeeProjectHourly.EditValue, 2)

            End If

            NumericInputRateTerms_TotalContractValue.EditValue = NumericInputRateTerms_FeeRetainer.EditValue +
                                                                 NumericInputRateTerms_FeeIncentiveBonus.EditValue +
                                                                 NumericInputRateTerms_FeeRoyalty.EditValue +
                                                                 NumericInputRateTerms_FeeProjectHourly.EditValue +
                                                                 NumericInputRateTerms_MediaCommission.EditValue +
                                                                 NumericInputRateTerms_ProductionCommission.EditValue

        End Sub
        Private Sub NumericInputRateTerms_Hours_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputRateTerms_Hours.EditValueChanged

            If NumericInputContractType_BlendedHourlyBillingRate.EditValue IsNot Nothing AndAlso NumericInputContractType_BlendedHourlyBillingRate.EditValue <> 0 Then

                NumericInputRateTerms_FeeProjectHourly.EditValue = AdvantageFramework.BillingSystem.CalculateAmount(NumericInputRateTerms_Hours.EditValue, NumericInputContractType_BlendedHourlyBillingRate.EditValue, 2)

            End If

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_AddNewRowEvent(RowObject As Object) Handles DataGridViewRateTerm_ContractFees.AddNewRowEvent

            'objects
            Dim ContractFeeItem As AdvantageFramework.Database.Classes.ContractFeeItem = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ContractFeeItem Then

                Me.ShowWaitForm("Processing...")

                ContractFeeItem = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractFeeItem.ContractFee.IsEntityBeingAdded() Then

                        If _ContractID <> 0 Then

                            ContractFeeItem.ContractFee.DbContext = DbContext

                            ContractFeeItem.ContractFee.ContractID = _ContractID

                            If AdvantageFramework.Database.Procedures.ContractFee.Insert(DbContext, ContractFeeItem.ContractFee) Then

                                DataGridViewRateTerm_ContractFees.SelectRow(ContractFeeItem.ContractFee.ID)

                            End If

                        Else

                            DataGridViewRateTerm_ContractFees.SetUserEntryChanged()

                        End If

                        LoadContractFees()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRateTerm_ContractFees.CellValueChangedEvent

            Dim ServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing
            Dim ContractFeeItem As AdvantageFramework.Database.Classes.ContractFeeItem = Nothing

            If TypeOf DataGridViewRateTerm_ContractFees.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.ContractFeeItem Then

                ContractFeeItem = DirectCast(DataGridViewRateTerm_ContractFees.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.ContractFeeItem)

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString Then

                    If e.Value IsNot Nothing And e.Value <> 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ServiceFeeType = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeID(DbContext, e.Value)

                        End Using

                        If ServiceFeeType IsNot Nothing Then

                            DataGridViewRateTerm_ContractFees.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeDescription.ToString, ServiceFeeType.Description)

                        End If

                    Else

                        DataGridViewRateTerm_ContractFees.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeDescription.ToString, Nothing)

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Hours.ToString Then

                    If NumericInputContractType_BlendedHourlyBillingRate.EditValue IsNot Nothing Then

                        ContractFeeItem.Amount = AdvantageFramework.BillingSystem.CalculateAmount(e.Value, NumericInputContractType_BlendedHourlyBillingRate.EditValue, 2)

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString Then

                    If NumericInputContractType_BlendedHourlyBillingRate.EditValue IsNot Nothing Then

                        ContractFeeItem.Hours = AdvantageFramework.BillingSystem.CalculateQuantity(NumericInputContractType_BlendedHourlyBillingRate.EditValue, e.Value, 2)

                    End If

                End If

                DataGridViewRateTerm_ContractFees.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_Enter(sender As Object, e As EventArgs) Handles DataGridViewRateTerm_ContractFees.Enter

            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            DataGridView = CType(sender, AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If DataGridView.GridControl.MainView.DataRowCount = 0 Then

                If DataGridView.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

                    DataGridView.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridView.CurrentView.FocusedColumn = DataGridViewRateTerm_ContractFees.CurrentView.VisibleColumns(0)

                End If

            End If

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRateTerm_ContractFees.InitNewRowEvent

            RaiseEvent ContractFeesInitNewRowEvent()

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRateTerm_ContractFees.NewItemRowCellValueChangedEvent

            Dim ContractFeeItemList As Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem) = Nothing

            If e.RowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString Then

                ContractFeeItemList = DataGridViewRateTerm_ContractFees.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.ContractFeeItem)().ToList

                If ContractFeeItemList.Where(Function(Entity) Entity.ServiceFeeTypeID = e.Value).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Fee type has already been added.  Please choose another.")

                    DataGridViewRateTerm_ContractFees.CancelNewItemRow()

                End If

            End If

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRateTerm_ContractFees.SelectionChangedEvent

            RaiseEvent ContractFeesSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewRateTerm_ContractFees_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewRateTerm_ContractFees.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If TypeOf DataGridViewRateTerm_ContractFees.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DataGridViewRateTerm_ContractFees.CurrentView.ActiveEditor

                    If DataGridViewRateTerm_ContractFees.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.ContractFeeItem.Properties.ServiceFeeTypeID.ToString Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewReports_Reports_AddNewRowEvent(RowObject As Object) Handles DataGridViewReports_Reports.AddNewRowEvent

            'objects
            Dim ContractReportDetail As AdvantageFramework.Database.Classes.ContractReportDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ContractReportDetail Then

                Me.ShowWaitForm("Processing...")

                ContractReportDetail = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractReportDetail.ContractReport.IsEntityBeingAdded() Then

                        If _ContractID <> 0 Then

                            ContractReportDetail.ContractReport.DbContext = DbContext

                            ContractReportDetail.ContractReport.ContractID = _ContractID

                            If AdvantageFramework.Database.Procedures.ContractReport.Insert(DbContext, ContractReportDetail.ContractReport) Then

                                LoadContractReports()

                            End If

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewReports_Reports_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewReports_Reports.CellValueChangedEvent

            Dim ContractReportDetail As AdvantageFramework.Database.Classes.ContractReportDetail = Nothing
            Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing

            If TypeOf DataGridViewReports_Reports.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.ContractReportDetail Then

                ContractReportDetail = DataGridViewReports_Reports.CurrentView.GetRow(e.RowHandle)

                If e.Column.FieldName = AdvantageFramework.Database.Classes.ContractReportDetail.Properties.LastCompletedDate.ToString AndAlso IsDate(e.Value) Then

                    If ContractReportDetail.CycleCode IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Cycle = AdvantageFramework.Database.Procedures.Cycle.LoadByCode(DbContext, ContractReportDetail.CycleCode)

                            If Cycle IsNot Nothing Then

                                Select Case Cycle.Type

                                    Case "A"

                                        ContractReportDetail.NextStartDate = DateAdd(DateInterval.Year, 1, e.Value)

                                    Case "D"

                                        ContractReportDetail.NextStartDate = DateAdd(DateInterval.Day, 1, e.Value)

                                    Case "M"

                                        ContractReportDetail.NextStartDate = DateAdd(DateInterval.Month, 1, e.Value)

                                    Case "Q"

                                        ContractReportDetail.NextStartDate = DateAdd(DateInterval.Quarter, 1, e.Value)

                                    Case "W"

                                        ContractReportDetail.NextStartDate = DateAdd(DateInterval.Day, 7, e.Value)

                                End Select

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewReports_Reports_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewReports_Reports.InitNewRowEvent

            RaiseEvent ContractReportInitNewRowEvent()

        End Sub
        Private Sub DataGridViewReports_Reports_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewReports_Reports.SelectionChangedEvent

            RaiseEvent ContractReportSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewValueAdded_ValueAdded_AddNewRowEvent(RowObject As Object) Handles DataGridViewValueAdded_ValueAdded.AddNewRowEvent

            'objects
            Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.ContractValueAdded Then

                Me.ShowWaitForm("Processing...")

                ContractValueAdded = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractValueAdded.ContractValueAdded.IsEntityBeingAdded() Then

                        If _ContractID <> 0 Then

                            ContractValueAdded.ContractValueAdded.DbContext = DbContext

                            ContractValueAdded.ContractValueAdded.ContractID = _ContractID

                            If AdvantageFramework.Database.Procedures.ContractValueAdded.Insert(DbContext, ContractValueAdded.ContractValueAdded) Then

                                LoadContractValueAdded()

                            End If

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewValueAdded_ValueAdded_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewValueAdded_ValueAdded.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Description.ToString Then

                If e.Value.ToString.StartsWith(" ") Then

                    DataGridViewValueAdded_ValueAdded.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.ContractValueAdded.Properties.Description.ToString, e.Value.ToString.Trim)

                End If

            End If

        End Sub
        Private Sub DataGridViewValueAdded_ValueAdded_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewValueAdded_ValueAdded.InitNewRowEvent

            RaiseEvent ContractValueAddedInitNewRowEvent()

        End Sub
        Private Sub DataGridViewValueAdded_ValueAdded_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewValueAdded_ValueAdded.SelectionChangedEvent

            RaiseEvent ContractValueAddedSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_AddNewRowEvent(RowObject As Object) Handles DataGridViewInternalContacts_Contacts.AddNewRowEvent

            'objects
            Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ContractContact Then

                Me.ShowWaitForm("Processing...")

                ContractContact = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractContact.IsEntityBeingAdded() Then

                        If _ContractID <> 0 Then

                            ContractContact.DbContext = DbContext

                            ContractContact.ContractID = _ContractID

                            If AdvantageFramework.Database.Procedures.ContractContact.Insert(DbContext, ContractContact) Then

                                DataGridViewInternalContacts_Contacts.SelectRow(ContractContact.ID)

                            End If

                        Else

                            DataGridViewInternalContacts_Contacts.SetUserEntryChanged()

                        End If

                        LoadContractContacts()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewInternalContacts_Contacts.InitNewRowEvent

            RaiseEvent ContractContactInitNewRowEvent()

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewInternalContacts_Contacts.NewItemRowCellValueChangedEvent

            Dim ContractContactList As Generic.List(Of AdvantageFramework.Database.Entities.ContractContact) = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.ContractContact.Properties.EmployeeCode.ToString Then

                ContractContactList = DataGridViewInternalContacts_Contacts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ContractContact)().ToList

                If ContractContactList.Where(Function(Entity) Entity.EmployeeCode = e.Value).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Employee has already been added.  Please choose another.")

                    DataGridViewInternalContacts_Contacts.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.ContractContact.Properties.EmployeeCode.ToString, "")

                End If

            End If

        End Sub
        Private Sub DataGridViewInternalContacts_Contacts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewInternalContacts_Contacts.SelectionChangedEvent

            RaiseEvent ContractContactSelectionChangedEvent()

        End Sub
        Private Sub CheckBoxGeneral_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneral_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxGeneral_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxGeneral_Inactive.Checked = Not CheckBoxGeneral_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub ButtonRateTerm_UpdateFeeRetainer_Click(sender As Object, e As EventArgs) Handles ButtonRateTerm_UpdateFeeRetainer.Click

            NumericInputRateTerms_FeeRetainer.EditValue = DataGridViewRateTerm_ContractFees.Columns(AdvantageFramework.Database.Classes.ContractFeeItem.Properties.Amount.ToString).SummaryText

        End Sub
        Private Sub DocumentManagerControlDocuments_ContractDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_ContractDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub DateTimePickerGeneral_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_StartDate.ValueChanged

            If DateTimePickerGeneral_StartDate.Value > DateTimePickerGeneral_EndDate.Value Then

                DateTimePickerGeneral_EndDate.Value = DateTimePickerGeneral_StartDate.Value

            End If

        End Sub
        Private Sub DateTimePickerGeneral_EndDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerGeneral_EndDate.ValueChanged

            If DateTimePickerGeneral_EndDate.Value < DateTimePickerGeneral_StartDate.Value Then

                DateTimePickerGeneral_StartDate.Value = DateTimePickerGeneral_EndDate.Value

            End If

        End Sub
        Private Sub TextBoxComments_BillingRateComment_GotFocus(sender As Object, e As EventArgs) Handles TextBoxComments_BillingRateComment.GotFocus

            RaiseEvent BillingRateCommentGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComments_BillingRateComment_LostFocus(sender As Object, e As EventArgs) Handles TextBoxComments_BillingRateComment.LostFocus

            RaiseEvent BillingRateCommentLostFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComments_BillingTerms_GotFocus(sender As Object, e As EventArgs) Handles TextBoxComments_BillingTerms.GotFocus

            RaiseEvent BillingTermsGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComments_BillingTerms_LostFocus(sender As Object, e As EventArgs) Handles TextBoxComments_BillingTerms.LostFocus

            RaiseEvent BillingTermsLostFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComments_EstimatingTerms_GotFocus(sender As Object, e As EventArgs) Handles TextBoxComments_EstimatingTerms.GotFocus

            RaiseEvent EstimatingTermsGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxComments_EstimatingTerms_LostFocus(sender As Object, e As EventArgs) Handles TextBoxComments_EstimatingTerms.LostFocus

            RaiseEvent EstimatingTermsLostFocusEvent(sender, e)

        End Sub
        Private Sub DocumentManagerControlReportsDocuments_ReportsDocuments_SelectedDocumentChanged() Handles DocumentManagerControlReportsDocuments_ReportsDocuments.SelectedDocumentChanged

            RaiseEvent SelectedReportDocumentChanged()

        End Sub

        Private Sub TextBoxComments_Comments_GotFocus(sender As Object, e As EventArgs) Handles TextBoxComments_Comments.GotFocus

            RaiseEvent CommentsGotFocusEvent(sender, e)

        End Sub

        Private Sub TextBoxComments_Comments_LostFocus(sender As Object, e As EventArgs) Handles TextBoxComments_Comments.LostFocus

            RaiseEvent CommentsLostFocusEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
