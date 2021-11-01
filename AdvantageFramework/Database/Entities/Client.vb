Namespace Database.Entities

	<Table("CLIENT")>
	Public Class Client
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			Code
			Name
			Address
			Address2
			City
			County
			State
			Country
			Zip
			IsActive
			BillingAddress
			BillingAddress2
			BillingCity
			BillingCounty
			BillingState
			BillingZip
			BillingCountry
			StatementAddress
			StatementAddress2
			StatementCity
			StatementCounty
			StatementState
			StatementZip
			StatementCountry
			ARComment
			AccountNumberRequired
			CoopBillingCodeRequired
			JobLogCustom1
			JobLogCustom2
			JobLogCustom3
			JobLogCustom4
			JobLogCustom5
			JobTypeRequired
			PromotionRequired
			DueDateRequired
			ComplexityCodeRequired
			SCFormatRequired
			DepartmentCodeRequired
			MarketCodeRequired
			AlertGroupRequired
			AdNumberRequired
			ClientReferenceRequired
			DateOpenedRequired
			FormatRequired
			ProductContactRequired
			ComponentBudgetRequired
			Blackplate1Required
			Blackplate2Required
			JobCustomComponent1Required
			JobCustomComponent2Required
			JobCustomComponent3Required
			JobCustomComponent4Required
			JobCustomComponent5Required
			FiscalPeriodRequired
			CampaignCodeRequired
			OverrideAgencySettings
			TaxFlagRequired
			ProductCategoryInTimesheetRequired
			AssignProductionInvoicesBy
			ProductionAttentionLine
			ProductionFooterComments
			ProductionDaysToPay
			IsNewBusiness
			SortName
			CreditLimit
			FiscalStart
			AssignMediaInvoicesBy
			MediaAttentionLine
			MediaFooterComments
			MediaDaysToPay
			ServiceFeeTypeRequired
			RequireTimeComment
			ContractExpirationDate
			BatchName
			AvalaraSalesClassCode
			AvalaraTaxExempt
			InvoiceLocationID
			AssignComboInvoicesBy
			AssignComboInvoicesMediaOnly
            CurrencyCode
            BillerEmployeeCode
            ClientDiscountCode
            LimitTimeFunctionsToBillingHierarchy
            CalculateLateFee
            LateFeePercent
            VATNumber
            ResponsibleForMediaTrafficInstruction
            DoubleClickProfileID
            DoubleClickReportID
            DoubleClickToken
            DoubleClickEnabled
            Divisions
			StandardComment
			Jobs
			Products
			BillingRateDetails
			EmployeeTimeForecastOfficeDetailJobComponents
			Campaigns
			Ads
			ClientSortKeys
			ClientContacts
			AgencyClient
			ClientWebsites
			Associates
			MediaPlans
			AccountReceivables
			ClientCashReceipts
			MediaATBs
			DigitalResults
            Currency
            ClientDiscount
            TvUnitProductSplit
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("CL_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("CL_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("CL_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("CL_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("CL_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("CL_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("CL_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("CL_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Is Inactive", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsActive() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("CL_BADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAddress() As String
		<MaxLength(40)>
		<Column("CL_BADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAddress2() As String
		<MaxLength(30)>
		<Column("CL_BCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCity() As String
		<MaxLength(20)>
		<Column("CL_BCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCounty() As String
		<MaxLength(10)>
		<Column("CL_BSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingState() As String
		<MaxLength(10)>
		<Column("CL_BZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingZip() As String
		<MaxLength(20)>
		<Column("CL_BCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCountry() As String
		<MaxLength(40)>
		<Column("CL_SADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementAddress() As String
		<MaxLength(40)>
		<Column("CL_SADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementAddress2() As String
		<MaxLength(30)>
		<Column("CL_SCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCity() As String
		<MaxLength(20)>
		<Column("CL_SCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCounty() As String
		<MaxLength(10)>
		<Column("CL_SSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementState() As String
		<MaxLength(10)>
		<Column("CL_SZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementZip() As String
		<MaxLength(20)>
		<Column("CL_SCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCountry() As String
		<Column("CL_AR_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARComment() As String
		<Column("ACCT_NBR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumberRequired() As Nullable(Of Short)
		<Column("BILL_COOP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CoopBillingCodeRequired() As Nullable(Of Short)
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
		Public Property DepartmentCodeRequired() As Nullable(Of Short)
		<Column("MARKET_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCodeRequired() As Nullable(Of Short)
		<Column("EMAIL_GR_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertGroupRequired() As Nullable(Of Short)
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
		Public Property FormatRequired() As Nullable(Of Short)
		<Column("PROD_CONT_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductContactRequired() As Nullable(Of Short)
		<Column("JOB_COMP_BUDGET_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComponentBudgetRequired() As Nullable(Of Short)
		<Column("BLACKPLATE_VER_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Blackplate1Required() As Nullable(Of Short)
		<Column("BLACKPLATE_VER2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Blackplate2Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV1_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobCustomComponent1Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobCustomComponent2Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV3_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobCustomComponent3Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV4_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobCustomComponent4Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV5_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobCustomComponent5Required() As Nullable(Of Short)
		<Column("FISCAL_PD_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FiscalPeriodRequired() As Nullable(Of Short)
		<Column("CMP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCodeRequired() As Nullable(Of Short)
		<Column("REQ_FLDS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OverrideAgencySettings() As Nullable(Of Short)
		<Column("TAX_FLAG_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxFlagRequired() As Nullable(Of Short)
		<Column("REQ_PROD_CAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCategoryInTimesheetRequired() As Nullable(Of Short)
		<Column("CL_INV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignProductionInvoicesBy() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("CL_ATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAttentionLine() As String
		<MaxLength(60)>
		<Column("CL_FOOTER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionFooterComments() As String
		<Column("CL_P_PAYDAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionDaysToPay() As Nullable(Of Short)
		<Column("NEW_BUSINESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsNewBusiness() As Nullable(Of Short)
		<MaxLength(20)>
		<Column("CL_ALPHA_SORT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortName() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("CL_CREDIT_LIMIT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreditLimit() As Nullable(Of Decimal)
		<Column("CL_FISCAL_START")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FiscalStart() As Nullable(Of Short)
		<Column("CL_MINV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignMediaInvoicesBy() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("CL_MATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaAttentionLine() As String
		<MaxLength(60)>
		<Column("CL_MFOOTER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaFooterComments() As String
		<Column("CL_M_PAYDAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaDaysToPay() As Nullable(Of Short)
		<Column("SERVICE_FEE_TYPE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeTypeRequired() As Nullable(Of Short)
		<Required>
		<Column("REQ_TIME_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RequireTimeComment() As Boolean
		<Column("CONTRACT_EXP_DT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContractExpirationDate() As Nullable(Of Date)
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String
		<MaxLength(6)>
		<Column("AVALARA_SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AvalaraSalesClassCode() As String
		<Column("AVALARA_TAX_EXEMPT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AvalaraTaxExempt() As Nullable(Of Boolean)
		<MaxLength(6)>
		<Column("INVOICE_LOCATION_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceLocationID() As String
		<Column("COMBO_INV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignComboInvoicesBy() As Nullable(Of Short)
		<Required>
		<Column("COMBO_MEDIA_ONLY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignComboInvoicesMediaOnly() As Boolean
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyCode() As String
        <MaxLength(6)>
        <Column("BILLER_EMP_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillerEmployeeCode() As String
        <MaxLength(6)>
        <Column("CLIENT_DISCOUNT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDiscountCode() As String
        <Required>
        <Column("LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LimitTimeFunctionsToBillingHierarchy() As Boolean
        <Column("TV_UNIT_PRODUCT_SPLIT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TvUnitProductSplit() As Boolean
        <Column("CALC_LATE_FEE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalculateLateFee() As Boolean
        <Column("LATE_FEE_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(5, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LateFeePercent() As Nullable(Of Decimal)
        <Column("AUTOMATED_ASSIGNMENT_JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AutomatedAssignmentJobNumber() As Nullable(Of Integer)
        <Column("AUTOMATED_ASSIGNMENT_JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AutomatedAssignmentJobComponentNumber() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("VAT_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VATNumber() As String
        <Required>
        <Column("RESP_FOR_MEDIA_TRAFFIC_INSTRUCTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ResponsibleForMediaTrafficInstruction() As Boolean
        <Column("DC_PROFILE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DoubleClickProfileID() As Nullable(Of Long)
        <Column("DC_REPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DoubleClickReportID() As Nullable(Of Long)
        <Column("DC_OAUTH2_TOKEN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DoubleClickToken() As String
        <Required>
        <Column("DC_ENABLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DoubleClickEnabled() As Boolean

        Public Overridable Property Divisions As ICollection(Of Database.Entities.Division)
        Public Overridable Property StandardComment As ICollection(Of Database.Entities.StandardComment)
        Public Overridable Property Jobs As ICollection(Of Database.Entities.Job)
        Public Overridable Property Products As ICollection(Of Database.Entities.Product)
        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property Campaigns As ICollection(Of Database.Entities.Campaign)
        Public Overridable Property Ads As ICollection(Of Database.Entities.Ad)
        Public Overridable Property ClientSortKeys As ICollection(Of Database.Entities.ClientSortKey)
        Public Overridable Property ClientContacts As ICollection(Of Database.Entities.ClientContact)
        <ForeignKey("Code")>
        Public Overridable Property AgencyClient As Database.Entities.AgencyClient
        Public Overridable Property ClientWebsites As ICollection(Of Database.Entities.ClientWebsite)
        Public Overridable Property Associates As ICollection(Of Database.Entities.Associate)
        Public Overridable Property MediaPlans As ICollection(Of Database.Entities.MediaPlan)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property ClientCashReceipts As ICollection(Of Database.Entities.ClientCashReceipt)
        Public Overridable Property MediaATBs As ICollection(Of Database.Entities.MediaATB)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property Currency As Database.Entities.Currency
        Public Overridable Property ClientDiscount As Database.Entities.ClientDiscount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Client.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Clients
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique client code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
