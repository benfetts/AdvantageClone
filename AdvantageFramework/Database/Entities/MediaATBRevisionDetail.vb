Namespace Database.Entities

	<Table("ATB_REV_DTL")>
	Public Class MediaATBRevisionDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			DetailID
			RevisionID
			VendorCode
			Quantity
			Rate
			CPMFlag
			Amount
			MarkupPercent
			MarkupAmount
			NetChargePercent
			NetChargeAmount
			NetSpend
			LineTotal
			CostType
			AdServingForDetailID
			GrossBudget
			MediaATBRevision
			Vendor

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ATB_REV_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailID() As Integer
		<Required>
		<Column("ATB_REV_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionID() As Integer
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorCode() As String
		<Column("QTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Quantity() As Nullable(Of Integer)
		<Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<Column("CPM_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CPMFlag() As Nullable(Of Boolean)
		<Column("EXT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property Amount() As Nullable(Of Decimal)
		<Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(8, 4)>
        Public Property MarkupPercent() As Nullable(Of Decimal)
		<Column("MARKUP_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property MarkupAmount() As Nullable(Of Decimal)
		<Column("NET_CHARGE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(8, 4)>
        Public Property NetChargePercent() As Nullable(Of Decimal)
		<Column("NET_CHARGE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property NetChargeAmount() As Nullable(Of Decimal)
		<Column("NET_SPEND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property NetSpend() As Nullable(Of Decimal)
		<Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property LineTotal() As Nullable(Of Decimal)
		<MaxLength(3)>
		<Column("COST_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostType() As String
		<Column("AD_SRV_ATB_REV_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdServingForDetailID() As Nullable(Of Integer)
		<Column("GROSS_BUDGET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property GrossBudget() As Nullable(Of Decimal)

        <ForeignKey("RevisionID")>
        Public Overridable Property MediaATBRevision As Database.Entities.MediaATBRevision
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DetailID.ToString

        End Function

#End Region

	End Class

End Namespace
