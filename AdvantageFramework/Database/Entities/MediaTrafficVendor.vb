Namespace Database.Entities

    <Table("MEDIA_TRAFFIC_VENDOR")>
    Public Class MediaTrafficVendor
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficCreativeGroupID
            VendorCode
            AlertID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_VENDOR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficRevisionID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Column("ALERT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Nullable(Of Integer)

        <ForeignKey("MediaTrafficRevisionID")>
        Public Overridable Property MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision

        <ForeignKey("VendorCode")>
        Public Overridable Property Vendor As AdvantageFramework.Database.Entities.Vendor

        Public Overridable Property MediaTrafficVendorStatuses As ICollection(Of AdvantageFramework.Database.Entities.MediaTrafficVendorStatus)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
