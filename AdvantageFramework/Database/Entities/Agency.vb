Namespace Database.Entities

	<Table("AGENCY")>
	Public Class Agency
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Name
			Address
			Address2
			City
			State
			Zip
			SMTPServer
			SMTPUserName
			SMTPPassword
			EmailUserName
			EmailPassword
			UseSMTPToSendPDF
			ITContactEmail
			WeeklyTimeType
			FileSystemDirectory
			FileSystemDomain
			FileSystemUserName
			FileSystemPassword
			StandardHours
			SMTPAuthenticationMethodType
			SMTPPortNumber
			ReplyToEmail
			SMTPSecurityType
			MailBeeLicenseKey
			UseEmployeeLogin
			UseEmployeeEmail
			POP3Server
			POP3PortNumber
			POP3UserName
			POP3Password
			POP3DeleteMessages
			EmployeeNote
			POP3AuthenticationMethod
			POP3SecureType
			POP3DefaultReplyToEmail
			WebvantageURL
			IsASP
			LicenseKey
			ServiceFeeTypeRequired
			Phone
			Country
			ActivateSystemAlerts
			IncludeAlertGroups
			IncludeAttachmentsWithAlerts
			EnableAlertNotification
			ExcludeAttachmentByDefault
			OfficeCodeOverride
			UseGLFilter
			EnableAttachmentsInJobJacket
			JobComponentTaxable
			RequireNewRevisions
			HideNonBillableFlag
			ApprovedEstimateRequired
			QVAQuery
			EditJobRequiredEstimate
			QuoteApprovalPasswordRequired
			POAmountRequired
			DefaultAlertGroup
			ClientContactOption
			EstimateDefaultComments
			POFooterComments
			APViewDeletedInvoices
			ValidateJobClose
			APFlagVendor1099
			APCalculatePOBalance
			APLimitByOffice
			APNonClientGLDetail
			InterCompanyTransactions
			APLockGLAccountCode
			APShowPayToInformation
			PrintVendorAccountNumber
			ShowARDescription
			RequireProductSetupComplete
			APComputerCheckFormat
			CheckAmountInWords
			CurrencySymbol
			CurrencyText
			CoinText
			APPOMessage
			APPOReject
			AdjustCheckStubLinesUp
			AdjustCheckBodyLinesDown
			APPOMessageText
			APPORejectText
			ActivateApprovals
			InternetPercent
			PrintMediaPercent
			OutOfHomePercent
			TelevisionPercent
			RadioPercent
			CopyTimesheetFeature
			UseBatchMethod
			EnableStartEndTimeRealTIME
			TimeCommentsRequired
			CheckClosedPeriods
			SupervisorCanEditTime
			EnableProductCategory
			AutoAlertSupervisor
			SupervisorApprovalActive
			EmailITContact
			EmailSupervisor
			NFusionDatasourceName
			StrataConnectPath
			ImportPath
			RenameFinanceFile
			UseAPAccountOnImport
			InternetFooterComments
			RadioFooterComments
			TelevisionFooterComments
			NewspaperFooterComments
			MagazineFooterComments
			OutOfHomeFooterComments
			CurrencyRateImportType
			IncomeOnlyImportType
			AccountPayableImportType
			JobLogCustom1
			JobLogCustom2
			JobLogCustom3
			JobLogCustom4
			JobLogCustom5
			JobComponentCustom1
			JobComponentCustom2
			JobComponentCustom3
			JobComponentCustom4
			JobComponentCustom5
			AccountNumberRequired
			JobTypeRequired
			PromotionRequired
			DueDateRequired
			ComplexityCodeRequired
			SCFormatRequired
			DepartmentTeamRequired
			MarketCodeRequired
			AlertGroupRequired
			CoopBillingCodeRequired
			AdNumberRequired
			ClientReferenceRequired
			DateOpenedRequired
			FormatAdSizeRequired
			ProductContactRequired
			ComponentBudgetRequired
			TaxFlagRequired
			Blackplate1Required
			Blackplate2Required
			CampaignCodeRequired
			FiscalPeriodRequired
			DefaultDisplayDays
			MediaImportDefault
			AccessReportTemporaryPath
			AccessReportPath
			UniqueClientReference
			HomeCurrency
			UseMultipleCurrencies
			County
			AllowCostOfSaleEntry
			InvoiceTaxFlag
			DatabaseServerTimeZoneID
			TimeZoneID
            CDPOverride
            ClientPortalURL
            AllowProofHQ
            ProofingURL

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(40)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(20)>
		<Column("CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(10)>
		<Column("STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(10)>
		<Column("ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(50)>
		<Column("SMTP_SERVER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPServer() As String
        <MaxLength(100)>
        <Column("SMTP_SENDER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPUserName() As String
        <MaxLength(100)>
        <Column("SMTP_SENDER_PWD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPPassword() As String
        <MaxLength(100)>
        <Column("EMAIL_USERNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailUserName() As String
        <Column("EMAIL_PWD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailPassword() As String
		<Column("USE_SMTP_FOR_PDF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseSMTPToSendPDF() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("IT_CONTACT_EMAIL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ITContactEmail() As String
		<Column("WEEKLY_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WeeklyTimeType() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("DOC_REPOSITORY_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileSystemDirectory() As String
		<MaxLength(30)>
		<Column("DOC_REPOSITORY_USER_DOMAIN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileSystemDomain() As String
		<MaxLength(50)>
		<Column("DOC_REPOSITORY_USER_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileSystemUserName() As String
        <MaxLength(100)>
        <Column("DOC_REPOSITORY_USER_PASSWORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileSystemPassword() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<Column("TRF_HRS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StandardHours() As Nullable(Of Decimal)
		<Column("SMTP_AUTH_METHOD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPAuthenticationMethodType() As Nullable(Of Short)
		<Column("SMTP_PORT_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPPortNumber() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("EMAIL_REPLY_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReplyToEmail() As String
		<Column("SMTP_SECURE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SMTPSecurityType() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("MB_KEY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MailBeeLicenseKey() As String
		<Column("SMTP_USE_EMP_LOGIN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseEmployeeLogin() As Nullable(Of Short)
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<Column("SMTP_USE_EMP_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseEmployeeEmail() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("POP3_SERVER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3Server() As String
		<Column("POP3_PORT_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3PortNumber() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("POP3_USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property POP3UserName() As String
        <Column("POP3_PWD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3Password() As String
		<Column("POP3_DEL_PROCESSED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3DeleteMessages() As Nullable(Of Short)
		<Required>
		<Column("EMP_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeNote() As Short
		<Column("POP3_AUTH_METHOD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3AuthenticationMethod() As Nullable(Of Short)
		<Column("POP3_SECURE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3SecureType() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("POP3_REPLY_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POP3DefaultReplyToEmail() As String
		<MaxLength(254)>
		<Column("WEBVANTAGE_URL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WebvantageURL() As String
		<Column("ASP_ACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsASP() As Nullable(Of Short)
		<MaxLength(8000)>
		<Column("LICENSE_KEY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LicenseKey() As String
		<Column("SERVICE_FEE_TYPE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeTypeRequired() As Nullable(Of Short)
		<MaxLength(13)>
		<Column("PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Phone() As String
		<MaxLength(10)>
		<Column("COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country() As String
		<Column("AUTO_EMAIL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ActivateSystemAlerts() As Nullable(Of Short)
		<Column("EMP_ON_ALERT_LIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeAlertGroups() As Nullable(Of Short)
		<Column("PDF_ALERT_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeAttachmentsWithAlerts() As Nullable(Of Short)
		<Column("ALERT_NOTIFY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnableAlertNotification() As Nullable(Of Short)
		<Column("EMAIL_ATTACH_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExcludeAttachmentByDefault() As Nullable(Of Short)
		<Column("EDIT_OFFICE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCodeOverride() As Nullable(Of Short)
		<Column("GL_FILTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseGLFilter() As Nullable(Of Short)
		<Column("ENABLE_ATTACHMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnableAttachmentsInJobJacket() As Nullable(Of Short)
		<Column("FLAG_TAX_JOBS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentTaxable() As Nullable(Of Short)
		<Column("AUTO_EST_REV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RequireNewRevisions() As Nullable(Of Short)
		<Column("NOBILL_FLAG_H")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HideNonBillableFlag() As Nullable(Of Short)
		<Column("APPR_EST_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedEstimateRequired() As Nullable(Of Short)
		<Column("QVA_QUERY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property QVAQuery() As Nullable(Of Short)
		<Column("EDIT_JOB_REQ_EST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EditJobRequiredEstimate() As Nullable(Of Short)
		<Column("QA_PWD_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property QuoteApprovalPasswordRequired() As Nullable(Of Short)
		<Column("PO_AMT_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POAmountRequired() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("DEF_EMAIL_GROUP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultAlertGroup() As String
		<Column("CONTACT_OPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactOption() As Nullable(Of Short)
		<Column("EST_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateDefaultComments() As String
		<Column("PO_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POFooterComments() As String
		<Column("DELETE_INVOICE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APViewDeletedInvoices() As Nullable(Of Short)
		<Column("VALIDATE_JOB_CLOSE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ValidateJobClose() As Nullable(Of Short)
		<Column("FLAG_1099")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APFlagVendor1099() As Nullable(Of Short)
		<Column("AP_CALC_PO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APCalculatePOBalance() As Nullable(Of Short)
		<Column("AP_OFFICE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APLimitByOffice() As Nullable(Of Short)
		<Column("NON_CLIENT_GL_DET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APNonClientGLDetail() As Nullable(Of Short)
		<Column("INTER_COMPANY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InterCompanyTransactions() As Nullable(Of Short)
		<Column("AP_LOCK_GLCODE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APLockGLAccountCode() As Nullable(Of Short)
		<Column("VN_PAY_TO_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APShowPayToInformation() As Nullable(Of Short)
		<Column("VN_ACCT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintVendorAccountNumber() As Nullable(Of Short)
		<Column("CR_AR_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowARDescription() As Nullable(Of Short)
		<Column("BILL_MEDIA_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RequireProductSetupComplete() As Nullable(Of Short)
		<Column("CHECK_FORMAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APComputerCheckFormat() As Nullable(Of Short)
		<Column("WORD_CHECK_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckAmountInWords() As Nullable(Of Short)
		<MaxLength(3)>
		<Column("CURRENCY_SYMBOL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencySymbol() As String
		<MaxLength(20)>
		<Column("CURRENCY_TEXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyText() As String
		<MaxLength(20)>
		<Column("COIN_TEXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CoinText() As String
		<Column("AP_PO_MESSAGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APPOMessage() As Nullable(Of Short)
		<Column("AP_PO_REJECT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APPOReject() As Nullable(Of Short)
		<Column("CHK_STUB_LINES_UP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdjustCheckStubLinesUp() As Nullable(Of Short)
		<Column("CHK_BODY_LINES_DN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdjustCheckBodyLinesDown() As Nullable(Of Short)
		<MaxLength(150)>
		<Column("AP_PO_MESSAGE_TEXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APPOMessageText() As String
		<MaxLength(150)>
		<Column("AP_PO_REJECT_TEXT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APPORejectText() As String
		<Column("AP_APPROVAL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ActivateApprovals() As Nullable(Of Short)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
		<Column("AP_APP_INET_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetPercent() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
		<Column("AP_APP_PRINT_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintMediaPercent() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
		<Column("AP_APP_OOH_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomePercent() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
		<Column("AP_APP_TV_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelevisionPercent() As Nullable(Of Decimal)
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
		<Column("AP_APP_RADIO_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioPercent() As Nullable(Of Decimal)
		<Column("COPY_TS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CopyTimesheetFeature() As Nullable(Of Short)
		<Column("ET_BATCH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseBatchMethod() As Nullable(Of Short)
		<Column("START_END_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnableStartEndTimeRealTIME() As Nullable(Of Short)
		<Column("TIME_COMMENTS_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TimeCommentsRequired() As Nullable(Of Short)
		<Column("TS_PPERIOD_CHK")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckClosedPeriods() As Nullable(Of Short)
		<Column("EDIT_OTHER_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SupervisorCanEditTime() As Nullable(Of Short)
		<Column("USE_PROD_CAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EnableProductCategory() As Nullable(Of Short)
		<Column("AUTO_ALERT_SUPER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AutoAlertSupervisor() As Nullable(Of Short)
		<Column("TIME_APPR_ACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SupervisorApprovalActive() As Nullable(Of Short)
		<Column("EMAIL_IT_CONTACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailITContact() As Nullable(Of Short)
		<Column("EMAIL_SUPERVISOR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailSupervisor() As Nullable(Of Short)
		<MaxLength(32)>
		<Column("MRP_DSN", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NFusionDatasourceName() As String
		<MaxLength(254)>
		<Column("STRATA_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StrataConnectPath() As String
		<MaxLength(254)>
		<Column("IMPORT_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportPath() As String
		<Column("MD_RENAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RenameFinanceFile() As Nullable(Of Short)
		<Column("AP_ACCT_OFF_IMP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseAPAccountOnImport() As Nullable(Of Short)
		<Column("INET_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetFooterComments() As String
		<Column("RADIO_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioFooterComments() As String
		<Column("TV_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TelevisionFooterComments() As String
		<Column("NEWS_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperFooterComments() As String
		<Column("MAG_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineFooterComments() As String
		<Column("OTDR_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomeFooterComments() As String
		<MaxLength(15)>
		<Column("CRNCY_IMPORT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyRateImportType() As String
		<MaxLength(15)>
		<Column("IO_IMPORT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncomeOnlyImportType() As String
		<MaxLength(15)>
		<Column("AP_IMPORT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableImportType() As String
		<Column("JOB_LOG_UDV1_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobLogCustom1() As Nullable(Of Short)
		<Column("JOB_LOG_UDV2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobLogCustom2() As Nullable(Of Short)
		<Column("JOB_LOG_UDV3_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobLogCustom3() As Nullable(Of Short)
		<Column("JOB_LOG_UDV4_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobLogCustom4() As Nullable(Of Short)
		<Column("JOB_LOG_UDV5_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobLogCustom5() As Nullable(Of Short)
		<Column("JOB_CMP_UDV1_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentCustom1() As Nullable(Of Short)
		<Column("JOB_CMP_UDV2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentCustom2() As Nullable(Of Short)
		<Column("JOB_CMP_UDV3_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentCustom3() As Nullable(Of Short)
		<Column("JOB_CMP_UDV4_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentCustom4() As Nullable(Of Short)
		<Column("JOB_CMP_UDV5_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentCustom5() As Nullable(Of Short)
		<Column("ACCT_NBR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumberRequired() As Nullable(Of Short)
		<Column("JT_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobTypeRequired() As Nullable(Of Short)
		<Column("PROMO_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PromotionRequired() As Nullable(Of Short)
		<Column("JOB_FIRST_USE_DT_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DueDateRequired() As Nullable(Of Short)
		<Column("COMPLEX_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComplexityCodeRequired() As Nullable(Of Short)
		<Column("FORMAT_SC_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SCFormatRequired() As Nullable(Of Short)
		<Column("DP_TM_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentTeamRequired() As Nullable(Of Short)
		<Column("MARKET_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCodeRequired() As Nullable(Of Short)
		<Column("EMAIL_GR_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertGroupRequired() As Nullable(Of Short)
		<Column("BILL_COOP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CoopBillingCodeRequired() As Nullable(Of Short)
		<Column("AD_NBR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdNumberRequired() As Nullable(Of Short)
		<Column("JOB_CLI_REF_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientReferenceRequired() As Nullable(Of Short)
		<Column("JOB_DATE_OPENED_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateOpenedRequired() As Nullable(Of Short)
		<Column("JOB_AD_SIZE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FormatAdSizeRequired() As Nullable(Of Short)
		<Column("PROD_CONT_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductContactRequired() As Nullable(Of Short)
		<Column("JOB_COMP_BUDGET_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComponentBudgetRequired() As Nullable(Of Short)
		<Column("TAX_FLAG_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxFlagRequired() As Nullable(Of Short)
		<Column("BLACKPLATE_VER_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Blackplate1Required() As Nullable(Of Short)
		<Column("BLACKPLATE_VER2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Blackplate2Required() As Nullable(Of Short)
		<Column("CMP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCodeRequired() As Nullable(Of Short)
		<Column("FISCAL_PD_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FiscalPeriodRequired() As Nullable(Of Short)
		<Column("TS_DAYS_PER_WK")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultDisplayDays() As Nullable(Of Short)
		<MaxLength(2)>
		<Column("MD_INTERFACE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaImportDefault() As String
		<MaxLength(254)>
		<Column("ACCESS_TMP_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccessReportTemporaryPath() As String
		<MaxLength(254)>
		<Column("ACCESS_RPT_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccessReportPath() As String
		<Column("CLIENT_REF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UniqueClientReference() As Nullable(Of Short)
		<MaxLength(5)>
		<Column("HOME_CRNCY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HomeCurrency() As String
		<Column("MULTI_CRNCY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseMultipleCurrencies() As Nullable(Of Short)
		<MaxLength(20)>
		<Column("COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<Required>
		<Column("COS_ENTRY_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AllowCostOfSaleEntry() As Short
		<Required>
		<Column("INV_TAX_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceTaxFlag() As Boolean
		<Column("DB_TIMEZONE_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DatabaseServerTimeZoneID() As String
        <Column("TIMEZONE_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeZoneID() As String
        <Column("EDIT_CDP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CDPOverride() As Nullable(Of Short)
        <MaxLength(254)>
        <Column("CLIENTPORTAL_URL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPortalURL() As String
        <Column("TIME_REQ_ASSN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimesheetRequireAssignment() As Boolean?
        <Column("TIME_UNIQUE_ROW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimesheetAddUniqueRowWhenComment() As Boolean?
        <Column("ALLOW_PROOFHQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowProofHQ() As Boolean?
        <MaxLength(256)>
        <Column("PROOFING_URL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProofingURL() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name.ToString

        End Function

#End Region

	End Class

End Namespace
