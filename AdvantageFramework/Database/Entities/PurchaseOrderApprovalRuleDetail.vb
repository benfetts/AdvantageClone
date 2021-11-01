Namespace Database.Entities

	<Table("PO_APPR_RULE_DTL")>
	Public Class PurchaseOrderApprovalRuleDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			PurchaseOrderApprovalRuleCode
			SequenceNumber
			ApprovalMinimum
			ApprovalMaximum
			IsInactive
			PurchaseOrderApprovalRule
			PurchaseOrderApprovalRuleEmployees
			POApprovals

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PO_APPR_RULE_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode)>
		Public Property PurchaseOrderApprovalRuleCode() As String
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property SequenceNumber() As Short
		<Column("APPR_MIN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ApprovalMinimum() As Nullable(Of Decimal)
		<Column("APPR_MAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ApprovalMaximum() As Nullable(Of Decimal)
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property PurchaseOrderApprovalRule As Database.Entities.PurchaseOrderApprovalRule
        Public Overridable Property PurchaseOrderApprovalRuleEmployees As ICollection(Of Database.Entities.PurchaseOrderApprovalRuleEmployee)
        Public Overridable Property POApprovals As ICollection(Of Database.Entities.POApproval)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.PurchaseOrderApprovalRuleCode

        End Function

#End Region

	End Class

End Namespace
