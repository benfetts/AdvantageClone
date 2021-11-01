Namespace Database.Entities

	<Table("VENDOR_INVOICE_CATEGORY")>
	Public Class VendorInvoiceCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
			Vendors
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("VENDOR_INVOICE_CATEGORY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String

		Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID & " - " & Me.Name

		End Function

#End Region

	End Class

End Namespace
