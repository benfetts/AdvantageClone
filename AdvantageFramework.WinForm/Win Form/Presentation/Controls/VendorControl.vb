Namespace WinForm.Presentation.Controls

    Public Class VendorControl

        Public Event SelectedTabChanged()
        Public Event FocusedGridSelectionChangedEvent()
        Public Event MediaSpecsChangedEvent()
        Public Event VendorPricingsSelectionChangedEvent()
        Public Event SelectedDocumentChanged()
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event VendorContractManagerRowCountChanged()
        Public Event VendorContractManagerSelectionChanged()
        Public Event MarketChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorCode As String = Nothing
        Private _SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.VendorSortKey) = Nothing
        Private _SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
        Private _SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
        Private _ControlLoaded As Boolean = False
        Private _IsNewVendor As Boolean = False
        Private _LastSelectedPayToVendorCode As String = Nothing
        Private _LastSelectedTabBeforeClearControl As DevComponents.DotNetBar.TabItem = Nothing
        Private _HasAccessToDocuments As Boolean = False
        Private _CanUserPrint As Boolean = False
        Private _CanUserUpdate As Boolean = False
        Private _CanUserAdd As Boolean = False
        Private _CanUserCustom1 As Boolean = False
        Private _CanUserCustom2 As Boolean = False
        Private _HasAccessToVendorContact As Boolean = False
        Private _CanUserUpdateInVendorContact As Boolean = False
        Private _CanUserAddInVendorContact As Boolean = False
        Private _HasAccessToVendorRep As Boolean = False
        Private _CanUserUpdateInVendorRep As Boolean = False
        Private _CanUserAddInVendorRep As Boolean = False
        Private _CategoryChanged As Boolean = False
        Private _Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market) = Nothing
        Private _IsSelectedMarketCanadadian As Boolean = False
        Private _IsQuickbooksEnabled As Boolean = False
        Private _IsLoading As Boolean = False
        Private _QuickBooksVendors As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Vendor) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInVendorRep As Boolean
            Get
                CanUserUpdateInVendorRep = _CanUserUpdateInVendorRep
            End Get
        End Property
        Public ReadOnly Property CanUserAddInVendorRep As Boolean
            Get
                CanUserAddInVendorRep = _CanUserAddInVendorRep
            End Get
        End Property
        Public ReadOnly Property HasAccessToVendorRep As Boolean
            Get
                HasAccessToVendorRep = _HasAccessToVendorRep
            End Get
        End Property
        Public ReadOnly Property CanUserUpdateInVendorContact As Boolean
            Get
                CanUserUpdateInVendorContact = _CanUserUpdateInVendorContact
            End Get
        End Property
        Public ReadOnly Property CanUserAddInVendorContact As Boolean
            Get
                CanUserAddInVendorContact = _CanUserAddInVendorContact
            End Get
        End Property
        Public ReadOnly Property HasAccessToVendorContact As Boolean
            Get
                HasAccessToVendorContact = _HasAccessToVendorContact
            End Get
        End Property
        Public ReadOnly Property CanUserCustom1 As Boolean
            Get
                CanUserCustom1 = _CanUserCustom1
            End Get
        End Property
        Public ReadOnly Property CanUserCustom2 As Boolean
            Get
                CanUserCustom2 = _CanUserCustom2
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
        Public ReadOnly Property VendorCode As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        Public ReadOnly Property VendorContactsGrid As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                VendorContactsGrid = DataGridViewContacts_Contacts
            End Get
        End Property
        Public ReadOnly Property VendorRepresentativesGrid As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                VendorRepresentativesGrid = DataGridViewRepresentatives_VendorReps
            End Get
        End Property
        Public ReadOnly Property IsContactsTabSelected As Boolean
            Get
                IsContactsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_ContactsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsRepresentativesTabSelected As Boolean
            Get
                IsRepresentativesTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_RepresentativesTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsMediaSpecsTabSelected As Boolean
            Get
                IsMediaSpecsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaSpecsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsMediaDeliveryTabSelected As Boolean
            Get
                IsMediaDeliveryTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaDeliveryTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsMediaInfoTabSelected As Boolean
            Get
                IsMediaInfoTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaInfoTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsDefaultsNotesTabSelected As Boolean
            Get
                IsDefaultsNotesTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_DefaultsNotesTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsDefaultCommentsTabSelected As Boolean
            Get
                IsDefaultCommentsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaDefaultsTab, If(TabControlMediaDefaults_MediaDefaultsTab.SelectedTab Is TabItemMediaDefaults_DefaultCommentsTab, True, False), False)
            End Get
        End Property
        Public ReadOnly Property IsMediaDefaultsTabSelected As Boolean
            Get
                IsMediaDefaultsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaDefaultsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsPricingsTabSelected As Boolean
            Get
                IsPricingsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_PricingsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsDocumentsTabSelected As Boolean
            Get
                IsDocumentsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_DocumentsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsContractsTabSelected As Boolean
            Get
                IsContractsTabSelected = If(TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_ContractsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property CanAddNewMediaSpec As Boolean
            Get

                Try

                    CanAddNewMediaSpec = Not (From Node In TreeListControlMediaSpecs_MediaSpecs.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList
                                              Where Node.Item("Code") Is Nothing OrElse
                                                    Node.Item("Code") = ""
                                              Select Node).Any

                Catch ex As Exception
                    CanAddNewMediaSpec = True
                End Try

            End Get
        End Property
        Public ReadOnly Property SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.VendorSortKey)
            Get
                SortKeyList = _SortKeyList
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property VendorContractManager As AdvantageFramework.WinForm.Presentation.Controls.VendorContractManagerControl
            Get
                Return VendorContractManagerControlContracts_Contracts
            End Get
        End Property
        Public ReadOnly Property ShowManageMarkets As Boolean
            Get
                ShowManageMarkets = (Me.IsMediaDefaultsTabSelected AndAlso _IsSelectedMarketCanadadian AndAlso Me.ComboBoxMain_DefaultCategory.GetSelectedValue = "T" AndAlso Me.ParentForm IsNot Nothing AndAlso
                    DirectCast(Me.ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).UserEntryChanged = False)
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
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            ' objects
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim EEOC2PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Vendor)

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)
                        _CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)
                        _CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)
                        _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)
                        _CanUserCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor)

                        _HasAccessToVendorContact = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)
                        _CanUserUpdateInVendorContact = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)
                        _CanUserAddInVendorContact = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)

                        _HasAccessToVendorRep = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
                        _CanUserUpdateInVendorRep = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
                        _CanUserAddInVendorRep = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)

                        ButtonOptions_SortActions.SecurityEnabled = Me.CanUserUpdate
                        ButtonRightSection_AddEEOCStatus.SecurityEnabled = Me.CanUserUpdate
                        ButtonRightSection_RemoveEEOCStatus.SecurityEnabled = Me.CanUserUpdate

                        If Me.CanUserUpdate = False Then

                            VendorPricingControlPricings_VendorPricings.DataGridViewForm_VendorPricings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                            VendorPricingControlPricings_VendorPricings.DataGridViewForm_VendorPricings.CurrentView.OptionsBehavior.Editable = False

                        Else

                            VendorPricingControlPricings_VendorPricings.DataGridViewForm_VendorPricings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
                            VendorPricingControlPricings_VendorPricings.DataGridViewForm_VendorPricings.CurrentView.OptionsBehavior.Editable = True

                        End If

                        DataGridViewRepresentatives_VendorReps.CurrentView.OptionsBehavior.Editable = Me.CanUserUpdate
                        DataGridViewContacts_Contacts.CurrentView.OptionsBehavior.Editable = Me.CanUserUpdate
                        TreeListControlMediaSpecs_MediaSpecs.OptionsBehavior.Editable = Me.CanUserUpdate

                        EnableOrDisableTabs()

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Vendor)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList
                                EEOC2PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.VendorEEOC2)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                                DbContext.Database.Connection.Open()

                                _IsQuickbooksEnabled = AdvantageFramework.Quickbooks.IsQuickBooksEnabled(DbContext)

                                TextBoxContacts_DefaultVendorContactCode.ByPassUserEntryChanged = True
                                TextBoxRepresentatives_DefaultRep1.ByPassUserEntryChanged = True
                                TextBoxRepresentatives_DefaultRep2.ByPassUserEntryChanged = True

                                DataGridViewLeftSection_AvailableEEOCStatuses.MultiSelect = False
                                DataGridViewRightSection_SelectedEEOCStatuses.MultiSelect = False
                                DataGridViewContacts_Contacts.MultiSelect = False
                                DataGridViewRepresentatives_VendorReps.MultiSelect = False

                                _SubItemTextBox = New AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox

                                _SubItemTextBox.Session = _Session
                                _SubItemTextBox.ControlType = SubItemTextBox.Type.Default
                                _SubItemTextBox.MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.MediaSpecsDetail), AdvantageFramework.Database.Entities.MediaSpecsDetail.Properties.SpecData.ToString))

                                TextBoxContacts_DefaultVendorContactCode.Visible = False
                                TextBoxRepresentatives_DefaultRep1.Visible = False
                                TextBoxRepresentatives_DefaultRep2.Visible = False

                                _SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl

                                _SubItemGridLookUpEditControl.ValueType = GetType(System.String)

                                _SubItemGridLookUpEditControl.Session = _Session
                                _SubItemGridLookUpEditControl.ControlType = SubItemGridLookUpEditControl.Type.AdSize

                                _SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                                TreeListControlMediaSpecs_MediaSpecs.RepositoryItems.Add(_SubItemGridLookUpEditControl)
                                TreeListControlMediaSpecs_MediaSpecs.OptionsView.ShowRoot = False
                                TreeListControlMediaSpecs_MediaSpecs.OptionsSelection.MultiSelect = False
                                TreeListControlMediaSpecs_MediaSpecs.OptionsNavigation.AutoMoveRowFocus = True
                                TreeListControlMediaSpecs_MediaSpecs.OptionsNavigation.UseTabKey = True

                                '
                                ' Property Settings
                                '
                                ' Main Tab
                                TextBoxMain_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Code)

                                TextBoxNameAndAddress_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Name)
                                Address3LineControlNameAndAddress_Address.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.StreetAddressLine1)
                                Address3LineControlNameAndAddress_Address.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.StreetAddressLine2)
                                Address3LineControlNameAndAddress_Address.SetAddress3PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.StreetAddressLine3)
                                Address3LineControlNameAndAddress_Address.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.City)
                                Address3LineControlNameAndAddress_Address.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.County)
                                Address3LineControlNameAndAddress_Address.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.State)
                                Address3LineControlNameAndAddress_Address.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ZipCode)
                                Address3LineControlNameAndAddress_Address.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Country)
                                TextBoxNameAndAddress_Phone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PhoneNumber)
                                TextBoxNameAndAddress_PhoneExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PhoneNumberExtension)
                                TextBoxNameAndAddress_Fax.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.FaxPhoneNumber)
                                TextBoxNameAndAddress_FaxExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.FaxPhoneNumberExtension)

                                TextBoxPayToNameAndAddress_Vendor.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToCode)
                                TextBoxPayToNameAndAddress_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToName)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToAddressLine1)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToAddressLine2)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetAddress3PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToStreetAddressLine3)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToCity)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToCounty)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToState)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToZipCode)
                                Address3LineControlPayToNameAndAddress_PayToAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToCountry)
                                TextBoxPayToNameAndAddress_Phone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToPhoneNumber)
                                TextBoxPayToNameAndAddress_PhoneExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToPhoneNumberExtension)
                                TextBoxPayToNameAndAddress_Fax.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToFaxPhoneNumber)
                                TextBoxPayToNameAndAddress_FaxExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PayToFaxPhoneNumberExtension)

                                TextBoxMain_Website.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Website)
                                TextBoxMain_Email.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.EmailAddress)
                                TextBoxMain_PaymentManagerEmail.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PaymentManagerEmailAddress)
                                TextBoxMain_FederalTaxID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.TaxID)
                                ComboBoxMain_DefaultCategory.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VendorCategory)
                                TextBoxMain_VATNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VATNumber)

                                ' Default / Notes Tab
                                SearchableComboBoxDefaultNotes_Currency.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.CurrencyCode)
                                SearchableComboBoxDefaultNotes_Office.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.OfficeCode)
                                SearchableComboBoxDefaultNotes_DefaultAPAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DefaultAPAccount)
                                SearchableComboBoxDefaultNotes_DefaultExpenseAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DefaultExpenseAccount)
                                TextBoxDefaultNotes_VendorAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.AccountNumber)
                                TextBoxDefaultNotes_SortName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.SortName)
                                SearchableComboBoxDefaultNotes_DefaultFunction.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.FunctionCode)
                                SearchableComboBoxDefaultNotes_Terms.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VendorTermCode)
                                ComboBoxDefaultNotes_ACHType.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ACHType)
                                TextBoxDefaultNotes_Notes.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Notes)
                                SearchableComboBoxDefaultNotes_DefaultBank.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.BankCode)
                                ComboBoxDefaultNotes_VCCStatus.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VCCStatus)
                                NumericInputDefaultNotes_VCCLimit.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VCCAmount)
                                ComboBoxDefaultNotes_InvoiceCategory.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VendorInvoiceCategoryID)

                                ' EEOC 2 Tab
                                TextBoxMOBD_MinorityCertifcateNumber.SetPropertySettings(EEOC2PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorEEOC2.Properties.MinorityCertificateNumber)
                                TextBoxWBD_WBENCCertificationNumber.SetPropertySettings(EEOC2PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorEEOC2.Properties.WBENCCertificateNumber)

                                ' 1099 Info Tab
                                Address3LineControl1099Info_Address.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099StreetAddressLine1)
                                Address3LineControl1099Info_Address.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099StreetAddressLine2)
                                Address3LineControl1099Info_Address.SetAddress3PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099StreetAddressLine3)
                                Address3LineControl1099Info_Address.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099City)
                                Address3LineControl1099Info_Address.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099State)
                                Address3LineControl1099Info_Address.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099ZipCode)
                                Address3LineControl1099Info_Address.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099County)
                                Address3LineControl1099Info_Address.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Vendor1099Country)

                                ' Media Defaults Tab
                                SearchableComboBoxGeneralDefaultInformation_Market.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.MarketCode)
                                NumericInputGeneralDefaultInformation_CommissionPercent.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Commission)
                                NumericInputGeneralDefaultInformation_MarkupPercent.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Markup)
                                NumericInputGeneralDefaultInformation_OveragePercent.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.OveragePercent)
                                NumericInputGeneralDefaultInformation_ColumnWidth.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ColumnSize)
                                SearchableComboBoxGeneralDefaultInformation_TaxCode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DefaultSalesTax)
                                TextBoxGeneralDefaultInformation_VendorCodeCrossReference.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.VendorCodeCrossReference)
                                NumericInputDeadlines_MaterialCloseDays.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.MaterialCloseDays)
                                NumericInputDeadlines_SpaceCloseDays.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.SpaceCloseDays)
                                TextBoxGeneralDefaultInformation_CallLetters.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.CallLetters)
                                ComboBoxGeneralDefaultInformation_Band.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Band)
                                ComboBoxGeneralDefaultInformation_CanadianVendorType.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.CanadianVendorType)
                                ComboBoxGeneralDefaultInformation_CanadianVendorType.SetRequired(False)

                                ' Media Info Tab
                                NumericInputMagazine_Circulation.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DailyCirculation)
                                NumericInputMagazine_Issues.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Issues)
                                TextBoxMagazine_Cycles.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Cycles)
                                TextBoxMagazine_PublishingFrequency.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PublishingFrequency)
                                TextBoxMagazine_Editions.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Editions)

                                NumericInputNewspaper_SundayCirculation.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.SundayCirculation)
                                NumericInputNewspaper_DailyCirculation.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DailyCirculation)
                                TextBoxNewspaper_PublishingFrequency.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.PublishingFrequency)
                                TextBoxNewspaper_Editions.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.Editions)

                                'Media Delivery Tab
                                TextBoxMediaShipping_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToName)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToAddress)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToAddress2)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetAddress3PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToAddress3)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToCity)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToCounty)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToState)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToZip)
                                Address3LineControlMediaDelivery_MediaShippingAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToCountry)

                                TextBoxMediaShipping_Phone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToPhone)
                                TextBoxMediaShipping_PhoneExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ShipToPhoneExt)

                                ' Media Specs Tab
                                SearchableComboBoxMediaSpecs_DefaultSize.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.DefaultAdSize)

                                'Service Tax Tab

                                NumericInputServiceTax_Rate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Vendor.Properties.ServiceTaxRate)

                                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.VendorComment)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                                ' Media Defaults Tab
                                TextBoxDefaultComments_Instructions.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.Instructions)
                                TextBoxDefaultComments_FooterComment.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.FooterInfo)
                                TextBoxDefaultComments_RateInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.RateInfo)
                                TextBoxDefaultComments_MaterialNotes.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.MaterialNotes)
                                TextBoxDefaultComments_PositionInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.PositionInfo)
                                TextBoxDefaultComments_MiscInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.MiscInfo)
                                TextBoxDefaultComments_CloseInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.CloseInfo)

                                'Media Delivery Tab
                                TextBoxMediaDelivery_GeneralInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.DeliveryGeneralInformation)
                                TextBoxMediaDelivery_AcceptedMedia.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.AcceptedMedia)
                                TextBoxMediaDelivery_EFileInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.EFileInfo)
                                TextBoxMediaDelivery_PreferredMaterial.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.PreferenceMaterial)
                                TextBoxMediaDelivery_FTPUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.FTPUserName)
                                TextBoxMediaDelivery_FTPPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.FTPPassword)
                                TextBoxMediaDelivery_FTPDirectory.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.VendorComment.Properties.FTPDirectory)

                                '
                                ' DataSource
                                '
                                ' Main Tab
                                ComboBoxMain_DefaultCategory.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorCategory)).ToList
                                                                           Select [Name] = EnumObject.Description,
                                                                                  [Value] = EnumObject.Code).ToList

                                SearchableComboBoxDefaultNotes_DefaultAPAccount.AddInactiveItemsOnSelectedValue = True

                                ComboBoxDefaultNotes_ACHType.DataSource = (From EnumName In AdvantageFramework.EnumUtilities.GetEnumNameList(GetType(AdvantageFramework.Database.Entities.ACHType), False).ToList
                                                                           Select [Name] = EnumName.ToString,
                                                                                  [Value] = EnumName.ToString).ToList

                                ComboBoxDefaultNotes_VCCStatus.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.VCCStatuses), False)

                                NumericInputGeneralDefaultInformation_CommissionPercent.EditValue = Nothing
                                NumericInputGeneralDefaultInformation_MarkupPercent.EditValue = Nothing
                                NumericInputGeneralDefaultInformation_ColumnWidth.EditValue = Nothing


                                SearchableComboBoxServiceTax_Type.HideValueMemberColumn = True
                                SearchableComboBoxServiceTax_Type.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorServiceTaxType))
                                                                                Select Entity.Code,
                                                                                       [Description] = Entity.Description).ToList

                                ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods), False)

                                ComboBoxDefaultNotes_InvoiceCategory.DataSource = AdvantageFramework.Database.Procedures.VendorInvoiceCategory.Load(DbContext)

                                ComboBoxGeneralDefaultInformation_CanadianVendorType.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CanadianVendorTypes)).ToList
                                                                                                   Select [Description] = EnumObject.Description,
                                                                                                          [Code] = CInt(EnumObject.Code)).ToList

                                LoadDropDownDataSources()

                                DbContext.Database.Connection.Close()

                            End Using

                        End Using

                        DataGridViewContacts_Contacts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.VendorContact))
                        DataGridViewContacts_Contacts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                        DataGridViewRepresentatives_VendorReps.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.VendorRepresentative))
                        DataGridViewRepresentatives_VendorReps.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadVendorEntity(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor, ByVal IsNew As Boolean)

            If Vendor IsNot Nothing Then

                If IsNew = True OrElse TabItemVendorDetails_MainTab.Tag = True Then

                    SaveMainTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_DefaultsNotesTab.Tag = True Then

                    SaveDefaultsNotesTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_EEOCStatusTab.Tag = True Then

                    SaveEEOCStatusTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_1099InfoTab.Tag = True Then

                    Save1099InfoTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_ContactsTab.Tag = True Then

                    SaveContactsTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_RepresentativesTab.Tag = True Then

                    SaveRepresentativesTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_MediaDefaultsTab.Tag = True OrElse _CategoryChanged = True Then

                    SaveMediaDefaultsTab(Vendor)
                    _CategoryChanged = False

                End If

                If IsNew = True OrElse TabItemVendorDetails_MediaInfoTab.Tag = True Then

                    SaveMediaInfoTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_MediaDeliveryTab.Tag = True Then

                    SaveMediaDeliveryTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_MediaSpecsTab.Tag = True Then

                    SaveMediaSpecsTab(Vendor)

                End If

                If IsNew = True OrElse TabItemVendorDetails_VendorServiceTaxTab.Tag = True Then

                    SaveServiceTaxTab(Vendor)

                End If

            End If

        End Sub
        Private Sub SaveVendorComment(ByVal VendorComment As AdvantageFramework.Database.Entities.VendorComment)

            If VendorComment IsNot Nothing Then

                If TabItemVendorDetails_MediaDefaultsTab.Tag = True Then

                    VendorComment.UseFooter = Convert.ToInt16(CheckBoxDefaultComments_UseFooterComment.Checked)
                    VendorComment.Instructions = TextBoxDefaultComments_Instructions.Text
                    VendorComment.FooterInfo = TextBoxDefaultComments_FooterComment.Text
                    VendorComment.RateInfo = TextBoxDefaultComments_RateInfo.Text
                    VendorComment.MaterialNotes = TextBoxDefaultComments_MaterialNotes.Text
                    VendorComment.PositionInfo = TextBoxDefaultComments_PositionInfo.Text
                    VendorComment.MiscInfo = TextBoxDefaultComments_MiscInfo.Text
                    VendorComment.CloseInfo = TextBoxDefaultComments_CloseInfo.Text

                End If

                If TabItemVendorDetails_MediaDeliveryTab.Tag = True Then

                    VendorComment.DeliveryGeneralInformation = TextBoxMediaDelivery_GeneralInfo.Text
                    VendorComment.AcceptedMedia = TextBoxMediaDelivery_AcceptedMedia.Text
                    VendorComment.EFileInfo = TextBoxMediaDelivery_EFileInfo.Text
                    VendorComment.PreferenceMaterial = TextBoxMediaDelivery_PreferredMaterial.Text
                    VendorComment.FTPUserName = TextBoxMediaDelivery_FTPUserName.Text
                    VendorComment.FTPPassword = TextBoxMediaDelivery_FTPPassword.Text
                    VendorComment.FTPDirectory = TextBoxMediaDelivery_FTPDirectory.Text

                End If

            End If

        End Sub
        Private Sub LoadVendorCommentEntity(ByVal VendorComment As AdvantageFramework.Database.Entities.VendorComment, ByVal IsNew As Boolean)

            If VendorComment IsNot Nothing Then

                If IsNew = True OrElse TabItemVendorDetails_MediaDefaultsTab.Tag = True OrElse TabItemVendorDetails_MediaDeliveryTab.Tag = True Then

                    SaveVendorComment(VendorComment)

                End If

            End If

        End Sub
        Private Function FillVendorCommentObject(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor, ByRef IsNew As Boolean) As AdvantageFramework.Database.Entities.VendorComment

            'objects
            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If IsNew = False Then

                        VendorComment = AdvantageFramework.Database.Procedures.VendorComment.LoadByVendorCode(DbContext, Vendor.Code)

                    End If

                    If VendorComment IsNot Nothing Then

                        LoadVendorCommentEntity(VendorComment, False)

                    ElseIf TextBoxMediaDelivery_GeneralInfo.Text <> "" OrElse
                           TextBoxMediaDelivery_AcceptedMedia.Text <> "" OrElse
                           TextBoxMediaDelivery_EFileInfo.Text <> "" OrElse
                           TextBoxMediaDelivery_PreferredMaterial.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPUserName.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPPassword.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPDirectory.Text <> "" OrElse
                           TextBoxMediaDelivery_GeneralInfo.Text <> "" OrElse
                           TextBoxMediaDelivery_AcceptedMedia.Text <> "" OrElse
                           TextBoxMediaDelivery_EFileInfo.Text <> "" OrElse
                           TextBoxMediaDelivery_PreferredMaterial.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPUserName.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPPassword.Text <> "" OrElse
                           TextBoxMediaDelivery_FTPDirectory.Text <> "" OrElse
                           TextBoxDefaultComments_Instructions.Text <> "" OrElse
                           TextBoxDefaultComments_FooterComment.Text <> "" OrElse
                           TextBoxDefaultComments_RateInfo.Text <> "" OrElse
                           TextBoxDefaultComments_MaterialNotes.Text <> "" OrElse
                           TextBoxDefaultComments_PositionInfo.Text <> "" OrElse
                           TextBoxDefaultComments_MiscInfo.Text <> "" OrElse
                           TextBoxDefaultComments_CloseInfo.Text <> "" Then

                        VendorComment = New AdvantageFramework.Database.Entities.VendorComment

                        IsNew = True

                        LoadVendorCommentEntity(VendorComment, True)

                        VendorComment.VendorCode = Vendor.Code

                    End If

                End Using

            Catch ex As Exception
                VendorComment = Nothing
            Finally
                FillVendorCommentObject = VendorComment
            End Try

        End Function
        Private Sub LoadVendorDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim HasQuickBookBill As Boolean = False

            If _VendorCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        If TabItem Is Nothing Then

                            For Each TabItem In TabControlControl_VendorDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                                TabItem.Tag = False

                            Next

                            If _LastSelectedTabBeforeClearControl IsNot Nothing AndAlso _LastSelectedTabBeforeClearControl.Visible Then

                                TabItem = _LastSelectedTabBeforeClearControl

                            Else

                                TabItem = TabItemVendorDetails_MainTab

                            End If

                        End If

                        If TabItem.Tag = False Then

                            If TabItem Is TabItemVendorDetails_MainTab OrElse TabItem Is TabItemVendorDetails_DefaultsNotesTab Then

                                If _IsQuickbooksEnabled Then

                                    _IsLoading = True

                                    SearchableComboBoxMain_QuickBooksVendor.DataSource = _QuickBooksVendors

                                    SearchableComboBoxMain_QuickBooksVendor.SelectedValue = AdvantageFramework.Quickbooks.GetVendorCrossReferenceVendorID(DbContext, Vendor.Code, HasQuickBookBill)

                                    SearchableComboBoxMain_QuickBooksVendor.Enabled = (HasQuickBookBill = False)

                                    _IsLoading = False

                                End If

                                LoadMainTab(Vendor)
                                LoadDefaultsNotesTab(Vendor)

                            End If

                                If TabItem Is TabItemVendorDetails_EEOCStatusTab Then

                                    LoadEEOCStatusTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_EEOC2Tab Then

                                    LoadEEOC2Tab(DbContext, Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_1099InfoTab Then

                                    Load1099InfoTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_ContactsTab Then

                                    LoadContactsTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_RepresentativesTab Then

                                    LoadRepresentativesTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_MediaDefaultsTab Then

                                    LoadMediaDefaultsTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_MediaInfoTab Then

                                    LoadMediaInfoTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_MediaDeliveryTab Then

                                    LoadMediaDeliveryTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_MediaSpecsTab Then

                                    LoadMediaSpecsTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_PricingsTab Then

                                    LoadPricingsTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_DocumentsTab Then

                                    LoadDocumentsTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_VendorServiceTaxTab Then

                                    LoadServiceTaxTab(Vendor)

                                End If

                                If TabItem Is TabItemVendorDetails_ContractsTab Then

                                    LoadContractsTab(Vendor)

                                End If

                            End If

                        End If

                End Using

            End If

        End Sub
        Private Sub LoadMainTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If Vendor IsNot Nothing Then

                TextBoxMain_Code.Text = Vendor.Code
                CheckBoxMain_Inactive.Checked = Not Convert.ToBoolean(Vendor.ActiveFlag.GetValueOrDefault(0))

                TextBoxNameAndAddress_Name.Text = Vendor.Name

                LoadNameAndAddress(Vendor, Address3LineControlNameAndAddress_Address)

                TextBoxNameAndAddress_Phone.Text = Vendor.PhoneNumber
                TextBoxNameAndAddress_PhoneExt.Text = Vendor.PhoneNumberExtension
                TextBoxNameAndAddress_Fax.Text = Vendor.FaxPhoneNumber
                TextBoxNameAndAddress_FaxExt.Text = Vendor.FaxPhoneNumberExtension

                TextBoxPayToNameAndAddress_Vendor.Text = Vendor.PayToCode

                If Vendor.PayToCode <> Vendor.Code Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PayToVendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Vendor.PayToCode)

                    End Using

                Else

                    PayToVendor = Vendor

                End If

                LoadNameAndAddress(PayToVendor, Address3LineControlPayToNameAndAddress_PayToAddress)

                TextBoxPayToNameAndAddress_Phone.Text = Vendor.PayToPhoneNumber
                TextBoxPayToNameAndAddress_PhoneExt.Text = Vendor.PayToPhoneNumberExtension
                TextBoxPayToNameAndAddress_Fax.Text = Vendor.PayToFaxPhoneNumber
                TextBoxPayToNameAndAddress_FaxExt.Text = Vendor.PayToFaxPhoneNumberExtension

                TextBoxMain_Website.Text = Vendor.Website
                TextBoxMain_Email.Text = Vendor.EmailAddress
                TextBoxMain_PaymentManagerEmail.Text = Vendor.PaymentManagerEmailAddress
                TextBoxMain_FederalTaxID.Text = Vendor.TaxID

                CheckBoxMain_Internet.CheckValue = Vendor.InternetCategory.GetValueOrDefault(0)
                CheckBoxMain_Magazine.CheckValue = Vendor.MagazineCategory.GetValueOrDefault(0)
                CheckBoxMain_Newspaper.CheckValue = Vendor.NewspaperCategory.GetValueOrDefault(0)
                CheckBoxMain_OutOfHome.CheckValue = Vendor.OutOfHomeCategory.GetValueOrDefault(0)
                CheckBoxMain_Radio.CheckValue = Vendor.RadioCategory.GetValueOrDefault(0)
                CheckBoxMain_Television.CheckValue = Vendor.TVCategory.GetValueOrDefault(0)

                TextBoxMain_VATNumber.Text = Vendor.VATNumber

                TabItemVendorDetails_MainTab.Tag = True

            End If

        End Sub
        Private Sub LoadDefaultsNotesTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                CheckBoxDefaultNotes_ACH.Checked = Convert.ToBoolean(Vendor.IsACH.GetValueOrDefault(0))
                CheckBoxDefaultNotes_EmployeeVendor.Checked = Convert.ToBoolean(Vendor.EmployeeVendor.GetValueOrDefault(0))
                CheckBoxDefaultNotes_OneCheckPerInvoice.Checked = Convert.ToBoolean(Vendor.OneCheckPerInvoice.GetValueOrDefault(0))

                ComboBoxDefaultNotes_ACHType.SelectedValue = Vendor.ACHType
                SearchableComboBoxDefaultNotes_Currency.SelectedValue = Vendor.CurrencyCode
                SearchableComboBoxDefaultNotes_Office.SelectedValue = Vendor.OfficeCode
                SearchableComboBoxDefaultNotes_DefaultAPAccount.SelectedValue = Vendor.DefaultAPAccount
                SearchableComboBoxDefaultNotes_DefaultExpenseAccount.SelectedValue = Vendor.DefaultExpenseAccount
                TextBoxDefaultNotes_VendorAccount.Text = Vendor.AccountNumber
                TextBoxDefaultNotes_SortName.Text = Vendor.SortName
                SearchableComboBoxDefaultNotes_DefaultFunction.SelectedValue = Vendor.FunctionCode
                SearchableComboBoxDefaultNotes_Terms.SelectedValue = Vendor.VendorTermCode
                SearchableComboBoxDefaultNotes_DefaultBank.SelectedValue = Vendor.BankCode
                ComboBoxDefaultNotes_VCCStatus.SelectedValue = Vendor.VCCStatus
                NumericInputDefaultNotes_VCCLimit.EditValue = Vendor.VCCAmount
                CheckBoxDefaultNotes_SpecialTerms.Checked = Vendor.HasSpecialTerms.GetValueOrDefault(False)
                ComboBoxDefaultNotes_InvoiceCategory.SelectedValue = Vendor.VendorInvoiceCategoryID

                If Vendor.VCCStatus.GetValueOrDefault(0) = AdvantageFramework.Database.Entities.VCCStatuses.Accepted Then

                    CheckBoxDefaultNotes_SendVCCWithMediaOrder.Enabled = True
                    CheckBoxDefaultNotes_SendVCCWithMediaOrder.Checked = Vendor.SendVCCWithMediaOrder

                Else

                    CheckBoxDefaultNotes_SendVCCWithMediaOrder.Checked = False
                    CheckBoxDefaultNotes_SendVCCWithMediaOrder.Enabled = False

                End If

                TextBoxDefaultNotes_Notes.Text = Vendor.Notes

                LoadSortKeys()

                TabItemVendorDetails_DefaultsNotesTab.Tag = True

            End If

        End Sub
        Private Sub LoadEEOCStatusTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                LoadEEOCStatuses()

                TabItemVendorDetails_EEOCStatusTab.Tag = True

            End If

        End Sub
        Private Sub LoadEEOC2Tab(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            Dim VendorEEOC2 As AdvantageFramework.Database.Entities.VendorEEOC2 = Nothing

            If Vendor IsNot Nothing Then

                LoadEEOCStatuses()

                VendorEEOC2 = AdvantageFramework.Database.Procedures.VendorEEOC2.LoadByVendorCode(DbContext, Vendor.Code)

                If VendorEEOC2 IsNot Nothing Then

                    If VendorEEOC2.Ethnicity.HasValue Then

                        SearchableComboBoxMOBD_Ethnicity.SelectedValue = CShort(VendorEEOC2.Ethnicity)

                    Else

                        SearchableComboBoxMOBD_Ethnicity.SelectedValue = Nothing

                    End If

                    TextBoxMOBD_MinorityCertifcateNumber.Text = VendorEEOC2.MinorityCertificateNumber
                    DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ValueObject = VendorEEOC2.MinorityCertificateNumberExpirationDate
                    CheckBoxMODB_IsNMSDC.Checked = VendorEEOC2.IsNMSDC
                    CheckBoxWBD_IsWBENC.Checked = VendorEEOC2.IsWBENC
                    TextBoxWBD_WBENCCertificationNumber.Text = VendorEEOC2.WBENCCertificateNumber
                    DateTimePickerWBD_WBENCCertificationExpirationDate.ValueObject = VendorEEOC2.WBENCCertificateNumberExpirationDate

                End If

            End If

            TabItemVendorDetails_EEOC2Tab.Tag = True

        End Sub
        Private Sub Load1099InfoTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim DefaultCategory As Short = Nothing

            If Vendor IsNot Nothing Then

                CheckBox1099Info_Is1099Vendor.Checked = Convert.ToBoolean(Vendor.Vendor1099Flag.GetValueOrDefault(0))
                CheckBox1099Info_Use1099Address.Checked = Convert.ToBoolean(Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0))
                Address3LineControl1099Info_Address.Address = Vendor.Vendor1099StreetAddressLine1
                Address3LineControl1099Info_Address.Address2 = Vendor.Vendor1099StreetAddressLine2
                Address3LineControl1099Info_Address.Address3 = Vendor.Vendor1099StreetAddressLine3
                Address3LineControl1099Info_Address.City = Vendor.Vendor1099City
                Address3LineControl1099Info_Address.State = Vendor.Vendor1099State
                Address3LineControl1099Info_Address.Zip = Vendor.Vendor1099ZipCode
                Address3LineControl1099Info_Address.County = Vendor.Vendor1099County
                Address3LineControl1099Info_Address.Country = Vendor.Vendor1099Country

                DefaultCategory = Vendor.Vendor1099Category.GetValueOrDefault(0)

                Select Case DefaultCategory

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation

                        RadioButtonControl1099Info_NonEmployeeCompensation.Checked = True

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome

                        RadioButtonControl1099Info_OtherIncome.Checked = True

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Rent

                        RadioButtonControl1099Info_Rent.Checked = True

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Royalties

                        RadioButtonControl1099Info_Royalties.Checked = True

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney

                        RadioButtonControl1099Info_GrossProceedsToAttorney.Checked = True

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare

                        RadioButtonControl1099Info_MedicalHealthcare.Checked = True

                    Case Else

                        RadioButtonControl1099Info_NonEmployeeCompensation.Checked = True

                End Select

                TabItemVendorDetails_1099InfoTab.Tag = True

            End If

        End Sub
        Private Sub LoadContactsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                TextBoxContacts_DefaultVendorContactCode.Text = Vendor.DefaultVendorContactCode

                LoadVendorContacts()

                TabItemVendorDetails_ContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadRepresentativesTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                TextBoxRepresentatives_DefaultRep1.Text = Vendor.DefaultVendorRepresentativeCode1
                TextBoxRepresentatives_DefaultRep2.Text = Vendor.DefaultVendorRepresentativeCode2

                LoadVendorRepresentatives()

                TabItemVendorDetails_RepresentativesTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaDefaultsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim VendorMediaDefaultUnits As AdvantageFramework.Database.Entities.VendorMediaDefaultUnits = Nothing
            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If Vendor IsNot Nothing Then

                If Vendor.DefaultUnits <> "" Then

                    Try

                        VendorMediaDefaultUnits = DirectCast([Enum].Parse(GetType(AdvantageFramework.Database.Entities.VendorMediaDefaultUnits), Vendor.DefaultUnits), AdvantageFramework.Database.Entities.VendorMediaDefaultUnits)

                    Catch ex As Exception
                        VendorMediaDefaultUnits = Database.Entities.VendorMediaDefaultUnits.BM
                    End Try

                End If

                If _Session.IsNielsenSetup Then

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                        SearchableComboBoxGeneralDefaultInformation_RadioStation.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen).ToList
                        SearchableComboBoxGeneralDefaultInformation_TVStation.DataSource = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                                                                            Where Entity.SourceType = "B"
                                                                                            Select Entity).ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, _Session.NielsenClientCodeForHosted, Nothing)

                            Else

                                SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Nothing)

                            End If

                        End Using

                    End Using

                End If

                If _Session.IsEastlanSetup Then

                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Eastlan).ToList

                    End Using

                End If

                If _Session.IsComscoreSetup Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, Vendor.MarketCode)

                        If Market IsNot Nothing AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                            SearchableComboBoxGeneralDefaultInformation_ComscoreStation.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)(String.Format("exec [advsp_comscore_stations] {0}, NULL", Market.ComscoreNewMarketNumber.Value)).ToList.Where(Function(Entity) Entity.ComscorePrimaryMarketNumber IsNot Nothing AndAlso Entity.ComscorePrimaryMarketNumber = Market.ComscoreNewMarketNumber.Value).ToList

                        End If

                    End Using

                End If

                SearchableComboBoxGeneralDefaultInformation_Market.SelectedValue = Vendor.MarketCode
                CheckBoxGeneralDefaultInformation_IsCableSystem.Checked = Vendor.IsCableSystem
                ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue = Vendor.CanadianVendorType
                SearchableComboBoxGeneralDefaultInformation_RadioStation.SelectedValue = Vendor.NielsenRadioStationComboID
                SearchableComboBoxGeneralDefaultInformation_TVStation.SelectedValue = Vendor.NielsenTVStationCode
                SearchableComboBoxGeneralDefaultInformation_CableSyscode.SelectedValue = Vendor.NCCTVSyscodeID
                SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.SelectedValue = Vendor.EastlanRadioStationComboID
                SearchableComboBoxGeneralDefaultInformation_ComscoreStation.SelectedValue = Vendor.ComscoreTVStationID

                CheckBoxIsNielsenSubscriber.Checked = Vendor.IsNielsenSubsciber
                CheckBoxIsComscoreSubscriber.Checked = Vendor.IsComscoreSubsciber

                NumericInputGeneralDefaultInformation_CommissionPercent.EditValue = Vendor.Commission
                NumericInputGeneralDefaultInformation_MarkupPercent.EditValue = Vendor.Markup
                NumericInputGeneralDefaultInformation_OveragePercent.EditValue = Vendor.OveragePercent
                NumericInputGeneralDefaultInformation_ColumnWidth.EditValue = Vendor.ColumnSize
                SearchableComboBoxGeneralDefaultInformation_TaxCode.SelectedValue = Vendor.DefaultSalesTax
                TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Text = Vendor.VendorCodeCrossReference
                TextBoxGeneralDefaultInformation_CallLetters.Text = Vendor.CallLetters

                If String.IsNullOrWhiteSpace(Vendor.Band) Then

                    If ComboBoxMain_DefaultCategory.GetSelectedValue() = "R" Then

                        ComboBoxGeneralDefaultInformation_Band.SelectedValue = "AM"

                    ElseIf ComboBoxMain_DefaultCategory.GetSelectedValue() = "T" Then

                        ComboBoxGeneralDefaultInformation_Band.SelectedValue = "TV"

                    End If

                Else

                    ComboBoxGeneralDefaultInformation_Band.SelectedValue = Vendor.Band

                End If

                CheckBoxApplyTo_AddlCharge.Checked = Convert.ToBoolean(Vendor.TaxAdditionalCharge.GetValueOrDefault(0))
                CheckBoxApplyTo_Commission.Checked = Convert.ToBoolean(Vendor.TaxCommission.GetValueOrDefault(0))
                CheckBoxApplyTo_LineNet.Checked = Convert.ToBoolean(Vendor.TaxLineNet.GetValueOrDefault(0))
                CheckBoxApplyTo_NetCharge.Checked = Convert.ToBoolean(Vendor.TaxNetCharge.GetValueOrDefault(0))
                CheckBoxApplyTo_NetDiscount.Checked = Convert.ToBoolean(Vendor.TaxNetDiscount.GetValueOrDefault(0))
                CheckBoxApplyTo_Rebate.Checked = Convert.ToBoolean(Vendor.TaxRebate.GetValueOrDefault(0))
                CheckBoxApplyTo_UseFlags.Checked = Convert.ToBoolean(Vendor.UseTaxFlags.GetValueOrDefault(0))

                NumericInputDeadlines_MaterialCloseDays.EditValue = Vendor.MaterialCloseDays
                NumericInputDeadlines_SpaceCloseDays.EditValue = Vendor.SpaceCloseDays

                Select Case VendorMediaDefaultUnits

                    Case Database.Entities.VendorMediaDefaultUnits.M, Database.Entities.VendorMediaDefaultUnits.BM

                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Checked = True

                    Case Database.Entities.VendorMediaDefaultUnits.CM, Database.Entities.VendorMediaDefaultUnits.W

                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Checked = True

                    Case Database.Entities.VendorMediaDefaultUnits.D, Database.Entities.VendorMediaDefaultUnits.F, "DB", "4"

                        RadioButtonControlUnits_Daily.Checked = True

                        'Case Database.Entities.VendorMediaDefaultUnits.F, "4"

                        '    RadioButtonControlUnits_4week.Checked = True

                    Case Else

                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Checked = True

                End Select

                If Vendor.DefaultNetGross.GetValueOrDefault(0) = 0 Then

                    RadioButtonControlRates_Net.Checked = True

                    If (ComboBoxMain_DefaultCategory.SelectedValue = "M" OrElse ComboBoxMain_DefaultCategory.SelectedValue = "R" OrElse ComboBoxMain_DefaultCategory.SelectedValue = "T" OrElse ComboBoxMain_DefaultCategory.SelectedValue = "O") And Vendor.VendorCategory = "P" Then
                        RadioButtonControlRates_Gross.Checked = True
                    End If

                ElseIf Vendor.DefaultNetGross.GetValueOrDefault(0) = 1 Then

                    RadioButtonControlRates_Gross.Checked = True

                    If (ComboBoxMain_DefaultCategory.SelectedValue = "N" OrElse ComboBoxMain_DefaultCategory.SelectedValue = "I" OrElse ComboBoxMain_DefaultCategory.SelectedValue = "Z") And Vendor.VendorCategory = "M" And Vendor.VendorCategory = "R" And Vendor.VendorCategory = "T" And Vendor.VendorCategory = "O" Then
                        RadioButtonControlRates_Net.Checked = True
                    End If

                Else

                    RadioButtonControlRates_Net.Checked = True

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorComment = AdvantageFramework.Database.Procedures.VendorComment.LoadByVendorCode(DbContext, Vendor.Code)

                End Using

                If VendorComment IsNot Nothing Then

                    CheckBoxDefaultComments_UseFooterComment.Checked = Convert.ToBoolean(VendorComment.UseFooter.GetValueOrDefault(0))
                    TextBoxDefaultComments_Instructions.Text = VendorComment.Instructions
                    TextBoxDefaultComments_FooterComment.Text = VendorComment.FooterInfo
                    TextBoxDefaultComments_RateInfo.Text = VendorComment.RateInfo
                    TextBoxDefaultComments_MaterialNotes.Text = VendorComment.MaterialNotes
                    TextBoxDefaultComments_PositionInfo.Text = VendorComment.PositionInfo
                    TextBoxDefaultComments_MiscInfo.Text = VendorComment.MiscInfo
                    TextBoxDefaultComments_CloseInfo.Text = VendorComment.CloseInfo

                End If

                TabItemVendorDetails_MediaDefaultsTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaInfoTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim DefaultCategory As AdvantageFramework.Database.Entities.VendorCategory = Nothing

            If Vendor IsNot Nothing Then

                Try

                    DefaultCategory = DirectCast(ComboBoxMain_DefaultCategory.Tag, AdvantageFramework.Database.Entities.VendorCategory)

                Catch ex As Exception
                    DefaultCategory = Nothing
                End Try

                Select Case DefaultCategory

                    Case AdvantageFramework.Database.Entities.VendorCategory.Magazine

                        NumericInputMagazine_Circulation.EditValue = Vendor.DailyCirculation
                        NumericInputMagazine_Issues.EditValue = Vendor.Issues
                        TextBoxMagazine_Cycles.Text = Vendor.Cycles
                        TextBoxMagazine_PublishingFrequency.Text = Vendor.PublishingFrequency
                        TextBoxMagazine_Editions.Text = Vendor.Editions

                    Case AdvantageFramework.Database.Entities.VendorCategory.Newspaper

                        NumericInputNewspaper_SundayCirculation.EditValue = Vendor.SundayCirculation
                        NumericInputNewspaper_DailyCirculation.EditValue = Vendor.DailyCirculation
                        TextBoxNewspaper_PublishingFrequency.Text = Vendor.PublishingFrequency
                        TextBoxNewspaper_Editions.Text = Vendor.Editions

                End Select

                TabItemVendorDetails_MediaInfoTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaDeliveryTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing

            If Vendor IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorComment = AdvantageFramework.Database.Procedures.VendorComment.LoadByVendorCode(DbContext, Vendor.Code)

                End Using

                If VendorComment IsNot Nothing Then

                    TextBoxMediaDelivery_GeneralInfo.Text = VendorComment.DeliveryGeneralInformation
                    TextBoxMediaDelivery_AcceptedMedia.Text = VendorComment.AcceptedMedia
                    TextBoxMediaDelivery_EFileInfo.Text = VendorComment.EFileInfo
                    TextBoxMediaDelivery_PreferredMaterial.Text = VendorComment.PreferenceMaterial
                    TextBoxMediaDelivery_FTPUserName.Text = VendorComment.FTPUserName
                    TextBoxMediaDelivery_FTPPassword.Text = VendorComment.FTPPassword
                    TextBoxMediaDelivery_FTPDirectory.Text = VendorComment.FTPDirectory

                End If

                If String.IsNullOrWhiteSpace(Vendor.ShipToName) Then
                    TextBoxMediaShipping_Name.Text = Vendor.Name
                Else
                    TextBoxMediaShipping_Name.Text = Vendor.ShipToName
                End If

                Address3LineControlMediaDelivery_MediaShippingAddress.Address = Vendor.ShipToAddress
                Address3LineControlMediaDelivery_MediaShippingAddress.Address2 = Vendor.ShipToAddress2
                Address3LineControlMediaDelivery_MediaShippingAddress.Address3 = Vendor.ShipToAddress3
                Address3LineControlMediaDelivery_MediaShippingAddress.City = Vendor.ShipToCity
                Address3LineControlMediaDelivery_MediaShippingAddress.County = Vendor.ShipToCounty
                Address3LineControlMediaDelivery_MediaShippingAddress.State = Vendor.ShipToState
                Address3LineControlMediaDelivery_MediaShippingAddress.Zip = Vendor.ShipToZip
                Address3LineControlMediaDelivery_MediaShippingAddress.Country = Vendor.ShipToCountry

                TextBoxMediaShipping_Phone.Text = Vendor.ShipToPhone
                TextBoxMediaShipping_PhoneExt.Text = Vendor.ShipToPhoneExt

                ComboBoxMediaDelivery_DefaultCorrespondenceMethod.SelectedValue = Vendor.DefaultCorrespondenceMethod

                TabItemVendorDetails_MediaDeliveryTab.Tag = True

            End If

        End Sub
        Private Sub LoadMediaSpecsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                SearchableComboBoxMediaSpecs_DefaultSize.Tag = Vendor.DefaultAdSize

                LoadAdSizes()

                LoadMediaSpecs()

                TabItemVendorDetails_MediaSpecsTab.Tag = True

            End If

        End Sub
        Private Sub LoadPricingsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                VendorPricingControlPricings_VendorPricings.Enabled = VendorPricingControlPricings_VendorPricings.LoadControl(Vendor.Code)

                TabItemVendorDetails_PricingsTab.Tag = True

            End If

        End Sub
        Private Sub LoadDocumentsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            DocumentManagerControlDocuments_VendorDocuments.ClearControl()

            DocumentManagerControlDocuments_VendorDocuments.Enabled = (Vendor IsNot Nothing)

            If DocumentManagerControlDocuments_VendorDocuments.Enabled Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Vendor) With {.VendorCode = Vendor.Code}

                DocumentManagerControlDocuments_VendorDocuments.Enabled = DocumentManagerControlDocuments_VendorDocuments.LoadControl(Database.Entities.DocumentLevel.Vendor, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemVendorDetails_DocumentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadServiceTaxTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                SearchableComboBoxServiceTax_Code.SelectedValue = Vendor.VendorServiceTaxID
                SearchableComboBoxServiceTax_Type.SelectedValue = Vendor.ServiceTaxType

                CheckBoxServiceTax_Enabled.Checked = Vendor.ServiceTaxEnabled.GetValueOrDefault(False)
                CheckBoxServiceTax_Waiver.Checked = Vendor.ServiceTaxWaiver.GetValueOrDefault(False)

                NumericInputServiceTax_Rate.EditValue = Vendor.ServiceTaxRate
                DateTimePickerServiceTax_WaiverExpirationDate.ValueObject = Vendor.ServiceTaxWaiverExpirationDate

                TabItemVendorDetails_VendorServiceTaxTab.Tag = True

            End If

        End Sub
        Private Sub LoadContractsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                If VendorContractManagerControlContracts_Contracts.LoadControl(Vendor.Code) = False Then

                    VendorContractManagerControlContracts_Contracts.Enabled = False
                    VendorContractManagerControlContracts_Contracts.ClearControl()

                Else

                    VendorContractManagerControlContracts_Contracts.Enabled = True

                End If

                TabItemVendorDetails_ContractsTab.Tag = True

            End If

        End Sub
        Private Sub SaveMainTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                Vendor.Code = TextBoxMain_Code.Text

                If CheckBoxMain_Inactive.Checked Then

                    Vendor.ActiveFlag = Convert.ToInt16(0)

                Else

                    Vendor.ActiveFlag = Convert.ToInt16(1)

                End If

                Vendor.Name = TextBoxNameAndAddress_Name.Text.Trim
                Vendor.StreetAddressLine1 = Address3LineControlNameAndAddress_Address.Address
                Vendor.StreetAddressLine2 = Address3LineControlNameAndAddress_Address.Address2
                Vendor.StreetAddressLine3 = Address3LineControlNameAndAddress_Address.Address3
                Vendor.City = Address3LineControlNameAndAddress_Address.City
                Vendor.County = Address3LineControlNameAndAddress_Address.County
                Vendor.State = Address3LineControlNameAndAddress_Address.State
                Vendor.ZipCode = Address3LineControlNameAndAddress_Address.Zip
                Vendor.Country = Address3LineControlNameAndAddress_Address.Country
                Vendor.PhoneNumber = TextBoxNameAndAddress_Phone.Text
                Vendor.PhoneNumberExtension = TextBoxNameAndAddress_PhoneExt.Text
                Vendor.FaxPhoneNumber = TextBoxNameAndAddress_Fax.Text
                Vendor.FaxPhoneNumberExtension = TextBoxNameAndAddress_FaxExt.Text

                Vendor.PayToCode = TextBoxPayToNameAndAddress_Vendor.Text

                If Vendor.PayToCode = Vendor.Code Then

                    Vendor.PayToName = TextBoxPayToNameAndAddress_Name.Text.Trim
                    Vendor.PayToAddressLine1 = Address3LineControlPayToNameAndAddress_PayToAddress.Address
                    Vendor.PayToAddressLine2 = Address3LineControlPayToNameAndAddress_PayToAddress.Address2
                    Vendor.PayToStreetAddressLine3 = Address3LineControlPayToNameAndAddress_PayToAddress.Address3
                    Vendor.PayToCity = Address3LineControlPayToNameAndAddress_PayToAddress.City
                    Vendor.PayToCounty = Address3LineControlPayToNameAndAddress_PayToAddress.County
                    Vendor.PayToState = Address3LineControlPayToNameAndAddress_PayToAddress.State
                    Vendor.PayToZipCode = Address3LineControlPayToNameAndAddress_PayToAddress.Zip
                    Vendor.PayToCountry = Address3LineControlPayToNameAndAddress_PayToAddress.Country

                Else

                    Vendor.PayToName = Nothing
                    Vendor.PayToAddressLine1 = Nothing
                    Vendor.PayToAddressLine2 = Nothing
                    Vendor.PayToStreetAddressLine3 = Nothing
                    Vendor.PayToCity = Nothing
                    Vendor.PayToCounty = Nothing
                    Vendor.PayToState = Nothing
                    Vendor.PayToZipCode = Nothing
                    Vendor.PayToCountry = Nothing

                End If

                Vendor.PayToPhoneNumber = TextBoxPayToNameAndAddress_Phone.Text
                Vendor.PayToPhoneNumberExtension = TextBoxPayToNameAndAddress_PhoneExt.Text
                Vendor.PayToFaxPhoneNumber = TextBoxPayToNameAndAddress_Fax.Text
                Vendor.PayToFaxPhoneNumberExtension = TextBoxPayToNameAndAddress_FaxExt.Text

                Vendor.Website = TextBoxMain_Website.Text
                Vendor.EmailAddress = TextBoxMain_Email.Text
                Vendor.PaymentManagerEmailAddress = TextBoxMain_PaymentManagerEmail.Text
                Vendor.TaxID = TextBoxMain_FederalTaxID.Text
                Vendor.VendorCategory = ComboBoxMain_DefaultCategory.GetSelectedValue

                Vendor.InternetCategory = If(CheckBoxMain_Internet.Checked, 1, Nothing)
                Vendor.MagazineCategory = If(CheckBoxMain_Magazine.Checked, 1, Nothing)
                Vendor.NewspaperCategory = If(CheckBoxMain_Newspaper.Checked, 1, Nothing)
                Vendor.OutOfHomeCategory = If(CheckBoxMain_OutOfHome.Checked, 1, Nothing)
                Vendor.RadioCategory = If(CheckBoxMain_Radio.Checked, 1, Nothing)
                Vendor.TVCategory = If(CheckBoxMain_Television.Checked, 1, Nothing)

                Vendor.VATNumber = TextBoxMain_VATNumber.GetText

            End If

        End Sub
        Private Sub SaveDefaultsNotesTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                Vendor.IsACH = Convert.ToInt16(CheckBoxDefaultNotes_ACH.Checked)
                Vendor.EmployeeVendor = Convert.ToInt16(CheckBoxDefaultNotes_EmployeeVendor.Checked)
                Vendor.OneCheckPerInvoice = Convert.ToInt16(CheckBoxDefaultNotes_OneCheckPerInvoice.Checked)

                Vendor.ACHType = ComboBoxDefaultNotes_ACHType.GetSelectedValue
                Vendor.CurrencyCode = SearchableComboBoxDefaultNotes_Currency.GetSelectedValue
                Vendor.OfficeCode = SearchableComboBoxDefaultNotes_Office.GetSelectedValue
                Vendor.DefaultAPAccount = SearchableComboBoxDefaultNotes_DefaultAPAccount.GetSelectedValue
                Vendor.DefaultExpenseAccount = SearchableComboBoxDefaultNotes_DefaultExpenseAccount.GetSelectedValue
                Vendor.AccountNumber = TextBoxDefaultNotes_VendorAccount.Text
                Vendor.SortName = TextBoxDefaultNotes_SortName.Text
                Vendor.FunctionCode = SearchableComboBoxDefaultNotes_DefaultFunction.GetSelectedValue
                Vendor.VendorTermCode = SearchableComboBoxDefaultNotes_Terms.GetSelectedValue
                Vendor.BankCode = SearchableComboBoxDefaultNotes_DefaultBank.GetSelectedValue
                Vendor.VCCStatus = ComboBoxDefaultNotes_VCCStatus.GetSelectedValue
                Vendor.VCCAmount = NumericInputDefaultNotes_VCCLimit.GetValue
                Vendor.HasSpecialTerms = CheckBoxDefaultNotes_SpecialTerms.Checked
                Vendor.SendVCCWithMediaOrder = CheckBoxDefaultNotes_SendVCCWithMediaOrder.Checked
                Vendor.VendorInvoiceCategoryID = ComboBoxDefaultNotes_InvoiceCategory.GetSelectedValue

                Vendor.Notes = TextBoxDefaultNotes_Notes.Text

            End If

        End Sub
        Private Sub SaveEEOCStatusTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                ' autosaves

            End If

        End Sub
        Private Sub SaveEEOC2Tab(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            Dim VendorEEOC2 As AdvantageFramework.Database.Entities.VendorEEOC2 = Nothing

            If Vendor IsNot Nothing Then

                VendorEEOC2 = AdvantageFramework.Database.Procedures.VendorEEOC2.LoadByVendorCode(DbContext, Vendor.Code)

                If VendorEEOC2 IsNot Nothing Then

                    If SearchableComboBoxMOBD_Ethnicity.HasASelectedValue Then

                        VendorEEOC2.Ethnicity = CShort(SearchableComboBoxMOBD_Ethnicity.GetSelectedValue)

                    Else

                        VendorEEOC2.Ethnicity = Nothing

                    End If

                    VendorEEOC2.MinorityCertificateNumber = TextBoxMOBD_MinorityCertifcateNumber.GetText
                    VendorEEOC2.MinorityCertificateNumberExpirationDate = DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.GetValue
                    VendorEEOC2.IsNMSDC = CheckBoxMODB_IsNMSDC.Checked
                    VendorEEOC2.IsWBENC = CheckBoxWBD_IsWBENC.Checked
                    VendorEEOC2.WBENCCertificateNumber = TextBoxWBD_WBENCCertificationNumber.GetText
                    VendorEEOC2.WBENCCertificateNumberExpirationDate = DateTimePickerWBD_WBENCCertificationExpirationDate.GetValue

                    AdvantageFramework.Database.Procedures.VendorEEOC2.Update(DbContext, VendorEEOC2)

                Else

                    VendorEEOC2 = New AdvantageFramework.Database.Entities.VendorEEOC2
                    VendorEEOC2.DbContext = DbContext
                    VendorEEOC2.VendorCode = Vendor.Code

                    If SearchableComboBoxMOBD_Ethnicity.HasASelectedValue Then

                        VendorEEOC2.Ethnicity = CShort(SearchableComboBoxMOBD_Ethnicity.GetSelectedValue)

                    Else

                        VendorEEOC2.Ethnicity = Nothing

                    End If

                    VendorEEOC2.MinorityCertificateNumber = TextBoxMOBD_MinorityCertifcateNumber.GetText
                    VendorEEOC2.MinorityCertificateNumberExpirationDate = DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.GetValue
                    VendorEEOC2.IsNMSDC = CheckBoxMODB_IsNMSDC.Checked
                    VendorEEOC2.IsWBENC = CheckBoxWBD_IsWBENC.Checked
                    VendorEEOC2.WBENCCertificateNumber = TextBoxWBD_WBENCCertificationNumber.GetText
                    VendorEEOC2.WBENCCertificateNumberExpirationDate = DateTimePickerWBD_WBENCCertificationExpirationDate.GetValue

                    AdvantageFramework.Database.Procedures.VendorEEOC2.Insert(DbContext, VendorEEOC2)

                End If

            End If

        End Sub
        Private Sub Save1099InfoTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim DefaultCategory As Short = Nothing

            If Vendor IsNot Nothing Then

                Vendor.Vendor1099Flag = Convert.ToInt16(CheckBox1099Info_Is1099Vendor.Checked)
                Vendor.UseAlternativeAddressFor1099 = Convert.ToInt16(CheckBox1099Info_Use1099Address.Checked)
                Vendor.Vendor1099StreetAddressLine1 = Address3LineControl1099Info_Address.Address
                Vendor.Vendor1099StreetAddressLine2 = Address3LineControl1099Info_Address.Address2
                Vendor.Vendor1099StreetAddressLine3 = Address3LineControl1099Info_Address.Address3
                Vendor.Vendor1099City = Address3LineControl1099Info_Address.City
                Vendor.Vendor1099State = Address3LineControl1099Info_Address.State
                Vendor.Vendor1099ZipCode = Address3LineControl1099Info_Address.Zip
                Vendor.Vendor1099County = Address3LineControl1099Info_Address.County
                Vendor.Vendor1099Country = Address3LineControl1099Info_Address.Country

                If RadioButtonControl1099Info_NonEmployeeCompensation.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)

                ElseIf RadioButtonControl1099Info_OtherIncome.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome)

                ElseIf RadioButtonControl1099Info_Rent.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.Rent)

                ElseIf RadioButtonControl1099Info_Royalties.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.Royalties)

                ElseIf RadioButtonControl1099Info_GrossProceedsToAttorney.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney)

                ElseIf RadioButtonControl1099Info_MedicalHealthcare.Checked Then

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare)

                Else

                    Vendor.Vendor1099Category = Convert.ToInt16(AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation)

                End If

            End If

        End Sub
        Private Sub SaveContactsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                If TextBoxContacts_DefaultVendorContactCode.Text <> "" Then

                    Vendor.DefaultVendorContactCode = TextBoxContacts_DefaultVendorContactCode.Text

                Else

                    Vendor.DefaultVendorContactCode = Nothing

                End If

            End If

        End Sub
        Private Sub SaveRepresentativesTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                If TextBoxRepresentatives_DefaultRep1.Text <> "" Then

                    Vendor.DefaultVendorRepresentativeCode1 = TextBoxRepresentatives_DefaultRep1.Text

                Else

                    Vendor.DefaultVendorRepresentativeCode1 = Nothing

                End If

                If TextBoxRepresentatives_DefaultRep2.Text <> "" Then

                    Vendor.DefaultVendorRepresentativeCode2 = TextBoxRepresentatives_DefaultRep2.Text

                Else

                    Vendor.DefaultVendorRepresentativeCode2 = Nothing

                End If

            End If

        End Sub
        Private Sub SaveMediaDefaultsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing AndAlso TabItemVendorDetails_MediaDefaultsTab.Tag = True Then

                Vendor.MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue
                Vendor.Commission = NumericInputGeneralDefaultInformation_CommissionPercent.GetValue
                Vendor.Markup = NumericInputGeneralDefaultInformation_MarkupPercent.GetValue
                Vendor.OveragePercent = NumericInputGeneralDefaultInformation_OveragePercent.GetValue
                Vendor.ColumnSize = NumericInputGeneralDefaultInformation_ColumnWidth.GetValue
                Vendor.DefaultSalesTax = SearchableComboBoxGeneralDefaultInformation_TaxCode.GetSelectedValue
                Vendor.VendorCodeCrossReference = TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Text

                If TextBoxGeneralDefaultInformation_CallLetters.Visible AndAlso TextBoxGeneralDefaultInformation_CallLetters.Enabled Then

                    Vendor.CallLetters = TextBoxGeneralDefaultInformation_CallLetters.Text

                Else

                    Vendor.CallLetters = String.Empty

                End If

                If ComboBoxGeneralDefaultInformation_Band.Visible AndAlso ComboBoxGeneralDefaultInformation_Band.Enabled Then

                    Vendor.Band = ComboBoxGeneralDefaultInformation_Band.GetSelectedValue

                Else

                    Vendor.Band = String.Empty

                End If

                Vendor.TaxAdditionalCharge = Convert.ToInt16(CheckBoxApplyTo_AddlCharge.Checked)
                Vendor.TaxCommission = Convert.ToInt16(CheckBoxApplyTo_Commission.Checked)
                Vendor.TaxLineNet = Convert.ToInt16(CheckBoxApplyTo_LineNet.Checked)
                Vendor.TaxNetCharge = Convert.ToInt16(CheckBoxApplyTo_NetCharge.Checked)
                Vendor.TaxNetDiscount = Convert.ToInt16(CheckBoxApplyTo_NetDiscount.Checked)
                Vendor.TaxRebate = Convert.ToInt16(CheckBoxApplyTo_Rebate.Checked)
                Vendor.UseTaxFlags = Convert.ToInt16(CheckBoxApplyTo_UseFlags.Checked)
                Vendor.MaterialCloseDays = NumericInputDeadlines_MaterialCloseDays.GetValue
                Vendor.SpaceCloseDays = NumericInputDeadlines_SpaceCloseDays.GetValue
                Vendor.IsCableSystem = CheckBoxGeneralDefaultInformation_IsCableSystem.Checked
                Vendor.CanadianVendorType = ComboBoxGeneralDefaultInformation_CanadianVendorType.GetSelectedValue
                Vendor.NielsenRadioStationComboID = If(SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible, SearchableComboBoxGeneralDefaultInformation_RadioStation.GetSelectedValue, Nothing)
                Vendor.NielsenTVStationCode = If(SearchableComboBoxGeneralDefaultInformation_TVStation.Visible, SearchableComboBoxGeneralDefaultInformation_TVStation.GetSelectedValue, Nothing)
                Vendor.NCCTVSyscodeID = If(SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible, SearchableComboBoxGeneralDefaultInformation_CableSyscode.GetSelectedValue, Nothing)
                Vendor.EastlanRadioStationComboID = If(SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible, SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.GetSelectedValue, Nothing)
                Vendor.ComscoreTVStationID = If(SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible, SearchableComboBoxGeneralDefaultInformation_ComscoreStation.GetSelectedValue, Nothing)
                Vendor.IsNielsenSubsciber = CheckBoxIsNielsenSubscriber.Checked
                Vendor.IsComscoreSubsciber = CheckBoxIsComscoreSubscriber.Checked

                If RadioButtonControlUnits_Daily.Checked Then

                    If RadioButtonControlUnits_Daily.Tag IsNot Nothing Then

                        Vendor.DefaultUnits = DirectCast(RadioButtonControlUnits_Daily.Tag, AdvantageFramework.Database.Entities.VendorMediaDefaultUnits).ToString

                    Else

                        Vendor.DefaultUnits = Nothing

                    End If

                    If Vendor.DefaultUnits = "F" Then Vendor.DefaultUnits = "4"

                ElseIf RadioButtonControlUnits_MontlyOrBroadcastMonth.Checked Then

                    If RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag IsNot Nothing Then

                        Vendor.DefaultUnits = DirectCast(RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag, AdvantageFramework.Database.Entities.VendorMediaDefaultUnits).ToString

                    Else

                        Vendor.DefaultUnits = Nothing

                    End If

                ElseIf RadioButtonControlUnits_WeeklyOrCalendarMonth.Checked Then

                    If RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag IsNot Nothing Then

                        Vendor.DefaultUnits = DirectCast(RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag, AdvantageFramework.Database.Entities.VendorMediaDefaultUnits).ToString

                    Else

                        Vendor.DefaultUnits = Nothing

                    End If

                Else

                    Vendor.DefaultUnits = Nothing

                End If

                If RadioButtonControlRates_Gross.Checked Then

                    Vendor.DefaultNetGross = Convert.ToInt16(1)

                Else

                    Vendor.DefaultNetGross = Convert.ToInt16(0)

                End If

            End If

        End Sub
        Private Sub SaveMediaInfoTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim DefaultCategory As AdvantageFramework.Database.Entities.VendorCategory = Nothing

            If Vendor IsNot Nothing Then

                Try

                    DefaultCategory = DirectCast(ComboBoxMain_DefaultCategory.Tag, AdvantageFramework.Database.Entities.VendorCategory)

                Catch ex As Exception
                    DefaultCategory = Nothing
                End Try

                Select Case DefaultCategory

                    Case AdvantageFramework.Database.Entities.VendorCategory.Magazine

                        Vendor.DailyCirculation = NumericInputMagazine_Circulation.GetValue
                        Vendor.Issues = NumericInputMagazine_Issues.GetValue
                        Vendor.Cycles = TextBoxMagazine_Cycles.Text
                        Vendor.PublishingFrequency = TextBoxMagazine_PublishingFrequency.Text
                        Vendor.Editions = TextBoxMagazine_Editions.Text

                    Case AdvantageFramework.Database.Entities.VendorCategory.Newspaper

                        Vendor.SundayCirculation = NumericInputNewspaper_SundayCirculation.GetValue
                        Vendor.DailyCirculation = NumericInputNewspaper_DailyCirculation.GetValue
                        Vendor.PublishingFrequency = TextBoxNewspaper_PublishingFrequency.Text
                        Vendor.Editions = TextBoxNewspaper_Editions.Text

                End Select

            End If

        End Sub
        Private Sub SaveMediaDeliveryTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                Vendor.ShipToName = TextBoxMediaShipping_Name.Text
                Vendor.ShipToAddress = Address3LineControlMediaDelivery_MediaShippingAddress.Address
                Vendor.ShipToAddress2 = Address3LineControlMediaDelivery_MediaShippingAddress.Address2
                Vendor.ShipToAddress3 = Address3LineControlMediaDelivery_MediaShippingAddress.Address3
                Vendor.ShipToCity = Address3LineControlMediaDelivery_MediaShippingAddress.City
                Vendor.ShipToCounty = Address3LineControlMediaDelivery_MediaShippingAddress.County
                Vendor.ShipToState = Address3LineControlMediaDelivery_MediaShippingAddress.State
                Vendor.ShipToZip = Address3LineControlMediaDelivery_MediaShippingAddress.Zip
                Vendor.ShipToCountry = Address3LineControlMediaDelivery_MediaShippingAddress.Country

                Vendor.ShipToPhone = TextBoxMediaShipping_Phone.Text
                Vendor.ShipToPhoneExt = TextBoxMediaShipping_PhoneExt.Text

                If ComboBoxMediaDelivery_DefaultCorrespondenceMethod.HasASelectedValue Then

                    Vendor.DefaultCorrespondenceMethod = Convert.ToInt16(ComboBoxMediaDelivery_DefaultCorrespondenceMethod.GetSelectedValue)

                Else

                    Vendor.DefaultCorrespondenceMethod = Nothing

                End If

            End If

        End Sub
        Private Sub SaveMediaSpecsTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                Vendor.DefaultAdSize = SearchableComboBoxMediaSpecs_DefaultSize.GetSelectedValue

            End If

        End Sub
        Private Sub SaveServiceTaxTab(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If Vendor IsNot Nothing Then

                Vendor.VendorServiceTaxID = SearchableComboBoxServiceTax_Code.GetSelectedValue

                If SearchableComboBoxServiceTax_Type.HasASelectedValue Then

                    Vendor.ServiceTaxType = CShort(SearchableComboBoxServiceTax_Type.GetSelectedValue)

                End If

                Vendor.ServiceTaxEnabled = CheckBoxServiceTax_Enabled.Checked
                Vendor.ServiceTaxWaiver = CheckBoxServiceTax_Waiver.Checked

                Vendor.ServiceTaxRate = NumericInputServiceTax_Rate.EditValue
                Vendor.ServiceTaxWaiverExpirationDate = DateTimePickerServiceTax_WaiverExpirationDate.GetValue

            End If

        End Sub
        Private Sub EnableOrDisableTabs()

            'objects
            Dim DefaultCategory As AdvantageFramework.Database.Entities.VendorCategory = Nothing

            If Me.DesignMode = False Then

                If _IsNewVendor Then

                    TabItemVendorDetails_MainTab.Visible = Not Me.CanUserCustom1
                    TabItemVendorDetails_DefaultsNotesTab.Visible = Not Me.CanUserCustom1
                    TabItemVendorDetails_1099InfoTab.Visible = Not Me.CanUserCustom1
                    TabItemVendorDetails_EEOCStatusTab.Visible = False
                    TabItemVendorDetails_EEOC2Tab.Visible = False
                    TabItemVendorDetails_ContactsTab.Visible = False
                    TabItemVendorDetails_RepresentativesTab.Visible = False
                    TabItemVendorDetails_MediaDefaultsTab.Visible = False
                    TabItemVendorDetails_MediaInfoTab.Visible = False
                    TabItemVendorDetails_MediaDeliveryTab.Visible = False
                    TabItemVendorDetails_MediaSpecsTab.Visible = False
                    TabItemVendorDetails_PricingsTab.Visible = False
                    TabItemVendorDetails_DocumentsTab.Visible = False
                    TabItemVendorDetails_VendorServiceTaxTab.Visible = False
                    TabItemVendorDetails_ContractsTab.Visible = False

                Else

                    TabItemVendorDetails_DocumentsTab.Visible = _HasAccessToDocuments AndAlso Not Me.CanUserCustom1

                    Try

                        DefaultCategory = DirectCast(ComboBoxMain_DefaultCategory.Tag, AdvantageFramework.Database.Entities.VendorCategory)

                    Catch ex As Exception
                        DefaultCategory = Nothing
                    End Try

                    Select Case DefaultCategory

                        Case Database.Entities.VendorCategory.NonMedia

                            TabItemVendorDetails_MainTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_DefaultsNotesTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_1099InfoTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_EEOCStatusTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_ContactsTab.Visible = Me.HasAccessToVendorContact
                            TabItemVendorDetails_RepresentativesTab.Visible = False
                            TabItemVendorDetails_MediaDefaultsTab.Visible = False
                            TabItemVendorDetails_MediaInfoTab.Visible = False
                            TabItemVendorDetails_MediaDeliveryTab.Visible = False
                            TabItemVendorDetails_MediaSpecsTab.Visible = False
                            TabItemVendorDetails_PricingsTab.Visible = True
                            TabItemVendorDetails_ContractsTab.Visible = Not Me.CanUserCustom2

                        Case Database.Entities.VendorCategory.Radio, Database.Entities.VendorCategory.Television

                            TabItemVendorDetails_MainTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_DefaultsNotesTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_1099InfoTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_EEOCStatusTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_ContactsTab.Visible = Me.HasAccessToVendorContact
                            TabItemVendorDetails_RepresentativesTab.Visible = Me.HasAccessToVendorRep
                            TabItemVendorDetails_MediaDefaultsTab.Visible = True
                            TabItemVendorDetails_MediaInfoTab.Visible = False
                            TabItemVendorDetails_MediaDeliveryTab.Visible = True
                            TabItemVendorDetails_MediaSpecsTab.Visible = False
                            TabItemVendorDetails_PricingsTab.Visible = True
                            TabItemVendorDetails_ContractsTab.Visible = Not Me.CanUserCustom2

                        Case Database.Entities.VendorCategory.OutOfHome, Database.Entities.VendorCategory.Internet

                            TabItemVendorDetails_MainTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_DefaultsNotesTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_1099InfoTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_EEOCStatusTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_ContactsTab.Visible = Me.HasAccessToVendorContact
                            TabItemVendorDetails_RepresentativesTab.Visible = Me.HasAccessToVendorRep
                            TabItemVendorDetails_MediaDefaultsTab.Visible = True
                            TabItemVendorDetails_MediaInfoTab.Visible = False
                            TabItemVendorDetails_MediaDeliveryTab.Visible = True
                            TabItemVendorDetails_MediaSpecsTab.Visible = True
                            TabItemVendorDetails_PricingsTab.Visible = True
                            TabItemVendorDetails_ContractsTab.Visible = Not Me.CanUserCustom2

                        Case Else

                            TabItemVendorDetails_MainTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_DefaultsNotesTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_1099InfoTab.Visible = Not Me.CanUserCustom1
                            TabItemVendorDetails_ContactsTab.Visible = Me.HasAccessToVendorContact
                            TabItemVendorDetails_RepresentativesTab.Visible = Me.HasAccessToVendorRep
                            TabItemVendorDetails_MediaDefaultsTab.Visible = True
                            TabItemVendorDetails_MediaInfoTab.Visible = True
                            TabItemVendorDetails_MediaDeliveryTab.Visible = True
                            TabItemVendorDetails_MediaSpecsTab.Visible = True
                            TabItemVendorDetails_PricingsTab.Visible = True
                            TabItemVendorDetails_ContractsTab.Visible = Not Me.CanUserCustom2

                    End Select

                    TabItemVendorDetails_EEOC2Tab.Visible = TabItemVendorDetails_EEOCStatusTab.Visible

                End If

                If _Session IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        TabItemVendorDetails_VendorServiceTaxTab.Visible = Not Me.CanUserCustom1

                        If Not Agency.GetOptionServiceTaxEnabled(DataContext) Then

                            TabItemVendorDetails_VendorServiceTaxTab.Visible = False

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim PayToVendorCode As String = Nothing

            PayToVendorCode = TextBoxPayToNameAndAddress_Vendor.Text
            ButtonPayToNameAndAddress_Refresh.Enabled = If(PayToVendorCode = _VendorCode OrElse PayToVendorCode = TextBoxMain_Code.Text, True, False)
            TextBoxPayToNameAndAddress_Name.Enabled = If(PayToVendorCode = _VendorCode OrElse PayToVendorCode = TextBoxMain_Code.Text, True, False)
            TextBoxPayToNameAndAddress_Name.SetRequired(TextBoxPayToNameAndAddress_Name.Enabled)

            Address3LineControlPayToNameAndAddress_PayToAddress.Enabled = If(PayToVendorCode = _VendorCode OrElse PayToVendorCode = TextBoxMain_Code.Text, True, False)

            ' Defaults / Notes Tab
            ButtonItemSortActions_Delete.Enabled = ComboBoxDefaultNotes_SortOptions.HasASelectedValue
            ComboBoxDefaultNotes_ACHType.SetRequired(CheckBoxDefaultNotes_ACH.Checked)
            ComboBoxDefaultNotes_ACHType.Enabled = CheckBoxDefaultNotes_ACH.Checked

            ' EEOC Status Tab
            ButtonRightSection_AddEEOCStatus.Enabled = DataGridViewLeftSection_AvailableEEOCStatuses.HasOnlyOneSelectedRow
            ButtonRightSection_RemoveEEOCStatus.Enabled = DataGridViewRightSection_SelectedEEOCStatuses.HasOnlyOneSelectedRow

            ' 1099 Info Tab
            CheckBox1099Info_Use1099Address.Enabled = CheckBox1099Info_Is1099Vendor.Checked
            Address3LineControl1099Info_Address.Enabled = CheckBox1099Info_Use1099Address.Checked

            ' Service Tax Tab
            If SearchableComboBoxServiceTax_Code.HasASelectedValue AndAlso
                    CheckBoxServiceTax_Enabled.Checked AndAlso
                    CheckBoxServiceTax_Waiver.Checked = False Then

                NumericInputServiceTax_Rate.SetRequired(True)

            Else

                NumericInputServiceTax_Rate.SetRequired(False)

            End If

            SearchableComboBoxServiceTax_Type.SetRequired(SearchableComboBoxServiceTax_Code.HasASelectedValue)

            DateTimePickerServiceTax_WaiverExpirationDate.SetRequired(CheckBoxServiceTax_Waiver.Checked)
            DateTimePickerServiceTax_WaiverExpirationDate.ReadOnly = Not CheckBoxServiceTax_Waiver.Checked

            'Media Defaults Tab
            NumericInputGeneralDefaultInformation_CommissionPercent.Enabled = RadioButtonControlRates_Gross.Checked
            NumericInputGeneralDefaultInformation_MarkupPercent.Enabled = RadioButtonControlRates_Net.Checked

            SearchableComboBoxGeneralDefaultInformation_TVStation.Enabled = SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue AndAlso Not CheckBoxGeneralDefaultInformation_IsCableSystem.Checked
            SearchableComboBoxGeneralDefaultInformation_RadioStation.Enabled = SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue
            SearchableComboBoxGeneralDefaultInformation_CableSyscode.Enabled = SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue AndAlso CheckBoxGeneralDefaultInformation_IsCableSystem.Checked
            SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Enabled = SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue
            SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Enabled = SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue AndAlso Not CheckBoxGeneralDefaultInformation_IsCableSystem.Checked

            TextBoxGeneralDefaultInformation_CallLetters.Enabled = (CheckBoxGeneralDefaultInformation_IsCableSystem.Checked = False)
            ComboBoxGeneralDefaultInformation_Band.Enabled = (CheckBoxGeneralDefaultInformation_IsCableSystem.Checked = False)

            TextBoxGeneralDefaultInformation_CallLetters.Visible = (ComboBoxMain_DefaultCategory.GetSelectedValue() = "R" OrElse ComboBoxMain_DefaultCategory.GetSelectedValue() = "T")
            LabelGeneralDefaultInformation_CallLetters.Visible = TextBoxGeneralDefaultInformation_CallLetters.Visible

            ComboBoxGeneralDefaultInformation_Band.Visible = (ComboBoxMain_DefaultCategory.GetSelectedValue() = "R" OrElse ComboBoxMain_DefaultCategory.GetSelectedValue() = "T")
            LabelGeneralDefaultInformation_Band.Visible = ComboBoxGeneralDefaultInformation_Band.Visible

        End Sub
        Private Sub LoadSortKeys()

            ComboBoxDefaultNotes_SortOptions.DataSource = Nothing
            ComboBoxDefaultNotes_SortOptions.SelectedIndex = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _SortKeyList = AdvantageFramework.Database.Procedures.VendorSortKey.LoadByVendorCode(DbContext, _VendorCode).ToList

                ComboBoxDefaultNotes_SortOptions.DataSource = _SortKeyList

                If ComboBoxDefaultNotes_SortOptions.HasASelectedValue Then

                    ButtonItemSortActions_Delete.Enabled = True

                Else

                    ButtonItemSortActions_Delete.Enabled = False

                End If

            End Using

        End Sub
        Private Sub LoadVendorContacts()

            'objects
            Dim DefaultVendorContactCode As String = Nothing

            If _VendorCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DefaultVendorContactCode = TextBoxContacts_DefaultVendorContactCode.Text

                    DataGridViewContacts_Contacts.DataSource = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorCode(DbContext, _VendorCode).ToList.Select(Function(VendorContact) New AdvantageFramework.Database.Classes.VendorContact(VendorContact, If(VendorContact.Code = DefaultVendorContactCode, True, False))).ToList
                    DataGridViewContacts_Contacts.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub LoadVendorRepresentatives()

            'objects
            Dim DefaultRep1 As String = Nothing
            Dim DefaultRep2 As String = Nothing
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing

            If _VendorCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DefaultRep1 = TextBoxRepresentatives_DefaultRep1.Text
                        DefaultRep2 = TextBoxRepresentatives_DefaultRep2.Text

                        VendorRepresentatives = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByVendorCode(DataContext, _VendorCode).ToList

                        DataGridViewRepresentatives_VendorReps.DataSource = VendorRepresentatives.Select(Function(VendorRep) New AdvantageFramework.Database.Classes.VendorRepresentative(DbContext, VendorRep,
                                                                                                                                                                                          If(VendorRep.Code = DefaultRep1, True, False),
                                                                                                                                                                                          If(VendorRep.Code = DefaultRep2, True, False))).ToList
                        DataGridViewRepresentatives_VendorReps.CurrentView.BestFitColumns()

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadEEOCStatuses()

            Dim DefaultEEOCStatuses As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim VendorEEOCStatuses As Generic.List(Of AdvantageFramework.Database.Entities.EEOCStatus) = Nothing
            Dim AllVendorEEOCStatuses As Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus) = Nothing
            Dim SelectedEEOCStatuses As Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus) = Nothing
            Dim AvailableEEOCStatuses As Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus) = Nothing

            If _VendorCode IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    DefaultEEOCStatuses = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorEEOCStatus)).ToList

                    VendorEEOCStatuses = AdvantageFramework.Database.Procedures.EEOCStatus.LoadByVendorCode(DataContext, _VendorCode).ToList

                    AllVendorEEOCStatuses = DefaultEEOCStatuses.Select(Function(EEOCStatus) New AdvantageFramework.Database.Classes.VendorEEOCStatus(EEOCStatus.Code, EEOCStatus.Description)).ToList

                    Try

                        AvailableEEOCStatuses = (From EEOCStatus In AllVendorEEOCStatuses
                                                 Where VendorEEOCStatuses.Any(Function(VenEEOCStatus) VenEEOCStatus.EEOCCode = EEOCStatus.EEOCStatusCode) = False
                                                 Select EEOCStatus).ToList

                    Catch ex As Exception
                        AvailableEEOCStatuses = New Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus)
                    End Try

                    Try

                        SelectedEEOCStatuses = (From EEOCStatus In AllVendorEEOCStatuses
                                                Where VendorEEOCStatuses.Any(Function(VenEEOCStatus) VenEEOCStatus.EEOCCode = EEOCStatus.EEOCStatusCode) = True
                                                Select EEOCStatus).ToList

                    Catch ex As Exception
                        SelectedEEOCStatuses = New Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus)
                    End Try

                    DataGridViewLeftSection_AvailableEEOCStatuses.DataSource = AvailableEEOCStatuses
                    DataGridViewLeftSection_AvailableEEOCStatuses.CurrentView.BestFitColumns()

                    DataGridViewRightSection_SelectedEEOCStatuses.DataSource = SelectedEEOCStatuses
                    DataGridViewRightSection_SelectedEEOCStatuses.CurrentView.BestFitColumns()

                End Using

                GroupBoxEEOC2_MinorityOwnedBusinessDetails.Enabled = DataGridViewRightSection_SelectedEEOCStatuses.HasRows 'AndAlso (From Entity In DataGridViewRightSection_SelectedEEOCStatuses.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.VendorEEOCStatus)
                'Where Entity.EEOCStatusCode = "MO").Any

                GroupBoxEEOC2_WomensBusinessDetails.Enabled = GroupBoxEEOC2_MinorityOwnedBusinessDetails.Enabled

            End If

        End Sub
        Private Sub LoadAdSizes()

            ' objects
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing
            Dim MediaType As String = Nothing

            If _Session IsNot Nothing Then

                If ComboBoxMain_DefaultCategory.HasASelectedValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        MediaType = ComboBoxMain_DefaultCategory.GetSelectedValue

                        SearchableComboBoxMediaSpecs_DefaultSize.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(DbContext)
                                                                               Where Entity.MediaType = MediaType
                                                                               Select Entity).ToList

                        Try

                            SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = SearchableComboBoxMediaSpecs_DefaultSize.Tag

                        Catch ex As Exception
                            SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = Nothing Then

                            AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(DbContext, SearchableComboBoxMediaSpecs_DefaultSize.Tag, ComboBoxMain_DefaultCategory.GetSelectedValue)

                            If AdSize IsNot Nothing Then

                                SearchableComboBoxMediaSpecs_DefaultSize.AddComboItemToExistingDataSource(AdSize.Description, AdSize.Code, True)

                                Try

                                    SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = SearchableComboBoxMediaSpecs_DefaultSize.Tag

                                Catch ex As Exception
                                    SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub LoadNameAndAddress(ByVal Vendor As AdvantageFramework.Database.Entities.Vendor, ByVal AddressControl As AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl)

            If Vendor IsNot Nothing Then

                If AddressControl Is Address3LineControlNameAndAddress_Address Then

                    TextBoxNameAndAddress_Name.Text = Vendor.Name
                    Address3LineControlNameAndAddress_Address.Address = Vendor.StreetAddressLine1
                    Address3LineControlNameAndAddress_Address.Address2 = Vendor.StreetAddressLine2
                    Address3LineControlNameAndAddress_Address.Address3 = Vendor.StreetAddressLine3
                    Address3LineControlNameAndAddress_Address.City = Vendor.City
                    Address3LineControlNameAndAddress_Address.County = Vendor.County
                    Address3LineControlNameAndAddress_Address.State = Vendor.State
                    Address3LineControlNameAndAddress_Address.Zip = Vendor.ZipCode
                    Address3LineControlNameAndAddress_Address.Country = Vendor.Country

                ElseIf AddressControl Is Address3LineControlPayToNameAndAddress_PayToAddress Then

                    TextBoxPayToNameAndAddress_Name.Text = Vendor.PayToName
                    Address3LineControlPayToNameAndAddress_PayToAddress.Address = Vendor.PayToAddressLine1
                    Address3LineControlPayToNameAndAddress_PayToAddress.Address2 = Vendor.PayToAddressLine2
                    Address3LineControlPayToNameAndAddress_PayToAddress.Address3 = Vendor.PayToStreetAddressLine3
                    Address3LineControlPayToNameAndAddress_PayToAddress.City = Vendor.PayToCity
                    Address3LineControlPayToNameAndAddress_PayToAddress.County = Vendor.PayToCounty
                    Address3LineControlPayToNameAndAddress_PayToAddress.State = Vendor.PayToState
                    Address3LineControlPayToNameAndAddress_PayToAddress.Zip = Vendor.PayToZipCode
                    Address3LineControlPayToNameAndAddress_PayToAddress.Country = Vendor.PayToCountry

                End If

            End If

        End Sub
        Private Sub LoadGeneralDefaultInformationSettings()

            ' objects
            Dim VendorCategory As AdvantageFramework.Database.Entities.VendorCategory = Nothing

            If ComboBoxMain_DefaultCategory.HasASelectedValue Then

                Try

                    VendorCategory = DirectCast(ComboBoxMain_DefaultCategory.Tag, AdvantageFramework.Database.Entities.VendorCategory)

                Catch ex As Exception
                    VendorCategory = Nothing
                End Try

                Select Case VendorCategory

                    Case Database.Entities.VendorCategory.Magazine, Database.Entities.VendorCategory.Internet

                        LabelGeneralDefaultInformation_Market.Visible = True
                        SearchableComboBoxGeneralDefaultInformation_Market.Visible = True
                        LabelGeneralDefaultInformation_OveragePercent.Visible = False
                        NumericInputGeneralDefaultInformation_OveragePercent.Visible = False
                        LabelGeneralDefaultInformation_ColumnWidth.Visible = False
                        NumericInputGeneralDefaultInformation_ColumnWidth.Visible = False
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = "Monthly"
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.M
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = "Weekly"
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.W
                        RadioButtonControlUnits_Daily.Visible = False
                        RadioButtonControlUnits_Daily.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.D
                        CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_Station.Visible = False
                        LabelGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                        LabelGeneralDefaultInformation_EastlanStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                        LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                        LabelRatingsSubscriber.Visible = False
                        CheckBoxIsNielsenSubscriber.Visible = False
                        CheckBoxIsComscoreSubscriber.Visible = False
                        LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                        ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                    Case Database.Entities.VendorCategory.OutOfHome

                        LabelGeneralDefaultInformation_Market.Visible = True
                        SearchableComboBoxGeneralDefaultInformation_Market.Visible = True
                        LabelGeneralDefaultInformation_OveragePercent.Visible = False
                        NumericInputGeneralDefaultInformation_OveragePercent.Visible = False
                        LabelGeneralDefaultInformation_ColumnWidth.Visible = False
                        NumericInputGeneralDefaultInformation_ColumnWidth.Visible = False
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = "Monthly"
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.M
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = "Weekly"
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.W
                        RadioButtonControlUnits_Daily.Visible = True
                        RadioButtonControlUnits_Daily.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.F
                        RadioButtonControlUnits_Daily.Text = "4 Week"
                        CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_Station.Visible = False
                        LabelGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                        LabelGeneralDefaultInformation_EastlanStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                        LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                        LabelRatingsSubscriber.Visible = False
                        CheckBoxIsNielsenSubscriber.Visible = False
                        CheckBoxIsComscoreSubscriber.Visible = False
                        LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                        ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                    Case Database.Entities.VendorCategory.Newspaper

                        LabelGeneralDefaultInformation_Market.Visible = True
                        SearchableComboBoxGeneralDefaultInformation_Market.Visible = True
                        LabelGeneralDefaultInformation_OveragePercent.Visible = True
                        NumericInputGeneralDefaultInformation_OveragePercent.Visible = True
                        LabelGeneralDefaultInformation_ColumnWidth.Visible = True
                        NumericInputGeneralDefaultInformation_ColumnWidth.Visible = True
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = "Monthly"
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.M
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = "Weekly"
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.W
                        RadioButtonControlUnits_Daily.Visible = True
                        RadioButtonControlUnits_Daily.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.D
                        RadioButtonControlUnits_Daily.Text = "Daily"
                        CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_Station.Visible = False
                        LabelGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                        LabelGeneralDefaultInformation_EastlanStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                        LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                        LabelRatingsSubscriber.Visible = False
                        CheckBoxIsNielsenSubscriber.Visible = False
                        CheckBoxIsComscoreSubscriber.Visible = False
                        LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                        ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                    Case Database.Entities.VendorCategory.Television, Database.Entities.VendorCategory.Radio

                        LabelGeneralDefaultInformation_OveragePercent.Visible = False
                        NumericInputGeneralDefaultInformation_OveragePercent.Visible = False
                        LabelGeneralDefaultInformation_ColumnWidth.Visible = False
                        NumericInputGeneralDefaultInformation_ColumnWidth.Visible = False
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = "Broadcast Month"
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.BM
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = "Calendar Month"
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.CM
                        RadioButtonControlUnits_Daily.Visible = True
                        RadioButtonControlUnits_Daily.Tag = AdvantageFramework.Database.Entities.VendorMediaDefaultUnits.D
                        RadioButtonControlUnits_Daily.Text = "Daily"

                        LabelGeneralDefaultInformation_Market.Visible = True
                        SearchableComboBoxGeneralDefaultInformation_Market.Visible = True

                        If VendorCategory = Database.Entities.Methods.VendorCategory.Radio Then

                            SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = True
                            SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                            CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                            LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                            LabelGeneralDefaultInformation_CableSyscode.Visible = False
                            SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                            LabelGeneralDefaultInformation_EastlanStation.Visible = True
                            SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = True
                            LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                            SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                            LabelRatingsSubscriber.Visible = True
                            CheckBoxIsNielsenSubscriber.Visible = True
                            CheckBoxIsComscoreSubscriber.Visible = False

                        ElseIf VendorCategory = Database.Entities.Methods.VendorCategory.Television Then

                            SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                            SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = True
                            CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = True
                            LabelGeneralDefaultInformation_IsCableSystem.Visible = True
                            LabelGeneralDefaultInformation_CableSyscode.Visible = True
                            SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = True
                            LabelGeneralDefaultInformation_EastlanStation.Visible = False
                            SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                            LabelGeneralDefaultInformation_ComscoreStation.Visible = True
                            SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = True
                            LabelRatingsSubscriber.Visible = True
                            CheckBoxIsNielsenSubscriber.Visible = True
                            CheckBoxIsComscoreSubscriber.Visible = True

                        End If

                        LabelGeneralDefaultInformation_Station.Visible = True

                    Case Else

                        LabelGeneralDefaultInformation_Market.Visible = True
                        SearchableComboBoxGeneralDefaultInformation_Market.Visible = True
                        LabelGeneralDefaultInformation_OveragePercent.Visible = False
                        NumericInputGeneralDefaultInformation_OveragePercent.Visible = False
                        LabelGeneralDefaultInformation_ColumnWidth.Visible = False
                        NumericInputGeneralDefaultInformation_ColumnWidth.Visible = False
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = ""
                        RadioButtonControlUnits_MontlyOrBroadcastMonth.Tag = Nothing
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = ""
                        RadioButtonControlUnits_WeeklyOrCalendarMonth.Tag = Nothing
                        RadioButtonControlUnits_Daily.Visible = False
                        RadioButtonControlUnits_Daily.Tag = Nothing
                        CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                        LabelGeneralDefaultInformation_Station.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                        LabelGeneralDefaultInformation_EastlanStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                        LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                        LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                        ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                End Select

                If VendorCategory = Database.Entities.VendorCategory.NonMedia OrElse VendorCategory = Database.Entities.VendorCategory.NonClient Then

                    RadioButtonControlRates_Gross.Checked = False
                    RadioButtonControlRates_Net.Checked = True

                ElseIf VendorCategory = Database.Entities.VendorCategory.Internet OrElse VendorCategory = Database.Entities.VendorCategory.Newspaper Then

                    RadioButtonControlRates_Gross.Checked = False
                    RadioButtonControlRates_Net.Checked = True

                Else

                    RadioButtonControlRates_Gross.Checked = True
                    RadioButtonControlRates_Net.Checked = False

                End If

            End If

        End Sub
        Private Sub LoadMediaInfoSettings()

            ' objects
            Dim VendorCategory As AdvantageFramework.Database.Entities.VendorCategory = Nothing

            If ComboBoxMain_DefaultCategory.HasASelectedValue Then

                Try

                    VendorCategory = DirectCast(ComboBoxMain_DefaultCategory.Tag, AdvantageFramework.Database.Entities.VendorCategory)

                Catch ex As Exception
                    VendorCategory = Nothing
                End Try

                Select Case VendorCategory

                    Case Database.Entities.VendorCategory.Magazine

                        PanelMediaInfo_Magazine.Visible = True
                        PanelMediaInfo_Newspaper.Visible = False

                    Case Database.Entities.VendorCategory.Newspaper

                        PanelMediaInfo_Magazine.Visible = False
                        PanelMediaInfo_Newspaper.Visible = True

                    Case Else

                        PanelMediaInfo_Magazine.Visible = False
                        PanelMediaInfo_Newspaper.Visible = False

                End Select

            End If

        End Sub
        Private Sub LoadMediaSpecs()

            'objects
            Dim AdSizeLabels As Generic.List(Of AdvantageFramework.Database.Entities.AdSizeLabel) = Nothing
            Dim TreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim AdSizeTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim MediaSpecHeaders As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpecsHeader) = Nothing
            Dim MediaSpecHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader = Nothing
            Dim MediaSpecsDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpecsDetail) = Nothing
            Dim MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail = Nothing
            Dim Values As Generic.Dictionary(Of String, String) = Nothing
            Dim ParentTreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TreeListControlMediaSpecs_MediaSpecs.Nodes.Clear()
                    TreeListControlMediaSpecs_MediaSpecs.Columns.Clear()

                    Try

                        AdSizeLabels = (From Entity In AdvantageFramework.Database.Procedures.AdSizeLabel.LoadByMediaType(DbContext, ComboBoxMain_DefaultCategory.GetSelectedValue)
                                        Where Entity.IsInactive Is Nothing OrElse
                                              Entity.IsInactive = 0
                                        Select Entity).ToList

                    Catch ex As Exception
                        AdSizeLabels = Nothing
                    End Try

                    Try

                        TreeListControlMediaSpecs_MediaSpecs.BeginUpdate()

                        AdSizeTreeListColumn = TreeListControlMediaSpecs_MediaSpecs.Columns.Add()
                        AdSizeTreeListColumn.Caption = "Ad Size"
                        AdSizeTreeListColumn.FieldName = "Code"
                        AdSizeTreeListColumn.Visible = True
                        AdSizeTreeListColumn.ColumnEdit = _SubItemGridLookUpEditControl

                        For Each AdSizeLabel In AdSizeLabels.OrderBy(Function(AdSizeLbl) AdSizeLbl.OrderNumber).ToList

                            TreeListColumn = TreeListControlMediaSpecs_MediaSpecs.Columns.Add()
                            TreeListColumn.Caption = If(AdSizeLabel.Description <> "", AdSizeLabel.Description, " ")
                            TreeListColumn.FieldName = AdSizeLabel.ID
                            TreeListColumn.Visible = True
                            TreeListColumn.ColumnEdit = _SubItemTextBox

                        Next

                        TreeListControlMediaSpecs_MediaSpecs.EndUpdate()

                        TreeListControlMediaSpecs_MediaSpecs.BeginUnboundLoad()

                        Try

                            MediaSpecHeaders = (From Entity In AdvantageFramework.Database.Procedures.MediaSpecsHeader.Load(DbContext).Include("MediaSpecsDetails").ToList
                                                Where Entity.VendorCode = _VendorCode AndAlso
                                                      ((Entity.MediaSpecsDetails Is Nothing OrElse
                                                       Entity.MediaSpecsDetails.Count = 0) OrElse
                                                      (Entity.MediaSpecsDetails IsNot Nothing AndAlso
                                                       Entity.MediaSpecsDetails.Where(Function(MediaSpecDtl) MediaSpecDtl.MediaType = ComboBoxMain_DefaultCategory.GetSelectedValue).Any))
                                                Select Entity).ToList

                        Catch ex As Exception
                            MediaSpecHeaders = Nothing
                        End Try

                        For Each MediaSpecHeader In MediaSpecHeaders

                            Try

                                TreeListNode = TreeListControlMediaSpecs_MediaSpecs.AppendNode(Nothing, ParentTreeListNode)

                            Catch ex As Exception
                                TreeListNode = Nothing
                            End Try

                            If TreeListNode IsNot Nothing Then

                                TreeListNode.Tag = MediaSpecHeader

                                TreeListNode.Item("Code") = MediaSpecHeader.AdSize

                                If MediaSpecHeader.MediaSpecsDetails IsNot Nothing AndAlso MediaSpecHeader.MediaSpecsDetails.Count > 0 Then

                                    For Each MediaSpecsDetail In MediaSpecHeader.MediaSpecsDetails.Where(Function(MediaSpecDtl) MediaSpecDtl.MediaType = ComboBoxMain_DefaultCategory.GetSelectedValue).ToList

                                        If TreeListControlMediaSpecs_MediaSpecs.Columns(MediaSpecsDetail.LabelID) IsNot Nothing Then

                                            TreeListNode.Item(MediaSpecsDetail.LabelID) = MediaSpecsDetail.SpecData

                                        End If

                                    Next

                                End If

                            End If

                        Next

                        TreeListControlMediaSpecs_MediaSpecs.EndUnboundLoad()

                    Catch ex As Exception

                    End Try

                End Using

            End If

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm IsNot Nothing Then

                If Me.FindForm.Modal = False Then

                    '' defaults / notes tab
                    'TextBoxDefaultNotes_Notes.Size = New System.Drawing.Size(TextBoxDefaultNotes_Notes.Size.Width, TextBoxDefaultNotes_Notes.Size.Height + 26)

                    '' contacts tab
                    'DataGridViewContacts_Contacts.Size = New System.Drawing.Size(DataGridViewContacts_Contacts.Size.Width, DataGridViewContacts_Contacts.Size.Height + 26)

                    '' representatives tab
                    'DataGridViewRepresentatives_VendorReps.Size = New System.Drawing.Size(DataGridViewRepresentatives_VendorReps.Size.Width, DataGridViewRepresentatives_VendorReps.Size.Height + 26)

                    '' media defaults tab
                    'TextBoxDefaultComments_FooterComment.Size = New System.Drawing.Size(TextBoxDefaultComments_FooterComment.Size.Width, TextBoxDefaultComments_FooterComment.Size.Height + 26)
                    'ButtonDefaultComments_CheckSpelling.Visible = False

                    '' media info tab
                    'PanelMediaInfo_Magazine.Size = New System.Drawing.Size(PanelMediaInfo_Magazine.Size.Width, PanelMediaInfo_Magazine.Size.Height + 26)
                    'PanelMediaInfo_Newspaper.Size = New System.Drawing.Size(PanelMediaInfo_Newspaper.Size.Width, PanelMediaInfo_Newspaper.Size.Height + 26)

                    '' media delivery tab
                    'TextBoxMediaDelivery_GeneralInfo.Size = New System.Drawing.Size(TextBoxMediaDelivery_GeneralInfo.Size.Width, TextBoxMediaDelivery_GeneralInfo.Size.Height + 26)
                    'ButtonMediaDelivery_CheckSpelling.Visible = False

                    '' media specs tab
                    'TreeListControlMediaSpecs_MediaSpecs.Size = New System.Drawing.Size(TreeListControlMediaSpecs_MediaSpecs.Size.Width, TreeListControlMediaSpecs_MediaSpecs.Size.Height + 26)

                End If

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            'objects
            Dim CurrencyCodes As String() = Nothing
            Dim AllowCostOfSaleEntry As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsQuickbooksEnabled Then

                        RefreshQuickBooksVendors()

                    End If

                    ' Default / Notes Tab
                    CurrencyCodes = AdvantageFramework.Database.Procedures.Currency.LoadAllActive(DbContext).Select(Function(Entity) Entity.CurrencyCode).ToArray

                    SearchableComboBoxDefaultNotes_Currency.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CurrencyCode.Load(DbContext)
                                                                          Where CurrencyCodes.Contains(Entity.Code) = True
                                                                          Select Entity).ToList

                    SearchableComboBoxDefaultNotes_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                    SearchableComboBoxDefaultNotes_DefaultAPAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, True, True, "5"))

                    Try

                        AllowCostOfSaleEntry = AdvantageFramework.Database.Procedures.Agency.AllowCostOfSaleEntry(DbContext)

                    Catch ex As Exception
                        AllowCostOfSaleEntry = False
                    End Try

                    SearchableComboBoxDefaultNotes_DefaultExpenseAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveByCostOfSaleEntryWithOfficeLimits(DbContext, _Session, True, False, AllowCostOfSaleEntry))

                    SearchableComboBoxDefaultNotes_DefaultFunction.DataSource = From Entity In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                                                                                Where (Entity.IsInactive Is Nothing OrElse
                                                                                       Entity.IsInactive = 0) AndAlso
                                                                                       Entity.Type = "V"
                                                                                Select Entity

                    SearchableComboBoxDefaultNotes_Terms.DataSource = AdvantageFramework.Database.Procedures.VendorTerm.LoadAllActive(DbContext)

                    SearchableComboBoxDefaultNotes_DefaultBank.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActiveWithOfficeLimits(DbContext, _Session).ToList

                    ' EEOC 2 Tab
                    SearchableComboBoxMOBD_Ethnicity.HideValueMemberColumn = True
                    SearchableComboBoxMOBD_Ethnicity.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorEEOC2Ethnicity))
                                                                   Select Entity.Code,
                                                                          [Description] = Entity.Description).ToList

                    ' Media Defaults Tab
                    _Markets = DbContext.Markets.Include("Country").Include("State").ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market(Entity)).ToList

                    SearchableComboBoxGeneralDefaultInformation_Market.DataSource = _Markets.Where(Function(Entity) Entity.IsInactive = False)
                    SearchableComboBoxGeneralDefaultInformation_TaxCode.DataSource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext)

                    If _Session.IsNielsenSetup Then

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                            SearchableComboBoxGeneralDefaultInformation_RadioStation.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen).ToList
                            SearchableComboBoxGeneralDefaultInformation_TVStation.DataSource = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                                                                                Where Entity.SourceType = "B"
                                                                                                Select Entity).ToList

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, _Session.NielsenClientCodeForHosted, Nothing)

                            Else

                                SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Nothing)

                            End If

                        End Using

                    End If

                    If _Session.IsNielsenSetup Then

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                            SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DataSource = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Eastlan).ToList

                        End Using

                    End If

                    ' Media Specs Tab
                    SearchableComboBoxMediaSpecs_DefaultSize.DataSource = AdvantageFramework.Database.Procedures.AdSize.Load(DbContext)

                    ' Service Tax Tab
                    SearchableComboBoxServiceTax_Code.DataSource = AdvantageFramework.Database.Procedures.VendorServiceTax.LoadAllActive(DataContext)

                End Using

            End Using

        End Sub
        Private Sub RefreshQuickBooksVendors()

            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.Quickbooks.GetVendors(_Session, _QuickBooksVendors, ErrorMessage) = False Then

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub UpdateQuickBooksCrossReference(DbContext As AdvantageFramework.Database.DbContext, VendorCode As String)

            Dim RecordSourceID As Integer = -1

            If _IsQuickbooksEnabled Then

                RecordSourceID = AdvantageFramework.Quickbooks.GetQuickBooksRecordSourceID(DbContext)

                If SearchableComboBoxMain_QuickBooksVendor.HasASelectedValue Then

                    If AdvantageFramework.Quickbooks.UpdateVendorCrossReference(DbContext, VendorCode, SearchableComboBoxMain_QuickBooksVendor.GetSelectedValue) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Selected QuickBooks vendor is already associated with another Advantage vendor.")

                        SearchableComboBoxMain_QuickBooksVendor.SelectedValue = Nothing

                    End If

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.VENDOR_XREF WHERE RECORD_SOURCE_ID = {0} AND VN_CODE = '{1}'", RecordSourceID, VendorCode))

                End If

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal VendorCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            _ControlLoaded = False

            _VendorCode = VendorCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" Then

                    TextBoxMain_Code.ReadOnly = True
                    TextBoxMain_Code.Enabled = False

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        TextBoxMain_Code.Text = Vendor.Code
                        ComboBoxMain_DefaultCategory.SelectedValue = Vendor.VendorCategory

                        LoadVendorDetails(Nothing)

                        TabItemVendorDetails_DocumentsTab.Visible = _HasAccessToDocuments

                    Else

                        Loaded = False

                    End If

                Else

                    ' new vendor
                    _IsNewVendor = True
                    TextBoxMain_Code.ReadOnly = False
                    TextBoxMain_Code.Enabled = True

                    If _Session.HasLimitedOfficeCodes Then

                        SearchableComboBoxDefaultNotes_Office.SetRequired(True)

                    End If

                    DateTimePickerServiceTax_WaiverExpirationDate.ValueObject = Nothing

                End If

                LabelMain_QuickbooksVendor.Visible = _IsQuickbooksEnabled
                SearchableComboBoxMain_QuickBooksVendor.Visible = _IsQuickbooksEnabled

            End Using

            EnableOrDisableTabs()

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

            _ControlLoaded = True

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Vendor

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Try

                If IsNew Then

                    Vendor = New AdvantageFramework.Database.Entities.Vendor

                    LoadVendorEntity(Vendor, IsNew)

                    If RadioButtonControlRates_Gross.Checked Then

                        Vendor.DefaultNetGross = Convert.ToInt16(1)

                    Else

                        Vendor.DefaultNetGross = Convert.ToInt16(0)

                    End If

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                        If Vendor IsNot Nothing Then

                            LoadVendorEntity(Vendor, IsNew)

                            If TabItemVendorDetails_EEOC2Tab.Tag = True Then

                                SaveEEOC2Tab(DbContext, Vendor)

                            End If

                        End If

                    End Using

                End If

                If Vendor IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(Vendor.CallLetters) Then

                        Vendor.CallLetters = String.Empty

                    End If

                    If String.IsNullOrWhiteSpace(Vendor.Band) Then

                        Vendor.Band = String.Empty

                    End If

                    If Vendor.VendorCategory IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Vendor.Band) Then

                        If Vendor.VendorCategory = "T" Then

                            Vendor.Band = AdvantageFramework.Database.Entities.TVBand.TV.ToString

                        ElseIf Vendor.VendorCategory = "R" Then

                            Vendor.Band = AdvantageFramework.Database.Entities.RadioBand.AM.ToString

                        End If

                    End If

                End If

            Catch ex As Exception
                Vendor = Nothing
            End Try

            FillObject = Vendor

        End Function
        Public Sub ClearControl()

            If _ControlLoaded Then

                _LastSelectedTabBeforeClearControl = TabControlControl_VendorDetails.SelectedTab

                ' Main Tab
                TextBoxMain_Code.Text = Nothing
                CheckBoxMain_Inactive.Checked = False
                TextBoxNameAndAddress_Fax.Text = Nothing
                TextBoxNameAndAddress_FaxExt.Text = Nothing
                TextBoxNameAndAddress_Name.Text = Nothing
                TextBoxNameAndAddress_Phone.Text = Nothing
                TextBoxNameAndAddress_PhoneExt.Text = Nothing
                Address3LineControlNameAndAddress_Address.ClearControl()
                TextBoxPayToNameAndAddress_Vendor.Text = Nothing
                SearchableComboBoxMain_QuickBooksVendor.SelectedValue = Nothing

                TextBoxPayToNameAndAddress_Fax.Text = Nothing
                TextBoxPayToNameAndAddress_FaxExt.Text = Nothing
                TextBoxPayToNameAndAddress_Name.Text = Nothing
                TextBoxPayToNameAndAddress_Phone.Text = Nothing
                TextBoxPayToNameAndAddress_PhoneExt.Text = Nothing
                TextBoxMain_Email.Text = Nothing
                TextBoxMain_FederalTaxID.Text = Nothing
                TextBoxMain_PaymentManagerEmail.Text = Nothing
                TextBoxMain_Website.Text = Nothing
                ComboBoxMain_DefaultCategory.SelectedValue = "N"
                TextBoxMain_VATNumber.Text = Nothing

                ' Defaults / Notes Tab
                TextBoxDefaultNotes_VendorAccount.Text = Nothing
                SearchableComboBoxDefaultNotes_Currency.SelectedValue = Nothing
                TextBoxDefaultNotes_SortName.Text = Nothing
                SearchableComboBoxDefaultNotes_Office.SelectedValue = Nothing
                SearchableComboBoxDefaultNotes_DefaultAPAccount.SelectedValue = Nothing
                ComboBoxDefaultNotes_SortOptions.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.VendorSortKey)
                SearchableComboBoxDefaultNotes_DefaultExpenseAccount.SelectedValue = Nothing
                ComboBoxDefaultNotes_ACHType.SelectedIndex = 0
                SearchableComboBoxDefaultNotes_DefaultFunction.SelectedValue = Nothing
                CheckBoxDefaultNotes_ACH.Checked = False
                SearchableComboBoxDefaultNotes_Terms.SelectedValue = Nothing
                CheckBoxDefaultNotes_EmployeeVendor.Checked = False
                CheckBoxDefaultNotes_OneCheckPerInvoice.Checked = False
                TextBoxDefaultNotes_Notes.Text = Nothing
                ComboBoxDefaultNotes_VCCStatus.SelectedValue = Nothing
                NumericInputDefaultNotes_VCCLimit.EditValue = Nothing
                CheckBoxDefaultNotes_SpecialTerms.Checked = False
                ComboBoxDefaultNotes_InvoiceCategory.SelectedValue = Nothing

                ' EEOC Status Tab
                DataGridViewLeftSection_AvailableEEOCStatuses.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus)
                DataGridViewRightSection_SelectedEEOCStatuses.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.VendorEEOCStatus)

                ' EEOC 2 Tab
                SearchableComboBoxMOBD_Ethnicity.SelectedValue = Nothing
                TextBoxMOBD_MinorityCertifcateNumber.Text = Nothing
                DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ValueObject = Nothing
                CheckBoxMODB_IsNMSDC.Checked = False
                CheckBoxWBD_IsWBENC.Checked = False
                TextBoxWBD_WBENCCertificationNumber.Text = Nothing
                DateTimePickerWBD_WBENCCertificationExpirationDate.ValueObject = Nothing

                ' 1099 Info Tab
                RadioButtonControl1099Info_GrossProceedsToAttorney.Checked = False
                RadioButtonControl1099Info_Royalties.Checked = False
                RadioButtonControl1099Info_Rent.Checked = False
                RadioButtonControl1099Info_OtherIncome.Checked = False
                RadioButtonControl1099Info_NonEmployeeCompensation.Checked = False
                CheckBox1099Info_Is1099Vendor.Checked = False
                CheckBox1099Info_Use1099Address.Checked = False
                Address3LineControl1099Info_Address.ClearControl()

                ' Contacts Tab
                DataGridViewContacts_Contacts.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.VendorContact)
                TextBoxContacts_DefaultVendorContactCode.Text = Nothing

                ' Representatives Tab
                DataGridViewRepresentatives_VendorReps.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.VendorRepresentative)
                TextBoxRepresentatives_DefaultRep1.Text = Nothing
                TextBoxRepresentatives_DefaultRep2.Text = Nothing

                ' Media Defaults Tab
                TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Text = Nothing
                SearchableComboBoxGeneralDefaultInformation_TaxCode.SelectedValue = Nothing
                CheckBoxApplyTo_NetDiscount.Checked = False
                CheckBoxApplyTo_AddlCharge.Checked = False
                CheckBoxApplyTo_Rebate.Checked = False
                CheckBoxApplyTo_NetCharge.Checked = False
                CheckBoxApplyTo_Commission.Checked = False
                CheckBoxApplyTo_LineNet.Checked = False
                NumericInputGeneralDefaultInformation_ColumnWidth.EditValue = Nothing
                CheckBoxApplyTo_UseFlags.Checked = False
                SearchableComboBoxGeneralDefaultInformation_Market.SelectedValue = Nothing
                NumericInputGeneralDefaultInformation_OveragePercent.EditValue = Nothing
                NumericInputGeneralDefaultInformation_CommissionPercent.EditValue = Nothing
                NumericInputGeneralDefaultInformation_MarkupPercent.EditValue = Nothing

                RadioButtonControlRates_Gross.Checked = False
                RadioButtonControlRates_Net.Checked = False
                NumericInputDeadlines_SpaceCloseDays.EditValue = Nothing
                NumericInputDeadlines_MaterialCloseDays.EditValue = Nothing
                RadioButtonControlUnits_Daily.Checked = False
                RadioButtonControlUnits_WeeklyOrCalendarMonth.Checked = False
                RadioButtonControlUnits_MontlyOrBroadcastMonth.Checked = False

                CheckBoxDefaultComments_UseFooterComment.Checked = False
                TextBoxDefaultComments_Instructions.Text = Nothing
                TextBoxDefaultComments_FooterComment.Text = Nothing
                TextBoxDefaultComments_RateInfo.Text = Nothing
                TextBoxDefaultComments_MaterialNotes.Text = Nothing
                TextBoxDefaultComments_PositionInfo.Text = Nothing
                TextBoxDefaultComments_MiscInfo.Text = Nothing
                TextBoxDefaultComments_CloseInfo.Text = Nothing

                ' Media Info Tab

                ' Media Delivery Tab
                Address3LineControlMediaDelivery_MediaShippingAddress.ClearControl()
                TextBoxMediaDelivery_FTPDirectory.Text = Nothing
                TextBoxMediaDelivery_FTPPassword.Text = Nothing
                TextBoxMediaDelivery_FTPUserName.Text = Nothing
                TextBoxMediaDelivery_PreferredMaterial.Text = Nothing
                TextBoxMediaDelivery_EFileInfo.Text = Nothing
                TextBoxMediaDelivery_AcceptedMedia.Text = Nothing
                TextBoxMediaDelivery_GeneralInfo.Text = Nothing

                TextBoxMediaShipping_Phone.Text = Nothing
                TextBoxMediaShipping_PhoneExt.Text = Nothing
                ComboBoxMediaDelivery_DefaultCorrespondenceMethod.SelectedIndex = 0

                ' Media Specs Tab

                ' Pricings Tab
                VendorPricingControlPricings_VendorPricings.ClearControl()

                _CategoryChanged = False

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsNewVendorComment As Boolean = False
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = Me.FillObject(False)

                    If Vendor IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(Vendor.MarketCode) = False AndAlso AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, Vendor.MarketCode).CountryID <> DTO.Countries.Canada Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.VENDOR_MARKET WHERE VN_CODE = '{0}'", Vendor.Code))

                        End If

                        Saved = AdvantageFramework.Database.Procedures.Vendor.Update(DbContext, Vendor)

                        If Saved Then

                            UpdateQuickBooksCrossReference(DbContext, Vendor.Code)

                            VendorComment = FillVendorCommentObject(Vendor, IsNewVendorComment)

                            If VendorComment IsNot Nothing Then

                                If IsNewVendorComment Then

                                    VendorComment.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.VendorComment.Insert(DbContext, VendorComment)

                                Else

                                    AdvantageFramework.Database.Procedures.VendorComment.Update(DbContext, VendorComment)

                                End If

                            End If

                            Me.SaveMediaSpecs()

                            VendorPricingControlPricings_VendorPricings.Save()

                        End If

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
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False
            Dim QuickBooksRecordSourceID As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = Me.FillObject(False)

                    If Vendor IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Vendor.Delete(DbContext, Vendor)

                        If Deleted AndAlso _IsQuickbooksEnabled Then

                            QuickBooksRecordSourceID = AdvantageFramework.Quickbooks.GetQuickBooksRecordSourceID(DbContext)

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.VENDOR_XREF WHERE VN_CODE = '{0}' AND RECORD_SOURCE_ID = {1}", Vendor.Code, QuickBooksRecordSourceID))

                        End If

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The Vendor is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef VendorCode As String) As Boolean

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorComment As AdvantageFramework.Database.Entities.VendorComment = Nothing
            Dim VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = Me.FillObject(True)

                    If Vendor IsNot Nothing Then

                        Vendor.DbContext = DbContext

                        If (String.IsNullOrWhiteSpace(Vendor.ShipToName)) Then
                            Vendor.ShipToName = Vendor.Name
                        End If

                        Inserted = AdvantageFramework.Database.Procedures.Vendor.Insert(DbContext, Vendor)

                        If Inserted Then

                            UpdateQuickBooksCrossReference(DbContext, Vendor.Code)

                            VendorComment = FillVendorCommentObject(Vendor, True)

                            If VendorComment IsNot Nothing Then

                                VendorComment.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.VendorComment.Insert(DbContext, VendorComment)

                            End If

                            If Me.SortKeyList IsNot Nothing Then

                                For Each SortKey In Me.SortKeyList.OfType(Of AdvantageFramework.Database.Entities.VendorSortKey).ToList

                                    VendorSortKey = SortKey
                                    VendorSortKey.VendorCode = Vendor.Code
                                    VendorSortKey.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.VendorSortKey.Insert(DbContext, VendorSortKey)

                                Next

                            End If

                            VendorCode = Vendor.Code

                        Else

                            TextBoxPayToNameAndAddress_Vendor.Tag = Nothing

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
        Public Sub AddVendorRepresentative(Optional LockVendorSelection As Boolean = False)

            If _VendorCode <> "" Then

                If AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog.ShowFormDialog(_VendorCode, LockVendorSelection:=LockVendorSelection) = Windows.Forms.DialogResult.OK Then

                    LoadVendorRepresentatives()

                End If

            End If

        End Sub
        Public Sub DeleteVendorRepresentative()

            'objects
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorRepCode As String = Nothing

            If DataGridViewRepresentatives_VendorReps.HasOnlyOneSelectedRow Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    VendorRepCode = DataGridViewRepresentatives_VendorReps.CurrentView.GetRowCellValue(DataGridViewRepresentatives_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRepresentative.Properties.Code.ToString)

                    VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, VendorRepCode, _VendorCode)

                    If VendorRepresentative IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.VendorRepresentative.Delete(DataContext, VendorRepresentative) Then

                            LoadVendorRepresentatives()

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub EditVendorRepresentative(Optional LockVendorSelection As Boolean = False)

            'objects
            Dim VendorRepCode As String = Nothing

            If DataGridViewRepresentatives_VendorReps.HasOnlyOneSelectedRow Then

                VendorRepCode = DataGridViewRepresentatives_VendorReps.CurrentView.GetRowCellValue(DataGridViewRepresentatives_VendorReps.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorRepresentative.Properties.Code.ToString)

                If AdvantageFramework.Maintenance.Media.Presentation.VendorRepEditDialog.ShowFormDialog(_VendorCode, VendorRepCode, LockVendorSelection:=LockVendorSelection) = Windows.Forms.DialogResult.OK Then

                    LoadVendorRepresentatives()

                End If

            End If

        End Sub
        Public Sub AddVendorContact()

            If _VendorCode <> "" Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactEditDialog.ShowFormDialog(_VendorCode) = Windows.Forms.DialogResult.OK Then

                    LoadVendorContacts()

                End If

            End If

        End Sub
        Public Sub DeleteVendorContact()

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim VendorContactCode As String = Nothing

            If DataGridViewContacts_Contacts.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContactCode = DataGridViewContacts_Contacts.CurrentView.GetRowCellValue(DataGridViewContacts_Contacts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorContact.Properties.ContactCode.ToString)

                    VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, _VendorCode, VendorContactCode)

                    If VendorContact IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.VendorContact.Delete(DbContext, VendorContact) Then

                            LoadVendorContacts()

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub EditVendorContact()

            'objects
            Dim VendoContactCode As String = Nothing

            If DataGridViewContacts_Contacts.HasOnlyOneSelectedRow Then

                VendoContactCode = DataGridViewContacts_Contacts.CurrentView.GetRowCellValue(DataGridViewContacts_Contacts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.VendorContact.Properties.ContactCode.ToString)

                If AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactEditDialog.ShowFormDialog(_VendorCode, VendoContactCode) = Windows.Forms.DialogResult.OK Then

                    LoadVendorContacts()

                End If

            End If

        End Sub
        Public Sub SpellCheckSelectedTab()

            If TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_DefaultsNotesTab Then

                TextBoxDefaultNotes_Notes.CheckSpelling()

            ElseIf TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaInfoTab Then

                If PanelMediaInfo_Magazine.Visible Then

                    TextBoxMagazine_PublishingFrequency.CheckSpelling()
                    TextBoxMagazine_Editions.CheckSpelling()

                ElseIf PanelMediaInfo_Newspaper.Visible Then

                    TextBoxNewspaper_PublishingFrequency.CheckSpelling()
                    TextBoxNewspaper_Editions.CheckSpelling()

                End If

            ElseIf TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaDefaultsTab Then

                If TabControlMediaDefaults_MediaDefaultsTab.SelectedTab Is TabItemMediaDefaults_DefaultCommentsTab Then

                    TextBoxDefaultComments_Instructions.CheckSpelling()
                    TextBoxDefaultComments_CloseInfo.CheckSpelling()
                    TextBoxDefaultComments_MiscInfo.CheckSpelling()
                    TextBoxDefaultComments_PositionInfo.CheckSpelling()
                    TextBoxDefaultComments_MaterialNotes.CheckSpelling()
                    TextBoxDefaultComments_RateInfo.CheckSpelling()
                    TextBoxDefaultComments_FooterComment.CheckSpelling()

                End If

            ElseIf TabControlControl_VendorDetails.SelectedTab Is TabItemVendorDetails_MediaDeliveryTab Then

                TextBoxMediaDelivery_GeneralInfo.CheckSpelling()

            End If

        End Sub
        Public Sub AddMediaSpec()

            'objects
            Dim TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim ParentListNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing

            If Me.CanAddNewMediaSpec Then

                TreeListNode = TreeListControlMediaSpecs_MediaSpecs.AppendNode(Nothing, ParentListNode)

                If TreeListNode.Item("Code") IsNot Nothing Then

                    TreeListNode.Item("Code") = ""

                End If

                TreeListControlMediaSpecs_MediaSpecs.FocusedNode = TreeListNode

                TreeListControlMediaSpecs_MediaSpecs.ShowEditor()

                If TypeOf TreeListControlMediaSpecs_MediaSpecs.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    DirectCast(TreeListControlMediaSpecs_MediaSpecs.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).ShowPopup()

                End If

                RaiseEvent MediaSpecsChangedEvent()

            End If

        End Sub
        Public Sub SaveMediaSpecs()

            ' objects
            Dim MediaSpecsHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader = Nothing
            Dim MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail = Nothing
            Dim AdSizeLabels As Generic.List(Of AdvantageFramework.Database.Entities.AdSizeLabel) = Nothing
            Dim AdSizeLabel As AdvantageFramework.Database.Entities.AdSizeLabel = Nothing
            Dim FlagChange As Boolean = False

            If TreeListControlMediaSpecs_MediaSpecs.Nodes.Count > 0 Then

                TreeListControlMediaSpecs_MediaSpecs.CloseEditor()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        AdSizeLabels = AdvantageFramework.Database.Procedures.AdSizeLabel.LoadByMediaType(DbContext, ComboBoxMain_DefaultCategory.GetSelectedValue).ToList

                    Catch ex As Exception
                        AdSizeLabels = Nothing
                    End Try

                    If AdSizeLabels IsNot Nothing AndAlso AdSizeLabels.Count > 0 Then

                        For Each Node In TreeListControlMediaSpecs_MediaSpecs.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)()

                            If Node.Tag IsNot Nothing Then

                                Try

                                    MediaSpecsHeader = DirectCast(Node.Tag, AdvantageFramework.Database.Entities.MediaSpecsHeader)

                                Catch ex As Exception
                                    MediaSpecsHeader = Nothing
                                End Try

                                If MediaSpecsHeader IsNot Nothing Then

                                    For Each AdSizeLabel In AdSizeLabels

                                        MediaSpecsDetail = AdvantageFramework.Database.Procedures.MediaSpecsDetail.LoadBySpecIDLabelIDandMediaType(DbContext, MediaSpecsHeader.ID, AdSizeLabel.ID, ComboBoxMain_DefaultCategory.GetSelectedValue)

                                        If MediaSpecsDetail IsNot Nothing Then

                                            If Node.Item(AdSizeLabel.ID) IsNot Nothing AndAlso Node.Item(AdSizeLabel.ID) <> MediaSpecsDetail.SpecData Then

                                                MediaSpecsDetail.SpecData = Node.Item(AdSizeLabel.ID)

                                                If AdvantageFramework.Database.Procedures.MediaSpecsDetail.Update(DbContext, MediaSpecsDetail) Then

                                                    FlagChange = True

                                                End If

                                            End If

                                        ElseIf Node.Item(AdSizeLabel.ID) IsNot Nothing Then

                                            MediaSpecsDetail = New AdvantageFramework.Database.Entities.MediaSpecsDetail

                                            MediaSpecsDetail.DbContext = DbContext
                                            MediaSpecsDetail.SpecID = MediaSpecsHeader.ID
                                            MediaSpecsDetail.LabelID = AdSizeLabel.ID
                                            MediaSpecsDetail.MediaType = ComboBoxMain_DefaultCategory.GetSelectedValue
                                            MediaSpecsDetail.SpecData = Node.Item(AdSizeLabel.ID)

                                            If AdvantageFramework.Database.Procedures.MediaSpecsDetail.Insert(DbContext, MediaSpecsDetail) Then

                                                FlagChange = True

                                            End If

                                        End If

                                    Next

                                    If FlagChange Then

                                        MediaSpecsHeader.DateModified = System.DateTime.Now
                                        MediaSpecsHeader.ModifiedBy = _Session.UserName

                                        If AdvantageFramework.Database.Procedures.MediaSpecsHeader.Update(DbContext, MediaSpecsHeader) Then

                                            Node.Tag = MediaSpecsHeader

                                        End If

                                    End If

                                End If

                            Else

                                MediaSpecsHeader = New AdvantageFramework.Database.Entities.MediaSpecsHeader

                                MediaSpecsHeader.DbContext = DbContext
                                MediaSpecsHeader.AdSize = Node.Item("Code")
                                MediaSpecsHeader.VendorCode = _VendorCode
                                MediaSpecsHeader.DateCreated = System.DateTime.Now
                                MediaSpecsHeader.CreatedBy = _Session.UserName

                                If AdvantageFramework.Database.Procedures.MediaSpecsHeader.Insert(DbContext, MediaSpecsHeader) Then

                                    Node.Tag = MediaSpecsHeader

                                    For Each AdSizeLabel In AdSizeLabels

                                        If Node.Item(AdSizeLabel.ID) IsNot Nothing AndAlso Node.Item(AdSizeLabel.ID) <> "" Then

                                            MediaSpecsDetail = New AdvantageFramework.Database.Entities.MediaSpecsDetail

                                            MediaSpecsDetail.DbContext = DbContext
                                            MediaSpecsDetail.SpecID = MediaSpecsHeader.ID
                                            MediaSpecsDetail.LabelID = AdSizeLabel.ID
                                            MediaSpecsDetail.SpecData = Node.Item(AdSizeLabel.ID)
                                            MediaSpecsDetail.MediaType = ComboBoxMain_DefaultCategory.GetSelectedValue

                                            AdvantageFramework.Database.Procedures.MediaSpecsDetail.Insert(DbContext, MediaSpecsDetail)

                                        End If

                                    Next

                                End If

                            End If

                        Next

                    End If

                End Using

            End If

        End Sub
        Public Sub DeleteSelectedMediaSpec()

            ' objects
            Dim MediaSpecsHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader = Nothing

            If TreeListControlMediaSpecs_MediaSpecs.Selection.Count = 1 Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            MediaSpecsHeader = DirectCast(TreeListControlMediaSpecs_MediaSpecs.Selection(0).Tag, AdvantageFramework.Database.Entities.MediaSpecsHeader)

                        Catch ex As Exception
                            MediaSpecsHeader = Nothing
                        End Try

                        TreeListControlMediaSpecs_MediaSpecs.ByPassUserEntryChanged = True

                        If MediaSpecsHeader IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.MediaSpecsHeader.Delete(DbContext, MediaSpecsHeader) Then

                                TreeListControlMediaSpecs_MediaSpecs.DeleteSelectedNodes()

                                RaiseEvent MediaSpecsChangedEvent()

                            End If

                        Else

                            TreeListControlMediaSpecs_MediaSpecs.DeleteSelectedNodes()

                            RaiseEvent MediaSpecsChangedEvent()

                        End If

                        TreeListControlMediaSpecs_MediaSpecs.ByPassUserEntryChanged = False

                    End Using

                End If

            End If

        End Sub
        Public Sub LoadRequiredNonGridControlsForValidation()

            'objects
            Dim RequiredTabsList As Generic.List(Of DevComponents.DotNetBar.TabItem) = Nothing

            If _VendorCode <> "" Then

                RequiredTabsList = New Generic.List(Of DevComponents.DotNetBar.TabItem)

                RequiredTabsList.Add(TabItemVendorDetails_MainTab)
                RequiredTabsList.Add(TabItemVendorDetails_DefaultsNotesTab)

                For Each TabItem In RequiredTabsList

                    If TabItem IsNot TabControlControl_VendorDetails.SelectedTab Then

                        LoadVendorDetails(TabItem)

                    End If

                Next

            End If

        End Sub
        Public Sub DeleteVendorPricing()

            VendorPricingControlPricings_VendorPricings.Delete()

        End Sub
        Public Sub CancelAddVendorPricing()

            VendorPricingControlPricings_VendorPricings.CancelAddVendorPricing()

        End Sub
        Public Sub UploadDocument()

            DocumentManagerControlDocuments_VendorDocuments.UploadNewDocument()

        End Sub
        Public Sub SendASPUploadEmail()

            DocumentManagerControlDocuments_VendorDocuments.SendASPUploadEmail()

        End Sub
        Public Sub DeletedDocument()

            DocumentManagerControlDocuments_VendorDocuments.DeleteSelectedDocument()

        End Sub
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_VendorDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub UpdatePayToVendorCode()

            If TextBoxMain_Code.Text <> "" AndAlso TextBoxPayToNameAndAddress_Vendor.Tag Is Nothing Then

                TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub
        Public Sub AddContract()

            VendorContractManagerControlContracts_Contracts.AddContract()

        End Sub
        Public Sub CopyContract()

            VendorContractManagerControlContracts_Contracts.CopyContract()

        End Sub
        Public Sub DeleteContract()

            VendorContractManagerControlContracts_Contracts.DeleteSelectedContract()

        End Sub
        Public Sub EditContract()

            VendorContractManagerControlContracts_Contracts.EditContract()

        End Sub
        Public Sub RefreshQuickBooksVendor()

            Dim ErrorMessage As String = Nothing
            Dim Vendor As AdvantageFramework.Quickbooks.Classes.Vendor = Nothing

            RefreshQuickBooksVendors()

            If SearchableComboBoxMain_QuickBooksVendor.HasASelectedValue AndAlso AdvantageFramework.Quickbooks.GetVendor(_Session, SearchableComboBoxMain_QuickBooksVendor.GetSelectedValue, Vendor, ErrorMessage) Then

                TextBoxNameAndAddress_Name.Text = Vendor.DisplayName

                Address3LineControlNameAndAddress_Address.Address = Vendor.BillAddressLine1
                Address3LineControlNameAndAddress_Address.Address2 = Vendor.BillAddressLine2
                Address3LineControlNameAndAddress_Address.Address3 = Vendor.BillAddressLine3
                Address3LineControlNameAndAddress_Address.City = Vendor.BillAddressCity
                Address3LineControlNameAndAddress_Address.State = Vendor.BillAddressState
                Address3LineControlNameAndAddress_Address.Zip = Vendor.BillAddressZip

                Address3LineControlPayToNameAndAddress_PayToAddress.Address = Vendor.BillAddressLine1
                Address3LineControlPayToNameAndAddress_PayToAddress.Address2 = Vendor.BillAddressLine2
                Address3LineControlPayToNameAndAddress_PayToAddress.Address3 = Vendor.BillAddressLine3
                Address3LineControlPayToNameAndAddress_PayToAddress.City = Vendor.BillAddressCity
                Address3LineControlPayToNameAndAddress_PayToAddress.State = Vendor.BillAddressState
                Address3LineControlPayToNameAndAddress_PayToAddress.Zip = Vendor.BillAddressZip

                TextBoxNameAndAddress_Phone.Text = Vendor.Phone

                TextBoxPayToNameAndAddress_Phone.Text = Vendor.Phone

                TextBoxMain_Website.Text = Vendor.Website
                TextBoxMain_Email.Text = Vendor.Email

            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub VendorControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemRefresh_Vendor.Image = AdvantageFramework.My.Resources.SmallVendorImage
            ButtonItemSortActions_Add.Icon = AdvantageFramework.My.Resources.AddIcon
            ButtonItemSortActions_Delete.Icon = AdvantageFramework.My.Resources.DeleteIcon

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_VendorDetails_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_VendorDetails.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True

                LoadVendorDetails(e.NewTab)

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False

            End If

            RaiseEvent SelectedTabChanged()

        End Sub

#Region "   Main Tab "

        Private Sub ComboBoxMain_DefaultCategory_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxMain_DefaultCategory.SelectedValueChanged

            'objects

            Dim SelectedValue As String = Nothing

            SelectedValue = ComboBoxMain_DefaultCategory.GetSelectedValue

            Select Case SelectedValue

                Case "M"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.Magazine
                    RadioButtonControlRates_Gross.Checked = True

                Case "N"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.Newspaper
                    RadioButtonControlRates_Net.Checked = True

                Case "R"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.Radio
                    RadioButtonControlRates_Gross.Checked = True

                    ComboBoxGeneralDefaultInformation_Band.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.RadioBand)).ToList
                                                                         Select [Name] = EnumObject.Description,
                                                                                [Value] = EnumObject.Code).ToList

                Case "T"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.Television
                    RadioButtonControlRates_Gross.Checked = True

                    ComboBoxGeneralDefaultInformation_Band.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.TVBand)).ToList
                                                                         Select [Name] = EnumObject.Description,
                                                                                [Value] = EnumObject.Code).ToList

                Case "O"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.OutOfHome
                    RadioButtonControlRates_Gross.Checked = True

                Case "I"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.Internet
                    RadioButtonControlRates_Net.Checked = True

                Case "P"

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.NonMedia
                    RadioButtonControlRates_Net.Checked = True

                Case Else

                    ComboBoxMain_DefaultCategory.Tag = Database.Entities.VendorCategory.NonMedia
                    RadioButtonControlRates_Net.Checked = True

            End Select

            If _ControlLoaded Then

                _CategoryChanged = True

            End If

            If ComboBoxMain_DefaultCategory.IsDataSourceLoading = False Then

                EnableOrDisableTabs()

                EnableOrDisableActions()

                LoadGeneralDefaultInformationSettings()

                LoadMediaInfoSettings()

                LoadMediaSpecs()

                LoadAdSizes()

            End If

        End Sub
        Private Sub ButtonItemRefresh_Vendor_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemRefresh_Vendor.Click

            TextBoxPayToNameAndAddress_Name.Text = TextBoxNameAndAddress_Name.Text
            Address3LineControlPayToNameAndAddress_PayToAddress.Address = Address3LineControlNameAndAddress_Address.Address
            Address3LineControlPayToNameAndAddress_PayToAddress.Address2 = Address3LineControlNameAndAddress_Address.Address2
            Address3LineControlPayToNameAndAddress_PayToAddress.Address3 = Address3LineControlNameAndAddress_Address.Address3
            Address3LineControlPayToNameAndAddress_PayToAddress.City = Address3LineControlNameAndAddress_Address.City
            Address3LineControlPayToNameAndAddress_PayToAddress.County = Address3LineControlNameAndAddress_Address.County
            Address3LineControlPayToNameAndAddress_PayToAddress.State = Address3LineControlNameAndAddress_Address.State
            Address3LineControlPayToNameAndAddress_PayToAddress.Zip = Address3LineControlNameAndAddress_Address.Zip
            Address3LineControlPayToNameAndAddress_PayToAddress.Country = Address3LineControlNameAndAddress_Address.Country

        End Sub
        Private Sub Address3LineControlNameAndAddress_Address_AddressChangedEvent() Handles Address3LineControlNameAndAddress_Address.AddressChangedEvent

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                Address3LineControlPayToNameAndAddress_PayToAddress.Address = Address3LineControlNameAndAddress_Address.Address
                Address3LineControlPayToNameAndAddress_PayToAddress.Address2 = Address3LineControlNameAndAddress_Address.Address2
                Address3LineControlPayToNameAndAddress_PayToAddress.Address3 = Address3LineControlNameAndAddress_Address.Address3
                Address3LineControlPayToNameAndAddress_PayToAddress.City = Address3LineControlNameAndAddress_Address.City
                Address3LineControlPayToNameAndAddress_PayToAddress.County = Address3LineControlNameAndAddress_Address.County
                Address3LineControlPayToNameAndAddress_PayToAddress.State = Address3LineControlNameAndAddress_Address.State
                Address3LineControlPayToNameAndAddress_PayToAddress.Zip = Address3LineControlNameAndAddress_Address.Zip
                Address3LineControlPayToNameAndAddress_PayToAddress.Country = Address3LineControlNameAndAddress_Address.Country

            End If

        End Sub
        Private Sub TextBoxNameAndAddress_Name_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNameAndAddress_Name.TextChanged

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                TextBoxPayToNameAndAddress_Name.Text = TextBoxNameAndAddress_Name.Text

                If TextBoxNameAndAddress_Name.Text.Length <= TextBoxDefaultNotes_SortName.MaxLength Then

                    TextBoxDefaultNotes_SortName.Text = TextBoxNameAndAddress_Name.Text

                End If

            End If

        End Sub
        Private Sub TextBoxNameAndAddress_Phone_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNameAndAddress_Phone.TextChanged

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                TextBoxPayToNameAndAddress_Phone.Text = TextBoxNameAndAddress_Phone.Text

            End If

        End Sub
        Private Sub TextBoxNameAndAddress_PhoneExt_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNameAndAddress_PhoneExt.TextChanged

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                TextBoxPayToNameAndAddress_PhoneExt.Text = TextBoxNameAndAddress_PhoneExt.Text

            End If

        End Sub
        Private Sub TextBoxNameAndAddress_Fax_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNameAndAddress_Fax.TextChanged

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                TextBoxPayToNameAndAddress_Fax.Text = TextBoxNameAndAddress_Fax.Text

            End If

        End Sub
        Private Sub TextBoxNameAndAddress_FaxExt_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNameAndAddress_FaxExt.TextChanged

            If _IsNewVendor AndAlso TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                TextBoxPayToNameAndAddress_FaxExt.Text = TextBoxNameAndAddress_FaxExt.Text

            End If

        End Sub
        Private Sub TextBoxPayToNameAndAddress_Name_EnabledChanged(sender As Object, e As System.EventArgs) Handles TextBoxPayToNameAndAddress_Name.EnabledChanged

            If TextBoxPayToNameAndAddress_Name.Enabled = False Then

                If Me.FindForm IsNot Nothing Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(TextBoxPayToNameAndAddress_Name)

                End If

            End If

        End Sub
        Private Sub TextBoxPayToNameAndAddress_Vendor_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxPayToNameAndAddress_Vendor.FinalizeValidationEvent

            If IsValid = False Then

                If TextBoxPayToNameAndAddress_Vendor.Text = TextBoxMain_Code.Text Then

                    IsValid = True
                    ErrorText = ""

                End If

            End If

        End Sub
        Private Sub TextBoxPayToNameAndAddress_Vendor_TagObjectChanged() Handles TextBoxPayToNameAndAddress_Vendor.TagObjectChanged

            'objects
            Dim PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If TextBoxPayToNameAndAddress_Vendor.Tag IsNot Nothing Then

                If _LastSelectedPayToVendorCode <> TextBoxPayToNameAndAddress_Vendor.Text Then

                    _LastSelectedPayToVendorCode = TextBoxPayToNameAndAddress_Vendor.Text

                    Try

                        PayToVendor = DirectCast(TextBoxPayToNameAndAddress_Vendor.Tag, AdvantageFramework.Database.Entities.Vendor)

                    Catch ex As Exception
                        PayToVendor = Nothing
                    End Try

                    If PayToVendor IsNot Nothing AndAlso PayToVendor.Code <> TextBoxMain_Code.Text Then

                        LoadNameAndAddress(PayToVendor, Address3LineControlPayToNameAndAddress_PayToAddress)

                    Else

                        TextBoxPayToNameAndAddress_Name.Text = Nothing
                        Address3LineControlPayToNameAndAddress_PayToAddress.ClearControl()

                    End If

                End If

            Else

                If _IsNewVendor Then

                    If TextBoxPayToNameAndAddress_Vendor.Text <> TextBoxMain_Code.Text Then

                        TextBoxPayToNameAndAddress_Name.Text = Nothing
                        Address3LineControlPayToNameAndAddress_PayToAddress.ClearControl()

                    End If

                Else

                    TextBoxPayToNameAndAddress_Name.Text = Nothing
                    Address3LineControlPayToNameAndAddress_PayToAddress.ClearControl()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub TextBoxMain_Code_Leave(sender As Object, e As System.EventArgs) Handles TextBoxMain_Code.Leave

            If _IsNewVendor Then

                UpdatePayToVendorCode()

            End If

        End Sub
        Private Sub CheckBoxMain_Inactive_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxMain_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxMain_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxMain_Inactive.Checked = Not CheckBoxMain_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxMain_QuickBooksVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxMain_QuickBooksVendor.EditValueChanged

            If SearchableComboBoxMain_QuickBooksVendor.HasASelectedValue AndAlso _IsLoading = False Then

                If AdvantageFramework.WinForm.MessageBox.Show("Load from QuickBooks?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                    RefreshQuickBooksVendor()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxMain_QuickBooksVendor_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBoxMain_QuickBooksVendor.QueryPopUp

            Dim Vendors As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Vendor) = Nothing
            Dim ErrorMessage As String = Nothing

            If SearchableComboBoxMain_QuickBooksVendor.HasASelectedValue = False Then

                If AdvantageFramework.Quickbooks.GetUnMappedVendors(_Session, Vendors, ErrorMessage) Then

                    SearchableComboBoxMain_QuickBooksVendor.DataSource = Vendors

                ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub

#End Region

#Region "   Defaults / Notes Tab "

        Private Sub ButtonItemSortActions_Add_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortActions_Add.Click

            'objects
            Dim SortKey As String = Nothing
            Dim VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey = Nothing

            If _VendorCode <> "" Then

                If AdvantageFramework.Maintenance.Client.Presentation.SortOptionsDialog.ShowFormDialog(SortKey, False, Nothing, Nothing, Nothing, _VendorCode) = System.Windows.Forms.DialogResult.OK Then

                    LoadSortKeys()

                End If

            Else

                If AdvantageFramework.Maintenance.Client.Presentation.SortOptionsDialog.ShowFormDialog(SortKey, True, Nothing, Nothing, Nothing, Nothing, Maintenance.Client.Presentation.SortOptionsDialog.NewEntityType.Vendor) = System.Windows.Forms.DialogResult.OK Then

                    If SortKey IsNot Nothing Then

                        VendorSortKey = New AdvantageFramework.Database.Entities.VendorSortKey

                        VendorSortKey.SortKey = SortKey

                        If _SortKeyList Is Nothing Then

                            _SortKeyList = New Generic.List(Of AdvantageFramework.Database.Entities.VendorSortKey)

                        End If

                        If _SortKeyList.Where(Function(VendSortKey) VendSortKey.SortKey = SortKey).Any = False Then

                            _SortKeyList.Add(VendorSortKey)

                        End If

                        ComboBoxDefaultNotes_SortOptions.DataSource = _SortKeyList

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemSortActions_Delete_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemSortActions_Delete.Click

            'objects
            Dim SortKey As String = Nothing
            Dim VendorSortKey As AdvantageFramework.Database.Entities.VendorSortKey = Nothing

            If ComboBoxDefaultNotes_SortOptions.HasASelectedValue Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        SortKey = ComboBoxDefaultNotes_SortOptions.GetSelectedValue

                        If _VendorCode <> "" Then

                            VendorSortKey = AdvantageFramework.Database.Procedures.VendorSortKey.LoadByVendorCodeAndSortKey(DbContext, _VendorCode, SortKey)

                            If VendorSortKey IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.VendorSortKey.Delete(DbContext, VendorSortKey) Then

                                    ComboBoxDefaultNotes_SortOptions.SelectedItem = Nothing

                                    LoadSortKeys()

                                End If

                            End If

                        Else

                            Try

                                VendorSortKey = _SortKeyList.Where(Function(VendSortKey) VendSortKey.SortKey = SortKey).FirstOrDefault

                                _SortKeyList.Remove(VendorSortKey)

                            Catch ex As Exception

                            End Try

                            ComboBoxDefaultNotes_SortOptions.SelectedIndex = -1

                            ComboBoxDefaultNotes_SortOptions.DataSource = _SortKeyList

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ComboBoxDefaultNotes_ACHType_EnabledChanged(sender As Object, e As System.EventArgs) Handles ComboBoxDefaultNotes_ACHType.EnabledChanged

            Try

                If ComboBoxDefaultNotes_ACHType.Enabled = False Then

                    If ComboBoxDefaultNotes_ACHType.Items.Count > 0 Then

                        ComboBoxDefaultNotes_ACHType.SelectedIndex = 0

                    Else

                        ComboBoxDefaultNotes_ACHType.SelectedIndex = -1

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub CheckBoxDefaultNotes_ACH_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxDefaultNotes_ACH.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxDefaultNotes_DefaultOffice_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxDefaultNotes_Office.EditValueChanged

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            If SearchableComboBoxDefaultNotes_Office.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, SearchableComboBoxDefaultNotes_Office.GetSelectedValue)

                    If Office IsNot Nothing Then

                        SearchableComboBoxDefaultNotes_DefaultAPAccount.SelectedValue = Office.AccountsPayableGLACode

                    End If

                End Using

            End If

        End Sub
        Private Sub ComboBoxDefaultNotes_VCCStatus_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxDefaultNotes_VCCStatus.SelectedValueChanged

            If ComboBoxDefaultNotes_VCCStatus.HasASelectedValue AndAlso ComboBoxDefaultNotes_VCCStatus.GetSelectedValue = AdvantageFramework.Database.Entities.VCCStatuses.Accepted Then

                CheckBoxDefaultNotes_SendVCCWithMediaOrder.Enabled = True

            Else

                CheckBoxDefaultNotes_SendVCCWithMediaOrder.Checked = False
                CheckBoxDefaultNotes_SendVCCWithMediaOrder.Enabled = False

            End If

        End Sub

#End Region

#Region "   EEOCStatus Tab "

        Private Sub ButtonRightSection_AddEEOCStatus_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddEEOCStatus.Click

            'objects
            Dim SelectedVendorEEOCStatusCode As String = Nothing
            Dim EEOCStatus As AdvantageFramework.Database.Entities.EEOCStatus = Nothing

            If DataGridViewLeftSection_AvailableEEOCStatuses.HasOnlyOneSelectedRow Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    SelectedVendorEEOCStatusCode = DataGridViewLeftSection_AvailableEEOCStatuses.GetFirstSelectedRowBookmarkValue

                    EEOCStatus = New AdvantageFramework.Database.Entities.EEOCStatus

                    EEOCStatus.DataContext = DataContext
                    EEOCStatus.EEOCCode = SelectedVendorEEOCStatusCode
                    EEOCStatus.VendorCode = _VendorCode

                    If AdvantageFramework.Database.Procedures.EEOCStatus.Insert(DataContext, EEOCStatus) Then

                        LoadEEOCStatuses()

                        EnableOrDisableActions()

                    End If

                End Using

                EnableOrDisableTabs()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveEEOCStatus_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveEEOCStatus.Click

            'objects
            Dim EEOCCode As String = Nothing
            Dim EEOCStatus As AdvantageFramework.Database.Entities.EEOCStatus = Nothing

            If DataGridViewRightSection_SelectedEEOCStatuses.HasOnlyOneSelectedRow Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    EEOCCode = DataGridViewRightSection_SelectedEEOCStatuses.GetFirstSelectedRowBookmarkValue

                    EEOCStatus = AdvantageFramework.Database.Procedures.EEOCStatus.LoadByVendorAndEEOCCode(DataContext, _VendorCode, EEOCCode)

                    If EEOCStatus IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.EEOCStatus.Delete(DataContext, EEOCStatus) Then

                            DataContext.ExecuteCommand(String.Format("DELETE dbo.VENDOR_EEOC2 WHERE VN_CODE = '{0}'", _VendorCode))

                            TabItemVendorDetails_EEOC2Tab.Tag = False

                            LoadEEOCStatuses()

                            EnableOrDisableActions()

                        End If

                    End If

                End Using

                EnableOrDisableTabs()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableEEOCStatuses_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableEEOCStatuses.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedEEOCStatuses_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedEEOCStatuses.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "   1099 Info Tab "

        Private Sub CheckBox1099Info_Use1099Address_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1099Info_Use1099Address.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBox1099Info_Is1099Vendor_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1099Info_Is1099Vendor.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBox1099Info_Use1099Address_EnabledChanged(sender As Object, e As System.EventArgs) Handles CheckBox1099Info_Use1099Address.EnabledChanged

            If CheckBox1099Info_Use1099Address.Enabled = False Then

                CheckBox1099Info_Use1099Address.Checked = False

            End If

        End Sub

#End Region

#Region "   Contacts Tab "

        Private Sub DataGridViewContacts_Contacts_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewContacts_Contacts.CellValueChangingEvent

            'objects
            Dim DefaultVendorContactCode As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.VendorContact.Properties.IsDefault.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        If e.Value = True Then

                            DefaultVendorContactCode = DataGridViewContacts_Contacts.GetFirstSelectedRowBookmarkValue

                        Else

                            DefaultVendorContactCode = Nothing

                        End If

                        Vendor.DefaultVendorContactCode = DefaultVendorContactCode

                        If AdvantageFramework.Database.Procedures.Vendor.Update(DbContext, Vendor) = True Then

                            Saved = True

                            TextBoxContacts_DefaultVendorContactCode.Text = DefaultVendorContactCode

                        End If

                        LoadVendorContacts()

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewContacts_Contacts_RowDoubleClickEvent() Handles DataGridViewContacts_Contacts.RowDoubleClickEvent

            EditVendorContact()

        End Sub
        Private Sub DataGridViewContacts_Contacts_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewContacts_Contacts.SelectionChangedEvent

            If Me.IsContactsTabSelected Then

                RaiseEvent FocusedGridSelectionChangedEvent()

            End If

        End Sub

#End Region

#Region "   Representatives Tab "

        Private Sub DataGridViewRepresentatives_VendorReps_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRepresentatives_VendorReps.CellValueChangingEvent

            'objects
            Dim DefaultRepTextbox As AdvantageFramework.WinForm.Presentation.Controls.TextBox = Nothing
            Dim VendorRepCode As String = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.VendorRepresentative.Properties.DefaultRep1.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Classes.VendorRepresentative.Properties.DefaultRep2.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

                    If Vendor IsNot Nothing Then

                        If e.Value = True Then

                            VendorRepCode = DataGridViewRepresentatives_VendorReps.GetFirstSelectedRowBookmarkValue

                        Else

                            VendorRepCode = Nothing

                        End If

                        Select Case e.Column.FieldName

                            Case AdvantageFramework.Database.Classes.VendorRepresentative.Properties.DefaultRep1.ToString

                                Vendor.DefaultVendorRepresentativeCode1 = VendorRepCode
                                DefaultRepTextbox = TextBoxRepresentatives_DefaultRep1

                            Case AdvantageFramework.Database.Classes.VendorRepresentative.Properties.DefaultRep2.ToString

                                Vendor.DefaultVendorRepresentativeCode2 = VendorRepCode
                                DefaultRepTextbox = TextBoxRepresentatives_DefaultRep2

                        End Select

                        If AdvantageFramework.Database.Procedures.Vendor.Update(DbContext, Vendor) = True Then

                            Saved = True
                            DefaultRepTextbox.Text = VendorRepCode

                        End If

                        LoadVendorRepresentatives()

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewRepresentatives_VendorReps_RowDoubleClickEvent() Handles DataGridViewRepresentatives_VendorReps.RowDoubleClickEvent

            EditVendorRepresentative()

        End Sub
        Private Sub DataGridViewRepresentatives_VendorReps_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRepresentatives_VendorReps.SelectionChangedEvent

            If Me.IsRepresentativesTabSelected Then

                RaiseEvent FocusedGridSelectionChangedEvent()

            End If

        End Sub

#End Region

#Region "   Media Defaults Tab "

        Private Sub TabControlMediaDefaults_MediaDefaultsTab_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlMediaDefaults_MediaDefaultsTab.SelectedTabChanged

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub ButtonDefaultComments_CheckSpelling_Click(sender As System.Object, e As System.EventArgs) Handles ButtonDefaultComments_CheckSpelling.Click

            SpellCheckSelectedTab()

        End Sub
        Private Sub RadioButtonControlRates_Gross_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControlRates_Gross.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonControlRates_Net_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonControlRates_Net.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxGeneralDefaultInformation_IsCableSystem_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneralDefaultInformation_IsCableSystem.CheckedChangedEx

            If e.NewChecked.Checked Then

                SearchableComboBoxGeneralDefaultInformation_TVStation.SelectedValue = Nothing
                SearchableComboBoxGeneralDefaultInformation_ComscoreStation.SelectedValue = Nothing

            ElseIf Not e.NewChecked.Checked Then

                SearchableComboBoxGeneralDefaultInformation_CableSyscode.SelectedValue = Nothing

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralDefaultInformation_Market.EditValueChanged

            If SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If (ComboBoxMain_DefaultCategory.GetSelectedValue = "T" OrElse ComboBoxMain_DefaultCategory.GetSelectedValue = "R") AndAlso
                            AdvantageFramework.Database.Procedures.Market.IsMarketCanadian(DbContext, SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue) Then

                        'Try

                        '    _IsSelectedMarketCanadadian = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue).CountryID = DTO.Countries.Canada

                        'Catch ex As Exception
                        '    _IsSelectedMarketCanadadian = False
                        'End Try

                        _IsSelectedMarketCanadadian = True

                        LoadGeneralDefaultInformationSettings()

                        LabelGeneralDefaultInformation_IsCableSystem.Visible = False
                        CheckBoxGeneralDefaultInformation_IsCableSystem.Visible = False
                        LabelGeneralDefaultInformation_CableSyscode.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_CableSyscode.Visible = False
                        LabelGeneralDefaultInformation_Station.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_RadioStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_TVStation.Visible = False
                        LabelGeneralDefaultInformation_EastlanStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Visible = False
                        LabelGeneralDefaultInformation_ComscoreStation.Visible = False
                        SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Visible = False
                        LabelRatingsSubscriber.Visible = False
                        CheckBoxIsNielsenSubscriber.Visible = False
                        CheckBoxIsComscoreSubscriber.Visible = False

                        If ComboBoxMain_DefaultCategory.GetSelectedValue = "T" Then

                            LabelGeneralDefaultInformation_CanadianVendorType.Visible = True
                            ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = True

                        Else

                            LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                            ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                            If ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue <> 0 Then

                                ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue = 0

                            End If

                        End If

                    Else

                        LoadGeneralDefaultInformationSettings()

                        _IsSelectedMarketCanadadian = False

                        LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                        ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                        If ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue <> 0 Then

                            ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue = 0

                        End If

                    End If

                End Using

            Else

                SearchableComboBoxGeneralDefaultInformation_RadioStation.SelectedValue = Nothing
                SearchableComboBoxGeneralDefaultInformation_TVStation.SelectedValue = Nothing
                SearchableComboBoxGeneralDefaultInformation_CableSyscode.SelectedValue = Nothing
                SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.SelectedValue = Nothing
                SearchableComboBoxGeneralDefaultInformation_ComscoreStation.SelectedValue = Nothing

                LabelGeneralDefaultInformation_CanadianVendorType.Visible = False
                ComboBoxGeneralDefaultInformation_CanadianVendorType.Visible = False

                If ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue <> 0 Then

                    ComboBoxGeneralDefaultInformation_CanadianVendorType.SelectedValue = 0

                End If

                _IsSelectedMarketCanadadian = False

            End If

            EnableOrDisableActions()

            RaiseEvent MarketChangedEvent()

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_Market_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBoxGeneralDefaultInformation_Market.QueryPopUp

            If SearchableComboBoxGeneralDefaultInformation_Market.Properties.View.Columns(AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market.Properties.StateProvince.ToString) IsNot Nothing Then

                SearchableComboBoxGeneralDefaultInformation_Market.Properties.View.Columns(AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market.Properties.StateProvince.ToString).Caption = "State/Province"

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_Market_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_Market.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market = Nothing
            Dim DoesHaveStationInUse As Boolean = False
            Dim Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Market) = Nothing

            If SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Market = _Markets.SingleOrDefault(Function(Entity) Entity.Code = MarketCode)

                Markets = _Markets.Where(Function(Entity) Entity.IsInactive = False).ToList

                SearchableComboBoxGeneralDefaultInformation_Market.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.PleaseSelect

                If Markets.Any(Function(Entity) Entity.Code = MarketCode) = False Then

                    Markets.Add(Market)

                End If

                SearchableComboBoxGeneralDefaultInformation_Market.DataSource = Markets.OrderByDescending(Function(Entity) Entity.CountryID).ToList

            Else

                Markets = _Markets.Where(Function(Entity) Entity.IsInactive = False).ToList

                SearchableComboBoxGeneralDefaultInformation_Market.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.PleaseSelect

                SearchableComboBoxGeneralDefaultInformation_Market.DataSource = Markets.OrderByDescending(Function(Entity) Entity.CountryID).ToList


                'SearchableComboBoxGeneralDefaultInformation_Market.AddComboItemToExistingDataSource("[" & AdvantageFramework.StringUtilities.GetNameAsWords(SearchableComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                '                                                                                    AdvantageFramework.EnumUtilities.GetValue(GetType(SearchableComboBox.ExtraComboBoxItems), SearchableComboBox.ExtraComboBoxItems.PleaseSelect.ToString),
                '                                                                                    True)

            End If

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_RadioStation_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_RadioStation.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing
            Dim RadioCode As Integer = 0

            If _Session.IsNielsenSetup AndAlso SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                End Using

                If Market IsNot Nothing Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                        If IsNumeric(Market.NielsenRadioCode) Then

                            RadioCode = CInt(Market.NielsenRadioCode)

                        End If

                        NielsenRadioStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Nielsen)
                                                   Where Entity.NielsenRadioMarketNumber = RadioCode
                                                   Select Entity).OrderBy(Function(Entity) Entity.CallLetters).ToList

                    End Using

                End If

            End If

            SearchableComboBoxGeneralDefaultInformation_RadioStation.DataSource = NielsenRadioStationList

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation) = Nothing
            Dim RadioCode As Integer = 0

            If _Session.IsEastlanSetup AndAlso SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                End Using

                If Market IsNot Nothing Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                        If Market.EastlanRadioCode.HasValue Then

                            RadioCode = Market.EastlanRadioCode.Value

                        End If

                        NielsenRadioStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByRadioSource(NielsenDbContext, Nielsen.Database.Entities.RadioSource.Eastlan)
                                                   Where Entity.NielsenRadioMarketNumber = RadioCode
                                                   Select Entity).OrderBy(Function(Entity) Entity.CallLetters).ToList

                    End Using

                End If

            End If

            SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DataSource = NielsenRadioStationList

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_TVStation_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_TVStation.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenTVStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation) = Nothing

            If _Session.IsNielsenSetup AndAlso SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                End Using

                If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenTVCode) Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                        NielsenTVStationList = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.Load(NielsenDbContext)
                                                Where Entity.SourceType = "B" AndAlso
                                                      Entity.NielsenMarketNumber = CInt(Market.NielsenTVCode)
                                                Select Entity).OrderBy(Function(Entity) Entity.CallLetters).ToList

                    End Using

                End If

            End If

            SearchableComboBoxGeneralDefaultInformation_TVStation.DataSource = NielsenTVStationList

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_CableSyscode_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxGeneralDefaultInformation_CableSyscode.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode.Properties.Description.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode.Properties.Description.ToString).Visible = False

            End If

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_CableSyscode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_CableSyscode.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NCCTVSyscodeList As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode) = Nothing

            If _Session.IsNielsenSetup AndAlso CheckBoxGeneralDefaultInformation_IsCableSystem.Checked Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                    If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenTVCode) Then

                        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarketHosted(NielsenDbContext, _Session.NielsenClientCodeForHosted, Market.NielsenTVCode)

                            Else

                                NCCTVSyscodeList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.GetSyscodesByMarket(NielsenDbContext, Market.NielsenTVCode)

                            End If

                        End Using

                    End If

                End Using

            End If

            SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = NCCTVSyscodeList

            DataSourceSet = True

        End Sub
        Private Sub SearchableComboBoxGeneralDefaultInformation_ComscoreStation_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxGeneralDefaultInformation_ComscoreStation.QueryPopupNeedDataSource

            'objects
            Dim MarketCode As String = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim StationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station) = Nothing
            Dim RadioCode As Integer = 0

            If _Session.IsComscoreSetup AndAlso SearchableComboBoxGeneralDefaultInformation_Market.HasASelectedValue Then

                MarketCode = SearchableComboBoxGeneralDefaultInformation_Market.GetSelectedValue

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                    If Market IsNot Nothing AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                        StationList = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.Station)(String.Format("exec [advsp_comscore_stations] {0}, NULL", Market.ComscoreNewMarketNumber.Value)).ToList.Where(Function(Entity) Entity.ComscorePrimaryMarketNumber IsNot Nothing AndAlso Entity.ComscorePrimaryMarketNumber = Market.ComscoreNewMarketNumber.Value).ToList

                    End If

                End Using

            End If

            SearchableComboBoxGeneralDefaultInformation_ComscoreStation.DataSource = StationList

            DataSourceSet = True

        End Sub
        'Private Sub ComboBoxGeneralDefaultInformation_Band_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxGeneralDefaultInformation_Band.SelectedValueChanged

        '    If ComboBoxGeneralDefaultInformation_Band.HasASelectedValue Then

        '        ComboBoxGeneralDefaultInformation_Band.Tag = ComboBoxGeneralDefaultInformation_Band.SelectedValue

        '    Else

        '        ComboBoxGeneralDefaultInformation_Band.Tag = String.Empty

        '    End If

        'End Sub

#End Region

#Region "   Media Info Tab "

        Private Sub TextBoxMagazine_Editions_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxMagazine_Editions.TextChanged

            If TextBoxMagazine_Editions.Text <> TextBoxNewspaper_Editions.Text Then

                TextBoxNewspaper_Editions.Text = TextBoxMagazine_Editions.Text

            End If

        End Sub
        Private Sub TextBoxNewspaper_Editions_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNewspaper_Editions.TextChanged

            If TextBoxMagazine_Editions.Text <> TextBoxNewspaper_Editions.Text Then

                TextBoxMagazine_Editions.Text = TextBoxNewspaper_Editions.Text

            End If

        End Sub
        Private Sub TextBoxNewspaper_PublishingFrequency_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxNewspaper_PublishingFrequency.TextChanged

            If TextBoxMagazine_PublishingFrequency.Text <> TextBoxNewspaper_PublishingFrequency.Text Then

                TextBoxMagazine_PublishingFrequency.Text = TextBoxNewspaper_PublishingFrequency.Text

            End If

        End Sub
        Private Sub TextBoxMagazine_PublishingFrequency_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxMagazine_PublishingFrequency.TextChanged

            If TextBoxMagazine_PublishingFrequency.Text <> TextBoxNewspaper_PublishingFrequency.Text Then

                TextBoxNewspaper_PublishingFrequency.Text = TextBoxMagazine_PublishingFrequency.Text

            End If

        End Sub
        Private Sub NumericInputMagazine_Circulation_EditValueChanged(sender As Object, e As System.EventArgs) Handles NumericInputMagazine_Circulation.EditValueChanged

            If NumericInputMagazine_Circulation.GetValue <> NumericInputNewspaper_DailyCirculation.GetValue Then

                NumericInputNewspaper_DailyCirculation.EditValue = NumericInputMagazine_Circulation.GetValue

            End If

        End Sub
        Private Sub NumericInputNewspaper_DailyCirculation_EditValueChanged(sender As Object, e As System.EventArgs) Handles NumericInputNewspaper_DailyCirculation.EditValueChanged

            If NumericInputMagazine_Circulation.GetValue <> NumericInputNewspaper_DailyCirculation.GetValue Then

                NumericInputMagazine_Circulation.EditValue = NumericInputNewspaper_DailyCirculation.GetValue

            End If

        End Sub

#End Region

#Region "   Media Delivery Tab "

        Private Sub ButtonMediaDelivery_CheckSpelling_Click(sender As System.Object, e As System.EventArgs) Handles ButtonMediaDelivery_CheckSpelling.Click

            SpellCheckSelectedTab()

        End Sub

#End Region

#Region "   Media Specs Tab "

        Private Sub SearchableComboBoxMediaSpecs_DefaultSize_EditValueChanged(sender As Object, e As System.EventArgs) Handles SearchableComboBoxMediaSpecs_DefaultSize.EditValueChanged

            If SearchableComboBoxMediaSpecs_DefaultSize.IsDataSourceLoading = False Then

                SearchableComboBoxMediaSpecs_DefaultSize.Tag = SearchableComboBoxMediaSpecs_DefaultSize.GetSelectedValue

            End If

        End Sub
        Private Sub TreeListControlMediaSpecs_MediaSpecs_CellValueChanged(sender As Object, e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles TreeListControlMediaSpecs_MediaSpecs.CellValueChanged

            'objects
            Dim MediaSpecHeader As AdvantageFramework.Database.Entities.MediaSpecsHeader = Nothing

            If e.Column.FieldName = "Code" Then

                RaiseEvent MediaSpecsChangedEvent()

            End If

        End Sub
        Private Sub TreeListControlMediaSpecs_MediaSpecs_InvalidNodeException(sender As Object, e As DevExpress.XtraTreeList.InvalidNodeExceptionEventArgs) Handles TreeListControlMediaSpecs_MediaSpecs.InvalidNodeException

            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction

        End Sub
        Private Sub TreeListControlMediaSpecs_MediaSpecs_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TreeListControlMediaSpecs_MediaSpecs.ShowingEditor

            If TreeListControlMediaSpecs_MediaSpecs.FocusedColumn.FieldName = "Code" Then

                If TreeListControlMediaSpecs_MediaSpecs.Selection(0).Tag IsNot Nothing Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub TreeListControlMediaSpecs_MediaSpecs_ShownEditor(sender As Object, e As System.EventArgs) Handles TreeListControlMediaSpecs_MediaSpecs.ShownEditor

            ' objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim AdSizeCodes As Generic.List(Of String) = Nothing

            If TreeListControlMediaSpecs_MediaSpecs.FocusedColumn.FieldName = "Code" Then

                Try

                    GridLookUpEdit = DirectCast(TreeListControlMediaSpecs_MediaSpecs.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit)

                Catch ex As Exception
                    GridLookUpEdit = Nothing
                End Try

                If GridLookUpEdit IsNot Nothing Then

                    AdSizeCodes = New Generic.List(Of String)

                    For Each Node In TreeListControlMediaSpecs_MediaSpecs.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)

                        AdSizeCodes.Add(Node.GetValue(TreeListControlMediaSpecs_MediaSpecs.FocusedColumn.FieldName))

                    Next

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        BindingSource = New System.Windows.Forms.BindingSource

                        BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView((From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadByMediaType(DbContext, ComboBoxMain_DefaultCategory.GetSelectedValue).ToList
                                                                                                                                Where Entity.IsInactive.GetValueOrDefault(0) = 0 AndAlso
                                                                                                                                      AdSizeCodes.Contains(Entity.Code) = False
                                                                                                                                Select Entity).ToList)

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    End Using

                End If

            End If

        End Sub
        Private Sub TreeListControlMediaSpecs_MediaSpecs_ValidateNode(sender As Object, e As DevExpress.XtraTreeList.ValidateNodeEventArgs) Handles TreeListControlMediaSpecs_MediaSpecs.ValidateNode

            ' objects
            Dim AdSizeTreeListColumn As DevExpress.XtraTreeList.Columns.TreeListColumn = Nothing
            Dim ErrorText As String = Nothing

            Try

                AdSizeTreeListColumn = TreeListControlMediaSpecs_MediaSpecs.Columns("Code")

            Catch ex As Exception
                AdSizeTreeListColumn = Nothing
            End Try

            If AdSizeTreeListColumn IsNot Nothing Then

                If e.Node.Item("Code") Is Nothing OrElse e.Node.Item("Code") = "" Then

                    ErrorText = "Ad Size is required."
                    e.Valid = False

                Else

                    For Each Node In TreeListControlMediaSpecs_MediaSpecs.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                        If Node.Id <> e.Node.Id Then

                            If Node.Item("Code") = e.Node.Item("Code") Then

                                ErrorText = "There is already a Media Specification for " & e.Node.Item("Code") & "."
                                e.Valid = False

                            End If

                        End If

                    Next

                End If

                If e.Valid = False Then

                    TreeListControlMediaSpecs_MediaSpecs.SetColumnError(AdSizeTreeListColumn, ErrorText)

                End If

            End If

        End Sub

#End Region

#Region "   Pricings Tab "

        Private Sub VendorPricingControlPricings_VendorPricings_VendorPricingSelectionChangedEvent() Handles VendorPricingControlPricings_VendorPricings.VendorPricingSelectionChangedEvent

            If Me.IsPricingsTabSelected Then

                RaiseEvent VendorPricingsSelectionChangedEvent()

            End If

        End Sub

#End Region

#Region "  Service Tax Tab "

        Private Sub CheckBoxServiceTax_Waiver_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxServiceTax_Waiver.CheckedChanged

            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            If TabItemVendorDetails_VendorServiceTaxTab.Tag = True Then

                If CheckBoxServiceTax_Waiver.Checked Then

                    NumericInputServiceTax_Rate.EditValue = 0

                Else

                    If SearchableComboBoxServiceTax_Code.HasASelectedValue Then

                        Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            VendorServiceTax = AdvantageFramework.Database.Procedures.VendorServiceTax.LoadByVendorServiceTaxID(DataContext, SearchableComboBoxServiceTax_Code.GetSelectedValue)

                            If VendorServiceTax IsNot Nothing Then

                                NumericInputServiceTax_Rate.EditValue = VendorServiceTax.Rate

                            End If

                        End Using

                    End If

                    DateTimePickerServiceTax_WaiverExpirationDate.ValueObject = Nothing

                End If

            End If

            EnableOrDisableActions()

        End Sub
        'Private Sub DateTimePickerServiceTax_WaiverExpirationDate_Leave(sender As Object, e As EventArgs) Handles DateTimePickerServiceTax_WaiverExpirationDate.Leave

        '    If _VendorCode = "" AndAlso DateTimePickerServiceTax_WaiverExpirationDate.Value = #12:00:00 AM# Then

        '        DateTimePickerServiceTax_WaiverExpirationDate.Value = Now.ToShortDateString

        '    End If

        'End Sub
        Private Sub SearchableComboBoxServiceTax_Code_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxServiceTax_Code.EditValueChanged

            Dim VendorServiceTax As AdvantageFramework.Database.Entities.VendorServiceTax = Nothing

            If TabItemVendorDetails_VendorServiceTaxTab.Tag = True Then

                If SearchableComboBoxServiceTax_Code.HasASelectedValue Then

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        VendorServiceTax = AdvantageFramework.Database.Procedures.VendorServiceTax.LoadByVendorServiceTaxID(DataContext, SearchableComboBoxServiceTax_Code.GetSelectedValue)

                    End Using

                    If VendorServiceTax IsNot Nothing Then

                        SearchableComboBoxServiceTax_Type.SelectedValue = VendorServiceTax.Type
                        NumericInputServiceTax_Rate.EditValue = VendorServiceTax.Rate

                    End If

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxServiceTax_Type_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SearchableComboBoxServiceTax_Type.EditValueChanging

            If SearchableComboBoxServiceTax_Code.HasASelectedValue AndAlso e.NewValue <= 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SearchableComboBoxServiceTax_Type_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxServiceTax_Type.Popup

            If TypeOf sender Is AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox AndAlso DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).Properties.View.Columns("Code") IsNot Nothing Then

                DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox).Properties.View.Columns("Code").Visible = False

            End If

        End Sub

#End Region

#Region "   Documents Tab "

        Private Sub DocumentManagerControlDocuments_VendorDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_VendorDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub

#End Region

#Region "   Contracts Tab "

        Private Sub VendorContractManagerControlContracts_Contracts_RowCountChangedEvent() Handles VendorContractManagerControlContracts_Contracts.RowCountChangedEvent

            RaiseEvent VendorContractManagerRowCountChanged()

        End Sub
        Private Sub VendorContractManagerControlContracts_Contracts_SelectionChangedEvent() Handles VendorContractManagerControlContracts_Contracts.SelectionChangedEvent

            RaiseEvent VendorContractManagerSelectionChanged()

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
