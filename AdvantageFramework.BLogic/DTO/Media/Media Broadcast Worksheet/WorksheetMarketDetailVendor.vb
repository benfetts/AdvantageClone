Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetailVendor
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            HasOrders
            Selected
            VendorCode
            VendorName
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property HasOrders() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.VendorCode)>
        Public Property VendorCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property VendorName() As String
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketDescription() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCategory() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.HasOrders = False
            Me.Selected = False
            Me.VendorCode = String.Empty
            Me.VendorName = String.Empty
            Me.MarketCode = String.Empty
            Me.MarketDescription = String.Empty
            Me.VendorCategory = String.Empty
            Me.IsInactive = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.VendorCode

        End Function

#End Region

    End Class

End Namespace
