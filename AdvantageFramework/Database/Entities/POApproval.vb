Namespace Database.Entities

	<Table("PO_APPROVAL")>
	Public Class POApproval
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			POApprovalRuleCode
			POApprovalRuleDetailSequenceNumber
			POApprovalRuleEmployeeID
			IsApproved
			UserCode
			[Date]
			Notes
			POApprovalRuleDetail
			POApprovalRuleEmployee
			PurchaseOrder

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("PO_NUMBER", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Number() As Integer
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PO_APPR_RULE_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POApprovalRuleCode() As String
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POApprovalRuleDetailSequenceNumber() As Short
		<Column("PO_APPR_RULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POApprovalRuleEmployeeID() As Nullable(Of Integer)
		<Column("PO_APPROVAL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsApproved() As Nullable(Of Boolean)
		<MaxLength(100)>
		<Column("PO_APPROVAL_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("PO_APPROVAL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property [Date]() As Nullable(Of Date)
		<Column("PO_APPROVAL_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Notes() As String

        <ForeignKey("POApprovalRuleCode, POApprovalRuleDetailSequenceNumber")>
        Public Overridable Property POApprovalRuleDetail As Database.Entities.PurchaseOrderApprovalRuleDetail
        <ForeignKey("POApprovalRuleEmployeeID")>
        Public Overridable Property POApprovalRuleEmployee As Database.Entities.PurchaseOrderApprovalRuleEmployee
        Public Overridable Property PurchaseOrder As Database.Entities.PurchaseOrder

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number

        End Function

#End Region

	End Class

End Namespace
