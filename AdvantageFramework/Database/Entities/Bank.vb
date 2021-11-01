Namespace Database.Entities

	<Table("BANK")>
	Public Class Bank
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Description
			AccountNumber
			LastComputerCheck
			LastManualCheck
			ARCashAccount
			APCashAccount
			APDiscAccount
			EndingBalance
			InterestEarnedGLAccount
			ServiceChargeGLAccount
			ImportFileName
			CheckNumberColumnStart
			CheckNumberLength
			CheckAmountColumnStart
			CheckAmountLength
			CheckAmountNumberOfDecimals
			OfficeCode
			IsInactive
			CheckFormat
            CheckAmountInWords
            CheckStubLinesUp
            CheckBodyLinesDown
            CurrencyCode
			APCurrencyCash
			ARCurrencyCash
			APForeignCurrencyCashExchangeAccount
			ARForeignCurrencyCashExchangeAccount
			ExchangeConversionAccount
			RoutingNumber
			CheckTemplateID
			ACHCompanyID
			PaymentManager
			PaymentManagerID
			PaymentManagerWord
			PaymentManagerFTP
			PaymentManagerDirectory
			PaymentManagerType
			CSIUserName
			CSIPassword
			CSITargetFolder
			ComDataAccountCode
			ComDataPassword
			PaymentManagerACHDestinationName
			PaymentManagerACHServiceClassCode
			PaymentManagerACHCompanyName
			PaymentManagerACHStandardEntryClassCode
            PaymentManagerACHCompanyEntryDescription
            CurrencyExchangeUnrealizedGLAccount
            DigitalSignatureActive
            DigitalSignatureText
            DigitalSignatureFont
            DigitalSignatureFontSize
            AccountPayablePayments
			GeneralLedgerAccount5
			GeneralLedgerAccount3
			GeneralLedgerAccount7
			GeneralLedgerAccount2
			GeneralLedgerAccount4
			GeneralLedgerAccount6
			GeneralLedgerAccount8
			GeneralLedgerAccount
			CheckRegisters
			BankExportSpec
			ClientCashReceipts
            OtherCashReceipts
            PaymentManagerFTPUsername
            PaymentManagerFTPPassword
            PaymentManagerFTPFolder
            PaymentManagerFTPAddress
            PaymentManagerFTPPort
            PaymentManagerFTPExportFolder
            PaymentManagerFTPSSL
            PaymentManagerFTPSSLMode
            PaymentManagerFTPPrivateKey
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
		<Column("BK_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("BK_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(20)>
		<Column("BK_ACCOUNT_NO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumber() As String
		<Column("BK_LAST_CHECK_COMP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="d9")>
		Public Property LastComputerCheck() As Nullable(Of Integer)
		<Column("BK_LAST_CHECK_MAN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="d9")>
		Public Property LastManualCheck() As Nullable(Of Integer)
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_AR_CASH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ARCashAccount() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_AP_CASH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property APCashAccount() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_AP_DISC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property APDiscAccount() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("ENDING_BALANCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndingBalance() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("GLACODE_IE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property InterestEarnedGLAccount() As String
		<MaxLength(30)>
		<Column("GLACODE_SC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ServiceChargeGLAccount() As String
		<MaxLength(12)>
		<Column("IMPORT_FILE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportFileName() As String
		<Column("CHECK_NBR_BEGIN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckNumberColumnStart() As Nullable(Of Short)
		<Column("CHECK_NBR_LENGTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckNumberLength() As Nullable(Of Short)
		<Column("CHECK_AMT_BEGIN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountColumnStart() As Nullable(Of Short)
		<Column("CHECK_AMT_LENGTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d3")>
		Public Property CheckAmountLength() As Nullable(Of Short)
		<Column("CHECK_AMT_DEC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d2")>
		Public Property CheckAmountNumberOfDecimals() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("CHECK_FORMAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckFormat() As Nullable(Of Short)
		<Column("WORD_CHECK_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmountInWords() As Nullable(Of Short)
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyCode() As String
		<MaxLength(30)>
		<Column("CRNCY_GL_AP_CASH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APCurrencyCash() As String
		<MaxLength(30)>
		<Column("CRNCY_GL_AR_CASH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARCurrencyCash() As String
		<MaxLength(30)>
		<Column("CRNCY_GL_AP_CASH_FRN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APForeignCurrencyCashExchangeAccount() As String
		<MaxLength(30)>
		<Column("CRNCY_GL_AR_CASH_FRN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARForeignCurrencyCashExchangeAccount() As String
		<MaxLength(30)>
		<Column("CRNCY_GL_EXCHG", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExchangeConversionAccount() As String
		<Column("BK_ROUTING_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d11")>
		Public Property RoutingNumber() As Nullable(Of Long)
		<Column("CHK_TEMPLATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d9")>
		Public Property CheckTemplateID() As Nullable(Of Long)
		<MaxLength(10)>
		<Column("ACH_COMPANY_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ACHCompanyID() As String
		<Column("PYMT_MGR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManager() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("PYMT_MGR_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerID() As String
		<MaxLength(50)>
		<Column("PYMT_MGR_WORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerWord() As String
		<MaxLength(254)>
		<Column("PYMT_MGR_FTP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerFTP() As String
		<MaxLength(100)>
		<Column("PYMT_MGR_DIR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerDirectory() As String
		<MaxLength(4)>
		<Column("PYMT_MGR_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerType() As String
		<MaxLength(250)>
		<Column("CSI_USERNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CSIUserName() As String
		<MaxLength(250)>
		<Column("CSI_PASSWORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CSIPassword() As String
		<MaxLength(250)>
		<Column("CSI_TARGET_FOLDER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CSITargetFolder() As String
		<MaxLength(250)>
		<Column("COMDATA_ACCOUNT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComDataAccountCode() As String
		<MaxLength(250)>
		<Column("COMDATA_PASSWORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComDataPassword() As String
		<MaxLength(30)>
		<Column("ACH_DESTINATION_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerACHDestinationName() As String
		<MaxLength(3)>
		<Column("ACH_SERVICE_CLASS_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerACHServiceClassCode() As String
		<MaxLength(30)>
		<Column("ACH_COMPANY_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerACHCompanyName() As String
		<MaxLength(3)>
		<Column("ACH_STD_ENTRY_CLASS_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentManagerACHStandardEntryClassCode() As String
		<MaxLength(10)>
		<Column("ACH_COMPANY_ENTRY_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerACHCompanyEntryDescription() As String
        <Column("CHK_STUB_LINES_UP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckStubLinesUp() As Nullable(Of Short)
        <Column("CHK_BODY_LINES_DN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckBodyLinesDown() As Nullable(Of Short)
        <Column("CRNCY_GL_EXCHG_UNREALIZED", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyExchangeUnrealizedGLAccount() As String
        <Column("CHK_SIGNATURE_ACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DigitalSignatureActive() As Boolean
        <MaxLength(100)>
        <Column("CHK_SIGNATURE_TEXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DigitalSignatureText() As String
        <MaxLength(100)>
        <Column("CHK_SIGNATURE_FONT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DigitalSignatureFont() As String
        <Column("CHK_SIGNATURE_FONT_SIZE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DigitalSignatureFontSize() As Nullable(Of Integer)

        <MaxLength(250)>
        <Column("PMT_FTP_USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPUsername() As String
        <MaxLength(250)>
        <Column("PMT_FTP_PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPPassword() As String
        <MaxLength(250)>
        <Column("PMT_FTP_FOLDER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPFolder() As String
        <Column("PMT_FTP_ADDRESS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPAddress() As String
        <Column("PMT_FTP_PORT", TypeName:="smallint")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPPort() As Nullable(Of Short)
        <MaxLength(250)>
        <Column("PMT_FTP_EXPORT_FOLDER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPExportFolder() As String
        <Column("PMT_FTP_SSL", TypeName:="bit")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPSSL() As Boolean
        <Column("PMT_FTP_SSL_MODE", TypeName:="smallint")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPSSLMode() As Short
        <Column("PMT_FTP_PRIVATE_KEY", TypeName:="varbinary(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PaymentManagerFTPPrivateKey() As Byte()

        Public Overridable Property AccountPayablePayments As ICollection(Of Database.Entities.AccountPayablePayment)
        Public Overridable Property CheckRegisters As ICollection(Of Database.Entities.CheckRegister)
        Public Overridable Property BankExportSpec As Database.Entities.BankExportSpec
        Public Overridable Property ClientCashReceipts As ICollection(Of Database.Entities.ClientCashReceipt)
        Public Overridable Property OtherCashReceipts As ICollection(Of Database.Entities.OtherCashReceipt)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Bank.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Banks
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique bank code."

                        End If

                    End If

            End Select

            If IsValid = False AndAlso (PropertyName = AdvantageFramework.Database.Entities.Bank.Properties.LastManualCheck.ToString OrElse _
                                        PropertyName = AdvantageFramework.Database.Entities.Bank.Properties.LastComputerCheck.ToString) Then

                If Value = 0 Then

                    IsValid = True
                    ErrorText = ""

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
