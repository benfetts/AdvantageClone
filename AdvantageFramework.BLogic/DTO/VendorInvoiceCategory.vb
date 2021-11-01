Namespace DTO

	Public Class VendorInvoiceCategory
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.Name = String.Empty

		End Sub
		Public Sub New(VendorInvoiceCategory As AdvantageFramework.Database.Entities.VendorInvoiceCategory)

			Me.ID = VendorInvoiceCategory.ID
			Me.Name = VendorInvoiceCategory.Name

		End Sub
		Public Sub SaveToEntity(ByRef VendorInvoiceCategory As AdvantageFramework.Database.Entities.VendorInvoiceCategory)

			VendorInvoiceCategory.ID = Me.ID
			VendorInvoiceCategory.Name = Me.Name

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID & " - " & Me.Name

		End Function

#End Region

	End Class

End Namespace
