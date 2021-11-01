Namespace Database.Entities

	<Table("JOB_COMPONENT")>
	Public Class JobComponent
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			JobNumber
			Number
			AccountExecutiveEmployeeCode
			CreatedDate
			DueDate
			StartDate
			CreativeInstructions
			Description
			Comment
			BudgetAmount
			EstimateNumber
			EstimateComponentNumber
			DeleteInstruction
			JobTypeCode
			IsNonbillable
			AlertGroupCode
			MarketCode
			ID
			JobTemplateCode
			JobSpecType
			JobProcessNumber
			AdNumber
			AccountNumber
			DepartmentTeamCode
			ClientContactID
			ServiceFeeTypeID
			FiscalPeriodCode
			TaxFlag
			TaxCode
			BlackplateCode1
			BlackplateCode2
			JobComponentUserDefinedValue1Code
			JobComponentUserDefinedValue2Code
			JobComponentUserDefinedValue3Code
			JobComponentUserDefinedValue4Code
			JobComponentUserDefinedValue5Code
			MarkupPercent
			IsAdvanceBilling
			AlertAssignmentTemplateID
			TrafficScheduleBy
			TrafficScheduleRequired
			IsJobBillHold
			BillingUserCode
			BillingApprovalBatchID
			SelectedBillingApprovalID
			BillingCommandCenterID
			ServiceFeeFlag
			ProductionAdvancedBillingIncome
            MediaBillDate
            ClientDiscountCode
            Job
			EmployeeNonTasks
			EmployeeTimeForecastOfficeDetailJobComponents
			EstimateApprovals
			JobComponentTasks
			Ad
			Account
			ClientContact
			ServiceFeeType
			FiscalPeriod
			Market
			Document
			Blackplate2
			Blackplate1
			EmployeeTimeDetails
			JobComponentUserDefinedValue1
			JobComponentUserDefinedValue2
			JobComponentUserDefinedValue3
			JobComponentUserDefinedValue4
			JobComponentUserDefinedValue5
			JobTraffic
			AccountPayableProduction
			PurchaseOrderDetails
			JobTemplate
			CreativeBriefDetails
			InternetOrderDetails
			NewspaperOrderDetails
			OutOfHomeOrderDetails
			RadioOrderDetailLegacies
			TVOrderDetailLegacies
			MagazineOrderDetails
			AccountReceivables
			AlertAssignmentTemplate
			IncomeOnlys
			JobServiceFees
			MediaPlanDetailLevelLineTags
            Discount
            ModifiedDate
            ModifiedBy
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("JOB_NUMBER", Order:=0)>
        Public Property JobNumber() As Integer
		<Key>
		<Required>
        <Column("JOB_COMPONENT_NBR", Order:=1)>
        Public Property Number() As Short
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		Public Property AccountExecutiveEmployeeCode() As String
		<Column("JOB_COMP_DATE")>
		Public Property CreatedDate() As Nullable(Of Date)
		<Column("JOB_FIRST_USE_DATE")>
		Public Property DueDate() As Nullable(Of Date)
		<Column("START_DATE")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("CREATIVE_INSTR")>
		Public Property CreativeInstructions() As String
		<Required>
		<MaxLength(60)>
		<Column("JOB_COMP_DESC", TypeName:="varchar")>
		Public Property Description() As String
		<Column("JOB_COMP_COMMENTS")>
		Public Property Comment() As String
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
		<Column("JOB_COMP_BUDGET_AM")>
		Public Property BudgetAmount() As Nullable(Of Decimal)
		<Column("ESTIMATE_NUMBER")>
		Public Property EstimateNumber() As Nullable(Of Integer)
		<Column("EST_COMPONENT_NBR")>
		Public Property EstimateComponentNumber() As Nullable(Of Short)
		<Column("JOB_DEL_INSTRUCT")>
		Public Property DeleteInstruction() As String
		<MaxLength(10)>
		<Column("JT_CODE", TypeName:="varchar")>
		Public Property JobTypeCode() As String
		<Column("NOBILL_FLAG")>
		Public Property IsNonbillable() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("EMAIL_GR_CODE", TypeName:="varchar")>
		Public Property AlertGroupCode() As String
		<MaxLength(10)>
		<Column("MARKET_CODE", TypeName:="varchar")>
		Public Property MarketCode() As String
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("JOB_TMPLT_CODE", TypeName:="varchar")>
		Public Property JobTemplateCode() As String
		<Required>
		<MaxLength(1)>
		<Column("JOB_SPEC_TYPE", TypeName:="varchar")>
		Public Property JobSpecType() As String
		<Column("JOB_PROCESS_CONTRL")>
		Public Property JobProcessNumber() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("AD_NBR", TypeName:="varchar")>
		Public Property AdNumber() As String
		<MaxLength(30)>
		<Column("ACCT_NBR", TypeName:="varchar")>
		Public Property AccountNumber() As String
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentTeamCode() As String
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Nullable(Of Integer)
		<Column("SERVICE_FEE_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeTypeID() As Nullable(Of Integer)
		<MaxLength(6)>
		<Column("FISCAL_PERIOD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FiscalPeriodCode() As String
		<Column("TAX_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxFlag() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxCode() As String
		<MaxLength(6)>
		<Column("BLACKPLT_VER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BlackplateCode1() As String
		<MaxLength(6)>
		<Column("BLACKPLT_VER2_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BlackplateCode2() As String
		<MaxLength(10)>
		<Column("UDV1_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentUserDefinedValue1Code() As String
		<MaxLength(10)>
		<Column("UDV2_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentUserDefinedValue2Code() As String
		<MaxLength(10)>
		<Column("UDV3_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentUserDefinedValue3Code() As String
		<MaxLength(10)>
		<Column("UDV4_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentUserDefinedValue4Code() As String
		<MaxLength(10)>
		<Column("UDV5_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentUserDefinedValue5Code() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("JOB_MARKUP_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarkupPercent() As Nullable(Of Decimal)
		<Column("AB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAdvanceBilling() As Nullable(Of Short)
		<Column("ALRT_NOTIFY_HDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplateID() As Nullable(Of Integer)
		<Column("TRF_SCHEDULE_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TrafficScheduleBy() As Nullable(Of Short)
		<Column("TRF_SCHEDULE_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TrafficScheduleRequired() As Nullable(Of Short)
		<Column("JOB_BILL_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsJobBillHold() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("BILLING_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingUserCode() As String
		<Column("BA_BATCH_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalBatchID() As Nullable(Of Integer)
		<Column("SELECTED_BA_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SelectedBillingApprovalID() As Nullable(Of Integer)
		<Column("BCC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCommandCenterID() As Nullable(Of Integer)
		<Column("SERVICE_FEE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeFlag() As Nullable(Of Short)
		<Column("PRD_AB_INCOME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAdvancedBillingIncome() As Nullable(Of Short)
		<Column("MEDIA_BILL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaBillDate() As Nullable(Of Date)
        <Column("CS_PROJECT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ConceptShareProjectID() As Nullable(Of Integer)
		<Column("TRF_JOB_NUMBER")>
		Public Property TrafficJobNumber() As Nullable(Of Integer)
        <Column("TRF_JOB_COMPONENT_NBR")>
        Public Property TrafficJobComponentNumber() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("CLIENT_DISCOUNT_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDiscountCode() As String
        <Column("MODIFY_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Column("MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedBy() As String

        Public Overridable Property Job As Database.Entities.Job
        Public Overridable Property EmployeeNonTasks As ICollection(Of Database.Entities.EmployeeNonTask)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property JobComponentTasks As ICollection(Of Database.Entities.JobComponentTask)
        Public Overridable Property Ad As Database.Entities.Ad
        Public Overridable Property Account As Database.Entities.Account
        <ForeignKey("ClientContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact
        Public Overridable Property ServiceFeeType As Database.Entities.ServiceFeeType
        Public Overridable Property FiscalPeriod As Database.Entities.FiscalPeriod
        Public Overridable Property Market As Database.Entities.Market
        <ForeignKey("BlackplateCode2")>
        Public Overridable Property Blackplate2 As Database.Entities.Blackplate
        <ForeignKey("BlackplateCode1")>
        Public Overridable Property Blackplate1 As Database.Entities.Blackplate
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property JobComponentUserDefinedValue1 As Database.Entities.JobComponentUserDefinedValue1
        Public Overridable Property JobComponentUserDefinedValue2 As Database.Entities.JobComponentUserDefinedValue2
        Public Overridable Property JobComponentUserDefinedValue3 As Database.Entities.JobComponentUserDefinedValue3
        Public Overridable Property JobComponentUserDefinedValue4 As Database.Entities.JobComponentUserDefinedValue4
        Public Overridable Property JobComponentUserDefinedValue5 As Database.Entities.JobComponentUserDefinedValue5
        Public Overridable Property AccountPayableProduction As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property PurchaseOrderDetails As ICollection(Of Database.Entities.PurchaseOrderDetail)
        Public Overridable Property JobTemplate As Database.Entities.JobTemplate
        Public Overridable Property CreativeBriefDetails As ICollection(Of Database.Entities.CreativeBriefDetail)
        Public Overridable Property InternetOrderDetails As ICollection(Of Database.Entities.InternetOrderDetail)
        Public Overridable Property NewspaperOrderDetails As ICollection(Of Database.Entities.NewspaperOrderDetail)
        Public Overridable Property OutOfHomeOrderDetails As ICollection(Of Database.Entities.OutOfHomeOrderDetail)
        Public Overridable Property RadioOrderDetailLegacies As ICollection(Of Database.Entities.RadioOrderDetailLegacy)
        Public Overridable Property TVOrderDetailLegacies As ICollection(Of Database.Entities.TVOrderDetailLegacy)
        Public Overridable Property MagazineOrderDetails As ICollection(Of Database.Entities.MagazineOrderDetail)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property AlertAssignmentTemplate As Database.Entities.AlertAssignmentTemplate
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)
        Public Overridable Property JobServiceFees As ICollection(Of Database.Entities.JobServiceFee)
		Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property EstimateApproval As Database.Views.EstimateApproval
        Public Overridable Property ClientDiscount As Database.Entities.ClientDiscount

#End Region

#Region " Methods "

        Public Shadows Function ToString(ByVal WithJobDetails As Boolean, ByVal WithDescription As Boolean) As String

            If WithJobDetails Then

                If WithDescription Then

                    ToString = CStr(Me.Job.ToString(True) & " | " & AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 3, "0", True, True) & " - " & Me.Description).Trim

                Else

                    ToString = CStr(Me.Job.ToString(False) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 3, "0", True, True)).Trim

                End If

            Else

                If WithDescription Then

                    ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 3, "0", True, True) & " - " & Me.Description).Trim

                Else

                    ToString = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(Me.Number, 3, "0", True, True)).Trim

                End If

            End If

        End Function

#End Region

	End Class

End Namespace
