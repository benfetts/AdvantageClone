Namespace DTO.Maintenance.Accounting.Vendor

    Public Class VendorComboRadioStation
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            NielsenRadioStationID
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property NielsenRadioStationID() As Integer
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property MarketDescription() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property VendorCategory() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.VendorCode = String.Empty
            Me.NielsenRadioStationID = 0
            Me.Name = String.Empty
            Me.MarketCode = String.Empty
            Me.MarketDescription = String.Empty
            Me.VendorCategory = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(VendorComboRadioStation As AdvantageFramework.Database.Entities.VendorComboRadioStation, NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

            Me.ID = VendorComboRadioStation.ID
            Me.VendorCode = VendorComboRadioStation.VendorCode
            Me.NielsenRadioStationID = NielsenRadioStation.ComboID
            Me.Name = NielsenRadioStation.Name
            Me.MarketCode = VendorComboRadioStation.Vendor.MarketCode
            Me.MarketDescription = If(VendorComboRadioStation.Vendor.Market IsNot Nothing, VendorComboRadioStation.Vendor.Market.Description, String.Empty)
            Me.VendorCategory = VendorComboRadioStation.Vendor.VendorCategory
            Me.IsInactive = If(VendorComboRadioStation.Vendor.ActiveFlag.GetValueOrDefault(0) = 0, True, False)

        End Sub
        Public Sub New(Vendor As AdvantageFramework.Database.Entities.Vendor, NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)

            Me.ID = 0
            Me.VendorCode = Vendor.Code
            Me.NielsenRadioStationID = NielsenRadioStation.ComboID
            Me.Name = NielsenRadioStation.Name
            Me.MarketCode = Vendor.MarketCode
            Me.MarketDescription = If(Vendor.Market IsNot Nothing, Vendor.Market.Description, String.Empty)
            Me.VendorCategory = Vendor.VendorCategory
            Me.IsInactive = If(Vendor.ActiveFlag.GetValueOrDefault(0) = 0, True, False)

        End Sub
        Public Sub SaveToEntity(VendorComboRadioStation As AdvantageFramework.Database.Entities.VendorComboRadioStation)

            VendorComboRadioStation.VendorCode = Me.VendorCode
            VendorComboRadioStation.NielsenRadioStationID = Me.NielsenRadioStationID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.VendorCode & " - - " & Me.NielsenRadioStationID & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
