Namespace WinForm.Presentation.Controls

    Public Class ClientControl

        Public Event SelectedTabChanged()
        Public Event SelectedDivisionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SelectedProductChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event AddClientWebsiteInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event ClientWebsiteSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ClientDocumentsSelectionChangedEvent()
        Public Event ARCommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ARCommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ClientSortKeysInitNewRowEvent()
        Public Event ClientSortKeysSelectionChangedEvent()
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event SelectedDocumentChanged()
        Public Event ClearChangedEvent()

#Region " Constants "

        Private Const LATE_FEE_MESSAGE As String = "Cannot set late payment fee at client level, at least one product has late payment fee enabled."

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey) = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _ClientWebsiteList As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing
        Private _DivisionGridLoading As Boolean = False
        Private _SortNameMaxLength As Long = Nothing
        Private _IsCRMUser As Boolean = False
        Private _HasAccessToDocuments As Boolean = False
        Private _CanUserPrint As Boolean = False
        Private _CanUserUpdate As Boolean = False
        Private _CanUserAdd As Boolean = False
        Private _DoesUserHaveAccessToClientContactMaintenance As Boolean = False
        Private _AvaTaxEnabled As Boolean = False
        Private _FromMaintenance As Boolean = False
        Private _IsAgencyASP As Boolean = False
        Private _IsQuickbooksEnabled As Boolean = False
        Private _IsLoading As Boolean = False
        Private _QuickBooksCustomers As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property DoesUserHaveAccessToClientContactMaintenance() As Boolean
            Get
                DoesUserHaveAccessToClientContactMaintenance = _DoesUserHaveAccessToClientContactMaintenance
            End Get
        End Property
        Public ReadOnly Property CanUserPrint As Boolean
            Get
                CanUserPrint = _CanUserPrint
            End Get
        End Property
        Public ReadOnly Property CanUserUpdate As Boolean
            Get
                CanUserUpdate = _CanUserUpdate
            End Get
        End Property
        Public ReadOnly Property CanUserAdd As Boolean
            Get
                CanUserAdd = _CanUserAdd
            End Get
        End Property
        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property HasASelectedDivision() As Boolean
            Get
                HasASelectedDivision = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property HasASelectedProduct() As Boolean
            Get
                HasASelectedProduct = DataGridViewRightSection_Products.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DuplicateForDivision() As Boolean
            Get
                DuplicateForDivision = CheckBoxNewClientOptions_DuplicateForDivision.Checked
            End Get
        End Property
        Public ReadOnly Property DuplicateForProduct() As Boolean
            Get
                DuplicateForProduct = CheckBoxNewClientOptions_DuplicateForProduct.Checked
            End Get
        End Property
        Public ReadOnly Property ClientWebsiteList() As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)
            Get
                ClientWebsiteList = _ClientWebsiteList
            End Get
        End Property
        Public ReadOnly Property DataGridViewWebsitesHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewWebsitesHasOnlyOneSelectedRow = DataGridViewWebsites_Websites.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DataGridViewWebsitesIsNewItemRow() As Boolean
            Get
                DataGridViewWebsitesIsNewItemRow = DataGridViewWebsites_Websites.CurrentView.IsNewItemRow(DataGridViewWebsites_Websites.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DocumentManager() As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_ClientDocuments
            End Get
        End Property
        Public ReadOnly Property DataGridViewClientSortKeys() As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DataGridViewClientSortKeys = DataGridViewTopRightColumn_ClientSortKeys
            End Get
        End Property
        Public ReadOnly Property IsCRMUser() As Boolean
            Get
                IsCRMUser = _IsCRMUser
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property IsQuickbooksEnabled As Boolean
            Get
                IsQuickbooksEnabled = _IsQuickbooksEnabled
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

            Dim UserDefinedLabelList As Generic.List(Of AdvantageFramework.Database.Entities.UserDefinedLabel) = Nothing
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing
            Dim InvoiceFormatsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim EstimateFormatsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim RadioButtonControl As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client)

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
                        _CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
                        _CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)

                        _DoesUserHaveAccessToClientContactMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)

                        'TabControlPanelBillingTab_Billing.Enabled = Me.CanUserUpdate
                        'TabControlPanelClientDetails_MediaInvoiceFormat.Enabled = Me.CanUserUpdate
                        'TabControlPanelContactTab_Contacts.Enabled = Me.CanUserUpdate
                        'TabControlPanelContractTab_Contracts.Enabled = Me.CanUserUpdate
                        'TabControlPanelDivisionTab_Division.Enabled = Me.CanUserUpdate
                        'TabControlPanelDocumentsTab_Documents.Enabled = Me.CanUserUpdate
                        'TabControlPanelGeneralTab_General.Enabled = Me.CanUserUpdate
                        'TabControlPanelMediaTab_Media.Enabled = Me.CanUserUpdate
                        'TabControlPanelProductionTab_Production.Enabled = Me.CanUserUpdate
                        'TabControlPanelRequiredFieldsTab_RequiredFields.Enabled = Me.CanUserUpdate
                        'TabControlPanelWebsiteTab_Websites.Enabled = Me.CanUserUpdate

                        DataGridViewRightSection_Products.DataSourceViewOption = DataGridView.DataSourceViewOptions.Product_ExcludeClientDivision
                        DataGridViewLeftSection_Divisions.DataSourceViewOption = DataGridView.DataSourceViewOptions.Division_ExcludeClient

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Client)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                                DataGridViewLeftSection_Divisions.MultiSelect = False
                                DataGridViewRightSection_Products.MultiSelect = False
                                DataGridViewTopRightColumn_ClientSortKeys.MultiSelect = False

                                CheckBoxRightColumn_Inactive.ByPassUserEntryChanged = Not Form.Modal

                                If Me.CanUserUpdate Then

                                    DataGridViewTopRightColumn_ClientSortKeys.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewWebsites_Websites.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                                    DataGridViewWebsites_Websites.OptionsBehavior.Editable = True

                                Else

                                    DataGridViewTopRightColumn_ClientSortKeys.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewWebsites_Websites.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                                    DataGridViewWebsites_Websites.OptionsBehavior.Editable = False

                                End If
                                Try

                                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Client.Properties.SortName))

                                Catch ex As Exception
                                    _SortNameMaxLength = Nothing
                                End Try

                                ' settings tab
                                TextBoxGeneral_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Code)
                                TextBoxGeneral_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Name)
                                TextBoxARComment_ARComment.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.ARComment)
                                NumericInputOptions_CreditLimit.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.CreditLimit)
                                DateTimePickerOptions_ContractExpirationDate.SetPropertySettings(AdvantageFramework.Database.Entities.Client.Properties.ContractExpirationDate)

                                AddressControlLeftColumn_Address.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Address)
                                AddressControlLeftColumn_Address.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Address2)
                                AddressControlLeftColumn_Address.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.City)
                                AddressControlLeftColumn_Address.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.County)
                                AddressControlLeftColumn_Address.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.State)
                                AddressControlLeftColumn_Address.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Country)
                                AddressControlLeftColumn_Address.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.Zip)

                                AddressControlLeftColumn_BillingAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingAddress)
                                AddressControlLeftColumn_BillingAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingAddress2)
                                AddressControlLeftColumn_BillingAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingCity)
                                AddressControlLeftColumn_BillingAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingCounty)
                                AddressControlLeftColumn_BillingAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingState)
                                AddressControlLeftColumn_BillingAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingCountry)
                                AddressControlLeftColumn_BillingAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.BillingZip)

                                AddressControlRightColumn_StatementAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementAddress)
                                AddressControlRightColumn_StatementAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementAddress2)
                                AddressControlRightColumn_StatementAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementCity)
                                AddressControlRightColumn_StatementAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementCounty)
                                AddressControlRightColumn_StatementAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementState)
                                AddressControlRightColumn_StatementAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementCountry)
                                AddressControlRightColumn_StatementAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.StatementZip)

                                NumericInputLatePaymentFee_Percentage.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.LateFeePercent)

                                ' Production Settings
                                TextBoxProduction_AttentionLine.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.ProductionAttentionLine)
                                TextBoxProduction_InvoiceFooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.ProductionFooterComments)

                                RadioButtonControlAssignProductionInvoicesBy_Campaign.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Campaign
                                RadioButtonControlAssignProductionInvoicesBy_Client.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Client
                                RadioButtonControlAssignProductionInvoicesBy_Division.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Division
                                RadioButtonControlAssignProductionInvoicesBy_Job.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Job
                                RadioButtonControlAssignProductionInvoicesBy_JobComponent.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.JobComponent
                                RadioButtonControlAssignProductionInvoicesBy_Product.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Product
                                RadioButtonControlAssignProductionInvoicesBy_ProductSalesClass.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.ProductSalesClass
                                RadioButtonControlAssignProductionInvoicesBy_ProductClientPO.Tag = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.PurchaseOrder

                                NumericInputProduction_DaysToPay.Properties.MaxLength = 3
                                NumericInputProduction_DaysToPay.Properties.MinValue = 0
                                NumericInputProduction_DaysToPay.Properties.MaxValue = 999

                                ' Media Settings
                                TextBoxMedia_AttentionLine.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.MediaAttentionLine)
                                TextBoxMedia_InvoiceFooterComments.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.MediaFooterComments)

                                RadioButtonControlAssignMediaInvoicesBy_Campaign.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.Campaign
                                RadioButtonControlAssignMediaInvoicesBy_ClientPO.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.ClientPurchaseOrder
                                RadioButtonControlAssignMediaInvoicesBy_Market.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.Market
                                RadioButtonControlAssignMediaInvoicesBy_SalesClass.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.SalesClass
                                RadioButtonControlAssignMediaInvoicesBy_OrderNumber.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.OrderNumber
                                RadioButtonControlAssignMediaInvoicesBy_OrderType.Tag = AdvantageFramework.Database.Entities.AssignMediaInvoicesBy.OrderType

                                NumericInputMedia_DaysToPay.Properties.MaxLength = 3
                                NumericInputMedia_DaysToPay.Properties.MinValue = 0
                                NumericInputMedia_DaysToPay.Properties.MaxValue = 999

                                NumericInputDoubleClick_ProfileID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.DoubleClickProfileID)
                                NumericInputDoubleClick_ReportID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.DoubleClickReportID)
                                CheckBoxMediaIntegrationSettings_EnableDoubleClick.ByPassUserEntryChanged = True

                                ' Billing Settings
                                RadioButtonControlAssignComboInvoicesBy_None.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.None
                                RadioButtonControlAssignComboInvoicesBy_Client.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.Client
                                RadioButtonControlAssignComboInvoicesBy_ClientDivision.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.ClientDivision
                                RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.ClientDivisionProduct
                                RadioButtonControlAssignComboInvoicesBy_ClientCampaign.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.ClientCampaign
                                RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.Tag = AdvantageFramework.Database.Entities.AssignComboInvoicesBy.ClientDivisionProductCampaign
                                TextBoxBilling_VATNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Client.Properties.VATNumber)

                                DbContext.Database.Connection.Open()

                                ' Required Fields Custom Labels
                                UserDefinedLabelList = AdvantageFramework.Database.Procedures.UserDefinedLabel.Load(DbContext).Where(Function(UDL) UDL.Label <> "" And UDL.Label IsNot Nothing).ToList

                                CheckBoxRightColumn_JobComponentCustom1.Tag = "JOB_CMP_UDV1"
                                CheckBoxRightColumn_JobComponentCustom2.Tag = "JOB_CMP_UDV2"
                                CheckBoxRightColumn_JobComponentCustom3.Tag = "JOB_CMP_UDV3"
                                CheckBoxRightColumn_JobComponentCustom4.Tag = "JOB_CMP_UDV4"
                                CheckBoxRightColumn_JobComponentCustom5.Tag = "JOB_CMP_UDV5"
                                CheckBoxRightColumn_JobLogCustom1.Tag = "JOB_LOG_UDV1"
                                CheckBoxRightColumn_JobLogCustom2.Tag = "JOB_LOG_UDV2"
                                CheckBoxRightColumn_JobLogCustom3.Tag = "JOB_LOG_UDV3"
                                CheckBoxRightColumn_JobLogCustom4.Tag = "JOB_LOG_UDV4"
                                CheckBoxRightColumn_JobLogCustom5.Tag = "JOB_LOG_UDV5"

                                For Each UserDefinedLabel In UserDefinedLabelList

                                    For Each CheckBox In PanelUserSelectedRequiredFields_RightColumn.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)().Where(Function(CB) CB.Tag IsNot Nothing AndAlso CB.Tag.ToString = UserDefinedLabel.AssociatedTable)

                                        CheckBox.Text = UserDefinedLabel.Label

                                    Next

                                Next

                                DataGridViewTopRightColumn_ClientSortKeys.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey))

                                ComboBoxOptions_Currency.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.CurrencyCode)

                                ComboBoxOptions_FiscalStartMonth.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))

                                SearchableComboBoxAvalara_SalesClassCode.AddInactiveItemsOnSelectedValue = True

                                InvoiceFormatsList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.InvoiceFormats))

                                ComboBoxProductionInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxTVInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxMagazineInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxNewspaperInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxRadioInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxInternetInvoiceFormat_Type.DataSource = InvoiceFormatsList
                                ComboBoxOutOfHomeInvoiceFormat_Type.DataSource = InvoiceFormatsList

                                EstimateFormatsList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.EstimateFormatsClient))

                                ComboBoxProductionEstimateFormat_Type.DataSource = EstimateFormatsList

                                CheckBoxNewClientOptions_DuplicateForDivision.ChildControls.Add(CheckBoxNewClientOptions_DuplicateForProduct)
                                CheckBoxNewClientOptions_DuplicateForProduct.ChildControls.Add(SearchableComboBoxNewClientOptions_Office)

                                CheckBoxNewClientOptions_DuplicateForProduct.Enabled = False
                                SearchableComboBoxNewClientOptions_Office.Enabled = False

                                _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Security.UserSettings.IsCRMUser)

                                If _IsCRMUser Then

                                    TabItemClientDetails_ProductionTab.Visible = False
                                    TabItemClientDetails_MediaTab.Visible = False
                                    TabItemClientDetails_MediaInvoiceFormatTab.Visible = False
                                    TabItemClientDetails_RequiredFieldsTab.Visible = False

                                End If

                                _AvaTaxEnabled = AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext)

                                _IsQuickbooksEnabled = AdvantageFramework.Quickbooks.IsQuickBooksEnabled(DbContext)

                                SearchableComboBoxAvalara_SalesClassCode.Enabled = _AvaTaxEnabled
                                CheckBoxAvalara_TaxExempt.Enabled = _AvaTaxEnabled

                                SearchableComboBoxAutomatedAssignments_Job.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.PleaseSelect
                                SearchableComboBoxAutomatedAssignments_JobComponent.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.PleaseSelect

                                SearchableComboBoxAutomatedAssignments_Job.Enabled = True
                                SearchableComboBoxAutomatedAssignments_JobComponent.Enabled = False

                                DataGridViewLeftSection_Divisions.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                                DataGridViewRightSection_Products.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
                                DataGridViewWebsites_Websites.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)

                                DataGridViewRightSection_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                                DataGridViewLeftSection_Divisions.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                                DataGridViewWebsites_Websites.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                                DbContext.Database.Connection.Close()

                                LoadDropDownDataSources()

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            'objects
            Dim AgencyMediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim AgencyProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim Customers As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer) = Nothing
            Dim ErrorMessage As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If _AvaTaxEnabled Then

                        SearchableComboBoxAvalara_SalesClassCode.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)

                    End If

                    If _IsQuickbooksEnabled Then

                        RefreshQuickBooksCustomers()

                    End If

                    ComboBoxOptions_Currency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActiveMultiCurrency(DbContext)

                    SearchableComboBoxBilling_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext)

                    SearchableComboBoxTVInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveTVReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxOutOfHomeInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveOutOfHomeReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxMagazineInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveMagazineReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxNewspaperInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveNewspaperReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxRadioInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveRadioReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxInternetInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveInternetReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList
                    SearchableComboBoxProductionInvoiceFormat_Format.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveProductionReports(DbContext).OrderBy(Function(Entity) Entity.LegacyModuleCode).ThenBy(Function(Entity) Entity.ReportCode).ToList

                    SearchableComboBoxProduction_ClientDiscount.DataSource = (From Entity In DbContext.ClientDiscounts
                                                                              Where Entity.IsInactive = False
                                                                              Select Entity).ToList

                    SearchableComboBoxNewClientOptions_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)

                    SearchableComboBoxAutomatedAssignments_Job.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)
                    SearchableComboBoxAutomatedAssignments_JobComponent.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)

                    ComboBoxOptions_Biller.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                                         Select Entity.Code,
                                                                Entity.MiddleInitial,
                                                                Entity.FirstName,
                                                                Entity.LastName).ToList.Select(Function(Employee) New With {.Code = Employee.Code,
                                                                                                                            .FullName = If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial.Trim <> "", Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName, Employee.FirstName & " " & Employee.LastName)}).ToList

                    AgencyMediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)
                    AgencyProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                    If AgencyMediaInvoiceDefault IsNot Nothing Then

                        If AgencyMediaInvoiceDefault.TVCustomFormat IsNot Nothing Then
                            SearchableComboBoxTVInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.TVCustomFormat
                        End If

                        If AgencyMediaInvoiceDefault.NewspaperCustomFormat IsNot Nothing Then
                            SearchableComboBoxNewspaperInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.NewspaperCustomFormat
                        End If

                        If AgencyMediaInvoiceDefault.MagazineCustomFormat IsNot Nothing Then
                            SearchableComboBoxMagazineInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.MagazineCustomFormat
                        End If

                        If AgencyMediaInvoiceDefault.RadioCustomFormat IsNot Nothing Then
                            SearchableComboBoxRadioInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.RadioCustomFormat
                        End If

                        If AgencyMediaInvoiceDefault.OutOfHomeCustomFormat IsNot Nothing Then
                            SearchableComboBoxOutOfHomeInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.OutOfHomeCustomFormat
                        End If

                        If AgencyMediaInvoiceDefault.InternetCustomFormat IsNot Nothing Then
                            SearchableComboBoxInternetInvoiceFormat_Format.Tag = AgencyMediaInvoiceDefault.InternetCustomFormat
                        End If

                    End If

                    If AgencyProductionInvoiceDefault IsNot Nothing Then

                        If AgencyProductionInvoiceDefault.CustomFormatName IsNot Nothing Then
                            SearchableComboBoxProductionInvoiceFormat_Format.Tag = AgencyProductionInvoiceDefault.CustomFormatName
                        End If

                    End If

                    DbContext.Database.Connection.Close()

                End Using

            End Using

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Client

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Try

                If IsNew Then

                    Client = New AdvantageFramework.Database.Entities.Client

                    LoadClientEntity(Client, True)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                        If Client IsNot Nothing Then

                            LoadClientEntity(Client, False)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Client = Nothing
            End Try

            FillObject = Client

        End Function
        Private Sub LoadClientEntity(ByVal Client As AdvantageFramework.Database.Entities.Client, ByVal IsNew As Boolean)

            If Client IsNot Nothing Then

                If IsNew OrElse TabItemClientDetails_GeneralTab.Tag = True Then

                    SaveGeneralTab(Client)

                End If

                If IsNew OrElse TabItemClientDetails_BillingTab.Tag = True Then

                    SaveBillingTab(Client, IsNew)

                End If

                If IsNew OrElse TabItemClientDetails_ProductionTab.Tag = True Then

                    SaveProductionTab(Client)

                End If

                If IsNew OrElse TabItemClientDetails_MediaTab.Tag = True Then

                    SaveMediaTab(Client)

                End If

                If IsNew OrElse TabItemClientDetails_RequiredFieldsTab.Tag = True Then

                    SaveRequiredFieldsTab(Client)

                End If

                If IsNew OrElse TabItemClientDetails_AutomatedAssignmentsTab.Tag = True Then

                    SaveAutomatedAssignmentsTab(Client)

                End If

                If TabItemClientDetails_MediaIntegrationSettings.Tag = True Then

                    SaveMediaIntegrationSettingsTab(Client)

                End If

            End If

        End Sub
        Private Sub LoadContactsTab()

            If _ClientCode IsNot Nothing AndAlso Not _IsCopy Then

                ClientContactManagerControlContacts_ClientContacts.LoadControl(_ClientCode, Nothing, Nothing)

                TabItemClientDetails_ContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadContractsTab()

            If _ClientCode IsNot Nothing AndAlso Not _IsCopy Then

                ContractManagerControlContractTab_Contracts.LoadControl(_ClientCode, Nothing, Nothing)

                TabItemClientDetails_ContractsTab.Tag = True

            End If

        End Sub
        Private Sub LoadClientDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            If _ClientCode IsNot Nothing Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_ClientDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_ClientDetails.SelectedTab

                End If

                If TabItem.Tag = False Then

                    Client = LoadSelectedClient()

                    If Client IsNot Nothing Then

                        If TabItem Is TabItemClientDetails_GeneralTab OrElse TabItem Is TabItemClientDetails_BillingTab OrElse _IsCopy = True Then

                            LoadGeneralTab(Client)
                            LoadBillingTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_ProductionTab OrElse _IsCopy = True Then

                            LoadProductionTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_MediaTab OrElse _IsCopy = True Then

                            LoadMediaTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_MediaInvoiceFormatTab OrElse _IsCopy = True Then

                            LoadMediaInvoiceFormatsTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_RequiredFieldsTab OrElse _IsCopy = True Then

                            LoadRequiredFieldsTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_WebsitesTab OrElse _IsCopy = True Then

                            LoadWebsitesTab()

                        End If

                        If TabItem Is TabItemClientDetails_DocumentsTab Then

                            LoadDocumentsTab()

                        End If

                        If TabItem Is TabItemClientDetails_DivisionProductTab Then

                            LoadDivisionTab()

                        End If

                        If TabItem Is TabItemClientDetails_ContactsTab Then

                            LoadContactsTab()

                        End If

                        If TabItem Is TabItemClientDetails_ContractsTab Then

                            LoadContractsTab()

                        End If

                        If TabItem Is TabItemClientDetails_AutomatedAssignmentsTab Then

                            LoadAutomatedAssignmentsTab(Client)

                        End If

                        If TabItem Is TabItemClientDetails_MediaIntegrationSettings Then

                            LoadMediaIntegrationSettingsTab(Client)

                        End If

                    End If

                End If

            Else

                If TabItem Is TabItemClientDetails_BillingTab AndAlso AddressControlLeftColumn_Address.Tag = False Then

                    ButtonItemRefreshBilling_Address.RaiseClick()
                    ButtonItemRefreshStatement_Address.RaiseClick()
                    AddressControlLeftColumn_Address.Tag = True

                End If

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                If _IsCopy = False Then

                    TextBoxGeneral_Code.Text = Client.Code

                End If

                TextBoxGeneral_Name.Text = Client.Name

                ' Client Address
                AddressControlLeftColumn_Address.Address = Client.Address
                AddressControlLeftColumn_Address.Address2 = Client.Address2
                AddressControlLeftColumn_Address.City = Client.City
                AddressControlLeftColumn_Address.County = Client.County
                AddressControlLeftColumn_Address.State = Client.State
                AddressControlLeftColumn_Address.Zip = Client.Zip
                AddressControlLeftColumn_Address.Country = Client.Country

                ' Settings
                If _IsCopy Then

                    CheckBoxRightColumn_Inactive.Checked = False

                Else

                    CheckBoxRightColumn_Inactive.Checked = Not Convert.ToBoolean(Client.IsActive.GetValueOrDefault(0))

                End If

                CheckBoxRightColumn_NewBusiness.CheckValue = Client.IsNewBusiness.GetValueOrDefault(0)

                LoadSortKeys()

                TabItemClientDetails_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadBillingTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                ' Billing Address
                AddressControlLeftColumn_BillingAddress.Address = Client.BillingAddress
                AddressControlLeftColumn_BillingAddress.Address2 = Client.BillingAddress2
                AddressControlLeftColumn_BillingAddress.City = Client.BillingCity
                AddressControlLeftColumn_BillingAddress.County = Client.BillingCounty
                AddressControlLeftColumn_BillingAddress.State = Client.BillingState
                AddressControlLeftColumn_BillingAddress.Zip = Client.BillingZip
                AddressControlLeftColumn_BillingAddress.Country = Client.BillingCountry

                AddressControlLeftColumn_BillingAddress.Tag = Nothing

                ' Statement Address
                AddressControlRightColumn_StatementAddress.Address = Client.StatementAddress
                AddressControlRightColumn_StatementAddress.Address2 = Client.StatementAddress2
                AddressControlRightColumn_StatementAddress.City = Client.StatementCity
                AddressControlRightColumn_StatementAddress.County = Client.StatementCounty
                AddressControlRightColumn_StatementAddress.State = Client.StatementState
                AddressControlRightColumn_StatementAddress.Zip = Client.StatementZip
                AddressControlRightColumn_StatementAddress.Country = Client.StatementCountry

                SearchableComboBoxBilling_Location.EditValue = Client.InvoiceLocationID

                NumericInputOptions_CreditLimit.EditValue = Client.CreditLimit
                ComboBoxOptions_Currency.SelectedValue = Client.CurrencyCode
                ComboBoxOptions_FiscalStartMonth.SelectedValue = CLng(Client.FiscalStart.GetValueOrDefault(0))

                If Client.ContractExpirationDate IsNot Nothing Then
                    DateTimePickerOptions_ContractExpirationDate.Value = Convert.ToDateTime(Client.ContractExpirationDate)
                Else
                    DateTimePickerOptions_ContractExpirationDate.Value = Nothing
                End If

                SearchableComboBoxAvalara_SalesClassCode.SelectedValue = Client.AvalaraSalesClassCode
                CheckBoxAvalara_TaxExempt.Checked = Client.AvalaraTaxExempt.GetValueOrDefault(False)

                ' A/R Comment
                TextBoxARComment_ARComment.Text = Client.ARComment

                CheckBoxAssignComboInvoicesBy_MediaOnly.Checked = Client.AssignComboInvoicesMediaOnly

                For Each RadioButtonControl In GroupBoxBilling_AssignComboInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If CShort(RadioButtonControl.Tag) = CShort(Client.AssignComboInvoicesBy.GetValueOrDefault(0)) Then

                        RadioButtonControl.Checked = True

                        Exit For

                    End If

                Next

                ComboBoxOptions_Biller.RemoveAddedItemsFromDataSource()
                ComboBoxOptions_Biller.SelectedValue = Client.BillerEmployeeCode

                CheckBoxLatePaymentFee_Calculate.Checked = Client.CalculateLateFee
                NumericInputLatePaymentFee_Percentage.EditValue = Client.LateFeePercent
                NumericInputLatePaymentFee_Percentage.Enabled = Client.CalculateLateFee

                TextBoxBilling_VATNumber.Text = Client.VATNumber

                TabItemClientDetails_BillingTab.Tag = True

            End If

        End Sub
        Private Sub LoadProductionTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            Dim RadioButtonControl As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing

            If Client IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each RadioButtonControl In GroupBoxProduction_AssignProductionInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                        If CShort(RadioButtonControl.Tag) = CShort(Client.AssignProductionInvoicesBy.GetValueOrDefault(1)) Then

                            RadioButtonControl.Checked = True

                            Exit For

                        End If

                    Next

                    GroupBoxProduction_AssignProductionInvoicesBy.Enabled = (Client.AssignComboInvoicesBy.GetValueOrDefault(0) = 0)

                    ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                    If ProductionInvoiceDefault IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(ProductionInvoiceDefault.CustomFormatName) = False Then

                            ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxProductionInvoiceFormat_Format.SelectedValue = ProductionInvoiceDefault.CustomFormatName

                        Else

                            If ProductionInvoiceDefault.UseAgencySetting Then

                                ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                    Else

                        ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                    End If

                    InvoiceDefaultHandler(ComboBoxProductionInvoiceFormat_Type, SearchableComboBoxProductionInvoiceFormat_Format)

                    'Estimate
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByClientCode(DataContext, Client.Code)
                        'ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientCode(DataContext, Client.Code)

                        If ProductionEstimateDefault IsNot Nothing Then

                            If ProductionEstimateDefault.UseAgencySetting Then

                                ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.Client.ToString

                            End If

                        Else

                            ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.AgencyDefault.ToString.Replace("Agency", "")

                        End If

                    End Using

                    TextBoxProduction_AttentionLine.Text = Client.ProductionAttentionLine
                    TextBoxProduction_InvoiceFooterComments.Text = Client.ProductionFooterComments
                    NumericInputProduction_DaysToPay.EditValue = Client.ProductionDaysToPay.GetValueOrDefault(0)
                    SearchableComboBoxProduction_ClientDiscount.SelectedValue = Client.ClientDiscountCode
                    CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Checked = Client.LimitTimeFunctionsToBillingHierarchy

                End Using

                TabItemClientDetails_ProductionTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            Dim RadioButtonControl As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl = Nothing

            If Client IsNot Nothing Then

                For Each RadioButtonControl In GroupBoxMedia_AssignMediaInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If CShort(RadioButtonControl.Tag) = CShort(Client.AssignMediaInvoicesBy.GetValueOrDefault(1)) Then

                        RadioButtonControl.Checked = True

                        Exit For

                    End If

                Next

                GroupBoxMedia_AssignMediaInvoicesBy.Enabled = (Client.AssignComboInvoicesBy.GetValueOrDefault(0) = 0)

                TextBoxMedia_AttentionLine.Text = Client.MediaAttentionLine
                TextBoxMedia_InvoiceFooterComments.Text = Client.MediaFooterComments
                NumericInputMedia_DaysToPay.EditValue = Client.MediaDaysToPay.GetValueOrDefault(0)
                'PJH 08/23/18 - 5547-1-1 - Broadcast TV - Billing Split by Units (Utilize Coop)
                CheckBoxNewClientOptions_TvUnitProductSplit.Checked = Client.TvUnitProductSplit

                CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Checked = Client.ResponsibleForMediaTrafficInstruction

                TabItemClientDetails_MediaTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaInvoiceFormatsTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing

            If Client IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                    If MediaInvoiceDefault IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.TVCustomFormat) = False Then

                            ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxTVInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.TVCustomFormat

                        Else

                            If MediaInvoiceDefault.TVUseAgencySetting Then

                                ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.NewspaperCustomFormat) = False Then

                            ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxNewspaperInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.NewspaperCustomFormat

                        Else

                            If MediaInvoiceDefault.NewspaperUseAgencySetting Then

                                ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.MagazineCustomFormat) = False Then

                            ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxMagazineInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.MagazineCustomFormat

                        Else

                            If MediaInvoiceDefault.MagazineUseAgencySetting Then

                                ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.RadioCustomFormat) = False Then

                            ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxRadioInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.RadioCustomFormat

                        Else

                            If MediaInvoiceDefault.RadioUseAgencySetting Then

                                ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.OutOfHomeCustomFormat) = False Then

                            ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxOutOfHomeInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.OutOfHomeCustomFormat

                        Else

                            If MediaInvoiceDefault.OutdoorUseAgencySetting Then

                                ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(MediaInvoiceDefault.InternetCustomFormat) = False Then

                            ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString
                            SearchableComboBoxInternetInvoiceFormat_Format.SelectedValue = MediaInvoiceDefault.InternetCustomFormat

                        Else

                            If MediaInvoiceDefault.InternetUseAgencySetting Then

                                ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString

                            End If

                        End If

                    Else

                        ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                        ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                        ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                        ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                        ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                        ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                    End If

                End Using

                InvoiceDefaultHandler(ComboBoxTVInvoiceFormat_Type, SearchableComboBoxTVInvoiceFormat_Format)
                InvoiceDefaultHandler(ComboBoxNewspaperInvoiceFormat_Type, SearchableComboBoxNewspaperInvoiceFormat_Format)
                InvoiceDefaultHandler(ComboBoxMagazineInvoiceFormat_Type, SearchableComboBoxMagazineInvoiceFormat_Format)
                InvoiceDefaultHandler(ComboBoxRadioInvoiceFormat_Type, SearchableComboBoxRadioInvoiceFormat_Format)
                InvoiceDefaultHandler(ComboBoxOutOfHomeInvoiceFormat_Type, SearchableComboBoxOutOfHomeInvoiceFormat_Format)
                InvoiceDefaultHandler(ComboBoxInternetInvoiceFormat_Type, SearchableComboBoxInternetInvoiceFormat_Format)

                TabItemClientDetails_MediaInvoiceFormatTab.Tag = True

            End If

        End Sub
        Private Sub LoadRequiredFieldsTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.CheckValue = Client.OverrideAgencySettings.GetValueOrDefault(0)

                CheckBoxLeftColumn_AccountNumber.CheckValue = Client.AccountNumberRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_JobType.CheckValue = Client.JobTypeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_Promotion.CheckValue = Client.PromotionRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_DueDate.CheckValue = Client.DueDateRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_ComplexityCode.CheckValue = Client.ComplexityCodeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_SCFormat.CheckValue = Client.SCFormatRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_DeptTeam.CheckValue = Client.DepartmentCodeRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_MarketCode.CheckValue = Client.MarketCodeRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_AlertGroup.CheckValue = Client.AlertGroupRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_ServiceFeeType.CheckValue = Client.ServiceFeeTypeRequired.GetValueOrDefault(0)

                CheckBoxLeftColumn_CoopBillingCode.CheckValue = Client.CoopBillingCodeRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_AdNumber.CheckValue = Client.AdNumberRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_ClientReference.CheckValue = Client.ClientReferenceRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_DateOpened.CheckValue = Client.DateOpenedRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_FormatAdSize.CheckValue = Client.FormatRequired.GetValueOrDefault(0)
                CheckBoxMiddleColumn_ProductContact.CheckValue = Client.ProductContactRequired.GetValueOrDefault(0)
                CheckBoxLeftColumn_ComponentBudget.CheckValue = Client.ComponentBudgetRequired.GetValueOrDefault(0)

                CheckBoxLeftColumn_Blackplate1.CheckValue = Client.Blackplate1Required.GetValueOrDefault(0)
                CheckBoxLeftColumn_Blackplate2.CheckValue = Client.Blackplate2Required.GetValueOrDefault(0)

                CheckBoxRightColumn_JobLogCustom1.CheckValue = Client.JobLogCustom1.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom2.CheckValue = Client.JobLogCustom2.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom3.CheckValue = Client.JobLogCustom3.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom4.CheckValue = Client.JobLogCustom4.GetValueOrDefault(0)
                CheckBoxRightColumn_JobLogCustom5.CheckValue = Client.JobLogCustom5.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom1.CheckValue = Client.JobCustomComponent1Required.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom2.CheckValue = Client.JobCustomComponent2Required.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom3.CheckValue = Client.JobCustomComponent3Required.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom4.CheckValue = Client.JobCustomComponent4Required.GetValueOrDefault(0)
                CheckBoxRightColumn_JobComponentCustom5.CheckValue = Client.JobCustomComponent5Required.GetValueOrDefault(0)

                CheckBoxJobsAndMedia_CampaignCode.CheckValue = Client.CampaignCodeRequired.GetValueOrDefault(0)
                CheckBoxJobsAndMedia_FiscalPeriod.CheckValue = Client.FiscalPeriodRequired.GetValueOrDefault(0)

                'CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.CheckValue = Client.ProductCategoryInTimesheetRequired.GetValueOrDefault(0)

                CheckBoxRequiredFields_RequireTimeComments.Checked = Client.RequireTimeComment

                TabItemClientDetails_RequiredFieldsTab.Tag = True

            End If

        End Sub
        Private Sub LoadWebsitesTab()

            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
            Dim ClientWebsites As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing

            If _ClientCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientWebsites = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, _ClientCode).ToList

                End Using

            Else

                ClientWebsites = New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)

                For Each ClientWebsite In _ClientWebsiteList

                    ClientWebsites.Add(ClientWebsite)

                Next

            End If

            DataGridViewWebsites_Websites.DataSource = ClientWebsites

            DataGridViewWebsites_Websites.CurrentView.BestFitColumns()

            TabItemClientDetails_WebsitesTab.Tag = True

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If _ClientCode IsNot Nothing Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Client) With {.ClientCode = _ClientCode}

                DocumentManagerControlDocuments_ClientDocuments.ClearControl()

                DocumentManagerControlDocuments_ClientDocuments.Enabled = DocumentManagerControlDocuments_ClientDocuments.LoadControl(Database.Entities.DocumentLevel.Client, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            End If

            TabItemClientDetails_DocumentsTab.Tag = True

        End Sub
        Private Sub LoadAutomatedAssignmentsTab(Client As AdvantageFramework.Database.Entities.Client)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxAutomatedAssignments_Job.DataSource = AdvantageFramework.Database.Procedures.JobView.LoadAllOpen(DbContext).Where(Function(Entity) Entity.ClientCode = Client.Code).ToList

            End Using

            SearchableComboBoxAutomatedAssignments_Job.SelectedValue = Client.AutomatedAssignmentJobNumber
            SearchableComboBoxAutomatedAssignments_JobComponent.SelectedValue = Client.AutomatedAssignmentJobComponentNumber

            TabItemClientDetails_AutomatedAssignmentsTab.Tag = True

        End Sub
        Private Sub LoadMediaIntegrationSettingsTab(Client As AdvantageFramework.Database.Entities.Client)

            NumericInputDoubleClick_ProfileID.EditValue = Client.DoubleClickProfileID
            NumericInputDoubleClick_ReportID.EditValue = Client.DoubleClickReportID

            CheckBoxMediaIntegrationSettings_EnableDoubleClick.Checked = Client.DoubleClickEnabled

            TabControlPanelMediaIntegrationsSettingsTab_Settings.Enabled = (_IsAgencyASP = False)

            TabItemClientDetails_MediaIntegrationSettings.Tag = True

        End Sub
        Private Sub LoadDivisionTab()

            Dim ClientCode As String = Nothing

            DataGridViewLeftSection_Divisions.DataSource = Nothing

            If _ClientCode IsNot Nothing Then

                _DivisionGridLoading = True

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientCode = _ClientCode

                        If _FromMaintenance Then

                            DataGridViewLeftSection_Divisions.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadWithOfficeLimits(DbContext, _Session).Include("Client")
                                                                           Where Entity.ClientCode = ClientCode
                                                                           Select Entity

                        Else

                            DataGridViewLeftSection_Divisions.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Include("Client")
                                                                           Where Entity.ClientCode = ClientCode
                                                                           Select Entity

                        End If

                        DataGridViewLeftSection_Divisions.CurrentView.BestFitColumns()

                    End Using

                End Using

                LoadDivisionProducts()

                _DivisionGridLoading = False

                TabItemClientDetails_DivisionProductTab.Tag = True

            End If

        End Sub
        Private Sub SaveGeneralTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                Client.Code = TextBoxGeneral_Code.Text
                Client.Name = TextBoxGeneral_Name.Text

                If Client.Name.Length > _SortNameMaxLength Then

                    Client.SortName = Client.Name.Substring(0, _SortNameMaxLength)

                Else

                    Client.SortName = Client.Name

                End If

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlLeftColumn_Address, AddressTypeToValidate.General)

                    End If

                End Using

                Client.Address = AddressControlLeftColumn_Address.Address
                Client.Address2 = AddressControlLeftColumn_Address.Address2
                Client.City = AddressControlLeftColumn_Address.City
                Client.County = AddressControlLeftColumn_Address.County
                Client.State = AddressControlLeftColumn_Address.State
                Client.Zip = AddressControlLeftColumn_Address.Zip
                Client.Country = AddressControlLeftColumn_Address.Country

                Client.IsActive = If(CheckBoxRightColumn_Inactive.Checked, 0, 1)
                Client.IsNewBusiness = Convert.ToInt16(CheckBoxRightColumn_NewBusiness.CheckValue)

            End If

        End Sub
        Private Sub SaveBillingTab(ByVal Client As AdvantageFramework.Database.Entities.Client, IsNew As Boolean)

            If Client IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlLeftColumn_BillingAddress, AddressTypeToValidate.Billing)

                    End If

                End Using

                Client.BillingAddress = AddressControlLeftColumn_BillingAddress.Address
                Client.BillingAddress2 = AddressControlLeftColumn_BillingAddress.Address2
                Client.BillingCity = AddressControlLeftColumn_BillingAddress.City
                Client.BillingCounty = AddressControlLeftColumn_BillingAddress.County
                Client.BillingState = AddressControlLeftColumn_BillingAddress.State
                Client.BillingZip = AddressControlLeftColumn_BillingAddress.Zip
                Client.BillingCountry = AddressControlLeftColumn_BillingAddress.Country

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlRightColumn_StatementAddress, AddressTypeToValidate.Statement)

                    End If

                End Using

                Client.StatementAddress = AddressControlRightColumn_StatementAddress.Address
                Client.StatementAddress2 = AddressControlRightColumn_StatementAddress.Address2
                Client.StatementCity = AddressControlRightColumn_StatementAddress.City
                Client.StatementCounty = AddressControlRightColumn_StatementAddress.County
                Client.StatementState = AddressControlRightColumn_StatementAddress.State
                Client.StatementZip = AddressControlRightColumn_StatementAddress.Zip
                Client.StatementCountry = AddressControlRightColumn_StatementAddress.Country

                Client.InvoiceLocationID = SearchableComboBoxBilling_Location.GetSelectedValue

                Client.CreditLimit = NumericInputOptions_CreditLimit.GetValue

                Client.CurrencyCode = ComboBoxOptions_Currency.GetSelectedValue

                If ComboBoxOptions_FiscalStartMonth.HasASelectedValue Then

                    Client.FiscalStart = CShort(ComboBoxOptions_FiscalStartMonth.GetSelectedValue)

                Else

                    Client.FiscalStart = Nothing

                End If

                If DateTimePickerOptions_ContractExpirationDate.ValueObject IsNot Nothing Then
                    Client.ContractExpirationDate = Convert.ToDateTime(DateTimePickerOptions_ContractExpirationDate.Value)
                Else
                    Client.ContractExpirationDate = Nothing
                End If

                Client.AvalaraSalesClassCode = SearchableComboBoxAvalara_SalesClassCode.GetSelectedValue
                Client.AvalaraTaxExempt = CheckBoxAvalara_TaxExempt.Checked

                Client.ARComment = TextBoxARComment_ARComment.GetText

                Client.AssignComboInvoicesMediaOnly = CheckBoxAssignComboInvoicesBy_MediaOnly.Checked

                For Each RadioButtonControl In GroupBoxBilling_AssignComboInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        Try

                            Client.AssignComboInvoicesBy = Convert.ToInt16(RadioButtonControl.Tag)

                        Catch ex As Exception
                            Client.AssignComboInvoicesBy = 0
                        End Try

                        Exit For

                    End If

                Next

                Client.BillerEmployeeCode = ComboBoxOptions_Biller.GetSelectedValue

                If Not IsNew AndAlso CheckBoxLatePaymentFee_Calculate.Checked AndAlso ProductLateFeeProcessingExists() Then

                    AdvantageFramework.WinForm.MessageBox.Show(LATE_FEE_MESSAGE)

                    NumericInputLatePaymentFee_Percentage.EditValue = Nothing
                    CheckBoxLatePaymentFee_Calculate.Checked = False

                End If

                Client.LateFeePercent = NumericInputLatePaymentFee_Percentage.GetValue
                Client.CalculateLateFee = CheckBoxLatePaymentFee_Calculate.Checked

                Client.VATNumber = TextBoxBilling_VATNumber.GetText

            End If

        End Sub
        Private Sub SaveProductionTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                For Each RadioButtonControl In GroupBoxProduction_AssignProductionInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        Try

                            Client.AssignProductionInvoicesBy = Convert.ToInt16(RadioButtonControl.Tag)

                        Catch ex As Exception
                            Client.AssignProductionInvoicesBy = 1
                        End Try

                        Exit For

                    End If

                Next

                Client.ProductionAttentionLine = TextBoxProduction_AttentionLine.GetText
                Client.ProductionFooterComments = TextBoxProduction_InvoiceFooterComments.GetText
                Client.ProductionDaysToPay = CShort(NumericInputProduction_DaysToPay.EditValue)
                Client.ClientDiscountCode = SearchableComboBoxProduction_ClientDiscount.GetSelectedValue
                Client.LimitTimeFunctionsToBillingHierarchy = CheckBoxProduction_LimitTimeFunctionsToBillingHierarchy.Checked

            End If

        End Sub
        Private Sub SaveMediaTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                For Each RadioButtonControl In GroupBoxMedia_AssignMediaInvoicesBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Checked Then

                        Try

                            Client.AssignMediaInvoicesBy = Convert.ToInt16(RadioButtonControl.Tag)

                        Catch ex As Exception
                            Client.AssignMediaInvoicesBy = 1
                        End Try

                        Exit For

                    End If

                Next

                Client.MediaAttentionLine = TextBoxMedia_AttentionLine.GetText
                Client.MediaFooterComments = TextBoxMedia_InvoiceFooterComments.GetText
                Client.MediaDaysToPay = CShort(NumericInputMedia_DaysToPay.EditValue)
                'PJH 08/23/18 - 5547-1-1 - Broadcast TV - Billing Split by Units (Utilize Coop)
                Client.TvUnitProductSplit = CheckBoxNewClientOptions_TvUnitProductSplit.Checked

                Client.ResponsibleForMediaTrafficInstruction = CheckBoxMedia_ClientResponsibleForMediaTrafficInstructions.Checked

            End If

        End Sub
        Private Sub SaveMediaInvoiceFormatsTab(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            If MediaInvoiceDefault IsNot Nothing Then

                If ComboBoxTVInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.TVCustomFormat = SearchableComboBoxTVInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.TVCustomFormat = Nothing

                End If

                If ComboBoxNewspaperInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.NewspaperCustomFormat = SearchableComboBoxNewspaperInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.NewspaperCustomFormat = Nothing

                End If

                If ComboBoxMagazineInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.MagazineCustomFormat = SearchableComboBoxMagazineInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.MagazineCustomFormat = Nothing

                End If

                If ComboBoxRadioInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.RadioCustomFormat = SearchableComboBoxRadioInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.RadioCustomFormat = Nothing

                End If

                If ComboBoxOutOfHomeInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.OutOfHomeCustomFormat = SearchableComboBoxOutOfHomeInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.OutOfHomeCustomFormat = Nothing

                End If

                If ComboBoxInternetInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    MediaInvoiceDefault.InternetCustomFormat = SearchableComboBoxInternetInvoiceFormat_Format.GetSelectedValue

                Else

                    MediaInvoiceDefault.InternetCustomFormat = Nothing

                End If

            End If

        End Sub
        Private Sub SaveRequiredFieldsTab(ByVal Client As AdvantageFramework.Database.Entities.Client)

            If Client IsNot Nothing Then

                Client.OverrideAgencySettings = CheckBoxUserSelectedRequiredFields_OverrideAgencySettings.GetValue

                Client.AccountNumberRequired = CheckBoxLeftColumn_AccountNumber.GetValue
                Client.JobTypeRequired = CheckBoxMiddleColumn_JobType.GetValue
                Client.PromotionRequired = CheckBoxMiddleColumn_Promotion.GetValue
                Client.DueDateRequired = CheckBoxMiddleColumn_DueDate.GetValue
                Client.ComplexityCodeRequired = CheckBoxLeftColumn_ComplexityCode.GetValue
                Client.SCFormatRequired = CheckBoxMiddleColumn_SCFormat.GetValue
                Client.DepartmentCodeRequired = CheckBoxMiddleColumn_DeptTeam.GetValue
                Client.MarketCodeRequired = CheckBoxMiddleColumn_MarketCode.GetValue
                Client.AlertGroupRequired = CheckBoxLeftColumn_AlertGroup.GetValue
                Client.ServiceFeeTypeRequired = CheckBoxMiddleColumn_ServiceFeeType.GetValue

                Client.CoopBillingCodeRequired = CheckBoxLeftColumn_CoopBillingCode.GetValue
                Client.AdNumberRequired = CheckBoxLeftColumn_AdNumber.GetValue
                Client.ClientReferenceRequired = CheckBoxLeftColumn_ClientReference.GetValue
                Client.DateOpenedRequired = CheckBoxLeftColumn_DateOpened.GetValue
                Client.FormatRequired = CheckBoxMiddleColumn_FormatAdSize.GetValue
                Client.ProductContactRequired = CheckBoxMiddleColumn_ProductContact.GetValue
                Client.ComponentBudgetRequired = CheckBoxLeftColumn_ComponentBudget.GetValue

                Client.Blackplate1Required = CheckBoxLeftColumn_Blackplate1.GetValue
                Client.Blackplate2Required = CheckBoxLeftColumn_Blackplate2.GetValue

                Client.JobLogCustom1 = CheckBoxRightColumn_JobLogCustom1.GetValue
                Client.JobLogCustom2 = CheckBoxRightColumn_JobLogCustom2.GetValue
                Client.JobLogCustom3 = CheckBoxRightColumn_JobLogCustom3.GetValue
                Client.JobLogCustom4 = CheckBoxRightColumn_JobLogCustom4.GetValue
                Client.JobLogCustom5 = CheckBoxRightColumn_JobLogCustom5.GetValue
                Client.JobCustomComponent1Required = CheckBoxRightColumn_JobComponentCustom1.GetValue
                Client.JobCustomComponent2Required = CheckBoxRightColumn_JobComponentCustom2.GetValue
                Client.JobCustomComponent3Required = CheckBoxRightColumn_JobComponentCustom3.GetValue
                Client.JobCustomComponent4Required = CheckBoxRightColumn_JobComponentCustom4.GetValue
                Client.JobCustomComponent5Required = CheckBoxRightColumn_JobComponentCustom5.GetValue

                Client.CampaignCodeRequired = CheckBoxJobsAndMedia_CampaignCode.GetValue
                Client.FiscalPeriodRequired = CheckBoxJobsAndMedia_FiscalPeriod.GetValue

                Client.ProductCategoryInTimesheetRequired = CheckBoxRequiredFields_RequireProductCategorySelectionInTimesheet.GetValue

                Client.RequireTimeComment = CheckBoxRequiredFields_RequireTimeComments.Checked

            End If

        End Sub
        Private Sub SaveDiscountsTab()

            'objects
            'Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing
            'Dim ClientDiscounts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount) = Nothing

            'If DataGridViewDiscounts_Discounts.HasRows Then

            '    DataGridViewDiscounts_Discounts.CurrentView.CloseEditorForUpdating()

            '    ClientDiscounts = DataGridViewDiscounts_Discounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount)().ToList

            '    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '        For Each CD In ClientDiscounts

            '            ClientDiscount = DbContext.ClientDiscounts.Find(CD.ID)

            '            If ClientDiscount IsNot Nothing Then

            '                ClientDiscount.DbContext = DbContext
            '                ClientDiscount.DiscountAddress = CW.DiscountAddress
            '                ClientDiscount.DiscountName = CW.DiscountName

            '                AdvantageFramework.Database.Procedures.ClientDiscount.Update(DbContext, ClientDiscount)

            '            End If

            '        Next

            '    End Using

            '    _ClientDiscountList = ClientDiscounts

            'End If

        End Sub
        Private Sub SaveWebsitesTab()

            'objects
            Dim ClientWebsites As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing

            If DataGridViewWebsites_Websites.HasRows Then

                DataGridViewWebsites_Websites.CurrentView.CloseEditorForUpdating()

                ClientWebsites = DataGridViewWebsites_Websites.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientWebsite)().ToList

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each CW In ClientWebsites

                        ClientWebsite = AdvantageFramework.Database.Procedures.ClientWebsite.LoadByID(DbContext, CW.ID)

                        If ClientWebsite IsNot Nothing Then

                            ClientWebsite.DbContext = DbContext
                            ClientWebsite.WebsiteAddress = CW.WebsiteAddress
                            ClientWebsite.WebsiteName = CW.WebsiteName

                            AdvantageFramework.Database.Procedures.ClientWebsite.Update(DbContext, ClientWebsite)

                        End If

                    Next

                End Using

                _ClientWebsiteList = ClientWebsites

            End If

        End Sub
        Private Sub SaveAutomatedAssignmentsTab(Client As AdvantageFramework.Database.Entities.Client)

            Client.AutomatedAssignmentJobNumber = SearchableComboBoxAutomatedAssignments_Job.GetSelectedValue
            Client.AutomatedAssignmentJobComponentNumber = SearchableComboBoxAutomatedAssignments_JobComponent.GetSelectedValue

        End Sub
        Private Sub SaveProductionInvoiceFormat(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            If ProductionInvoiceDefault IsNot Nothing Then

                If ComboBoxProductionInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                    ProductionInvoiceDefault.CustomFormatName = SearchableComboBoxProductionInvoiceFormat_Format.GetSelectedValue

                Else

                    ProductionInvoiceDefault.CustomFormatName = Nothing

                End If

            End If

        End Sub
        Private Sub SaveMediaIntegrationSettingsTab(Client As AdvantageFramework.Database.Entities.Client)

            Client.DoubleClickProfileID = NumericInputDoubleClick_ProfileID.GetValue
            Client.DoubleClickReportID = NumericInputDoubleClick_ReportID.GetValue
            Client.DoubleClickEnabled = CheckBoxMediaIntegrationSettings_EnableDoubleClick.Checked

        End Sub
        Private Sub InvoiceDefaultHandler(ByVal InvoiceTypeComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox, ByVal InvoiceFormatSearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox)

            If InvoiceTypeComboBox.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                If InvoiceFormatSearchableComboBox.Tag IsNot Nothing Then

                    Try

                        InvoiceFormatSearchableComboBox.SelectedValue = InvoiceFormatSearchableComboBox.Tag.ToString

                    Catch ex As Exception
                        InvoiceFormatSearchableComboBox.SelectedValue = Nothing
                    End Try

                Else

                    InvoiceFormatSearchableComboBox.SelectedValue = Nothing

                End If

                InvoiceFormatSearchableComboBox.Enabled = False

            ElseIf InvoiceTypeComboBox.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                InvoiceFormatSearchableComboBox.SelectedValue = Nothing

                InvoiceFormatSearchableComboBox.Enabled = False

            ElseIf InvoiceTypeComboBox.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                InvoiceFormatSearchableComboBox.Enabled = True

            End If

        End Sub
        Private Sub UpdateAddressFields(ByVal AddressControlToCopy As AdvantageFramework.WinForm.Presentation.Controls.AddressControl, ByVal AddressControl As AdvantageFramework.WinForm.Presentation.Controls.AddressControl)

            If AddressControlToCopy IsNot Nothing AndAlso AddressControl IsNot Nothing Then

                AddressControl.Address = AddressControlToCopy.Address
                AddressControl.Address2 = AddressControlToCopy.Address2
                AddressControl.City = AddressControlToCopy.City
                AddressControl.County = AddressControlToCopy.County
                AddressControl.State = AddressControlToCopy.State
                AddressControl.Zip = AddressControlToCopy.Zip
                AddressControl.Country = AddressControlToCopy.Country

            End If

        End Sub
        Private Sub LoadDivisionProducts()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                ClientCode = _ClientCode

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                        If _FromMaintenance Then

                            DataGridViewRightSection_Products.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, _Session).Include("Office").Include("Client").Include("Division")
                                                                            Where Product.ClientCode = ClientCode AndAlso
                                                                                  Product.DivisionCode = DivisionCode
                                                                            Select Product).ToList

                        Else

                            DataGridViewRightSection_Products.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                                                            Where Product.ClientCode = ClientCode AndAlso
                                                                                  Product.DivisionCode = DivisionCode
                                                                            Select Product).ToList

                        End If

                        DataGridViewRightSection_Products.CurrentView.BestFitColumns()

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadSortKeys()

            If _ClientCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _SortKeyList = AdvantageFramework.Database.Procedures.ClientSortKey.LoadByClientCode(DbContext, _ClientCode).ToList

                End Using

            End If

            DataGridViewTopRightColumn_ClientSortKeys.DataSource = _SortKeyList

        End Sub
        Private Sub CopyCompanyProfile(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ProductToCopy As AdvantageFramework.Database.Entities.Product,
                                       ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim CompanyProfileToCopy As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim CompanyProfileAffiliations As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing
            Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing

            CompanyProfileToCopy = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, ProductToCopy.ClientCode, ProductToCopy.DivisionCode, ProductToCopy.Code)

            If CompanyProfileToCopy IsNot Nothing Then

                CompanyProfile = New AdvantageFramework.Database.Entities.CompanyProfile

                CompanyProfile = CompanyProfileToCopy.Copy

                CompanyProfile.DbContext = DbContext
                CompanyProfile.ProductCode = Product.Code
                CompanyProfile.ClientCode = Product.ClientCode
                CompanyProfile.DivisionCode = Product.DivisionCode
                CompanyProfile.CreateDate = Now
                CompanyProfile.CreatedByUserCode = _Session.UserCode
                CompanyProfile.ModifiedDate = Nothing
                CompanyProfile.ModifiedByUserCode = Nothing

                If AdvantageFramework.Database.Procedures.CompanyProfile.Insert(DbContext, CompanyProfile) Then

                    CompanyProfileAffiliations = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByCompanyProfileID(DbContext, CompanyProfileToCopy.ID).ToList

                    For Each Affiliation In CompanyProfileAffiliations

                        CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                        CompanyProfileAffiliation.DbContext = DbContext
                        CompanyProfileAffiliation.CompanyProfileID = CompanyProfile.ID
                        CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                        AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

                    Next

                End If

            End If

        End Sub
        Private Sub CopyProductMediaOverrides(DbContext As AdvantageFramework.Database.DbContext, ProductToCopy As AdvantageFramework.Database.Entities.Product,
                                              Product As AdvantageFramework.Database.Entities.Product)

            Dim CreatedDate As Date = Nothing
            Dim ProductMediaOverridesList As Generic.List(Of AdvantageFramework.Database.Entities.ProductMediaOverrides) = Nothing
            Dim ProductMediaOverrides As AdvantageFramework.Database.Entities.ProductMediaOverrides = Nothing

            CreatedDate = Now

            ProductMediaOverridesList = AdvantageFramework.Database.Procedures.ProductMediaOverrides.LoadByClientDivisionProduct(DbContext, ProductToCopy.ClientCode, ProductToCopy.DivisionCode, ProductToCopy.Code).ToList

            DbContext.Database.ExecuteSqlCommand(String.Format("delete dbo.PRODUCT_MEDIA_OVERRIDES WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'", Product.ClientCode, Product.DivisionCode, Product.Code))

            For Each ProductMediaOverride In ProductMediaOverridesList

                ProductMediaOverrides = New AdvantageFramework.Database.Entities.ProductMediaOverrides

                ProductMediaOverrides.ClientCode = Product.ClientCode
                ProductMediaOverrides.DivisionCode = Product.DivisionCode
                ProductMediaOverrides.ProductCode = Product.Code
                ProductMediaOverrides.MediaType = ProductMediaOverride.MediaType
                ProductMediaOverrides.SalesClassCode = ProductMediaOverride.SalesClassCode
                ProductMediaOverrides.RebatePercent = ProductMediaOverride.RebatePercent
                ProductMediaOverrides.MarkupPercent = ProductMediaOverride.MarkupPercent
                ProductMediaOverrides.CreatedByUserCode = DbContext.UserCode
                ProductMediaOverrides.CreatedDate = CreatedDate

                DbContext.ProductMediaOverrides.Add(ProductMediaOverrides)

            Next

            DbContext.SaveChanges()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonLeftSection_Edit.Enabled = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow
            ButtonRightSection_Edit.Enabled = DataGridViewRightSection_Products.HasOnlyOneSelectedRow
            ButtonLeftSection_Delete.Enabled = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow
            ButtonRightSection_Delete.Enabled = DataGridViewRightSection_Products.HasOnlyOneSelectedRow
            ButtonItemDivisionCopy_To.Enabled = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow
            ButtonItemProductCopy_To.Enabled = DataGridViewRightSection_Products.HasOnlyOneSelectedRow
            'ButtonItemDivisionCopy_From.Enabled = DataGridViewLeftSection_Divisions.HasASelectedRow
            ButtonItemProductCopy_From.Enabled = DataGridViewLeftSection_Divisions.HasASelectedRow
            ButtonRightSection_Add.Enabled = DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow

        End Sub
        Private Function LoadSelectedClient() As AdvantageFramework.Database.Entities.Client

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim HasQuickBookInvoice As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                If _IsQuickbooksEnabled Then

                    _IsLoading = True

                    SearchableComboBoxGeneral_QuickBooksCustomer.DataSource = _QuickBooksCustomers

                    SearchableComboBoxGeneral_QuickBooksCustomer.SelectedValue = AdvantageFramework.Quickbooks.GetClientCrossReferenceCustomerID(DbContext, Client.Code, HasQuickBookInvoice)

                    SearchableComboBoxGeneral_QuickBooksCustomer.Enabled = (HasQuickBookInvoice = False)

                    _IsLoading = False

                End If

            End Using

            LoadSelectedClient = Client

        End Function
        Private Function LoadSelectedDivision() As AdvantageFramework.Database.Entities.Division

            Dim DivisionCode As String = Nothing
            Dim ClientCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue
                ClientCode = _ClientCode

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadSelectedDivision = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)

                End Using

            Else

                LoadSelectedDivision = Nothing

            End If

        End Function
        Private Sub FillMediaInvoiceFormatObjectTV(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxTVInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.TVUseAgencySetting = True

                    ElseIf ComboBoxTVInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.TVUseAgencySetting = False

                    ElseIf ComboBoxTVInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.TVUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillMediaInvoiceFormatObjectRadio(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxRadioInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.RadioUseAgencySetting = True

                    ElseIf ComboBoxRadioInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.RadioUseAgencySetting = False

                    ElseIf ComboBoxRadioInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.RadioUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillMediaInvoiceFormatObjectOutdoor(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxOutOfHomeInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.OutdoorUseAgencySetting = True

                    ElseIf ComboBoxOutOfHomeInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.OutdoorUseAgencySetting = False

                    ElseIf ComboBoxOutOfHomeInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.OutdoorUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillMediaInvoiceFormatObjectInternet(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxInternetInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.InternetUseAgencySetting = True

                    ElseIf ComboBoxInternetInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.InternetUseAgencySetting = False

                    ElseIf ComboBoxInternetInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.InternetUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillMediaInvoiceFormatObjectNewspaper(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxNewspaperInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.NewspaperUseAgencySetting = True

                    ElseIf ComboBoxNewspaperInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.NewspaperUseAgencySetting = False

                    ElseIf ComboBoxNewspaperInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.NewspaperUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FillMediaInvoiceFormatObjectMagazine(ByRef MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Try

                If MediaInvoiceDefault IsNot Nothing Then

                    If ComboBoxMagazineInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        MediaInvoiceDefault.MagazineUseAgencySetting = True

                    ElseIf ComboBoxMagazineInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        MediaInvoiceDefault.MagazineUseAgencySetting = False

                    ElseIf ComboBoxMagazineInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        MediaInvoiceDefault.MagazineUseAgencySetting = False

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub RadioButtonControlAssignComboInvoicesByCheckedChanging(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso Not e.NewChecked.Checked Then

                If AdvantageFramework.WinForm.MessageBox.Show("Enabling a combo invoice option will disable Production and Media Invoice Assign By options, are you sure you want to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                    e.Cancel = True

                Else

                    GroupBoxMedia_AssignMediaInvoicesBy.Enabled = False
                    GroupBoxProduction_AssignProductionInvoicesBy.Enabled = False

                End If

            ElseIf e.NewChecked.Checked Then

                GroupBoxMedia_AssignMediaInvoicesBy.Enabled = True
                GroupBoxProduction_AssignProductionInvoicesBy.Enabled = True

            End If

        End Sub
        Private Function ProductLateFeeProcessingExists() As Boolean

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ProductLateFeeProcessingExists = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByClientCode(DbContext, _ClientCode)
                                                  Where Product.IsActive = 1 AndAlso
                                                        Product.CalculateLateFee = True
                                                  Select Product).Any

            End Using

        End Function
        Private Sub AuthorizeGoogleServices()

            'objects
            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Try

                Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, False, _ClientCode)

                If Service IsNot Nothing Then

                    If Service.Authorize() Then

                        Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.CLIENT SET DC_ENABLED = 1 WHERE CL_CODE = '{0}'", _ClientCode))

                        End Using

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub DeauthorizeGoogleServices()

            Dim Service As AdvantageFramework.GoogleServices.Service = Nothing

            Me.ShowWaitForm("Processing...")

            Try

                Service = AdvantageFramework.GoogleServices.Service.InitializeDoubleClick(_Session, False, _ClientCode)

                If Service IsNot Nothing Then

                    If Service.Deauthorize() Then

                        Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            DataContext.ExecuteCommand(String.Format("UPDATE dbo.CLIENT SET DC_ENABLED = 0 WHERE CL_CODE = '{0}'", _ClientCode))

                        End Using

                    End If

                End If

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub RefreshQuickBooksCustomers()

            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.Quickbooks.GetCustomers(_Session, _QuickBooksCustomers, ErrorMessage) = False Then

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub UpdateQuickBooksCrossReference(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String)

            Dim RecordSourceID As Integer = -1

            If _IsQuickbooksEnabled Then

                RecordSourceID = AdvantageFramework.Quickbooks.GetQuickBooksRecordSourceID(DbContext)

                If SearchableComboBoxGeneral_QuickBooksCustomer.HasASelectedValue Then

                    If AdvantageFramework.Quickbooks.UpdateClientCrossReference(DbContext, ClientCode, SearchableComboBoxGeneral_QuickBooksCustomer.GetSelectedValue) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Selected QuickBooks customer is already associated with another Advantage client.")

                        SearchableComboBoxGeneral_QuickBooksCustomer.SelectedValue = Nothing

                    End If

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CLIENT_XREF WHERE RECORD_SOURCE_ID = {0} AND CL_CODE = '{1}'", RecordSourceID, ClientCode))

                End If

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal IsCopy As Boolean, FromMaintenance As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            _ClientCode = ClientCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If _ClientCode <> "" Then

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    If IsCopy = False Then

                        TextBoxGeneral_Code.Text = _ClientCode
                        TextBoxGeneral_Code.Enabled = False
                        TextBoxGeneral_Code.ReadOnly = True
                        GroupBoxLeftColumn_NewClientOptions.Visible = False
                        TabItemClientDetails_WebsitesTab.Visible = True
                        TabItemClientDetails_DocumentsTab.Visible = _HasAccessToDocuments
                        TabItemClientDetails_DivisionProductTab.Visible = True
                        TabItemClientDetails_ContactsTab.Visible = True
                        TabItemClientDetails_ContractsTab.Visible = False
                        TabItemClientDetails_AutomatedAssignmentsTab.Visible = True
                        TabItemClientDetails_MediaIntegrationSettings.Visible = True

                    Else

                        TextBoxGeneral_Code.Text = ""
                        TextBoxGeneral_Code.Enabled = True
                        TextBoxGeneral_Code.ReadOnly = False
                        GroupBoxLeftColumn_NewClientOptions.Visible = True
                        TabItemClientDetails_WebsitesTab.Visible = False
                        TabItemClientDetails_DocumentsTab.Visible = False
                        TabItemClientDetails_DivisionProductTab.Visible = False
                        TabItemClientDetails_ContactsTab.Visible = False
                        TabItemClientDetails_ContractsTab.Visible = False
                        TabItemClientDetails_AutomatedAssignmentsTab.Visible = False
                        TabItemClientDetails_MediaIntegrationSettings.Visible = False

                    End If

                    If Client IsNot Nothing Then

                        LoadClientDetails(Nothing)
                        AddressControlLeftColumn_Address.Tag = True

                    Else

                        Loaded = False
                        AddressControlLeftColumn_Address.Tag = True

                    End If

                    If Me.IsCRMUser Then

                        CheckBoxRightColumn_NewBusiness.AutoCheck = False

                        TabItemClientDetails_MediaIntegrationSettings.Visible = False

                    End If

                Else

                    AddressControlLeftColumn_Address.Tag = False
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Name.Enabled = True
                    TextBoxGeneral_Name.ReadOnly = False
                    GroupBoxLeftColumn_NewClientOptions.Visible = True
                    TabItemClientDetails_WebsitesTab.Visible = False
                    TabItemClientDetails_DivisionProductTab.Visible = False
                    TabItemClientDetails_DocumentsTab.Visible = False
                    TabItemClientDetails_ContactsTab.Visible = False
                    TabItemClientDetails_ContractsTab.Visible = False
                    TabItemClientDetails_AutomatedAssignmentsTab.Visible = False
                    TabItemClientDetails_MediaIntegrationSettings.Visible = False
                    RadioButtonControlAssignProductionInvoicesBy_Job.Checked = True
                    RadioButtonControlAssignMediaInvoicesBy_SalesClass.Checked = True
                    DataGridViewWebsites_Websites.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)

                    ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                    ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                    ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                    ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                    ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                    ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
                    ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

                    If Me.IsCRMUser Then

                        CheckBoxRightColumn_NewBusiness.AutoCheck = False
                        CheckBoxRightColumn_NewBusiness.Checked = True

                    End If

                End If

                LabelGeneral_QuickbooksCustomer.Visible = _IsQuickbooksEnabled
                SearchableComboBoxGeneral_QuickBooksCustomer.Visible = _IsQuickbooksEnabled

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ErrorMessage As String = ""
            Dim IsNewMediaInvoiceDefault As Boolean = False
            Dim IsNewProductionInvoiceDefault As Boolean = False
            Dim IsNewProductionEstimateDefault As Boolean = False
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Client = Me.FillObject(False)

                        If Client IsNot Nothing AndAlso AddressControlLeftColumn_BillingAddress.Tag Is Nothing Then

                            Saved = AdvantageFramework.Database.Procedures.Client.Update(DbContext, Client)

                            If Saved Then

                                UpdateQuickBooksCrossReference(DbContext, Client.Code)

                                MediaInvoiceDefault = FillMediaInvoiceFormatObject(DbContext, IsNewMediaInvoiceDefault)

                                ProductionInvoiceDefault = FillProductionInvoiceFormatObject(DbContext, IsNewProductionInvoiceDefault)

                                ProductionEstimateDefault = FillProductionEstimateFormatObject(DataContext, IsNewProductionEstimateDefault)

                                If MediaInvoiceDefault IsNot Nothing Then

                                    If IsNewMediaInvoiceDefault Then

                                        MediaInvoiceDefault.DbContext = DbContext
                                        MediaInvoiceDefault.ClientCode = Client.Code
                                        MediaInvoiceDefault.ClientOrDefault = 2

                                        If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault) Then

                                            AdvantageFramework.Database.Procedures.MediaInvoiceDefault.ResetToDefaults(DbContext, MediaInvoiceDefault)

                                        End If

                                    Else

                                        AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Update(DbContext, MediaInvoiceDefault)

                                    End If

                                End If

                                If ProductionInvoiceDefault IsNot Nothing Then

                                    If IsNewProductionInvoiceDefault Then

                                        ProductionInvoiceDefault.DbContext = DbContext
                                        ProductionInvoiceDefault.ClientCode = Client.Code
                                        ProductionInvoiceDefault.ClientOrDefault = 2

                                        If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault) Then

                                            AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.ResetToDefaults(DbContext, ProductionInvoiceDefault)

                                        End If

                                    Else

                                        AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Update(DbContext, ProductionInvoiceDefault)

                                    End If

                                End If

                                If ProductionEstimateDefault IsNot Nothing Then

                                    If IsNewProductionEstimateDefault Then

                                        ProductionEstimateDefault.DataContext = DataContext
                                        ProductionEstimateDefault.ClientCode = Client.Code
                                        ProductionEstimateDefault.ClientOrDefault = 2

                                        If AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault) Then

                                            'AdvantageFramework.Database.Procedures.EstimatePrintingSetting.ResetToDefaults(DataContext, ProductionEstimateDefault)

                                        End If

                                    Else

                                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, ProductionEstimateDefault)

                                    End If

                                End If

                                SaveWebsitesTab()

                            Else

                                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                            End If

                        ElseIf AddressControlLeftColumn_BillingAddress.Tag IsNot Nothing Then

                            ErrorMessage = "Failed to validate billing address."

                        End If

                    End Using

                End Using

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
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False
            Dim QuickBooksRecordSourceID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = Me.FillObject(False)

                    If Client IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Client.Delete(DbContext, Client)

                        If Deleted AndAlso _IsQuickbooksEnabled Then

                            QuickBooksRecordSourceID = AdvantageFramework.Quickbooks.GetQuickBooksRecordSourceID(DbContext)

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CLIENT_XREF WHERE CL_CODE = '{0}' AND RECORD_SOURCE_ID = {1}", Client.Code, QuickBooksRecordSourceID))

                        End If

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The client is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ClientCode As String) As Boolean

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ClSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = Me.FillObject(True)

                    If Client IsNot Nothing AndAlso AddressControlLeftColumn_BillingAddress.Tag Is Nothing Then

                        Client.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.Client.Insert(DbContext, Client)

                        If Inserted Then

                            UpdateQuickBooksCrossReference(DbContext, Client.Code)

                            If Me.GetSortKeyList IsNot Nothing Then

                                For Each ClientSortKey In Me.GetSortKeyList

                                    ClSortKey = New AdvantageFramework.Database.Entities.ClientSortKey

                                    ClSortKey.DbContext = DbContext
                                    ClSortKey.ClientCode = Client.Code
                                    ClSortKey.SortKey = ClientSortKey.SortKey

                                    AdvantageFramework.Database.Procedures.ClientSortKey.Insert(DbContext, ClSortKey)

                                Next

                            End If

                            If Me.DuplicateForDivision Then

                                SaveNewClientOptions(Client)

                            End If

                            MediaInvoiceDefault = FillMediaInvoiceFormatObject(DbContext, True)

                            If MediaInvoiceDefault IsNot Nothing Then

                                MediaInvoiceDefault.DbContext = DbContext
                                MediaInvoiceDefault.ClientCode = Client.Code
                                MediaInvoiceDefault.ClientOrDefault = 2

                                If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Insert(DbContext, MediaInvoiceDefault) Then

                                    AdvantageFramework.Database.Procedures.MediaInvoiceDefault.ResetToDefaults(DbContext, MediaInvoiceDefault)

                                End If

                            End If

                            ProductionInvoiceDefault = FillProductionInvoiceFormatObject(DbContext, True)

                            If ProductionInvoiceDefault IsNot Nothing Then

                                ProductionInvoiceDefault.DbContext = DbContext
                                ProductionInvoiceDefault.ClientCode = Client.Code
                                ProductionInvoiceDefault.ClientOrDefault = 2

                                If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Insert(DbContext, ProductionInvoiceDefault) Then

                                    AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.ResetToDefaults(DbContext, ProductionInvoiceDefault)

                                End If

                            End If

                            If Me.ClientWebsiteList IsNot Nothing Then

                                For Each ClientWebsite In Me.ClientWebsiteList

                                    ClientWebsite.DbContext = DbContext
                                    ClientWebsite.ClientCode = Client.Code

                                    AdvantageFramework.Database.Procedures.ClientWebsite.Insert(DbContext, ClientWebsite)

                                Next

                            End If

                            ClientCode = Client.Code

                        Else

                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                        End If

                    ElseIf AddressControlLeftColumn_BillingAddress.Tag IsNot Nothing Then

                        ErrorMessage = "Failed to validate billing address."

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
        Public Function GetSortKeyList() As Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey)

            Dim SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey) = Nothing

            Try

                SortKeyList = _SortKeyList

            Catch ex As Exception
                SortKeyList = Nothing
            End Try

            GetSortKeyList = SortKeyList

        End Function
        Public Sub DeleteSelectedClientWebsite()

            'objects
            Dim ClientWebsites As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing

            If DataGridViewWebsites_Websites.HasASelectedRow Then

                DataGridViewWebsites_Websites.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    ClientWebsites = DataGridViewWebsites_Websites.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ClientWebsite)().ToList

                    If _ClientCode IsNot Nothing AndAlso _ClientCode <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each ClientWebsite In ClientWebsites

                                If AdvantageFramework.Database.Procedures.ClientWebsite.Delete(DbContext, ClientWebsite) = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Website: " & ClientWebsite.WebsiteAddress & " is in use and cannot be deleted.")

                                End If

                            Next

                        End Using

                    Else

                        For Each ClientWebsite In ClientWebsites

                            _ClientWebsiteList.Remove(ClientWebsite)

                        Next

                    End If

                    Me.CloseWaitForm()

                    LoadWebsitesTab()

                End If

            End If

        End Sub
        Public Sub AddContact()

            ClientContactManagerControlContacts_ClientContacts.AddClientContact()

        End Sub
        Public Sub EditContact()

            ClientContactManagerControlContacts_ClientContacts.EditSelectedClientContact()

        End Sub
        Public Sub DeleteContact()

            ClientContactManagerControlContacts_ClientContacts.DeleteSelectedClientContact()

        End Sub
        Public Sub AddContract()

            ContractManagerControlContractTab_Contracts.AddContract()

        End Sub
        Public Sub EditContract()

            ContractManagerControlContractTab_Contracts.EditContract()

        End Sub
        Public Sub DeleteContract()

            ContractManagerControlContractTab_Contracts.DeleteSelectedContract()

        End Sub
        Public Sub CopyContract()

            ContractManagerControlContractTab_Contracts.CopyContract()

        End Sub
        Public Sub CancelAddNewClientWebsite()

            DataGridViewWebsites_Websites.CancelNewItemRow()

            LoadWebsitesTab()

        End Sub
        Public Sub UploadDocument()

            DocumentManagerControlDocuments_ClientDocuments.UploadNewDocument()

        End Sub
        Public Sub SendASPUploadEmail()

            DocumentManagerControlDocuments_ClientDocuments.SendASPUploadEmail()

        End Sub
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_ClientDocuments.DeleteSelectedDocument()

        End Sub
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_ClientDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub SaveNewClientOptions(ByVal Client As AdvantageFramework.Database.Entities.Client)

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If Client IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If CheckBoxNewClientOptions_DuplicateForDivision.Checked Then

                        Division = AdvantageFramework.Database.Procedures.Division.CreateFromClient(Client)

                        If Division IsNot Nothing Then

                            Division.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division) AndAlso CheckBoxNewClientOptions_DuplicateForProduct.Checked Then

                                Product = AdvantageFramework.Database.Procedures.Product.CreateFromClient(Client)

                                If Product IsNot Nothing Then

                                    Product.DbContext = DbContext
                                    Product.OfficeCode = SearchableComboBoxNewClientOptions_Office.GetSelectedValue

                                    AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                                End If

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub ClearControl()

            _ClientCode = Nothing
            _SortKeyList.Clear()
            _IsCopy = Nothing

            'settings
            TextBoxGeneral_Code.Text = Nothing
            TextBoxGeneral_Name.Text = Nothing
            AddressControlLeftColumn_Address.ClearControl()
            ComboBoxOptions_FiscalStartMonth.SelectedIndex = -1
            NumericInputOptions_CreditLimit.Value = Nothing
            CheckBoxRightColumn_Inactive.Checked = False
            CheckBoxRightColumn_NewBusiness.Checked = False
            SearchableComboBoxGeneral_QuickBooksCustomer.SelectedValue = Nothing

            DataGridViewTopRightColumn_ClientSortKeys.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey))

            'billing
            ComboBoxOptions_Currency.SelectedIndex = -1
            AddressControlLeftColumn_BillingAddress.ClearControl()
            AddressControlRightColumn_StatementAddress.ClearControl()
            TextBoxARComment_ARComment.Text = Nothing
            NumericInputLatePaymentFee_Percentage.EditValue = Nothing
            CheckBoxLatePaymentFee_Calculate.Checked = False
            TextBoxBilling_VATNumber.Text = Nothing

            'Production
            RadioButtonControlAssignProductionInvoicesBy_Job.Checked = True
            ComboBoxProductionInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxProductionEstimateFormat_Type.SelectedIndex = -1
            SearchableComboBoxProductionInvoiceFormat_Format.SelectedValue = Nothing
            TextBoxProduction_AttentionLine.Text = Nothing
            TextBoxProduction_InvoiceFooterComments.Text = Nothing
            NumericInputProduction_DaysToPay.EditValue = Nothing
            ComboBoxProductionInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.AgencyDefault.ToString.Replace("Agency", "")
            SearchableComboBoxProduction_ClientDiscount.SelectedValue = Nothing

            'Media
            RadioButtonControlAssignMediaInvoicesBy_SalesClass.Checked = True
            TextBoxMedia_AttentionLine.Text = Nothing
            TextBoxMedia_InvoiceFooterComments.Text = Nothing
            NumericInputMedia_DaysToPay.EditValue = Nothing

            'Media Integration Settings
            CheckBoxMediaIntegrationSettings_EnableDoubleClick.Checked = False
            NumericInputDoubleClick_ProfileID.EditValue = Nothing
            NumericInputDoubleClick_ReportID.EditValue = Nothing

            'Media Invoice Format
            ComboBoxInternetInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxOutOfHomeInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxRadioInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxMagazineInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxNewspaperInvoiceFormat_Type.SelectedIndex = -1
            ComboBoxTVInvoiceFormat_Type.SelectedIndex = -1

            SearchableComboBoxInternetInvoiceFormat_Format.SelectedValue = Nothing
            SearchableComboBoxOutOfHomeInvoiceFormat_Format.SelectedValue = Nothing
            SearchableComboBoxRadioInvoiceFormat_Format.SelectedValue = Nothing
            SearchableComboBoxMagazineInvoiceFormat_Format.SelectedValue = Nothing
            SearchableComboBoxNewspaperInvoiceFormat_Format.SelectedValue = Nothing
            SearchableComboBoxTVInvoiceFormat_Format.SelectedValue = Nothing

            ComboBoxInternetInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxRadioInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxMagazineInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxNewspaperInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")
            ComboBoxTVInvoiceFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "")

            'websites tab
            DataGridViewWebsites_Websites.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite))

            'Required Fields
            For Each CheckBox In GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                CheckBox.Checked = False

            Next
            CheckBoxJobsAndMedia_CampaignCode.Checked = False
            CheckBoxJobsAndMedia_FiscalPeriod.Checked = False

            ' Division/Product
            DataGridViewLeftSection_Divisions.DataSource = Nothing
            DataGridViewRightSection_Products.DataSource = Nothing

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ClearValidations()

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function FillProductionInvoiceFormatObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.ProductionInvoiceDefault

            'objects
            Dim AgencyProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing

            Try

                If IsNew OrElse TabItemClientDetails_ProductionTab.Tag = True Then

                    If _ClientCode IsNot Nothing Then

                        ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, _ClientCode)

                    End If

                    If ComboBoxProductionInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", "") Then

                        If ProductionInvoiceDefault IsNot Nothing Then

                            ProductionInvoiceDefault.UseAgencySetting = True

                        Else

                            AgencyProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                            ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault

                            ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(AgencyProductionInvoiceDefault)

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                            ProductionInvoiceDefault.UseAgencySetting = True

                            IsNew = True

                        End If

                    ElseIf ComboBoxProductionInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString Then

                        If ProductionInvoiceDefault IsNot Nothing Then

                            ProductionInvoiceDefault.UseAgencySetting = False

                        Else

                            AgencyProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                            ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault

                            ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(AgencyProductionInvoiceDefault)

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                            ProductionInvoiceDefault.UseAgencySetting = False

                            IsNew = True

                        End If

                    ElseIf ComboBoxProductionInvoiceFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString Then

                        If ProductionInvoiceDefault IsNot Nothing Then

                            ProductionInvoiceDefault.UseAgencySetting = False

                        Else

                            AgencyProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadAgencyDefault(DbContext)

                            ProductionInvoiceDefault = New AdvantageFramework.Database.Entities.ProductionInvoiceDefault

                            ProductionInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting(AgencyProductionInvoiceDefault)

                            ProductionInvoiceSetting.Save(ProductionInvoiceDefault)

                            ProductionInvoiceDefault.UseAgencySetting = False

                            IsNew = True

                        End If

                    End If

                    SaveProductionInvoiceFormat(ProductionInvoiceDefault)

                End If

            Catch ex As Exception
                ProductionInvoiceDefault = Nothing
            Finally
                FillProductionInvoiceFormatObject = ProductionInvoiceDefault
            End Try

        End Function
        Public Function FillMediaInvoiceFormatObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.MediaInvoiceDefault

            'objects
            Dim AgencyMediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing

            Try

                If IsNew OrElse TabItemClientDetails_MediaInvoiceFormatTab.Tag = True Then

                    If _ClientCode IsNot Nothing Then

                        MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, _ClientCode)

                    End If

                    If MediaInvoiceDefault Is Nothing Then

                        AgencyMediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadAgencyDefault(DbContext)

                        MediaInvoiceDefault = New AdvantageFramework.Database.Entities.MediaInvoiceDefault

                        MediaInvoiceSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting(AgencyMediaInvoiceDefault)

                        MediaInvoiceSetting.Save(MediaInvoiceDefault)

                        IsNew = True

                    End If

                    If MediaInvoiceDefault IsNot Nothing Then

                        FillMediaInvoiceFormatObjectMagazine(MediaInvoiceDefault)
                        FillMediaInvoiceFormatObjectNewspaper(MediaInvoiceDefault)
                        FillMediaInvoiceFormatObjectInternet(MediaInvoiceDefault)
                        FillMediaInvoiceFormatObjectOutdoor(MediaInvoiceDefault)
                        FillMediaInvoiceFormatObjectRadio(MediaInvoiceDefault)
                        FillMediaInvoiceFormatObjectTV(MediaInvoiceDefault)

                        SaveMediaInvoiceFormatsTab(MediaInvoiceDefault)

                    End If

                End If

            Catch ex As Exception
                MediaInvoiceDefault = Nothing
            Finally
                FillMediaInvoiceFormatObject = MediaInvoiceDefault
            End Try

        End Function
        Public Function FillProductionEstimateFormatObject(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            'objects
            Dim AgencyProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Try

                If IsNew OrElse TabItemClientDetails_ProductionTab.Tag = True Then

                    If _ClientCode IsNot Nothing Then

                        ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByClientCode(DataContext, _ClientCode)
                        'ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientCode(DataContext, _ClientCode)

                    End If

                    If ComboBoxProductionEstimateFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.AgencyDefault.ToString.Replace("Agency", "") Then

                        If ProductionEstimateDefault IsNot Nothing Then

                            ProductionEstimateDefault.UseAgencySetting = 1

                        Else

                            AgencyProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                            If AgencyProductionEstimateDefault Is Nothing Then

                                AgencyProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

                                ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                                ProductionEstimateSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(AgencyProductionEstimateDefault)

                                ProductionEstimateSetting.Save(ProductionEstimateDefault)

                                ProductionEstimateDefault.ClientOrDefault = 1

                                AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                            End If

                            ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                            ProductionEstimateSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(AgencyProductionEstimateDefault)

                            ProductionEstimateSetting.Save(ProductionEstimateDefault)

                            ProductionEstimateDefault.UseAgencySetting = 1

                            IsNew = True

                        End If

                    ElseIf ComboBoxProductionEstimateFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsClient.Client.ToString Then

                        If ProductionEstimateDefault IsNot Nothing Then

                            ProductionEstimateDefault.UseAgencySetting = 0

                        Else

                            AgencyProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                            If AgencyProductionEstimateDefault Is Nothing Then

                                AgencyProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

                                ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                                ProductionEstimateSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(AgencyProductionEstimateDefault)

                                ProductionEstimateSetting.Save(ProductionEstimateDefault)

                                ProductionEstimateDefault.ClientOrDefault = 1

                                AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                            End If

                            ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                            ProductionEstimateSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(AgencyProductionEstimateDefault)

                            ProductionEstimateSetting.Save(ProductionEstimateDefault)

                            ProductionEstimateDefault.UseAgencySetting = 0

                            IsNew = True

                        End If

                    End If

                End If

            Catch ex As Exception
                ProductionEstimateDefault = Nothing
            Finally
                FillProductionEstimateFormatObject = ProductionEstimateDefault
            End Try

        End Function
        Public Sub LoadRequiredNonGridControlsForValidation()

            'objects
            Dim RequiredTabsList As Generic.List(Of DevComponents.DotNetBar.TabItem) = Nothing

            If _ClientCode <> "" Then

                RequiredTabsList = New Generic.List(Of DevComponents.DotNetBar.TabItem)

                RequiredTabsList.Add(TabItemClientDetails_GeneralTab)

                For Each TabItem In RequiredTabsList

                    If TabItem IsNot TabControlControl_ClientDetails.SelectedTab Then

                        LoadClientDetails(TabItem)

                    End If

                Next

            End If

        End Sub
        Public Sub DeleteSelectedSortKey()

            'objects
            Dim ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing

            If DataGridViewTopRightColumn_ClientSortKeys.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want To delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ClientSortKey = DataGridViewTopRightColumn_ClientSortKeys.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ClientSortKey = Nothing
                    End Try

                    If ClientSortKey IsNot Nothing Then

                        If _ClientCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ClientSortKey.Delete(DbContext, ClientSortKey) Then

                                    LoadSortKeys()

                                End If

                            End Using

                        Else

                            Try

                                _SortKeyList.Remove(_SortKeyList.Where(Function(ClSortKey) ClSortKey.SortKey = ClientSortKey.SortKey).FirstOrDefault)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddSelectedSortKey()

            DataGridViewTopRightColumn_ClientSortKeys.CancelNewItemRow()

        End Sub
        Public Sub RefreshDivisionsProducts()

            LoadDivisionProducts()

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub
        Public Sub RefreshQuickbooksCustomer()

            Dim ErrorMessage As String = Nothing
            Dim Customer As AdvantageFramework.Quickbooks.Classes.Customer = Nothing

            RefreshQuickBooksCustomers()

            If SearchableComboBoxGeneral_QuickBooksCustomer.HasASelectedValue AndAlso AdvantageFramework.Quickbooks.GetCustomer(_Session, SearchableComboBoxGeneral_QuickBooksCustomer.GetSelectedValue, Customer, ErrorMessage) Then

                TextBoxGeneral_Name.Text = Customer.DisplayName

                AddressControlLeftColumn_Address.Address = Customer.BillAddressLine1
                AddressControlLeftColumn_Address.Address2 = Customer.BillAddressLine2
                AddressControlLeftColumn_Address.City = Customer.BillAddressCity
                AddressControlLeftColumn_Address.State = Customer.BillAddressState
                AddressControlLeftColumn_Address.Zip = Customer.BillAddressZip
                AddressControlLeftColumn_Address.Country = Customer.BillAddressCounty
                AddressControlLeftColumn_Address.Country = Customer.BillAddressCountry

                AddressControlLeftColumn_BillingAddress.Address = Customer.BillAddressLine1
                AddressControlLeftColumn_BillingAddress.Address2 = Customer.BillAddressLine2
                AddressControlLeftColumn_BillingAddress.City = Customer.BillAddressCity
                AddressControlLeftColumn_BillingAddress.State = Customer.BillAddressState
                AddressControlLeftColumn_BillingAddress.Zip = Customer.BillAddressZip
                AddressControlLeftColumn_BillingAddress.County = Customer.BillAddressCounty
                AddressControlLeftColumn_BillingAddress.Country = Customer.BillAddressCountry

                AddressControlRightColumn_StatementAddress.Address = Customer.BillAddressLine1
                AddressControlRightColumn_StatementAddress.Address2 = Customer.BillAddressLine2
                AddressControlRightColumn_StatementAddress.City = Customer.BillAddressCity
                AddressControlRightColumn_StatementAddress.State = Customer.BillAddressState
                AddressControlRightColumn_StatementAddress.Zip = Customer.BillAddressZip
                AddressControlRightColumn_StatementAddress.County = Customer.BillAddressCounty
                AddressControlRightColumn_StatementAddress.Country = Customer.BillAddressCountry

            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler RadioButtonControlAssignComboInvoicesBy_Client.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            RemoveHandler RadioButtonControlAssignComboInvoicesBy_ClientCampaign.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            RemoveHandler RadioButtonControlAssignComboInvoicesBy_ClientDivision.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            RemoveHandler RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            RemoveHandler RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging

        End Sub
        Private Sub ClientControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _ClientWebsiteList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)
            _SortKeyList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientSortKey)

            ButtonItemRefreshBilling_Address.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemRefreshStatement_Address.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemRefreshStatement_Billing.Icon = AdvantageFramework.My.Resources.PurchaseOrderIcon

            DataGridViewLeftSection_Divisions.FocusToFindPanel(False)
            DataGridViewRightSection_Products.FocusToFindPanel(False)

            CheckBoxAssignComboInvoicesBy_MediaOnly.Visible = False

            AddHandler RadioButtonControlAssignComboInvoicesBy_Client.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            AddHandler RadioButtonControlAssignComboInvoicesBy_ClientCampaign.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            AddHandler RadioButtonControlAssignComboInvoicesBy_ClientDivision.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            AddHandler RadioButtonControlAssignComboInvoicesBy_ClientDivisionProduct.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging
            AddHandler RadioButtonControlAssignComboInvoicesBy_ClientDivisionProductCampaign.CheckedChanging, AddressOf RadioButtonControlAssignComboInvoicesByCheckedChanging

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewLeftSection_Divisions_RowDoubleClickEvent() Handles DataGridViewLeftSection_Divisions.RowDoubleClickEvent

            ButtonLeftSection_Edit.PerformClick()

        End Sub
        Private Sub DataGridViewLeftSection_Division_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Divisions.SelectionChangedEvent

            If _DivisionGridLoading = False Then

                LoadDivisionProducts()

            End If

            EnableOrDisableActions()

            RaiseEvent SelectedDivisionChanged(sender, e)

        End Sub
        Private Sub DataGridViewRightSection_Products_RowDoubleClickEvent() Handles DataGridViewRightSection_Products.RowDoubleClickEvent

            ButtonRightSection_Edit.PerformClick()

        End Sub
        Private Sub DataGridViewRightSecion_Products_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_Products.SelectionChangedEvent

            EnableOrDisableActions()

            RaiseEvent SelectedProductChanged(sender, e)

        End Sub
        Private Sub TabControlControl_ClientDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_ClientDetails.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False

            End If

        End Sub
        Private Sub TabControlControl_ClientDetails_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_ClientDetails.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True

            End If

            LoadClientDetails(e.NewTab)

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub ButtonItemProductCopy_From_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProductCopy_From.Click

            'objects
            Dim SelectedProducts As IEnumerable = Nothing
            Dim ProductToCopy As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Product, True, True, SelectedProducts) = Windows.Forms.DialogResult.OK Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedProduct In SelectedProducts

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        ProductToCopy = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, SelectedProduct.ClientCode, SelectedProduct.DivisionCode, SelectedProduct.Code)

                        If ProductToCopy IsNot Nothing Then

                            Product = New AdvantageFramework.Database.Entities.Product

                            Product = AdvantageFramework.Database.Procedures.Product.Copy(ProductToCopy)

                            Product.DbContext = DbContext
                            Product.ClientCode = _ClientCode
                            Product.DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                            If (From Entity In DbContext.Products
                                Where Entity.Code.ToUpper = Product.Code.ToUpper AndAlso
                                      Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                      Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any Then

                                ProductCode = Product.Code

                                Do While ValidCode = False

                                    DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Product Code", "Please enter a unique code For: " & vbCrLf & Product.ToString, ProductCode, ProductCode, AdvantageFramework.Database.Entities.Product.Properties.Code)

                                    If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                        Exit Do

                                    Else

                                        If (From Entity In DbContext.Products
                                            Where Entity.Code.ToUpper = ProductCode.ToUpper AndAlso
                                                  Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                                  Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any = False Then

                                            Product.Code = ProductCode
                                            ValidCode = True

                                        End If

                                    End If

                                Loop

                            Else

                                ValidCode = True

                            End If

                            If ValidCode Then

                                Try

                                    If AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product) Then

                                        CopyCompanyProfile(DbContext, ProductToCopy, Product)

                                        CopyProductMediaOverrides(DbContext, ProductToCopy, Product)

                                    End If

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End Using

                LoadDivisionProducts()

            End If

        End Sub
        Private Sub ButtonItemDivisionCopy_From_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivisionCopy_From.Click

            'objects
            Dim SelectedDivisions As IEnumerable = Nothing
            Dim DivisionToCopy As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim DivisionCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Division, True, True, SelectedDivisions) = Windows.Forms.DialogResult.OK Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedDivision In SelectedDivisions

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        DivisionToCopy = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, SelectedDivision.ClientCode, SelectedDivision.Code)

                        If DivisionToCopy IsNot Nothing Then

                            Division = New AdvantageFramework.Database.Entities.Division

                            Division = AdvantageFramework.Database.Procedures.Division.Copy(DivisionToCopy)

                            Division.DbContext = DbContext
                            Division.ClientCode = _ClientCode

                            If (From Entity In DbContext.Divisions
                                Where Entity.Code.ToUpper = Division.Code.ToUpper AndAlso
                                        Entity.ClientCode.ToUpper = Division.ClientCode.ToUpper).Any Then

                                DivisionCode = Division.Code

                                Do While ValidCode = False

                                    DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Division Code", "Please enter a unique code for: " & vbCrLf & Division.ToString, DivisionCode, DivisionCode, AdvantageFramework.Database.Entities.Division.Properties.Code)

                                    If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                        Exit Do

                                    Else

                                        If (From Entity In DbContext.Divisions
                                            Where Entity.Code.ToUpper = DivisionCode.ToUpper AndAlso
                                                  Entity.ClientCode.ToUpper = Division.ClientCode.ToUpper).Any = False Then

                                            Division.Code = DivisionCode
                                            ValidCode = True

                                        End If

                                    End If

                                Loop

                            Else

                                ValidCode = True

                            End If

                            If ValidCode Then

                                Try

                                    AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division)

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End Using

                LoadDivisionTab()

            End If

        End Sub
        Private Sub ButtonItemDivisionCopy_To_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDivisionCopy_To.Click

            'objects
            Dim SelectedClients As IEnumerable = Nothing
            Dim DivisionToCopy As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim DivisionCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso _ClientCode IsNot Nothing Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Client, True, True, SelectedClients, LimitToNewBusinessClients:=Me.IsCRMUser) = Windows.Forms.DialogResult.OK Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                        DivisionToCopy = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, DivisionCode)

                        If DivisionToCopy IsNot Nothing Then

                            For Each SelectedClient In SelectedClients

                                Division = New AdvantageFramework.Database.Entities.Division

                                Division = AdvantageFramework.Database.Procedures.Division.Copy(DivisionToCopy)

                                Division.DbContext = DbContext
                                Division.ClientCode = SelectedClient.Code

                                If (From Entity In DbContext.Divisions
                                    Where Entity.Code.ToUpper = Division.Code.ToUpper AndAlso
                                          Entity.ClientCode.ToUpper = Division.ClientCode.ToUpper).Any Then

                                    DivisionCode = Division.Code

                                    Do While ValidCode = False

                                        DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Division Code", "Please enter a unique code for: " & vbCrLf & Division.ToString, DivisionCode, DivisionCode, AdvantageFramework.Database.Entities.Division.Properties.Code)

                                        If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                            Exit Do

                                        Else

                                            If (From Entity In DbContext.Divisions
                                                Where Entity.Code.ToUpper = DivisionCode.ToUpper AndAlso
                                                      Entity.ClientCode.ToUpper = Division.ClientCode.ToUpper).Any = False Then

                                                Division.Code = DivisionCode
                                                ValidCode = True

                                            End If

                                        End If

                                    Loop

                                Else

                                    ValidCode = True

                                End If

                                If ValidCode Then

                                    Try

                                        AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division)

                                    Catch ex As Exception

                                    End Try

                                End If

                            Next

                        End If

                    End Using

                    LoadDivisionTab()

                End If

            End If

        End Sub
        Private Sub ButtonItemProductCopy_To_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemProductCopy_To.Click

            'objects
            Dim SelectedDivisions As IEnumerable = Nothing
            Dim ProductToCopy As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_Products.HasOnlyOneSelectedRow Then

                DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue
                ProductCode = DataGridViewRightSection_Products.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Division, True, True, SelectedDivisions, LimitToNewBusinessClients:=Me.IsCRMUser) = Windows.Forms.DialogResult.OK Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        ProductToCopy = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, DivisionCode, ProductCode)

                        If ProductToCopy IsNot Nothing Then

                            For Each SelectedDivision In SelectedDivisions

                                Product = New AdvantageFramework.Database.Entities.Product

                                Product = AdvantageFramework.Database.Procedures.Product.Copy(ProductToCopy)

                                Product.DbContext = DbContext
                                Product.ClientCode = SelectedDivision.ClientCode
                                Product.DivisionCode = SelectedDivision.Code

                                If (From Entity In DbContext.Products
                                    Where Entity.Code.ToUpper = Product.Code.ToUpper AndAlso
                                          Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper AndAlso
                                          Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper).Any Then

                                    ProductCode = Product.Code

                                    Do While ValidCode = False

                                        DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Product Code", "Please enter a unique code for: " & vbCrLf & Product.ToString, ProductCode, ProductCode, AdvantageFramework.Database.Entities.Product.Properties.Code)

                                        If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                            Exit Do

                                        Else

                                            If (From Entity In DbContext.Products
                                                Where Entity.Code.ToUpper = ProductCode.ToUpper AndAlso
                                                      Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                                      Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any = False Then

                                                Product.Code = ProductCode
                                                ValidCode = True

                                            End If

                                        End If

                                    Loop

                                Else

                                    ValidCode = True

                                End If

                                If ValidCode Then

                                    Try

                                        If AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product) Then

                                            CopyCompanyProfile(DbContext, ProductToCopy, Product)

                                            CopyProductMediaOverrides(DbContext, ProductToCopy, Product)

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If

                            Next

                        End If

                    End Using

                    LoadDivisionProducts()

                End If

            End If

        End Sub
        Private Sub ButtonLeftSection_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLeftSection_Edit.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso _ClientCode IsNot Nothing Then

                ClientCode = _ClientCode
                DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode)

                LoadDivisionTab()

                DataGridViewLeftSection_Divisions.SelectRow(0, ClientCode & "|" & DivisionCode)

            End If

        End Sub
        Private Sub ButtonLeftsection_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLeftSection_Add.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If _ClientCode IsNot Nothing Then

                ClientCode = _ClientCode

                If AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode) = System.Windows.Forms.DialogResult.OK Then

                    LoadDivisionTab()

                    DataGridViewLeftSection_Divisions.SelectRow(0, ClientCode & "|" & DivisionCode)

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_Edit.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_Products.HasOnlyOneSelectedRow Then

                ClientCode = _ClientCode
                DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue
                ProductCode = DataGridViewRightSection_Products.GetFirstSelectedRowBookmarkValue

                AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode, ProductCode)

                LoadDivisionProducts()

                DataGridViewRightSection_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

            End If

        End Sub
        Private Sub ButtonRightSection_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_Add.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow Then

                ClientCode = _ClientCode
                DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode, ProductCode) = System.Windows.Forms.DialogResult.OK Then

                    LoadDivisionProducts()

                    DataGridViewRightSection_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

                End If

            End If

        End Sub
        Private Sub ComboBoxTVInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTVInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxTVInvoiceFormat_Type, SearchableComboBoxTVInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxInternetInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxInternetInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxInternetInvoiceFormat_Type, SearchableComboBoxInternetInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxRadioInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRadioInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxRadioInvoiceFormat_Type, SearchableComboBoxRadioInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxMagazineInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxMagazineInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxMagazineInvoiceFormat_Type, SearchableComboBoxMagazineInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxNewspaperInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxNewspaperInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxNewspaperInvoiceFormat_Type, SearchableComboBoxNewspaperInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxOutOfHomeInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxOutOfHomeInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxOutOfHomeInvoiceFormat_Type, SearchableComboBoxOutOfHomeInvoiceFormat_Format)

        End Sub
        Private Sub ComboBoxProductionInvoiceFormat_Type_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxProductionInvoiceFormat_Type.SelectedValueChanged

            InvoiceDefaultHandler(ComboBoxProductionInvoiceFormat_Type, SearchableComboBoxProductionInvoiceFormat_Format)

        End Sub
        Private Sub ButtonItemRefreshBilling_Address_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRefreshBilling_Address.Click

            UpdateAddressFields(AddressControlLeftColumn_Address, AddressControlLeftColumn_BillingAddress)

        End Sub
        Private Sub ButtonItemRefreshStatement_Address_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRefreshStatement_Address.Click

            UpdateAddressFields(AddressControlLeftColumn_Address, AddressControlRightColumn_StatementAddress)

        End Sub
        Private Sub ButtonItemRefreshStatement_Billing_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRefreshStatement_Billing.Click

            UpdateAddressFields(AddressControlLeftColumn_BillingAddress, AddressControlRightColumn_StatementAddress)

        End Sub
        Private Sub ButtonLeftSection_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonLeftSection_Delete.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            If DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow And _ClientCode IsNot Nothing Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    ClientCode = _ClientCode
                    DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)

                        If Division IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Division.Delete(DbContext, Division) Then

                                LoadDivisionTab()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The division is in use and cannot be deleted.")

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_Delete.Click

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If _ClientCode IsNot Nothing AndAlso DataGridViewLeftSection_Divisions.HasOnlyOneSelectedRow AndAlso DataGridViewRightSection_Products.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    ClientCode = _ClientCode
                    DivisionCode = DataGridViewLeftSection_Divisions.GetFirstSelectedRowBookmarkValue
                    ProductCode = DataGridViewRightSection_Products.GetFirstSelectedRowBookmarkValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                        If Product IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Product.Delete(DbContext, Product) Then

                                LoadDivisionProducts()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The product is in use and cannot be deleted.")

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub CheckBoxNewClientOptions_Duplicate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxNewClientOptions_DuplicateForDivision.CheckedChanged, CheckBoxNewClientOptions_DuplicateForProduct.CheckedChanged

            If TypeOf sender Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox Then

                DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).HandleAllControls()

            End If

            If sender Is CheckBoxNewClientOptions_DuplicateForProduct Then

                SearchableComboBoxNewClientOptions_Office.SetRequired(CheckBoxNewClientOptions_DuplicateForProduct.Checked)

                If CheckBoxNewClientOptions_DuplicateForProduct.Checked = False Then

                    If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(SearchableComboBoxNewClientOptions_Office)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewWebsites_Websites_AddNewRowEvent(RowObject As Object) Handles DataGridViewWebsites_Websites.AddNewRowEvent

            'objects
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
            Dim ClientWebsites As Generic.List(Of Object) = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientWebsite Then

                Me.ShowWaitForm("Processing...")

                ClientWebsite = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ClientWebsite.IsEntityBeingAdded() Then

                        If _ClientCode IsNot Nothing AndAlso _ClientCode <> "" Then

                            ClientWebsite.DbContext = DbContext

                            ClientWebsite.ClientCode = _ClientCode

                            If AdvantageFramework.Database.Procedures.ClientWebsite.Insert(DbContext, ClientWebsite) Then

                                LoadWebsitesTab()

                            End If

                        Else

                            If _ClientWebsiteList.Where(Function(ClWebsite) ClWebsite.WebsiteTypeCode = ClientWebsite.WebsiteTypeCode).Any = False Then

                                _ClientWebsiteList.Add(ClientWebsite)

                            End If

                            LoadWebsitesTab()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewWebsites_Websites_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewWebsites_Websites.CellValueChangingEvent

            'objects
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
            Dim RefreshClientWebsites As Boolean = False
            Dim RowType As Object = Nothing

            If _ClientCode IsNot Nothing AndAlso _ClientCode <> "" Then

                If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.ClientWebsite.Properties.IsInactive.ToString Then

                    Try

                        ClientWebsite = DataGridViewWebsites_Websites.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ClientWebsite = Nothing
                    End Try

                    If ClientWebsite IsNot Nothing Then

                        Try

                            ClientWebsite.IsInactive = Convert.ToBoolean(e.Value)

                        Catch ex As Exception
                            ClientWebsite.IsInactive = ClientWebsite.IsInactive
                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ClientWebsite.Update(DbContext, ClientWebsite) = False Then

                                    RefreshClientWebsites = True

                                Else

                                    DataGridViewWebsites_Websites.CurrentView.RefreshData()

                                End If

                                DbContext.UndoChanges(ClientWebsite)

                            End Using

                        Catch ex As Exception

                        End Try

                        AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    End If

                    If RefreshClientWebsites Then

                        LoadWebsitesTab()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewWebsites_Websites_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewWebsites_Websites.EmbeddedNavigatorButtonClick

            Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                    CancelAddNewClientWebsite()

                    e.Handled = True

                Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                    DeleteSelectedClientWebsite()

                    e.Handled = True

            End Select

        End Sub
        Private Sub DataGridViewWebsites_Websites_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewWebsites_Websites.InitNewRowEvent

            If _ClientCode IsNot Nothing AndAlso _ClientCode <> "" Then

                DataGridViewWebsites_Websites.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.ClientWebsite.Properties.ClientCode.ToString, _ClientCode)

            End If

            RaiseEvent AddClientWebsiteInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewWebsites_Websites_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewWebsites_Websites.SelectionChangedEvent

            If DataGridViewWebsites_Websites.CustomDeleteButton IsNot Nothing Then

                DataGridViewWebsites_Websites.CustomDeleteButton.Enabled = Not DataGridViewWebsites_Websites.CurrentView.IsNewItemRow(DataGridViewWebsites_Websites.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent ClientWebsiteSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DocumentManagerControlDocuments_ClientDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_ClientDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub TextBoxARComment_ARComment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxARComment_ARComment.GotFocus

            RaiseEvent ARCommentGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxARComment_ARComment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxARComment_ARComment.LostFocus

            RaiseEvent ARCommentLostFocusEvent(sender, e)

        End Sub
        Private Sub DataGridViewTopRightColumn_ClientSortKeys_AddNewRowEvent(RowObject As Object) Handles DataGridViewTopRightColumn_ClientSortKeys.AddNewRowEvent

            'objects
            Dim ClientSortKey As AdvantageFramework.Database.Entities.ClientSortKey = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ClientSortKey Then

                Me.ShowWaitForm("Processing...")

                ClientSortKey = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ClientSortKey.IsEntityBeingAdded() Then

                        If _ClientCode IsNot Nothing Then

                            ClientSortKey.DbContext = DbContext

                            ClientSortKey.ClientCode = _ClientCode

                            AdvantageFramework.Database.Procedures.ClientSortKey.Insert(DbContext, ClientSortKey)

                        Else

                            If _SortKeyList.Where(Function(ClSrtKey) ClientSortKey.SortKey = ClientSortKey.SortKey).Any = False Then

                                _SortKeyList.Add(ClientSortKey)

                            End If

                        End If

                    End If

                End Using

                LoadSortKeys()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewTopRightColumn_ClientSortKeys_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTopRightColumn_ClientSortKeys.DataSourceChangedEvent, DataGridViewTopRightColumn_ClientSortKeys.Resize

            If DataGridViewTopRightColumn_ClientSortKeys.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewTopRightColumn_ClientSortKeys.CurrentView.VisibleColumns(0).Width = DataGridViewTopRightColumn_ClientSortKeys.Width - 35

            End If

        End Sub
        Private Sub DataGridViewTopRightColumn_ClientSortKeys_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewTopRightColumn_ClientSortKeys.InitNewRowEvent

            DataGridViewClientSortKeys.CurrentView.SetRowCellValue(DataGridViewClientSortKeys.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ClientSortKey.Properties.ClientCode.ToString, _ClientCode)

            RaiseEvent ClientSortKeysInitNewRowEvent()

        End Sub
        Private Sub DataGridViewTopRightColumn_ClientSortKeys_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewTopRightColumn_ClientSortKeys.SelectionChangedEvent

            RaiseEvent ClientSortKeysSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewTopRightColumn_ClientSortKeys_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewTopRightColumn_ClientSortKeys.ShowingEditorEvent

            If DataGridViewTopRightColumn_ClientSortKeys.CurrentView.IsNewItemRow(DataGridViewTopRightColumn_ClientSortKeys.CurrentView.FocusedRowHandle) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub CheckBoxRightColumn_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxRightColumn_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If Me.CanUserUpdate Then

                    RaiseEvent InactiveChangedEvent(CheckBoxRightColumn_Inactive.Checked, e.Cancel)

                Else

                    e.Cancel = True

                End If

                If e.Cancel Then

                    CheckBoxRightColumn_Inactive.Checked = Not CheckBoxRightColumn_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxLatePaymentFee_Calculate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLatePaymentFee_Calculate.CheckedChanged

            NumericInputLatePaymentFee_Percentage.SetRequired(CheckBoxLatePaymentFee_Calculate.Checked)
            NumericInputLatePaymentFee_Percentage.Enabled = CheckBoxLatePaymentFee_Calculate.Checked

        End Sub
        Private Sub CheckBoxLatePaymentFee_Calculate_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxLatePaymentFee_Calculate.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso e.NewChecked.Checked AndAlso ProductLateFeeProcessingExists() Then

                AdvantageFramework.WinForm.MessageBox.Show(LATE_FEE_MESSAGE)

                NumericInputLatePaymentFee_Percentage.EditValue = Nothing

                e.NewChecked.Checked = False

                e.Cancel = True

            ElseIf e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso Not e.NewChecked.Checked Then

                NumericInputLatePaymentFee_Percentage.EditValue = Nothing

            End If

        End Sub
        Private Sub SearchableComboBoxAutomatedAssignments_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxAutomatedAssignments_Job.EditValueChanged

            'objects
            Dim JobNumber As Integer = 0
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            If SearchableComboBoxAutomatedAssignments_Job.GetSelectedValue IsNot Nothing Then

                SearchableComboBoxAutomatedAssignments_JobComponent.SelectedValue = Nothing
                SearchableComboBoxAutomatedAssignments_JobComponent.SetRequired(True)
                SearchableComboBoxAutomatedAssignments_JobComponent.Enabled = True

                JobNumber = SearchableComboBoxAutomatedAssignments_Job.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobComponents = AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext).Where(Function(Entity) Entity.JobNumber = JobNumber).ToList

                    SearchableComboBoxAutomatedAssignments_JobComponent.DataSource = JobComponents

                End Using

                If JobComponents.Count = 1 Then

                    SearchableComboBoxAutomatedAssignments_JobComponent.SelectedValue = JobComponents(0).JobComponentNumber

                End If

            Else

                SearchableComboBoxAutomatedAssignments_JobComponent.SelectedValue = Nothing
                SearchableComboBoxAutomatedAssignments_JobComponent.SetRequired(False)
                SearchableComboBoxAutomatedAssignments_JobComponent.Enabled = False

            End If

        End Sub
        Private Sub CheckBoxMediaIntegrationSettings_EnableDoubleClick_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxMediaIntegrationSettings_EnableDoubleClick.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso Me.Save Then

                If e.NewChecked.Checked Then

                    AuthorizeGoogleServices()

                Else

                    DeauthorizeGoogleServices()

                End If

                RaiseEvent ClearChangedEvent()

            End If

        End Sub
        Private Sub NumericInputDoubleClick_ProfileID_TextChanged(sender As Object, e As EventArgs) Handles NumericInputDoubleClick_ProfileID.TextChanged

            CheckBoxMediaIntegrationSettings_EnableDoubleClick.Checked = False

        End Sub
        Private Sub SearchableComboBoxGeneral_QuickBooksCustomer_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneral_QuickBooksCustomer.EditValueChanged

            If SearchableComboBoxGeneral_QuickBooksCustomer.HasASelectedValue AndAlso _IsLoading = False Then

                If AdvantageFramework.WinForm.MessageBox.Show("Load from QuickBooks?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                    RefreshQuickbooksCustomer()

                Else

                    RefreshQuickBooksCustomers()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxGeneral_QuickBooksCustomer_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBoxGeneral_QuickBooksCustomer.QueryPopUp

            Dim Customers As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Customer) = Nothing
            Dim ErrorMessage As String = Nothing

            If SearchableComboBoxGeneral_QuickBooksCustomer.HasASelectedValue = False Then

                If AdvantageFramework.Quickbooks.GetUnMappedCustomers(_Session, Customers, ErrorMessage) Then

                    SearchableComboBoxGeneral_QuickBooksCustomer.DataSource = Customers

                ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
