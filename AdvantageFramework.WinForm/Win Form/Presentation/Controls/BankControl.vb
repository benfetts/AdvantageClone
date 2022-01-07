Namespace WinForm.Presentation.Controls

    Public Class BankControl

        Public Event SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _BankCode As String = Nothing
        Private _BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing
        Private _CheckWritingInProgress As Boolean = False
        Private _BankIsNew As Boolean = False
        Private _IsMultiCurrencyEnabled As Boolean = False
        Private _AgencyCurrencyCode As String = Nothing
        Private _CurrencyCode As String = Nothing
        'Private _CurrencyCodeOrig As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec
            Get
                BankExportSpec = _BankExportSpec
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

                            CheckBoxSetup_Inactive.ByPassUserEntryChanged = Not Form.Modal

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Bank)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            '
                            ' PROPERTY SETTINGS
                            '

                            ' Setup tab
                            TextBoxSetup_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.Code)
                            TextBoxSetup_Name.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.Description)
                            TextBoxSetup_AccountNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.AccountNumber)
                            TextBoxSetup_ACHCompanyID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ACHCompanyID)
                            NumericInputSetup_CheckTemplateID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckTemplateID)
                            NumericInputSetup_LastComputerCheckIssued.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.LastComputerCheck)
                            NumericInputSetup_LastManualCheckIssued.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.LastManualCheck)
                            NumericInputSetup_RoutingNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.RoutingNumber)
                            SearchableComboBoxSetup_Office.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.OfficeCode)
                            SearchableComboBoxSetup_ARCashAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ARCashAccount)
                            SearchableComboBoxSetup_APCashAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.APCashAccount)
                            SearchableComboBoxSetup_APDiscAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.APDiscAccount)
                            SearchableComboBoxSetup_ServiceChargeGLAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ServiceChargeGLAccount)
                            SearchableComboBoxSetup_InterestEarnedGLAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.InterestEarnedGLAccount)
                            ComboBoxSetup_CheckAmountInWords.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckAmountInWords)
                            TextBoxSetup_DigitalSignatureText.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.DigitalSignatureText)

                            ' Currency Tab
                            SearchableComboBoxCurrency_Currency.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CurrencyCode)
                            SearchableComboBoxCurrency_Currency.DisplayName = "Currency"
                            SearchableComboBoxCurrency_ExchangeRealizedAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ExchangeConversionAccount)
                            SearchableComboBoxCurrency_ExchangeRealizedAccount.DisplayName = "Currency Exchange Realized"
                            SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CurrencyExchangeUnrealizedGLAccount)
                            SearchableComboBoxCurrency_ExchangeUnrealizedAccount.DisplayName = "Currency Exchange Unrealized"

                            _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

                            SearchableComboBoxCurrency_Currency.SetRequired(_IsMultiCurrencyEnabled)
                            SearchableComboBoxCurrency_ExchangeRealizedAccount.SetRequired(_IsMultiCurrencyEnabled)
                            SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SetRequired(_IsMultiCurrencyEnabled)

                            TabItemBankDetails_Currency.Visible = _IsMultiCurrencyEnabled

                            _AgencyCurrencyCode = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                            ' Check Import Tab
                            TextBoxCheckImport_ImportFileName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ImportFileName)
                            NumericInputLeftColumn_ColumnStart.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckNumberColumnStart)
                            NumericInputLeftColumn_Length.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckNumberLength)
                            NumericInputRightColumn_ColumnStart.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckAmountColumnStart)
                            NumericInputRightColumn_Length.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckAmountLength)
                            NumericInputRightColumn_NumberOfDecimals.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CheckAmountNumberOfDecimals)

                            ' Payment Manager Tab
                            TextBoxPaymentManager_AccountNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.AccountNumber)
                            TextBoxPaymentManager_CustomerID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerID)
                            TextBoxPaymentManager_Word.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerWord)
                            TextBoxPaymentManager_FTPClient.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTP)
                            TextBoxPaymentManager_FileOutputDirectory.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerDirectory)
                            SearchableComboBoxPaymentManager_ExportType.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerType)
                            TextBoxPaymentManager_CSIUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CSIUserName)
                            TextBoxPaymentManager_CSIPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CSIPassword)
                            TextBoxPaymentManager_CSITargetFolder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.CSITargetFolder)
                            TextBoxPaymentManager_ComDataAccountCode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ComDataAccountCode)
                            TextBoxPaymentManager_ComDataPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.ComDataPassword)
                            TextBoxPaymentManager_DestinationName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerACHDestinationName)
                            ComboBoxPaymentManager_ServiceClassCode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerACHServiceClassCode)
                            ComboBoxPaymentManager_StandardEntryClassCode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerACHStandardEntryClassCode)
                            TextBoxPaymentManager_CompanyName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerACHCompanyName)
                            TextBoxPaymentManager_CompanyEntryDescription.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerACHCompanyEntryDescription)

                            TextBoxPaymentManager_FTPAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPAddress)
                            TextBoxPaymentManager_FTPFolder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPFolder)
                            TextBoxPaymentManager_FTPUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPUsername)
                            TextBoxPaymentManager_FTPPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPPassword)
                            TextBoxPaymentManager_FTPPort.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPPort)
                            TextBoxPaymentManager_FTPExportFolder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPExportFolder)

                            ComboBoxPaymentManager_FTPSecure.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Bank.Properties.PaymentManagerFTPSSLMode)

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.BankExportSpec)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            TextBoxSetup_BankID.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankID)

                            ' Check Export Tab
                            NumericInputHeaderRecord_AgencyBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AgencyBeginPositionHeader)
                            NumericInputHeaderRecord_AgencyEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AgencyEndPositionHeader)
                            NumericInputHeaderRecord_AgencyCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AgencyCSVOrderHeader)
                            NumericInputHeaderRecord_CreateDateBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CreateDateBeginPositionHeader)
                            NumericInputHeaderRecord_CreateDateEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CreateDateEndPositionHeader)
                            NumericInputHeaderRecord_CreateDateCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CreateDateCSVOrderHeader)
                            NumericInputHeaderRecord_Filler1BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1BeginPositionHeader)
                            NumericInputHeaderRecord_Filler1EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1EndPositionHeader)
                            TextBoxHeaderRecord_Filler1FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1ValueHeader)
                            NumericInputHeaderRecord_Filler2BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2BeginPositionHeader)
                            NumericInputHeaderRecord_Filler2EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2EndPositionHeader)
                            TextBoxHeaderRecord_Filler2FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2ValueHeader)
                            NumericInputDetailRecord_BankIDBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDBeginPositionDetail)
                            NumericInputDetailRecord_BankIDEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDEndPositionDetail)
                            NumericInputDetailRecord_BankIDCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDCSVOrderDetail)
                            NumericInputDetailRecord_AccountNumberBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberBeginPositionDetail)
                            NumericInputDetailRecord_AccountNumberEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberEndPositionDetail)
                            NumericInputDetailRecord_AccountNumberCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberCSVOrderDetail)
                            NumericInputDetailRecord_CheckNumberBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckNumberBeginPositionDetail)
                            NumericInputDetailRecord_CheckNumberEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckNumberEndPositionDetail)
                            NumericInputDetailRecord_CheckNumberCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckNumberCSVOrderDetail)
                            NumericInputDetailRecord_CheckDateBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeBeginPositionDetail)
                            NumericInputDetailRecord_CheckDateEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeEndPositionDetail)
                            NumericInputDetailRecord_CheckDateCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeCSVOrderDetail)
                            NumericInputDetailRecord_CheckAmountBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountBeginPositionDetail)
                            NumericInputDetailRecord_CheckAmountEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountEndPositionDetail)
                            NumericInputDetailRecord_CheckAmountCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountCSVOrderDetail)
                            NumericInputDetailRecord_VoidFlagBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidBeginPositionDetail)
                            NumericInputDetailRecord_VoidFlagEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidEndPositionDetail)
                            NumericInputDetailRecord_VoidFlagCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidCSVOrderDetail)
                            NumericInputDetailRecord_PayeeBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckPayeeBeginPositionDetail)
                            NumericInputDetailRecord_PayeeEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckPayeeEndPositionDetail)
                            NumericInputDetailRecord_PayeeCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckPayeeCSVOrderDetail)
                            NumericInputDetailRecord_Filler1BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1BeginPositionDetail)
                            NumericInputDetailRecord_Filler1EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1EndPositionDetail)
                            TextBoxDetailRecord_Filler1FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1ValueDetail)
                            NumericInputDetailRecord_Filler2BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2BeginPositionDetail)
                            NumericInputDetailRecord_Filler2EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2EndPositionDetail)
                            TextBoxDetailRecord_Filler2FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2ValueDetail)
                            NumericInputDetailRecord_Filler3BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3BeginPositionDetail)
                            NumericInputDetailRecord_Filler3EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3EndPositionDetail)
                            NumericInputDetailRecord_Filler4BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4BeginPositionDetail)
                            NumericInputDetailRecord_Filler4EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4EndPositionDetail)

                            ' Check Export 2 Tab
                            NumericInputTotalRecord_BankIDBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDBeginPositionTotal)
                            NumericInputTotalRecord_BankIDEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDEndPositionTotal)
                            NumericInputTotalRecord_BankIDCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDCSVOrderTotal)
                            NumericInputTotalRecord_AccountNumberBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberBeginPositionTotal)
                            NumericInputTotalRecord_AccountNumberEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberEndPositionTotal)
                            NumericInputTotalRecord_AccountNumberCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberCSVOrderTotal)
                            NumericInputTotalRecord_FileDateBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeBeginPositionTotal)
                            NumericInputTotalRecord_FileDateEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeEndPositionTotal)
                            NumericInputTotalRecord_FileDateCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeCSVOrderTotal)
                            NumericInputTotalRecord_ExportAmountBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountBeginPositionTotal)
                            NumericInputTotalRecord_ExportAmountEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountEndPositionTotal)
                            NumericInputTotalRecord_ExportAmountCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountCSVOrderTotal)
                            NumericInputTotalRecord_TotalFlagBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidBeginPositionTotal)
                            NumericInputTotalRecord_TotalFlagEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidEndPositionTotal)
                            NumericInputTotalRecord_TotalFlagCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidCSVOrderTotal)
                            NumericInputTotalRecord_RecordCountBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountBeginPositionTotal)
                            NumericInputTotalRecord_RecordCountEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountEndPositionTotal)
                            NumericInputTotalRecord_RecordCountCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountCSVOrderTotal)
                            NumericInputTotalRecord_Filler1BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1BeginPositionTotal)
                            NumericInputTotalRecord_Filler1EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1EndPositionTotal)
                            TextBoxTotalRecord_Filler1FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1ValueTotal)
                            NumericInputTotalRecord_Filler2BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2BeginPositionTotal)
                            NumericInputTotalRecord_Filler2EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2EndPositionTotal)
                            TextBoxTotalRecord_Filler2FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2ValueTotal)
                            NumericInputTotalRecord_Filler3BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3BeginPositionTotal)
                            NumericInputTotalRecord_Filler3EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3EndPositionTotal)
                            NumericInputTotalRecord_Filler4BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4BeginPositionTotal)
                            NumericInputTotalRecord_Filler4EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4EndPositionTotal)
                            NumericInputTrailerRecord_BankIDBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDBeginPositionTrailer)
                            NumericInputTrailerRecord_BankIDEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDEndPositionTrailer)
                            NumericInputTrailerRecord_BankIDCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.BankIDCSVOrderTrailer)
                            NumericInputTrailerRecord_AccountNumberBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberBeginPositionTrailer)
                            NumericInputTrailerRecord_AccountNumberEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberEndPositionTrailer)
                            NumericInputTrailerRecord_AccountNumberCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.AccountNumberCSVOrderTrailer)
                            NumericInputTrailerRecord_FileDateBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeBeginPositionTrailer)
                            NumericInputTrailerRecord_FileDateEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeEndPositionTrailer)
                            NumericInputTrailerRecord_FileDateCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckDateTimeCSVOrderTrailer)
                            NumericInputTrailerRecord_ExportAmountBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountBeginPositionTrailer)
                            NumericInputTrailerRecord_ExportAmountEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountEndPositionTrailer)
                            NumericInputTrailerRecord_ExportAmountCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckAmountCSVOrderTrailer)
                            NumericInputTrailerRecord_TotalFlagBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidBeginPositionTrailer)
                            NumericInputTrailerRecord_TotalFlagEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidEndPositionTrailer)
                            NumericInputTrailerRecord_TotalFlagCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.CheckVoidCSVOrderTrailer)
                            NumericInputTrailerRecord_RecordCountBeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountBeginPositionTrailer)
                            NumericInputTrailerRecord_RecordCountEndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountEndPositionTrailer)
                            NumericInputTrailerRecord_RecordCountCSVOrder.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.RecordCountCSVOrderTrailer)
                            NumericInputTrailerRecord_Filler1BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1BeginPositionTrailer)
                            NumericInputTrailerRecord_Filler1EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1EndPositionTrailer)
                            TextBoxTrailerRecord_Filler1FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler1ValueTrailer)
                            NumericInputTrailerRecord_Filler2BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2BeginPositionTrailer)
                            NumericInputTrailerRecord_Filler2EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2EndPositionTrailer)
                            TextBoxTrailerRecord_Filler2FillValue.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler2ValueTrailer)
                            NumericInputTrailerRecord_Filler3BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3BeginPositionTrailer)
                            NumericInputTrailerRecord_Filler3EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler3EndPositionTrailer)
                            NumericInputTrailerRecord_Filler4BeginPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4BeginPositionTrailer)
                            NumericInputTrailerRecord_Filler4EndPosition.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.BankExportSpec.Properties.Filler4EndPositionTrailer)

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                TextBoxPaymentManager_FileOutputDirectory.SecurityEnabled = False

                            End If

                            'PJH 07/20/21 - Always disabled
                            TextBoxPaymentManager_FTPExportFolder.SecurityEnabled = False

                            '
                            ' Datasources
                            '
                            'Comment for now - Load by selected bank
                            LoadDropDownDataSources(False)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Bank

            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing

            Try

                If IsNew Then

                    _BankIsNew = True

                    Bank = New AdvantageFramework.Database.Entities.Bank

                    BankExportSpec = New AdvantageFramework.Database.Entities.BankExportSpec

                    LoadBankEntity(Bank, True)

                    LoadBankExportSpecEntity(BankExportSpec, True)

                    BankExportSpec.BankCode = Bank.Code

                    _BankExportSpec = BankExportSpec

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                        If Bank IsNot Nothing Then

                            LoadBankEntity(Bank, False)

                            BankExportSpec = AdvantageFramework.Database.Procedures.BankExportSpec.LoadByBankCode(DbContext, _BankCode)

                            If BankExportSpec Is Nothing Then

                                BankExportSpec = New AdvantageFramework.Database.Entities.BankExportSpec

                                LoadBankExportSpecEntity(BankExportSpec, True)

                                BankExportSpec.BankCode = Bank.Code

                            Else

                                LoadBankExportSpecEntity(BankExportSpec, False)

                            End If

                            _BankExportSpec = BankExportSpec

                        End If

                    End Using

                End If

            Catch ex As Exception
                Bank = Nothing
            End Try

            FillObject = Bank

        End Function
        Private Sub LoadBankEntity(ByVal Bank As AdvantageFramework.Database.Entities.Bank, ByVal IsNew As Boolean)

            If Bank IsNot Nothing Then

                If IsNew Then
                    _BankIsNew = True
                End If

                If IsNew OrElse TabItemBankDetails_Setup.Tag = True Then

                    SaveSetupTab(Bank)

                End If

                If IsNew OrElse TabItemBankDetails_Currency.Tag = True Then

                    SaveCurrencyTab(Bank)

                End If

                'If IsNew OrElse TabItemBankDetails_CheckImport.Tag = True Then

                '    SaveCheckImportTab(Bank)

                'End If

                If IsNew OrElse TabItemBankDetails_PaymentManager.Tag = True Then

                    SavePaymentManagerTab(Bank)

                End If

            End If

        End Sub
        Private Sub LoadBankExportSpecEntity(ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec, ByVal IsNew As Boolean)

            If BankExportSpec IsNot Nothing Then

                If IsNew OrElse TabItemBankDetails_Setup.Tag = True Then

                    SaveSetupTab(BankExportSpec)

                End If

                If IsNew OrElse TabItemBankDetails_CheckExport.Tag = True Then

                    SaveCheckExportTab(BankExportSpec)

                End If

                If IsNew OrElse TabItemBankDetails_CheckExport2.Tag = True Then

                    SaveCheckExport2Tab(BankExportSpec)

                End If

            End If

        End Sub
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing

            If _BankCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                    If Bank IsNot Nothing Then

                        BankExportSpec = AdvantageFramework.Database.Procedures.BankExportSpec.LoadByBankCode(DbContext, _BankCode)

                        If TabItem Is Nothing Then

                            For Each TabItem In TabControlControl_BankDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                                TabItem.Tag = False

                            Next

                            TabItem = TabControlControl_BankDetails.SelectedTab

                        End If

                        If TabItem.Tag = False Then

                            If TabItem Is TabItemBankDetails_CheckExport Then

                                LoadCheckExportTab(Bank, BankExportSpec)

                            End If

                            If TabItem Is TabItemBankDetails_CheckExport2 Then

                                LoadCheckExport2Tab(Bank, BankExportSpec)

                            End If

                            'If TabItem Is TabItemBankDetails_CheckImport Then

                            '    LoadCheckImportTab(Bank)

                            'End If

                            If TabItem Is TabItemBankDetails_Currency Then

                                LoadCurrencyTab(Bank)

                            End If

                            If TabItem Is TabItemBankDetails_PaymentManager Then

                                LoadPaymentManagerTab(Bank)

                            End If

                            If TabItem Is TabItemBankDetails_Setup Then

                                LoadSetupTab(Bank, BankExportSpec)

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'check writing in process
            SearchableComboBoxSetup_APComputerCheckFormat.Enabled = Not _CheckWritingInProgress
            ComboBoxSetup_CheckAmountInWords.Enabled = Not _CheckWritingInProgress
            LabelSetup_CheckWritingInProgress.Visible = _CheckWritingInProgress

            ' Check Export Tab
            NumericInputHeaderRecord_AgencyCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputHeaderRecord_CreateDateCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_BankIDCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_AccountNumberCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_CheckNumberCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_CheckDateCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_CheckAmountCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_VoidFlagCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputDetailRecord_PayeeCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked

            ' Check Export 2 Tab
            NumericInputTotalRecord_BankIDCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTotalRecord_AccountNumberCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTotalRecord_FileDateCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTotalRecord_ExportAmountCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTotalRecord_TotalFlagCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTotalRecord_RecordCountCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_BankIDCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_AccountNumberCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_FileDateCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_ExportAmountCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_TotalFlagCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked
            NumericInputTrailerRecord_RecordCountCSVOrder.Enabled = RadioButtonControlCheckExport_CSV.Checked

            ' Check Export Tab
            NumericInputHeaderRecord_AgencyBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_AgencyEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_CreateDateBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_CreateDateEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_Filler1BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_Filler1EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxHeaderRecord_Filler1FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_Filler2BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputHeaderRecord_Filler2EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxHeaderRecord_Filler2FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_BankIDBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_BankIDEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_AccountNumberBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_AccountNumberEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckNumberBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckNumberEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckDateBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckDateEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckAmountBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_CheckAmountEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_VoidFlagBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_VoidFlagEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_PayeeBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_PayeeEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler1BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler1EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxDetailRecord_Filler1FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler2BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler2EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxDetailRecord_Filler2FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler3BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler3EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxDetailRecord_Filler3FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler4BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputDetailRecord_Filler4EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxDetailRecord_Filler4FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked

            ' Check Export 2 Tab
            NumericInputTotalRecord_BankIDBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_BankIDEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_AccountNumberBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_AccountNumberEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_FileDateBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_FileDateEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_ExportAmountBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_ExportAmountEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_TotalFlagBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_TotalFlagEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_RecordCountBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_RecordCountEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler1BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler1EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTotalRecord_Filler1FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler2BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler2EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTotalRecord_Filler2FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler3BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler3EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler4BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTotalRecord_Filler4EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_BankIDBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_BankIDEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_AccountNumberBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_AccountNumberEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_FileDateBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_FileDateEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_ExportAmountBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_ExportAmountEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_TotalFlagBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_TotalFlagEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_RecordCountBeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_RecordCountEndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler1BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler1EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTrailerRecord_Filler1FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler2BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler2EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTrailerRecord_Filler2FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler3BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler3EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTrailerRecord_Filler3FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler4BeginPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            NumericInputTrailerRecord_Filler4EndPosition.Enabled = RadioButtonControlCheckExport_Fixed.Checked
            TextBoxTrailerRecord_Filler4FillValue.Enabled = RadioButtonControlCheckExport_Fixed.Checked

        End Sub
        Private Sub LoadSetupTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            If Bank IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If BankExportSpec IsNot Nothing Then

                        TextBoxSetup_BankID.Text = BankExportSpec.BankID

                    End If

                    CheckBoxSetup_Inactive.CheckValue = Bank.IsInactive.GetValueOrDefault(0)
                    CheckBoxSetup_PaymentManager.CheckValue = Bank.PaymentManager.GetValueOrDefault(0)

                    TextBoxSetup_Code.Text = Bank.Code
                    TextBoxSetup_Name.Text = Bank.Description

                    If TextBoxSetup_AccountNumber.UserEntryChanged = False Then

                        TextBoxSetup_AccountNumber.Text = Bank.AccountNumber

                    End If

                    NumericInputSetup_RoutingNumber.EditValue = Bank.RoutingNumber

                    TextBoxSetup_ACHCompanyID.Text = Bank.ACHCompanyID
                    NumericInputSetup_LastComputerCheckIssued.EditValue = Bank.LastComputerCheck
                    NumericInputSetup_LastManualCheckIssued.EditValue = Bank.LastManualCheck
                    NumericInputSetup_CheckTemplateID.EditValue = Bank.CheckTemplateID

                    If Bank.OfficeCode IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_Office.SelectedValue = Bank.OfficeCode

                        Catch ex As Exception
                            SearchableComboBoxSetup_Office.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_Office.HasASelectedValue = False Then

                            Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Bank.OfficeCode)

                            If Office IsNot Nothing Then

                                SearchableComboBoxSetup_Office.AddComboItemToExistingDataSource(Office.ToString & "*", Office.Code, False)

                                Try

                                    SearchableComboBoxSetup_Office.SelectedValue = Bank.OfficeCode

                                Catch ex As Exception
                                    SearchableComboBoxSetup_Office.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_Office.SelectedValue = 0

                    End If

                    If Bank.APCashAccount IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_APCashAccount.SelectedValue = Bank.APCashAccount

                        Catch ex As Exception
                            SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_APCashAccount.HasASelectedValue = False Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.APCashAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                SearchableComboBoxSetup_APCashAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                Try

                                    SearchableComboBoxSetup_APCashAccount.SelectedValue = Bank.APCashAccount

                                Catch ex As Exception
                                    SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing

                    End If

                    If Bank.APDiscAccount IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_APDiscAccount.SelectedValue = Bank.APDiscAccount

                        Catch ex As Exception
                            SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_APDiscAccount.HasASelectedValue = False Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.APDiscAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                SearchableComboBoxSetup_APDiscAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                Try

                                    SearchableComboBoxSetup_APDiscAccount.SelectedValue = Bank.APDiscAccount

                                Catch ex As Exception
                                    SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing

                    End If

                    If Bank.ARCashAccount IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_ARCashAccount.SelectedValue = Bank.ARCashAccount

                        Catch ex As Exception
                            SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_ARCashAccount.HasASelectedValue = False Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.ARCashAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                SearchableComboBoxSetup_ARCashAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                Try

                                    SearchableComboBoxSetup_ARCashAccount.SelectedValue = Bank.ARCashAccount

                                Catch ex As Exception
                                    SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing

                    End If

                    If Bank.InterestEarnedGLAccount IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Bank.InterestEarnedGLAccount

                        Catch ex As Exception
                            SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_InterestEarnedGLAccount.HasASelectedValue = False Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.InterestEarnedGLAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                SearchableComboBoxSetup_InterestEarnedGLAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                Try

                                    SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Bank.InterestEarnedGLAccount

                                Catch ex As Exception
                                    SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing

                    End If

                    If Bank.ServiceChargeGLAccount IsNot Nothing Then

                        Try

                            SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Bank.ServiceChargeGLAccount

                        Catch ex As Exception
                            SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing
                        End Try

                        If SearchableComboBoxSetup_ServiceChargeGLAccount.HasASelectedValue = False Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.ServiceChargeGLAccount)

                            If GeneralLedgerAccount IsNot Nothing Then

                                SearchableComboBoxSetup_ServiceChargeGLAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                Try

                                    SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Bank.ServiceChargeGLAccount

                                Catch ex As Exception
                                    SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing
                                End Try

                            End If

                        End If

                    Else

                        SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing

                    End If


                    Try

                        SearchableComboBoxSetup_APComputerCheckFormat.SelectedValue = Bank.CheckFormat

                    Catch ex As Exception
                        SearchableComboBoxSetup_APComputerCheckFormat.SelectedValue = Nothing
                    End Try

                    Try

                        ComboBoxSetup_CheckAmountInWords.SelectedValue = Bank.CheckAmountInWords.ToString

                    Catch ex As Exception
                        ComboBoxSetup_CheckAmountInWords.SelectedIndex = 0
                    End Try

                    ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.SelectedValue = Bank.CheckBodyLinesDown.GetValueOrDefault(-1).ToString

                    ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.SelectedValue = Bank.CheckStubLinesUp.GetValueOrDefault(-1).ToString

                    CheckBoxSetup_DigitalSignatureActive.Checked = Bank.DigitalSignatureActive
                    TextBoxSetup_DigitalSignatureText.Text = Bank.DigitalSignatureText
                    ComboBoxSetup_DigitalSignatureFont.SelectedValue = Bank.DigitalSignatureFont

                    If Bank.DigitalSignatureFontSize.HasValue = False Then

                        ComboBoxSetup_DigitalSignatureFontSize.SelectedValue = Nothing

                    Else

                        ComboBoxSetup_DigitalSignatureFontSize.SelectedValue = CShort(Bank.DigitalSignatureFontSize.Value)

                    End If

                End Using

                TabItemBankDetails_Setup.Tag = True

            End If

        End Sub
        Private Sub LoadCurrencyTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

            Dim CurrencyCode As AdvantageFramework.Database.Entities.CurrencyCode = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            If TabItemBankDetails_Currency.Tag = False Then

                If Bank IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Bank.CurrencyCode IsNot Nothing Then

                            Try

                                SearchableComboBoxCurrency_Currency.SelectedValue = Bank.CurrencyCode

                            Catch ex As Exception
                                SearchableComboBoxCurrency_Currency.SelectedValue = Nothing
                            End Try

                            'If SearchableComboBoxCurrency_Currency.HasASelectedValue = False Then

                            'CurrencyCode = AdvantageFramework.Database.Procedures.CurrencyCode.LoadByCode(DbContext, Bank.CurrencyCode)

                            '    If CurrencyCode IsNot Nothing Then

                            '        SearchableComboBoxCurrency_Currency.AddComboItemToExistingDataSource(CurrencyCode.ToString & "*", CurrencyCode.Code, False)

                            '        Try

                            '            SearchableComboBoxCurrency_Currency.SelectedValue = Bank.CurrencyCode

                            '        Catch ex As Exception
                            '            SearchableComboBoxCurrency_Currency.SelectedValue = Nothing
                            '        End Try

                            '    End If

                            'End If

                        Else

                            SearchableComboBoxCurrency_Currency.SelectedValue = _AgencyCurrencyCode

                        End If

                        '_CurrencyCodeOrig = SearchableComboBoxCurrency_Currency.SelectedValue

                        If Bank.CurrencyExchangeUnrealizedGLAccount IsNot Nothing Then

                            Try

                                SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Bank.CurrencyExchangeUnrealizedGLAccount

                            Catch ex As Exception
                                SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Nothing
                            End Try

                            If SearchableComboBoxCurrency_ExchangeUnrealizedAccount.HasASelectedValue = False Then

                                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.CurrencyExchangeUnrealizedGLAccount)

                                If CurrencyCode IsNot Nothing Then

                                    SearchableComboBoxCurrency_ExchangeUnrealizedAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                    Try

                                        SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Bank.CurrencyExchangeUnrealizedGLAccount

                                    Catch ex As Exception
                                        SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Nothing
                                    End Try

                                End If

                            End If

                        Else

                            SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Nothing

                        End If

                        If Bank.ExchangeConversionAccount IsNot Nothing Then

                            Try

                                SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Bank.ExchangeConversionAccount

                            Catch ex As Exception
                                SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Nothing
                            End Try

                            If SearchableComboBoxCurrency_ExchangeRealizedAccount.HasASelectedValue = False Then

                                GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Bank.ExchangeConversionAccount)

                                If CurrencyCode IsNot Nothing Then

                                    SearchableComboBoxCurrency_ExchangeRealizedAccount.AddComboItemToExistingDataSource(GeneralLedgerAccount.ToString & "*", GeneralLedgerAccount.Code, False)

                                    Try

                                        SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Bank.ExchangeConversionAccount

                                    Catch ex As Exception
                                        SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Nothing
                                    End Try

                                End If

                            End If

                        Else

                            SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Nothing

                        End If

                    End Using

                    TabItemBankDetails_Currency.Tag = True

                    _CurrencyCode = SearchableComboBoxCurrency_Currency.SelectedValue

                End If

            End If

        End Sub
        'Private Sub LoadCheckImportTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

        '    If Bank IsNot Nothing Then

        '        TextBoxCheckImport_ImportFileName.Text = Bank.ImportFileName

        '        If Bank.CheckNumberColumnStart IsNot Nothing Then
        '            NumericInputLeftColumn_ColumnStart.EditValue = CInt(Bank.CheckNumberColumnStart)
        '        End If

        '        If Bank.CheckNumberLength IsNot Nothing Then
        '            NumericInputLeftColumn_Length.EditValue = CInt(Bank.CheckNumberLength)
        '        End If

        '        If Bank.CheckAmountColumnStart IsNot Nothing Then
        '            NumericInputRightColumn_ColumnStart.EditValue = CInt(Bank.CheckAmountColumnStart)
        '        End If

        '        If Bank.CheckAmountLength IsNot Nothing Then
        '            NumericInputRightColumn_Length.EditValue = CInt(Bank.CheckAmountLength)
        '        End If

        '        If Bank.CheckAmountNumberOfDecimals IsNot Nothing Then
        '            NumericInputRightColumn_NumberOfDecimals.EditValue = CInt(Bank.CheckAmountNumberOfDecimals)
        '        End If

        '        TabItemBankDetails_CheckImport.Tag = True

        '    End If

        'End Sub
        Private Sub LoadCheckExportTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            If Bank IsNot Nothing Then

                If BankExportSpec IsNot Nothing Then

                    If BankExportSpec.ExportType = AdvantageFramework.Database.Entities.ImportFileTypes.Fixed.ToString.ToUpper Then

                        RadioButtonControlCheckExport_Fixed.Checked = True

                    ElseIf BankExportSpec.ExportType = AdvantageFramework.Database.Entities.ImportFileTypes.Delimited.ToString.ToUpper Then

                        RadioButtonControlCheckExport_CSV.Checked = True

                    Else

                        RadioButtonControlCheckExport_Fixed.Checked = True

                    End If

                    CheckBoxCheckExport_UseHeaderRecord.Checked = Convert.ToBoolean(BankExportSpec.UseHeader.GetValueOrDefault(0))

                    ' Header Record
                    CheckBoxHeaderRecord_ExportAgency.Checked = Convert.ToBoolean(BankExportSpec.AgencyFlagHeader.GetValueOrDefault(0))

                    If BankExportSpec.AgencyBeginPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_AgencyBeginPosition.EditValue = CInt(BankExportSpec.AgencyBeginPositionHeader)
                    End If

                    If BankExportSpec.AgencyEndPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_AgencyEndPosition.EditValue = CInt(BankExportSpec.AgencyEndPositionHeader)
                    End If

                    If BankExportSpec.AgencyCSVOrderHeader IsNot Nothing Then
                        NumericInputHeaderRecord_AgencyCSVOrder.EditValue = CInt(BankExportSpec.AgencyCSVOrderHeader)
                    End If

                    CheckBoxHeaderRecord_CreateDateExport.Checked = Convert.ToBoolean(BankExportSpec.CreateDateFlagHeader.GetValueOrDefault(0))

                    If BankExportSpec.CreateDateBeginPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_CreateDateBeginPosition.EditValue = CInt(BankExportSpec.CreateDateBeginPositionHeader)
                    End If

                    If BankExportSpec.CreateDateEndPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_CreateDateEndPosition.EditValue = CInt(BankExportSpec.CreateDateEndPositionHeader)
                    End If

                    If BankExportSpec.CreateDateCSVOrderHeader IsNot Nothing Then
                        NumericInputHeaderRecord_CreateDateCSVOrder.EditValue = CInt(BankExportSpec.CreateDateCSVOrderHeader)
                    End If

                    CheckBoxHeaderRecord_Filler1Export.Checked = Convert.ToBoolean(BankExportSpec.Filler1FlagHeader.GetValueOrDefault(0))

                    If BankExportSpec.Filler1BeginPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_Filler1BeginPosition.EditValue = CInt(BankExportSpec.Filler1BeginPositionHeader)
                    End If

                    If BankExportSpec.Filler1EndPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_Filler1EndPosition.EditValue = CInt(BankExportSpec.Filler1EndPositionHeader)
                    End If

                    TextBoxHeaderRecord_Filler1FillValue.Text = BankExportSpec.Filler1ValueHeader

                    CheckBoxHeaderRecord_Filler2Export.Checked = Convert.ToBoolean(BankExportSpec.Filler2FlagHeader.GetValueOrDefault(0))

                    If BankExportSpec.Filler2BeginPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_Filler2BeginPosition.EditValue = CInt(BankExportSpec.Filler2BeginPositionHeader)
                    End If

                    If BankExportSpec.Filler2EndPositionHeader IsNot Nothing Then
                        NumericInputHeaderRecord_Filler2EndPosition.EditValue = CInt(BankExportSpec.Filler2EndPositionHeader)
                    End If

                    TextBoxHeaderRecord_Filler2FillValue.Text = BankExportSpec.Filler2ValueHeader

                    ' Detail Record
                    CheckBoxDetailRecord_BankIDExport.Checked = Convert.ToBoolean(BankExportSpec.BankIDFlag.GetValueOrDefault(0))

                    If BankExportSpec.BankIDBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_BankIDBeginPosition.EditValue = CInt(BankExportSpec.BankIDBeginPositionDetail)
                    End If

                    If BankExportSpec.BankIDEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_BankIDEndPosition.EditValue = CInt(BankExportSpec.BankIDEndPositionDetail)
                    End If

                    If BankExportSpec.BankIDCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_BankIDCSVOrder.EditValue = CInt(BankExportSpec.BankIDCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_AccountNumberExport.Checked = Convert.ToBoolean(BankExportSpec.AccountNumberFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.AccountNumberBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_AccountNumberBeginPosition.EditValue = CInt(BankExportSpec.AccountNumberBeginPositionDetail)
                    End If

                    If BankExportSpec.AccountNumberEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_AccountNumberEndPosition.EditValue = CInt(BankExportSpec.AccountNumberEndPositionDetail)
                    End If

                    If BankExportSpec.AccountNumberCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_AccountNumberCSVOrder.EditValue = CInt(BankExportSpec.AccountNumberCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_CheckNumberExport.Checked = Convert.ToBoolean(BankExportSpec.CheckNumberFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.CheckNumberBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckNumberBeginPosition.EditValue = CInt(BankExportSpec.CheckNumberBeginPositionDetail)
                    End If

                    If BankExportSpec.CheckNumberEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckNumberEndPosition.EditValue = CInt(BankExportSpec.CheckNumberEndPositionDetail)
                    End If

                    If BankExportSpec.CheckNumberCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckNumberCSVOrder.EditValue = CInt(BankExportSpec.CheckNumberCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_CheckDateExport.Checked = Convert.ToBoolean(BankExportSpec.CheckDateTimeFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.CheckDateTimeBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckDateBeginPosition.EditValue = CInt(BankExportSpec.CheckDateTimeBeginPositionDetail)
                    End If

                    If BankExportSpec.CheckDateTimeEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckDateEndPosition.EditValue = CInt(BankExportSpec.CheckDateTimeEndPositionDetail)
                    End If

                    If BankExportSpec.CheckDateTimeCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckDateCSVOrder.EditValue = CInt(BankExportSpec.CheckDateTimeCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_CheckAmountExport.Checked = Convert.ToBoolean(BankExportSpec.CheckAmountFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.CheckAmountBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckAmountBeginPosition.EditValue = CInt(BankExportSpec.CheckAmountBeginPositionDetail)
                    End If

                    If BankExportSpec.CheckAmountEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckAmountEndPosition.EditValue = CInt(BankExportSpec.CheckAmountEndPositionDetail)
                    End If

                    If BankExportSpec.CheckAmountCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_CheckAmountCSVOrder.EditValue = CInt(BankExportSpec.CheckAmountCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_VoidFlagExport.Checked = Convert.ToBoolean(BankExportSpec.CheckVoidFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.CheckVoidBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_VoidFlagBeginPosition.EditValue = CInt(BankExportSpec.CheckVoidBeginPositionDetail)
                    End If

                    If BankExportSpec.CheckVoidEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_VoidFlagEndPosition.EditValue = CInt(BankExportSpec.CheckVoidEndPositionDetail)
                    End If

                    If BankExportSpec.CheckVoidCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_VoidFlagCSVOrder.EditValue = CInt(BankExportSpec.CheckVoidCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_PayeeExport.Checked = Convert.ToBoolean(BankExportSpec.CheckPayeeFlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.CheckPayeeBeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_PayeeBeginPosition.EditValue = CInt(BankExportSpec.CheckPayeeBeginPositionDetail)
                    End If

                    If BankExportSpec.CheckPayeeEndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_PayeeEndPosition.EditValue = CInt(BankExportSpec.CheckPayeeEndPositionDetail)
                    End If

                    If BankExportSpec.CheckPayeeCSVOrderDetail IsNot Nothing Then
                        NumericInputDetailRecord_PayeeCSVOrder.EditValue = CInt(BankExportSpec.CheckPayeeCSVOrderDetail)
                    End If

                    CheckBoxDetailRecord_Filler1Export.Checked = Convert.ToBoolean(BankExportSpec.Filler1FlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.Filler1BeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler1BeginPosition.EditValue = CInt(BankExportSpec.Filler1BeginPositionDetail)
                    End If

                    If BankExportSpec.Filler1EndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler1EndPosition.EditValue = CInt(BankExportSpec.Filler1EndPositionDetail)
                    End If

                    TextBoxDetailRecord_Filler1FillValue.Text = BankExportSpec.Filler1ValueDetail

                    CheckBoxDetailRecord_Filler2Export.Checked = Convert.ToBoolean(BankExportSpec.Filler2FlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.Filler2BeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler2BeginPosition.EditValue = CInt(BankExportSpec.Filler2BeginPositionDetail)
                    End If

                    If BankExportSpec.Filler2EndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler2EndPosition.EditValue = CInt(BankExportSpec.Filler2EndPositionDetail)
                    End If

                    TextBoxDetailRecord_Filler2FillValue.Text = BankExportSpec.Filler2ValueDetail

                    CheckBoxDetailRecord_Filler3Export.Checked = Convert.ToBoolean(BankExportSpec.Filler3FlagDetail.GetValueOrDefault(0))
                    If BankExportSpec.Filler3BeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler3BeginPosition.EditValue = CInt(BankExportSpec.Filler3BeginPositionDetail)
                    End If

                    If BankExportSpec.Filler3EndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler3EndPosition.EditValue = CInt(BankExportSpec.Filler3EndPositionDetail)
                    End If

                    CheckBoxDetailRecord_Filler4Export.Checked = Convert.ToBoolean(BankExportSpec.Filler4FlagDetail.GetValueOrDefault(0))

                    If BankExportSpec.Filler4BeginPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler4BeginPosition.EditValue = CInt(BankExportSpec.Filler4BeginPositionDetail)
                    End If

                    If BankExportSpec.Filler4EndPositionDetail IsNot Nothing Then
                        NumericInputDetailRecord_Filler4EndPosition.EditValue = CInt(BankExportSpec.Filler4EndPositionDetail)
                    End If

                    TabItemBankDetails_CheckExport.Tag = True

                End If

            End If

        End Sub
        Private Sub LoadCheckExport2Tab(ByVal Bank As AdvantageFramework.Database.Entities.Bank, ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            If Bank IsNot Nothing Then

                If BankExportSpec IsNot Nothing Then

                    CheckBoxTotalRecord_BankIDExport.Checked = Convert.ToBoolean(BankExportSpec.BankIDFlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.BankIDBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_BankIDBeginPosition.EditValue = CInt(BankExportSpec.BankIDBeginPositionTotal)
                    End If

                    If BankExportSpec.BankIDEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_BankIDEndPosition.EditValue = CInt(BankExportSpec.BankIDEndPositionTotal)
                    End If

                    If BankExportSpec.BankIDCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_BankIDCSVOrder.EditValue = CInt(BankExportSpec.BankIDCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_AccountNumberExport.Checked = Convert.ToBoolean(BankExportSpec.AccountNumberFlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.AccountNumberBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_AccountNumberBeginPosition.EditValue = CInt(BankExportSpec.AccountNumberBeginPositionTotal)
                    End If

                    If BankExportSpec.AccountNumberEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_AccountNumberEndPosition.EditValue = CInt(BankExportSpec.AccountNumberEndPositionTotal)
                    End If

                    If BankExportSpec.AccountNumberCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_AccountNumberCSVOrder.EditValue = CInt(BankExportSpec.AccountNumberCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_FileDateExport.Checked = Convert.ToBoolean(BankExportSpec.CheckDateTimeFlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.CheckDateTimeBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_FileDateBeginPosition.EditValue = CInt(BankExportSpec.CheckDateTimeBeginPositionTotal)
                    End If

                    If BankExportSpec.CheckDateTimeEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_FileDateEndPosition.EditValue = CInt(BankExportSpec.CheckDateTimeEndPositionTotal)
                    End If

                    If BankExportSpec.CheckDateTimeCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_FileDateCSVOrder.EditValue = CInt(BankExportSpec.CheckDateTimeCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_ExportAmountExport.Checked = Convert.ToBoolean(BankExportSpec.CheckAmountFlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.CheckAmountBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_ExportAmountBeginPosition.EditValue = CInt(BankExportSpec.CheckAmountBeginPositionTotal)
                    End If

                    If BankExportSpec.CheckAmountEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_ExportAmountEndPosition.EditValue = CInt(BankExportSpec.CheckAmountEndPositionTotal)
                    End If

                    If BankExportSpec.CheckAmountCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_ExportAmountCSVOrder.EditValue = CInt(BankExportSpec.CheckAmountCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_TotalFlagExport.Checked = Convert.ToBoolean(BankExportSpec.CheckVoidFlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.CheckVoidBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_TotalFlagBeginPosition.EditValue = CInt(BankExportSpec.CheckVoidBeginPositionTotal)
                    End If

                    If BankExportSpec.CheckVoidEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_TotalFlagEndPosition.EditValue = CInt(BankExportSpec.CheckVoidEndPositionTotal)
                    End If

                    If BankExportSpec.CheckVoidCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_TotalFlagCSVOrder.EditValue = CInt(BankExportSpec.CheckVoidCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_RecordCountExport.Checked = Convert.ToBoolean(BankExportSpec.RecordCountFlagTotal.GetValueOrDefault(0))
                    If BankExportSpec.RecordCountBeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_RecordCountBeginPosition.EditValue = CInt(BankExportSpec.RecordCountBeginPositionTotal)
                    End If

                    If BankExportSpec.RecordCountEndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_RecordCountEndPosition.EditValue = CInt(BankExportSpec.RecordCountEndPositionTotal)
                    End If

                    If BankExportSpec.RecordCountCSVOrderTotal IsNot Nothing Then
                        NumericInputTotalRecord_RecordCountCSVOrder.EditValue = CInt(BankExportSpec.RecordCountCSVOrderTotal)
                    End If

                    CheckBoxTotalRecord_Filler1Export.Checked = Convert.ToBoolean(BankExportSpec.Filler1FlagTotal.GetValueOrDefault(0))
                    If BankExportSpec.Filler1BeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler1BeginPosition.EditValue = CInt(BankExportSpec.Filler1BeginPositionTotal)
                    End If

                    If BankExportSpec.Filler1EndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler1EndPosition.EditValue = CInt(BankExportSpec.Filler1EndPositionTotal)
                    End If

                    If BankExportSpec.Filler1ValueTotal IsNot Nothing Then
                        TextBoxTotalRecord_Filler1FillValue.Text = BankExportSpec.Filler1ValueTotal
                    End If

                    CheckBoxTotalRecord_Filler2Export.Checked = Convert.ToBoolean(BankExportSpec.Filler2FlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.Filler2BeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler2BeginPosition.EditValue = CInt(BankExportSpec.Filler2BeginPositionTotal)
                    End If

                    If BankExportSpec.Filler2EndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler2EndPosition.EditValue = CInt(BankExportSpec.Filler2EndPositionTotal)
                    End If

                    TextBoxTotalRecord_Filler2FillValue.Text = BankExportSpec.Filler2ValueTotal

                    CheckBoxTotalRecord_Filler3Export.Checked = Convert.ToBoolean(BankExportSpec.Filler3FlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.Filler3BeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler3BeginPosition.EditValue = CInt(BankExportSpec.Filler3BeginPositionTotal)
                    End If

                    If BankExportSpec.Filler3EndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler3EndPosition.EditValue = CInt(BankExportSpec.Filler3EndPositionTotal)
                    End If

                    CheckBoxTotalRecord_Filler4Export.Checked = Convert.ToBoolean(BankExportSpec.Filler4FlagTotal.GetValueOrDefault(0))

                    If BankExportSpec.Filler4BeginPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler4BeginPosition.EditValue = CInt(BankExportSpec.Filler4BeginPositionTotal)
                    End If

                    If BankExportSpec.Filler4EndPositionTotal IsNot Nothing Then
                        NumericInputTotalRecord_Filler4EndPosition.EditValue = CInt(BankExportSpec.Filler4EndPositionTotal)
                    End If

                    ' Trailer Record
                    CheckBoxTrailerRecord_BankIDExport.Checked = Convert.ToBoolean(BankExportSpec.BankIDFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.BankIDBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_BankIDBeginPosition.EditValue = CInt(BankExportSpec.BankIDBeginPositionTrailer)
                    End If

                    If BankExportSpec.BankIDEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_BankIDEndPosition.EditValue = CInt(BankExportSpec.BankIDEndPositionTrailer)
                    End If

                    If BankExportSpec.BankIDCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_BankIDCSVOrder.EditValue = CInt(BankExportSpec.BankIDCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_AccountNumberExport.Checked = Convert.ToBoolean(BankExportSpec.AccountNumberFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.AccountNumberBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_AccountNumberBeginPosition.EditValue = CInt(BankExportSpec.AccountNumberBeginPositionTrailer)
                    End If

                    If BankExportSpec.AccountNumberEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_AccountNumberEndPosition.EditValue = CInt(BankExportSpec.AccountNumberEndPositionTrailer)
                    End If

                    If BankExportSpec.AccountNumberCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_AccountNumberCSVOrder.EditValue = CInt(BankExportSpec.AccountNumberCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_FileDateExport.Checked = Convert.ToBoolean(BankExportSpec.CheckDateTimeFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.CheckDateTimeBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_FileDateBeginPosition.EditValue = CInt(BankExportSpec.CheckDateTimeBeginPositionTrailer)
                    End If

                    If BankExportSpec.CheckDateTimeEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_FileDateEndPosition.EditValue = CInt(BankExportSpec.CheckDateTimeEndPositionTrailer)
                    End If

                    If BankExportSpec.CheckDateTimeCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_FileDateCSVOrder.EditValue = CInt(BankExportSpec.CheckDateTimeCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_ExportAmountExport.Checked = Convert.ToBoolean(BankExportSpec.CheckAmountFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.CheckAmountBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_ExportAmountBeginPosition.EditValue = CInt(BankExportSpec.CheckAmountBeginPositionTrailer)
                    End If

                    If BankExportSpec.CheckAmountEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_ExportAmountEndPosition.EditValue = CInt(BankExportSpec.CheckAmountEndPositionTrailer)
                    End If

                    If BankExportSpec.CheckAmountCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_ExportAmountCSVOrder.EditValue = CInt(BankExportSpec.CheckAmountCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_TotalFlagExport.Checked = Convert.ToBoolean(BankExportSpec.CheckVoidFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.CheckVoidBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_TotalFlagBeginPosition.EditValue = CInt(BankExportSpec.CheckVoidBeginPositionTrailer)
                    End If

                    If BankExportSpec.CheckVoidEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_TotalFlagEndPosition.EditValue = CInt(BankExportSpec.CheckVoidEndPositionTrailer)
                    End If

                    If BankExportSpec.CheckVoidCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_TotalFlagCSVOrder.EditValue = CInt(BankExportSpec.CheckVoidCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_RecordCountExport.Checked = Convert.ToBoolean(BankExportSpec.RecordCountFlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.RecordCountBeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_RecordCountBeginPosition.EditValue = CInt(BankExportSpec.RecordCountBeginPositionTrailer)
                    End If

                    If BankExportSpec.RecordCountEndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_RecordCountEndPosition.EditValue = CInt(BankExportSpec.RecordCountEndPositionTrailer)
                    End If

                    If BankExportSpec.RecordCountCSVOrderTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_RecordCountCSVOrder.EditValue = CInt(BankExportSpec.RecordCountCSVOrderTrailer)
                    End If

                    CheckBoxTrailerRecord_Filler1Export.Checked = Convert.ToBoolean(BankExportSpec.Filler1FlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.Filler1BeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler1BeginPosition.EditValue = CInt(BankExportSpec.Filler1BeginPositionTrailer)
                    End If

                    If BankExportSpec.Filler1EndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler1EndPosition.EditValue = CInt(BankExportSpec.Filler1EndPositionTrailer)
                    End If

                    TextBoxTrailerRecord_Filler1FillValue.Text = BankExportSpec.Filler1ValueTrailer

                    CheckBoxTrailerRecord_Filler2Export.Checked = Convert.ToBoolean(BankExportSpec.Filler2FlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.Filler2BeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler2BeginPosition.EditValue = CInt(BankExportSpec.Filler2BeginPositionTrailer)
                    End If

                    If BankExportSpec.Filler2EndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler2EndPosition.EditValue = CInt(BankExportSpec.Filler2EndPositionTrailer)
                    End If

                    TextBoxTrailerRecord_Filler2FillValue.Text = BankExportSpec.Filler2ValueTrailer

                    CheckBoxTrailerRecord_Filler3Export.Checked = Convert.ToBoolean(BankExportSpec.Filler3FlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.Filler3BeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler3BeginPosition.EditValue = CInt(BankExportSpec.Filler3BeginPositionTrailer)
                    End If

                    If BankExportSpec.Filler3EndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler3EndPosition.EditValue = CInt(BankExportSpec.Filler3EndPositionTrailer)
                    End If

                    CheckBoxTrailerRecord_Filler4Export.Checked = Convert.ToBoolean(BankExportSpec.Filler4FlagTrailer.GetValueOrDefault(0))

                    If BankExportSpec.Filler4BeginPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler4BeginPosition.EditValue = CInt(BankExportSpec.Filler4BeginPositionTrailer)
                    End If

                    If BankExportSpec.Filler4EndPositionTrailer IsNot Nothing Then
                        NumericInputTrailerRecord_Filler4EndPosition.EditValue = CInt(BankExportSpec.Filler4EndPositionTrailer)
                    End If

                    TabItemBankDetails_CheckExport2.Tag = True

                End If

            End If

        End Sub
        Private Sub LoadPaymentManagerTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

            If Bank IsNot Nothing Then

                If TextBoxPaymentManager_AccountNumber.UserEntryChanged = False Then

                    TextBoxPaymentManager_AccountNumber.Text = Bank.AccountNumber

                End If

                If Bank.PaymentManagerType IsNot Nothing Then

                    Try

                        SearchableComboBoxPaymentManager_ExportType.SelectedValue = Bank.PaymentManagerType

                    Catch ex As Exception
                        SearchableComboBoxPaymentManager_ExportType.SelectedValue = Nothing
                    End Try

                End If

                TextBoxPaymentManager_CustomerID.Text = Bank.PaymentManagerID
                TextBoxPaymentManager_Word.Text = Bank.PaymentManagerWord
                TextBoxPaymentManager_FTPClient.Text = Bank.PaymentManagerFTP
                TextBoxPaymentManager_FileOutputDirectory.Text = Bank.PaymentManagerDirectory

                TextBoxPaymentManager_CSIUserName.Text = Bank.CSIUserName
                TextBoxPaymentManager_CSIPassword.Text = Bank.CSIPassword
                TextBoxPaymentManager_CSITargetFolder.Text = Bank.CSITargetFolder
                TextBoxPaymentManager_ComDataAccountCode.Text = Bank.ComDataAccountCode
                TextBoxPaymentManager_ComDataPassword.Text = Bank.ComDataPassword

                TextBoxPaymentManager_DestinationName.Text = Bank.PaymentManagerACHDestinationName
                TextBoxPaymentManager_CompanyEntryDescription.Text = Bank.PaymentManagerACHCompanyEntryDescription
                ComboBoxPaymentManager_ServiceClassCode.SelectedValue = Bank.PaymentManagerACHServiceClassCode
                ComboBoxPaymentManager_StandardEntryClassCode.SelectedValue = Bank.PaymentManagerACHStandardEntryClassCode
                TextBoxPaymentManager_CompanyName.Text = Bank.PaymentManagerACHCompanyName

                TextBoxPaymentManager_FTPAddress.Text = Bank.PaymentManagerFTPAddress
                TextBoxPaymentManager_FTPFolder.Text = Bank.PaymentManagerFTPFolder
                TextBoxPaymentManager_FTPUserName.Text = Bank.PaymentManagerFTPUsername
                TextBoxPaymentManager_FTPPassword.Text = Bank.PaymentManagerFTPPassword

                If Bank.PaymentManagerFTPPort IsNot Nothing Then
                    TextBoxPaymentManager_FTPPort.Text = Bank.PaymentManagerFTPPort
                Else
                    TextBoxPaymentManager_FTPPort.Text = Nothing
                End If

                TextBoxPaymentManager_FTPExportFolder.Text = Bank.PaymentManagerFTPExportFolder

                CheckBoxPaymentManager_UseSSL.Checked = Bank.PaymentManagerFTPSSL

                ComboBoxPaymentManager_FTPSecure.SelectedValue = CStr(Bank.PaymentManagerFTPSSLMode)

                ButtonPaymentManager_FTPPrivateKeySelect.Tag = Bank.PaymentManagerFTPPrivateKey

                EnableDisableFTPPrivateKey()

            End If

            TabItemBankDetails_PaymentManager.Tag = True

        End Sub
        Private Sub EnableDisablePaymentManagerACHSettings(ByVal Enable As Boolean)

            TextBoxPaymentManager_DestinationName.Enabled = Enable
            TextBoxPaymentManager_CompanyName.Enabled = Enable
            TextBoxPaymentManager_CompanyEntryDescription.Enabled = Enable
            ComboBoxPaymentManager_ServiceClassCode.Enabled = Enable
            ComboBoxPaymentManager_StandardEntryClassCode.Enabled = Enable

        End Sub
        Private Sub EnableDisableFTPPrivateKey()

            ButtonPaymentManager_FTPPrivateKeyDelete.Enabled = (ButtonPaymentManager_FTPPrivateKeySelect.Tag IsNot Nothing)
            ButtonPaymentManager_FTPPrivateKeySelect.Enabled = (ButtonPaymentManager_FTPPrivateKeySelect.Tag Is Nothing)

        End Sub
        Private Sub SaveSetupTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

            If Bank IsNot Nothing Then

                Bank.IsInactive = CShort(If(CheckBoxSetup_Inactive.Checked, CheckBoxSetup_Inactive.CheckValueChecked, CheckBoxSetup_Inactive.CheckValueUnchecked))
                Bank.PaymentManager = CShort(CheckBoxSetup_PaymentManager.CheckValue)
                Bank.Code = TextBoxSetup_Code.Text
                Bank.Description = TextBoxSetup_Name.Text
                Bank.AccountNumber = TextBoxSetup_AccountNumber.Text
                Bank.RoutingNumber = NumericInputSetup_RoutingNumber.GetValue
                Bank.ACHCompanyID = TextBoxSetup_ACHCompanyID.Text
                Bank.LastComputerCheck = NumericInputSetup_LastComputerCheckIssued.GetValue
                Bank.LastManualCheck = NumericInputSetup_LastManualCheckIssued.GetValue
                Bank.CheckTemplateID = NumericInputSetup_CheckTemplateID.GetValue
                Bank.CheckAmountInWords = ComboBoxSetup_CheckAmountInWords.GetSelectedValue
                Bank.APCashAccount = SearchableComboBoxSetup_APCashAccount.GetSelectedValue
                Bank.CheckFormat = SearchableComboBoxSetup_APComputerCheckFormat.GetSelectedValue
                Bank.APDiscAccount = SearchableComboBoxSetup_APDiscAccount.GetSelectedValue
                Bank.ARCashAccount = SearchableComboBoxSetup_ARCashAccount.GetSelectedValue
                Bank.InterestEarnedGLAccount = SearchableComboBoxSetup_InterestEarnedGLAccount.GetSelectedValue
                Bank.OfficeCode = SearchableComboBoxSetup_Office.GetSelectedValue
                Bank.ServiceChargeGLAccount = SearchableComboBoxSetup_ServiceChargeGLAccount.GetSelectedValue
                If ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.GetSelectedValue = "-1" Then
                    Bank.CheckBodyLinesDown = Nothing
                Else
                    Bank.CheckBodyLinesDown = CShort(ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.GetSelectedValue)
                End If

                If ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.GetSelectedValue = "-1" Then
                    Bank.CheckStubLinesUp = Nothing
                Else
                    Bank.CheckStubLinesUp = CShort(ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.GetSelectedValue)
                End If

                Bank.DigitalSignatureActive = CheckBoxSetup_DigitalSignatureActive.Checked
                Bank.DigitalSignatureText = TextBoxSetup_DigitalSignatureText.Text
                Bank.DigitalSignatureFont = ComboBoxSetup_DigitalSignatureFont.GetSelectedValue
                Bank.DigitalSignatureFontSize = CInt(ComboBoxSetup_DigitalSignatureFontSize.GetSelectedValue)

            End If

        End Sub
        Private Sub SaveSetupTab(ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            If BankExportSpec IsNot Nothing Then

                BankExportSpec.BankID = TextBoxSetup_BankID.Text

            End If

        End Sub
        Private Sub SaveCurrencyTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

            If Bank IsNot Nothing Then

                Bank.CurrencyCode = SearchableComboBoxCurrency_Currency.GetSelectedValue
                Bank.ExchangeConversionAccount = SearchableComboBoxCurrency_ExchangeRealizedAccount.GetSelectedValue
                Bank.CurrencyExchangeUnrealizedGLAccount = SearchableComboBoxCurrency_ExchangeUnrealizedAccount.GetSelectedValue

            End If

        End Sub
        'Private Sub SaveCheckImportTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

        '    If Bank IsNot Nothing Then

        '        Bank.ImportFileName = TextBoxCheckImport_ImportFileName.Text

        '        If NumericInputLeftColumn_ColumnStart.EditValue IsNot Nothing Then
        '            Bank.CheckNumberColumnStart = Convert.ToInt16(NumericInputLeftColumn_ColumnStart.EditValue)
        '        Else
        '            Bank.CheckNumberColumnStart = Nothing
        '        End If

        '        If NumericInputLeftColumn_Length.EditValue IsNot Nothing Then
        '            Bank.CheckNumberLength = Convert.ToInt16(NumericInputLeftColumn_Length.Value)
        '        Else
        '            Bank.CheckNumberLength = Nothing
        '        End If

        '        If NumericInputRightColumn_ColumnStart.EditValue IsNot Nothing Then
        '            Bank.CheckAmountColumnStart = Convert.ToInt16(NumericInputRightColumn_ColumnStart.Value)
        '        Else
        '            Bank.CheckAmountColumnStart = Nothing
        '        End If

        '        If NumericInputRightColumn_Length.EditValue IsNot Nothing Then
        '            Bank.CheckAmountLength = Convert.ToInt16(NumericInputRightColumn_Length.Value)
        '        Else
        '            Bank.CheckAmountLength = Nothing
        '        End If

        '        If NumericInputRightColumn_NumberOfDecimals.EditValue IsNot Nothing Then
        '            Bank.CheckAmountNumberOfDecimals = Convert.ToInt16(NumericInputRightColumn_NumberOfDecimals.Value)
        '        Else
        '            Bank.CheckAmountNumberOfDecimals = Nothing
        '        End If

        '    End If

        'End Sub
        Private Sub SaveCheckExportTab(ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            If BankExportSpec IsNot Nothing Then

                If RadioButtonControlCheckExport_CSV.Checked Then
                    BankExportSpec.ExportType = AdvantageFramework.Database.Entities.ImportFileTypes.Delimited.ToString.ToUpper
                ElseIf RadioButtonControlCheckExport_Fixed.Checked Then
                    BankExportSpec.ExportType = AdvantageFramework.Database.Entities.ImportFileTypes.Fixed.ToString.ToUpper
                End If

                BankExportSpec.UseHeader = Convert.ToInt16(CheckBoxCheckExport_UseHeaderRecord.Checked)

                BankExportSpec.AgencyFlagHeader = Convert.ToInt16(CheckBoxHeaderRecord_ExportAgency.Checked)

                If NumericInputHeaderRecord_AgencyBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AgencyBeginPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_AgencyBeginPosition.EditValue)
                Else
                    BankExportSpec.AgencyBeginPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_AgencyEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AgencyEndPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_AgencyEndPosition.EditValue)
                Else
                    BankExportSpec.AgencyEndPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_AgencyCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.AgencyCSVOrderHeader = Convert.ToInt16(NumericInputHeaderRecord_AgencyCSVOrder.EditValue)
                Else
                    BankExportSpec.AgencyCSVOrderHeader = Nothing
                End If

                BankExportSpec.CreateDateFlagHeader = Convert.ToInt16(CheckBoxHeaderRecord_CreateDateExport.Checked)

                If NumericInputHeaderRecord_CreateDateBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CreateDateBeginPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_CreateDateBeginPosition.EditValue)
                Else
                    BankExportSpec.CreateDateBeginPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_CreateDateEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CreateDateEndPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_CreateDateEndPosition.EditValue)
                Else
                    BankExportSpec.CreateDateEndPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_CreateDateCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CreateDateCSVOrderHeader = Convert.ToInt16(NumericInputHeaderRecord_CreateDateCSVOrder.EditValue)
                Else
                    BankExportSpec.CreateDateCSVOrderHeader = Nothing
                End If

                BankExportSpec.Filler1FlagHeader = Convert.ToInt16(CheckBoxHeaderRecord_Filler1Export.Checked)

                If NumericInputHeaderRecord_Filler1BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1BeginPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_Filler1BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler1BeginPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_Filler1EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1EndPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_Filler1EndPosition.EditValue)
                Else
                    BankExportSpec.Filler1EndPositionHeader = Nothing
                End If

                BankExportSpec.Filler1ValueHeader = TextBoxHeaderRecord_Filler1FillValue.Text

                BankExportSpec.Filler2FlagHeader = Convert.ToInt16(CheckBoxHeaderRecord_Filler2Export.Checked)

                If NumericInputHeaderRecord_Filler2BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2BeginPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_Filler2BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler2BeginPositionHeader = Nothing
                End If

                If NumericInputHeaderRecord_Filler2EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2EndPositionHeader = Convert.ToInt16(NumericInputHeaderRecord_Filler2EndPosition.EditValue)
                Else
                    BankExportSpec.Filler2EndPositionHeader = Nothing
                End If

                BankExportSpec.Filler2ValueHeader = TextBoxHeaderRecord_Filler2FillValue.Text

                BankExportSpec.BankIDFlag = Convert.ToInt16(CheckBoxDetailRecord_BankIDExport.Checked)

                If NumericInputDetailRecord_BankIDBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_BankIDBeginPosition.EditValue)
                Else
                    BankExportSpec.BankIDBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_BankIDEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_BankIDEndPosition.EditValue)
                Else
                    BankExportSpec.BankIDEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_BankIDCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_BankIDCSVOrder.EditValue)
                Else
                    BankExportSpec.BankIDCSVOrderDetail = Nothing
                End If

                BankExportSpec.AccountNumberFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_AccountNumberExport.Checked)

                If NumericInputDetailRecord_AccountNumberBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_AccountNumberBeginPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_AccountNumberEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_AccountNumberEndPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_AccountNumberCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_AccountNumberCSVOrder.EditValue)
                Else
                    BankExportSpec.AccountNumberCSVOrderDetail = Nothing
                End If

                BankExportSpec.CheckNumberFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_CheckNumberExport.Checked)

                If NumericInputDetailRecord_CheckNumberBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckNumberBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckNumberBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckNumberBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckNumberEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckNumberEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckNumberEndPosition.EditValue)
                Else
                    BankExportSpec.CheckNumberEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckNumberCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckNumberCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_CheckNumberCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckNumberCSVOrderDetail = Nothing
                End If

                BankExportSpec.CheckDateTimeFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_CheckDateExport.Checked)

                If NumericInputDetailRecord_CheckDateBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckDateBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckDateEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckDateEndPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckDateCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_CheckDateCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckDateTimeCSVOrderDetail = Nothing
                End If

                BankExportSpec.CheckAmountFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_CheckAmountExport.Checked)

                If NumericInputDetailRecord_CheckAmountBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckAmountBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckAmountEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_CheckAmountEndPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_CheckAmountCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_CheckAmountCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckAmountCSVOrderDetail = Nothing
                End If

                BankExportSpec.CheckVoidFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_VoidFlagExport.Checked)

                If NumericInputDetailRecord_VoidFlagBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_VoidFlagBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_VoidFlagEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_VoidFlagEndPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_VoidFlagCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_VoidFlagCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckVoidCSVOrderDetail = Nothing
                End If

                BankExportSpec.CheckPayeeFlagDetail = Convert.ToInt16(CheckBoxDetailRecord_PayeeExport.Checked)

                If NumericInputDetailRecord_PayeeBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckPayeeBeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_PayeeBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckPayeeBeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_PayeeEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckPayeeEndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_PayeeEndPosition.EditValue)
                Else
                    BankExportSpec.CheckPayeeEndPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_PayeeCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckPayeeCSVOrderDetail = Convert.ToInt16(NumericInputDetailRecord_PayeeCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckPayeeCSVOrderDetail = Nothing
                End If

                BankExportSpec.Filler1FlagDetail = Convert.ToInt16(CheckBoxDetailRecord_Filler1Export.Checked)

                If NumericInputDetailRecord_Filler1BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1BeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler1BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler1BeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_Filler1EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1EndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler1EndPosition.EditValue)
                Else
                    BankExportSpec.Filler1EndPositionDetail = Nothing
                End If

                BankExportSpec.Filler1ValueDetail = TextBoxDetailRecord_Filler1FillValue.Text

                BankExportSpec.Filler2FlagDetail = Convert.ToInt16(CheckBoxDetailRecord_Filler2Export.Checked)

                If NumericInputDetailRecord_Filler2BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2BeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler2BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler2BeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_Filler2EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2EndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler2EndPosition.EditValue)
                Else
                    BankExportSpec.Filler2EndPositionDetail = Nothing
                End If

                BankExportSpec.Filler2ValueDetail = TextBoxDetailRecord_Filler2FillValue.Text

                BankExportSpec.Filler3FlagDetail = Convert.ToInt16(CheckBoxDetailRecord_Filler3Export.Checked)

                If NumericInputDetailRecord_Filler3BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3BeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler3BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler3BeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_Filler3EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3EndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler3EndPosition.EditValue)
                Else
                    BankExportSpec.Filler3EndPositionDetail = Nothing
                End If

                BankExportSpec.Filler4FlagDetail = Convert.ToInt16(CheckBoxDetailRecord_Filler4Export.Checked)

                If NumericInputDetailRecord_Filler4BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4BeginPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler4BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler4BeginPositionDetail = Nothing
                End If

                If NumericInputDetailRecord_Filler4EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4EndPositionDetail = Convert.ToInt16(NumericInputDetailRecord_Filler4EndPosition.EditValue)
                Else
                    BankExportSpec.Filler4EndPositionDetail = Nothing
                End If

            End If

        End Sub
        Private Sub SaveCheckExport2Tab(ByVal BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec)

            If BankExportSpec IsNot Nothing Then

                BankExportSpec.BankIDFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_BankIDExport.Checked)

                If NumericInputTotalRecord_BankIDBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_BankIDBeginPosition.EditValue)
                Else
                    BankExportSpec.BankIDBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_BankIDEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_BankIDEndPosition.EditValue)
                Else
                    BankExportSpec.BankIDEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_BankIDCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_BankIDCSVOrder.EditValue)
                Else
                    BankExportSpec.BankIDCSVOrderTotal = Nothing
                End If

                BankExportSpec.AccountNumberFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_AccountNumberExport.Checked)

                If NumericInputTotalRecord_AccountNumberBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_AccountNumberBeginPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_AccountNumberEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_AccountNumberEndPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_AccountNumberCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_AccountNumberCSVOrder.EditValue)
                Else
                    BankExportSpec.AccountNumberCSVOrderTotal = Nothing
                End If

                BankExportSpec.CheckDateTimeFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_FileDateExport.Checked)

                If NumericInputTotalRecord_FileDateBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_FileDateBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_FileDateEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_FileDateEndPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_FileDateCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_FileDateCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckDateTimeCSVOrderTotal = Nothing
                End If

                BankExportSpec.CheckAmountFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_ExportAmountExport.Checked)

                If NumericInputTotalRecord_ExportAmountBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_ExportAmountBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_ExportAmountEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_ExportAmountEndPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_ExportAmountCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_ExportAmountCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckAmountCSVOrderTotal = Nothing
                End If

                BankExportSpec.CheckVoidFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_TotalFlagExport.Checked)

                If NumericInputTotalRecord_TotalFlagBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_TotalFlagBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_TotalFlagEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_TotalFlagEndPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_TotalFlagCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_TotalFlagCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckVoidCSVOrderTotal = Nothing
                End If

                BankExportSpec.RecordCountFlagTotal = Convert.ToInt16(CheckBoxTotalRecord_RecordCountExport.Checked)

                If NumericInputTotalRecord_RecordCountBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountBeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_RecordCountBeginPosition.EditValue)
                Else
                    BankExportSpec.RecordCountBeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_RecordCountEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountEndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_RecordCountEndPosition.EditValue)
                Else
                    BankExportSpec.RecordCountEndPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_RecordCountCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountCSVOrderTotal = Convert.ToInt16(NumericInputTotalRecord_RecordCountCSVOrder.EditValue)
                Else
                    BankExportSpec.RecordCountCSVOrderTotal = Nothing
                End If

                BankExportSpec.Filler1FlagTotal = Convert.ToInt16(CheckBoxTotalRecord_Filler1Export.Checked)

                If NumericInputTotalRecord_Filler1BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1BeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler1BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler1BeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_Filler1EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1EndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler1EndPosition.EditValue)
                Else
                    BankExportSpec.Filler1EndPositionTotal = Nothing
                End If

                BankExportSpec.Filler1ValueTotal = TextBoxTotalRecord_Filler1FillValue.Text

                BankExportSpec.Filler2FlagTotal = Convert.ToInt16(CheckBoxTotalRecord_Filler2Export.Checked)

                If NumericInputTotalRecord_Filler2BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2BeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler2BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler2BeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_Filler2EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2EndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler2EndPosition.EditValue)
                Else
                    BankExportSpec.Filler2EndPositionTotal = Nothing
                End If

                BankExportSpec.Filler2ValueTotal = TextBoxTotalRecord_Filler2FillValue.Text

                BankExportSpec.Filler3FlagTotal = Convert.ToInt16(CheckBoxTotalRecord_Filler3Export.Checked)

                If NumericInputTotalRecord_Filler3BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3BeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler3BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler3BeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_Filler3EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3EndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler3EndPosition.EditValue)
                Else
                    BankExportSpec.Filler3EndPositionTotal = Nothing
                End If

                BankExportSpec.Filler4FlagTotal = Convert.ToInt16(CheckBoxTotalRecord_Filler4Export.Checked)

                If NumericInputTotalRecord_Filler4BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4BeginPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler4BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler4BeginPositionTotal = Nothing
                End If

                If NumericInputTotalRecord_Filler4EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4EndPositionTotal = Convert.ToInt16(NumericInputTotalRecord_Filler4EndPosition.EditValue)
                Else
                    BankExportSpec.Filler4EndPositionTotal = Nothing
                End If

                BankExportSpec.BankIDFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_BankIDExport.Checked)

                If NumericInputTrailerRecord_BankIDBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_BankIDBeginPosition.EditValue)
                Else
                    BankExportSpec.BankIDBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_BankIDEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_BankIDEndPosition.EditValue)
                Else
                    BankExportSpec.BankIDEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_BankIDCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.BankIDCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_BankIDCSVOrder.EditValue)
                Else
                    BankExportSpec.BankIDCSVOrderTrailer = Nothing
                End If

                BankExportSpec.AccountNumberFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_AccountNumberExport.Checked)

                If NumericInputTrailerRecord_AccountNumberBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_AccountNumberBeginPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_AccountNumberEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_AccountNumberEndPosition.EditValue)
                Else
                    BankExportSpec.AccountNumberEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_AccountNumberCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.AccountNumberCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_AccountNumberCSVOrder.EditValue)
                Else
                    BankExportSpec.AccountNumberCSVOrderTrailer = Nothing
                End If

                BankExportSpec.CheckDateTimeFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_FileDateExport.Checked)

                If NumericInputTrailerRecord_FileDateBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_FileDateBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_FileDateEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_FileDateEndPosition.EditValue)
                Else
                    BankExportSpec.CheckDateTimeEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_FileDateCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckDateTimeCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_FileDateCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckDateTimeCSVOrderTrailer = Nothing
                End If

                BankExportSpec.CheckAmountFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_ExportAmountExport.Checked)

                If NumericInputTrailerRecord_ExportAmountBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_ExportAmountBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_ExportAmountEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_ExportAmountEndPosition.EditValue)
                Else
                    BankExportSpec.CheckAmountEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_ExportAmountCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckAmountCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_ExportAmountCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckAmountCSVOrderTrailer = Nothing
                End If

                BankExportSpec.CheckVoidFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_TotalFlagExport.Checked)
                If NumericInputTrailerRecord_TotalFlagBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_TotalFlagBeginPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_TotalFlagEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_TotalFlagEndPosition.EditValue)
                Else
                    BankExportSpec.CheckVoidEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_TotalFlagCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.CheckVoidCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_TotalFlagCSVOrder.EditValue)
                Else
                    BankExportSpec.CheckVoidCSVOrderTrailer = Nothing
                End If

                BankExportSpec.RecordCountFlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_RecordCountExport.Checked)

                If NumericInputTrailerRecord_RecordCountBeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountBeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_RecordCountBeginPosition.EditValue)
                Else
                    BankExportSpec.RecordCountBeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_RecordCountEndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountEndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_RecordCountEndPosition.EditValue)
                Else
                    BankExportSpec.RecordCountEndPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_RecordCountCSVOrder.EditValue IsNot Nothing Then
                    BankExportSpec.RecordCountCSVOrderTrailer = Convert.ToInt16(NumericInputTrailerRecord_RecordCountCSVOrder.EditValue)
                Else
                    BankExportSpec.RecordCountCSVOrderTrailer = Nothing
                End If

                BankExportSpec.Filler1FlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_Filler1Export.Checked)

                If NumericInputTrailerRecord_Filler1BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1BeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler1BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler1BeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_Filler1EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler1EndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler1EndPosition.EditValue)
                Else
                    BankExportSpec.Filler1EndPositionTrailer = Nothing
                End If

                BankExportSpec.Filler1ValueTrailer = TextBoxTrailerRecord_Filler1FillValue.Text

                BankExportSpec.Filler2FlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_Filler2Export.Checked)
                If NumericInputTrailerRecord_Filler2BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2BeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler2BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler2BeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_Filler2EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler2EndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler2EndPosition.EditValue)
                Else
                    BankExportSpec.Filler2EndPositionTrailer = Nothing
                End If

                BankExportSpec.Filler2ValueTrailer = TextBoxTrailerRecord_Filler2FillValue.Text

                BankExportSpec.Filler3FlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_Filler3Export.Checked)

                If NumericInputTrailerRecord_Filler3BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3BeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler3BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler3BeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_Filler3EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler3EndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler3EndPosition.EditValue)
                Else
                    BankExportSpec.Filler3EndPositionTrailer = Nothing
                End If

                BankExportSpec.Filler4FlagTrailer = Convert.ToInt16(CheckBoxTrailerRecord_Filler4Export.Checked)

                If NumericInputTrailerRecord_Filler4BeginPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4BeginPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler4BeginPosition.EditValue)
                Else
                    BankExportSpec.Filler4BeginPositionTrailer = Nothing
                End If

                If NumericInputTrailerRecord_Filler4EndPosition.EditValue IsNot Nothing Then
                    BankExportSpec.Filler4EndPositionTrailer = Convert.ToInt16(NumericInputTrailerRecord_Filler4EndPosition.EditValue)
                Else
                    BankExportSpec.Filler4EndPositionTrailer = Nothing
                End If

            End If

        End Sub
        Private Sub SavePaymentManagerTab(ByVal Bank As AdvantageFramework.Database.Entities.Bank)

            If Bank IsNot Nothing Then

                Bank.PaymentManagerType = SearchableComboBoxPaymentManager_ExportType.GetSelectedValue
                Bank.PaymentManagerID = TextBoxPaymentManager_CustomerID.Text
                Bank.PaymentManagerWord = TextBoxPaymentManager_Word.Text
                Bank.PaymentManagerFTP = TextBoxPaymentManager_FTPClient.Text
                Bank.PaymentManagerDirectory = TextBoxPaymentManager_FileOutputDirectory.Text

                Bank.CSIUserName = TextBoxPaymentManager_CSIUserName.Text
                Bank.CSIPassword = TextBoxPaymentManager_CSIPassword.Text
                Bank.CSITargetFolder = TextBoxPaymentManager_CSITargetFolder.Text
                Bank.ComDataAccountCode = TextBoxPaymentManager_ComDataAccountCode.Text
                Bank.ComDataPassword = TextBoxPaymentManager_ComDataPassword.Text

                Bank.PaymentManagerACHDestinationName = TextBoxPaymentManager_DestinationName.GetText
                Bank.PaymentManagerACHCompanyEntryDescription = TextBoxPaymentManager_CompanyEntryDescription.GetText
                Bank.PaymentManagerACHServiceClassCode = ComboBoxPaymentManager_ServiceClassCode.GetSelectedValue
                Bank.PaymentManagerACHStandardEntryClassCode = ComboBoxPaymentManager_StandardEntryClassCode.GetSelectedValue
                Bank.PaymentManagerACHCompanyName = TextBoxPaymentManager_CompanyName.GetText

                Bank.PaymentManagerFTPAddress = TextBoxPaymentManager_FTPAddress.GetText
                Bank.PaymentManagerFTPExportFolder = TextBoxPaymentManager_FTPExportFolder.GetText
                Bank.PaymentManagerFTPFolder = TextBoxPaymentManager_FTPFolder.GetText
                Bank.PaymentManagerFTPUsername = TextBoxPaymentManager_FTPUserName.GetText
                Bank.PaymentManagerFTPPassword = TextBoxPaymentManager_FTPPassword.GetText
                Bank.PaymentManagerFTPPort = CShort(TextBoxPaymentManager_FTPPort.GetText)
                Bank.PaymentManagerFTPAddress = TextBoxPaymentManager_FTPAddress.GetText
                Bank.PaymentManagerFTPSSL = CheckBoxPaymentManager_UseSSL.Checked
                Bank.PaymentManagerFTPSSLMode = ComboBoxPaymentManager_FTPSecure.GetSelectedValue

                Bank.PaymentManagerFTPPrivateKey = ButtonPaymentManager_FTPPrivateKeySelect.Tag

            End If

        End Sub
        Private Sub SetFillerMaxLength(ByVal NumericInput_BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput, ByVal NumericInput_EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput, ByVal TextBox_Filler As AdvantageFramework.WinForm.Presentation.Controls.TextBox)

            'objects
            Dim MaxLength As Integer = Nothing

            If NumericInput_BeginPosition.EditValue IsNot Nothing AndAlso NumericInput_EndPosition.EditValue IsNot Nothing Then

                Try
                    MaxLength = CInt(NumericInput_EndPosition.Value) - CInt(NumericInput_BeginPosition.Value)
                Catch ex As Exception
                    MaxLength = 1
                End Try

                If MaxLength > 0 Then
                    TextBox_Filler.MaxLength = MaxLength + 1
                Else
                    TextBox_Filler.MaxLength = 1
                End If

                If TextBox_Filler.Text.Length > TextBox_Filler.MaxLength Then

                    AdvantageFramework.WinForm.MessageBox.Show("Value exceeds the defined field length.")

                    TextBox_Filler.Focus()

                End If

            Else
                TextBox_Filler.MaxLength = 1
            End If

        End Sub
        Private Sub LoadDropDownDataSources(BypassCurrencyLoad As Boolean)

            'objects
            Dim GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim CurrencyCodes() As String = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim GeneralLedgerAccountTypesRealized As IEnumerable(Of String) = Nothing
            Dim GeneralLedgerAccountTypesUnrealized As IEnumerable(Of String) = Nothing
            Dim FontSizeList As Generic.List(Of Short) = Nothing
            Dim InstalledFontCollection As System.Drawing.Text.InstalledFontCollection = Nothing
            Dim InstalledFonts As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim LimitByBankCurrency As Boolean = False
            Dim CurrencyCode As AdvantageFramework.Database.Entities.CurrencyCode = Nothing

            GeneralLedgerAccountTypesRealized = {AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseOther, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseTaxes,
                                                    AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.Income_Other, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseOperating,
                                                    AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.ExpenseCOS, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.Income}

            GeneralLedgerAccountTypesUnrealized = {AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.NonCurrentLiability, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.CurrentLiability,
                                                    AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.FixedAsset, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.CurrentAsset,
                                                    AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.NonCurrentAsset}

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'Moved from below
                    If _BankCode IsNot Nothing Then

                        Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                    End If

                    'If _IsMultiCurrencyEnabled = True Then

                    '    LimitByBankCurrency = True

                    'End If

                    'PJH 09/08/20 - Per Martine "We can't limit the Accounts to just Foreign Accounts." - 4262-1-90 - Multi-Currency - Bank Maintenance
                    LimitByBankCurrency = False

                    'If LimitByBankCurrency Then

                    '    _CurrencyCode = SearchableComboBoxCurrency_Currency.SelectedValue

                    '    If _CurrencyCode = Nothing And Bank IsNot Nothing Then

                    '        _CurrencyCode = Bank.CurrencyCode

                    '    End If

                    '    'Load GL Accounts where account currency = bank currency or (bank currency = home currency and account currency is null)
                    '    GeneralLedgerAccounts = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, False))
                    '                             Where Entity.CurrencyCode = _CurrencyCode Or (_AgencyCurrencyCode = _CurrencyCode And Entity.CurrencyCode Is Nothing)
                    '                             Select Entity).ToList()

                    'Else

                    GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, False))

                    'End If

                    ' Setup Tab
                    ComboBoxSetup_CheckAmountInWords.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.Yes1No0))
                    SearchableComboBoxSetup_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                    SearchableComboBoxSetup_ServiceChargeGLAccount.DataSource = GeneralLedgerAccounts
                    SearchableComboBoxSetup_InterestEarnedGLAccount.DataSource = GeneralLedgerAccounts
                    SearchableComboBoxSetup_ARCashAccount.DataSource = GeneralLedgerAccounts
                    SearchableComboBoxSetup_APCashAccount.DataSource = GeneralLedgerAccounts
                    SearchableComboBoxSetup_APDiscAccount.DataSource = GeneralLedgerAccounts

                    SearchableComboBoxSetup_APComputerCheckFormat.DataSource = AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 94).OrderBy(Function(Entity) Entity.Number).ThenBy(Function(Entity) Entity.Name)

                    ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AdjustCheckBodyLinesDn)).ToList
                                                                                       Select [Code] = EnumObject.Code,
                                                                                              [Description] = EnumObject.Description).ToList

                    ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AdjustCheckStubLinesUp)).ToList
                                                                                     Select [Code] = EnumObject.Code,
                                                                                              [Description] = EnumObject.Description).ToList

                    ' Currency Tab
                    SearchableComboBoxCurrency_ExchangeRealizedAccount.DataSource = (From GLA In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, False))
                                                                                     Where GeneralLedgerAccountTypesRealized.Contains(GLA.Type)
                                                                                     Select New With {GLA.Code, GLA.Description}).ToList

                    SearchableComboBoxCurrency_ExchangeUnrealizedAccount.DataSource = (From GLA In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session, False))
                                                                                       Where GeneralLedgerAccountTypesUnrealized.Contains(GLA.Type)
                                                                                       Select New With {GLA.Code, GLA.Description}).ToList

                    If Not BypassCurrencyLoad Then

                        CurrencyCodes = AdvantageFramework.Database.Procedures.Currency.Load(DbContext).Select(Function(Entity) Entity.CurrencyCode).ToArray

                        SearchableComboBoxCurrency_Currency.DataSource = (From Entity In AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActive(DbContext)
                                                                          Where CurrencyCodes.Contains(Entity.Code)
                                                                          Select Entity)


                        CurrencyCode = AdvantageFramework.Database.Procedures.CurrencyCode.LoadByCode(DbContext, _AgencyCurrencyCode)

                        If CurrencyCode IsNot Nothing Then

                            SearchableComboBoxCurrency_Currency.AddComboItemToExistingDataSource(CurrencyCode.Description & "*", CurrencyCode.Code, False)

                            'SearchableComboBoxCurrency_Currency.SelectedValue = Bank.CurrencyCode

                        End If

                    End If


                    ' Payment manager tab
                    Try

                        SearchableComboBoxPaymentManager_ExportType.DataSource = AdvantageFramework.Database.Procedures.ExportSystem.LoadBySystemName(DbContext, Database.Entities.ExportSystem.SystemNames.PAYMENT_MANAGER)

                    Catch ex As Exception

                    End Try

                    ComboBoxPaymentManager_ServiceClassCode.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.PaymentManagerACHServiceClassCode))
                    ComboBoxPaymentManager_StandardEntryClassCode.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.PaymentManagerACHStandardEntryClassCode))

                    ComboBoxPaymentManager_FTPSecure.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.FTP.FTPSSLMode), GetType(Short))

                    InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
                    InstalledFonts = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                    For Each FontFamily In InstalledFontCollection.Families

                        InstalledFonts.Add(New EnumUtilities.Attributes.EnumObjectAttribute(FontFamily.Name, FontFamily.Name))

                    Next

                    ComboBoxSetup_DigitalSignatureFont.DataSource = InstalledFonts

                    ' Font size list
                    FontSizeList = New Generic.List(Of Short)

                    For I = 3 To 72

                        If I < 12 Then

                            FontSizeList.Add(I)

                        ElseIf I >= 12 AndAlso I <= 28 AndAlso I Mod 2 = 0 Then

                            FontSizeList.Add(I)

                        ElseIf I = 36 OrElse I = 48 OrElse I = 72 Then

                            FontSizeList.Add(I)

                        End If

                    Next

                    ComboBoxSetup_DigitalSignatureFontSize.DataSource = FontSizeList.Select(Function(Size) New With {.FontSize = Size}).ToList

                    DbContext.Database.Connection.Close()

                End Using

            End Using

            'If _BankCode = Nothing Then

            '    If _IsMultiCurrencyEnabled = True Then

            '        SearchableComboBoxSetup_ServiceChargeGLAccount.Enabled = False
            '        SearchableComboBoxSetup_InterestEarnedGLAccount.Enabled = False
            '        SearchableComboBoxSetup_ARCashAccount.Enabled = False
            '        SearchableComboBoxSetup_APCashAccount.Enabled = False
            '        SearchableComboBoxSetup_APDiscAccount.Enabled = False

            '        SearchableComboBoxSetup_ServiceChargeGLAccount.Text = "[Pending Currency Selection]"
            '        SearchableComboBoxSetup_InterestEarnedGLAccount.Text = "[Pending Currency Selection]"
            '        SearchableComboBoxSetup_ARCashAccount.Text = "[Pending Currency Selection]"
            '        SearchableComboBoxSetup_APCashAccount.Text = "[Pending Currency Selection]"
            '        SearchableComboBoxSetup_APDiscAccount.Text = "[Pending Currency Selection]"

            '    End If

            'Else

            '    SearchableComboBoxSetup_ServiceChargeGLAccount.Enabled = True
            '    SearchableComboBoxSetup_InterestEarnedGLAccount.Enabled = True
            '    SearchableComboBoxSetup_ARCashAccount.Enabled = True
            '    SearchableComboBoxSetup_APCashAccount.Enabled = True
            '    SearchableComboBoxSetup_APDiscAccount.Enabled = True

            'End If

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal BankCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing

            _BankCode = BankCode

            If _BankCode = Nothing Then

                If _IsMultiCurrencyEnabled = True Then

                    AdvantageFramework.WinForm.MessageBox.Show("Currency selection is required to enable GL Account selection.")

                End If

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                TextBoxDetailRecord_Filler3FillValue.Visible = False
                TextBoxDetailRecord_Filler4FillValue.Visible = False
                TextBoxTotalRecord_Filler3FillValue.Visible = False
                TextBoxTotalRecord_Filler4FillValue.Visible = False
                TextBoxTrailerRecord_Filler3FillValue.Visible = False
                TextBoxTrailerRecord_Filler4FillValue.Visible = False

                If _BankCode <> "" Then

                    Try

                        _CheckWritingInProgress = CBool(DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.CHECKWRITING WHERE BK_CODE = '{0}'", _BankCode)).FirstOrDefault)

                    Catch ex As Exception
                        _CheckWritingInProgress = False
                    End Try

                    TextBoxSetup_Code.ReadOnly = True
                    TextBoxSetup_Code.Enabled = False

                    Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, _BankCode)

                    If Bank IsNot Nothing Then

                        If Bank.PaymentManagerType = "HSB1" Then

                            LabelSetup_BankID.Text = "Special Handling Code:"

                        End If

                        LoadEntityDetails(Nothing)

                        CheckBoxSetup_PaymentManager.CheckValue = Bank.PaymentManager.GetValueOrDefault(0)

                        SearchableComboBoxCurrency_Currency.Enabled = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT APH.BANK_CURRENCY_CODE FROM dbo.CHECK_REGISTER CR INNER JOIN dbo.AP_PMT_HIST APH ON CR.CHECK_NBR = APH.AP_CHK_NBR WHERE CR.BK_CODE = '{0}' AND COALESCE(CR.VOID_FLAG, 0) = 0 AND APH.BANK_CURRENCY_CODE IS NOT NULL", _BankCode)).Any = False

                    Else

                        Loaded = False

                    End If

                Else

                    RadioButtonControlCheckExport_Fixed.Checked = True
                    TextBoxSetup_Code.Enabled = True
                    TextBoxSetup_Name.Enabled = True
                    TextBoxSetup_Code.ReadOnly = False
                    TextBoxSetup_Name.ReadOnly = False

                End If

            End Using

            EnableOrDisableActions()

            If Loaded = False Then

                Me.ClearControl()

            End If

            LoadDropDownDataSources(True)
            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            ' setup tab
            TextBoxSetup_Code.Text = String.Empty
            TextBoxSetup_Name.Text = String.Empty
            CheckBoxSetup_Inactive.Checked = False
            CheckBoxSetup_PaymentManager.Checked = False
            TextBoxSetup_AccountNumber.Text = String.Empty
            NumericInputSetup_RoutingNumber.EditValue = Nothing
            TextBoxSetup_ACHCompanyID.Text = String.Empty
            TextBoxSetup_BankID.Text = String.Empty
            NumericInputSetup_LastManualCheckIssued.EditValue = Nothing
            NumericInputSetup_LastComputerCheckIssued.EditValue = Nothing
            NumericInputSetup_CheckTemplateID.EditValue = Nothing
            SearchableComboBoxSetup_Office.SelectedValue = Nothing
            SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing
            SearchableComboBoxSetup_APComputerCheckFormat.SelectedValue = Nothing
            SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing
            SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing
            ComboBoxSetup_CheckAmountInWords.SelectedIndex = 0
            SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing
            SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing

            'currency tab
            SearchableComboBoxCurrency_Currency.SelectedValue = Nothing
            SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Nothing
            SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Nothing

            'check import tab
            TextBoxCheckImport_ImportFileName.Text = String.Empty
            NumericInputLeftColumn_ColumnStart.EditValue = Nothing
            NumericInputLeftColumn_Length.EditValue = Nothing
            NumericInputRightColumn_ColumnStart.EditValue = Nothing
            NumericInputRightColumn_Length.EditValue = Nothing
            NumericInputRightColumn_NumberOfDecimals.EditValue = Nothing

            ' check export tab
            RadioButtonControlCheckExport_Fixed.Checked = True
            CheckBoxCheckExport_UseHeaderRecord.Checked = False
            CheckBoxHeaderRecord_ExportAgency.Checked = False
            NumericInputHeaderRecord_AgencyBeginPosition.EditValue = Nothing
            NumericInputHeaderRecord_AgencyEndPosition.EditValue = Nothing
            NumericInputHeaderRecord_AgencyCSVOrder.EditValue = Nothing
            CheckBoxHeaderRecord_CreateDateExport.Checked = False
            NumericInputHeaderRecord_CreateDateBeginPosition.EditValue = Nothing
            NumericInputHeaderRecord_CreateDateEndPosition.EditValue = Nothing
            NumericInputHeaderRecord_CreateDateCSVOrder.EditValue = Nothing
            CheckBoxHeaderRecord_Filler1Export.Checked = False
            NumericInputHeaderRecord_Filler1BeginPosition.EditValue = Nothing
            NumericInputHeaderRecord_Filler1EndPosition.EditValue = Nothing
            TextBoxHeaderRecord_Filler1FillValue.Text = String.Empty
            CheckBoxHeaderRecord_Filler2Export.Checked = False
            NumericInputHeaderRecord_Filler2BeginPosition.EditValue = Nothing
            NumericInputHeaderRecord_Filler2EndPosition.EditValue = Nothing
            TextBoxHeaderRecord_Filler2FillValue.Text = String.Empty
            CheckBoxDetailRecord_BankIDExport.Checked = False
            NumericInputDetailRecord_BankIDBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_BankIDEndPosition.EditValue = Nothing
            NumericInputDetailRecord_BankIDCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_AccountNumberExport.Checked = False
            NumericInputDetailRecord_AccountNumberBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_AccountNumberEndPosition.EditValue = Nothing
            NumericInputDetailRecord_AccountNumberCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_CheckNumberExport.Checked = False
            NumericInputDetailRecord_CheckNumberBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckNumberEndPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckNumberCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_CheckDateExport.Checked = False
            NumericInputDetailRecord_CheckDateBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckDateEndPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckDateCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_CheckAmountExport.Checked = False
            NumericInputDetailRecord_CheckAmountBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckAmountEndPosition.EditValue = Nothing
            NumericInputDetailRecord_CheckAmountCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_VoidFlagExport.Checked = False
            NumericInputDetailRecord_VoidFlagBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_VoidFlagEndPosition.EditValue = Nothing
            NumericInputDetailRecord_VoidFlagCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_PayeeExport.Checked = False
            NumericInputDetailRecord_PayeeBeginPosition.EditValue = Nothing
            NumericInputDetailRecord_PayeeEndPosition.EditValue = Nothing
            NumericInputDetailRecord_PayeeCSVOrder.EditValue = Nothing
            CheckBoxDetailRecord_Filler1Export.Checked = False
            NumericInputDetailRecord_Filler1BeginPosition.EditValue = Nothing
            NumericInputDetailRecord_Filler1EndPosition.EditValue = Nothing
            TextBoxDetailRecord_Filler1FillValue.Text = String.Empty
            CheckBoxDetailRecord_Filler2Export.Checked = False
            NumericInputDetailRecord_Filler2BeginPosition.EditValue = Nothing
            NumericInputDetailRecord_Filler2EndPosition.EditValue = Nothing
            TextBoxDetailRecord_Filler2FillValue.Text = String.Empty
            CheckBoxDetailRecord_Filler3Export.Checked = False
            NumericInputDetailRecord_Filler3BeginPosition.EditValue = Nothing
            NumericInputDetailRecord_Filler3EndPosition.EditValue = Nothing
            TextBoxDetailRecord_Filler3FillValue.Text = String.Empty
            CheckBoxDetailRecord_Filler4Export.Checked = False
            NumericInputDetailRecord_Filler4BeginPosition.EditValue = Nothing
            NumericInputDetailRecord_Filler4EndPosition.EditValue = Nothing
            TextBoxDetailRecord_Filler4FillValue.Text = String.Empty

            ' check export 2 tab
            CheckBoxTotalRecord_BankIDExport.Checked = False
            NumericInputTotalRecord_BankIDBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_BankIDEndPosition.EditValue = Nothing
            NumericInputTotalRecord_BankIDCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_AccountNumberExport.Checked = False
            NumericInputTotalRecord_AccountNumberBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_AccountNumberEndPosition.EditValue = Nothing
            NumericInputTotalRecord_AccountNumberCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_FileDateExport.Checked = False
            NumericInputTotalRecord_FileDateBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_FileDateEndPosition.EditValue = Nothing
            NumericInputTotalRecord_FileDateCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_ExportAmountExport.Checked = False
            NumericInputTotalRecord_ExportAmountBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_ExportAmountEndPosition.EditValue = Nothing
            NumericInputTotalRecord_ExportAmountCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_TotalFlagExport.Checked = False
            NumericInputTotalRecord_TotalFlagBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_TotalFlagEndPosition.EditValue = Nothing
            NumericInputTotalRecord_TotalFlagCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_RecordCountExport.Checked = False
            NumericInputTotalRecord_RecordCountBeginPosition.EditValue = Nothing
            NumericInputTotalRecord_RecordCountEndPosition.EditValue = Nothing
            NumericInputTotalRecord_RecordCountCSVOrder.EditValue = Nothing
            CheckBoxTotalRecord_Filler1Export.Checked = False
            NumericInputTotalRecord_Filler1BeginPosition.EditValue = Nothing
            NumericInputTotalRecord_Filler1EndPosition.EditValue = Nothing
            TextBoxTotalRecord_Filler1FillValue.Text = String.Empty
            CheckBoxTotalRecord_Filler2Export.Checked = False
            NumericInputTotalRecord_Filler2BeginPosition.EditValue = Nothing
            NumericInputTotalRecord_Filler2EndPosition.EditValue = Nothing
            TextBoxTotalRecord_Filler2FillValue.Text = String.Empty
            CheckBoxTotalRecord_Filler3Export.Checked = False
            NumericInputTotalRecord_Filler3BeginPosition.EditValue = Nothing
            NumericInputTotalRecord_Filler3EndPosition.EditValue = Nothing
            TextBoxTotalRecord_Filler3FillValue.Text = String.Empty
            CheckBoxTotalRecord_Filler4Export.Checked = False
            NumericInputTotalRecord_Filler4BeginPosition.EditValue = Nothing
            NumericInputTotalRecord_Filler4EndPosition.EditValue = Nothing
            TextBoxTotalRecord_Filler4FillValue.Text = String.Empty
            CheckBoxTrailerRecord_BankIDExport.Checked = False
            NumericInputTrailerRecord_BankIDBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_BankIDEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_BankIDCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_AccountNumberExport.Checked = False
            NumericInputTrailerRecord_AccountNumberBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_AccountNumberEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_AccountNumberCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_FileDateExport.Checked = False
            NumericInputTrailerRecord_FileDateBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_FileDateEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_FileDateCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_ExportAmountExport.Checked = False
            NumericInputTrailerRecord_ExportAmountBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_ExportAmountEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_ExportAmountCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_TotalFlagExport.Checked = False
            NumericInputTrailerRecord_TotalFlagBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_TotalFlagEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_TotalFlagCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_RecordCountExport.Checked = False
            NumericInputTrailerRecord_RecordCountBeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_RecordCountEndPosition.EditValue = Nothing
            NumericInputTrailerRecord_RecordCountCSVOrder.EditValue = Nothing
            CheckBoxTrailerRecord_Filler1Export.Checked = False
            NumericInputTrailerRecord_Filler1BeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_Filler1EndPosition.EditValue = Nothing
            TextBoxTrailerRecord_Filler1FillValue.Text = String.Empty
            CheckBoxTrailerRecord_Filler2Export.Checked = False
            NumericInputTrailerRecord_Filler2BeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_Filler2EndPosition.EditValue = Nothing
            TextBoxTrailerRecord_Filler2FillValue.Text = String.Empty
            CheckBoxTrailerRecord_Filler3Export.Checked = False
            NumericInputTrailerRecord_Filler3BeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_Filler3EndPosition.EditValue = Nothing
            TextBoxTrailerRecord_Filler3FillValue.Text = String.Empty
            CheckBoxTrailerRecord_Filler4Export.Checked = False
            NumericInputTrailerRecord_Filler4BeginPosition.EditValue = Nothing
            NumericInputTrailerRecord_Filler4EndPosition.EditValue = Nothing
            TextBoxTrailerRecord_Filler4FillValue.Text = String.Empty

            ' payment manager tab
            TextBoxPaymentManager_AccountNumber.Text = String.Empty
            TextBoxPaymentManager_CustomerID.Text = String.Empty
            TextBoxPaymentManager_FileOutputDirectory.Text = String.Empty
            TextBoxPaymentManager_FTPClient.Text = String.Empty
            TextBoxPaymentManager_Word.Text = String.Empty
            SearchableComboBoxPaymentManager_ExportType.SelectedValue = Nothing

            TextBoxPaymentManager_CSIUserName.Text = String.Empty
            TextBoxPaymentManager_CSIPassword.Text = String.Empty
            TextBoxPaymentManager_CSITargetFolder.Text = String.Empty
            TextBoxPaymentManager_ComDataAccountCode.Text = String.Empty
            TextBoxPaymentManager_ComDataPassword.Text = String.Empty

            TextBoxPaymentManager_DestinationName.Text = String.Empty
            TextBoxPaymentManager_CompanyEntryDescription.Text = String.Empty
            ComboBoxPaymentManager_ServiceClassCode.SelectedIndex = 0
            ComboBoxPaymentManager_StandardEntryClassCode.SelectedIndex = 0
            TextBoxPaymentManager_CompanyName.Text = String.Empty


            TextBoxPaymentManager_FTPAddress.Text = String.Empty
            TextBoxPaymentManager_FTPFolder.Text = String.Empty
            TextBoxPaymentManager_FTPUserName.Text = String.Empty
            TextBoxPaymentManager_FTPPassword.Text = String.Empty
            TextBoxPaymentManager_FTPPort.Text = Nothing
            TextBoxPaymentManager_FTPExportFolder.Text = String.Empty

            CheckBoxPaymentManager_UseSSL.Checked = False

            ComboBoxPaymentManager_FTPSecure.SelectedIndex = 0

            ComboBoxPaymentManager_FTPSecure.SelectedIndex = 0

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Bank = Me.FillObject(False)

                    If Bank IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Bank.Update(DbContext, Bank) Then

                            Saved = True

                            BankExportSpec = Me.BankExportSpec

                            If BankExportSpec IsNot Nothing Then

                                If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BankExportSpec).Where(Function(BnkExportSpec) BnkExportSpec.BankCode = BankExportSpec.BankCode).Any = True Then

                                    AdvantageFramework.Database.Procedures.BankExportSpec.Update(DbContext, BankExportSpec)

                                Else

                                    BankExportSpec.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.BankExportSpec.Insert(DbContext, BankExportSpec)

                                End If

                            End If

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
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Bank = Me.FillObject(False)

                    BankExportSpec = Me.BankExportSpec

                    If Bank IsNot Nothing Then

                        If BankExportSpec IsNot Nothing Then

                            DbContext.DeleteEntityObject(BankExportSpec)

                        End If

                        Deleted = AdvantageFramework.Database.Procedures.Bank.Delete(DbContext, Bank)

                        If Deleted = False Then

                            ErrorMessage = "The bank is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef BankCode As String) As Boolean

            'objects
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankExportSpec As AdvantageFramework.Database.Entities.BankExportSpec = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Bank = Me.FillObject(True)

                    If Bank IsNot Nothing Then

                        Bank.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Bank.Insert(DbContext, Bank) Then

                            Inserted = True

                            BankExportSpec = Me.BankExportSpec

                            If BankExportSpec IsNot Nothing Then

                                BankExportSpec.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.BankExportSpec.Insert(DbContext, BankExportSpec)

                            End If

                            BankCode = Bank.Code

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
        Public Sub LoadRequiredNonGridControlsForValidation()

            If _BankCode <> "" Then

                If TabItemBankDetails_Currency IsNot TabControlControl_BankDetails.SelectedTab Then

                    LoadEntityDetails(TabItemBankDetails_Currency)

                End If

                If TabItemBankDetails_Setup IsNot TabControlControl_BankDetails.SelectedTab Then

                    LoadEntityDetails(TabItemBankDetails_Setup)

                End If

                If TabItemBankDetails_PaymentManager IsNot TabControlControl_BankDetails.SelectedTab Then

                    LoadEntityDetails(TabItemBankDetails_PaymentManager)

                End If

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources(False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BankControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            TabItemBankDetails_CheckImport.Visible = False
            TabItemBankDetails_Currency.Visible = _IsMultiCurrencyEnabled

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_BankDetails_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_BankDetails.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

                LoadEntityDetails(e.NewTab)

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub CheckBoxSetup_PaymentManager_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxSetup_PaymentManager.CheckedChanged

            TabControlPanelPaymentManager_PaymentManager.Enabled = CheckBoxSetup_PaymentManager.Checked
            TabItemBankDetails_PaymentManager.Visible = CheckBoxSetup_PaymentManager.Checked

            SearchableComboBoxPaymentManager_ExportType.SetRequired(CheckBoxSetup_PaymentManager.Checked)

            If CheckBoxSetup_PaymentManager.Checked = False Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ValidateControl(SearchableComboBoxPaymentManager_ExportType)

                End If

            End If

        End Sub
        Private Sub RadioButtonControlCheckExport_CSV_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonControlCheckExport_CSV.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub RadioButtonControlCheckExport_Fixed_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonControlCheckExport_Fixed.CheckedChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TrailerRecord_Filler1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputTrailerRecord_Filler1BeginPosition.ValueChanged, NumericInputTrailerRecord_Filler1EndPosition.ValueChanged, TextBoxTrailerRecord_Filler1FillValue.Leave

            SetFillerMaxLength(NumericInputTrailerRecord_Filler1BeginPosition, NumericInputTrailerRecord_Filler1EndPosition, TextBoxTrailerRecord_Filler1FillValue)

        End Sub
        Private Sub TrailerRecord_Filler2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputTrailerRecord_Filler2BeginPosition.ValueChanged, NumericInputTrailerRecord_Filler2EndPosition.ValueChanged, TextBoxTrailerRecord_Filler2FillValue.Leave

            SetFillerMaxLength(NumericInputTrailerRecord_Filler2BeginPosition, NumericInputTrailerRecord_Filler2EndPosition, TextBoxTrailerRecord_Filler2FillValue)

        End Sub
        Private Sub DetailRecord_Filler1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputDetailRecord_Filler1BeginPosition.ValueChanged, NumericInputDetailRecord_Filler1EndPosition.ValueChanged, CheckBoxDetailRecord_VoidFlagExport.Leave

            SetFillerMaxLength(NumericInputDetailRecord_Filler1BeginPosition, NumericInputDetailRecord_Filler1EndPosition, TextBoxDetailRecord_Filler1FillValue)

        End Sub
        Private Sub DetailRecord_Filler2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputDetailRecord_Filler2BeginPosition.ValueChanged, NumericInputDetailRecord_Filler2EndPosition.ValueChanged, TextBoxDetailRecord_Filler2FillValue.Leave

            SetFillerMaxLength(NumericInputDetailRecord_Filler2BeginPosition, NumericInputDetailRecord_Filler2EndPosition, TextBoxDetailRecord_Filler2FillValue)

        End Sub
        Private Sub HeaderRecord_Filler1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputHeaderRecord_Filler1BeginPosition.ValueChanged, NumericInputHeaderRecord_Filler1EndPosition.ValueChanged, TextBoxHeaderRecord_Filler1FillValue.Leave

            SetFillerMaxLength(NumericInputHeaderRecord_Filler1BeginPosition, NumericInputHeaderRecord_Filler1EndPosition, TextBoxHeaderRecord_Filler1FillValue)

        End Sub
        Private Sub HeaderRecord_Filler2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputHeaderRecord_Filler2BeginPosition.ValueChanged, NumericInputHeaderRecord_Filler2EndPosition.ValueChanged, TextBoxHeaderRecord_Filler2FillValue.Leave

            SetFillerMaxLength(NumericInputHeaderRecord_Filler2BeginPosition, NumericInputHeaderRecord_Filler2EndPosition, TextBoxHeaderRecord_Filler2FillValue)

        End Sub
        Private Sub TotalRecord_Filler1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputTotalRecord_Filler1BeginPosition.ValueChanged, NumericInputTotalRecord_Filler1EndPosition.ValueChanged, TextBoxTotalRecord_Filler1FillValue.Leave

            SetFillerMaxLength(NumericInputTotalRecord_Filler1BeginPosition, NumericInputTotalRecord_Filler1EndPosition, TextBoxTotalRecord_Filler1FillValue)

        End Sub
        Private Sub TotalRecord_Filler2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericInputTotalRecord_Filler2BeginPosition.ValueChanged, NumericInputTotalRecord_Filler2EndPosition.ValueChanged, TextBoxTotalRecord_Filler2FillValue.Leave

            SetFillerMaxLength(NumericInputTotalRecord_Filler2BeginPosition, NumericInputTotalRecord_Filler2EndPosition, TextBoxTotalRecord_Filler2FillValue)

        End Sub
        Private Sub SearchableComboBoxPaymentManager_ExportType_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxPaymentManager_ExportType.EditValueChanged

            If SearchableComboBoxPaymentManager_ExportType.HasASelectedValue Then

                TextBoxPaymentManager_CustomerID.Enabled = True
                TextBoxPaymentManager_Word.Enabled = True

                TextBoxPaymentManager_CustomerID.Visible = True
                TextBoxPaymentManager_Word.Visible = True

                If SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CPA" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Additional ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "SBPP" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Additional ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI2" OrElse
                        SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI3" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "COMD" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Word:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFPV" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Batch ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "AMEX" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "CARDPOOLID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ABT" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFB" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "REG" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "BOAC" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "BOAP" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "HSBC" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFBP" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ADPE" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFBP" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ACHG" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ACHR" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFBF" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CHA2" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WTB" Then

                    LabelPaymentManager_CustomerID.Text = "Destination ID:"
                    LabelPaymentManager_Word.Text = "Origination ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "PAC" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Additional ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "TCHK" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Additional ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "BOAR" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = "Origination ID:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ANCH" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "AOC" OrElse
                        SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "FAST" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "EPP" Then

                    LabelPaymentManager_CustomerID.Text = "Customer ID:"
                    LabelPaymentManager_Word.Text = ""

                    TextBoxPaymentManager_CustomerID.Enabled = True
                    TextBoxPaymentManager_Word.Enabled = False
                    TextBoxPaymentManager_Word.Visible = False

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "HSB1" Then

                    LabelPaymentManager_CustomerID.Text = "Debtor BIC:"
                    LabelPaymentManager_Word.Text = "Clearing Code:"

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "PMX" Then

                    LabelPaymentManager_CustomerID.Text = ""
                    LabelPaymentManager_Word.Text = "Account ID:"

                    TextBoxPaymentManager_CustomerID.Enabled = False
                    TextBoxPaymentManager_Word.Enabled = True

                    TextBoxPaymentManager_CustomerID.Visible = False

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CIBC" Then

                    LabelPaymentManager_CustomerID.Text = "File Creation Number:"
                    LabelPaymentManager_Word.Text = "Trans Code:"

                    TextBoxPaymentManager_CustomerID.Enabled = True
                    TextBoxPaymentManager_Word.Enabled = True

                ElseIf SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFTB" Then

                    LabelPaymentManager_CustomerID.Text = "N/A:"
                    LabelPaymentManager_Word.Text = "N/A:"
                    TextBoxPaymentManager_CustomerID.Enabled = False
                    TextBoxPaymentManager_Word.Enabled = False

                Else

                    LabelPaymentManager_CustomerID.Text = ""
                    LabelPaymentManager_Word.Text = ""

                    TextBoxPaymentManager_CustomerID.Enabled = False
                    TextBoxPaymentManager_Word.Enabled = False

                    TextBoxPaymentManager_CustomerID.Visible = False
                    TextBoxPaymentManager_Word.Visible = False

                End If

                If SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ABT" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFB" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "REG" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "BOAC" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "BOAP" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "HSBC" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFBP" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ACHG" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "ACHR" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFBF" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CHA2" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WTB" OrElse
                       SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "WFTB" Then

                    EnableDisablePaymentManagerACHSettings(True)

                Else

                    EnableDisablePaymentManagerACHSettings(False)

                    If TabItemBankDetails_PaymentManager.Tag = True Then

                        TextBoxPaymentManager_DestinationName.Text = ""
                        TextBoxPaymentManager_CompanyEntryDescription.Text = ""
                        TextBoxPaymentManager_CompanyName.Text = ""

                        If ComboBoxPaymentManager_ServiceClassCode.Items.Count > 0 Then

                            ComboBoxPaymentManager_ServiceClassCode.SelectedIndex = 0

                        End If

                        If ComboBoxPaymentManager_StandardEntryClassCode.Items.Count > 0 Then

                            ComboBoxPaymentManager_StandardEntryClassCode.SelectedIndex = 0

                        End If

                    End If

                End If

                If SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI2" OrElse SearchableComboBoxPaymentManager_ExportType.GetSelectedValue = "CSI3" Then

                    TextBoxPaymentManager_CSIUserName.Enabled = True
                    TextBoxPaymentManager_CSIPassword.Enabled = True
                    TextBoxPaymentManager_CSITargetFolder.Enabled = True
                    TextBoxPaymentManager_ComDataAccountCode.Enabled = True
                    TextBoxPaymentManager_ComDataPassword.Enabled = True

                Else

                    TextBoxPaymentManager_CSIUserName.Text = ""
                    TextBoxPaymentManager_CSIPassword.Text = ""
                    TextBoxPaymentManager_CSITargetFolder.Text = ""
                    TextBoxPaymentManager_ComDataAccountCode.Text = ""
                    TextBoxPaymentManager_ComDataPassword.Text = ""

                    TextBoxPaymentManager_CSIUserName.Enabled = False
                    TextBoxPaymentManager_CSIPassword.Enabled = False
                    TextBoxPaymentManager_CSITargetFolder.Enabled = False
                    TextBoxPaymentManager_ComDataAccountCode.Enabled = False
                    TextBoxPaymentManager_ComDataPassword.Enabled = False

                End If

            Else

                EnableDisablePaymentManagerACHSettings(False)

                If TabItemBankDetails_PaymentManager.Tag = True Then

                    TextBoxPaymentManager_DestinationName.Text = ""
                    TextBoxPaymentManager_CompanyEntryDescription.Text = ""
                    TextBoxPaymentManager_CompanyName.Text = ""

                    If ComboBoxPaymentManager_ServiceClassCode.Items.Count > 0 Then

                        ComboBoxPaymentManager_ServiceClassCode.SelectedIndex = 0

                    End If

                    If ComboBoxPaymentManager_StandardEntryClassCode.Items.Count > 0 Then

                        ComboBoxPaymentManager_StandardEntryClassCode.SelectedIndex = 0

                    End If

                End If

            End If

        End Sub
        Private Sub CheckBoxSetup_Inactive_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSetup_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxSetup_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxSetup_Inactive.Checked = Not CheckBoxSetup_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub TextBoxSetup_AccountNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSetup_AccountNumber.TextChanged

            If TextBoxSetup_AccountNumber.Focused Then

                TextBoxPaymentManager_AccountNumber.Text = TextBoxSetup_AccountNumber.Text

            End If

        End Sub
        Private Sub TextBoxPaymentManager_AccountNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPaymentManager_AccountNumber.TextChanged

            If TextBoxPaymentManager_AccountNumber.Focused Then

                TextBoxSetup_AccountNumber.Text = TextBoxPaymentManager_AccountNumber.Text

            End If

        End Sub
        Private Sub SearchableComboBoxCurrency_Currency_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxCurrency_Currency.EditValueChanged

            If (_CurrencyCode <> SearchableComboBoxCurrency_Currency.SelectedValue AndAlso
                SearchableComboBoxCurrency_Currency.SelectedValue <> Nothing AndAlso
                _CurrencyCode <> Nothing) OrElse _BankCode = Nothing Then

                LoadDropDownDataSources(True)

                'SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing
                'SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing
                'SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing
                'SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing
                'SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing

                For i As Integer = 0 To 5 ' Short Pause
                    i = i
                Next

                'If _BankCode = Nothing Then
                '    _CurrencyCode = SearchableComboBoxCurrency_Currency.SelectedValue

                '    If _IsMultiCurrencyEnabled = True Then

                '        SearchableComboBoxSetup_ServiceChargeGLAccount.Enabled = True
                '        SearchableComboBoxSetup_InterestEarnedGLAccount.Enabled = True
                '        SearchableComboBoxSetup_ARCashAccount.Enabled = True
                '        SearchableComboBoxSetup_APCashAccount.Enabled = True
                '        SearchableComboBoxSetup_APDiscAccount.Enabled = True

                '        SearchableComboBoxSetup_ServiceChargeGLAccount.Text = "[Please Select]"
                '        SearchableComboBoxSetup_InterestEarnedGLAccount.Text = "[Please Select]"
                '        SearchableComboBoxSetup_ARCashAccount.Text = "[Please Select]"
                '        SearchableComboBoxSetup_APCashAccount.Text = "[Please Select]"
                '        SearchableComboBoxSetup_APDiscAccount.Text = "[Please Select]"

                '    End If

                'End If

            End If

            If _IsMultiCurrencyEnabled AndAlso _AgencyCurrencyCode = SearchableComboBoxCurrency_Currency.SelectedValue Then

                SearchableComboBoxCurrency_ExchangeRealizedAccount.SetRequired(False)
                SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SetRequired(False)

            Else

                SearchableComboBoxCurrency_ExchangeRealizedAccount.SetRequired(_IsMultiCurrencyEnabled)
                SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SetRequired(_IsMultiCurrencyEnabled)

            End If

        End Sub
        Private Sub CheckBoxPaymentManager_UseSSL_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPaymentManager_UseSSL.CheckedChanged

            If CheckBoxPaymentManager_UseSSL.Checked Then

                ComboBoxPaymentManager_FTPSecure.Enabled = False
                ComboBoxPaymentManager_FTPSecure.SelectedIndex = 0

            Else

                ComboBoxPaymentManager_FTPSecure.Enabled = True

            End If

        End Sub
        Private Sub ButtonPaymentManager_FTPPrivateKeySelect_Click(sender As Object, e As EventArgs) Handles ButtonPaymentManager_FTPPrivateKeySelect.Click

            Dim PrivateKeyLocation As String = Nothing
            Dim PrivateKey As Byte() = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim Files() As String = Nothing
            Dim ImportFolder As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    ImportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                    If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(ImportFolder, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({FileSystem.FileFilters.PPK}), False, Files) = Windows.Forms.DialogResult.OK Then

                        If Files IsNot Nothing AndAlso Files.Count > 0 Then

                            PrivateKeyLocation = Files(0)

                        End If

                    End If

                Else

                    PrivateKeyLocation = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", "PPK files (*.ppk)|*.ppk", "")

                End If

            End Using

            If String.IsNullOrWhiteSpace(PrivateKeyLocation) = False Then

                FileStream = New System.IO.FileStream(PrivateKeyLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                BinaryReader = New System.IO.BinaryReader(FileStream)

                PrivateKey = BinaryReader.ReadBytes(CInt(New System.IO.FileInfo(PrivateKeyLocation).Length))

                ButtonPaymentManager_FTPPrivateKeySelect.Tag = PrivateKey

                TextBoxPaymentManager_FTPAddress.SetUserEntryChanged()

                'Try

                '    TextBoxSettings_AdobeSignatureFile.Text = PrivateKeyLocation

                'Catch ex As Exception

                'End Try

            End If

            EnableDisableFTPPrivateKey()

        End Sub
        Private Sub ButtonPaymentManager_FTPPrivateKeyDelete_Click(sender As Object, e As EventArgs) Handles ButtonPaymentManager_FTPPrivateKeyDelete.Click

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Try

                    ButtonPaymentManager_FTPPrivateKeySelect.Tag = Nothing

                    TextBoxPaymentManager_FTPAddress.SetUserEntryChanged()

                    'Try

                    '    TextBoxSettings_AdobeSignatureFile.Text = "Deleted"

                    'Catch ex As Exception

                    'End Try

                Catch ex As Exception

                End Try

                EnableDisableFTPPrivateKey()

            End If

        End Sub

        Private Sub TextBoxPaymentManager_FileOutputDirectory_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPaymentManager_FileOutputDirectory.TextChanged
            'PJH 07/20/21 - Added
            TextBoxPaymentManager_FTPExportFolder.Text = TextBoxPaymentManager_FileOutputDirectory.Text

        End Sub

#End Region

#End Region

    End Class

End Namespace
