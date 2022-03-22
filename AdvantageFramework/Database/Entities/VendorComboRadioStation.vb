Namespace Database.Entities

    <Table("VENDOR_COMBO_RADIO_STATION")>
    Public Class VendorComboRadioStation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            NielsenRadioStationID
            Vendor
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("VENDOR_COMBO_RADIO_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorCode() As String
        <Required>
        <Column("NIELSEN_RADIO_STATION_COMBO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenRadioStationID() As Integer

        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
