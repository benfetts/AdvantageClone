Namespace WinForm.Presentation.Controls

    Public Class ProductControl

        Public Event SelectedDocumentChanged()
        Public Event SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event ProductSortKeysInitNewRowEvent()
        Public Event ProductSortKeysSelectionChangedEvent()
        Public Event SelectedDetailChangedEvent()
        Public Event CompanyProfileAffiliationInitNewRowEvent()
        Public Event CompanyProfileAffiliationSelectionChangedEvent()
        Public Event ActivitySummaryCompetitorInitNewRowEvent()
        Public Event ActivitySummaryCompetitorSelectionChangedEvent()
        Public Event ActivitySummaryCRMActivitySelectionChangedEvent()
        Public Event CompanyProfileNotesGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CompanyProfileNotesLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ContractManagerRowCountChanged()
        Public Event ClientContactManagerRowCountChanged()

#Region " Constants "

        Private Const LATE_FEE_MESSAGE As String = "Cannot set late payment fee at product level, client has late payment fee enabled."

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey) = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _SortNameMaxLength As Long = Nothing
        Private _IsCRMUser As Boolean = False
        Private _HasAccessToDocuments As Boolean = False
        Private _CanUserUpdateInClientMaintenance As Boolean = False
        Private _DoesUserHaveAccessToClientContactMaintenance As Boolean = False
        Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DoesUserHaveAccessToClientContactMaintenance() As Boolean
            Get
                DoesUserHaveAccessToClientContactMaintenance = _DoesUserHaveAccessToClientContactMaintenance
            End Get
        End Property
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
                DocumentManager = DocumentManagerControlDocuments_ProductDocuments
            End Get
        End Property
        Public ReadOnly Property ContractManager() As AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl
            Get
                ContractManager = ContractManagerControlContracts_ProductContracts
            End Get
        End Property
        Public ReadOnly Property IsCRMUser() As Boolean
            Get
                IsCRMUser = _IsCRMUser
            End Get
        End Property
        Public ReadOnly Property ActivitySummarySelectedActivitySummaryIsDiaryEntry() As Boolean
            Get
                ActivitySummarySelectedActivitySummaryIsDiaryEntry = ActivitySummaryControlActivitySummary_ActivitySummary.SelectedCRMActivityIsDiaryEntry
            End Get
        End Property
        Public ReadOnly Property ActivitySummarySelectedCRMActivityAlertID() As Integer
            Get
                ActivitySummarySelectedCRMActivityAlertID = ActivitySummaryControlActivitySummary_ActivitySummary.SelectedCRMActivityAlertID
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property CompanyProfileAffiliationsIsNewItemRow As Boolean
            Get
                CompanyProfileAffiliationsIsNewItemRow = CompanyProfileControlCompanyProfile_CompanyProfile.AffiliationsIsNewItemRow
            End Get
        End Property
        Public ReadOnly Property CompanyProfileAffiliationsHasOnlyOneSelectedRow As Boolean
            Get
                CompanyProfileAffiliationsHasOnlyOneSelectedRow = CompanyProfileControlCompanyProfile_CompanyProfile.AffiliationsHasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property ActivitySummaryCompetitorsIsNewItemRow As Boolean
            Get
                ActivitySummaryCompetitorsIsNewItemRow = ActivitySummaryControlActivitySummary_ActivitySummary.CompetitorsIsNewItemRow()
            End Get
        End Property
        Public ReadOnly Property ActivitySummaryCompetitorsHasOnlyOneSelectedRow As Boolean
            Get
                ActivitySummaryCompetitorsHasOnlyOneSelectedRow = ActivitySummaryControlActivitySummary_ActivitySummary.CompetitorsHasOnlyOneSelectedRow
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

            Dim EstimateFormatsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Product)

                        _CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
                        _DoesUserHaveAccessToClientContactMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)

                        ButtonRightSection_RemoveAccountExecutive.SecurityEnabled = Me.CanUserUpdateInClientMaintenance
                        ButtonRightSection_AddAccountExecutive.SecurityEnabled = Me.CanUserUpdateInClientMaintenance

                        If Me.CanUserUpdateInClientMaintenance Then

                            DataGridViewRightColumn_SortOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                        Else

                            DataGridViewRightColumn_SortOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Try

                                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Product.Properties.SortName))

                                Catch ex As Exception
                                    _SortNameMaxLength = Nothing
                                End Try

                                CheckBoxGeneral_Inactive.ByPassUserEntryChanged = True

                                TextBoxGeneral_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.Code)
                                TextBoxGeneral_Description.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.Name)

                                AddressControlLeftColumn_BillingAddress.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCity)
                                AddressControlLeftColumn_BillingAddress.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCountry)
                                AddressControlLeftColumn_BillingAddress.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCounty)
                                AddressControlLeftColumn_BillingAddress.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingAddress2)
                                AddressControlLeftColumn_BillingAddress.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingState)
                                AddressControlLeftColumn_BillingAddress.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingAddress)
                                AddressControlLeftColumn_BillingAddress.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingZip)

                                AddressControlRightColumn_StatementAddress.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCity)
                                AddressControlRightColumn_StatementAddress.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCountry)
                                AddressControlRightColumn_StatementAddress.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCounty)
                                AddressControlRightColumn_StatementAddress.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementAddress2)
                                AddressControlRightColumn_StatementAddress.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementState)
                                AddressControlRightColumn_StatementAddress.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementAddress)
                                AddressControlRightColumn_StatementAddress.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementZip)

                                TextBoxOptions_AttentionLine.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.AttentionTo)

                                NumericInputLatePaymentFee_Percentage.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.LateFeePercent)

                                TextBoxBillingContactInformation_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.BillingPhone)
                                TextBoxBillingContactInformation_PhoneExt.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.BillingPhoneExtension)
                                TextBoxBillingContactInformation_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.BillingFax)
                                TextBoxBillingContactInformation_FaxExt.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.BillingFaxExtension)

                                TextBoxStatementContactInformation_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.StatementPhone)
                                TextBoxStatementContactInformation_PhoneExt.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.StatementPhoneExtension)
                                TextBoxStatementContactInformation_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.StatementFax)
                                TextBoxStatementContactInformation_FaxExt.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.StatementFaxExtension)

                                ComboBoxGeneral_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.ClientCode)
                                ComboBoxGeneral_Division.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.DivisionCode)
                                ComboBoxOptions_Office.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.OfficeCode)

                                TextBoxUserDefinedFields_Field1.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField1)
                                TextBoxUserDefinedFields_Field2.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField2)
                                TextBoxUserDefinedFields_Field3.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField3)
                                TextBoxUserDefinedFields_Field4.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField4)

                                ComboBoxProduction_DefaultAlertGroup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.ProductionAlertGroup)
                                ComboBoxProduction_DefaultTaxCode.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.ProductionTaxCode)

                                DataGridViewRightColumn_SortOptions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey))

                                NumericInputProduction_ContingencyPercent.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.ProductionContingency)
                                NumericInputProduction_DefaultMarkupPercent.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.ProductionMarkup)

                                NumericInputBillingOptions_EarlyPayDaysOverride.Properties.MaxLength = 3
                                NumericInputBillingOptions_EarlyPayDaysOverride.Properties.MinValue = 0
                                NumericInputBillingOptions_EarlyPayDaysOverride.Properties.MaxValue = 999

                                NumericInputRadio_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.RadioMarkup)
                                NumericInputRadio_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.RadioRebate)

                                NumericInputTelevision_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.TelevisionMarkup)
                                NumericInputTelevision_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.TelevisionRebate)

                                NumericInputMagazine_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.MagazineMarkup)
                                NumericInputMagazine_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.MagazineRebate)

                                NumericInputNewspaper_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.NewspaperMarkup)
                                NumericInputNewspaper_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.NewspaperRebate)

                                NumericInputInternet_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.InternetMarkup)
                                NumericInputInternet_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.InternetRebate)

                                NumericInputOutOfHome_Markup.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.OutOfHomeMarkup)
                                NumericInputOutOfHome_Rebate.SetPropertySettings(AdvantageFramework.Database.Entities.Product.Properties.OutOfHomeRebate)

                                NumericInputNumberOfDaysToBillInternet_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillInternet_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillInternet_Days.Properties.MaxValue = 999

                                NumericInputNumberOfDaysToBillMagazine_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillMagazine_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillMagazine_Days.Properties.MaxValue = 999

                                NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MaxValue = 999

                                NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MaxValue = 999

                                NumericInputNumberOfDaysToBillRadio_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillRadio_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillRadio_Days.Properties.MaxValue = 999

                                NumericInputNumberOfDaysToBillTelevision_Days.Properties.MaxLength = 3
                                NumericInputNumberOfDaysToBillTelevision_Days.Properties.MinValue = 0
                                NumericInputNumberOfDaysToBillTelevision_Days.Properties.MaxValue = 999

                                _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Security.UserSettings.IsCRMUser)

                                'ComboBoxOptions_Currency.Enabled = False

                                EstimateFormatsList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.EstimateFormatsProduct))

                                ComboBoxProductionEstimateFormat_Type.DataSource = EstimateFormatsList

                                If _IsCRMUser Then

                                    TabItemProductSetup_Production.Visible = False
                                    TabItemProductSetup_BroadcastMedia.Visible = False
                                    TabItemProductSetup_PrintMedia.Visible = False
                                    TabItemProductSetup_OutOfHomeInternetMedia.Visible = False

                                End If

                                CheckBoxProduction_AvalaraTaxExemptOverride.Visible = AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext)

                                ResetDataSources()

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean, ByVal IsDeleting As Boolean) As AdvantageFramework.Database.Entities.Product

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                If IsNew Then

                    Product = New AdvantageFramework.Database.Entities.Product

                    LoadProductEntity(Product, True)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                        If Product IsNot Nothing Then

                            LoadProductEntity(Product, False)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Product = Nothing
            End Try

            FillObject = Product

        End Function
        Private Sub LoadProductEntity(ByVal Product As AdvantageFramework.Database.Entities.Product, ByVal IsNew As Boolean)

            If Product IsNot Nothing Then

                If IsNew = True OrElse TabItemProductSetup_GeneralTab.Tag = True Then

                    SaveGeneralTab(Product, IsNew)

                End If

                If IsNew = True OrElse TabItemProductSetup_Production.Tag = True Then

                    SaveProductionTab(Product)

                End If

                If IsNew = True OrElse TabItemProductSetup_BroadcastMedia.Tag = True Then

                    SaveBroadcastMediaTab(Product)

                End If

                If IsNew = True OrElse TabItemProductSetup_PrintMedia.Tag = True Then

                    SavePrintMediaTab(Product)

                End If

                If IsNew = True OrElse TabItemProductSetup_OutOfHomeInternetMedia.Tag = True Then

                    SaveInternetMediaOutOfHomeTab(Product)

                End If

            End If

        End Sub
        Protected Sub ResetDataSources()

            'objects
            Dim SalesTaxes As Generic.List(Of AdvantageFramework.Database.Entities.SalesTax) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ComboBoxOptions_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                'ComboBoxOptions_Currency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.Load(DbContext)

                SalesTaxes = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                ComboBoxInternet_TaxCode.DataSource = SalesTaxes
                ComboBoxMagazine_TaxCode.DataSource = SalesTaxes
                ComboBoxNewspaper_TaxCode.DataSource = SalesTaxes
                ComboBoxOutOfHome_TaxCode.DataSource = SalesTaxes
                ComboBoxProduction_DefaultTaxCode.DataSource = SalesTaxes
                ComboBoxRadio_TaxCode.DataSource = SalesTaxes
                ComboBoxTelevision_TaxCode.DataSource = SalesTaxes

                ComboBoxProduction_DefaultAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext)

            End Using

        End Sub
        Private Function LoadSelectedProduct() As AdvantageFramework.Database.Entities.Product

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    Catch ex As Exception
                        Product = Nothing
                    End Try

                End Using

            End If

            LoadSelectedProduct = Product

        End Function
        Private Sub LoadProductDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_ProductSetup.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_ProductSetup.SelectedTab

                End If

                If TabItem.Tag = False Then

                    Product = LoadSelectedProduct()

                    If Product IsNot Nothing Then

                        If TabItem Is TabItemProductSetup_GeneralTab OrElse _IsCopy Then

                            LoadGeneralTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_Production OrElse _IsCopy Then

                            LoadProductionTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_BroadcastMedia OrElse _IsCopy Then

                            LoadBroadcastMediaTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_PrintMedia OrElse _IsCopy Then

                            LoadPrintMediaTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_OutOfHomeInternetMedia OrElse _IsCopy Then

                            LoadInternetMediaOutOfHomeTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_CompanyProfileTab OrElse _IsCopy Then

                            LoadCompanyProfileTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_AccountExecutivesTab Then

                            LoadAccountExecutivesTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_DocumentsTab Then

                            LoadDocuments(Product)

                        End If

                        If TabItem Is TabItemProductSetup_ContactsTab Then

                            LoadContactsTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_ContractsTab Then

                            LoadContractsTab(Product)

                        End If

                        If TabItem Is TabItemProductSetup_ActivitySummaryTab Then

                            LoadActivitySummaryTab(Product)

                        End If

                    End If

                ElseIf TabItem.Tag = True AndAlso TabItem Is TabItemProductSetup_ActivitySummaryTab AndAlso CheckBoxGeneral_NewBusiness.Checked Then

                    ActivitySummaryControlActivitySummary_ActivitySummary.RefreshTotalOpportunity()

                End If

            End If

        End Sub
        Private Function GetUpdatedClient() As AdvantageFramework.Database.Entities.Client

            If ComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    GetUpdatedClient = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ComboBoxGeneral_Client.GetSelectedValue)

                End Using

            Else

                GetUpdatedClient = Nothing

            End If

        End Function
        Private Function GetUpdatedDivision() As AdvantageFramework.Database.Entities.Division

            If ComboBoxGeneral_Client.HasASelectedValue AndAlso ComboBoxGeneral_Division.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    GetUpdatedDivision = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ComboBoxGeneral_Client.GetSelectedValue, ComboBoxGeneral_Division.GetSelectedValue)

                End Using

            Else

                GetUpdatedDivision = Nothing

            End If

        End Function
        Private Sub UpdateAddressFields(UpdatedInfo As Object, Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim BillingAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl = Nothing

            If TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Client Then

                Client = UpdatedInfo

                If Address.Name = "AddressControlLeftColumn_BillingAddress" Then

                    Address.Address = Client.BillingAddress
                    Address.Address2 = Client.BillingAddress2
                    Address.City = Client.BillingCity
                    Address.County = Client.BillingCounty
                    Address.State = Client.BillingState
                    Address.Zip = Client.BillingZip
                    Address.Country = Client.BillingCountry

                    Address.Tag = Nothing

                ElseIf Address.Name = "AddressControlRightColumn_StatementAddress" Then

                    Address.Address = Client.StatementAddress
                    Address.Address2 = Client.StatementAddress2
                    Address.City = Client.StatementCity
                    Address.County = Client.StatementCounty
                    Address.State = Client.StatementState
                    Address.Zip = Client.StatementZip
                    Address.Country = Client.StatementCountry

                End If

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Division Then

                Division = UpdatedInfo

                If Address.Name = "AddressControlLeftColumn_BillingAddress" Then

                    Address.Address = Division.BillingAddress
                    Address.Address2 = Division.BillingAddress2
                    Address.City = Division.BillingCity
                    Address.County = Division.BillingCounty
                    Address.State = Division.BillingState
                    Address.Zip = Division.BillingZip
                    Address.Country = Division.BillingCountry

                    Address.Tag = Nothing

                ElseIf Address.Name = "AddressControlRightColumn_StatementAddress" Then

                    Address.Address = Division.Address
                    Address.Address2 = Division.Address2
                    Address.City = Division.City
                    Address.County = Division.County
                    Address.State = Division.State
                    Address.Zip = Division.Zip
                    Address.Country = Division.Country

                End If

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.WinForm.Presentation.Controls.AddressControl Then

                BillingAddress = UpdatedInfo

                Address.Address = BillingAddress.Address
                Address.Address2 = BillingAddress.Address2
                Address.City = BillingAddress.City
                Address.County = BillingAddress.County
                Address.State = BillingAddress.State
                Address.Zip = BillingAddress.Zip
                Address.Country = BillingAddress.Country

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            If Product IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy Then

                        CheckBoxGeneral_Inactive.Checked = False

                    Else

                        CheckBoxGeneral_Inactive.Checked = Not Convert.ToBoolean(Product.IsActive.GetValueOrDefault(0))

                    End If

                    AddressControlLeftColumn_BillingAddress.Address = Product.BillingAddress
                    AddressControlLeftColumn_BillingAddress.Address2 = Product.BillingAddress2
                    AddressControlLeftColumn_BillingAddress.City = Product.BillingCity
                    AddressControlLeftColumn_BillingAddress.County = Product.BillingCounty
                    AddressControlLeftColumn_BillingAddress.State = Product.BillingState
                    AddressControlLeftColumn_BillingAddress.Zip = Product.BillingZip
                    AddressControlLeftColumn_BillingAddress.Country = Product.BillingCountry
                    TextBoxBillingContactInformation_Phone.Text = Product.BillingPhone
                    TextBoxBillingContactInformation_PhoneExt.Text = Product.BillingPhoneExtension
                    TextBoxBillingContactInformation_Fax.Text = Product.BillingFax
                    TextBoxBillingContactInformation_FaxExt.Text = Product.BillingFaxExtension

                    AddressControlRightColumn_StatementAddress.Address = Product.StatementAddress
                    AddressControlRightColumn_StatementAddress.Address2 = Product.StatementAddress2
                    AddressControlRightColumn_StatementAddress.City = Product.StatementCity
                    AddressControlRightColumn_StatementAddress.County = Product.StatementCounty
                    AddressControlRightColumn_StatementAddress.State = Product.StatementState
                    AddressControlRightColumn_StatementAddress.Zip = Product.StatementZip
                    AddressControlRightColumn_StatementAddress.Country = Product.StatementCountry
                    TextBoxStatementContactInformation_Phone.Text = Product.StatementPhone
                    TextBoxStatementContactInformation_PhoneExt.Text = Product.StatementPhoneExtension
                    TextBoxStatementContactInformation_Fax.Text = Product.StatementFax
                    TextBoxStatementContactInformation_FaxExt.Text = Product.StatementFaxExtension

                    TextBoxUserDefinedFields_Field1.Text = Product.UserDefinedField1
                    TextBoxUserDefinedFields_Field2.Text = Product.UserDefinedField2
                    TextBoxUserDefinedFields_Field3.Text = Product.UserDefinedField3
                    TextBoxUserDefinedFields_Field4.Text = Product.UserDefinedField4

                    TextBoxOptions_AttentionLine.Text = Product.AttentionTo

                    CheckBoxLatePaymentFee_Calculate.Checked = Product.CalculateLateFee
                    NumericInputLatePaymentFee_Percentage.EditValue = Product.LateFeePercent
                    NumericInputLatePaymentFee_Percentage.Enabled = Product.CalculateLateFee

                    'If Product.CurrencyCode IsNot Nothing Then
                    '    ComboBoxOptions_Currency.SelectedValue = Product.CurrencyCode
                    'End If

                    If Product.OfficeCode IsNot Nothing Then

                        Try

                            ComboBoxOptions_Office.SelectedValue = Product.OfficeCode

                        Catch ex As Exception
                            ComboBoxOptions_Office.SelectedIndex = 0
                        End Try

                        If ComboBoxOptions_Office.HasASelectedValue = False Then

                            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Product.OfficeCode)

                            If Office IsNot Nothing Then

                                ComboBoxOptions_Office.AddComboItemToExistingDataSource(Office.ToString & "*", Office.Code, False)

                                Try

                                    ComboBoxOptions_Office.SelectedValue = Product.OfficeCode

                                Catch ex As Exception
                                    ComboBoxOptions_Office.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxOptions_Office.SelectedIndex = 0

                    End If

                End Using

                TabItemProductSetup_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadCompanyProfileTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                CompanyProfileControlCompanyProfile_CompanyProfile.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

                TabItemProductSetup_CompanyProfileTab.Tag = True

            End If

        End Sub
        Private Sub LoadContactsTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing AndAlso Not _IsCopy Then

                ClientContactManagerControlContacts_ProductContacts.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

                TabItemProductSetup_ContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadContractsTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing AndAlso Not _IsCopy Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractManagerControlContracts_ProductContracts.LoadControl(Product.ClientCode, Product.DivisionCode, Product.Code) = False Then

                        ContractManagerControlContracts_ProductContracts.Enabled = False
                        ContractManagerControlContracts_ProductContracts.ClearControl()

                    Else

                        ContractManagerControlContracts_ProductContracts.Enabled = True

                    End If

                End Using

                TabItemProductSetup_ContractsTab.Tag = True

            End If

        End Sub
        Private Sub LoadActivitySummaryTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing AndAlso Not _IsCopy Then

                ActivitySummaryControlActivitySummary_ActivitySummary.LoadControl(_ClientCode, _DivisionCode, _ProductCode, CheckBoxGeneral_NewBusiness.Checked)

                TabItemProductSetup_ActivitySummaryTab.Tag = True

            End If

        End Sub
        Private Sub LoadProductionTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing

            If Product IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    NumericInputProduction_ContingencyPercent.EditValue = Product.ProductionContingency
                    NumericInputProduction_DefaultMarkupPercent.EditValue = Product.ProductionMarkup
                    NumericInputProduction_EmployeeTimeBillingRate.EditValue = Product.ProductionEmployeeTimeBillingRate
                    LabelProduction_EmployeeTimeBillableMessage.Visible = CBool(Product.ProductionEmployeeTimeBillable.GetValueOrDefault(0))
                    CheckBoxProduction_UseEstimateBillingRate.CheckValue = Product.ProductionUseEstimateBillingRate.GetValueOrDefault(0)
                    CheckBoxProduction_AvalaraTaxExemptOverride.CheckValue = Product.AvalaraTaxExemptOverride

                    If Product.ProductionTaxCode IsNot Nothing Then

                        Try

                            ComboBoxProduction_DefaultTaxCode.SelectedValue = Product.ProductionTaxCode

                        Catch ex As Exception
                            ComboBoxProduction_DefaultTaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxProduction_DefaultTaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.ProductionTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxProduction_DefaultTaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxProduction_DefaultTaxCode.SelectedValue = Product.ProductionTaxCode

                                Catch ex As Exception
                                    ComboBoxProduction_DefaultTaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxProduction_DefaultTaxCode.SelectedIndex = 0

                    End If

                    If Product.ProductionAlertGroup IsNot Nothing Then

                        Try

                            ComboBoxProduction_DefaultAlertGroup.SelectedValue = Product.ProductionAlertGroup

                        Catch ex As Exception
                            ComboBoxProduction_DefaultAlertGroup.SelectedIndex = 0
                        End Try

                        If ComboBoxProduction_DefaultAlertGroup.HasASelectedValue = False Then

                            Try

                                AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, Product.ProductionAlertGroup).FirstOrDefault

                            Catch ex As Exception

                            End Try

                            If AlertGroup IsNot Nothing Then

                                ComboBoxProduction_DefaultAlertGroup.AddComboItemToExistingDataSource(AlertGroup.ToString & "*", AlertGroup.Code, False)

                                Try

                                    ComboBoxProduction_DefaultAlertGroup.SelectedValue = Product.ProductionAlertGroup

                                Catch ex As Exception
                                    ComboBoxProduction_DefaultAlertGroup.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxProduction_DefaultAlertGroup.SelectedIndex = 0

                    End If

                    'Estimate
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientDivisionProduct(DataContext, Product.ClientCode, Product.DivisionCode, Product.Code)

                        If ProductionEstimateDefault IsNot Nothing Then

                            If ProductionEstimateDefault.UseAgencySetting Then

                                ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.AgencyDefault.ToString.Replace("Agency", "")

                            Else

                                ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.Product.ToString

                            End If

                        Else

                            ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.AgencyDefault.ToString.Replace("Agency", "")

                        End If

                    End Using

                    CheckBoxBillingOptions_AllowVendorDiscounts.CheckValue = Product.ProductionVendorDiscounts.GetValueOrDefault(0)
                    CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValue = Product.ProductionApprovedEstimatedRequired.GetValueOrDefault(0)
                    CheckBoxBillingOptions_BillingSetupComplete.CheckValue = Product.ProductionBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxBillingOptions_BillNet.CheckValue = Product.ProductionBillNet.GetValueOrDefault(0)
                    CheckBoxBillingOptions_ConsolidateFunctions.CheckValue = Product.ProductionConsolidateFunctions.GetValueOrDefault(0)

                    NumericInputBillingOptions_EarlyPayDaysOverride.EditValue = Product.ProductionDaysToPay

                End Using

                TabItemProductSetup_Production.Tag = True

            End If

        End Sub
        Private Sub LoadBroadcastMediaTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If Product IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    NumericInputRadio_Markup.EditValue = Product.RadioMarkup
                    NumericInputRadio_Rebate.EditValue = Product.RadioRebate
                    CheckBoxRadio_BillingSetupComplete.CheckValue = Product.RadioBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxRadio_BillNet.CheckValue = Product.RadioBillNet.GetValueOrDefault(0)
                    CheckBoxRadio_CommissionOnly.CheckValue = Product.RadioCommissionOnly.GetValueOrDefault(0)
                    CheckBoxRadio_VendorDiscounts.CheckValue = Product.RadioVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlRadio_Prebill.Checked = True
                    RadioButtonControlRadio_PostBill.Checked = If(Product.RadioPrePostBill = 2, True, False)

                    If Product.RadioDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillRadio_Days.EditValue = Product.RadioDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Checked = If(Product.RadioBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Checked = If(Product.RadioBillSetting = 3, True, False)

                    If Product.RadioTaxCode IsNot Nothing Then

                        Try

                            ComboBoxRadio_TaxCode.SelectedValue = Product.RadioTaxCode

                        Catch ex As Exception
                            ComboBoxRadio_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxRadio_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.RadioTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxRadio_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxRadio_TaxCode.SelectedValue = Product.RadioTaxCode

                                Catch ex As Exception
                                    ComboBoxRadio_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxRadio_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToRadio_UseFlags.CheckValue = Product.RadioApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValue = Product.RadioApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_Commission.CheckValue = Product.RadioApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_LineNet.CheckValue = Product.RadioApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_NetCharge.CheckValue = Product.RadioApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValue = Product.RadioApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToRadio_Rebate.CheckValue = Product.RadioApplyTaxRebate.GetValueOrDefault(0)

                    NumericInputTelevision_Markup.EditValue = Product.TelevisionMarkup
                    NumericInputTelevision_Rebate.EditValue = Product.TelevisionRebate
                    CheckBoxTelevision_BillingSetupComplete.CheckValue = Product.TelevisionBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxTelevision_BillNet.CheckValue = Product.TelevisionBillNet.GetValueOrDefault(0)
                    CheckBoxTelevision_CommissionOnly.CheckValue = Product.TelevisionCommissionOnly.GetValueOrDefault(0)
                    CheckBoxTelevision_VendorDiscounts.CheckValue = Product.TelevisionVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlTelevision_Prebill.Checked = True
                    RadioButtonControlTelevision_PostBill.Checked = If(Product.TelevisionPrePostBill = 2, True, False)

                    If Product.TelevisionDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillTelevision_Days.EditValue = Product.TelevisionDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Checked = If(Product.TelevisionBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Checked = If(Product.TelevisionBillSetting = 3, True, False)

                    If Product.TelevisionTaxCode IsNot Nothing Then

                        Try

                            ComboBoxTelevision_TaxCode.SelectedValue = Product.TelevisionTaxCode

                        Catch ex As Exception
                            ComboBoxTelevision_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxTelevision_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.TelevisionTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxTelevision_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxTelevision_TaxCode.SelectedValue = Product.TelevisionTaxCode

                                Catch ex As Exception
                                    ComboBoxTelevision_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxTelevision_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValue = Product.TelevisionApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValue = Product.TelevisionApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_Commission.CheckValue = Product.TelevisionApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_LineNet.CheckValue = Product.TelevisionApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValue = Product.TelevisionApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValue = Product.TelevisionApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToTelevision_Rebate.CheckValue = Product.TelevisionApplyTaxRebate.GetValueOrDefault(0)

                End Using

                TabItemProductSetup_BroadcastMedia.Tag = True

            End If

        End Sub
        Private Sub LoadPrintMediaTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If Product IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    NumericInputMagazine_Markup.EditValue = Product.MagazineMarkup
                    NumericInputMagazine_Rebate.EditValue = Product.MagazineRebate
                    CheckBoxMagazine_BillingSetupComplete.CheckValue = Product.MagazineBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxMagazine_BillNet.CheckValue = Product.MagazineBillNet.GetValueOrDefault(0)
                    CheckBoxMagazine_CommissionOnly.CheckValue = Product.MagazineCommissionOnly.GetValueOrDefault(0)
                    CheckBoxMagazine_VendorDiscounts.CheckValue = Product.MagazineVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlMagazine_Prebill.Checked = True
                    RadioButtonControlMagazine_PostBill.Checked = If(Product.MagazinePrePostBill = 2, True, False)

                    If Product.MagazineDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillMagazine_Days.EditValue = Product.MagazineDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Checked = If(Product.MagazineBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Checked = If(Product.MagazineBillSetting = 3, True, False)

                    If Product.MagazineTaxCode IsNot Nothing Then

                        Try

                            ComboBoxMagazine_TaxCode.SelectedValue = Product.MagazineTaxCode

                        Catch ex As Exception
                            ComboBoxMagazine_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxMagazine_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.MagazineTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxMagazine_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxMagazine_TaxCode.SelectedValue = Product.MagazineTaxCode

                                Catch ex As Exception
                                    ComboBoxMagazine_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxMagazine_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValue = Product.MagazineApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValue = Product.MagazineApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_Commission.CheckValue = Product.MagazineApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_LineNet.CheckValue = Product.MagazineApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValue = Product.MagazineApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValue = Product.MagazineApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToMagazine_Rebate.CheckValue = Product.MagazineApplyTaxRebate.GetValueOrDefault(0)

                    NumericInputNewspaper_Markup.EditValue = Product.NewspaperMarkup
                    NumericInputNewspaper_Rebate.EditValue = Product.NewspaperRebate
                    CheckBoxNewspaper_BillingSetupComplete.CheckValue = Product.NewspaperBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxNewspaper_BillNet.CheckValue = Product.NewspaperBillNet.GetValueOrDefault(0)
                    CheckBoxNewspaper_CommissionOnly.CheckValue = Product.NewspaperCommissionOnly.GetValueOrDefault(0)
                    CheckBoxNewspaper_VendorDiscounts.CheckValue = Product.NewspaperVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlNewspaper_Prebill.Checked = True
                    RadioButtonControlNewspaper_PostBill.Checked = If(Product.NewspaperPrePostBill = 2, True, False)

                    If Product.NewspaperDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillNewspaper_Days.EditValue = Product.NewspaperDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Checked = If(Product.NewspaperBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Checked = If(Product.NewspaperBillSetting = 3, True, False)

                    If Product.NewspaperTaxCode IsNot Nothing Then

                        Try

                            ComboBoxNewspaper_TaxCode.SelectedValue = Product.NewspaperTaxCode

                        Catch ex As Exception
                            ComboBoxNewspaper_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxNewspaper_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.NewspaperTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxNewspaper_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxNewspaper_TaxCode.SelectedValue = Product.NewspaperTaxCode

                                Catch ex As Exception
                                    ComboBoxNewspaper_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxNewspaper_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValue = Product.NewspaperApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValue = Product.NewspaperApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_Commission.CheckValue = Product.NewspaperApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValue = Product.NewspaperApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValue = Product.NewspaperApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValue = Product.NewspaperApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValue = Product.NewspaperApplyTaxRebate.GetValueOrDefault(0)

                End Using

                TabItemProductSetup_PrintMedia.Tag = True

            End If

        End Sub
        Private Sub LoadInternetMediaOutOfHomeTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If Product IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    NumericInputOutOfHome_Markup.EditValue = Product.OutOfHomeMarkup
                    NumericInputOutOfHome_Rebate.EditValue = Product.OutOfHomeRebate
                    CheckBoxOutOfHome_BillingSetupComplete.CheckValue = Product.OutOfHomeBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxOutOfHome_BillNet.CheckValue = Product.OutOfHomeBillNet.GetValueOrDefault(0)
                    CheckBoxOutOfHome_CommissionOnly.CheckValue = Product.OutOfHomeCommissionOnly.GetValueOrDefault(0)
                    CheckBoxOutOfHome_VendorDiscounts.CheckValue = Product.OutOfHomeVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlOutOfHome_Prebill.Checked = True
                    RadioButtonControlOutOfHome_PostBill.Checked = If(Product.OutOfHomePrePostBill = 2, True, False)

                    If Product.OutOfHomeDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillOutOfHome_Days.EditValue = Product.OutOfHomeDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Checked = If(Product.OutOfHomeBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Checked = If(Product.OutOfHomeBillSetting = 3, True, False)

                    If Product.OutOfHomeTaxCode IsNot Nothing Then

                        Try

                            ComboBoxOutOfHome_TaxCode.SelectedValue = Product.OutOfHomeTaxCode

                        Catch ex As Exception
                            ComboBoxOutOfHome_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxOutOfHome_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.OutOfHomeTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxOutOfHome_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxOutOfHome_TaxCode.SelectedValue = Product.OutOfHomeTaxCode

                                Catch ex As Exception
                                    ComboBoxOutOfHome_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxOutOfHome_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValue = Product.OutOfHomeApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValue = Product.OutOfHomeApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValue = Product.OutOfHomeApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValue = Product.OutOfHomeApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValue = Product.OutOfHomeApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValue = Product.OutOfHomeApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValue = Product.OutOfHomeApplyTaxRebate.GetValueOrDefault(0)

                    NumericInputInternet_Markup.EditValue = Product.InternetMarkup
                    NumericInputInternet_Rebate.EditValue = Product.InternetRebate
                    CheckBoxInternet_BillingSetupComplete.CheckValue = Product.InternetBillingSetupComplete.GetValueOrDefault(0)
                    CheckBoxInternet_BillNet.CheckValue = Product.InternetBillNet.GetValueOrDefault(0)
                    CheckBoxInternet_CommissionOnly.CheckValue = Product.InternetCommissionOnly.GetValueOrDefault(0)
                    CheckBoxInternet_VendorDiscounts.CheckValue = Product.InternetVendorDiscounts.GetValueOrDefault(0)
                    RadioButtonControlInternet_Prebill.Checked = True
                    RadioButtonControlInternet_PostBill.Checked = If(Product.InternetPrePostBill = 2, True, False)

                    If Product.InternetDaysToBill IsNot Nothing Then
                        NumericInputNumberOfDaysToBillInternet_Days.EditValue = Product.InternetDaysToBill
                    End If

                    RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Checked = True
                    RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Checked = If(Product.InternetBillSetting = 2, True, False)
                    RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Checked = If(Product.InternetBillSetting = 3, True, False)

                    If Product.InternetTaxCode IsNot Nothing Then

                        Try

                            ComboBoxInternet_TaxCode.SelectedValue = Product.InternetTaxCode

                        Catch ex As Exception
                            ComboBoxInternet_TaxCode.SelectedIndex = 0
                        End Try

                        If ComboBoxInternet_TaxCode.HasASelectedValue = False Then

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, Product.InternetTaxCode)

                            If SalesTax IsNot Nothing Then

                                ComboBoxInternet_TaxCode.AddComboItemToExistingDataSource(SalesTax.ToString & "*", SalesTax.TaxCode, False)

                                Try

                                    ComboBoxInternet_TaxCode.SelectedValue = Product.InternetTaxCode

                                Catch ex As Exception
                                    ComboBoxInternet_TaxCode.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxInternet_TaxCode.SelectedIndex = 0

                    End If

                    CheckBoxApplySalesTaxToInternet_UseFlags.CheckValue = Product.InternetApplyTaxUseFlags.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValue = Product.InternetApplyTaxAddlCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_Commission.CheckValue = Product.InternetApplyTaxCommission.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_LineNet.CheckValue = Product.InternetApplyTaxLineNet.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_NetCharge.CheckValue = Product.InternetApplyTaxNetCharge.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValue = Product.InternetApplyTaxNetDiscount.GetValueOrDefault(0)
                    CheckBoxApplySalesTaxToInternet_Rebate.CheckValue = Product.InternetApplyTaxRebate.GetValueOrDefault(0)

                End Using

                TabItemProductSetup_OutOfHomeInternetMedia.Tag = True

            End If

        End Sub
        Private Sub SaveGeneralTab(ByVal Product As AdvantageFramework.Database.Entities.Product, IsNew As Boolean)

            If Product IsNot Nothing Then

                Product.Code = TextBoxGeneral_Code.Text
                Product.Name = TextBoxGeneral_Description.Text
                Product.ClientCode = ComboBoxGeneral_Client.GetSelectedValue
                Product.DivisionCode = ComboBoxGeneral_Division.GetSelectedValue

                Product.IsActive = If(CheckBoxGeneral_Inactive.Checked, 0, 1)

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlLeftColumn_BillingAddress, AddressTypeToValidate.Billing)

                    End If

                End Using

                Product.BillingAddress = AddressControlLeftColumn_BillingAddress.Address
                Product.BillingAddress2 = AddressControlLeftColumn_BillingAddress.Address2
                Product.BillingCity = AddressControlLeftColumn_BillingAddress.City
                Product.BillingCounty = AddressControlLeftColumn_BillingAddress.County
                Product.BillingState = AddressControlLeftColumn_BillingAddress.State
                Product.BillingZip = AddressControlLeftColumn_BillingAddress.Zip
                Product.BillingCountry = AddressControlLeftColumn_BillingAddress.Country
                Product.BillingPhone = TextBoxBillingContactInformation_Phone.GetText
                Product.BillingPhoneExtension = TextBoxBillingContactInformation_PhoneExt.GetText
                Product.BillingFax = TextBoxBillingContactInformation_Fax.GetText
                Product.BillingFaxExtension = TextBoxBillingContactInformation_FaxExt.GetText

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                        AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlRightColumn_StatementAddress, AddressTypeToValidate.Statement)

                    End If

                End Using

                Product.StatementAddress = AddressControlRightColumn_StatementAddress.Address
                Product.StatementAddress2 = AddressControlRightColumn_StatementAddress.Address2
                Product.StatementCity = AddressControlRightColumn_StatementAddress.City
                Product.StatementCounty = AddressControlRightColumn_StatementAddress.County
                Product.StatementState = AddressControlRightColumn_StatementAddress.State
                Product.StatementZip = AddressControlRightColumn_StatementAddress.Zip
                Product.StatementCountry = AddressControlRightColumn_StatementAddress.Country
                Product.StatementPhone = TextBoxStatementContactInformation_Phone.GetText
                Product.StatementPhoneExtension = TextBoxStatementContactInformation_PhoneExt.GetText
                Product.StatementFax = TextBoxStatementContactInformation_Fax.GetText
                Product.StatementFaxExtension = TextBoxStatementContactInformation_FaxExt.GetText

                Product.UserDefinedField1 = TextBoxUserDefinedFields_Field1.GetText
                Product.UserDefinedField2 = TextBoxUserDefinedFields_Field2.GetText
                Product.UserDefinedField3 = TextBoxUserDefinedFields_Field3.GetText
                Product.UserDefinedField4 = TextBoxUserDefinedFields_Field4.GetText

                If Product.Name.Length > _SortNameMaxLength Then

                    Product.SortName = Product.Name.Substring(0, _SortNameMaxLength)

                Else

                    Product.SortName = Product.Name

                End If

                Product.AttentionTo = TextBoxOptions_AttentionLine.GetText

                'Product.CurrencyCode = ComboBoxOptions_Currency.GetSelectedValue

                Product.OfficeCode = ComboBoxOptions_Office.GetSelectedValue

                If Not IsNew AndAlso ClientLateFeeProcessingExists() Then

                    AdvantageFramework.WinForm.MessageBox.Show(LATE_FEE_MESSAGE)

                    NumericInputLatePaymentFee_Percentage.EditValue = Nothing
                    CheckBoxLatePaymentFee_Calculate.Checked = False

                End If

                Product.CalculateLateFee = CheckBoxLatePaymentFee_Calculate.Checked
                Product.LateFeePercent = NumericInputLatePaymentFee_Percentage.GetValue

            End If

        End Sub
        Private Sub SaveProductionTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                Product.ProductionContingency = Convert.ToDecimal(NumericInputProduction_ContingencyPercent.EditValue)
                Product.ProductionMarkup = Convert.ToDecimal(NumericInputProduction_DefaultMarkupPercent.EditValue)
                Product.ProductionUseEstimateBillingRate = Convert.ToInt16(CheckBoxProduction_UseEstimateBillingRate.CheckValue)
                Product.AvalaraTaxExemptOverride = CheckBoxProduction_AvalaraTaxExemptOverride.CheckValue
                Product.ProductionTaxCode = ComboBoxProduction_DefaultTaxCode.GetSelectedValue
                Product.ProductionAlertGroup = ComboBoxProduction_DefaultAlertGroup.GetSelectedValue

                Product.ProductionVendorDiscounts = Convert.ToInt16(CheckBoxBillingOptions_AllowVendorDiscounts.CheckValue)
                Product.ProductionApprovedEstimatedRequired = Convert.ToInt16(CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValue)
                Product.ProductionBillingSetupComplete = Convert.ToInt16(CheckBoxBillingOptions_BillingSetupComplete.CheckValue)
                Product.ProductionBillNet = Convert.ToInt16(CheckBoxBillingOptions_BillNet.CheckValue)
                Product.ProductionConsolidateFunctions = Convert.ToInt16(CheckBoxBillingOptions_ConsolidateFunctions.CheckValue)

                Product.ProductionDaysToPay = CShort(NumericInputBillingOptions_EarlyPayDaysOverride.EditValue)

            End If

        End Sub
        Private Sub SaveBroadcastMediaTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                'Radio
                Product.RadioMarkup = Convert.ToDecimal(NumericInputRadio_Markup.EditValue)
                Product.RadioRebate = Convert.ToDecimal(NumericInputRadio_Rebate.EditValue)
                Product.RadioBillingSetupComplete = Convert.ToInt16(CheckBoxRadio_BillingSetupComplete.CheckValue)
                Product.RadioBillNet = Convert.ToInt16(CheckBoxRadio_BillNet.CheckValue)
                Product.RadioCommissionOnly = Convert.ToInt16(CheckBoxRadio_CommissionOnly.CheckValue)
                Product.RadioVendorDiscounts = Convert.ToInt16(CheckBoxRadio_VendorDiscounts.CheckValue)

                If RadioButtonControlRadio_Prebill.Checked Then

                    Product.RadioPrePostBill = 1

                Else

                    Product.RadioPrePostBill = 2

                End If

                Product.RadioDaysToBill = CShort(NumericInputNumberOfDaysToBillRadio_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Checked Then

                    Product.RadioBillSetting = 1


                ElseIf RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Checked Then

                    Product.RadioBillSetting = 2

                Else

                    Product.RadioBillSetting = 3

                End If

                Product.RadioTaxCode = ComboBoxRadio_TaxCode.GetSelectedValue

                Product.RadioApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_UseFlags.CheckValue)
                Product.RadioApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValue)
                Product.RadioApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_Commission.CheckValue)
                Product.RadioApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_LineNet.CheckValue)
                Product.RadioApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_NetCharge.CheckValue)
                Product.RadioApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValue)
                Product.RadioApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToRadio_Rebate.CheckValue)

                'Television
                Product.TelevisionMarkup = Convert.ToDecimal(NumericInputTelevision_Markup.EditValue)
                Product.TelevisionRebate = Convert.ToDecimal(NumericInputTelevision_Rebate.EditValue)
                Product.TelevisionBillingSetupComplete = Convert.ToInt16(CheckBoxTelevision_BillingSetupComplete.CheckValue)
                Product.TelevisionBillNet = Convert.ToInt16(CheckBoxTelevision_BillNet.CheckValue)
                Product.TelevisionCommissionOnly = Convert.ToInt16(CheckBoxTelevision_CommissionOnly.CheckValue)
                Product.TelevisionVendorDiscounts = Convert.ToInt16(CheckBoxTelevision_VendorDiscounts.CheckValue)

                If RadioButtonControlTelevision_Prebill.Checked Then

                    Product.TelevisionPrePostBill = 1

                Else

                    Product.TelevisionPrePostBill = 2

                End If

                Product.TelevisionDaysToBill = CShort(NumericInputNumberOfDaysToBillTelevision_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Checked Then

                    Product.TelevisionBillSetting = 1

                ElseIf RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Checked Then

                    Product.TelevisionBillSetting = 2

                Else

                    Product.TelevisionBillSetting = 3

                End If

                Product.TelevisionTaxCode = ComboBoxTelevision_TaxCode.GetSelectedValue

                Product.TelevisionApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValue)
                Product.TelevisionApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValue)
                Product.TelevisionApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_Commission.CheckValue)
                Product.TelevisionApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_LineNet.CheckValue)
                Product.TelevisionApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValue)
                Product.TelevisionApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValue)
                Product.TelevisionApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToTelevision_Rebate.CheckValue)

            End If

        End Sub
        Private Sub SavePrintMediaTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                'Magazine
                Product.MagazineMarkup = Convert.ToDecimal(NumericInputMagazine_Markup.EditValue)
                Product.MagazineRebate = Convert.ToDecimal(NumericInputMagazine_Rebate.EditValue)
                Product.MagazineBillingSetupComplete = Convert.ToInt16(CheckBoxMagazine_BillingSetupComplete.CheckValue)
                Product.MagazineBillNet = Convert.ToInt16(CheckBoxMagazine_BillNet.CheckValue)
                Product.MagazineCommissionOnly = Convert.ToInt16(CheckBoxMagazine_CommissionOnly.CheckValue)
                Product.MagazineVendorDiscounts = Convert.ToInt16(CheckBoxMagazine_VendorDiscounts.CheckValue)

                If RadioButtonControlMagazine_Prebill.Checked Then

                    Product.MagazinePrePostBill = 1

                Else

                    Product.MagazinePrePostBill = 2

                End If

                Product.MagazineDaysToBill = CShort(NumericInputNumberOfDaysToBillMagazine_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Checked Then

                    Product.MagazineBillSetting = 1

                ElseIf RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Checked Then

                    Product.MagazineBillSetting = 2

                Else

                    Product.MagazineBillSetting = 3

                End If

                Product.MagazineTaxCode = ComboBoxMagazine_TaxCode.GetSelectedValue

                Product.MagazineApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValue)
                Product.MagazineApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValue)
                Product.MagazineApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_Commission.CheckValue)
                Product.MagazineApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_LineNet.CheckValue)
                Product.MagazineApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValue)
                Product.MagazineApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValue)
                Product.MagazineApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToMagazine_Rebate.CheckValue)

                'Newspaper
                Product.NewspaperMarkup = Convert.ToDecimal(NumericInputNewspaper_Markup.EditValue)
                Product.NewspaperRebate = Convert.ToDecimal(NumericInputNewspaper_Rebate.EditValue)
                Product.NewspaperBillingSetupComplete = Convert.ToInt16(CheckBoxNewspaper_BillingSetupComplete.CheckValue)
                Product.NewspaperBillNet = Convert.ToInt16(CheckBoxNewspaper_BillNet.CheckValue)
                Product.NewspaperCommissionOnly = Convert.ToInt16(CheckBoxNewspaper_CommissionOnly.CheckValue)
                Product.NewspaperVendorDiscounts = Convert.ToInt16(CheckBoxNewspaper_VendorDiscounts.CheckValue)

                If RadioButtonControlNewspaper_Prebill.Checked Then

                    Product.NewspaperPrePostBill = 1

                Else

                    Product.NewspaperPrePostBill = 2

                End If

                Product.NewspaperDaysToBill = CShort(NumericInputNumberOfDaysToBillNewspaper_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Checked Then

                    Product.NewspaperBillSetting = 1

                ElseIf RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Checked Then

                    Product.NewspaperBillSetting = 2

                Else

                    Product.NewspaperBillSetting = 3

                End If

                Product.NewspaperTaxCode = ComboBoxNewspaper_TaxCode.GetSelectedValue

                Product.NewspaperApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValue)
                Product.NewspaperApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValue)
                Product.NewspaperApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_Commission.CheckValue)
                Product.NewspaperApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValue)
                Product.NewspaperApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValue)
                Product.NewspaperApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValue)
                Product.NewspaperApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValue)

            End If

        End Sub
        Private Sub SaveInternetMediaOutOfHomeTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing Then

                'OutOfHome
                Product.OutOfHomeMarkup = Convert.ToDecimal(NumericInputOutOfHome_Markup.EditValue)
                Product.OutOfHomeRebate = Convert.ToDecimal(NumericInputOutOfHome_Rebate.EditValue)
                Product.OutOfHomeBillingSetupComplete = Convert.ToInt16(CheckBoxOutOfHome_BillingSetupComplete.CheckValue)
                Product.OutOfHomeBillNet = Convert.ToInt16(CheckBoxOutOfHome_BillNet.CheckValue)
                Product.OutOfHomeCommissionOnly = Convert.ToInt16(CheckBoxOutOfHome_CommissionOnly.CheckValue)
                Product.OutOfHomeVendorDiscounts = Convert.ToInt16(CheckBoxOutOfHome_VendorDiscounts.CheckValue)

                If RadioButtonControlOutOfHome_Prebill.Checked Then

                    Product.OutOfHomePrePostBill = 1

                Else

                    Product.OutOfHomePrePostBill = 2

                End If

                Product.OutOfHomeDaysToBill = CShort(NumericInputNumberOfDaysToBillOutOfHome_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Checked Then

                    Product.OutOfHomeBillSetting = 1

                ElseIf RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Checked Then

                    Product.OutOfHomeBillSetting = 2

                Else

                    Product.OutOfHomeBillSetting = 3

                End If

                Product.OutOfHomeTaxCode = ComboBoxOutOfHome_TaxCode.GetSelectedValue

                Product.OutOfHomeApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValue)
                Product.OutOfHomeApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValue)
                Product.OutOfHomeApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValue)
                Product.OutOfHomeApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValue)
                Product.OutOfHomeApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValue)
                Product.OutOfHomeApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValue)
                Product.OutOfHomeApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValue)

                'Internet
                Product.InternetMarkup = Convert.ToDecimal(NumericInputInternet_Markup.EditValue)
                Product.InternetRebate = Convert.ToDecimal(NumericInputInternet_Rebate.EditValue)
                Product.InternetBillingSetupComplete = Convert.ToInt16(CheckBoxInternet_BillingSetupComplete.CheckValue)
                Product.InternetBillNet = Convert.ToInt16(CheckBoxInternet_BillNet.CheckValue)
                Product.InternetCommissionOnly = Convert.ToInt16(CheckBoxInternet_CommissionOnly.CheckValue)
                Product.InternetVendorDiscounts = Convert.ToInt16(CheckBoxInternet_VendorDiscounts.CheckValue)

                If RadioButtonControlInternet_Prebill.Checked Then

                    Product.InternetPrePostBill = 1

                Else

                    Product.InternetPrePostBill = 2

                End If

                Product.InternetDaysToBill = CShort(NumericInputNumberOfDaysToBillInternet_Days.EditValue)

                If RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Checked Then

                    Product.InternetBillSetting = 1

                ElseIf RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Checked Then

                    Product.InternetBillSetting = 2

                Else

                    Product.InternetBillSetting = 3

                End If

                Product.InternetTaxCode = ComboBoxInternet_TaxCode.GetSelectedValue

                Product.InternetApplyTaxUseFlags = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_UseFlags.CheckValue)
                Product.InternetApplyTaxAddlCharge = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValue)
                Product.InternetApplyTaxCommission = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_Commission.CheckValue)
                Product.InternetApplyTaxLineNet = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_LineNet.CheckValue)
                Product.InternetApplyTaxNetCharge = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_NetCharge.CheckValue)
                Product.InternetApplyTaxNetDiscount = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValue)
                Product.InternetApplyTaxRebate = Convert.ToInt16(CheckBoxApplySalesTaxToInternet_Rebate.CheckValue)

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddAccountExecutive.Enabled = DataGridViewLeftSection_Employees.HasASelectedRow
            ButtonRightSection_RemoveAccountExecutive.Enabled = DataGridViewRightSection_AccountExecutives.HasASelectedRow

        End Sub
        Private Sub HandleApplyTaxCheckBoxes(ByVal sender As AdvantageFramework.WinForm.Presentation.Controls.CheckBox)

            For Each Checkbox In sender.Parent.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                If Checkbox IsNot sender Then

                    Checkbox.Enabled = sender.Checked

                End If

            Next

        End Sub
        Private Sub LoadSortKeys()

            If String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _SortKeyList = AdvantageFramework.Database.Procedures.ProductSortKey.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                End Using

            End If

            DataGridViewRightColumn_SortOptions.DataSource = _SortKeyList

        End Sub
        Private Sub LoadDivisions()

            Dim ClientCode As String = Nothing

            If ComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientCode = ComboBoxGeneral_Client.GetSelectedValue

                        If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                            CheckBoxGeneral_NewBusiness.Checked = True

                        Else

                            CheckBoxGeneral_NewBusiness.Checked = False

                        End If

                        If _FromMaintenance Then

                            If String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                                ComboBoxGeneral_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.Load(DbContext)
                                                                      Where Division.ClientCode = ClientCode
                                                                      Select Division

                            Else

                                ComboBoxGeneral_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)
                                                                      Where Division.ClientCode = ClientCode
                                                                      Select Division

                            End If

                        Else

                            If String.IsNullOrWhiteSpace(_DivisionCode) = False Then

                                ComboBoxGeneral_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                      Where Division.ClientCode = ClientCode
                                                                      Select Division

                            Else

                                ComboBoxGeneral_Division.DataSource = From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                                      Where Division.ClientCode = ClientCode
                                                                      Select Division

                            End If

                        End If

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadEmployeesAndAccountExecutives()

            Dim AccountExecutives As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            Dim AvailableEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim EmployeeCodes As String() = Nothing
            Dim CoreEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    AccountExecutives = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                    CoreEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(DbContext).ToList

                    EmployeeCodes = (From AccountExec In AccountExecutives
                                     Select AccountExec.EmployeeCode).ToArray

                    Try

                        DataGridViewLeftSection_Employees.DataSource = From Emp In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode)
                                                                       Where EmployeeCodes.Contains(Emp.Code) = False
                                                                       Select Emp

                    Catch ex As Exception
                        DataGridViewLeftSection_Employees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                    End Try

                    Try

                        DataGridViewRightSection_AccountExecutives.DataSource = AccountExecutives _
                                                                                .Select(Function(AcctExec) New AdvantageFramework.Database.Classes.AccountExecutive(AcctExec, (From Emp In CoreEmployees
                                                                                                                                                                               Where Emp.Code = AcctExec.EmployeeCode
                                                                                                                                                                               Select Emp).SingleOrDefault)).ToList

                    Catch ex As Exception
                        DataGridViewRightSection_AccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive)
                    End Try

                    ButtonRightSection_AddAccountExecutive.Enabled = True
                    ButtonRightSection_RemoveAccountExecutive.Enabled = True

                Else

                    DataGridViewLeftSection_Employees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                    DataGridViewRightSection_AccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive)

                End If

                DataGridViewRightSection_AccountExecutives.HideOrShowColumn(AdvantageFramework.Database.Classes.AccountExecutive.Properties.ManagementLevel.ToString, False)
                DataGridViewRightSection_AccountExecutives.HideOrShowColumn(AdvantageFramework.Database.Classes.AccountExecutive.Properties.AccountExecutive.ToString, False)

                DataGridViewLeftSection_Employees.CurrentView.BestFitColumns()
                DataGridViewRightSection_AccountExecutives.CurrentView.BestFitColumns()

                EnableOrDisableActions()

            End Using

        End Sub
        Private Sub LoadAccountExecutivesTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

            If Product IsNot Nothing AndAlso Not _IsCopy Then

                LoadEmployeesAndAccountExecutives()

                TabItemProductSetup_AccountExecutivesTab.Tag = True

            End If

        End Sub
        Private Sub LoadDocuments(ByVal Product As AdvantageFramework.Database.Entities.Product)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If Product IsNot Nothing AndAlso Not _IsCopy Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Product) With {.ClientCode = _ClientCode,
                                                                                                                                                                      .DivisionCode = _DivisionCode,
                                                                                                                                                                      .ProductCode = _ProductCode}

                DocumentManagerControlDocuments_ProductDocuments.ClearControl()

                DocumentManagerControlDocuments_ProductDocuments.Enabled = DocumentManagerControlDocuments_ProductDocuments.LoadControl(Database.Entities.DocumentLevel.Product, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemProductSetup_DocumentsTab.Tag = True

            End If

        End Sub
        Private Function ClientLateFeeProcessingExists() As Boolean

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim LateFeeProcessingExists As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                If Client IsNot Nothing AndAlso Client.CalculateLateFee Then

                    LateFeeProcessingExists = True

                End If

            End Using

            ClientLateFeeProcessingExists = LateFeeProcessingExists

        End Function

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal IsCopy As Boolean, FromMaintenance As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _FromMaintenance Then

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.Load(DbContext)

                        Else

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)

                        End If

                    Else

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                        Else

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)

                        End If

                    End If

                End Using

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    TextBoxGeneral_Code.Enabled = _IsCopy
                    TextBoxGeneral_Code.ReadOnly = Not _IsCopy
                    ComboBoxGeneral_Client.Enabled = _IsCopy
                    ComboBoxGeneral_Division.Enabled = _IsCopy

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If Product IsNot Nothing Then

                        If _IsCopy = False Then

                            TextBoxGeneral_Code.Text = Product.Code
                            TabItemProductSetup_DocumentsTab.Visible = _HasAccessToDocuments
                            TabItemProductSetup_AccountExecutivesTab.Visible = True
                            TabItemProductSetup_ContactsTab.Visible = True
                            TabItemProductSetup_ContractsTab.Visible = True

                        Else

                            TabItemProductSetup_DocumentsTab.Visible = False
                            TabItemProductSetup_AccountExecutivesTab.Visible = False
                            TabItemProductSetup_ContactsTab.Visible = False
                            TabItemProductSetup_ContractsTab.Visible = False

                        End If

                        ComboBoxGeneral_Client.SelectedValue = _ClientCode
                        ComboBoxGeneral_Division.SelectedValue = _DivisionCode

                        TextBoxGeneral_Description.Text = Product.Name

                        LoadSortKeys()

                        LoadProductDetails(Nothing)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The product you are trying to edit does not exist anymore.")

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    UpdateAddressFields(Division, AddressControlLeftColumn_BillingAddress)
                    UpdateAddressFields(Division, AddressControlRightColumn_StatementAddress)

                    ComboBoxGeneral_Client.Enabled = False
                    ComboBoxGeneral_Division.Enabled = False
                    CheckBoxGeneral_Inactive.Checked = False
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Description.Enabled = True
                    TextBoxGeneral_Description.ReadOnly = False
                    ComboBoxGeneral_Client.SelectedValue = _ClientCode
                    ComboBoxGeneral_Division.SelectedValue = _DivisionCode

                    TabItemProductSetup_AccountExecutivesTab.Visible = False
                    TabItemProductSetup_DocumentsTab.Visible = False
                    TabItemProductSetup_ContactsTab.Visible = False
                    TabItemProductSetup_ContractsTab.Visible = False

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    UpdateAddressFields(Client, AddressControlLeftColumn_BillingAddress)
                    UpdateAddressFields(Client, AddressControlRightColumn_StatementAddress)

                    ComboBoxGeneral_Client.Enabled = False
                    ComboBoxGeneral_Division.Enabled = True
                    CheckBoxGeneral_Inactive.Checked = False
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Description.Enabled = True
                    TextBoxGeneral_Description.ReadOnly = False

                    ComboBoxGeneral_Client.SelectedValue = _ClientCode

                    TabItemProductSetup_AccountExecutivesTab.Visible = False
                    TabItemProductSetup_DocumentsTab.Visible = False
                    TabItemProductSetup_ContactsTab.Visible = False
                    TabItemProductSetup_ContractsTab.Visible = False

                Else

                    ComboBoxGeneral_Client.Enabled = True
                    ComboBoxGeneral_Division.Enabled = True
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Description.Enabled = True
                    TextBoxGeneral_Description.ReadOnly = False

                    TabItemProductSetup_AccountExecutivesTab.Visible = False
                    TabItemProductSetup_DocumentsTab.Visible = False
                    TabItemProductSetup_ContactsTab.Visible = False
                    TabItemProductSetup_ContractsTab.Visible = False

                End If

                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToInternet_UseFlags)
                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToMagazine_UseFlags)
                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToNewspaper_UseFlags)
                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToOutOfHome_UseFlags)
                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToRadio_UseFlags)
                HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToTelevision_UseFlags)

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False
            Dim ControlLoaded As Boolean = False
            Dim IsNewProductionEstimateDefault As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Product = Me.FillObject(False, False)

                    If Product IsNot Nothing AndAlso AddressControlLeftColumn_BillingAddress.Tag Is Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.Product.Update(DbContext, Product)

                        If Saved Then

                            ControlLoaded = False

                            Try

                                If TabItemProductSetup_CompanyProfileTab.Tag = True Then

                                    ControlLoaded = True

                                End If

                            Catch ex As Exception
                                ControlLoaded = False
                            End Try

                            If ControlLoaded = False Then

                                CompanyProfileControlCompanyProfile_CompanyProfile.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

                            End If

                            If CompanyProfileControlCompanyProfile_CompanyProfile.IsNewCompanyProfile(DbContext) Then

                                CompanyProfileControlCompanyProfile_CompanyProfile.Insert(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code)

                            Else

                                CompanyProfileControlCompanyProfile_CompanyProfile.Save(DbContext)

                            End If

                            ControlLoaded = False

                            Try

                                If TabItemProductSetup_ActivitySummaryTab.Tag = True Then

                                    ControlLoaded = True

                                End If

                            Catch ex As Exception
                                ControlLoaded = False
                            End Try

                            If ControlLoaded = False Then

                                ActivitySummaryControlActivitySummary_ActivitySummary.LoadControl(_ClientCode, _DivisionCode, _ProductCode, CheckBoxGeneral_NewBusiness.Checked)

                            End If

                            If ActivitySummaryControlActivitySummary_ActivitySummary.IsNewActivitySummary(DbContext) Then

                                ActivitySummaryControlActivitySummary_ActivitySummary.Insert(DbContext, Product.ClientCode, Product.DivisionCode, Product.Code)

                            Else

                                ActivitySummaryControlActivitySummary_ActivitySummary.Save(DbContext)

                            End If

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                ProductionEstimateDefault = FillProductionEstimateFormatObject(DataContext, IsNewProductionEstimateDefault)

                                If ProductionEstimateDefault IsNot Nothing Then

                                    If IsNewProductionEstimateDefault Then

                                        ProductionEstimateDefault.DataContext = DataContext
                                        ProductionEstimateDefault.ClientCode = Product.ClientCode
                                        ProductionEstimateDefault.DivisionCode = Product.DivisionCode
                                        ProductionEstimateDefault.ProductCode = Product.Code
                                        ProductionEstimateDefault.ClientOrDefault = 3

                                        If AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault) Then

                                            'AdvantageFramework.Database.Procedures.EstimatePrintingSetting.ResetToDefaults(DataContext, ProductionEstimateDefault)

                                        End If

                                    Else

                                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Update(DataContext, ProductionEstimateDefault)

                                    End If

                                End If

                            End Using

                        Else

                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                        End If

                    ElseIf AddressControlLeftColumn_BillingAddress.Tag IsNot Nothing Then

                        ErrorMessage = "Failed to validate billing address."

                    End If

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
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Product = Me.FillObject(False, True)

                    If Product IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Product.Delete(DbContext, Product)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The product is in use and cannot be deleted."

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
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ProdSortKey As AdvantageFramework.Database.Entities.ProductSortKey = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Product = Me.FillObject(True, False)

                    If Product IsNot Nothing AndAlso AddressControlLeftColumn_BillingAddress.Tag Is Nothing Then

                        Product.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                        If Inserted Then

                            If Me.GetSortKeyList IsNot Nothing Then

                                For Each ProductSortKey In Me.GetSortKeyList.OfType(Of AdvantageFramework.Database.Entities.ProductSortKey)()

                                    ProdSortKey = New AdvantageFramework.Database.Entities.ProductSortKey

                                    ProdSortKey.DbContext = DbContext
                                    ProdSortKey.ClientCode = Product.ClientCode
                                    ProdSortKey.DivisionCode = Product.DivisionCode
                                    ProdSortKey.ProductCode = Product.Code
                                    ProdSortKey.SortKey = ProductSortKey.SortKey

                                    AdvantageFramework.Database.Procedures.ProductSortKey.Insert(DbContext, ProdSortKey)

                                Next

                            End If

                            ClientCode = Product.ClientCode
                            DivisionCode = Product.DivisionCode
                            ProductCode = Product.Code

                            CompanyProfileControlCompanyProfile_CompanyProfile.Insert(DbContext, ClientCode, DivisionCode, ProductCode)
                            ActivitySummaryControlActivitySummary_ActivitySummary.Insert(DbContext, ClientCode, DivisionCode, ProductCode)

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
        Public Sub ClearControl()

            TextBoxGeneral_Code.Text = ""
            TextBoxGeneral_Description.Text = ""
            ComboBoxGeneral_Client.SelectedIndex = -1
            ComboBoxGeneral_Division.SelectedIndex = -1
            DataGridViewRightColumn_SortOptions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey))
            CheckBoxGeneral_Inactive.Checked = False
            TextBoxBillingContactInformation_Phone.Text = ""
            TextBoxBillingContactInformation_PhoneExt.Text = ""
            TextBoxBillingContactInformation_Fax.Text = ""
            TextBoxBillingContactInformation_FaxExt.Text = ""
            TextBoxStatementContactInformation_Phone.Text = ""
            TextBoxStatementContactInformation_PhoneExt.Text = ""
            TextBoxStatementContactInformation_Fax.Text = ""
            TextBoxStatementContactInformation_FaxExt.Text = ""
            TextBoxUserDefinedFields_Field1.Text = ""
            TextBoxUserDefinedFields_Field2.Text = ""
            TextBoxUserDefinedFields_Field3.Text = ""
            TextBoxUserDefinedFields_Field4.Text = ""
            TextBoxOptions_AttentionLine.Text = ""
            ComboBoxOptions_Office.SelectedIndex = -1
            NumericInputLatePaymentFee_Percentage.EditValue = Nothing
            CheckBoxLatePaymentFee_Calculate.Checked = False
            'ComboBoxOptions_Currency.SelectedIndex = -1
            NumericInputProduction_ContingencyPercent.EditValue = Nothing
            NumericInputProduction_DefaultMarkupPercent.EditValue = Nothing
            NumericInputProduction_EmployeeTimeBillingRate.EditValue = Nothing
            CheckBoxProduction_UseEstimateBillingRate.Checked = False
            CheckBoxProduction_AvalaraTaxExemptOverride.Checked = False
            ComboBoxProduction_DefaultAlertGroup.SelectedIndex = -1
            ComboBoxProduction_DefaultTaxCode.SelectedIndex = -1
            CheckBoxBillingOptions_AllowVendorDiscounts.Checked = False
            CheckBoxBillingOptions_ApprovedEstimateRequired.Checked = False
            CheckBoxBillingOptions_BillingSetupComplete.Checked = False
            CheckBoxBillingOptions_BillNet.Checked = False
            CheckBoxBillingOptions_ConsolidateFunctions.Checked = False
            NumericInputBillingOptions_EarlyPayDaysOverride.EditValue = 0
            NumericInputRadio_Markup.EditValue = Nothing
            NumericInputRadio_Rebate.EditValue = Nothing
            CheckBoxRadio_BillingSetupComplete.Checked = False
            CheckBoxRadio_BillNet.Checked = False
            CheckBoxRadio_CommissionOnly.Checked = False
            CheckBoxRadio_VendorDiscounts.Checked = False
            RadioButtonControlRadio_Prebill.Checked = False
            RadioButtonControlRadio_PostBill.Checked = False
            NumericInputNumberOfDaysToBillRadio_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Checked = False
            RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Checked = False
            RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Checked = False
            ComboBoxRadio_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToRadio_UseFlags.Checked = False
            CheckBoxApplySalesTaxToRadio_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToRadio_Commission.Checked = False
            CheckBoxApplySalesTaxToRadio_LineNet.Checked = False
            CheckBoxApplySalesTaxToRadio_NetCharge.Checked = False
            CheckBoxApplySalesTaxToRadio_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToRadio_Rebate.Checked = False
            NumericInputTelevision_Markup.EditValue = Nothing
            NumericInputTelevision_Rebate.EditValue = Nothing
            CheckBoxTelevision_BillingSetupComplete.Checked = False
            CheckBoxTelevision_BillNet.Checked = False
            CheckBoxTelevision_CommissionOnly.Checked = False
            CheckBoxTelevision_VendorDiscounts.Checked = False
            RadioButtonControlTelevision_Prebill.Checked = False
            RadioButtonControlTelevision_PostBill.Checked = False
            NumericInputNumberOfDaysToBillTelevision_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Checked = False
            RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Checked = False
            RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Checked = False
            ComboBoxTelevision_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToTelevision_UseFlags.Checked = False
            CheckBoxApplySalesTaxToTelevision_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToTelevision_Commission.Checked = False
            CheckBoxApplySalesTaxToTelevision_LineNet.Checked = False
            CheckBoxApplySalesTaxToTelevision_NetCharge.Checked = False
            CheckBoxApplySalesTaxToTelevision_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToTelevision_Rebate.Checked = False
            NumericInputMagazine_Markup.EditValue = Nothing
            NumericInputMagazine_Rebate.EditValue = Nothing
            CheckBoxMagazine_BillingSetupComplete.Checked = False
            CheckBoxMagazine_BillNet.Checked = False
            CheckBoxMagazine_CommissionOnly.Checked = False
            CheckBoxMagazine_VendorDiscounts.Checked = False
            RadioButtonControlMagazine_Prebill.Checked = False
            RadioButtonControlMagazine_PostBill.Checked = False
            NumericInputNumberOfDaysToBillMagazine_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Checked = False
            RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Checked = False
            RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Checked = False
            ComboBoxMagazine_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToMagazine_UseFlags.Checked = False
            CheckBoxApplySalesTaxToMagazine_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToMagazine_Commission.Checked = False
            CheckBoxApplySalesTaxToMagazine_LineNet.Checked = False
            CheckBoxApplySalesTaxToMagazine_NetCharge.Checked = False
            CheckBoxApplySalesTaxToMagazine_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToMagazine_Rebate.Checked = False
            NumericInputNewspaper_Markup.EditValue = Nothing
            NumericInputNewspaper_Rebate.EditValue = Nothing
            CheckBoxNewspaper_BillingSetupComplete.Checked = False
            CheckBoxNewspaper_BillNet.Checked = False
            CheckBoxNewspaper_CommissionOnly.Checked = False
            CheckBoxNewspaper_VendorDiscounts.Checked = False
            RadioButtonControlNewspaper_Prebill.Checked = False
            RadioButtonControlNewspaper_PostBill.Checked = False
            NumericInputNumberOfDaysToBillNewspaper_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Checked = False
            RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Checked = False
            RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Checked = False
            ComboBoxNewspaper_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToNewspaper_UseFlags.Checked = False
            CheckBoxApplySalesTaxToNewspaper_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToNewspaper_Commission.Checked = False
            CheckBoxApplySalesTaxToNewspaper_LineNet.Checked = False
            CheckBoxApplySalesTaxToNewspaper_NetCharge.Checked = False
            CheckBoxApplySalesTaxToNewspaper_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToNewspaper_Rebate.Checked = False
            NumericInputOutOfHome_Markup.EditValue = Nothing
            NumericInputOutOfHome_Rebate.EditValue = Nothing
            CheckBoxOutOfHome_BillingSetupComplete.Checked = False
            CheckBoxOutOfHome_BillNet.Checked = False
            CheckBoxOutOfHome_CommissionOnly.Checked = False
            CheckBoxOutOfHome_VendorDiscounts.Checked = False
            RadioButtonControlOutOfHome_Prebill.Checked = False
            RadioButtonControlOutOfHome_PostBill.Checked = False
            NumericInputNumberOfDaysToBillOutOfHome_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Checked = False
            RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Checked = False
            RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Checked = False
            ComboBoxOutOfHome_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToOutOfHome_UseFlags.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_Commission.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_LineNet.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_NetCharge.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToOutOfHome_Rebate.Checked = False
            NumericInputInternet_Markup.EditValue = Nothing
            NumericInputInternet_Rebate.EditValue = Nothing
            CheckBoxInternet_BillingSetupComplete.Checked = False
            CheckBoxInternet_BillNet.Checked = False
            CheckBoxInternet_CommissionOnly.Checked = False
            CheckBoxInternet_VendorDiscounts.Checked = False
            RadioButtonControlInternet_Prebill.Checked = False
            RadioButtonControlInternet_PostBill.Checked = False
            NumericInputNumberOfDaysToBillInternet_Days.EditValue = Nothing
            RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Checked = False
            RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Checked = False
            RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Checked = False
            ComboBoxInternet_TaxCode.SelectedIndex = -1
            CheckBoxApplySalesTaxToInternet_UseFlags.Checked = False
            CheckBoxApplySalesTaxToInternet_AddlCharge.Checked = False
            CheckBoxApplySalesTaxToInternet_Commission.Checked = False
            CheckBoxApplySalesTaxToInternet_LineNet.Checked = False
            CheckBoxApplySalesTaxToInternet_NetCharge.Checked = False
            CheckBoxApplySalesTaxToInternet_NetDiscount.Checked = False
            CheckBoxApplySalesTaxToInternet_Rebate.Checked = False
            ComboBoxProductionEstimateFormat_Type.SelectedIndex = -1
            ComboBoxProductionEstimateFormat_Type.SelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.AgencyDefault.ToString.Replace("Agency", "")

            AddressControlLeftColumn_BillingAddress.ClearControl()
            AddressControlRightColumn_StatementAddress.ClearControl()

            CompanyProfileControlCompanyProfile_CompanyProfile.ClearControl()

            ActivitySummaryControlActivitySummary_ActivitySummary.ClearControl()

            ResetDataSources()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function GetSortKeyList() As Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey)

            Dim SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey) = Nothing

            Try

                SortKeyList = _SortKeyList

            Catch ex As Exception
                SortKeyList = Nothing
            End Try

            GetSortKeyList = SortKeyList

        End Function
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_ProductDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_ProductDocuments.DeleteSelectedDocument()

        End Sub
        Public Sub UploadDocument()

            DocumentManagerControlDocuments_ProductDocuments.UploadNewDocument()

        End Sub
        Public Sub SendASPUploadEmail()

            DocumentManagerControlDocuments_ProductDocuments.SendASPUploadEmail()

        End Sub
        Public Sub AddContact()

            ClientContactManagerControlContacts_ProductContacts.AddClientContact()

        End Sub
        Public Sub EditContact()

            ClientContactManagerControlContacts_ProductContacts.EditSelectedClientContact()

        End Sub
        Public Sub DeleteContact()

            ClientContactManagerControlContacts_ProductContacts.DeleteSelectedClientContact()

        End Sub
        Public Sub AddContract()

            ContractManagerControlContracts_ProductContracts.AddContract()

        End Sub
        Public Sub CopyContract()

            ContractManagerControlContracts_ProductContracts.CopyContract()

        End Sub
        Public Sub DeleteContract()

            ContractManagerControlContracts_ProductContracts.DeleteSelectedContract()

        End Sub
        Public Sub EditContract()

            ContractManagerControlContracts_ProductContracts.EditContract()

        End Sub
        Public Sub LoadRequiredNonGridControlsForValidation()

            'objects
            Dim RequiredTabsList As Generic.List(Of DevComponents.DotNetBar.TabItem) = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                RequiredTabsList = New Generic.List(Of DevComponents.DotNetBar.TabItem)

                RequiredTabsList.Add(TabItemProductSetup_GeneralTab)

                For Each TabItem In RequiredTabsList

                    If TabItem IsNot TabControlControl_ProductSetup.SelectedTab Then

                        LoadProductDetails(TabItem)

                    End If

                Next

            End If

        End Sub
        Public Sub DeleteSelectedSortKey()

            'objects
            Dim ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey = Nothing

            If DataGridViewRightColumn_SortOptions.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ProductSortKey = DataGridViewRightColumn_SortOptions.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ProductSortKey = Nothing
                    End Try

                    If ProductSortKey IsNot Nothing Then

                        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ProductSortKey.Delete(DbContext, ProductSortKey) Then

                                    LoadSortKeys()

                                End If

                            End Using

                        Else

                            Try

                                _SortKeyList.Remove(_SortKeyList.Where(Function(PrdSortKey) PrdSortKey.SortKey = ProductSortKey.SortKey).FirstOrDefault)

                                DataGridViewRightColumn_SortOptions.DataSource = _SortKeyList

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddSelectedSortKey()

            DataGridViewRightColumn_SortOptions.CancelNewItemRow()

        End Sub
        Public Sub CancelAddNewCompanyProfileAffiliation()

            CompanyProfileControlCompanyProfile_CompanyProfile.CancelAddNewCompanyProfileAffiliation()

        End Sub
        Public Sub DeleteSelectedCompanyProfileAffiliation()

            CompanyProfileControlCompanyProfile_CompanyProfile.DeleteSelectedCompanyProfileAffiliation()

        End Sub
        Public Sub CancelAddNewActivityCompetitor()

            ActivitySummaryControlActivitySummary_ActivitySummary.CancelAddNewActivityCompetitor()

        End Sub
        Public Sub DeleteSelectedActivityCompetitor()

            ActivitySummaryControlActivitySummary_ActivitySummary.DeleteSelectedActivityCompetitor()

        End Sub
        Public Sub RefreshActivitySummary()

            ActivitySummaryControlActivitySummary_ActivitySummary.RefreshActivitySummary()

        End Sub
        Public Function FillProductionEstimateFormatObject(ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

            'objects
            Dim AgencyProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            Try

                If IsNew OrElse TabItemProductSetup_Production.Tag = True Then

                    If _ProductCode IsNot Nothing Then

                        ProductionEstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientDivisionProduct(DataContext, _ClientCode, _DivisionCode, _ProductCode)

                    End If

                    If ComboBoxProductionEstimateFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.AgencyDefault.ToString.Replace("Agency", "") Then

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

                    ElseIf ComboBoxProductionEstimateFormat_Type.GetSelectedValue = AdvantageFramework.Database.Entities.EstimateFormatsProduct.Product.ToString Then

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

#End Region

#Region "  Control Event Handlers "

        Private Sub ProductControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            _SortKeyList = New Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey)

            ButtonItemRefreshBilling_Client.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemRefreshBilling_Division.Icon = AdvantageFramework.My.Resources.DivisionIcon

            ButtonItemRefreshStatement_Client.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemRefreshStatement_Division.Icon = AdvantageFramework.My.Resources.DivisionIcon
            ButtonItemRefreshStatement_BillingAddress.Icon = AdvantageFramework.My.Resources.PurchaseOrderIcon

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxGeneral_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneral_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxGeneral_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxGeneral_Inactive.Checked = Not CheckBoxGeneral_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub ButtonItemRefresh_Client_Click(sender As Object, e As System.EventArgs) Handles ButtonItemRefreshBilling_Client.Click, ButtonItemRefreshStatement_Client.Click

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim AddressControl As AdvantageFramework.WinForm.Presentation.Controls.AddressControl = Nothing

            If sender Is ButtonItemRefreshBilling_Client Then
                AddressControl = AddressControlLeftColumn_BillingAddress
            ElseIf sender Is ButtonItemRefreshStatement_Client Then
                AddressControl = AddressControlRightColumn_StatementAddress
            End If

            Client = GetUpdatedClient()

            If Client IsNot Nothing AndAlso AddressControl IsNot Nothing Then

                UpdateAddressFields(Client, AddressControl)

            End If

        End Sub
        Private Sub ButtonItemRefreshStatement_BillingAddress_Click(sender As Object, e As System.EventArgs) Handles ButtonItemRefreshStatement_BillingAddress.Click

            UpdateAddressFields(AddressControlLeftColumn_BillingAddress, AddressControlRightColumn_StatementAddress)

        End Sub
        Private Sub ButtonItemRefresh_Division_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRefreshBilling_Division.Click, ButtonItemRefreshStatement_Division.Click

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim AddressControl As AdvantageFramework.WinForm.Presentation.Controls.AddressControl = Nothing

            If sender Is ButtonItemRefreshBilling_Division Then
                AddressControl = AddressControlLeftColumn_BillingAddress
            ElseIf sender Is ButtonItemRefreshStatement_Division Then
                AddressControl = AddressControlRightColumn_StatementAddress
            End If

            Division = GetUpdatedDivision()

            If Division IsNot Nothing AndAlso AddressControl IsNot Nothing Then

                UpdateAddressFields(Division, AddressControl)

            End If

        End Sub
        Private Sub CheckBoxApplySalesTaxToUseFlags_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxApplySalesTaxToInternet_UseFlags.CheckedChanged,
                                                                                                                    CheckBoxApplySalesTaxToMagazine_UseFlags.CheckedChanged,
                                                                                                                    CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckedChanged,
                                                                                                                    CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckedChanged,
                                                                                                                    CheckBoxApplySalesTaxToRadio_UseFlags.CheckedChanged,
                                                                                                                    CheckBoxApplySalesTaxToTelevision_UseFlags.CheckedChanged
            If TypeOf sender Is AdvantageFramework.WinForm.Presentation.Controls.CheckBox Then

                HandleApplyTaxCheckBoxes(sender)

            End If

        End Sub
        Private Sub CheckBoxBillingSettings_CheckChanged(sender As Object, e As System.EventArgs) Handles CheckBoxRadio_BillNet.CheckedChanged, CheckBoxRadio_CommissionOnly.CheckedChanged, CheckBoxRadio_VendorDiscounts.CheckedChanged,
                                                                                                          CheckBoxTelevision_BillNet.CheckedChanged, CheckBoxTelevision_CommissionOnly.CheckedChanged, CheckBoxTelevision_VendorDiscounts.CheckedChanged,
                                                                                                          CheckBoxMagazine_BillNet.CheckedChanged, CheckBoxMagazine_CommissionOnly.CheckedChanged, CheckBoxMagazine_VendorDiscounts.CheckedChanged,
                                                                                                          CheckBoxNewspaper_BillNet.CheckedChanged, CheckBoxNewspaper_CommissionOnly.CheckedChanged, CheckBoxNewspaper_VendorDiscounts.CheckedChanged,
                                                                                                          CheckBoxOutOfHome_BillNet.CheckedChanged, CheckBoxOutOfHome_CommissionOnly.CheckedChanged, CheckBoxOutOfHome_VendorDiscounts.CheckedChanged,
                                                                                                          CheckBoxInternet_BillNet.CheckedChanged, CheckBoxInternet_CommissionOnly.CheckedChanged, CheckBoxInternet_VendorDiscounts.CheckedChanged

            If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Name.Contains("CommissionOnly") Then

                For Each CheckBox In DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Parent.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                    If CheckBox.Name.Contains("VendorDiscounts") OrElse CheckBox.Name.Contains("BillNet") Then

                        CheckBox.Enabled = If(sender.Checked, False, True)

                    End If

                Next

            End If

            If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Name.Contains("VendorDiscounts") OrElse DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Name.Contains("BillNet") Then

                For Each CheckBox In DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Parent.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                    If CheckBox.Name.Contains("CommissionOnly") Then

                        CheckBox.Enabled = If(sender.Checked, False, True)

                    End If

                Next

            End If

        End Sub
        Private Sub ComboBoxGeneral_Client_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxGeneral_Client.SelectedValueChanged

            If ComboBoxGeneral_Client.HasASelectedValue Then

                ButtonLeftSection_RefreshBilling.Enabled = True
                ButtonRightColumn_RefreshStatement.Enabled = True

                LoadDivisions()

            Else

                ButtonLeftSection_RefreshBilling.Enabled = False
                ButtonRightColumn_RefreshStatement.Enabled = False

            End If

        End Sub
        Private Sub PanelBilling_ContactInformation_Leave(sender As Object, e As System.EventArgs) Handles PanelBilling_ContactInformation.Leave

            If _ProductCode Is Nothing OrElse _ProductCode = "" Then

                If TextBoxStatementContactInformation_Fax.Text = "" Then
                    TextBoxStatementContactInformation_Fax.Text = TextBoxBillingContactInformation_Fax.Text
                End If

                If TextBoxStatementContactInformation_FaxExt.Text = "" Then
                    TextBoxStatementContactInformation_FaxExt.Text = TextBoxBillingContactInformation_FaxExt.Text
                End If

                If TextBoxStatementContactInformation_Phone.Text = "" Then
                    TextBoxStatementContactInformation_Phone.Text = TextBoxBillingContactInformation_Phone.Text
                End If

                If TextBoxStatementContactInformation_PhoneExt.Text = "" Then
                    TextBoxStatementContactInformation_PhoneExt.Text = TextBoxBillingContactInformation_PhoneExt.Text
                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_AccountExecutives_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_AccountExecutives.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_Employees_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_Employees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonRightSection_AddAccountExecutive_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddAccountExecutive.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim EmployeeCodesList As IEnumerable(Of Object) = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" AndAlso DataGridViewLeftSection_Employees.HasASelectedRow Then

                EmployeeCodesList = DataGridViewLeftSection_Employees.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewLeftSection_Employees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Views.Employee.Properties.Code.ToString)).ToList

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()
                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each EmployeeCode In EmployeeCodesList.OfType(Of String)()

                            AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                            AccountExecutive.ClientCode = _ClientCode
                            AccountExecutive.DivisionCode = _DivisionCode
                            AccountExecutive.ProductCode = _ProductCode
                            AccountExecutive.EmployeeCode = EmployeeCode
                            AccountExecutive.IsInactive = 0
                            AccountExecutive.IsDefaultAccountExecutive = 0

                            AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AccountExecutive)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadEmployeesAndAccountExecutives()

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveAccountExecutive_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveAccountExecutive.Click

            'objects
            Dim EmployeeCode As String = Nothing
            Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim EmployeeCodesList As IEnumerable(Of Object) = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" AndAlso DataGridViewRightSection_AccountExecutives.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EmployeeCodesList = DataGridViewRightSection_AccountExecutives.CurrentView.GetSelectedRows.Select(Function(RowHandle) DataGridViewRightSection_AccountExecutives.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.AccountExecutive.Properties.EmployeeCode.ToString)).ToList

                        For Each EmployeeCode In EmployeeCodesList.OfType(Of String)()

                            AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, _ClientCode, _DivisionCode, _ProductCode, EmployeeCode)

                            AdvantageFramework.Database.Procedures.AccountExecutive.Delete(DbContext, AccountExecutive)

                        Next

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                Try

                    LoadEmployeesAndAccountExecutives()

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightSection_AccountExecutives_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_AccountExecutives.CellValueChangingEvent

            'objects
            Dim AccountExecutive As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim CurrentRowAccountExecutive As AdvantageFramework.Database.Classes.AccountExecutive = Nothing
            Dim DisplayMessage As String = Nothing
            Dim IsDefault As Boolean = Nothing
            Dim HasError As Boolean = Nothing
            Dim DoSave As Boolean = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DoSave = False
                HasError = False

                AccountExecutive = DataGridViewRightSection_AccountExecutives.CurrentView.GetRow(e.RowHandle)

                If AccountExecutive IsNot Nothing Then

                    If e.Column.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.IsDefault.ToString Then

                        If CBool(e.Value) = True Then

                            If (From AccountExec In DataGridViewRightSection_AccountExecutives.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.AccountExecutive).ToList
                                Where AccountExec.IsDefault = True AndAlso
                                      AccountExec.EmployeeCode <> AccountExecutive.EmployeeCode
                                Select AccountExec).Any Then

                                AdvantageFramework.WinForm.MessageBox.Show("Only one default A/E is allowed.")

                            ElseIf AccountExecutive.IsInactive = True Then

                                If AdvantageFramework.WinForm.MessageBox.Show("This A/E is inactive. Marking this A/E as the default will activate the A/E. Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    DoSave = True

                                    AccountExecutive.IsDefault = True
                                    AccountExecutive.IsInactive = False

                                    AccountExecutive.AccountExecutive.IsInactive = 0
                                    AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 1

                                End If

                            Else

                                DoSave = True
                                AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 1

                            End If

                        Else

                            DoSave = True
                            AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 0

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.AccountExecutive.Properties.IsInactive.ToString Then

                        If CBool(e.Value) = True Then

                            If AccountExecutive.IsDefault Then

                                If AdvantageFramework.WinForm.MessageBox.Show("This A/E is the default A/E. Marking this A/E inactive will remove the default status. Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    DoSave = True

                                    AccountExecutive.IsDefault = False
                                    AccountExecutive.IsInactive = True

                                    AccountExecutive.AccountExecutive.IsInactive = 1
                                    AccountExecutive.AccountExecutive.IsDefaultAccountExecutive = 0

                                End If

                            Else

                                DoSave = True
                                AccountExecutive.AccountExecutive.IsInactive = 1

                            End If

                        Else

                            DoSave = True
                            AccountExecutive.AccountExecutive.IsInactive = 0

                        End If

                    End If

                End If

                If DoSave Then

                    Saved = AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AccountExecutive.AccountExecutive)

                Else

                    Saved = True
                    LoadEmployeesAndAccountExecutives()

                End If

            End Using

        End Sub
        Private Sub TabControlControl_ProductSetup_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_ProductSetup.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False

            End If

        End Sub
        Private Sub TabControlControl_ProductSetup_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_ProductSetup.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True

            End If

            LoadProductDetails(e.NewTab)

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub DataGridViewRightColumn_SortOptions_AddNewRowEvent(RowObject As Object) Handles DataGridViewRightColumn_SortOptions.AddNewRowEvent

            'objects
            Dim ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ProductSortKey Then

                Me.ShowWaitForm("Processing...")

                ProductSortKey = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ProductSortKey.IsEntityBeingAdded() Then

                        If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso _ProductCode IsNot Nothing Then

                            ProductSortKey.DbContext = DbContext

                            ProductSortKey.ClientCode = _ClientCode
                            ProductSortKey.DivisionCode = _DivisionCode
                            ProductSortKey.ProductCode = _ProductCode

                            AdvantageFramework.Database.Procedures.ProductSortKey.Insert(DbContext, ProductSortKey)

                        Else

                            If _SortKeyList.Where(Function(ProdSortKey) ProdSortKey.SortKey = ProductSortKey.SortKey).Any = False Then

                                _SortKeyList.Add(ProductSortKey)

                            End If

                        End If

                    End If

                End Using

                LoadSortKeys()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewRightColumn_SortOptions_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightColumn_SortOptions.DataSourceChangedEvent, DataGridViewRightColumn_SortOptions.Resize

            If DataGridViewRightColumn_SortOptions.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewRightColumn_SortOptions.CurrentView.VisibleColumns(0).Width = DataGridViewRightColumn_SortOptions.Width - 35

            End If

        End Sub
        Private Sub DataGridViewRightColumn_SortOptions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewRightColumn_SortOptions.InitNewRowEvent

            DataGridViewRightColumn_SortOptions.CurrentView.SetRowCellValue(DataGridViewRightColumn_SortOptions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ProductSortKey.Properties.ClientCode.ToString, _ClientCode)
            DataGridViewRightColumn_SortOptions.CurrentView.SetRowCellValue(DataGridViewRightColumn_SortOptions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ProductSortKey.Properties.DivisionCode.ToString, _DivisionCode)
            DataGridViewRightColumn_SortOptions.CurrentView.SetRowCellValue(DataGridViewRightColumn_SortOptions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ProductSortKey.Properties.ProductCode.ToString, _ProductCode)

            RaiseEvent ProductSortKeysInitNewRowEvent()

        End Sub
        Private Sub DataGridViewRightColumn_SortOptions_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightColumn_SortOptions.SelectionChangedEvent

            RaiseEvent ProductSortKeysSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewRightColumn_SortOptions_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightColumn_SortOptions.ShowingEditorEvent

            If DataGridViewRightColumn_SortOptions.IsNewItemRow = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub TabControlGeneral_General_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlGeneral_General.SelectedTabChanged

            RaiseEvent SelectedDetailChangedEvent()

        End Sub
        Private Sub DocumentManagerControlDocuments_ProductDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_ProductDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub ContractManagerControlContracts_ProductContracts_RowCountChangedEvent() Handles ContractManagerControlContracts_ProductContracts.RowCountChangedEvent

            RaiseEvent ContractManagerRowCountChanged()

        End Sub
        Private Sub ClientContactManagerControlContacts_ProductContacts_RowCountChangedEvent() Handles ClientContactManagerControlContacts_ProductContacts.RowCountChangedEvent

            RaiseEvent ClientContactManagerRowCountChanged()

        End Sub
        Private Sub CompanyProfileControlCompanyProfile_CompanyProfile_AffiliationInitNewRowEvent() Handles CompanyProfileControlCompanyProfile_CompanyProfile.AffiliationInitNewRowEvent

            RaiseEvent CompanyProfileAffiliationInitNewRowEvent()

        End Sub
        Private Sub CompanyProfileControlCompanyProfile_CompanyProfile_AffiliationSelectionChangedEvent() Handles CompanyProfileControlCompanyProfile_CompanyProfile.AffiliationSelectionChangedEvent

            RaiseEvent CompanyProfileAffiliationSelectionChangedEvent()

        End Sub
        Private Sub CompanyProfileControlCompanyProfile_CompanyProfile_NotesGotFocusEvent(sender As Object, e As EventArgs) Handles CompanyProfileControlCompanyProfile_CompanyProfile.NotesGotFocusEvent

            RaiseEvent CompanyProfileNotesGotFocusEvent(sender, e)

        End Sub
        Private Sub CompanyProfileControlCompanyProfile_CompanyProfile_NotesLostFocusEvent(sender As Object, e As EventArgs) Handles CompanyProfileControlCompanyProfile_CompanyProfile.NotesLostFocusEvent

            RaiseEvent CompanyProfileNotesLostFocusEvent(sender, e)

        End Sub
        Private Sub ActivitySummaryControlActivitySummary_ActivitySummary_CRMActivitySelectionChangedEvent() Handles ActivitySummaryControlActivitySummary_ActivitySummary.CRMActivitySelectionChangedEvent

            RaiseEvent ActivitySummaryCRMActivitySelectionChangedEvent()

        End Sub
        Private Sub ActivitySummaryControlActivitySummary_ActivitySummary_CompetitorInitNewRowEvent() Handles ActivitySummaryControlActivitySummary_ActivitySummary.CompetitorInitNewRowEvent

            RaiseEvent ActivitySummaryCompetitorInitNewRowEvent()

        End Sub
        Private Sub ActivitySummaryControlActivitySummary_ActivitySummary_CompetitorSelectionChangedEvent() Handles ActivitySummaryControlActivitySummary_ActivitySummary.CompetitorSelectionChangedEvent

            RaiseEvent ActivitySummaryCompetitorSelectionChangedEvent()

        End Sub
        Private Sub CheckBoxLatePaymentFee_Calculate_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxLatePaymentFee_Calculate.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso e.NewChecked.Checked AndAlso ClientLateFeeProcessingExists() Then

                AdvantageFramework.WinForm.MessageBox.Show(LATE_FEE_MESSAGE)

                NumericInputLatePaymentFee_Percentage.EditValue = Nothing

                e.NewChecked.Checked = False

                e.Cancel = True

            ElseIf e.EventSource <> DevComponents.DotNetBar.eEventSource.Code AndAlso Not e.NewChecked.Checked Then

                NumericInputLatePaymentFee_Percentage.EditValue = Nothing

            End If

        End Sub
        Private Sub CheckBoxLatePaymentFee_Calculate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLatePaymentFee_Calculate.CheckedChanged

            NumericInputLatePaymentFee_Percentage.SetRequired(CheckBoxLatePaymentFee_Calculate.Checked)
            NumericInputLatePaymentFee_Percentage.Enabled = CheckBoxLatePaymentFee_Calculate.Checked

        End Sub

#End Region

#End Region

    End Class

End Namespace
