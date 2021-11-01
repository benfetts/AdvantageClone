Namespace Database.Entities

	<Table("ATB_REV")>
	Public Class MediaATBRevision
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			RevisionID
			ATBNumber
			Description
			RevisionNumber
			DateRequested
			CampaignID
			CampaignStartDate
			CampaignEndDate
			ClientBudget
			Comments
			BuyGrossOrNetFlag
			SalesClassCode
			BillingComments
			BillingDate
			ClientPO
			CommissionOnlyFlag
			BillingMethod
			CreatedByUserCode
			ModifiedByUserCode
			CreatedDate
			ModifiedDate
			ApprovedByUserCode
			ApprovedDate
			ApprovalFlag
			NetCalculationOption
			MediaATB
			Campaign
			MediaATBRevisionDetails
			SalesClass

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ATB_REV_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionID() As Integer
		<Required>
		<Column("ATB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ATBNumber() As Integer
		<Required>
		<MaxLength(100)>
		<Column("ATB_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Integer
		<Column("REQ_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateRequested() As Nullable(Of Date)
		<Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignID() As Nullable(Of Integer)
		<Column("CMP_START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Beginning Date")>
		Public Property CampaignStartDate() As Nullable(Of Date)
		<Column("CMP_END_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ending Date")>
		Public Property CampaignEndDate() As Nullable(Of Date)
		<Column("CMP_CL_BUDGET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(18, 2)>
		Public Property ClientBudget() As Nullable(Of Decimal)
		<Column("ATB_COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<Column("ATB_BUY_GROSS_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BuyGrossOrNetFlag() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property SalesClassCode() As String
		<Column("BILL_COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingComments() As String
		<Column("BILL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingDate() As Nullable(Of Date)
		<MaxLength(25)>
		<Column("CL_PO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientPO() As String
		<Column("COMM_ONLY_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommissionOnlyFlag() As Nullable(Of Boolean)
		<Column("BILLING_METHOD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingMethod() As Nullable(Of Short)
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("APPROVED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedByUserCode() As String
		<Column("APPROVED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedDate() As Nullable(Of Date)
		<Column("APPROVAL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovalFlag() As Nullable(Of Short)
		<Column("NET_CALC_OPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetCalculationOption() As Nullable(Of Short)

        <ForeignKey("ATBNumber")>
        Public Overridable Property MediaATB As Database.Entities.MediaATB
        Public Overridable Property Campaign As Database.Entities.Campaign
        Public Overridable Property MediaATBRevisionDetails As ICollection(Of Database.Entities.MediaATBRevisionDetail)
        Public Overridable Property SalesClass As Database.Entities.SalesClass

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.RevisionID.ToString

        End Function

#End Region

	End Class

End Namespace
