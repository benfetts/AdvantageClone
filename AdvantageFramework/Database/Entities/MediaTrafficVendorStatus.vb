Namespace Database.Entities

    <Table("MEDIA_TRAFFIC_VENDOR_STATUS")>
    Public Class MediaTrafficVendorStatus
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficVendorID
            MediaTrafficStatusID
            CreatedDate
            UserCreated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_VENDOR_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_VENDOR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficVendorID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficStatusID() As AdvantageFramework.Database.Entities.MediaTrafficStatusID
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCreated() As String

        <ForeignKey("MediaTrafficVendorID")>
        Public Overridable Property MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor

        <ForeignKey("MediaTrafficStatusID")>
        Public Overridable Property MediaTrafficStatus As AdvantageFramework.Database.Entities.MediaTrafficStatus

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
