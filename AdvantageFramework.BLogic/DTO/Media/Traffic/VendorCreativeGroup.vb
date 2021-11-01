Namespace DTO.Media.Traffic

    Public Class VendorCreativeGroup
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficVendorID
            MediaTrafficCreativeGroupID
            CableNetworkStationCodes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficVendorID() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Creative Group", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaTrafficCreativeGroup)>
        Public Property MediaTrafficCreativeGroupID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CableNetworkStationCodes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup)

            Me.ID = MediaTrafficVendorCreativeGroup.ID
            Me.MediaTrafficVendorID = MediaTrafficVendorCreativeGroup.MediaTrafficVendorID
            Me.MediaTrafficCreativeGroupID = MediaTrafficVendorCreativeGroup.MediaTrafficCreativeGroupID
            Me.CableNetworkStationCodes = MediaTrafficVendorCreativeGroup.CableNetworkStationCodes
            Me.VendorCode = MediaTrafficVendorCreativeGroup.MediaTrafficVendor.VendorCode

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup)

            MediaTrafficVendorCreativeGroup.MediaTrafficVendorID = Me.MediaTrafficVendorID
            MediaTrafficVendorCreativeGroup.MediaTrafficCreativeGroupID = Me.MediaTrafficCreativeGroupID
            MediaTrafficVendorCreativeGroup.CableNetworkStationCodes = Me.CableNetworkStationCodes

        End Sub

#End Region

    End Class

End Namespace
