Namespace Database.Entities

	<Table("VN_PRICING")>
	Public Class VendorPricing
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			VendorCode
			JobTypeCode
			Description
			Rate
			Notes
			CreatedBy
			DateCreated
			JobType
			Vendor

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<DatabaseGenerated(DatabaseGeneratedOption.None)>
		<Required>
		<Column("VN_PRICING_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property VendorCode() As String
		<MaxLength(10)>
		<Column("JT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobTypeCode() As String
		<MaxLength(60)>
		<Column("VN_PRICING_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description/Quantity")>
		Public Property Description() As String
		<Column("VN_PRICING_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="###,##0.##0", CustomColumnCaption:="Unit - Rate")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 3)>
        Public Property Rate() As Nullable(Of Decimal)
		<MaxLength(254)>
		<Column("VN_PRICING_NOTES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Comments")>
		Public Property Notes() As String
		<MaxLength(100)>
		<Column("CREATE_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreatedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DateCreated() As Nullable(Of Date)

        Public Overridable Property JobType As Database.Entities.JobType
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
