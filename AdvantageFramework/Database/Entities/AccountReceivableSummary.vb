Namespace Database.Entities

	<Table("AR_SUMMARY")>
	Public Class AccountReceivableSummary
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ARInvoiceNumber
			ARInvoiceSequence
			ARType
			BillingCoopCode
			BillingCoopPercent
			IsManual
			OrderNumber
			OrderLineNumber
			MediaType
			JobNumber
			JobComponentNumber
			JobIsAdvanceBilling
			ARDescription
			ClientCode
			DivisionCode
			ProductCode
			OfficeCode
			SalesClassCode
			CampaignID
			ClientPO
			FunctionCode
			FunctionType
			SalesPostPeriodCode
			SalesTaxCode
			InvTaxFlag
			InvBy
			BillCommNet
			AdvanceBillingRecFlag
			MediaRecFlag
			Hours
			AccountsReceivableGLACode
			SalesGLACode
			DeferredSalesGLACode
			CostOfSalesGLACode
			DeferredCostOfSalesGLACode
			AccruedAccountsPayableGLACode
			AccruedCostOfSalesGLACode
			WorkInProgressGLACode
			StateGLACode
			CountyGLACode
			CityGLACode
			MediaMonth
			MediaYear
			StartDate
			EndDate
			EmployeeTimeAmount
			IncomeOnlyAmount
			CommissionAmount
			RebateAmount
			CostAmount
			NetChargeAmount
			VendorTax
			DiscountAmount
			AdditionalAmount
			AdvanceBillingCostAmount
			AdvanceBillingIncomeAmount
			AdvanceBillingCommissionAmount
			AdvanceBillingSaleAmount
			CityTaxAmount
			CountyTaxAmount
			StateTaxAmount
			TotalBillAmount
			GLTransaction
			GLTransactionDeferred
			IsModified
			IsDiffApplied
			IsConverted
			AvaTaxKey
			IsAvaTaxPosted

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("AR_SUMMARY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Column("AR_INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceNumber() As Nullable(Of Integer)
		<Column("AR_INV_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceSequence() As Nullable(Of Short)
		<MaxLength(2)>
		<Column("AR_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARType() As String
		<MaxLength(6)>
		<Column("COOP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCoopCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 4)>
        <Column("COOP_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCoopPercent() As Nullable(Of Decimal)
		<Column("MANUAL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsManual() As Nullable(Of Boolean)
		<Column("ORDER_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<Column("ORDER_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineNumber() As Nullable(Of Short)
		<MaxLength(1)>
		<Column("MEDIA_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("JOB_AB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobIsAdvanceBilling() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("AR_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARDescription() As String
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassCode() As String
		<Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignID() As Nullable(Of Integer)
		<MaxLength(40)>
		<Column("CLIENT_PO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientPO() As String
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionCode() As String
		<MaxLength(1)>
		<Column("FNC_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionType() As String
		<MaxLength(6)>
		<Column("SALE_POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesPostPeriodCode() As String
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesTaxCode() As String
		<Column("INV_TAX_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvTaxFlag() As Nullable(Of Boolean)
		<Column("INV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvBy() As Nullable(Of Short)
		<Column("BILL_COMM_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillCommNet() As Nullable(Of Short)
		<Column("AB_REC_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdvanceBillingRecFlag() As Nullable(Of Short)
		<Column("MED_REC_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaRecFlag() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("HRS_QTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Hours() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("GL_ACCT_AR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountsReceivableGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_SALE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_DEF_SALE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeferredSalesGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_DEF_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeferredCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_ACC_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccruedAccountsPayableGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_ACC_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccruedCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_WIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WorkInProgressGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StateGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CountyGLACode() As String
		<MaxLength(30)>
		<Column("GL_ACCT_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CityGLACode() As String
		<Column("MEDIA_MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMonth() As Nullable(Of Byte)
        <Column("MEDIA_YEAR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaYear() As Nullable(Of Short)
		<Column("START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("EMP_TIME_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("INC_ONLY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncomeOnlyAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("COMMISSION_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("COST_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("NET_CHARGE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("NON_RESALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("ADDITIONAL_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdditionalAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("AB_COST_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingCostAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("AB_INC_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingIncomeAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("AB_COMMISSION_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingCommissionAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("AB_SALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillingSaleAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CITY_TAX_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("CNTY_TAX_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("STATE_TAX_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(18, 2)>
        <Column("TOTAL_BILL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalBillAmount() As Nullable(Of Decimal)
		<Column("GL_XACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GL_XACT_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransactionDeferred() As Nullable(Of Integer)
		<Column("MODIFIED_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsModified() As Nullable(Of Boolean)
		<Column("DIFF_APPLIED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsDiffApplied() As Nullable(Of Boolean)
		<Column("CONVERTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsConverted() As Nullable(Of Boolean)
		<MaxLength(50)>
		<Column("AVATAX_KEY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AvaTaxKey() As String
		<Column("AVATAX_POSTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAvaTaxPosted() As Nullable(Of Boolean)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
