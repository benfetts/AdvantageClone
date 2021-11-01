Namespace DTO

    Public Class VendorStation
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            VendorCategory
            MarketCode
            IsCableSystem
            NCCTVSyscodeID
            NielsenTVStationCode
            NielsenRadioStationComboID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Name() As String
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCategory() As String
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
        Public Property MarketCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsCableSystem() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.NCCTVSyscode, CustomColumnCaption:="Cable Syscode")>
        Public Property NCCTVSyscodeID() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenTVStation, CustomColumnCaption:="TV Station")>
        Public Property NielsenTVStationCode() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenRadioStation, CustomColumnCaption:="Radio Station")>
        Public Property NielsenRadioStationComboID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public Property Market As AdvantageFramework.Database.Entities.Market

#End Region

#Region " Methods "

        Public Sub New(Vendor As AdvantageFramework.Database.Entities.Vendor)

            Me.Code = Vendor.Code
            Me.Name = Vendor.Name
            Me.VendorCategory = Vendor.VendorCategory
            Me.MarketCode = Vendor.MarketCode
            Me.NCCTVSyscodeID = Vendor.NCCTVSyscodeID
            Me.IsCableSystem = Vendor.IsCableSystem
            Me.NielsenTVStationCode = Vendor.NielsenTVStationCode
            Me.NielsenRadioStationComboID = Vendor.NielsenRadioStationComboID
            Me.Market = Vendor.Market

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
