Namespace DTO

	Public Class Vendor
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Code
			Name
			MarketCode
			MarketDescription
			VendorCategory
			IsInactive
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<MaxLength(6)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(40)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(10)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCode() As String
		<MaxLength(40)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketDescription() As String
		<MaxLength(1)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCategory() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.Code = String.Empty
			Me.Name = String.Empty
			Me.MarketCode = String.Empty
			Me.MarketDescription = String.Empty
			Me.VendorCategory = String.Empty
			Me.IsInactive = False

		End Sub
		Public Sub New(Vendor As AdvantageFramework.Database.Entities.Vendor)

			Me.Code = Vendor.Code
			Me.Name = Vendor.Name
			Me.MarketCode = Vendor.MarketCode
			Me.MarketDescription = If(Vendor.Market IsNot Nothing, Vendor.Market.Description, String.Empty)
			Me.VendorCategory = Vendor.VendorCategory
			Me.IsInactive = If(Vendor.ActiveFlag.GetValueOrDefault(0) = 0, True, False)

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Name

		End Function

#End Region

	End Class

End Namespace
