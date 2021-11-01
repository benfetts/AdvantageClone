Namespace Database.Entities

    <Table("MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP")>
    Public Class MediaTrafficVendorCreativeGroup
        Inherits BaseClasses.Entity

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

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_VENDOR_CREATIVE_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_VENDOR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficVendorID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_CREATIVE_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficCreativeGroupID() As Integer
        <Column("CABLE_NETWORK_STATION_CODES", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkStationCodes() As String

        <ForeignKey("MediaTrafficVendorID")>
        Public Overridable Property MediaTrafficVendor As Database.Entities.MediaTrafficVendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
